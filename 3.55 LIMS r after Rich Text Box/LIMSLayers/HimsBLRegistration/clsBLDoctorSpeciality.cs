using System;
using System.Data;  
using HimsDlRegistration;

namespace HimsBLRegistration
{
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Doctor" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	
	public class clsBLDoctorSpeciality
	{
		clsdoctorspeciality ObjDLDoctorSpeciality = new clsdoctorspeciality(); 
		//clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Active.";
		private const string Error002 = "Invalid Doctor ID.";
		private const string Error003 = "Invalid Specialty ID.";


		public clsBLDoctorSpeciality()
		{

		}

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsInsert(string mDoctorID, string SpecialityID, clsoperation ObjTransD) 
		{
		 
			try
			{
				ObjDLDoctorSpeciality.PersonId = mDoctorID;
				ObjDLDoctorSpeciality.SpecialityId = SpecialityID;
				strErrorMessage = ObjTransD.DataTrigger_Insert(ObjDLDoctorSpeciality, clsoperation.Get_PKey.No);				
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

		public bool rsDelete(string mDoctorID, clsoperation ObjTransD)
		{
			try
			{
				ObjDLDoctorSpeciality.PersonId = mDoctorID;
				strErrorMessage=ObjTransD.DataTrigger_Delete(ObjDLDoctorSpeciality); 
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

		/// <summary>
		///		Display All Record - Return type DataView
		/// </summary>

		public DataView rsGetAll(clsoperation ObjTransD)
		{
			return ObjTransD.DataTrigger_Get_All(ObjDLDoctorSpeciality);
		}

		public DataView rsGetSingle(string mDoctorID, clsoperation ObjTransD)
		{
			ObjDLDoctorSpeciality.PersonId =mDoctorID;
			return ObjTransD.DataTrigger_Get_All(ObjDLDoctorSpeciality);
		}

		private bool VD_DoctorID(string mDoctorID)
		{
			clsBLLogin objLogin = new clsBLLogin();
			DataView mDataView = new DataView();
			mDataView = objLogin.rsGetSingle(mDoctorID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}

		private bool VD_SpecialityID(string mSpecialityID)
		{
			//SpecialityID
			clsBLSpeciality ObjBLSpeciality = new clsBLSpeciality();
			DataView mDataView = new DataView();
			mDataView=ObjBLSpeciality.rsGetSingle(mSpecialityID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
		}



	}
}
