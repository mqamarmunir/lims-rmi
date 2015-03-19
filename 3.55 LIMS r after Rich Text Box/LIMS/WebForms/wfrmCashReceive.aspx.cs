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
	/// Summary description for wfrmCashReceive.
	/// </summary>
	public partial class wfrmCashReceive : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{			
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "103";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

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
			this.dgGroupList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_ItemCommand);

		}
		#endregion	
		

		private void RefreshForm()
		{		
			this.txtPatientName.Text = "";
			this.ddlSex.SelectedItem.Selected = false;
			this.ddlSex.Items.FindByValue("-1").Selected = true;			
			this.txtMSerialNoFrom.Text = "";
			this.txtMSerialNoTo.Text = "";
		}
		private void FillDG()
		{
			this.lblErrMsg.Text = "";

			clsBLCashReceive objTCashReceive = new clsBLCashReceive();			
			# region "Parameters Conditions"
			if (!this.txtPatientName.Text.Equals(""))
			{ objTCashReceive.PatientName = this.txtPatientName.Text;}
			if (!this.ddlSex.SelectedItem.Value.Equals("-1"))
			{ objTCashReceive.Sex = this.ddlSex.SelectedItem.Value;}

			if (this.txtMSerialNoFrom.Text.Trim() != "")
			{ objTCashReceive.LabIDFrom = this.txtMSerialNoFrom.Text;}
			if (this.txtMSerialNoTo.Text.Trim() != "")
			{ objTCashReceive.LabIDTo = this.txtMSerialNoTo.Text;}

			if(!this.txtDF.Text.Equals(""))
			{ 
				objTCashReceive.EnteredateF = this.txtDF.Text;
			}

			if(!this.txtDT.Text.Equals(""))
			{ 
				objTCashReceive.EnteredateT = this.txtDT.Text;
			}

			# endregion

			DataView dvTCashReceive = objTCashReceive.GetAll(1);

			if(dvTCashReceive.Count > 0)
			{
				lblRecordNo.Text = "Record fetched : "+dvTCashReceive.Count.ToString();
				this.dgGroupList.DataSource = dvTCashReceive;
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
			if(e.CommandName.Equals("Receive"))
			{
				clsBLCashReceive objTCashReceive = new clsBLCashReceive();					
					
				objTCashReceive.MSerialNo = e.Item.Cells[2].Text;				
				objTCashReceive.LabID = e.Item.Cells[3].Text;							
				objTCashReceive.PRNo = e.Item.Cells[11].Text;				
				objTCashReceive.PatientName = e.Item.Cells[4].Text;			
				objTCashReceive.TotalAmount = e.Item.Cells[8].Text;			
				bool isSuccessful = objTCashReceive.Update();
				if(!isSuccessful)
				{ this.lblErrMsg.Text = objTCashReceive.ErrorMessage; }
				else 
				{
					this.lblErrMsg.Text = "<font color='Green'>Record has been updated successfully.</font>"; }
				FillDG();			
			} 
			else 
				if(e.CommandName.Equals("Detail"))
			{
				Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno=" + e.Item.Cells[2].Text + "','','channelmode')</script>"); 			
			}			
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

		protected void lnkToday_Click(object sender, System.EventArgs e)
		{
			this.txtDF.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
			FillDG();		
		}

		protected void lnkYesterday_Click(object sender, System.EventArgs e)
		{
			txtDF.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
			txtDT.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
			FillDG();			
		}

		protected void dgGroupList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}