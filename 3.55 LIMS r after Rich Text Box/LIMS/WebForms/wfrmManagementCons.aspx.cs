using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Globalization;

public partial class LIMS_WebForms_wfrmManagementCons : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "122";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                txttestdatefrom.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txttestdateto.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                FillddlSubDepartment();
                FillddlWard();
                FillGv();
                
                txtFromdate.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                txtTodate.Text = System.DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                //FIllGv_Perfomance();
                FillDDlProcess();
                FillDDLPersonnel();
                FillGV_Notifications();
                Fillddlpersonnel_notofications();
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
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
    string processIDs = "";
    private void FillGv()
    {
        clsBlManagementConsole obj_console = new clsBlManagementConsole();
      
     
        if (chkSpecomenInqueue.Checked == true)
        {
            processIDs += "'0009',";
        }
        if (chkresultentry.Checked == true)
        {
            processIDs += "'0004',";
        }
        if (chkresultverification.Checked == true)
        {
            processIDs += "'0005',";
        }
        if (chkSpecimenOutQUeue.Checked == true)
        {
            processIDs += "'0010',";
        }
        if (processIDs != "")
        {
            processIDs = processIDs.Substring(0, processIDs.Length - 1);
            obj_console.ProcessID = processIDs;
           // obj_console.p
        }
        if (ddlSubDep.SelectedValue.ToString().Trim() != "-1" && ddlSubDep.SelectedValue.ToString().Trim() != "")
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
        if (txtLabTo.Text != "__-___-_______" && txtLabTo.Text.Trim() != "")
        {
            obj_console.LabIDTo = txtLabTo.Text.Trim();
        }
        if (!txttestdatefrom.Text.Replace("__/__/____","").Equals("") && !txttestdateto.Text.Replace("__/__/____","").Equals(""))
        {
            obj_console.DateFrom = txttestdatefrom.Text.Trim();
            obj_console.DateTo = txttestdateto.Text.Trim();
        }
        if (ddlWard.SelectedValue.ToString().Trim() != "-1" && ddlWard.SelectedValue.ToString().Trim() != "")
        {
            obj_console.WardID = ddlWard.SelectedValue.ToString().Trim();
        }
        //obj_console.SectionID = "013";
        DataView dv_Tests = obj_console.GetAll(1);
        if (dv_Tests.Count > 0)
        {
            dv_Tests.Sort = DGSort;
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
        obj_Console.PersonID = Session["loginid"].ToString().Trim();
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
            lblnotify.Text = "Notifications";
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
        
        int i = 0;
        foreach (ListItem item in (ddlPersons_notification as ListControl).Items)
        {
            if (item.Selected)
            {
                //str[i] = item.Value.ToString().Trim();
                i++;
            }
                
        }
        string[] str = new string[i];
        int j = 0;
        foreach (ListItem item in (ddlPersons_notification as ListControl).Items)
        {
            if (item.Selected)
            {
                str[j] = item.Value.ToString().Trim();
                j++;
            }

        }
        obj_Console.StrpersonIds = str;
            if (obj_Console.Insert())
            {
                foreach (ListItem item in (ddlPersons_notification as ListControl).Items)
                {
                    item.Selected = false;
                    
                }
                this.txtComment.Text = "";
                lblErrMsg.Text = "<font color='green'>Comment inserted Successfully</font>";
            }
            else
            {
                this.lblErrMsg.Text = obj_Console.ErrorMessage;
            }
    }

    



    protected void gvTests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string labid = e.Row.Cells[1].Text.Trim();
            string testid = gvTests.DataKeys[e.Row.RowIndex].Values["testid"].ToString().Trim();
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0002")
            {
                e.Row.BackColor = System.Drawing.Color.Aquamarine;
            }
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0004")
            {
                e.Row.BackColor = System.Drawing.Color.AntiqueWhite;
            }
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0005")
            {
                e.Row.BackColor = System.Drawing.Color.Aqua;
            }
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0006" || gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0007")
            {
                e.Row.BackColor = System.Drawing.Color.White;
            }
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0010")
            {
                e.Row.BackColor = System.Drawing.Color.SeaShell;
            }
            if (gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString() == "0009")
            {
                e.Row.BackColor = System.Drawing.Color.RoyalBlue;
            }
            if (e.Row.Cells[7].Text.Contains("OverDue"))
            {
                e.Row.Cells[7].BackColor = System.Drawing.Color.FromName("IndianRed");
               
            }

            clsBlRepeatTest obj_chkRepeat = new clsBlRepeatTest();
            obj_chkRepeat.LabID = labid;
            obj_chkRepeat.TestID = testid;
            DataView dv_chkRepeat = obj_chkRepeat.GetAll(1);
            if (dv_chkRepeat.Count > 0)
            {
                e.Row.BackColor = System.Drawing.Color.Bisque;

            }


            //if(gvTests.DataKeys[e.Row.RowIndex].Values[0].ToString()=="0003")
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lbllastupdated.Text = "Last Updated at " + System.DateTime.Now.ToLongTimeString();
        FillGv();
    }

    #region "Employees Perfomance Tab methods"
    ///////////////////////////Tab Panel Staff Perfomance methods/////////////////////////////////////
    private void FillDDLPersonnel()
    {
        clsBlManagementConsole objManage = new clsBlManagementConsole();
        DataView dv_persons = objManage.GetAll(3);
        SComponents objcom = new SComponents();
        objcom.FillDropDownList(ddlPersons, dv_persons, "Name", "PersonID");
        //objcom.FillDropDownList(ddlPersons_notification, dv_persons, "Name", "PersonId");
        dv_persons.Dispose();
        objManage = null;
        objcom = null;

    }
    protected void ibtnrefreshstaff_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlPersons.SelectedValue.ToString().Trim() != "-1")
        {
            lblindipersum.Visible = true;
            gvIndividualPer.Visible = true;

            FillgvIndividualPer();
        }
        else
        {
            gvIndividualPer.Visible = false;
            lblindipersum.Visible = false;

        }
        if (ddlProcess.SelectedValue.ToString().Trim() == "0002")
        {
            FIllGv_PerfomanceSpecimen();
        }
        if (ddlProcess.SelectedValue.ToString().Trim() == "0004")
        {
            FIllGv_PerfomanceEntry();
        }
        if (ddlProcess.SelectedValue.ToString().Trim() == "0005")
        {
            FIllGv_PerfomanceVerification();
        }
        
        
       // FIllGv_Perfomance();
    }
    private void FillgvIndividualPer()
    {
        clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        obj_Empeval.FromDate = txtFromdate.Text;
        obj_Empeval.EndDate = txtTodate.Text;
        obj_Empeval.EnteredBy = ddlPersons.SelectedValue.ToString().Trim();
        
       
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {

            obj_Empeval.Starttime = "08:00:00";
            obj_Empeval.EndTime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            obj_Empeval.Starttime = "15:00:00";
            obj_Empeval.EndTime = "22:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            obj_Empeval.Starttime = "22:00:00";
            obj_Empeval.EndTime = "08:00:00";
        }
       

        DataView dv_persons = obj_Empeval.GetAll(12);
        if (dv_persons.Count > 0)
        {
            gvIndividualPer.DataSource = dv_persons;
            gvIndividualPer.DataBind();
        }
        else
        {
            lblindipersum.Visible = false;
            gvIndividualPer.DataSource = "";
            gvIndividualPer.DataBind();
        } 
    }
    protected void gvPerfomance_RowDatabound(object sender, GridViewRowEventArgs e)
    {
        int index = e.Row.DataItemIndex;
        Control Container = e.Row;
        DataControlRowType RowType = e.Row.RowType;

        if (RowType == DataControlRowType.DataRow)
        {
            string PersonID = gvPerfomance.DataKeys[index].Value.ToString();
            clsBlAllEmplooyesEval obj_allEmp = new clsBlAllEmplooyesEval();
            obj_allEmp.EnteredBy = PersonID;
            obj_allEmp.FromDate = txtFromdate.Text;
            obj_allEmp.EndDate = txtTodate.Text;
            if (ddlShift.SelectedValue.ToString().Trim() == "0")
            {

                obj_allEmp.Starttime = "08:00:00";
                obj_allEmp.EndTime = "15:00:00";
            }
            else if (ddlShift.SelectedValue.ToString().Trim() == "1")
            {
                obj_allEmp.Starttime = "15:00:00";
                obj_allEmp.EndTime = "22:00:00";
            }
            else if (ddlShift.SelectedValue.ToString().Trim() == "2")
            {
                obj_allEmp.Starttime = "22:00:00";
                obj_allEmp.EndTime = "08:00:00";
            }
            DataView dv_allemp = new DataView();
            if (ddlProcess.SelectedValue.ToString() == "0004")
            {
                dv_allemp = obj_allEmp.GetAll(6);
            }
            else if (ddlProcess.SelectedValue.ToString() == "0002")
            {
                dv_allemp = obj_allEmp.GetAll(8);
            }
            else if (ddlProcess.SelectedValue.ToString() == "0005")
            {
                dv_allemp = obj_allEmp.GetAll(10);
            }

            if (dv_allemp.Count > 0)
            {
                GridView gvQualitative = (GridView)Container.FindControl("gvQualitative");
                //GridView gvQualitative = (GridView)gvPerfomance.Rows[index].Cells[8].FindControl("gvQualitative");
                gvQualitative.DataSource = dv_allemp;
                gvQualitative.DataBind();
            }
        }

    }
    private void FIllGv_PerfomanceEntry()
    {
        clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
       obj_Empeval.FromDate = txtFromdate.Text;
            obj_Empeval.EndDate = txtTodate.Text;
        if (ddlPersons.SelectedValue.ToString().Trim() != "-1")
        {
            obj_Empeval.EnteredBy = ddlPersons.SelectedValue.ToString().Trim();
        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {

            obj_Empeval.Starttime = "08:00:00";
            obj_Empeval.EndTime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            obj_Empeval.Starttime = "15:00:00";
            obj_Empeval.EndTime = "22:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            obj_Empeval.Starttime = "22:00:00";
            obj_Empeval.EndTime = "08:00:00";
        }

        DataView dv_persons = obj_Empeval.GetAll(5);
        if (dv_persons.Count > 0)
        {
            gvPerfomance.DataSource = dv_persons;
            gvPerfomance.DataBind();
        }
        else
        {
            gvPerfomance.DataSource = "";
            gvPerfomance.DataBind();
        }
    }

    private void FIllGv_PerfomanceSpecimen()
    {
        clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        obj_Empeval.FromDate = txtFromdate.Text;
        obj_Empeval.EndDate = txtTodate.Text;
        if (ddlPersons.SelectedValue.ToString().Trim() != "-1")
        {
            obj_Empeval.EnteredBy = ddlPersons.SelectedValue.ToString().Trim();
        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {

            obj_Empeval.Starttime = "08:00:00";
            obj_Empeval.EndTime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            obj_Empeval.Starttime = "15:00:00";
            obj_Empeval.EndTime = "22:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            obj_Empeval.Starttime = "22:00:00";
            obj_Empeval.EndTime = "08:00:00";
        }

        DataView dv_persons = obj_Empeval.GetAll(7);
        if (dv_persons.Count > 0)
        {
            gvPerfomance.DataSource = dv_persons;
            gvPerfomance.DataBind();
        }
        else
        {
            gvPerfomance.DataSource = "";
            gvPerfomance.DataBind();
        }
    }

    private void FIllGv_PerfomanceVerification()
    {
        clsBlAllEmplooyesEval obj_Empeval = new clsBlAllEmplooyesEval();
        obj_Empeval.FromDate = txtFromdate.Text;
        obj_Empeval.EndDate = txtTodate.Text;
        if (ddlPersons.SelectedValue.ToString().Trim() != "-1")
        {
            obj_Empeval.EnteredBy = ddlPersons.SelectedValue.ToString().Trim();
        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {

            obj_Empeval.Starttime = "08:00:00";
            obj_Empeval.EndTime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            obj_Empeval.Starttime = "15:00:00";
            obj_Empeval.EndTime = "22:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            obj_Empeval.Starttime = "22:00:00";
            obj_Empeval.EndTime = "08:00:00";
        }

        DataView dv_persons = obj_Empeval.GetAll(9);
        if (dv_persons.Count > 0)
        {
            gvPerfomance.DataSource = dv_persons;
            gvPerfomance.DataBind();
        }
        else
        {
            gvPerfomance.DataSource = "";
            gvPerfomance.DataBind();
        }
    }

    private void FillDDlProcess()
    {
        clsBlAllEmplooyesEval obj_Emp = new clsBlAllEmplooyesEval();
        DataView dv_Processes = obj_Emp.GetAll(11);
        if (dv_Processes.Count > 0)
        {
            SComponents obj_Com = new SComponents();
            obj_Com.FillDropDownList(ddlProcess, dv_Processes, "Process", "ProcessID");
            obj_Com = null;
        }
        dv_Processes.Dispose();
    }

    ///////////////////////////////////////----------////////////////////////////////////////////////
    #endregion


    #region "Notifications Tab methods"
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
    protected void gvimgdone_Click(object sender, CommandEventArgs e)
    {
        int rownumber=Convert.ToInt16(e.CommandArgument);
        clsBlManagementConsole obj_Console = new clsBlManagementConsole();
        obj_Console.NotificationID = gvNotifications.DataKeys[rownumber].Value.ToString().Trim();
        if (obj_Console.updateNewNotifications())
        {
            FillGV_Notifications();
        }
    }
    #endregion
    protected void btnsearchlab_Click(object sender, EventArgs e)
    {
        txtLabTo.Text = txtLabFrom.Text.Trim();
        clsBlManagementConsole objconsole = new clsBlManagementConsole();
        objconsole.LabIDFrom = txtLabFrom.Text.Trim();
        objconsole.LabIDTo = txtLabTo.Text.Trim();
        DataView dv = objconsole.GetAll(1);
        if (dv.Count > 0)
        {
            gvTests.DataSource = dv;
            gvTests.DataBind();
        }
        else
        {
            gvTests.AllowPaging = false;
            lbllastupdated.Text = "No Test Found!!!";
            gvTests.DataSource = "";
            gvTests.DataBind();
        }
    }
    protected void leftside_ActiveTabChanged(object sender, EventArgs e)
    {
        if (leftside.ActiveTab.HeaderText=="Employees Perfomance")
        {
            if (ApplyUserMatrix())
            {

            }
            else
            {
                lblErrMsg.Text = "You are not allowed to view this Information. If you think you should be allowed then please contact Administrator.";
                leftside.ActiveTabIndex = 0;
            }
            //lblErrMsg.Text = "Hi i Am called";
        }
    }
    private bool ApplyUserMatrix()
    {
        clsBLUMatrix UMatrix = new clsBLUMatrix();
        UMatrix.ApplicationID = "001";
        UMatrix.FormID = "131";
        UMatrix.PersonID = Session["loginid"].ToString();
        DataView dvUMatrix = UMatrix.GetAll(1);
        string sRigth = dvUMatrix[0]["Rec"].ToString();
        if (sRigth.Equals("0"))
        {
            return false;
            //Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }
        return true;
    }
    private void Fillddlpersonnel_notofications()
    {

        clsBlManagementConsole objManage = new clsBlManagementConsole();
        objManage.PersonID = Session["loginid"].ToString().Trim();
        DataView dv_persons = objManage.GetAll(3);
        //DataView dv_Br = obj_Br.GetAll(3);
        if (dv_persons.Count > 0)
        {
            ddlPersons_notification.DataTextField = "Name";
            ddlPersons_notification.DataValueField = "PersonID";
            ddlPersons_notification.DataSource = dv_persons;
            ddlPersons_notification.DataBind();

        }
    }
    protected void SendNotif_Click(object sender, EventArgs e)
    {

    }
    protected void imgCancelNoti_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibtnsavetest_Click(object sender, ImageClickEventArgs e)
    {
        string subdept = ddlSubDep.SelectedValue.Trim().ToString();
        string patient = txtpatient.Text.Trim().ToString();
        string wardid = ddlWard.SelectedValue.Trim().ToString();
        string prno = txtPRNo.Text.Trim().ToString();
        string labidfrom = txtLabFrom.Text.Trim().ToString();
        string labidto = txtLabTo.Text.Trim().ToString();
        string testdatefrom = txttestdatefrom.Text.Trim().ToString();
        string testdateto = txttestdateto.Text.Trim().ToString();
        if (chkSpecomenInqueue.Checked == true)
        {
            processIDs += "'0009',";
        }
        if (chkresultentry.Checked == true)
        {
            processIDs += "'0004',";
        }
        if (chkresultverification.Checked == true)
        {
            processIDs += "'0005',";
        }
        if (chkSpecimenOutQUeue.Checked == true)
        {
            processIDs += "'0010',";
        }
      processIDs= processIDs.TrimEnd(',');
        string _SelectionFormula = "";
        string selectprno = "";
        string selectpatient = "";
        string selectsectionid = "";
        string selectlab = "";
        string selectdate = "";
        string selectward = "";

        if (ddlSubDep.SelectedValue.ToString().Trim() != "-1" && ddlSubDep.SelectedValue.ToString().Trim() != "")
        {
            selectsectionid = "{Command.SECTIONID}='" + subdept + "' and";

        }

        if (txtpatient.Text.Trim() != "" && txtpatient.Text.Trim() != "&nbsp;")
        {
            selectpatient = "{Command.PATIENTNAME}='" + patient + "' and";
        }

        if (txtPRNo.Text.Trim() != "__-__-______" && txtPRNo.Text.Trim() != "")
        {
            selectprno = "{Command.PRNO}='" + prno + "' and";

        }
        if (txtLabFrom.Text != "__-___-_______" && txtLabFrom.Text.Trim() != "")
        {
            selectlab = "{Command.LABID}>= '" + labidfrom + "'";

            if (txtLabTo.Text != "__-___-_______" && txtLabTo.Text.Trim() != "")
            {
                selectlab += " and {Command.LABID}<= '" + labidto + "' and";
            }

        }
        if (!txttestdatefrom.Text.Replace("__/__/____", "").Equals("") && !txttestdateto.Text.Replace("__/__/____", "").Equals(""))
        {
            selectdate = "dATE({Command.ENTRYDATETIME}) in Date('" + DateTime.ParseExact(testdatefrom, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + @"') to Date('" + DateTime.ParseExact(testdateto, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + "')  and ";


        }
        if (ddlWard.SelectedValue.ToString().Trim() != "-1" && ddlWard.SelectedValue.ToString().Trim() != "")
        {
            selectward = "  {Command.WARDID}= '" + wardid + "' and";
        }
        string processid="";
        if (processIDs != null && processIDs != "")
        {
           processid=" {Command.PROCESSID} in ["+processIDs+"]";
        }
        _SelectionFormula = selectdate + selectsectionid + selectprno + selectpatient + selectward + selectlab + processid;
        if (processid == "")
        {
            _SelectionFormula = _SelectionFormula.Substring(0, _SelectionFormula.Length - 3);
        }
        //_SelectionFormula=_SelectionFormula.TrimEnd("and");
        //     string _SelectionFormula = "{Command.LABID}>= '" + labidfrom + "'";
        //       _SelectionFormula+=" and {Command.LABID}<= '" + labidto+ "'";
        //     _SelectionFormula += " and {Command.WARDID}= '" + wardid + "'";
        //   _SelectionFormula+= " and {Command.ENTEREDATE}>= '" + testdatefrom + "'";
        // _SelectionFormula += " and {Command.ENTEREDATE}<= '" + testdateto + "'";




        printReport(_SelectionFormula, null, "TestProcessReport");


    }
    protected void ibtnsavestaff_Click(object sender, ImageClickEventArgs e)
    {
        if (ddlProcess.SelectedValue.ToString() == "0004")
        {
            EmpTestEnterReport();
        }
        if (ddlProcess.SelectedValue.ToString() == "0002")
        {
            EmpSpecimenCollectedReport();
        }
        if (ddlProcess.SelectedValue.ToString() == "0005")
        {
            EmpTestVerifyReport();
        }
    }
    private void printReport(string _SelectionFormula, string[] parameter, string ReportName)
    {

        CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        try
        {
            // Put user code to initialize the page here
            string strRUrl = Server.MapPath( @"~/LIMS/reports/" + ReportName + ".rpt");
            // string strRUrl = Server.MapPath(@"~/LIMS/reports/TestResult.rpt");
            Session["ReportUrl"] = strRUrl;


            int i;
            int j;
            doc.Load(strRUrl);
            j = doc.Database.Tables.Count - 1;
            string userName = "whims";
            string pwd = "whims";
            string serverName = "HIMS";

            //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
            //string[] info = strConn.Split(';');
            //userName = ((info[1].Split('='))[1]).Trim();
            //pwd = ((info[3].Split('='))[1]).Trim();
            //serverName = ((info[2].Split('='))[1]).Trim();

            for (i = 0; i <= j; i++)
            {
                TableLogOnInfo logOnInfo = new TableLogOnInfo();
                logOnInfo = doc.Database.Tables[i].LogOnInfo;
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo = logOnInfo.ConnectionInfo;
                connectionInfo.ServerName = serverName;
                connectionInfo.Password = pwd;
                connectionInfo.UserID = userName;
                doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
            }
            if (ReportName == "EmpSpecimenCollected" || ReportName == "EmpTestEntered" || ReportName == "EmpTestVerified")
            {
                if (_SelectionFormula != "")
                {
                    //string[] formulas = _SelectionFormula.Split(';');
                    //string s1 = formulas[0].Trim();
                    //string s2 = formulas[1].Trim();
                    doc.RecordSelectionFormula = _SelectionFormula;
                    //doc.OpenSubreport("Test Details.rpt");
                    // doc.Subreports["Test Details"].RecordSelectionFormula = s2;
                    //doc.Subreports[0].RecordSelectionFormula = s2;
                    //doc.IsSubreport;
                    if (ReportName == "EmpSpecimenCollected")
                    {
                        doc.SetParameterValue("collectedon", parameter[0]);
                        doc.SetParameterValue("collectedonto", parameter[1]);
                        doc.SetParameterValue("starttime", parameter[2]);
                        doc.SetParameterValue("endtime", parameter[3]);
                    }
                    else
                    {
                        doc.SetParameterValue("fromdate", parameter[0]);
                        doc.SetParameterValue("todate", parameter[1]);
                        doc.SetParameterValue("starttime", parameter[2]);
                        doc.SetParameterValue("endtime", parameter[3]);
                    }

                }
            }
            else
            {
                doc.RecordSelectionFormula = _SelectionFormula;

                _SelectionFormula = doc.RecordSelectionFormula;

            }
            CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
            string szFileName = Server.MapPath(@"~/LIMS/reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf");
            dfdoCustomers.DiskFileName = szFileName;
            doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
            doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
            doc.ExportOptions.DestinationOptions = dfdoCustomers;
            doc.Export();
            //Response.Redirect(strRUrl + "_" + Session["loginid"].ToString() + ".pdf");

            ScriptManager.RegisterStartupScript(this, typeof(Page), "EmpTestEntered", @"<script>window.open('../reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf');</script>", false);



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
        }
        finally
        {
            doc.Close();
            doc.Dispose();
            GC.Collect();
        }



    }

    private void EmpTestEnterReport()
    {
        string processid = ddlProcess.SelectedValue.Trim().ToString();
        string personid = ddlPersons.SelectedValue.Trim().ToString();
        string shifitid = ddlShift.SelectedValue.Trim().ToString();
        string fromdate = txtFromdate.Text.Trim().ToString();
        string todate = txtTodate.Text.Trim().ToString();

        // string subselectformula = "";
        string _SelectionFormula = "";
        //string selectprocessid = "";
        string selectpersonid = "";


        string selectfromdate = "";
        string startdate = "";
        string enddate = "";
        string starttime = "";
        string endtime = "";



        if (ddlPersons.SelectedValue.ToString().Trim() != "-1" && ddlPersons.SelectedValue.ToString().Trim() != "")
        {
            selectpersonid = "and {Command.ENTEREDBY}='" + personid + "'";
        }




        if (!txtFromdate.Text.Replace("__/__/____", "").Equals("") && !txtTodate.Text.Replace("__/__/____", "").Equals(""))
        {
            selectfromdate = "dATE({Command.ENTEREDON}) in Date('" + DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + @"') to Date('" + DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + "') ";
            startdate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");
            enddate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");


        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {
            selectfromdate += " and {Command.ENTEREDTIME} in '08:00:00' to '15:00:00'";
            starttime = "08:00:00";
            endtime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            selectfromdate += " and {Command.ENTEREDTIME} in '15:00:00' to '22:00:00'";
            starttime = "15:00:00";
            endtime = "22:00:00";

        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            selectfromdate += " and {Command.ENTEREDTIME} in '22:00:00' to '08:00:00'";
            starttime = "22:00:00";
            endtime = "08:00:00";

        }
        _SelectionFormula = selectfromdate + selectpersonid;
        //subselectformula = "; " + _SelectionFormula;
        //_SelectionFormula = subselectformula;
        string[] param = new string[] { startdate, enddate, starttime, endtime };
        printReport(_SelectionFormula, param, "EmpTestEntered");
    }
    private void EmpTestVerifyReport()
    {
        string processid = ddlProcess.SelectedValue.Trim().ToString();
        string personid = ddlPersons.SelectedValue.Trim().ToString();
        string shifitid = ddlShift.SelectedValue.Trim().ToString();
        string fromdate = txtFromdate.Text.Trim().ToString();
        string todate = txtTodate.Text.Trim().ToString();
        string starttime = "";
        string endtime = "";
        // string subselectformula = "";
        string _SelectionFormula = "";
        //string selectprocessid = "";
        string selectpersonid = "";


        string selectfromdate = "";
        string startdate = "";
        string enddate = "";



        if (ddlPersons.SelectedValue.ToString().Trim() != "-1" && ddlPersons.SelectedValue.ToString().Trim() != "")
        {
            selectpersonid = "and {Command.ENTEREDBY}='" + personid + "'";
        }




        if (!txtFromdate.Text.Replace("__/__/____", "").Equals("") && !txtTodate.Text.Replace("__/__/____", "").Equals(""))
        {
            selectfromdate = "dATE({Command.EVALUATEDON}) in Date('" + DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + @"') to Date('" + DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + "') ";
            startdate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");
            enddate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");


        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {
            selectfromdate += " and {Command.EVALUATIONTIME} in '08:00:00' to '15:00:00'";
            // startdate += " 08:00:00";
            //enddate += "  15:00:00";
            starttime = "08:00:00";
            endtime = "15:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            selectfromdate += " and {Command.EVALUATIONTIME} in '15:00:00' to '22:00:00'";
            starttime = "15:00:00";
            endtime = "22:00:00";

        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            selectfromdate += " and {Command.EVALUATIONTIME} in '22:00:00' to '08:00:00'";
            starttime = "22:00:00";
            endtime = "08:00:00";

        }
        _SelectionFormula = selectfromdate + selectpersonid;
        // subselectformula = "; " + _SelectionFormula;
        // _SelectionFormula = subselectformula;
        string[] param = new string[] { startdate, enddate, starttime, endtime };
        printReport(_SelectionFormula, param, "EmpTestVerified");
    }
    private void EmpSpecimenCollectedReport()
    {

        string personid = ddlPersons.SelectedValue.Trim().ToString();
        string shifitid = ddlShift.SelectedValue.Trim().ToString();
        string fromdate = txtFromdate.Text.Trim().ToString();
        string todate = txtTodate.Text.Trim().ToString();

        //string subselectformula = "";
        string startdate = "";
        string enddate = "";
        string _SelectionFormula = "";
        //string selectprocessid = "";
        string selectpersonid = "";
        string selectfromdate = "";

        string starttime = "";
        string endtime = "";


        if (ddlPersons.SelectedValue.ToString().Trim() != "-1" && ddlPersons.SelectedValue.ToString().Trim() != "")
        {
            selectpersonid = "and {Command.SpecimenCollectedBy}='" + personid + "'";
        }




        if (!txtFromdate.Text.Replace("__/__/____", "").Equals("") && !txtTodate.Text.Replace("__/__/____", "").Equals(""))
        {
            selectfromdate = "DATE({Command.SPECIMENCOLLECTEDON}) in Date('" + DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + @"') to Date('" + DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd") + "') ";

            startdate = DateTime.ParseExact(fromdate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");
            enddate = DateTime.ParseExact(todate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyy,MM,dd");
        }
        if (ddlShift.SelectedValue.ToString().Trim() == "0")
        {
            selectfromdate += "  and {Command.COLLECTEDTIME} in '08:00:00' to '15:00:00'";
            starttime = "08:00:00";
            endtime = "15:00:00";

        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "1")
        {
            selectfromdate += " and {Command.COLLECTEDTIME} in '15:00:00' to '22:00:00'";

            starttime = "15:00:00";
            endtime = "22:00:00";
        }
        else if (ddlShift.SelectedValue.ToString().Trim() == "2")
        {
            selectfromdate += " and {Command.COLLECTEDTIME} in '22:00:00' to '08:00:00'";
            starttime = "22:00:00";
            endtime = "08:00:00";

        }
        _SelectionFormula = selectfromdate + selectpersonid;
        //subselectformula = "; " + selectfromdate;
        //_SelectionFormula = _SelectionFormula +";"+ subselectformula;
        string[] param = new string[] { startdate, enddate, starttime, endtime };

        printReport(_SelectionFormula, param, "EmpSpecimenCollected");
    }
    string DGSort = "";
    protected void gvTests_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "labid")
        {
            if (DGSort == "labid ASC")
            {
                DGSort = "labid DESC";
            }
            else
                DGSort = "labid ASC";

        }
        else if (e.SortExpression == "PatientName")
        {
            if (DGSort == "PatientName ASC")
            {
                DGSort = "PatientName DESC";
            }
            else
                DGSort = "PatientName ASC";

        }
        else if (e.SortExpression == "test")
        {
            if (DGSort == "test ASC")
            {
                DGSort = "test DESC";
            }
            else
                DGSort = "test ASC";

        }
        else if (e.SortExpression == "Priority")
        {
            if (DGSort == "Priority ASC")
            {
                DGSort = "Priority DESC";
            }
            else
                DGSort = "Priority ASC";

        }
        else if (e.SortExpression == "EnteredAte")
        {
            if (DGSort == "EnteredAte ASC")
            {
                DGSort = "EnteredAte DESC";
            }
            else
                DGSort = "EnteredAte ASC";

        }
        else if (e.SortExpression == "DeliveryDate")
        {
            if (DGSort == "DeliveryDate ASC")
            {
                DGSort = "DeliveryDate DESC";
            }
            else
                DGSort = "DeliveryDate ASC";
        }

        else if (e.SortExpression == "TimeLeft")
        {
            if (DGSort == "TimeLeft ASC")
            {
                DGSort = "TimeLeft DESC";
            }
            else
                DGSort = "TimeLeft ASC";

        }
        else if (e.SortExpression == "WardName")
        {
            if (DGSort == "WardName ASC")
            {
                DGSort = "WardName DESC";
            }
            else
                DGSort = "WardName ASC";

        }


        FillGv();

    }
}