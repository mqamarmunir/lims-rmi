using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;

using System.Net.Mail;


namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmPatientTestStatus.
	/// </summary>
	public partial class wfrmPatientTestStatus : System.Web.UI.Page
	{
	
		private string mSerialNo;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					mSerialNo = Request.QueryString.Get("mserialno");
					clsBLPatientStatus patientTestStatus = new clsBLPatientStatus();
					DataView dv = patientTestStatus.GetTestStatus(mSerialNo);
					DGPatientStatus.DataSource = dv;
					DGPatientStatus.DataBind();

					LblMSerialNo.Text = dv[0]["MSerialno"].ToString();
					lblLabID.Text = dv[0]["LabID"].ToString();
					LblPatientName.Text = dv[0]["PatientName"].ToString();
					LblAge.Text = dv[0]["Age"].ToString();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
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

		protected void lbtnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");	
		}

		protected void lbtnViewResult_Click(object sender, System.EventArgs e)
		{	
			LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT1.MSerialNo} in [" + LblMSerialNo.Text + "]";

			LIMS.reports.GeneralReports.PdfSetting = null;
			LIMS.reports.GeneralReports.ReportReference = "LMS-001-01";
			LIMS.reports.GeneralReports.mFromDate = "";
			LIMS.reports.GeneralReports.mToDate = "";

			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-01','_blank','channelmode')</script>");		

		}
        protected void lbtn_EmailClick(object sender, CommandEventArgs e)
        {
           
            if (e.CommandName == "EMail")
            {
                txtEmailID.Visible = true;
                lnkbtnEmail.CommandName = "Send";
                lnkbtnEmail.Text = "Send";
            }
            else if (e.CommandName == "Send")
            {
                LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT1.MSerialNo} in [" + LblMSerialNo.Text + "]";

                LIMS.reports.GeneralReports.PdfSetting = null;
                LIMS.reports.GeneralReports.ReportReference = "LMS-001-01";
                LIMS.reports.GeneralReports.mFromDate = "";
                LIMS.reports.GeneralReports.mToDate = "";

                Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-01&Email=Y&EmailID="+txtEmailID.Text+"','_blank','channelmode')</script>");
                lbtnClose_Click(sender, e);
            }
            //MailMessage message = new MailMessage();
            //message.From = new MailAddress("qamar.nust@gmail.com");
            //message.To.Add(new MailAddress("qamar.munir@seecs.edu.pk"));
            //message.Subject = "abc";
            //message.Body = "Attached";
            //Attachment attach = new Attachment(Server.MapPath("~/LIMS/reports/pdf/LMS-001-01_000001.pdf"));
            //message.Attachments.Add(attach);

            //SmtpClient smtpclient = new SmtpClient();
            //smtpclient.Host = "smtp.gmail.com";
          
            //smtpclient.Send(message);




        }
      
}
}
