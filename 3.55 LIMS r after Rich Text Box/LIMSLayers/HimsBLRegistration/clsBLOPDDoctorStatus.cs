using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;


namespace HimsBLRegistration
{// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Shffled Patient" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	July 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	///

	public class clsBLOPDDoctorStatus
	{

		clsopddoctorstatus ObjDLOPDDoctorStatus = new clsopddoctorstatus();				 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Doctor";
		private const string Error002 = "Invalid Value of Doctor Status";

		public clsBLOPDDoctorStatus()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/* Property for Error Message*/

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsInsert(string mDoctorID, string mStatus, string mDoctorReturnTime)
		{		
			try
			{

				if (VD_DoctorID(mDoctorID)==false)
				{
					return false;
				}

				if (VD_DoctorStatus(mStatus)==false)
				{
					return false;
				}


				ObjDLOPDDoctorStatus.DOCTORID = mDoctorID;
				ObjDLOPDDoctorStatus.STATUS = mStatus;
				ObjDLOPDDoctorStatus.DOCTORRETURNEDTIME = mDoctorReturnTime;
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLOPDDoctorStatus, clsoperation.Get_PKey.No);				
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

		public bool rsUpdate(string mDoctorStatusID, string mDoctorID, string mStatus, string mDoctorReturnTime)
		{		
			try
			{

				if (VD_DoctorID(mDoctorID)==false)
				{
					return false;
				}

				if (VD_DoctorStatus(mStatus)==false)
				{
					return false;
				}

				ObjDLOPDDoctorStatus.PKeycode  = mDoctorStatusID;
				ObjDLOPDDoctorStatus.DOCTORID = mDoctorID;
				ObjDLOPDDoctorStatus.STATUS = mStatus;
				ObjDLOPDDoctorStatus.DOCTORRETURNEDTIME = mDoctorReturnTime;
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLOPDDoctorStatus);				
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

		public bool rsDelete(string mDoctorStatusID)
		{
			try
			{
				ObjDLOPDDoctorStatus.PKeycode  = mDoctorStatusID;
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLOPDDoctorStatus); 
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

		public DataView rsGetAll()
		{
			ObjDLOPDDoctorStatus.DOCTORID ="";
			ObjDLOPDDoctorStatus.STATUS ="";
 			return ObjTrans.DataTrigger_Get_All(ObjDLOPDDoctorStatus);
		}

		public DataView rsGetAll(string mDoctorID, string mStatus)
		{
			ObjDLOPDDoctorStatus.DOCTORID =mDoctorID;
			ObjDLOPDDoctorStatus.STATUS =mStatus;
			return ObjTrans.DataTrigger_Get_All(ObjDLOPDDoctorStatus);
		}

		public DataView rsGetSingle(string mDoctorStatusID)
		{
			ObjDLOPDDoctorStatus.PKeycode = mDoctorStatusID;
			return  ObjTrans.DataTrigger_Get_Single(ObjDLOPDDoctorStatus);
		}


		private bool VD_DoctorStatus(string mStatus)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.DoctorStatus(); 
				{mDataView.RowFilter ="DSCode='" + mStatus + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error002;
					return false;}
				else
				{return true;}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();  
				return false;				
			}		
		}

		private bool VD_DoctorID(string mDoctorID)
		{
			clsBLDoctor ObjBLDoctor = new clsBLDoctor();
			DataView mDataView = new DataView();
			mDataView=ObjBLDoctor.rsGetSingle(mDoctorID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error001;
				return false;}
			else
			{return true;}
		}


	}
}
