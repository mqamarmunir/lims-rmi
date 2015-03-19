using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clspatientvisit.
	/// </summary>
	public class clspatientvisit:Iinterface
	{
		public clspatientvisit()
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
    private string StrHOSPITALNO;
	private string StrVISITDT;
	private string StrPTYPE;
	private string StrTITLE;
	private string StrPFNAME;
	private string StrPMNAME;
	private string StrPLNAME;
	private string StrSEX;
	private string StrBG;
	private string StrDOB;
	private string StrAGE;
	private string StrNIC;
	private string StrMS;
	private string StrHPHONE;
	private string StrOPHONE;
	private string StrEMAIL;
	private string StrADDRESS;
	private string StrEMPLOYEEID;
	private string StrDEPENDENTID;
	private string StrDEPARTMENTID;	
	private long StrADVAMOUNT;
	private string StrCLINICID;
	private string StrPLNO;
	private string StrPATIENTNAME;
	private string StrFACTORYID;
	private string StrSECTIONID;
	private string StrRANKID;
	private string StrDOCTORID;
	private string StrPCONDITION;
	private string StrTSTATUS;
	private string StrFollowUp;


#endregion

#region "Properties"

	/// <summary>
	/// HOSPITALNO Primary key
	/// </summary>

		public string FollowUp{
			get{
				return StrFollowUp;
			}
			set{
				StrFollowUp = value;
			}
		}
	public string PKeycode
	{
		get
		{
			return StrHOSPITALNO;
		}
		set
		{
			StrHOSPITALNO=value;
		}
	}

		/// <summary>
		/// Visit Date table field
		/// </summary>

		public string VISITDT
		{
			get
			{
				return StrVISITDT;
			}
			set
			{
				StrVISITDT=value;
			}
		}
	
	/// <summary>
	/// PTYPE table field
	/// </summary>

	public string PTYPE
	{
		get
		{
			return StrPTYPE;
		}
		set
		{
			StrPTYPE=value;
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
	/// PFNAME table field
	/// </summary>

	public string PFNAME
	{
		get
		{
			return StrPFNAME;
		}
		set
		{
			StrPFNAME=value;
		}
	}

	/// <summary>
	/// PMNAME table field
	/// </summary>

	public string PMNAME
	{
		get
		{
			return StrPMNAME;
		}
		set
		{
			StrPMNAME=value;
		}
	}

	/// <summary>
	/// PLNAME table field
	/// </summary>

	public string PLNAME
	{
		get
		{
			return StrPLNAME;
		}
		set
		{
			StrPLNAME=value;
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
	/// AGE table field
	/// </summary>

	public string AGE
	{
		get
		{
			return StrAGE;
		}
		set
		{
			StrAGE=value;
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
	/// HPHONE table field
	/// </summary>

	public string HPHONE
	{
		get
		{
			return StrHPHONE;
		}
		set
		{
			StrHPHONE=value;
		}
	}

	/// <summary>
	/// OPHONE table field
	/// </summary>

	public string OPHONE
	{
		get
		{
			return StrOPHONE;
		}
		set
		{
			StrOPHONE=value;
		}
	}

	/// <summary>
	/// EMAIL table field
	/// </summary>

	public string EMAIL
	{
		get
		{
			return StrEMAIL;
		}
		set
		{
			StrEMAIL=value;
		}
	}

	/// <summary>
	/// ADDRESS table field
	/// </summary>

	public string ADDRESS
	{
		get
		{
			return StrADDRESS;
		}
		set
		{
			StrADDRESS=value;
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
	/// DEPENDENTID table field
	/// </summary>

	public string DEPENDENTID
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
	/// DEPARTMENTID table field
	/// </summary>

	public string DEPARTMENTID
	{
		get
		{
			return StrDEPARTMENTID;
		}
		set
		{
			StrDEPARTMENTID=value;
		}
	}

	/// <summary>
	/// ADVAMOUNT table field
	/// </summary>

	public long ADVAMOUNT
	{
		get
		{
			return StrADVAMOUNT;
		}
		set
		{
			StrADVAMOUNT=value;
		}
	}

		/// <summary>
		/// DOCTORID table field
		/// </summary>

		public string CLINICID
		{
			get
			{
				return StrCLINICID;
			}
			set
			{
				StrCLINICID=value;
			}
		}

		/// <summary>
		/// Doctor ID table field
		/// </summary>

		public string DoctorID
		{
			get
			{
				return StrDOCTORID;
			}
			set
			{
				StrDOCTORID=value;
			}
		}

		/// <summary>
		/// Patient Conidtion table field
		/// </summary>

		public string PCondition
		{
			get
			{
				return StrPCONDITION;
			}
			set
			{
				StrPCONDITION=value;
			}
		}

		/// <summary>
		/// Treatment Status ID table field
		/// </summary>

		public string TStatus
		{
			get
			{
				return StrTSTATUS;
			}
			set
			{
				StrTSTATUS=value;
			}
		}


		/* * *  * * * These Field Use For Search Purpose  * * * * */

		/// <summary>
		/// PLNo table field
		/// </summary>

		public string PLNo
		{
			get
			{
				return StrPLNO;
			}
			set
			{
				StrPLNO=value;
			}
		}

		/// <summary>
		/// Patient Name table field
		/// </summary>

		public string PatientName
		{
			get
			{
				return StrPATIENTNAME;
			}
			set
			{
				StrPATIENTNAME=value;
			}
		}

		/// <summary>
		/// Factory  ID table field
		/// </summary>

		public string FactoryID
		{
			get
			{
				return StrFACTORYID;
			}
			set
			{
				StrFACTORYID=value;
			}
		}

		/// <summary>
		/// Section ID table field
		/// </summary>

		public string SectionID
		{
			get
			{
				return StrSECTIONID;
			}
			set
			{
				StrSECTIONID=value;
			}
		}

		/// <summary>
		/// Rank ID table field
		/// </summary>

		public string RankID
		{
			get
			{
				return StrRANKID;
			}
			set
			{
				StrRANKID=value;
			}
		}


#endregion

#region "Data_Methods"
		
		
		// INSERT DATA IN PATIENTVISIT TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert PATIENTVISIT table
			SP.PATIENTVISIT = (clsdatadefinition.SPPatientvisit)1; // 1 is used for get insert stored procedure name
			StrData = SP.PATIENTVISIT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,10,ParameterDirection.Output,false,0,0,"HOSPITALNO",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MPTYPE",OleDbType.VarChar,3,"PTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPFNAME",OleDbType.VarChar,15,"MPFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPMNAME",OleDbType.VarChar,15,"PMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNAME",OleDbType.VarChar,15,"PLNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAGE",OleDbType.VarChar,2,"AGE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.VarChar,10,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE",OleDbType.VarChar,15,"HPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE",OleDbType.VarChar,15,"OPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.VarChar,7,"EMPLOYEEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPENDENTID",OleDbType.VarChar,7,"DEPENDENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.VarChar,4,"DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADVAMOUNT",OleDbType.Numeric,0,"ADVAMOUNT"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"CLINICID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORID",OleDbType.Char,4,"DOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPCONDITION",OleDbType.Char,1,"PCONDITION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTSTATUS",OleDbType.Char,1,"TSTATUS"));
            
			ObjCommand.Parameters.Add(new OleDbParameter("@MFOLLOWUP",OleDbType.Char,1,"FOLLOWUP"));

			ObjCommand.Parameters["@MPTYPE"].Value=StrPTYPE;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MPFNAME"].Value=StrPFNAME;
			ObjCommand.Parameters["@MPMNAME"].Value=StrPMNAME;
			ObjCommand.Parameters["@MPLNAME"].Value=StrPLNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MAGE"].Value=StrAGE;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MHPHONE"].Value=StrHPHONE;
			ObjCommand.Parameters["@MOPHONE"].Value=StrOPHONE;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MADDRESS"].Value=StrADDRESS;
			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MDEPENDENTID"].Value=StrDEPENDENTID;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDEPARTMENTID;			
			ObjCommand.Parameters["@MADVAMOUNT"].Value=StrADVAMOUNT;
			ObjCommand.Parameters["@MCLINICID"].Value=StrCLINICID;
			ObjCommand.Parameters["@MDOCTORID"].Value=StrDOCTORID;
			ObjCommand.Parameters["@MPCONDITION"].Value=StrPCONDITION; 
			ObjCommand.Parameters["@MTSTATUS"].Value=StrTSTATUS;
			ObjCommand.Parameters["@MFOLLOWUP"].Value = StrFollowUp;
				
			return ObjCommand;
		}

		// UPDATE RECORD IN PATIENTVISIT TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in PATIENTVISIT table
			SP.PATIENTVISIT = (clsdatadefinition.SPPatientvisit)2; // 2 is used for get update stored procedure name
			StrData = SP.PATIENTVISIT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPTYPE",OleDbType.VarChar,3,"PTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPFNAME",OleDbType.VarChar,15,"MPFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPMNAME",OleDbType.VarChar,15,"PMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNAME",OleDbType.VarChar,15,"PLNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAGE",OleDbType.VarChar,2,"AGE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.VarChar,10,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE",OleDbType.VarChar,15,"HPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE",OleDbType.VarChar,15,"OPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,255,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.VarChar,7,"EMPLOYEEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPENDENTID",OleDbType.Char,7,"DEPENDENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.VarChar,4,"DEPARTMENTID"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MADVAMOUNT",OleDbType.Numeric,0,"ADVAMOUNT"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"CLINICID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORID",OleDbType.Char,4,"DOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPCONDITION",OleDbType.Char,1,"PCONDITION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTSTATUS",OleDbType.Char,1,"TSTATUS"));


			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MPTYPE"].Value=StrPTYPE;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MPFNAME"].Value=StrPFNAME;
			ObjCommand.Parameters["@MPMNAME"].Value=StrPMNAME;
			ObjCommand.Parameters["@MPLNAME"].Value=StrPLNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MAGE"].Value=StrAGE;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MHPHONE"].Value=StrHPHONE;
			ObjCommand.Parameters["@MOPHONE"].Value=StrOPHONE;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MADDRESS"].Value=StrADDRESS;
			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MDEPENDENTID"].Value=StrDEPENDENTID;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDEPARTMENTID;
			ObjCommand.Parameters["@MADVAMOUNT"].Value=StrADVAMOUNT;
			ObjCommand.Parameters["@MCLINICID"].Value=StrCLINICID;
			ObjCommand.Parameters["@MDOCTORID"].Value=StrDOCTORID;
			ObjCommand.Parameters["@MPCONDITION"].Value=StrPCONDITION; 
			ObjCommand.Parameters["@MTSTATUS"].Value=StrTSTATUS;	
			return ObjCommand;
		}

		// DELETE RECORD IN PATIENTVISIT TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in PATIENTVISIT table
			SP.PATIENTVISIT = (clsdatadefinition.SPPatientvisit)3; //3 is used for get delete stored procedure name
			StrData = SP.PATIENTVISIT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HOSPITALNO"));

			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN PATIENTVISIT TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in PATIENTVISIT table
			SP.PATIENTVISIT = (clsdatadefinition.SPPatientvisit)4;  //4 is used for get search all stored procedure name
			StrData = SP.PATIENTVISIT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MVISITDT",OleDbType.Char,10,"VISITDT"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPTYPE",OleDbType.Char,3,"PTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNO",OleDbType.VarChar,10,"PLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPATIENTNAME",OleDbType.VarChar,60,"PATIENTNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE",OleDbType.VarChar,15,"HPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE",OleDbType.VarChar,15,"OPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.Char,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.Char,3,"DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"CLINICID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,4,"SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RANKID"));
		
			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MVISITDT"].Value=StrVISITDT;			
			ObjCommand.Parameters["@MPTYPE"].Value=StrPTYPE;
			ObjCommand.Parameters["@MPLNO"].Value=StrPLNO;
			ObjCommand.Parameters["@MPATIENTNAME"].Value=StrPATIENTNAME;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MHPHONE"].Value=StrHPHONE;
			ObjCommand.Parameters["@MOPHONE"].Value=StrOPHONE;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MADDRESS"].Value=StrADDRESS;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDEPARTMENTID;
			ObjCommand.Parameters["@MCLINICID"].Value=StrCLINICID;
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFACTORYID;
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSECTIONID;
			ObjCommand.Parameters["@MRANKID"].Value=StrRANKID;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM PATIENTVISIT
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in PATIENTVISIT table
			SP.PATIENTVISIT = (clsdatadefinition.SPPatientvisit)5; //5 is used for get search Single stored procedure name
			StrData = SP.PATIENTVISIT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HOSPITALNO"));
			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			return ObjCommand;
		}

#endregion
	
	
	}
}
