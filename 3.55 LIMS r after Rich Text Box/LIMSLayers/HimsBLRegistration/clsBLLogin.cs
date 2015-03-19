using System;
using System.Data;  
using HimsDlRegistration;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;


namespace HimsBLRegistration
{
	/// <summary>
	/// Application	:	Hospital Information & Management System (HIMS)
	///	Class for	:	"tPersonnel" Table
	///	Developer	:	Trees Software (Pvt) Ltd.
	///	Date		:	August 2004 (In POF Hospital Wah Cantt)	
	/// Type		:	Business Layer Class
	/// </summary>
	public class clsBLLogin
	{
		private string strErrorMessage = "";
		private const string Error01 = "Invalid user name or password";
		private const string Error02 = "Your account is Inactive, contact your System Administrator";
		private const string Error03 = "User Name must be entered"; 
		private const string Error04 = "Password must be entered";		
		private const string Error05 = "Designation ID must be selected.";
		private const string Error06 = "Department ID must be selected.";
		private const string Error07 = "Title must be selected.";
		private const string Error08 = "First Name must be entered.";
		private const string Error09 = "First Name is Incorrect.";
		private const string Error10 = "Middle Name is Incorrect.";
		private const string Error11 = "Last Name is Incorrect.";
		private const string Error12 = "Acronym must be entered.";
		private const string Error13 = "Acronym is Incorrect.";
		private const string Error14 = "Given Acronym is already used by another person.";
		private const string Error15 = "Father Name must be entered.";
		private const string Error16 = "Father Name is Incorrect.";
		private const string Error17 = "Sex must be selected";
		private const string Error18 = "Date of Birth is Incorrect.";
		private const string Error19 = "Marital Status must be selected.";
		private const string Error20 = "NIC Number is Incorrect.";
		private const string Error21 = "NIC Number is already in used by another Person.";
		private const string Error22 = "NIC Number is not entered,while its validity date is entered.";
		private const string Error23 = "NIC valid Upto Date is Incorrect.";
		private const string Error24 = "Passport Number is not entered, while its Validity Date is entered.";
		private const string Error25 = "Passport Valid upto Date is Incorrect.";
		private const string Error26 = "Email Address is Incorrect.";
		private const string Error27 = "Address is Incorrect.";
		private const string Error28 = "This Login ID is already in used by another Person.";
		private const string Error29 = "NIC Validity Date is not entered.";
		private const string Error30 = "Passport Validity Date is not entered.";
		private const string Error31 = "Blood Group must be selected.";
				
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
		clsoperation ObjTrans = new clsoperation();
		Validation objValid = new Validation();


		public clsBLLogin()
		{
		}


        public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}


		/// <summary>
		/// Method for Login Purpose verify through User ID & Password
		/// </summary>
		/// <param name="userId">User / Login ID (string, 10)</param>
		/// <param name="password">Password (string, 10)</param>
		/// <returns>Person Name (Title + Frist Name + Middle Name + Last Name) (string, 66)</returns>
		public string  VD_Login(string userId,string password)
		{
			string personName="";

			if(userId.ToString().Equals("")){
				strErrorMessage = Error03;
				return personName;
			}
			if(password.ToString().Equals("")){
				strErrorMessage = Error04;
				return personName;
			}
			DataView mDataView = new DataView();			
			mDataView=rsGetAll("", "", "", "", "", "", "", "", "", "", "", "", "", "", "", userId,password,"","");
			if(mDataView.Count > 0 )
			{
				personName = mDataView[0].Row["PersonName"].ToString();
				if(mDataView[0].Row["Active"].ToString()=="N"){
					strErrorMessage = Error02;
					personName="";
					return personName;
				}
				else
				{	
					return personName;
				}
			}
			else
			{
				strErrorMessage =  Error01;
				personName = "";
				return personName;
			}		
		}
		

