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
	/// Summary description for WebForm1.
	/// </summary>
	public partial class WebForm1 : System.Web.UI.Page
	{

		private static string mode = "";
		private static string TestGroupID = "";
		private static string DGSort = "";	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{				
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "001";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					EnableForm(false);
					mode = "Insert";
					DGSort = "DOrder";
					FillSectionDDL();
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
			this.ibtnTest.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTest_Click);
			this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
			this.dgGroupList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGroupList_ItemCreated);
			this.dgGroupList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_ItemCommand);
			this.dgGroupList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgGroupList_PageIndexChanged);
			this.dgGroupList.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_EditCommand);
			this.dgGroupList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgGroupList_SortCommand);

		}
		#endregion

		private void EnableForm(bool enable)
		{
			this.ibtnSave.Enabled = enable;
			this.chkActive.Enabled = enable;
			this.txtGroup.Enabled = enable;
			this.txtAcronym.Enabled = enable;
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID"); 
		}

		private void lbtnSave_Click(object sender, System.EventArgs e)
		{
			
		}

		private void Insert()
		{
			clsBLTestGroup objTGroup = new clsBLTestGroup();

			objTGroup.TestGroup = this.txtGroup.Text;
			objTGroup.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objTGroup.Acronym = this.txtAcronym.Text;
			objTGroup.SectionID = (this.ddlSection.SelectedItem.Value == "-1") ? "" : this.ddlSection.SelectedItem.Value;
            objTGroup.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTGroup.Enteredby = Session["loginid"].ToString();

			bool isSuccessful = objTGroup.Insert();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objTGroup.ErrorMessage + "<br><br>";
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
			clsBLTestGroup objTGroup = new clsBLTestGroup();
			
			
			objTGroup.TestGroupID = TestGroupID.ToString();
			objTGroup.TestGroup = this.txtGroup.Text;
			objTGroup.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objTGroup.Acronym = this.txtAcronym.Text;
			objTGroup.SectionID = this.ddlSection.SelectedItem.Value;
            objTGroup.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTGroup.Enteredby = Session["loginid"].ToString();
	
			bool isSuccessful = objTGroup.Update();

			if(!isSuccessful)
			{
				this.lblErrMsg.Text = "<br>" + objTGroup.ErrorMessage + "<br><br>";
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
			clsBLTestGroup objTGroup = new clsBLTestGroup();

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				objTGroup.SectionID = this.ddlSection.SelectedItem.Value;
				DataView dvTGroup = objTGroup.GetAll(5);

				if(dvTGroup.Count > 0)
				{
					dvTGroup.Sort = DGSort;
					this.dgGroupList.DataSource = dvTGroup;
					this.dgGroupList.DataBind();
					this.dgGroupList.Visible = true;
				}
				else
				{
					this.dgGroupList.Visible = false;
				}
			}
			else
			{
				this.lblErrMsg.Text = "<br>Please select Section ID.<br><br>";
				this.dgGroupList.Visible = false;
			}
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				EnableForm(true);
			}
			else
			{
				EnableForm(false);
			}
		}

		private void RefreshForm()
		{
			this.txtGroup.Text = "";
			this.txtAcronym.Text = "";
			this.chkActive.Checked = true;			
			TestGroupID = "";
			mode = "Insert";
		}

		private void dgGroupList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgGroupList.CurrentPageIndex = e.NewPageIndex;
			FillDG();
		}

		private void dgGroupList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			int index = e.Item.ItemIndex;
			this.chkActive.Checked = ((CheckBox)this.dgGroupList.Items[index].Cells[3].FindControl("dgchkActive")).Checked;
			TestGroupID = this.dgGroupList.Items[index].Cells[0].Text;
			this.txtGroup.Text = this.dgGroupList.Items[index].Cells[1].Text;
			this.txtAcronym.Text = this.dgGroupList.Items[index].Cells[2].Text;
			this.ibtnSave.ToolTip = "Update";
			mode = "Update";
		}

		private void dgGroupList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			DGSort = e.SortExpression;
			FillDG();
		}

		private void dgGroupList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{				
				clsBLTestGroup objTGroup = new clsBLTestGroup();			
			
				objTGroup.TestGroupID = e.Item.Cells[0].Text;
				objTGroup.Active = "D";					
				bool isSuccessful = objTGroup.Delete();

				if(!isSuccessful)
				{
					this.lblErrMsg.Text = "<br>" + objTGroup.ErrorMessage + "<br><br>";
				}
				else
				{
					this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
					RefreshForm();
					FillDG();				
				}
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
			uiFacade.SetRowHover(this.dgGroupList, e);
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

		private void ibtnTest_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language = 'javascript'>window.open('wfrmTest.aspx?SectionID="+ddlSection.SelectedValue.ToString()+"','','fullscreen')</script>");						
		}

		private void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");			
		}
	}
}