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
	/// Summary description for wfrmWorkList.
	/// </summary>
	public partial class wfrmWorkList : System.Web.UI.Page
	{
	
		private static string mode = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "104";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					mode = "Insert";
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
			//this.txtGroup.Text = "";
			//this.txtAcronym.Text = "";
			//this.CheckBox1.Checked = false;			
			//TestGroupID = "";
		}
		private void FillDG()
		{
			clsBLWorkList objTWorkList = new clsBLWorkList();			
			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				objTWorkList.SectionID = this.ddlSection.SelectedItem.Value;		
				DataView dvTWorkList = objTWorkList.GetAll(1);

				if(dvTWorkList.Count > 0)
				{
					this.dgGroupList.DataSource = dvTWorkList;
					this.dgGroupList.DataBind();
					this.dgGroupList.Visible = true;
				}
				else
				{
					this.dgGroupList.Visible = false;
				}
			}
			else
			{
				this.lblErrMsg.Text = "<br>Please select Section ID.<br><br>";
				this.dgGroupList.Visible = false;
			}
		}

		private void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			if(ddlSection.SelectedIndex > 0)
			{
				clsBLWorkList objWorkL = new clsBLWorkList();
				objWorkL.SectionID = ddlSection.SelectedItem.Value.ToString();
				DataView dvWorkL = objWorkL.GetAll(4);
				
				LIMS.reports.GeneralReports.mFilterString = "{LS_VWORKLIST.WORKLISTNO}=" +dvWorkL.Table.Rows[0]["WorkListNo"].ToString()+ " and {LS_VWORKLIST.SECTIONID}='" +ddlSection.SelectedItem.Value.ToString()+ "'";
				LIMS.reports.GeneralReports.ReportReference = "LMS-002-01";
				Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','resizable')</script>");
			}
			else
			{
				lblErrMsg.Text = "<br>Please select Section ID.<br><br>";
			}
		}

		protected void lbtnSave_Click(object sender, System.EventArgs e)
		{
			string[,] AttributeResult = new string[dgGroupList.Items.Count, 3];			
			for (int i=0; i < dgGroupList.Items.Count; i++)
			{
				AttributeResult[i, 0] = this.dgGroupList.Items[i].Cells[8].Text;  //DSerialNo
				AttributeResult[i, 1] = this.dgGroupList.Items[i].Cells[7].Text; // ProcedureID
				AttributeResult[i, 2] = ddlSection.SelectedItem.Value; // SectionID
			}	

			
			clsBLWorkList objTWorkList = new clsBLWorkList();		

			objTWorkList.SectionID = ddlSection.SelectedItem.Value;
			objTWorkList.WorkListDate = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
			objTWorkList.GeneratedBy = Session["loginid"].ToString();
			objTWorkList.NoofTest = dgGroupList.Items.Count.ToString();				

			bool isSuccessful = objTWorkList.UpdateAll(AttributeResult);
			if(!isSuccessful)
			{
				this.lblErrMsg.Text = objTWorkList.ErrorMessage;
			}
			else
			{				
				Response.Redirect("wfrmWorkListHistory.aspx?sdeptid="+ddlSection.SelectedValue);
				//FillDG();		
			}		
			
			/*

			for (int I = 0; I < this.dgGroupList.Items.Count; I++) 
			{		
				objTWorkList.DSerialNo = this.dgGroupList.Items[I].Cells[8].Text;	
				objTWorkList.ProcedureID = this.dgGroupList.Items[I].Cells[7].Text;
				objTWorkList.SectionID = ddlSection.SelectedItem.Value;
				bool isSuccessful = objTWorkList.Update();
				if(!isSuccessful)
				{
					this.lblErrMsg.Text = objTWorkList.ErrorMessage; 
					break;
				}
				else 
				{
					this.lblErrMsg.Text = "<font color='Green'>Record has been updated successfully.</font>"; }								
			}
			FillDG();		*/
		}


		protected void LinkButton2_Click(object sender, System.EventArgs e)
		{			
			Response.Redirect("wfrmWorkListHistory.aspx?sdeptid="+ddlSection.SelectedValue);
		}

		protected void dgGroupList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();
		}
	}
}