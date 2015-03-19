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
	/// Summary description for wfrmPatientTestChange.
	/// </summary>
	public partial class wfrmPatientTestChange : System.Web.UI.Page
	{

		private static clsBLPatientTestChange patientTestChange = new clsBLPatientTestChange();
		private static DataTable dtSelectedTest;
		private static int ageD=0;
		private static string ageU;
		private static string mSerialNo;
		private static string sectionID;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					/*try
					{
						mSerialNo = Request.QueryString.Get("mSerialNo").ToString();
					}
					catch(Exception err)
					{}*/
				
					DataView dvTransaction = patientTestChange.GetTransactionMaster(mSerialNo);
			
					LblPatientName.Text = dvTransaction.Table.Rows[0]["PatientName"].ToString();
					LblGender.Text = dvTransaction.Table.Rows[0]["PSex"].ToString();
					ageD = int.Parse(dvTransaction.Table.Rows[0]["PAgeD"].ToString());
					ageU = dvTransaction.Table.Rows[0]["PAgeU"].ToString();
					LblAge.Text = ageD.ToString() + " " + ageU + "(s)";
					LblType.Text = dvTransaction.Table.Rows[0]["Type"].ToString();
					LblPriority.Text = dvTransaction.Table.Rows[0]["Priority"].ToString();
				
					LoadGrid();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
		}

		public DataView FillDDLSection()
		{

			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();
			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			
			return dvSection;
		}
		
		private void LoadGrid()
		{
			dtSelectedTest = patientTestChange.GetTransactionDetail(mSerialNo).Table;
			
			DGSelectedTest.DataSource = dtSelectedTest.DefaultView;
			DGSelectedTest.DataBind();
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
			this.DGSelectedTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_ItemCommand);
			this.DGSelectedTest.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_CancelCommand);
			this.DGSelectedTest.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_EditCommand);
			this.DGSelectedTest.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_UpdateCommand);

		}
		#endregion

		private void DGSelectedTest_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DGSelectedTest.EditItemIndex = e.Item.ItemIndex;
			LoadGrid();
		}

		protected void ddlSection_SelectedIndexChanged(object source, System.EventArgs e)
		{
			DropDownList ddlSection = (DropDownList) source;
			
			clsBLTestGroup objTestGroup = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTestGroup.Active = "Y";
			objTestGroup.SectionID = ddlSection.SelectedValue;
			sectionID = ddlSection.SelectedValue;
			DataView dvTestGroup = objTestGroup.GetAll(3);
			
			TableCell tb = (TableCell) ddlSection.Parent;
			DropDownList ddlTestGroup = (DropDownList) tb.FindControl("ddlTestGroup");
			
			objComp.FillDropDownList(ddlTestGroup, dvTestGroup, "TestGroup", "TestGroupID");
			
			try
			{
				TableCell tb1 = (TableCell) ddlTestGroup.Parent;
				DropDownList ddlTest = (DropDownList) tb1.FindControl("ddlTest");
			
				ddlTest.Items.Clear();
			}
			catch(Exception err)
			{}
		}

		protected void ddlTestGroup_SelectedIndexChanged(object source, System.EventArgs e)
		{
			DropDownList ddlTestGroup = (DropDownList) source;
			if(!ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				SComponents objComp = new SComponents();
				
				long year = 0;
				if(ageU.Equals("Year"))
					year = ageD * 365;
				else if(ageU.Equals("Month"))
					year = ageD * 30;
				else if(ageU.Equals("Year"))
					year = ageD * 7;
					
				DataView dvTest = patientTestChange.GetAllTest(year, LblGender.Text, ddlTestGroup.SelectedValue.ToString(), sectionID);
				TableCell tb = (TableCell) ddlTestGroup.Parent;
				DropDownList ddlTest = (DropDownList) tb.FindControl("ddlTest");
			
				objComp.FillDropDownList(ddlTest, dvTest, "Test", "TestID"); 
			}
			else
			{
				try
				{
					TableCell tb = (TableCell) ddlTestGroup.Parent;
					DropDownList ddlTest = (DropDownList) tb.FindControl("ddlTest");
			
					ddlTest.Items.Clear();
				}
				catch(Exception err)
				{}
			}
		}		

		private void DGSelectedTest_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DGSelectedTest.EditItemIndex = -1;
			LoadGrid();
		}

		private void DGSelectedTest_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clsBLDTransaction dTransaction = new clsBLDTransaction();
			TableCell cell1 = (TableCell) e.Item.Controls[1];
			dTransaction.TestID = ((DropDownList) e.Item.Controls[1].FindControl("ddlTest")).SelectedValue;
			dTransaction.MSerialNo = mSerialNo;
			dTransaction.DSerialNo = ((TableCell) e.Item.Controls[9]).Text;
			dTransaction.EnteredBy = "000001";
			dTransaction.EnteredDateTime = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
			
			if(patientTestChange.Save(dTransaction))
			{
				LblMessage.Text = "<br><font color='Green'>Successfully updated</font><br><br>";
				
				DGSelectedTest.EditItemIndex = -1;
				LoadGrid();
			}
			else
			{
				LblMessage.Text = "<br>" + patientTestChange.ErrorMessage + "<br><br>";
			}
		}

		private void DGSelectedTest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			clsBLDTransaction dTransaction = new clsBLDTransaction();
			TableCell cell1 = (TableCell) e.Item.Controls[1];
			dTransaction.TestID = ((TableCell)e.Item.Controls[5]).Text;
			dTransaction.MSerialNo = mSerialNo;
			dTransaction.DSerialNo = ((TableCell) e.Item.Controls[9]).Text;
			
			if(e.CommandName.Equals("Delete"))
			{
				patientTestChange.Remove(dTransaction);
				LoadGrid();
			}
		}

		protected void lbtnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>window.opener.RefreshPage();self.close();</script>");
		}
	}
}
