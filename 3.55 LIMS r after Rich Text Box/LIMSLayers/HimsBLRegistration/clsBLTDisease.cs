using System;
using System.Data;  
using System.Data.OleDb;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	/// Summary description for clsBLTDisease.
	/// </summary>
	public class clsBLTDisease
	{
		public clsBLTDisease()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		clsDisease ObjDLDisease = new clsDisease();
		Validation objValid = new Validation();
		clsoperation ObjTrans = new clsoperation();

		private string strErrorMessage = "";
		private const string Error01 = "Disease Name field is empty.";
		private const string Error02 = "Disease Name is already present.";

		/// <summary>
		/// Error Message - Property
		/// </summary>
		public string ErrorMessage
		{
			get{	return strErrorMessage;	}
		}


		/// <summary>
		/// Record Insertion Method
		/// </summary>
		/// <param name="mDiseaseName">Disease Name (string, 50)</param>
		/// <param name="mAcronym">Acronym (string, 10)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <returns>Boolean</returns>
		public bool rsInsert(string mDiseaseName, string mAcronym,string mActive)
		{		
			try
			{
				if(!VD_DiseaseName("", mDiseaseName))
				{						
					return false;
				}

				ObjDLDisease.DiseaseName = mDiseaseName; 
				ObjDLDisease.Acronym = mAcronym; 
				ObjDLDisease.Active = mActive;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLDisease, clsoperation.Get_PKey.No);
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
				strErrorMessage = ex.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <param name="mDiseaseID">Disease ID (number)</param>
		/// <param name="mDiseaseName">Disease Name (string, 50)</param>
		/// <param name="mAcronym">Acronym (string, 10)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <returns>Boolean</returns>
		public bool rsUpdate(string mDiseaseID, string mDiseaseName, string mAcronym, string mActive)
		{
			try
			{
				if(!VD_DiseaseName(mDiseaseID, mDiseaseName)) 
				{
					return false;
				}

				ObjDLDisease.PKeycode = mDiseaseID;
				ObjDLDisease.DiseaseName = mDiseaseName; 
				ObjDLDisease.Acronym = mAcronym;
				ObjDLDisease.Active = mActive; 

				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLDisease);
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
				strErrorMessage = ex.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Reocord Deletion Method
		/// </summary>
		/// <param name="mDiseaseID">Disease ID (number)</param>
		/// <returns>Boolean</returns>
		public bool rsDelete(string mDiseaseID)
		{
			try
			{
				ObjDLDisease.PKeycode = mDiseaseID;

				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Delete(ObjDLDisease);
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
				strErrorMessage = ex.Message.ToString();
				return false;
			}
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <param name="mDiseaseName">Disease Name (string, 50)</param>
		/// <param name="mAcronym">Acronym (string, 10)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <returns>Boolean</returns>
		public DataView rsGetAll(string mDiseaseName, string mAcronym, string mActive)
		{
			ObjDLDisease.DiseaseName = mDiseaseName;
			ObjDLDisease.Acronym = mAcronym;
			ObjDLDisease.Active = mActive;

			return ObjTrans.DataTrigger_Get_All(ObjDLDisease);
		}


		/// <summary>
		/// Get Single Record on the basis of Primary Key
		/// </summary>
		/// <param name="mDiseaseID">Disease ID (number)</param>
		/// <returns>Boolean</returns>
		public DataView rsGetSingle(string mDiseaseID)
		{
			ObjDLDisease.PKeycode = mDiseaseID; 
			return ObjTrans.DataTrigger_Get_Single(ObjDLDisease);
		}


		private bool VD_DiseaseName(string mDiseaseID, string mDiseaseName)
		{
			try
			{
				if(!mDiseaseName.Equals(""))
				{
					DataView dvDisease = rsGetAll(mDiseaseName, "", "");

					if(!mDiseaseID.Equals(""))
					{
						dvDisease.RowFilter = "DiseaseID <> '" + mDiseaseID + "'";
						dvDisease.RowStateFilter = DataViewRowState.OriginalRows;
					}

					if(dvDisease.Count > 0)
					{
						strErrorMessage = Error02;
						return false;
					}

					strErrorMessage = "";
					return true;
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
	}
}
