using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;


namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Rank" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	May 2004 (POF Hospital Wah Cantt)
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLRank
	{
		clsrank ObjDLRank = new clsrank(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Please enter Rank Name (empty is not allowed)";
		private const string Error002 = "Rank Name already exist";
		private const string Error003 = "Acronym Name already exist";
		private const string Error004 = "Please select Organization";
		private const string Error005 = "Please select Employee Class";

		public clsBLRank()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ErrorMessage
		{
			get{	return strErrorMessage;	}
		}

		public bool rsInsert(string mRankName, string mAcronym, string mActive, string mOrgID, string mClassID)
		{		
			try
			{
				if(!VD_OrgID(mOrgID))
				{
					return false;
				}

				if(!VD_ClassID(mClassID))
				{
					return false;
				}

				if(!VD_RankName(mOrgID, "", mRankName))
				{						
					return false;
				}

				if(!VD_Acronym(mOrgID, "", mAcronym))
				{						
					return false;
				}

				ObjDLRank.RankName = mRankName; 
				ObjDLRank.Acronym = mAcronym;
				ObjDLRank.Active = mActive;
				ObjDLRank.ClassID = mClassID;
				ObjDLRank.OrgID = mOrgID;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLRank, clsoperation.Get_PKey.Yes);
				ObjTrans.End_Transaction();

				if(strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}

				strErrorMessage = "";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage=ex.Message.ToString();
				return false;
			}
		}

		public bool rsUpdate(string mRankID, string mRankName, string mAcronym, string mActive, string mOrgID, string mClassID)
		{
			try
			{
				if(!VD_OrgID(mOrgID))
				{
					return false;
				}

				if(!VD_ClassID(mClassID))
				{
					return false;
				}

				if(!VD_RankName(mOrgID, mRankID, mRankName))
				{						
					return false;
				}

				if(!VD_Acronym(mOrgID, mRankID, mAcronym))
				{						
					return false;
				}

				ObjDLRank.PKeycode = mRankID; 
				ObjDLRank.RankName = mRankName; 
				ObjDLRank.Acronym = mAcronym;				
				ObjDLRank.Active = mActive;
				ObjDLRank.ClassID = mClassID;
				ObjDLRank.OrgID = mOrgID;

				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLRank);
				ObjTrans.End_Transaction();

				if(strErrorMessage == "True") 
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

		public bool rsDelete(string mRankID)
		{
			try
			{
				ObjDLRank.PKeycode=mRankID;

				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLRank); 
				ObjTrans.End_Transaction();

				if(strErrorMessage == "True")
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
		///	Display All Record - Return type DataView
		/// </summary>
		public DataView rsGetAll(string mOrgID, string mClassID, string mActive)
		{
			ObjDLRank.OrgID = mOrgID;
			ObjDLRank.ClassID = mClassID;
			ObjDLRank.Active = mActive;

			return ObjTrans.DataTrigger_Get_All(ObjDLRank);
		}

		/// <summary>
		///	Return Single Record - Paramater Rank ID - Return type DataView
		/// </summary>
		public DataView rsGetSingle(string mRankID)
		{
			ObjDLRank.PKeycode=mRankID;

			return  ObjTrans.DataTrigger_Get_Single(ObjDLRank);
		}

		private bool VD_RankName(string mOrgID, string mRankID, string mRankName)
		{
			if(mRankName.Equals(""))
			{
				strErrorMessage = Error001;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView = rsGetAll(mOrgID, "", "");

			if(mRankID.Equals(""))
			{
				mDataView.RowFilter = "RankName = '" + mRankName + "'";
			}
			else
			{
				mDataView.RowFilter ="RankName = '" + mRankName + "' And RankID <> '" + mRankID + "'";
			}
			
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;

			if(mDataView.Count>0)
			{
				strErrorMessage = Error002;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_Acronym(string mOrgID, string mRankID, string mAcronym)
		{
			DataView mDataView = new DataView();			
			mDataView = rsGetAll(mOrgID, "", "");

			if(mRankID.Equals(""))
			{
				mDataView.RowFilter = "Acronym = '" + mAcronym + "'";
			}
			else
			{
				mDataView.RowFilter = "Acronym = '" + mAcronym + "' And RankID <> '" + mRankID + "'";
			}

			mDataView.RowStateFilter = DataViewRowState.OriginalRows;

			if(mDataView.Count > 0)
			{
				strErrorMessage = Error003;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_OrgID(string mOrgID)
		{
			if(mOrgID.Equals(""))
			{
				strErrorMessage = Error004;
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_ClassID(string mClassID)
		{
			if(mClassID.Equals(""))
			{
				strErrorMessage = Error005;
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}