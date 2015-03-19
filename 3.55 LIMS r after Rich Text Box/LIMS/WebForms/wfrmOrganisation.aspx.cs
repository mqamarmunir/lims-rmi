//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Data;
//using LS_BusinessLayer;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using LS_BusinessLayer;
using System.Data;

public partial class LIMS_wfrmOrganisation : System.Web.UI.Page
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
                UMatrix.FormID = "125";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillGrid();
                chkActive.Checked = true;
                chkExternal.Checked = true;

                // FillGV();


            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }



    //    if (Session["loginid"] == String.Empty)
    //    {
    //        Response.Redirect("~/login.aspx");
    //    }
        //if (!IsPostBack)
        //{
        //    FillGrid();
        //    chkActive.Checked = true;
        //    chkExternal.Checked = true;
        //}

    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLExternalOrganization eOrg = new clsBLExternalOrganization();
        if (mode == "")
        {
            eOrg.Name = txtName.Text.Trim().Replace("'", "");
            eOrg.Acronym = txtAcronym.Text.Trim().Replace("'", "");
            if (chkActive.Checked)
            {
                eOrg.Active = "Y";
            }
            else
            {
                eOrg.Active = "N";
            }
            eOrg.PhoneNo = txtPhoneNumber.Text.Trim().Replace("'", "");
            eOrg.FaxNo = txtFaxNumber.Text.Trim().Replace("'", "");
            eOrg.Email = txtEmail.Text.Trim().Replace("'", "");
            eOrg.WebAddress = txtWebAddress.Text.Trim().Replace("'", "");
            eOrg.PostalAddress = txtPostalAddress.Text.Trim().Replace("'", "");
            eOrg.EnteredBy = Session["loginid"].ToString();
            eOrg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            eOrg.ClientId = "005";
            if (chkExternal.Checked)
            {
                eOrg.External = "Y";
            }
            else
            {
                eOrg.External = "N";
            }

            if (eOrg.insert())
            {
                lblErrMsg.Text = "Record Inserted Successfully";
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                FillGrid();
                ClearAll();
            }
            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = eOrg.ErrorMessage;
            } 
        }
        else if (mode == "Update")
        {
            eOrg.OrganizationId = hfOrgId.Value;
            eOrg.Name = txtName.Text.Trim().Replace("'", "");
            eOrg.Acronym = txtAcronym.Text.Trim().Replace("'", "");
            if (chkActive.Checked)
            {
                eOrg.Active = "Y";
            }
            else
            {
                eOrg.Active = "N";
            }
            eOrg.PhoneNo = txtPhoneNumber.Text.Trim().Replace("'", "");
            eOrg.FaxNo = txtFaxNumber.Text.Trim().Replace("'", "");
            eOrg.Email = txtEmail.Text.Trim().Replace("'", "");
            eOrg.WebAddress = txtWebAddress.Text.Trim().Replace("'", "");
            eOrg.PostalAddress = txtPostalAddress.Text.Trim().Replace("'", "");
            eOrg.EnteredBy = Session["loginid"].ToString();
            eOrg.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            eOrg.ClientId = "005";
            if (chkExternal.Checked)
            {
                eOrg.External = "Y";
            }
            else
            {
                eOrg.External = "N";
            }

            if (eOrg.update())
            {
                lblErrMsg.Text = "Record Updated Successfully";
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                FillGrid();
                ClearAll();
            }
            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = eOrg.ErrorMessage;
            }
        }
    }

    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();
        lblErrMsg.Text = "";
    }

    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./wfrmMainMenu.aspx");
    }

    protected void gvOrganisation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            FillForm(index);
            mode = "Update";
            ibtnSave.ToolTip = "Update";

        }

    }

    public void FillGrid()
    {
        clsBLExternalOrganization eOrg = new clsBLExternalOrganization();
        DataView dv = eOrg.GetAll(1);
        gvOrganisation.DataSource = dv;
        gvOrganisation.DataBind();
    }



    public void FillForm(int rowindex)
    {
        txtName.Text = gvOrganisation.Rows[rowindex].Cells[1].Text;
        txtAcronym.Text = gvOrganisation.Rows[rowindex].Cells[2].Text;
        txtPhoneNumber.Text = gvOrganisation.Rows[rowindex].Cells[3].Text;
        chkActive.Checked = ((CheckBox)gvOrganisation.Rows[rowindex].Cells[6].FindControl("chkgvActive")).Checked ? true : false;
        chkExternal.Checked = ((CheckBox)gvOrganisation.Rows[rowindex].Cells[7].FindControl("chkgvExternal")).Checked ? true : false;
        hfOrgId.Value =gvOrganisation.DataKeys[rowindex].Values[0].ToString();
        txtFaxNumber.Text = gvOrganisation.DataKeys[rowindex].Values[1].ToString();
        txtEmail.Text = gvOrganisation.DataKeys[rowindex].Values[2].ToString();
        txtWebAddress.Text = gvOrganisation.DataKeys[rowindex].Values[3].ToString();
        txtPostalAddress.Text = gvOrganisation.DataKeys[rowindex].Values[4].ToString();
    }

    public void ClearAll()
    {
        txtAcronym.Text = "";
        txtEmail.Text = "";
        txtFaxNumber.Text = "";
        txtName.Text = "";
        txtPhoneNumber.Text = "";
        txtPostalAddress.Text = "";
        txtWebAddress.Text = "";
        chkActive.Checked = true;
        chkExternal.Checked = true;
        mode = "";
        ibtnSave.ToolTip = "Save";

    }

    protected bool GetStatus(string str)
    {
        if (str == "Y")
            return true;
        else
            return false;
    }



   
}