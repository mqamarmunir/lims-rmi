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
	/// Summary description for wfrmTestAttribute.
	/// </summary>
	public partial class wfrmTestAttribute : System.Web.UI.Page
	{

		private static string mode = "";
		private static string AttributeID = "";
		private static string DGSort = "";
		private static string ProcedureID = "";
        private static string old_Acronym = "";
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{				
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "003";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					mode = "Insert";
					DGSort = "DOrder";
					EnableForm(false);
					this.ddlTestGroup.Enabled = false;
					this.ddlTest.Enabled = false;
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
			this.ibtnAttributeRanges.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAttributeRanges_Click);
			this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
			this.dgTestAtt.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTestAtt_ItemCreated);
			this.dgTestAtt.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTestAtt_ItemCommand);
			this.dgTestAtt.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTestAtt_EditCommand);

		}
		#endregion

		private void EnableForm(bool enable)
		{
			this.chkActive.Enabled = enable;
			this.txtTestAttribute.Enabled = enable;
			this.txtAcronym.Enabled = enable;
			this.ddlType.Enabled = enable;
			this.ibtnSave.Enabled = enable;
			this.ddlSMline.Enabled = enable;
            this.interpretation_Rtext.Enabled = enable;
            this.ddlAttributeType.Enabled = enable;
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);

			if(dvSection.Count > 0)
			{
				objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID");
			}
			else
			{
				this.lblErrMsg.Text = "No Section found";
			}
		}

		private void FillTestGroupDDL(string sectionID, string active)
		{
			clsBLTestGroup objTestG = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTestG.SectionID = sectionID;
			objTestG.Active = active;
			DataView dvTestG = objTestG.GetAll(4);

			if(dvTestG.Count > 0)
			{
				objComp.FillDropDownList(this.ddlTestGroup, dvTestG, "TestGroup", "TestGroupID");
			}
			else
			{
				this.lblErrMsg.Text = "No Test Group found";
			}
		}

		private void FillTestDDL(string sectionID, string testGroupID, string active)
		{
			clsBLTest objTest = new clsBLTest();
			SComponents objComp = new SComponents();

			objTest.SectionID = sectionID;
			objTest.TestGroupID = testGroupID;
			objTest.Active = active;
			DataView dvTest = objTest.GetAll(2);

			if(dvTest.Count > 0)
			{
				objComp.FillDropDownList(this.ddlTest, dvTest, "Test", "TestID");
			}
			else
			{
				this.lblErrMsg.Text = "No Test found";
			}
		}

		private void FillDG()
		{
			clsBLTestAttribute objTestA = new clsBLTestAttribute();

			objTestA.SectionID = this.ddlSection.SelectedItem.Value;
			objTestA.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTestA.TestID = this.ddlTest.SelectedItem.Value;
			DataView dvTestA = objTestA.GetAll(1);

			if(dvTestA.Count > 0)
			{
				this.dgTestAtt.DataSource = dvTestA;
                this.popupgridAttributes.DataSource = dvTestA;
				this.dgTestAtt.DataBind();
                this.popupgridAttributes.DataBind();

				this.dgTestAtt.Visible = true;
			}
			else
			{
				this.lblErrMsg.Text = "No Test Attribute found";
				this.dgTestAtt.Visible = false;
			}
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(this.ddlSection.SelectedItem.Value != "-1")
			{
				FillTestGroupDDL(this.ddlSection.SelectedItem.Value, "Y");
				this.ddlTestGroup.Enabled = true;
				this.ddlTest.Enabled = false;
			}
			else
			{
				this.ddlTestGroup.Enabled = false;
				this.ddlTest.Enabled = false;

			}

			EnableForm(false);
			this.dgTestAtt.Visible = false;
		}

		protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(this.ddlTestGroup.SelectedItem.Value != "-1")
			{
				FillTestDDL(this.ddlSection.SelectedItem.Value, this.ddlTestGroup.SelectedItem.Value, "Y");
				this.ddlTest.Enabled = true;
			}
			else
			{
				this.ddlTest.Enabled = false;
			}

			EnableForm(false);
			this.dgTestAtt.Visible = false;
		}

		protected void ddlTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(this.ddlTest.SelectedItem.Value != "-1")
			{
				FillDG();
				EnableForm(true);
			}
			else
			{
				EnableForm(false);
				this.dgTestAtt.Visible = false;
			}
		}

		private void dgTestAtt_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			FillForm(e.Item.ItemIndex);
			this.ibtnSave.ToolTip = "Update";
		}

		private void FillForm(int index)
		{
            this.lnkupdteAcronym.Visible = true;
            this.lnkupdteAcronym.CommandName = "Edit";
            this.lnkupdteAcronym.Text = "Update Acronym";
			this.chkActive.Checked = ((CheckBox)this.dgTestAtt.Items[index].Cells[3].FindControl("dgchkActive")).Checked;
			this.txtTestAttribute.Text = this.dgTestAtt.Items[index].Cells[1].Text.Replace("&nbsp;", "");
			this.txtAcronym.Text = this.dgTestAtt.Items[index].Cells[2].Text.Replace("&nbsp;", "");
            this.txtAcronym.Enabled = false;
            old_Acronym = this.dgTestAtt.Items[index].Cells[2].Text.Replace("&nbsp;", "");
			this.ddlType.SelectedItem.Selected = false;
			this.ddlType.Items.FindByValue(this.dgTestAtt.Items[index].Cells[5].Text).Selected = true;
			AttributeID = this.dgTestAtt.Items[index].Cells[0].Text;
			ProcedureID = this.dgTestAtt.Items[index].Cells[6].Text;
			this.ddlSMline.SelectedItem.Selected = false;
			this.ddlSMline.Items.FindByValue(this.dgTestAtt.Items[index].Cells[8].Text).Selected = true;
			this.chkReport.Checked = (this.dgTestAtt.Items[index].Cells[7].Text == "Y");
            this.interpretation_Rtext.Text = dgTestAtt.Items[index].Cells[12].Text;
			this.ddlReportCol.SelectedItem.Selected = false;
			this.ddlReportCol.Items.FindByValue(this.dgTestAtt.Items[index].Cells[10].Text).Selected = true;
            this.chkSummary.Checked = (this.dgTestAtt.Items[index].Cells[11].Text == "Y");
            this.ddlAttributeType.ClearSelection();
            if (this.dgTestAtt.Items[index].Cells[13].Text.Trim() == "N")
            {
                this.ddlAttributeType.Items.FindByValue("0").Selected = true;
                this.chkCount.Enabled = true;

            }
            else if (this.dgTestAtt.Items[index].Cells[13].Text.Trim() == "T")
            {
                this.ddlAttributeType.Items.FindByValue("1").Selected = true;
                this.chkCount.Enabled = false;
            }
            else
            {
                this.ddlAttributeType.ClearSelection();
            }

            this.chkCount.Checked = (this.dgTestAtt.Items[index].Cells[14].Text == "Y");
            if (dgTestAtt.Items[index].Cells[14].Text == "Y")
            {
                txtCountValue.Enabled = true;
                clsBLTest objTest = new clsBLTest();
                objTest.TestID = ddlTest.SelectedValue.ToString();
                DataView dv_countvalue = objTest.GetAll(9);
                if (dv_countvalue.Count > 0)
                {
                    txtCountValue.Text = dv_countvalue[0]["Attribute_Count"].ToString();
                }

            }
            else 
            {
                txtCountValue.Enabled = false;
            }

            this.chkDerived.Checked = (this.dgTestAtt.Items[index].Cells[15].Text == "Y");
            if (dgTestAtt.Items[index].Cells[15].Text == "Y")
            {
                tblderivedfield.Visible = true;
                //txtFormula.Visible = true;
                //lblFormula.Visible = true;
                clsBLDerivedAttributes objDerived = new clsBLDerivedAttributes();
                objDerived.AttributeID = AttributeID;
                DataView dv_derivedData = objDerived.GetAll(1);
                if (dv_derivedData.Count > 0)
                {
                    txtFormula.Text = dv_derivedData[0]["Formula"].ToString();
                    txtDescription.Text = dv_derivedData[0]["Description"].ToString();
                    txtFmlValue.Text = dv_derivedData[0]["GenderValue_F"].ToString();
                    txtMlValue.Text = dv_derivedData[0]["GenderValue_M"].ToString();
                    if (txtMlValue.Text != "" && txtFmlValue.Text != "")
                    {
                        txtMlValue.Enabled = true;
                        txtFmlValue.Enabled = true;

                    }
                    else
                    {
                        txtMlValue.Enabled = false;
                        txtFmlValue.Enabled = false;
                    }



                }
                dv_derivedData.Dispose();
            }

            else
            {
                tblderivedfield.Visible = false;

                //lblFormula.Visible = false;
                //txtFormula.Visible = false;

            }

			mode = "Update";
		}

		private void InsertTestAtt()
		{
			clsBLTestAttribute objTestAtt = new clsBLTestAttribute();

			objTestAtt.SectionID = this.ddlSection.SelectedItem.Value;
			objTestAtt.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTestAtt.TestID = this.ddlTest.SelectedItem.Value;
			objTestAtt.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objTestAtt.Attribute = this.txtTestAttribute.Text;
			objTestAtt.Acronym = this.txtAcronym.Text;
			objTestAtt.InputType = this.ddlType.SelectedItem.Value;
			objTestAtt.RPrint = (this.chkReport.Checked == true) ? "Y" : "N";
			objTestAtt.SMLine = this.ddlSMline.SelectedItem.Value;
			objTestAtt.RDISCOL = this.ddlReportCol.SelectedItem.Value;
            objTestAtt.Summary = this.chkSummary.Checked ? "Y" : "N";
            objTestAtt.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTestAtt.Enteredby = Session["loginid"].ToString();
            string _Attribute_interpretation = interpretation_Rtext.Text;
            _Attribute_interpretation = _Attribute_interpretation.Replace("<strong>", "<b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</strong>", "</b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("<em>", "<i>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</em>", "</i>");
            //objTestAtt.Attribute_Interpretation = interpretation_Rtext.Text;
            objTestAtt.Attribute_Interpretation = _Attribute_interpretation;
            objTestAtt.AttributeType = ddlAttributeType.SelectedValue.ToString() == "0" ? "N" : "T";
            objTestAtt.AttributeCount = (this.chkCount.Checked == true) ? "Y" : "N";
            objTestAtt.AttributeCountValue = txtCountValue.Text;
            objTestAtt.DerivedAttribute = (this.chkDerived.Checked == true) ? "Y" : "N";
			bool isSuccessful = true;

			isSuccessful = objTestAtt.Insert();

            if (isSuccessful)
            {
                if (this.chkDerived.Checked == true)
                {
                    clsBLDerivedAttributes obj_DerivedAttributes = new clsBLDerivedAttributes();
                    DataView dv_AttributeID = objTestAtt.GetAll(7);
                    obj_DerivedAttributes.AttributeID = dv_AttributeID[0]["AttributeID"].ToString();
                   // dv_AttributeID.Dispose();
                    obj_DerivedAttributes.AttributeName = txtTestAttribute.Text;
                    obj_DerivedAttributes.Formula = txtFormula.Text;
                    obj_DerivedAttributes.Description = txtDescription.Text;
                    if (txtMlValue.Text != "" && txtFmlValue.Text != "")
                    {
                        obj_DerivedAttributes.MlValue = txtMlValue.Text;
                        obj_DerivedAttributes.FmlValue = txtFmlValue.Text;
                    }
                    obj_DerivedAttributes.TestID = ddlTest.SelectedValue.ToString();
                    obj_DerivedAttributes.EnteredBy = Session["loginid"].ToString();
                    obj_DerivedAttributes.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_DerivedAttributes.ClientID = "0005";
                    if (obj_DerivedAttributes.insert())
                    {
                        DataView dv_DerivedID = obj_DerivedAttributes.GetAll(2);
                        clsBLDerivedAttributesD obj_DerivedAttributesD = new clsBLDerivedAttributesD();
                        obj_DerivedAttributesD.TestID = ddlTest.SelectedValue.ToString();
                        obj_DerivedAttributesD.DerivedID = dv_DerivedID[0]["DerivedID"].ToString();
                        obj_DerivedAttributesD.AttributeID = dv_AttributeID[0]["AttributeID"].ToString();
                        dv_AttributeID.Dispose();
                        dv_DerivedID.Dispose();
                        obj_DerivedAttributesD.EnteredBy = Session["loginid"].ToString();
                        obj_DerivedAttributesD.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                        obj_DerivedAttributesD.ClientID = "0005";
                        obj_DerivedAttributesD.Status = "A";
                        string[] variable_names = hdVariableNames.Value.ToString().Split(',');
                        string[] variable_locations = hdlocations.Value.ToString().Split(',');
                        string[] variable_types = hdVariableTypes.Value.ToString().Split(',');
                        int count_inserts = 0;
                        for (int i = 0; i < variable_locations.Length; i++)
                        {
                            obj_DerivedAttributesD.VariableName = variable_names[i].ToString();
                            obj_DerivedAttributesD.Location = variable_locations[i].ToString();
                            obj_DerivedAttributesD.Type = variable_types[i].ToString();
                            if (obj_DerivedAttributesD.insert())
                            {
                                count_inserts++;
                            }

                        }
                        if (count_inserts == variable_types.Length)
                        {

                            this.lblErrMsg.Text = "<font color='Green'>Record has been inserted successfully</font>";
                            RefreshForm();
                            FillDG();
                        }
                        else
                        {
                            this.lblErrMsg.Text="<font color='Green'>Test Attribute and Attribute Formula inserted successfully but the Following Error occured in Formula Variable Entry</font><br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                            RefreshForm();
                            FillDG();
                        }

                    }
                    else
                    {
                        this.lblErrMsg.Text = "<font color='Green'>Only TestAttribute successfully inserted, the following error occured while inserting Derived Attribute Formula</font> <br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                        RefreshForm();
                        FillDG();
                    }

                }
                else
                {
                    this.lblErrMsg.Text = "<font color='Green'>Record has been inserted successfully</font>";
                    RefreshForm();
                    FillDG();
                }
            }
            else
            {
                this.lblErrMsg.Text = objTestAtt.ErrorMessage;
            }
            interpretation_Rtext.Text = "";
		}

		private void UpdateTestAtt()
		{
			clsBLTestAttribute objTestAtt = new clsBLTestAttribute();

			objTestAtt.AttributeID = AttributeID;
			objTestAtt.SectionID = this.ddlSection.SelectedItem.Value;
			objTestAtt.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTestAtt.TestID = this.ddlTest.SelectedItem.Value;
			objTestAtt.Active = (this.chkActive.Checked == true) ? "Y" : "N";
			objTestAtt.Attribute = this.txtTestAttribute.Text;
			objTestAtt.Acronym = this.txtAcronym.Text;

            //string Acronym_new = this.txtAcronym.Text.Replace("&nbsp;", "");
            //if (old_Acronym != Acronym_new)
            //{
            //    clsBLDerivedAttributes obj_DerivedAttributes = new clsBLDerivedAttributes();
            //    DataView dv_gettestAttributes="";
                
            //}

            
			objTestAtt.InputType = this.ddlType.SelectedItem.Value;
			objTestAtt.ProcedureID = ProcedureID;
			objTestAtt.RPrint = (this.chkReport.Checked == true) ? "Y" : "N";
			objTestAtt.SMLine = this.ddlSMline.SelectedItem.Value;
			objTestAtt.RDISCOL = this.ddlReportCol.SelectedItem.Value;
            objTestAtt.Summary = this.chkSummary.Checked ? "Y" : "N";
            objTestAtt.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            objTestAtt.Enteredby = Session["loginid"].ToString();

            string _Attribute_interpretation = interpretation_Rtext.Text;
            _Attribute_interpretation = _Attribute_interpretation.Replace("<strong>", "<b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</strong>", "</b>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("<em>", "<i>");
            _Attribute_interpretation = _Attribute_interpretation.Replace("</em>", "</i>");
            //objTestAtt.Attribute_Interpretation = interpretation_Rtext.Text;
            objTestAtt.Attribute_Interpretation = _Attribute_interpretation;
            objTestAtt.AttributeType = ddlAttributeType.SelectedValue.ToString() == "0" ? "N" : "T";
			bool isSuccessful = true;
            objTestAtt.AttributeCount = (this.chkCount.Checked == true) ? "Y" : "N";
            objTestAtt.AttributeCountValue = txtCountValue.Text;
            objTestAtt.DerivedAttribute = (this.chkDerived.Checked == true) ? "Y" : "N";
          
            

			isSuccessful = objTestAtt.Update();

            if (isSuccessful)
            {
                if (this.chkDerived.Checked == true)
                {
                    clsBLDerivedAttributes obj_DerivedAttributes = new clsBLDerivedAttributes();
                    // DataView dv_AttributeID = objTestAtt.GetAll(7);
                    obj_DerivedAttributes.AttributeID = AttributeID;

                    obj_DerivedAttributes.AttributeName = txtTestAttribute.Text;
                    obj_DerivedAttributes.Formula = txtFormula.Text;
                    obj_DerivedAttributes.Description = txtDescription.Text;
                    if (txtMlValue.Text != "" && txtFmlValue.Text != "")
                    {
                        obj_DerivedAttributes.MlValue = txtMlValue.Text;
                        obj_DerivedAttributes.FmlValue = txtFmlValue.Text;
                    }
                    obj_DerivedAttributes.TestID = ddlTest.SelectedValue.ToString();

                    obj_DerivedAttributes.EnteredBy = Session["loginid"].ToString();
                    obj_DerivedAttributes.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    obj_DerivedAttributes.ClientID = "0005";
                    if (obj_DerivedAttributes.Update())
                    {
                        DataView dv_DerivedID = obj_DerivedAttributes.GetAll(1);
                        clsBLDerivedAttributesD obj_DerivedAttributesD = new clsBLDerivedAttributesD();
                      
                        if (hdlocations.Value.ToString() != "")
                        {
                          
                            obj_DerivedAttributesD.DerivedID = dv_DerivedID[0]["DerivedID"].ToString();

                            if (obj_DerivedAttributesD.delete())
                            {
                                obj_DerivedAttributesD.DerivedID = dv_DerivedID[0]["DerivedID"].ToString();
                                obj_DerivedAttributesD.AttributeID = AttributeID;
                                obj_DerivedAttributesD.TestID = ddlTest.SelectedValue.ToString();

                                dv_DerivedID.Dispose();
                                obj_DerivedAttributesD.EnteredBy = Session["loginid"].ToString();
                                obj_DerivedAttributesD.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                                obj_DerivedAttributesD.ClientID = "0005";
                                string[] variable_names = hdVariableNames.Value.ToString().Split(',');
                                string[] variable_locations = hdlocations.Value.ToString().Split(',');
                                string[] variable_types = hdVariableTypes.Value.ToString().Split(',');
                                int count_inserts = 0;
                                for (int i = 0; i < variable_locations.Length; i++)
                                {
                                    obj_DerivedAttributesD.VariableName = variable_names[i].ToString();
                                    obj_DerivedAttributesD.Location = variable_locations[i].ToString();
                                    obj_DerivedAttributesD.Type = variable_types[i].ToString();
                                    if (obj_DerivedAttributesD.insert())
                                    {
                                        count_inserts++;
                                    }

                                }
                                if (count_inserts == variable_types.Length)
                                {

                                    this.lblErrMsg.Text = "<font color='Green'>Record has been Updated successfully</font>";
                                    RefreshForm();
                                    ibtnSave.ToolTip = "Save";
                                    FillDG();
                                }

                                else
                                {
                                    this.lblErrMsg.Text = "<font color='Green'>Test Attribute and Attribute Formula updated successfully but the Following Error occured in Formula Variable Entry</font><br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                                    RefreshForm();
                                    ibtnSave.ToolTip = "Save";
                                    FillDG();
                                }
                            }
                            else
                            {
                                lblErrMsg.Text = "Unable to Delete the Records";
                            }


                        }
                        else
                        {
                            this.lblErrMsg.Text = "<font color='Green'>Record has been Updated successfully</font>";
                            RefreshForm();
                            this.ibtnSave.ToolTip = "Save";
                            FillDG();
                        }

                    }
                    else
                    {
                        this.lblErrMsg.Text = "<font color='Green'>TestAttribute successfully updated but the following error occured while updating Derived Attribute Formula Entry</font> <br /><font color='Red'>" + obj_DerivedAttributes.ErrorMessage + "</font>";
                        RefreshForm();
                        ibtnSave.ToolTip = "Save";
                        FillDG();

                    }

                    
                }
                else
                {
                    this.lblErrMsg.Text = "<font color='Green'>Record has been Updated successfully</font>";
                    RefreshForm();
                    this.ibtnSave.ToolTip = "Save";
                    FillDG();
                }
            }
            else
            {
                this.lblErrMsg.Text = objTestAtt.ErrorMessage;
            }
            interpretation_Rtext.Text = "";
		}

		private void RefreshForm()
		{
			this.chkActive.Checked = true;
			this.txtTestAttribute.Text = "";
			this.txtAcronym.Text = "";
            this.chkSummary.Checked = false;
			mode = "Insert";
			AttributeID = "";
			ProcedureID = "";
            this.txtCountValue.Text = "";
            this.chkCount.Enabled = false;
            this.ddlAttributeType.ClearSelection();
            tblderivedfield.Visible = false;
            //this.txtFormula.Visible = false;
            //this.lblFormula.Visible = false;
            this.chkDerived.Checked = false;
            this.txtFormula.Text = "";
            this.txtDescription.Text = "";
            this.txtFmlValue.Text = "";
            this.txtMlValue.Text = "";
            this.txtMlValue.Enabled = false;
            this.txtFmlValue.Enabled = false;

            this.lnkupdteAcronym.CommandName = "Edit";
            this.lnkupdteAcronym.Text = "Update Acronym";
            this.lnkupdteAcronym.Visible = false;
        }

		private void dgTestAtt_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{				
				clsBLTestAttribute objTestAtt = new clsBLTestAttribute();

				objTestAtt.AttributeID = e.Item.Cells[0].Text;		
				objTestAtt.Active = "D";				
				bool isSuccessful = true;

				isSuccessful = objTestAtt.Delete();

				if(isSuccessful)
				{
					this.lblErrMsg.Text = "<font color='Green'>Record has been Updated successfully</font>";
					RefreshForm();				
					FillDG();
				}
				else
				{
					this.lblErrMsg.Text = objTestAtt.ErrorMessage;
				}
			}
		}

		private void dgTestAtt_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			uiFacade.SetRowHover(this.dgTestAtt, e);
		}

		private void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(mode.Equals("Insert"))
			{
				InsertTestAtt();
			}
			else
			{
				UpdateTestAtt();

			}
		}

		private void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblErrMsg.Text = "";
			RefreshForm();
			this.ibtnSave.ToolTip = "Save";
            interpretation_Rtext.Text = "";
            lnkupdteAcronym.Visible = false;
            lnkupdteAcronym.Text = "Update Acronym";
            lnkupdteAcronym.CommandName = "Edit";
		}

		private void ibtnAttributeRanges_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language = 'javascript'>window.open('wfrmAttributeRange.aspx','','fullscreen')</script>");						
		}

		private void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");			
		}

		protected void ddlType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lbtnSelectionValues.Visible = (ddlType.SelectedValue.Equals("1"));		
			lbtnSelectionValues.Visible = (!AttributeID.Equals(""));
		}

		protected void lbtnSelectionValues_Click(object sender, System.EventArgs e)
		{
			if (!AttributeID.Equals(""))
			Response.Write("<script language = 'javascript'>window.open('wfrmAttributrSelection.aspx?AttributeID="+AttributeID+"','','')</script>");
		}
        protected void ibtnSave_Click1(object sender, ImageClickEventArgs e)
        {

        }
        protected void ibtnClear_Click1(object sender, ImageClickEventArgs e)
        {

        }
        protected void chkCount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCount.Checked == true)
            {
                txtCountValue.Enabled = true;
            }
            else
            {
                txtCountValue.Enabled = false;
            }
        }
        protected void ddlAttributeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAttributeType.SelectedItem.Text == "Numeric")
            {
                chkCount.Enabled = true;
            }
            else
            {
                chkCount.Enabled = false;
            }
        }
        protected void chkDerived_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDerived.Checked)
            {
                tblderivedfield.Visible = true;


            }
            else
            {
                tblderivedfield.Visible = false;
                //lblFormula.Visible = false;
                //txtFormula.Visible = false;
            }
        }

        protected void lnkbtnupdateAcronym_Click(object sender, EventArgs e)
        {
            if (lnkupdteAcronym.CommandName == "Edit")
            {
                txtAcronym.Enabled = true;
                old_Acronym = txtAcronym.Text;
                lnkupdteAcronym.Text = "Save";
                lnkupdteAcronym.CommandName = "UpdateAcronym";
            }

            else if (lnkupdteAcronym.CommandName == "UpdateAcronym")
            {
                clsBLTestAttribute obj_TAttribute = new clsBLTestAttribute();
                obj_TAttribute.AttributeID = AttributeID;
                obj_TAttribute.Acronym = txtAcronym.Text;
                int countFormula = 0;
                int countupdateAcronym = 0;
                if (obj_TAttribute.Update())
                {
                    clsBLDerivedAttributes objDerived = new clsBLDerivedAttributes();
                    objDerived.TestID = ddlTest.SelectedValue.ToString();
                    DataView dv_updte = objDerived.GetAll(3);
                    if (dv_updte.Count > 0)
                    {
                        for (int i = 0; i < dv_updte.Count; i++)
                        {
                            string Frmulae = dv_updte[i]["Formula"].ToString();
                            string DerivedID = dv_updte[i]["DerivedID"].ToString();

                            Frmulae = Frmulae.Replace(old_Acronym.ToUpper(), txtAcronym.Text.ToUpper());
                            objDerived.DerivedID = DerivedID;
                            objDerived.Formula = Frmulae;
                            if (objDerived.Update())
                            {
                                countFormula++;
                            }
                        }

                        if (countFormula == dv_updte.Count)
                        {
                            //dv_updte.Dispose();
                            clsBLDerivedAttributesD obj_derivedd = new clsBLDerivedAttributesD();
                            obj_derivedd.TestID = ddlTest.SelectedValue.ToString();
                            DataView dv_upted = obj_derivedd.GetAll(2);
                            if (dv_upted.Count > 0)
                            {
                                for (int i = 0; i < dv_upted.Count; i++)
                                {
                                    string DetailDerivedID = dv_upted[i]["DETAILDERIVEID"].ToString();
                                    string Variable = dv_upted[i]["VariableName"].ToString();
                                    Variable = Variable.Replace(old_Acronym.ToUpper(), txtAcronym.Text.ToUpper());
                                    obj_derivedd.DetailDerivedID = DetailDerivedID;
                                    obj_derivedd.VariableName = Variable;
                                    if (obj_derivedd.updateAcronym())
                                    {
                                        countupdateAcronym++;
                                    }
                                }
                                if (countFormula == dv_updte.Count && countupdateAcronym == dv_upted.Count)
                                {
                                    dv_updte.Dispose();
                                    dv_upted.Dispose();
                                    lblErrMsg.Text = "<font color='Green'>All formulas related to Acronym (" + old_Acronym + ") replaced with Acronym(" + txtAcronym.Text + ")</font>";
                                    FillDG();
                                    RefreshForm();
                                }
                                else
                                {
                                    lblErrMsg.ForeColor = Color.Green;
                                    lblErrMsg.Text = "<font color='Green'>Acronym Updated But the Following error occured while updating Formulas relaed to this Acronym</font><br /><font Color='Red'>" + obj_derivedd.ErrorMessage + "</font>";
                                    FillDG();
                                    RefreshForm();
                                }

                            }

                            //lblErrMsg.Text = "<font color='Green'>All formulas related to Acronym (" + old_Acronym + ") replaced with Acronym(" + txtAcronym.Text + ")</font>";
                            //FillDG();
                            //RefreshForm();
                        }
                        else
                        {
                            lblErrMsg.ForeColor = Color.Green;
                            lblErrMsg.Text = "<font color='Green'>Acronym Updated But the Following error occured while updating Formulas related to this Acronym</font><br /><font Color='Red'>" + objDerived.ErrorMessage + "</font>";
                            FillDG();
                            RefreshForm();
                        }

                    }
                    else
                    {
                        lblErrMsg.Text = "<font color='Green'>Attribute Acronym Updated Successfully.</font>";
                        FillDG();
                        RefreshForm();
                    }
                    
                }
                else
                {
                    lblErrMsg.ForeColor = Color.Red;
                    lblErrMsg.Text = obj_TAttribute.ErrorMessage;
                }

            }
        }
        protected void popupsave_Click(object sender, ImageClickEventArgs e)
        {
            clsBLTestAttribute obj_Attrib = new clsBLTestAttribute();
            string numericattributes = "";
            string textattributes = "";
            foreach (GridViewRow dr in popupgridAttributes.Rows)
            {
                if ((popupgridAttributes.Rows[dr.RowIndex].Cells[2].FindControl("gvpopchknumeric") as CheckBox).Checked == true)
                {
                    numericattributes += popupgridAttributes.DataKeys[dr.RowIndex].Values["AttributeID"].ToString() + ",";
                }
                else
                {
                    textattributes += popupgridAttributes.DataKeys[dr.RowIndex].Values["AttributeID"].ToString() + ",";
                }
            }
            numericattributes += "'~!@'";
            textattributes += "'~!@'";

            obj_Attrib.NumericAttributeIDs = numericattributes;
            obj_Attrib.TextAttributeIDs = textattributes;
            obj_Attrib.TestID = ddlTest.SelectedValue.ToString().Trim();

            if (obj_Attrib.updateattribType())
            {
                FillDG();
                lblErrMsg.Text = "<font color='green'>Updates Successful.</font>";
            }



        }
        protected void popupclose_Click(object sender, ImageClickEventArgs e)
        {

        }
        protected void lnkupdateType_Click(object sender, EventArgs e)
        {
          //  FillgvAttributesType();
        }

        protected void popgridAttributes_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (popupgridAttributes.DataKeys[e.Row.RowIndex].Values["AttributeType"].ToString().Trim() == "N")
                {
                    (e.Row.Cells[2].FindControl("gvpopchknumeric") as CheckBox).Checked = true;
                    e.Row.BackColor = System.Drawing.Color.Cyan;
                }

            }
        }

        protected void dTgTestAtt_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[13].Text.Trim() == "N")
                {
                    e.Item.BackColor = System.Drawing.Color.Cyan;
                }
            }
        }


        protected void ibtnSave_Click2(object sender, ImageClickEventArgs e)
        {

        }
}
}