using System;
using System.Data;  
using System.Threading;
using System.Globalization;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	/// Summary description for clsBLTPatientVisit.
	/// </summary>
	public class clsBLTPVRegistration
	{
		System.Globalization.CultureInfo ObjDateFormat = new CultureInfo("ur-PK");
		clspatientvisit ObjDLPatientVisit = new clspatientvisit(); 
		clsoperation ObjTrans = new clsoperation(); 
		Validation objValid = new Validation();

		private string StrPKeyCode = "";
		private string strErrorMessage = "";
		private string visitNo = "";
		private string StrAlreadyVisited = "";

		private const string Error001 ="Invalid value Of Patient Type";
		private const string Error002 = "Invalid Employee";
		private const string Error003 = "Invalid value Of Dependent";
		private const string Error004 = "Invalid value Of Title";
		private const string Error005 = "Patient First Name is not Entered";
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
		private const string Error016 ="You Cannot Update Patient Info \n if you are trying to add new one \n use clear all and then try again";
		private const string Error017 = "Invalid Value Of Advance Amount";
		private const string Error018 = "Advance amount must be Number";
		private const string Error019 = "No Data Selected";
		private const string Error020 = "Invalid value of Department";
		private const string Error021 = "Invalid Email Address";
		private const string Error022 = "Invalid value of Patient First Name";
		private const string Error023 = "Invalid value of Patient Middle Name";
		private const string Error024 = "Invalid value of Patient Last Name";
		private const string Error025 = "Entered Amount is invalid (+ve Integer number is allowed).";
		private const string Error026 = "Please enter comments (empty is not allowed).";
		private const string Error027 = "Selected patient has already routed to selected department today, if want to proceed click upon Save button again.";
		

		public clsBLTPVRegistration()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string VisitNo
		{
			get{	return visitNo;		}
			set{	visitNo = value;	}
		}

		public string ErrorMessage
		{
			get{	return strErrorMessage;	}
		}

		public string PKeycode
		{
			get{	return StrPKeyCode;	}
		}

		public string AVisited
		{
			get{	return StrAlreadyVisited;	}
			set{	StrAlreadyVisited = value;	}
		}
	
		private bool AllowOnly(string mAllowOnly, string mValue)
		{
			mAllowOnly = mAllowOnly.ToLower();

			if(mAllowOnly.Equals("int"))
			{
				try
				{
					Double.Parse(mValue);
					return true;
				}
				catch{	return false;	}
			}

			return true;
		}

		private bool Validate(string mType, string mValue, bool mEmptyAllowed)
		{
			mType = mType.ToLower();

			if(mType.Equals("dropdownlist"))
			{
				if(mValue.Equals("-1"))
				{
					return false;
				}
			}
			else if(mType.Equals("textbox") || mType.Equals("textfield"))
			{
				if(!mEmptyAllowed)
				{
					if(mValue.Equals(""))
					{
						return false;
					}
				}
			}

			return true;
		}

		public string rsInsert(string mTitle, string mPFName, string mPMName, string mPLName, string mSex, string mDOB, string mBloodgroup, string mMS, string mNIC, string mPictureRef, string mAddress, string mCellPhone, string mPhone1, string mPhone2, string mFax, string mEmail, string mRegisteredBy, string mLastVisitNo, string pType, string advAmount, string clinicId, string pCondition, string tStatus, string followUp, string doctorId, string mPatientId, string mIdToConfirm, string mDepartment, string mAmount, string mServiceID, string mComments, string mRelation, string mLetterInfo, string mGovtDiscount)
		{
			try
			{
				if(!mAmount.Equals(""))
				{
					if(!objValid.IsPositiveNumber(mAmount))
					{
						this.strErrorMessage = Error025;
						return "-1";
					}
				}
				else
				{
					mAmount = "0";
				}

				if(!Validate("DropDownList", mTitle, false))
				{
					this.strErrorMessage = Error004;
					return "-1";
				}
				
				if(mPFName.Equals(""))
				{
					this.strErrorMessage = Error005;
					return "-1";
				}
				else if(!VD_Name(mPFName))
				{
					this.strErrorMessage = Error022;
					return "-1";
				}

				if(!mPMName.Equals(""))
				{
					if(!VD_Name(mPMName))
					{
						this.strErrorMessage = Error023;
						return "-1";
					}
				}

				if(!mPLName.Equals(""))
				{
					if(!VD_Name(mPLName))
					{
						this.strErrorMessage = Error024;
						return "-1";
					}
				}

				if(!Validate("textbox", mSex, false))
				{
					this.strErrorMessage = Error006;
					return "-1";
				}

				if(!mDOB.Equals(""))
				{
					if(!VD_Date(mDOB))
					{
						this.strErrorMessage = Error008;
						return "-1";
					}
				}				

				if(!Validate("DropDownList", mBloodgroup, false))
				{
					this.strErrorMessage = Error007;
					return "-1";
				}

				if(!Validate("DropDownList", mMS, false))
				{
					this.strErrorMessage = Error009;
					return "-1";
				}

				if(!Validate("DropDownList", pCondition, false))
				{
					this.strErrorMessage = Error012;
					return "-1";
				}

				if(!Validate("DropDownList", doctorId, false))
				{
					this.strErrorMessage = Error015;
					return "-1";
				}

				if(!Validate("DropDownList", mDepartment, false))
				{
					this.strErrorMessage = Error020;
					return "-1";
				}

				if(!mEmail.Equals(""))
				{
					if(!objValid.IsEmail(mEmail))
					{
						strErrorMessage = Error021;
						return "-1";
					}
				}

				if(mComments.Equals(""))
				{
					this.strErrorMessage = Error026;
					return "-1";
				}

				if(!StrAlreadyVisited.Equals("N"))
				{
					if(!AlreadyVisited(mDepartment, mPatientId))
					{
						this.strErrorMessage = Error027;
						return "-1";
					}
				}
				
				string localAdvAmount ;

				if(advAmount != "")
					localAdvAmount = advAmount;
			
				bool isNewRegistration = false;

				if(mPatientId == "" && mIdToConfirm == "")
					isNewRegistration = true;

				ObjTrans.Start_Transaction();

				if(isNewRegistration)
				{
					clstpvregistration objpvregistration = new clstpvregistration();
					objpvregistration.TITLE =mTitle ;
					objpvregistration.PFNAME=mPFName;
					objpvregistration.PMNAME = mPMName;
					objpvregistration.PLNAME = mPLName;
					objpvregistration.SEX = mSex;
					objpvregistration.DOB = mDOB;
					objpvregistration.BLOODGROUP = mBloodgroup.Trim();
					objpvregistration.MS = mMS;
					objpvregistration.NIC = mNIC;
					objpvregistration.PictureReference = mPictureRef;
					objpvregistration.ADDRESS = mAddress;
					objpvregistration.CellPhone = mCellPhone;
					objpvregistration.Phone1 = mPhone1;
					objpvregistration.Phone2 = mPhone2;
					objpvregistration.EMAIL = mEmail;
					objpvregistration.RegisteredBy = mRegisteredBy;
					objpvregistration.LastVistNo = mLastVisitNo;
					objpvregistration.Fax = mFax;
					objpvregistration.PTYPE = pType;
					objpvregistration.Relation = mRelation;
						
					strErrorMessage = ObjTrans.DataTrigger_Insert(objpvregistration, clsoperation.Get_PKey.Yes);				

					if(strErrorMessage == "True") 
					{
						strErrorMessage = ObjTrans.OperationError;
					}
						
					StrPKeyCode = "";
					StrPKeyCode = objpvregistration.PKeycode;
					mPatientId = StrPKeyCode;
					strErrorMessage="";
				}

				clsTPatientVisit objtpatientvisit = new clsTPatientVisit();
				objtpatientvisit.PatientID = mPatientId;
				objtpatientvisit.AdvAmount = advAmount;
				objtpatientvisit.ClinicID = clinicId;
				objtpatientvisit.PCondition = pCondition;
				objtpatientvisit.TStatus = tStatus;
				objtpatientvisit.FollowUp = followUp;
				objtpatientvisit.EnteredBy = mRegisteredBy;
				objtpatientvisit.DoctorID = doctorId;
				objtpatientvisit.LetterInfo = mLetterInfo;
				
				strErrorMessage = ObjTrans.DataTrigger_Insert(objtpatientvisit, clsoperation.Get_PKey.Yes);

				if(strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return "-1";
				}
				else
				{
					clsServicesAvailed objSAvailed= new clsServicesAvailed();

					visitNo = objtpatientvisit.PKeycode;
					objSAvailed.VisitNo = visitNo;
					objSAvailed.PatientID = mPatientId;
					objSAvailed.VisitDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
					objSAvailed.DepartmentID = mDepartment;
					objSAvailed.ClinicID = clinicId;
					objSAvailed.ServiceID = mServiceID;
					objSAvailed.DoctorID = doctorId;
					objSAvailed.Amount = Int32.Parse(mAmount);
					objSAvailed.ShowedUp = "N";
					objSAvailed.Comments = mComments;
					objSAvailed.GovtDiscount = Int32.Parse(mGovtDiscount);

					strErrorMessage = ObjTrans.DataTrigger_Insert(objSAvailed, clsoperation.Get_PKey.Yes);

					if(strErrorMessage == "True") 
					{
						strErrorMessage = ObjTrans.OperationError;
						return "-1";
					}
					else
					{
						this.StrPKeyCode = objSAvailed.PKeycode;
					}
				}

				ObjTrans.End_Transaction();
				return mPatientId;
			
			}			
			catch(Exception ex)
			{
				strErrorMessage = ex.Message;
				return "-1";
			}	
		}
		
		public string rsInsert(string mTitle, string mPFName, string mPMName, string mPLName, string mSex, string mDOB, string mBloodgroup, string mMS, string mNIC, string mPictureRef, string mAddress, string mCellPhone, string mPhone1, string mPhone2, string mFax, string mEmail, string mRegisteredBy, string mLastVisitNo, string pType, string advAmount, string clinicId, string pCondition, string tStatus, string followUp, string doctorId, string mDependentId, string mPatientId, bool isNewRegistration, string mDepartment, string mAmount, string mServiceID, string mComments, string mGovtDiscount)
		{
			try
			{
				if(!mAmount.Equals(""))
				{
					if(!objValid.IsPositiveNumber(mAmount))
					{
						this.strErrorMessage = Error025;
						return "-1";
					}
				}
				else
				{
					mAmount = "0";
				}

				if(!Validate("DropDownList", mTitle, false))
				{
					this.strErrorMessage = Error019;
					return "-1";
				}

				if(mPFName.Equals(""))
				{
					this.strErrorMessage = Error005;
					return "-1";
				}
				else if(!VD_Name(mPFName))
				{
					this.strErrorMessage = Error022;
					return "-1";
				}

				if(!mPMName.Equals(""))
				{
					if(!VD_Name(mPMName))
					{
						this.strErrorMessage = Error023;
						return "-1";
					}
				}

				if(!mPLName.Equals(""))
				{
					if(!VD_Name(mPLName))
					{
						this.strErrorMessage = Error024;
						return "-1";
					}
				}

				if(!mDOB.Equals(""))
				{
					if(!VD_Date(mDOB))
					{
						this.strErrorMessage = Error008;
						return "-1";
					}
				}

				if(!Validate("DropDownList", pCondition, false))
				{
					this.strErrorMessage = Error012;
					return "-1";
				}

				if(!Validate("DropDownList", doctorId, false))
				{
					this.strErrorMessage = Error015;
					return "-1";
				}

				if(!Validate("DropDownList", mDepartment, false))
				{
					this.strErrorMessage = Error020;
					return "-1";
				}

				if(!Validate("DropDownList", clinicId, false))
				{
					this.strErrorMessage = Error011;
					return "-1";
				}

				if(!mEmail.Equals(""))
				{
					if(!objValid.IsEmail(mEmail))
					{
						strErrorMessage = Error021;
						return "-1";
					}
				}

				if(mComments.Equals(""))
				{
					this.strErrorMessage = Error026;
					return "-1";
				}

				if(!StrAlreadyVisited.Equals("N"))
				{
					if(!AlreadyVisited(mDepartment, mPatientId))
					{
						this.strErrorMessage = Error027;
						return "-1";
					}
				}

				ObjTrans.Start_Transaction();
				
				if(isNewRegistration)
				{
					clstpvregistration objpvregistration = new clstpvregistration();

					objpvregistration.TITLE =mTitle;
					objpvregistration.PFNAME=mPFName;
					objpvregistration.PMNAME = mPMName;
					objpvregistration.PLNAME = mPLName;
					objpvregistration.SEX = mSex;
					objpvregistration.DOB = mDOB;
					objpvregistration.BLOODGROUP = mBloodgroup.Trim();
					objpvregistration.MS = mMS;
					objpvregistration.NIC = mNIC;
					objpvregistration.PictureReference = mPictureRef;
					objpvregistration.ADDRESS = mAddress;
					objpvregistration.CellPhone = mCellPhone;
					objpvregistration.Phone1 = mPhone1;
					objpvregistration.Phone2 = mPhone2;
					objpvregistration.EMAIL = mEmail;
					objpvregistration.RegisteredBy = mRegisteredBy;
					objpvregistration.LastVistNo = mLastVisitNo;
					objpvregistration.Fax = mFax;
					objpvregistration.PTYPE = pType;
					objpvregistration.Relation = "";

					strErrorMessage = ObjTrans.DataTrigger_Insert(objpvregistration, clsoperation.Get_PKey.Yes);				

					if(strErrorMessage == "True") 
					{
						strErrorMessage = ObjTrans.OperationError;
						return "-1";
					}
						
					StrPKeyCode = "";
					StrPKeyCode = objpvregistration.PKeycode;
					mPatientId = StrPKeyCode;

					//-------this part deals with update in dependent table
					clsdependent objDependent = new clsdependent();
					objDependent.Update_PatientId(mDependentId,mPatientId,ObjTrans.GetConnection,ObjTrans.DBTransaction);
					strErrorMessage="";
				}

				clsTPatientVisit objtpatientvisit = new clsTPatientVisit();
				objtpatientvisit.PatientID = mPatientId;
				objtpatientvisit.AdvAmount = advAmount;
				objtpatientvisit.ClinicID = clinicId;
				objtpatientvisit.PCondition = pCondition;
				objtpatientvisit.TStatus = tStatus;
				objtpatientvisit.FollowUp = followUp;
				objtpatientvisit.EnteredBy = mRegisteredBy;
				objtpatientvisit.DoctorID = doctorId;
				objtpatientvisit.LetterInfo = "";

				strErrorMessage = ObjTrans.DataTrigger_Insert(objtpatientvisit, clsoperation.Get_PKey.Yes);

				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return "-1";
				}
				else
				{
					clsServicesAvailed objSAvailed= new clsServicesAvailed();

					visitNo = objtpatientvisit.PKeycode;
					objSAvailed.VisitNo = visitNo;
					objSAvailed.PatientID = mPatientId;
					objSAvailed.VisitDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
					objSAvailed.DepartmentID = mDepartment;
					objSAvailed.ClinicID = clinicId;
					objSAvailed.ServiceID = mServiceID;
					objSAvailed.DoctorID = doctorId;
					objSAvailed.Amount = Int32.Parse(mAmount);
					objSAvailed.ShowedUp = "N";
					objSAvailed.Comments = mComments;
					objSAvailed.GovtDiscount = Int32.Parse(mGovtDiscount);

					strErrorMessage = ObjTrans.DataTrigger_Insert(objSAvailed, clsoperation.Get_PKey.Yes);

					if(strErrorMessage == "True") 
					{
						strErrorMessage = ObjTrans.OperationError;
						mPatientId = "-1";
					}
					else
					{
						this.StrPKeyCode = objSAvailed.PKeycode;
					}
				}

				ObjTrans.End_Transaction();
				
				return mPatientId;
			
			}
			catch(Exception ex)
			{
				strErrorMessage = ex.Message;
				return "-1";
			}
		}


		public DataView rsGetSingle(string mPatientId)
		{	
			DataView mDataView = new DataView();
			clstpvregistration objtpvregistration = new clstpvregistration();	
			objtpvregistration.PKeycode = mPatientId;
			mDataView = ObjTrans.DataTrigger_Get_Single(objtpvregistration);
				
			return mDataView; 
		}


		private bool VD_Name(string mName)
		{
			if(objValid.IsAlpha(mName))
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		private bool VD_Date(string strDate)
		{
			if(objValid.IsDate(strDate))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private bool AlreadyVisited(string strDepartmentID, string strPatientID)
		{
			if(!strPatientID.Equals(""))
			{
				clsBLPatientVisit objPVisit = new clsBLPatientVisit();
				DataView dvPVisit = objPVisit.rsGetAll("", strPatientID, DateTime.Now.ToString("dd/MM/yyyy"), "", "", "", "", "", "", "", "", "", strDepartmentID, "", "");

				if(dvPVisit.Count > 0)
				{
					StrAlreadyVisited = "Y";
					return false;
				}
			}

			return true;
		}
	}
}