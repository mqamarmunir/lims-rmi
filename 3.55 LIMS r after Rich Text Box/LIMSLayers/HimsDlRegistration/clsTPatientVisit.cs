using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsTPatientVisit.
	/// </summary>
	public class clsTPatientVisit:Iinterface
	{
		public clsTPatientVisit()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variable Declaration"
		
		clsdatadefinition.StoredProcedure SP;

		#endregion


		#region "Variable Declarations"

		private string strData;
		private string strVisitNo;
		private string strPatientID;
		private string strVisitDateTime;
		private string strAdvAmount;
		private string strClinicID;
		private string strPCondition;
		private string strTStatus;
		private string strFollowUp;
		private string strEnteredBy;
		private string strDoctorID;		
		private string StrNIC;
		private string StrName;
		private string StrAddress;
		private string StrPatientType;
		private string StrSex;
		private string StrBloodGroup;
		private string StrMaritalStatus;
		private string StrDepartmentID;
		private string StrPLNo;
		private string StrLetterInfo;

		#endregion


		#region "Properties"
		
		/// <summary>
		/// Visit Number - Primary Key
		/// </summary>
		public string PKeycode
		{
			get{	return strVisitNo;	}
			set{	strVisitNo = value;	}
		}

		/// <summary>
		/// Patient ID - Table Field
		/// </summary>
		public string PatientID
		{
			get{	return strPatientID;	}
			set{	strPatientID = value;	}
		}

		/// <summary>
		/// Visit Date Time - Table Field
		/// </summary>
		public string VisitDateTime
		{
			get{	return strVisitDateTime;	}
			set{	strVisitDateTime = value;	}
		}

		/// <summary>
		/// Advance Amount - Table Field
		/// </summary>
		public string AdvAmount
		{
			get{	return strAdvAmount;	}
			set{	strAdvAmount = value;	}
		}

		/// <summary>
		/// Clinic ID - Table Field
		/// </summary>
		public string ClinicID
		{
			get{	return strClinicID;		}
			set{	strClinicID = value;	}
		}

		/// <summary>
		/// Patient Condition - Table Field
		/// </summary>
		public string PCondition
		{
			get{	return strPCondition;	}
			set{	strPCondition = value;	}
		}

		/// <summary>
		/// 
		/// </summary>
		public string TStatus
		{
			get{	return strTStatus;	}
			set{	strTStatus = value;	}
		}

		/// <summary>
		/// Follow Up - Table Field
		/// </summary>
		public string FollowUp
		{
			get{	return strFollowUp;		}
			set{	strFollowUp = value;	}
		}

		/// <summary>
		/// Entered By - Table Field
		/// </summary>
		public string EnteredBy
		{
			get{	return strEnteredBy;	}
			set{	strEnteredBy = value;	}
		}

		/// <summary>
		/// Doctor ID - Table Field
		/// </summary>
		public string DoctorID
		{
			get{	return strDoctorID;		}
			set{	strDoctorID = value;	}
		}

		/// <summary>
		/// National Identity Card Number - Needed in Searching, retrived from "tPatientRegistration" Table
		/// </summary>
		public string NIC
		{
			get{	return StrNIC;	}
			set{	StrNIC = value;	}
		}

		/// <summary>
		/// Patient Name - Needed in searching, retrived from "tPatientRegistration" Table
		/// </summary>
		public string Name
		{
			get{	return StrName;		}
			set{	StrName = value;	}
		}

		/// <summary>
		/// Address - Needed in searching, retrieved from "tPatientRegistration" Table
		/// </summary>
		public string Address
		{
			get{	return StrAddress;	}
			set{	StrAddress = value;	}
		}

		/// <summary>
		/// Patient Type - Needed in searching, retrieved from "tPatientRegistration" Table through "PatientID" 
		/// Field
		/// </summary>
		public string PatientType
		{
			get{	return StrPatientType;	}
			set{	StrPatientType = value;	}
		}

		/// <summary>
		/// Sex - Needed in searching, retrieved from "tPatientRegistration" Table
		/// </summary>
		public string Sex
		{
			get{	return StrSex;	}
			set{	StrSex = value;	}
		}

		/// <summary>
		/// BloodGroup - Needed in searching, retrived from "tPtientRegistration" Table
		/// </summary>
		public string BloodGroup
		{
			get{	return StrBloodGroup;	}
			set{	StrBloodGroup = value;	}
		}

		/// <summary>
		/// Marital Status - Needed in searching, retrived from "tPatientRegistration" Table
		/// </summary>
		public string MS
		{
			get{	return StrMaritalStatus;	}
			set{	StrMaritalStatus = value;	}
		}

		/// <summary>
		/// Departmetn ID - Needed in searching, retrieved from "Clinic" Table
		/// </summary>
		public string DepartmentID
		{
			get{	return StrDepartmentID;		}
			set{	StrDepartmentID = value;	}
		}

		/// <summary>
		/// PL No - Needed in searching, retrieved from "Dependent" Table
		/// </summary>
		public string PLNo
		{
			get{	return StrPLNo;		}
			set{	StrPLNo = value;	}
		}

		public string LetterInfo
		{
			get{	return StrLetterInfo;	}
			set{	StrLetterInfo = value;	}
		}

		#endregion


		#region "Data_Methods"
		
		/// <summary>
		/// Record Insertion Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Insert()
		{
			// get Stored procedure name for Insert record in tPatientVisit table
			SP.TPATIENTVISIT = (clsdatadefinition.SPTPatientVisit)1;	// 1 is used for get insert stored procedure name
			strData = SP.TPATIENTVISIT.ToString().Replace("3", ".");

			OleDbCommand objCommand = new OleDbCommand();
			objCommand.CommandText = strData;
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 10, ParameterDirection.Output,false, 0, 0,"VisitNo", DataRowVersion.Default, null));
			objCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

			objCommand.Parameters.Add(new OleDbParameter("@MPatientID", OleDbType.VarChar, 11, "patientID"));	
			objCommand.Parameters.Add(new OleDbParameter("@MAdvAmount", OleDbType.VarChar, 4, "AdvAmount"));
			objCommand.Parameters.Add(new OleDbParameter("@MClinicID", OleDbType.VarChar, 10, "ClinicID"));
			objCommand.Parameters.Add(new OleDbParameter("@MPCondition", OleDbType.VarChar, 10, "PCondition"));
			objCommand.Parameters.Add(new OleDbParameter("@MTStatus", OleDbType.VarChar, 10, "TStatus"));
			objCommand.Parameters.Add(new OleDbParameter("@MFollowUp", OleDbType.VarChar, 10, "FollowUp"));
			objCommand.Parameters.Add(new OleDbParameter("@MEnteredBy", OleDbType.VarChar, 10, "EnteredBy"));
			objCommand.Parameters.Add(new OleDbParameter("@MDoctorID", OleDbType.VarChar, 10, "DoctorID"));
			objCommand.Parameters.Add(new OleDbParameter("@MLetterInfo", OleDbType.VarChar, 20, "LetterInfo"));

			objCommand.Parameters["@MPatientID"].Value = strPatientID;
			objCommand.Parameters["@MAdvAmount"].Value = strAdvAmount;
			objCommand.Parameters["@MClinicID"].Value = strClinicID;
			objCommand.Parameters["@MPCondition"].Value = strPCondition;
			objCommand.Parameters["@MTStatus"].Value = strTStatus;
			objCommand.Parameters["@MFollowUp"].Value = strFollowUp;
			objCommand.Parameters["@MEnteredBy"].Value = strEnteredBy;
			objCommand.Parameters["@MDoctorID"].Value = strDoctorID;
			objCommand.Parameters["@MLetterInfo"].Value = StrLetterInfo;

			return objCommand;
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Update()
		{
		/*	// get Stored procedure name for Update record in tPatientVisit table
			SP.TPATIENTVISIT = (clsdatadefinition.SPTPatientVisit)2; // 2 is used for get update stored procedure name
			strData = SP.TPATIENTVISIT.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDependentID", OleDbType.VarChar, 5, "DesignationID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationName", OleDbType.VarChar, 30,"DesignationName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationType", OleDbType.VarChar, 2, "DesignationType"));

			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			ObjCommand.Parameters["@MDesignationName"].Value = strDesignationName;
			ObjCommand.Parameters["@MActive"].Value = strActive;
			ObjCommand.Parameters["@MAcronym"].Value = strAcronym;
			ObjCommand.Parameters["@MDesignationType"].Value = strDesignationType;
		
			return ObjCommand;*/	return null;
		}


		/// <summary>
		/// Record Deletion Method
		/// </summary>
		/// <returns></returns>
		public OleDbCommand Delete()
		{
/*			// get Stored procedure name for Delete record in tDesignation table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)3;	//3 is used for get delete stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5, "DesignationID"));
			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
		
			return ObjCommand;		*/		return null;
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in "tPatientVisit" table
			SP.TPATIENTVISIT = (clsdatadefinition.SPTPatientVisit)4;	//4 is used for get search all stored procedure name
			strData = SP.TPATIENTVISIT.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			ObjCommand.Parameters.Add(new OleDbParameter("@MVISITNO", OleDbType.VarChar, 10, "VISITNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTID", OleDbType.VarChar, 11, "PATIENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MVISITDATE", OleDbType.VarChar, 10, "VISITDATETIME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID", OleDbType.VarChar, 3, "CLINICID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTCONDITION",OleDbType.VarChar,10,"PCONDITION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNICNO", OleDbType.VarChar, 20, "NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNAME", OleDbType.VarChar, 66, "PVNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS", OleDbType.VarChar, 255, "ADDRESS"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTTYPE", OleDbType.VarChar, 11, "PATIENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX", OleDbType.VarChar, 1, "SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBLOODGROUP", OleDbType.VarChar, 3, "BLOODGROUP"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS", OleDbType.VarChar, 1, "MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID", OleDbType.VarChar, 4, "DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNO", OleDbType.VarChar, 10, "PLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLetterInfo", OleDbType.VarChar, 20, "LetterInfo"));

			ObjCommand.Parameters["@MVISITNO"].Value = strVisitNo;
			ObjCommand.Parameters["@MPATIENTID"].Value = strPatientID;
			ObjCommand.Parameters["@MVISITDATE"].Value = strVisitDateTime;
			ObjCommand.Parameters["@MCLINICID"].Value = strClinicID;
			ObjCommand.Parameters["@MPATIENTCONDITION"].Value = strPCondition;			
			ObjCommand.Parameters["@MNICNO"].Value = StrNIC;
			ObjCommand.Parameters["@MNAME"].Value = StrName;			
			ObjCommand.Parameters["@MADDRESS"].Value = StrAddress;			
			ObjCommand.Parameters["@MPATIENTTYPE"].Value = StrPatientType;
			ObjCommand.Parameters["@MSEX"].Value = StrSex;
			ObjCommand.Parameters["@MBLOODGROUP"].Value = StrBloodGroup;
			ObjCommand.Parameters["@MMS"].Value = StrMaritalStatus;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value = StrDepartmentID;
			ObjCommand.Parameters["@MPLNO"].Value = StrPLNo;
			ObjCommand.Parameters["@MLetterInfo"].Value = StrLetterInfo;

			return ObjCommand;
		}


		/// <summary>
		/// Get Single Record Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_Single()
		{
			// get Stored procedure name for Search Single record in tPatientVisit table
			SP.TPATIENTVISIT = (clsdatadefinition.SPTPatientVisit)5;	//5 is used for get search Single stored procedure name
			strData = SP.TPATIENTVISIT.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MVisitNo", OleDbType.VarChar, 10, "VisitNo"));
			ObjCommand.Parameters["@MVisitNo"].Value = strVisitNo;

			return ObjCommand;
		}
		
		#endregion
	}
}
