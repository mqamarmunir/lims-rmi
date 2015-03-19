using System;
using System.Data;  
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"SpecialityType" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	June 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLSpecialityType
	{
		clsspecialitytype ObjDLSpecialityType = new clsspecialitytype(); 

		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Speciality Type ID.";
		private const string Error002 = "Speciality Type Invalid.";
		private const string Error003 = "Speciality Type Already Exist.";
		private const string Error004 = "Invalid Value of Active.";
		public clsBLSpecialityType()
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

		public bool rsInsert(string mSpecialityTypeDesc, string mActive)
		{
		
			try
			{
				if (VD_SpecialityTypeDesc("", mSpecialityTypeDesc)==false) 
				{						
					return false;
				};


				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLSpecialityType.SpecialityTypeDesc =mSpecialityTypeDesc; 
				ObjDLSpecialityType.Active=mActive; 			
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLSpecialityType, clsoperation.Get_PKey.Yes);
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

		public bool rsUpdate(string mSpecialityTypeID, string mSpecialityTypeDesc, string mActive)
		{
			try
			{		

				if (VD_SpecialityTypeDesc(mSpecialityTypeID, mSpecialityTypeDesc)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLSpecialityType.PKeycode=mSpecialityTypeID; 
				ObjDLSpecialityType.SpecialityTypeDesc=mSpecialityTypeDesc; 
				ObjDLSpecialityType.Active=mActive; 				
				ObjTrans.Start_Transaction(); 
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLSpecialityType);
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

		public bool rsDelete(string mSpecialityTypeID)
		{
			try
			{
				ObjDLSpecialityType.PKeycode=mSpecialityTypeID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLSpecialityType); 
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
			return ObjTrans.DataTrigger_Get_All(ObjDLSpecialityType);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mSpecialityTypeID)
		{
			ObjDLSpecialityType.PKeycode=mSpecialityTypeID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLSpecialityType);
		}

		private bool VD_SpecialityTypeDesc(string mSpecialityTypeID,  string mSpecialityTypeDesc)
		{
			if (mSpecialityTypeDesc=="") 
			{
				strErrorMessage=Error002;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll();
			if (mSpecialityTypeID=="")
			{mDataView.RowFilter ="SpecialityTypeDesc='" + mSpecialityTypeDesc + "'";}
			else
			{mDataView.RowFilter ="SpecialityTypeDesc='" + mSpecialityTypeDesc + "' And SpecialityTypeID<>'" + mSpecialityTypeID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count>0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
		}

		private bool VD_Active(string mActive)
		{
			if (mActive!="Y" & mActive!="N") 
			{
				strErrorMessage=Error004; 
				return false;
			}
			else
			{return true;}
		}


	}
}
