using System;
using System.Data;  
using HimsDlRegistration;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;


namespace HimsBLRegistration
{
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Employee" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	///  
	

	public class clsBLEmployee
	{
		clsemployee ObjDLEmployee = new clsemployee(); 
		Validation objValid = new Validation();
		clsoperation ObjTrans = new clsoperation(); 

		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");

		private string strErrorMessage = "";
		private string strEmployeeID = "";

		# region "Error Messages"

		private const string Error001 = "Invalid value of Organization Type";
		private const string Error002 = "Invalid value Of Organization";
		private const string Error003 = "Invalid value Of Section ID";
		private const string Error004 = "Invalid value of PL #";
		private const string Error005 = "Pl # already Exist";
		private const string Error006 ="Invalid value Of Status"; 
		private const string Error007 = "Invalid value Of Title";
		private const string Error008 ="First Name is not entered";
		private const string Error009 = "Invalid value of Rank";
		private const string Error010 ="Invalid value of Sex";
		private const string Error011 = "Invalid value Of Blood Group";
		private const string Error012 = "Invalid value Of Date of Joining";
		private const string Error013 = "Invalid value Of Date of Birth"; 
		private const string Error014 ="Invalid value Of Marital Status";
		//private const string Error015 = "NIC # already Exist";
		private const string Error016 = "NIC Number is Incorrect.";
		private const string Error017 = "NIC Number is already in used by another Person.";
		private const string Error018 = "NIC Number is not entered,while its validity date is entered.";
		private const string Error019 = "NIC valid Upto Date is Incorrect.";
		private const string Error020 = "NIC Validity Date is not entered.";
		private const string Error021 = "PLNo is Incorrect";
		private const string Error022 = "Email Address is Incorrect.";
		private const string Error023 = "Invalid First Name";
		private const string Error024 = "Invalid Middle Name";
		private const string Error025 = "Invalid Last Name";
		private const string Error026 = "Invalid Father/Husband Name";
		private const string Error027 = "A Male Person may not be a Widow";

		# endregion

		public clsBLEmployee()
		{			
		}

		#region "Properties"

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public string EmployeeID
		{
			get
			{
				return strEmployeeID;
			}
		}

		#endregion

