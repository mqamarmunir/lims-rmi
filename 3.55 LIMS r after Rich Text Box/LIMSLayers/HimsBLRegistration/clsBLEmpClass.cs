using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Class" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	May 2004 (In WOP Hospital Wah Cantt)	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLEmpClass
	{

		clsempclass ObjDLEmpClass = new clsempclass();				 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Please enter Class Name (empty is not allowed)";
		private const string Error002 = "Class Name already exist";
		private const string Error003 = "Acronym already exist";
		private const string Error004 = "Please select Organization";

		public clsBLEmpClass()
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

		public bool rsInsert(string mClassName, string mAcronym,string mActive, string mOrgID)
		{		
			try
			{
				if(!VD_OrgID(mOrgID))
				{
					return false;
				}

				if(!VD_ClassName("", mClassName, mOrgID))
				{						
					return false;
				}

				if(!VD_Acronym("", mAcronym, mOrgID))
				{						
					return false;
				}

				ObjDLEmpClass.ClassName = mClassName; 
				ObjDLEmpClass.Acronym = mAcronym; 
				ObjDLEmpClass.Active = mActive;
				ObjDLEmpClass.OrgID = mOrgID;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLEmpClass, clsoperation.Get_PKey.Yes);
				ObjTrans.End_Transaction();
					
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}

				strErrorMessage = "";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage = ex.Message.ToString();
				return false;
			}
		}

		public bool rsUpdate(string mClassID, string mClassName, string mAcronym, string mActive, string mOrgID)
		{
			try
			{
				if(!VD_OrgID(mOrgID))
				{
					return false;
				}

				if(!VD_ClassName(mClassID, mClassName, mOrgID))
				{						
					return false;
				}

				if(!VD_Acronym(mClassID, mAcronym, mOrgID))
				{						
					return false;
				}

				ObjDLEmpClass.PKeycode = mClassID; 
				ObjDLEmpClass.ClassName = mClassName; 
				ObjDLEmpClass.Acronym = mAcronym; 
				ObjDLEmpClass.Active = mActive;
				
				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLEmpClass);
				ObjTrans.End_Transaction();

				if(strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}

				strErrorMessage = "";
				return true;
			}
			catch(Exception ex)
			{		
				strErrorMessage=ex.Message.ToString();
				return false;
			}
		}

		public bool rsDelete(string mClassID)
		{
			try
			{
				ObjDLEmpClass.PKeycode=mClassID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLEmpClass); 
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

		public DataView rsGetAll(string mClassName, string mAcronym, string mActive, string mOrgID)
		{
			ObjDLEmpClass.ClassName = mClassName;
			ObjDLEmpClass.Acronym = mAcronym;
			ObjDLEmpClass.Active = mActive;
			ObjDLEmpClass.OrgID = mOrgID;

			return ObjTrans.DataTrigger_Get_All(ObjDLEmpClass);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>
		public DataView rsGetSingle(string mClassID)
		{
			ObjDLEmpClass.PKeycode = mClassID; 

			return  ObjTrans.DataTrigger_Get_Single(ObjDLEmpClass);
		}

		private bool VD_ClassName(string mClassID, string mClassName, string mOrgID)
		{
			if(mClassName.Equals(""))
			{
				strErrorMessage = Error001;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView = rsGetAll(mClassName, "", "", mOrgID);

			if(!mClassID.Equals(""))
			{
				mDataView.RowFilter = "ClassID <> '" + mClassID + "'";
				mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			}
			
			if(mDataView.Count > 0)
			{
				strErrorMessage = Error002;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_Acronym(string mClassID, string mAcronym, string mOrgID)
		{
			DataView mDataView = new DataView();			
			mDataView = rsGetAll("", mAcronym, "", mOrgID);

			if(!mClassID.Equals(""))
			{
				mDataView.RowFilter = "ClassID <> '" + mClassID + "'";
				mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			}
			
			if(mDataView.Count > 0)
			{
				strErrorMessage = Error003;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_OrgID(string mOrgID)
		{
			if(mOrgID.Equals("")) 
			{
				strErrorMessage = Error004;
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}