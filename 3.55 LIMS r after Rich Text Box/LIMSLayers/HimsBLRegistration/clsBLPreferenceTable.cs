using System;
using System.Data;  
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Factory" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 


	public class clsBLPreferenceTable
	{

		clspreferencetable ObjDLPreferenceTable = new clspreferencetable();  
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";


		public clsBLPreferenceTable()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsInsert(string mReportNo, string mReportDesc, string mReportTitle, 
			string mReportSubTitle1, string mPageFooter, string mTreesFooter1, string mTreesFooter2)
		{
		
			try
			{
				ObjDLPreferenceTable.PKeycode=mReportNo; 
				ObjDLPreferenceTable.ReportDesc=mReportDesc; 
				ObjDLPreferenceTable.ReportTitle=mReportTitle; 
				ObjDLPreferenceTable.ReportSubTitle1=mReportSubTitle1; 
				ObjDLPreferenceTable.PageFooter=mPageFooter; 
				ObjDLPreferenceTable.TreesFooter1=mTreesFooter1; 
				ObjDLPreferenceTable.TreesFooter2=mTreesFooter2; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLPreferenceTable, clsoperation.Get_PKey.Yes);
				ObjTrans.End_Transaction(); 
					
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}
				strErrorMessage="";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage=ex.Message.ToString();
				return false;
			};				  
		}

		public bool rsUpdate(string mReportNo, string mReportDesc, string mReportTitle, 
			string mReportSubTitle1, string mPageFooter, string mTreesFooter1, 
			string mTreesFooter2)
		{
			try
			{		

				ObjDLPreferenceTable.PKeycode=mReportNo; 
				ObjDLPreferenceTable.ReportDesc=mReportDesc; 
				ObjDLPreferenceTable.ReportTitle=mReportTitle; 
				ObjDLPreferenceTable.ReportSubTitle1=mReportSubTitle1; 
				ObjDLPreferenceTable.PageFooter=mPageFooter; 
				ObjDLPreferenceTable.TreesFooter1=mTreesFooter1; 
				ObjDLPreferenceTable.TreesFooter2=mTreesFooter2; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLPreferenceTable);
				ObjTrans.End_Transaction(); 
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}
				strErrorMessage="";
				return true;
			}
			catch(Exception ex)
			{		
				strErrorMessage=ex.Message.ToString();
				return false;
			};				  
		}

		public bool rsDelete(string mReportNo)
		{
			try
			{
				ObjDLPreferenceTable.PKeycode=mReportNo; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLPreferenceTable); 
				ObjTrans.End_Transaction(); 
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}
				strErrorMessage="";

				return true;
			}
			catch(Exception ex)
			{		
				strErrorMessage=ex.Message.ToString();
				return false;
			};	
		}

		/// <summary>
		///		Display All Record - Return type DataView
		/// </summary>

		public DataView rsGetAll()
		{
			return ObjTrans.DataTrigger_Get_All(ObjDLPreferenceTable);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mReportNo)
		{
			ObjDLPreferenceTable.PKeycode=mReportNo; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLPreferenceTable);
		}
	}
}
