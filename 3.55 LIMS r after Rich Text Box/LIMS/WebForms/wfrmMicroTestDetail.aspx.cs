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
	/// Summary description for wfrmTestDetail.
	/// </summary>
	public partial class wfrmMicroTestDetail : System.Web.UI.Page
	{
	
		protected static string id;		
		protected static string sMSerialNo;
		protected static string sMSerialNos;
		protected static string ProcessID;
		protected static string SectionID;
		protected static string SelectedOpinion = "";
		protected static string SelectedComment = "";
		protected static DataTable dtDrug = null;
		string sPAgeinDays;
		string sSex;
		string sOrganismID = "0";
		string[] saMSerialNos = new string[50];
		int iSelectedTest = -1;
		protected string organism = "";
		
		private static DataView _dvForwardto = null;

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				// Put user code to initialize the page here						
				id = Request.QueryString["id"].ToString();							
				ProcessID = Request.QueryString["ProcessID"].ToString();
				sMSerialNos = Request.QueryString["MSerialNos"].ToString();
				parseMSerialNos(sMSerialNos);
				SectionID = Request.QueryString["SectionID"].ToString();
				lblHeading.Text = "Test Detail";
				if(!IsPostBack)				
				{			    					
					sMSerialNo = id;								
					DisplayPatient(sMSerialNo);
					MakeDrugDT();
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
			this.dgTest.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_CancelCommand);
			this.dgTest.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_EditCommand);
			this.dgTest.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_UpdateCommand);

		}
		#endregion		

		private void MakeDrugDT()
		{
			dtDrug = new DataTable();

			dtDrug.Columns.Add("DrugID");
			dtDrug.Columns.Add("OrganismID");
			dtDrug.Columns.Add("Drug");
			dtDrug.Columns.Add("Result");
		}

		private bool DrugExist(DataTable t1, string sValue)
		{
			// Repeat for each row in the table.
			bool r1 = false;
			foreach ( DataRow row in t1.Rows )
			{
				if (row["DrugID"].Equals(sValue))
				{
					r1 = true;
				}				
			}
			return r1;
		}

		private void parseMSerialNos(string sValue)
		{
			string sMSNo = "";
			int ArrayPosition = 0;

			for (int i=0; i < sValue.Length; i++)
			{
				if (sValue[i].ToString() != "|")
				{
					sMSNo += sValue[i].ToString();
				}
				else
				{
					if (!sMSNo.Equals("")) 
					{
						saMSerialNos[ArrayPosition] = sMSNo;
						sMSNo = "";
						ArrayPosition++;					
					}
				}		
			} 	
		}

		private string NextMSerialNo(string sValue)
		{
			try
			{
				for (int i=0; i <= saMSerialNos.GetUpperBound(0); i++)
				{
					if (saMSerialNos[i].Equals(sValue))
					{
						return saMSerialNos[i+1].ToString();
					}						
				} 	
			}
			catch{}
			return "";
		}
		public DataView FillDDLForwardTo(string sValue)
		{
			clsBLTestProcess objTestProcess = new clsBLTestProcess();
			SComponents objComp = new SComponents();
			
			objTestProcess.ProcedureID = sValue;
			DataView dvTestProcess = objTestProcess.GetAll(1);
			_dvForwardto = dvTestProcess;
			return dvTestProcess;
		}	

		public bool Microbiology1Test()
		{
			return true;		
		}

		public DataView FillDDLOrganism()
		{
			clsBLOrganism objOrganism = new clsBLOrganism();
			
			DataView dvOrganism = objOrganism.GetAll(1);			
			return dvOrganism;
		}		

		private void DisplayPatient(string Str)
		{
			this.lblErrMsg.Text = "";

			clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();						
			objTGeneralTestResult.MSerialNo = Str;	
			objTGeneralTestResult.ProcessID = ProcessID;		
			objTGeneralTestResult.SectionID = SectionID;		
			DataView dvTGeneralTestResult = objTGeneralTestResult.GetAll(2);

			if(dvTGeneralTestResult.Count > 0)
			{
				lblReceptionID.Text = dvTGeneralTestResult.Table.Rows[0]["MSerialNo"].ToString();				
				lblName.Text = dvTGeneralTestResult.Table.Rows[0]["PatientName"].ToString();
				lblPriority.Text = dvTGeneralTestResult.Table.Rows[0]["Priority"].ToString();
				lblAgeSex.Text = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
				lblAgeSex.Text += ' '+dvTGeneralTestResult.Table.Rows[0]["PAge"].ToString();
				lblType.Text = dvTGeneralTestResult.Table.Rows[0]["Type"].ToString();
				
				sPAgeinDays = dvTGeneralTestResult.Table.Rows[0]["PAgeinDays"].ToString();
				sSex = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();


				this.dgTest.DataSource = dvTGeneralTestResult;
				this.dgTest.DataBind();
				this.dgTest.Visible = true;
			}
			else
			{
				//this.dgTest.Visible = false;
				DisplayNextPatient();
			}						
		}

		private void DisplayNextPatient()
		{
			sMSerialNo = NextMSerialNo(sMSerialNo);
			if (sMSerialNo.Equals(""))
			{   
				Response.Write("<script language='javascript'>self.close();</script>");
			} 
			else
			{
				DisplayPatient(sMSerialNo);
			}			
		}

		
		public DataView DisplayDrugSource(string sValue)
		{
			this.lblErrMsg.Text = "";

			clsBLDrug objTDrug = new clsBLDrug();						
			objTDrug.OrganismID = sValue;
			DataView dvTDrug = objTDrug.GetAll(1);

			return dvTDrug;			
		}

		public DataView DisplayAttribute(string Str)
		{
			this.lblErrMsg.Text = "";

			clsBLGeneralTestResult objTGeneralTestResult = new clsBLGeneralTestResult();						
			objTGeneralTestResult.DSerialNo = Str;
			DataView dvTGeneralTestResult = objTGeneralTestResult.GetAll(3);

			if(dvTGeneralTestResult.Count > 0)
			{
				return dvTGeneralTestResult;
			} 
			else
			{			
				objTGeneralTestResult.DSerialNo = Str;
				objTGeneralTestResult.Age = sPAgeinDays;
				objTGeneralTestResult.Sex =sSex;
				DataView dvTGeneralTestResult2 = objTGeneralTestResult.GetAll(4);
				return dvTGeneralTestResult2;
			}
		}

		public int GetForwardIndex(string sProcessID)
		{
			for(int i=0; i < _dvForwardto.Table.DefaultView.Count; i++)
			{
				if (_dvForwardto.Table.DefaultView[i]["ProcessID"].ToString()==sProcessID)
				{
					return i+1;
				}
			}
			return 0;
				
		}

		private void dgTest_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			string sMSerialNo = lblReceptionID.Text;
			string sTestID = e.Item.Cells[3].Text ;	
			string sDSerialNo = e.Item.Cells[4].Text ;	

			DropDownList ddl=(DropDownList)e.Item.Cells[2].FindControl("dgddlForwardtoET");			
			string sProcessID = ddl.SelectedItem.Value;

			TextBox txt1 = (TextBox)e.Item.Cells[2].FindControl("dgtxtOpinionET");
			string sOpinion = txt1.Text;

			TextBox txt2 = (TextBox)e.Item.Cells[2].FindControl("dgtxtCommentET");
			string sComment = txt2.Text; 		
		
			DataGrid dg1 = (DataGrid)e.Item.Cells[1].FindControl("Datagrid1");								
			string[,] AttributeResult = new string[dg1.Items.Count, 6];			
			for (int i=0; i < dg1.Items.Count; i++)
			{
				AttributeResult[i, 0] = dg1.Items[i].Cells[0].Text; //AttributeID
				AttributeResult[i, 1] = ((TextBox)dg1.Items[i].Cells[2].FindControl("dgAttributeResult")).Text; //Result
				AttributeResult[i, 2] = "Y"; //Print
				AttributeResult[i, 3] = dg1.Items[i].Cells[4].Text; //MinRange
				AttributeResult[i, 4] = dg1.Items[i].Cells[5].Text; //MaxRange
				AttributeResult[i, 5] = dg1.Items[i].Cells[3].Text; //RUnit			
			}	

			clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

			objTGenTestResult.DSerialNo = sDSerialNo;
			objTGenTestResult.NextProcessID = sProcessID;						
			objTGenTestResult.MSerialNo = sMSerialNo;
			objTGenTestResult.TestID = sTestID;
			objTGenTestResult.Times = "0";
			objTGenTestResult.Opinion = sOpinion;
			objTGenTestResult.Comments = sComment;

			bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult, AttributeResult, "N");
			if(!isSuccessful)
			{
				this.lblErrMsg.Text = objTGenTestResult.ErrorMessage;
			}
			else
			{
				dgTest.EditItemIndex=-1;		
				DisplayPatient(sMSerialNo);		
			}
			
		}

		private void dgTest_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			dgTest.EditItemIndex=e.Item.ItemIndex;
			iSelectedTest = e.Item.ItemIndex;
			DisplayPatient(sMSerialNo);			
	
			
		}

		private void dgTest_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgTest.EditItemIndex=-1;
			DisplayPatient(sMSerialNo);

		}

		protected void LinkButton3_Click(object sender, System.EventArgs e)
		{
			//Response.Write("<script language='javascript'>window.opener.pagerefresh();self.close();</script>");
			/* parent page code
			 * <script language="javascript">
			function pagerefresh()
			{
				window.location.href="wfrmGeneralTestResult.aspx?pageid=<%Response.Write(spageid);%>";
			}
		</script>
		*/
		}

		protected void lbtnNextPatient_Click(object sender, System.EventArgs e)
		{
			DisplayNextPatient();
		}

		protected void lbtnPatientTestDetail_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno="+sMSerialNo+"','','channelmode')</script>"); 
		}

		protected void lbtnAddTest_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestChange.aspx?mserialno="+sMSerialNo+"','','channelmode')</script>"); 
		}

		protected void lbtnClose_Click(object sender, System.EventArgs e)
		{
			Response.Write("<script language='javascript'>self.close();</script>");	
		}

		protected void LinkButton2_Click(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = ((DataGridItem)((LinkButton)sender).Parent.Parent);
			this.dgTest.SelectedIndex = dgItem.ItemIndex;
			SelectedOpinion = ((TextBox)this.dgTest.SelectedItem.Cells[2].FindControl("dgtxtOpinionET")).ClientID.ToString();

			Response.Write("<script language='javascript'>window.open('wfrmOpinion.aspx?testID=" + this.dgTest.SelectedItem.Cells[3].Text + "', '', 'channelmode');</script>");
		}

		protected void Linkbutton1_Click(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = ((DataGridItem)((LinkButton)sender).Parent.Parent);
			this.dgTest.SelectedIndex = dgItem.ItemIndex;
			SelectedComment= ((TextBox)this.dgTest.SelectedItem.Cells[2].FindControl("dgtxtCommentET")).ClientID.ToString();

			Response.Write("<script language='javascript'>window.open('wfrmVault.aspx?testID=" + this.dgTest.SelectedItem.Cells[3].Text + "', '', 'channelmode');</script>");
		}

		protected void chkSensitivity_CheckedChanged(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = ((DataGridItem)((CheckBox)sender).Parent.Parent);
			this.dgTest.SelectedIndex = dgItem.ItemIndex;
			DataGrid dgDrugET = (DataGrid)this.dgTest.SelectedItem.Cells[1].FindControl("dgDrugET");			
			CheckBox chk1 = (CheckBox)this.dgTest.SelectedItem.Cells[1].FindControl("chkSensitivityET");			

			DataGrid dgDrugSource = (DataGrid)this.dgTest.SelectedItem.Cells[2].FindControl("dgDrugsSource");	

			LinkButton lbtnAdd = (LinkButton)this.dgTest.SelectedItem.Cells[2].FindControl("lbtnAddET");	

			DropDownList ddlOrganism = (DropDownList)this.dgTest.SelectedItem.Cells[2].FindControl("ddlOrganism");	
		
			if (chk1.Checked )
			{
				dgDrugET.Visible = true;
				dgDrugSource.Visible = true;
				lbtnAdd.Visible = true;
				ddlOrganism.Visible = true;
			} 
			else
			{
				dgDrugET.Visible = false;
				dgDrugSource.Visible = false;
				lbtnAdd.Visible = false;
				ddlOrganism.Visible = false;
			}	
			
		}

		protected void ddlOrganism_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TableCell tbc = ((TableCell)((DropDownList)sender).Parent);
			DataGrid dgDrugsSource = ((DataGrid)tbc.FindControl("dgDrugsSource"));
			dgDrugsSource.DataSource = DisplayDrugSource(((DropDownList)tbc.FindControl("ddlOrganism")).SelectedItem.Value);
			dgDrugsSource.DataBind();
		}

		protected void lbtnAdd_Click(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = ((DataGridItem)((LinkButton)sender).Parent.Parent);
			this.dgTest.SelectedIndex = dgItem.ItemIndex;
			DataGrid dgDrugSource = (DataGrid)this.dgTest.SelectedItem.Cells[2].FindControl("dgDrugsSource");			

			DataGrid dgDrugET = (DataGrid)this.dgTest.SelectedItem.Cells[1].FindControl("dgDrugET");			

			/*for (int i=0; i < dtDrug.Rows.Count; i++)
			{
				dtDrug.Rows[i].f
				if (dgDrugSource.Items[0].Cells[1].Text = dtDrug. Rows[i].
				dtDrug.Rows[i].Delete();
			
			}*/
			

			for(int i=0; i < dgDrugSource.Items.Count; i++)
			{
				DropDownList ddlResult = (DropDownList)dgDrugSource.Items[i].Cells[2].FindControl("ddlsensitivity");						

				if (!ddlResult.SelectedItem.Value.Equals("None"))
				{
					
					if (!DrugExist(dtDrug, dgDrugSource.Items[i].Cells[0].Text))
					{
						DataRow drDrug = dtDrug.NewRow();
						drDrug["DrugID"] = dgDrugSource.Items[i].Cells[0].Text;
						drDrug["OrganismID"] = dgDrugSource.Items[i].Cells[1].Text;
						drDrug["Drug"] = dgDrugSource.Items[i].Cells[2].Text;
						drDrug["Result"] = ddlResult.SelectedItem.Value.ToString();
						dtDrug.Rows.Add(drDrug);								
					}

				}				
			}

			dgDrugET.DataSource = dtDrug.DefaultView;
			dgDrugET.DataBind();
		}

//iftikar_30082@hotmail.com
	}
}