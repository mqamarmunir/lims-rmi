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
	/// Summary description for wfrmSpecimenContainer.
	/// </summary>
	public partial class wfrmSpecimenContainer : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here				
			FillDG();
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
			this.dgSelectionValue.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgSelectionValue_ItemCommand);

		}
		#endregion

		private void Insert()
		{
			clsBLSpecimenContainer objSpecimenContainer = new clsBLSpecimenContainer();			
			objSpecimenContainer.SValue = txtValue.Text;
			if (!txtValue.ToolTip.Equals("")) 
			{
				objSpecimenContainer.SValueOld = txtValue.ToolTip;	
			} 
			else
			{
				objSpecimenContainer.SValueOld = txtValue.Text;
			}
            objSpecimenContainer.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objSpecimenContainer.Enteredby = this.Session["loginid"].ToString();
			
			if(objSpecimenContainer.Insert())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objSpecimenContainer.ErrorMessage + "<br><br>";
			}
		}	
	
		private void Delete(string sValue)
		{
			clsBLSpecimenContainer objSpecimenContainer = new clsBLSpecimenContainer();

			objSpecimenContainer.SValue = sValue;
			objSpecimenContainer.SValueOld = sValue;	
			
			if(objSpecimenContainer.Delete())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objSpecimenContainer.ErrorMessage + "<br><br>";
			}
		}

		private void FillDG()
		{
			clsBLSpecimenContainer objSpecimenContainer = new clsBLSpecimenContainer();			
			DataView dvSpecimenContainer = objSpecimenContainer.GetAll(1);

			if(dvSpecimenContainer.Count > 0)
			{
				//dvAttributeSelection.Sort = DGSort;
				this.dgSelectionValue.DataSource = dvSpecimenContainer;
				this.dgSelectionValue.DataBind();
				this.dgSelectionValue.Visible = true;
			}
			else
			{
				this.lblErrMSg.Text = "<br>No Method found.<br><br>";
				this.dgSelectionValue.Visible = false;
			}
		}

		private void RefreshForm()
		{
			this.txtValue.Text = "";
			this.txtValue.ToolTip = "";
		}		

		protected void lbtnSave_Click(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";			
			Insert();			
		}

		protected void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";
			RefreshForm();
		}

		private void dgSelectionValue_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{			
				this.lblErrMSg.Text = "";
				int index = e.Item.ItemIndex;
				txtValue.Text = e.Item.Cells[0].Text.Replace("&nbsp;", "");	
				txtValue.ToolTip = txtValue.Text;	
			}
			else if(e.CommandName.Equals("Delete"))
			{			
				this.lblErrMSg.Text = "";
				int index = e.Item.ItemIndex;
				Delete(e.Item.Cells[0].Text);				
			}	
		}
	}
}