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
using System.IO;
using System.Globalization;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmResultDispatcher.
	/// </summary>
	public partial class wfrmResultDispatcher : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "107";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}

					this.lblErrMsg.Text = "";
					this.lblRecordNo.Text = "";
					FillReportDDL();
					FillSectionDDL();
					FillWardDDL();
                    txtDF.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
                    txtDT.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                    FillDG();
                    txtMSerialNoFrom.Focus();
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
			this.dgResultDis.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgResultDis_ItemCommand);

		}
		#endregion

		private void FillWardDDL()
		{
			// getting Ward list
			SComponents objComp = new SComponents();
			clsBLWard objWard = new clsBLWard();
			objWard.Active = "Y";
			DataView dvWard = objWard.GetAll(1);
			objComp.FillDropDownList(this.ddlWard, dvWard, "WardName", "WardID");
		}

		private void FillReportDDL()
		{
            clsBLExternalOrganization objOrganization = new clsBLExternalOrganization();
			SComponents objComp = new SComponents();

            DataView dvReport = objOrganization.GetAll(3);
            objComp.FillDropDownList(this.ddlOrganization, dvReport, "name", "orgid", true, false, true);
		}

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			objComp.FillDropDownList(this.ddlSection, dvSection, "SectionName", "SectionID"); 
		}

		private void RefreshForm()
		{		
			this.ddlSection.SelectedItem.Selected = false;
			this.ddlSection.Items.FindByValue("-1").Selected = true;

			this.txtPatientName.Text = "";

			try{	this.ddlTestGroup.Items.Clear();	}
			catch{}
			this.ddlTestGroup.Enabled = false;

			this.ddlSex.SelectedItem.Selected = false;
			this.ddlSex.Items.FindByValue("-1").Selected = true;

			try{	this.ddlTest.Items.Clear();	}
			catch{}
			this.ddlTest.Enabled = false;

			this.txtMSerialNoFrom.Text = "";
			this.txtMSerialNoTo.Text = "";

			try{	this.ddlWard.Items.Clear();	}
			catch{}
			this.ddlWard.Enabled = false;

			this.rbtnPatientType.SelectedIndex = 0;
            txtMSerialNoFrom.Focus();
		}

		private void FillDG()
		{
			this.chkSelect.Checked = false;
			this.lblErrMsg.Text = "";
			this.lblRecordNo.Text = "";
            string processIDs = "'abcd',";
			clsBLSpecimenColletion objSpecimenCol = new clsBLSpecimenColletion();
			
			# region "Parameters Conditions"
            if (chkUnpaid.Checked == true)
            {
                processIDs += "'0008',";
            }
            if (chkSpecimen.Checked == true)
            {
                processIDs += "'0002',";
            }
            if (chkSpecimenOutQueue.Checked)
            {
                processIDs += "'0009',";

            }
            if (chkSpecomenInQueue.Checked)
            {
                processIDs += "'0010',";

            }

            if (chkREntry.Checked == true)
            {
                processIDs += "'0004',";
            }
            if (chkVerification.Checked == true)
            {
                processIDs += "'0005',";
            }
            if (chkDispatch.Checked == true)
            {
                processIDs += "'0006',";
            }
            if (chkDelivered.Checked == true)
            {
                processIDs += "'0007',";
            }
            if (chkSpecimenPending.Checked)
            {
                processIDs += "'0011',";
            }
            processIDs = processIDs.Substring(0, processIDs.Length - 1);

            objSpecimenCol.ProcessIDVary = processIDs;
            //if(this.rbtnlArchiver.SelectedItem.Value.Equals("N"))
            //{
            //    objSpecimenCol.ProcessIDVary = "0006";
            //}
            //else
            //{
            //    objSpecimenCol.ProcessIDVary = "0007";
            //}		

			if(!this.txtDF.Text.Equals(""))
			{ 
				objSpecimenCol.EnteredateF = this.txtDF.Text;
			}

			if(!this.txtDT.Text.Equals(""))
			{ 
				objSpecimenCol.EnteredateT = DateTime.Parse(this.txtDT.Text,new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
			}

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{ 
				objSpecimenCol.SectionID = this.ddlSection.SelectedItem.Value;
			}

			if(!this.txtPRNo.Text.Replace("__-__-______","").Equals(""))
			{
				objSpecimenCol.PLNo = this.txtPRNo.Text.Trim();
			}

			try
			{
				if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.TestGroupID = this.ddlTestGroup.SelectedItem.Value;
				}
			}	
			catch{}
			
			try
			{
				if(!this.ddlTest.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.TestID = this.ddlTest.SelectedItem.Value;
				}
			}
			catch{}

			if(!this.txtPatientName.Text.Equals(""))
			{ 
				objSpecimenCol.PatientName = this.txtPatientName.Text;
			}
			
			if(!this.ddlSex.SelectedItem.Value.Equals("-1"))
			{ 
				objSpecimenCol.Sex = this.ddlSex.SelectedItem.Value;
			}

			if(this.txtMSerialNoFrom.Text.Replace("__-___-_______","").Trim() != "")
			{ 
				objSpecimenCol.LabIDFrom = this.txtMSerialNoFrom.Text;
			}
			
			if(this.txtMSerialNoTo.Text.Replace("__-___-_______","").Trim() != "")
			{ 
				objSpecimenCol.LabIDTo = this.txtMSerialNoTo.Text;
			}
			
			try
			{
				if(!this.ddlWard.SelectedItem.Value.Equals("-1"))
				{ 
					objSpecimenCol.WardID = this.ddlWard.SelectedItem.Value;
				}
			}
			catch{}

			if (!this.rbtnPatientType.SelectedItem.Value.Equals("A")) 
			{
				objSpecimenCol.PatientType = this.rbtnPatientType.SelectedItem.Value;	
			}

			if (!this.rbtnIO.SelectedItem.Value.Equals("A")) 
			{
				objSpecimenCol.IOPatient = this.rbtnIO.SelectedItem.Value;	
			}
            if (!ddlOrganization.SelectedValue.ToString().Trim().Equals("-1"))
            {
                objSpecimenCol.Extorgid = ddlOrganization.SelectedValue.ToString().Trim();
            }

			# endregion

			DataView dvSpecimenCol = objSpecimenCol.GetAll(3);

			if(dvSpecimenCol.Count > 0)
			{
                if (dvSpecimenCol.Count < 31)
                {
                    dgResultDis.AllowPaging = false;
                }
                else
                {
                    dgResultDis.AllowPaging = true;
                }
				lblRecordNo.Text = "Record fetched : " + dvSpecimenCol.Count.ToString();
				this.dgResultDis.DataSource = dvSpecimenCol;
				this.dgResultDis.DataBind();
				this.dgResultDis.Visible = true;
			}
			else
			{
				this.dgResultDis.Visible = false;
				lblRecordNo.Text = "Record not found.";
			}
		}

		protected void ddlSection_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(!this.ddlSection.SelectedItem.Value.Equals("-1"))
			{
				FillTestGroupDDL();
				this.ddlTestGroup.Enabled = true;

				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
			}
			else
			{
				try{	this.ddlTestGroup.Items.Clear();	}
				catch{}
				this.ddlTestGroup.Enabled = false;
				
				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
			}
		}

		private void FillTestGroupDDL()
		{
			clsBLTestGroup objTestGroup = new clsBLTestGroup();
			SComponents objComp = new SComponents();

			objTestGroup.Active = "Y";
			objTestGroup.SectionID = ddlSection.SelectedValue;
			DataView dvTestGroup = objTestGroup.GetAll(3);
			objComp.FillDropDownList(this.ddlTestGroup, dvTestGroup, "TestGroup", "TestGroupID");
		}

		protected void lbtnRefresh_Click(object sender, System.EventArgs e)
		{
			FillDG();
		}

		protected void lbtnAll_Click(object sender, System.EventArgs e)
		{
			RefreshForm();
			FillDG();
		}

		protected void ddlTestGroup_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.lblErrMsg.Text = "";

			if(!this.ddlTestGroup.SelectedItem.Value.Equals("-1"))
			{
				FillTestDDL();
				this.ddlTest.Enabled = true;
			}
			else
			{
				try{	this.ddlTest.Items.Clear();	}
				catch{}
				this.ddlTest.Enabled = false;
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

		protected void lbtnPrint_Click(object sender, System.EventArgs e)
		{
			string selectionFormula = "";
			string[] aryToArchive = new string[this.dgResultDis.Items.Count+1];
			int counter = 0;
            int count_unchecked = 0;
            int alertcount = 0;

			foreach(DataGridItem dgItem in this.dgResultDis.Items)
			{
                if (((CheckBox)dgItem.Cells[0].FindControl("dgchkPrint")).Checked == true)
                {
                    if ((dgResultDis.Items[dgItem.ItemIndex].Cells[16].Text == "0006" || dgResultDis.Items[dgItem.ItemIndex].Cells[16].Text.Trim() == "0007" || dgResultDis.Items[dgItem.ItemIndex].Cells[16].Text.Trim() == "0005"))
                    {

                        selectionFormula += "" + dgItem.Cells[13].Text + ",";

                        if (this.rbtnlArchiver.SelectedItem.Value.Equals("N") && this.chkArchived.Checked == true)
                        {
                            aryToArchive[counter] = dgItem.Cells[13].Text;
                            counter++;
                        }
                    }
                    else
                    {
                        if (alertcount == 0)
                        {
                            Response.Write("<script language='javascript'>alert('Some Required Results not Ready yet.');</script>");
                            alertcount++;
                        }
                    }

                }
                else
                {
                    count_unchecked++;
                }

			}
            if (count_unchecked == dgResultDis.Items.Count)
            {
                Response.Write("<script language='javascript'>alert('No Test selected.');</script>");
            }

			LIMS.reports.GeneralReports.mFilterString = "";

			if(!selectionFormula.Equals(""))
			{
				selectionFormula = selectionFormula.Remove(selectionFormula.LastIndexOf(","), 1);
				LIMS.reports.GeneralReports.mFilterString = "{LS_VGENERALREPORT2.DSerialNo} in [" + selectionFormula + "]";
			

				LIMS.reports.GeneralReports.PdfSetting = null;
                LIMS.reports.GeneralReports.ReportReference = "LMS-001-11";//this.ddlReportType.SelectedItem.Value;
				LIMS.reports.GeneralReports.mFromDate = "";
				LIMS.reports.GeneralReports.mToDate = "";

				//Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','resizable')</script>");

				Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx?reportID=LMS-001-11','_blank','resizable')</script>");		

				clsBLDTransaction objDTrans = new clsBLDTransaction();

				if(this.rbtnlArchiver.SelectedItem.Value.Equals("N"))
				{
					objDTrans.UpdateToArchived(aryToArchive);
					FillDG();
				}
			}
		}

		protected void rbtnlArchiver_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rbtnlArchiver.SelectedItem.Value.Equals("N"))
			{
				this.chkArchived.Enabled = true;
			}
			else
			{
				this.chkArchived.Enabled = false;
			}

			FillDG();
		}

		private void dgResultDis_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Details"))
			{
				Response.Write("<script language = 'javascript'>window.open('wfrmPatientTestStatus.aspx?mserialno=" + e.Item.Cells[2].Text + "','','channelmode')</script>"); 
			}
			else if(e.CommandName.Equals("SenttoResultEntry"))
			{
				clsBLDTransaction objTDTransaction = new clsBLDTransaction();
			
			
				objTDTransaction.DSerialNo = e.Item.Cells[13].Text;
				objTDTransaction.ProcessID = "0004";	
				bool isSuccessful = objTDTransaction.UpdateReLocation();

				if(!isSuccessful)
				{
					this.lblRecordNo.Text = "<br>" + objTDTransaction.ErrorMessage + "<br><br>";
				}
				else
				{
					this.lblRecordNo.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
					FillDG();
				}			
			}
            else if (e.CommandName.Equals("Attachment"))
            {
 
            }
		}

		protected void dgResultDis_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		protected void chkSelect_CheckedChanged(object sender, System.EventArgs e)
		{
			foreach(DataGridItem dgItem in this.dgResultDis.Items)
			{
				((CheckBox)dgItem.Cells[0].FindControl("dgchkPrint")).Checked = chkSelect.Checked;				
			}		
		}

        protected void dgResultDis_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[16].Text.Trim() == "0002")//Specimen
                {
                    e.Item.BackColor = System.Drawing.Color.Yellow;
                }
                if (e.Item.Cells[16].Text.Trim() == "0004")//Result Entry
                {
                    e.Item.BackColor = System.Drawing.Color.Aqua;//66ccff
                }
                if (e.Item.Cells[16].Text.Trim() == "0005")//Result verification
                {
                    e.Item.BackColor = System.Drawing.Color.Orchid;//ffccff
                }
                if (e.Item.Cells[16].Text.Trim() == "0006")//Result Dispatch
                {
                    e.Item.BackColor = System.Drawing.Color.White;//FromName("White");
                }
                if (e.Item.Cells[16].Text.Trim() == "0007")//Delivered
                {
                    e.Item.BackColor = System.Drawing.Color.SpringGreen;
                }
                if (e.Item.Cells[16].Text.Trim() == "0008")//Unpaid or Cash Reception
                {
                    e.Item.BackColor = System.Drawing.Color.BurlyWood;
                }
                if (e.Item.Cells[16].Text.Trim() == "0009")//Specimen Out QUeue
                {
                    e.Item.BackColor = System.Drawing.Color.SeaShell;
                }
                if (e.Item.Cells[16].Text.Trim() == "0010")//Specimen In Queue
                {
                    e.Item.BackColor = System.Drawing.Color.RoyalBlue;
                }
                if (e.Item.Cells[16].Text.Trim() == "0011")//Pending Specimen Queue
                {
                    e.Item.BackColor = System.Drawing.Color.FromName("#993333");
                }
                if (!e.Item.Cells[17].Text.Trim().Equals("xxxx") && (Convert.ToInt16(e.Item.Cells[16].Text)<6 || Convert.ToInt16(e.Item.Cells[16].Text)==8))
                {
                    e.Item.BackColor = System.Drawing.Color.Green;
                    e.Item.ToolTip = e.Item.Cells[17].Text.Trim();
                    
                }
               // e.Item.Attributes.Add("oncontextmenu", "return ShowMenu(event,'"+e.Item.Cells[4].Text.Trim()+"')");
                if (int.Parse(e.Item.Cells[16].Text.Trim()) == 6 || int.Parse(e.Item.Cells[16].Text.Trim()) == 7)
                {
                    HyperLink hlprint = e.Item.FindControl("lbtnPrint") as HyperLink;
                    hlprint.NavigateUrl = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&DSerialNo=" + DataBinder.Eval(e.Item.DataItem, "DSerialNo");
                    hlprint.Target = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&DSerialNo=" + DataBinder.Eval(e.Item.DataItem, "DSerialNo");
                    hlprint.ToolTip = "Print this test result";
                    HyperLink hlprintall = e.Item.FindControl("lbtnPrintall") as HyperLink;
                    hlprintall.NavigateUrl = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&MSerialNo=" + DataBinder.Eval(e.Item.DataItem, "MSerialNo") + "&ProcessId=" + DataBinder.Eval(e.Item.DataItem, "processID");
                    hlprintall.Target = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&MSerialNo=" + DataBinder.Eval(e.Item.DataItem, "MSerialNo") + "&ProcessId=" + DataBinder.Eval(e.Item.DataItem, "processID");
                    hlprintall.ToolTip = "Print this Visit results";

                    HyperLink hlEmail = e.Item.FindControl("lbtnEmail") as HyperLink;
                    hlEmail.NavigateUrl = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&MSerialNo=" + DataBinder.Eval(e.Item.DataItem, "MSerialNo") + "&ProcessId=" + DataBinder.Eval(e.Item.DataItem, "processID") + "&Email=Y";
                    hlEmail.Target = "~/LIMS/reports/GeneralReports.aspx?reportID=LMS-001-11" + "&MSerialNo=" + DataBinder.Eval(e.Item.DataItem, "MSerialNo") + "&ProcessId=" + DataBinder.Eval(e.Item.DataItem, "processID") + "&Email=Y";
                    hlEmail.ToolTip = "Email";
                }
                else
                {
                    HyperLink hlprint = e.Item.FindControl("lbtnPrint") as HyperLink;
                    hlprint.ToolTip = "Result not ready";
                    HyperLink hlprintall = e.Item.FindControl("lbtnPrintall") as HyperLink;
                    hlprintall.ToolTip = "Result not Reay";

                    HyperLink hlEmail = e.Item.FindControl("lbtnEmail") as HyperLink;
                    hlEmail.ToolTip = "Result not Ready";

                }
 //               if (((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).Text.Trim().Length > 2)
 //             {
 //                   ((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).ToolTip = ((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).Text.Trim();
 //((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).Text=((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).Text.Trim().Substring(((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath1")).Text.Trim().LastIndexOf(@"\"));
 //               }
 //               if (((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).Text.Trim().Length > 2)
 //               {
 //                   ((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).ToolTip = ((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).Text.Trim();
 //((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).Text=((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).Text.Trim().Substring(((LinkButton)e.Item.Cells[18].FindControl("lnkimgpath2")).Text.Trim().LastIndexOf(@"\"));
 //               }
                //WebUIFacade uiFacade = new WebUIFacade();
                //uiFacade.SetRowHover(this.dgResultDis, e);
            }
        }


        protected void btncopylabidsearch_Click(object sender, EventArgs e)
        {
            txtMSerialNoTo.Text = txtMSerialNoFrom.Text;
            clsBLSpecimenColletion obj_sp=new clsBLSpecimenColletion() ;
            if (txtMSerialNoFrom.Text.Length <= 7)
            {
                obj_sp.LabIDFrom = System.DateTime.Now.ToString("yy") + "001" + txtMSerialNoFrom.Text.PadLeft(7, '0');
                obj_sp.LabIDTo = obj_sp.LabIDFrom;
            }
            else
            {
                obj_sp.LabIDFrom = txtMSerialNoFrom.Text.Trim().Replace("-", "");
                obj_sp.LabIDTo = txtMSerialNoTo.Text.Trim().Replace("-", "");
            }
            DataView dv_getresult = obj_sp.GetAll(5);
            obj_sp = null;
            if (dv_getresult.Count > 0)
            {
                dgResultDis.AllowPaging = false;
                lblRecordNo.Text = "Record fetched : " + dv_getresult.Count.ToString();
                dgResultDis.DataSource = dv_getresult;
                dgResultDis.DataBind();
                dgResultDis.Visible = true;
                dv_getresult.Dispose();
                txtMSerialNoFrom.Text = "";
                txtMSerialNoFrom.Focus();
            }
            else
            {
                dgResultDis.DataSource = "";
                dgResultDis.DataBind();
                dgResultDis.Visible = false;
                txtMSerialNoFrom.Text = "";
                txtMSerialNoFrom.Focus();
            }
                
            
        }
        protected void lbtnReset_Click(object sender, EventArgs e)
        {
            ddlSection.ClearSelection();
            ddlSection.ClearSelection();
            ddlTestGroup.ClearSelection();
            ddlTest.ClearSelection();
            ddlWard.ClearSelection();
            txtDF.Text = System.DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy");
            txtDT.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            txtMSerialNoFrom.Text = "";
            txtMSerialNoTo.Text = "";
            txtPatientName.Text = "";
            txtPRNo.Text = "";
            rbtnPatientType.Items.FindByValue("A").Selected = true;
            rbtnIO.Items.FindByValue("A").Selected = true;
            chkREntry.Checked = false;
            chkSpecimen.Checked = false;
            chkUnpaid.Checked = false;
            chkDispatch.Checked = true;
            chkDelivered.Checked = false;
            chkVerification.Checked = false;
            chkDispatch.Checked = false;
            chkSpecimenOutQueue.Checked = false;
            chkSpecomenInQueue.Checked = false;
            chkall.Checked = false;
            ddlSex.ClearSelection();
            FillDG();
            txtMSerialNoFrom.Focus();

        }

        protected void dgResultDis_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            WebUIFacade uiFacade = new WebUIFacade();

            // This is gives a tool tip for each
            // of the columns to sort by.
            uiFacade.SetHeaderToolTip(e);


            // This sets a class for the link buttons in a grid.
            uiFacade.SetGridLinkButtonStyle(e);

            // Make the row change color when the mouse hovers over.
            // *** You must have a class called gridHover with a different background 
            // color in your StyleSheet.
            uiFacade.SetRowHover(this.dgResultDis, e);
        }

        protected void lnkimgpath1_Click(object sender, EventArgs e)
        {
            LinkButton lnkPath1 = (LinkButton)sender;
            string filepath = lnkPath1.ToolTip.ToString();// @"D:\negno25462.jpg";
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }
        }
        protected void lnkimgpath2_Click(object sender, EventArgs e)
        {
            LinkButton lnkPath1 = (LinkButton)sender;
            string filepath = lnkPath1.ToolTip.ToString();// @"D:\negno25462.jpg";
            // Create New instance of FileInfo class to get the properties of the file being downloaded
            FileInfo myfile = new FileInfo(filepath);

            // Checking if file exists
            if (myfile.Exists)
            {
                // Clear the content of the response
                Response.ClearContent();

                // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
                Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

                // Add the file size into the response header
                Response.AddHeader("Content-Length", myfile.Length.ToString());

                // Set the ContentType
                Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

                // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
                Response.TransmitFile(myfile.FullName);

                // End the response
                Response.End();
            }
        }

        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";

                case ".docx":
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        protected void dgResultDis_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgResultDis.CurrentPageIndex = e.NewPageIndex;

            FillDG();//dgResultDis.DataBind();
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'>window.close();</script>");
        }
}
}