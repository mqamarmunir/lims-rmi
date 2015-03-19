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
using CrystalDecisions.Shared;
using System.Configuration;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmReport.
	/// </summary>
	public partial class wfrmReport : System.Web.UI.Page
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if(User.Identity.IsAuthenticated)
			{
				if(!IsPostBack)
				{
					clsBLUMatrix UMatrix = new clsBLUMatrix();
					UMatrix.ApplicationID = "001";
					UMatrix.FormID = "109";
					UMatrix.PersonID = Session["loginid"].ToString();
					DataView dvUMatrix = UMatrix.GetAll(1);
					string sRigth = dvUMatrix[0]["Rec"].ToString(); 
					if (sRigth.Equals("0"))
					{
						Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");							
					}
					
					this.txtDF.Text = DateTime.Now.ToString("dd/MM/yyyy");
					this.txtDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
					//this.txtAdminDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
					FillSectionDDL();
                    FillEXTORGDDL();
					ResetPageView();
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

		}
		#endregion

		private void FillSectionDDL()
		{
			clsBLSection objSection = new clsBLSection();
			SComponents objComp = new SComponents();

			objSection.Active = "Y";
			DataView dvSection = objSection.GetAll(1);
			dgDepartment.DataSource = dvSection;
			dgDepartment.DataBind();		
		}
        private void FillEXTORGDDL()
        {
            clsBLSection objSection = new clsBLSection();
            SComponents objComp = new SComponents();

           // objSection.Active = "Y";
            DataView dvSection = objSection.GetAll(3);

            ddlextorg.DataSource = dvSection;
            ddlextorg.DataTextField = "name";
            ddlextorg.DataValueField = "orgid";
            ddlextorg.DataBind();
        }
		private void ResetPageView()
		{
			switch(this.rdoReport.SelectedItem.Value)
			{
				case "0":
					dgDepartment.Visible = false;
					ddlShift.Visible = false;
					txtDF.Visible = true;
					txtDT.Visible = true;
					Label1.Visible = false;
					Label2.Visible = true;
					Label3.Visible = true;										
					lblPatientType.Visible = true;					
					ddlPatientType.Visible = true;
					ddlIOPatient.Visible = true;
					lblAdminNo.Visible = false;
					txtAdminNo.Visible = false;
					lblAdminDate.Visible = false;
					txtAdminDate.Visible = false;
					lblName.Visible = false;
					txtPatientName.Visible = false;
                      lblextorg.Visible = false;
                    ddlextorg.Visible = false;
					break;
				case  "1":
					dgDepartment.Visible = false;
					ddlShift.Visible = false;
					txtDF.Visible = true;
					txtDT.Visible = true;
					Label1.Visible = false;
					Label2.Visible = true;
					Label3.Visible = true;					
					lblPatientType.Visible = true;					
					ddlPatientType.Visible = true;					
					ddlIOPatient.Visible = true;
					lblAdminNo.Visible = true;	
					txtAdminNo.Visible = true;	
					lblAdminDate.Visible = true;	
					txtAdminDate.Visible = true;	
					lblName.Visible = true;	
					txtPatientName.Visible = true;	
                      lblextorg.Visible = false;
                    ddlextorg.Visible = false;
					break;
				case  "2":
					dgDepartment.Visible = true;
					ddlShift.Visible = false; //true;
					txtDF.Visible = true;
					txtDT.Visible = true;
                    Label1.Visible = false; // true;
					Label2.Visible = true;
					Label3.Visible = true;					
					lblPatientType.Visible = false;					
					ddlPatientType.Visible = false;					
					ddlIOPatient.Visible = false;
					lblAdminNo.Visible = false;
					txtAdminNo.Visible = false;
					lblAdminDate.Visible = false;
					txtAdminDate.Visible = false;
					lblName.Visible = false;
					txtPatientName.Visible = false;
                      lblextorg.Visible = false;
                    ddlextorg.Visible = false;
					break;				
				case  "3":
					dgDepartment.Visible = false;
					ddlShift.Visible = false;
					txtDF.Visible = true;
					txtDT.Visible = true;
					Label1.Visible = false;
					Label2.Visible = true;
					Label3.Visible = true;
					lblPatientType.Visible = false;
					ddlPatientType.Visible = false;
					ddlIOPatient.Visible = false;
					lblAdminNo.Visible = false;
					txtAdminNo.Visible = false;
					lblAdminDate.Visible = false;
					txtAdminDate.Visible = false;
					lblName.Visible = false;
					txtPatientName.Visible = false;
                      lblextorg.Visible = false;
                    ddlextorg.Visible = false;
					break;				
				case  "4":
					dgDepartment.Visible = true;
					ddlShift.Visible = false;
					txtDF.Visible = false;
					txtDT.Visible = false;
					Label1.Visible = false;
					Label2.Visible = false;
					Label3.Visible = false;					
					lblPatientType.Visible = false;					
					ddlPatientType.Visible = false;
					ddlIOPatient.Visible = false;
					lblAdminNo.Visible = false;
					txtAdminNo.Visible = false;
					lblAdminDate.Visible = false;
					txtAdminDate.Visible = false;
					lblName.Visible = false;
					txtPatientName.Visible = false;
                      lblextorg.Visible = false;
                    ddlextorg.Visible = false;
					break;
                case "5":
                    dgDepartment.Visible = true;
                    ddlShift.Visible = false;
                    txtDF.Visible = false;
                    txtDT.Visible = false;
                    Label1.Visible = false;
                    Label2.Visible = false;
                    Label3.Visible = false;
                    lblPatientType.Visible = false;
                    ddlPatientType.Visible = false;
                    ddlIOPatient.Visible = false;
                    lblAdminNo.Visible = false;
                    txtAdminNo.Visible = false;
                    lblAdminDate.Visible = false;
                    txtAdminDate.Visible = false;
                    lblName.Visible = false;
                    txtPatientName.Visible = false;
                     lblextorg.Visible = false;
                    ddlextorg.Visible = false;
                    break;	
                case "6":
                     //dgDepartment.Visible = true;
                    ddlIOPatient.Visible = false;
                    ddlPatientType.Visible = false;
                    ddlShift.Visible = false;
                    lblextorg.Visible = true;
                    ddlextorg.Visible = true;
                    break;
			}
		}		

		private string GetSelectedDepartment(string strTable)
		{
			string selectionFormula = "";						

			foreach(DataGridItem dgItem in this.dgDepartment.Items)
			{
				if(((CheckBox)dgItem.Cells[0].FindControl("dgchkActive")).Checked == true)
				{
					selectionFormula += "'" + dgItem.Cells[1].Text + "',";									
				}
			}

			if (!selectionFormula.Equals("")) 
			{
				selectionFormula = " And "+strTable+" in [ "+selectionFormula+"'---']";
			}			
		
		return selectionFormula;
		//"007", "006", "004", "001"]
		}
	
		private void DailyPatientStatus()
		{
			string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";
			sFilterString = "{LS_TMTRANSACTION.MSTATUS} = 'A' and {LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;

			
			//sFilterString =  sFilterString +GetSelectedDepartment("{LS_TDTRANSACTION.SECTIONID}");			


			reports.GeneralReports.mFilterString = sFilterString;

			if (!ddlPatientType.SelectedValue.Equals("A"))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_TMTRANSACTION.TYPE} = '"+ddlPatientType.SelectedValue.ToString()+"'";
			}

			if (!ddlIOPatient.SelectedValue.Equals("A"))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_TMTRANSACTION.IOP} = '"+ddlIOPatient.SelectedValue.ToString()+"'";
			}

			reports.GeneralReports.ReportReference = "LMS-005-05";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

		private void DailyCashReport()
		{
			string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";
			sFilterString = "{LS_TMTRANSACTION.MSTATUS} = 'A' and {LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;

			
			//sFilterString =  sFilterString +GetSelectedDepartment("{LS_TDTRANSACTION.SECTIONID}");			


			reports.GeneralReports.mFilterString = sFilterString;

			if (!ddlPatientType.SelectedValue.Equals("A"))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And{LS_TMTRANSACTION.TYPE} = "+ddlPatientType.SelectedValue.ToString();
			}

			reports.GeneralReports.ReportReference = "LMS-005-01";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

		private void DailyPateintReport()
		{
		string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";					

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			
			
			reports.GeneralReports.mFilterString = "";
			reports.GeneralReports.mFilterString = "{LS_TDTRANSACTION.PROCESSID} <> '0002' and{LS_TMTRANSACTION.MSTATUS} = 'A' and {LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;

			if (!txtAdminNo.Text.Equals(""))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_VPATIENT.PADMNO} = '"+txtAdminNo.Text.ToString()+"'";				
			}

			if (!txtAdminDate.Text.Equals(""))
			{
				string mAdminDate = "Date(" + this.txtAdminDate.Text.Substring(6, 4).ToString() + "," + this.txtAdminDate.Text.Substring(3, 2).ToString() + "," + this.txtAdminDate.Text.Substring(0, 2).ToString() + ")";	

				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_VPATIENT.PADMDATE} = "+mAdminDate+"";				
			}

			if (!ddlPatientType.SelectedValue.Equals("A"))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_TMTRANSACTION.TYPE} = '"+ddlPatientType.SelectedValue.ToString()+"'";
			}

			if (!ddlIOPatient.SelectedValue.Equals("A"))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And {LS_TMTRANSACTION.IOP} = '"+ddlIOPatient.SelectedValue.ToString()+"'";
			}

			if (!txtPatientName.Text.Equals(""))
			{
				reports.GeneralReports.mFilterString = reports.GeneralReports.mFilterString+" And Uppercase({LS_VPATIENT.PATIENTCOMPLETENAME}) like Uppercase('*"+txtPatientName.Text+"*')";		
			}

			reports.GeneralReports.ReportReference = "LMS-005-02";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}
		private void DailyTestSummary()
		{
			string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";
			sFilterString = "{LS_TMTRANSACTION.MSTATUS} = 'A' and {LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;
			
			sFilterString =  sFilterString +GetSelectedDepartment("{LS_TDTRANSACTION.SECTIONID}");

			reports.GeneralReports.mFilterString = sFilterString;

			reports.GeneralReports.ReportReference = "LMS-005-03";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

		private void CommissionReport()
		{
			string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";
			sFilterString = "{LS_TMTRANSACTION.MSTATUS} = 'A' and {LS_TMTRANSACTION.ENTRYDATETIME} in " + mFromDate + " To " + mToDate;
			
			sFilterString =  sFilterString +GetSelectedDepartment("{LS_TDTRANSACTION.SECTIONID}");

			reports.GeneralReports.mFilterString = sFilterString;

			reports.GeneralReports.ReportReference = "LMS-005-04";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

		private void CashReportByCashier()
		{
			string mFromDate = "Date(" + this.txtDF.Text.Substring(6, 4).ToString() + "," + this.txtDF.Text.Substring(3, 2).ToString() + "," + this.txtDF.Text.Substring(0, 2).ToString() + ")";
			string mToDate = "Date(" + this.txtDT.Text.Substring(6, 4).ToString() + "," + this.txtDT.Text.Substring(3, 2).ToString() + "," + this.txtDT.Text.Substring(0, 2).ToString() + ")";

			string [,] pdfSetting = {{"SDate", this.txtDF.Text}, {"EDate", this.txtDT.Text}};
			reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";
			sFilterString = "(not isNull({LS_TMTRANSACTION.PAIDNO})) And Date({LS_TMTRANSACTION.ENTRYDATETIME}) in " + mFromDate + " To " + mToDate;

			reports.GeneralReports.mFilterString = sFilterString;

			reports.GeneralReports.ReportReference = "LMS-005-06";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

		private void MasterTestList()
		{			
			//reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";

            sFilterString = "{LS_TTEST.ACTIVE} = 'Y' ";
			
			sFilterString =  sFilterString +GetSelectedDepartment("{LS_TSECTION.SECTIONID}");

			reports.GeneralReports.mFilterString = sFilterString;

			reports.GeneralReports.ReportReference = "LMS-004-01";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}

        private void MasterTestListII()
		{			
			//reports.GeneralReports.PdfSetting = pdfSetting;			

			string sFilterString = "";

            sFilterString = "{LS_TTEST.ACTIVE} = 'Y' ";
			
			sFilterString =  sFilterString +GetSelectedDepartment("{LS_TSECTION.SECTIONID}");

			reports.GeneralReports.mFilterString = sFilterString;

			reports.GeneralReports.ReportReference = "LMS-004-02";
			Response.Write("<script language = 'javascript'>window.open('../reports/GeneralReports.aspx','_blank','')</script>");
		}
        private void ExternalTestReport()
        {
            //reports.GeneralReports.PdfSetting = pdfSetting;			
            string fromdate = txtDF.Text.ToString();
            string todate = txtDT.Text.ToString();
            string sFilterString = "";


            sFilterString = "Cdate({Command.BOOKEDON}) in cdate('"+fromdate+"') to cdate('"+todate+"') ";
            if (!ddlextorg.SelectedValue.ToString().Equals("-1"))
            {
                 sFilterString +=" and {Command.EXTERNAL_ORGID}="+ddlextorg.SelectedValue.ToString().Trim();
            }
            string[] param = new string[3];
            //sFilterString = sFilterString + GetSelectedDepartment("{LS_TSECTION.SECTIONID}");
            param[0] = fromdate;
            param[1] = todate;
            param[2] = Session["loginid"].ToString();
            printReport(sFilterString, param, "ExtTestSummary");
           
        }


		protected void rdoReport_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ResetPageView();			
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
		  
		}

		private void btnfromdate_ServerClick(object sender, System.EventArgs e)
		{
		
		}
        protected void ibtnDisplayReport_Click(object sender, ImageClickEventArgs e)
        {
            switch (this.rdoReport.SelectedItem.Value)
            {
                case "0":
                    DailyPatientStatus();  //DailyCashReport();
                    break;
                case "1":
                    DailyPateintReport();
                    break;
                case "2":
                    DailyTestSummary();
                    break;
                case "3":
                    CashReportByCashier(); //CommissionReport();
                    break;
                case "4":
                    MasterTestList();
                    break;
                case "5":
                    MasterTestListII();
                    break;
                case "6":
                    ExternalTestReport();
                    break;
            }
        }

        private void printReport(string _SelectionFormula, string[] parameter, string ReportName)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

            try
            {
                // Put user code to initialize the page here
                string strRUrl = Server.MapPath(@"~/LIMS/reports/" + ReportName + ".rpt");
                // string strRUrl = Server.MapPath(@"~/LIMS/reports/TestResult.rpt");
                Session["ReportUrl"] = strRUrl;


                int i;
                int j;
                doc.Load(strRUrl);
                j = doc.Database.Tables.Count - 1;
                string userName = "whims";
                string pwd ="whims";
                string serverName = "HIMS";

                //string strConn = ConfigurationSettings.AppSettings["ConnectionString"].ToString();
                //string[] info = strConn.Split(';');
                //userName = ((info[1].Split('='))[1]).Trim();
                //pwd = ((info[3].Split('='))[1]).Trim();
                //serverName = ((info[2].Split('='))[1]).Trim();

                for (i = 0; i <= j; i++)
                {
                    TableLogOnInfo logOnInfo = new TableLogOnInfo();
                    logOnInfo = doc.Database.Tables[i].LogOnInfo;
                    ConnectionInfo connectionInfo = new ConnectionInfo();
                    connectionInfo = logOnInfo.ConnectionInfo;
                    connectionInfo.ServerName = serverName;
                    connectionInfo.Password = pwd;
                    connectionInfo.UserID = userName;
                    doc.Database.Tables[i].ApplyLogOnInfo(logOnInfo);
                }
                if (ReportName == "EmpSpecimenCollected" || ReportName == "EmpTestEntered" || ReportName == "EmpTestVerified")
                {
                    if (_SelectionFormula != "")
                    {
                        //string[] formulas = _SelectionFormula.Split(';');
                        //string s1 = formulas[0].Trim();
                        //string s2 = formulas[1].Trim();
                        doc.RecordSelectionFormula = _SelectionFormula;
                        //doc.OpenSubreport("Test Details.rpt");
                        // doc.Subreports["Test Details"].RecordSelectionFormula = s2;
                        //doc.Subreports[0].RecordSelectionFormula = s2;
                        //doc.IsSubreport;
                        if (ReportName == "EmpSpecimenCollected")
                        {
                            doc.SetParameterValue("collectedon", parameter[0]);
                            doc.SetParameterValue("collectedonto", parameter[1]);
                            doc.SetParameterValue("starttime", parameter[2]);
                            doc.SetParameterValue("endtime", parameter[3]);
                        }
                        else
                        {
                            
                           
                        }

                    }
                }
                else
                {
                    doc.SetParameterValue("fromdate", parameter[0]);
                    doc.SetParameterValue("todate", parameter[1]);
                    doc.SetParameterValue("printby", parameter[2]);
                    doc.RecordSelectionFormula = _SelectionFormula;

                    _SelectionFormula = doc.RecordSelectionFormula;

                }
                CrystalDecisions.Shared.DiskFileDestinationOptions dfdoCustomers = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                string szFileName = Server.MapPath(@"~/LIMS/reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf");
                dfdoCustomers.DiskFileName = szFileName;
                doc.ExportOptions.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.DiskFile;
                doc.ExportOptions.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;
                doc.ExportOptions.DestinationOptions = dfdoCustomers;
                doc.Export();
                //Response.Redirect(strRUrl + "_" + Session["loginid"].ToString() + ".pdf");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "EmpTestEntered", @"<script>window.open('../reports/pdf/" + ReportName + "_" + Session["loginid"].ToString() + ".pdf');</script>", false);



            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "<script>alert('" + ex.Message + "')</script>", false);
            }
            finally
            {
                doc.Close();
                doc.Dispose();
                GC.Collect();
            }



        }
}
}