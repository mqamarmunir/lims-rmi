using System;
using System.Data;  
using HimsDlRegistration;


namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Speciality" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLSpeciality
	{
		clsspeciality ObjDLSpeciality = new clsspeciality(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Speciality ID.";
		private const string Error002 = "Speciality Name Invalid.";
		private const string Error003 = "Speciality  Already Exist.";
		private const string Error004 = "Speciality Value of Active.";
		private const string Error005 = "Invalid Speciality Type.";

		public clsBLSpeciality()
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

		public bool rsInsert(string mSpecialityDesc, string mActive, 
			string mSpecialityTypeID)
		{
		
			try
			{
				if (VD_SpecialityDesc("", mSpecialityDesc)==false) 
				{						
					return false;
				};


				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLSpeciality.SpecialityDesc =mSpecialityDesc; 
				ObjDLSpeciality.Active=mActive; 			
				ObjDLSpeciality.SpecialityTypeID=mSpecialityTypeID;
				
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLSpeciality, clsoperation.Get_PKey.Yes);
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

		public bool rsUpdate(string mSpecialityID, string mSpecialityDesc, 
			string mActive, string mSpecialityTypeID)
		{
			try
			{		

				if (VD_SpecialityDesc(mSpecialityID, mSpecialityDesc)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLSpeciality.PKeycode=mSpecialityID; 
				ObjDLSpeciality.SpecialityDesc=mSpecialityDesc; 
				ObjDLSpeciality.Active=mActive; 				
				ObjDLSpeciality.SpecialityTypeID=mSpecialityTypeID;
				ObjTrans.Start_Transaction(); 
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLSpeciality);
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

		public bool rsDelete(string mSpecialityID)
		{
			try
			{
				ObjDLSpeciality.PKeycode=mSpecialityID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLSpeciality); 
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
			return ObjTrans.DataTrigger_Get_All(ObjDLSpeciality);
		}


		public DataView rsGetAll(string mSpecialityTypeID)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetAll();
			{mDataView.RowFilter ="SpecialityTypeID='" + mSpecialityTypeID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
		return mDataView; 

		}


		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mSpecialityID)
		{
			ObjDLSpeciality.PKeycode=mSpecialityID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLSpeciality);
		}

		private bool VD_SpecialityDesc(string mSpecialityID,  string mSpecialityDesc)
		{
			if (mSpecialityDesc=="") 
			{
				strErrorMessage=Error002;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll();
			if (mSpecialityID=="")
			{mDataView.RowFilter ="SpecialityDesc='" + mSpecialityDesc + "'";}
			else
			{mDataView.RowFilter ="SpecialityDesc='" + mSpecialityDesc + "' And SpecialityID<>'" + mSpecialityID + "'";}
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

		private bool VD_SpecialityTypeID(string mSpecialityTypeID)
		{
			clsBLSpecialityType ObjBLSpecialityType = new clsBLSpecialityType();
			DataView mDataView = new DataView();
			mDataView=ObjBLSpecialityType.rsGetSingle(mSpecialityTypeID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error005;
				return false;}
			else
			{return true;}
		}


	}
}
