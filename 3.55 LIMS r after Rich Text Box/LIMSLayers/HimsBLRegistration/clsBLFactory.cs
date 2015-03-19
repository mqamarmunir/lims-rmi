using System;
using System.Data;  
using HimsDlRegistration;


namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Factory" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	
	public class clsBLFactory
	{
		clsfactory ObjDLFactory = new clsfactory();  
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";

		private const string Error001 = "Invalid Value of Organization Type.";
		private const string Error002 = "Invalid Value of Organization Name.";
		private const string Error003 = "Organization Name Already Exist.";
		private const string Error004 = "Invalid Value of Active.";		
		private const string Error005 = "Invalid Value of Billing.";
		private const string Error006 = "Invalid Organization ID.";
		private const string Error007 = "Invalid Value of Acronym.";
		private const string Error008 = "Acronym Already Exist.";


		public clsBLFactory()
		{
		}
		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsInsert(string mActive, string mFactoryName, string mAcronym,
			string mContactPerson, string mCellNo, string mPhone1, string mPhone2, 
			string mFax1, string mFax2, string mEmail1, string mEmail2, 
			string mPAddress, string mBAddress, string mDescription,
			string mOrgID, string mBill)
		{
		
			try
			{
/*
				if (VD_FactoryType(mOrgID)==false) 
				{						
					return false;
				};
*/
				if (VD_FactoryName("", mFactoryName)==false) 
				{						
					return false;
				};

				if (VD_Acronym("", mAcronym)==false) 
				{						
					return false;
				};

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};


				ObjDLFactory.Active=mActive; 
				ObjDLFactory.Factoryname=mFactoryName; 
				ObjDLFactory.Acronym=mAcronym; 
				ObjDLFactory.ContactPerson=mContactPerson; 
				ObjDLFactory.CellNo=mCellNo; 
				ObjDLFactory.Phone1=mPhone1; 
				ObjDLFactory.Phone2=mPhone2; 
				ObjDLFactory.Fax1=mFax1; 
				ObjDLFactory.Fax2=mFax2; 
				ObjDLFactory.Email1=mEmail1; 
				ObjDLFactory.Email2=mEmail2; 
				ObjDLFactory.PAddress=mPAddress; 
				ObjDLFactory.BAddress=mBAddress; 
				ObjDLFactory.Description=mDescription; 
				ObjDLFactory.OrgID = mOrgID; 
				ObjDLFactory.Bill =	mBill;
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLFactory, clsoperation.Get_PKey.Yes);
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

		public bool rsUpdate(string mFactoryID, string mActive, string mFactoryName, 
			string mAcronym, string mContactPerson, string mCellNo, string mPhone1, 
			string mPhone2, string mFax1, string mFax2, string mEmail1, string mEmail2, 
			string mPAddress, string mBAddress, string mDescription,
			string mOrgID, string mBill)
		{
			try
			{		
/*
				if (VD_FactoryType(mFactoryType)==false) 
				{						
					return false;
				};
*/
				if (VD_FactoryName(mFactoryID, mFactoryName)==false) 
				{						
					return false;
				};

				if (VD_Acronym(mFactoryID, mAcronym)==false) 
				{						
					return false;
				};


				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				ObjDLFactory.PKeycode=mFactoryID; 
				ObjDLFactory.Active=mActive; 
				ObjDLFactory.Factoryname=mFactoryName; 
				ObjDLFactory.Acronym=mAcronym; 
				ObjDLFactory.ContactPerson=mContactPerson; 
				ObjDLFactory.CellNo=mCellNo; 
				ObjDLFactory.Phone1=mPhone1; 
				ObjDLFactory.Phone2=mPhone2; 
				ObjDLFactory.Fax1=mFax1; 
				ObjDLFactory.Fax2=mFax2; 
				ObjDLFactory.Email1=mEmail1; 
				ObjDLFactory.Email2=mEmail2; 
				ObjDLFactory.PAddress=mPAddress; 
				ObjDLFactory.BAddress=mBAddress; 
				ObjDLFactory.Description=mDescription; 
				ObjDLFactory.OrgID = mOrgID; 
				ObjDLFactory.Bill =	mBill;
				ObjTrans.Start_Transaction(); 
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLFactory);
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

		public bool rsDelete(string mFactoryID)
		{
			try
			{
				ObjDLFactory.PKeycode=mFactoryID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLFactory); 
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

		public DataView rsGetAll(string mActive, string mFactoryName, 
			string mAcronym, string mContactPerson, string mCellNo, string mPhone, 
			string mFax, string mEmail, string mPAddress, string mBAddress,
			string mDescription, string mOrgID, string mBill)
		{
			ObjDLFactory.Active=mActive; 
			ObjDLFactory.Factoryname=mFactoryName; 
			ObjDLFactory.Acronym=mAcronym; 
			ObjDLFactory.ContactPerson=mContactPerson; 
			ObjDLFactory.CellNo=mCellNo; 
			ObjDLFactory.Phone=mPhone; 
			ObjDLFactory.Fax=mFax; 
			ObjDLFactory.Email=mEmail; 
			ObjDLFactory.PAddress=mPAddress; 
			ObjDLFactory.BAddress=mBAddress; 
			ObjDLFactory.Description=mDescription; 
			ObjDLFactory.OrgID = mOrgID; 
			ObjDLFactory.Bill =	mBill;
			return ObjTrans.DataTrigger_Get_All(ObjDLFactory);
		}

		/// <summary>
		///		Display Record Only Specific factory Type- Return type DataView
		/// </summary>

		public DataView rsGetAll(string mOrgID)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetAll("", "", "", "", "", "", "", "", "", "", "", mOrgID, "");
			{mDataView.RowFilter ="OrgID='" + mOrgID+ "'";}
			return mDataView;
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mFactoryID)
		{
			ObjDLFactory.PKeycode=mFactoryID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLFactory);
		}

		private bool VD_FactoryID(string mFactoryID)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetSingle(mFactoryID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error006;
				return false;}
			else
			{return true;}
		}

		private bool VD_FactoryName(string mFactoryID,  string mFactoryName)
		{
			if (mFactoryName=="") 
			{
			strErrorMessage=Error002;
				return false;
			};

			DataView mDataView = new DataView();			
			//mDataView=rsGetAll("", mFactoryName, "", "", "", "", "", "", "");
			mDataView=rsGetAll("", mFactoryName, "", "", "", "", "", "", "", "", "", "", "");

			if (mFactoryID!="")
				{
				mDataView.RowFilter ="FactoryID<>'" + mFactoryID + "'";
				mDataView.RowStateFilter = DataViewRowState.OriginalRows;
				};
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

/*		private bool VD_FactoryType(string mFactoryType)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.FactoryType(); 
				{mDataView.RowFilter ="FactoryTypeCode='" + mFactoryType + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error001;
					return false;}
				else
				{return true;}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();
				return false;				
			}		
		}
*/
		private bool VD_Acronym(string mFactoryID,  string mAcronym)
		{
			if (mAcronym=="") 
			{
				strErrorMessage=Error006;
				return false;
			};

			DataView mDataView = new DataView();			
			mDataView=rsGetAll("", "", mAcronym, "", "", "", "", "", "", "", "", "", "");

			if (mFactoryID!="")
			{
				mDataView.RowFilter ="FactoryID<>'" + mFactoryID + "'";
				mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			};

			if (mDataView.Count>0)
			{
				strErrorMessage=Error007;
				return false;}
			else
			{return true;}
		}


		private bool VD_Bill(string mBill)
		{
			if (mBill!="Y" & mBill!="N") 
			{
				strErrorMessage=Error005; 
				return false;
			}
			else
			{return true;}
		}


	}
}
