using System;
using System.Configuration;
using System.IO; 
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using LS_BusinessLayer;
using System.Net.Mail;



namespace HMIS.LIMS.reports
{
	/// <summary>
	/// Summary description for GeneralReports.
	/// </summary>
	public partial class GeneralReports : System.Web.UI.Page
	{
		private static string fromDate = "";
		private static string toDate   = "";
		private static string FilterString = "";
		private static string mReportReference="";
		private static string [,] pdfSetting;
		private static string Message = "";
        ReportDocument doc = null;

		# region "Properties"

		public static string[,] PdfSetting
		{
			get
			{
				return pdfSetting ;
			}
			set
			{
				pdfSetting = value;
			}
		}

		public static string ReportReference
		{
			get
			{
				return mReportReference;
			}
			set
			{
				mReportReference = value;
			}
		}

		public static string mFromDate
		{
			get
			{
				return fromDate;
			}
			set
			{
				fromDate=value;
			}
		}

		public static string mToDate
		{
			get
			{
				return toDate;
			}
			set
			{
				toDate = value;
			}
		}

		public static string mFilterString
		{
			get
			{
				return FilterString;
			}
			set
			{
				FilterString = value;
			}
		}

		public static string mMessage
		{
			get
			{
				return Message;
			}
			set
			{
				//
			}
		}

		# endregion