		public bool rsInsert(string mPlNo, string mTitle, string mEFName, string mEMName, string mELName, string mActive, string mPictureRef, string mFactoryID, string mSex, string mBG, string mDob, string mMS, string mNic, string mNicValidUpTo, string mHPhone1, string mHPhone2, string mOPhone1, string mOPhone2, string mCPhone, string mEmail, string mTempAddress, string mPermentAddress, string mWelfareContNo, string mOrgID, string mRankID, string mSectionID, string mFHName, string mRegisteredBy, string mServiceType, string mDOJ, string mBPS, string mGatePassNo)
		{		
			try
			{
				if(!VD_FactoryID(mFactoryID)) 
				{						
					return false;
				}

				if(!VD_SectionID(mFactoryID, mSectionID)) 
				{						
					return false;
				}

				if(!VD_PLNo("", mPlNo, mOrgID)) 
				{						
					return false;
				}

				if(!VD_Active(mActive)) 
				{						
					return false;
				}

				if(!VD_Title(mTitle)) 
				{						
					return false;
				}

				if(!VD_EFName(mEFName)) 
				{						
					return false;
				}
				
				if(!mEMName.Equals(""))
				{
					if(!objValid.IsAlpha(mEMName))
					{
						strErrorMessage = Error024;
						return false;
					}
				}

				if(!mELName.Equals(""))
				{
					if(!objValid.IsAlpha(mELName))
					{
						strErrorMessage = Error025;
						return false;
					}
				}

				if(!mFHName.Equals(""))
				{
					if(!objValid.IsName(mFHName))
					{
						strErrorMessage = Error026;
                        return false;
					}
				}

				if(!VD_RankID(mOrgID, mRankID)) 
				{						
					return false;
				}

				if(mRankID == "-1")
					mRankID = "";

				if(!VD_Sex(mSex)) 
				{						
					return false;
				}

				if(mBG.Length > 0)
				{
					if (!VD_BloodGroups(mBG)) 
					{						
						return false;
					}
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
				if(!mDob.Equals(""))
				{ 
					if(!VD_Dob(mDob))
					{						
						strErrorMessage = Error013;
						return false;
					}	
				}

				if(!mDOJ.Equals(""))
				{ 
					if(!VD_Dob(mDOJ))
					{						
						strErrorMessage = Error012;
						return false;
					}	
				}

				if(!VD_MS(mMS, mTitle)) 
				{						
					return false;
				}

				if(!mEmail.Equals(""))
				{
					if(!VD_Email(mEmail))
					{
						strErrorMessage = Error022;
						return false;
					}
				}

				strEmployeeID="";
				ObjDLEmployee.PLNO = mPlNo;				
				ObjDLEmployee.TITLE  = mTitle;
				ObjDLEmployee.EFNAME = mEFName;
				ObjDLEmployee.EMNAME  = mEMName;
				ObjDLEmployee.ELNAME = mELName;
				ObjDLEmployee.ACTIVE  = mActive;
				ObjDLEmployee.PICTUREREF = mPictureRef;
				ObjDLEmployee.FACTORYID = mFactoryID;				
				ObjDLEmployee.SEX = mSex;
				ObjDLEmployee.BG = mBG;
				ObjDLEmployee.DOB = mDob;
				ObjDLEmployee.MS = mMS;
				ObjDLEmployee.NIC = mNic;
				ObjDLEmployee.NICVALIDUPTO = mNicValidUpTo;
				ObjDLEmployee.HPHONE1 = mHPhone1;
				ObjDLEmployee.HPHONE2 = mHPhone2;
				ObjDLEmployee.OPHONE1  = mOPhone1;
				ObjDLEmployee.OPHONE2 = mOPhone2;
				ObjDLEmployee.CPHONE = mCPhone;
				ObjDLEmployee.EMAIL = mEmail;
				ObjDLEmployee.TEMPADDRESS = mTempAddress;
				ObjDLEmployee.PERMENTADDRESS = mPermentAddress;
				ObjDLEmployee.WELFARECONTNO = mWelfareContNo; 
				ObjDLEmployee.ORGID = mOrgID; 
				ObjDLEmployee.RANKID = mRankID;
				ObjDLEmployee.SECTIONID = mSectionID;
				ObjDLEmployee.FHName = mFHName;
				ObjDLEmployee.ServiceType = mServiceType;
				ObjDLEmployee.DOJ = mDOJ;
				ObjDLEmployee.BPS = mBPS;
				ObjDLEmployee.GatePassNo = mGatePassNo;

				ObjTrans.Start_Transaction();

				if(mPlNo.Trim().Equals(""))
				{
					clsBLOrganizations objOrg = new clsBLOrganizations();
					ObjDLEmployee.PLNO = ObjDLEmployee.GetMax_PLNo(ObjTrans.GetConnection, ObjTrans.DBTransaction, objOrg.rsGetAcronym(mOrgID));
				}

				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLEmployee, clsoperation.Get_PKey.Yes);

				if(!this.strErrorMessage.Equals("True"))
				{
					strEmployeeID = ObjDLEmployee.PKeycode;

					clstpvregistration objPVR = new clstpvregistration();
					
					objPVR.ADDRESS = mPermentAddress;
					objPVR.BLOODGROUP = mBG;
					objPVR.CellPhone= mCPhone;
					objPVR.DOB = mDob;
					objPVR.EMAIL = mEmail;
					objPVR.Fax = mOPhone2;
					objPVR.LastVistNo = "";
					objPVR.MS = mMS;
					objPVR.NIC = mNic;
					objPVR.PFNAME = mEFName;
					objPVR.Phone1 = mHPhone1;
					
					if(!mHPhone2.Equals(""))
					{
						objPVR.Phone2 = mHPhone2;
					}
					else if(!mOPhone1.Equals(""))
					{
						objPVR.Phone2 = mOPhone1;
					}
					else
					{
						objPVR.Phone2 = mOPhone2;
					}

					objPVR.PictureReference = mPictureRef;
					objPVR.PLNAME = mELName;
					objPVR.PMNAME = mEMName;
					objPVR.PTYPE = "E" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM");
					objPVR.RegisteredBy = mRegisteredBy;
					objPVR.SEX = mSex;
					objPVR.TITLE = mTitle;
					objPVR.Relation = "Self";
                    
					this.strErrorMessage = ObjTrans.DataTrigger_Insert(objPVR, clsoperation.Get_PKey.Yes);

					if(!this.strErrorMessage.Equals("True"))
					{
						clsdependent objDependent = new clsdependent();

						objDependent.BG = mBG;
						objDependent.DFNAME = mEFName;
						objDependent.DLNAME = mELName;
						objDependent.DMNAME = mEMName;
						objDependent.DOB = mDob;
						objDependent.EMPLOYEEID = strEmployeeID;
						objDependent.FactoryID = mFactoryID;
						objDependent.MS = mMS;
						objDependent.NIC = mNic;
						objDependent.NICVALIDUPTO = mNicValidUpTo;
						objDependent.OrgID = mOrgID;
						objDependent.PatientID = objPVR.PKeycode;
						objDependent.PICTUREREF = mPictureRef;
						objDependent.RankID = mRankID;
						objDependent.RELATION = "Self";
						objDependent.SectionID = mSectionID;
						objDependent.SEX = mSex;
						objDependent.TITLE = mTitle;
						objDependent.PLNo = ObjDLEmployee.PLNO;

						this.strErrorMessage = ObjTrans.DataTrigger_Insert(objDependent,clsoperation.Get_PKey.No);

						if(this.strErrorMessage.Equals("True"))
						{
							strErrorMessage = ObjTrans.OperationError;
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


		public bool rsUpdate(string mEmployeeID, string mPlNo, string mTitle, string mEFName, string mEMName, string mELName, string mActive, string mPictureRef, string mFactoryID, string mSex, string mBG, string mDob, string mMS, string mNic, string mNicValidUpTo, string mHPhone1, string mHPhone2, string mOPhone1, string mOPhone2, string mCPhone, string mEmail, string mTempAddress, string mPermentAddress, string mWelfareContNo, string mOrgID, string mRankID, string mSectionID, string mFHName, string mServiceType, string mDOJ, string mBPS, string mGatePassNo)
		{		
			try
			{
				if(VD_FactoryID(mFactoryID) == false) 
				{						
					return false;
				}

				if(VD_SectionID(mFactoryID, mSectionID) == false) 
				{						
					return false;
				}
				
				if(VD_PLNo(mEmployeeID, mPlNo, mOrgID) == false) 
				{						
					return false;
				}

				if(VD_Active(mActive) == false) 
				{						
					return false;
				}

				if(VD_Title(mTitle) == false) 
				{						
					return false;
				}

				if(VD_EFName(mEFName) == false) 
				{						
					return false;
				}

				if(!mEMName.Equals(""))
				{
					if(!objValid.IsAlpha(mEMName))
					{
						strErrorMessage = Error024;
						return false;
					}
				}

				if(!mELName.Equals(""))
				{
					if(!objValid.IsAlpha(mELName))
					{
						strErrorMessage = Error025;
						return false;
					}
				}

				if(!mFHName.Equals(""))
				{
					if(!objValid.IsName(mFHName))
					{
						strErrorMessage = Error026;
						return false;
					}
				}

				if(VD_RankID(mOrgID, mRankID) == false) 
				{						
					return false;
				}

				if(VD_Sex(mSex) == false) 
				{						
					return false;
				}

				if(mBG.Length > 0)
				{
					if(VD_BloodGroups(mBG) == false) 
					{						
						return false;
					}
				}
/*
				if(!mNic.Equals(""))
				{	*/
					if(!VD_NIC(mEmployeeID, mNic, mNicValidUpTo))
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
				if(mDob.Length > 0)
				{ 
					if(!VD_Dob(mDob))
					{						
						strErrorMessage = Error013;
						return false;
					}			
				}

				if(mDOJ.Length > 0)
				{ 
					if(!VD_Dob(mDOJ))
					{						
						strErrorMessage = Error012;
						return false;
					}			
				}

				if(VD_MS(mMS, mTitle) == false) 
				{						
					return false;
				}

				if(!mEmail.Equals(""))
				{
					if(!VD_Email(mEmail))
					{
						strErrorMessage = Error022;
						return false;
					}
				}
				
				ObjDLEmployee.PKeycode = mEmployeeID;
				ObjDLEmployee.PLNO = mPlNo;				
				ObjDLEmployee.TITLE  = mTitle;
				ObjDLEmployee.EFNAME = mEFName;
				ObjDLEmployee.EMNAME  = mEMName;
				ObjDLEmployee.ELNAME = mELName;
				ObjDLEmployee.ACTIVE  = mActive;
				ObjDLEmployee.PICTUREREF = mPictureRef;
				ObjDLEmployee.FACTORYID = mFactoryID;
				ObjDLEmployee.SEX = mSex;
				ObjDLEmployee.BG = mBG;
				ObjDLEmployee.DOB = mDob;
				ObjDLEmployee.MS = mMS;
				ObjDLEmployee.NIC = mNic;
				ObjDLEmployee.NICVALIDUPTO = mNicValidUpTo;
				ObjDLEmployee.HPHONE1 = mHPhone1;
				ObjDLEmployee.HPHONE2 = mHPhone2;
				ObjDLEmployee.OPHONE1  = mOPhone1;
				ObjDLEmployee.OPHONE2 = mOPhone2;
				ObjDLEmployee.CPHONE = mCPhone;
				ObjDLEmployee.EMAIL = mEmail;
				ObjDLEmployee.TEMPADDRESS = mTempAddress;
				ObjDLEmployee.PERMENTADDRESS = mPermentAddress;
				ObjDLEmployee.WELFARECONTNO = mWelfareContNo;
				ObjDLEmployee.ORGID = mOrgID; 
				ObjDLEmployee.RANKID = mRankID;
				ObjDLEmployee.SECTIONID = mSectionID;
				ObjDLEmployee.FHName = mFHName;
				ObjDLEmployee.ServiceType = mServiceType;
				ObjDLEmployee.DOJ = mDOJ;
				ObjDLEmployee.BPS = mBPS;
				ObjDLEmployee.GatePassNo = mGatePassNo;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLEmployee);
//				ObjTrans.End_Transaction();

				if(!strErrorMessage.Equals("True"))
				{
					clsBLDependent objDependent = new clsBLDependent();
					clsdependent objDep = new clsdependent();
					DataView dvDependent = objDependent.rsGetAll(mEmployeeID);

					foreach(DataRow drRow in dvDependent.Table.Rows)
					{
						if(drRow["Relation"].ToString() == "Self")
						{
							objDep.PKeycode = drRow["DependentID"].ToString();
							objDep.EMPLOYEEID = mEmployeeID;
							objDep.RELATION = drRow["Relation"].ToString();
							objDep.TITLE = mTitle;
							objDep.DFNAME = mEFName;
							objDep.DMNAME = mEMName;
							objDep.DLNAME = mELName;
							objDep.SEX = mSex;
							objDep.BG = mBG;
							objDep.DOB = mDob;
							objDep.MS = mMS;
							objDep.NIC = mNic;
							objDep.NICVALIDUPTO = mNicValidUpTo;
							objDep.PICTUREREF = mPictureRef;
							objDep.SectionID = mSectionID;
							objDep.FactoryID = mFactoryID;
							objDep.OrgID = mOrgID;
							objDep.RankID = mRankID;
						}
						else
						{
							objDep.PKeycode = drRow["DependentID"].ToString();
							objDep.EMPLOYEEID = mEmployeeID;
							objDep.RELATION = drRow["Relation"].ToString();
							objDep.TITLE = drRow["Title"].ToString();
							objDep.DFNAME = drRow["DFName"].ToString();
							objDep.DMNAME = drRow["DMName"].ToString();
							objDep.DLNAME = drRow["DLName"].ToString();
							objDep.SEX = drRow["Sex"].ToString();
							objDep.BG = drRow["BG"].ToString();
							objDep.DOB = drRow["DOB"].ToString();
							objDep.MS = drRow["MS"].ToString();
							objDep.NIC = drRow["NIC"].ToString();
							objDep.NICVALIDUPTO = drRow["NICValidUpto"].ToString();
							objDep.PICTUREREF = drRow["PictureRef"].ToString();
							objDep.SectionID = mSectionID;
							objDep.FactoryID = mFactoryID;
							objDep.OrgID = mOrgID;
							objDep.RankID = mRankID;
						}

						this.strErrorMessage = ObjTrans.DataTrigger_Update(objDep);

						if(!this.strErrorMessage.Equals("True"))
						{
							clsBLTPVRegistration objTPVRegistration = new clsBLTPVRegistration();
							clstpvregistration objTPVR = new clstpvregistration();
							DataView dvTPVR = objTPVRegistration.rsGetSingle(drRow["PatientID"].ToString());

							if(drRow["Relation"].ToString() == "Self")
							{
								objTPVR.PKeycode = dvTPVR.Table.Rows[0]["PatientID"].ToString();
								objTPVR.TITLE = mTitle;
								objTPVR.PFNAME = mEFName;
								objTPVR.PMNAME = mEMName;
								objTPVR.PLNAME = mELName;
								objTPVR.SEX = mSex;
								objTPVR.DOB = mDob;
								objTPVR.BLOODGROUP = mBG;
								objTPVR.MS = mMS;
								objTPVR.NIC = mNic;
								objTPVR.PictureReference = mPictureRef;
								
								if(!mTempAddress.Equals(""))
								{
									objTPVR.ADDRESS = mTempAddress;
								}
								else
								{
									objTPVR.ADDRESS = mPermentAddress;
								}

								objTPVR.CellPhone = mCPhone;

								if(!mHPhone1.Equals(""))
								{
									objTPVR.Phone1 = mHPhone1;
								}
								else
								{
									objTPVR.Phone1 = mHPhone2;
								}

								if(!mOPhone1.Equals(""))
								{
									objTPVR.Phone2 = mOPhone1;
								}
								else
								{
									objTPVR.Phone2 = mOPhone2;
								}

								objTPVR.Fax = dvTPVR.Table.Rows[0]["Fax"].ToString();
								objTPVR.EMAIL = mEmail;
								objTPVR.LastVistNo = dvTPVR.Table.Rows[0]["LastVisitNo"].ToString();
								objTPVR.Relation = "Self";
							}
							else
							{
								objTPVR.PKeycode = dvTPVR.Table.Rows[0]["PatientID"].ToString();
								objTPVR.TITLE = dvTPVR.Table.Rows[0]["Title"].ToString();
								objTPVR.PFNAME = dvTPVR.Table.Rows[0]["PFName"].ToString();
								objTPVR.PMNAME = dvTPVR.Table.Rows[0]["PMName"].ToString();
								objTPVR.PLNAME = dvTPVR.Table.Rows[0]["PLName"].ToString();
								objTPVR.SEX = dvTPVR.Table.Rows[0]["Sex"].ToString();
								objTPVR.DOB = dvTPVR.Table.Rows[0]["DOB"].ToString();
								objTPVR.BLOODGROUP = dvTPVR.Table.Rows[0]["BloodGroup"].ToString();
								objTPVR.MS = dvTPVR.Table.Rows[0]["MS"].ToString();
								objTPVR.NIC = dvTPVR.Table.Rows[0]["NIC"].ToString();
								objTPVR.PictureReference = dvTPVR.Table.Rows[0]["PictureRef"].ToString();
								
								if(!mTempAddress.Equals(""))
								{
									objTPVR.ADDRESS = mTempAddress;
								}
								else
								{
									objTPVR.ADDRESS = mPermentAddress;
								}

								objTPVR.CellPhone = mCPhone;

								if(!mHPhone1.Equals(""))
								{
									objTPVR.Phone1 = mHPhone1;
								}
								else
								{
									objTPVR.Phone1 = mHPhone2;
								}

								if(!mOPhone1.Equals(""))
								{
									objTPVR.Phone2 = mOPhone1;
								}
								else
								{
									objTPVR.Phone2 = mOPhone2;
								}

								objTPVR.Fax = dvTPVR.Table.Rows[0]["Fax"].ToString();
								objTPVR.EMAIL = mEmail;
								objTPVR.LastVistNo = dvTPVR.Table.Rows[0]["LastVisitNo"].ToString();
								objTPVR.Relation = drRow["Relation"].ToString();
							}

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
							this.strErrorMessage = ObjTrans.OperationError;
							ObjTrans.End_Transaction();
							return false;
						}
					}
				}
				else
				{
					strErrorMessage = ObjTrans.OperationError;
					ObjTrans.End_Transaction();
					return false;
				}

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
			}
		}


		public bool rsDelete(string mEmployeeID)
		{
			try
			{
				ObjDLEmployee.PKeycode=mEmployeeID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLEmployee); 
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
		///		Display All Record - Return type DataView
		/// </summary>

		public DataView rsGetAll(string mPLNo, string mEmployeeName, string mFactoryID, string mSectionID,string mRankID, string mNic, string mSex, string mBG, string mMS, string mEmail, string mAddress, string mHPhone, string mOPhone, string mCPhone, string mWelFareContNo)
		{
			ObjDLEmployee.PLNO = mPLNo;
			ObjDLEmployee.EmployeeName  = mEmployeeName;
			ObjDLEmployee.FACTORYID = mFactoryID;
			ObjDLEmployee.SECTIONID = mSectionID;
			ObjDLEmployee.RANKID = mRankID;
			ObjDLEmployee.NIC = mNic;
			ObjDLEmployee.SEX = mSex;
			ObjDLEmployee.BG = mBG;
			ObjDLEmployee.MS = mMS;
			ObjDLEmployee.EMAIL = mEmail;
			ObjDLEmployee.Address  = mAddress;
			ObjDLEmployee.HPhone = mHPhone;
			ObjDLEmployee.OPhone = mOPhone;
			ObjDLEmployee.CPHONE = mCPhone;
			ObjDLEmployee.WELFARECONTNO =mWelFareContNo;

			return ObjTrans.DataTrigger_Get_All(ObjDLEmployee);
		}


		public DataView rsGetAll(string mPLNo, string mEmployeeName, string mFactoryID, string mSectionID,string mRankID, string mNic, string mSex, string mBG, string mMS, string mEmail, string mAddress, string mHPhone, string mOPhone, string mCPhone, string mWelFareContNo, string mOrgID, string mServiceType, string mBPS)
		{
			ObjDLEmployee.PLNO = mPLNo;
			ObjDLEmployee.EmployeeName  = mEmployeeName;
			ObjDLEmployee.FACTORYID = mFactoryID;
			ObjDLEmployee.SECTIONID = mSectionID;
			ObjDLEmployee.RANKID = mRankID;
			ObjDLEmployee.NIC = mNic;
			ObjDLEmployee.SEX = mSex;
			ObjDLEmployee.BG = mBG;
			ObjDLEmployee.MS = mMS;
			ObjDLEmployee.EMAIL = mEmail;
			ObjDLEmployee.Address  = mAddress;
			ObjDLEmployee.HPhone = mHPhone;
			ObjDLEmployee.OPhone = mOPhone;
			ObjDLEmployee.CPHONE = mCPhone;
			ObjDLEmployee.WELFARECONTNO =mWelFareContNo; 
			ObjDLEmployee.ORGID = mOrgID;
			ObjDLEmployee.ServiceType = mServiceType;
			ObjDLEmployee.BPS = mBPS;
			return ObjTrans.DataTrigger_Get_All(ObjDLEmployee);
		}


		/// <summary>
		///		Display All Record - Return type DataView
		/// </summary>

		public DataView rsGetAll(string mPlNo)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mPlNo, "", "", "", "", "", "", "", "", "", "", "", "", "", "","", "", "");
			return mDataView; 
		}


		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mEmployeeID)
		{
			ObjDLEmployee.PKeycode=mEmployeeID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLEmployee);
		}


		public DataView rsGetSingle(string mOrgID, string mPlNo)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mPlNo, "", "", "", "", "", "", "", "", "", "", "", "", "", "", mOrgID, "", "");
			return mDataView; 
		}


