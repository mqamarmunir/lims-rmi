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
	/// Summary description for wfrmOpinion.
	/// </summary>
	public partial class wfrmOpinion : System.Web.UI.Page
	{
		#region Form Component
		#endregion

		private static clsBLOpinion opinion;
		private static string personID="";
		private static string testID="";

		#region Page Load
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
                if (!IsPostBack)
                {
                    try
                    {
                        LoadForm();
                    }
                    catch (Exception ee)
                    {
                        Response.Write(ee.ToString());
                    }

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
			opinion = new clsBLOpinion();
			DataView dv = opinion.GetAll(personID, testID, "All~!@");
            for (int i = 0; i < dv.Count; i++)
            {
                dv[i]["opinion"] = dv[i]["Opinion"].ToString().Replace("<br>", "\r\n");
            }
            DGOpinion.DataSource = dv;
			DGOpinion.DataBind();
			
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
			this.DGOpinion.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGOpinion_ItemCommand);
			this.DGOpinion.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGOpinion_CancelCommand);
			this.DGOpinion.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGOpinion_EditCommand);
			this.DGOpinion.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGOpinion_UpdateCommand);

		}
		#endregion

		private void DGOpinion_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
            try
            {
                // OpinionID
                TableCell cell1 = (TableCell)e.Item.Controls[1];
                string id = ((Label)cell1.Controls[1]).Text;

                // Opinion
                TableCell cell2 = (TableCell)e.Item.Controls[2];
                string opinionDesc = ((TextBox)cell2.Controls[1]).Text.Replace("\r\n", "<br>");

                if (opinionDesc.Equals(""))
                {
                    LblMessage.Text = "Please enter opinion";
                    return;
                }

                if (id == "0")	// new one
                {
                    opinion.AddOpinion(personID, testID, opinionDesc);
                }
                else		// editing	
                {
                    opinion.UpdateOpinion(long.Parse(id), opinionDesc, testID, personID);
                }

                DGOpinion.EditItemIndex = -1;
                LoadGrid();
            }
            catch (Exception ee)
            {
                Response.Write(ee.ToString());
            }

		}

		private void DGOpinion_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DGOpinion.EditItemIndex = -1;
			LoadGrid();
		}

		private void DGOpinion_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//string xyz = ((Label)(e.Item.Cells[2].FindControl("LblDescription"))).Text;
           // ((Label)(e.Item.Cells[2].FindControl("LblDescription"))).Text = ((Label)(e.Item.Cells[2].FindControl("LblDescription"))).Text.Replace("<br>", "\r\n");
            //TextBox txtopinion = (TextBox)(e.Item.Cells[2].FindControl("TxtDescription"));
            //txtopinion.Text = txtopinion.Text.Replace("<br>", "\r\n");
            DGOpinion.EditItemIndex = e.Item.ItemIndex;
            //((Label)(e.Item.Cells[2].FindControl("LblDescription"))).Visible=false;
            //TextBox txtopinion = (TextBox)(e.Item.Cells[2].FindControl("TxtDescription"));
            //txtopinion.Visible = true;
           // txtopinion.Text = ((Label)(e.Item.Cells[2].FindControl("LblDescription"))).Text;




            LoadGrid();
		}

		private void DGOpinion_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{
				// Opinion
				TableCell cell = (TableCell)e.Item.Controls[2];
				string opinionDesc = ((Label)cell.Controls[1]).Text.Replace("\r\n","<br>");

				Response.Write("<script> window.opener.SetOpinion('"+opinionDesc+"'); window.close(); </script>");
			}
            if (e.CommandName.Equals("Delete"))
            {
                string opinionid = ((Label)DGOpinion.Items[e.Item.ItemIndex].Cells[1].FindControl("LblVaultID")).Text.Trim();
                opinion = new clsBLOpinion();
                opinion.Opinionid = opinionid;
                opinion.Testid = testID;
                opinion.Personid = personID;

                if (opinion.deleteopinion())
                {
                    LblMessage.Text = "<font color='green'>Opinion Deleted</font>";
                    LoadGrid();
                }
                else
                {
                    LblMessage.Text = opinion.ErrorMessage;
                }
            }
                

		}

		protected void ButGo_Click(object sender, System.EventArgs e)
		{
			if(TxtSearch.Text != "")
			{
				DataView dv = opinion.GetAll(personID, testID, TxtSearch.Text);
                for (int i = 0; i < dv.Count; i++)
                {
                    dv[i]["opinion"] = dv[i]["Opinion"].ToString().Replace("<br>", "\r\n");
                }
				DGOpinion.DataSource = dv;
				DGOpinion.DataBind();
			}
			else
			{
                LoadGrid();
                //DataView dv = opinion.GetAll(personID, testID, "All~!@");
                //DGOpinion.DataSource = dv;
                //DGOpinion.DataBind();
			}
		}
	}
}