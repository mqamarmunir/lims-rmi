using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmSopTypes : System.Web.UI.Page
{
    private static string mode = "";
    private static string DGSort = "Name ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "116";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillDDLProcess();
                FillDDLPersons();
                FillGV();
            }
        }

    }

    private void FillDDLProcess()
    {
        clsBLTestProcess obj_TestProcess = new clsBLTestProcess();
        DataView dv_Processes = obj_TestProcess.GetAll(4);
        if (dv_Processes.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlProcess, dv_Processes, "Process", "ProcessID");
            obj_Comp = null;
        }
        dv_Processes.Dispose();
        obj_TestProcess = null;
 
    }
    private void FillDDLPersons()
    {
        clsBlSopTypes obj_types = new clsBlSopTypes();
        obj_types.DepartmentId = "011";
        DataView dv_persons = obj_types.GetAll(5);
        obj_types = null;
        if (dv_persons.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlPersons, dv_persons, "Name", "PersonID");
            obj_Comp = null;

        }
        dv_persons.Dispose();


 
    }

    private void FillGV()
    {
        clsBlSopTypes obj_Sops = new clsBlSopTypes();
        DataView dv_Types = obj_Sops.GetAll(1);
        if (dv_Types.Count > 0)
        {
            dv_Types.Sort = DGSort;
            gvTypes.DataSource = dv_Types;
            gvTypes.DataBind();
        }
        dv_Types.Dispose();
        obj_Sops = null;
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            clsBlSopTypes obj_Sops = new clsBlSopTypes();
            obj_Sops.SopTypeID = hdSopTypeID.Value.ToString();
            obj_Sops.Name = txtSopType.Text;
            obj_Sops.ProcessID = ddlProcess.SelectedValue.ToString();
            obj_Sops.Active = chkActive.Checked == true ? "Y" : "N";

            obj_Sops.EnteredBy = Session["loginid"].ToString();
            obj_Sops.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Sops.ClientID = "0005";
            obj_Sops.System_Ip = Request.UserHostAddress.ToString();
            obj_Sops.ApprovedBy = ddlPersons.SelectedValue.ToString();
            obj_Sops.ApprovedOn = txtApprovedOn.Text;
            obj_Sops.ApplicableDate = txtApplicable.Text;
            if (obj_Sops.Update())
            {

                FillGV();
                RefreshForm();
                this.lblErrMSg.Text = "<font color='Green'>Record Updated Successfully</font>";
            }
            else
            {
                this.lblErrMSg.Text = obj_Sops.ErrorMessage;
            }
        }

        else
        {
            clsBlSopTypes obj_Sops = new clsBlSopTypes();
            
            obj_Sops.Name = txtSopType.Text;
            obj_Sops.ProcessID = ddlProcess.SelectedValue.ToString();
            obj_Sops.Active = chkActive.Checked == true ? "Y" : "N";

            obj_Sops.EnteredBy = Session["loginid"].ToString();
            obj_Sops.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Sops.ClientID = "0005";
            obj_Sops.System_Ip = Request.UserHostAddress.ToString();
            obj_Sops.ApprovedBy = ddlPersons.SelectedValue.ToString();
            obj_Sops.ApprovedOn = txtApprovedOn.Text;
            obj_Sops.ApplicableDate = txtApplicable.Text;
            if (obj_Sops.insert())
            {

                FillGV();
                RefreshForm();
                this.lblErrMSg.Text = "<font color='Green'>Record Updated Successfully</font>";
            }
            else
            {
                this.lblErrMSg.Text = obj_Sops.ErrorMessage;
            }
        }

    }

    private void RefreshForm()
    {
        txtSopType.Text = "";
        mode = "save";
        this.ibtnSave.ToolTip = "insert";
        this.ddlProcess.ClearSelection();
        //this.ddlTest.ClearSelection();
        this.lblErrMSg.Text = "";
        this.txtApplicable.Text = "";
        this.txtApprovedOn.Text = "";
        this.ddlPersons.ClearSelection();
 
    }

    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");

    }
    protected void gvTypes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            hdSopTypeID.Value = gvTypes.DataKeys[index].Values[0].ToString();

            FillForm(index);
            mode = "Update";
            ibtnSave.ToolTip = "Update";

        }
    }
    private void FillForm(int rowindex)
    {
        this.ddlProcess.ClearSelection();
        this.ddlProcess.Items.FindByValue(gvTypes.DataKeys[rowindex].Values[1].ToString()).Selected = true;
        this.chkActive.Checked = ((CheckBox)gvTypes.Rows[rowindex].Cells[4].FindControl("gvchkActive")).Checked == true ? true : false;
        this.ddlPersons.ClearSelection();
        if (gvTypes.DataKeys[rowindex].Values[2].ToString() != "")
        {
            try
            {
                this.ddlPersons.Items.FindByValue(gvTypes.DataKeys[rowindex].Values[2].ToString()).Selected = true;
            }
            catch
            { 
            }
        }
        this.txtApplicable.Text = (DateTime.Parse(gvTypes.Rows[rowindex].Cells[3].Text)).ToString("dd/MM/yyyy");
        this.txtApprovedOn.Text = DateTime.Parse(gvTypes.DataKeys[rowindex].Values[3].ToString()).ToString("dd/MM/yyyy");
       
        this.txtSopType.Text = gvTypes.Rows[rowindex].Cells[1].Text.Trim();
    }

}