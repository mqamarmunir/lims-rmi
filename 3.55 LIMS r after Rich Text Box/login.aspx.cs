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
using System.Web.Security;
using HimsBLRegistration;
using LS_BusinessLayer;

namespace HMIS
{
	/// <summary>
	/// Summary description for login.
	/// </summary>
    public partial class login : System.Web.UI.Page
    {
        protected static string focusElement = "";

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page heref
            try
            {
                if (Request.QueryString["errmsg"] != null)
                {
                    this.lblErrMsg.Text = Request.QueryString["errmsg"].ToString();
                }
            }
            catch (NullReferenceException e1) { }

            focusElement = this.txtlogin.ID.ToString();
           // txtlogin.CssClass = "txtOutRangeValue";
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

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            LS_BusinessLayer.clsBLUMatrix umat = new LS_BusinessLayer.clsBLUMatrix();
            umat.ApplicationID = "001"; //001

            string strOrg = "2.0.000";
            string strEnd = "";

            for (int i = strOrg.Length - 1; i >= 0; i--)
            {
                strEnd = strEnd + (char)(strOrg[i] - 10);
            }
            umat.Version = strEnd;
            DataView dv = umat.GetAll(2);
            if (dv.Count == 0)
            {
                lblErrMsg.Text = "You are using old version.Please Contact your administrator.";

            }

            else
            {
                if (this.txtlogin.Text == "")
                {
                    lblErrMsg.Text = "User Name must be entered.";

                }
                else if (this.txtpassword.Text == "")
                {
                    lblErrMsg.Text = "User Password must be entered.";

                }
                else
                {
                    this.lblErrMsg.Text = "";
                    //HimsBLRegistration.clsBLLogin objLogin = new HimsBLRegistration.clsBLLogin();

                    //dvLoginInfo = objLogin.rsGetAll("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", this.txtlogin.Text, this.txtpassword.Text, "", "");
                    //string sessionUserName = objLogin.VD_Login(this.txtlogin.Text, this.txtpassword.Text);

                    LS_BusinessLayer.clsBLLogin lg = new LS_BusinessLayer.clsBLLogin();
                    lg.LoginID = this.txtlogin.Text.Trim();
                    lg.Pasword = this.txtpassword.Text.Trim();

                    DataView dvLoginInfo = lg.GetAll(1);
                    if (dvLoginInfo.Count > 0)
                    {
                        Session.Timeout = 500;
                        Session["loginid"] = dvLoginInfo[0].Row["personid"].ToString();

                        Session["UNUIDFORMATTED"] = dvLoginInfo.Table.Rows[0]["PersonName"].ToString() + "(" + txtlogin.Text + ")";
                        Session["PERSONID"] = this.txtlogin.Text;
                        //Session["roleid"] = dvLoginInfo.Table.Rows[0]["RoleID"].ToString();
                        Session["SHIFT"] = this.ddlShift.SelectedValue.ToString();
                        FormsAuthentication.RedirectFromLoginPage(txtlogin.Text, false);
                       // Response.Redirect("~/LIMS/WebForms/wfrmMainMenu.aspx");
                    }
                    else
                    {
                        lblErrMsg.Text = "Invalid User/pasword ";

                    }
                }
            }
        }
    }
}