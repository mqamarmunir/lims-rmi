using System;
using System.Data;  
using System.Threading;
using System.Globalization;
using HimsDlRegistration;


namespace HimsBLRegistration
{
	
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Patient Visit" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	///

	public class clsBLPatientVisit
	{
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
		clspatientvisit ObjDLPatientVisit = new clspatientvisit(); 
		clsoperation ObjTrans = new clsoperation(); 
		private string StrPKeyCode="";
		private string strErrorMessage = "";
		private const string Error001 ="Invalid value Of Patient Type";
		private const string Error002 = "Invalid Employee";
		private const string Error003 = "Invalid value Of Dependent";
		private const string Error004 = "Invalid value Of Title";
		private const string Error005 = "Invalid value Of Patient First Name";
		private const string Error006 =	"Invalid Value Of Sex";
		private const string Error007 = "Invalid value Of Blood Groups";
		private const string Error008 =	"Invalid value Of Date of Birth"; 
		private const string Error009 =	"Invalid value Of Marital Status";
		private const string Error010 = "Invalid value Of Department";
		private const string Error011 = "Invalid value Of Clinic";
		private const string Error012 = "Invalid value Of Patient Condition";
		private const string Error013 = "Invalid value Of Treatment Status";
		private const string Error014 = "Invalid value Of Doctor";

		private const string Error015 = "Invalid value Of RMO";

		public clsBLPatientVisit()
		{

		}

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public string PKeycode
		{
			get
			{
				return StrPKeyCode;
			}
		}

		public bool rsInsert(string mPType, string mTitle, string mPFName, string mPMName,
			string mPLName, string mSex, string mBG, string mDob, string mAge, string mNic, string mMS, 
			string mHPhone, string mOPhone, string mEmail, string mAddress, string mEmployeeID,
			string mDependentID, string mDepartmentID, int mAdvAmount, string mClinicID,
			string mDoctorID, string mPCondition, string mTStatus,string mFollowUp)
		{		
			try
			{
				if (VD_PatientType(mPType)==false) 
				{						
					return false;
				};

				if (mPType=="ENT")
				{
					if (VD_EmployeeID(mEmployeeID)==false) 
					{						
						return false;
					};

					if (VD_DependentID(mEmployeeID, mDependentID)==false) 
					{						
						return false;
					};

				};

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				};

				if (VD_PFName(mPFName)==false) 
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
					}			
				}

				if (VD_MS(mMS)==false) 
				{						
					return false;
				}
				if(!VD_RMO(mDoctorID)){
					return false;
				}
				if (VD_DepartmentID(mDepartmentID)==false)
				{
						return false;
				}

				if (VD_ClinicID(mDepartmentID, mClinicID)==false)
				{
					return false;
				}

				if (mPCondition.Length>0)
				{ 
					if (VD_PatientCondition(mPCondition)==false) 
					{						
						return false;
					}			
				}

				if (mTStatus.Length>0)
				{ 
					if (VD_TStatus(mTStatus)==false) 
					{						
						return false;
					}			
				}

				if (mDoctorID.Length>0)
				{ 
					if (VD_DoctorID(mDoctorID)==false)
					{
						return false;
					}
				}

