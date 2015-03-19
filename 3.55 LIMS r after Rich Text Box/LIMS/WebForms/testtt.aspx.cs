using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_testtt : System.Web.UI.Page
{
    private static string DGSort = "CollTime_Indoor ASC";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "118";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                FillgridView();

            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }

    void FillgridView()
    {
        clsBLPreferenceSettings obj_preferencesettings = new clsBLPreferenceSettings();
        DataView dv = obj_preferencesettings.GetAll(1);
        dv.Sort = DGSort;
        gvPreference.DataSource = dv;
        gvPreference.DataBind();
 
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLPreferenceSettings obj_preference = new clsBLPreferenceSettings();
        obj_preference.IndoorTime = txtIndoor.Text;
        obj_preference.OutdoorTime = txtOutdoor.Text;
        // obj_NatureRegistration.Active = chkActive.Checked == true ? "Y" : "N";
        obj_preference.icdEnabled = ICD.Checked == true ? "Y" : "N";
        obj_preference.AttributeMax_min = txtPercent.Text;
        obj_preference.ResultEntryTime = txttimeResultEntry.Text;
        obj_preference.AutoVerify = chkAutoVerification.Checked == true ? "Y" : "N";
        obj_preference.AutoVerifyIndoor = (chkAutoVerificationIndoor.Checked) ? "Y" : "N";
        obj_preference.Img_Path = txtPath.Text;
        obj_preference.Doc_Path = txtPath_doc.Text;
        obj_preference.ThresholdTime = txtThreshold.Text.Trim();
        

        string _adnote = adnote.Text.Trim();
        _adnote = _adnote.Replace("<strong>", "<b>");
        _adnote = _adnote.Replace("</strong>", "</b>");
        _adnote = _adnote.Replace("<em>", "<i>");
        _adnote = _adnote.Replace("</em>", "</i>");
        obj_preference.Ad_Note = _adnote;
        if (hdEdit.Value == "edit")
        {
            obj_preference.PreferenceID = hdPreference.Value.ToString();
            obj_preference.update();
            FillgridView();
            ibtnClear_Click(sender, e);
        }
        else
        {
            if (obj_preference.insert())
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Green;
                lblErrMsg.Text = "Record inserted Successfully";
                FillgridView();
            }
            else
            {
                lblErrMsg.ForeColor = System.Drawing.Color.Red;
                lblErrMsg.Text = "Only one Entry is Allowed.";
            }
        }
      
    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        txtIndoor.Text = "";
        txtOutdoor.Text = "";
        ICD.Checked = false;
        hdEdit.Value = "";
        hdPreference.Value = "";
        lblErrMsg.Text = "";
        txtPercent.Text = "";
        txttimeResultEntry.Text = "";
        chkAutoVerification.Checked = false;
        txtPath.Text = "";
        txtPath_doc.Text = "";
        adnote.Text = "";
        txtThreshold.Text = "";
    }

    protected void gvPreference_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Response.Redirect("wfrmTestPriceUpdate.aspx");
        if (e.CommandName == "select")
        {

            hdEdit.Value = "edit";
            int rowindex = int.Parse(e.CommandArgument.ToString());
            txtIndoor.Text = gvPreference.Rows[rowindex].Cells[2].Text;
            txtOutdoor.Text = gvPreference.Rows[rowindex].Cells[3].Text;
            ICD.Checked = gvPreference.Rows[rowindex].Cells[4].Text == "Y" ? true : false;
            txtPercent.Text = gvPreference.Rows[rowindex].Cells[5].Text;
            txttimeResultEntry.Text=gvPreference.Rows[rowindex].Cells[6].Text;
            chkAutoVerification.Checked = gvPreference.Rows[rowindex].Cells[7].Text.Trim() == "Y" ? true : false;
            hdPreference.Value = gvPreference.DataKeys[rowindex].Values[0].ToString();
            txtPath.Text = gvPreference.Rows[rowindex].Cells[8].Text;
            txtPath_doc.Text = gvPreference.Rows[rowindex].Cells[9].Text;
            adnote.Text = gvPreference.DataKeys[rowindex].Values[2].ToString().Trim();
            txtThreshold.Text = gvPreference.Rows[rowindex].Cells[10].Text.Trim();
        }
        
 
    }
    protected void gvPreference_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "CollTime_Indoor")
        {
            if (DGSort == "CollTime_Indoor ASC")
            {
                DGSort = "CollTime_Indoor DESC";
            }
            else
                DGSort="CollTime_Indoor ASC";
        }

         if (e.SortExpression == "CollTime_OutDoor")
        {
            if (DGSort == "CollTime_OutDoor ASC")
            {
                DGSort="CollTime_OutDoor DESC";
            }
            else
                DGSort="CollTime_OutDoor ASC";
        }
         if (e.SortExpression == "ICD")
        {
            if (DGSort == "ICD ASC")
            {
                DGSort="ICD DESC";
            }
            else
                DGSort="ICD ASC";
        }

         if (e.SortExpression == "PreferenceID")
         {
             if (DGSort == "PreferenceID ASC")
             {
                 DGSort = "PreferenceID DESC";
             }
             else
                 DGSort = "PreferenceID ASC";
         }

         if (e.SortExpression == "Threshold_Time")
         {
             if (DGSort == "Threshold_Time")
             {
                 DGSort = "Threshold_Time DESC";
             }
             else
                 DGSort = "Threshold_Time ASC";
         }
         FillgridView();

    }

    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
    }
}