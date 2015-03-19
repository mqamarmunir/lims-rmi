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

public partial class LIMS_WebForms_wfrmConsultantreport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            clsBLUMatrix UMatrix = new clsBLUMatrix();
            UMatrix.ApplicationID = "001";
            UMatrix.FormID = "135";
            UMatrix.PersonID = Session["loginid"].ToString();
            DataView dvUMatrix = UMatrix.GetAll(1);
            string sRigth = dvUMatrix[0]["Rec"].ToString();
            if (sRigth.Equals("0"))
            {
                Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
            }
            else
            {

               
                    FillConsultant();
                
           }
        }
        //}
        //else
        //{
        //    Response.Write("<script language='javascript'>parent.location.href = '../../login.aspx'</script>");
        //}


       

    }
    private void FillConsultant()
    {
        PatientRegView vp = new PatientRegView();
        DataView dv = vp.GetAll(24);
        SComponents objComp = new SComponents();
        objComp.FillDropDownList(this.ddlconsultant, dv, "Completename", "personid");
        ListItem li = new ListItem("Select All", "-2");
        ddlconsultant.Items.Insert(1, li);
        
      
    }
    protected void rbtnsummary_CheckedChanged(object sender, EventArgs e)
    {
        rbtndetail.Checked = false;
    }
    protected void rbtndetail_CheckedChanged(object sender, EventArgs e)
    {
        rbtnsummary.Checked = false;
    }
    protected void imgClode_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        if(ddlconsultant.SelectedValue.ToString().Equals("-1"))
        {
            Response.Write("<script language='javascript'>alert('Please Select the Consultant!');</script>");
            return;
        }
        if (rbtnsummary.Checked == false && rbtndetail.Checked == false)
        {
            Response.Write("<script language='javascript'>alert('Please Select the Report Type!');</script>");
            return;
        }
        string fromdate = txtFromdate.Text.ToString();
        string todate = txtTodate.Text.ToString();
        string consultant = ddlconsultant.SelectedValue.ToString();
        string type="";
        if (rbtndetail.Checked)
            type = "false";
        else
            if (rbtnsummary.Checked)
                type = "true";
        string selectFormula = "Date({Command.ENTRYDATETIME}) in Date('" + DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + @"') to Date('" + DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + "')";
        if (!consultant.Equals("-2"))
        {
            selectFormula += " and {Command.ORIGINID}=" + consultant;

        }
        clsBLConsultants cs = new clsBLConsultants();
        cs.Fromdate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
        cs.Todate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1).ToString("dd/MM/yyyy"); 
        DataView dv = cs.GetAll(9);
        string[] para = { DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd"), DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd"), Session["UNUIDFORMATTED"].ToString(), type };
        printReport(selectFormula, para, "Consultantsummary",dv);
        
    }
    private void printReport(string _SelectionFormula, string[] parameter, string ReportName,DataView dv)
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
            doc.SetDataSource(dv);
            doc.Subreports[0].SetDataSource(dv);
            //string[] formula = _SelectionFormula.Split(';');
            doc.RecordSelectionFormula = _SelectionFormula;

            _SelectionFormula = doc.RecordSelectionFormula;
                //doc.Subreports[0].RecordSelectionFormula = formula[1];
                doc.SetParameterValue("printby", parameter[2]);
                doc.SetParameterValue("fromdate", parameter[0]);
                doc.SetParameterValue("todate", parameter[1]);
                doc.SetParameterValue("subsupress", parameter[3]);

            //}
         
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