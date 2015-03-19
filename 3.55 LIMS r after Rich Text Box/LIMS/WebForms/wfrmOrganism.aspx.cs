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
	/// Summary description for wfrmOrganism.
	/// </summary>
	public partial class wfrmOrganism : System.Web.UI.Page

	{

		private static string mode = "";
        private static string DGSort = "Organism ASC";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "006";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}
					mode = "Insert";										
					txtOrganismID.Text = "";
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
		/// Required Organism for Designer support - do not modify
		/// the contents of this Organism with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgOrganism.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgOrganism_ItemCommand);

		}
		#endregion

		private void FillDG()
		{
			clsBLOrganism objOrganism = new clsBLOrganism();			
			DataView dvOrganism = objOrganism.GetAll(2);

			if(dvOrganism.Count > 0)
			{
                dvOrganism.Sort = DGSort;
				this.dgOrganism.DataSource = dvOrganism;
				this.dgOrganism.DataBind();
				this.dgOrganism.Visible = true;
			}
			else
			{
				this.lblErrMSg.Text = "<br>No Organism found.<br><br>";
				this.dgOrganism.Visible = false;
			}
		}

		protected void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";
			RefreshForm();
		}

		private void RefreshForm()
		{
			this.chkActive.Checked = true;			
			this.txtOrganism.Text = "";
			this.txtAcronym.Text = "";
			this.txtDescription.Text = "";			
			mode = "Insert";
			txtOrganismID.Text = "";
		}

		protected void lbtnSave_Click(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";
			
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
			clsBLOrganism objOrganism = new clsBLOrganism();
			
			objOrganism.Organism = this.txtOrganism.Text.Replace("&nbsp;", "");
			objOrganism.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objOrganism.Acronym = this.txtAcronym.Text.Replace("&nbsp;", "");			
			objOrganism.Description = this.txtDescription.Text.Replace("&nbsp;", "");
            objOrganism.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objOrganism.Enteredby = this.Session["loginid"].ToString();
			
			if(objOrganism.Insert())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objOrganism.ErrorMessage + "<br><br>";
			}
		}

		private void Update()
		{
			clsBLOrganism objOrganism = new clsBLOrganism();

			objOrganism.OrganismID = txtOrganismID.Text;
			objOrganism.Organism = txtOrganism.Text.Replace("&nbsp;", "");
			objOrganism.Acronym = this.txtAcronym.Text.Replace("&nbsp;", "");
			objOrganism.Active = (this.chkActive.Checked == true) ? "Y" : "N";			
			objOrganism.Description = this.txtDescription.Text.Replace("&nbsp;", "");
            objOrganism.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objOrganism.Enteredby = this.Session["loginid"].ToString();
			
			if(objOrganism.Update())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objOrganism.ErrorMessage + "<br><br>";
			}
		}

		private void dgOrganism_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{			
				this.lblErrMSg.Text = "";
				this.lbtnSave.Text = "Update";
				mode = "Update";
				int index = e.Item.ItemIndex;

				txtOrganismID.Text = e.Item.Cells[0].Text.Replace("&nbsp;", "");
				this.txtOrganism.Text = e.Item.Cells[1].Text.Replace("&nbsp;", "");
				this.txtAcronym.Text = e.Item.Cells[2].Text.Replace("&nbsp;", "");
				this.chkActive.Checked = ((CheckBox)e.Item.Cells[3].FindControl("dgchkActive")).Checked;	
				this.txtDescription.Text = e.Item.Cells[4].Text.Replace("&nbsp;", "");
			}			
		}

        protected void dgOrganism_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression == "Organism")
            {
                if (DGSort == "Organism ASC")
                {
                    DGSort = "Organism DESC";
                }
                else
                    DGSort = "Organism ASC";

            }
            if (e.SortExpression == "Acronym")
            {
                if (DGSort == "Acronym ASC")
                {
                    DGSort = "Acronym DESC";
                }
                else
                    DGSort = "Acronym ASC";

            }
            if (e.SortExpression == "Active")
            {
                if (DGSort == "Active ASC")
                {
                    DGSort = "Active DESC";
                }
                else
                    DGSort = "Active ASC";

            }
            FillDG();
 
        }
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.close();</script>");
        }
}
}