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
	/// Summary description for wfrmBatchedTests.
	/// </summary>
	public partial class wfrmBatchedTests : System.Web.UI.Page
	{

		protected static string focusElement = "";
		private static DataTable DTSelectedTests = null;
		private static DataTable DTUnSelectedTests = null;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "124";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
				
				if(!IsPostBack)
				{
					this.lblErrMsg.Text = "";
					EnableForm(false);
					FillSectionDDL();
					MakeDTs();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href = '../../login.aspx'</script>");
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
			this.dgTests.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgTests_ItemCreated);
			this.dgTests.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTests_ItemCommand);
			this.dgBatchTest.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBatchTest_ItemCreated);
			this.dgBatchTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgBatchTest_ItemCommand);

		}
		#endregion

		private void EnableForm(bool enable)
		{
			this.ddlTestGroup.Enabled = enable;
			this.lbtnSave.Enabled = enable;
			this.dgTests.Visible = enable;
			this.dgBatchTest.Visible = enable;
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			objComp.FillDropDownList(this.ddlSection, objSection.GetAll(1), "SectionName", "SectionID");
		}

		private void MakeDTs()
		{
			DTSelectedTests = new DataTable();
			DTSelectedTests.Columns.Add("TestID");
			DTSelectedTests.Columns.Add("Test");
			DTSelectedTests.Columns.Add("TestBatchNo");

			DTUnSelectedTests = new DataTable();
			DTUnSelectedTests.Columns.Add("TestID");
			DTUnSelectedTests.Columns.Add("Test");
			DTUnSelectedTests.Columns.Add("TestBatchNo");
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";
			EnableForm(false);

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				FillTestGroupDDL();
				this.ddlTestGroup.Enabled = true;
			}
			else
			{
				this.ddlTestGroup.Items.Clear();
			}

			try{	DTSelectedTests.Rows.Clear();	}
			catch{}

			try{	DTUnSelectedTests.Rows.Clear();	}
			catch{}
		}

		private void FillTestGroupDDL()
		{
			clsBLTestGroup objTGroup = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTGroup.SectionID = this.ddlSection.SelectedItem.Value;
			objTGroup.Active = "Y";
			objComp.FillDropDownList(this.ddlTestGroup, objTGroup.GetAll(4), "TestGroup", "TestGroupID");
		}

		protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			try{	DTSelectedTests.Rows.Clear();	}
			catch{}

			try{	DTUnSelectedTests.Rows.Clear();	}
			catch{}

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				FillTestDG();
				FillBatchedTestDG();
			}
			else
			{
				this.lbtnSave.Enabled = false;
				this.dgTests.Visible = false;
				this.dgBatchTest.Visible = false;
			}
		}

		private void FillTestDG()
		{
			clsBLTest objTest = new clsBLTest();

			objTest.SectionID = this.ddlSection.SelectedItem.Value;
			objTest.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
			objTest.Active = "Y";

			DataView dvTest = objTest.GetAll(2);
			this.dgTests.DataSource = dvTest;
			this.dgTests.DataBind();
			ColorizedDG(this.dgTests);

			if(dvTest.Count > 0)
			{			
				this.dgTests.Visible = true;
				this.lbtnSave.Enabled = true;
			}
			else
			{
				this.dgTests.Visible = false;
				this.lbtnSave.Enabled = false;
				this.lblErrMsg.Text = "<br>No Test found.<br><br>";
			}
		}

		private void FillBatchedTestDG()
		{
			this.dgBatchTest.DataSource = DTSelectedTests.DefaultView;
			this.dgBatchTest.DataBind();
			this.dgBatchTest.Visible = true;
			ColorizedDG(this.dgBatchTest);
		}

		private void ColorizedDG(DataGrid dg)
		{
			try
			{
				foreach(DataGridItem dgItem in dg.Items)
				{
					if((int.Parse(dgItem.Cells[2].Text) > 0))
					{
						dgItem.BackColor = Color.FromArgb(255, 252, 242);
					}
					else
					{
						dgItem.BackColor = Color.FromName("White");
					}
				}
			}
			catch{}
		}

		private void dgTests_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			this.dgTests.SelectedIndex = e.Item.ItemIndex;

			if(e.CommandName.Equals("Select"))
			{
				if((int.Parse(e.Item.Cells[2].Text) > 0))
				{
					bool isBatchPresent = false;

					foreach(DataRow drST in DTSelectedTests.Rows)
					{
						if((int.Parse(drST["TestBatchNo"].ToString()) > 0))
						{
							isBatchPresent = true;
							break;
						}
					}

					if(isBatchPresent)
					{
						bool isSameBatch = false;

						foreach(DataRow drST2 in DTSelectedTests.Rows)
						{
							if(drST2["TestBatchNo"].ToString() == e.Item.Cells[2].Text)
							{
								isSameBatch = true;
								break;
							}
						}

						if(isSameBatch)
						{
							bool isPresent = false;

							foreach(DataRow drST3 in DTSelectedTests.Rows)
							{
								if(drST3["TestID"].ToString() == e.Item.Cells[0].Text)
								{
									isPresent = true;
									break;
								}
							}

							if(!isPresent)
							{
								DataRow dr = DTSelectedTests.NewRow();
								dr["TestID"] = e.Item.Cells[0].Text;
								dr["Test"] = e.Item.Cells[1].Text;
								dr["TestBatchNo"] = e.Item.Cells[2].Text;
								DTSelectedTests.Rows.Add(dr);

								int index = 0;

								foreach(DataRow drUST in DTUnSelectedTests.Rows)
								{
									if(drUST["TestID"].ToString() == e.Item.Cells[0].Text)
									{
										break;
									}

									index++;
								}

								DTUnSelectedTests.Rows[index].Delete();
								DTUnSelectedTests.AcceptChanges();
							}
						}
						else
						{
							this.lblErrMsg.Text = "<br>Another Test Batch is already present in the selected tests.<br><br>";
						}
					}
					else
					{
						foreach(DataGridItem dgItem in this.dgTests.Items)
						{
							if(dgItem.Cells[2].Text.Equals(e.Item.Cells[2].Text))
							{
								DataRow dr = DTSelectedTests.NewRow();
								dr["TestID"] = dgItem.Cells[0].Text;
								dr["Test"] = dgItem.Cells[1].Text;
								dr["TestBatchNo"] = dgItem.Cells[2].Text;
								DTSelectedTests.Rows.Add(dr);
							}
						}
					}
				}
				else
				{
					bool isPresent = false;

					foreach(DataRow drST in DTSelectedTests.Rows)
					{
						if(drST["TestID"].ToString() == e.Item.Cells[0].Text)
						{
							isPresent = true;
							break;
						}
					}

					if(!isPresent)
					{
						DataRow dr = DTSelectedTests.NewRow();
						dr["TestID"] = e.Item.Cells[0].Text;
						dr["Test"] = e.Item.Cells[1].Text;
						dr["TestBatchNo"] = e.Item.Cells[2].Text;
						DTSelectedTests.Rows.Add(dr);
					}
					else
					{
						this.lblErrMsg.Text = "<br>Selected Test is already selected for Test Batch.<br><br>";
					}
				}

				FillBatchedTestDG();
			}
		}

		private void dgBatchTest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.lblErrMsg.Text = "";
			this.dgBatchTest.SelectedIndex = e.Item.ItemIndex;

			if(e.CommandName.Equals("Select"))
			{
				if((int.Parse(e.Item.Cells[2].Text) > 0))
				{
					DataRow drUST = DTUnSelectedTests.NewRow();
					drUST["TestID"] = e.Item.Cells[0].Text;
					drUST["Test"] = e.Item.Cells[1].Text;
					drUST["TestBatchNo"] = e.Item.Cells[2].Text;
					DTUnSelectedTests.Rows.Add(drUST);

					foreach(DataRow drST in DTSelectedTests.Rows)
					{
						if(drST["TestID"].ToString() == e.Item.Cells[0].Text)
						{
							drST.Delete();
							break;
						}
					}
				}
				else
				{
					foreach(DataRow drST in DTSelectedTests.Rows)
					{
						if(drST["TestID"].ToString() == e.Item.Cells[0].Text)
						{
							drST.Delete();
							break;
						}
					}
				}
			}

			FillBatchedTestDG();
		}

		protected void lbtnSave_Click(object sender, System.EventArgs e)
		{
			if(DTSelectedTests.Rows.Count > 0 || DTUnSelectedTests.Rows.Count > 0)
			{
				if(DTSelectedTests.Rows.Count == 1)
				{
					this.lblErrMsg.Text = "<br>Single Test can't be Batched.<br><br>";
				}
				else
				{
					int aryRows = DTSelectedTests.Rows.Count + DTUnSelectedTests.Rows.Count;
					string[,] arySave = new string[aryRows, 2];
					int aryIndex = 0;

					foreach(DataRow drUST in DTUnSelectedTests.Rows)
					{
						arySave[aryIndex, 0] = drUST["TestID"].ToString();
						arySave[aryIndex, 1] = "N";
						aryIndex++;
					}

					int batchNo = 0;

					foreach(DataRow drST in DTSelectedTests.Rows)
					{
						batchNo = int.Parse(drST["TestBatchNo"].ToString());
					
						if(batchNo > 0)
						{
							break;
						}
					}

					if(batchNo > 0)
					{
						foreach(DataRow drST in DTSelectedTests.Rows)
						{
							if((int.Parse(drST["TestBatchNo"].ToString()) == 0))
							{
								arySave[aryIndex, 0] = drST["TestID"].ToString();
								arySave[aryIndex, 1] = batchNo.ToString();
								aryIndex++;
							}
						}
					}
					else
					{
						foreach(DataRow drST in DTSelectedTests.Rows)
						{
							arySave[aryIndex, 0] = drST["TestID"].ToString();
							arySave[aryIndex, 1] = "Y";
							aryIndex++;
						}
					}

					//	Business Layer to update
					clsBLBatchingTest objBatTest = new clsBLBatchingTest();
					
					if(objBatTest.Update(arySave))
					{
						this.lblErrMsg.Text = "<br><font color='Green'>Tests are batched up successfully.</font><br><br>";
						try{	DTSelectedTests.Rows.Clear();	}
						catch{}

						try{	DTUnSelectedTests.Rows.Clear();	}
						catch{}

						FillTestDG();
						FillBatchedTestDG();
					}
					else
					{
						this.lblErrMsg.Text = "<br>" + objBatTest.ErrorMessage + "<br><br>";
					}
				}
			}
			else
			{
				this.lblErrMsg.Text = "No Tests selected in order to batch them.";
			}
		}

		protected void lbtnNew_Click(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			try{	DTSelectedTests.Rows.Clear();	}
			catch{}

			try{	DTUnSelectedTests.Rows.Clear();	}
			catch{}

			FillTestDG();
			FillBatchedTestDG();
		}

		private void dgTests_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			uiFacade.SetRowHover(this.dgTests, e);
		}

		private void dgBatchTest_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
			uiFacade.SetRowHover(this.dgBatchTest, e);
		}
	}
}