using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmHistoryDisplay : System.Web.UI.Page
{
    protected static string mode = "insert";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                mode = "insert";
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
                if (Session["dt"] != "")
                {
                    Session["dt"] = "";
                }
                lblLabID.Text = Request.QueryString["labid"].ToString().Trim();
                lblPRno.Text = Request.QueryString["PRNo"].ToString().Trim();
                FillPatientInfo();
                Fillhistory();
            }
        }
    }
    private void FillPatientInfo()
    {
        clsBlHistoryTaking obj_history = new clsBlHistoryTaking();
        obj_history.LabID = Request.QueryString["labid"].ToString().Trim();
        obj_history.PRNo = Request.QueryString["PRNo"].ToString().Trim();

        DataView dv_patientinfo = obj_history.GetAll(1);
        if (dv_patientinfo.Count > 0)
        {
            lblName.Text = dv_patientinfo[0]["PatientCompleteName"].ToString().Trim();
            lblAge.Text = dv_patientinfo[0]["PAgeD"].ToString().Trim() + " " + dv_patientinfo[0]["PageUN"].ToString().Trim();
            lblSex.Text = dv_patientinfo[0]["PSex"].ToString().Trim();

        }
        dv_patientinfo.Dispose();
        obj_history = null;

    }

    private void Fillhistory()
    {
        clsBlHistoryTaking obj_history = new clsBlHistoryTaking();
        obj_history.LabID = lblLabID.Text.Trim();
        obj_history.PRNo = lblPRno.Text.Trim();
        obj_history.TestID = Request.QueryString["testid"].ToString().Trim();
        DataView dv_history = obj_history.GetAll(2);
        if (dv_history.Count > 0)
        {
            mode = "update";
            hdHistoryTakingID_A.Value = dv_history[0]["HistoryTakingAID"].ToString().Trim();
            txtPresenthistory.Text = dv_history[0]["PresentHistory"].ToString();
            txtPasthistory.Text = dv_history[0]["Pasthistory"].ToString();
            txtTransfusionhistory.Text = dv_history[0]["Transfusionhistory"].ToString();
            txtFamilyhistory.Text = dv_history[0]["Familyhistory"].ToString();
            txtComplaintsPresent.Text = dv_history[0]["C_PresentHistory"].ToString();
            txtComplaintsPast.Text = dv_history[0]["C_PastHistory"].ToString();
            txtComplaintsTrans.Text = dv_history[0]["C_TransfusionHistory"].ToString();
            txtComplaintsFamily.Text = dv_history[0]["C_FamilyHistory"].ToString();
            txttreatment.Text = dv_history[0]["TreatmentTaken"].ToString();
            txtTemperature.Text = dv_history[0]["Temperature"].ToString();
            txtPulse.Text = dv_history[0]["PulseRate"].ToString();
            txtBloodPressure.Text = dv_history[0]["BloodPressure"].ToString();

        }

        dv_history = obj_history.GetAll(3);
        if (dv_history.Count > 0)
        {
            DataTable dt = dv_history.ToTable();


            Session["dt"] = dt;
            gvClinical.DataSource = dt;
            gvClinical.DataBind();

        }
        dv_history.Dispose();


    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "update")
        {
            Update();
        }
        else
        {
            Insert();
        }
    }

    private void Insert()
    {
        clsBlHistoryTaking obj_Hist = new clsBlHistoryTaking();
        obj_Hist.PRNo = lblPRno.Text.Trim();
        obj_Hist.LabID = lblLabID.Text.Trim();
        obj_Hist.TestID = Request.QueryString["testid"].ToString().Trim();
        obj_Hist.PresentHistory = txtPresenthistory.Text;
        obj_Hist.Pasthistory = txtPasthistory.Text;
        obj_Hist.TransfusionHistory = txtTransfusionhistory.Text;
        obj_Hist.FamilyHistory = txtFamilyhistory.Text;
        obj_Hist.C_PresentHistory = txtComplaintsPresent.Text;
        obj_Hist.C_Pasthistory = txtComplaintsPast.Text;
        obj_Hist.C_TransfusionHistory = txtComplaintsTrans.Text;
        obj_Hist.C_FamilyHistory = txtComplaintsFamily.Text;
        obj_Hist.TreatmentTaken = txttreatment.Text;
        obj_Hist.Temperature = txtTemperature.Text;
        obj_Hist.PulseRate = txtPulse.Text;
        obj_Hist.BloodPressure = txtBloodPressure.Text;
        obj_Hist.EnteredBy = Session["loginid"].ToString().Trim();
        obj_Hist.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_Hist.ClientID = "0005";
        obj_Hist.System_Ip = Request.UserHostAddress.ToString();
        if (obj_Hist.Insert1())
        {
            int count = 0;
            for (int i = 0; i < gvClinical.Rows.Count; i++)
            {
                obj_Hist.FieldName = gvClinical.Rows[i].Cells[1].Text.Trim();
                obj_Hist.Description = gvClinical.Rows[i].Cells[2].Text.Trim();
                obj_Hist.Active = "Y";
                if (obj_Hist.Insert2())
                {
                    count++;
                }
            }
            if (count == gvClinical.Rows.Count)
            {
                lblErrMsg.Text = "<font color='green'>Record inserted Successfully</font>";
                RefreshForm();
                Response.Write("<script language='javascript'>self.close();</script>");
            }
        }

    }

    private void Update()
    {
        clsBlHistoryTaking obj_Hist = new clsBlHistoryTaking();
        obj_Hist.HistoryTakingAID = hdHistoryTakingID_A.Value.ToString().Trim();
        obj_Hist.PRNo = lblPRno.Text.Trim();
        obj_Hist.LabID = lblLabID.Text.Trim();
        obj_Hist.TestID = Request.QueryString["testid"].ToString().Trim();
        obj_Hist.PresentHistory = txtPresenthistory.Text;
        obj_Hist.Pasthistory = txtPasthistory.Text;
        obj_Hist.TransfusionHistory = txtTransfusionhistory.Text;
        obj_Hist.FamilyHistory = txtFamilyhistory.Text;
        obj_Hist.C_PresentHistory = txtComplaintsPresent.Text;
        obj_Hist.C_Pasthistory = txtComplaintsPast.Text;
        obj_Hist.C_TransfusionHistory = txtComplaintsTrans.Text;
        obj_Hist.C_FamilyHistory = txtComplaintsFamily.Text;
        obj_Hist.TreatmentTaken = txttreatment.Text;
        obj_Hist.Temperature = txtTemperature.Text;
        obj_Hist.PulseRate = txtPulse.Text;
        obj_Hist.BloodPressure = txtBloodPressure.Text;
        obj_Hist.EnteredBy = Session["loginid"].ToString().Trim();
        obj_Hist.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_Hist.ClientID = "0005";
        obj_Hist.System_Ip = Request.UserHostAddress.ToString();
        if (obj_Hist.Update1())
        {
            int count = 0;
            if (obj_Hist.DeletePrevious())
            {
                for (int i = 0; i < gvClinical.Rows.Count; i++)
                {
                    obj_Hist.FieldName = gvClinical.Rows[i].Cells[1].Text.Trim();
                    obj_Hist.Description = gvClinical.Rows[i].Cells[2].Text.Trim();
                    obj_Hist.Active = "Y";
                    if (obj_Hist.Insert2())
                    {
                        count++;
                    }
                }
                if (count == gvClinical.Rows.Count)
                {
                    lblErrMsg.Text = "<font color='green'>Record inserted Successfully</font>";
                    RefreshForm();
                    Response.Write("<script language='javascript'>self.close();</script>");
                }
            }
        }
    }
    private void RefreshForm()
    {
        txtPresenthistory.Text = "";
        txtPasthistory.Text = "";
        txtTransfusionhistory.Text = "";
        txtFamilyhistory.Text = "";
        txtComplaintsFamily.Text = "";
        txtComplaintsPast.Text = "";
        txtComplaintsPresent.Text = "";
        txtComplaintsTrans.Text = "";
        txttreatment.Text = "";
        txtTemperature.Text = "";
        txtPulse.Text = "";
        txtBloodPressure.Text = "";
        mode = "insert";
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "";
        RefreshForm();

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }

    protected void gvimgEdit_Click(object sender, CommandEventArgs e)
    {

    }

    protected void gvimgDelete_Click(object sender, CommandEventArgs e)
    {
        int index = Convert.ToInt16(e.CommandArgument);
        DataTable dt = (DataTable)Session["dt"];
        dt.Rows.RemoveAt(index);
        gvClinical.DataSource = dt;
        gvClinical.DataBind();

    }

    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = new DataTable();
        createTable(dt);
        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

        if (dt.Columns.Count == 0)
        {
            createTable(dt);
            Session["dt"] = dt;
        }

        DataRow dr = dt.NewRow();
        dr["FieldName"] = txtclName.Text;
        dr["Description"] = txtclDescription.Text;
        dt.Rows.Add(dr);
        txtclDescription.Text = "";
        txtclName.Text = "";
        gvClinical.DataSource = dt;
        gvClinical.DataBind();
    }

    private void createTable(DataTable dt)
    {
        dt.Columns.Add("FieldName");
        dt.Columns.Add("Description");
    }
}