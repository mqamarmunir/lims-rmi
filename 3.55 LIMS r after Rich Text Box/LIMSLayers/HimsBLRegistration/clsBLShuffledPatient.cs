using System;
using System.Data;  
using System.Threading;
using System.Globalization;
using HimsDlRegistration;

namespace HimsBLRegistration
{
	// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Shffled Patient" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	July 2004	
	/// 	Type		:	Business Layer Class
	/// </summary>
	///
	
	public class clsBLShuffledPatient
	{
		clsshuffledpatient ObjDLShuffledPatient = new clsshuffledpatient(); 
		clsoperation ObjTrans = new clsoperation(); 
		private string StrPKeyCode="";
		private string strErrorMessage = "";
		private const string Error001 ="Invalid value Of Hospital No";
		private const string Error002 = "Invalid value Of Assigner Doctor";
		private const string Error003 = "Invalid value Of Assgned Doctor";

		public clsBLShuffledPatient()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/* Property for Error Message*/

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}


		public bool rsInsert(string mHospitalNo, string mAssignerDoctorID, string mAssgnedDoctorID)
		{		
			try
			{

				if (VD_HospitalNo(mHospitalNo)==false)
				{
					return false;
				}

				if (VD_AssignerDoctorID(mAssignerDoctorID)==false)
					{
						return false;
					}

				if (VD_AssgnedDoctorID(mAssgnedDoctorID)==false)
				{
					return false;
				}

				ObjDLShuffledPatient.HOSPITALNO  = mHospitalNo;
				ObjDLShuffledPatient.ASSIGNERDOCTORID = mAssignerDoctorID;
				ObjDLShuffledPatient.ASSGNEDDOCTORID  = mAssgnedDoctorID;
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Insert(ObjDLShuffledPatient, clsoperation.Get_PKey.No);				
				ObjTrans.End_Transaction();
				if (strErrorMessage == "True") 
				{
					strErrorMessage = ObjTrans.OperationError;
					return false;
				}
				StrPKeyCode="";
				StrPKeyCode=ObjDLShuffledPatient.PKeycode;
				strErrorMessage="";
				return true;
			}
			catch(Exception ex)
			{	
				strErrorMessage=ex.Message.ToString();
				return false;
			};				  
		}

		public bool rsUpdate(string mHospitalNo, int mTransNo, string mAssignerDoctorID, string mAssgnedDoctorID)
		{		
			try
			{

				if (VD_HospitalNo(mHospitalNo)==false)
				{
					return false;
				}

				if (VD_AssignerDoctorID(mAssignerDoctorID)==false)
				{
					return false;
				}

				if (VD_AssgnedDoctorID(mAssgnedDoctorID)==false)
				{
					return false;
				}


				ObjDLShuffledPatient.HOSPITALNO  = mHospitalNo;
				ObjDLShuffledPatient.TRANSNO = mTransNo; 
				ObjDLShuffledPatient.ASSIGNERDOCTORID = mAssignerDoctorID;
				ObjDLShuffledPatient.ASSGNEDDOCTORID  = mAssgnedDoctorID;
				ObjTrans.Start_Transaction();
				strErrorMessage = ObjTrans.DataTrigger_Update(ObjDLShuffledPatient);				
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

		public bool rsDelete(string mHospitalNo, int mTransNo)
		{
			try
			{
				ObjDLShuffledPatient.HOSPITALNO  = mHospitalNo;
				ObjDLShuffledPatient.TRANSNO = mTransNo; 
				ObjTrans.Start_Transaction(); 
				strErrorMessage=ObjTrans.DataTrigger_Delete(ObjDLShuffledPatient); 
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

		public DataView rsGetAll()
		{
			ObjDLShuffledPatient.HOSPITALNO  = "";
			return ObjTrans.DataTrigger_Get_All(ObjDLShuffledPatient);
		}

		public DataView rsGetAll(string mHospitalNo)
		{
			ObjDLShuffledPatient.HOSPITALNO  = mHospitalNo;
			return ObjTrans.DataTrigger_Get_All(ObjDLShuffledPatient);
		}

		public DataView rsGetSingle(string mHospitalNo, int mTransNo)
		{
			ObjDLShuffledPatient.HOSPITALNO  = mHospitalNo;
			ObjDLShuffledPatient.TRANSNO = mTransNo; 
			return  ObjTrans.DataTrigger_Get_Single(ObjDLShuffledPatient);
		}


		private bool VD_HospitalNo(string mHospitalNo)
		{
			clsBLPatientVisit ObjBLPatientVisit = new clsBLPatientVisit();
			DataView mDataView = new DataView();
			mDataView=ObjBLPatientVisit.rsGetSingle(mHospitalNo.Trim());
			if (mDataView.Count==0)
			{
				strErrorMessage=Error001;
				return false;}
			else
			{return true;}
		}

		private bool VD_AssignerDoctorID(string mAssignerDoctorID)
		{
			clsBLDoctor ObjBLDoctor = new clsBLDoctor();
			DataView mDataView = new DataView();
			mDataView=ObjBLDoctor.rsGetSingle(mAssignerDoctorID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}

		private bool VD_AssgnedDoctorID(string mAssgnedDoctorID)
		{
			clsBLDoctor ObjBLDoctor = new clsBLDoctor();
			DataView mDataView = new DataView();
			mDataView=ObjBLDoctor.rsGetSingle(mAssgnedDoctorID);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error003;
				return false;}
			else
			{return true;}
		}



	}
}
