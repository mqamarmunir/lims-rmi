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
	/// Summary description for wfrmSearchTest.
	/// </summary>
	public partial class wfrmSearchTest : System.Web.UI.Page
	{
		#region Form Component


		#endregion
		
		#region Class Variable
		
		private long yearValue = 0;
		private string sex = "";
		private clsBLReceiption receiption;
		private static DataTable dtAllTest, dtSelectedTest1;
		private static DataTable DTPreviousSelectedTest;

		#endregion

		#region Page Load

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				yearValue = long.Parse(Request.QueryString.Get("age"));
				sex = Request.QueryString.Get("gender");
				receiption = new clsBLReceiption();
			
				SComponents objComp = new SComponents();
			
				if(!IsPostBack)
				{
					ArrayList formValues = (ArrayList) Session["ReceptionFormValues"];
					lblPatientInfo.Text = "<b>Name: </b>" + formValues[17].ToString() + " " + formValues[18].ToString() + " " + formValues[19].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
				
					if(formValues[20].ToString().Equals("0"))
					{
						lblPatientInfo.Text += "<b>Sex: </b>Male";
					}
					else
					{
						lblPatientInfo.Text += "<b>Sex: </b>Female";
					}

					string ageType = "";
				
					if(formValues[23].ToString().Equals("0"))
					{
						ageType = "Year(s)";
					}
					else if(formValues[23].ToString().Equals("1"))
					{
						ageType = "Month(s)";
					}
					else if(formValues[23].ToString().Equals("2"))
					{
						ageType = "Week(s)";
					}
				
					lblPatientInfo.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Age: </b>" + formValues[22].ToString() + " " + ageType;

					// setting selected test grid
					dtSelectedTest1 = new DataTable();
					dtSelectedTest1.Columns.Add("SNO");
					dtSelectedTest1.Columns.Add("Section");
					dtSelectedTest1.Columns.Add("TestGroup");
					dtSelectedTest1.Columns.Add("Times");
					dtSelectedTest1.Columns.Add("TestName");
					dtSelectedTest1.Columns.Add("Charges");
					dtSelectedTest1.Columns.Add("Delivery");
					dtSelectedTest1.Columns.Add("TestID");
					dtSelectedTest1.Columns.Add("SectionID");
					dtSelectedTest1.Columns.Add("TestGroupID");
					dtSelectedTest1.Columns.Add("TestBatchNo");
					DGSelectedTest.DataSource = dtSelectedTest1;
					DGSelectedTest.DataBind();

					dtAllTest = new DataTable();
					dtAllTest.Columns.Add("Section");
					dtAllTest.Columns.Add("TestGroup");
					dtAllTest.Columns.Add("TestName");
					dtAllTest.Columns.Add("Charges");
					dtAllTest.Columns.Add("Delivery");
					dtAllTest.Columns.Add("TestID");
					dtAllTest.Columns.Add("SectionID");
					dtAllTest.Columns.Add("TestGroupID");
					dtAllTest.Columns.Add("TestBatchNo");
					DGAllTest.DataSource = dtAllTest;
					DGAllTest.DataBind();

					// getting all sections for selection
					clsBLSection objSection = new clsBLSection();
					objSection.Active = "Y";
					DataView dvSection = objSection.GetAll(1);
					objComp.FillDropDownList(this.CmbSection, dvSection, "SectionName", "SectionID");
				
					// filling selected test grid
					dtSelectedTest1 = (DataTable) ((ArrayList) Session["ReceptionFormValues"])[33];
					DTPreviousSelectedTest = ((DataTable) ((ArrayList)Session["ReceptionFormValues"])[33]).Copy();

					if(dtSelectedTest1.Rows.Count > 0)
					{
						DGSelectedTest.DataSource = dtSelectedTest1;
						this.DGSelectedTest.Visible = true;
					}
					else
					{
						this.DGSelectedTest.Visible = false;
					}

					DGSelectedTest.DataBind();

					// filling all test grid
					dtAllTest = receiption.GetAllTestByGroupWise(this.yearValue, sex, "All", "", "").Table;
					DGAllTest.DataSource = dtAllTest.DefaultView;
					DGAllTest.DataBind();
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
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
			this.DGSelectedTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_ItemCommand_1);
			this.DGAllTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGAllTest_ItemCommand);
			this.DGAllTest.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGAllTest_PageIndexChanged);

		}
		#endregion

		#region Events
		protected void ButGetTest_Click(object sender, System.EventArgs e)
		{
			string testGroup = "All";
			string sectionID = (this.CmbSection.SelectedItem.Value == "-1") ? "" : this.CmbSection.SelectedItem.Value;
			
			
			if(CmbTestGroup != null && CmbTestGroup.SelectedIndex > 0)
				testGroup = CmbTestGroup.SelectedValue.ToString();
		
			string SearchString = "";

			SearchString = txtSearchString.Text.ToUpper();
			if (rbLeft.Checked)
			{
				SearchString = SearchString+"%";
			}
			else if (rbMiddle.Checked)
			{
				SearchString = "%"+SearchString+"%";
			}
			else if (rbRight.Checked)
			{
				SearchString = "%"+SearchString;
			}	

			//query += " and Upper(t.test) like '%"+st.ToUpper()+"%'";

			dtAllTest = receiption.GetAllTestByGroupWise(yearValue, sex, testGroup, sectionID, SearchString).Table;
			DGAllTest.DataSource = dtAllTest.DefaultView;
			DGAllTest.DataBind();
		}

		protected void CmbSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void DGAllTest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Select"))
			{
				int index = e.Item.ItemIndex;
			
				string testID = this.DGAllTest.Items[index].Cells[5].Text;
				dtSelectedTest1 =receiption.AddTest(dtSelectedTest1.DefaultView,dtAllTest.DefaultView,testID, false).Table;
			
				DGSelectedTest.DataSource = dtSelectedTest1;
				DGSelectedTest.DataBind();

				if(dtSelectedTest1.Rows.Count > 0)
				{
					this.DGSelectedTest.Visible = true;
				}
				else
				{
					this.DGSelectedTest.Visible = false;
				}

				double totalAmount=0;

				for(int i=0; i<dtSelectedTest1.Rows.Count; i++)
				{
					totalAmount += double.Parse(dtSelectedTest1.Rows[i].ItemArray[5].ToString());
				}
			}
		}

		protected void ButClose_Click(object sender, System.EventArgs e)
		{
			ArrayList formValues = (ArrayList) Session["ReceptionFormValues"];
			formValues.RemoveAt(33);

			formValues.Insert(33, dtSelectedTest1);

			Session.Remove("ReceptionFormValues");
			Session.Add("ReceptionFormValues", formValues);
			Response.Write("<script language='javascript'> window.opener.FillForm(); window.close(); </script>");
		}

		private void DGSelectedTest_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DGSelectedTest.CurrentPageIndex = e.NewPageIndex;
			this.DGSelectedTest.DataSource = dtSelectedTest1;
			this.DGSelectedTest.DataBind();
		}

		private void DGAllTest_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DGAllTest.CurrentPageIndex = e.NewPageIndex;
			this.DGAllTest.DataSource = dtAllTest;
			this.DGAllTest.DataBind();
		}

		private void DGSelectedTest_ItemCommand_1(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{
				int index = e.Item.ItemIndex;
				dtSelectedTest1 = receiption.RemoveTest(dtSelectedTest1.DefaultView, index).Table;
				DGSelectedTest.DataSource = dtSelectedTest1;
				DGSelectedTest.DataBind();
				
				if(dtSelectedTest1.Rows.Count > 0)
				{
					this.DGSelectedTest.Visible = true;
				}
				else
				{
					this.DGSelectedTest.Visible = false;
				}
			}		
		}

		protected void lbtnCancel_Click(object sender, System.EventArgs e)
		{
			ArrayList formValues = (ArrayList) Session["ReceptionFormValues"];
			formValues.RemoveAt(33);

			formValues.Insert(33, DTPreviousSelectedTest);

			Session.Remove("ReceptionFormValues");
			Session.Add("ReceptionFormValues", formValues);

			Response.Write("<script language='javascript'>window.opener.FillForm();self.close();</script>");
		}

		protected void dglbtnBatch_Click(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = (DataGridItem)(((LinkButton) sender).Parent.Parent);
			
			string testID = dgItem.Cells[5].Text;
			dtSelectedTest1 = receiption.AddTest(dtSelectedTest1.DefaultView, dtAllTest.DefaultView, testID, true).Table;
			
			DGSelectedTest.DataSource = dtSelectedTest1;
			DGSelectedTest.DataBind();

			if(dtSelectedTest1.Rows.Count > 0)
			{
				this.DGSelectedTest.Visible = true;
			}
			else
			{
				this.DGSelectedTest.Visible = false;
			}

			double totalAmount = 0;

			for(int i = 0; i < dtSelectedTest1.Rows.Count; i++)
			{
				totalAmount += double.Parse(dtSelectedTest1.Rows[i].ItemArray[5].ToString());
			}
		}

		protected void lbtnGetList_Click(object sender, System.EventArgs e)
		{
			// loading all sections for selection
			clsBLTestGroup objTGroup = new clsBLTestGroup();

			if(!this.CmbSection.SelectedItem.Value.Equals("-1"))
			{
				objTGroup.SectionID = this.CmbSection.SelectedItem.Value;
				DataView dvTGroup = objTGroup.GetAll(3);
				
				if(dvTGroup.Count > 0)
				{
					SComponents objComp = new SComponents();
					objComp.FillDropDownList(this.CmbTestGroup, dvTGroup, "TestGroup", "TestGroupID");
					this.CmbTestGroup.Enabled = true;
				}
				else
				{
					this.CmbTestGroup.Enabled = false;
				}
			}
			else
			{
				this.LblMessage.Text = "Please select Section ID.";
			}
		}
	}

	#endregion
}