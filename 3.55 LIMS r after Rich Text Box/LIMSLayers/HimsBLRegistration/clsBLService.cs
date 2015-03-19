using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Service" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 


	public class clsBLService
	{
		clsservice ObjDLService = new clsservice(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Service Name";
		private const string Error002 = "Service Name already exist";
		private const string Error003 = "Invalid Value of Acronym";
		private const string Error004 = "Acronym Name already exist";
		private const string Error005 = "Invalid Value of Status";
		private const string Error006 = "Please select Department.";

		public clsBLService()
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

		public bool rsInsert(string mServiceName, string mAcronym, string mClinicID, string mActive, string mPhoneNo, string mDepartmentID)
		{		
			try
			{
				if(!VD_DepartmentID(mDepartmentID)) 
				{						
					return false;
				}

				if (VD_ServiceName(mClinicID, "", mServiceName)==false) 

				{						
					return false;
				};

				if (VD_Acronym(mClinicID, "", mAcronym)==false) 

				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLService.ServiceName =mServiceName; 
				ObjDLService.Acronym =mAcronym;
				ObjDLService.ClinicID = mClinicID;
				ObjDLService.Active=mActive;
				ObjDLService.PhoneNo = mPhoneNo;
				ObjDLService.DepartmentID = mDepartmentID;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLService, clsoperation.Get_PKey.Yes);
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


		public bool rsUpdate(string mServiceID, string mServiceName, string mAcronym, string mClinicID, string mActive, string mPhoneNo, string mDepartmentID)
		{
			try
			{
				if(!VD_DepartmentID(mDepartmentID))
				{						
					return false;
				}

				if (VD_ServiceName(mClinicID, mServiceID, mServiceName)==false) 
				{						
					return false;
				};

				if (VD_Acronym(mClinicID, mServiceID, mAcronym)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLService.PKeycode=mServiceID; 
				ObjDLService.ServiceName=mServiceName; 
				ObjDLService.Acronym =mAcronym;
				ObjDLService.ClinicID = mClinicID; 
				ObjDLService.Active=mActive;
				ObjDLService.PhoneNo = mPhoneNo;
				ObjDLService.DepartmentID = mDepartmentID;
				
				ObjTrans.Start_Transaction();
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLService);
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


		public bool rsDelete(string mServiceID)
		{
			try
			{
				ObjDLService.PKeycode=mServiceID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLService); 
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
				strErrorMessage=ex.Message;
				return false;
			};	
		}

		/// <summary>
		///		Display All Record - Return type DataView
		/// </summary>
		public DataView rsGetAll(string mServiceName, string mAcronym, string mClinicID, string mActive, string mPhoneNo, string mDepartmentID)
		{
			ObjDLService.ServiceName = mServiceName;
			ObjDLService.Acronym = mAcronym;
			ObjDLService.ClinicID = mClinicID;
			ObjDLService.Active = mActive;
			ObjDLService.PhoneNo = mPhoneNo;
			ObjDLService.DepartmentID = mDepartmentID;

			return ObjTrans.DataTrigger_Get_All(ObjDLService);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mServiceID)
		{
			ObjDLService.PKeycode=mServiceID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLService);
		}

		private bool VD_ServiceName(string mDepartmentID, string mServiceID, string mServiceName)
		{
			if (mServiceName=="") 
			{
				strErrorMessage=Error001;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll("", "", "", "", "", mDepartmentID);

			if (mServiceID=="")
			{mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And ServiceName='" + mServiceName + "'";}
			else
			{mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And ServiceName='" + mServiceName + "' And ServiceID<>'" + mServiceID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count > 0)
			{
				strErrorMessage = Error002;
				return false;}
			else
			{return true;}
		}

		private bool VD_Acronym(string mDepartmentID, string mServiceID, string mAcronym)
		{
			if (mAcronym=="") 
			{
				strErrorMessage=Error003;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll("", "", "", "", "", mDepartmentID);

			if (mServiceID=="")
			{mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And Acronym='" + mAcronym + "'";}
			else
			{mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And Acronym='" + mAcronym + "' And ServiceID<>'" + mServiceID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count>0)
			{
				strErrorMessage=Error004;
				return false;}
			else
			{return true;}
		}

		private bool VD_Active(string mActive)
		{
			if (mActive!="Y" & mActive!="N") 
			{
				strErrorMessage=Error005; 
				return false;
			}
			else
			{return true;}
		}

		private bool VD_DepartmentID(string mDepartmentID)
		{
			if(mDepartmentID.Equals(""))
			{
				strErrorMessage = Error006;
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}