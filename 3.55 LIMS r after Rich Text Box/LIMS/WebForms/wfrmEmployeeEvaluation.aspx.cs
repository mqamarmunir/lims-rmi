using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmEmployeeEvaluation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "003";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

               
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }

    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLGeneralTestResult obj_gTestResult = new clsBLGeneralTestResult();
        obj_gTestResult.MSerialNo = Request.QueryString["MSerialNo"].ToString();
        obj_gTestResult.TestID = Request.QueryString["TestID"].ToString();
        obj_gTestResult.Qualitative = txtQualitative.Text;
        if (rbExcellent.Checked == true)
        {
            obj_gTestResult.Quantitative = "E";
        }
        if (rbVGood.Checked == true)
        {
            obj_gTestResult.Quantitative = "vG";
        }
        if (rbGood.Checked == true)
        {
            obj_gTestResult.Quantitative = "G";
        }
        if (rbPoor.Checked == true)
        {
            obj_gTestResult.Quantitative = "P";
        }
        if (rbVPoor.Checked == true)
        {
            obj_gTestResult.Quantitative = "vP";
        }
        obj_gTestResult.EnteredBy = Session["loginid"].ToString();
        obj_gTestResult.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        if (obj_gTestResult.update_ResultM_Evaluation())
        {
            Response.Write("<script language='javascript'>window.close()</script>");
        }
        else
        {
            lblErrMsg.Text = obj_gTestResult.ErrorMessage;
        }
      
    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
}