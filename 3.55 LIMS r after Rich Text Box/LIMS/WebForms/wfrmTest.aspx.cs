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
	/// Summary description for wfrmTest.
	/// </summary>
	public partial class wfrmTest : System.Web.UI.Page
	{
		protected static string sSection;

	
		private static string mode = "";
		private static string TestID = "";
		private static string DGSort = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
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

		}
		#endregion
	
		private void FillProcedureDDL()
		{
			clsBLTestProcedure objTestP = new clsBLTestProcedure();
			SComponents objComp = new SComponents();

			objTestP.Active = "Y";
			DataView dvTestP = objTestP.GetAll(2);

			objComp.FillDropDownList(this.ddlProcedure, dvTestP, "Procedure", "ProcedureID", true, false, false);
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
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID"); 
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				FillTestDDL();
				this.ddlTestGroup.Enabled = true;
			}
			else
			{
				this.ddlTestGroup.Enabled = false;
			}

			EnableForm(false);
			this.dgTestList.Visible = false;
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

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
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
			mode = "Insert";
		}

		private void FillDG()
		{
			clsBLTest objTTest = new clsBLTest();

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				objTTest.SectionID = this.ddlSection.SelectedItem.Value;
				objTTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;

				DataView dvTTest = objTTest.GetAll(1);

				if(dvTTest.Count > 0)
				{
					dvTTest.Sort = DGSort;
					this.dgTestList.DataSource = dvTTest;
					this.dgTestList.DataBind();
					this.dgTestList.Visible = true;
				}
				else
				{
					this.dgTestList.Visible = false;
				}
			}
			else
			{
				this.lblErrMsg.Text = "<br>Please select Test Group.<br><br>";
				this.dgTestList.Visible = false;
			}
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
			objTTest.AutomatedText = this.txtAutomatedText.Text;
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


			isSuccessful = objTTest.Insert();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objTTest.ErrorMessage + "<br><br>";
			}
			else
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
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
			objTTest.AutomatedText = this.txtAutomatedText.Text;
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
			
			bool isSuccessful = objTTest.Update();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = objTTest.ErrorMessage;
			}
			else
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				this.ibtnSave.ToolTip = "Save";
				RefreshForm();
				FillDG();
			}
		}

		private void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			
		}

		private void dgTestList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			FillForm(e.Item.ItemIndex);
		}

		private void FillForm(int index)
		{
			TestID = this.dgTestList.Items[index].Cells[0].Text.Replace("&nbsp;", "");
			this.chkActive.Checked = ((CheckBox)this.dgTestList.Items[index].Cells[3].FindControl("dgchkActive")).Checked;
			this.txtTest.Text = this.dgTestList.Items[index].Cells[1].Text.Replace("&nbsp;", "");
			this.txtAcronym.Text = this.dgTestList.Items[index].Cells[2].Text.Replace("&nbsp;", "");
			this.txtCharges.Text = this.dgTestList.Items[index].Cells[5].Text.Replace("&nbsp;", "");
			this.txtChargesUrgent.Text = this.dgTestList.Items[index].Cells[19].Text.Replace("&nbsp;", "");
			this.txtSpecimen.Text = this.dgTestList.Items[index].Cells[6].Text.Replace("&nbsp;", "");
			this.txtAutomatedText.Text = this.dgTestList.Items[index].Cells[7].Text.Replace("&nbsp;", "");
			this.txtClinicalUse.Text = this.dgTestList.Items[index].Cells[8].Text.Replace("&nbsp;", "");

			this.ddlProcedure.SelectedItem.Selected = false;
			this.ddlProcedure.Items.FindByValue(this.dgTestList.Items[index].Cells[9].Text).Selected = true;

			this.ddlGenLevel.SelectedItem.Selected = false;
			this.ddlGenLevel.Items.FindByValue(this.dgTestList.Items[index].Cells[10].Text).Selected= true;

			this.ddlGenOn.SelectedItem.Selected = false;
			this.ddlGenOn.Items.FindByValue(this.dgTestList.Items[index].Cells[11].Text).Selected = true;

			this.ddlFormat.SelectedItem.Selected = false;
			try
			{
				this.ddlFormat.Items.FindByValue(this.dgTestList.Items[index].Cells[15].Text).Selected = true;
			}
			catch{}
			
			this.ddlSpecimenType.SelectedItem.Selected = false;
			try
			{
				this.ddlSpecimenType.Items.FindByValue(this.dgTestList.Items[index].Cells[12].Text).Selected = true;
			}
			catch{}

			this.ddlSpecimenContainer.SelectedItem.Selected = false;
			try
			{
				this.ddlSpecimenContainer.Items.FindByValue(this.dgTestList.Items[index].Cells[13].Text).Selected = true;
			}
			catch{}

			this.chkSepReport.Checked = (this.dgTestList.Items[index].Cells[16].Text == "Y");
			this.chkReportGroup.Checked = (this.dgTestList.Items[index].Cells[17].Text == "Y");
			this.chkReportTest.Checked = (this.dgTestList.Items[index].Cells[18].Text == "Y");
			this.chkUrgent.Checked = (this.dgTestList.Items[index].Cells[20].Text == "Y");
            this.chkSummary.Checked = (this.dgTestList.Items[index].Cells[21].Text == "Y");
            this.txtReorder.Text = this.dgTestList.Items[index].Cells[22].Text.Replace("&nbsp;", "");

			this.ibtnSave.ToolTip = "Update";
			mode = "Update";
		}

		private void dgTestList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			DGSort = e.SortExpression;
			FillDG();
		}

		private void dgTestList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.lblErrMsg.Text = "";
			this.dgTestList.CurrentPageIndex = e.NewPageIndex;
			FillDG();
		}

		private void lbtnPrint_Click(object sender, System.EventArgs e)
		{
			/*LIMS.reports.GeneralReports.mFilterString = "";
			LIMS.reports.GeneralReports.mFromDate = "";
			LIMS.reports.GeneralReports.mToDate = "";
			LIMS.reports.GeneralReports.PdfSetting = null;
			LIMS.reports.GeneralReports.ReportReference = "LMS-004-01";

			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','resizable')</script>");*/
		}

		private void dgTestList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{				
				clsBLTest objTTest = new clsBLTest();

				objTTest.TestID = e.Item.Cells[0].Text;	
				objTTest.Active = "D";			
				bool isSuccessful = objTTest.Delete();

				if(!isSuccessful)
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

		private void dgTestList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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

		private void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblErrMsg.Text = "";
			if(mode.Equals("Insert"))
			{
				Insert();
			}
			else
			{
				Update();
			}
		}

		private void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
			
			mode = "Insert";
		}

		private void ibtnTestAttribute_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language = 'javascript'>window.open('wfrmTestAttribute.aspx','','fullscreen')</script>");						
		}

		private void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");			
		}
        protected void ibtnSave_Click1(object sender, ImageClickEventArgs e)
        {

        }
}
}