		protected void Page_Load(object sender, System.EventArgs e)
		{
            try
            {
                try
                {
                    if (Request.QueryString["reportID"].ToString().Equals("LMS-001-11"))
                    { mReportReference = Request.QueryString["reportID"].ToString(); }
                }
                catch { }
                // Put user code to initialize the page here
                string strRUrl = Server.MapPath(@"../reports/" + mReportReference + ".rpt");
                //Response.Write("<script language ='javascript'>alert("+strRUrl+");</script>");
                Session["ReportUrl"] = strRUrl;
                doc = new ReportDocument();
                //CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                int i;
                int j;
                if (Request.QueryString["reportID"] != null)
                {
                    if (Request.QueryString["reportID"].ToString().Equals("LMS-001-11"))
                    {
                        if (Request.QueryString["MSerialNo"] != null && Request.QueryString["ProcessId"] != null)
                        {
                            if (Request.QueryString["ProcessId"].ToString().Equals("0006") || Request.QueryString["ProcessId"].ToString().Equals("0007"))
                            {
                                FilterString = "{LS_VGENERALREPORT2.MSerialNo} in [" + Request.QueryString["MSerialNo"].ToString() + "] and {LS_VGENERALREPORT2.PROCESSID} in ['0007','0006']";
                            }
                            else
                            {
                                Response.Write("<script language='javascript'>alert('Some Required Results not Ready yet.');</script>");
                                return;
                            }
                        }
                        else
                        {
                            if (Request.QueryString["DSerialNo"] != null)
                            { 
                                FilterString = "{LS_VGENERALREPORT2.DSerialNo} in [" + Request.QueryString["DSerialNo"].ToString() + "]";
                                
                                
                            }

                        }
                    }
                }
                doc.Load(strRUrl);
                j = doc.Database.Tables.Count - 1;
                ////
                string userName = "";
                string pwd = "";
                string serverName = "";
                string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
                string[] info = strConn.Split(';');


                userName = ((info[1].Split('='))[1]).Trim();
                pwd = ((info[2].Split('='))[1]).Trim();
                serverName = ((info[3].Split('='))[1]).Trim();
                // for testing ///
                /*userName = "whims";
                pwd	="whims";
                serverName = "hims";	*/

                if (mReportReference.Equals("LMS-004-01"))
                {
                    SetLogonDetailsForReport(doc, serverName, "hims", userName, pwd, "");
                }
                else
                {
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
                }

                if (FilterString != "")
                    doc.RecordSelectionFormula = FilterString;

                FilterString = doc.RecordSelectionFormula;

                clsBLReport report = new clsBLReport();

                //DataView dvPreferenceTable = ObjPreferenceTable.rsGetSingle("PRG-002-01");
                // getting report information
                //string reportID = Request.QueryString.Get("reportID").ToString();

                DataView dvPreferenceTable = report.GetReport(mReportReference);
               // "Heading1"
               // "Heading2"
                doc.SetParameterValue("Heading1", dvPreferenceTable.Table.Rows[0]["ReportTitle"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ReportTitle"].ToString());
                doc.SetParameterValue("Heading2", dvPreferenceTable.Table.Rows[0]["ReportSubTitle1"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ReportSubTitle1"].ToString());

                try
                {
                    doc.SetParameterValue("Heading3", dvPreferenceTable.Table.Rows[0]["ReportSubTitle2"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ReportSubTitle2"].ToString());
                }
                catch { }

                try
                {
                    doc.SetParameterValue("ReportName", dvPreferenceTable.Table.Rows[0]["PageFooter"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["PageFooter"].ToString());
                }
                catch { }

                try
                {
                    doc.SetParameterValue("ClientWebAddress", dvPreferenceTable.Table.Rows[0]["ClientWebAddress"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ClientWebAddress"].ToString());
                }
                catch { }

                try
                {
                    doc.SetParameterValue("TreesFooter1", dvPreferenceTable.Table.Rows[0]["TreesFooter1"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["TreesFooter1"].ToString());
                }
                catch { }

                try
                {
                    doc.SetParameterValue("TreesFooter2", dvPreferenceTable.Table.Rows[0]["TreesFooter2"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["TreesFooter2"].ToString());
                }
                catch { }

                try
                {
                    doc.SetParameterValue("SDate", fromDate);
                }
                catch { }

                try
                {
                    doc.SetParameterValue("EDate", toDate);
                }
                catch { }
                try
                {
                    int k = 0;
                    if (pdfSetting != null)
                    {
                        for (k = 0; k < (pdfSetting.Length) / 2; k++)
                        {
                            doc.SetParameterValue(pdfSetting[k, 0], pdfSetting[k, 1]);
                        }
                    }
                }
                catch { }

                //CrystalReportViewer1.ReportSource = doc;
                //CrystalReportViewer1.RefreshReport();


                //MemoryStream oStream; // using System.IO

                //oStream = (MemoryStream)
                //doc.ExportToStream(
                //CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                //Response.Clear();
                //Response.Buffer = true;
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                //doc.Close();

                //Response.Redirect(@"../reports/clsReportPrint.aspx"); 		

                CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                string szFileName="";
                string concattime = System.DateTime.Now.ToString("ddMMyyhhmmsstt");
                string hourdeletefiles = System.DateTime.Now.AddHours(-1).ToString("ddMMyyhh");
                if (mReportReference.Equals("LMS-001-11"))
                {
                    szFileName = Server.MapPath(@"../reports/pdf/" + mReportReference + "_" + concattime  + "_" + Session["loginid"].ToString()+".pdf");
                }
                else
                {
                    szFileName = Server.MapPath(@"../reports/pdf/" + mReportReference + "_" + Session["loginid"].ToString() + ".pdf");
                }
                dfdoCustomers.DiskFileName = szFileName;
                doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;

                doc.ExportOptions.DestinationOptions = dfdoCustomers;
              
                doc.Export();
                //doc.Refresh();
                
                
                
           

                try
                {
                    string Email = Request.QueryString["Email"].ToString();
                    if (Email == "Y")
                    {
                        Response.Redirect("~/Lims/webforms/SentEmail.aspx?attachment=" + szFileName.Substring(szFileName.LastIndexOf(@"\")+1)+"&MSerialNo="+Request.QueryString["Mserialno"].ToString().Trim());
                        //clsBLEMailPreferences obj_Email = new clsBLEMailPreferences();
                        //DataView dv_EmailPreferences = obj_Email.GetAll(1);
                        //if (dv_EmailPreferences.Count > 0)
                        //{
                        //    MailMessage message = new MailMessage();
                        //    message.From = new MailAddress(dv_EmailPreferences[0]["MessageFrom"].ToString());
                        //    message.To.Add(new MailAddress(Request.QueryString["EmailID"].ToString()));
                        //    //message.From = new MailAddress("qamar.nust@gmail.com");
                        //    //message.To.Add(new MailAddress("qamar.munir@seecs.edu.pk"));
                        //    message.Subject = "Lab Report";
                        //    message.Body = "Attention:<br /> Your lab Report is enclosed; Herewith<br /><br />Note:<br />This is Computer generated message.<br /><br />" + dv_EmailPreferences[0]["MESSAGEFOOTER"].ToString();
                        //    message.IsBodyHtml = true;
                        //    Attachment attach = new Attachment(Server.MapPath("~/LIMS/reports/pdf/LMS-001-01_" + Session["loginid"].ToString() + ".pdf"));
                        //    message.Attachments.Add(attach);

                        //    SmtpClient smtpclient = new SmtpClient();
                        //    smtpclient.Host = dv_EmailPreferences[0]["HOSTADDRESS"].ToString();
                        //    smtpclient.Credentials = new System.Net.NetworkCredential(dv_EmailPreferences[0]["UserName"].ToString(), dv_EmailPreferences[0]["Password"].ToString());
                        //    smtpclient.Send(message);
                        //    lblmsg.Text = "<font color='black'>Message Sent.</font>";
                        //}
                    }
                    else
                    {
                        // ScriptManager.RegisterStartupScript(this, typeof(Page), "Result Report", @"<script>window.open('pdf/"+mReportReference + "_" + Session["loginid"].ToString() + ".pdf');</script>", false);
                        if (mReportReference.Equals("LMS-001-11"))
                        {
                           
                            Response.Redirect(@"../reports/pdf/" + mReportReference + "_" + concattime  + "_" + Session["loginid"].ToString()+".pdf");
                            foreach (FileInfo f in new DirectoryInfo(Server.MapPath(@"../reports/pdf")).GetFiles("LMS-001-11_" + hourdeletefiles + "*.pdf"))
                            {
                                f.Delete();
                            }
                        }
                        else
                        {
                            Response.Redirect(@"../reports/pdf/" + mReportReference + "_" + Session["loginid"].ToString() + ".pdf");
                        }
                    }
                }
                catch (Exception ee)
                {
                    if (ee.ToString().Contains("Object reference not set to an instance of an object."))// == "object Reference not set to an instance of object")
                    {
                           //Response.Write("<script language='javascript'>this.close();</script>");
                       
                        if (mReportReference.Equals("LMS-001-11"))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Result Report", @"<script>window.open('pdf/" + mReportReference +"_"+concattime+ "_" + Session["loginid"].ToString() + ".pdf','_parent');</script>", false);
                            //Response.Write("<script language='javascript'>this.close();</script>");
                            //Response.Redirect(@"../reports/pdf/" + mReportReference + "_" + Session["loginid"].ToString() + "_" + concattime + ".pdf");
                            foreach (FileInfo f in new DirectoryInfo(Server.MapPath(@"../reports/pdf")).GetFiles("LMS-001-11_"+hourdeletefiles+"*.pdf"))
                            {
                                f.Delete();
                            }
                        }
                        else
                        {
                             Response.Redirect(@"../reports/pdf/" + mReportReference + "_" + Session["loginid"].ToString() + ".pdf");
                        }
                    }
                    else
                    {
                        lblmsg.Text = "<font color='red'>" + ee.ToString() + "</font>";
                    }
                }
                //Response.Redirect(@"../reports/pdf/" + mReportReference + "_" + Session["loginid"].ToString() + ".pdf"); 
            }
            catch (Exception ex)
            {
                Message = ex.Message + " " + mReportReference + " " + FilterString;
                lblmsg.Text = "<font color='red'>" + Message + ". Please try Again in few minutes.</font>";
            }
            finally 
            {
                doc.Close();
                doc.Dispose();
                GC.Collect();
            }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion

		private void SetLogonDetailsForReport(ReportDocument repDoc, string serverName, string databaseName, string userName, string password, string schemaName)
		{
			CrystalDecisions.CrystalReports.Engine.Database crDatabase = repDoc.Database;
			CrystalDecisions.CrystalReports.Engine.Tables crTables = crDatabase.Tables;			

			ConnectionInfo crConnInfo = new ConnectionInfo();
			crConnInfo.ServerName = serverName;
			//crConnInfo.DatabaseName = databaseName;
			crConnInfo.UserID = userName;
			crConnInfo.Password = password;

			//Loop through each table and set the connection info
			//Pass the connection info to the logoninfo object then apply the
			//logoninfo to the main report
			foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
			{
				TableLogOnInfo crLogOnInfo = crTable.LogOnInfo;
				crLogOnInfo.ConnectionInfo = crConnInfo;
				crTable.ApplyLogOnInfo(crLogOnInfo);

				//crTable.Location = schemaName + "." + crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
				crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
			}

			//Set the sections collection with report sections
			Sections crSections = repDoc.ReportDefinition.Sections;

			//Loop through each section and find all the report objects
			//Loop through all the report objects to find all subreport objects, then set the
			//logoninfo to the subreport
			foreach (Section crSection in crSections)
			{
				ReportObjects crReportObjects = crSection.ReportObjects;
				foreach (ReportObject crReportObject in crReportObjects)
				{
					if (crReportObject.Kind == ReportObjectKind.SubreportObject)
					{
						//If you find a subreport, typecast the reportobject to a subreport object
						SubreportObject crSubreportObject = (SubreportObject) crReportObject;

						//Open the subreport
						ReportDocument subRepDoc = crSubreportObject.OpenSubreport(crSubreportObject.SubreportName);

						crDatabase = subRepDoc.Database;
						crTables = crDatabase.Tables;

						//Loop through each table and set the connection info
						//Pass the connection info to the logoninfo object then apply the
						//logoninfo to the subreport

						foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables)
						{
							TableLogOnInfo crLogOnInfo = crTable.LogOnInfo;
							crLogOnInfo.ConnectionInfo = crConnInfo;
							crTable.ApplyLogOnInfo(crLogOnInfo);
							//crTable.Location = schemaName + "." + crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
							crTable.Location = crTable.Location.Substring(crTable.Location.LastIndexOf(".") + 1);
						}
					}
				}
			}
		}

        private void Page_UnLoad(object sender, EventArgs e)
        {
            try
            {
                doc.Close();
                doc.Dispose();
                doc = null;
                GC.Collect();
            }
            catch
            { }
        }
      
}
    
}