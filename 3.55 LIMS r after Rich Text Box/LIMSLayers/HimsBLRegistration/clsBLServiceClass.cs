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


	public class clsBLServiceClass
	{

		clsserviceclass ObjDLServiceClass = new clsserviceclass(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Service";
		private const string Error002 = "Invalid Value of Class";
		private const string Error003 = "Service already exist with the same class";



		public clsBLServiceClass()
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

		public bool rsInsert(string mServiceID, string mClassID, int mRate)
		{		
			try
			{

				if (VD_ServiceID(mServiceID)==false) 
				{						
					return false;
				};

				if (VD_ClassID(mClassID)==false) 
				{						
					return false;
				};

				if (VD_ServiceClass(mServiceID, mClassID)==false)
				{
					return false;
				}
			

				ObjDLServiceClass.ServiceID = mServiceID; 
				ObjDLServiceClass.ClassID =mClassID; 
				ObjDLServiceClass.Rate= mRate; 		

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLServiceClass, clsoperation.Get_PKey.No);
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
		public bool rsUpdate(string mServiceID, string mClassID, int mRate)
		{
			try
			{		

				if (VD_ServiceID(mServiceID)==false) 
				{						
					return false;
				};

				if (VD_ClassID(mClassID)==false) 
				{						
					return false;
				};



				ObjDLServiceClass.ServiceID = mServiceID; 
				ObjDLServiceClass.ClassID =mClassID; 
				ObjDLServiceClass.Rate= mRate; 		

				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLServiceClass);
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

		public bool rsDelete(string mServiceID, string mClassID)
		{
			try
			{
				ObjDLServiceClass.ServiceID = mServiceID;
				ObjDLServiceClass.ClassID = mClassID;
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLServiceClass); 
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
			return ObjTrans.DataTrigger_Get_All(ObjDLServiceClass);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mServiceID, string mClassID)
		{
			ObjDLServiceClass.ServiceID = mServiceID;
			ObjDLServiceClass.ClassID = mClassID;
			return  ObjTrans.DataTrigger_Get_Single(ObjDLServiceClass);
		}

		private bool VD_ServiceID(string mServiceID)
		{
			clsBLService ObjBLService = new clsBLService();
			DataView mDataView = new DataView();
			mDataView=ObjBLService.rsGetSingle(mServiceID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error001;
				return false;}
			else
			{return true;}
		}

		private bool VD_ClassID(string mClassID)
		{
			clsBLEmpClass ObjBLClass = new clsBLEmpClass();
			DataView mDataView = new DataView();
			mDataView=ObjBLClass.rsGetSingle(mClassID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}
		private bool VD_ServiceClass(string mServiceID, string mClassID)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetSingle(mServiceID, mClassID);
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count>0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
		}
	}
}
