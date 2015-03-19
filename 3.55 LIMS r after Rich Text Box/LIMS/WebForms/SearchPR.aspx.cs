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
	/// Summary description for SearchPR.
	/// </summary>
	public partial class SearchPR : System.Web.UI.Page
	{

		protected static string focusElement = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			//		if(User.Identity.IsAuthenticated)
			//		{
			if(!IsPostBack)
			{
				this.lblErrMsg.Text = "";
				focusElement = this.ddlOrganization.ID.ToString();

				FillOrganizationDDL();
			}
			//		}
			//		else
			//		{
			//			Response.Redirect("<script language='javascript'>parent.location.href = '../../login.aspx';</script>");
			//		}
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
			this.dgSearch.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSearch_EditCommand);

		}
		#endregion

		private void FillOrganizationDDL()
		{
			clsBLOrganization objOrg = new clsBLOrganization();
			SComponents objComp = new SComponents();

			objOrg.Active = "Y";
			DataView dvOrg = objOrg.GetAll(1);
			objComp.FillDropDownList(this.ddlOrganization, dvOrg, "Name", "OrgID", false);
		}
		
		private void dgSearch_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			Response.Write("<script language='javascript'>window.opener.LoadPatient('" + e.Item.Cells[5].Text + "');self.close();</script>");
		}

		protected void btnSearch_Click(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			clsBLSearchPR objSearchPR = new clsBLSearchPR();

			objSearchPR.OrgID = this.ddlOrganization.SelectedItem.Value.Equals("-1") ? "" : this.ddlOrganization.SelectedItem.Value;

			try
			{
				objSearchPR.FactoryID = this.ddlFactory.SelectedItem.Value.Equals("-1") ? "" : this.ddlFactory.SelectedItem.Value;
			}
			catch(Exception e2)
			{
				objSearchPR.FactoryID = "";
			}

			try
			{
				objSearchPR.SectionID = this.ddlSection.SelectedItem.Value.Equals("-1") ? "" : this.ddlSection.SelectedItem.Value;
			}
			catch(Exception e2)
			{
				objSearchPR.SectionID = "";
			}

			try
			{
				objSearchPR.RankID = this.ddlRank.SelectedItem.Value.Equals("-1") ? "" : this.ddlRank.SelectedItem.Value;
			}
			catch(Exception e2)
			{
				objSearchPR.RankID = "";
			}

			objSearchPR.Sex = this.ddlSex.SelectedItem.Value.Equals("-1") ? "" : this.ddlSex.SelectedItem.Value;
			objSearchPR.BloodGroup = this.ddlBloodGroup.SelectedItem.Value.Equals("-1") ? "" : this.ddlBloodGroup.SelectedItem.Value;
			objSearchPR.Address = this.txtAddress.Text;
			objSearchPR.PLNo = this.txtPlNo.Text;
			objSearchPR.Name = this.txtName.Text;
			objSearchPR.FHName = this.txtFHName.Text;
			objSearchPR.PatientID = this.txtPatientID.Text;
			objSearchPR.NIC = this.txtNIC.Text;
			objSearchPR.PhoneNo = this.txtPhoneNo.Text;

			DataView dvPatient = objSearchPR.GetAll(1);

			if(dvPatient.Count > 0)
			{
				this.dgSearch.DataSource = dvPatient;
				this.dgSearch.DataBind();
				this.lblErrMsg.Text = "<br><font color='Green'>Total records found: " + dvPatient.Count.ToString() + ".</font><br><br>";
				this.dgSearch.Visible = true;
			}
			else
			{
				this.lblErrMsg.Text = "<br>No record found.<br><br>";
				this.dgSearch.Visible = false;
			}
		}

		protected void ddlOrganization_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!this.ddlOrganization.SelectedItem.Value.Equals("-1"))
			{
				FillFactoryDDL();
				FillRankDDL();
			}
			else
			{
				try{	this.ddlFactory.Items.Clear();	}
				catch{}

				try{	this.ddlRank.Items.Clear();	}
				catch{}
			}

			try{	this.ddlSection.Items.Clear();	}
			catch{}
		}

		private void FillFactoryDDL()
		{
			clsBLFactory objFactory = new clsBLFactory();
			SComponents objComp = new SComponents();

			objFactory.Active = "Y";
			objFactory.OrgID = this.ddlOrganization.SelectedItem.Value;
			objComp.FillDropDownList(this.ddlFactory, objFactory.GetAll(1), "FactoryName", "FactoryID");
		}

		private void FillRankDDL()
		{
			clsBLRank objRank = new clsBLRank();
			SComponents objComp = new SComponents();

			objRank.Active = "Y";
			objRank.OrgID = this.ddlOrganization.SelectedItem.Value;
			objComp.FillDropDownList(this.ddlRank, objRank.GetAll(1), "RankName", "RankID");
		}

		protected void ddlFactory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(!this.ddlFactory.SelectedItem.Value.Equals("-1"))
			{
				FillSectionDDL();
			}
			else
			{
				try{	this.ddlSection.Items.Clear();	}
				catch{}
			}
		}

		private void FillSectionDDL()
		{
			clsBLFacSection objSection = new clsBLFacSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			objSection.FactoryID = this.ddlFactory.SelectedItem.Value;
			objSection.OrgID = this.ddlOrganization.SelectedItem.Value;
			objComp.FillDropDownList(this.ddlSection, objSection.GetAll(1), "SectionName", "SectionID");
		}
	}
}