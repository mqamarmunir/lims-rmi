using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_Ajax_TestmethodConfig : System.Web.UI.Page
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
              
                FillSectionDDL();


            }
        }

    }

    private void FillSectionDDL()
    {
        clsBlTestMethod obj_FillSection = new clsBlTestMethod();
        SComponents objComp = new SComponents();
        DataView dv = obj_FillSection.GetAll(1);
        if (dv.Count > 0)
        {
            objComp.FillDropDownList(ddlSubDepartment, dv, "SECTIONNAME", "SECTIONID");

        }
        else
        {
            this.lblErrMsg.Text = "No Section found";
        }
        dv.Dispose();
        obj_FillSection = null;
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMethod.Enabled = true;
        FillMethodDDL();
        ddlTest.Enabled = true;
        FillTestDDL();

    }

    private void FillMethodDDL()
    {
        clsBlTestMethod obj_FillMethod = new clsBlTestMethod();
        obj_FillMethod.SectionID = ddlSubDepartment.SelectedValue.ToString();
        SComponents objComp = new SComponents();
        DataView dv = obj_FillMethod.GetAll(2);
        if (dv.Count > 0)
        {
            lblErrMsg.Text = "";
            objComp.FillDropDownList(ddlMethod, dv, "METHOD", "METHODID");

        }
        else
        {
            ddlMethod.ClearSelection();
            ddlMethod.Enabled = false;

            this.lblErrMsg.Text = "No Method Found";

            this.lblCount.Text = "";
        }
        dv.Dispose();
        obj_FillMethod = null;


    }

    private void FillTestDDL()
    {
        clsBlTestMethod obj_FillTest = new clsBlTestMethod();
        obj_FillTest.SectionID = ddlSubDepartment.SelectedValue.ToString();
        SComponents objComp = new SComponents();
        DataView dv = obj_FillTest.GetAll(3);
        if (dv.Count > 0)
        {
            lblErrMsg.Text = "";
            objComp.FillDropDownList(ddlTest, dv, "Test", "TestID");

        }
        else
        {
            ddlTest.ClearSelection();
            ddlTest.Enabled = false;
            lblErrMsg.Text = "No Test Found";
        }
        dv.Dispose();
        obj_FillTest = null;

    }

    protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}