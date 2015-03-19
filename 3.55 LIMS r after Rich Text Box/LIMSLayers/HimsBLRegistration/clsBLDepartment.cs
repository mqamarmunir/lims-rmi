using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;


namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Department" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	May 2004 (In POF Hospital Wah Cantt)	
	/// 	Type		:	Business Layer Class
	/// </summary>
	
	
	public class clsBLDepartment
	{
		clsdepartment ObjDLDepartment = new clsdepartment(); 
		Validation objValid = new Validation();	 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error01 = "Department Name field is Empty.";
		private const string Error02 = "Department Name is Incorrect.";
		private const string Error03 = "Department Name is already Used.";
		private const string Error04 = "Acronym Field is Empty.";
		private const string Error05 = "Acronym is Incorrect.";
		private const string Error06 = "Acronym is already Used.";
		private const string Error07 = "Department Type field is Empty.";		
		

		public clsBLDepartment()
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
		/// <param name="mDepartmentName">Department Name (string, 30)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mDepartmentType">Department Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public bool rsInsert(string mDepartmentName, string mAcronym,string mActive, string mDepartmentType)
		{		
			try
			{
				if(!VD_DepartmentName("", mDepartmentName)) 
				{						
					return false;
				}
				
				if(!VD_Acronym("", mAcronym)) 
				{						
					return false;
				}

				if(!VD_DepartmentType(mDepartmentType)) 
				{						
					return false;
				}

				ObjDLDepartment.DepartmentName =mDepartmentName; 
				ObjDLDepartment.Acronym =mAcronym; 
				ObjDLDepartment.Active=mActive; 		
				ObjDLDepartment.DepartmentType = mDepartmentType; 

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLDepartment, clsoperation.Get_PKey.Yes);
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
		public bool rsUpdate(string mDepartmentID, string mDepartmentName, string mAcronym, string mActive, 	string mDepartmentType)
		{
			try
			{		
				if(!VD_DepartmentName(mDepartmentID, mDepartmentName)) 
				{						
					return false;
				}

				if(!VD_Acronym(mDepartmentID, mAcronym)) 
				{						
					return false;
				}

				if(!VD_DepartmentType(mDepartmentType)) 
				{						
					return false;
				}
				
				ObjDLDepartment.PKeycode = mDepartmentID; 
				ObjDLDepartment.DepartmentName = mDepartmentName; 
				ObjDLDepartment.Acronym = mAcronym; 
				ObjDLDepartment.Active = mActive; 
				ObjDLDepartment.DepartmentType = mDepartmentType; 
				
				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLDepartment);
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
		/// Reocord Deletion Method
		/// </summary>
		/// <param name="mDepartmentID">Department ID (string, 4)</param>
		/// <returns>Boolean</returns>
		public bool rsDelete(string mDepartmentID)
		{
			try
			{
				ObjDLDepartment.PKeycode = mDepartmentID; 
				
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLDepartment); 
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
		/// <param name="mDepartmentName">Department Name (string, 30)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mDepartmentType">Department Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public DataView rsGetAll(string mDepartmentName, string mAcronym, string mActive, string mDepartmentType)
		{			
			ObjDLDepartment.DepartmentName = mDepartmentName; 
			ObjDLDepartment.Acronym = mAcronym; 
			ObjDLDepartment.Active = mActive; 
			ObjDLDepartment.DepartmentType = mDepartmentType; 
			
			return ObjTrans.DataTrigger_Get_All(ObjDLDepartment);
		}


		/// <summary>
		/// Get Single Record on the basis of Primary Key
		/// </summary>
		/// <param name="mDepartmentID">Department ID (string, 4)</param>
		/// <returns>Boolean</returns>
		public DataView rsGetSingle(string mDepartmentID)
		{
			ObjDLDepartment.PKeycode=mDepartmentID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLDepartment);
		}


		private bool VD_DepartmentName(string mDepartmentID, string mDepartmentName)
		{
			try
			{
				if(!mDepartmentName.Equals(""))
				{
					if(objValid.IsName(mDepartmentName))
					{
						DataView dvDept = rsGetAll(mDepartmentName, "", "", "");
						if(!mDepartmentID.Equals(""))
						{
							dvDept.RowFilter = "DepartmentID<>'"+ mDepartmentID +"'";
							dvDept.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDept.Count > 0)
						{
							strErrorMessage = Error03;
							return false;
						}
						strErrorMessage = "";
						return true;
					}
					else
					{
						strErrorMessage = Error02;
						return false;
					}
				}
				else
				{
					strErrorMessage = Error01;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrorMessage = e.Message.ToString();
				return false;
			}
		}


		private bool VD_Acronym(string mDepartmentID, string mAcronym)
		{
			try
			{
				if(!mAcronym.Equals(""))
				{
					if(objValid.IsName(mAcronym))
					{
						DataView dvDept = rsGetAll("", mAcronym, "", "");
						if(!mDepartmentID.Equals(""))
						{
							dvDept.RowFilter = "DepartmentID<>'"+ mDepartmentID +"'";
							dvDept.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDept.Count > 0)
						{
							strErrorMessage = Error06;
							return false;
						}
						strErrorMessage = "";
						return true;
					}
					else
					{
						strErrorMessage = Error05;
						return false;
					}
				}
				else
				{
					strErrorMessage = Error04;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrorMessage = e.Message.ToString();
				return false;
			}
		}


		private bool VD_DepartmentType(string mDepartmentType)
		{
			if(mDepartmentType.Equals(""))
			{
				strErrorMessage = Error07;
				return false;
			}
			strErrorMessage = "";
			return true;
		}		
	}
}