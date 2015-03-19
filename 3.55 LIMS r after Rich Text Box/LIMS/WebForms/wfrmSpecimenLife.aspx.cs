using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmSpecimenLife : System.Web.UI.Page
{
    private static string DGSort = "Description ASC";
    private static string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "115";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillDDLSubDepartment();
                FillGV();
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
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            clsBlSpecimenLife obj_Specimen = new clsBlSpecimenLife();
            obj_Specimen.LifeID = hdLifeID.Value.ToString();
            obj_Specimen.TestID = ddlTest.SelectedValue.ToString();

            obj_Specimen.Specimen = ddlSpecimen.SelectedValue.ToString();
            obj_Specimen.Life = txtLife.Text;
            obj_Specimen.EnteredBy = Session["loginid"].ToString();
            obj_Specimen.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Specimen.ClientID = "0005";
            obj_Specimen.System_Ip = Request.UserHostAddress.ToString();
            if (obj_Specimen.update())
            {
               
                FillGV();
                RefreshForm();
                this.lblErrMSg.Text = "<font color='Green'>Record Updated Successfully</font>";
            }
            else
            {
                this.lblErrMSg.Text = obj_Specimen.ErrorMessage;
            }
        }
        else
        {
            clsBlSpecimenLife obj_Specimen = new clsBlSpecimenLife();
            obj_Specimen.TestID = ddlTest.SelectedValue.ToString();

            obj_Specimen.Specimen = ddlSpecimen.SelectedValue.ToString();
            obj_Specimen.Life = txtLife.Text;
            obj_Specimen.EnteredBy = Session["loginid"].ToString();
            obj_Specimen.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Specimen.ClientID = "0005";
            obj_Specimen.System_Ip = Request.UserHostAddress.ToString();
            if (obj_Specimen.insert())
            {
                
                FillGV();
                RefreshForm();
                this.lblErrMSg.Text = "<font color='Green'>Record Inserted Successfully</font>";
            }
            else
            {
                this.lblErrMSg.Text = obj_Specimen.ErrorMessage;
            }
        }

    }
    private void RefreshForm()
    {
        txtLife.Text = "";
        mode = "save";
        this.ibtnSave.ToolTip = "insert";
        this.ddlSpecimen.ClearSelection();
        this.ddlTest.ClearSelection();
        this.lblErrMSg.Text = "";
    }
    private void FillGV()
    {
        clsBlSpecimenLife obj_life = new clsBlSpecimenLife();
        DataView dv_Life = obj_life.GetAll(1);
        obj_life = null;
        if (dv_Life.Count > 0)
        {
            gvSpecimenLife.DataSource = dv_Life;
            gvSpecimenLife.DataBind();
        }
        dv_Life.Dispose();

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script type='javascript'> window.close()</script>");
    }

    protected void gvSpecimenLife_Sorting(object sender, GridViewSortEventArgs e)
    {
 
    }

    protected void gvSpecimenLife_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            hdLifeID.Value = gvSpecimenLife.DataKeys[index].Values[0].ToString();

            FillForm(index);
            mode = "Update";
            ibtnSave.ToolTip = "Update";

        }
 
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
            FillddlTest();
            FillddlSpecimen();
            
            
        }
    }
    private void FillddlTest()
    {
        clsBLTest obj_Test = new clsBLTest();
        obj_Test.SectionID = ddlSubDepartment.SelectedValue.ToString();
        DataView dv_Tests = obj_Test.GetAll(10);
        obj_Test = null;
        if (dv_Tests.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlTest, dv_Tests, "Test", "TestID");
            obj_Comp = null;
        }
        dv_Tests.Dispose();
    }

    private void FillddlSpecimen()
    {
        clsBLSpecimenType obj_SpecimenType = new clsBLSpecimenType();
        DataView dv_Specimentypes = obj_SpecimenType.GetAll(1);
        if (dv_Specimentypes.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlSpecimen, dv_Specimentypes, "specimentype", "specimentype");
        }
    }
    private void FillForm(int rowindex)
    {
       this.ddlSubDepartment.ClearSelection();
       this.ddlSubDepartment.Items.FindByValue(gvSpecimenLife.DataKeys[rowindex].Values[1].ToString()).Selected=true;
       FillddlTest();
       FillddlSpecimen();
       this.ddlTest.ClearSelection();
       this.ddlTest.Items.FindByText(gvSpecimenLife.Rows[rowindex].Cells[1].Text.Trim()).Selected=true;
       this.ddlSpecimen.ClearSelection();
       this.ddlSpecimen.Items.FindByText(gvSpecimenLife.Rows[rowindex].Cells[2].Text.Trim()).Selected = true;
       this.txtLife.Text = gvSpecimenLife.Rows[rowindex].Cells[3].Text.Trim();
       
 
    }

}