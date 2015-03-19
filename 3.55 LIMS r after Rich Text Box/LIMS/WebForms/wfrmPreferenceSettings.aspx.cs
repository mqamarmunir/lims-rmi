using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmPreferenceSettings : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBLPreferenceSettings obj_preference = new clsBLPreferenceSettings();
        obj_preference.IndoorTime = txtIndoor.Text;
        obj_preference.OutdoorTime = txtOutdoor.Text;
       // obj_NatureRegistration.Active = chkActive.Checked == true ? "Y" : "N";
        obj_preference.icdEnabled = ICD.Checked == true ? "Y" : "N";
      //  //bool operation= obj_preference.insert();
      ////  if (operation)
      //  {
      // /     lblErrMsg.Text = "Insertion Successful";
      //      lblErrMsg.ForeColor = Color.Green;
      //  }

      //  else
      //  {
      //      lblErrMsg.Text = "Error Occured";
      //  }


    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        txtIndoor.Text = "";
        txtOutdoor.Text = "";
        ICD.Checked = false;
    }
}