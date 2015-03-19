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
	/// Summary description for wfrmAttributeRange.
	/// </summary>
	public partial class wfrmAttributeRange : System.Web.UI.Page
	{		
		protected System.Web.UI.WebControls.LinkButton lbtnClearAll;

		private static string Mode = "";
		protected static string focusElement = "";
		private static string DGSort = "";
		private static string TransID = "";

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "004";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					this.lblErrMsg.Text = "";
					Mode = "Insert";
					focusElement = this.ddlSection.ID.ToString();
					DGSort = "TransID";
					TransID = "";
					FillSectionDDL();
					EnableForm(false);
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
			this.ibtnClear.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClear_Click);
			this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
			this.dgAttRange.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgAttRange_ItemCreated);
			this.dgAttRange.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgAttRange_ItemCommand);
			this.dgAttRange.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgAttRange_EditCommand);

		}
		#endregion

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID");
		}

		private void EnableForm(bool enable)
		{
			this.ddlTestGroup.Enabled = enable;
			this.ddlTest.Enabled = enable;
			this.ddlTestAttribute.Enabled = enable;
			this.ddlMethod.Enabled = enable;
			this.ddlSex.Enabled = enable;
			this.ddlMinMaxAgeType.Enabled = enable;
			this.txtAgeMin.Enabled = enable;
			this.txtAgeMax.Enabled = enable;
			this.txtUnit.Enabled = enable;
			this.txtMinValue.Enabled = enable;
			this.txtMaxValue.Enabled = enable;
			this.ibtnSave.Enabled = enable;
            this.txtAutomatedText2.Enabled = enable;
            this.txtAutomatedText3.Enabled = enable;
            this.txtAutomatedText4.Enabled = enable;
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			EnableForm(false);
			this.dgAttRange.Visible = false;
			focusElement = this.ddlSection.ID.ToString();

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				FillTestGroupDDL();
				this.ddlTestGroup.Enabled = true;
			}
			else
			{
				try{	this.ddlTestGroup.Items.Clear();	}
				catch{}

				try{	this.ddlTest.Items.Clear();	}
				catch{}

				try{	this.ddlTestAttribute.Items.Clear();	}
				catch{}
			}
		}

		private void FillTestGroupDDL()
		{
			clsBLTestGroup objTestG = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTestG.SectionID = this.ddlSection.SelectedItem.Value;
			objTestG.Active = "Y";
			DataView dvTestG = objTestG.GetAll(4);
			objComp.FillDropDownList(this.ddlTestGroup, dvTestG, "TestGroup", "TestGroupID");
		}

		protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			EnableForm(false);
			this.dgAttRange.Visible = false;
			focusElement = this.ddlTestGroup.ID.ToString();

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				FillTestDDL();
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = true;
			}
			else
			{
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = false;

				try{	this.ddlTest.Items.Clear();	}
				catch{}

				try{	this.ddlTestAttribute.Items.Clear();	}
				catch{}
			}
		}

		private void FillTestDDL()
		{
			clsBLTest objTest = new clsBLTest();
			SComponents objComp = new SComponents();

			objTest.SectionID = this.ddlSection.SelectedItem.Value;
			objTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTest.Active = "Y";
			DataView dvTest = objTest.GetAll(2);
			objComp.FillDropDownList(this.ddlTest, dvTest, "Test", "TestID");
		}

		protected void ddlTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			EnableForm(false);
			this.dgAttRange.Visible = false;
			focusElement = this.ddlTest.ID.ToString();

			if(!this.ddlTest.SelectedItem.Value.Equals("-1"))
			{
				FillTestAttDDL();
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = true;
				this.ddlTestAttribute.Enabled = true;
			}
			else
			{
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = true;
				this.ddlTestAttribute.Enabled = false;

				try{	this.ddlTestAttribute.Items.Clear();	}
				catch{}
			}
		}

		private void FillTestAttDDL()
		{
			clsBLTestAttribute objTestAtt = new clsBLTestAttribute();
			SComponents objComp = new SComponents();

			objTestAtt.SectionID = this.ddlSection.SelectedItem.Value;
			objTestAtt.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTestAtt.TestID = this.ddlTest.SelectedItem.Value;
			objTestAtt.Active = "Y";
			DataView dvTestAtt = objTestAtt.GetAll(2);
			objComp.FillDropDownList(this.ddlTestAttribute, dvTestAtt, "Attribute", "AttributeID");
		}

		protected void ddlTestAttribute_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			focusElement = this.ddlTestAttribute.ID.ToString();

			if(!this.ddlTestAttribute.SelectedItem.Value.Equals("-1"))
			{
				EnableForm(true);
				this.dgAttRange.Visible = true;
				FillMethodDDL();
                this.interpretation_Rtext.Enabled = true;
				FillDG();
			}
			else
			{
				EnableForm(false);
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = true;
				this.ddlTestAttribute.Enabled = true;
				this.dgAttRange.Visible = false;
                this.interpretation_Rtext.Enabled = false;
			}
		}

		private void FillMethodDDL()
		{
			clsBLMethod objMethod = new clsBLMethod();
			SComponents objComp = new SComponents();

			objMethod.SectionID = this.ddlSection.SelectedItem.Value;
			DataView dvMethod = objMethod.GetAll(3);
			objComp.FillDropDownList(this.ddlMethod, dvMethod, "Method", "MethodID");
		}

		private void FillDG()
		{
			clsBLAttributeRange objAttRange = new clsBLAttributeRange();

			objAttRange.SectionID = this.ddlSection.SelectedItem.Value;
			objAttRange.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objAttRange.TestID = this.ddlTest.SelectedItem.Value;
			objAttRange.AttributeID = this.ddlTestAttribute.SelectedItem.Value;
			DataView dvAttRange = objAttRange.GetAll(1);

			if(dvAttRange.Count > 0)
			{
				dvAttRange.Sort = DGSort;
				this.dgAttRange.DataSource = dvAttRange;
				this.dgAttRange.DataBind();
				this.dgAttRange.Visible = true;
			}
			else
			{
				this.lblErrMsg.Text = "<br>No record found.<br><br>";
				this.dgAttRange.Visible = false;
			}
		}

		private void InsertRange()
		{
			clsBLAttributeRange objAttRange = new clsBLAttributeRange();
			
			objAttRange.SectionID = this.ddlSection.SelectedItem.Value;
			objAttRange.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objAttRange.TestID = this.ddlTest.SelectedItem.Value;
			objAttRange.AttributeID = this.ddlTestAttribute.SelectedItem.Value;
			objAttRange.MethodID = this.ddlMethod.SelectedItem.Value;
			objAttRange.Sex = this.ddlSex.SelectedItem.Value;
			objAttRange.AgeType = this.ddlMinMaxAgeType.SelectedItem.Value;
			objAttRange.AgeMin = this.txtAgeMin.Text;
			objAttRange.AgeMax = this.txtAgeMax.Text;
			objAttRange.AUnit = this.txtUnit.Text.Trim();
			objAttRange.MinValue = this.txtMinValue.Text;
			objAttRange.MaxValue = this.txtMaxValue.Text;
            objAttRange.MinPValue = this.txtMinPValue.Text;
            objAttRange.MaxPValue = this.txtMaxPValue.Text;
            objAttRange.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objAttRange.Enteredby = Session["loginid"].ToString();
            string _Attribute_interpretation = interpretation_Rtext.Text;
            _Attribute_interpretation = _Attribute_interpretation.Replace("<strong>", "<b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</strong>", "</b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("<em>", "<i>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</em>", "</i>");

            objAttRange.Interpretation = _Attribute_interpretation;
            if (chkmlinterpretation.Checked)
            {
                if (!txtAutomatedText2.Text.Trim().Equals(""))
                {
                    objAttRange.Interpretation2 = txtAutomatedText2.Text.Trim();
                }
                if (!txtAutomatedText3.Text.Trim().Equals(""))
                {
                    objAttRange.Interpretation3 = txtAutomatedText3.Text.Trim();
                }
                if (!txtAutomatedText4.Text.Trim().Equals(""))
                {

                    objAttRange.Interpretation4 = txtAutomatedText4.Text.Trim();
                }
            }
			if(objAttRange.Insert())
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
				RefreshForm();
				FillDG();
			}
			else
			{
				this.lblErrMsg.Text = "<br>" + objAttRange.ErrorMessage + "<br><br>";
			}

			focusElement = this.ddlMethod.ID.ToString();
		}

		private void UpdateRange()
		{
			clsBLAttributeRange objAttRange = new clsBLAttributeRange();

			objAttRange.TransID = TransID;
			objAttRange.MethodID = this.ddlMethod.SelectedItem.Value;
			objAttRange.Sex = this.ddlSex.SelectedItem.Value;
			objAttRange.AgeType = this.ddlMinMaxAgeType.SelectedItem.Value;
			objAttRange.AgeMin = this.txtAgeMin.Text;
			objAttRange.AgeMax = this.txtAgeMax.Text;
			objAttRange.AUnit = this.txtUnit.Text.Trim();
			objAttRange.MinValue = this.txtMinValue.Text;
			objAttRange.MaxValue = this.txtMaxValue.Text;
            objAttRange.MinPValue = this.txtMinPValue.Text;
            objAttRange.MaxPValue = this.txtMaxPValue.Text;
            objAttRange.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objAttRange.Enteredby = Session["loginid"].ToString();
            string _Attribute_interpretation = interpretation_Rtext.Text;
            _Attribute_interpretation = _Attribute_interpretation.Replace("<strong>", "<b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</strong>", "</b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("<em>", "<i>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</em>", "</i>");

            objAttRange.Interpretation = _Attribute_interpretation;
            if (chkmlinterpretation.Checked)
            {
                if (!txtAutomatedText2.Text.Trim().Equals(""))
                {
                    objAttRange.Interpretation2 = txtAutomatedText2.Text.Trim();
                }
                if (!txtAutomatedText3.Text.Trim().Equals(""))
                {
                    objAttRange.Interpretation3 = txtAutomatedText3.Text.Trim();
                }
                if (!txtAutomatedText4.Text.Trim().Equals(""))
                {

                    objAttRange.Interpretation4 = txtAutomatedText4.Text.Trim();
                }
            }
			if(objAttRange.Update())
			{
				this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
				RefreshForm();
				FillDG();
				this.ddlSection.Enabled = true;
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = true;
				this.ddlTestAttribute.Enabled = true;
				this.ibtnSave.ToolTip = "Save";
			}
			else
			{
				this.lblErrMsg.Text = "<br>" + objAttRange.ErrorMessage + "<br><br>";
			}

			focusElement = this.ddlMethod.ID.ToString();
		}

		private void RefreshForm()
		{
			this.txtAgeMax.Text = "";
			this.txtAgeMin.Text = "";
			this.txtMaxValue.Text = "";
			this.txtMinValue.Text = "";
			this.txtUnit.Text = "";
			Mode = "Insert";
			TransID = "";
            this.txtMaxPValue.Text = "";
            this.txtMinPValue.Text = "";
            chkmlinterpretation.Checked = false;
            txtAutomatedText2.Text = "";
            txtAutomatedText3.Text = "";
            txtAutomatedText4.Text = "";
		}

        protected void dgAttRange_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			focusElement = this.ddlMethod.ID.ToString();
			this.ibtnSave.ToolTip = "Update";
			Mode = "Update";
			FillForm(e.Item.ItemIndex);
			this.ddlSection.Enabled = false;
			this.ddlTestGroup.Enabled = false;
			this.ddlTest.Enabled = false;
			this.ddlTestAttribute.Enabled = false;
		}

		private void FillForm(int dgIndex)
		{
			this.ddlMethod.SelectedItem.Selected = false;
			this.ddlMethod.Items.FindByText(this.dgAttRange.Items[dgIndex].Cells[1].Text).Selected = true;

			this.ddlSex.SelectedItem.Selected = false;
			this.ddlSex.Items.FindByText(this.dgAttRange.Items[dgIndex].Cells[2].Text).Selected = true;

			this.ddlMinMaxAgeType.SelectedItem.Selected = false;

			string[] minAge = this.dgAttRange.Items[dgIndex].Cells[3].Text.Split(' ');
			this.ddlMinMaxAgeType.Items.FindByValue(minAge[1].Substring(0, 1)).Selected = true;
			this.txtAgeMin.Text = minAge[0];

			string[] maxAge = this.dgAttRange.Items[dgIndex].Cells[4].Text.Split(' ');
			this.txtAgeMax.Text = maxAge[0];

			this.txtUnit.Text = this.dgAttRange.Items[dgIndex].Cells[6].Text.Replace("&nbsp;", "");
			this.txtMinValue.Text = this.dgAttRange.Items[dgIndex].Cells[8].Text;
			this.txtMaxValue.Text = this.dgAttRange.Items[dgIndex].Cells[9].Text;
            this.txtMinPValue.Text = this.dgAttRange.Items[dgIndex].Cells[10].Text.Replace("&nbsp;", "");
            this.txtMaxPValue.Text = this.dgAttRange.Items[dgIndex].Cells[11].Text.Replace("&nbsp;", "");
            this.interpretation_Rtext.Text = this.dgAttRange.Items[dgIndex].Cells[13].Text.Trim();
            this.txtAutomatedText2.Text = this.dgAttRange.Items[dgIndex].Cells[14].Text.Trim();
            this.txtAutomatedText3.Text = this.dgAttRange.Items[dgIndex].Cells[15].Text.Trim();
            this.txtAutomatedText4.Text = this.dgAttRange.Items[dgIndex].Cells[16].Text.Trim();
			TransID = this.dgAttRange.Items[dgIndex].Cells[0].Text;
		}

        protected void dgAttRange_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{
				clsBLAttributeRange objAttRange = new clsBLAttributeRange();
				objAttRange.TransID = e.Item.Cells[0].Text;

				if(objAttRange.Delete())
				{
					this.lblErrMsg.Text = "<br><font color='Green'>Attribute Range is deleted successfully.</font><br><br>";
					RefreshForm();
					FillDG();
				}
				else
				{
					this.lblErrMsg.Text = "<br>" + objAttRange.ErrorMessage + "<br><br>";
				}
			}
		}

        protected void dgAttRange_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			uiFacade.SetRowHover(this.dgAttRange, e);
		}
        
        protected void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblErrMsg.Text = "";
			this.ibtnSave.ToolTip = "Save";
			RefreshForm();
			this.ddlSection.Enabled = true;
			this.ddlTestGroup.Enabled = true;
			this.ddlTest.Enabled = true;
			this.ddlTestAttribute.Enabled = true;
		}

        protected void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");			
		}
       
        protected void ibtnSave_Click1(object sender, ImageClickEventArgs e)
        {
            this.lblErrMsg.Text = "";

            if (Mode.Equals("Insert"))
            {
                InsertRange();
            }
            else
            {
                UpdateRange();
            }
        }
}
}