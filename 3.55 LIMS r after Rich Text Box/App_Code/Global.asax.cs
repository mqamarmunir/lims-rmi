using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Diagnostics;
using System.Web.Mail;

namespace HMIS 
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{

		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{				 
			/*String Message = "\n\nURL:\n http://localhost/" + Request.Path
				+ "\n\nMESSAGE:\n " + Server.GetLastError().Message
				+ "\n\nSTACK TRACE:\n" + Server.GetLastError().StackTrace;*/

			String Message = "\n\nURL:\n http://localhost/" + Request.Path
				+ "\n\nMESSAGE:\n " + Server.GetLastError().ToString()
				+ "\n\nSTACK TRACE:\n" + Server.GetLastError().StackTrace;

			// Create event Log if it does not exist

			String LogName = "Application";			
			if (!EventLog.SourceExists(LogName)) 
			{
				EventLog.CreateEventSource(LogName, LogName);				
			}			

			// Insert into event log
			EventLog Log = new EventLog();
			Log.Source = LogName;			
			Log.WriteEntry(Message, EventLogEntryType.Error);			
			
			/*
						String message = "<font face=verdana color=red>"
							+ "<h4>" + Request.Url.ToString() + "</h4>"
							+ "<pre><font color='red'>" + Server.GetLastError().ToString() + "</pre>"
							+ "</font>";

						Response.Write(message);
						Response.Write("An error has occured on this server, and the administrator of the site has been notified.");			
						Server.ClearError();
			*/
			/*

			String message = "<font face=verdana color=red>"
				+ "<h4>" + Request.Url.ToString() + "</h4>"
				+ "<pre><font color='red'>" + Server.GetLastError().ToString() + "</pre>"
				+ "</font>";		

			MailMessage mail = new MailMessage();
			mail.From = "waqartrees@hotmail.com";
			mail.To = "waqartrees@hotmail.com";
			mail.Subject = "Site Error";
			mail.Body = message;
			mail.BodyFormat = MailFormat.Html;
			SmtpMail.Send(mail);*/		

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

