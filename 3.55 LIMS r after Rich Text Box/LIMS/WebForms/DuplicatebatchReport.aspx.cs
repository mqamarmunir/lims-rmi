using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Globalization;
using System.Data;
using CrystalDecisions.Shared;


public partial class LIMS_WebForms_DuplicatebatchReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "130";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();

                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                txtDF.Text = System.DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
                txtDT.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

                FillGV();
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }
    }
    private void FillGV()
    {
        clsBLCourierbatches objbatches = new clsBLCourierbatches();
        objbatches.DateFrom = txtDF.Text.Trim();
        objbatches.DateTo = DateTime.Parse(txtDT.Text.Trim(), new CultureInfo("ur-pk", false)).AddDays(1).ToString("dd/MM/yyyy");

        DataView dv_batches = objbatches.GetAll(2);
        if (dv_batches.Count > 0)
        {
            gvbatches.DataSource = dv_batches;
            gvbatches.DataBind();
        }
        else
        {
            Response.Write("<script language='javascript'>alert('No Batches Found in these days.')");

        }
    }

    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        FillGV();
    }
   
    protected void lnkbatchno_Click(object sender, EventArgs e)
    {
        LinkButton senderbutton = sender as LinkButton;
        string batchno = senderbutton.Text.Trim();
        string _SelectionFormula = "{Command.batchno}='" + batchno + "'";
        printReport(_SelectionFormula, null, "testout");
        //Session["SelectionFormula"] = "{Command.batchno}='" + batchno + "'";
        //Session[""]
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
