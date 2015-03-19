using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;
using CrystalDecisions.Shared;
using System.Globalization;
public partial class LIMS_WebForms_wfrmSpecimentOutQueue : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated && Session["loginid"].ToString()!="")
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "126";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
               // string sRigth = dvUMatrix[0]["Rec"].ToString();
               // if (sRigth.Equals("0"))
               // {
                 //   Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
               // }
                //FillDDLSubDepartment();
                txtFromDate.Text = System.DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
                txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                FillGV();
            }
        }

        else
        {
            Response.Redirect("~/login.aspx");
        }


    }
    private void FillGV()
    {
        clsBlSpecimenOutQueue objOq = new clsBlSpecimenOutQueue();
        objOq.FromDate = txtFromDate.Text;
        objOq.ToDate = DateTime.Parse(txtToDate.Text,new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
        DataView dv_orgs = objOq.GetAll(1);
        if (dv_orgs.Count > 0)
        {
            gvExtOrganizations.Visible = true;
            gvExtOrganizations.DataSource = dv_orgs;
            gvExtOrganizations.DataBind();
        }
        else
        {
            gvExtOrganizations.Visible = false;
            Response.Write("<script language='javascript'>alert('No Pending Specimen in these days.');</script>");
        }

        //clsBlSpecimenLife obj_life = new clsBlSpecimenLife();
        //DataView dv_Life = obj_life.GetAll(1);
        //obj_life = null;
        //if (dv_Life.Count > 0)
        //{
        //    gvSpecimenLife.DataSource = dv_Life;
        //    gvSpecimenLife.DataBind();
        //}
        //dv_Life.Dispose();

    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        FillGV();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void gvExtOrganizations_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int index = e.Row.RowIndex;
            GridView gv_tests = e.Row.FindControl("gvTests") as GridView;
            string organizationid = gvExtOrganizations.DataKeys[index].Value.ToString().Trim();
            clsBlSpecimenOutQueue objorganization = new clsBlSpecimenOutQueue();
            objorganization.OrgId = organizationid;
            objorganization.FromDate = txtFromDate.Text;
            objorganization.ToDate = DateTime.Parse(txtToDate.Text,new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
            DataView dv_tests = objorganization.GetAll(2);
            if (dv_tests.Count > 0)
            {
                
                gv_tests.DataSource = dv_tests;
                gv_tests.DataBind();
            }
            else
            {
                gv_tests.DataSource = "";
                gv_tests.DataBind();
            }

        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            clsBLCourierbatches objbatches = new clsBLCourierbatches();
            GridView gvTests = null;
            int count = 0;
            int count_checked = 0;
            string batch_no = "";
            string maxid = "";
            string errormessage = "";

            GridViewRow gvRow = ((Button)sender).Parent.Parent.Parent.Parent.Parent as GridViewRow;
            gvTests = gvExtOrganizations.Rows[gvRow.RowIndex].FindControl("gvtests") as GridView;
            objbatches.Extorgid = gvExtOrganizations.DataKeys[gvRow.RowIndex].Value.ToString().Trim();
            maxid = objbatches.GetAll(1)[0]["maxid"].ToString().Trim();
            batch_no = System.DateTime.Now.ToString("MM/yy") + "-" + gvExtOrganizations.DataKeys[gvRow.RowIndex].Value.ToString().Trim().PadLeft(3, '0') + "-" + maxid;

            objbatches.Batchno = batch_no;
            objbatches.Enteredby = Session["loginid"].ToString().Trim();
            objbatches.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objbatches.ClientID = System.Configuration.ConfigurationManager.AppSettings["clientid"].ToString().Trim();
            foreach (GridViewRow row in gvTests.Rows)
            {
                if (((CheckBox)gvTests.Rows[row.RowIndex].FindControl("gvChkSelect")).Checked == true)
                {
                    count_checked++;
                    objbatches.StrProcedureId = "002";
                    objbatches.CurrentProcessid = "0009";
                    objbatches.DSerialNo = gvTests.DataKeys[row.RowIndex].Values["DSerialno"].ToString().Trim();
                    objbatches.Mserialno = gvTests.DataKeys[row.RowIndex].Values["MSerialno"].ToString().Trim();
                    objbatches.Labid = gvTests.Rows[row.RowIndex].Cells[1].Text.Trim();
                    objbatches.Testid = gvTests.DataKeys[row.RowIndex].Values[0].ToString();
                    objbatches.Prno = gvTests.DataKeys[row.RowIndex].Values[1].ToString().Trim();
                    if (objbatches.Insert())
                    {
                        count++;
                    }
                    else
                    {
                        errormessage += objbatches.StrErrorMessage;
                    }
                }

            }
            if (count == count_checked)
            {
                errormessage = "All Records Inserted Successfully.";
                lblError.Text = "<font color='green'>" + errormessage + "</font>";
                clsBLReport report = new clsBLReport();
                //  report.
                FillGV();
                string _SelectionFormula = "{Command.BATCHNO} ='" + batch_no + "'";
                printReport(_SelectionFormula, null, "testout");
            }
            else
            {
                lblError.Text = errormessage;
            }
        }
        catch(Exception ee)
        {
            Response.Write(ee.ToString());
        }

        


    }
    private void printReport(string _SelectionFormula, string[] parameter, string ReportName)
    {

        CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"~/LIMS/reports/" + ReportName + ".rpt");
            // string strRUrl = Server.MapPath(@"~/LIMS/reports/TestResult.rpt");
           // Session["ReportUrl"] = strRUrl;


            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "whims";
            string pwd = "whims";
            string serverName = "HIMS";

            //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //string[] info = strConn.Split(';');
            //userName = ((info[1].Split('='))[1]).Trim();
            //pwd = ((info[3].Split('='))[1]).Trim();
            //serverName = ((info[2].Split('='))[1]).Trim();

            for (i = 0; i <= j; i++)
            {
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                logOnInfo = doc.Database.Tables[i].LogOnInfo;
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo = logOnInfo.ConnectionInfo;
                connectionInfo.ServerName = serverName;
                connectionInfo.Password = pwd;
                connectionInfo.UserID = userName;
                doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
            }
            if (ReportName == "EmpSpecimenCollected" || ReportName == "EmpTestEntered" || ReportName == "EmpTestVerified")
            {
                if (_SelectionFormula != "")
                {
                    //string[] formulas = _SelectionFormula.Split(';');
                    //string s1 = formulas[0].Trim();
                    //string s2 = formulas[1].Trim();
                    doc.RecordSelectionFormula = _SelectionFormula;
                    //doc.OpenSubreport("Test Details.rpt");
                    // doc.Subreports["Test Details"].RecordSelectionFormula = s2;
                    //doc.Subreports[0].RecordSelectionFormula = s2;
                    //doc.IsSubreport;
                    if (ReportName == "EmpSpecimenCollected")
                    {
                        doc.SetParameterValue("collectedon", parameter[0]);
                        doc.SetParameterValue("collectedonto", parameter[1]);
                        doc.SetParameterValue("starttime", parameter[2]);
                        doc.SetParameterValue("endtime", parameter[3]);
                    }
                    else
                    {
                        doc.SetParameterValue("fromdate", parameter[0]);
                        doc.SetParameterValue("todate", parameter[1]);
                        doc.SetParameterValue("starttime", parameter[2]);
                        doc.SetParameterValue("endtime", parameter[3]);
                    }

                }
            }
            else
            {
                doc.RecordSelectionFormula = _SelectionFormula;

                _SelectionFormula = doc.RecordSelectionFormula;

            }
            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"~/LIMS/reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();
            //Response.Redirect(strRUrl + "_" + Session["loginid"].ToString() + ".pdf");

            ScriptManager.RegisterStartupScript(this, typeof(Page), "EmpTestEntered", @"<script>window.open('../reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf');</script>", false);



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
        finally
        {
            doc.Close();
            doc.Dispose();
            GC.Collect();
        }



    }
}