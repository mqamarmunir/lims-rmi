using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using CrystalDecisions.Shared;
using System.Globalization;
using System.Data;


public partial class LIMS_WebForms_wfrmTestCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "128";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                txtFromDate.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txtToDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                
            }
        }

        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        string selectionFormula = "";
        string[] parameter = new string[2];
        if (!txtFromDate.Text.Equals(""))
        {
            if (!txtFromDate.Text.Equals(""))
            {
                selectionFormula = @"{ LS_VTESTORDERED.ENTRYDATETIME } in  " + 
                    "DateTime(" + DateTime.Parse(txtFromDate.Text, new CultureInfo("ur-pk", false)).ToString("yyyy, MM, dd, 00, 00, 00 ") + ")" + 
                    " to DateTime(" + DateTime.Parse(txtToDate.Text, new CultureInfo("ur-pk", false)).ToString("yyyy, MM, dd, 23, 59, 59 ") + ")";
                parameter[0] = txtFromDate.Text;
                parameter[1] = txtToDate.Text;
            }
            
        }

        printReport(selectionFormula, parameter, "lms_Ordered_Tests");
        
        
        
    }

    private void printReport(string _SelectionFormula, string[] parameter, string ReportName)
    {

        CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath(@"~/LIMS/reports/" + ReportName + ".rpt");
            // string strRUrl = Server.MapPath(@"~/LIMS/reports/TestResult.rpt");
            Session["ReportUrl"] = strRUrl;


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
                        doc.SetParameterValue("SDate", parameter[0]);
                        doc.SetParameterValue("EDate", parameter[1]);
                }
            
            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"~/LIMS/reports/pdf/" + ReportName + ".pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();
            //Response.Redirect(strRUrl + "_" + Session["loginid"].ToString() + ".pdf");

            ScriptManager.RegisterStartupScript(this, typeof(Page), "lms_Ordered_Tests", @"<script>window.open('../reports/pdf/" + ReportName + ".pdf');</script>", false);



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