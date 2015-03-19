using System;
using System.Data;  
using HimsDlRegistration;
using System.Data.OleDb;

namespace HimsBLRegistration
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Patient Visit Comments" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	Juns 2004 - Wah Site Office	
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 

	public class clsBLPVComment
	{

		clspvcomment ObjDLPVComment = new clspvcomment(); 
		clsoperation ObjTrans = new clsoperation();

		private string strErrorMessage = "";
		private const string Error001 ="Invalid Hospital No";
		private const string Error002 ="Invalid Value of Comments";


		public clsBLPVComment()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string ErrorMessage
		{
			get
			{
				return strErrorMessage;
			}
		}

		public bool rsUpdate(string mHospitalNo, string mComments)
		{
			try
			{		

				if (VD_HospitalNo(mHospitalNo)==false) 
				{						
					return false;
				};

				if (VD_PVComment(mComments)==false) 
				{						
					return false;
				};

				ObjDLPVComment.PKeycode = mHospitalNo;
				ObjDLPVComment.Comments = mComments;
 				ObjTrans.Start_Transaction(); 		
				strErrorMessage= ObjTrans.DataTrigger_Update(ObjDLPVComment);
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

		public DataView rsGetAll()
		{
			return ObjTrans.DataTrigger_Get_All(ObjDLPVComment);
		}

		/// <summary>
		///		Return Single Record - Paramater Application ID - Return type DataView
		/// </summary>

		public DataView rsGetSingle(string mHospitalNo)
		{
			ObjDLPVComment.PKeycode = mHospitalNo;
			return  ObjTrans.DataTrigger_Get_Single(ObjDLPVComment);
		}

		private bool VD_HospitalNo(string mHospitalNo)
		{
			clsBLPatientVisit ObjBLPatientVisit = new clsBLPatientVisit();
			DataView mDataView = new DataView();
			mDataView=ObjBLPatientVisit.rsGetSingle(mHospitalNo);
			if (mDataView.Count==0)
			{
				strErrorMessage=Error001;
				return false;}
			else
			{return true;}
		}

		private bool VD_PVComment(string mPVComment)
		{
			if (mPVComment.Length==0)
			{
				strErrorMessage=Error002;
				return false;}
			else
			{return true;}
		}


	}
}
