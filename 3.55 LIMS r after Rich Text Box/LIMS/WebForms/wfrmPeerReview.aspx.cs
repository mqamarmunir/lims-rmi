using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
public partial class LIMS_WebForms_wfrmPeerReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "121";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillGV();
            }
        }
    }

    private void FillGV()
    {
        clsBlPeerReviews obj_peers = new clsBlPeerReviews();
        obj_peers.ReferredTo = Session["loginid"].ToString().Trim();
        DataView dv = obj_peers.GetAll(1);

        if (dv.Count > 0)
        {
            gvReviews.DataSource = dv;
            gvReviews.DataBind();
        }

        else
        {
            gvReviews.DataSource = "";
            gvReviews.DataBind();
        }
    }
    protected void ibtnSave_Click(object sender, CommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        clsBlPeerReviews obj_Reviews = new clsBlPeerReviews();
        obj_Reviews.Comments = ((TextBox)gvReviews.Rows[index].Cells[4].FindControl("txtComment")).Text;
        obj_Reviews.ReviewID = gvReviews.DataKeys[index].Values[1].ToString().Trim();
        obj_Reviews.Reviewed = "Y";

        if (obj_Reviews.Update())
        {
            lblErrMSg.Text = "<font color='green'>Comment Succesfully Added to the Review Test.</font>";
            FillGV();

        }
        else
        {
            lblErrMSg.Text = obj_Reviews.ErrorMessage;
        }

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void gvReviews_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    int index = Convert.ToInt16(e.CommandArgument);
        //    clsBlPeerReviews obj_Reviews = new clsBlPeerReviews();
        //    obj_Reviews.DSerialNo = gvReviews.DataKeys[index].Value.ToString().Trim();
        //    DataView dv_Result = obj_Reviews.GetAll(2);

        //    //if (dv_Result.Count > 0)
        //    //{
        //    //    divResult.Visible = true;
        //    //    gvResult.DataSource = dv_Result;
        //    //    gvResult.DataBind();

        //    //}
        //    //else
        //    //{
        //    //    divResult.Visible = false;
        //    //    gvResult.DataSource = "";
        //    //    gvResult.DataBind();
        //    //    lblErrMSg.Text = "No Result Found";
        //    //}
        //}
    }

    protected void gvlnkDetails_Click(object sender, CommandEventArgs e)
    {
        //lblNumber.Text = e.CommandArgument.ToString();
        //int index = Convert.ToInt16(e.CommandArgument);
        //clsBlPeerReviews obj_Reviews = new clsBlPeerReviews();
        //obj_Reviews.DSerialNo = gvReviews.DataKeys[index].Value.ToString().Trim();
        //DataView dv_Result = obj_Reviews.GetAll(2);

        //if (dv_Result.Count > 0)
        //{
        //    //divResult.Visible = true;
        //    gvResult.DataSource = dv_Result;
        //    gvResult.DataBind();

        //}
        //else
        //{
        //    divResult.Visible = false;
        //    gvResult.DataSource = "";
        //    gvResult.DataBind();
        //    lblErrMSg.Text = "No Result Found";
        //}
    }

    protected void gvReviews_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int index = e.Row.RowIndex;
            clsBlPeerReviews obj_Reviews = new clsBlPeerReviews();
            obj_Reviews.DSerialNo = gvReviews.DataKeys[index].Values[0].ToString().Trim();
            DataView dv_Result = obj_Reviews.GetAll(2);
            if (dv_Result.Count > 0)
            {
                GridView gvResult = e.Row.Cells[4].FindControl("gvResult") as GridView;
                gvResult.DataSource = dv_Result;
                gvResult.DataBind();
            }
        }
    }
}