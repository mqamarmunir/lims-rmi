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
	/// Summary description for wfrmMethod.
	/// </summary>
	public partial class wfrmMethod : System.Web.UI.Page
	{

		private static string mode = "";
		private static string MethodID = "";
		private static string DGSort = "";
		private static string DOrder = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "005";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					mode = "Insert";
					MethodID = "";
					DOrder = "";
					DGSort = "DOrder";
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
			this.dgMethod.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgMethod_PageIndexChanged);
			this.dgMethod.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgMethod_EditCommand);
			this.dgMethod.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgMethod_SortCommand);

		}
		#endregion

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);

			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID", true, false, false);
		}

		private void FillDG()
		{
			clsBLMethod objMethod = new clsBLMethod();
			objMethod.SectionID = this.ddlSection.SelectedItem.Value;
			DataView dvMethod = objMethod.GetAll(3);

			if(dvMethod.Count > 0)
			{
				dvMethod.Sort = DGSort;
				this.dgMethod.DataSource = dvMethod;
				this.dgMethod.DataBind();
				this.dgMethod.Visible = true;
			}
			else
			{
				this.lblErrMSg.Text = "<br>No Method found.<br><br>";
				this.dgMethod.Visible = false;
			}
		}

		protected void lbtnClearAll_Click(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";
			RefreshForm();
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMSg.Text = "";
			RefreshForm();
			FillDG();
		}

		private void RefreshForm()
		{
			this.chkActive.Checked = true;
			this.chkDefault.Checked = false;
			this.txtMethod.Text = "";
			this.txtAcronym.Text = "";
			this.txtMinTime.Text = "";
			this.txtMaxTime.Text = "";
			this.lbtnSave.Text = "Save";
			mode = "Insert";
			MethodID = "";
			DOrder = "";
            rtbText.Text = "";
		}

		private void dgMethod_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.lblErrMSg.Text = "";
			DGSort = e.SortExpression;
			FillDG();
		}

		private void dgMethod_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.lblErrMSg.Text = "";
			this.dgMethod.CurrentPageIndex = e.NewPageIndex;
			FillDG();
		}

		private void dgMethod_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMSg.Text = "";
			this.lbtnSave.Text = "Update";
			mode = "Update";
			int index = e.Item.ItemIndex;

			MethodID = this.dgMethod.Items[index].Cells[1].Text;
			this.chkActive.Checked = ((CheckBox)this.dgMethod.Items[index].Cells[4].FindControl("dgchkActive")).Checked;
			this.chkDefault.Checked = (this.dgMethod.Items[index].Cells[9].Text == "Y") ? true : false;
			this.txtMethod.Text = this.dgMethod.Items[index].Cells[2].Text;
			this.txtAcronym.Text = this.dgMethod.Items[index].Cells[3].Text;
			this.ddlTAT.SelectedItem.Selected = false;
			this.ddlTAT.Items.FindByValue(this.dgMethod.Items[index].Cells[6].Text).Selected = true;
			this.txtMinTime.Text = this.dgMethod.Items[index].Cells[7].Text;
			this.txtMaxTime.Text = this.dgMethod.Items[index].Cells[8].Text;
			DOrder = this.dgMethod.Items[index].Cells[10].Text;
            rtbText.Text = dgMethod.Items[index].Cells[11].Text;
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
			clsBLMethod objMethod = new clsBLMethod();

			objMethod.Acronym = this.txtAcronym.Text;
			objMethod.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objMethod.MaxTime = this.txtMaxTime.Text;
			objMethod.MDefault = (this.chkDefault.Checked == true) ? "Y" : "N";
			objMethod.Method = this.txtMethod.Text;
			objMethod.MinTime = this.txtMinTime.Text;
			objMethod.SectionID = this.ddlSection.SelectedItem.Value;
			objMethod.TAT = this.ddlTAT.SelectedItem.Value;
            string method_text = rtbText.Text;
            method_text = method_text.Replace("<strong>", "<b>");
            method_text = method_text.Replace("</strong>", "</b>");
            method_text = method_text.Replace("<em>", "<i>");
            method_text = method_text.Replace("</em>", "</i>");
            objMethod.MethodText = method_text;
            objMethod.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objMethod.Enteredby = this.Session["loginid"].ToString();
			
			if(objMethod.Insert())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objMethod.ErrorMessage + "<br><br>";
			}
		}

		private void Update()
		{
			clsBLMethod objMethod = new clsBLMethod();

			objMethod.Acronym = this.txtAcronym.Text;
			objMethod.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objMethod.DOrder = DOrder;
			objMethod.MaxTime = this.txtMaxTime.Text;
			objMethod.MDefault = (this.chkDefault.Checked == true) ? "Y" : "N";
			objMethod.Method = this.txtMethod.Text;
			objMethod.MethodID = MethodID;
			objMethod.MinTime = this.txtMinTime.Text;
			objMethod.SectionID = this.ddlSection.SelectedItem.Value;
			objMethod.TAT = this.ddlTAT.SelectedItem.Value;
            string method_text = rtbText.Text;
            method_text = method_text.Replace("<strong>", "<b>");
            method_text = method_text.Replace("</strong>", "</b>");
            method_text = method_text.Replace("<em>", "<i>");
            method_text = method_text.Replace("</em>", "</i>");
            objMethod.MethodText = method_text;
            objMethod.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objMethod.Enteredby = this.Session["loginid"].ToString();
			
			if(objMethod.Update())
			{
				this.lblErrMSg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMSg.Text = "<br>" + objMethod.ErrorMessage + "<br><br>";
			}
		}

		protected void dgMethod_Init(object sender, System.EventArgs e)
		{
			/*// Create a new WebUIFacade.
			WebUIFacade uiFacade = new WebUIFacade();
    
			// This is gives a tool tip for each
			// of the columns to sort by.
			uiFacade.SetHeaderToolTip(e);
    
    
			// This sets a class for the link buttons in a grid.
			uiFacade.SetGridLinkButtonStyle(e);
    
			// Make the row change color when the mouse hovers over.
			// *** You must have a class called gridHover with a different background 
			// color in your StyleSheet.
			uiFacade.SetRowHover(this.dgMethod, e);*/
		}
        protected void lbtnClose_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.close();</script>");
        }
}
}