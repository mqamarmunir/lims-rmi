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


namespace HMIS.LIMS.reports
{
	/// <summary>
	/// Summary description for wfrmReceipt.
	/// </summary>
	public partial class wfrmReceipt : System.Web.UI.Page
	{
		private static string fromDate = "";
		private static string toDate   = "";
		private static string FilterString = "";
		private static string mReportReference="";
		private static string [,] pdfSetting;
		private static string Message = "";
		
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
				// Put user code to initialize the page here
				string strRUrl = Server.MapPath(@"../reports/"+mReportReference+".rpt");
				//Response.Write("<script language ='javascript'>alert("+strRUrl+");</script>");
				Session["ReportUrl"] = strRUrl;
				CrystalDecisions.CrystalReports.Engine.ReportDocument Report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				int i;
				int j;

				Report.Load(strRUrl);	
				j = Report.Database.Tables.Count-1;
				////
				string userName = "";
				string pwd = "";
				string serverName="";
				string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
				string [] info = strConn.Split(';');
						
				userName = ((info[1].Split('='))[1]).Trim();
				pwd	=((info[3].Split('='))[1]).Trim();
				serverName = ((info[2].Split('='))[1]).Trim();	
				/*// for testing ///
				userName = "whims";
				pwd	="whims";
				serverName = "hims";	*/

				
				for (i=0; i <= j ;i++)   
				{
					TableLogOnInfo logOnInfo = new TableLogOnInfo();
					logOnInfo = Report.Database.Tables[i].LogOnInfo;
					ConnectionInfo connectionInfo = new ConnectionInfo ();
					
					connectionInfo = logOnInfo.ConnectionInfo;
					connectionInfo.ServerName =serverName;
					connectionInfo.Password = pwd;
					connectionInfo.UserID = userName;
					Report.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
				}
			
				if(FilterString !="")
					Report.RecordSelectionFormula = FilterString;
				
				FilterString = Report.RecordSelectionFormula;
				
				clsBLReport report = new clsBLReport();

				//DataView dvPreferenceTable = ObjPreferenceTable.rsGetSingle("PRG-002-01");
				// getting report information
				//				string reportID = Request.QueryString.Get("reportID").ToString();
				
				//DataView dvPreferenceTable = report.GetReport(mReportReference);
				
				
				
				//doc.SetParameterValue("Heading1", dvPreferenceTable.Table.Rows[0]["ReportTitle"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ReportTitle"].ToString());
				//doc.SetParameterValue("Heading2", dvPreferenceTable.Table.Rows[0]["ReportSubTitle1"].ToString() == null ? "" : dvPreferenceTable.Table.Rows[0]["ReportSubTitle1"].ToString());
				Report.SetParameterValue("Heading1", "DEPARTMENT OF PATHOLOGY");
				Report.SetParameterValue("Heading2", "CMH QUETTA ");

				Report.SetParameterValue("Heading3", "Receipt");
				Report.SetParameterValue("ReportName", "");
				Report.SetParameterValue("TreesFooter1", "");
				Report.SetParameterValue("TreesFooter2", "");
				Report.SetParameterValue("ClientWebAddress", "");			
				
				
				MemoryStream oStream; // using System.IO

				oStream = (MemoryStream)
					Report.ExportToStream(
					CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
				Response.Clear();
				Response.Buffer= true;
				Response.ContentType = "application/pdf"; 
				Response.BinaryWrite(oStream.ToArray());
				Response.End();
				Report.Close();			

				//Response.Redirect(@"../reports/clsReportPrint.aspx"); 				
			}
			catch(Exception ex)
			{
				Message = ex.Message+" "+mReportReference+" "+FilterString;
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
	}
}
