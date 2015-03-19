using System;
using System.Data;  
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	/// Application	:	Hospital Information & Management System (HIMS)
	///	Class for	:	"tPersonnelSpecialty" Table
	///	Developer	:	Trees Software (Pvt) Ltd.
	///	Date		:	August 2004 (In POF Hospital Wah Cantt)	
	/// Type		:	Business Layer Class
	/// </summary>
	public class clsBLTPersonnelSpecialty
	{
		private string strErrorMessage = "";
		private const string Error01 = "Invalid user name or password";
		private const string Error02 = "Your account is Inactive, contact your System Administrator";
		private const string Error03 = "User Name must be entered"; 
		private const string Error04 = "Password must be entered";		
		
		clsTPersonnelSpecialty objTPSpecialty = new clsTPersonnelSpecialty();
		clsoperation ObjTrans = new clsoperation();

		public clsBLTPersonnelSpecialty()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		/// <summary>
		/// Error Message Property
		/// </summary>
		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}


		public bool rsInsert(string mPersonID, string mDsgSpecialtyID, clsoperation ObjTransD) 
		{		 
			try
			{
				objTPSpecialty.PersonID = mPersonID;
				objTPSpecialty.DsgSpecialtyID = mDsgSpecialtyID;
				strErrorMessage = ObjTransD.DataTrigger_Insert(objTPSpecialty, clsoperation.Get_PKey.Yes);
		
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTransD.OperationError;
					return false;
				}
				strErrorMessage="";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage=ex.Message.ToString();
				return false;
			}
		}

		
		public bool rsDelete(string mPersonID, clsoperation ObjTransD)
		{
			try
			{
				objTPSpecialty.PersonID = mPersonID;
				strErrorMessage = ObjTransD.DataTrigger_Delete(objTPSpecialty); 
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTransD.OperationError;
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


		/// <summary>
		///		Display All Record - Return type DataView
		/// </summary>
		public DataView rsGetAll(string mPersonID, string mDsgSpecialtyID)
		{
			objTPSpecialty.PersonID = mPersonID;
			objTPSpecialty.DsgSpecialtyID = mDsgSpecialtyID;
			return ObjTrans.DataTrigger_Get_All(objTPSpecialty);
		}


		public DataView rsGetSingle(string mPersonID, clsoperation ObjTransD)
		{
			objTPSpecialty.PersonID = mPersonID;
			return ObjTransD.DataTrigger_Get_Single(objTPSpecialty);
		}
	}
}