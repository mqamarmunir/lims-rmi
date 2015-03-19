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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using CrystalDecisions.Web.Design;

namespace LIMS
{
	/// <summary>
	/// Summary description for Components.
	/// </summary>
	public class SComponents
	{
		
		public SComponents()
		{
		}
		public void FillDropDownList(DropDownList ddl,DataView dv,string strTextField,string strValueField)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;
			dv.Sort = strTextField;
			ddl.DataSource = dv;
			ddl.DataBind();

			ListItem li  = new ListItem("Select","-1");
			ddl.Items.Insert(0,li);
			
			ddl.SelectedItem.Selected = false;
			ddl.Items[0].Selected = true;

		}
		public void FillDropDownList(DropDownList ddl,DataView dv,string strTextField,string strValueField,bool sort)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;

			if(sort)
				dv.Sort = strTextField;

			ddl.DataSource = dv;
			ddl.DataBind();

			ListItem li  = new ListItem("Select","-1");
			ddl.Items.Insert(0,li);

			ddl.SelectedItem.Selected = false;
			ddl.Items[0].Selected = true;
		}

		public void FillDropDownList(DropDownList ddl,DataView dv,string strTextField,string strValueField,bool sort,bool isAll)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;

			if(sort)
				dv.Sort = strTextField;

			ddl.DataSource = dv;
			ddl.DataBind();
			ListItem li;
			if(!isAll)
			{
				li  = new ListItem("Select","-1");
			}
			else
			{
				li  = new ListItem("All","");
			}
			ddl.Items.Insert(0,li);
			ddl.SelectedItem.Selected = false;
			ddl.Items[0].Selected = true;
		}

		public void FillDropDownList(DropDownList ddl,DataView dv,string strTextField,string strValueField,bool sort,bool isAll,bool isSelect)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;

			if(sort)
				dv.Sort = strTextField;

			ddl.DataSource = dv;
			ddl.DataBind();
			ListItem li;
			if(!isAll)
			{
				if(isSelect)
				{
					li  = new ListItem("Select","-1");
					
					ddl.Items.Insert(0,li);
				}

			}
			else
			{
				li  = new ListItem("All","");
				ddl.Items.Insert(0,li);
			}

			if(dv.Count > 0)
			{
				ddl.SelectedItem.Selected = false;
				ddl.Items[0].Selected = true;
			}
		}

		public void FillDropDownList(RadioButtonList ddl,DataView dv,string strTextField,string strValueField,bool sort)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;

			if(sort)
				dv.Sort = strTextField;

			ddl.DataSource = dv;
			ddl.DataBind();
			
	

		}




		public void FillDropDownListWithoutSelect(DropDownList ddl,DataView dv,string strTextField,string strValueField,bool sort,bool isAll)
		{
			ddl.DataTextField = strTextField;
			ddl.DataValueField = strValueField;

			if(sort)
				dv.Sort = strTextField;

			ddl.DataSource = dv;
			ddl.DataBind();
			ListItem li;
			if(isAll)
			{
				li  = new ListItem("All","");
				ddl.Items.Insert(0,li);
			}
		}

		public string GetAge(string strDate)
		{	
			string [] Date = strDate.Split('/');
			string [] splittedYear = null;

			if(Date[2].Length > 4)
			{
				splittedYear = Date[2].Split(' ');
			}
			int day = 0;
			int month = 0;
			int year = 0;
			try
			{
				day = int.Parse(Date[0]);
				month= int.Parse(Date[1]);
				if(Date[2].Length > 4)
				{
					year = int.Parse(splittedYear[0]);					
				}
				else
				{
					year = int.Parse(Date[2]);
				}
			
			}
			catch(IndexOutOfRangeException e)
			{
				return "";
			}
			catch(FormatException e)
			{
				return "";
			}
			System.DateTime objDateTime;
			try
			{
				objDateTime = new DateTime(year,month,day);
			}
			catch(ArgumentOutOfRangeException e)
			{
				return "";
			}

			TimeSpan objTimeSpan = DateTime.Now.Subtract(objDateTime);
			double TDays = objTimeSpan.TotalDays;
			if(TDays < 31)
			{
				return ((int)TDays).ToString() + " day(s)";
			}
			else if(TDays < 365)
			{
				return ((int)(TDays / 30)).ToString() + " month(s)";
			}
			else
			{
				return ((int)(TDays / 365)).ToString();
			}
		}
		

