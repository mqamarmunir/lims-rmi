using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;

public partial class LIMS_WebForms_wfrmManagementConsole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
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
            FillddlSubDepartment();
            FillddlWard();
            FillGv();
            FillGV_Notifications();
           // txtFromdate.Text = System.DateTime.Now.AddDays(-30).ToString("dd/MM/yyyy");
           // txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            FIllGv_Perfomance();
        }


    }
    private void FillddlSubDepartment()
    {
        clsBLSection objSection = new clsBLSection();
        SComponents objComp = new SComponents();

        objSection.Active = "Y";
        DataView dvSection = objSection.GetAll(1);
        objComp.FillDropDownList(this.ddlSubDep, dvSection, "SectionName", "SectionID");
        objComp = null;
        dvSection.Dispose();
    }

    private void FillddlWard()
    {
        clsBLWard objWard = new clsBLWard();
        objWard.Active = "Y";
        DataView dvWard = objWard.GetAll(1);
        SComponents objComp = new SComponents();
        objComp.FillDropDownList(this.ddlWard, dvWard, "WardName", "WardID");
    
        objComp = null;
        dvWard.Dispose();
    }
    private void FillGv()
    {
        clsBlManagementConsole obj_console = new clsBlManagementConsole();
        if (ddlSubDep.SelectedValue.ToString().Trim() != "-1" && ddlSubDep.SelectedValue.ToString().Trim()!="")
        {
            obj_console.SectionID = ddlSubDep.SelectedValue.ToString().Trim();
        }
        if (txtpatient.Text.Trim() != "" && txtpatient.Text.Trim() != "&nbsp;")
        {
            obj_console.PatientName = txtpatient.Text.Trim();
        }
        if (txtPRNo.Text.Trim() != "__-__-______" && txtPRNo.Text.Trim() != "")
        {
            obj_console.PRNo = txtPRNo.Text;
        }
        if (txtLabFrom.Text != "__-___-_______" && txtLabFrom.Text.Trim() != "")
        {
            obj_console.LabIDFrom = txtLabFrom.Text.Trim();
        }
        if (ddlWard.SelectedValue.ToString().Trim() != "-1" && ddlWard.SelectedValue.ToString().Trim() != "")
        {
            obj_console.WardID = ddlWard.SelectedValue.ToString().Trim();
        }
        //obj_console.SectionID = "013";
        DataView dv_Tests = obj_console.GetAll(1);
        if (dv_Tests.Count > 0)
        {
            gvTests.DataSource = dv_Tests;
            gvTests.AllowPaging = true;
            gvTests.DataBind();
        }
        else
        {
            gvTests.DataSource = "";
            gvTests.AllowPaging = false;
            gvTests.DataBind();
        }
    }
    private void FillGV_Notifications()
    {
        clsBlManagementConsole obj_Console = new clsBlManagementConsole();
        obj_Console.EnteredBy = Session["loginid"].ToString().Trim();
        DataView dv_notifications = obj_Console.GetAll(2);
        if (dv_notifications.Count > 0)
        {
            //Label lblNotify = (Label)tabnotification.FindControl("lblnotify");
            lblnotify.Text = "You have <font color='green'>" + dv_notifications.Count + "</font> new notifications";
            //tabnotification.HeaderText = "You have <font color='green'>" + dv_notifications.Count + "</font> new notifications";

            gvNotifications.DataSource = dv_notifications;
            gvNotifications.DataBind();
        }
        else
        {
            gvNotifications.DataSource = "";
            gvNotifications.DataBind();
        }
    }

   

    protected void gvTests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTests.PageIndex = e.NewPageIndex;
        FillGv();
    }
    protected void ddlSubDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGv();

    }
    protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGv();
    }
    protected void ibtnrefreshtest_Click(object sender, ImageClickEventArgs e)
    {
        FillGv();
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }
    protected void imgSave_Click(object sender, ImageClickEventArgs e)
    {
        clsBlManagementConsole obj_Console = new clsBlManagementConsole();
        obj_Console.Comment_Desc = txtComment.Text;
        obj_Console.EnteredBy = Session["loginid"].ToString().Trim();
        obj_Console.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_Console.ClientID = "0005";
        obj_Console.System_Ip = Request.UserHostAddress.ToString();
        obj_Console.New = "Y";

        if (obj_Console.Insert())
        {
            this.txtComment.Text = "";
            lblErrMsg.Text = "<font color='green'>Comment inserted Successfully</font>";
        }
        else
        {
            this.lblErrMsg.Text = obj_Console.ErrorMessage;
        }
    }

    protected void gvnotifications_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Control container = e.Row;
        //int index=e.Row.RowIndex;

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    clsBlManagementConsole obj_Console = new clsBlManagementConsole();
        //    obj_Console.CommentID = gvNotifications.DataKeys[index].Value.ToString().Trim();
        //    if (obj_Console.updateNewNotifications())
        //    {
                
        //    }
        //    //lblErrMsg.Text = gvNotifications.DataKeys[index].Value.ToString().Trim();

        //}

    }

    

    protected void gvTests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0004")
            {
                e.Row.BackColor = System.Drawing.Color.FromName("ff99ff");
            }
            //if (e.Row.Cells[5].Text == "OverDue")
            //{
            //    e.Row.BackColor = System.Drawing.Color.IndianRed;
            //}

            //if(gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString()=="0003")
        }
    }

    #region "Employees Perfomance Tab methods"
    ///////////////////////////Tab Panel Staff Perfomance methods/////////////////////////////////////
    protected void ibtnrefreshstaff_Click(object sender, ImageClickEventArgs e)
    {
        FIllGv_Perfomance();
    }
    protected void gvPerfomance_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        //int index = e.Row.DataItemIndex;
        //Control Container = e.Row;
        //DataControlRowType RowType = e.Row.RowType;

        //if (RowType == DataControlRowType.DataRow)
        //{
        //    string PersonID = gvPerfomance.DataKeys[index].Value.ToString();
        //    clsBlAllEmplooyesEval obj_allEmp = new clsBlAllEmplooyesEval();
        //    obj_allEmp.EnteredBy = PersonID;
        //    DataView dv_allemp = obj_allEmp.GetAll(6);
        //    if (dv_allemp.Count > 0)
        //    {
        //        GridView gvQualitative = (GridView)Container.FindControl("gvQualitative");
        //        //GridView gvQualitative = (GridView)gvPerfomance.Rows[index].Cells[8].FindControl("gvQualitative");
        //        gvQualitative.DataSource = dv_allemp;
        //        gvQualitative.DataBind();
        //    }
        //}

    }
    private void FIllGv_Perfomance()
    {
        //clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        //obj_Empeval.FromDate = txtFromdate.Text;
        //obj_Empeval.EndDate = txtTodate.Text;
        //DataView dv_persons = obj_Empeval.GetAll(5);
        //if (dv_persons.Count > 0)
        //{
        //    gvPerfomance.DataSource = dv_persons;
        //    gvPerfomance.DataBind();
        //}
        //else
        //{

        //}
    }
    ///////////////////////////////////////----------////////////////////////////////////////////////
    #endregion

}