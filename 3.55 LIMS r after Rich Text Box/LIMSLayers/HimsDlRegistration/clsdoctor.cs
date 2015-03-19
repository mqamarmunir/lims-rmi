using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsdoctor.
	/// </summary>

	public class clsdoctor:Iinterface
	{
		
		public clsdoctor()
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

		string StrDoctorId=null;
		string StrActive=null;
		string StrTitle=null;
		string StrFname=null;
		string StrMname=null;
		string StrLname=null;
		string StrAcronym=null;
		string StrFHname=null;
		string StrSex=null;
		string StrBG=null;
		string StrDOB=null;
		string StrAge=null;
		string StrMS=null;
		string StrNIC=null;
		string StrNicValIdupto=null;
		string StrPassport=null;
		string StrPassportValIdupto=null;
		string StrHphoneNo1=null;
		string StrHphoneNo2=null;
		string StrOphoneNo1=null;
		string StrOphoneNo2=null;
		string StrCphoneNo=null;
		string StrPagerno=null;
		string StrEmail=null;
		string StrAddress=null;
		string StrPICTUREREF=null;
		string StrSPECIALITYTYPEID=null;
		string StrOPDStatus=null;

	// For Searching Purpose Specially

		string StrDOCTORNAME=null;
		string StrHPHONE=null;
		string StrOPHONE=null;



#endregion

#region "Properties"
		
	/// <summary>
	/// DoctorId Primary key
	/// </summary>
	public string PKeycode
	{
		get
		{
			return StrDoctorId;
		}
		set
		
		{
			StrDoctorId = value;
		}
	}

		/// <summary>
		/// Active field
		/// </summary>
		public string Active
		{
			get
			{
				return StrActive;
			}
			set
		
			{
				StrActive=value;
			}
		}


		/// <summary>
		/// Title field
		/// </summary>
		public string Title
		{
			get
			{
				return StrTitle;
			}
			set
		
			{
				StrTitle=value;
			}
		}

		/// <summary>
		/// Fname field
		/// </summary>
		public string Fname
		{
			get
			{
				return StrFname;
			}
			set
		
			{
				StrFname=value;
			}
		}

		/// <summary>
		/// Mname field
		/// </summary>
		public string Mname
		{
			get
			{
				return StrMname;
			}
			set
		
			{
				StrMname=value;
			}
		}

		/// <summary>
		/// Lname field
		/// </summary>
		public string Lname
		{
			get
			{
				return StrLname;
			}
			set
		
			{
				StrLname=value;
			}
		}

		/// <summary>
		/// Acronym field
		/// </summary>
		public string Acronym
		{
			get
			{
				return StrAcronym;
			}
			set
		
			{
				StrAcronym=value;
			}
		}

		/// <summary>
		/// FHname field
		/// </summary>
		public string FHname
		{
			get
			{
				return StrFHname;
			}
			set
		
			{
				StrFHname=value;
			}
		}

		/// <summary>
		/// Sex field
		/// </summary>
		public string Sex
		{
			get
			{
				return StrSex;
			}
			set
		
			{
				StrSex=value;
			}
		}

		/// <summary>
		/// BG field
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
		/// DOB field
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
		/// AGE field
		/// </summary>
		public string Age
		{
			get
			{
				return StrAge;
			}
			set
		
			{
				StrAge=value;
			}
		}

		/// <summary>
		/// MS field
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
		/// NIC field
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
		/// NicValIdupto field
		/// </summary>
		public string NicValIdupto
		{
			get
			{
				return StrNicValIdupto;
			}
			set
		
			{
				StrNicValIdupto=value;
			}
		}

		/// <summary>
		/// Passport field
		/// </summary>
		public string Passport
		{
			get
			{
				return StrPassport;
			}
			set
		
			{
				StrPassport=value;
			}
		}

		/// <summary>
		/// PassportValIdupto field
		/// </summary>
		public string PassportValIdupto
		{
			get
			{
				return StrPassportValIdupto;
			}
			set
		
			{
				StrPassportValIdupto=value;
			}
		}

		/// <summary>
		/// HphoneNo1 field
		/// </summary>
		public string HphoneNo1
		{
			get
			{
				return StrHphoneNo1;
			}
			set
		
			{
				StrHphoneNo1=value;
			}
		}

		/// <summary>
		/// HphoneNo2 field
		/// </summary>
		public string HphoneNo2
		{
			get
			{
				return StrHphoneNo2;
			}
			set
		
			{
				StrHphoneNo2=value;
			}
		}

		/// <summary>
		/// OphoneNo1 field
		/// </summary>
		public string OphoneNo1
		{
			get
			{
				return StrOphoneNo1;
			}
			set
		
			{
				StrOphoneNo1=value;
			}
		}

		/// <summary>
		/// OphoneNo2 field
		/// </summary>
		
		public string OphoneNo2
		{
			get
			{
				return StrOphoneNo2;
			}
			set
		
			{
				StrOphoneNo2=value;
			}
		}

		/// <summary>
		/// CphoneNo field
		/// </summary>
		public string CphoneNo
		{
			get
			{
				return StrCphoneNo;
			}
			set
		
			{
				StrCphoneNo=value;
			}
		}

		/// <summary>
		/// Pagerno field
		/// </summary>
		public string Pagerno
		{
			get
			{
				return StrPagerno;
			}
			set
		
			{
				StrPagerno=value;
			}
		}

		/// <summary>
		/// Email field
		/// </summary>
		public string Email
		{
			get
			{
				return StrEmail;
			}
			set
		
			{
				StrEmail=value;
			}
		}

		/// <summary>
		/// Address field
		/// </summary>
		public string Address
		{
			get
			{
				return StrAddress;
			}
			set
		
			{
				StrAddress=value;
			}
		}

		/// <summary>
		/// PICTUREREF field
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
		/// SPECIALITYTYPEID field
		/// </summary>
		public string SPECIALITYTYPEID
		{
			get
			{
				return StrSPECIALITYTYPEID;
			}
			set
		
			{
				StrSPECIALITYTYPEID=value;
			}
		}

		/// <summary>
		/// OPDStatus field
		/// </summary>
		public string OPDSTATUS
		{
			get
			{
				return StrOPDStatus;
			}
			set
		
			{
				StrOPDStatus=value;
			}
		}


		/// <summary>
		/// DOCTORNAME field
		/// </summary>
		public string DOCTORNAME
		{
			get
			{
				return StrDOCTORNAME;
			}
			set
		
			{
				StrDOCTORNAME=value;
			}
		}


		/// <summary>
		/// Home Phone field
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
		/// Office Phone field
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


		
#endregion

#region "Data_Methods"
		
		
	// INSERT DATA IN DOCTOR TABLE
	public  OleDbCommand Insert()
	{
		
		// Get Stored procedure name for insert DOCTOR table
		SP.DOCTOR = (clsdatadefinition.SPDoctor)1; // 1 is used for get insert stored procedure name
		StrData = SP.DOCTOR.ToString().Replace("3",".");
			
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
			
	
		ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,6,ParameterDirection.Output,false,0,0,"DOCTORID",DataRowVersion.Default,null));
		ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,6,"TITLE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFNAME",OleDbType.VarChar,20,"FNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MMNAME",OleDbType.VarChar,20,"MNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MLNAME",OleDbType.VarChar,20,"LNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.VarChar,30,"FHNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,3,"BG"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MAGE",OleDbType.VarChar,2,"AGE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,10,"NICVALIDUPTO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORT",OleDbType.VarChar,20,"PASSPORT"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORTVALIDUPTO",OleDbType.VarChar,10,"PASSPORTVALIDUPTO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONENO1",OleDbType.VarChar,15,"HPHONENO1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONENO2",OleDbType.VarChar,15,"HPHONENO2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONENO1",OleDbType.VarChar,15,"OPHONENO1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONENO2",OleDbType.VarChar,15,"OPHONENO2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONENO",OleDbType.VarChar,15,"CPHONENO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,15,"PAGERNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,150,"EMAIL"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,255,"ADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,255,"PICTUREREF"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,5,"SPECIALITYTYPEID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPDSTATUS",OleDbType.Char,1,"OPDSTATUS"));

		
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MTITLE"].Value=StrTitle;
		ObjCommand.Parameters["@MFNAME"].Value=StrFname;
		ObjCommand.Parameters["@MMNAME"].Value=StrMname;
		ObjCommand.Parameters["@MLNAME"].Value=StrLname;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MFHNAME"].Value=StrFHname;
		ObjCommand.Parameters["@MSEX"].Value=StrSex;
		ObjCommand.Parameters["@MBG"].Value=StrBG;
		ObjCommand.Parameters["@MDOB"].Value=StrDOB;
		ObjCommand.Parameters["@MAGE"].Value=StrAge;
		ObjCommand.Parameters["@MMS"].Value=StrMS;
		ObjCommand.Parameters["@MNIC"].Value=StrNIC;
		ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNicValIdupto;
		ObjCommand.Parameters["@MPASSPORT"].Value=StrPassport;
		ObjCommand.Parameters["@MPASSPORTVALIDUPTO"].Value=StrPassportValIdupto;
		ObjCommand.Parameters["@MHPHONENO1"].Value=StrHphoneNo1;
		ObjCommand.Parameters["@MHPHONENO2"].Value=StrHphoneNo2;
		ObjCommand.Parameters["@MOPHONENO1"].Value=StrOphoneNo1;
		ObjCommand.Parameters["@MOPHONENO2"].Value=StrOphoneNo2;
		ObjCommand.Parameters["@MCPHONENO"].Value=StrCphoneNo;
		ObjCommand.Parameters["@MPAGERNO"].Value=StrPagerno;
		ObjCommand.Parameters["@MEMAIL"].Value=StrEmail;
		ObjCommand.Parameters["@MADDRESS"].Value=StrAddress;
		ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
		ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSPECIALITYTYPEID;	
		ObjCommand.Parameters["@MOPDSTATUS"].Value=StrOPDStatus;
	
		return ObjCommand;
	}
 
	// UPDATE RECORD IN DOCTOR TABLE
	public OleDbCommand Update()
	{
		// get Stored procedure name for Update record in Doctor table
		SP.DOCTOR = (clsdatadefinition.SPDoctor)2; // 2 is used for get update stored procedure name
		StrData = SP.DOCTOR.ToString().Replace("3",".");
			
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
		
		ObjCommand.Parameters.Add(new OleDbParameter("@MDoctorId",OleDbType.Char,6,"DOCTORID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,6,"TITLE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFNAME",OleDbType.VarChar,20,"FNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MMNAME",OleDbType.VarChar,20,"MNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MLNAME",OleDbType.VarChar,20,"LNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.VarChar,30,"FHNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,3,"BG"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MAGE",OleDbType.VarChar,2,"AGE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,10,"NICVALIDUPTO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORT",OleDbType.VarChar,20,"PASSPORT"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORTVALIDUPTO",OleDbType.VarChar,10,"PASSPORTVALIDUPTO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONENO1",OleDbType.VarChar,15,"HPHONENO1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONENO2",OleDbType.VarChar,15,"HPHONENO2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONENO1",OleDbType.VarChar,15,"OPHONENO1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONENO2",OleDbType.VarChar,15,"OPHONENO2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONENO",OleDbType.VarChar,15,"CPHONENO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,15,"PAGERNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,150,"EMAIL"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,255,"ADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,255,"PICTUREREF"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,5,"SPECIALITYTYPEID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPDSTATUS",OleDbType.Char,1,"OPDSTATUS"));

		ObjCommand.Parameters["@MDoctorId"].Value=StrDoctorId;
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MTITLE"].Value=StrTitle;
		ObjCommand.Parameters["@MFNAME"].Value=StrFname;
		ObjCommand.Parameters["@MMNAME"].Value=StrMname;
		ObjCommand.Parameters["@MLNAME"].Value=StrLname;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MFHNAME"].Value=StrFHname;
		ObjCommand.Parameters["@MSEX"].Value=StrSex;
		ObjCommand.Parameters["@MBG"].Value=StrBG;
		ObjCommand.Parameters["@MDOB"].Value=StrDOB;
		ObjCommand.Parameters["@MAGE"].Value=StrAge;
		ObjCommand.Parameters["@MMS"].Value=StrMS;
		ObjCommand.Parameters["@MNIC"].Value=StrNIC;
		ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNicValIdupto;
		ObjCommand.Parameters["@MPASSPORT"].Value=StrPassport;
		ObjCommand.Parameters["@MPASSPORTVALIDUPTO"].Value=StrPassportValIdupto;
		ObjCommand.Parameters["@MHPHONENO1"].Value=StrHphoneNo1;
		ObjCommand.Parameters["@MHPHONENO2"].Value=StrHphoneNo2;
		ObjCommand.Parameters["@MOPHONENO1"].Value=StrOphoneNo1;
		ObjCommand.Parameters["@MOPHONENO2"].Value=StrOphoneNo2;
		ObjCommand.Parameters["@MCPHONENO"].Value=StrCphoneNo;
		ObjCommand.Parameters["@MPAGERNO"].Value=StrPagerno;
		ObjCommand.Parameters["@MEMAIL"].Value=StrEmail;
		ObjCommand.Parameters["@MADDRESS"].Value=StrAddress;
		ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
		ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSPECIALITYTYPEID;
		ObjCommand.Parameters["@MOPDSTATUS"].Value=StrOPDStatus;
		return ObjCommand;
	}

	// DELETE RECORD IN Doctor TABLE
	public OleDbCommand Delete()
	{
		// get Stored procedure name for Delete record in Doctor table
		SP.DOCTOR = (clsdatadefinition.SPDoctor)3; //3 is used for get delete stored procedure name
		StrData = SP.DOCTOR.ToString().Replace("3",".");
			
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
		
		ObjCommand.Parameters.Add(new OleDbParameter("@MDoctorId",OleDbType.Char,6,"DOCTORID"));
		ObjCommand.Parameters["@MDoctorId"].Value=StrDoctorId;
		
		return ObjCommand;
	}

	// SELECT ALL RECORD IN Doctor TABLE
	public OleDbCommand Get_All()
	{

		// get Stored procedure name for Get All record in Doctor table
		SP.DOCTOR = (clsdatadefinition.SPDoctor)4;  //4 is used for get search all stored procedure name
		StrData = SP.DOCTOR.ToString().Replace("3",".");
			
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORNAME",OleDbType.VarChar,66,"DOCTORNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,3,"BG"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORT",OleDbType.VarChar,20,"PASSPORT"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE",OleDbType.VarChar,15,"HPHONE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE",OleDbType.VarChar,15,"OPHONE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONE",OleDbType.VarChar,15,"CPHONE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,15,"PAGERNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,150,"EMAIL"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,255,"ADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,5,"SPECIALITYTYPEID"));

		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MDOCTORNAME"].Value=StrDOCTORNAME;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MSEX"].Value=StrSex;
		ObjCommand.Parameters["@MBG"].Value=StrBG;
		ObjCommand.Parameters["@MMS"].Value=StrMS;
		ObjCommand.Parameters["@MNIC"].Value=StrNIC;
		ObjCommand.Parameters["@MPASSPORT"].Value=StrPassport;
		ObjCommand.Parameters["@MHPHONE"].Value=StrHPHONE;
		ObjCommand.Parameters["@MOPHONE"].Value=StrOPHONE;
		ObjCommand.Parameters["@MCPHONE"].Value=StrCphoneNo;
		ObjCommand.Parameters["@MPAGERNO"].Value=StrPagerno;
		ObjCommand.Parameters["@MEMAIL"].Value=StrEmail;
		ObjCommand.Parameters["@MADDRESS"].Value=StrAddress;
		ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSPECIALITYTYPEID;


		
		return ObjCommand;
	}

	// SELECT SINGLE RECORD FROM Doctor
	public OleDbCommand Get_Single()
	{

		// get Stored procedure name for Search Single record in Doctor table
		SP.DOCTOR = (clsdatadefinition.SPDoctor)5; //5 is used for get search Single stored procedure name
		StrData = SP.DOCTOR.ToString().Replace("3",".");
			
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
		
		ObjCommand.Parameters.Add(new OleDbParameter("@MDoctorId",OleDbType.Char,6,"DOCTORID"));
		ObjCommand.Parameters["@MDoctorId"].Value=StrDoctorId;
		
		return ObjCommand;
	}

#endregion

	}
}
