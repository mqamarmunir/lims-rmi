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
	/// Summary description for wfrmVault.
	/// </summary>
	public partial class wfrmVault : System.Web.UI.Page
	{
		#region Form Component
		#endregion
		private static clsBLVault vault;
		

		private static string personID = "";
		private static string testID="";

		#region Page Load

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					LoadForm();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
		}

		private void LoadForm()
		{
			personID = Session["loginid"].ToString();
			testID = Request.QueryString.Get("testID").ToString();
			LoadGrid();
		}
		private void LoadGrid()
		{
			vault = new clsBLVault();
			DataView dv = vault.GetAll(personID, testID, "All~!@");
			DGVault.DataSource = dv;
			DGVault.DataBind();
			
			LblPerson.Text = dv.Table.Rows[0]["PersonName"].ToString();
			LblTest.Text = dv.Table.Rows[0]["Test"].ToString();
		}
		#endregion
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
			this.DGVault.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGVault_ItemCommand);
			this.DGVault.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGVault_CancelCommand);
			this.DGVault.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGVault_EditCommand);
			this.DGVault.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGVault_UpdateCommand);

		}
		#endregion

		#region Event
		private void DGVault_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LblMessage.Text = "";
			DGVault.EditItemIndex = e.Item.ItemIndex;
			LoadGrid();
		}
		
		private void DGVault_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LblMessage.Text = "";
			// VaultID
			TableCell cell1 = (TableCell)e.Item.Controls[1];
			string id = ((Label)cell1.Controls[1]).Text;

			// Description
			TableCell cell2 = (TableCell)e.Item.Controls[2];
			string description = ((TextBox)cell2.Controls[1]).Text;

			if(description.Equals(""))
			{
				LblMessage.Text = "<br>Please enter search text<br><br>";
				return;
			}
			
			if( id=="0" )	// new one
			{
				vault.AddVault(personID, testID, description);
			}
			else		// editing	
			{
				vault.UpdateVault(long.Parse(id), description);
			}

			DGVault.EditItemIndex = -1;
			LoadGrid();
		}

		private void DGVault_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LblMessage.Text = "";
			DGVault.EditItemIndex = -1;
			LoadGrid();
		}
		private void DGVault_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.LblMessage.Text = "";

			if(e.CommandName.Equals("Select"))
			{
				// Opinion
				TableCell cell = (TableCell)e.Item.Controls[2];
				string vaultDesc = ((Label)cell.Controls[1]).Text;
				Response.Write("<script> window.opener.SetComment('"+vaultDesc+"'); window.close(); </script>");
			}
		}

		protected void ButGo_Click(object sender, System.EventArgs e)
		{
			this.LblMessage.Text = "";

			if(TxtSearch.Text != "")
			{
				DataView dv = vault.GetAll(personID, testID, TxtSearch.Text);
				DGVault.DataSource = dv;
				DGVault.DataBind();
			}
			else
			{
				DataView dv = vault.GetAll(personID, testID, "All~!@");
				DGVault.DataSource = dv;
				DGVault.DataBind();
			}
		}
		#endregion
	}
}