		public DataView rsGetSingle(string mOrgID, string mFactoryID, string mPlNo)
		{
			DataView mDataView = new DataView();			
			mDataView=rsGetAll(mPlNo,"", mFactoryID,"", "", "", "", "", "", "", "", "", "", "", "", mOrgID, "", "");
			return mDataView; 
		}


		// Check First Name

		private bool VD_EFName(string mEFName)
		{
			if(mEFName.Equals("")) 
			{
				strErrorMessage=Error008;
				return false;
			}
//			else if(!objValid.IsAlpha(mEFName))
//			{
//				strErrorMessage = Error023;
//				return false;
//			}

			return true;			
		}


		private bool VD_Active(string mActive)
		{
			if (mActive!="Y" & mActive!="N") 
			{
				strErrorMessage=Error006; 
				return false;
			}
			else
			{
				return true;
			}
		}


		private bool VD_Sex(string mSex)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView = ObjGeneralCollections.SexTypes(); 
				mDataView.RowFilter ="SexCode='" + mSex + "'";
				if(mDataView.Count==0)
				{
					strErrorMessage=Error010;
					return false;
				}
				else
				{
					return true;
				}
			}  
			catch(Exception ex)
			{
				strErrorMessage=ex.Message.ToString();  
				return false;				
			}
		}


		private bool VD_MS(string mMS, string mTitle)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.MaritalStatus(); 
				mDataView.RowFilter ="MaritalCode='" + mMS + "'";
				if(mDataView.Count == 0)
				{
					strErrorMessage=Error014;
					return false;}
				else if(mTitle.Equals("Mr") && mMS.Equals("W"))
				{
					strErrorMessage = Error027;
					return false;
				}
				else
				{
					return true;
				}
			}  
			catch(Exception ex)
			{
				strErrorMessage = ex.Message.ToString();  
				return false;				
			}
		}


		private bool VD_Dob(string mDob)
		{
			return objValid.IsDate(mDob);
		}


		private bool VD_Title(string mTitle)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.Titles();
				mDataView.RowFilter ="Titles='" + mTitle + "'";
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

		private bool VD_FactoryID(string mFactoryID)
		{
			clsBLFactory ObjBLFactory = new clsBLFactory();
			DataView mDataView = new DataView();
			mDataView=ObjBLFactory.rsGetSingle(mFactoryID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}

		
		private bool VD_PLNo(string mEmployeeID, string mPLNo)
		{			
			if(mPLNo == "") 
			{
				strErrorMessage = Error004;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView = rsGetAll(mPLNo);
			//int i=mDataView.Count;
			if(mEmployeeID != "")
			{
				mDataView.RowFilter = "EmployeeID<>'" + mEmployeeID + "'";
				//		mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			}
			
			if(mDataView.Count>0)
			{
				strErrorMessage=Error005;
				return false;}
			else
			{return true;}
		}

		// Salahuddin
		private bool VD_PLNo(string mEmployeeID, string mPLNo, string mOrgID)
		{
//			if(mOrgID.Equals("01") && (mPLNo.Length != 6))
//			{
//				this.strErrorMessage = Error021;
//				return false;
//			}

			if(mPLNo == "") 
			{
				clsBLOrganizations objOrg = new clsBLOrganizations();
				DataView dv = objOrg.rsGetSingle(mOrgID);

				if(!dv.Table.Rows[0]["OType"].ToString().Equals("P"))
				{
					strErrorMessage = Error004;
					return false;
				}
				
				return true;
			}
			else if(!objValid.IsPLNo(mPLNo))
			{
				strErrorMessage = Error021;
				return false;
			}

			DataView mDataView = new DataView();			
			mDataView = rsGetAll(mPLNo, "", "", "", "", "", "","", "", "", "", "", "", "", "", mOrgID, "", "");
			//int i=mDataView.Count;
			if (mEmployeeID!="")
			{
				mDataView.RowFilter ="EmployeeID<>'" + mEmployeeID + "' And PLNo = '" + mPLNo + "'";
				//		mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			}
			else
			{
				mDataView.RowFilter = "PLNo = '" + mPLNo + "'";
			}
			
			if (mDataView.Count>0)
			{
				strErrorMessage=Error005;
				return false;}
			else
			{return true;}
		}	// End Salahuddin


		/// <summary>
		/// Validation Method for National Identity Card Number
		/// </summary>
		/// <param name="mEmployeeID">Employee ID to distinguish b/w Insert & Update (string, 6)</param>
		/// <param name="mNIC">National Identity Card Number (string, 20)</param>
		/// <param name="mNICVUpto">National Identity Card Validity Date (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_NIC(string mEmployeeID, string mNIC, string mNICVUpto)
		{	/*
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
						strErrorMessage = Error019;
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


		private bool VD_RankID(string mOrgID, string mRankID)
		{
			try
			{
				clsBLRank ObjBLRank = new clsBLRank();
				DataView mDataView = new DataView();
				mDataView=ObjBLRank.rsGetAll(mOrgID, "", ""); 
				{mDataView.RowFilter ="RankID='" + mRankID + "'";}
				mDataView.RowStateFilter = DataViewRowState.OriginalRows;
				if (mDataView.Count==0)
				{
					strErrorMessage=Error009;
					return false;
				}
				else
				{
					return true;
				}
			}
			catch(Exception e)
			{
				strErrorMessage = e.Message.ToString();
				return false;
			}
		}

		private bool VD_SectionID(string mFactoryID, string mSectionID)
		{
			clsBLSection ObjBLSection = new clsBLSection();
			DataView mDataView = new DataView();
			mDataView=ObjBLSection.rsGetAll(mFactoryID); 
			{mDataView.RowFilter ="SectionID='" + mSectionID + "'";}
			mDataView.RowStateFilter = DataViewRowState.OriginalRows;
			if (mDataView.Count==0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
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


		/// <summary>
		/// Validation Method for validating Email
		/// </summary>
		/// <param name="mEmail">Email Address (string, 150)</param>
		/// <returns>Boolean</returns>
		private bool VD_Email(string mEmail)
		{
			return objValid.IsEmail(mEmail);
		}
	}
}