/*		public string GetFactoryName(string strFactoryID)
		{
			string strFactoryName = "";
			DataView dvFactory;
			clsBLFactory objFactory = new clsBLFactory();
			dvFactory = objFactory.rsGetSingle(strFactoryID);
		
			if(dvFactory.Count != 0)		
			{
				strFactoryName = dvFactory[0].Row["FactoryName"].ToString();
			}

			return strFactoryName;
		}
		
		public string GetFactoryType(string strFactoryTypeID)
		{
			string strFactoryType = "";
			clsGeneralCollections objGC = new clsGeneralCollections();
			DataView dvFactory = objGC.FactoryType();
			dvFactory.RowFilter = "FactoryTypeCode = '" + strFactoryTypeID + "'" ;

			
			if(dvFactory.Count != 0)		
			{
				strFactoryType = dvFactory[0].Row["FactoryTypeDesc"].ToString();
			}

			return strFactoryType;


		}
		public string GetFactoryID(string strFactoryType,string strFactoryName)
		{
			string strFactoryID = "";
			DataView dvFactory;
			clsBLFactory objFactory = new clsBLFactory();
			dvFactory = objFactory.rsGetAll(strFactoryType);
			dvFactory.RowFilter = "FactoryName='" +strFactoryName + "'";
			if(dvFactory.Count != 0)		
			{
				strFactoryID = dvFactory[0].Row["FactoryID"].ToString();
			}

			return strFactoryID;
		}
*/		public string GetEmployeeID(string strFactoryID,string PlNo)
		{
			return "";
			
		}
