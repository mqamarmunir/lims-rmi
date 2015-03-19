using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Clinic" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	
	public class clsBLClinic
	{
	
		clsclinic ObjDLClinic = new clsclinic(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Department";
		private const string Error002 = "Invalid Value of Sub-Department";
		private const string Error003 = "Sub-Department already exist";
		private const string Error004 = "Invalid Value of Acronym";
		private const string Error005 = "Acronym already exist";
		private const string Error006 = "Invalid Value of Status";


		public clsBLClinic()
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


		public bool rsInsert(string mClinicName, string mDepartmentID, string mActive, string mAcronym, string mContactPerson, string mCellNo, string mPhone1, string mPhone2, string mFax1, string mFax2, string mEMail1, string mEMail2, string mDescription, string mLocation)
		{
			try
			{
				/*if(false == Data_Validation(mClinicName,mDepartmentID,  mActive,  mAcronym,mContactPerson,  mCellNo,  mPhone1,  mPhone2,  mFax1,mFax2,  mEMail1,  mEMail2,  mDescription))
				{
					return false;
				}*/

				if (VD_DepartmentID(mDepartmentID)==false) 
				{						
					return false;
				};

				if (VD_ClinicName(mDepartmentID, "", mClinicName)==false) 

				{						
					return false;
				};

				if (VD_Acronym(mDepartmentID, "", mAcronym)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLClinic.ClinicName =mClinicName; 
				ObjDLClinic.DepartmentID =mDepartmentID;
				ObjDLClinic.Active=mActive; 	
				ObjDLClinic.Acronym=mAcronym; 
				ObjDLClinic.ContactPerson = mContactPerson;
				ObjDLClinic.CellNo = mCellNo;
				ObjDLClinic.Phone1 = mPhone1;
				ObjDLClinic.Phone2 = mPhone2;
				ObjDLClinic.Fax2 = mFax2;
				ObjDLClinic.Fax1 = mFax1;
				ObjDLClinic.Fax2 = mFax2;
				ObjDLClinic.EMail1 = mEMail1;
				ObjDLClinic.EMail2 = mEMail2;
				ObjDLClinic.Description = mDescription;
				ObjDLClinic.Location = mLocation;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLClinic, clsoperation.Get_PKey.Yes);
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
				strErrorMessage = ex.Message;
				return false;
			};				  
		}


		private bool Data_Validation(string mClinicName, string mDepartmentID, string mActive, string mAcronym,string mContactPerson, string mCellNo, string mPhone1, string mPhone2, string mFax1,string mFax2, string mEMail1, string mEMail2, string mDescription)
		{
			Validation objVal = new Validation();

			if(!objVal.IsName(mClinicName) && mClinicName != "")
			{
				strErrorMessage = "Invalid name of clinic";
				return false;
			}
			
			if(!objVal.IsAlpha(mAcronym) && mAcronym != "")
			{
				strErrorMessage = "Invalid acronym";
				return false;
			}

			if(!objVal.IsName(mContactPerson) && mContactPerson != "")
			{
				strErrorMessage = "Invalid contact person name";
				return false;
			}

			if(!objVal.IsEmail(mEMail1) && mEMail1 != "")
			{
				strErrorMessage = "Invalid email address 1";
			}

			if(!objVal.IsEmail(mEMail2) && mEMail2 != "")
			{
				strErrorMessage = "Invalid email address 2";
			}

			return true;
		}


		public bool rsUpdate(string mClinicID, string mClinicName, string mDepartmentID, string mActive, string mAcronym, string mContactPerson, string mCellNo, string mPhone1, string mPhone2, string mFax1, string mFax2, string mEMail1, string mEMail2, string mDescription, string mLocation)
		{
			try
			{
			/*	if(false == Data_Validation(mClinicName,mDepartmentID,  mActive,  mAcronym,mContactPerson,  mCellNo,  mPhone1,  mPhone2,  mFax1,mFax2,  mEMail1,  mEMail2,  mDescription))
				{
					return false;
				}*/

				if (VD_DepartmentID(mDepartmentID)==false) 
				{						
					return false;
				};

				if (VD_ClinicName(mDepartmentID, mClinicID, mClinicName)==false) 
				{						
					return false;
				};

				if (VD_Acronym(mDepartmentID, mClinicID, mAcronym)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLClinic.PKeycode=mClinicID; 
				ObjDLClinic.ClinicName=mClinicName; 
				ObjDLClinic.DepartmentID =mDepartmentID;
				ObjDLClinic.Active=mActive; 		
				ObjDLClinic.Acronym=mAcronym; 
				ObjDLClinic.ContactPerson = mContactPerson;
				ObjDLClinic.CellNo = mCellNo;
				ObjDLClinic.Phone1 = mPhone1;
				ObjDLClinic.Phone2 = mPhone2;
				ObjDLClinic.Fax2 = mFax2;
				ObjDLClinic.Fax1 = mFax1;
				ObjDLClinic.Fax2 = mFax2;
				ObjDLClinic.EMail1 = mEMail1;
				ObjDLClinic.EMail2 = mEMail2;
				ObjDLClinic.Description = mDescription;
				ObjDLClinic.Location = mLocation;

				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLClinic);
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
				strErrorMessage = ex.Message;
				return false;
			};
		}


		public bool rsDelete(string mClinicID)
		{
			try
			{
				ObjDLClinic.PKeycode = mClinicID;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Delete(ObjDLClinic); 
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
				strErrorMessage = ex.Message;
				return false;
			};	
		}


		/// <summary>
		///	Display All Record - Return type DataView
		/// </summary>

		public DataView rsGetAll(string mClinicName, string mDepartmentID, string mActive, string mAcronym, string mContactPerson, string mCellNo, string mPhone, string mFax, string mEMail, string mDescription, string mLocation)
		{
			ObjDLClinic.ClinicName = mClinicName;
			ObjDLClinic.DepartmentID = mDepartmentID;
			ObjDLClinic.Active = mActive;
			ObjDLClinic.Acronym = mAcronym;
			ObjDLClinic.ContactPerson = mContactPerson;
			ObjDLClinic.CellNo = mCellNo;
			ObjDLClinic.Phone = mPhone;
			ObjDLClinic.Fax = mFax;
			ObjDLClinic.Email = mEMail;
			ObjDLClinic.Description = mDescription;
			ObjDLClinic.Location = mLocation;

			return ObjTrans.DataTrigger_Get_All(ObjDLClinic);
		}


		/// <summary>
		///	Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>
		public DataView rsGetSingle(string mClinicID)
		{
			ObjDLClinic.PKeycode = mClinicID;

			return ObjTrans.DataTrigger_Get_Single(ObjDLClinic);
		}


		public DataView rsGetSingle(string mDepartmentID, string mClinicID)
		{
			DataView mDataView = new DataView();
			ObjDLClinic.PKeycode = mClinicID; 
			mDataView = ObjTrans.DataTrigger_Get_Single(ObjDLClinic);
			{mDataView.RowFilter ="ClinicID='" + mClinicID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			return mDataView; 
		}


		private bool VD_ClinicName(string mDepartmentID, string mClinicID, string mClinicName)
		{
			if (mClinicName == "")
			{
				strErrorMessage=Error002;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mClinicName, mDepartmentID, "", "", "", "", "", "", "", "", "");

			if (mClinicID!="")
				{
					mDataView.RowFilter ="ClinicID<>'" + mClinicID + "'";
					mDataView.RowStateFilter = DataViewRowState.OriginalRows;
				}

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
				strErrorMessage=Error006; 
				return false;
			}
			else
			{return true;}
		}

		private bool VD_DepartmentID(string mDepartmentID)
		{
			clsBLDepartment ObjBLDepartment = new clsBLDepartment();
			DataView mDataView = new DataView();
			mDataView=ObjBLDepartment.rsGetSingle(mDepartmentID);
			
			if (mDataView.Count == 0)
			{
				strErrorMessage = Error001;
				return false;
			}
			else
			{
				return true;
			}
		}


		private bool VD_Acronym(string mDepartmentID, string mClinicID, string mAcronym)
		{
			if (mAcronym=="") 
			{
				strErrorMessage=Error004;
				return false;
			};

			DataView mDataView = new DataView();			
			/*mDataView=rsGetAll();*/

			mDataView=rsGetAll("", "", "", "", "", "", "", "", "", "", "");

			if(mClinicID=="")
			{
				mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And Acronym='" + mAcronym + "'";
			}
			else
			{
				mDataView.RowFilter ="DepartmentID='" + mDepartmentID + "' And Acronym='" + mAcronym + "' And ClinicID<>'" + mClinicID + "'";
			}
			
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
		
			if (mDataView.Count>0)
			{
				strErrorMessage=Error005;
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}