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
using System.Web.Handlers;
using LS_BusinessLayer;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmReceiption.
	/// </summary>
	public partial class wfrmReception : System.Web.UI.Page
	{
		#region Form Component
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Table Table4;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;		
		#endregion

		private clsBLReceiption receiption;
		protected static string mode = "";
		private static DataTable dtSelectedTest;

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
			this.DGSelectedTest.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGSelectedTest_ItemCommand);
			this.DGSelectedTest.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DGSelectedTest_PageIndexChanged);

		}
		#endregion

		#region Page Load

		protected void Page_Load(object sender, System.EventArgs e)
		{			
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "101";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					mode = "Insert";
					LoadForm();

					receiption = new clsBLReceiption();

					ArrayList formValues = (ArrayList) Session["ReceptionFormValues"];
			
					if(formValues != null)
					{
						FillForm(formValues);
					}

					try
					{
						string patientID = Request.QueryString["patientid"].ToString();
						LoadPatient(patientID);
					}
					catch(Exception e2)
					{string str = e2.Message;}
				}
			}
			else
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}
		}

		private void LoadForm()
		{
			SComponents objComp = new SComponents();
			
			// getting Factory list
			clsBLFactory objFactory = new clsBLFactory();
			objFactory.Active = "Y";
			objFactory.FactoryType = "E";
			objFactory.OrgID = "01";
			DataView dvFactory = objFactory.GetAll(1);
			objComp.FillDropDownList(this.CmbPanel, dvFactory, "FactoryName", "FactoryID");		

			// getting Factory list
			clsBLFactory objFactoryP = new clsBLFactory();
			objFactoryP.Active = "Y";
			objFactoryP.FactoryType = "P";
			objFactoryP.OrgID = "01";
			DataView dvFactoryP = objFactoryP.GetAll(1);
			objComp.FillDropDownList(this.CmbPanelP, dvFactoryP, "FactoryName", "FactoryID");		

			/*// getting DiscountLevel list
			clsBLTDiscountLevel objDiscountLevel = new clsBLTDiscountLevel();
			objDiscountLevel.Active = "Y";			
			DataView dvDiscountLevel = objDiscountLevel.GetAll(2);
			objComp.FillDropDownList(this.ddlDiscountLevel, dvDiscountLevel, "DiscountName", "DiscountID");		*/

			clsBLTDiscountLevel objDiscountLevel = new clsBLTDiscountLevel();
			//SComponents objComp = new SComponents();

			DataView dvDiscountLevel = objDiscountLevel.GetAll(2);
			objComp.FillDropDownList(this.ddlDiscountLevel, dvDiscountLevel, "DiscountName", "DiscountID", false, false, false);

			// getting Ward list
			clsBLWard objWard = new clsBLWard();
			objWard.Active = "Y";			
			DataView dvWard = objWard.GetAll(1);
			objComp.FillDropDownList(this.ddlWard, dvWard, "WardName", "WardID");		

			// getting payment modes
			objComp.FillDropDownList(this.CmbPaymentMode, new clsBLPaymentMode().GetAll(), "Data", "ID", false, false, false);
			
			// getting result despatchs
			objComp.FillDropDownList(this.CmbResultDespatch, new clsBLResultDespatch().GetAll(), "Data", "ID", false, false, false);

			// getting relationship						
			objComp.FillDropDownList(this.CmbRelationShip2, new clsBLRelationShip().GetAll(), "Data", "ID");
			objComp.FillDropDownList(this.CmbRelationShip, new clsBLRelationShip().GetAll(), "Data", "ID");

			MakeDTSelected();
		}

		private void LoadPatient(string strPatientID)
		{
			clsBLSearchPR objSearchPR = new clsBLSearchPR();
			SComponents objComp = new SComponents();
			DataView dvPatient = null;

			// if Tests selected before selecting patient
			if(dtSelectedTest.Rows.Count > 0)
			{
				dtSelectedTest.Rows.Clear();
				this.DGSelectedTest.DataSource = dtSelectedTest;
				this.DGSelectedTest.DataBind();
			}

			if(strPatientID.Substring(0, 1).Equals("E"))
			{	//	for Entitled
				objSearchPR.PatientID = strPatientID;
				dvPatient = objSearchPR.GetAll(3);

				this.RdoEntitled.SelectedItem.Selected = false;
				this.RdoEntitled.Items.FindByValue("E").Selected = true;

				this.CmbTitle.SelectedItem.Selected = false;
				this.CmbTitle.Items.FindByValue(dvPatient.Table.Rows[0]["ETitle"].ToString()).Selected = true;

				this.TxtEFName.Text = dvPatient.Table.Rows[0]["EFName"].ToString();
				this.TxtEMName.Text = dvPatient.Table.Rows[0]["EMName"].ToString();
				this.TxtELName.Text = dvPatient.Table.Rows[0]["ELName"].ToString();

				this.CmbPanel.SelectedItem.Selected = false;
				this.CmbPanel.Items.FindByValue(dvPatient.Table.Rows[0]["FactoryID"].ToString()).Selected = true;

				FillSectionDDL();
				this.CmbUnit.SelectedItem.Selected = false;
				this.CmbUnit.Items.FindByValue(dvPatient.Table.Rows[0]["SectionID"].ToString()).Selected = true;
				this.CmbUnit.Enabled = true;

				this.TxtPLNo.Text = dvPatient.Table.Rows[0]["PLNo"].ToString();

				this.CmbRank.SelectedItem.Selected = false;
				this.CmbRank.Items.FindByValue(dvPatient.Table.Rows[0]["RankID"].ToString()).Selected = true;

				this.txtOfficePhone.Text = dvPatient.Table.Rows[0]["OPhone1"].ToString().Equals("") ? dvPatient.Table.Rows[0]["OPhone2"].ToString() : dvPatient.Table.Rows[0]["OPhone1"].ToString();
				this.txtMobileNo.Text = dvPatient.Table.Rows[0]["CPhone"].ToString();
				this.txtEmail.Text = dvPatient.Table.Rows[0]["EMail"].ToString();
				this.TxtAddress.Text = dvPatient.Table.Rows[0]["TempAddress"].ToString().Equals("") ? dvPatient.Table.Rows[0]["PermentAddress"].ToString() : dvPatient.Table.Rows[0]["TempAddress"].ToString();

				this.CmbRelationShip.SelectedItem.Selected = false;
				this.CmbRelationShip.Items.FindByValue(dvPatient.Table.Rows[0]["Relation"].ToString()).Selected = true;

				this.ddlPTitle.SelectedItem.Selected = false;
				this.ddlPTitle.Items.FindByValue(dvPatient.Table.Rows[0]["DTitle"].ToString()).Selected = true;

				this.TxtPFName.Text = dvPatient.Table.Rows[0]["DFName"].ToString();
				this.TxtPMName.Text = dvPatient.Table.Rows[0]["DMName"].ToString();
				this.TxtPLName.Text = dvPatient.Table.Rows[0]["DLName"].ToString();

				this.CmbGender.SelectedItem.Selected = false;
				this.CmbGender.Items.FindByValue(dvPatient.Table.Rows[0]["Sex"].ToString().Equals("M") ? "Male" : "Female").Selected = true;

				this.TxtDOB.Text = dvPatient.Table.Rows[0]["DOB"].ToString();

				if(!this.TxtDOB.Text.Equals(""))
				{
					string strAge = objComp.GetAge(this.TxtDOB.Text);
					string[] splittedAge = strAge.Split(' ');
					this.TxtAge.Text = splittedAge[0];
					this.CmbAgeType.SelectedItem.Selected = false;
					this.CmbAgeType.Items.FindByValue(splittedAge[1].Substring(0, 1).ToUpper()).Selected = true;
				}
				else
				{
					this.TxtAge.Text = "";
				}
			}
			else	//	for CNE
			{
				objSearchPR.PatientID = strPatientID;
				dvPatient = objSearchPR.GetAll(2);

				this.RdoEntitled.SelectedItem.Selected = false;
				this.RdoEntitled.Items.FindByValue("C").Selected = true;

				this.ddlPTitle.SelectedItem.Selected = false;
				this.ddlPTitle.Items.FindByValue(dvPatient.Table.Rows[0]["Title"].ToString()).Selected = true;

				this.TxtPFName.Text = dvPatient.Table.Rows[0]["PFName"].ToString();
				this.TxtPMName.Text = dvPatient.Table.Rows[0]["PMName"].ToString();
				this.TxtPLName.Text = dvPatient.Table.Rows[0]["PLName"].ToString();

				this.CmbGender.SelectedItem.Selected = false;
				this.CmbGender.Items.FindByValue(dvPatient.Table.Rows[0]["Sex"].ToString().Equals("M") ? "Male" : "Female").Selected = true;

				this.TxtDOB.Text = dvPatient.Table.Rows[0]["DOB"].ToString();

				if(!this.TxtDOB.Text.Equals(""))
				{
					string strAge = objComp.GetAge(this.TxtDOB.Text);
					string[] splittedAge = strAge.Split(' ');
					this.TxtAge.Text = splittedAge[0];
					this.CmbAgeType.SelectedItem.Selected = false;
					this.CmbAgeType.Items.FindByValue(splittedAge[1].Substring(0, 1).ToUpper()).Selected = true;
				}
				else
				{
					this.TxtAge.Text = "";
				}
			}
		}

		private void MakeDTSelected()
		{
			dtSelectedTest = new DataTable();
			dtSelectedTest.Columns.Add("SNO");
			dtSelectedTest.Columns.Add("Section");
			dtSelectedTest.Columns.Add("TestGroup");
			dtSelectedTest.Columns.Add("Times");
			dtSelectedTest.Columns.Add("TestName");
			dtSelectedTest.Columns.Add("Charges");
			dtSelectedTest.Columns.Add("Delivery");
			dtSelectedTest.Columns.Add("TestID");
			dtSelectedTest.Columns.Add("SectionID");
			dtSelectedTest.Columns.Add("TestGroupID");
			dtSelectedTest.Columns.Add("TestBatchNo");			
			DGSelectedTest.DataSource = dtSelectedTest;
			DGSelectedTest.DataBind();
		}

		#endregion
		
		#region Methods

		private void Save()
		{
			receiption = new clsBLReceiption();

			if(!User.Identity.IsAuthenticated)
			{
				Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
			}

			// setting data for storing transtion master object
			clsBLMTransaction transaction = new clsBLMTransaction();

			transaction.PatientType = RdoEntitled.SelectedValue;
			transaction.Pririty = RdoRequestType.SelectedValue;
			transaction.IOP = RdoIOP.SelectedValue;

			if(RdoEntitled.SelectedIndex == 0)
			{
				transaction.HospitalID = CmbPanel.SelectedValue;
				transaction.PaymentMode = CmbPaymentMode.SelectedValue;
				transaction.ContactNo = this.txtMobileNo.Text;
			} else
			if(RdoEntitled.SelectedIndex == 2)
			{
				transaction.HospitalID = CmbPanelP.SelectedValue;
				transaction.PaymentMode = CmbPaymentMode.SelectedValue;
				transaction.ContactNo = this.txtMobileNoP.Text;
			}
			
			transaction.DeliveryType = CmbResultDespatch.SelectedValue;
			transaction.DeliveryRef = TxtAddress.Text;
			transaction.EntryDateTime = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
			transaction.EntryPerson = Session["loginid"].ToString();
			transaction.MStatus = "A";

			// temporary setting start
			transaction.Shift = Session["Shift"].ToString();
			// end
			
			// setting data for storing patient object
			clsBLPatient patient = new clsBLPatient();
			patient.PTitle = ddlPTitle.SelectedValue;
			patient.PFName = TxtPFName.Text.Trim();
			patient.PMName = TxtPMName.Text.Trim();
			patient.PLName = TxtPLName.Text.Trim();
			patient.PSex = CmbGender.SelectedValue;
			patient.PDOB = TxtDOB.Text;
			patient.PAgeD = TxtAge.Text;
			patient.PAgeU = CmbAgeType.SelectedValue;
			transaction.ReferredBy = txtReferredBy.Text;
			
			if(RdoEntitled.SelectedIndex == 0)
			{
				patient.ServiceNo = this.TxtPLNo.Text;
				patient.RankID = txtRank.ToolTip;// CmbRank.SelectedValue;
				patient.UnitID = txtUnit.ToolTip;// CmbUnit.SelectedValue;
				patient.KinShip = CmbRelationShip2.SelectedValue;				
				patient.KFName = this.TxtEFName.Text.Trim();
				patient.KMName = this.TxtEMName.Text.Trim();
				patient.KLName = this.TxtELName.Text.Trim();
				transaction.DiscountPer = "0";
				transaction.TotalAmount = "0";
				transaction.TotalAmount = "0";
			}
			else
			if(RdoEntitled.SelectedIndex == 2)
			{
				patient.ServiceNo = this.TxtPLNoP.Text;				
				patient.RefNo = this.txtReferenceNoP.Text;				
				patient.KinShip = CmbRelationShip2.SelectedValue;				
				patient.KFName = this.TxtEFNameP.Text.Trim();
				patient.KMName = this.TxtEMNameP.Text.Trim();
				patient.KLName = this.TxtELNameP.Text.Trim();									
				transaction.DiscountPer = TxtDiscountPer.Text.Equals("") ? "0" : TxtDiscountPer.Text;
				transaction.TotalAmount = TxtAmount.Text;
				transaction.PaidAmount = txtPaidAmount.Text;				
			} else
			{
				patient.KinShip = CmbRelationShip.SelectedValue;
				patient.KFName = this.txtKinFName.Text.Trim();
				patient.KMName = this.txtKinMName.Text.Trim();
				patient.KLName = this.txtKinLName.Text.Trim();
				transaction.DiscountPer = TxtDiscountPer.Text.Equals("") ? "0" : TxtDiscountPer.Text;
				transaction.TotalAmount = TxtAmount.Text;
				transaction.PaidAmount = txtPaidAmount.Text;
				if(RdoIOP.SelectedIndex == 1)
				{
					transaction.PaidNo = txtPaidNo.Text;
				}
			}
			
			if(RdoIOP.SelectedIndex != 1)
			{
				patient.WardID = ddlWard.SelectedValue;
				patient.PAdmNo = TxtPatientNo.Text;
				patient.RequestNo = TxtRequestNo.Text;
				if (!TxtAdmDate.Text.Equals(""))
				{ patient.PAdmDate = TxtAdmDate.Text; }
			}
			
			if(receiption.Save(patient, transaction, dtSelectedTest) == true)
			{
				if(!receiption.LastEntry.Equals(""))
				{					
					LIMS.reports.wfrmReceipt.mFilterString = "{LS_VRECEPTIONREPORT.MSERIALNO} = " + receiption.LastEntry;
					LIMS.reports.wfrmReceipt.ReportReference = "LMS-003-01";
					Response.Write("<script language = 'javascript'>window.open('../reports/wfrmReceipt.aspx?reportID=001','_blank','resizable')</script>");
					LblMessage.Text = LIMS.reports.wfrmReceipt.mMessage.ToString();
				}
				else
				{
					LblMessage.ForeColor = Color.Red;
					//LblMessage.Text = "Please enter new receipt number";					
				}

				RefreshForm();
				LblMessage.ForeColor = Color.Green;				
				LblMessage.Text = "Entry Successfully Completed";
			}
			else
			{
				this.LblMessage.Text = receiption.ErrorMessage;
			}
		}

		private void RefreshForm()
		{
			this.LblMessage.Text = "";
			mode = "Insert";
			dtSelectedTest.Rows.Clear();
			this.DGSelectedTest.DataSource = dtSelectedTest;
			this.DGSelectedTest.DataBind();
			
			this.TxtEFName.Text = "";
			this.TxtEMName.Text = "";
			this.TxtELName.Text = "";
			this.TxtPLNo.Text = "";
			this.txtOfficePhone.Text = "";
			this.txtMobileNo.Text = "";
			this.txtEmail.Text = "";
			this.TxtHPhone.Text = "";
			this.TxtAddress.Text = "";
			this.txtKinFName.Text = "";
			this.txtKinMName.Text = "";
			this.txtKinLName.Text = "";			
			this.TxtPFName.Text = "";
			this.TxtPMName.Text = "";
			this.TxtPLName.Text = "";
			this.TxtDOB.Text = "";
			this.TxtAge.Text = "";
			this.TxtPatientNo.Text = "";
			this.TxtRequestNo.Text = "";
			this.ddlWard.SelectedIndex = 0;
			this.TxtAdmDate.Text = "";
			this.TxtDiscountPer.Text = "";
			this.TxtAmount.Text = "";
			this.txtPaidAmount.Text = "";
			this.txtPaidNo.Text = "";
			this.txtReferredBy.Text = "";
			this.LblNoTest.Text = "";
			this.CmbPanel.SelectedIndex = 0;
			this.CmbRank.SelectedIndex = 0;
			this.txtUnit.Text = "";
			this.txtRank.Text = "";
			this.txtUnit.ToolTip = "";
			this.txtRank.ToolTip = "";
			this.CmbRelationShip.SelectedIndex = 0;
			this.CmbRelationShip2.SelectedIndex = 0;

			this.CmbPanelP.SelectedIndex = 0;
			this.TxtPLNoP.Text = "";
			this.txtReferenceNoP.Text = "";
			this.TxtEFNameP.Text = "";
			this.TxtEMNameP.Text = "";
			this.TxtELNameP.Text = "";			
			this.txtOfficePhoneP.Text = "";
			this.txtMobileNoP.Text = "";
			this.txtEmailP.Text = "";
			this.TxtHPhoneP.Text = "";
			this.TxtAddressP.Text = "";

			try
			{	
				this.CmbUnit.Items.Clear();	
				this.CmbUnit.Enabled = false;	
			}
			catch{}

			try
			{	
				this.CmbRank.Items.Clear();	
				this.CmbRank.Enabled = false;	
			}
			catch{}
		}
		
		private void FillForm(ArrayList formValues)
		{
			//	Employee
			RdoEntitled.SelectedIndex = int.Parse(formValues[0].ToString());
			RdoRequestType.SelectedIndex = int.Parse(formValues[1].ToString());
			RdoIOP.SelectedIndex= int.Parse(formValues[2].ToString());
			if (RdoEntitled.SelectedValue.Equals("E"))
			{
				this.CmbTitle.SelectedIndex = int.Parse(formValues[3].ToString());
				this.TxtEFName.Text = formValues[4].ToString();
				this.TxtEMName.Text = formValues[5].ToString();
				this.TxtELName.Text = formValues[6].ToString();
				this.CmbPanel.SelectedIndex = int.Parse(formValues[7].ToString());

				if(this.CmbPanel.SelectedItem.Value != "-1")
				{
					FillSectionDDL();
					this.CmbUnit.Enabled = true;
					this.CmbUnit.SelectedIndex = int.Parse(formValues[8].ToString());
				}
				else
				{
					this.CmbUnit.Enabled = false;
				}

				if(this.CmbPanel.SelectedItem.Value != "-1")
				{
					FillRankDDL();
					this.CmbRank.Enabled = true;
					this.CmbRank.SelectedIndex = int.Parse(formValues[10].ToString());
				}
				else
				{
					this.CmbRank.Enabled = false;
				}

				this.TxtPLNo.Text = formValues[9].ToString();
			
				this.txtOfficePhone.Text = formValues[11].ToString();
				this.txtMobileNo.Text = formValues[12].ToString();
				this.txtEmail.Text = formValues[13].ToString();
				this.TxtHPhone.Text = formValues[14].ToString();
				this.TxtAddress.Text = formValues[15].ToString();				
			} 
			else
				if (RdoEntitled.SelectedValue.Equals("P"))				
			{
				this.cmbTitleP.SelectedIndex = int.Parse(formValues[3].ToString());
				this.TxtEFNameP.Text = formValues[4].ToString();
				this.TxtEMNameP.Text = formValues[5].ToString();
				this.TxtELNameP.Text = formValues[6].ToString();
				this.CmbPanelP.SelectedIndex = int.Parse(formValues[7].ToString());					
				this.TxtPLNoP.Text = formValues[9].ToString();			
				this.txtOfficePhoneP.Text = formValues[11].ToString();
				this.txtMobileNoP.Text = formValues[12].ToString();
				this.txtEmailP.Text = formValues[13].ToString();
				this.TxtHPhoneP.Text = formValues[14].ToString();
				this.TxtAddressP.Text = formValues[15].ToString();				
			} 

			//	Patient
			this.ddlPTitle.SelectedIndex = int.Parse(formValues[16].ToString());
			this.TxtPFName.Text = formValues[17].ToString();
			this.TxtPMName.Text = formValues[18].ToString();
			this.TxtPLName.Text = formValues[19].ToString();
			this.CmbGender.SelectedIndex = int.Parse(formValues[20].ToString());
			this.TxtDOB.Text = formValues[21].ToString();
			this.TxtAge.Text = formValues[22].ToString();
			this.CmbAgeType.SelectedIndex = int.Parse(formValues[23].ToString());			
			this.CmbRelationShip.SelectedIndex = int.Parse(formValues[24].ToString());
			this.TxtPatientNo.Text = formValues[25].ToString();
			this.txtKinFName.Text = formValues[35].ToString();
			this.txtKinMName.Text = formValues[36].ToString();
			this.txtKinLName.Text = formValues[37].ToString();
			this.txtPaidAmount.Text = formValues[34].ToString();			
			this.txtPaidNo.Text = formValues[45].ToString();			
			this.txtReferredBy.Text = formValues[38].ToString();			
			this.txtUnit.Text = formValues[39].ToString();			
			this.txtRank.Text = formValues[40].ToString();			
			this.txtUnit.ToolTip = formValues[41].ToString();			
			this.txtRank.ToolTip = formValues[42].ToString();			
			this.txtReferenceNoP.Text = formValues[43].ToString();			
			this.CmbRelationShip2.SelectedIndex = int.Parse(formValues[44].ToString());

			//	Test
			CmbResultDespatch.SelectedIndex = int.Parse(formValues[26].ToString());
			TxtRequestNo.Text = formValues[27].ToString();
			CmbPaymentMode.SelectedIndex = int.Parse(formValues[28].ToString());
			ddlWard.SelectedIndex = int.Parse(formValues[29].ToString());
			TxtAdmDate.Text = formValues[30].ToString();
			TxtDiscountPer.Text = formValues[31].ToString();
			TxtAmount.Text = formValues[32].ToString();
			dtSelectedTest = (DataTable) formValues[33];
			
			DGSelectedTest.DataSource = dtSelectedTest;
			DGSelectedTest.DataBind();
			Session.Remove("ReceptionFormValues");

			double totalAmount = 0;

			for(int i = 0; i < dtSelectedTest.Rows.Count; i++)
			{
				totalAmount += double.Parse(dtSelectedTest.Rows[i]["Charges"].ToString());
			}
			
			try
			{
				double per = double.Parse(TxtDiscountPer.Text);
				per = (totalAmount - ((per/100)*totalAmount));
				TxtAmount.Text = per.ToString();
			}
			catch(Exception err)
			{
				TxtAmount.Text = totalAmount.ToString();
			}
		}

		private void FillSectionDDL()
		{
			clsBLFacSection objSection = new clsBLFacSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			objSection.OrgID = "01";
			objSection.FactoryID = this.CmbPanel.SelectedItem.Value;
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.CmbUnit, dvSection, "SectionName", "SectionID");
			//objComp.FillDropDownList(this.CmbUnit, dvSection, "SectionName", "SectionID", true, false, false);
			//objComp.FillDropDownList(this.CmbPanel, dvFactory, "FactoryName", "FactoryID");
		}

		private void FillRankDDL()
		{
			clsBLRank ObjRank = new clsBLRank();
			SComponents objComp = new SComponents();

			ObjRank.Active = "Y";
			ObjRank.OrgID = "01";
			ObjRank.FactoryID = this.CmbPanel.SelectedItem.Value;
			DataView dvRank = ObjRank.GetAll(1);
			objComp.FillDropDownList(this.CmbRank, dvRank, "RankName", "RankID");		
		}	

		#endregion

		#region Form Event

		protected void ButSave_Click(object sender, System.EventArgs e)
		{
			double totalAmount = 0;

			for(int i = 0; i < dtSelectedTest.Rows.Count; i++)
			{
				totalAmount += double.Parse(dtSelectedTest.Rows[i]["Charges"].ToString());
			}

			try
			{
				double per = double.Parse(TxtDiscountPer.Text);
				per = (totalAmount - ((per/100)*totalAmount));
				TxtAmount.Text = per.ToString();
			}
			catch(Exception err)
			{
				TxtAmount.Text = totalAmount.ToString();
			}		

			if(mode.Equals("Insert"))
			{		
				string sError = "";
				string sRank = "";
				string sUnit = "";
				if (RdoEntitled.SelectedValue.Equals("E"))
				{
					// check and save Units;					
					clsBLFacSection objSection = new clsBLFacSection();
					objSection.SectionName = txtUnit.Text;
					objSection.FactoryID = CmbPanel.SelectedValue;
					DataView dvUnit = objSection.GetAll(1);					
					if (dvUnit.Count == 0)
					{	
						objSection.SectionName = txtUnit.Text.Trim();
						objSection.FactoryID = CmbPanel.SelectedValue;
						objSection.Active = "Y";
						objSection.OrgID = "01";
						sUnit = objSection.Insert();
						if (sUnit.Equals("Error"))
						{					
							LblMessage.Text = objSection.ErrorMessage;
							sError = objSection.ErrorMessage;
						}
						else
						{
							txtUnit.ToolTip = sUnit;						
						}					
					} 
					else
					{
						txtUnit.ToolTip = dvUnit[0]["SectionID"].ToString();
					}										
					
					// check and save Ranks;
					clsBLRank ObjRank = new clsBLRank();
					ObjRank.RankName = txtRank.Text;			
					ObjRank.FactoryID = CmbPanel.SelectedValue;
					DataView dvRank = ObjRank.GetAll(1);					
					if (dvRank.Count == 0)
					{						
						ObjRank.RankName = txtRank.Text.Trim();
						ObjRank.Active = "Y";
						ObjRank.OrgID = "01";
						ObjRank.FactoryID = CmbPanel.SelectedValue;
						sRank = ObjRank.Insert();
						if (sRank.Equals("Error"))
						{					
							LblMessage.Text = ObjRank.ErrorMessage;
							sError = ObjRank.ErrorMessage;
						}
						else
						{
							txtRank.ToolTip = sRank;
						}
					} 
					else
					{
						txtRank.ToolTip = dvRank[0]["RankID"].ToString();
					}					
				}

				if (sError .Equals(""))
				{
					Save();
				}
				else
				{
					//
				}
			}
		}

		private void DGSelectedTest_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DGSelectedTest.CurrentPageIndex = e.NewPageIndex;
			this.DGSelectedTest.DataSource = dtSelectedTest;
			this.DGSelectedTest.DataBind();
		}

		protected void ButClear_Click(object sender, System.EventArgs e)
		{
			RdoEntitled.SelectedIndex = 0;
			RdoRequestType.SelectedIndex = 0;
			RdoIOP.SelectedIndex = 0;
			RefreshForm();
		}

		protected void ButSelectedTest_Click(object sender, System.EventArgs e)
		{
			LblMessage.Text = "";
			
			try
			{
				if(!TxtAge.Text.Equals("") && Int16.Parse(TxtAge.Text) > 0)
				{
					int year = Int16.Parse(TxtAge.Text);
			
					if(CmbAgeType.SelectedValue.ToString().Equals("Y"))
						year = year * 365;
					else if(CmbAgeType.SelectedValue.ToString().Equals("M"))
						year = year * 30;
					else if(CmbAgeType.SelectedValue.ToString().Equals("W"))
						year = year * 7;
					else if(CmbAgeType.SelectedValue.ToString().Equals("D"))
						year = year;

					MakeSession();
					Response.Write("<script language='javascript'> window.open('wfrmSearchTest.aspx?gender="+CmbGender.SelectedValue+"&age="+year+"', '', 'channelmode'); </script>");
				}
				else
				{
					LblMessage.Text = "<br>Please enter patient age.<br><br>";
				}
			}
			catch(Exception err)
			{
				LblMessage.Text = "<br>Please enter valid age.<br><br>";
			}
		}

		private void MakeSession()
		{
			ArrayList formValues = new ArrayList();
			//	Employee
			formValues.Add(RdoEntitled.SelectedIndex);				// 0	First Radio
			formValues.Add(RdoRequestType.SelectedIndex);			// 1	Second Radio
			formValues.Add(RdoIOP.SelectedIndex);					// 2	Third Radio
			if (RdoEntitled.SelectedValue.Equals("E"))
			{
				formValues.Add(this.CmbTitle.SelectedIndex);			// 3	Employee Title
				formValues.Add(this.TxtEFName.Text);					// 4	Employee First Name
				formValues.Add(this.TxtEMName.Text);					// 5	Employee Middle Name
				formValues.Add(this.TxtELName.Text);					// 6	Employee Last Name
				formValues.Add(this.CmbPanel.SelectedIndex);			// 7	Factory
				formValues.Add(this.CmbUnit.SelectedIndex);				// 8	Section
				formValues.Add(this.TxtPLNo.Text);						// 9	PL No
				formValues.Add(CmbRank.SelectedIndex);					// 10	Rank
				formValues.Add(this.txtOfficePhone.Text);				// 11	Ofice Phone
				formValues.Add(this.txtMobileNo.Text);					// 12	Mobile Phone
				formValues.Add(this.txtEmail.Text);						// 13	Email
				formValues.Add(this.TxtHPhone.Text);					// 14	Home Phone
				formValues.Add(this.TxtAddress.Text);					// 15	Address
			} 
			else
				if (RdoEntitled.SelectedValue.Equals("P"))
			{
				formValues.Add(this.cmbTitleP.SelectedIndex);			// 3	Employee Title
				formValues.Add(this.TxtEFNameP.Text);					// 4	Employee First Name
				formValues.Add(this.TxtEMNameP.Text);					// 5	Employee Middle Name
				formValues.Add(this.TxtELNameP.Text);					// 6	Employee Last Name
				formValues.Add(this.CmbPanelP.SelectedIndex);			// 7	Factory
				formValues.Add("");				// 8	Section
				formValues.Add(this.TxtPLNoP.Text);						// 9	PL No
				formValues.Add("");					// 10	Rank
				formValues.Add(this.txtOfficePhoneP.Text);				// 11	Ofice Phone
				formValues.Add(this.txtMobileNoP.Text);					// 12	Mobile Phone
				formValues.Add(this.txtEmailP.Text);						// 13	Email
				formValues.Add(this.TxtHPhoneP.Text);					// 14	Home Phone
				formValues.Add(this.TxtAddressP.Text);					// 15	Address
			} else				
			{
				formValues.Add("");				// 3	Employee Title
				formValues.Add("");				// 4	Employee First Name
				formValues.Add("");				// 5	Employee Middle Name
				formValues.Add("");				// 6	Employee Last Name
				formValues.Add("");				// 7	Factory
				formValues.Add("");				// 8	Section
				formValues.Add("");				// 9	PL No
				formValues.Add("");				// 10	Rank
				formValues.Add("");				// 11	Ofice Phone
				formValues.Add("");				// 12	Mobile Phone
				formValues.Add("");				// 13	Email
				formValues.Add("");				// 14	Home Phone
				formValues.Add("");				// 15	Address
			}
			//	Patient
			formValues.Add(this.ddlPTitle.SelectedIndex);			// 16	Patient Title
			formValues.Add(this.TxtPFName.Text);					// 17	Patient FName
			formValues.Add(this.TxtPMName.Text);					// 18	Patient MName
			formValues.Add(this.TxtPLName.Text);					// 19	Patient LName
			formValues.Add(this.CmbGender.SelectedIndex);			// 20	Patient Gender
			formValues.Add(this.TxtDOB.Text);						// 21	Patient DOB
			formValues.Add(this.TxtAge.Text);						// 22	Patient Age
			formValues.Add(this.CmbAgeType.SelectedIndex);			// 23	Patient Age Type			
			formValues.Add(this.CmbRelationShip.SelectedIndex);		// 24	Patient Relation
			formValues.Add(this.TxtPatientNo.Text);					// 25	Patient ID
			//	Test
			formValues.Add(this.CmbResultDespatch.SelectedIndex);	// 26	Result Dispatch
			formValues.Add(this.TxtRequestNo.Text);					// 27	Request No
			formValues.Add(this.CmbPaymentMode.SelectedIndex);		// 28	Payment Mode
			formValues.Add(this.ddlWard.SelectedIndex);					// 29	Ward No
			formValues.Add(this.TxtAdmDate.Text);					// 30	Admission Date
			formValues.Add(this.TxtDiscountPer.Text);				// 31	Discount
			formValues.Add(this.TxtAmount.Text);					// 32	Total Amount
			formValues.Add(dtSelectedTest);							// 33	Selected Tests Data Table
			formValues.Add(this.txtPaidAmount.Text);				// 34	Selected Tests Data Table
			formValues.Add(this.txtKinFName.Text);					// 35	Selected Tests Data Table
			formValues.Add(this.txtKinMName.Text);					// 36	Selected Tests Data Table
			formValues.Add(this.txtKinLName.Text);					// 37	Selected Tests Data Table
			formValues.Add(this.txtReferredBy.Text);					// 38	Selected Tests Data Table	
			formValues.Add(this.txtUnit.Text);					// 39	Unit
			formValues.Add(this.txtRank.Text);					// 40	Selected Tests Data Table		
			formValues.Add(this.txtUnit.ToolTip);					// 41	Selected Tests Data Table		
			formValues.Add(this.txtRank.ToolTip);					// 42	Selected Tests Data Table		

			//Panel
			formValues.Add(this.txtReferenceNoP.Text);			// 43	Employee Title			
			formValues.Add(this.CmbRelationShip2.SelectedIndex);		// 44	Patient Relation
			formValues.Add(this.txtPaidNo.Text);		// 45	Patient Relation

			try
			{
				Session.Remove("ReceptionFormValues");
			}
			catch{}

			Session.Add("ReceptionFormValues", formValues);
		}

		private void DGSelectedTest_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Delete"))
			{
				int index = e.Item.ItemIndex;
				receiption = new clsBLReceiption();
				dtSelectedTest = receiption.RemoveTest(dtSelectedTest.DefaultView, index).Table;
				DGSelectedTest.DataSource = dtSelectedTest;
				DGSelectedTest.DataBind();
				TxtAmount.Text = Convert.ToString(receiption.GetTotalAmount());

				double totalAmount = 0;
				for(int i = 0;i < dtSelectedTest.Rows.Count; i++)
				{
					totalAmount += double.Parse(dtSelectedTest.Rows[i]["Charges"].ToString());
				}
			
				try
				{
					double per = double.Parse(TxtDiscountPer.Text);
					per = (totalAmount - ((per/100)*totalAmount));
					TxtAmount.Text = per.ToString();
				}
				catch(Exception err)
				{
					TxtAmount.Text = totalAmount.ToString();
				}
			}
		}

		#endregion

		protected void CmbPanel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.CmbPanel.SelectedItem.Value != "-1")
			{
				FillSectionDDL();
				this.CmbUnit.Enabled = true;

				FillRankDDL();
				this.CmbRank.Enabled = true;
			}
			else
			{
				this.CmbUnit.SelectedItem.Selected = false;
				this.CmbUnit.Items.FindByValue("-1").Selected = true;
				this.CmbUnit.Enabled = false;
				this.txtUnit.Text = "";

				this.CmbRank.SelectedItem.Selected = false;
				this.CmbRank.Items.FindByValue("-1").Selected = true;
				this.CmbRank.Enabled = false;				
				this.txtRank.Text = "";
			}
		}

		protected void RdoEntitled_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LblMessage.Text = "";			
		}

		protected void RdoIOP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LblMessage.Text = "";
		}

		private void CmbRelationShip_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			/*this.LblMessage.Text = "";

			if (RdoEntitled.SelectedValue.Equals("E"))
			{
				if(this.CmbRelationShip.SelectedItem.Value.Equals("Self"))
				{
					this.ddlPTitle.SelectedItem.Selected = false;
					this.ddlPTitle.Items.FindByValue(CmbTitle.SelectedValue).Selected = true;
					this.TxtPFName.Text = this.TxtEFName.Text;
					this.TxtPMName.Text = this.TxtEMName.Text;
					this.TxtPLName.Text = this.TxtELName.Text;
				}
			}
			else if (RdoEntitled.SelectedValue.Equals("C"))
			{
				if(this.CmbRelationShip.SelectedItem.Value.Equals("Self"))
				{
					this.TxtPFName.Text = this.txtKinFName.Text;
					this.TxtPMName.Text = this.txtKinMName.Text;
					this.TxtPLName.Text = this.txtKinLName.Text;
				}
			}*/			
		}

		private void lbtnSearch_Click(object sender, System.EventArgs e)
		{
			this.LblMessage.Text = "";
			MakeSession();
			Response.Write("<script language='javascript'>window.open('SearchPR.aspx', '', 'channelmode');</script>");

		}

		protected void lnkbPrintLastReceipt_Click(object sender, System.EventArgs e)
		{
			LIMS.reports.wfrmReceipt.mFilterString = "";
			LIMS.reports.wfrmReceipt.ReportReference = "LMS-003-02";
			Response.Write("<script language = 'javascript'>window.open('../reports/wfrmReceipt.aspx?reportID=001','_blank','resizable')</script>");
			if (!LIMS.reports.wfrmReceipt.mMessage.Equals(""))
			{
				LblMessage.ForeColor = Color.Red;
				LblMessage.Text = LIMS.reports.wfrmReceipt.mMessage.ToString();
			}

		}	

		protected void ddlDiscountLevel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			TxtDiscountPer.Text = "";
			clsBLTDiscountLevel objDiscountLevel = new clsBLTDiscountLevel();
			objDiscountLevel.DiscountID = ddlDiscountLevel.SelectedValue.ToString();
			DataView dvDiscountLevel = objDiscountLevel.GetAll(2);
			TxtDiscountPer.Text = dvDiscountLevel.Table.Rows[0]["Discount"].ToString();					
		}

		private void CmbUnit_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!CmbUnit.SelectedItem.Equals("Select"))
			{
				txtUnit.Text = CmbUnit.SelectedItem.ToString();
				txtUnit.ToolTip = CmbUnit.SelectedValue.ToString();
			} 
			else 
			{
				txtUnit.Text = "";
				txtUnit.ToolTip = "";
			}

		}

		private void CmbRank_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!CmbRank.SelectedItem.Equals("Select"))
			{
				txtRank.Text = CmbRank.SelectedItem.ToString();
				txtRank.ToolTip = CmbRank.SelectedValue.ToString();
			}
			else
			{
				txtRank.Text = "";
				txtRank.ToolTip = "";
			}
		}

		public int GetIndex(DropDownList ddl, string sValue)
		{
			try
			{
				for(int i=0; i < ddl.Items.Count; i++)
				{
					if (ddl.Items[i].Text.ToUpper() ==sValue.ToUpper())
					{
						return i;
					}
				}
			}
			catch{}
			return -1;				
		}

		private void txtUnit_TextChanged(object sender, System.EventArgs e)
		{			
			//CmbUnit.SelectedIndex = GetIndex(CmbUnit, txtUnit.Text);
		}

		protected void txtRank_TextChanged(object sender, System.EventArgs e)
		{
			//CmbRank.SelectedIndex = GetIndex(CmbRank, txtRank.Text);
		}

		protected void CmbRelationShip_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			if (CmbRelationShip.SelectedValue.Equals("Self"))
			{
				txtKinFName.Text = 	TxtPFName.Text;
				txtKinMName.Text = 	TxtPMName.Text;
				txtKinLName.Text = 	TxtPLName.Text;
			}		
		}

		protected void CmbRelationShip2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (CmbRelationShip2.SelectedValue.Equals("Self"))
			{
				if (RdoEntitled.SelectedValue.Equals("E")) 
				{
					TxtPFName.Text = TxtEFName.Text;
					TxtPMName.Text = TxtEMName.Text;
					TxtPLName.Text = TxtELName.Text;
				} 
				else
				{
					TxtPFName.Text = TxtEFNameP.Text;
					TxtPMName.Text = TxtEMNameP.Text;
					TxtPLName.Text = TxtELNameP.Text;
				}

			}				
		}
	}
}