/*		public void FillFactory(DropDownList ddlFactory,string FactoryType)
		{
			if(FactoryType != "-1")
			{
				clsBLFactory objFactory = new clsBLFactory();
				ddlFactory.Enabled = true;
				FillDropDownList(ddlFactory,objFactory.rsGetAll(FactoryType),"FactoryName","FactoryID");
			}
			else
			{
				ddlFactory.Items.Clear();
				ddlFactory.Enabled = false;
			}
		}
		public string GetPatientID(string HospitalNo)
		{
			clsBLPatientVisit objPatientVisit = new clsBLPatientVisit();
			DataView dvPatientVisit = objPatientVisit.rsGetSingle(HospitalNo);
			string PatientID = "";
			if(dvPatientVisit.Count != 0)
			{
				PatientID =  dvPatientVisit[0].Row["DependentID"].ToString();
			}
			return PatientID;
		}

		public string GetRankName(string RankID)
		{
			clsBLRank objRank = new clsBLRank();
			DataView dvRank = objRank.rsGetSingle(RankID);

			if(dvRank.Table.Rows.Count != 0)
				return dvRank.Table.Rows[0]["RankName"].ToString();
			else
				return "";
		
		}
*/		public void setDropDownListValue(DropDownList objddl,string strValue,string T_or_V)
		{

			if(T_or_V == "V")
			{
				objddl.SelectedItem.Selected = false;
				objddl.Items.FindByValue(strValue).Selected = true;
			}
			else if(T_or_V == "T")
			{
				objddl.SelectedItem.Selected = false;
				objddl.Items.FindByText(strValue).Selected = true;
			}
		}
		public void setDropDownListValue(DropDownList objddl,string strValue)
		{
			objddl.SelectedItem.Selected = false;
			objddl.Items.FindByValue(strValue).Selected = true;
		
		}

		public void LoadReport(CrystalReportViewer CrystalReportViewer1,string strReportURL,string strFilter,string PrintOption)
		{
			int i=0;
			int j=0;		
			//	prin
			CrystalReportViewer1.DisplayToolbar=true; 
			CrystalReportViewer1.DisplayGroupTree = false;
			CrystalReportViewer1.DisplayPage = true;
			CrystalReportViewer1.BestFitPage = true;
			CrystalReportViewer1.HasDrillUpButton = false;
			CrystalReportViewer1.HasGotoPageButton = false;
			CrystalReportViewer1.HasPageNavigationButtons= false;
			CrystalReportViewer1.HasRefreshButton= false;
			CrystalReportViewer1.HasSearchButton= false;
			CrystalReportViewer1.HasZoomFactorList= false; 
			CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			doc.Load(strReportURL);

			
			//doc.Load(@"E:\Hims\HimsReports\FactoryList.rpt");
			//CrystalReportViewer1.Load(@"E:\Hims\HimsReports\FactoryList.rpt"); 

			j=doc.Database.Tables.Count-1;
			for (i=0; i <= j ;i++)   
			{
				TableLogOnInfo logOnInfo = new TableLogOnInfo();
				logOnInfo = doc.Database.Tables[i].LogOnInfo;
				ConnectionInfo connectionInfo = new ConnectionInfo ();
				connectionInfo = logOnInfo.ConnectionInfo;
				connectionInfo.ServerName = "hims";
				connectionInfo.Password = "hims";
				connectionInfo.UserID = "hims";
				doc.Database.Tables [i].ApplyLogOnInfo(logOnInfo);
			}

			doc.RecordSelectionFormula  =strFilter;

			//1.	 Print To Printer

			if(PrintOption == "1")
			{

				doc.PrintOptions.PrinterName ="HP LaserJet";
				doc.PrintToPrinter(1, true, 0, 0); 
			}
			else if(PrintOption == "2") //2.	 ON THE WEB
			{
				
				CrystalReportViewer1.ReportSource = doc;
				
			}
			else 
			{//3.	 Print On PDF
				

				MemoryStream s = (MemoryStream)doc.ExportToStream(ExportFormatType.PortableDocFormat);
				HttpContext.Current.Response.ClearContent();
				HttpContext.Current.Response.ClearHeaders();
				HttpContext.Current.Response.ContentType = "application/pdf";
				HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
				HttpContext.Current.Response.BinaryWrite(s.ToArray());
				HttpContext.Current.Response.End();
			}

		}
		public void ApplyCssOnDataGrid(DataGrid dg)
		{
			dg.CssClass = "dg";
			dg.ItemStyle.CssClass = "dgItemStyle";
			dg.HeaderStyle.CssClass = "dgHeader";
			dg.PagerStyle.CssClass = "dgPager";
			dg.BorderWidth = 0;
			dg.CellSpacing = 1;

			//dg.HeaderStyle.ForeColor = System.Drawing.ColorConverter;
		
		}
/*		public bool IsEmployee(string DependentID)
		{
			clsBLDependent objDep = new clsBLDependent();
			DataView dvDep = objDep.rsGetSingle(DependentID);
			bool flag = true;
			string relation = "";
			if(dvDep.Count != 0 )
			{
				relation = dvDep[0].Row["Relation"].ToString();
				if(relation != "Self")
				{
					flag = false;
				}
			}
			return flag;
		}
*/
		public string GetMaritalStatus(string MSCode)

		{
			string MaritalStatus = "";
			if("S" == MSCode)	
			{
				MaritalStatus = "Single";
			}
			else if("M" == MSCode)
			{
				MaritalStatus = "Married";
			}
			else if ("W" == MSCode)
			{
				MaritalStatus = "Widow";
			}
			else
			{
				MaritalStatus = "Un-Known";
			}
			
					

			return MaritalStatus;

			


		}
		public string GetSex(string SexCode)

		{
			string Sex = "";
			
			if("F" == SexCode)
			{
				Sex = "Female";
			}
			else if("M" == SexCode)
			{
				Sex = "Male";
			}
			else
			{
				Sex = "Un-Known";
			}
					

			return Sex;

			


		}
