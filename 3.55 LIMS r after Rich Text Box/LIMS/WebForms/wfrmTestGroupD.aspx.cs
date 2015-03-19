using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmTestGroupD : System.Web.UI.Page
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
                UMatrix.FormID = "110";
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

    public void FillSectionDDL()
    {
        //clsBLTestPriceUpdate obj_priceupdate = new clsBLTestPriceUpdate();
        clsBLTestGroupD obj_GroupD = new clsBLTestGroupD();
        SComponents objComp = new SComponents();
        DataView dv = obj_GroupD.GetAll(1);
        if (dv.Count > 0)
        {
            objComp.FillDropDownList(ddlSubDepartment, dv, "SECTIONNAME", "SECTIONID");

        }
        else
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrMsg.Text = "No Section found";
        }
        dv.Dispose();
        obj_GroupD = null;
    }


    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLTestGroupD obj_save = new clsBLTestGroupD();
        obj_save.SectionID = ddlSubDepartment.SelectedValue.ToString();
        obj_save.TestGroupID = ddlTestGroup.SelectedValue.ToString();
        obj_save.TestID = ddlTest.SelectedValue.ToString();
        if (hdEdit.Value.ToString() == "edit")
        {
            obj_save.GroupDetailID = hdGroupDetail.Value.ToString();
            obj_save.SectionID = ddlSubDepartment.SelectedValue.ToString();
            obj_save.TestGroupID = ddlTestGroup.SelectedValue.ToString();
            obj_save.TestID = ddlTest.SelectedValue.ToString();
            obj_save.Active = (this.chkActive.Checked == true) ? "Y" : "N";
            obj_save.Charges = txtRate.Text;
            obj_save.EnteredBy = Session["loginid"].ToString();
            obj_save.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_save.ClientID = "0005";
            if (obj_save.Update())
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                lblErrMsg.Text = "Update Successful!";
                txtCharges.Text = "";
                txtRate.Text = "";
                hdEdit.Value = "";
                hdGroupDetail.Value = "";
                FillGV();
                groupTotal();
            }
            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = obj_save.ErrorMessage;
                hdEdit.Value = "";
                hdGroupDetail.Value = "";
            }
        }
        else
        {
            obj_save.SectionID = ddlSubDepartment.SelectedValue.ToString();
            obj_save.TestGroupID = ddlTestGroup.SelectedValue.ToString();
            obj_save.TestID = ddlTest.SelectedValue.ToString();
            obj_save.Active = (this.chkActive.Checked == true) ? "Y" : "N";
            obj_save.Charges = txtRate.Text;
            obj_save.EnteredBy = Session["loginid"].ToString();
            obj_save.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_save.ClientID = "0005";
            if (obj_save.Insert())
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                lblErrMsg.Text = "Record inserted Successfully";
                txtCharges.Text = "";
                txtRate.Text = "";
                FillGV();
                groupTotal();
            }

            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = obj_save.ErrorMessage;
            }
        }
    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        Clearall();
        
    }
    private void Clearall()
    {
        hdEdit.Value = "";
        hdGroupDetail.Value = "";
        txtCharges.Text = "";
        txtRate.Text = "";
        ddlTest.ClearSelection();
        ddlTestGroup.ClearSelection();
        ddlSubDepartment.ClearSelection();
        ibtnSave.ToolTip = "Click To Save";
        lblErrMsg.Text = "";
        ddlTest.Enabled = false;
        ddlTestGroup.Enabled = false;
        lblCount.Text = "";
        lblGroupTotal.Text = "";
    }

    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }
    protected void gvTests_Sorting(object sender, GridViewSortEventArgs e)
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
        else if (e.SortExpression == "TestGroup")
        {
            if (DGSort == "TestGroup ASC")
            {
                DGSort = "TestGroup DESC";
            }
            else
                DGSort = "TestGroup ASC";

        }
        else if (e.SortExpression == "TEST")
        {
            if (DGSort == "TEST ASC")
            {
                DGSort = "TEST DESC";
            }
            else
                DGSort = "TEST ASC";

        }
        else if (e.SortExpression == "CHARGES")
        {
            if (DGSort == "CHARGES ASC")
            {
                DGSort = "CHARGES DESC";
            }
            else
                DGSort = "CHARGES ASC";

        }
        else if (e.SortExpression == "Active")
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
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTestGroup.Enabled = true;
        FillTestGroupDDl();
        FillTestddl();
        FillGV();
    }
    protected void FillTestGroupDDl()
    {

        clsBLTestGroupD obj_GroupD = new clsBLTestGroupD();
        obj_GroupD.SectionID = ddlSubDepartment.SelectedValue.ToString();
        SComponents objComp = new SComponents();
        DataView dv = obj_GroupD.GetAll(2);
        if (dv.Count > 0)
        {
            lblErrMsg.Text = "";
            objComp.FillDropDownList(ddlTestGroup, dv, "TESTGROUP", "TESTGROUPID");

        }
        else
        {
            ddlTestGroup.ClearSelection();
            ddlTestGroup.Enabled = false;
            ddlTest.ClearSelection();
            ddlTest.Enabled = false;
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            this.lblErrMsg.Text = "No Test Group Found";
            this.lblGroupTotal.Text = "";
            this.lblCount.Text = "";
        }
        dv.Dispose();
        obj_GroupD = null;
    }


    protected void FillGV()
    {
        clsBLTestGroupD obj_grid = new clsBLTestGroupD();
        obj_grid.SectionID = ddlSubDepartment.SelectedValue.ToString();
        if (ddlTestGroup.SelectedValue.ToString() != "-1")
        {
            obj_grid.TestGroupID = ddlTestGroup.SelectedValue.ToString();
        }
        DataView dv=obj_grid.GetAll(5);
        dv.Sort = DGSort;
        gvTests.DataSource = dv;
        gvTests.DataBind();
        lblCount.Visible = true;
        lblCount.Text = gvTests.Rows.Count + " Rows Found";
    }
    protected void gvTests_RowCommand(object sender,GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            hdEdit.Value = "edit";
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdGroupDetail.Value = gvTests.DataKeys[rowindex].Value.ToString();
            ibtnSave.ToolTip = "Update";

            FillForm(rowindex);
        }
 
    }
    private void FillForm(int rowindex)
    {
        ddlSubDepartment.ClearSelection();
        ddlTestGroup.ClearSelection();
       
       
        ddlSubDepartment.Items.FindByText(gvTests.Rows[rowindex].Cells[1].Text).Selected = true;
        ddlTestGroup.Items.FindByText(gvTests.Rows[rowindex].Cells[2].Text).Selected = true;
        ddlTestGroup.Enabled = false;
        FillTestddl();
        ddlTest.ClearSelection();
        ddlTest.Items.FindByText(gvTests.Rows[rowindex].Cells[3].Text).Selected = true;
        this.chkActive.Checked = ((CheckBox)this.gvTests.Rows[rowindex].Cells[5].FindControl("dgchkActive")).Checked;
        FillCharges();
    }
    protected void ddlTestGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTest.Enabled = true;
        FillTestddl();
        FillGV();
        if (ddlTestGroup.SelectedValue.ToString() != "-1")
        {
            double grouptotal = 0;
            for (int i = 0; i < gvTests.Rows.Count; i++)
            {
                grouptotal += Convert.ToDouble(gvTests.Rows[i].Cells[4].Text);

            }
            lblGroupTotal.Visible = true;
            lblGroupTotal.Text = "Group Total:" + grouptotal;
        }
        else
        {
            lblGroupTotal.Visible = false;
        }
    }

    private void FillTestddl()
    {
        clsBLTestGroupD obj_Test = new  clsBLTestGroupD();
        obj_Test.SectionID = ddlSubDepartment.SelectedValue.ToString();

        SComponents objComp = new SComponents();
        DataView dv = obj_Test.GetAll(3);
        if (dv.Count > 0)
        {
            lblErrMsg.Text = "";
            objComp.FillDropDownList(ddlTest, dv, "TEST", "TESTID");

        }
        else
        {
            ddlTest.Enabled = false;
            this.lblErrMsg.Text = "No Test Found";
        }
        dv.Dispose();
        obj_Test = null;

    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillCharges();
    }

    private void FillCharges()
    {
        clsBLTestGroupD obj_charges = new clsBLTestGroupD();
        obj_charges.TestID = ddlTest.SelectedValue.ToString();
        obj_charges.TestGroupID = ddlTestGroup.SelectedValue.ToString();
        DataView dv = obj_charges.GetAll(4);
        if (dv.Count > 0)
        {
            txtCharges.Text = dv[0]["Charges"].ToString();
            txtRate.Text = dv[0]["Rate"].ToString();
        }
        else
        {
            txtCharges.Text = "";
            txtRate.Text = "";
        }
    }
    protected void groupTotal()
    {
        double grouptotal = 0;
        for (int i = 0; i < gvTests.Rows.Count; i++)
        {
            grouptotal += Convert.ToDouble(gvTests.Rows[i].Cells[4].Text);

        }
        lblGroupTotal.Visible = true;
        lblGroupTotal.Text = "Group Total:" + grouptotal;
    }
}