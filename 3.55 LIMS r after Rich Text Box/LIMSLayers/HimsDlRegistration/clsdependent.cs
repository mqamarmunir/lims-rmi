using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsdependent.
	/// </summary>
	public class clsdependent:Iinterface
	{
		public clsdependent()
		{
			//
			// TODO: Add constructor logic here
			//
		}
	
	
		#region "Class Variable Declaration"

		// call stored procedure name from clsdatdefinition class
		clsdatadefinition.StoredProcedure SP;

		#endregion

		#region "Variable Declaration"

		// use for string data
		private string StrData;	
		private string StrDEPENDENTID;
		private string StrEMPLOYEEID;
		private string StrRELATION;
		private string StrTITLE;
		private string StrDFNAME;
		private string StrDMNAME;
		private string StrDLNAME;
		private string StrSEX;
		private string StrBG;
		private string StrDOB;
		private string StrMS;
		private string StrNIC;
		private string StrNICVALIDUPTO;
		private string StrPICTUREREF;
		private string StrPatientID;
		private string StrSectionID;
		private string StrFactoryID;
		private string StrOrgID;
		private string StrRankID;

		//For Search Purpose

		private string StrDEPENDENTNAME;
		private string StrPLNo;
		private string StrAddress;
		private string StrEmail;
		private string StrHPhone;
		private string StrOPhone;
		private string StrCPhone;
		private string StrWelfareContNo;
		private string StrDOBDay;
		private string StrDOBMonth;
		private string StrDOBYear;
		private string StrFHName;
		private string StrGatePassNo;

		#endregion

		#region "Properties"
	
		/// <summary>
		/// DEPENDENTID Primary key
		/// </summary>

		public string PKeycode
		{
			get
			{
				return StrDEPENDENTID;
			}
			set
			{
				StrDEPENDENTID=value;
			}
		}

		/// <summary>
		/// EMPLOYEEID table field
		/// </summary>

		public string EMPLOYEEID
		{
			get
			{
				return StrEMPLOYEEID;
			}
			set
			{
				StrEMPLOYEEID=value;
			}
		}

		/// <summary>
		/// RELATION table field
		/// </summary>

		public string RELATION
		{
			get
			{
				return StrRELATION;
			}
			set
			{
				StrRELATION=value;
			}
		}

		/// <summary>
		/// TITLE table field
		/// </summary>

		public string TITLE
		{
			get
			{
				return StrTITLE;
			}
			set
			{
				StrTITLE=value;
			}
		}

		/// <summary>
		/// DFNAME table field
		/// </summary>

		public string DFNAME
		{
			get
			{
				return StrDFNAME;
			}
			set
			{
				StrDFNAME=value;
			}
		}

		/// <summary>
		/// DMNAME table field
		/// </summary>

		public string DMNAME
		{
			get
			{
				return StrDMNAME;
			}
			set
			{
				StrDMNAME=value;
			}
		}

		/// <summary>
		/// DLNAME table field
		/// </summary>

		public string DLNAME
		{
			get
			{
				return StrDLNAME;
			}
			set
			{
				StrDLNAME=value;
			}
		}

		/// <summary>
		/// SEX table field
		/// </summary>

		public string SEX
		{
			get
			{
				return StrSEX;
			}
			set
			{
				StrSEX=value;
			}
		}

		/// <summary>
		/// BG table field
		/// </summary>

		public string BG
		{
			get
			{
				return StrBG;
			}
			set
			{
				StrBG=value;
			}
		}

		/// <summary>
		/// DOB table field
		/// </summary>

		public string DOB
		{
			get
			{
				return StrDOB;
			}
			set
			{
				StrDOB=value;
			}
		}
		
		/// <summary>
		/// MS table field
		/// </summary>
		public string MS
		{
			get
			{
				return StrMS;
			}
			set
			{
				StrMS=value;
			}
		}

		/// <summary>
		/// NIC table field
		/// </summary>

		public string NIC
		{
			get
			{
				return StrNIC;
			}
			set
			{
				StrNIC=value;
			}
		}

		/// <summary>
		/// NICVALIDUPTO table field
		/// </summary>

		public string NICVALIDUPTO
		{
			get
			{
				return StrNICVALIDUPTO;
			}
			set
			{
				StrNICVALIDUPTO=value;
			}
		}

		/// <summary>
		/// NICVALIDUPTO table field
		/// </summary>

		public string PICTUREREF
		{
			get
			{
				return StrPICTUREREF;
			}
			set
			{
				StrPICTUREREF=value;
			}
		}

		/// <summary>
		/// NICVALIDUPTO table field
		/// </summary>

		public string FactoryID
		{
			get
			{
				return StrFactoryID;
			}
			set
			{
				StrFactoryID=value;
			}
		}


		/// <summary>
		/// Department Name table field
		/// </summary>

		public string DependentName
		{
			get
			{
				return StrDEPENDENTNAME;
			}
			set
			{
				StrDEPENDENTNAME=value;
			}
		}


		/// <summary>
		/// Patient ID - Table Field
		/// </summary>
		public string PatientID
		{
			get
			{
				return StrPatientID;
			}
			set
			{
				StrPatientID = value;
			}
		}


		/// <summary>
		/// Section ID - Table Field - Foreign Key to "Section" Table
		/// </summary>
		public string SectionID
		{
			get
			{
				return StrSectionID;
			}
			set
			{
				StrSectionID = value;
			}
		}


		/// <summary>
		/// Organization ID - Table Field - Foreign Key to "Organizations" Table
		/// </summary>
		public string OrgID
		{
			get
			{
				return StrOrgID;
			}
			set
			{
				StrOrgID = value;
			}
		}


		/// <summary>
		/// Rank ID - Table Field - Foreign Key to "Rank" Table
		/// </summary>
		public string RankID
		{
			get
			{
				return StrRankID;
			}
			set
			{
				StrRankID = value;
			}
		}

		/// <summary>
		/// Employee Personnel No for searching
		/// </summary>
		public string PLNo
		{
			get{	return StrPLNo;		}
			set{	StrPLNo = value;	}
		}

		/// <summary>
		/// Address for searching
		/// </summary>
		public string Address
		{
			get{	return StrAddress;		}
			set{	StrAddress = value;	}
		}

		/// <summary>
		/// Email for searching
		/// </summary>
		public string Email
		{
			get{	return StrEmail;		}
			set{	StrEmail = value;	}
		}

		/// <summary>
		/// HOme Phone for searching
		/// </summary>
		public string HPhone
		{
			get{	return StrHPhone;		}
			set{	StrHPhone = value;	}
		}

		/// <summary>
		/// Office Phone for searching
		/// </summary>
		public string OPhone
		{
			get{	return StrOPhone;		}
			set{	StrOPhone = value;	}
		}

		/// <summary>
		/// Cell Phone for searching
		/// </summary>
		public string CPhone
		{
			get{	return StrCPhone;		}
			set{	StrCPhone = value;	}
		}

		/// <summary>
		/// Employee Welfare Contact No for searching
		/// </summary>
		public string WelfareContNo
		{
			get{	return StrWelfareContNo;		}
			set{	StrWelfareContNo = value;	}
		}

		/// <summary>
		/// Date of Birth Day for searching
		/// </summary>
		public string DOBDay
		{
			get{	return StrDOBDay;		}
			set{	StrDOBDay = value;	}
		}

		/// <summary>
		/// Date of Birth Month for searching
		/// </summary>
		public string DOBMonth
		{
			get{	return StrDOBMonth;		}
			set{	StrDOBMonth = value;	}
		}

		/// <summary>
		/// Date of Birth Year for searching
		/// </summary>
		public string DOBYear
		{
			get{	return StrDOBYear;		}
			set{	StrDOBYear = value;	}
		}

		/// <summary>
		/// Employee Father/Husband Name for searching
		/// </summary>
		public string FHName
		{
			get{	return StrFHName;		}
			set{	StrFHName = value;	}
		}

		/// <summary>
		/// Gate Pass Number for searching
		/// </summary>
		public string GatePassNo
		{
			get{	return StrGatePassNo;	}
			set{	StrGatePassNo = value;	}
		}

		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Dependent TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Dependent table
			SP.DEPENDENT = (clsdatadefinition.SPDependent)1; // 1 is used for get insert stored procedure name
			StrData = SP.DEPENDENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,7,ParameterDirection.Output,false,0,0,"DEPENDENTID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,7,"EMPLOYEEID"));          

			ObjCommand.Parameters.Add(new OleDbParameter("@MRELATION",OleDbType.VarChar,5,"RELATION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDFNAME",OleDbType.VarChar,15,"DFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDMNAME",OleDbType.VarChar,15,"DMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDLNAME",OleDbType.VarChar,15,"DLNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,20,"NICVALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,250,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID", OleDbType.VarChar, 5, "SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID", OleDbType.VarChar, 4, "FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID", OleDbType.VarChar, 2, "ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID", OleDbType.VarChar, 4, "RANKID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPatientID", OleDbType.VarChar, 11, "PatientID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNo", OleDbType.VarChar, 10, "PLNo"));
		
			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MRELATION"].Value=StrRELATION;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MDFNAME"].Value=StrDFNAME;
			ObjCommand.Parameters["@MDMNAME"].Value=StrDMNAME;
			ObjCommand.Parameters["@MDLNAME"].Value=StrDLNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNICVALIDUPTO;
			ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
			ObjCommand.Parameters["@MSECTIONID"].Value = StrSectionID;
			ObjCommand.Parameters["@MFACTORYID"].Value = StrFactoryID;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MRANKID"].Value = StrRankID;
			ObjCommand.Parameters["@MPatientID"].Value = StrPatientID;
			ObjCommand.Parameters["@MPLNo"].Value = StrPLNo;

			return ObjCommand;
		}

		// UPDATE RECORD IN Dependent TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in Dependent table
			SP.DEPENDENT = (clsdatadefinition.SPDependent)2; // 2 is used for get update stored procedure name
			StrData = SP.DEPENDENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DEPENDENTID",OleDbType.Char,7,"DEPENDENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,7,"EMPLOYEEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRELATION",OleDbType.VarChar,5,"RELATION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDFNAME",OleDbType.VarChar,15,"DFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDMNAME",OleDbType.VarChar,15,"DMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDLNAME",OleDbType.VarChar,15,"DLNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,20,"NICVALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,250,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID", OleDbType.VarChar, 5, "SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID", OleDbType.VarChar, 4, "FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID", OleDbType.VarChar, 2, "ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID", OleDbType.VarChar, 4, "RANKID"));

			ObjCommand.Parameters["@DEPENDENTID"].Value=StrDEPENDENTID;
			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MRELATION"].Value=StrRELATION;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MDFNAME"].Value=StrDFNAME;
			ObjCommand.Parameters["@MDMNAME"].Value=StrDMNAME;
			ObjCommand.Parameters["@MDLNAME"].Value=StrDLNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNICVALIDUPTO;
			ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
			ObjCommand.Parameters["@MSECTIONID"].Value = StrSectionID;
			ObjCommand.Parameters["@MFACTORYID"].Value = StrFactoryID;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MRANKID"].Value = StrRankID;

			return ObjCommand;
		}

		// DELETE RECORD IN Dependent TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in Dependent table
			SP.DEPENDENT = (clsdatadefinition.SPDependent)3; //3 is used for get delete stored procedure name
			StrData = SP.DEPENDENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DEPENDENTID",OleDbType.Char,7,"DEPENDENTID"));

			ObjCommand.Parameters["@DEPENDENTID"].Value=StrDEPENDENTID;

	
			return ObjCommand;
		}

		// SELECT ALL RECORD IN Dependent TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in Dependent table
			SP.DEPENDENT = (clsdatadefinition.SPDependent)4;  //4 is used for get search all stored procedure name
			StrData = SP.DEPENDENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;


			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,7,"EMPLOYEEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRELATION",OleDbType.VarChar,5,"RELATION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPENDENTNAME",OleDbType.VarChar,50,"DEPENDENTNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTID", OleDbType.VarChar, 11, "PATIENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID", OleDbType.VarChar, 5, "SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID", OleDbType.VarChar, 4, "FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID", OleDbType.VarChar, 2, "ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID", OleDbType.VarChar, 4, "RANKID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNo", OleDbType.VarChar, 10, "PLNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAddress", OleDbType.VarChar, 250, "TempAddress"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEmail", OleDbType.VarChar, 50, "Email"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPhone", OleDbType.VarChar, 15, "HPhone1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPhone", OleDbType.VarChar, 15, "OPhone1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCPhone", OleDbType.VarChar, 15, "CPhone"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MWelfareContNo",OleDbType.VarChar,15,"WelfareContNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOBDay", OleDbType.VarChar, 2, "DOBDay"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOBMonth", OleDbType.VarChar, 2, "DOBMonth"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOBYear", OleDbType.VarChar, 4, "DOBYear"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFHName", OleDbType.VarChar, 50, "FHName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MGatePassNo", OleDbType.VarChar, 10, "GatePassNo"));

			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MRELATION"].Value=StrRELATION;
			ObjCommand.Parameters["@MDEPENDENTNAME"].Value=StrDEPENDENTNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MPATIENTID"].Value = StrPatientID;
			ObjCommand.Parameters["@MSECTIONID"].Value = StrSectionID;
			ObjCommand.Parameters["@MFACTORYID"].Value = StrFactoryID;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MRANKID"].Value = StrRankID;
			ObjCommand.Parameters["@MPLNo"].Value = StrPLNo;
			ObjCommand.Parameters["@MAddress"].Value = StrAddress;
			ObjCommand.Parameters["@MEmail"].Value = StrEmail;
			ObjCommand.Parameters["@MHPhone"].Value = StrHPhone;
			ObjCommand.Parameters["@MOPhone"].Value = StrOPhone;
			ObjCommand.Parameters["@MCPhone"].Value = StrCPhone;
			ObjCommand.Parameters["@MWelfareContNo"].Value = StrWelfareContNo;
			ObjCommand.Parameters["@MDOBDay"].Value = StrDOBDay;
			ObjCommand.Parameters["@MDOBMonth"].Value = StrDOBMonth;
			ObjCommand.Parameters["@MDOBYear"].Value = StrDOBYear;
			ObjCommand.Parameters["@MFHName"].Value = StrFHName;
			ObjCommand.Parameters["@MGatePassNo"].Value = StrGatePassNo;

			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM Dependent
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in Dependent table
			SP.DEPENDENT = (clsdatadefinition.SPDependent)5; //5 is used for get search Single stored procedure name
			StrData = SP.DEPENDENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DEPENDENTID",OleDbType.Char,7,"DEPENDENTID"));
			ObjCommand.Parameters["@DEPENDENTID"].Value=StrDEPENDENTID;

			return ObjCommand;
		}

		public int Update_PatientId(string dependentId,string patientId,OleDbConnection con,OleDbTransaction trans)
		{
			
			try
			{
				
				OleDbCommand ObjCommand = new OleDbCommand();
				ObjCommand.CommandText = "PK_DEPENDENT.P_UPDATEPATIENTID_DEPENDENT";
				ObjCommand.CommandType = CommandType.StoredProcedure;
				ObjCommand.Parameters.Add(new OleDbParameter("@MDEPENDENTID",OleDbType.VarChar,7,"DEPENDENTID"));
				ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTID",OleDbType.VarChar,11,"PATIENTID"));
				
				ObjCommand.Parameters["@MDEPENDENTID"].Value=dependentId;
				ObjCommand.Parameters["@MPATIENTID"].Value=patientId;
				
				ObjCommand.Connection = con;
				ObjCommand.Transaction = trans;

				return ObjCommand.ExecuteNonQuery();
			}
			catch(Exception ex)
			{
				string excep = ex.Message.ToString();
				return 0;
			}

		}


		#endregion

	}
}