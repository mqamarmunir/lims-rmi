using System;
using System.Data;  
using System.Threading;
using System.Globalization;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Dependent" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLDependent
	{
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
		Validation objValid = new Validation();
		clsdependent ObjDLDependent = new clsdependent(); 		 
		clsoperation ObjTrans = new clsoperation(); 

		/* Error Message Constant*/

		private string strErrorMessage = "";
		private const string Error001 ="Invalid value Of Sex"; 
		private const string Error002 ="Invalid value Of Marital Status";
		private const string Error004 ="Invalid value Of Retirement Date";
		private const string Error005 ="Invalid value Of Date of Birth"; 
		//private const string Error006 = "Invalid value Of NIC ValidUpTo";
		private const string Error007 = "Invalid value Of Title";
		private const string Error008 = "Invalid value Of Blood Groups";
		private const string Error009 = "Invalid value Of Employee ID";
		private const string Error010 ="First Name is not entered";
		private const string Error011 ="Invalid Value Relation";
		private const string Error012 ="Father Name Already Defined";
		private const string Error013 ="Dependent Name Already Exist";
		private const string Error014 ="Invalid Relation";
		private const string Error015 = "NIC Number is Incorrect.";
		private const string Error016 = "NIC Number is already in used by another Person.";
		private const string Error017 = "NIC Number is not entered,while its validity date is entered.";
		private const string Error018 = "NIC valid Upto Date is Incorrect.";
		private const string Error019 = "NIC Validity Date is not entered.";
		private const string Error020 = "Invalid Dependent First Name";
		private const string Error021 = "Invalid Dependent Middle Name";
		private const string Error022 = "Invalid Dependent Last Name";
		private const string Error023 = "An Employee whose Marital Status is Single, his/her relation with Dependent is Invalid";

		
		public clsBLDependent()
		{
		}


		public string ErrorMessage
		{
			get
			{	return strErrorMessage;	}
		}


		public bool rsInsert(string mEmployeeID, string mRelation, string mTitle, string mDFName, string mDMName, string mDLName, string mSex, string mBG, string mDob, string mMS, string mNic, string mNicValidUpTo, string mPictureRef, string mSectionID, string mFactoryID, string mOrgID, string mRankID, string mRegisteredBy, string mPLNo)
		{		
			try
			{
				
				/*		if(false == Data_Validation( mDFName,  mDMName,  mDLName, mDob, mNic, mNicValidUpTo))
						{
							return false;
						}*/

				if (VD_Relation(mRelation)==false) 
				{						
					return false;
				}
				
				if (VD_DuplicateRelation(mEmployeeID, "", mRelation)==false) 
				{						
					return false;
				}
				
				if(!VD_Single(mEmployeeID, mRelation))
				{
					return false;
				}

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				}

				if (VD_DFName(mDFName)==false) 
				{						
					return false;
				}

				if(!mDMName.Equals(""))
				{
					if(!objValid.IsAlpha(mDMName))
					{
						strErrorMessage = Error021;
						return false;
					}
				}

				if(!mDLName.Equals(""))
				{
					if(!objValid.IsAlpha(mDLName))
					{
						strErrorMessage = Error022;
						return false;
					}
				}

				if (VD_DuplicateName("", mEmployeeID, mDFName, mDMName, mDLName)==false) 
				{						
					return false;
				}

				if (VD_Sex(mSex)==false) 
				{						
					return false;
				}

				if (mBG.Length>0)
				{
					if (VD_BloodGroups(mBG)==false) 
					{						
						return false;
					}
				}
	
				if(mDob.ToString() != "")
				{
					if(VD_Dob(mDob) == false) 
					{						
						return false;
					}
				}

				if(!mDob.Equals(""))
				{
					if(!VD_AgeDifference(mEmployeeID, mRelation, mDob))
					{
						return false;
					}
				}

				if (VD_MS(mMS)==false) 
				{						
					return false;
				}

				if (VD_EmployeeID(mEmployeeID)==false) 
				{						
					return false;
				}
				/*
								if(!mNic.Equals(""))
								{	*/
				if(!VD_NIC("", mNic, mNicValidUpTo))
				{
					return false;
				}	/*
				}
				else
				{
					if(!mNicValidUpTo.Equals(""))
					{
						strErrorMessage = Error018;
						return false;
					}
				}
*/
				clsBLEmployee objEmployee = new clsBLEmployee();
				clstpvregistration objTPVR = new clstpvregistration();

				DataView dvEmployee = objEmployee.rsGetSingle(mEmployeeID);

				if(dvEmployee.Table.Rows[0]["TempAddress"].ToString() != "")
				{
					objTPVR.ADDRESS = dvEmployee.Table.Rows[0]["TempAddress"].ToString();
				}
				else
				{
					objTPVR.ADDRESS = dvEmployee.Table.Rows[0]["PermentAddress"].ToString();
				}

				objTPVR.BLOODGROUP = mBG;
				objTPVR.CellPhone = dvEmployee.Table.Rows[0]["CPhone"].ToString();
				objTPVR.DOB = mDob;
				objTPVR.EMAIL = dvEmployee.Table.Rows[0]["Email"].ToString();
				
				if(dvEmployee.Table.Rows[0]["OPhone2"].ToString() != "")
				{
					objTPVR.Fax = dvEmployee.Table.Rows[0]["OPhone2"].ToString();
				}
				else
				{
					objTPVR.Fax = dvEmployee.Table.Rows[0]["OPhone1"].ToString();
				}

				objTPVR.LastVistNo = "";
				objTPVR.MS = mMS;
				objTPVR.NIC = mNic;
				objTPVR.PFNAME = mDFName;
				objTPVR.Phone1 = dvEmployee.Table.Rows[0]["HPhone1"].ToString();
				objTPVR.Phone2 = dvEmployee.Table.Rows[0]["HPhone2"].ToString();
				objTPVR.PictureReference = mPictureRef;
				objTPVR.PLNAME = mDLName;
				objTPVR.PMNAME = mDMName;
				objTPVR.PTYPE = "E" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM");
				objTPVR.RegisteredBy = mRegisteredBy;
				objTPVR.SEX = mSex;
				objTPVR.TITLE = mTitle;
				objTPVR.Relation = mRelation;

				ObjTrans.Start_Transaction();
				this.strErrorMessage = ObjTrans.DataTrigger_Insert(objTPVR, clsoperation.Get_PKey.Yes);

				if(!this.strErrorMessage.Equals("True"))
				{				
					ObjDLDependent.EMPLOYEEID = mEmployeeID;				
					ObjDLDependent.RELATION = mRelation;
					ObjDLDependent.TITLE = mTitle;
					ObjDLDependent.DFNAME = mDFName;
					ObjDLDependent.DMNAME = mDMName;
					ObjDLDependent.DLNAME = mDLName;
					ObjDLDependent.SEX = mSex;
					ObjDLDependent.BG = mBG;
					ObjDLDependent.DOB = mDob;
					ObjDLDependent.MS = mMS;
					ObjDLDependent.NIC = mNic;
					ObjDLDependent.NICVALIDUPTO = mNicValidUpTo;
					ObjDLDependent.PICTUREREF = mPictureRef;
					ObjDLDependent.SectionID = mSectionID;
					ObjDLDependent.FactoryID = mFactoryID;
					ObjDLDependent.OrgID = mOrgID;
					ObjDLDependent.RankID = mRankID;
					ObjDLDependent.PatientID = objTPVR.PKeycode;
					ObjDLDependent.PLNo = mPLNo;

					this.strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLDependent, clsoperation.Get_PKey.Yes);

					if(this.strErrorMessage.Equals("True"))
					{
						strErrorMessage = ObjTrans.OperationError;
						ObjTrans.End_Transaction();
						return false;
					}
				}
				else if(strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					ObjTrans.End_Transaction();
					return false;
				}

				ObjTrans.End_Transaction();
				
				strErrorMessage = "";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage = ex.Message.ToString();
				
				if(ObjTrans.DBTransaction != null)
				{
					ObjTrans.End_Transaction();
				}

				return false;
			}
		}


		private bool Data_Validation(string mDFName, string mDMName, string mDLName,string mDob, string mNic, 
			string mNicValidUpTo)
		{
			Validation objVal = new Validation();

			if(!objVal.IsAlpha(mDFName) && mDFName != "")			
			{
				
				strErrorMessage = "Invalid first name of dependent";
				return false;
			}
			if(!objVal.IsAlpha(mDMName) && mDMName != "")			
			{
				
				strErrorMessage = "Invalid middle name of dependent";
				return false;
			}
			if(!objVal.IsAlpha(mDLName) && mDLName != "")			
			{
				
				strErrorMessage = "Invalid last name of dependent";
				return false;
			}
			
			
			if(!objVal.IsDate(mDob) && mDob != "")
			{
				strErrorMessage = "Invalid format of birth date";
				return false;
			}
/*
			if(!objVal.IsNIC(mNic) && mNic != "")
			{
				strErrorMessage = "Invalid format of NIC no";
				return false;
			}
						
			if(!objVal.IsDate(mNicValidUpTo) && mNicValidUpTo != "")
			{
				strErrorMessage = "Invalid format of valid date";
				return false;
			}
*/
			return true;									
		}

		public bool rsUpdate(string mDependentID, string mEmployeeID, string mRelation, string mTitle, string mDFName, string mDMName, string mDLName, string mSex, string mBG, string mDob, string mMS, string mNic, string mNicValidUpTo, string mPictureRef, string mSectionID, string mFactoryID, string mOrgID, string mRankID)
		{		
			try
			{
				/*if(false == Data_Validation( mDFName,  mDMName,  mDLName, mDob, mNic, mNicValidUpTo))
				{
					return false;
				}*/

				if (VD_Relation(mRelation)==false) 
				{						
					return false;
				};

/*				if (VD_DuplicateRelation(mEmployeeID, mDependentID, mRelation)==false) 
				{						
					return false;
				};
*/
				if(!VD_Single(mEmployeeID, mRelation))
				{
					return false;
				}

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				};


				if (VD_DFName(mDFName)==false) 
				{						
					return false;
				};

				if(!mDMName.Equals(""))
				{
					if(!objValid.IsAlpha(mDMName))
					{
						strErrorMessage = Error021;
						return false;
					}
				}

				if(!mDLName.Equals(""))
				{
					if(!objValid.IsAlpha(mDLName))
					{
						strErrorMessage = Error022;
						return false;
					}
				}

				if (VD_DuplicateName(mDependentID, mEmployeeID, mDFName, mDMName, mDLName)==false) 
				{						
					return false;
				};

				if (VD_Sex(mSex)==false) 
				{						
					return false;
				};

				if (mBG.Length>0)
				{
					if (VD_BloodGroups(mBG)==false) 
					{						
						return false;
					};
				};
	
				if (mDob.Length>0)
				{ 
					if (VD_Dob(mDob)==false) 
					{						
						return false;
					};			
				};

				if(!mDob.Equals(""))
				{
					if(!VD_AgeDifference(mEmployeeID, mRelation, mDob))
					{
						return false;
					}
				}
				
				if (VD_MS(mMS)==false) 
				{						
					return false;
				};

				if (VD_EmployeeID(mEmployeeID)==false) 
				{						
					return false;
				};
				/*
								if(!mNic.Equals(""))
								{	*/
				if(!VD_NIC(mDependentID, mNic, mNicValidUpTo))
				{
					return false;
				}	/*
				}
				else
				{
					if(!mNicValidUpTo.Equals(""))
					{
						strErrorMessage = Error018;
						return false;
					}
				}
*/
				ObjDLDependent.PKeycode = mDependentID; 
				ObjDLDependent.EMPLOYEEID = mEmployeeID;				
				ObjDLDependent.RELATION = mRelation;
				ObjDLDependent.TITLE = mTitle;
				ObjDLDependent.DFNAME = mDFName;
				ObjDLDependent.DMNAME = mDMName;
				ObjDLDependent.DLNAME = mDLName;
				ObjDLDependent.SEX = mSex;
				ObjDLDependent.BG = mBG;
				ObjDLDependent.DOB = mDob;
				ObjDLDependent.MS = mMS;
				ObjDLDependent.NIC = mNic;
				ObjDLDependent.NICVALIDUPTO = mNicValidUpTo;
				ObjDLDependent.PICTUREREF = mPictureRef;
				ObjDLDependent.SectionID = mSectionID;
				ObjDLDependent.FactoryID = mFactoryID;
				ObjDLDependent.OrgID = mOrgID;
				ObjDLDependent.RankID = mRankID;
				
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLDependent);

				if(!this.strErrorMessage.Equals("True"))
				{
					clsdependent objDependent = new clsdependent();
					clsoperation objTrans2 = new clsoperation();
					clsBLTPVRegistration objTPVRegistration = new clsBLTPVRegistration();
					clstpvregistration objTPVR = new clstpvregistration(); 

					objDependent.PKeycode = mDependentID;
					DataView dvDependent = objTrans2.DataTrigger_Get_Single(objDependent);
					DataView dvTPVReg = objTPVRegistration.rsGetSingle(dvDependent.Table.Rows[0]["PatientID"].ToString());

					objTPVR.PKeycode = dvTPVReg.Table.Rows[0]["PatientID"].ToString();
					objTPVR.TITLE = mTitle;
					objTPVR.PFNAME = mDFName;
					objTPVR.PMNAME = mDMName;
					objTPVR.PLNAME = mDLName;
					objTPVR.SEX = mSex;
					objTPVR.DOB = mDob;
					objTPVR.BLOODGROUP = mBG;
					objTPVR.MS = mMS;
					objTPVR.NIC = mNic;
					objTPVR.PictureReference = dvTPVReg.Table.Rows[0]["PictureRef"].ToString();
					objTPVR.ADDRESS = dvTPVReg.Table.Rows[0]["Address"].ToString();
					objTPVR.CellPhone = dvTPVReg.Table.Rows[0]["CellPhone"].ToString();
					objTPVR.Phone1 = dvTPVReg.Table.Rows[0]["Phone1"].ToString();
					objTPVR.Phone2 = dvTPVReg.Table.Rows[0]["Phone2"].ToString();
					objTPVR.Fax = dvTPVReg.Table.Rows[0]["Fax"].ToString();
					objTPVR.EMAIL = dvTPVReg.Table.Rows[0]["Email"].ToString();
					objTPVR.LastVistNo = dvTPVReg.Table.Rows[0]["LastVisitNo"].ToString();
					objTPVR.Relation = mRelation;

					this.strErrorMessage = ObjTrans.DataTrigger_Update(objTPVR);

					if(this.strErrorMessage.Equals("True"))
					{
						this.strErrorMessage = ObjTrans.OperationError;
						ObjTrans.End_Transaction();
						return false;
					}
				}
				else
				{
					strErrorMessage = ObjTrans.OperationError;
					ObjTrans.End_Transaction();
					return false;
				}

				ObjTrans.End_Transaction();

				strErrorMessage = "";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage = ex.Message;
				return false;
			}
		}

		public bool rsDelete(string mDependentID)
		{
			try
			{
				ObjDLDependent.PKeycode=mDependentID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLDependent); 
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


		public DataView rsGetAll(string mEmployeeID, string mRelation, string mDependentName, string mSex, string mBG, string mMS, string mNic, string mPatientID, string mSectionID, string mFactoryID, string mOrgID, string mRankID, string mPLNo, string mAddress, string mEmail, string mHPhone, string mOPhone, string mCPhone, string mWelfareContNo, string mDOBDay, string mDOBMonth, string mDOBYear, string mFHName, string mGatePassNo)
		{
			ObjDLDependent.EMPLOYEEID = mEmployeeID;
			ObjDLDependent.RELATION = mRelation;
			ObjDLDependent.DependentName = mDependentName;
			ObjDLDependent.SEX = mSex;
			ObjDLDependent.BG = mBG;
			ObjDLDependent.MS = mMS;
			ObjDLDependent.NIC = mNic;
			ObjDLDependent.PatientID = mPatientID;
			ObjDLDependent.SectionID = mSectionID;
			ObjDLDependent.FactoryID = mFactoryID;
			ObjDLDependent.OrgID = mOrgID;
			ObjDLDependent.RankID = mRankID;
			ObjDLDependent.PLNo = mPLNo;
			ObjDLDependent.Address = mAddress;
			ObjDLDependent.Email = mEmail;
			ObjDLDependent.HPhone = mHPhone;
			ObjDLDependent.OPhone = mOPhone;
			ObjDLDependent.CPhone = mCPhone;
			ObjDLDependent.WelfareContNo = mWelfareContNo;
			ObjDLDependent.DOBDay = mDOBDay;
			ObjDLDependent.DOBMonth = mDOBMonth;
			ObjDLDependent.DOBYear = mDOBYear;
			ObjDLDependent.FHName = mFHName;
			ObjDLDependent.GatePassNo = mGatePassNo;

			return ObjTrans.DataTrigger_Get_All(ObjDLDependent);
		}


		public DataView rsGetAll(string mEmployeeID)
		{
			DataView mDataView = new DataView();			 
			mDataView=rsGetAll(mEmployeeID, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "");
			return mDataView; 
		}

		public DataView rsGetAll(string mEmployeeID, bool ShowSelf)
		{
			DataView mDataView = new DataView();			 
			mDataView=rsGetAll(mEmployeeID);
			if (ShowSelf==false) 
			{mDataView.RowFilter ="Relation<>'Self'";}
			else
			{mDataView.RowFilter ="";};

			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			return mDataView; 
		}


		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mDependentID)
		{
			ObjDLDependent.PKeycode=mDependentID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLDependent);
		}

		public DataView rsGetSingle(string mEmployeeID, string mDependentID)
		{
			DataView mDataView = new DataView();
			ObjDLDependent.PKeycode=mDependentID; 
			mDataView=ObjTrans.DataTrigger_Get_Single(ObjDLDependent);
		{mDataView.RowFilter ="EmployeeID='" + mEmployeeID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			return mDataView; 
		}


		private bool VD_Sex(string mSex)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.SexTypes(); 
			{mDataView.RowFilter ="SexCode='" + mSex + "'";}
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
		private bool VD_MS(string mMS)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.MaritalStatus(); 
			{mDataView.RowFilter ="MaritalCode='" + mMS + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error009;
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


		private bool VD_RtDate(string mRtDate)
		{
			try
			{
				System.DateTime.Parse(mRtDate);
				return true;
			}  
			catch(Exception)
			{
				strErrorMessage=Error004; 
				return false;				
			}		
		}

		private bool VD_Dob(string mDob)
		{
			if(!objValid.IsDate(mDob))
			{
				strErrorMessage = Error005;
				return false;
			}
			else
			{
				return true;
			}
		}

		/// <summary>
		/// Validation Method for National Identity Card Number
		/// </summary>
		/// <param name="mEmployeeID">Dependent ID to distinguish b/w Insert & Update (string, 6)</param>
		/// <param name="mNIC">National Identity Card Number (string, 20)</param>
		/// <param name="mNICVUpto">National Identity Card Validity Date (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_NIC(string mDependentID, string mNIC, string mNICVUpto)
		{
			/*
			if(objValid.IsNIC(mNIC))
			{
				DataView dvNIC = rsGetAll("","","", "", "", mNIC, "", "", "", "", "", "", "", "", "", "", "", "");
				if(!mEmployeeID.Equals(""))
				{
				{dvNIC.RowFilter = "EmployeeID<>'"+mEmployeeID+"'";}
					dvNIC.RowStateFilter = DataViewRowState.OriginalRows;
				}
				if(dvNIC.Count > 0)
				{
					strErrorMessage = Error017;
					return false;
				}	*/

			if(!mNICVUpto.Equals(""))
			{
				if(VD_IsDate(mNICVUpto))
				{
					return true;
				}
				else
				{
					strErrorMessage = Error018;
					return false;
				}
			}	/*
				else
				{
					strErrorMessage = Error020;
					return false;
				}	
			}
			else
			{
				strErrorMessage = Error016;
				return false;
			}	*/

			return true;
		}

		
		private bool VD_Title(string mTitle)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.Titles();
			{mDataView.RowFilter ="Titles='" + mTitle + "'";}
				//mDataView.RowStateFilter = DataViewRowState.OriginalRows;
				if (mDataView.Count==0)
				{
					strErrorMessage=Error007;
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

		private bool VD_BloodGroups(string mBloodGroups)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.BloodGroups(); 
			{mDataView.RowFilter ="BloodGroups='" + mBloodGroups + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error008;
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

		private bool VD_EmployeeID(string mEmployeeID)
		{
			clsBLEmployee ObjBLEmployee = new clsBLEmployee();
			DataView mDataView = new DataView();
			mDataView=ObjBLEmployee.rsGetSingle(mEmployeeID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error009;
				return false;}
			else
			{return true;}
		}

		private bool VD_DFName(string mDFName)
		{
			if (mDFName=="") 
			{
				strErrorMessage=Error010;
				return false;
			}
			else if(!objValid.IsAlpha(mDFName))
			{
				strErrorMessage = Error020;
				return false;
			}
			return true;
		}

		private bool VD_Relation(string mRelation)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.Relations(); 
			{mDataView.RowFilter ="Relation='" + mRelation + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error011;
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
		
		private bool VD_DuplicateRelation(string mEmployeeID, string mDependentID, string mRelation)
		{
			try
			{
				DataView mDataView = new DataView();
				clsBLDependent ObjDependent = new clsBLDependent(); 
				mDataView=ObjDependent.rsGetAll(mEmployeeID, mRelation, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); 
				if (mDependentID!="")
				{
					mDataView.RowFilter ="DependentID='" + mDependentID + "'";
				}

				if (mRelation=="F/O") 
				{
					if (mDataView.Count>0)
					{
						strErrorMessage=Error012;
						return false;
					}
					else
					{return true;
					}
				}
				if (mRelation=="H/O") 
				{
					mDataView.Table.Clear();
					clsBLEmployee ObjEmployee = new clsBLEmployee(); 
					mDataView=ObjEmployee.rsGetSingle(mEmployeeID); 				
					string mSex=mDataView[0].Row["Sex"].ToString();
					if (mSex=="M")
					{
						strErrorMessage=Error014;
						return false;
					}
					else
					{
						return true;
					}
				}

				if (mRelation=="W/O") 
				{
					mDataView.Table.Clear();
					clsBLEmployee ObjEmployee = new clsBLEmployee(); 
					mDataView=ObjEmployee.rsGetSingle(mEmployeeID); 				
					string mSex=mDataView[0].Row["Sex"].ToString();
					if (mSex=="F")
					{
						strErrorMessage=Error014;
						return false;
					}
					else
					{
						return true;
					}
				}				
				else
				{return true;}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();
				return false;				
			}		
		}

		private bool VD_Single(string empID, string depRelation)
		{			
			clsBLEmployee objEmp = new clsBLEmployee();
			DataView dvEmp = objEmp.rsGetSingle(empID);
			if(dvEmp[0].Row["MS"].ToString().Equals("S"))
			{
				if(depRelation.Equals("H/O") || depRelation.Equals("W/O") || depRelation.Equals("S/O") || depRelation.Equals("D/O"))
				{
					strErrorMessage = Error023;
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}

		private bool VD_DuplicateName(string mDependentID, string mEmployeeID, string mFName, 
			string mMName, string mLName )
		{
			try
			{
				//System.String.t 
				DataView mDataView = new DataView();
				string mDependentName = mFName.Trim()  + " " + mMName.Trim()  + " "+ mLName.Trim();
				clsBLDependent ObjDependent = new clsBLDependent(); 
				mDataView=ObjDependent.rsGetAll(mEmployeeID, "", mDependentName, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""); 
				if (mDependentID!="")
				{
					mDataView.RowFilter ="DependentID<>'" + mDependentID + "'";
				}

				if (mDataView.Count>0)
				{
					strErrorMessage=Error013;
					return false;}
				else
				{
					return true;}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();
				return false;				
			}		
		}


		/// <summary>
		/// Validation Method for validating Date
		/// </summary>
		/// <param name="mDate">Date Input (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_IsDate(string mDate)
		{
			return objValid.IsDate(mDate);
		}


		private bool VD_AgeDifference(string empID, string relation, string depDOB)
		{
			clsBLEmployee objEmp = new clsBLEmployee();
			string empDOB = "";
			
			DataView dvEmp = objEmp.rsGetSingle(empID);
			
			try
			{
				empDOB = dvEmp[0].Row["DOB"].ToString();
			}
			catch{	empDOB = "";	}

			if(!empDOB.Equals(""))
			{
				DateTime dtEmpDOB =  new DateTime(int.Parse(empDOB.Substring(6, 4)), int.Parse(empDOB.Substring(3, 2)), int.Parse(empDOB.Substring(0, 2)));
				DateTime dtDepDOB = new DateTime(int.Parse(depDOB.Substring(6, 4)), int.Parse(depDOB.Substring(3, 2)), int.Parse(depDOB.Substring(0, 2)));
				bool check = (dtEmpDOB < dtDepDOB) ? true : false;
				
				if(relation.Equals("F/O") && check == true)
				{
					this.strErrorMessage = "Father Age is Less than the Employee Age";
					return false;
				}
				else if(relation.Equals("M/O") && check == true)
				{
					this.strErrorMessage = "Mother Age is Less than the Employee Age";
					return false;
				}
				else if(relation.Equals("D/O") && check == false)
				{
					this.strErrorMessage = "Daughter Age is Greater than the Employee Age";
					return false;
				}
				else if(relation.Equals("S/O") && check == false)
				{
					this.strErrorMessage = "Son Age is Greater than the Employee Age";
					return false;
				}
				else if(dtEmpDOB == dtDepDOB && !relation.Equals("W/O"))
				{
					this.strErrorMessage = "Employee And Dependent Ages are Same";
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return true;
			}
		}
	}
}