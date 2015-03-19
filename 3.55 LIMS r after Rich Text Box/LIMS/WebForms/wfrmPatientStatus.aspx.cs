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
	/// Summary description for wfrmPatientStatus.
	/// </summary>
	public partial class wfrmPatientStatus : System.Web.UI.Page
	{
		
		private static SComponents objComp = new SComponents();
		private static clsBLPatientStatus patientStatus = new clsBLPatientStatus();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					FillForm();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
		}
		private void FillForm()
		{
			// filling section combo
			objComp.FillDropDownList(CmbSection, new clsBLSection().GetAll(2), "SectionName", "SectionID");
						
			DGPatientInfo.DataSource = patientStatus.GetAll();
			DGPatientInfo.DataBind();
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
			this.DGPatientInfo.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGPatientInfo_ItemCommand);

		}
		#endregion

		private void DGPatientInfo_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//int index = e.Item.ItemIndex;
			if(e.CommandName.Equals("Select"))
			{
				TableCell cell = (TableCell) e.Item.Controls[0];
				Response.Write("<script> window.open('wfrmPatientTestStatus.aspx?mserialno="+cell.Text+"','_blank'); </script>");
			}
		}

		protected void ButRefresh_Click(object sender, System.EventArgs e)
		{
			string sectionID = CmbSection.SelectedValue.ToString();
			string testGroupID = CmbTestGroup.SelectedValue.ToString();
			string patient = TxtPatient.Text;
			string sex = CmbSex.SelectedValue.ToString();
			string recNoFrom = TxtRecNoFrom.Text;
			string recNoTo = TxtRecNoTo.Text;
			DGPatientInfo.DataSource = patientStatus.GetAll(sectionID, testGroupID,
				sex, patient, recNoFrom, recNoTo);
			DGPatientInfo.DataBind();
		}

		protected void CmbSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// filling section combo
			clsBLTestGroup testGroup = new clsBLTestGroup();
			testGroup.SectionID = CmbSection.SelectedValue.ToString();
			objComp.FillDropDownList(CmbTestGroup, testGroup.GetAll(3), "TestGroup", "TestGroupID");
			
		}

		private void ButAll_Click(object sender, System.EventArgs e)
		{
			DGPatientInfo.DataSource = patientStatus.GetAll();
			DGPatientInfo.DataBind();		
		}
	}
}
