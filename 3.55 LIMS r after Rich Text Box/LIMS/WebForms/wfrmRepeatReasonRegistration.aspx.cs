using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmRepeatReasonRegistration : System.Web.UI.Page
{
    private static string mode = "";
    private static string DGSort = "Reason ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "112";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                mode = "Insert";
                //txtOrganismID.Text = "";
                FillDG();
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }

    }

    private void FillDG()
    {
        clsBLRepeatReasons obj_Reasons = new clsBLRepeatReasons();
        DataView dv_Reasons = obj_Reasons.GetAll(1);
        if (dv_Reasons.Count > 0)
        {
            lblCount.Visible = true;
            lblCount.Text = "(" + dv_Reasons.Count + ") Record(s) Found";
            dv_Reasons.Sort = DGSort;
            dgReasons.DataSource = dv_Reasons;
            dgReasons.DataBind();
        }

        else
        {
            lblCount.Visible = false;
        }
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        this.lblErrMSg.Text = "";

        if (mode.Equals("Insert"))
        {
            Insert();
        }
        else
        {
            Update();
        }
    }

    private void Insert()
    {
        clsBLRepeatReasons objReasons = new clsBLRepeatReasons();

        objReasons.Reason = this.txtReason.Text.Replace("&nbsp;", "");
        objReasons.Active = (this.chkActive.Checked == true) ? "Y" : "N";
        //objReasons.Acronym = this.txtAcronym.Text.Replace("&nbsp;", "");
        objReasons.Description = this.txtDescription.Text.Replace("&nbsp;", "");
        objReasons.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objReasons.EnteredBy = this.Session["loginid"].ToString();
        objReasons.ClientID = "0005";

        if (objReasons.Insert())
        {
            this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
            RefreshForm();
            FillDG();
        }
        else
        {
            this.lblErrMSg.Text = "<br>" + objReasons.ErrorMessage + "<br><br>";
        }
    }

    private void Update()
    {
        clsBLRepeatReasons objReasons = new clsBLRepeatReasons();

       // objReasons.OrganismID = txtOrganismID.Text;
        objReasons.RepeatReasonID = ReasonID.Value.ToString();
        objReasons.Reason = txtReason.Text.Replace("&nbsp;", "");
        //objReasons.Acronym = this.txtAcronym.Text.Replace("&nbsp;", "");
        objReasons.Active = (this.chkActive.Checked == true) ? "Y" : "N";
        objReasons.Description = this.txtDescription.Text.Replace("&nbsp;", "");
        objReasons.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objReasons.EnteredBy = this.Session["loginid"].ToString();
        objReasons.ClientID = "0005";

        if (objReasons.Update())
        {
            this.lblErrMSg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
            RefreshForm();
            FillDG();
        }
        else
        {
            this.lblErrMSg.Text = "<br>" + objReasons.ErrorMessage + "<br><br>";
        }
    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        this.lblErrMSg.Text = "";
        RefreshForm();
    }

    private void RefreshForm()
    {
        this.chkActive.Checked = true;
        this.txtReason.Text = "";
        this.ibtnSave.ToolTip = "Insert";
        this.txtDescription.Text = "";
        mode = "Insert";
        
    }

    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }

    protected void dgReasons_ItemCommand(object sender, DataGridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            this.lblErrMSg.Text = "";
            this.ibtnSave.ToolTip = "Update";
            mode = "Update";
            int index = e.Item.ItemIndex;
            ReasonID.Value = e.Item.Cells[1].Text;
           // txtOrganismID.Text = e.Item.Cells[0].Text.Replace("&nbsp;", "");
            this.txtReason.Text = e.Item.Cells[2].Text.Replace("&nbsp;", "");
            //this.txtAcronym.Text = e.Item.Cells[2].Text.Replace("&nbsp;", "");
            this.chkActive.Checked = ((CheckBox)e.Item.Cells[4].FindControl("dgchkActive")).Checked;
            this.txtDescription.Text = e.Item.Cells[3].Text.Replace("&nbsp;", "");
        }	
    }

    protected void dgReasons_Sorting(object sender, DataGridSortCommandEventArgs e)
    {
        if (e.SortExpression == "Reason")
        {
            if (DGSort == "Reason ASC")
            {
                DGSort = "Reason DESC";
            }
            else
                DGSort = "Reason ASC";

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
        FillDG();
    }

}