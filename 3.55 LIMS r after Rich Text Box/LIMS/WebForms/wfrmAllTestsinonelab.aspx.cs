using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

public partial class LIMS_WebForms_wfrmAllTestsinonelab : System.Web.UI.Page
{
    private static string sSex = "";
    private static string PAgeIndays = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            // Response.AddHeader("Refresh", "10");
            if (!IsPostBack)
            {

                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "105";
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
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }

    }

    private void FillGV()
    {
        string mSerialNo = Request.QueryString["id"].ToString();

        clsBlalltestsinonelab obj_alltests = new clsBlalltestsinonelab();
        obj_alltests.MSerialNo = mSerialNo;
        DataView dv_allTests = obj_alltests.GetAll(1);
        if (dv_allTests.Count > 0)
        {
            sSex = dv_allTests[0]["PSex"].ToString();
            PAgeIndays = dv_allTests[0]["PAgeinDays"].ToString();
            gvTests.DataSource = dv_allTests;
            gvTests.DataBind();
        }
    }

    protected void gvTests_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        string testtid = e.Row.Cells[0].Text;
        string labid = Request.QueryString["labid"].ToString();
        Control container = e.Row;
        DataControlRowType rowType = e.Row.RowType;
        if (rowType == DataControlRowType.DataRow)
        {
            GridView gvAttributes = (GridView)container.FindControl("gvAttributes");
            string DSerialNo = "";
            DSerialNo = gvTests.DataKeys[e.Row.RowIndex].Value.ToString();
            DataView dv_Attributes=DisplayAttributes(DSerialNo);
            gvAttributes.DataSource = dv_Attributes;
            gvAttributes.DataBind();

/////////////////////////////Comments
            GridView gvCOmments = (GridView)container.FindControl("gvComments");
            clsBlalltestsinonelab obj_alltests = new clsBlalltestsinonelab();
            obj_alltests.LabID = labid;
            obj_alltests.TestID = testtid;
            DataView dv_comments = obj_alltests.GetAll(3);
            gvCOmments.DataSource = dv_comments;
            gvCOmments.DataBind();
            dv_comments.Dispose();
/////////////////////////////---Comments
////////////////////////////Diagnosis
            GridView gvDiagnosis = (GridView)container.FindControl("gvDiagnosis");
            DataView dv_disease = obj_alltests.GetAll(4);
            gvDiagnosis.DataSource = dv_disease;
            gvDiagnosis.DataBind();
///////////////////////////---Diagnosis


        }
    }

    private DataView DisplayAttributes(string serialNo)
    {
        clsBlalltestsinonelab obj_alltests = new clsBlalltestsinonelab();
        obj_alltests.DSerialNo = serialNo;
        DataView dv_tests = obj_alltests.GetAll(2);
        if (dv_tests.Count > 0)
        {
            return dv_tests;
        }
        else
        {
            obj_alltests.DSerialNo = serialNo;
            obj_alltests.Age = PAgeIndays;
            if (sSex == "M")
            {
                obj_alltests.Sex = "Male";
            }
            else if (sSex == "F")
            {
                obj_alltests.Sex = "Female";
            }
            else
            {
                obj_alltests.Sex = sSex;
            }
            DataView dvTGeneralTestResult2 = obj_alltests.GetAll(5);
            return dvTGeneralTestResult2;
        }
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }
}