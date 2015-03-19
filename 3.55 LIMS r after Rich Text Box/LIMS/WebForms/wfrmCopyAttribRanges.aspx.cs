using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
public partial class LIMS_WebForms_wfrmCopyAttribRanges : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPress_Click(object sender, EventArgs e)
    {
        clsBLAttributeRange ar = new clsBLAttributeRange();
        ar.TestID = "000781";
        ar.MethodID = "0042";
        DataView dv_ar = ar.GetAll(3);
        int count = 0;
        if (dv_ar.Count > 0)
        {
            for (int i = 0; i < dv_ar.Count; i++)
            {
                ar.MethodID = "0124";
                ar.ProcedureID = dv_ar[i]["ProcedureID"].ToString().Trim();
                ar.AttributeID = dv_ar[i]["AttributeID"].ToString().Trim();
                ar.TestID = dv_ar[i]["TestID"].ToString().Trim();
                ar.TestGroupID = dv_ar[i]["TestGroupID"].ToString().Trim();
                ar.SectionID = dv_ar[i]["SectionID"].ToString().Trim();
                ar.Sex = dv_ar[i]["Sex"].ToString().Trim();
                ar.AgeMin = dv_ar[i]["AgeMin"].ToString().Trim();
                ar.AgeMax = dv_ar[i]["AgeMax"].ToString().Trim();
                ar.MinValue = dv_ar[i]["MinValue"].ToString().Trim();
                ar.MaxValue = dv_ar[i]["MaxValue"].ToString().Trim();
                ar.AUnit = dv_ar[i]["AUnit"].ToString().Trim();
                ar.AgeType = dv_ar[i]["AgeType"].ToString().Trim();
                ar.MinPValue = dv_ar[i]["MinPValue"].ToString().Trim();
                ar.MaxPValue = dv_ar[i]["MaxPValue"].ToString().Trim();
                ar.Enteredby = Session["loginid"].ToString().Trim();
                ar.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                //ar.Cli = "0005";
                ar.Interpretation=dv_ar[i]["Interpretation"].ToString().Trim();

                if (ar.Insertcopy())
                {
                    count++;
                }
            }
            if (count == dv_ar.Count)
            {
                btnPress.Visible = false;
                Label1.Visible = true;
                Label1.Text = "All Records inserted Successfully";
            }
        }
    }
}