				ObjDLPatientVisit.PTYPE = mPType;
				ObjDLPatientVisit.TITLE = mTitle;
				ObjDLPatientVisit.PFNAME = mPFName;
				ObjDLPatientVisit.PMNAME = mPMName;
				ObjDLPatientVisit.PLNAME = mPLName;
				ObjDLPatientVisit.SEX = mSex;
				ObjDLPatientVisit.DOB = mDob;
				ObjDLPatientVisit.AGE = mAge;
				ObjDLPatientVisit.BG = mBG;				
				ObjDLPatientVisit.NIC = mNic;
				ObjDLPatientVisit.MS = mMS;
				ObjDLPatientVisit.HPHONE= mHPhone;
				ObjDLPatientVisit.OPHONE= mOPhone;
				ObjDLPatientVisit.EMAIL = mEmail;
				ObjDLPatientVisit.ADDRESS = mAddress;
				ObjDLPatientVisit.EMPLOYEEID = mEmployeeID;
				ObjDLPatientVisit.DEPENDENTID = mDependentID;
				ObjDLPatientVisit.DEPARTMENTID = mDepartmentID;
				ObjDLPatientVisit.ADVAMOUNT = mAdvAmount;	
				ObjDLPatientVisit.CLINICID = mClinicID;		
				ObjDLPatientVisit.DoctorID = mDoctorID;
				ObjDLPatientVisit.PCondition = mPCondition;
				ObjDLPatientVisit.TStatus = mTStatus;	
				ObjDLPatientVisit.FollowUp = mFollowUp;

				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLPatientVisit, clsoperation.Get_PKey.Yes);				
				ObjTrans.End_Transaction();
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}
				StrPKeyCode="";
				StrPKeyCode=ObjDLPatientVisit.PKeycode;
				strErrorMessage="";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage=ex.Message.ToString();
				return false;
			};				  
		}

		public bool rsUpdate(string mHospitalNo, string mPType, string mTitle, string mPFName,
			string mPMName, string mPLName, string mSex, string mBG, string mDob, string mAge,
			string mNic, string mMS, string mHPhone, string mOPhone, string mEmail, 
			string mAddress, string mEmployeeID, string mDependentID, string mDepartmentID,
			int mAdvAmount, string mClinicID, string mDoctorID, string mPCondition, string mTStatus)
		{		
			try
			{

				if (VD_PatientType(mPType)==false) 
				{						
					return false;
				}

				if (mPType=="ENT")
				{
					if (VD_EmployeeID(mEmployeeID)==false) 
					{						
						return false;
					}

					if (VD_DependentID(mEmployeeID, mDependentID)==false) 
					{						
						return false;
					}

				}

				if (VD_Title(mTitle)==false) 
				{						
					return false;
				}

				if (VD_PFName(mPFName)==false) 
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

				if (mDob.Length>0)
				{ 
					if (VD_Dob(mDob)==false) 
					{						
						return false;
					}			
				}

				if (VD_MS(mMS)==false) 
				{						
					return false;
				}

				if (VD_DepartmentID(mDepartmentID)==false)
				{
					return false;
				}

				if (VD_ClinicID(mDepartmentID, mClinicID)==false)
				{
					return false;
				}

				if (mPCondition.Length>0)
				{ 
					if (VD_PatientCondition(mPCondition)==false) 
					{						
						return false;
					}			
				}

				if (mTStatus.Length>0)
				{ 
					if (VD_TStatus(mTStatus)==false) 
					{						
						return false;
					}			
				}

				if (mDoctorID.Length>0)
				{ 
					if (VD_DoctorID(mDoctorID)==false)
					{
						return false;
					}
				}

				ObjDLPatientVisit.PKeycode = mHospitalNo;
				ObjDLPatientVisit.PTYPE = mPType;
				ObjDLPatientVisit.TITLE = mTitle;
				ObjDLPatientVisit.PFNAME = mPFName;
				ObjDLPatientVisit.PMNAME = mPMName;
				ObjDLPatientVisit.PLNAME = mPLName;
				ObjDLPatientVisit.SEX = mSex;
				ObjDLPatientVisit.DOB = mDob;
				ObjDLPatientVisit.AGE = mAge;
				ObjDLPatientVisit.BG = mBG;				
				ObjDLPatientVisit.NIC = mNic;
				ObjDLPatientVisit.MS = mMS;
				ObjDLPatientVisit.HPHONE= mHPhone;
				ObjDLPatientVisit.OPHONE= mOPhone;
				ObjDLPatientVisit.EMAIL = mEmail;
				ObjDLPatientVisit.ADDRESS = mAddress;
				ObjDLPatientVisit.EMPLOYEEID = mEmployeeID;
				ObjDLPatientVisit.DEPENDENTID = mDependentID;
				ObjDLPatientVisit.DEPARTMENTID = mDepartmentID;
				ObjDLPatientVisit.ADVAMOUNT = mAdvAmount;							
				ObjDLPatientVisit.CLINICID = mClinicID;		
				ObjDLPatientVisit.DoctorID = mDoctorID;
				ObjDLPatientVisit.PCondition = mPCondition;
				ObjDLPatientVisit.TStatus = mTStatus;
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLPatientVisit);				
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

		public bool rsDelete(string mHospitalNo)
		{
			try
			{
				ObjDLPatientVisit.PKeycode=mHospitalNo; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLPatientVisit); 
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
		/// Get All Records Method from "tPatientVisit" Table
		/// </summary>
		/// <param name="mVisitNo">Visit Number (string, 10)</param>
		/// <param name="mPatientID">Patient ID (string, 11)</param>
		/// <param name="mVisitDateTime">Visit Date Time (string, 10)</param>
		/// <param name="mClinicID">Clinic ID (stirng, 3)</param>
		/// <param name="mPCondition">Patient Condition (string, 10)</param>		
		/// <param name="mNIC">NIC (string, 20)</param>
		/// <param name="mName">Patient Name (string, 66)</param>
		/// <param name="mAddress">Address (string, 255)</param>		
		/// <param name="mPatientType">Patient Type (string, 1)</param>
		/// <param name="mSex">Sex (string, 1)</param>
		/// <param name="mBloodGroup">Blood Group (stirng, 3)</param>
		/// <param name="mMaritalStatus">Marital Status (string, 1)</param>
		/// <param name="DepartmentID" >DepartmentID (string, 4)</param>
		/// <returns>Data View</returns>
		public DataView rsGetAll(string mVisitNo, string mPatientID, string mVisitDateTime, string mClinicID, string mPCondition, string mNIC, string mName, string mAddress, string mPatientType, string mSex, string mBloodGroup, string mMaritalStatus, string mDepartmentID, string mPLNo, string mLetterInfo)
		{
			clsTPatientVisit objTPVisit = new clsTPatientVisit();
			objTPVisit.PKeycode = mVisitNo; 
			objTPVisit.PatientID  = mPatientID; 
			objTPVisit.VisitDateTime = mVisitDateTime;
			objTPVisit.ClinicID = mClinicID;
			objTPVisit.PCondition = mPCondition;			
			objTPVisit.NIC = mNIC;
			objTPVisit.Name = mName;
			objTPVisit.Address = mAddress;			
			objTPVisit.PatientType = mPatientType;
			objTPVisit.Sex = mSex;
			objTPVisit.BloodGroup = mBloodGroup;
			objTPVisit.MS = mMaritalStatus;
			objTPVisit.DepartmentID = mDepartmentID;
			objTPVisit.PLNo = mPLNo;
			objTPVisit.LetterInfo = mLetterInfo;
			
			return ObjTrans.DataTrigger_Get_All(objTPVisit);
		}

		public DataView rsGetAll(string mVisitDT, string mDepartmentID, string mClinicID)
		{
			DataView mDataView = new DataView();
			mDataView=rsGetAll("","", mVisitDT, mClinicID, "", "", "", "", "", "", "", "", mDepartmentID, "", "");
			return mDataView;
		}


		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mVisitNo)
		{
			clsTPatientVisit objTPVisit = new clsTPatientVisit();
			objTPVisit.PKeycode = mVisitNo; 
			return  ObjTrans.DataTrigger_Get_Single(objTPVisit);
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
					strErrorMessage=Error006;
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

		private bool VD_PatientType(string mPatientType)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.PatientTypes();
				{mDataView.RowFilter ="PatientType='" + mPatientType + "'";}
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

		private bool VD_Dob(string mDob)
		{
			ObjDateFormat.DateTimeFormat.ShortDatePattern ="dd/MM/yyyy"; 
			System.Threading.Thread.CurrentThread.CurrentCulture = ObjDateFormat;
			try
			{
				System.DateTime.Parse(mDob);
				return true;
			}  
			catch(Exception)
			{
				strErrorMessage=Error008;
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
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}

		private bool VD_DependentID(string mEmployeeID, string mDependentID)
		{
			clsBLDependent ObjBLDependent = new clsBLDependent();
			DataView mDataView = new DataView();
			mDataView=ObjBLDependent.rsGetSingle(mEmployeeID, mDependentID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
		}

		private bool VD_DepartmentID(string mDepartmentID)
		{
			clsBLDepartment ObjBLDepartment = new clsBLDepartment();
			DataView mDataView = new DataView();
			mDataView=ObjBLDepartment.rsGetSingle(mDepartmentID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error010;
				return false;}
			else
			{return true;}
		}

		private bool VD_ClinicID(string mDepartmentID, string mClinicID)
		{
			clsBLClinic ObjBLClinic = new clsBLClinic();
			DataView mDataView = new DataView();
			mDataView=ObjBLClinic.rsGetSingle(mDepartmentID, mClinicID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error011;
				return false;}
			else
			{return true;}
		}

		private bool VD_PFName(string mPFName)
		{
			if (mPFName=="") 
			{
				strErrorMessage=Error005;
				return false;
			}
			else
				return true;
		}

		private bool VD_PatientCondition(string mPCondition)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.PatientCondition(); 
				{mDataView.RowFilter ="PCCode='" + mPCondition + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error012;
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

		private bool VD_TStatus(string mTStatus)
		{
			try
			{
				DataView mDataView = new DataView();
				clsGeneralCollections ObjGeneralCollections = new clsGeneralCollections();
				mDataView=ObjGeneralCollections.TStatus(); 
				{mDataView.RowFilter ="TSCode='" + mTStatus + "'";}
				if (mDataView.Count==0)
				{
					strErrorMessage=Error013;
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

		private bool VD_DoctorID(string mDoctorID)
		{
			clsBLDoctor ObjBLDoctor = new clsBLDoctor();
			DataView mDataView = new DataView();
			mDataView=ObjBLDoctor.rsGetSingle(mDoctorID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error014;
				return false;}
			else
			{return true;}
		}
		
		private bool VD_RMO(string mDoctorID){
			if(mDoctorID.Equals("-1"))
			{	
				strErrorMessage = Error015;
				return false;
			}
			else
			{
				return true;
			}
		}

	}
}
