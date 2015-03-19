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
	/// Summary description for wfrmOtherDeptActivity.
	/// </summary>
	public partial class wfrmOtherDeptActivity : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{				
					FillDDL();
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
			this.dgGroupList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_ItemCommand);

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

		private void RefreshForm()
		{		
			this.ddlSection.SelectedItem.Selected = false;
			this.ddlSection.Items.FindByValue("-1").Selected = true;			
			this.txtPatientName.Text = "";
			this.ddlSex.SelectedItem.Selected = false;
			this.ddlSex.Items.FindByValue("-1").Selected = true;			
			this.txtMSerialNoFrom.Text = "";
			this.txtMSerialNoTo.Text = "";
			try
			{
				this.ddlTestGroup.SelectedItem.Selected = false;
				this.ddlTestGroup.Items.FindByValue("-1").Selected = true;			
			}
			catch
			{}
		}
		private void FillDG()
		{
			this.lblErrMsg.Text = "";

			clsBLUSXRays objTUSXRays = new clsBLUSXRays();			
			# region "Parameters Conditions"
			if (!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{ objTUSXRays.SectionID = this.ddlSection.SelectedItem.Value;	}
			try
			{
				if (!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
				{ objTUSXRays.TestGroupID = this.ddlTestGroup.SelectedItem.Value;	}	
			}	
			catch{}
			

			if (!this.txtPatientName.Text.Equals(""))
			{ objTUSXRays.PatientName = this.txtPatientName.Text;}
			if (!this.ddlSex.SelectedItem.Value.Equals("-1"))
			{ objTUSXRays.Sex = this.ddlSex.SelectedItem.Value;}

			if (this.txtMSerialNoFrom.Text.Trim() != "")
			{ objTUSXRays.MSerialNoFrom = this.txtMSerialNoFrom.Text;}
			if (this.txtMSerialNoTo.Text.Trim() != "")
			{ objTUSXRays.MSerialNoTo = this.txtMSerialNoTo.Text;}
			# endregion

			DataView dvTUSXRays = objTUSXRays.GetAll(1);

			if(dvTUSXRays.Count > 0)
			{
				lblRecordNo.Text = "Record fetched : "+dvTUSXRays.Count.ToString();
				this.dgGroupList.DataSource = dvTUSXRays;
				this.dgGroupList.DataBind();
				this.dgGroupList.Visible = true;
			}
			else
			{
				this.dgGroupList.Visible = false;
				lblRecordNo.Text = "Record not found.";
			}
		}

		private void dgGroupList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Done"))
			{
				clsBLUSXRays objTUSXRays = new clsBLUSXRays();					
					
				objTUSXRays.MSerialNo = e.Item.Cells[2].Text;				
				objTUSXRays.LastUpdatedBy = Session["loginid"].ToString();
				bool isSuccessful = objTUSXRays.Update();
				if(!isSuccessful)
				{ this.lblErrMsg.Text = objTUSXRays.ErrorMessage; }
				else 
				{
					this.lblErrMsg.Text = "<font color='Green'>Record has been updated successfully.</font>"; }					
					
			}
			FillDG();	
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

		protected void Refreash_Click(object sender, System.EventArgs e)
		{
			FillDG();	
		}

		protected void LinkButton1_Click(object sender, System.EventArgs e)
		{			
			RefreshForm();
			FillDG();	
		}
	}
}