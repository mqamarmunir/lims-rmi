using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmCollectionCenterrecieving : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {


            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "136";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillGv();

            }
        }
        else
        {

            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");

        }
    }
    private void FillGv()
    {
        ExternalSamples objexternalsamples = new ExternalSamples();
        DataView dv = objexternalsamples.GetAll(1);
        if (dv.Count > 0)
        {
            lblCount.Visible = true;
            lblCount.Text = "<font color='green'>" + dv.Count + " New Records found.</font>";
            gvTests.DataSource = dv;
            gvTests.DataBind();
            txtSearch.Focus();
        }
        else 
        {
            lblCount.Visible = false;
            Response.Write("<script language='javascript'>alert('No Pending Specimen.');</script>");
        }
 
    }
    protected void gvTests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //string abc = ((WebControl)e.CommandSource).NamingContainer.ToString();
        //GridViewRow gvr=(GridViewRow)((WebControl)e.CommandSource).NamingContainer;
        if (e.CommandName == "Recieved")
        {
            ExternalSamples objsamples = new ExternalSamples();
            objsamples.EnteredBy = Session["loginid"].ToString().Trim();
            objsamples.MserialNo = gvTests.DataKeys[int.Parse(e.CommandArgument.ToString())].Values["MserialNo"].ToString().Trim();
            objsamples.DSerialNo = gvTests.DataKeys[int.Parse(e.CommandArgument.ToString())].Values["DSerialNo"].ToString().Trim();
            objsamples.CliqorderID = gvTests.DataKeys[int.Parse(e.CommandArgument.ToString())].Values["cliqorderid"].ToString().Trim();
            objsamples.cliqprocessid = "4";
            objsamples.processId = "0004";
            objsamples.cprocessid = "0011";
            if (objsamples.Update())
            {
                FillGv();
            }
            else
            {
                Response.Write("<script language='javascript'>alert('"+objsamples.ErrorMessage+"');</script>");
            }
        }
    }
}