﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using HMIS.LIMS.WebForms;


public partial class LIMS_WebForms_wfrmTestRegistrationNew : System.Web.UI.Page
{
    protected static string sSection;


    private static string mode = "";
    private static string TestID = "";
    private static string DGSort = "Test ASC";
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "002";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                try
                {
                    sSection = Request.QueryString["SectionID"].ToString();
                }
                catch { sSection = "-1"; };
                DGSort = "DOrder";
                mode = "Insert";
                FillSectionDDL();
                FillProcedureDDL();
                FillSpecimenDDL();
                FillORGDDL();
                EnableForm(false);
            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.ibtnSave.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSave_Click);
        this.ibtnClear.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClear_Click);
        this.ibtnTestAttribute.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTestAttribute_Click);
        this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
        this.dgTestList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTestList_ItemCreated);
        this.dgTestList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTestList_ItemCommand);
        this.dgTestList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgTestList_PageIndexChanged);
        this.dgTestList.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTestList_EditCommand);
        this.dgTestList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgTestList_SortCommand);
       // this.ddlTestGroup.SelectedIndexChanged += new System.Web.UI.WebControls.DropDownList(this.ddlTestGroup_SelectedIndexChanged);

    }
    #endregion




    private void FillProcedureDDL()
    {
        clsBLTestProcedure objTestP = new clsBLTestProcedure();
        SComponents objComp = new SComponents();

        objTestP.Active = "Y";
        DataView dvTestP = objTestP.GetAll(2);

        objComp.FillDropDownListWithoutSelect(this.ddlProcedure, dvTestP, "Procedure", "ProcedureID",true,false);
    }

    private void FillSpecimenDDL()
    {
        clsBLSpecimen objSpecimen = new clsBLSpecimen();
        SComponents objComp = new SComponents();

        DataView dvSpecimen = objSpecimen.GetAll(1);

        objComp.FillDropDownList(this.ddlSpecimenType, dvSpecimen, "SpecimenType", "SpecimenType");

        DataView dvSpecimen2 = objSpecimen.GetAll(2);

        objComp.FillDropDownList(this.ddlSpecimenContainer, dvSpecimen2, "SpecimenContainer", "SpecimenContainer");
    }

    private void EnableForm(bool enable)
    {
        this.ibtnSave.Enabled = enable;
        this.chkActive.Enabled = enable;
        this.txtTest.Enabled = enable;
        this.txtAcronym.Enabled = enable;
        this.txtCharges.Enabled = enable;
        this.txtChargesUrgent.Enabled = enable;
        this.txtSpecimen.Enabled = enable;
        this.txtAutomatedText.Enabled = enable;
        this.txtClinicalUse.Enabled = enable;
        this.ddlGenLevel.Enabled = enable;
        this.ddlGenOn.Enabled = enable;
        this.ddlProcedure.Enabled = enable;
        this.chkPreferred.Enabled = enable;
        this.chkDelivery.Enabled = enable;
        this.txtAutomatedText2.Enabled = enable;
        this.txtAutomatedText3.Enabled = enable;
        this.txtAutomatedText4.Enabled = enable;
        txtAutomatedText5.Enabled = enable;
        txtAutomatedText_footer.Enabled = enable;
    }

    private void FillSectionDDL()
    {
        clsBLSection objSection = new clsBLSection();
        SComponents objComp = new SComponents();

        objSection.Active = "Y";
        DataView dvSection = objSection.GetAll(1);
        objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID");
        dvSection.Dispose();
        objComp = null;
    }
    private void FillORGDDL()
    {
        clsBLSection objSection = new clsBLSection();
        SComponents objComp = new SComponents();

        objSection.Active = "Y";
        DataView dvorg = objSection.GetAll(3);
        objComp.FillDropDownList(this.ddlorg, dvorg, "name", "orgid");
        dvorg.Dispose();
        objComp = null;
    }
    protected void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        this.lblErrMsg.Text = "";
        if (mode.Equals("Insert"))
        {
            Insert();
        }
        else
        {
            Update();
        }
    }

    protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.lblErrMsg.Text = "";

        if (!this.ddlSection.SelectedItem.Value.Equals("-1"))
        {
            FillTestDDL();
            FillDG();
            this.ddlTestGroup.Enabled = true;
        }
        else
        {
            this.ddlTestGroup.Enabled = false;
        }

        EnableForm(true);
        this.dgTestList.Visible = true;
    }

    private void FillTestDDL()
    {
        clsBLTestGroup objTestGroup = new clsBLTestGroup();
        SComponents objComp = new SComponents();

        objTestGroup.Active = "Y";
        objTestGroup.SectionID = ddlSection.SelectedValue;
        DataView dvTestGroup = objTestGroup.GetAll(3);
        objComp.FillDropDownList(this.ddlTestGroup, dvTestGroup, "TestGroup", "TestGroupID");
    }

    protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
    {
        this.lblErrMsg.Text = "";

        if (!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
        {
            EnableForm(true);
            FillDG();
        }
        else
        {
            EnableForm(false);
        }

        RefreshForm();
    }

    private void RefreshForm()
    {
        txtCostprice.Text = "";
        this.chkActive.Checked = true;
        this.txtTest.Text = "";
        this.txtAcronym.Text = "";
        this.txtCharges.Text = "";
        this.txtChargesUrgent.Text = "";
        this.txtSpecimen.Text = "";
        this.txtAutomatedText.Text = "";
        this.txtClinicalUse.Text = "";
        this.txtReorder.Text = "";
        this.chkSummary.Checked = false;
        TestID = "";
        this.chkProvisional.Checked = false;
        this.chkExternal.Checked = false;
        this.txtQuantity.Text = "";
        this.txtunit.Text = "";
        uncheckall();
        uncheckcutoffdays();
        txtbatchtime.Text = "";
        //txtbatchtime.Visible = false;
        //lblbatch.Visible = false;
        this.ddlPerform.ClearSelection();
        //PanelDays.Visible = false;
        //PanelWeek.Visible = false;
        PanelDays.Style.Add("display", "none");
        PanelWeek.Style.Add("display", "none");
        lblbatch.Style.Add("display", "none");
        txtbatchtime.Style.Add("display", "none");
        pnlCutoffdays.Style.Add("display", "none");
        Panel1.Visible = false;
        Panel2.Visible = false;
        lblCount.Text = "";
        this.chkPrintMachine.Checked = false;
        this.chkPrintmethod.Checked = false;
        this.chkHistory.Checked = false;
        this.chkAdNote.Checked = false;
        mode = "Insert";
        chkmlinterpretation.Checked = false;
        txtAutomatedText2.Text = "";
        txtAutomatedText3.Text = "";
        txtAutomatedText4.Text = "";
        txtAutomatedText5.Text = "";
        txtAutomatedText_footer.Text = "";
        txttraveltime.Text = "";
       // Panel3.Visible = false;
        Panel3.Style.Add("display", "none");
        ddltimetype.ClearSelection();
        ddlorg.ClearSelection();
        this.ddlProcedure.ClearSelection();
        try
        {
            this.ddlProcedure.Items.FindByValue("001").Selected = true;
        }
        catch { }
        txtReportingTime.Text = "";
    }

    private void FillDG()
    {
        clsBLTest objTTest = new clsBLTest();
        objTTest.SectionID = this.ddlSection.SelectedItem.Value;
        if (!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
        {
            
            objTTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
        }
            DataView dvTTest = objTTest.GetAll(1);

            if (dvTTest.Count > 0)
            {
                dvTTest.Sort = DGSort;
                this.dgTestList.DataSource = dvTTest;
                this.dgTestList.DataBind();
                lblCount.Visible = true;
                lblCount.Text = dvTTest.Count + " Records Found";
                this.dgTestList.Visible = true;
            }
            else
            {
                this.dgTestList.Visible = false;
            }
       // }
        //else
        //{
        //    this.lblErrMsg.Text = "<br>Please select Test Group.<br><br>";
        //    this.dgTestList.Visible = false;
        //}
    }

    private void Insert()
    {
        bool isSuccessful = true;
        clsBLTest objTTest = new clsBLTest();

        objTTest.SectionID = this.ddlSection.SelectedItem.Value;
        objTTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
        objTTest.Active = (this.chkActive.Checked == true) ? "Y" : "N";
        objTTest.Test = this.txtTest.Text;
        objTTest.Acronym = this.txtAcronym.Text;
        objTTest.Charges = this.txtCharges.Text;
        objTTest.ChargesUrgent = this.txtChargesUrgent.Text;
        objTTest.Specimen = this.txtSpecimen.Text;
        objTTest.SpecimenType = this.ddlSpecimenType.SelectedItem.Value;
        objTTest.SpecimenContainer = this.ddlSpecimenContainer.SelectedItem.Value;
        if (chkExternal.Checked)
        {
            objTTest.TestCost = this.txtCostprice.Text.Trim();
            objTTest.ReportingTime = txtReportingTime.Text.Replace("__:__", "");
        }
        //if (txtAutomatedText.Text.Contains("<td>"))
        //{
        //    txtAutomatedText.Text = setAutomatedText();
        //}
        //else
        //{
        //    objTTest.AutomatedText = this.txtAutomatedText.Text;
        //}
        if (!txtAutomatedText.Text.Trim().Equals(""))
        {
            objTTest.AutomatedText = this.txtAutomatedText.Text.Trim();

        }
        if (chkmlinterpretation.Checked)
        {
            if (!txtAutomatedText2.Text.Trim().Equals(""))
            {
                objTTest.Interpretation2 = txtAutomatedText2.Text.Trim();
            }
            if (!txtAutomatedText3.Text.Trim().Equals(""))
            {
                objTTest.Interpretation3 = txtAutomatedText3.Text.Trim();
            }
            if (!txtAutomatedText4.Text.Trim().Equals(""))
            {

                objTTest.Interpretation4 = txtAutomatedText4.Text.Trim();
            }
            if (!txtAutomatedText5.Text.Trim().Equals(""))
            {

                objTTest.Interpretation5 = txtAutomatedText5.Text.Trim();
            }
            if (!txtAutomatedText_footer.Text.Trim().Equals(""))
            {

                objTTest.Interpretationfooter = txtAutomatedText_footer.Text.Trim();
            }
        }
        
        objTTest.ClinicalUse = this.txtClinicalUse.Text;
        objTTest.GenerationLevel = this.ddlGenLevel.SelectedItem.Value;
        objTTest.GenerateOn = this.ddlGenOn.SelectedItem.Value;
        objTTest.ProcedureID = this.ddlProcedure.SelectedItem.Value;
        objTTest.TestType = this.ddlFormat.SelectedItem.Value;
        objTTest.SepReport = (this.chkSepReport.Checked == true) ? "Y" : "N";
        objTTest.PrintTest = (this.chkReportTest.Checked == true) ? "Y" : "N";
        objTTest.PrintGroup = (this.chkReportGroup.Checked == true) ? "Y" : "N";
        objTTest.Urgent = (this.chkUrgent.Checked == true) ? "Y" : "N";
        objTTest.Summary = this.chkSummary.Checked ? "Y" : "N";
        objTTest.ReorderTime = this.txtReorder.Text.Trim();
        objTTest.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objTTest.Enteredby = Session["loginid"].ToString();
        objTTest.SpecimenQuantity = txtQuantity.Text;
        objTTest.SpecimenUnit = txtunit.Text;
        objTTest.ProvisionalReport = (this.chkProvisional.Checked == true) ? "Y" : "N";
        objTTest.External = (this.chkExternal.Checked == true) ? "Y" : "N";
        objTTest.Preferred = this.chkPreferred.Checked == true ? "Y" : "N";
        objTTest.DeliveryDateOnSpecimen = this.chkDelivery.Checked == true ? "Y" : "N";
        objTTest.RoundDelivery = this.chk24hrs.Checked == true ? "Y" : "N";
        objTTest.PrintMachine = this.chkPrintMachine.Checked == true ? "Y" : "N";
        objTTest.PrintMethod = this.chkPrintmethod.Checked == true ? "Y" : "N";
        objTTest.HistoryTaking = this.chkHistory.Checked == true ? "Y" : "N";
        objTTest.Ad_Note = this.chkAdNote.Checked == true ? "Y" : "N";
        if (Convert.ToInt16(ddlPerform.SelectedValue.ToString().Trim()) > 0)
        {
            objTTest.batchTime = txtbatchtime.Text.Trim();
            if (Convert.ToInt16(ddlPerform.SelectedValue.ToString().Trim())==2)//Weekly
            {
                objTTest.Cutoffday = getcutoffday();
            }
        }
        if (chkExternal.Checked == true)
        {
            objTTest.ExtOrganizationID = ddlorg.SelectedValue.ToString();
            objTTest.Timetype = ddltimetype.SelectedValue.ToString();
            objTTest.Traveltime = txttraveltime.Text.Trim().ToString();

        }
        isSuccessful = objTTest.Insert();

        if (!isSuccessful)
        {
            this.lblErrMsg.Text = "<br>" + objTTest.ErrorMessage + "<br><br>";
        }
        else
        {
            #region updating clsBlTestSchedule class
            string _TestID = objTTest.GetTestId();
            //objTTest.TestID = _TestID;
            clsBLTestSchedule objTTestSchedule = new clsBLTestSchedule();
            objTTestSchedule.TestID = _TestID;
            objTTestSchedule.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTTestSchedule.Enteredby = Session["loginid"].ToString();
            objTTestSchedule.ClientID = "0005";
            if (ddlPerform.SelectedValue.ToString() == "0")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
            }
            #region Days
            else if (ddlPerform.SelectedValue.ToString() == "1")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
                if (chkMon1.Checked == true)
                {
                    objTTestSchedule.chkMon1 = "Y";
                }
                if (chkTue1.Checked == true)
                {
                    objTTestSchedule.chkTue1 = "Y";
                }

                if (chkWed1.Checked == true)
                {
                    objTTestSchedule.chkWed1 = "Y";
                }

                if (chkThu1.Checked == true)
                {
                    objTTestSchedule.chkThu1 = "Y";
                }

                if (chkFri1.Checked == true)
                {
                    objTTestSchedule.chkFri1 = "Y";
                }

                if (chkSat1.Checked == true)
                {
                    objTTestSchedule.chkSat1 = "Y";
                }

                if (chkSun1.Checked == true)
                {
                    objTTestSchedule.chkSun1 = "Y";
                }



            }
            #endregion
            #region Weekly
            else if (ddlPerform.SelectedValue.ToString() == "2")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
                if (chkMon1.Checked == true)
                {
                    objTTestSchedule.chkMon1 = "Y";
                }
                if (chkTue1.Checked == true)
                {
                    objTTestSchedule.chkTue1 = "Y";
                }

                if (chkWed1.Checked == true)
                {
                    objTTestSchedule.chkWed1 = "Y";
                }

                if (chkThu1.Checked == true)
                {
                    objTTestSchedule.chkThu1 = "Y";
                }

                if (chkFri1.Checked == true)
                {
                    objTTestSchedule.chkFri1 = "Y";
                }

                if (chkSat1.Checked == true)
                {
                    objTTestSchedule.chkSat1 = "Y";
                }

                if (chkSun1.Checked == true)
                {
                    objTTestSchedule.chkSun1 = "Y";
                }

                /////////////
                if (chkMon2.Checked == true)
                {
                    objTTestSchedule.chkMon2 = "Y";
                }
                if (chkTue2.Checked == true)
                {
                    objTTestSchedule.chkTue2 = "Y";
                }

                if (chkWed2.Checked == true)
                {
                    objTTestSchedule.chkWed2 = "Y";
                }

                if (chkThu2.Checked == true)
                {
                    objTTestSchedule.chkThu2 = "Y";
                }

                if (chkFri2.Checked == true)
                {
                    objTTestSchedule.chkFri2 = "Y";
                }

                if (chkSat2.Checked == true)
                {
                    objTTestSchedule.chkSat2 = "Y";
                }

                if (chkSun2.Checked == true)
                {
                    objTTestSchedule.chkSun2 = "Y";
                }
                /////////////////////////
                if (chkMon3.Checked == true)
                {
                    objTTestSchedule.chkMon3 = "Y";
                }
                if (chkTue3.Checked == true)
                {
                    objTTestSchedule.chkTue3 = "Y";
                }

                if (chkWed3.Checked == true)
                {
                    objTTestSchedule.chkWed3 = "Y";
                }

                if (chkThu3.Checked == true)
                {
                    objTTestSchedule.chkThu3 = "Y";
                }

                if (chkFri3.Checked == true)
                {
                    objTTestSchedule.chkFri3 = "Y";
                }

                if (chkSat3.Checked == true)
                {
                    objTTestSchedule.chkSat3 = "Y";
                }

                if (chkSun3.Checked == true)
                {
                    objTTestSchedule.chkSun3 = "Y";
                }
                /////////////////////
                if (chkMon4.Checked == true)
                {
                    objTTestSchedule.chkMon4 = "Y";
                }
                if (chkTue4.Checked == true)
                {
                    objTTestSchedule.chkTue4 = "Y";
                }

                if (chkWed4.Checked == true)
                {
                    objTTestSchedule.chkWed4 = "Y";
                }

                if (chkThu4.Checked == true)
                {
                    objTTestSchedule.chkThu4 = "Y";
                }

                if (chkFri4.Checked == true)
                {
                    objTTestSchedule.chkFri4 = "Y";
                }

                if (chkSat4.Checked == true)
                {
                    objTTestSchedule.chkSat4 = "Y";
                }

                if (chkSun4.Checked == true)
                {
                    objTTestSchedule.chkSun4 = "Y";
                }

            }
            #endregion
            #region Monthly
            else if (ddlPerform.SelectedIndex.ToString() == "3")
            {
                if (CheckBox1.Checked)
                {
                    objTTestSchedule.ChkMonthly1 = "Y";
                }
                if (CheckBox2.Checked)
                {
                    objTTestSchedule.ChkMonthly2 = "Y";
                }
                if (CheckBox3.Checked)
                {
                    objTTestSchedule.ChkMonthly3 = "Y";
                }
                if (CheckBox14.Checked)
                {
                    objTTestSchedule.ChkMonthly4 = "Y";
                }
                if (CheckBox5.Checked)
                {
                    objTTestSchedule.ChkMonthly5 = "Y";
                }
                if (CheckBox6.Checked)
                {
                    objTTestSchedule.ChkMonthly6 = "Y";
                }
                if (CheckBox7.Checked)
                {
                    objTTestSchedule.ChkMonthly7 = "Y";
                }
                if (CheckBox8.Checked)
                {
                    objTTestSchedule.ChkMonthly8 = "Y";
                }
                if (CheckBox9.Checked)
                {
                    objTTestSchedule.ChkMonthly9 = "Y";
                }
                if (CheckBox10.Checked)
                {
                    objTTestSchedule.ChkMonthly10 = "Y";
                }
                if (CheckBox11.Checked)
                {
                    objTTestSchedule.ChkMonthly11 = "Y";
                }
                if (CheckBox12.Checked)
                {
                    objTTestSchedule.ChkMonthly12 = "Y";
                }
                if (CheckBox13.Checked)
                {
                    objTTestSchedule.ChkMonthly13 = "Y";
                }
                if (CheckBox14.Checked)
                {
                    objTTestSchedule.ChkMonthly14 = "Y";
                }
                if (CheckBox15.Checked)
                {
                    objTTestSchedule.ChkMonthly15 = "Y";
                }
                if (CheckBox16.Checked)
                {
                    objTTestSchedule.ChkMonthly16 = "Y";
                }
                if (CheckBox17.Checked)
                {
                    objTTestSchedule.ChkMonthly17 = "Y";
                }
                if (CheckBox18.Checked)
                {
                    objTTestSchedule.ChkMonthly18 = "Y";
                }
                if (CheckBox19.Checked)
                {
                    objTTestSchedule.ChkMonthly19 = "Y";
                }
                if (CheckBox20.Checked)
                {
                    objTTestSchedule.ChkMonthly20 = "Y";
                }
                if (CheckBox21.Checked)
                {
                    objTTestSchedule.ChkMonthly21 = "Y";
                }
                if (CheckBox22.Checked)
                {
                    objTTestSchedule.ChkMonthly22 = "Y";
                }
                if (CheckBox23.Checked)
                {
                    objTTestSchedule.ChkMonthly23 = "Y";
                }
                if (CheckBox24.Checked)
                {
                    objTTestSchedule.ChkMonthly24 = "Y";
                }
                if (CheckBox25.Checked)
                {
                    objTTestSchedule.ChkMonthly25 = "Y";
                }
                if (CheckBox26.Checked)
                {
                    objTTestSchedule.ChkMonthly26 = "Y";
                }
                if (CheckBox27.Checked)
                {
                    objTTestSchedule.ChkMonthly27 = "Y";
                }
                if (CheckBox28.Checked)
                {
                    objTTestSchedule.ChkMonthly28 = "Y";
                }
                if (CheckBox29.Checked)
                {
                    objTTestSchedule.ChkMonthly29 = "Y";
                }
                if (CheckBox30.Checked)
                {
                    objTTestSchedule.ChkMonthly30 = "Y";
                }
            }
            #endregion
            objTTestSchedule.insertall();
            //this.lblErrMsg.Text = objTTest.GetTestId();
            objTTestSchedule = null;
            #endregion
            this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
            RefreshForm();
            FillDG();

        }
    }

    private string getcutoffday()
    {
        if (chcutMonday.Checked)
        {
            return "1";
        }
        else if (chcuttuesday.Checked)
        {
            return "2";
        }
        else if (chcutwed.Checked)
        {
            return "3";
        }
        else if (chcutthu.Checked)
        {
            return "4";
        }
        else if (chcutFriday.Checked)
        {
            return "5";
        }
        else if (chcutsat.Checked)
        {
            return "6";
        }
        else if (chcutsunday.Checked)
        {
            return "7";
        }
        else
        {
            return "0";
        }
    }
    private string setAutomatedText()
    {
        string AutomatedText = txtAutomatedText.Text.Trim();
        AutomatedText = AutomatedText.Replace("</td>", "|</td>");//
        AutomatedText=AutomatedText.Replace("<td>","");//.Replace("</td>","");
        AutomatedText = AutomatedText.Replace("</td>", "");

        return AutomatedText;
 
    }

    private void Update()
    {
        clsBLTest objTTest = new clsBLTest();

        objTTest.TestID = TestID;
        objTTest.SectionID = this.ddlSection.SelectedItem.Value;
        objTTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
        objTTest.Active = (this.chkActive.Checked == true) ? "Y" : "N";
        objTTest.Test = this.txtTest.Text;
        objTTest.Acronym = this.txtAcronym.Text;
        objTTest.Charges = this.txtCharges.Text;
        objTTest.ChargesUrgent = this.txtChargesUrgent.Text;
        objTTest.Specimen = this.txtSpecimen.Text;
        objTTest.SpecimenType = this.ddlSpecimenType.SelectedItem.Value;
        objTTest.SpecimenContainer = this.ddlSpecimenContainer.SelectedItem.Value;
        if (chkExternal.Checked)
        {
            objTTest.TestCost = this.txtCostprice.Text.Trim();

            objTTest.ReportingTime = txtReportingTime.Text.Replace("__:__", "");
        }
        if (!txtAutomatedText.Text.Trim().Equals(""))
        {
            objTTest.AutomatedText = this.txtAutomatedText.Text.Trim();

        }
        if (chkmlinterpretation.Checked)
        {
            if (!txtAutomatedText2.Text.Trim().Equals(""))
            {
                objTTest.Interpretation2 = txtAutomatedText2.Text.Trim();
            }
            if (!txtAutomatedText3.Text.Trim().Equals(""))
            {
                objTTest.Interpretation3 = txtAutomatedText3.Text.Trim();
            }
            if (!txtAutomatedText4.Text.Trim().Equals(""))
            {

                objTTest.Interpretation4 = txtAutomatedText4.Text.Trim();
            }
            if (!txtAutomatedText5.Text.Trim().Equals(""))
            {

                objTTest.Interpretation5 = txtAutomatedText5.Text.Trim();
            }
            if (!txtAutomatedText_footer.Text.Trim().Equals(""))
            {

                objTTest.Interpretationfooter = txtAutomatedText_footer.Text.Trim();
            }
        }
        objTTest.ClinicalUse = this.txtClinicalUse.Text;
        objTTest.GenerationLevel = this.ddlGenLevel.SelectedItem.Value;
        objTTest.GenerateOn = this.ddlGenOn.SelectedItem.Value;
        objTTest.ProcedureID = this.ddlProcedure.SelectedItem.Value;
        objTTest.TestType = this.ddlFormat.SelectedItem.Value;
        objTTest.SepReport = (this.chkSepReport.Checked == true) ? "Y" : "N";
        objTTest.PrintTest = (this.chkReportTest.Checked == true) ? "Y" : "N";
        objTTest.PrintGroup = (this.chkReportGroup.Checked == true) ? "Y" : "N";
        objTTest.Urgent = (this.chkUrgent.Checked == true) ? "Y" : "N";
        objTTest.Summary = this.chkSummary.Checked ? "Y" : "N";
        objTTest.ReorderTime = this.txtReorder.Text.Trim();
        objTTest.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objTTest.Enteredby = Session["loginid"].ToString();
        objTTest.SpecimenQuantity = txtQuantity.Text;
        objTTest.SpecimenUnit = txtunit.Text;
        objTTest.ProvisionalReport = (this.chkProvisional.Checked == true) ? "Y" : "N";
        objTTest.External = (this.chkExternal.Checked == true) ? "Y" : "N";
        objTTest.Preferred = this.chkPreferred.Checked == true ? "Y" : "N";
        objTTest.DeliveryDateOnSpecimen = this.chkDelivery.Checked == true ? "Y" : "N";
        objTTest.RoundDelivery = this.chk24hrs.Checked == true ? "Y" : "N";
        objTTest.PrintMachine = this.chkPrintMachine.Checked == true ? "Y" : "N";
        objTTest.PrintMethod = this.chkPrintmethod.Checked == true ? "Y" : "N";
        objTTest.HistoryTaking = this.chkHistory.Checked == true ? "Y" : "N";
        objTTest.Ad_Note = this.chkAdNote.Checked == true ? "Y" : "N";
        if (Convert.ToInt16(ddlPerform.SelectedValue.ToString().Trim()) > 0)
        {
            objTTest.batchTime = txtbatchtime.Text.Trim();
            if (Convert.ToInt16(ddlPerform.SelectedValue.ToString().Trim()) == 2)//Weekly
            {
                objTTest.Cutoffday = getcutoffday();
            }
        }
        if (chkExternal.Checked == true)
        {
            objTTest.ExtOrganizationID = ddlorg.SelectedValue.ToString();
            objTTest.Timetype = ddltimetype.SelectedValue.ToString();
            objTTest.Traveltime = txttraveltime.Text.Trim().ToString();

        }
        bool isSuccessful = objTTest.Update();

        if (!isSuccessful)
        {
            this.lblErrMsg.Text = objTTest.ErrorMessage;
        }
        else
        {
            #region updating clsBlTestSchedule class
            //string _TestID = objTTest.GetTestId();
            //objTTest.TestID = _TestID;
            clsBLTestSchedule objTTestSchedule = new clsBLTestSchedule();
            
            objTTestSchedule.TestID = TestID;
            objTTestSchedule.deleteall();
            objTTestSchedule.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTTestSchedule.Enteredby = Session["loginid"].ToString();
            objTTestSchedule.ClientID = "0005";
            if (ddlPerform.SelectedValue.ToString() == "0")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
            }
            #region Days
            else if (ddlPerform.SelectedValue.ToString() == "1")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
                if (chkMon1.Checked == true)
                {
                    objTTestSchedule.chkMon1 = "Y";
                }
                if (chkTue1.Checked == true)
                {
                    objTTestSchedule.chkTue1 = "Y";
                }

                if (chkWed1.Checked == true)
                {
                    objTTestSchedule.chkWed1 = "Y";
                }

                if (chkThu1.Checked == true)
                {
                    objTTestSchedule.chkThu1 = "Y";
                }

                if (chkFri1.Checked == true)
                {
                    objTTestSchedule.chkFri1 = "Y";
                }

                if (chkSat1.Checked == true)
                {
                    objTTestSchedule.chkSat1 = "Y";
                }

                if (chkSun1.Checked == true)
                {
                    objTTestSchedule.chkSun1 = "Y";
                }



            }
            #endregion
            #region Weekly
            else if (ddlPerform.SelectedValue.ToString() == "2")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
                if (chkMon1.Checked == true)
                {
                    objTTestSchedule.chkMon1 = "Y";
                }
                if (chkTue1.Checked == true)
                {
                    objTTestSchedule.chkTue1 = "Y";
                }

                if (chkWed1.Checked == true)
                {
                    objTTestSchedule.chkWed1 = "Y";
                }

                if (chkThu1.Checked == true)
                {
                    objTTestSchedule.chkThu1 = "Y";
                }

                if (chkFri1.Checked == true)
                {
                    objTTestSchedule.chkFri1 = "Y";
                }

                if (chkSat1.Checked == true)
                {
                    objTTestSchedule.chkSat1 = "Y";
                }

                if (chkSun1.Checked == true)
                {
                    objTTestSchedule.chkSun1 = "Y";
                }

                /////////////
                if (chkMon2.Checked == true)
                {
                    objTTestSchedule.chkMon2 = "Y";
                }
                if (chkTue2.Checked == true)
                {
                    objTTestSchedule.chkTue2 = "Y";
                }

                if (chkWed2.Checked == true)
                {
                    objTTestSchedule.chkWed2 = "Y";
                }

                if (chkThu2.Checked == true)
                {
                    objTTestSchedule.chkThu2 = "Y";
                }

                if (chkFri2.Checked == true)
                {
                    objTTestSchedule.chkFri2 = "Y";
                }

                if (chkSat2.Checked == true)
                {
                    objTTestSchedule.chkSat2 = "Y";
                }

                if (chkSun2.Checked == true)
                {
                    objTTestSchedule.chkSun2 = "Y";
                }
                /////////////////////////
                if (chkMon3.Checked == true)
                {
                    objTTestSchedule.chkMon3 = "Y";
                }
                if (chkTue3.Checked == true)
                {
                    objTTestSchedule.chkTue3 = "Y";
                }

                if (chkWed3.Checked == true)
                {
                    objTTestSchedule.chkWed3 = "Y";
                }

                if (chkThu3.Checked == true)
                {
                    objTTestSchedule.chkThu3 = "Y";
                }

                if (chkFri3.Checked == true)
                {
                    objTTestSchedule.chkFri3 = "Y";
                }

                if (chkSat3.Checked == true)
                {
                    objTTestSchedule.chkSat3 = "Y";
                }

                if (chkSun3.Checked == true)
                {
                    objTTestSchedule.chkSun3 = "Y";
                }
                /////////////////////
                if (chkMon4.Checked == true)
                {
                    objTTestSchedule.chkMon4 = "Y";
                }
                if (chkTue4.Checked == true)
                {
                    objTTestSchedule.chkTue4 = "Y";
                }

                if (chkWed4.Checked == true)
                {
                    objTTestSchedule.chkWed4 = "Y";
                }

                if (chkThu4.Checked == true)
                {
                    objTTestSchedule.chkThu4 = "Y";
                }

                if (chkFri4.Checked == true)
                {
                    objTTestSchedule.chkFri4 = "Y";
                }

                if (chkSat4.Checked == true)
                {
                    objTTestSchedule.chkSat4 = "Y";
                }

                if (chkSun4.Checked == true)
                {
                    objTTestSchedule.chkSun4 = "Y";
                }

            }
            #endregion

            #region Monthly
            else if (ddlPerform.SelectedValue.ToString() == "3")
            {
                objTTestSchedule.Type = ddlPerform.SelectedItem.Text;
                if (CheckBox1.Checked)
                {
                    objTTestSchedule.ChkMonthly1 = "Y";
                }
                if (CheckBox2.Checked)
                {
                    objTTestSchedule.ChkMonthly2 = "Y";
                }
                if (CheckBox3.Checked)
                {
                    objTTestSchedule.ChkMonthly3 = "Y";
                }
                if (CheckBox14.Checked)
                {
                    objTTestSchedule.ChkMonthly4 = "Y";
                }
                if (CheckBox5.Checked)
                {
                    objTTestSchedule.ChkMonthly5 = "Y";
                }
                if (CheckBox6.Checked)
                {
                    objTTestSchedule.ChkMonthly6 = "Y";
                }
                if (CheckBox7.Checked)
                {
                    objTTestSchedule.ChkMonthly7 = "Y";
                }
                if (CheckBox8.Checked)
                {
                    objTTestSchedule.ChkMonthly8 = "Y";
                }
                if (CheckBox9.Checked)
                {
                    objTTestSchedule.ChkMonthly9 = "Y";
                }
                if (CheckBox10.Checked)
                {
                    objTTestSchedule.ChkMonthly10 = "Y";
                }
                if (CheckBox11.Checked)
                {
                    objTTestSchedule.ChkMonthly11 = "Y";
                }
                if (CheckBox12.Checked)
                {
                    objTTestSchedule.ChkMonthly12 = "Y";
                }
                if (CheckBox13.Checked)
                {
                    objTTestSchedule.ChkMonthly13 = "Y";
                }
                if (CheckBox14.Checked)
                {
                    objTTestSchedule.ChkMonthly14 = "Y";
                }
                if (CheckBox15.Checked)
                {
                    objTTestSchedule.ChkMonthly15 = "Y";
                }
                if (CheckBox16.Checked)
                {
                    objTTestSchedule.ChkMonthly16 = "Y";
                }
                if (CheckBox17.Checked)
                {
                    objTTestSchedule.ChkMonthly17 = "Y";
                }
                if (CheckBox18.Checked)
                {
                    objTTestSchedule.ChkMonthly18 = "Y";
                }
                if (CheckBox19.Checked)
                {
                    objTTestSchedule.ChkMonthly19 = "Y";
                }
                if (CheckBox20.Checked)
                {
                    objTTestSchedule.ChkMonthly20 = "Y";
                }
                if (CheckBox21.Checked)
                {
                    objTTestSchedule.ChkMonthly21 = "Y";
                }
                if (CheckBox22.Checked)
                {
                    objTTestSchedule.ChkMonthly22 = "Y";
                }
                if (CheckBox23.Checked)
                {
                    objTTestSchedule.ChkMonthly23 = "Y";
                }
                if (CheckBox24.Checked)
                {
                    objTTestSchedule.ChkMonthly24 = "Y";
                }
                if (CheckBox25.Checked)
                {
                    objTTestSchedule.ChkMonthly25 = "Y";
                }
                if (CheckBox26.Checked)
                {
                    objTTestSchedule.ChkMonthly26 = "Y";
                }
                if (CheckBox27.Checked)
                {
                    objTTestSchedule.ChkMonthly27 = "Y";
                }
                if (CheckBox28.Checked)
                {
                    objTTestSchedule.ChkMonthly28 = "Y";
                }
                if (CheckBox29.Checked)
                {
                    objTTestSchedule.ChkMonthly29 = "Y";
                }
                if (CheckBox30.Checked)
                {
                    objTTestSchedule.ChkMonthly30 = "Y";
                }
            }
            #endregion
            objTTestSchedule.insertall();
            //this.lblErrMsg.Text = objTTest.GetTestId();
            objTTestSchedule = null;
            #endregion
            this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
            this.ibtnSave.ToolTip = "Save";
            RefreshForm();
            FillDG();
        }
    }

    private void lbtnClearAll_Click(object sender, System.EventArgs e)
    {

    }

    protected void dgTestList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        
        this.lblErrMsg.Text = "";
        FillForm(e.Item.ItemIndex);
        EnableForm(true);
       // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "OnClick", "<script>window.scrollTo(0,0); </script>");
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "ScrollPage", "ResetScrollPosition();", true);
    }

    protected void FillForm(int index)
    {
        try
        {
            TestID = this.dgTestList.Items[index].Cells[1].Text.Replace("&nbsp;", "");
            string testgroupid = "";
            clsBLTest obj_getgroup = new clsBLTest();
            obj_getgroup.TestID = TestID;

            DataView dv_group = obj_getgroup.GetAll(9);
            if (dv_group.Count > 0)
            {
                testgroupid = dv_group[0]["TestGroupID"].ToString();
            }
            dv_group.Dispose();
            this.chkActive.Checked = ((CheckBox)this.dgTestList.Items[index].Cells[8].FindControl("dgchkActive")).Checked;
            this.txtTest.Text = this.dgTestList.Items[index].Cells[3].Text.Replace("&nbsp;", "");
            this.txtAcronym.Text = this.dgTestList.Items[index].Cells[6].Text.Replace("&nbsp;", "");
            this.txtCharges.Text = this.dgTestList.Items[index].Cells[8].Text.Replace("&nbsp;", "");
            this.txtChargesUrgent.Text = this.dgTestList.Items[index].Cells[24].Text.Replace("&nbsp;", "");
            this.txtSpecimen.Text = this.dgTestList.Items[index].Cells[7].Text.Replace("&nbsp;", "");
            this.txtAutomatedText.Text = this.dgTestList.Items[index].Cells[12].Text.Replace("&nbsp;", "");
            this.txtClinicalUse.Text = this.dgTestList.Items[index].Cells[13].Text.Replace("&nbsp;", "");

            this.ddlProcedure.SelectedItem.Selected = false;
            this.ddlProcedure.Items.FindByValue(this.dgTestList.Items[index].Cells[14].Text).Selected = true;

            this.ddlGenLevel.SelectedItem.Selected = false;
            this.ddlGenLevel.Items.FindByValue(this.dgTestList.Items[index].Cells[15].Text).Selected = true;

            this.ddlGenOn.SelectedItem.Selected = false;
            this.ddlGenOn.Items.FindByValue(this.dgTestList.Items[index].Cells[16].Text).Selected = true;

            this.ddlFormat.SelectedItem.Selected = false;
            try
            {
                this.ddlFormat.Items.FindByValue(this.dgTestList.Items[index].Cells[20].Text).Selected = true;
            }
            catch { }
            this.ddlTestGroup.ClearSelection();
            try
            {
                //this.ddlTestGroup.Items.FindByText(this.dgTestList.Items[index].Cells[5].Text).Selected = true;
                this.ddlTestGroup.Items.FindByValue(testgroupid).Selected = true;
            }
            catch { }
            this.ddlSpecimenType.SelectedItem.Selected = false;
            try
            {
                this.ddlSpecimenType.Items.FindByValue(this.dgTestList.Items[index].Cells[17].Text).Selected = true;
            }
            catch { }

            this.ddlSpecimenContainer.SelectedItem.Selected = false;
            try
            {
                this.ddlSpecimenContainer.Items.FindByValue(this.dgTestList.Items[index].Cells[18].Text).Selected = true;
            }
            catch { }

            this.chkSepReport.Checked = (this.dgTestList.Items[index].Cells[21].Text == "Y");
            this.chkReportGroup.Checked = (this.dgTestList.Items[index].Cells[22].Text == "Y");
            this.chkReportTest.Checked = (this.dgTestList.Items[index].Cells[23].Text == "Y");
            this.chkUrgent.Checked = (this.dgTestList.Items[index].Cells[25].Text == "Y");
            this.chkSummary.Checked = (this.dgTestList.Items[index].Cells[26].Text == "Y");
            this.txtReorder.Text = this.dgTestList.Items[index].Cells[27].Text.Replace("&nbsp;", "");
            this.chkProvisional.Checked = (this.dgTestList.Items[index].Cells[28].Text == "Y");
            this.chkExternal.Checked = (this.dgTestList.Items[index].Cells[29].Text == "Y");
            if (this.chkExternal.Checked == true)
            {
                //Panel3.Visible = true;
                Panel3.Style.Add("display", "block");
                //,tt.travel_time,tt.time_type
                this.ddlorg.SelectedValue = dgTestList.Items[index].Cells[45].Text.Trim();
                this.ddltimetype.SelectedValue = dgTestList.Items[index].Cells[47].Text.Trim();
                this.txttraveltime.Text = dgTestList.Items[index].Cells[46].Text.Trim();
                this.txtCostprice.Text = dgTestList.Items[index].Cells[48].Text.Trim();
                txtReportingTime.Text = dgTestList.Items[index].Cells[50].Text.Trim();

            }
            this.txtQuantity.Text = this.dgTestList.Items[index].Cells[30].Text.Replace("&nbsp;", "");
            this.txtunit.Text = this.dgTestList.Items[index].Cells[31].Text.Replace("&nbsp;", "");
            this.chkPreferred.Checked = (this.dgTestList.Items[index].Cells[32].Text == "Y");
            this.chkDelivery.Checked = (this.dgTestList.Items[index].Cells[33].Text == "Y");
            this.chk24hrs.Checked = (this.dgTestList.Items[index].Cells[34].Text == "Y");
            this.chkPrintmethod.Checked = (this.dgTestList.Items[index].Cells[35].Text == "Y");
            this.chkPrintMachine.Checked = (this.dgTestList.Items[index].Cells[36].Text == "Y");
            this.chkHistory.Checked = (this.dgTestList.Items[index].Cells[37].Text == "Y");
            this.chkAdNote.Checked = (this.dgTestList.Items[index].Cells[38].Text == "Y");
            this.txtAutomatedText2.Text = dgTestList.Items[index].Cells[40].Text.Trim();
            this.txtAutomatedText3.Text = dgTestList.Items[index].Cells[41].Text.Trim();
            this.txtAutomatedText4.Text = dgTestList.Items[index].Cells[42].Text.Trim();
            this.txtAutomatedText5.Text = dgTestList.Items[index].Cells[43].Text.Trim();
            this.txtAutomatedText_footer.Text = dgTestList.Items[index].Cells[44].Text.Trim();
            Panel1.Visible = true;
            Panel2.Visible = true;
            this.FillTest_Metod_Group(TestID);
            clsBLTestSchedule objTestSchedule = new clsBLTestSchedule();
            objTestSchedule.TestID = TestID;
            DataView dv = new DataView();
            dv = objTestSchedule.GetAll(1);
            ddlPerform.ClearSelection();
            uncheckall();
            uncheckcutoffdays();
            if (dv.Count > 0)
            {

                ddlPerform.Items.FindByText(dv[0]["Type"].ToString()).Selected = true;
                if (ddlPerform.SelectedItem.Text == "Daily")
                {
                    //lblbatch.Visible = false;
                    //txtbatchtime.Visible = false;
                    //PanelDays.Visible = false;
                    //PanelWeek.Visible = false;

                    PanelDays.Style.Add("display", "none");
                    PanelWeek.Style.Add("display", "none");
                    lblbatch.Style.Add("display", "none");
                    txtbatchtime.Style.Add("display", "none");
                    pnlCutoffdays.Style.Add("display", "none");
                    PanelMonthly.Style.Add("display", "none");
                }
                else if (ddlPerform.SelectedItem.Text == "Days")
                {
                    //lblbatch.Visible = true;
                    //txtbatchtime.Visible = true;
                    txtbatchtime.Text = this.dgTestList.Items[index].Cells[39].Text.Trim();
                    txtbatchtime.Style.Add("display", "block");
                    PanelDays.Style.Add("display", "block");
                    PanelWeek.Style.Add("display", "none");
                    lblbatch.Style.Add("display", "block");
                    pnlCutoffdays.Style.Add("display", "none");
                    PanelMonthly.Style.Add("display", "none");
                    //PanelDays.Visible = true;
                    //PanelWeek.Visible = false;
                    DataTable dt = dv.ToTable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Value"].ToString() == "Monday")
                        {
                            chkMon1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Tuesday")
                        {
                            chkTue1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Wednesday")
                        {
                            chkWed1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Thursday")
                        {
                            chkThu1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Friday")
                        {
                            chkFri1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Saturday")
                        {
                            chkSat1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "Sunday")
                        {
                            chkSun1.Checked = true;
                        }
                    }
                    dt.Dispose();


                }
                #region Weekly
                else if (ddlPerform.SelectedItem.Text == "Weekly")
                {
                    txtbatchtime.Text = this.dgTestList.Items[index].Cells[39].Text.Trim();
                    //lblbatch.Visible = true;
                    //txtbatchtime.Visible = true;
                    //PanelDays.Visible = true;
                    ////PanelDays.Style.Add("display", "block");
                    //PanelWeek.Visible = true;
                    PanelDays.Style.Add("display", "block");
                    PanelWeek.Style.Add("display", "block");
                    txtbatchtime.Style.Add("display", "block");
                    lblbatch.Style.Add("display", "block");
                    pnlCutoffdays.Style.Add("display", "block");
                    PanelMonthly.Style.Add("display", "none");
                    try
                    {
                         checkcutoffday(dgTestList.Items[index].Cells[49].Text.Trim());
                    }
                    catch
                    {
                        uncheckcutoffdays();
                    }
                    DataTable dt = dv.ToTable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["Value"].ToString() == "1-Monday")
                        {
                            chkMon1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Tuesday")
                        {
                            chkTue1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Wednesday")
                        {
                            chkWed1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Thursday")
                        {
                            chkThu1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Friday")
                        {
                            chkFri1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Saturday")
                        {
                            chkSat1.Checked = true;
                        }
                        if (dr["Value"].ToString() == "1-Sunday")
                        {
                            chkSun1.Checked = true;
                        }
                        //////////////////
                        if (dr["Value"].ToString() == "2-Monday")
                        {
                            chkMon2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Tuesday")
                        {
                            chkTue2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Wednesday")
                        {
                            chkWed2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Thursday")
                        {
                            chkThu2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Friday")
                        {
                            chkFri2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Saturday")
                        {
                            chkSat2.Checked = true;
                        }
                        if (dr["Value"].ToString() == "2-Sunday")
                        {
                            chkSun2.Checked = true;
                        }
                        ////////////////////////
                        if (dr["Value"].ToString() == "3-Monday")
                        {
                            chkMon3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Tuesday")
                        {
                            chkTue3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Wednesday")
                        {
                            chkWed3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Thursday")
                        {
                            chkThu3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Friday")
                        {
                            chkFri3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Saturday")
                        {
                            chkSat3.Checked = true;
                        }
                        if (dr["Value"].ToString() == "3-Sunday")
                        {
                            chkSun3.Checked = true;
                        }
                        ////////////////////////////////
                        if (dr["Value"].ToString() == "4-Monday")
                        {
                            chkMon4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-TuesDay")
                        {
                            chkTue4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-Wednesday")
                        {
                            chkWed4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-Thursday")
                        {
                            chkThu4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-Friday")
                        {
                            chkFri4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-Saturday")
                        {
                            chkSat4.Checked = true;
                        }
                        if (dr["Value"].ToString() == "4-Sunday")
                        {
                            chkSun4.Checked = true;
                        }
                        ///////////////////////////////////
                        dt.Dispose();
                        dv.Dispose();

                    }
                }
                #endregion
                else if (ddlPerform.SelectedItem.Text == "Monthly")
                {
                    uncheckall();
                    uncheckcutoffdays();
                    txtbatchtime.Text = this.dgTestList.Items[index].Cells[39].Text.Trim();
                    txtbatchtime.Style.Add("display", "block");
                    PanelDays.Style.Add("display", "none");
                    lblbatch.Style.Add("display", "block");
                    pnlCutoffdays.Style.Add("display", "none");
                    PanelWeek.Style.Add("display", "none");
                    PanelMonthly.Style.Add("display", "block");

                    DataTable dt = dv.ToTable();
                    foreach (DataRow dr in dt.Rows)
                    {
                        for (int i = 1; i <= 30; i++)
                        {
                            if (dr["Value"].ToString() == i.ToString())
                            {
                                (Page.FindControl("CheckBox" + i.ToString()) as CheckBox).Checked = true;
                            }
                        }
                        
                    }
                    dt.Dispose();
                    dv.Dispose();

                }

            }
            else
            {
               // PanelDays.Visible = false;
               // PanelWeek.Visible = false;
                PanelDays.Style.Add("display", "none");
                PanelWeek.Style.Add("display", "none");
                pnlCutoffdays.Style.Add("display", "none");
            }
            this.ibtnSave.ToolTip = "Update";
            mode = "Update";
        }
        catch (Exception ee)
        {
            Response.Write(ee.ToString());
        }
    }

    private void checkcutoffday(string cutoffday)
    {
        switch (Convert.ToInt16(cutoffday))
        {
            case 1:
                chcutMonday.Checked = true;
                break;
            case 2:
                chcuttuesday.Checked = true;
                break;
            case 3:
                chcutwed.Checked = true;
                break;
            case 4:
                chcutthu.Checked = true;
                break;
            case 5:
                chcutFriday.Checked = true;
                break;
            case 6:
                chcutsat.Checked = true;
                break;
            case 7:
                chcutsunday.Checked = true;
                break;
        }
    }

    private void uncheckcutoffdays()
    {
        chcutMonday.Checked = false;
        chcuttuesday.Checked = false;
        chcutwed.Checked = false;
        chcutthu.Checked = false;
        chcutFriday.Checked = false;
        chcutsat.Checked = false;
        chcutsunday.Checked = false;
    }

    private void FillTest_Metod_Group(string TesttID)
    {
        clsBLTest objFillTest_me_gr = new clsBLTest();
        objFillTest_me_gr.TestID = TesttID;
        DataView dv_methods = objFillTest_me_gr.GetAll(6);
        gvMethod.DataSource = dv_methods;
        gvMethod.DataBind();
        dv_methods.Dispose();

        DataView dv_TestGroups = objFillTest_me_gr.GetAll(7);
        gvTestGroup.DataSource = dv_TestGroups;
        gvTestGroup.DataBind();
        dv_TestGroups.Dispose();

    }

    protected void dgTestList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DGSort = e.SortExpression;
        FillDG();
    }

    protected void dgTestList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
    {
        this.lblErrMsg.Text = "";
        this.dgTestList.CurrentPageIndex = e.NewPageIndex;
        FillDG();
    }

    protected void dgTestList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            clsBLTest objTTest = new clsBLTest();

            objTTest.TestID = e.Item.Cells[0].Text;
            objTTest.Active = "D";
            bool isSuccessful = objTTest.Delete();

            if (!isSuccessful)
            {
                this.lblErrMsg.Text = objTTest.ErrorMessage;
            }
            else
            {
                this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
                RefreshForm();
                FillDG();
            }
        }
    }

    protected void dgTestList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
    {
        // Create a new WebUIFacade.
        WebUIFacade uiFacade = new WebUIFacade();

        // This is gives a tool tip for each
        // of the columns to sort by.
        uiFacade.SetHeaderToolTip(e);


        // This sets a class for the link buttons in a grid.
        uiFacade.SetGridLinkButtonStyle(e);

        // Make the row change color when the mouse hovers over.
        // *** You must have a class called gridHover with a different background 
        // color in your StyleSheet.
        uiFacade.SetRowHover(this.dgTestList, e);
    }

    

    protected void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        this.lblErrMsg.Text = "";
        this.chkActive.Checked = true;
        this.txtTest.Text = "";
        this.txtAcronym.Text = "";
        this.txtCharges.Text = "";
        this.txtChargesUrgent.Text = "";
        this.txtSpecimen.Text = "";
        this.txtAutomatedText.Text = "";
        this.txtClinicalUse.Text = "";
        this.ibtnSave.ToolTip = "Save";
        this.chkUrgent.Checked = false;
        this.chkReportGroup.Checked = false;
        this.chkReportTest.Checked = false;
        this.chkSepReport.Checked = false;
        this.chkSummary.Checked = false;
        this.txtReorder.Text = "";
        this.ddlPerform.ClearSelection();
        uncheckall();
        uncheckcutoffdays();
        //PanelDays.Visible = false;
        //PanelWeek.Visible = false;
        PanelDays.Style.Add("display", "none");
        PanelWeek.Style.Add("display", "none");
        pnlCutoffdays.Style.Add("display", "none");
        this.txtQuantity.Text = "";
        this.txtunit.Text = "";
        Panel1.Visible = false;
        Panel2.Visible = false;
        lblCount.Text = "";
        this.chkPrintMachine.Checked = false;
        this.chkPrintmethod.Checked = false;
        Panel3.Style.Add("display", "none");
        // Panel3.Visible = false;
        ddlorg.ClearSelection();
        ddltimetype.ClearSelection();
        txttraveltime.Text = "";
        lblbatch.Style.Add("display", "none");
        txtbatchtime.Style.Add("display", "none");

        this.ddlProcedure.ClearSelection();
        try
        {
            this.ddlProcedure.Items.FindByValue("001").Selected = true;
        }
        catch { }
        txtReportingTime.Text = "";


        mode = "Insert";
    }

    protected void ibtnTestAttribute_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.open('wfrmTestAttribute.aspx','','fullscreen')</script>");
    }

    protected void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>self.close();</script>");
    }

    protected void ddlPerform_SelectedIndexChanged(object sender, EventArgs e)
    {
        uncheckall();
        uncheckcutoffdays();
        if (ddlPerform.SelectedValue.ToString() == "0")
        {
            //lblbatch.Visible = false;
            //txtbatchtime.Visible = false;
            //PanelDays.Visible = false;
            PanelDays.Style.Add("display", "none");
            lblbatch.Style.Add("display", "none");
            txtbatchtime.Style.Add("display", "none");
            PanelWeek.Style.Add("display", "none");
            pnlCutoffdays.Style.Add("display", "none");
            //PanelDays.Style.Add("display", "block");
        }
        else if (ddlPerform.SelectedValue.ToString() == "1")
        {
            //lblbatch.Visible = true;
            //txtbatchtime.Visible = true;
            //PanelDays.Visible = true;
            //PanelWeek.Visible = false;

            PanelDays.Style.Add("display", "block");
            PanelWeek.Style.Add("display", "none");
            lblbatch.Style.Add("display", "block");
            txtbatchtime.Style.Add("display", "block");
            pnlCutoffdays.Style.Add("display", "none");
        }
        else if (ddlPerform.SelectedValue.ToString() == "2")
        {
            //lblbatch.Visible = true;
            //txtbatchtime.Visible = true;
            //PanelDays.Visible = true;
            //PanelWeek.Visible = true;
            PanelDays.Style.Add("display", "block");
            PanelWeek.Style.Add("display", "block");
            lblbatch.Style.Add("display", "block");
            txtbatchtime.Style.Add("display", "block");
            pnlCutoffdays.Style.Add("display", "block");
        }
    }

    protected void dgTestList_Sorting(object sender, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        if (e.SortExpression == "Test")
        {
            if (DGSort == "Test ASC")
            {
                DGSort = "Test DESC";
            }
            else
                DGSort = "Test ASC";
        }
        if (e.SortExpression == "Method")
        {
            if (DGSort == "Method ASC")
            {
                DGSort = "Method DESC";
            }
            else
                DGSort = "Method ASC";
        }
        if (e.SortExpression == "TESTGROUP")
        {
            if (DGSort == "TESTGROUP ASC")
            {
                DGSort = "TESTGROUP DESC";
            }
            else
                DGSort = "TESTGROUP ASC";
        }
        if (e.SortExpression == "Acronym")
        {
            if (DGSort == "Acronym ASC")
            {
                DGSort = "Acronym DESC";
            }
            else
                DGSort = "Acronym ASC";
        }
        if (e.SortExpression == "Specimen")
        {
            if (DGSort == "Specimen ASC")
            {
                DGSort = "Specimen DESC";
            }
            else
                DGSort = "Specimen ASC";
        }
        if (e.SortExpression == "Charges")
        {
            if (DGSort == "Charges ASC")
            {
                DGSort = "Charges DESC";
            }
            else
                DGSort = "Charges ASC";
        }
        if (e.SortExpression == "DORDER")
        {
            if (DGSort == "DORDER ASC")
            {
                DGSort = "DORDER DESC";
            }
            else
                DGSort = "DORDER ASC";
        }
        if (e.SortExpression == "Active")
        {
            if (DGSort == "Active ASC")
            {
                DGSort = "Active DESC";
            }
            else
                DGSort = "Active ASC";
        }
        FillDG();
 
    }

    private void uncheckall()
    {
        chkMon1.Checked = false;
        chkMon2.Checked = false;
        chkMon3.Checked = false;
        chkMon4.Checked = false;

        chkTue1.Checked = false;
        chkTue2.Checked = false;
        chkTue3.Checked = false;
        chkTue4.Checked = false;

        chkWed1.Checked = false;
        chkWed2.Checked = false;
        chkWed3.Checked = false;
        chkWed4.Checked = false;

        chkThu1.Checked = false;
        chkThu2.Checked = false;
        chkThu3.Checked = false;
        chkThu4.Checked = false;

        chkFri1.Checked = false;
        chkFri2.Checked = false;
        chkFri3.Checked = false;
        chkFri4.Checked = false;

        chkSat1.Checked = false;
        chkSat2.Checked = false;
        chkSat3.Checked = false;
        chkSat4.Checked = false;

        chkSun1.Checked = false;
        chkSun2.Checked = false;
        chkSun3.Checked = false;
        chkSun4.Checked = false;

        for (int i = 1; i <= 30; i++)
        {
            (Page.FindControl("CheckBox" + i.ToString()) as CheckBox).Checked = false;
        }

    }

    protected void chkExternal_CheckedChanged(object sender, EventArgs e)
    {
        if (chkExternal.Checked == true)
        {
            Panel3.Style.Add("display", "block");
            //  Panel3.Visible = true;
        }
        else
        {
            //Panel3.Visible = false;
            Panel3.Style.Add("display", "none");
            ddltimetype.ClearSelection();
            ddlorg.ClearSelection();
            txttraveltime.Text = "";
        }

    }
    
}