/*		public string GetSectionName(string SectionID)
		{
			clsBLSection objSection = new clsBLSection();
			DataView dvSection = objSection.rsGetSingle(SectionID);
			string SectionName = "";

			if(dvSection.Count != 0)
			{
				SectionName = dvSection[0].Row["SectionName"].ToString();
			}

			return SectionName;
		}

		public string GetDependentID(string EmployeeID)
		{
			clsBLDependent objDep = new clsBLDependent();
			DataView dvDep = objDep.rsGetAll(EmployeeID);
			dvDep.RowFilter = "Relation = 'Self' ";

			return dvDep[0].Row["DependentID"].ToString();
		}
*/		//Two Parameter DateTime obj
		//Format can be dd/mm/yyyy or mm/dd/yyyy
		public string GetDateString(DateTime objDT,string format)
		{
			string strDate = "";

			if("dd/mm/yyyy" == format)
			{
				strDate = objDT.Day.ToString() + "/" + objDT.Month.ToString() + "/" + objDT.Year.ToString();
			}
			else if("mm/dd/yyyy" == format)
			{
				strDate = objDT.Month.ToString() + "/" + objDT.Day.ToString() + "/" + objDT.Year.ToString();
			}
			else
			{
				throw new Exception("Unrecognized date format");
			}

			return strDate;
		}
		public string MoveDateBack(int days,string format)
		{
			SComponents objComp = new SComponents();
			
			TimeSpan objTS = new TimeSpan(days,0,0,0);
		
			DateTime objDT;

			objDT = DateTime.Now.Subtract(objTS);

			return objComp.GetDateString(objDT,format);
			
		}
		public int GetWeekDayNo(string strDay)
		{
			string[] DaysArray = new string[] {"Sunday" , "Monday" , "Tuesday" , "Wednesday" , "Thursday" , "Friday" , "Saturday" };

			for(int j=0;j<7;j++)
			{
				if(DaysArray[j].CompareTo(strDay) == 0)
				{
					return j+1;
				}
				
			}

			return -1;
		}

		public string PrintVoucher(string RPTPath,string HospitalNo)
		{
			try
			{
				int i=0;
				int j=0;
				/*	CrystalReportViewer CrystalReportViewer1 = new CrystalReportViewer();
					CrystalReportViewer1.DisplayToolbar=true; 
					CrystalReportViewer1.DisplayGroupTree = false;
					CrystalReportViewer1.DisplayPage = true;
					CrystalReportViewer1.BestFitPage = true;
					CrystalReportViewer1.HasDrillUpButton = false;
					CrystalReportViewer1.HasGotoPageButton = false;
					CrystalReportViewer1.HasPageNavigationButtons= false;
					CrystalReportViewer1.HasRefreshButton= false;
					CrystalReportViewer1.HasSearchButton= false;
					CrystalReportViewer1.HasZoomFactorList= false; */
				CrystalDecisions.CrystalReports.Engine.ReportDocument doc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			
				doc.Load(RPTPath);
		
				j=doc.Database.Tables.Count-1;
				for (i=0; i <= j ;i++)   
				{
					TableLogOnInfo logOnInfo = new TableLogOnInfo();
					logOnInfo = doc.Database.Tables[i].LogOnInfo;
					ConnectionInfo connectionInfo = new ConnectionInfo ();
					connectionInfo = logOnInfo.ConnectionInfo;
					connectionInfo.ServerName = "hims";
					connectionInfo.Password = "hims";
					connectionInfo.UserID = "hims";
					doc.Database.Tables [i].ApplyLogOnInfo(logOnInfo);
				}

				doc.RecordSelectionFormula  ="{PATIENTVISIT.HOSPITALNO} = '" + HospitalNo + "'";

				doc.SetParameterValue("ReportTitle", "POF Hospital Wah Cantt");
				doc.SetParameterValue("ReportSubTitle1", "Patient Visit Ticket");
				doc.SetParameterValue("PageFooter", "PRG-0001-01");
				doc.SetParameterValue("TreesFooter1", "Copyright Trees software (pvt) Ltd.");
				doc.SetParameterValue("TreesFooter2", "www.treesvalley.com");
 
				//			CrystalReportViewer1.ReportSource = doc;

				/*				CrystalReportViewer1.Load()
								CrystalReportViewer1.ReportSource = doc;
								CrystalReportViewer1.p*/
	
				//1.	 Print To Printer
				
				// "HP LaserJet";
				//doc.PrintOptions.PrinterName =@"\\TREES02\HP LaserJet";
				doc.PrintOptions.PrinterName = "\\\\TREES02\\HP LaserJet 1200 Series PCL 6";
				doc.PrintToPrinter(1, true, 0, 0); 

				/*MemoryStream s = (MemoryStream)doc.ExportToStream(ExportFormatType.PortableDocFormat);
				HttpContext.Current.Response.ClearContent();
				HttpContext.Current.Response.ClearHeaders();
				HttpContext.Current.Response.ContentType = "application/pdf";
				HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
				HttpContext.Current.Response.BinaryWrite(s.ToArray());
				HttpContext.Current.Response.End();*/

				//CrystalReportViewer1.ReportSource = doc				return "";
				return "";
			}
			catch (Exception ex)
			{
				return ex.Message.ToString() ;
			}
		}

		///<Summary>
		///Set Patient Condition field in data grid (OPD)
		///<summary>
		public void SetPatientCondition(DataGrid dgPV,int index)
		{
			string strCondition = "";

			for(int i = 0;i<dgPV.Items.Count;i++)
			{
				strCondition = dgPV.Items[i].Cells[index].Text;
				if(strCondition == "S")
				{
					dgPV.Items[i].Cells[index].Text = "<font color='green'>Serious</font>";

				}
				else if(strCondition == "V")
				{
					dgPV.Items[i].Cells[index].Text = "<font color='red'>Severe</font>";
				}
				else
				{
					dgPV.Items[i].Cells[index].Text = "Normal";
				}

			}
		}

		public DataView TrimLeftZeros(DataView dv, string columnName, int strLen)
		{
			int dvCount = dv.Count;
			
			for(int counter = 0; counter < dvCount; counter++)
			{
				string strChange = dv.Table.Rows[counter][columnName].ToString();
				char[] arrChange = strChange.ToCharArray();
				int index = 0;

				for(; index < strLen; index++)
				{
					if(arrChange[index] != '0')
					{
						break;
					}
				}
				
				dv.Table.Rows[counter][columnName] = strChange.Remove(0, index);
			}
			return dv;
		}


		/// <summary>
		/// Left Padding Zeros in a column
		/// </summary>
		/// <param name="dv">Data View to edit</param>
		/// <param name="SCName">Source Column Name</param>
		/// <param name="TCName">Target Column Name, first it will be created in data view and then filled</param>
		/// <param name="strLen">length of desired string with left pading</param>
		/// <returns>Edited Data View</returns>
		public DataView ZerosLeftPading(DataView dv, string sCName, string tCName, int strLen)
		{
			int dvCount = dv.Count;
			dv.Table.Columns.Add(tCName);
			
			for(int counter = 0; counter < dvCount; counter++)
			{
				dv.Table.Rows[counter][tCName] = dv.Table.Rows[counter][sCName].ToString().PadLeft(strLen, '0');
			}

			return dv;
		}


		public DataView CalculateAge(DataView dvLocal, string dobColumn)
		{
			int dvCount = dvLocal.Count;

			for(int counter = 0; counter < dvCount; counter++)
			{
				string dob = dvLocal.Table.Rows[counter][dobColumn].ToString();				 
				if(!dob.Equals(""))
				{
					dvLocal.Table.Rows[counter]["Age"] = GetAge(dob);
				}
			}
			return dvLocal;
		}

		public DataView RemoveDuplication(DataView dvLocal, string columnName)
		{
			string strToCompare = dvLocal.Table.Rows[0][columnName].ToString();
			for(int counter = 1; counter < dvLocal.Count; counter++)
			{
				if(strToCompare == dvLocal.Table.Rows[counter][columnName].ToString())
				{
					dvLocal.Table.Rows[counter].Delete();
					dvLocal.Table.AcceptChanges();
					counter--;
				}
				else
				{
					strToCompare = dvLocal.Table.Rows[counter][columnName].ToString();
				}
			}
			return dvLocal;
		}
	}
}