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
using HMIS.LIMS;
using System.Globalization;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmSpecimenCollection.
	/// </summary>
    public partial class wfrmSpecimenCollection : System.Web.UI.Page
    {
        private static string DGSort = "Priority Desc";
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                {
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
                    clsBLPreferenceSettings obj_Preference = new clsBLPreferenceSettings();
                    DataView dv_preferences = obj_Preference.GetAll(1);

                    hdcollTimeIn.Value = dv_preferences[0]["COLLTIME_INDOOR"].ToString();
                    hdcollTimeOut.Value = dv_preferences[0]["COLLTIME_OUTDOOR"].ToString();
                    dv_preferences.Dispose();
                    FillSpecimenDDL();
                    FillDDL();
                    this.txtDF.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    this.txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    FillDG();
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
           // this.dgGroupList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGroupList_ItemCreated);

        }
        #endregion

        private void FillDDL()
        {
            clsBLSection objSection = new clsBLSection();
            SComponents objComp = new SComponents();

            objSection.Active = "Y";
            DataView dvSection = objSection.GetAll(1);
            objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID");
        }

        private void FillSpecimenDDL()
        {
            clsBLSpecimen objSpecimen = new clsBLSpecimen();
            SComponents objComp = new SComponents();
            DataView dvSpecimen = objSpecimen.GetAll(1);
            objComp.FillDropDownList(this.ddlSpecimenType, dvSpecimen, "SpecimenType", "SpecimenType");
        }

        private void RefreshForm()
        {
            this.ddlSection.SelectedItem.Selected = false;
            this.ddlSection.Items.FindByValue("-1").Selected = true;
            this.txtPatientName.Text = "";
            this.ddlSex.SelectedItem.Selected = false;
            this.ddlSex.Items.FindByValue("-1").Selected = true;
            this.txtMSerialNoFrom.Text = "";
            this.txtMSerialNoTo.Text = "";
            this.ddlSpecimenType.SelectedItem.Selected = false;
            this.ddlSpecimenType.Items.FindByValue("-1").Selected = true;
            try
            {
                this.ddlTestGroup.SelectedItem.Selected = false;
                this.ddlTestGroup.Items.FindByValue("-1").Selected = true;
            }
            catch
            { }
        }
        private void FillDG()
        {
            this.lblErrMsg.Text = "";

            clsBLSpecimenColletion objTSpecimenColletion = new clsBLSpecimenColletion();
            # region "Parameters Conditions"
            if (!this.ddlSection.SelectedItem.Value.Equals("-1"))
            { objTSpecimenColletion.SectionID = this.ddlSection.SelectedItem.Value; }
            try
            {
                if (!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
                { objTSpecimenColletion.TestGroupID = this.ddlTestGroup.SelectedItem.Value; }
            }
            catch { }


            if (!this.txtPatientName.Text.Equals(""))
            { objTSpecimenColletion.PatientName = this.txtPatientName.Text; }
            if (!this.ddlSex.SelectedItem.Value.Equals("-1"))
            { objTSpecimenColletion.Sex = this.ddlSex.SelectedItem.Value; }

            if (this.txtMSerialNoFrom.Text.Trim() != "")
            { objTSpecimenColletion.LabIDFrom = this.txtMSerialNoFrom.Text; }
            if (this.txtMSerialNoTo.Text.Trim() != "")
            { objTSpecimenColletion.LabIDTo = this.txtMSerialNoTo.Text; }

            if (!this.txtDF.Text.Equals(""))
            {
                objTSpecimenColletion.EnteredateF = this.txtDF.Text;
            }

            if (!this.txtDT.Text.Equals(""))
            {
                objTSpecimenColletion.EnteredateT = DateTime.Parse(this.txtDT.Text.Trim(),new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
            }

            if (!this.ddlSpecimenType.SelectedItem.Value.Equals("-1"))
            { objTSpecimenColletion.SpecimenType = this.ddlSpecimenType.SelectedItem.Value; }

            # endregion

            DataView dvTSpecimenColletion = objTSpecimenColletion.GetAll(1);
            DataView dv_internla = dvTSpecimenColletion;
            DataView DC_EXTERNAL = dvTSpecimenColletion;
            dv_internla.RowFilter = "externaltest=0";
         
            if (dv_internla.Count > 0)
            {
                lblicount.Text = "(" + dv_internla.Count.ToString() + ")";
                dvTSpecimenColletion.Sort = DGSort;
                this.dgGroupList.DataSource = dv_internla;
                this.dgGroupList.DataBind();
                this.dgGroupList.Visible = true;
            }
            else
            {
                dgGroupList.Visible = false;
               // lblRecordNo.Text = "Record not found.";
            }

            DC_EXTERNAL.RowFilter = "externaltest > 0";
            if (DC_EXTERNAL.Count > 0)
            {
                lblexcount.Text="("+DC_EXTERNAL.Count.ToString()+")";
                //dvTSpecimenColletionExt.Sort = DGSort;
                this.dgexternal.DataSource = DC_EXTERNAL;
                this.dgexternal.DataBind();
            }
            else
            {
                lblexcount.Text = "";
                this.dgexternal.Visible = true;
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

        private void dgGroupList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

        protected void ibtnToday_Click(object sender, ImageClickEventArgs e)
        {
            this.txtDF.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillDG();
        }
        protected void ibtnLast2Days_Click(object sender, ImageClickEventArgs e)
        {
            txtDF.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            txtDT.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            FillDG();
        }
        protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillDG();
        }
        protected void ibtnAll_Click(object sender, ImageClickEventArgs e)
        {
            RefreshForm();
            FillDG();
        }
        protected void ibtnIndoorReport_Click(object sender, ImageClickEventArgs e)
        {
            string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
            string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";
            string sFilterString = "";
            sFilterString = "{LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;

            sFilterString = sFilterString + " And {LS_TMTRANSACTION.IOP} = 'I' and {LS_TMTRANSACTION.MSTATUS} <> 'C' and {LS_TDTRANSACTION.PROCESSID} = '0002' ";//and {LS_TDTRANSACTION.SECTIONID} <> '013'

            //sFilterString =  sFilterString +GetSelectedDepartment("{LS_TDTRANSACTION.SECTIONID}");			
            LIMS.reports.GeneralReports.PdfSetting = null;
            reports.GeneralReports.mFilterString = sFilterString;
            reports.GeneralReports.ReportReference = "LMS-002-03";
            Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
        }
        protected void dgGroupList_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Detail"))
            {
                Response.Write("<script language = 'javascript'>window.open('wfrmSpecimenCollectionDetail.aspx?mserialno=" + e.Item.Cells[2].Text + "&labid=" + e.Item.Cells[3].Text + "&Specimen=" + ddlSpecimenType.SelectedValue.ToString() + "&IOP="+e.Item.Cells[10].Text.Trim()+"','channelmode')</script>");//,'','channelmode'
            }
            if (e.CommandName == "Delete")
            {
                string labId = e.Item.Cells[3].Text;
                string PatientName = e.Item.Cells[4].Text;
                Response.Write("<script language = 'javascript'>window.open('wfrmTestCancellationReasons.aspx?LabID=" + labId + "&Name=" + PatientName + "','channelmode')</script>");

            }
        }
        protected void dgGroupList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            double collTimeIndoor = Convert.ToInt32(hdcollTimeIn.Value.ToString());
            double collTimeOutdoor = Convert.ToInt32(hdcollTimeOut.Value.ToString());
            //string entrydateTime = e.Item.Cells[11].Text;
            //string _patienttype = e.Item.Cells[10].Text;
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string entrydateTime = e.Item.Cells[11].Text;
                string _patienttype = e.Item.Cells[10].Text;
                if (_patienttype == "I")
                {
                    double minutes = (System.DateTime.Now - DateTime.Parse(entrydateTime, new System.Globalization.CultureInfo("en-GB", false))).TotalMinutes;
                    if (minutes > collTimeIndoor)
                    {
                        e.Item.BackColor = Color.BurlyWood;
                    }
                }
                else if (_patienttype == "O")
                {
                    double minutes = (System.DateTime.Now - DateTime.Parse(entrydateTime, new System.Globalization.CultureInfo("en-GB", false))).TotalMinutes;
                    if (minutes > collTimeOutdoor)
                    {
                        e.Item.BackColor = Color.Cyan;
                    }
 
                }

               
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _priority = DataBinder.Eval(e.Item.DataItem, "Priority").ToString();

                if (_priority == "Urg" || _priority == "U")
                {
                    e.Item.ForeColor = Color.Red;
                }
                else if (_priority == "VIP" || _priority == "V")
                {
                    e.Item.ForeColor = Color.DarkRed;
                }
            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string labId = e.Item.Cells[3].Text;
                clsBlRepeatTest obj_chkReapeat = new clsBlRepeatTest();
                obj_chkReapeat.LabID = labId;
                DataView dv_chkRepeat = obj_chkReapeat.GetAll(2);
                if (dv_chkRepeat.Count > 0)
                {
                    e.Item.BackColor = Color.Bisque;
                }

            }
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[10].Text == "I")
                {
                    e.Item.Cells[12].FindControl("lnkDelete").Visible = false;
                }
                else
                {
                    e.Item.Cells[12].FindControl("lnkDelete").Visible = false;
                }

                if (Convert.ToInt16(e.Item.Cells[13].Text)>0)//Checking whether any comment saved against this labid
                {
                    e.Item.BackColor = System.Drawing.Color.OliveDrab;
                }
                if (Convert.ToInt16(e.Item.Cells[14].Text) > 0)//Checking whether test is external
                {
                    e.Item.BackColor = System.Drawing.Color.SeaShell;
                }

            }
            
        }

        protected void dgGroupList_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
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

            FillDG();
        }
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>self.close();</script>");
        }
}
}