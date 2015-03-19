using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Section" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	

	
	public class clsBLSection
	{
		clssection ObjDLSection = new clssection(); 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Section Name";
		private const string Error002 = "Section Name already exist";
		private const string Error003 = "Invalid Value of Status";
		private const string Error004 = "Invalid Value of Factory";
		private const string Error005 = "Invalid Value of Organization ID";
		private const string Error006 = "Invalid Value of Acronym";
		private const string Error007 = "Acronym already exist";


		public clsBLSection()
		{

		}

		public void chkconn()
		{
			OleDbConnection Conn;
			clsdbconnection clsco = new clsdbconnection();			
			Conn = clsco.OleDb_SQL_Connection;

		}
		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsInsert(string mFactoryID, string mSectionName, string mActive,
			string mOrgID, string mAcronym, string mContactPerson, string mCellNo, string mPhone1,
			string mPhone2, string mFax1, string mFax2, string mEMail1, 
			string mEMail2, string mBAddress, string mDescription)
		{		
			try
			{
/*				if (VD_FactoryType(mFactoryType)==false) 
				{						
					return false;
				};
*/
				if (VD_FactoryID(mFactoryID)==false) 
				{						
					return false;
				}

				if (VD_SectionName(mFactoryID, "", mSectionName)==false) 
				{						
					return false;
				}

				if (VD_Active(mActive)==false) 
				{						
					return false;
				}

				ObjDLSection.FactoryId =mFactoryID;
				ObjDLSection.SectionName =mSectionName; 
				ObjDLSection.Active=mActive; 		
				ObjDLSection.OrgID = mOrgID; 
				ObjDLSection.Acronym = mAcronym;
				ObjDLSection.ContactPerson = mContactPerson;
				ObjDLSection.CellNo = mCellNo;
				ObjDLSection.Phone1 = mPhone1;
				ObjDLSection.Phone2 = mPhone2;
				ObjDLSection.Fax2 = mFax2;
				ObjDLSection.Fax1 = mFax1;
				ObjDLSection.Fax2 = mFax2;
				ObjDLSection.EMail1 = mEMail1;
				ObjDLSection.EMail2 = mEMail2;
				ObjDLSection.BAddress = mBAddress;
				ObjDLSection.Description = mDescription;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLSection, clsoperation.Get_PKey.Yes);
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
		public bool rsUpdate(string mSectionID, string mFactoryID, string mSectionName, string mActive, 
			string mOrgID, string mAcronym, string mContactPerson, string mCellNo, string mPhone1, string mPhone2,
			string mFax1, string mFax2, string mEMail1, string mEMail2, string mBAddress, string mDescription)
		{
			try
			{		
/*				if (VD_FactoryType(mFactoryType)==false) 
				{						
					return false;
				};
*/
				if (VD_FactoryID(mFactoryID)==false) 
				{						
					return false;
				}

				if (VD_SectionName(mFactoryID, mSectionID, mSectionName)==false) 
				{						
					return false;
				}

				if (VD_Active(mActive)==false) 
				{						
					return false;
				}

				ObjDLSection.PKeycode=mSectionID; 
				ObjDLSection.FactoryId =mFactoryID;
				ObjDLSection.SectionName =mSectionName; 
				ObjDLSection.Active=mActive; 		
				ObjDLSection.OrgID = mOrgID; 
				ObjDLSection.Acronym = mAcronym;
				ObjDLSection.ContactPerson = mContactPerson;
				ObjDLSection.CellNo = mCellNo;
				ObjDLSection.Phone1 = mPhone1;
				ObjDLSection.Phone2 = mPhone2;
				ObjDLSection.Fax2 = mFax2;
				ObjDLSection.Fax1 = mFax1;
				ObjDLSection.Fax2 = mFax2;
				ObjDLSection.EMail1 = mEMail1;
				ObjDLSection.EMail2 = mEMail2;
				ObjDLSection.BAddress = mBAddress;
				ObjDLSection.Description = mDescription;

				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLSection);
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

		public bool rsDelete(string mSectionID)
		{
			try
			{
				ObjDLSection.PKeycode=mSectionID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLSection); 
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

		public DataView rsGetAll(string mFactoryID)
		{
			ObjDLSection.FactoryId = mFactoryID;
			return ObjTrans.DataTrigger_Get_All(ObjDLSection);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mSectionID)
		{
			ObjDLSection.PKeycode=mSectionID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLSection);
		}

		private bool VD_SectionName(string mFactoryID, string mSectionID, string mSectionName)
		{
			if (mSectionName=="") 
			{
				strErrorMessage=Error001;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mFactoryID);
			if (mSectionID=="")
			{mDataView.RowFilter ="FactoryID='" + mFactoryID + "' And SectionName='" + mSectionName + "'";}
			else
			{mDataView.RowFilter ="FactoryID='" + mFactoryID + "' And SectionName='" + mSectionName + "' And SectionID<>'" + mSectionID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count>0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}

		private bool VD_Acronym(string mFactoryID, string mSectionID,
			string mAcronym)
		{
			if (mAcronym=="") 
			{
				strErrorMessage=Error006;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mFactoryID);
			if (mSectionID=="")
			{mDataView.RowFilter ="FactoryID='" + mFactoryID + "' And Acronym='" + mAcronym + "'";}
			else
			{mDataView.RowFilter ="FactoryID='" + mFactoryID + "' And Acronym='" + mAcronym + "' And SectionID<>'" + mSectionID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count>0)
			{
				strErrorMessage=Error007;
				return false;}
			else
			{return true;}
		}

		private bool VD_Active(string mActive)
		{
			if (mActive!="Y" & mActive!="N") 
			{
				strErrorMessage=Error003; 
				return false;
			}
			else
			{return true;}
		}

		private bool VD_FactoryID(string mFactoryID)
		{
			clsBLFactory ObjBLFactory = new clsBLFactory();
			DataView mDataView = new DataView();
			mDataView=ObjBLFactory.rsGetSingle(mFactoryID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error004;
				return false;}
			else
			{return true;}
		}

	/*	private bool VD_FactoryType(string mFactoryType)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.FactoryType(); 
			{mDataView.RowFilter ="FactoryTypeCode='" + mFactoryType + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error005;
					return false;}
				else
				{return true;}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();
				return false;				
			}		
		}	*/

	}
}
