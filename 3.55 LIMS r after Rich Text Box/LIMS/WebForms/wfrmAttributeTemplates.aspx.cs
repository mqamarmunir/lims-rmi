using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmAttributeTemplates : System.Web.UI.Page
{
    private static string DGSort = "Attribute ASC";
    private static string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "113";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillDDLSubDepartment();
               
               // FillGV();


            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }

    }

    protected void FillDDLSubDepartment()
    {
        clsBLSection obj_fillSubdeparmtent = new clsBLSection();
        obj_fillSubdeparmtent.Active = "Y";
        DataView dv_FillSubDepartment = obj_fillSubdeparmtent.GetAll(1);
        SComponents obj_scomp = new SComponents();
        if (dv_FillSubDepartment.Count > 0)
        {
            obj_scomp.FillDropDownList(ddlSubDepartment, dv_FillSubDepartment, "SectionName", "SectionID");
        }
        dv_FillSubDepartment.Dispose();
        obj_scomp = null;
        obj_fillSubdeparmtent = null;

    }
    protected void FillGV()
    {
        clsBlAttributeTemplates obj_templates = new clsBlAttributeTemplates();
        obj_templates.AttributeID = ddlAttributes.SelectedValue.ToString();
        DataView dv_Template_values = obj_templates.GetAll(1);
        obj_templates = null;
        if (dv_Template_values.Count > 0)
        {
            lblCount.Visible = true;
            lblCount.Text = "(" + dv_Template_values.Count + ") Record(s) Found";
            dv_Template_values.Sort = DGSort;
            dgTemplates.DataSource = dv_Template_values;
            dgTemplates.DataBind();

        }
        else
        {
            lblCount.Text = "No Record Found";
            dgTemplates.DataSource = "";
            dgTemplates.DataBind();
            
        }
        dv_Template_values.Dispose();


    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            clsBlAttributeTemplates obj_templates = new clsBlAttributeTemplates();
            obj_templates.TemplateID = hdTemplateID.Value.ToString();
            obj_templates.AttributeID = ddlAttributes.SelectedValue.ToString();
            obj_templates.Description = txtDescription.Text;
            obj_templates.Active = chkActive.Checked == true ? "Y" : "N";
            obj_templates.T_Default = chkDefault.Checked == true ? "Y" : "N";
            obj_templates.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_templates.EnteredBy = this.Session["loginid"].ToString();
            obj_templates.ClientID = "0005";
            if (obj_templates.update())
            {
                lblErrMSg.Text = "<font color='Green'>Record updated successfully</font>";
                FillGV();
                RefreshForm();

            }
            else
            {
                lblErrMSg.Text = obj_templates.ErrorMessage;
            }
            obj_templates = null;
        }
        else
        {
            clsBlAttributeTemplates obj_templates = new clsBlAttributeTemplates();
            obj_templates.AttributeID = ddlAttributes.SelectedValue.ToString();
            obj_templates.Description = txtDescription.Text;
            obj_templates.Active = chkActive.Checked == true ? "Y" : "N";
            obj_templates.T_Default = chkDefault.Checked == true ? "Y" : "N";
            obj_templates.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_templates.EnteredBy = this.Session["loginid"].ToString();
            obj_templates.ClientID = "0005";
            if (obj_templates.insert())
            {
                lblErrMSg.Text = "<font color='Green'>Record inserted successfully</font>";
                FillGV();
                RefreshForm();

            }
            else
            {
                lblErrMSg.Text = obj_templates.ErrorMessage;
            }
            obj_templates = null;
        }

    }

    private void RefreshForm()
    {
        txtDescription.Text = "";
        chkDefault.Checked = false;
        chkActive.Checked = true;
        mode = "";
        ibtnSave.ToolTip = "Save";

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    
    }

    protected void dgTemplates_Sorting(object sender, DataGridSortCommandEventArgs e)
    {
        if (e.SortExpression == "Attribute")
        {
            if (DGSort == "Attribute ASC")
            {
                DGSort = "Attribute DESC";

            }
            else
            {
                DGSort = "Attribute ASC";
            }
        }

        if (e.SortExpression == "Description")
        {
            if (DGSort == "Description ASC")
            {
                DGSort = "Description DESC";

            }
            else
            {
                DGSort = "Description ASC";
            }
        }

        if (e.SortExpression == "Active")
        {
            if (DGSort == "Active ASC")
            {
                DGSort = "Active DESC";

            }
            else
            {
                DGSort = "Active ASC";
            }
        }

        if (e.SortExpression == "T_Default")
        {
            if (DGSort == "T_Default ASC")
            {
                DGSort = "T_Default DESC";

            }
            else
            {
                DGSort = "T_Default ASC";
            }
        }

        FillGV();
    }

    protected void dg_ItemCommand(object sender, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = e.Item.ItemIndex;
            FillForm(index);
            mode = "Update";
            ibtnSave.ToolTip = "Update";

        }
 
    }

    private void FillForm(int rowindex)
    {
        ddlAttributes.ClearSelection();
        string x = dgTemplates.Items[rowindex].Cells[3].Text.ToString();
        ddlAttributes.Items.FindByText(dgTemplates.Items[rowindex].Cells[3].Text.ToString()).Selected = true;
        txtDescription.Text = dgTemplates.Items[rowindex].Cells[4].Text;
        chkActive.Checked = ((CheckBox)dgTemplates.Items[rowindex].Cells[5].FindControl("dgchkActive")).Checked == true ? true : false;
        chkDefault.Checked = ((CheckBox)dgTemplates.Items[rowindex].Cells[5].FindControl("dgchkDefault")).Checked == true ? true : false;
        hdTemplateID.Value = dgTemplates.Items[rowindex].Cells[1].Text;
 
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
            FillTestDDL();
        }
    }

    protected void FillTestDDL()
    {
        clsBLTest obj_Test = new clsBLTest();
        obj_Test.SectionID = ddlSubDepartment.SelectedValue.ToString();
        DataView dv_filltestddl = obj_Test.GetAll(10);
        SComponents obj_scomp = new SComponents();
        obj_scomp.FillDropDownList(ddlTest, dv_filltestddl, "Test", "TestID");
        dv_filltestddl.Dispose();
        obj_scomp = null;
        obj_Test = null;
 
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedValue.ToString() != "-1")
        {
            FillAttributesDDL();
        }

    }
    private void FillAttributesDDL()
    {
        clsBLTestAttribute obj_TestAttribute = new clsBLTestAttribute();
        obj_TestAttribute.TestID = ddlTest.SelectedValue.ToString();
        DataView dv_Attribute = obj_TestAttribute.GetAll(8);
        if (dv_Attribute.Count > 0)
        {
            SComponents obj_Scomp = new SComponents();
            obj_Scomp.FillDropDownList(ddlAttributes, dv_Attribute, "Attribute", "AttributeID");
            obj_Scomp = null;
        }
        dv_Attribute.Dispose();
        obj_TestAttribute = null;


    }
    protected void ddlAttributes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAttributes.SelectedValue.ToString() != "-1")
        {
            FillGV();
        }

    }
}