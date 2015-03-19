using System;
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

namespace HMIS.LIMS.WebForms
{
    /// <summary>
    /// Summary description for wfrmGeneralTestResult.
    /// </summary>
    public partial class wfrmGeneralTestResult : System.Web.UI.Page
    {
        private static string DGSort = "LabID ASC";
        private static string ProcessID = "0004";
        const string ScreenID = "001";
        //string RoleID = "001";		

        protected void Page_Load(object sender, System.EventArgs e)
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
                    clsBLPreferenceSettings obj_Pref = new clsBLPreferenceSettings();
                    DataView dv_resultentrytime = obj_Pref.GetAll(1);
                    if (dv_resultentrytime.Count > 0)
                    {
                        hdresultEntryTime.Value = dv_resultentrytime[0]["RESULTENTRYTIME"].ToString();
                    }
                    dv_resultentrytime.Dispose();
                    obj_Pref = null;
                    FillDDL();
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
            this.dgGroupList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGroupList_ItemCreated);
            this.dgGroupList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgGroupList_PageIndexChanged);

        }
        #endregion
        private void FillDDL()
        {
            clsBLSection objSection = new clsBLSection();
            SComponents objComp = new SComponents();

            objSection.Active = "Y";
            DataView dvSection = objSection.GetAll(1);
            objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID");

            // getting Ward list
            clsBLWard objWard = new clsBLWard();
            objWard.Active = "Y";
            DataView dvWard = objWard.GetAll(1);
            objComp.FillDropDownList(this.ddlWard, dvWard, "WardName", "WardID");
        }

        protected void dgGrouplist_OnRowDataBound(object sender, DataGridItemEventArgs e)
        {
            Control container=e.Item;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _priority = DataBinder.Eval(e.Item.DataItem, "Priority").ToString();

                if (_priority == "Urg" || _priority == "U")
                {
                    e.Item.ForeColor = Color.IndianRed;
                }
                string del_datetime = e.Item.Cells[14].Text;
                if (del_datetime != "" && del_datetime != "&nbsp;")
                {
                    double hours = (Convert.ToDateTime(del_datetime) - System.DateTime.Now).TotalHours;
                    if (hours > Convert.ToDouble(hdresultEntryTime.Value))
                    {
                        ////e.Item.BackColor = Color.OrangeRed;
                        ColorCode2.Visible = true;
                        e.Item.BackColor = Color.Silver;
                        ColorCode2.Text = ">" + hdresultEntryTime.Value.ToString() + "hours";
                    }
                    else if (hours < Convert.ToDouble(hdresultEntryTime.Value) && hours > 0)
                    {
                        ColorCode1.Visible = true;
                        e.Item.BackColor = Color.Gold;
                        ColorCode1.Text = "<" + hdresultEntryTime.Value.ToString() + "hours";
                    }
                    else if (hours < 0)
                    {
                        ColorCode3.Visible = true;
                        e.Item.BackColor = Color.OrangeRed;
                    }
                }
                LinkButton btnfield = (LinkButton)e.Item.Cells[0].Controls[0];
                string labId = btnfield.Text;
                string testid = e.Item.Cells[12].Text;
                clsBlRepeatTest obj_chkRepeat = new clsBlRepeatTest();
                obj_chkRepeat.LabID = labId;
                obj_chkRepeat.TestID = testid;
                DataView dv_chkRepeat = obj_chkRepeat.GetAll(1);
                if (dv_chkRepeat.Count > 0)
                {
                    e.Item.BackColor = Color.Bisque;

                }

                DropDownList ddlReasons = (DropDownList)container.FindControl("ddlReasons");
                clsBLRepeatReasons objReasons = new clsBLRepeatReasons();
                DataView dv_Reasons = objReasons.GetAll(1);
                if (dv_Reasons.Count > 0)
                {
                    SComponents obj_com = new SComponents();
                    obj_com.FillDropDownList(ddlReasons, dv_Reasons, "Reason", "REPEATREASON_ID");
                    obj_com = null;
                    dv_Reasons.Dispose();


                }
                else
                {
                    dv_Reasons.Dispose();
                }

            }
            
        }
        
        protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            clsBLTestGroup objTestGroup = new clsBLTestGroup();
            SComponents objComp = new SComponents();

            objTestGroup.Active = "Y";
            objTestGroup.SectionID = ddlSection.SelectedValue;
            DataView dvTestGroup = objTestGroup.GetAll(3);
            objComp.FillDropDownList(this.ddlTestGroup, dvTestGroup, "TestGroup", "TestGroupID");
        }

        private void RefreshForm()
        {
            this.txtMSerialNoFrom.Text = "";
            this.txtMSerialNoTo.Text = "";
            this.TextBox1.Text = "";
            this.txtPatientName.Text = "";
            try
            {
                this.ddlTestGroup.SelectedItem.Selected = false;
                this.ddlTestGroup.Items.FindByValue("-1").Selected = true;
            }
            catch
            { }
            try
            {
                this.ddlWard.SelectedItem.Selected = false;
                this.ddlWard.Items.FindByValue("-1").Selected = true;
            }
            catch
            { }
        }

        private void FillDG()
        {
            clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();
            if (!this.ddlSection.SelectedItem.Value.Equals("-1"))
            {
                //objTSpecimenColletion.SectionID = this.ddlSection.SelectedItem.Value;				
                objTGeneralTestResult.SectionID = ddlSection.SelectedValue;

                # region "Parameters Conditions"
                try
                {
                    if (!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
                    { objTGeneralTestResult.TestGroupID = this.ddlTestGroup.SelectedItem.Value; }
                }
                catch { }

                try
                {
                    if (!this.ddlWard.SelectedItem.Value.Equals("-1"))
                    { objTGeneralTestResult.WardID = this.ddlWard.SelectedItem.Value; }
                }
                catch { }

                if (this.txtMSerialNoFrom.Text.Trim() != "")
                { objTGeneralTestResult.LabIDFrom = this.txtMSerialNoFrom.Text; }
                if (this.txtMSerialNoTo.Text.Trim() != "")
                { objTGeneralTestResult.LabIDTo = this.txtMSerialNoTo.Text; }

                if (this.TextBox1.Text.Trim() != "")
                { objTGeneralTestResult.PRNo = this.TextBox1.Text; }

                if (this.txtPatientName.Text.Trim() != "")
                { objTGeneralTestResult.PatientName = this.txtPatientName.Text; }
                if (TabContainer1.ActiveTab.ID == "tbExternaltest")
                {
                    objTGeneralTestResult.External = "Y";
                }
                else
                {
                    objTGeneralTestResult.External = "N";

                }


                objTGeneralTestResult.ProcessID = ProcessID;
                # endregion

                DataView dvTGeneralTestResult = new DataView(); 

                

                    if (TabContainer1.ActiveTab.ID == "tbExternaltest")
                    {
                        dvTGeneralTestResult=objTGeneralTestResult.GetAll(1);
                        if (dvTGeneralTestResult.Count > 0)
                        {
                            lblExtTcount.Text = "(" + dvTGeneralTestResult.Count.ToString() + ")";
                            dvTGeneralTestResult.Sort = DGSort;
                            this.dgGroupListExt.DataSource = dvTGeneralTestResult;
                            this.dgGroupListExt.DataBind();
                            this.dgGroupListExt.Visible = true;
                            this.lblErrMsg.Text = "";
                        }
                        else
                        {
                            this.dgGroupList.Visible = false;
                            lblRecordNo.Text = "Record not found.";
                            this.lblErrMsg.Text = "";
                        }
                    }
                    else
                    {
                        dvTGeneralTestResult = objTGeneralTestResult.GetAll(1);
                        if (dvTGeneralTestResult.Count > 0)
                        {
                            lblIntCount.Text = "(" + dvTGeneralTestResult.Count.ToString() + ")";
                            dvTGeneralTestResult.Sort = DGSort;
                            this.dgGroupList.DataSource = dvTGeneralTestResult;
                            this.dgGroupList.DataBind();
                            this.dgGroupList.Visible = true;
                            this.lblErrMsg.Text = "";
                        }
                        else
                        {
                            this.dgGroupList.Visible = false;
                            lblRecordNo.Text = "Record not found.";
                            this.lblErrMsg.Text = "";
                        }

                    }


                
                
            }
            else
            {
                this.lblErrMsg.Text = "Please select Section ID.";
                this.dgGroupList.Visible = false;
                lblRecordNo.Text = "";
            }
        }

        protected void dgGroupList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            //startIndex = e.NewPageIndex * MyDataGrid.PageSize;
            dgGroupList.CurrentPageIndex = e.NewPageIndex;
            FillDG();

        }

        protected void LinkButton3_Click(object sender, System.EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {

        }

        protected void dgGroupList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            /*// Create a new WebUIFacade.
            WebUIFacade uiFacade = new WebUIFacade();
    
            // This is gives a tool tip for each
            // of the columns to sort by.
            uiFacade.SetHeaderToolTip(e);
    
    
            // This sets a class for the link buttons in a grid.
            uiFacade.SetGridLinkButtonStyle(e);
    
            // Make the row change color when the mouse hovers over.
            // *** You must have a class called gridHover with a different background 
            // color in your StyleSheet.
            uiFacade.SetRowHover((DataGrid)sender, e);*/
        }
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            FillDG();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            RefreshForm();
            FillDG();
        }
        protected void dgGroupList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                if (e.Item.Cells[11].Text.Equals("G"))
                {
                    string sMSerialNos = "";
                    string sMSerialNoPrior = "";
                    int j = 0;
                    for (int i = e.Item.ItemIndex; i < dgGroupList.Items.Count; i++)
                    {
                        if (dgGroupList.Items[i].Cells[11].Text.Equals("G"))
                        {
                            if (j < 101)
                            {
                                if (sMSerialNoPrior != dgGroupList.Items[i].Cells[9].Text)
                                {
                                    sMSerialNos += dgGroupList.Items[i].Cells[9].Text;
                                    sMSerialNos += "|";
                                }
                                sMSerialNoPrior = dgGroupList.Items[i].Cells[9].Text;
                                j++;
                            }
                        }
                    }

                    Response.Write("<script language = 'javascript'>window.open('wfrmTestGE.aspx?id=" + e.Item.Cells[9].Text + "&ProcessID=" + e.Item.Cells[8].Text + "&MSerialNos=" + sMSerialNos + "&SectionID=" + ddlSection.SelectedValue + "&Psex=" + e.Item.Cells[3].Text + "&PAge=" + e.Item.Cells[13].Text + "&testid=" + e.Item.Cells[12].Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
                }
                else if (e.Item.Cells[11].Text.Equals("M"))
                {
                    string sDSerialNos = "";
                    string sDSerialNoPrior = "";
                    int j = 0;
                    for (int i = e.Item.ItemIndex; i < dgGroupList.Items.Count; i++)
                    {
                        if (dgGroupList.Items[i].Cells[11].Text.Equals("M"))
                        {
                            if (j < 101)
                            {
                                if (sDSerialNoPrior != dgGroupList.Items[i].Cells[10].Text)
                                {
                                    sDSerialNos += dgGroupList.Items[i].Cells[10].Text;
                                    sDSerialNos += "|";
                                }
                                sDSerialNoPrior = dgGroupList.Items[i].Cells[10].Text;
                                j++;
                            }
                        }
                    }

                    Response.Write("<script language = 'javascript'>window.open('wfrmTestMicro.aspx?id=" + e.Item.Cells[10].Text + "&ProcessID=" + e.Item.Cells[8].Text + "&DSerialNos=" + sDSerialNos + "&SectionID=" + ddlSection.SelectedValue + "&Psex = " + e.Item.Cells[3].Text + "&PAge = " + e.Item.Cells[4].Text + "&testid =" + e.Item.Cells[12].Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
                }
                else if (e.Item.Cells[11].Text.Equals("H"))
                {
                    string sMSerialNos = "";
                    string sMSerialNoPrior = "";
                    int j = 0;
                    for (int i = e.Item.ItemIndex; i < dgGroupList.Items.Count; i++)
                    {
                        if (dgGroupList.Items[i].Cells[11].Text.Equals("H"))
                        {
                            if (j < 101)
                            {
                                if (sMSerialNoPrior != dgGroupList.Items[i].Cells[9].Text)
                                {
                                    sMSerialNos += dgGroupList.Items[i].Cells[9].Text;
                                    sMSerialNos += "|";
                                }
                                sMSerialNoPrior = dgGroupList.Items[i].Cells[9].Text;
                                j++;
                            }
                        }
                    }

                    Response.Write("<script language = 'javascript'>window.open('wfrmTestHisto.aspx?id=" + e.Item.Cells[9].Text + "&ProcessID=" + e.Item.Cells[8].Text + "&MSerialNos=" + sMSerialNos + "&SectionID=" + ddlSection.SelectedValue + "&Psex = " + e.Item.Cells[3].Text + "&PAge = " + e.Item.Cells[4].Text + "&testid =" + e.Item.Cells[12].Text + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
                }
            }

           
        }
        protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>self.close();</script>");

        }

        protected void dgGroupList_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression == "LabID")
            {
                if (DGSort == "LabID ASC")
                {
                    DGSort = "LabID DESC";
                }
                else
                {
                    DGSort = "LabID ASC";
                }
            }
            if (e.SortExpression == "Test")
            {
                if (DGSort == "Test ASC")
                {
                    DGSort = "Test DESC";
                }
                else
                {
                    DGSort = "Test ASC";
                }
            }
            if (e.SortExpression == "namewotitle")
            {
                if (DGSort == "namewotitle ASC")
                {
                    DGSort = "namewotitle DESC";
                }
                else
                {
                    DGSort = "namewotitle ASC";
                }
            }
            if (e.SortExpression == "PSex")
            {
                if (DGSort == "PSex ASC")
                {
                    DGSort = "PSex DESC";
                }
                else
                {
                    DGSort = "PSex ASC";
                }
            }
            if (e.SortExpression == "PAge")
            {
                if (DGSort == "PAge ASC")
                {
                    DGSort = "PAge DESC";
                }
                else
                {
                    DGSort = "PAge ASC";
                }
            }
            if (e.SortExpression == "WardName")
            {
                if (DGSort == "WardName ASC")
                {
                    DGSort = "WardName DESC";
                }
                else
                {
                    DGSort = "WardName ASC";
                }
            }
            if (e.SortExpression == "Priority")
            {
                if (DGSort == "Priority ASC")
                {
                    DGSort = "Priority DESC";
                }
                else
                {
                    DGSort = "Priority ASC";
                }
            }
            if (e.SortExpression == "Origin")
            {
                if (DGSort == "Origin ASC")
                {
                    DGSort = "Origin DESC";
                }
                else
                {
                    DGSort = "Origin ASC";
                }
            }
            FillDG();
        }


        protected void lnkspecimen_Click(object sender, CommandEventArgs e)
        {
           // int index = Convert.ToInt32(e.CommandArgument);
           // lblErrMsg.Text = index.ToString();
        }

        protected void Reasonsave_Click(object sender, CommandEventArgs e)
        {
            //lblErrMsg.Text = "Reason save called";
            int index = Convert.ToInt32(e.CommandArgument);
            string ReasonID = ((DropDownList)dgGroupList.Items[index].Cells[16].FindControl("ddlReasons")).SelectedValue.ToString().Trim();
            if (!ReasonID.Trim().Equals("-1"))
            {
                //string labid = ((LinkButton)dgGroupList.Items[index].Cells[0].Controls[0]).Text.Trim();
                string DSerialNO = dgGroupList.Items[index].Cells[10].Text.Trim();
                clsBLGeneralTestResult objgeneraltest = new clsBLGeneralTestResult();
                objgeneraltest.DSerialNo = DSerialNO;
                objgeneraltest.NextProcessID = "0002";
                if (objgeneraltest.UpdateLs_TdTransaction(true))
                {
                    clsBlRepeatTest obj_Repeat = new clsBlRepeatTest();
                    obj_Repeat.LabID = ((LinkButton)dgGroupList.Items[index].Cells[0].Controls[0]).Text.Trim();
                    obj_Repeat.TestID = dgGroupList.Items[index].Cells[12].Text.Trim();
                    obj_Repeat.RepeatReasonID = ReasonID;
                    obj_Repeat.EnteredBy = Session["loginid"].ToString();
                    obj_Repeat.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_Repeat.ClientID = "0005";
                    // obj_Repeat.PRNumber = lblPRNo.Text;

                    if (obj_Repeat.insert())
                    {
                        lblErrMsg.Text = "Insertion Successful";
                        FillDG();
                    }

                }
            }
            else
            {
                lblErrMsg.Text = "Please Select Valid Reason";
            }
            //lblErrMsg.Text = labid;
        }

        protected void gvClose_CLick(object sender, EventArgs e)
        {
 
        }

        protected void dgGroupList_ItemCreated1(object sender, DataGridItemEventArgs e)
        {
            WebUIFacade uiFacade = new WebUIFacade();

            // This is gives a tool tip for each
            // of the columns to sort by.
             uiFacade.SetHeaderToolTip(e);


            // This sets a class for the link buttons in a grid.
            uiFacade.SetGridLinkButtonStyle(e);

            // Make the row change color when the mouse hovers over.
            // *** You must have a class called gridHover with a different background 
            // color in your StyleSheet.
            uiFacade.SetRowHover(this.dgGroupList, e);
        }
        private bool ApplyUserMatrix()
        {
            clsBLUMatrix UMatrix = new clsBLUMatrix();
            UMatrix.ApplicationID = "001";
            UMatrix.FormID = "132";
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
        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (TabContainer1.ActiveTab.ID == "tbExternaltest")
            {
                if (ApplyUserMatrix())
                {
                    FillDG();
                }
                else
                {
                    lblErrMsg.Text = "You are not allowed to view this Information. If you think you should be allowed then please contact Administrator.";
                    TabContainer1.ActiveTabIndex = 0;
                }
                //lblErrMsg.Text = "Hi i Am called";
            }
        }
}
}

