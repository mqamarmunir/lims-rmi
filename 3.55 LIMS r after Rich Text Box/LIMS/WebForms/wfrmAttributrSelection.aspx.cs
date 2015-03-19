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
	/// Summary description for wfrmAttributrSelection.
	/// </summary>
	public partial class wfrmAttributrSelection : System.Web.UI.Page
	{
		string sAttributeID;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//select t.svalue, t.attributeid from ls_tattributeselection t
			sAttributeID = Request.QueryString.Get("AttributeID").ToString();
			//Label1.Text = sAttributeID;	
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
			clsBLAttributeSelection objAttributeSelection = new clsBLAttributeSelection();

			objAttributeSelection.AttributeID = sAttributeID;
			objAttributeSelection.SValue = txtValue.Text;
			if (!txtValue.ToolTip.Equals("")) 
			{
				objAttributeSelection.SValueOld = txtValue.ToolTip;	
			} 
			else
			{
				objAttributeSelection.SValueOld = txtValue.Text;
			}			
			
			if(objAttributeSelection.Insert())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objAttributeSelection.ErrorMessage + "<br><br>";
			}
		}	
	
		private void Delete(string sValue)
		{
			clsBLAttributeSelection objAttributeSelection = new clsBLAttributeSelection();

			objAttributeSelection.AttributeID = sAttributeID;
			objAttributeSelection.SValue = sValue;
			objAttributeSelection.SValueOld = sValue;	
			
			if(objAttributeSelection.Delete())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objAttributeSelection.ErrorMessage + "<br><br>";
			}
		}

		private void FillDG()
		{
			clsBLAttributeSelection objAttributeSelection = new clsBLAttributeSelection();
			objAttributeSelection.AttributeID = sAttributeID;
			DataView dvAttributeSelection = objAttributeSelection.GetAll(1);

			if(dvAttributeSelection.Count > 0)
			{
				//dvAttributeSelection.Sort = DGSort;
				this.dgSelectionValue.DataSource = dvAttributeSelection;
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

		private void dgSelectionList_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		}

		private void dgSelectionList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgSelectionValue.EditItemIndex = e.Item.ItemIndex;
			FillDG();
		}

		private void dgSelectionList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
		}

		private void dgSelectionList_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
		}

		private void dgSelectionList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
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
