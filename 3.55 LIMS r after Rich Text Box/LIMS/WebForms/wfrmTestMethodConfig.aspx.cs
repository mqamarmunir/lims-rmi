using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Drawing;
using System.Data;

public partial class LIMS_WebForms_wfrmTestMethodConfig : System.Web.UI.Page
{
    private static string DGSort = "SECTIONNAME ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "111";
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
            lblErrMsg.ForeColor = Color.Red;
            this.lblErrMsg.Text = "No Section found";
        }
        dv.Dispose();
        obj_FillSection = null;
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBlTestMethod obj_save = new clsBlTestMethod();
        obj_save.SectionID = ddlSubDepartment.SelectedValue.ToString();
        obj_save.MethodID = ddlMethod.SelectedValue.ToString();
        obj_save.TestID = ddlTest.SelectedValue.ToString();
        if (hdEdit.Value.ToString() == "edit")
        {
            obj_save.TestMethodID = hdTestMethod.Value.ToString();
            obj_save.Active = (this.chkActive.Checked == true) ? "Y" : "N";
            obj_save.M_Default = (this.chkDefault.Checked == true) ? "Y" : "N";
            //if (txtDorder.Text == "")
            //{
            //    obj_save.D_Order = null;
            //}
            //obj_save.D_Order = txtDorder.Text;
            obj_save.EnteredBy = Session["loginid"].ToString();
            obj_save.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_save.ClientID = "0005";
            if (obj_save.Update())
            {
                if (this.chkDefault.Checked == true)
                {
                    if (obj_save.update_TestTable())
                    {
                        lblErrMsg.ForeColor = Color.Green;
                        lblErrMsg.Text = "Update Successful!";
                        txtDorder.Text = "";
                        //txtRate.Text = "";
                        FillGV();
                        hdEdit.Value = "";
                        hdTestMethod.Value = "";

                    }
                    else
                    {
                        lblErrMsg.ForeColor = Color.Red;
                        lblErrMsg.Text = obj_save.ErrorMessage;
                        hdEdit.Value = "";
                        hdTestMethod.Value = "";
                    }
                }
                else
                {
                    lblErrMsg.ForeColor = Color.Green;
                    lblErrMsg.Text = "Update Successful!";
                    txtDorder.Text = "";
                    //txtRate.Text = "";
                    FillGV();
                    hdEdit.Value = "";
                    hdTestMethod.Value = "";
                }
            }
            else
            {
                lblErrMsg.ForeColor = Color.Red;
                lblErrMsg.Text = obj_save.ErrorMessage;
                hdEdit.Value = "";
                hdTestMethod.Value = "";
            }
        }
        else
        {
            obj_save.Active = (this.chkActive.Checked == true) ? "Y" : "N";
            obj_save.M_Default = (this.chkDefault.Checked == true) ? "Y" : "N";
            //if (txtDorder.Text == "")
            //{
            //    obj_save.D_Order = null;
            //}
            //obj_save.D_Order = txtDorder.Text;
            obj_save.EnteredBy = Session["loginid"].ToString();
            obj_save.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_save.ClientID = "0005";
            if (obj_save.Insert())
            {
                if (this.chkDefault.Checked == true)
                {
                    if (obj_save.update_TestTable())
                    {
                        lblErrMsg.ForeColor = Color.Green;
                        lblErrMsg.Text = "Record inserted Successfully";
                        txtDorder.Text = "";
                        //txtRate.Text = "";
                        FillGV();
                        hdEdit.Value = "";
                        hdTestMethod.Value = "";

                    }
                    else
                    {
                        lblErrMsg.ForeColor = Color.Red;
                        lblErrMsg.Text = obj_save.ErrorMessage;
                        hdEdit.Value = "";
                        hdTestMethod.Value = "";
                    }
                }
                else
                {
                    lblErrMsg.ForeColor = Color.Green;
                    lblErrMsg.Text = "Record inserted Successfully";
                    txtDorder.Text = "";
                    //txtRate.Text = "";
                    FillGV();
                }
            }

            else
            {
                lblErrMsg.ForeColor = Color.Red;
                lblErrMsg.Text = obj_save.ErrorMessage;
            }
        }
        
    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();
    }
    private void ClearAll()
    {
        hdEdit.Value = "";
        hdTestMethod.Value = "";
        txtDorder.Text = "";
       // txtRate.Text = "";
        ddlTest.ClearSelection();
        ddlMethod.ClearSelection();
        ddlSubDepartment.ClearSelection();
        ibtnSave.ToolTip = "Click To Save";
        lblErrMsg.Text = "";
        ddlTest.Enabled = false;
        ddlMethod.Enabled = false;
        lblCount.Text = "";
        Clear_Grid();
       // lblGroupTotal.Text = "";
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlMethod.Enabled = true;
        FillMethodDDL();
        ddlTest.Enabled = true;
        FillTestDDL();
        lblCount.Text = "";
        Clear_Grid();
       // FillGV();
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
            lblErrMsg.ForeColor = Color.Red;
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
            lblErrMsg.ForeColor = Color.Red;
            lblErrMsg.Text = "No Test Found";
        }
        dv.Dispose();
        obj_FillTest = null;
 
    }

    private void FillGV()
    {
        clsBlTestMethod obj_grid = new clsBlTestMethod();
        obj_grid.SectionID = ddlSubDepartment.SelectedValue.ToString();


        obj_grid.MethodID = ddlMethod.SelectedValue.ToString();

        DataView dv = obj_grid.GetAll(4);
        dv.Sort = DGSort;
        gvTestMethod.DataSource = dv;
        gvTestMethod.DataBind();
        lblCount.Visible = true;
        lblCount.Text = gvTestMethod.Rows.Count + " Rows Found";
    }
    protected void ddlMethod_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
        lblCount.Visible = true;
        lblCount.Text = gvTestMethod.Rows.Count + " Rows Found";
    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvTestMethod_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "SECTIONNAME")
        {
            if (DGSort == "SECTIONNAME ASC")
            {
                DGSort = "SECTIONNAME DESC";
            }
            else
                DGSort = "SECTIONNAME ASC";
        }
        if (e.SortExpression == "TEST")
        {
            if (DGSort == "TEST ASC")
            {
                DGSort = "TEST DESC";
            }
            else
                DGSort = "TEST ASC";
        }
        if (e.SortExpression == "D_Order")
        {
            if (DGSort == "D_Order ASC")
            {
                DGSort = "D_Order DESC";
            }
            else
                DGSort = "D_Order ASC";
        }
        if (e.SortExpression == "M_Default")
        {
            if (DGSort == "M_Default ASC")
            {
                DGSort = "M_Default DESC";
            }
            else
                DGSort = "M_Default ASC";
        }
        if (e.SortExpression == "Active")
        {
            if (DGSort == "Active ASC")
            {
                DGSort = "Active DESC";
            }
            else
                DGSort = "Active ASC";
        }
        FillGV();

    }

    protected void gvTestMethod_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            hdEdit.Value = "edit";
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdTestMethod.Value = gvTestMethod.DataKeys[rowindex].Value.ToString();
            ibtnSave.ToolTip = "Update";

            FillForm(rowindex);
        }
 
    }

    private void FillForm(int rowindex)
    {
      //  ddlSubDepartment.ClearSelection();
     //   ddlMethod.ClearSelection();


        //ddlSubDepartment.Items.FindByText(gvTestMethod.Rows[rowindex].Cells[1].Text).Selected = true;
        //ddlMethod.Items.FindByText(gvTestMethod.Rows[rowindex].Cells[2].Text).Selected = true;
        ddlMethod.Enabled = false;

      //  ddlSubDepartment.Enabled = false;
        
        //FillTestDDL();
        ddlTest.ClearSelection();
        ddlTest.Items.FindByText(gvTestMethod.Rows[rowindex].Cells[2].Text).Selected = true;
        ddlTest.Enabled = false;
        this.chkActive.Checked = ((CheckBox)this.gvTestMethod.Rows[rowindex].Cells[5].FindControl("dgchkActive")).Checked;
        this.chkDefault.Checked = ((CheckBox)this.gvTestMethod.Rows[rowindex].Cells[4].FindControl("dgchkDefault")).Checked;
        this.txtDorder.Text=gvTestMethod.Rows[rowindex].Cells[3].Text;
 
    }
    private void Clear_Grid()
    {
        gvTestMethod.DataSource = "";
        gvTestMethod.DataBind();
    }
}