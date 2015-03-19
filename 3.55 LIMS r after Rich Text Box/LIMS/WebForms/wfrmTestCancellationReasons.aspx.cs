using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
public partial class LIMS_WebForms_wfrmTestCancellationReasons : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "102";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                lblname.Text = Request.QueryString["Name"].ToString();
                lblLabID.Text = Request.QueryString["LabID"].ToString();
                FillGV();
            }
        }
    }
    protected void lnkbtnsave_Click(object sender, EventArgs e)
    {
        clsBLSpecimenColletion obj_Specimnecoll = new clsBLSpecimenColletion();
        obj_Specimnecoll.LabID = lblLabID.Text;
        obj_Specimnecoll.MStatus = "C";
        obj_Specimnecoll.CancelReason = txtReason.Text;

        if (obj_Specimnecoll.updatestatus())
        {
            Response.Write("<script language='javascript'> alert('Test cancelled');</script>");
            Response.Write("<script language='javascript'> window.close();</script>");
        }
        else
        {
            LblMessage.Text = obj_Specimnecoll.ErrorMessage;
        }

    }
    protected void gvReasons_SelectedIndexChanged(object sender, GridViewSelectEventArgs e)
    {
        
        string reason =  gvReasons.Rows[e.NewSelectedIndex].Cells[1].Text;
        clsBLSpecimenColletion obj_Specimnecoll = new clsBLSpecimenColletion();
        obj_Specimnecoll.LabID = lblLabID.Text;
        obj_Specimnecoll.MStatus = "C";
        obj_Specimnecoll.CancelReason = reason;

        if (obj_Specimnecoll.updatestatus())
        {
            Response.Write("<script language='javascript'> alert('Test cancelled');</script>");
            Response.Write("<script language='javascript'> window.close();</script>");
        }
        else
        {
            LblMessage.Text = obj_Specimnecoll.ErrorMessage;
        }
        
    }

    private void FillGV()
    {
        clsBLSpecimenColletion obj_Collection = new clsBLSpecimenColletion();
        DataView dv_reason = obj_Collection.GetAll(4);
        if (dv_reason.Count>0)
        {
            gvReasons.DataSource = dv_reason;
            gvReasons.DataBind();
        }
            
    }
}