		/// <summary>
		/// Record Insertion Method for "tPersonnel" and "tPersonnelSpecialty" Tables
		/// </summary>		
		/// <param name="mDesignationID">Designation ID (string, 4)</param>
		/// <param name="mDepartmentID">Department ID (string, 4)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mTitle">Title (string, 6)</param>
		/// <param name="mFName">First Name (string, 20)</param>
		/// <param name="mMName">Middle Name (string, 20)</param>
		/// <param name="mLName">Last Name (string, 20)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mFHName">Father / Husband Name (string, 30)</param>
		/// <param name="mSex">Sex (string, 1)</param>
		/// <param name="mDOB">Date of Birth (string, 10)</param>
		/// <param name="mMS">Marital Status (string, 1)</param>
		/// <param name="mNIC">National Identity Card Number (string, 20)</param>
		/// <param name="mNICValidUpto">National Identity Card Validity Date (string, 10)</param>
		/// <param name="mPassport">Passport Number (string, 20)</param>
		/// <param name="mPassportValidUpto">Passport Validity Date (string, 10)</param>
		/// <param name="mHPhoneNo1">House Phone Number 1 (string, 15)</param>
		/// <param name="mHPhoneNo2">House Phone Number 2 (string, 15)</param>
		/// <param name="mOPhoneNo1">Office Phone Number 1 (string, 15)</param>
		/// <param name="mOPhoneNo2">Office Phone Number 2 (string, 15)</param>
		/// <param name="mCPhoneNo">Cell Phone Number (string, 15)</param>
		/// <param name="mPagerNo">Pager Number(string, 15)</param>
		/// <param name="mEMail">Email Address (string, 150)</param>
		/// <param name="mAddress">Address (string, 255)</param>
		/// <param name="mPictureRef">Picture Reference (string, 255)</param>
		/// <param name="mLoginID">Login ID (string, 10)</param>
		/// <param name="mPassword">Password (string, 10)</param>
		/// <param name="mBloodGroup">Blood Group (string, 3)</param>
		/// <param name="mPersonSpecialty">Personnel specialties - "tPersonnelSpecialty" Table (string[], 5)</param>
		/// <returns>Boolean</returns>
		public bool rsInsert(string mDesignationID, string mDepartmentID, string mActive, string mTitle, string mFName, string mMName, string mLName, string mAcronym, string mFHName, string mSex, string mDOB, string mMS, string mNIC, string mNICValidUpto, string mPassport, string mPassportValidUpto, string mHPhoneNo1, string mHPhoneNo2, string mOPhoneNo1, string mOPhoneNo2, string mCPhoneNo, string mPagerNo, string mEMail, string mAddress, string mPictureRef, string mLoginID, string mPassword, string mBloodGroup, string[] mPersonSpecialty)
		{		
			int i;
			int j;
			string mPersonID;
			i = mPersonSpecialty.Length; 
			try
			{				
				if(mLoginID.Equals(""))
				{
					strErrorMessage = Error03;
					return false;
				}
				else if(!VD_LoginID(mLoginID))
				{
					strErrorMessage = Error28;
					return false;
				}

				if(mPassword.Equals(""))
				{
					strErrorMessage = Error04;
					return false;
				}

				if(mDesignationID.Equals("-1"))
				{
					strErrorMessage = Error05;
					return false;
				}

				if(mDepartmentID.Equals("-1"))
				{
					strErrorMessage = Error06;
					return false;
				}

				if(mTitle.Equals("-1"))
				{
					strErrorMessage = Error07;
					return false;
				}

				if(mFName.Equals(""))
				{
					strErrorMessage = Error08;
					return false;
				}
				else if(!VD_Word(mFName))
				{
					strErrorMessage = Error09;
					return false;
				}

				if(!mMName.Equals(""))
				{
					if(!VD_Word(mMName))
					{
						strErrorMessage = Error10;
						return false;
					}
				}

				if(!mLName.Equals(""))
				{
					if(!VD_Word(mLName))
					{
						strErrorMessage = Error11;
						return false;
					}
				}

				if(mAcronym.Equals(""))
				{
					strErrorMessage = Error12;
					return false;
				}
				else if(!VD_Word(mAcronym))
				{
					strErrorMessage = Error13;
					return false;
				}
				else if(!VD_Acronym("", mAcronym))
				{
					strErrorMessage = Error14;
					return false;
				}

				if(mFHName.Equals(""))
				{
					strErrorMessage = Error15;
					return false;
				}
				else if(!VD_Name(mFHName))
				{
					strErrorMessage = Error16;
					return false;
				}

				if(mSex.Equals("-1"))
				{
					strErrorMessage = Error17;
					return false;
				}

				if(!mDOB.Equals(""))
				{
					if(!VD_IsDate(mDOB))
					{
						strErrorMessage = Error18;
						return false;
					}
				}

				if(mMS.Equals("-1"))
				{
					strErrorMessage = Error19;
					return false;
				}

				if(!mNIC.Equals(""))
				{					
					if(!VD_NIC("", mNIC, mNICValidUpto))
					{
						return false;
					}
				}
				else
				{
					if(!mNICValidUpto.Equals(""))
					{
						strErrorMessage = Error22;
						return false;
					}
				}

				if(!VD_Passport(mPassport, mPassportValidUpto))
				{
					return false;
				}

				if(!mEMail.Equals(""))
				{
					if(!VD_Email(mEMail))
					{
						strErrorMessage = Error26;
						return false;
					}
				}

				if(!mAddress.Equals(""))
				{
					if(!VD_Address(mAddress))
					{
						strErrorMessage = Error27;
						return false;
					}
				}

				if(mBloodGroup.Equals("-1"))
				{
					strErrorMessage = Error31;
					return false;
				}
						
				clsTPersonnel objTPerson = new clsTPersonnel();
				objTPerson.DesignationID = mDesignationID;
				objTPerson.DepartmentID = mDepartmentID;
				objTPerson.Active = mActive;
				objTPerson.Title = mTitle;
				objTPerson.FName = mFName;
				objTPerson.MName = mMName;
				objTPerson.LName = mLName;
				objTPerson.Acronym = mAcronym;
				objTPerson.FHName = mFHName;
				objTPerson.Sex = mSex;
				objTPerson.DOB = mDOB;
				objTPerson.MS = mMS;
				objTPerson.NIC = mNIC;
				objTPerson.NICVUpto = mNICValidUpto;
				objTPerson.Passport = mPassport;
				objTPerson.PVUpto = mPassportValidUpto;
				objTPerson.HPNo1 = mHPhoneNo1;
				objTPerson.HPNo2 = mHPhoneNo2;
				objTPerson.OPNo1 = mOPhoneNo1;
				objTPerson.OPNo2 = mOPhoneNo2;
				objTPerson.CPNo = mCPhoneNo;
				objTPerson.PNo = mPagerNo;
				objTPerson.Email = mEMail;
				objTPerson.Address = mAddress;
				objTPerson.PReference = mPictureRef;
				objTPerson.LoginId = mLoginID;
				objTPerson.Password = mPassword;
				objTPerson.BloodGroup = mBloodGroup;

				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Insert(objTPerson, clsoperation.Get_PKey.Yes);
				mPersonID = objTPerson.PKeycode;

				clsBLTPersonnelSpecialty objTPSpecialty = new clsBLTPersonnelSpecialty();
				for (j=0; j < i; j++)
				{
					objTPSpecialty.rsInsert(mPersonID, mPersonSpecialty[j], ObjTrans); 
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
			}
		}


		/// <summary>
		/// Record Updation Method for "tPersonnel" and "tPersonnelSpecialty" Tables
		/// </summary>
		/// <param name="mPersonID">Person ID - for search (string, 6)</param>
		/// <param name="mDesignationID">Designation ID (string, 4)</param>
		/// <param name="mDepartmentID">Department ID (string, 4)</param>
		/// <param name="mActive">Active (string, 1)</param>
		/// <param name="mTitle">Title (string, 6)</param>
		/// <param name="mFName">First Name (string, 20)</param>
		/// <param name="mMName">Middle Name (string, 20)</param>
		/// <param name="mLName">Last Name (string, 20)</param>
		/// <param name="mAcronym">Acronym (string, 6)</param>
		/// <param name="mFHName">Father / Husband Name (string, 30)</param>
		/// <param name="mSex">Sex (string, 1)</param>
		/// <param name="mDOB">Date of Birth (string, 10)</param>
		/// <param name="mMS">Marital Status (string, 1)</param>
		/// <param name="mNIC">National Identity Card Number (string, 20)</param>
		/// <param name="mNICValidUpto">National Identity Card Validity Date (string, 10)</param>
		/// <param name="mPassport">Passport Number (string, 20)</param>
		/// <param name="mPassportValidUpto">Passport Validity Date (string, 10)</param>
		/// <param name="mHPhoneNo1">House Phone Number 1 (string, 15)</param>
		/// <param name="mHPhoneNo2">House Phone Number 2 (string, 15)</param>
		/// <param name="mOPhoneNo1">Office Phone Number 1 (string, 15)</param>
		/// <param name="mOPhoneNo2">Office Phone Number 2 (string, 15)</param>
		/// <param name="mCPhoneNo">Cell Phone Number (string, 15)</param>
		/// <param name="mPagerNo">Pager Number(string, 15)</param>
		/// <param name="mEMail">Email Address (string, 150)</param>
		/// <param name="mAddress">Address (string, 255)</param>
		/// <param name="mPictureRef">Picture Reference (string, 255)</param>
		/// <param name="mPassword">Password (string, 10)</param>
		/// <param name="mBloodGroup">Blood Group (string, 3)</param>
		/// <param name="mPersonSpecialty">Personnel specialties - "tPersonnelSpecialty" Table (string[], 5)</param>
		/// <returns>Boolean</returns>
		public bool rsUpdate(string mPersonID, string mDesignationID, string mDepartmentID, string mActive, string mTitle, string mFName, string mMName, string mLName, string mAcronym, string mFHName, string mSex, string mDOB, string mMS, string mNIC, string mNICValidUpto, string mPassport, string mPassportValidUpto, string mHPhoneNo1, string mHPhoneNo2, string mOPhoneNo1, string mOPhoneNo2, string mCPhoneNo, string mPagerNo, string mEMail, string mAddress, string mPictureRef, string mPassword, string mBloodGroup, string[] mPersonSpecialty)
		{		
			try
			{
				int i;
				int j;
				i = mPersonSpecialty.Length; 
				
				if(mPassword.Equals(""))
				{
					strErrorMessage = Error04;
					return false;
				}

				if(mDesignationID.Equals("-1"))
				{
					strErrorMessage = Error05;
					return false;
				}

				if(mDepartmentID.Equals("-1"))
				{
					strErrorMessage = Error06;
					return false;
				}

				if(mTitle.Equals("-1"))
				{
					strErrorMessage = Error07;
					return false;
				}

				if(mFName.Equals(""))
				{
					strErrorMessage = Error08;
					return false;
				}
				else if(!VD_Word(mFName))
				{
					strErrorMessage = Error09;
					return false;
				}

				if(!mMName.Equals(""))
				{
					if(!VD_Word(mMName))
					{
						strErrorMessage = Error10;
						return false;
					}
				}

				if(!mLName.Equals(""))
				{
					if(!VD_Word(mLName))
					{
						strErrorMessage = Error11;
						return false;
					}
				}

				if(mAcronym.Equals(""))
				{
					strErrorMessage = Error12;
					return false;
				}
				else if(!VD_Word(mAcronym))
				{
					strErrorMessage = Error13;
					return false;
				}
				else if(!VD_Acronym(mPersonID, mAcronym))
				{
					strErrorMessage = Error14;
					return false;
				}

				if(mFHName.Equals(""))
				{
					strErrorMessage = Error15;
					return false;
				}
				else if(!VD_Name(mFHName))
				{
					strErrorMessage = Error16;
					return false;
				}

				if(mSex.Equals("-1"))
				{
					strErrorMessage = Error17;
					return false;
				}

				if(!mDOB.Equals(""))
				{
					if(!VD_IsDate(mDOB))
					{
						strErrorMessage = Error18;
						return false;
					}
				}

				if(mMS.Equals("-1"))
				{
					strErrorMessage = Error19;
					return false;
				}

				if(!mNIC.Equals(""))
				{
					if(!VD_NIC(mPersonID, mNIC, mNICValidUpto))
					{
						return false;
					}
				}
				else
				{
					if(!mNICValidUpto.Equals(""))
					{
						strErrorMessage = Error22;
						return false;
					}
				}

				if(!mPassport.Equals(""))
				{
					if(!VD_Passport(mPassport, mPassportValidUpto))
					{
						return false;
					}
				}
				else
				{
					if(!mPassportValidUpto.Equals(""))
					{
						strErrorMessage = Error24;
						return false;
					}
				}

				if(!mEMail.Equals(""))
				{
					if(!VD_Email(mEMail))
					{
						strErrorMessage = Error26;
						return false;
					}
				}

				if(!mAddress.Equals(""))
				{
					if(!VD_Address(mAddress))
					{
						strErrorMessage = Error27;
						return false;
					}
				}

				if(mBloodGroup.Equals("-1"))
				{
					strErrorMessage = Error31;
					return false;
				}
				
				clsTPersonnel objTPerson = new clsTPersonnel();
				objTPerson.PKeycode = mPersonID;
				objTPerson.DesignationID = mDesignationID;
				objTPerson.DepartmentID = mDepartmentID;
				objTPerson.Active = mActive;
				objTPerson.Title = mTitle;
				objTPerson.FName = mFName;
				objTPerson.MName = mMName;
				objTPerson.LName = mLName;
				objTPerson.Acronym = mAcronym;
				objTPerson.FHName = mFHName;
				objTPerson.Sex = mSex;
				objTPerson.DOB = mDOB;
				objTPerson.MS = mMS;
				objTPerson.NIC = mNIC;
				objTPerson.NICVUpto = mNICValidUpto;
				objTPerson.Passport = mPassport;
				objTPerson.PVUpto = mPassportValidUpto;
				objTPerson.HPNo1 = mHPhoneNo1;
				objTPerson.HPNo2 = mHPhoneNo2;
				objTPerson.OPNo1 = mOPhoneNo1;
				objTPerson.OPNo2 = mOPhoneNo2;
				objTPerson.CPNo = mCPhoneNo;
				objTPerson.PNo = mPagerNo;
				objTPerson.Email = mEMail;
				objTPerson.Address = mAddress;
				objTPerson.PReference = mPictureRef;				
				objTPerson.Password = mPassword;
				objTPerson.BloodGroup = mBloodGroup;
				
				ObjTrans.Start_Transaction(); 
				strErrorMessage = ObjTrans.DataTrigger_Update(objTPerson);

				
				clsBLTPersonnelSpecialty objTPSpecialty = new clsBLTPersonnelSpecialty();
				objTPSpecialty.rsDelete(mPersonID, ObjTrans);
				for (j=0; j < i; j++)
				{
					objTPSpecialty.rsInsert(mPersonID, mPersonSpecialty[j], ObjTrans); 
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
			}
		}


		/// <summary>
		/// Get All Records on the basis of different combinations of search from tPersonnel table
		/// </summary>
		/// <param name="designationID">Designation ID (string, 4)</param>
		/// <param name="departmentID">Departmetn ID (string, 4)</param>
		/// <param name="active">Active (string, 1)</param>
		/// <param name="personName">Person Name (Title + First Name + Middke Name + Last Name) (string, 66)</param>
		/// <param name="acronym">Acronym (string, 6)</param>
		/// <param name="sex">Sex (string, 1)</param>
		/// <param name="maritalStatus">Date of Birth (Date, 10)</param>
		/// <param name="nICard">NIC Number (string, 20)</param>
		/// <param name="passport">Passport Number (string, 20)</param>
		/// <param name="hPNo">House Phone Number (string, 15)</param>
		/// <param name="oPNo">Office Phone Number (string, 20)</param>
		/// <param name="cPNo">Cell Phone Number (string, 15)</param>
		/// <param name="pNo">Pager Number (string, 15)</param>
		/// <param name="email">Email Address (string, 150)</param>
		/// <param name="address">Address (string, 255)</param>
		/// <param name="loginID">Login ID (string, 10)</param>
		/// <param name="bloodGroup">Blood Group (string, 3)</param>
		/// <returns>DataView</returns>
		public DataView rsGetAll(string designationID, string departmentID, string active, string personName, string acronym, string sex, string maritalStatus, string nICard, string passport, string hPNo, string oPNo, string cPNo, string pNo, string email, string address, string loginID, string pasword, string bloodGroup, string dsgSpecialtyID)
		{
			clsTPersonnel objTPerson = new clsTPersonnel();
			System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
						
			objTPerson.DesignationID = designationID;
			objTPerson.DepartmentID = departmentID;
			objTPerson.Active = active;
			objTPerson.PName = personName;
			objTPerson.Acronym = acronym;
			objTPerson.Sex = sex;
			objTPerson.MS = maritalStatus;
			objTPerson.NIC = nICard;
			objTPerson.Passport = passport;
			objTPerson.HPNo1 = hPNo;
			objTPerson.OPNo1 = oPNo;
			objTPerson.CPNo = cPNo;
			objTPerson.PNo = pNo;
			objTPerson.Email = email;
			objTPerson.Address = address;
			objTPerson.LoginId= loginID;
			objTPerson.Password = pasword;
			objTPerson.BloodGroup = bloodGroup;
			objTPerson.DsgSpecialtyID = dsgSpecialtyID;

			return ObjTrans.DataTrigger_Get_All(objTPerson);
		}


		/// <summary>
		/// Get a Single Record from tPersonnel table
		/// </summary>
		/// <param name="mPersonID">Person ID (string, 6)</param>
		/// <returns>Person Record (DataView)</returns>
		public DataView rsGetSingle(string mPersonID)
		{
			clsTPersonnel objTPerson = new clsTPersonnel();	
			objTPerson.PKeycode = mPersonID; 
			return ObjTrans.DataTrigger_Get_Single(objTPerson);
		}


		/// <summary>
		/// Return Person all Specialty Records from "tPersonnelSpecialty" Table
		/// </summary>
		/// <param name="mPersonID">Person ID (string, 6)</param>
		/// <returns>Person Specialties (DataView)</returns>
		public DataView rsGetAllDoctorSP(string mPersonID)
		{
			clsBLTPersonnelSpecialty objTPSpecialty = new clsBLTPersonnelSpecialty();
			return objTPSpecialty.rsGetSingle(mPersonID, ObjTrans); 
		}


		/// <summary>
		/// Validation Method for validating Date
		/// </summary>
		/// <param name="mDate">Date Input (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_IsDate(string mDate)
		{
			ObjDateFormat.DateTimeFormat.ShortDatePattern ="dd/MM/yyyy"; 
			System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;

			try
			{
				System.DateTime.Parse(mDate);
				return true;
			}  
			catch(Exception)
			{				
				return false;				
			}		
		}


		/// <summary>
		/// Validation Method for unique Login ID in "tPersonnel" Table
		/// </summary>
		/// <param name="loginID">Login ID (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_LoginID(string loginID)
		{
			DataView dvPerson = rsGetAll("", "", "", "", "", "", "", "", "", "","","","","","",loginID,"","",""); 
			if(dvPerson.Count == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// Validation Method for checking name (Sentence), are Characters or not
		/// </summary>
		/// <param name="alphabet">Input (string)</param>
		/// <returns>Boolean</returns>
		private bool VD_Name(string alphabet)
		{
			return objValid.IsName(alphabet);
		}


		/// <summary>
		/// Validation Method for checking leeters in a word, characters or not
		/// </summary>
		/// <param name="word">Word (Not Sentence) (string)</param>
		/// <returns>Boolean</returns>
		private bool VD_Word(string word)
		{
			return objValid.IsAlpha(word);
		}


		/// <summary>
		/// Validation Method for validating unique Acronym
		/// </summary>
		/// <param name="mPersonID">Person ID to distinguish b/w Insert & Update (string, 6)</param>
		/// <param name="acronym">Acronym (string, 6)</param>
		/// <returns>Boolean</returns>
		private bool VD_Acronym(string mPersonID, string acronym)
		{
			DataView dvAcronym = rsGetAll("", "", "", "", acronym, "", "", "", "", "","","","","","","","","","");
			if(!mPersonID.Equals(""))
			{
				dvAcronym.RowFilter = "PersonID<>'"+ mPersonID +"'";
				dvAcronym.RowStateFilter = DataViewRowState.OriginalRows;
			}
			if(dvAcronym.Count > 0)
			{
				return false;
			}
			return true;
		}


		/// <summary>
		/// Validation Method for National Identity Card Number
		/// </summary>
		/// <param name="mPersonID">Person ID to distinguish b/w Insert & Update (string, 6)</param>
		/// <param name="mNIC">National Identity Card Number (string, 20)</param>
		/// <param name="mNICVUpto">National Identity Card Validity Date (string, 10)</param>
		/// <returns>Boolean</returns>
		private bool VD_NIC(string mPersonID, string mNIC, string mNICVUpto)
		{
			if(objValid.IsNIC(mNIC))
			{
				DataView dvNIC = rsGetAll("","","", "", "", "", "", mNIC, "", "", "", "", "", "", "","","","","");
				if(!mPersonID.Equals(""))
				{
					dvNIC.RowFilter = "NIC<>'"+ mNIC +"'";
					dvNIC.RowStateFilter = DataViewRowState.OriginalRows;
				}
				if(dvNIC.Count > 0)
				{
					strErrorMessage = Error21;
					return false;
				}
				if(!mNICVUpto.Equals(""))
				{
					if(VD_IsDate(mNICVUpto))
					{
						return true;
					}
					else
					{
						strErrorMessage = Error23;
						return false;
					}
				}
				else
				{
					strErrorMessage = Error29;
					return false;
				}
			}
			else
			{
				strErrorMessage = Error20;
				return false;
			}
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


		/// <summary>
		/// Validation Method for validating Address
		/// </summary>
		/// <param name="mAddress">Address (string, 255)</param>
		/// <returns>Boolean</returns>
		private bool VD_Address(string mAddress)
		{
			return objValid.IsAddress(mAddress);
		}


		private bool VD_Passport(string mPassport, string mPassportValidUpto)
		{
			if(!mPassport.Equals(""))
			{
				if(mPassportValidUpto.Equals(""))
				{
					strErrorMessage = Error30;
					return false;
				}
				else
				{
					if(!VD_IsDate(mPassportValidUpto))
					{
						strErrorMessage = Error25;
						return false;
					}
					else
					{
						return true;
					}
				}
			}
			else
			{
				if(!mPassportValidUpto.Equals(""))
				{
					strErrorMessage = Error24;
					return false;
				}
				strErrorMessage = "";
				return true;
			}
		}
	}
}