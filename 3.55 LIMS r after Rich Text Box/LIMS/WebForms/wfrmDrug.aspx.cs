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
	/// Summary description for wfrmDrug.
	/// </summary>
	public partial class wfrmDrug : System.Web.UI.Page
	{

		private static string mode = "";
        private static string DGSort = "Drug ASC";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{				
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "007";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					EnableForm(false);
					mode = "Insert";
					this.txtDrug.ToolTip = "";
					FillOrganism();
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
			this.ibtnSave.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSave_Click);
			this.ibtnClear.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClear_Click);
			this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
			this.dgDrug.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGroupList_ItemCreated);
			this.dgDrug.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_ItemCommand);			

		}
		#endregion

		private void EnableForm(bool enable)
		{
			this.ibtnSave.Enabled = enable;
			this.chkActive.Enabled = enable;
			this.txtDrug.Enabled = enable;
			this.txtAcronym.Enabled = enable;			
		}

		private void FillOrganism()
		{
			clsBLOrganism objOrganism = new clsBLOrganism();
			SComponents objComp = new SComponents();			
			DataView dvOrganism = objOrganism.GetAll(1);
			objComp.FillDropDownList(this.ddlOrganism, dvOrganism, "Organism", "OrganismID"); 
		}

		private void Insert()
		{
			clsBLDrug objDrug = new clsBLDrug();

			objDrug.Drug = this.txtDrug.Text;
			objDrug.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objDrug.Acronym = this.txtAcronym.Text;
			objDrug.OrganismID = this.ddlOrganism.SelectedItem.Value;
            objDrug.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objDrug.Enteredby = this.Session["loginid"].ToString();

			bool isSuccessful = objDrug.Insert();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objDrug.ErrorMessage + "<br><br>";
			}
			else
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
		}

		private void Update()
		{
			clsBLDrug objDrug = new clsBLDrug();

			objDrug.DrugID = this.txtDrug.ToolTip.ToString();
			objDrug.Drug = this.txtDrug.Text;
			objDrug.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objDrug.Acronym = this.txtAcronym.Text;
			objDrug.OrganismID = this.ddlOrganism.SelectedItem.Value;
            objDrug.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objDrug.Enteredby = this.Session["loginid"].ToString();
	
			bool isSuccessful = objDrug.Update();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objDrug.ErrorMessage + "<br><br>";
			}
			else
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				RefreshForm();
				FillDG();
				this.ibtnSave.ToolTip = "Save";
			}
		}

		private void FillDG()
		{
			clsBLDrug objDrug = new clsBLDrug();

			if(!this.ddlOrganism.SelectedItem.Value.Equals("-1"))
			{
				objDrug.OrganismID = this.ddlOrganism.SelectedItem.Value;
				DataView dvDrug = objDrug.GetAll(4);

				if(dvDrug.Count > 0)
				{
                    dvDrug.Sort = DGSort;
					this.dgDrug.DataSource = dvDrug;
					this.dgDrug.DataBind();
					this.dgDrug.Visible = true;
				}
				else
				{
					this.dgDrug.Visible = false;
				}
			}
			else
			{
				this.lblErrMsg.Text = "<br>Please select Organism.<br><br>";
				this.dgDrug.Visible = false;
			}
		}

		private void RefreshForm()
		{
			this.txtDrug.ToolTip = "";
			this.txtDrug.Text = "";
			this.txtAcronym.Text = "";
			this.chkActive.Checked = true;						
			mode = "Insert";
		}

		private void dgGroupList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{				
				this.lblErrMsg.Text = "";				
				this.chkActive.Checked = ((CheckBox)e.Item.Cells[3].FindControl("dgchkActive")).Checked;
				this.txtDrug.ToolTip = e.Item.Cells[0].Text.Replace("&nbsp;", "");
				this.txtDrug.Text = e.Item.Cells[1].Text.Replace("&nbsp;", "");
				this.txtAcronym.Text = e.Item.Cells[2].Text.Replace("&nbsp;", "");			
				this.ibtnSave.ToolTip = "Update";
				mode = "Update";
			}
		}

		private void dgGroupList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			// Create a new WebUIFacade.
			WebUIFacade uiFacade = new WebUIFacade();
    
			// This is gives a tool tip for each
			// of the columns to sort by.
			uiFacade.SetHeaderToolTip(e);
    
    
			// This sets a class for the link buttons in a grid.
			uiFacade.SetGridLinkButtonStyle(e);
    
			// Make the row change color when the mouse hovers over.
			// *** You must have a class called gridHover with a different background 
			// color in your StyleSheet.
			uiFacade.SetRowHover(this.dgDrug, e);
		}

		private void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		private void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			RefreshForm();
		}

		private void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");			
		}
		
		protected void ddlOrganism_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();

			if(!this.ddlOrganism.SelectedItem.Value.Equals("-1"))
			{
				EnableForm(true);
			}
			else
			{
				EnableForm(false);
			}
		}
        protected void dgDrug_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            if (e.SortExpression == "Drug")
            {
                if (DGSort == "Drug ASC")
                {
                    DGSort = "Drug DESC";
                }
                else
                    DGSort = "Drug ASC";
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


	}
}