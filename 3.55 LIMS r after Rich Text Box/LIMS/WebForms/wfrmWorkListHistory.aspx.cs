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
	/// Summary description for wfrmWorkListHistory.
	/// </summary>
	public partial class wfrmWorkListHistory : System.Web.UI.Page
	{
	
		private string sDeptID;

		protected void Page_Load(object sender, System.EventArgs e)
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

				sDeptID = Request.QueryString.Get("sdeptid");
				FillDDL();
				ddlSection.SelectedValue = sDeptID;
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
			this.dgWorkList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgWorkList_ItemCommand);

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

		private void FillWLDG()
		{			
			clsBLWorkList objTWorkList = new clsBLWorkList();			
			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				objTWorkList.SectionID = this.ddlSection.SelectedItem.Value;		
				DataView dvTWorkList = objTWorkList.GetAll(2);

				if(dvTWorkList.Count > 0)
				{
					lblRecordNo.Text = "Record fetched : "+dvTWorkList.Count.ToString();
					this.dgWorkList.DataSource = dvTWorkList;
					this.dgWorkList.DataBind();
					this.dgWorkList.Visible = true;
					this.lblErrMsg.Text = "";
				}
				else
				{
					this.dgWorkList.Visible = false;
					this.dgGroupList.Visible = false;
					this.lblDetail.Visible = false;
					lblRecordNo.Text = "Record not found.";
				}
			}
			else
			{
				this.lblErrMsg.Text = "Please select Section ID.";
				this.dgWorkList.Visible = false;
				this.dgGroupList.Visible = false;
				this.lblDetail.Visible = false;
			}
		}

		private void FillDG(string Str)
		{			
			clsBLWorkList objTWorkList = new clsBLWorkList();			
			objTWorkList.SectionID = this.ddlSection.SelectedItem.Value;		
			objTWorkList.WorkListNo = Str;									
			DataView dvTWorkList = objTWorkList.GetAll(3);

			if(dvTWorkList.Count > 0)
			{
				lblDetail.Text = "(Detail) WorkList No: "+Str+" ("+dvTWorkList.Count.ToString()+" Records).";
				this.dgGroupList.DataSource = dvTWorkList;
				this.dgGroupList.DataBind();
				this.dgGroupList.Visible = true;
				lblDetail.Visible = true;
				this.lblErrMsg.Text = "";
			}
			else
			{
				this.dgGroupList.Visible = false;
				lblDetail.Text = "";
				lblDetail.Visible = false;
			}		
		}

		protected void Refreash_Click(object sender, System.EventArgs e)
		{
			FillWLDG();
		}	

		private void dgWorkList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{		
			string sWorkListNo = "";
			string sSectionID = "";
			if(e.CommandName.Equals("Detail"))
			{ 
				int index = e.Item.ItemIndex;
				this.dgWorkList.SelectedIndex = index;
				sWorkListNo = this.dgWorkList.Items[index].Cells[1].Text;
				FillDG(sWorkListNo);
			}
			else
				if(e.CommandName.Equals("Print"))
			{
				int index = e.Item.ItemIndex;
				this.dgWorkList.SelectedIndex = index;
				sWorkListNo = this.dgWorkList.Items[index].Cells[1].Text;
				sSectionID = this.ddlSection.SelectedItem.ToString();

				if(RdoGroupWise.SelectedValue.ToString().Equals("T"))
				{
					if(RdoList.SelectedValue.ToString().Equals("W"))
					{
						LIMS.reports.GeneralReports.mFilterString = "{LS_VWORKLIST.WORKLISTNO}="+sWorkListNo+" and {LS_VWORKLIST.SECTIONNAME}='"+sSectionID+"'";
						LIMS.reports.GeneralReports.ReportReference = "LMS-002-01";
						string[,] pdfSetting = {{"groupby", "W"}};
						LIMS.reports.GeneralReports.PdfSetting = pdfSetting;
						
						Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-002-01','_blank','resizable')</script>");		
					}
					else
					{
					}
				}
				else if(RdoGroupWise.SelectedValue.ToString().Equals("G"))
				{
					if(RdoList.SelectedValue.ToString().Equals("W"))
					{
						LIMS.reports.GeneralReports.mFilterString = "{LS_VWORKLIST.WORKLISTNO}="+sWorkListNo+" and {LS_VWORKLIST.SECTIONNAME}='"+sSectionID+"'";
						LIMS.reports.GeneralReports.ReportReference = "LMS-002-01";
						string[,] pdfSetting = {{"groupby", "G"}};
						LIMS.reports.GeneralReports.PdfSetting = pdfSetting;

						Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-002-01','_blank','resizable')</script>");		
					}
					else
					{
					}
				}
				else
				{
					if(RdoList.SelectedValue.ToString().Equals("W"))
					{
						LIMS.reports.GeneralReports.mFilterString = "{LS_VWORKLIST.WORKLISTNO}="+sWorkListNo+" and {LS_VWORKLIST.SECTIONNAME}='"+sSectionID+"'";
						LIMS.reports.GeneralReports.ReportReference = "LMS-002-02";
						
						Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-002-02','_blank','resizable')</script>");		
					}
					else
					{
					}
				}
			}
		}
	}
}