using System;
using System.Data;  
using System.Threading;
using System.Globalization;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Doctor" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLDoctor
	{
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
		clsdoctor ObjDLDoctor = new clsdoctor(); 		 
		clsoperation ObjTrans = new clsoperation(); 

		private string strErrorMessage = "";
		private const string Error001 = "Invalid Value of Active.";
		private const string Error002 = "Invalid Nic ValidUpTo Date.";
		private const string Error003 = "Invalid Passport ValidUpTo Date.";
		private const string Error004 = "Invalid Value of Title.";
		private const string Error005 = "Invalid Value of Speciality Type";


		public clsBLDoctor()
		{
		}

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}
	
	
		private bool Data_Validation(string mFName, 
			string mMName, string mLName, string mAcronym, string mFHName, 
			string mDOB,string mNic, string mNicValidUpTo, 
			string mPassportValidUpTo, string mEMail, string mAddress)
		{
			Validation objVal = new Validation();

			if(!objVal.IsAlpha(mFName) && mFName != "")			
			{
				
				strErrorMessage = "Invalid first name";
				return false;
			}
			if(!objVal.IsAlpha(mMName) && mMName != "")			
			{
				
				strErrorMessage = "Invalid middle name";
				return false;
			}
			if(!objVal.IsAlpha(mLName) && mLName != "")			
			{
				
				strErrorMessage = "Invalid last name";
				return false;
			}
			
			if(!objVal.IsAlpha(mAcronym) && mAcronym != "")
			{
				strErrorMessage = "Invalid acronym";
				return false;
			}
			
			if(!objVal.IsName(mFHName) && mFHName != "" )
			{
				strErrorMessage = "Invalid father name";
			}

			if(!objVal.IsDate(mDOB) && mDOB != "")
			{
				strErrorMessage = "Invalid format of birth date";
				return false;
			}

			if(!objVal.IsNIC(mNic) && mNic != "")
			{
				strErrorMessage = "Invalid format of NIC no";
				return false;
			}

			if(!objVal.IsDate(mNicValidUpTo) && mNicValidUpTo != "")
			{
				strErrorMessage = "Invalid format of NIC valid date";
				return false;
			}

			if(!objVal.IsDate(mPassportValidUpTo) && mPassportValidUpTo != "")
			{
				
				strErrorMessage = "Invalid format of passport valid date";
				return false;
			}
			if(!objVal.IsEmail(mEMail) && mEMail != "")
			{
				strErrorMessage = "Invalid email address";
				return false;
			}

			if(!objVal.IsAddress(mAddress) && mAddress != "")
			{
				strErrorMessage = "Invalid address";
				return false;
			}



			return true;
			
		}

		
		public bool rsInsert(string mActive, string mTitle, string mFName, 
			string mMName, string mLName, string mAcronym, string mFHName, 
			string mSex, string mBG, string mDOB, string mAge, string mMS,
			string mNic, string mNicValidUpTo, string mPassport, 
			string mPassportValidUpTo, string mHPhoneNo1, string mHPhoneNo2, 
			string mOPhoneNo1, string mOPhoneNo2, string mCPhoneNo, 
			string mPagerNo, string mEMail, string mAddress, string mPictureRef,
			string mSpecialityTypeID, string mOPDStatus, string[] mDoctorSpeciality)
		{		
			int i;
			int j;
			string mDoctorID;
			i=mDoctorSpeciality.Length; 
			try
			{
				/*if(false == Data_Validation( mFName,mMName,  mLName,  mAcronym,  mFHName,mDOB, mNic,  mNicValidUpTo,mPassportValidUpTo,mEMail,  mAddress))
				{
					return false;
				}*/
	

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				};


				if (mNicValidUpTo.Length>0)
				{ 
					if (VD_NicValidUpTo(mNicValidUpTo)==false) 
					{						
						return false;
					};			
				};

				if (mPassportValidUpTo.Length>0)
				{ 
					if (VD_PassportValidUpTo(mPassportValidUpTo)==false) 
					{						
						return false;
					};			
				};

				if (VD_SpecialityTypeID(mSpecialityTypeID)==false)
				{						
					return false;
				};

				ObjDLDoctor.Active = mActive;
				ObjDLDoctor.Title  = mTitle;
				ObjDLDoctor.Fname = mFName;
				ObjDLDoctor.Mname = mMName;
				ObjDLDoctor.Lname = mLName;
				ObjDLDoctor.Acronym = mAcronym;
				ObjDLDoctor.FHname = mFHName;
				ObjDLDoctor.Sex = mSex;
				ObjDLDoctor.BG = mBG;
				ObjDLDoctor.DOB = mDOB;
				ObjDLDoctor.Age = mAge;
				ObjDLDoctor.MS = mMS;
				ObjDLDoctor.NIC = mNic;
				ObjDLDoctor.NicValIdupto = mNicValidUpTo;
				ObjDLDoctor.Passport = mPassport;
				ObjDLDoctor.PassportValIdupto = mPassportValidUpTo;
				ObjDLDoctor.HphoneNo1 = mHPhoneNo1;
				ObjDLDoctor.HphoneNo2 = mHPhoneNo2;
				ObjDLDoctor.OphoneNo1 = mOPhoneNo1;
				ObjDLDoctor.OphoneNo2 = mOPhoneNo2;
				ObjDLDoctor.CphoneNo = mCPhoneNo;
				ObjDLDoctor.Pagerno = mPagerNo;
				ObjDLDoctor.Email = mEMail;
				ObjDLDoctor.Address = mAddress;
				ObjDLDoctor.PICTUREREF = mPictureRef;			
				ObjDLDoctor.SPECIALITYTYPEID  = mSpecialityTypeID;
				ObjDLDoctor.OPDSTATUS = mOPDStatus; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLDoctor, clsoperation.Get_PKey.Yes);
				mDoctorID=ObjDLDoctor.PKeycode;

				clsBLDoctorSpeciality ObjBLDoctorSpeciality=new clsBLDoctorSpeciality(); 
				for (j=0; j < i; j++)
				{
					ObjBLDoctorSpeciality.rsInsert(mDoctorID, mDoctorSpeciality[j], ObjTrans); 
				}
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

		//string mDoctorID, 
		public bool rsUpdate(string mDoctorID, string mActive, string mTitle, 
			string mFName, string mMName, string mLName, string mAcronym, 
			string mFHName, string mSex, string mBG, string mDOB,
			string mAge, string mMS, string mNic, string mNicValidUpTo, 
			string mPassport, string mPassportValidUpTo, string mHPhoneNo1, 
			string mHPhoneNo2, string mOPhoneNo1, string mOPhoneNo2, 
			string mCPhoneNo, string mPagerNo, string mEMail, string mAddress,
			string mPictureRef, string mSpecialityTypeID, string mOPDStatus, string[] mDoctorSpeciality)
		{		
			try
			{
				int i;
				int j;
				i=mDoctorSpeciality.Length; 

				/*if(false == Data_Validation( mFName,mMName,  mLName,  mAcronym,  mFHName,mDOB, mNic,  mNicValidUpTo,mPassportValidUpTo,mEMail,  mAddress))
				{
					return false;
				}*/

				if (VD_Active(mActive)==false) 
				{						
					return false;
				};

				if (mNicValidUpTo.Length>0)
				{ 
					if (VD_NicValidUpTo(mNicValidUpTo)==false) 
					{						
						return false;
					};			
				};

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				};


				if (mPassportValidUpTo.Length>0)
				{ 
					if (VD_PassportValidUpTo(mPassportValidUpTo)==false) 
					{						
						return false;
					};			
				};

				if (VD_SpecialityTypeID(mSpecialityTypeID)==false)
				{						
					return false;
				};

				ObjDLDoctor.PKeycode=mDoctorID; 
				ObjDLDoctor.Active = mActive;
				ObjDLDoctor.Title  = mTitle;
				ObjDLDoctor.Fname = mFName;
				ObjDLDoctor.Mname = mMName;
				ObjDLDoctor.Lname = mLName;
				ObjDLDoctor.Acronym = mAcronym;
				ObjDLDoctor.FHname = mFHName;
				ObjDLDoctor.Sex = mSex;
				ObjDLDoctor.BG = mBG;
				ObjDLDoctor.DOB = mDOB;
				ObjDLDoctor.Age = mAge;
				ObjDLDoctor.MS = mMS;
				ObjDLDoctor.NIC = mNic;
				ObjDLDoctor.NicValIdupto = mNicValidUpTo;
				ObjDLDoctor.Passport = mPassport;
				ObjDLDoctor.PassportValIdupto = mPassportValidUpTo;
				ObjDLDoctor.HphoneNo1 = mHPhoneNo1;
				ObjDLDoctor.HphoneNo2 = mHPhoneNo2;
				ObjDLDoctor.OphoneNo1 = mOPhoneNo1;
				ObjDLDoctor.OphoneNo2 = mOPhoneNo2;
				ObjDLDoctor.CphoneNo = mCPhoneNo;
				ObjDLDoctor.Pagerno = mPagerNo;
				ObjDLDoctor.Email = mEMail;
				ObjDLDoctor.Address = mAddress;
				ObjDLDoctor.PICTUREREF = mPictureRef;
				ObjDLDoctor.SPECIALITYTYPEID  = mSpecialityTypeID;
				ObjDLDoctor.OPDSTATUS = mOPDStatus; 			
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLDoctor);

				clsBLDoctorSpeciality ObjBLDoctorSpeciality=new clsBLDoctorSpeciality(); 
				ObjBLDoctorSpeciality.rsDelete(mDoctorID, ObjTrans); 
				for (j=0; j < i; j++)
				{
					ObjBLDoctorSpeciality.rsInsert(mDoctorID, mDoctorSpeciality[j], ObjTrans); 
				}

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

		public bool rsDelete(string mDoctorID)
		{
			try
			{
				ObjDLDoctor.PKeycode=mDoctorID; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLDoctor); 
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

		public DataView rsGetAll(string mActive, string mDoctorName, 
			string mAcronym, string mSex, string mBG, string mMS, string mNic,
			string mPassport, string mHPhone, string mOPhone, string mCPhoneNo,
			string mPagerNo, string mEMail, string mAddress, string mSpecialityTypeID)
		{
			ObjDLDoctor.Active = mActive;
			ObjDLDoctor.DOCTORNAME = mDoctorName;
			ObjDLDoctor.Acronym = mAcronym;
			ObjDLDoctor.Sex = mSex;
			ObjDLDoctor.BG = mBG;
			ObjDLDoctor.MS = mMS;
			ObjDLDoctor.NIC = mNic;
			ObjDLDoctor.Passport = mPassport;
			ObjDLDoctor.HPHONE = mHPhone;
			ObjDLDoctor.OPHONE = mOPhone;
			ObjDLDoctor.CphoneNo = mCPhoneNo;
			ObjDLDoctor.Pagerno = mPagerNo;
			ObjDLDoctor.Email = mEMail;
			ObjDLDoctor.Address = mAddress;
			ObjDLDoctor.SPECIALITYTYPEID  = mSpecialityTypeID;
			return ObjTrans.DataTrigger_Get_All(ObjDLDoctor);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mDoctorID)
		{
			ObjDLDoctor.PKeycode=mDoctorID; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLDoctor);
		}

		/// <summary>
		///		Return Doctor All Speci Record - Paramater Application ID - Return type DataView
		/// </summary>


		public DataView rsGetAllDoctorSP(string mDoctorID)
		{
			clsBLDoctorSpeciality ObjDLDoctorSpeciality = new clsBLDoctorSpeciality(); 
			return ObjDLDoctorSpeciality.rsGetSingle(mDoctorID, ObjTrans); 
		}


		private bool VD_Active(string mActive)
		{
			if (mActive!="Y" & mActive!="N") 
			{
				strErrorMessage=Error001; 
				return false;
			}
			else
			{return true;}
		}

		private bool VD_NicValidUpTo(string mNicValidUpTo)
		{
			ObjDateFormat.DateTimeFormat.ShortDatePattern ="dd/MM/yyyy"; 
			System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

			try
			{
				System.DateTime.Parse(mNicValidUpTo);
				return true;
			}  
			catch(Exception)
			{
				strErrorMessage=Error002; //"Invalid Nic ValidUpTo";
				return false;				
			}		
		}

		private bool VD_PassportValidUpTo(string mPassportValidUpTo)
		{
			ObjDateFormat.DateTimeFormat.ShortDatePattern ="dd/MM/yyyy"; 
			System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

			try
			{
				System.DateTime.Parse(mPassportValidUpTo);
				return true;
			}  
			catch(Exception)
			{
				strErrorMessage=Error003; //"Invalid Passport ValidUpTo";
				return false;				
			}		
		}

		private bool VD_Title(string mTitle)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.Titles();
			{mDataView.RowFilter ="Titles='" + mTitle + "'";}

				if (mDataView.Count==0)
				{
					strErrorMessage=Error004;
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

		private bool VD_SpecialityTypeID(string mSpecialityTypeID)
		{
			clsBLSpecialityType ObjBLSpecialityType = new clsBLSpecialityType();
			DataView mDataView = new DataView();
			mDataView=ObjBLSpecialityType.rsGetSingle(mSpecialityTypeID); 
			if (mDataView.Count==0)
			{
				strErrorMessage=Error005;
				return false;}
			else
			{return true;}
		}
	}
}
