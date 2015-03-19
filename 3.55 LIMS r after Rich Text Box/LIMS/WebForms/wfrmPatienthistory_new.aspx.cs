using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;


public partial class LIMS_WebForms_wfrmPatienthistory_new : System.Web.UI.Page
{
   private  static string sSex = "";
   private static string PAgeIndays = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            // Response.AddHeader("Refresh", "10");
            if (!IsPostBack)
            {
                txtPRNumber.Focus();
               
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "120";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");

    }
    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        fieldlabs.Visible = true;
        clsBlPatienttesthistory obj_patienthistory = new clsBlPatienttesthistory();
        obj_patienthistory.PrNo = txtPRNumber.Text.Trim();
        FillPatientinfo(txtPRNumber.Text.Trim());
        DataView dv_patienthistory = obj_patienthistory.GetAll(1);
        //obj_patienthistory = null;
        if (dv_patienthistory.Count > 0)
        {
            //sSex = dv_patienthistory[0]["PSex"].ToString();
            // PAgeIndays = dv_patienthistory[0]["PAgeinDays"].ToString();
            gvPatientLabs.DataSource = dv_patienthistory;
            gvPatientLabs.DataBind();
        }
        else
        {
            fieldlabs.Visible = false;
            lblErrMsg.Text = "Sorry! No laboratory Record Found.";
        }
        dv_patienthistory.Dispose();
        DataView dv_Tests = obj_patienthistory.GetAll(3);
        if (dv_Tests.Count > 0)
        {
            gvTests.DataSource = dv_Tests;
            gvTests.DataBind();
        }
        dv_Tests.Dispose();

    }

    private void FillPatientinfo(string PrNumber)
    {
        fieldpatientinfo.Visible = true;
        clsBlPatienttesthistory obj_patienthistory = new clsBlPatienttesthistory();
        obj_patienthistory.PrNo = PrNumber;
        DataView dv_patientinfo = obj_patienthistory.GetAll(2);
        obj_patienthistory = null;
        if (dv_patientinfo.Count > 0)
        {
            lblName.Text = dv_patientinfo[0]["Name"].ToString();
            lblgender.Text = dv_patientinfo[0]["Gender"].ToString();
            lblAddress.Text = dv_patientinfo[0]["HAddress"].ToString();
            lblDOB.Text = dv_patientinfo[0]["DOB"].ToString();
            lblphNumber.Text = dv_patientinfo[0]["CellPhone"].ToString();
        }
        else
        {
            fieldlabs.Visible = false;
            fieldpatientinfo.Visible = false;
            lblErrMsg.Text = "No Patient Found with this PRNo.";
        }
        dv_patientinfo.Dispose();

 
    }
    protected void gvPatientlabs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string sMSerailno = "";
            string labid = "";
            int rowNum = int.Parse(e.CommandArgument.ToString());
            labid = ((LinkButton)gvPatientLabs.Rows[rowNum].Cells[1].Controls[0]).Text;
            
            sMSerailno = gvPatientLabs.Rows[rowNum].Cells[2].Text;
            Response.Write("<script language='javascript'>window.open('wfrmAllTestsinonelab.aspx?id=" + sMSerailno + "&labid="+labid+"&PSex="+sSex+"&PAge="+PAgeIndays+"');</script>");

        }
    }

    protected void gvTests_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string testid = "";
            string PRNo="";
            int rownum = int.Parse(e.CommandArgument.ToString());
            PRNo = txtPRNumber.Text;
            testid = gvTests.DataKeys[rownum].Value.ToString().Trim();
            //testid=((LinkButton)gvTests.Rows[rownum].Cells[1].Controls[0]).Text;
            Response.Write("<script language='javascript'>window.open('wfrmTesthistory.aspx?TestID=" + testid + "&PRNo=" + PRNo + "&PSex=" + sSex + "&PAge=" + PAgeIndays + "');</script>");
        }
    }
}