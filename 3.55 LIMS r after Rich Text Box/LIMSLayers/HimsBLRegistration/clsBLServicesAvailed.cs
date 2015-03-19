using System;
using System.Data;
using System.Data.OleDb;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Management & Information System (HIMS)
	///		Class for	:	"ServicesAvailed" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	February 2005
	/// 	Type		:	Business Layer Class
	/// </summary>
	public class clsBLServicesAvailed
	{
		clsServicesAvailed objSAvailed = new clsServicesAvailed();
		clsoperation ObjTrans = new clsoperation();
		private string StrErrorMessage = null;

		public clsBLServicesAvailed()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ErrorMessage
		{
			get{	return StrErrorMessage;		}
			set{	StrErrorMessage = value;	}
		}

		private const string Error01 = "Entered Amount is invalid (+ve Integer number is allowed).";
		private const string Error02 = "Please enter comments (empty is not allowed).";

		public bool rsInsert(string mVisitNo, string mPatientID, string mDateTime, string mDepartmentID, string mClinicID, string mServiceID, string mDoctorID, string mAmount, string mComments)
		{
			try
			{
				Validation objValid = new Validation();

				if(!objValid.IsPositiveNumber(mAmount))
				{
					this.StrErrorMessage = Error01;
					return false;
				}

				if(mComments.Equals(""))
				{
					this.StrErrorMessage = Error02;
					return false;
				}

				objSAvailed.VisitNo = mVisitNo;
				objSAvailed.PatientID = mPatientID; 	
				objSAvailed.VisitDateTime = mDateTime; 
				objSAvailed.DepartmentID = mDepartmentID;
				objSAvailed.ClinicID = mClinicID;
				objSAvailed.ServiceID = mServiceID;
				objSAvailed.DoctorID = mDoctorID;
				objSAvailed.Amount = Int32.Parse(mAmount);
				objSAvailed.Comments = mComments;

				ObjTrans.Start_Transaction(); 
				this.StrErrorMessage = ObjTrans.DataTrigger_Insert(objSAvailed, clsoperation.Get_PKey.Yes);
				ObjTrans.End_Transaction(); 
					
				if (this.StrErrorMessage == "True") 
				{
					this.StrErrorMessage = ObjTrans.OperationError;
					return false;
				}

				return true;
			}
			catch(Exception e)
			{
				this.StrErrorMessage = e.Message;
				return false;
			}
		}
	}
}