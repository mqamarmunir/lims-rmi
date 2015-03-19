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
	/// Summary description for wfrmPatientEdit.
	/// </summary>
	public partial class wfrmPatientEdit : System.Web.UI.Page
	{
		private string sMSerialNo;		

		protected void Page_Load(object sender, System.EventArgs e)
		{
			 if(User.Identity.IsAuthenticated)
			{				
				sMSerialNo = Request.QueryString["sMSerialNo"].ToString();												
				if(!IsPostBack)				
				{	
					RefreshForm();
					DisplayPatient(sMSerialNo);
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
		
		private int GetIndex(string sValue, DropDownList ddl)
		{
			try
			{				
				for(int i=0; i < ddl.Items.Count; i++)
				{
					if (ddl.Items[i].Value==sValue)
					{
						return i;
					}
				}
			}
			catch{}
			return 0;			
		}

		private void RefreshForm()
		{				
			SComponents objComp = new SComponents();
			objComp.FillDropDownList(this.CmbRelationShip, new clsBLRelationShip().GetAll(), "Data", "ID");

			
			/*this.CmbRelationShip.SelectedItem.Selected = false;		
			this.CmbRelationShip.Items.FindByValue("-1").Selected = true;			*/
			this.txtKinFName.Text = "";
			this.txtKinMName.Text = "";
			this.txtKinLName.Text = "";			
			/*this.ddlPTitle.SelectedItem.Selected = false;
			this.ddlPTitle.Items.FindByValue("-1").Selected = true;			*/			
			this.TxtPFName.Text = "";
			this.TxtPMName.Text = "";
			this.TxtPLName.Text = "";			
			this.lblSexAge.Text = "";			
		}		

		private void DisplayPatient(string sMSerialNo)
		{	
			clsBLPatient objTPatient = new clsBLPatient();						
			objTPatient.MSerialNo = sMSerialNo;				
			DataView dvTPatient = objTPatient.GetAll(1);

			if(dvTPatient.Count > 0)
			{
				CmbRelationShip.SelectedIndex = GetIndex(dvTPatient.Table.Rows[0]["KinShip"].ToString(), CmbRelationShip);				
				txtKinFName.Text = dvTPatient.Table.Rows[0]["KFName"].ToString();		
				txtKinMName.Text = dvTPatient.Table.Rows[0]["KMName"].ToString();		
				txtKinLName.Text = dvTPatient.Table.Rows[0]["KLName"].ToString();		

				ddlPTitle.SelectedIndex = GetIndex(dvTPatient.Table.Rows[0]["PTitle"].ToString(), ddlPTitle);	
				TxtPFName.Text = dvTPatient.Table.Rows[0]["PFName"].ToString();		
				TxtPMName.Text = dvTPatient.Table.Rows[0]["PMName"].ToString();		
				TxtPLName.Text = dvTPatient.Table.Rows[0]["PLName"].ToString();		
				lblSexAge.Text = dvTPatient.Table.Rows[0]["PSex"].ToString()+" / "+
				dvTPatient.Table.Rows[0]["PAgeD"].ToString()+" "+
				dvTPatient.Table.Rows[0]["PAgeUN"].ToString();

                txtReferredBy.Text = dvTPatient.Table.Rows[0]["RefDoctor"].ToString().Trim();
			}

		}

		protected void ButSave_Click(object sender, System.EventArgs e)
		{
			clsBLPatient objTPatient = new clsBLPatient();			
			
			objTPatient.MSerialNo = sMSerialNo;
			objTPatient.KFName = txtKinFName.Text;
			objTPatient.KMName = txtKinMName.Text;
			objTPatient.KLName = txtKinLName.Text;
			objTPatient.PFName = TxtPFName.Text;
			objTPatient.PMName = TxtPMName.Text;
			objTPatient.PLName = TxtPLName.Text;
			objTPatient.KinShip = this.CmbRelationShip.SelectedItem.Value;
			objTPatient.PTitle = this.ddlPTitle.SelectedItem.Value;
            objTPatient.RefDoctor = txtReferredBy.Text.Trim();
			bool isSuccessful = objTPatient.UpdatePatientName();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objTPatient.ErrorMessage + "<br><br>";
			}
			else
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";			
			}
		}
	}
}