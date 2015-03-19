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
	/// Summary description for wfrmRole.
	/// </summary>
	public partial class wfrmRole : System.Web.UI.Page
	{

		private static string mode = "";
		private static string RoleID = "";
		private static string DGSort = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if ((Session["loginid"].Equals("111111")) || (Session["loginid"].Equals("000001")))		
				{
					/**/
				}
				else
				{
					Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
				}
				if(!IsPostBack)
				{
					mode = "Insert";
					RoleID = "";
					DGSort = "Role";
					FillSectionDDL();
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
			this.dgRole.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgRole_PageIndexChanged);
			this.dgRole.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgRole_EditCommand);
			this.dgRole.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgRole_SortCommand);

		}
		#endregion

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();
			
			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);

			if(dvSection.Count > 0)
			{
				objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID",true,false,false);
			}
			else
			{
				this.lblErrMsg.Text = "<br>No Section found<br><br>";
			}
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			FillDG();
		}

		private void FillDG()
		{
			clsBLRole objRole = new clsBLRole();
			objRole.SectionID = this.ddlSection.SelectedItem.Value;
			DataView dvRole = objRole.GetAll(3);

			if(dvRole.Count > 0)
			{
				dvRole.Sort = DGSort;
				this.dgRole.DataSource = dvRole;
				this.dgRole.DataBind();
				this.dgRole.Visible = true;
			}
			else
			{
				this.lblErrMsg.Text = "<br>No Role found<br><br>";
				this.dgRole.Visible = false;
			}
		}

		private void dgRole_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			DGSort = e.SortExpression;
			FillDG();
		}

		private void dgRole_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.lblErrMsg.Text = "";
			this.dgRole.CurrentPageIndex = e.NewPageIndex;
			FillDG();
		}

		private void dgRole_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			int index = e.Item.ItemIndex;

			this.chkActive.Checked = ((CheckBox)this.dgRole.Items[index].Cells[3].FindControl("dgchkActive")).Checked;
			this.txtRole.Text = this.dgRole.Items[index].Cells[1].Text;
			this.txtAcronym.Text = this.dgRole.Items[index].Cells[2].Text;
			RoleID = this.dgRole.Items[index].Cells[0].Text;
			mode = "Update";
			this.lbtnSave.Text = "Update";
		}

		protected void lbtnSave_Click(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(mode.Equals("Insert"))
			{
				Insert();
			}
			else
			{
				Update();
			}
		}

		private void Insert()
		{
			clsBLRole objRole = new clsBLRole();

			objRole.Acronym = this.txtAcronym.Text;
			objRole.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objRole.Role = this.txtRole.Text;
			objRole.SectionID = this.ddlSection.SelectedItem.Value;
			
			if(objRole.Insert())
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMsg.Text = "<br>" + objRole.ErrorMessage + "<br><br>";
			}
		}

		private void RefreshForm()
		{
			mode = "Insert";
			RoleID = "";
			this.chkActive.Checked = true;
			this.txtRole.Text = "";
			this.txtAcronym.Text = "";
			this.lbtnSave.Text = "Save";
		}

		private void Update()
		{
			clsBLRole objRole = new clsBLRole();

			objRole.Acronym = this.txtAcronym.Text;
			objRole.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objRole.Role = this.txtRole.Text;
			objRole.RoleID = RoleID;
			objRole.SectionID = this.ddlSection.SelectedItem.Value;
			
			if(objRole.Update())
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMsg.Text = "<br>" + objRole.ErrorMessage + "<br><br>";
			}
		}

		protected void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			RefreshForm();
		}

		protected void dgRole_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}