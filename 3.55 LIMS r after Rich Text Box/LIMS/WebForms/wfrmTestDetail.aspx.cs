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
	public partial class wfrmTestDetail : System.Web.UI.Page
	{
	
		protected static string id;		
		protected static string sMSerialNo;
		protected static string sMSerialNos;
		protected static string ProcessID;
		protected static string SectionID;
		protected static string SelectedOpinion = "";
		protected static string SelectedComment = "";
		protected static string sOrgID;		
		protected static string sDSerNo;		

		string sPAgeinDays;
		string sSex;				
		string[] saMSerialNos = new string[100];
		
		private DataView _dvForwardto;	
		private DataView _dvOrganism;

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
					sOrgID = "";		
					sDSerNo = "";
					DisplayPatient(sMSerialNo);
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
			this.dgTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_ItemCommand);
			this.dgTest.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_CancelCommand);
			this.dgTest.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_EditCommand);
			this.dgTest.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgTest_UpdateCommand);

		}
		#endregion		

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

		public DataView FillDDLOrganism()
		{
			clsBLOrganism objOrganism = new clsBLOrganism();
			SComponents objComp = new SComponents();						
			DataView dvOrganism = objOrganism.GetAll(1);		
			_dvOrganism = dvOrganism;	
			return dvOrganism;
		}	
		
		public bool Micro(string sValue1, string sValue2)
		{
			if ((sValue1.Equals("M")) && (sValue2.Equals("Y")))			
				return true;
			else return false;									 
		}	

		protected void ddlOrganism_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
			DataGridItem dgItem = ((DataGridItem)((DropDownList)sender).Parent.Parent);			
			string sDSerialNo =  dgItem.Cells[3].Text ;							
			TableCell tbc = ((TableCell)((DropDownList)sender).Parent);
			DataGrid dgMicro = ((DataGrid)tbc.FindControl("dgMicro"));
			
			dgMicro.DataSource = null;
			dgMicro.DataSource = DisplayDrugSource(((DropDownList)tbc.FindControl("ddlOrganism")).SelectedItem.Value, sDSerialNo);
			dgMicro.DataBind();
			 			
		}

		public DataView DisplayDrugSource(string sValue, string sDSerialNo)
		{
			this.lblErrMsg.Text = "";

			clsBLDrug objTDrug = new clsBLDrug();						
			objTDrug.OrganismID = sValue;
			objTDrug.DerialNo = sDSerialNo;
			DataView dvTDrug = objTDrug.GetAll(1);

			return dvTDrug;			
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
				lblLabID.Text = dvTGeneralTestResult.Table.Rows[0]["LabID"].ToString();				
				lblMSerialNo.Text = dvTGeneralTestResult.Table.Rows[0]["MSerialNo"].ToString();				
				lblName.Text = dvTGeneralTestResult.Table.Rows[0]["PatientName"].ToString();
				lblPriority.Text = dvTGeneralTestResult.Table.Rows[0]["Priority"].ToString();
				lblAgeSex.Text = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();
				lblAgeSex.Text += ' '+dvTGeneralTestResult.Table.Rows[0]["PAge"].ToString();
				lblType.Text = dvTGeneralTestResult.Table.Rows[0]["Type"].ToString();
				lblWard.Text = dvTGeneralTestResult.Table.Rows[0]["WardName"].ToString();
				
				sPAgeinDays = dvTGeneralTestResult.Table.Rows[0]["PAgeinDays"].ToString();
				sSex = dvTGeneralTestResult.Table.Rows[0]["PSex"].ToString();


				
				/*for (int i = 0; i < 11; i++)
				{  					
					dgTest.EditItemIndex = i;
				}*/

				dgTest.EditItemIndex = 0;
				dgTest.EditItemIndex = 1;
				dgTest.EditItemIndex = 2;
				dgTest.EditItemIndex = 3;
				dgTest.EditItemIndex = 4;
				dgTest.EditItemIndex = 5;
				dgTest.EditItemIndex = 6;
				dgTest.EditItemIndex = 7;
				dgTest.EditItemIndex = 8;
				dgTest.EditItemIndex = 9;
				dgTest.EditItemIndex = 10;
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
		
		protected void chkSensitivity_CheckedChanged(object sender, System.EventArgs e)
		{
			DataGridItem dgItem = ((DataGridItem)((CheckBox)sender).Parent.Parent);
			this.dgTest.SelectedIndex = dgItem.ItemIndex;
			DataGrid dgMicro = (DataGrid)this.dgTest.SelectedItem.Cells[1].FindControl("dgMicro");			
			Label lblOrganism = (Label)this.dgTest.SelectedItem.Cells[1].FindControl("lblOrganism");
			CheckBox chkSensitivity = (CheckBox)this.dgTest.SelectedItem.Cells[1].FindControl("chkSensitivity");
			DropDownList ddlOrganism = (DropDownList)this.dgTest.SelectedItem.Cells[1].FindControl("ddlOrganism");	

			if (chkSensitivity.Checked )
			{
				lblOrganism.Visible = true;								
				ddlOrganism.Visible = true;
				dgMicro.Visible = true;				
			} 
			else
			{
				lblOrganism.Visible = false;								
				ddlOrganism.Visible = false;
				dgMicro.Visible = false;				
			}				
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
			try
			{
				for(int i=0; i < _dvForwardto.Table.DefaultView.Count; i++)
				{
					if (_dvForwardto.Table.DefaultView[i]["ProcessID"].ToString()==sProcessID)
					{
						return i+1;
					}
				}
			}
			catch{}
			return 0;
				
		}

		public int GetOrganismIndex(string sOrganismID)
		{			
			try
			{				
				for(int i=0; i < _dvOrganism.Table.DefaultView.Count; i++)
				{
					if (_dvOrganism.Table.DefaultView[i]["OrganismID"].ToString()==sOrganismID)
					{
						//DisplayDrugSource(i, sDSerialNo);
						return i;
					}
				}
			}
			catch{}
			return 0;				
		}		

		public int GetMicroResultIndex(string sProcessID)
		{
			if (sProcessID.Equals("Sensitive")) 
			{
				return 1;				
			} 
			else if (sProcessID.Equals("Resistant")) 
			{
				return 2;				
			}
			else if (sProcessID.Equals("Intermediate")) 
			{
				return 3;				
			} else return 0;				
		}		

		public System.Web.UI.WebControls.TextBoxMode GetTextmode(string sFlag)
		{		
			if (sFlag.Equals("1")) 
			{
				return System.Web.UI.WebControls.TextBoxMode.SingleLine;
			} 
			else
			{
				return System.Web.UI.WebControls.TextBoxMode.MultiLine;
			}
			
		}
		
		private void dgTest_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{			
			/****string sMSerialNo = lblReceptionID.Text;
			string sTestID = e.Item.Cells[2].Text ;	
			string sDSerialNo = e.Item.Cells[3].Text ;	

			DropDownList ddl=(DropDownList)e.Item.Cells[1].FindControl("dgddlForwardtoET");			
			string sProcessID = ddl.SelectedItem.Value;

			TextBox txt1 = (TextBox)e.Item.Cells[1].FindControl("dgtxtOpinionET");
			string sOpinion = txt1.Text;

			TextBox txt2 = (TextBox)e.Item.Cells[1].FindControl("dgtxtCommentET");
			string sComment = txt2.Text; 		
		
			DataGrid dg1 = (DataGrid)e.Item.Cells[1].FindControl("Datagrid1");								
			string[,] AttributeResult = new string[dg1.Items.Count, 7];			
			for (int i=0; i < dg1.Items.Count; i++)
			{
				AttributeResult[i, 0] = dg1.Items[i].Cells[0].Text; //AttributeID
				AttributeResult[i, 1] = ((TextBox)dg1.Items[i].Cells[2].FindControl("dgAttributeResult")).Text; //Result
				if(AttributeResult[i, 1].Equals(""))
				{
					AttributeResult[i, 1] = "-";
				}
				if(AttributeResult[i, 1].Length > 1024)
				{
					AttributeResult[i, 1] = AttributeResult[i, 1].Substring(0, 1024);
				}

				AttributeResult[i, 2] = "Y"; //Print
				AttributeResult[i, 3] = dg1.Items[i].Cells[4].Text; //MinRange
				AttributeResult[i, 4] = dg1.Items[i].Cells[5].Text; //MaxRange
				AttributeResult[i, 5] = dg1.Items[i].Cells[3].Text; //RUnit			
				AttributeResult[i, 6] = (((CheckBox)dg1.Items[i].Cells[2].FindControl("chkRPrint")).Checked == true) ? "Y" : "N"; //Report
			}

			clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

			objTGenTestResult.DSerialNo = sDSerialNo;
			objTGenTestResult.NextProcessID = sProcessID;						
			objTGenTestResult.MSerialNo = sMSerialNo;
			objTGenTestResult.TestID = sTestID;
			objTGenTestResult.Times = "0";
			objTGenTestResult.Opinion = sOpinion;
			objTGenTestResult.Comments = sComment;

			bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult);
			if(!isSuccessful)
			{
				this.lblErrMsg.Text = objTGenTestResult.ErrorMessage;
			}
			else
			{
				dgTest.EditItemIndex=-1;		
				DisplayPatient(sMSerialNo);		
			}*/
			
		}

		private void dgTest_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{	
			/****dgTest.EditItemIndex=e.Item.ItemIndex;
			DisplayPatient(sMSerialNo);				*/
		}

		private void dgTest_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			/****dgTest.EditItemIndex=-1;
			DisplayPatient(sMSerialNo);*/

		}

		private void LinkButton3_Click(object sender, System.EventArgs e)
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

		private void lbtnAddTest_Click(object sender, System.EventArgs e)
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

		private void dgTest_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void dgTest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string sMSerialNo = lblMSerialNo.Text;
			string sTestID = e.Item.Cells[2].Text ;	
			string sDSerialNo = e.Item.Cells[3].Text ;				

			DropDownList ddl=(DropDownList)e.Item.Cells[1].FindControl("dgddlForwardtoIT");			
			string sProcessID = ddl.SelectedItem.Value;

			TextBox txt1 = (TextBox)e.Item.Cells[1].FindControl("dgtxtOpinionET");
			string sOpinion = txt1.Text;

			TextBox txt2 = (TextBox)e.Item.Cells[1].FindControl("dgtxtCommentET");
			string sComment = txt2.Text; 		
		
			DataGrid dg1 = (DataGrid)e.Item.Cells[1].FindControl("Datagrid1");								
			string[,] AttributeResult = new string[dg1.Items.Count, 7];			
			for (int i=0; i < dg1.Items.Count; i++)
			{
				AttributeResult[i, 0] = dg1.Items[i].Cells[0].Text; //AttributeID
				AttributeResult[i, 1] = ((TextBox)dg1.Items[i].Cells[2].FindControl("dgAttributeResult")).Text; //Result
				if(AttributeResult[i, 1].Equals(""))
				{
					AttributeResult[i, 1] = "-";
				}
				if(AttributeResult[i, 1].Length > 1024)
				{
					AttributeResult[i, 1] = AttributeResult[i, 1].Substring(0, 1024);
				}

				AttributeResult[i, 2] = "Y"; //Print
				AttributeResult[i, 3] = dg1.Items[i].Cells[4].Text; //MinRange
				AttributeResult[i, 4] = dg1.Items[i].Cells[5].Text; //MaxRange
				AttributeResult[i, 5] = dg1.Items[i].Cells[3].Text; //RUnit			
				AttributeResult[i, 6] = (((CheckBox)dg1.Items[i].Cells[2].FindControl("chkRPrint")).Checked == true) ? "Y" : "N"; //Report
			}

			DataGrid dgMicro = (DataGrid)e.Item.Cells[1].FindControl("dgMicro");							
			string[,] MicroResult = new string[dgMicro.Items.Count, 3];

			CheckBox chkSensitivity = (CheckBox)e.Item.Cells[1].FindControl("chkSensitivity");
			string sSensitivity = (chkSensitivity.Checked == true) ? "Y" : "N"; //Report

			if ((chkSensitivity.Visible) && (sSensitivity.Equals("Y")))
			{
				DropDownList ddlOrganism = (DropDownList)e.Item.Cells[1].FindControl("ddlOrganism");			
				string sOrganismID = ddl.SelectedItem.Value;

				//DataGrid dgMicro = (DataGrid)e.Item.Cells[1].FindControl("dgMicro");								
				//string[,] MicroResult = new string[dgMicro.Items.Count, 3];			
				for (int i=0; i < dgMicro.Items.Count; i++)
				{
					DropDownList ddlResult = (DropDownList)dgMicro.Items[i].Cells[3].FindControl("ddlResult");					    string sResult = ddlResult.SelectedItem.Value;
					
					MicroResult[i, 0] = dgMicro.Items[i].Cells[0].Text; //OrganismID
					MicroResult[i, 1] = dgMicro.Items[i].Cells[1].Text; //DrugID						
					MicroResult[i, 2] = sResult;											
				}				
			}		

			clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

			objTGenTestResult.DSerialNo = sDSerialNo;
			objTGenTestResult.NextProcessID = sProcessID;						
			objTGenTestResult.MSerialNo = sMSerialNo;
			objTGenTestResult.TestID = sTestID;
			objTGenTestResult.Times = "0";
			objTGenTestResult.Opinion = sOpinion;
			objTGenTestResult.Comments = sComment;
			objTGenTestResult.Sensitivity = sSensitivity;

			bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult, MicroResult, "Y");
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
	
	
		protected void lblDisplaydgMicro_Load(object sender, System.EventArgs e)
		{	
			/*DataGridItem dgItem = ((DataGridItem)((Label)sender).Parent.Parent);			
			string sDSerialNo =  dgItem.Cells[3].Text ;							
			TableCell tbc = ((TableCell)((Label)sender).Parent);
			CheckBox chkSensitivity = ((CheckBox)tbc.FindControl("chkSensitivity"));			
			DropDownList ddlOrganism = ((DropDownList)tbc.FindControl("ddlOrganism"));

			if ((!sOrgID.Equals(ddlOrganism.SelectedValue)) || (!sDSerNo.Equals(sDSerialNo)))
			{	
				sOrgID = ddlOrganism.SelectedValue;
				sDSerNo = sDSerialNo;

				if ((chkSensitivity.Visible) && (chkSensitivity.Checked))
				{
					DataGrid dgMicro = ((DataGrid)tbc.FindControl("dgMicro"));						
				
					dgMicro.DataSource = DisplayDrugSource(ddlOrganism.SelectedValue, sDSerialNo);
					dgMicro.DataBind();
				}
			}*/
		}

		protected void btnSaveAll_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem dgItem in this.dgTest.Items)
			{
				string sMSerialNo = lblMSerialNo.Text;
				string sTestID = dgItem.Cells[2].Text ;	
				string sDSerialNo = dgItem.Cells[3].Text ;				

				DropDownList ddl=(DropDownList)dgItem.Cells[1].FindControl("dgddlForwardtoIT");			
				string sProcessID = ddl.SelectedItem.Value;

				TextBox txt1 = (TextBox)dgItem.Cells[1].FindControl("dgtxtOpinionET");
				string sOpinion = txt1.Text;

				TextBox txt2 = (TextBox)dgItem.Cells[1].FindControl("dgtxtCommentET");
				string sComment = txt2.Text; 		
		
				DataGrid dg1 = (DataGrid)dgItem.Cells[1].FindControl("Datagrid1");								
				string[,] AttributeResult = new string[dg1.Items.Count, 7];			
				for (int i=0; i < dg1.Items.Count; i++)
				{
					AttributeResult[i, 0] = dg1.Items[i].Cells[0].Text; //AttributeID
					AttributeResult[i, 1] = ((TextBox)dg1.Items[i].Cells[2].FindControl("dgAttributeResult")).Text; //Result
					if(AttributeResult[i, 1].Equals(""))
					{
						AttributeResult[i, 1] = "-";
					}
					if(AttributeResult[i, 1].Length > 1024)
					{
						AttributeResult[i, 1] = AttributeResult[i, 1].Substring(0, 1024);
					}

					AttributeResult[i, 2] = "Y"; //Print
					AttributeResult[i, 3] = dg1.Items[i].Cells[4].Text; //MinRange
					AttributeResult[i, 4] = dg1.Items[i].Cells[5].Text; //MaxRange
					AttributeResult[i, 5] = dg1.Items[i].Cells[3].Text; //RUnit			
					AttributeResult[i, 6] = (((CheckBox)dg1.Items[i].Cells[2].FindControl("chkRPrint")).Checked == true) ? "Y" : "N"; //Report
				}

				DataGrid dgMicro = (DataGrid)dgItem.Cells[1].FindControl("dgMicro");							
				string[,] MicroResult = new string[dgMicro.Items.Count, 3];

				CheckBox chkSensitivity = (CheckBox)dgItem.Cells[1].FindControl("chkSensitivity");
				string sSensitivity = (chkSensitivity.Checked == true) ? "Y" : "N"; //Report

				if ((chkSensitivity.Visible) && (sSensitivity.Equals("Y")))
				{
					DropDownList ddlOrganism = (DropDownList)dgItem.Cells[1].FindControl("ddlOrganism");			
					string sOrganismID = ddl.SelectedItem.Value;

					//DataGrid dgMicro = (DataGrid)e.Item.Cells[1].FindControl("dgMicro");								
					//string[,] MicroResult = new string[dgMicro.Items.Count, 3];			
					for (int i=0; i < dgMicro.Items.Count; i++)
					{
						DropDownList ddlResult = (DropDownList)dgMicro.Items[i].Cells[3].FindControl("ddlResult");					    string sResult = ddlResult.SelectedItem.Value;
					
						MicroResult[i, 0] = dgMicro.Items[i].Cells[0].Text; //OrganismID
						MicroResult[i, 1] = dgMicro.Items[i].Cells[1].Text; //DrugID						
						MicroResult[i, 2] = sResult;											
					}				
				}		

				clsBLGeneralTestResult objTGenTestResult = new clsBLGeneralTestResult();

				objTGenTestResult.DSerialNo = sDSerialNo;
				objTGenTestResult.NextProcessID = sProcessID;						
				objTGenTestResult.MSerialNo = sMSerialNo;
				objTGenTestResult.TestID = sTestID;
				objTGenTestResult.Times = "0";
				objTGenTestResult.Opinion = sOpinion;
				objTGenTestResult.Comments = sComment;
				objTGenTestResult.Sensitivity = sSensitivity;

				bool isSuccessful = objTGenTestResult.UpdateAll(AttributeResult, MicroResult, "Y");
				if(!isSuccessful)
				{
					this.lblErrMsg.Text = objTGenTestResult.ErrorMessage;
				}
				else
				{
					
				}
			}		
			dgTest.EditItemIndex=-1;		
			DisplayPatient(lblMSerialNo.Text);				
		}				
	}
}