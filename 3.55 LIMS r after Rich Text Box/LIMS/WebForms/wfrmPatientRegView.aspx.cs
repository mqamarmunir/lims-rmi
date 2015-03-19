using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmPatientRegView : System.Web.UI.Page
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

                txtFrom.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtTo.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                Fillgv();
            }
        }
    }
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        Fillgv();
            //PatientRegView prv = new PatientRegView();
            //        prv.FromDate = txtFrom.Text.Trim();
            //        prv.ToDate = txtTo.Text.Trim();
            //        DataView dv = prv.GetAll(18);
            //        if (dv.Count > 0)
            //        {
            //            gvVisitReg.DataSource = dv;
            //            gvVisitReg.DataBind();
            //        }

    }
    protected void gvPatientVisitReg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Select"))
        {
            int index = Convert.ToInt32(e.CommandArgument);
            lblPRNO.Text = gvVisitReg.Rows[index].Cells[1].Text.Trim();
            lblVisitno.Text = gvVisitReg.Rows[index].Cells[2].Text.Trim();
            Response.Redirect("wfrmReceptionLab.aspx?prno="+gvVisitReg.Rows[index].Cells[1].Text.Trim()+"&visitno="+gvVisitReg.Rows[index].Cells[2].Text.Trim());

        }
    }
    protected void gvVisitReg_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvVisitReg.PageIndex = e.NewPageIndex;
        Fillgv();
    }
    protected void gvVisitReg_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }
    protected void btnRefresh_Click(object sender, ImageClickEventArgs e)
    {
        Fillgv();
        //PatientRegView prv = new PatientRegView();
        //prv.FromDate = txtFrom.Text.Trim();
        //prv.ToDate = txtTo.Text.Trim();
        //DataView dv = prv.GetAll(2);
        //if (dv.Count > 0)
        //{
        //    gvVisitReg.DataSource = dv;
        //    gvVisitReg.DataBind();
        //}
    }

    protected void Fillgv()
    {
        PatientRegView prv = new PatientRegView();
        prv.FromDate = txtFrom.Text.Trim()+" 12:00:00 am";
        prv.ToDate = txtTo.Text.Trim()+" 11:59:59 pm";
        DataView dv = prv.GetAll(18);
        if (dv.Count > 0)
        {
            gvVisitReg.DataSource = dv;
            gvVisitReg.DataBind();
        }
 
    }
}
