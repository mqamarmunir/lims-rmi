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
	/// Summary description for wfrmComment.
	/// </summary>
	public partial class wfrmComment : System.Web.UI.Page
	{
		#region Form Component
		#endregion

		private static clsBLComment Comment;
		private static string personID="";
		protected System.Web.UI.WebControls.DataGrid DGOpinion;
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
			Comment = new clsBLComment();
			DataView dv = Comment.GetAll(personID, testID, "All~!@");
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i]["Comments"] = dv[i]["Comments"].ToString().Replace("<br>", "\r\n");
            }
			DGComment.DataSource = dv;
			DGComment.DataBind();
			
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
			this.DGComment.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGComment_ItemCommand);
			this.DGComment.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGComment_CancelCommand);
			this.DGComment.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGComment_EditCommand);
			this.DGComment.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGComment_UpdateCommand);

		}
		#endregion

		private void DGComment_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// CommentID
			TableCell cell1 = (TableCell)e.Item.Controls[1];
			string id = ((Label)cell1.Controls[1]).Text;

			// Comment
			TableCell cell2 = (TableCell)e.Item.Controls[2];
            string CommentDesc = ((TextBox)cell2.Controls[1]).Text.Replace("\r\n", "<br>");
			
			if(CommentDesc.Equals(""))
			{
				LblMessage.Text = "Please enter Comment";
				return;
			}

			if( id=="0" )	// new one
			{
				Comment.AddComment(personID, testID, CommentDesc);
			}
			else		// editing	
			{
				Comment.UpdateComment(long.Parse(id), CommentDesc,testID,personID);
			}

			DGComment.EditItemIndex = -1;
			LoadGrid();
		}

		private void DGComment_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DGComment.EditItemIndex = -1;
			LoadGrid();
		}

		private void DGComment_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DGComment.EditItemIndex = e.Item.ItemIndex;
			LoadGrid();
		}

		private void DGComment_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{
				// Comment
				TableCell cell = (TableCell)e.Item.Controls[2];
                string CommentDesc = ((Label)cell.Controls[1]).Text.Replace("\r\n", "<br>");
              //  CommentDesc = CommentDesc.Replace("\r\n", "<br />");
				Response.Write("<script> window.opener.SetComment('"+CommentDesc+"'); window.close(); </script>");
			}
            if (e.CommandName.Equals("Delete"))
            {
                string commentid = ((Label)DGComment.Items[e.Item.ItemIndex].Cells[1].FindControl("LblVaultID")).Text.Trim();
                Comment = new clsBLComment();
                Comment.Commentid = commentid;
                Comment.Testid = testID;
                Comment.Personid = personID;

                if (Comment.deletecomment())
                {
                    LblMessage.Text = "<font color='green'>Comment Deleted</font>";
                    LoadGrid();
                }
                else
                {
                    LblMessage.Text = Comment.ErrorMessage;
                }
                

            }
		}

		protected void ButGo_Click(object sender, System.EventArgs e)
		{
			if(TxtSearch.Text != "")
			{
				DataView dv = Comment.GetAll(personID, testID, TxtSearch.Text);
                for (int i = 0; i < dv.Count; i++)
                {
                    dv[i]["Comments"] = dv[i]["Comments"].ToString().Replace("<br>", "\r\n");
                }
				DGComment.DataSource = dv;
				DGComment.DataBind();
			}
			else
			{
                LoadGrid();
                //DataView dv = Comment.GetAll(personID, testID, "All~!@");
                //DGComment.DataSource = dv;
                //DGComment.DataBind();
			}
		}
	}
}