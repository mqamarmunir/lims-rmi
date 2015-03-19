using System;
using System.Data;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	/// Application	:	Hospital Information & Management System (HIMS)
	///	Class for	:	"tDesignation" Table
	///	Developer	:	Trees Software (Pvt) Ltd.
	///	Date		:	August 2004 (In POF Hospital Wah Cantt)	
	/// Type		:	Business Layer Class
	/// </summary>
	public class clsBLTDesignation
	{
		public clsBLTDesignation()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		clsTDesignation objTDesignation = new clsTDesignation();
		clsoperation objTrans = new clsoperation();
		Validation objValid = new Validation(); 
		
		private string strErrMsg = "";
		
		#region "Constant Errors"

		private const string Error01 = "Designation Name field is Empty.";
		private const string Error02 = "Designation Name is Incorrect.";
		private const string Error03 = "Designation Name is already Used.";
		private const string Error04 = "Acronym Field is Empty.";
		private const string Error05 = "Acronym is Incorrect.";
		private const string Error06 = "Acronym is already Used.";
		private const string Error07 = "Designation Type field is Empty.";
		private const string Error08 = "Designation Type is Incorrect";

		#endregion
		

		/// <summary>
		/// Error Message Property
		/// </summary>
		public string ErrorMessage
		{
			get
			{
				return strErrMsg;
			}
		}

		
		/// <summary>
		/// Record Insertion Method
		/// </summary>
		/// <param name="mDesignationName">Designation Name (string, 30)</param>
		/// <param name="mActive">Designation - Active or Inactive (string, 1)</param>
		/// <param name="mAcronym">Designation Acronym (string, 6)</param>
		/// <param name="mDesignationType">Designation Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public bool rsInsert(string mDesignationName, string mActive, string mAcronym, string mDesignationType)
		{
			try
			{
				if(!VD_DesignationName("", mDesignationName))
				{
					return false;
				}

				if(!VD_Acronym("", mAcronym))
				{
					return false;
				}

				if(!VD_DesignationType(mDesignationType))
				{
					return false;
				}

				objTDesignation.DesignationName = mDesignationName;
				objTDesignation.Active = mActive;
				objTDesignation.Acronym = mAcronym;
				objTDesignation.DesignationType = mDesignationType;

				objTrans.Start_Transaction();
				strErrMsg = objTrans.DataTrigger_Insert(objTDesignation, clsoperation.Get_PKey.Yes);
				objTrans.End_Transaction();

				if(strErrMsg.Equals("True"))
				{
					strErrMsg = objTrans.OperationError.ToString();
					return false;
				}
				strErrMsg = "";
				return true;
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <param name="mDesignationID">Designation ID (string, 5)</param>
		/// <param name="mDesignationName">Designation Name (string, 30)</param>
		/// <param name="Active">Designation - Active or Inactive (string, 1)</param>
		/// <param name="Acronym">Designation - Acronym (string, 6)</param>
		/// <param name="mDesignationType">Designation Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public bool rsUpdate(string mDesignationID, string mDesignationName, string mActive, string mAcronym, string mDesignationType)
		{
			try
			{
				if(!VD_DesignationName(mDesignationID, mDesignationName))
				{
					return false;
				}

				if(!VD_Acronym(mDesignationID, mAcronym))
				{
					return false;
				}

				if(!VD_DesignationType(mDesignationType))
				{
					return false;
				}

				objTDesignation.PKeycode = mDesignationID;
				objTDesignation.DesignationName = mDesignationName;
				objTDesignation.Active = mActive;
				objTDesignation.Acronym = mAcronym;
				objTDesignation.DesignationType = mDesignationType;
				
				objTrans.Start_Transaction();
				strErrMsg = objTrans.DataTrigger_Update(objTDesignation);
				objTrans.End_Transaction();

				if(strErrMsg.Equals("True"))
				{
					strErrMsg = objTrans.OperationError.ToString();
					return false;
				}
				strErrMsg = "";
				return true;
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Record Deletion Method
		/// </summary>
		/// <param name="mDesignationID">Designation ID (string, 5)</param>
		/// <returns>Boolean</returns>
		public bool rsDelete(string mDesignationID)
		{
			try
			{
				objTDesignation.PKeycode = mDesignationID;

				objTrans.Start_Transaction();
				strErrMsg = objTrans.DataTrigger_Delete(objTDesignation);
				objTrans.End_Transaction();

				if(strErrMsg.Equals("True"))
				{
					strErrMsg = objTrans.OperationError.ToString();
					return false;
				}
				strErrMsg = "";
				return true;
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <param name="mDesignationName">Designation Name (string, 30)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mDesignationType">Designation Type (string, 2)</param>
		/// <returns>Boolean</returns>
		public DataView rsGetAll(string mDesignationName, string mActive, string mAcronym, string mDesignationType)
		{
			try
			{
				objTDesignation.DesignationName = mDesignationName;
				objTDesignation.Active = mActive;
				objTDesignation.Acronym = mAcronym;
				objTDesignation.DesignationType = mDesignationType;

				
				DataView dvTDsg = objTrans.DataTrigger_Get_All(objTDesignation);
				
				return dvTDsg;
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return null;
			}
		}


		public DataView rsGetSingle(string mDesignationID)
		{
			try
			{
				objTDesignation.PKeycode = mDesignationID;

				DataView dvTDsg = objTrans.DataTrigger_Get_Single(objTDesignation);
				
				return dvTDsg;
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return null;
			}
		}


		private bool VD_DesignationName(string mDsgID, string mDsgName)
		{
			try
			{
				if(!mDsgName.Equals(""))
				{
					if(objValid.IsName(mDsgName))
					{
						DataView dvDesignation = rsGetAll(mDsgName, "", "", "");
						if(!mDsgID.Equals(""))
						{
							dvDesignation.RowFilter = "DesignationID<>'"+ mDsgID +"'";
							dvDesignation.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDesignation.Count > 0)
						{
							strErrMsg = Error03;
							return false;
						}
						strErrMsg = "";
						return true;
					}
					else
					{
						strErrMsg = Error02;
						return false;
					}
				}
				else
				{
					strErrMsg = Error01;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}


		private bool VD_Acronym(string mDsgID, string mAcronym)
		{
			try
			{
				if(!mAcronym.Equals(""))
				{
					if(objValid.IsName(mAcronym))
					{
						DataView dvDesignation = rsGetAll("", "", mAcronym, "");
						if(!mDsgID.Equals(""))
						{
							dvDesignation.RowFilter = "DesignationID<>'"+ mDsgID +"'";
							dvDesignation.RowStateFilter = DataViewRowState.OriginalRows;
						}
						if(dvDesignation.Count > 0)
						{
							strErrMsg = Error06;
							return false;
						}
						strErrMsg = Error05;
						return true;
					}
					else
					{
						strErrMsg = Error04;
						return false;
					}
				}
				else
				{
					strErrMsg = Error04;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}


		private bool VD_DesignationType(string mDsgType)
		{
			try
			{
				if(!mDsgType.Equals(""))
				{
					if(objValid.IsAlpha(mDsgType))
					{
						return true;
					}
					else
					{
						strErrMsg = Error08;
						return false;						
					}
				}
				else
				{
					strErrMsg = Error07;
					return false;
				}
			}
			catch(Exception e)
			{
				strErrMsg = e.Message.ToString();
				return false;
			}
		}
	}
}