using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.IO;
using System.Windows.Forms;
using LS_BusinessLayer;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Threading;

public partial class transaction_SentEmail : System.Web.UI.Page
{
    //clsEmailConfiguration config = new clsEmailConfiguration();
    private static string prid = "";
    private static string labid = "";
    // clsDocumentList list = new clsDocumentList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetEmailIdandattachement();
            //getValue();
        }
    }

    private void GetEmailIdandattachement()
    {
        string bookingid = Request.QueryString["mserialno"].ToString().Trim();
        PatientRegView objbokking = new PatientRegView();
        objbokking.MSerialNo = bookingid;
        DataView dv_Email = objbokking.GetAll(23);
        string email = dv_Email[0]["Email"].ToString().Trim();
        labid = dv_Email[0]["labid"].ToString().Trim();
       // prid = dv_Email[0]["prid"].ToString().Trim();
        TxBx_To.Text = email;
        Hyp_Email.Text = Request.QueryString["attachment"].ToString().Trim();//.Substring(Request.QueryString[Rot13.Transform("FileName").ToString()].LastIndexOf('\\')+1);
      
            TxBx_Subject.Text = "Laboratory Report for visit no : " + labid;
            TxBx_Message.Text = "Message Body set from database";
            //TxBx_Message.Text = "Dear Sir/Madam,<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Your lab Report is enclosed; Herewith<br /><br />Note:<br />This is Computer generated message.<br /><br />";         

    }


    public void Email()
    {
        string EMailId = "";
        string _cellno = "";
        string subject = "";
        string headertext = "";
        string footertext = "";

        //clsBLPatientReg_Inv obj_patient = new clsBLPatientReg_Inv();

        // DataView dvpass = new DataView();
        //obj_patient.PRID = prid;// Request.QueryString["prid"];
        //dvpass = obj_patient.GetAll(33);

        //string prno = dvpass[0]["prno"].ToString();// Request.QueryString["PRNo"].ToString().Trim();
        //string _labid = labid;// Request.QueryString["labid"].ToString().Trim();
        //string branchid = Session["BranchID"].ToString().Trim();
        //string pasword = dvpass[0]["Pasword"].ToString();

        //        obj_patient.PRNO = prno.ToString();
        //      DataView dv = obj_patient.GetAll(47);
        //    obj_patient = null;
        //if (dv.Count > 0)
        //{
        //    if (dv[0]["email"].ToString().Trim() != null)
        //    {
        //        EMailId = TxBx_To.Text.ToString();
        //        // EMailId = "Ammanzaheer@gmail.com";
        //        //EMailId = "asifalikkhan@gmail.com";
        //    }
        //    else
        //    {
        //        //EMailId = "Ammanzaheer@gmail.com";
        //    }
        //    _cellno = dv[0]["cellno"].ToString().Trim();
        //}
        ////string emailid = TxBx_To.Text;
        ////string emailcc = TxBx_Cc.Text;
        ////string fileName = "LetterInviting.pdf";
        //clsBLBranchAlertsD obj_alert = new clsBLBranchAlertsD();
        //obj_alert.BranchID = Session["BranchID"].ToString().Trim();
        //obj_alert.Type = "E";
        //// obj_alert.ProcessID = Request.QueryString["ProcessID"].ToString().Trim();
        //obj_alert.Active = "Y";
        //  DataView dv_messagedata = obj_alert.GetAll(1);
        //obj_alert = null;

        //////////////////////For RMI
        clsBLEMailPreferences obj_Email = new clsBLEMailPreferences();
        DataView dv_EmailPreferences = obj_Email.GetAll(1);
        if (dv_EmailPreferences.Count > 0)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(dv_EmailPreferences[0]["MessageFrom"].ToString());
            message.To.Add(TxBx_To.Text.Trim());
            //message.From = new MailAddress("qamar.nust@gmail.com");
            //message.To.Add(new MailAddress("qamar.munir@seecs.edu.pk"));
            message.Subject = TxBx_Subject.Text.Trim();
            message.Body = dv_EmailPreferences[0]["messagebody"].ToString().Trim() + dv_EmailPreferences[0]["MESSAGEFOOTER"].ToString();
            message.IsBodyHtml = true;
            Attachment attach = new Attachment(Server.MapPath("~/LIMS/reports/pdf/" + Request.QueryString["attachment"]));
            message.Attachments.Add(attach);

            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Host = dv_EmailPreferences[0]["HOSTADDRESS"].ToString();
            smtpclient.Credentials = new System.Net.NetworkCredential(dv_EmailPreferences[0]["UserName"].ToString(), dv_EmailPreferences[0]["Password"].ToString());
            smtpclient.EnableSsl = dv_EmailPreferences[0]["enablessl"].ToString()=="Y"?true:false;
           
        //    smtpclient.SendCompleted += new SendCompletedEventHandler(smtpClient_SendCompleted);
        //    try
        //    {
        //        smtpclient.Send(message);
        //        Thread t = new Thread(new ThreadStart(delegate
        //{
        //    smtpclient.Send(message);
        //}));
                //t.IsBackground = true;
                //t.Start();
            try
            {
                smtpclient.Send(message);
                lblsent.Visible = true;
                lblsent.Text = "Mail Successfully Sent";
                Response.Write("<script type=\"text/javascript\">alert('Email Sent');</script>");
                Response.Write("<script language = 'javascript'>window.close()</script>");
            }
            catch(Exception ee)
            {

                lblsent.Visible = true;
                lblsent.Text = "Following Error OCcured while Sending Email: "+ee.ToString().Trim();
                Response.Write("<script type=\"text/javascript\">alert('Error Occured while Sending EMail.Please review smtp settings');</script>");
            }
            
            
            //}
            //catch (Exception ee)
            //{
            //    lblsent.Visible = true;
            //    lblsent.Text = ee.Message.ToString();
            //}
        }
    }

 


    protected void Btn_ok_Click(object sender, ImageClickEventArgs e)
    {
        
        
       Email();
       


       // tb2.Visible = true;
        tb3.Visible = false;
    }
    void smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        MailMessage mail = e.UserState as MailMessage;
        if (!e.Cancelled && e.Error != null)
        {

            //message.Text = "Mail sent successfully";       
        }
    }
    protected void HypEmail_Click(object sender, EventArgs e)
    {
        LinkButton lnkPath3 = (LinkButton)sender;
        string filepath = Server.MapPath("~/Lims/Reports/pdf/"+lnkPath3.Text.Trim());// @"D:\negno25462.jpg";
        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";

            case ".docx":
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }
}