using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmICD_Diseases : System.Web.UI.Page
{
    private static string DGSort = "DISEASENAME ASC";
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

                FillChaptersDDL();
                DisplayPatient();
               // FillGV();

            }
        }

    }

    private void DisplayPatient()
    {
        clsBLGeneralTestResult obj_generaltestresult = new clsBLGeneralTestResult();
        obj_generaltestresult.MSerialNo = Request.QueryString["MSerialNum"].ToString();
        obj_generaltestresult.ProcessID = Request.QueryString["ProcessID"].ToString();
        obj_generaltestresult.SectionID = Request.QueryString["SectionID"].ToString();
        obj_generaltestresult.TestType = Request.QueryString["Type"].ToString();

        DataView dvTGeneralTestResult = obj_generaltestresult.GetAll(2);
        if (dvTGeneralTestResult.Count > 0)
        {
            lblPName.Text = dvTGeneralTestResult.Table.Rows[0]["PatientName"].ToString();
            lblAge.Text = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
            lblAge.Text += ' ' + dvTGeneralTestResult.Table.Rows[0]["PAge"].ToString();
            lblWard.Text = dvTGeneralTestResult.Table.Rows[0]["WardName"].ToString();
            lblRefer.Text = dvTGeneralTestResult.Table.Rows[0]["REFERREDBY"].ToString();
            lblPType.Text = dvTGeneralTestResult.Table.Rows[0]["Type"].ToString();

        }
    }

    private void FillChaptersDDL()
    {
        clsBLICDDiseases obj_Chapters = new clsBLICDDiseases();
        DataView dv = obj_Chapters.GetAll(1);
        SComponents objComp = new SComponents();
        if (dv.Count > 0)
        {
            objComp.FillDropDownList(ddlICDChapter, dv, "CHAPBLOCKTITLE", "CHAPBLOCKID");

        }
        else
        {
            this.lblErrMsg.Text = "No BLOCK found";
        }
        dv.Dispose();
        obj_Chapters = null;
            
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();

    }
    private void ClearAll()
    {
        lblErrMsg.Text = "";
        lblCount.Text = "";
        ddlICDBlock.ClearSelection();
        ddlICDChapter.ClearSelection();
        ddlICDBlock.Enabled = false;
        txtSearch.Text = "";
        FillGV();
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");

    }
    protected void ddlICDBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
    }
    protected void ddlICDChapter_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlICDBlock.Enabled = true;
        FillBlocksDDl();
        FillGV();
    }

    private void FillBlocksDDl()
    {
        clsBLICDDiseases obj_Blocks = new clsBLICDDiseases();
        obj_Blocks.ChapterID = ddlICDChapter.SelectedValue.ToString();
        DataView dv=obj_Blocks.GetAll(2);
        SComponents objComp = new SComponents();
        if (dv.Count > 0)
        {
            this.lblErrMsg.Text = "";
            objComp.FillDropDownList(ddlICDBlock, dv, "CHAPBLOCKTITLE", "CHAPBLOCKID");

        }

        else
        {
            ddlICDBlock.ClearSelection();
            ddlICDBlock.Enabled = false;
            this.lblCount.Text = "";
            this.lblErrMsg.Text = "No Block Found";
        }
    }

    private void FillGV()
    {

        clsBLICDDiseases obj_Gv = new clsBLICDDiseases();
        if (ddlICDChapter.SelectedValue.ToString() != "-1" && ddlICDChapter.SelectedValue.ToString()!="")
        {
            obj_Gv.ChapterID = ddlICDChapter.SelectedValue.ToString();
        }

        //obj_Gv.SearchQuery = txtSearch.Text;
        if (ddlICDBlock.SelectedValue.ToString() != "-1" && ddlICDBlock.SelectedValue.ToString()!="")
        {
            obj_Gv.BlockID = ddlICDBlock.SelectedValue.ToString();
        }
        DataView dv = obj_Gv.GetAll(3);
        dv.Sort = DGSort;
        gvDiseases.DataSource = dv;
        gvDiseases.DataBind();
        dv.Dispose();
        obj_Gv = null;
        // break;
        //     case 1:
        //         clsBLICDDiseases obj_Gv1 = new clsBLICDDiseases();
        //         obj_Gv1.SearchQuery = txtSearch.Text;
        //         DataView dv1=obj_Gv1.GetAll(4);
        //         dv1.Sort = DGSort;
        //         gvDiseases.DataSource = dv1;
        //         gvDiseases.DataBind();
        //         dv1.Dispose();
        //         obj_Gv1=null;
        //         break;
        //}

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGV();
    }

    protected void gvDiseases_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "DISEASENAME")
        {
            if (DGSort == "DISEASENAME ASC")
            {
                DGSort = "DISEASENAME DESC";
            }
            else
                DGSort = "DISEASENAME ASC";
        }
        if (e.SortExpression == "DISEASECODE")
        {
            if (DGSort == "DISEASECODE ASC")
            {
                DGSort = "DISEASECODE DESC";
            }
            else
            {
                DGSort = "DISEASECODE ASC";
            }
        }
       
            FillGV();
      
           
    }

    protected void gvDiseases_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            string testid = Request.QueryString["testid"].ToString();
            string Labid = Request.QueryString["labid"].ToString();
            string PRNumber = Request.QueryString["PRNumber"].ToString();
            if (testid != "" && Labid != "" && PRNumber != "")
            {
                clsBLDiagnose obj_Diagnose = new clsBLDiagnose();
                obj_Diagnose.LabID = Labid;
                obj_Diagnose.TestID = testid;
                obj_Diagnose.PRNumber = PRNumber;
                int rowindex = int.Parse(e.CommandArgument.ToString());
                obj_Diagnose.DiseaseID = gvDiseases.DataKeys[rowindex].Value.ToString();
                obj_Diagnose.DiseaseName = gvDiseases.Rows[rowindex].Cells[2].Text;
                obj_Diagnose.ICDCode = gvDiseases.Rows[rowindex].Cells[1].Text;
                obj_Diagnose.Print = ((CheckBox)(gvDiseases.Rows[rowindex].FindControl("dgchkPrint"))).Checked == true ? "Y" : "N";
                obj_Diagnose.EnteredBy = Session["loginid"].ToString();
                obj_Diagnose.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_Diagnose.ClientID = "0005";

                if (obj_Diagnose.Insert())
                {
                    lblErrMsg.ForeColor = Color.Green;
                    lblErrMsg.Text = "Disease Added to LabID=" + Labid + " TestID=" + testid;
                    gvDiseases.Rows[rowindex].BackColor = Color.Green;
                }
                else
                {
                    lblErrMsg.ForeColor = Color.Red;
                    lblErrMsg.Text = obj_Diagnose.Errormessage;
                }
                
            }
        }
    }
        
 
    
}