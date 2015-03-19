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
	/// Summary description for wfrmResultCallBack.
	/// </summary>
	public partial class wfrmResultCallBack : System.Web.UI.Page
	{
        private static string DGSort = "LabID ASC";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "108";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					this.lblErrMsg.Text = "";
					this.lblRecordNo.Text = "";
					FillReportDDL();
					FillSectionDDL();
					FillWardDDL();
					this.txtDF.Text = DateTime.Now.ToString("dd/MM/yyyy");
					this.txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
					//FillDG();
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
			this.dgResultDis.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgResultDis_ItemCreated);
			this.dgResultDis.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResultDis_ItemCommand);

		}
		#endregion

		private void FillWardDDL()
		{
			// getting Ward list
			SComponents objComp = new SComponents();
			clsBLWard objWard = new clsBLWard();
			objWard.Active = "Y";
			DataView dvWard = objWard.GetAll(1);
			objComp.FillDropDownList(this.ddlWard, dvWard, "WardName", "WardID");
		}

		private void FillReportDDL()
		{
			clsBLReport objReport = new clsBLReport();
			SComponents objComp = new SComponents();

			DataView dvReport = objReport.GetTestReportType();
			objComp.FillDropDownList(this.ddlReportType, dvReport, "ReportDesc", "ReportNo", true, false, false);
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID"); 
		}

		private void RefreshForm()
		{		
			this.ddlSection.SelectedItem.Selected = false;
			this.ddlSection.Items.FindByValue("-1").Selected = true;

			this.txtPatientName.Text = "";

			try{	this.ddlTestGroup.Items.Clear();	}
			catch{}
			this.ddlTestGroup.Enabled = false;

			this.ddlSex.SelectedItem.Selected = false;
			this.ddlSex.Items.FindByValue("-1").Selected = true;

			try{	this.ddlTest.Items.Clear();	}
			catch{}
			this.ddlTest.Enabled = false;

			this.txtMSerialNoFrom.Text = "";
			this.txtMSerialNoTo.Text = "";

			try{	this.ddlWard.Items.Clear();	}
			catch{}
			this.ddlWard.Enabled = false;

			this.rbtnPatientType.SelectedIndex = 0;
		}

		private void FillDG()
		{			
			this.lblErrMsg.Text = "";
			this.lblRecordNo.Text = "";

			clsBLSpecimenColletion objSpecimenCol = new clsBLSpecimenColletion();
			
			# region "Parameters Conditions"

			if(!this.txtDF.Text.Equals(""))
			{ 
				objSpecimenCol.EnteredateF = this.txtDF.Text;
			}

			if(!this.txtDT.Text.Equals(""))
			{ 
				objSpecimenCol.EnteredateT = this.txtDT.Text;
			}

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{ 
				objSpecimenCol.SectionID = this.ddlSection.SelectedItem.Value;
			}

			if(!this.txtPLNo.Text.Equals(""))
			{
				objSpecimenCol.PLNo = this.txtPLNo.Text.Trim();
			}

			try
			{
				if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
				}
			}	
			catch{}
			
			try
			{
				if(!this.ddlTest.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.TestID = this.ddlTest.SelectedItem.Value;
				}
			}
			catch{}

			if(!this.txtPatientName.Text.Equals(""))
			{ 
				objSpecimenCol.PatientName = this.txtPatientName.Text;
			}
			
			if(!this.ddlSex.SelectedItem.Value.Equals("-1"))
			{ 
				objSpecimenCol.Sex = this.ddlSex.SelectedItem.Value;
			}

			if(this.txtMSerialNoFrom.Text.Trim() != "")
			{ 
				objSpecimenCol.LabIDFrom = this.txtMSerialNoFrom.Text;
			}
			
			if(this.txtMSerialNoTo.Text.Trim() != "")
			{ 
				objSpecimenCol.LabIDTo = this.txtMSerialNoTo.Text;
			}
			
			try
			{
				if(!this.ddlWard.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.WardID = this.ddlWard.SelectedItem.Value;
				}
			}
			catch{}

			if (!this.rbtnPatientType.SelectedItem.Value.Equals("A")) 
			{
				objSpecimenCol.PatientType = this.rbtnPatientType.SelectedItem.Value;	
			}

			if (!this.rbtnIO.SelectedItem.Value.Equals("A")) 
			{
				objSpecimenCol.IOPatient = this.rbtnIO.SelectedItem.Value;	
			}			

			# endregion

			DataView dvSpecimenCol = objSpecimenCol.GetAll(3);

			if(dvSpecimenCol.Count > 0)
			{
				lblRecordNo.Text = "Record fetched : " + dvSpecimenCol.Count.ToString();
                dvSpecimenCol.Sort = DGSort;
				this.dgResultDis.DataSource = dvSpecimenCol;
				this.dgResultDis.DataBind();
				this.dgResultDis.Visible = true;
			}
			else
			{
				this.dgResultDis.Visible = false;
				lblRecordNo.Text = "Record not found.";
			}
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				FillTestGroupDDL();
				this.ddlTestGroup.Enabled = true;

				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
			}
			else
			{
				try{	this.ddlTestGroup.Items.Clear();	}
				catch{}
				this.ddlTestGroup.Enabled = false;
				
				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
			}
		}

		private void FillTestGroupDDL()
		{
			clsBLTestGroup objTestGroup = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTestGroup.Active = "Y";
			objTestGroup.SectionID = ddlSection.SelectedValue;
			DataView dvTestGroup = objTestGroup.GetAll(3);
			objComp.FillDropDownList(this.ddlTestGroup, dvTestGroup, "TestGroup", "TestGroupID");
		}

		private void lbtnAll_Click(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();
		}

		protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				FillTestDDL();
				this.ddlTest.Enabled = true;
			}
			else
			{
				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
			}
		}

		private void FillTestDDL()
		{
			clsBLTest objTest = new clsBLTest();
			SComponents objComp = new SComponents();

			objTest.SectionID = this.ddlSection.SelectedItem.Value;
			objTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTest.Active = "Y";
			DataView dvTest = objTest.GetAll(2);
			objComp.FillDropDownList(this.ddlTest, dvTest, "Test", "TestID");
		}
		
		private void dgResultDis_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("ClearR"))
			{
				clsBLTestResultM objTestResultM = new clsBLTestResultM();
			
			
				objTestResultM.DSerialNo = e.Item.Cells[10].Text;				
				objTestResultM.ProcessID = e.Item.Cells[15].Text;
                objTestResultM.Labid = e.Item.Cells[2].Text.Trim();
				bool isSuccessful = objTestResultM.Delete();

				if(!isSuccessful)
				{
					this.lblRecordNo.Text = "<br>" + objTestResultM.ErrorMessage + "<br><br>";
				}
				else
				{
					this.lblRecordNo.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
					FillDG();
				}				
			}
			else if(e.CommandName.Equals("SenttoResultEntry"))
			{
				clsBLDTransaction objTDTransaction = new clsBLDTransaction();
			
			
				objTDTransaction.DSerialNo = e.Item.Cells[10].Text;
				objTDTransaction.ProcessID = "0004";	
				bool isSuccessful = objTDTransaction.UpdateReLocation();

				if(!isSuccessful)
				{
					this.lblRecordNo.Text = "<br>" + objTDTransaction.ErrorMessage + "<br><br>";
				}
				else
				{
					this.lblRecordNo.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
					FillDG();
				}			
			}
			else if(e.CommandName.Equals("SenttoVerification"))
			{
				clsBLDTransaction objTDTransaction = new clsBLDTransaction();
			
			
				objTDTransaction.DSerialNo = e.Item.Cells[10].Text;
				objTDTransaction.ProcessID = "0005";	
				bool isSuccessful = objTDTransaction.UpdateReLocation();

				if(!isSuccessful)
				{
					this.lblRecordNo.Text = "<br>" + objTDTransaction.ErrorMessage + "<br><br>";
				}
				else
				{
					this.lblRecordNo.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
					FillDG();
				}			
			}
			else if(e.CommandName.Equals("EPName"))
			{		
				Response.Write("<script language = 'javascript'>window.open('wfrmPatientEdit.aspx?sMSerialNo=" + e.Item.Cells[17].Text + "','','channelmode')</script>"); 			
				FillDG();							
			}
		}

		private void dgResultDis_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
        protected void ibtnRefresh_Click(object sender, ImageClickEventArgs e)
        {
            FillDG();
        }

        protected void dgResultDis_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression == "LabID")
            {
                if (DGSort == "LabID ASC")
                {
                    DGSort = "LabID DESC";
                }
                else
                    DGSort = "LabID ASC";

            }
            if (e.SortExpression == "Test")
            {
                if (DGSort == "Test ASC")
                {
                    DGSort = "Test DESC";
                }
                else
                    DGSort = "Test ASC";

            }
            if (e.SortExpression == "PatientName")
            {
                if (DGSort == "PatientName ASC")
                {
                    DGSort = "PatientName DESC";
                }
                else
                    DGSort = "PatientName ASC";

            }
            if (e.SortExpression == "Psex")
            {
                if (DGSort == "Psex ASC")
                {
                    DGSort = "Psex DESC";
                }
                else
                    DGSort = "Psex ASC";

            }
            if (e.SortExpression == "PAge")
            {
                if (DGSort == "PAge ASC")
                {
                    DGSort = "PAge DESC";
                }
                else
                    DGSort = "PAge ASC";

            }
            if (e.SortExpression == "EnteredDate")
            {
                if (DGSort == "EnteredDate ASC")
                {
                    DGSort = "EnteredDate DESC";
                }
                else
                    DGSort = "EnteredDate ASC";


            }
            if (e.SortExpression == "WardName")
            {
                if (DGSort == "WardName ASC")
                {
                    DGSort = "WardName DESC";
                }
                else
                    DGSort = "WardName ASC";

            }

            if (e.SortExpression == "Location")
            {
                if (DGSort == "Location ASC")
                {
                    DGSort = "Location DESC";
                }
                else
                    DGSort = "Location ASC";

            }
            FillDG();
        }

        protected void dgResultDis_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string _priority = DataBinder.Eval(e.Item.DataItem, "Priority").ToString();

                if (_priority == "Urg" || _priority == "U")
                {
                    e.Item.ForeColor = Color.IndianRed;
                }
            }
            
        }
}
}