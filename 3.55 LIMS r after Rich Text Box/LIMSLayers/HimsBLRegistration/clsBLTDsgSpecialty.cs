using System;
using System.Data;
using System.Data.OleDb;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	/// Application	:	Hospital Information & Management System (HIMS)
	///	Class for	:	"tDsgSpecialty" Table
	///	Developer	:	Trees Software (Pvt) Ltd.
	///	Date		:	August 2004 (In POF Hospital Wah Cantt)	
	/// Type		:	Business Layer Class
	/// </summary>
	public class clsBLTDsgSpecialty
	{
		clsTDsgSpecialty objTDSpecialty = new clsTDsgSpecialty();
		Validation objValid = new Validation();	 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error01 = "Designation ID field is Empty.";
		private const string Error02 = "Designation Specialty Name field is Empty.";
		private const string Error03 = "Designation Specialty Name is Incorrect.";
		private const string Error04 = "Designation Specialty Name is already Used.";
		private const string Error05 = "Acronym Field is Empty.";
		private const string Error06 = "Acronym is Incorrect.";
		private const string Error07 = "Acronym is already Used.";
				

		public clsBLTDsgSpecialty()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		

		/// <summary>
		/// Error Message - Property
		/// </summary>
		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}


		/// <summary>
		/// Record Insertion Method
		/// </summary>
		/// <param name="mDesignationID">Designaiotn ID (string, 5)</param>
		/// <param name="mDsgSpecialtyName">Designation Specialty Name (string, 30)</param>
		/// <param name="mActive"> Active (string, 1)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <returns>Boolean</returns>
		public bool rsInsert(string mDesignationID, string mDsgSpecialtyName, string mActive, string mAcronym)
		{		
			try
			{
				if(!VD_DesignationID(mDesignationID)) 
				{						
					return false;
				}
				
				if(!VD_DsgSpecialtyName("", mDsgSpecialtyName)) 
				{						
					return false;
				}

				if(!VD_Acronym("", mAcronym)) 
				{						
					return false;
				}				

				objTDSpecialty.DesignationID = mDesignationID; 
				objTDSpecialty.DsgSpecialtyName = mDsgSpecialtyName;  
				objTDSpecialty.Active = mActive; 		
				objTDSpecialty.Acronym = mAcronym; 

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(objTDSpecialty, clsoperation.Get_PKey.Yes);
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
			}			  
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <param name="mDepartmentID">Department ID (string, 4)</param>
		/// <param name="mDepartmentName">Department Name (string, 30)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mDepartmentType">Department Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public bool rsUpdate(string mDsgSpecialtyID, string mDesignationID, string mDsgSpecialtyName, string mActive, string mAcronym)
		{
			try
			{		
				if(!VD_DesignationID(mDesignationID)) 
				{						
					return false;
				}

				if(!VD_DsgSpecialtyName(mDsgSpecialtyID, mDsgSpecialtyName)) 
				{						
					return false;
				}

				if(!VD_Acronym(mDsgSpecialtyID, mAcronym)) 
				{						
					return false;
				}
				
				objTDSpecialty.PKeycode = mDsgSpecialtyID; 
				objTDSpecialty.DesignationID = mDesignationID; 
				objTDSpecialty.DsgSpecialtyName = mDsgSpecialtyName; 
				objTDSpecialty.Active = mActive; 
				objTDSpecialty.Acronym = mAcronym; 
								
				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(objTDSpecialty);
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
			}			  
		}


		/// <summary>
		/// Record Deletion Method
		/// </summary>
		/// <param name="mDsgSpecialtyID">Designation Specialty ID (string, 5)</param>
		/// <returns>Boolean</returns>
		public bool rsDelete(string mDsgSpecialtyID)
		{
			try
			{
				objTDSpecialty.PKeycode = mDsgSpecialtyID; 
				
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(objTDSpecialty); 
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
			}
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <returns>DataView</returns>
		public DataView rsGetAll(string mDesignationID, string mDsgSpecialtyName, string mActive, string mAcronym)
		{
			objTDSpecialty.DesignationID = mDesignationID;
			objTDSpecialty.DsgSpecialtyName = mDsgSpecialtyName;
			objTDSpecialty.Active = mActive;
			objTDSpecialty.Acronym = mAcronym;

			return ObjTrans.DataTrigger_Get_All(objTDSpecialty);
		}


		/// <summary>
		/// Get Single Record Method on the basis of Primary Key
		/// </summary>
		/// <param name="mDsgSpecialtyID">Designation Specialty ID</param>
		/// <returns>DataView</returns>
		public DataView rsGetSingle(string mDsgSpecialtyID)
		{
			objTDSpecialty.PKeycode = mDsgSpecialtyID; 
			return  ObjTrans.DataTrigger_Get_Single(objTDSpecialty);
		}


		private bool VD_DsgSpecialtyName(string mDsgSpecialtyID, string mDsgSpecialtyName)
		{
			try
			{
				if(!mDsgSpecialtyName.Equals(""))
				{
					if(objValid.IsName(mDsgSpecialtyName))
					{
						DataView dvDSpecialty = rsGetAll("", mDsgSpecialtyName, "", "");
						if(!mDsgSpecialtyID.Equals(""))
						{
							dvDSpecialty.RowFilter = "DsgSpecialtyID<>'"+ mDsgSpecialtyID +"'";
							dvDSpecialty.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDSpecialty.Count > 0)
						{
							strErrorMessage = Error04;
							return false;
						}
						strErrorMessage = "";
						return true;
					}
					else
					{
						strErrorMessage = Error03;
						return false;
					}
				}
				else
				{
					strErrorMessage = Error02;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrorMessage = e.Message.ToString();
				return false;
			}
		}


		private bool VD_Acronym(string mDsgSpecialtyID, string mAcronym)
		{
			try
			{
				if(!mAcronym.Equals(""))
				{
					if(objValid.IsAlpha(mAcronym))
					{
						DataView dvDSpecialty = rsGetAll("", "", "", mAcronym);
						if(!mDsgSpecialtyID.Equals(""))
						{
							dvDSpecialty.RowFilter = "DsgSpecialtyID<>'"+ mDsgSpecialtyID +"'";
							dvDSpecialty.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDSpecialty.Count > 0)
						{
							strErrorMessage = Error07;
							return false;
						}
						strErrorMessage = "";
						return true;
					}
					else
					{
						strErrorMessage = Error06;
						return false;
					}
				}
				else
				{
					strErrorMessage = Error05;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrorMessage = e.Message.ToString();
				return false;
			}
		}


		private bool VD_DesignationID(string mDesignationID)
		{
			if(mDesignationID.Equals(""))
			{
				strErrorMessage = Error01;
				return false;
			}
			strErrorMessage = "";
			return true;
		}		
	}
}
