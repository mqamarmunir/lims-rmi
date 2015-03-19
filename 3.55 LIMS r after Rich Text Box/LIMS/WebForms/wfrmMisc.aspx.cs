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
	/// Summary description for wfrmMisc.
	/// </summary>
	public partial class wfrmMisc : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				/*if (!Session["loginid"].Equals("000001"))										 
				{
					Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
				} 
				else if (!Session["loginid"].Equals("000011"))					
				{
					Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
				}*/

				if(!IsPostBack)
				{
					this.lblErrMsg.Text = "";
					this.lblRecordNo.Text = "";					
					FillSectionDDL();
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
		}

		private void FillDG()
		{
			this.lblErrMsg.Text = "";
			this.lblRecordNo.Text = "";

			clsBLMisc objMisc = new clsBLMisc();
			
			# region "Parameters Conditions"			

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{ 
				objMisc.SectionID = this.ddlSection.SelectedItem.Value;
			}

			if(!this.txtPLNo.Text.Equals(""))
			{
				objMisc.PLNo = this.txtPLNo.Text.Trim();
			}

			try
			{
				if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
				{ 
					objMisc.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
				}
			}	
			catch{}
			
			try
			{
				if(!this.ddlTest.SelectedItem.Value.Equals("-1"))
				{ 
					objMisc.TestID = this.ddlTest.SelectedItem.Value;
				}
			}
			catch{}

			if(!this.txtPatientName.Text.Equals(""))
			{ 
				objMisc.PatientName = this.txtPatientName.Text;
			}
			
			if(!this.ddlSex.SelectedItem.Value.Equals("-1"))
			{ 
				objMisc.Sex = this.ddlSex.SelectedItem.Value;
			}

			if(this.txtMSerialNoFrom.Text.Trim() != "")
			{ 
				objMisc.MSerialNoFrom = this.txtMSerialNoFrom.Text;
			}
			
			if(this.txtMSerialNoTo.Text.Trim() != "")
			{ 
				objMisc.MSerialNoTo = this.txtMSerialNoTo.Text;
			}

			objMisc.Status = this.rbtnStatus.SelectedItem.Value.ToString();
						
			# endregion

			DataView dvMisc = objMisc.GetAll(1);

			if(dvMisc.Count > 0)
			{
				lblRecordNo.Text = dvMisc.Count.ToString()+" Records found";
				this.dgResultDis.DataSource = dvMisc;
				this.dgResultDis.DataBind();
				this.dgResultDis.Visible = true;
			}
			else
			{
				this.dgResultDis.Visible = false;
				lblRecordNo.Text = "Record not found.";
			}
		}

		private void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
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

		protected void lbtnRefresh_Click(object sender, System.EventArgs e)
		{
			FillDG();
		}

		protected void lbtnAll_Click(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();
		}

		private void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
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

		protected void lbtnPrint_Click(object sender, System.EventArgs e)
		{
			/*string selectionFormula = "";
			string[] aryToArchive = new string[this.dgResultDis.Items.Count+1];
			int counter = 0;

			foreach(DataGridItem dgItem in this.dgResultDis.Items)
			{
				if(((CheckBox)dgItem.Cells[0].FindControl("dgchkPrint")).Checked == true)
				{
					selectionFormula += "" + dgItem.Cells[10].Text + ",";				

					if(this.rbtnlArchiver.SelectedItem.Value.Equals("N") && this.chkArchived.Checked == true)
					{
						aryToArchive[counter] = dgItem.Cells[10].Text;
						counter++;
					}
				}
			}

			LIMS.reports.GeneralReports.mFilterString = "";

			if(!selectionFormula.Equals(""))
			{
				selectionFormula = selectionFormula.Remove(selectionFormula.LastIndexOf(","), 1);
				LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT1.DSerialNo} in [" + selectionFormula + "]";
			}

			LIMS.reports.GeneralReports.PdfSetting = null;
			LIMS.reports.GeneralReports.ReportReference = this.ddlReportType.SelectedItem.Value;
			LIMS.reports.GeneralReports.mFromDate = "";
			LIMS.reports.GeneralReports.mToDate = "";

			//Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','resizable')</script>");

			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-01','_blank','resizable')</script>");		

			clsBLDTransaction objDTrans = new clsBLDTransaction();

			if(this.rbtnlArchiver.SelectedItem.Value.Equals("N"))
			{
				objDTrans.UpdateToArchived(aryToArchive);
				FillDG();
			}*/
		}

		protected void rbtnlArchiver_SelectedIndexChanged(object sender, System.EventArgs e)
		{			
			FillDG();
		}

		private void dgResultDis_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Details"))
			{
				Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno=" + e.Item.Cells[0].Text + "','','channelmode')</script>"); 			
			}
			else if(e.CommandName.Equals("RecPrint"))
			{
				LIMS.reports.wfrmReceipt.mFilterString = "{LS_VRECEPTIONREPORT.MSERIALNO} = " + e.Item.Cells[0].Text;
				LIMS.reports.wfrmReceipt.ReportReference = "LMS-003-01";
				Response.Write("<script language = 'javascript'>window.open('../reports/wfrmReceipt.aspx?reportID=001','_blank','resizable')</script>");
			}
			else if(e.CommandName.Equals("Cancel"))
			{				
				clsBLMTransaction objTMTransaction = new clsBLMTransaction();					
					
				objTMTransaction.MSerialNo = e.Item.Cells[0].Text;				
				objTMTransaction.MStatus = "C";				
				bool isSuccessful = objTMTransaction.UpdateStatus();
				if(!isSuccessful)
				{ this.lblErrMsg.Text = objTMTransaction.ErrorMessage; }
				else
				{FillDG();}							
			}
			else if(e.CommandName.Equals("Edit"))
			{
				Response.Write("<script language = 'javascript'>window.open('wfrmPatientEdit.aspx?sMSerialNo=" + e.Item.Cells[0].Text + "','','channelmode')</script>"); 			
			}
		}

		private void dgResultDis_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//if (e.Item.Cells[9].Text.Equals("C"))	
			{				
//				e.Item.Cells[8].Text = e.Item.Cells[0].Text;	
			
			}
		}
	}
}