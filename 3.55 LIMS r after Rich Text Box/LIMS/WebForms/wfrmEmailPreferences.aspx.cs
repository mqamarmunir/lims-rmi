using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmEmailPreferences : System.Web.UI.Page
{
    private static string mode = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {

            if (!IsPostBack)
            {

                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "119";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

               
                    FillForm();
              

                    

            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");

        }

    }

    private void FillForm()
    {
        clsBLEMailPreferences obj_Emails = new clsBLEMailPreferences();
        DataView dv_Emails = obj_Emails.GetAll(1);
        obj_Emails = null;
        if (dv_Emails.Count > 0)
        {
            hdEmailid.Value = dv_Emails[0]["EMAILPREFERENCEID"].ToString();
            mode = "Update";
            txtServerAddr.Text = dv_Emails[0]["HOSTADDRESS"].ToString();
            txtPort.Text = dv_Emails[0]["PORTNUMBER"].ToString();
            txtFromEmail.Text = dv_Emails[0]["MESSAGEFROM"].ToString();

            txtMsgFooter.Text = dv_Emails[0]["MESSAGEFOOTER"].ToString();
            txtUserName.Text = dv_Emails[0]["USERNAME"].ToString();
            txtPassword.Text = dv_Emails[0]["Password"].ToString();
        }
        else
        {
            mode = "";
            txtServerAddr.Text = "";
            txtPort.Text = "";
            txtMsgFooter.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
        }
        dv_Emails.Dispose();
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            clsBLEMailPreferences obj_Emails = new clsBLEMailPreferences();
            obj_Emails.EmailPreferenceID = hdEmailid.Value.ToString();
            obj_Emails.HostAddress = txtServerAddr.Text;
            obj_Emails.PortNumber = txtPort.Text;
            obj_Emails.UserName = txtUserName.Text;
            obj_Emails.Password = txtPassword.Text;
            obj_Emails.Footer = txtMsgFooter.Text;
            obj_Emails.MessageFrom = txtFromEmail.Text;
            obj_Emails.EnteredBy = Session["loginid"].ToString();
            obj_Emails.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Emails.ClientID = "0005";
            obj_Emails.System_IP = Request.UserHostAddress.ToString();

            if (obj_Emails.Update())
            {
                FillForm();
                this.lblErrMsg.Text = "<font color='green'>Record Updated Successfully.</font>";
            }
            else
            {
                this.lblErrMsg.Text = obj_Emails.ErrorMessage;
            }
            obj_Emails = null;
        }
        else
        {
            clsBLEMailPreferences obj_Emails = new clsBLEMailPreferences();
            obj_Emails.EmailPreferenceID = hdEmailid.Value.ToString();
            obj_Emails.HostAddress = txtServerAddr.Text;
            obj_Emails.PortNumber = txtPort.Text;
            obj_Emails.UserName = txtUserName.Text;
            obj_Emails.Password = txtPassword.Text;
            obj_Emails.Footer = txtMsgFooter.Text;
            obj_Emails.MessageFrom = txtFromEmail.Text;
            obj_Emails.EnteredBy = Session["loginid"].ToString();
            obj_Emails.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Emails.ClientID = "0005";
            obj_Emails.System_IP = Request.UserHostAddress.ToString();
            if (obj_Emails.Insert())
            {
                FillForm();
                this.lblErrMsg.Text = "<font color='green'>Record Inserted Successfully</font>";
            }
            else
            {
                this.lblErrMsg.Text = obj_Emails.ErrorMessage;
            }
            obj_Emails = null;
 
        }

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        txtMsgFooter.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtServerAddr.Text = "";
        txtPort.Text = "";
        mode = "";
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }
    
}