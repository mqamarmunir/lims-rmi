using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clslogin.
	/// </summary>
	/// 
	public class clslogin:Iinterface
	{
		public clslogin()
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
		string StrPersonId=null;		
		string StrActive = null;
		string StrLoginId = null;
		string StrPassword=null;
		string StrTitle = null;
		string StrFName = null;
		string StrMName = null;
		string StrLName = null;
		string StrAcronym = null;
		string StrFHName = null;
		string StrSex = null;
		string StrBG = null;
		string StrDOB = null;
		string StrAge = null;
		string StrMS = null;
		string StrNIC = null;
		string StrNICVUpto = null;
		string StrPassport = null;
		string StrPVUpto = null;
		string StrHPNo1 = null;
		string StrHPNo2 = null;
		string StrOPNo1 = null;
		string StrOPNo2 = null;
		string StrCPNo = null;
		string StrPNo = null;
		string StrEmail = null;
		string StrAddress = null;
		string StrPRef = null;
		string StrSTID = null;
		string StrPersonName = null;

		#endregion

		#region "Properties"

		/// <summary>
		/// Personal Primary Key
		/// </summary>
		public string PKeycode
		{
			get
			{
				return StrPersonId;
			}
			set
			{
				StrPersonId=value;
			}
		}

		
		/// <summary>
		/// Person Active or Inactive
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
		/// Person Login ID
		/// </summary>
		public string LoginId
		{
			get
			{
				return StrLoginId;
			}
			set
			{
				StrLoginId=value;
			}
		}


		/// <summary>
		/// Person Login Password
		/// </summary>
		public string Password
		{
			get
			{
				return StrPassword;
			}

			set
			{
				StrPassword=value;
			}
		}


		/// <summary>
		/// Person Title
		/// </summary>
		public string Title
		{
			get
			{
				return StrTitle;
			}
			set
			{
				StrTitle = value;
			}
		}
		

		/// <summary>
		/// Person First Name
		/// </summary>
		public string FName
		{
			get
			{
				return StrFName;
			}
			set
			{
				StrFName = value;
			}
		}


		/// <summary>
		/// Person Middle Name
		/// </summary>
		public string MName
		{
			get
			{
				return StrMName;
			}
			set
			{
				StrMName = value;
			}
		}


		/// <summary>
		/// Person Last Name
		/// </summary>
		public string LName
		{
			get
			{
				return StrLName;
			}
			set
			{
				StrLName = value;
			}
		}


		/// <summary>
		/// Person Acronym/Nick Name
		/// </summary>
		public string Acronym
		{
			get
			{
				return StrAcronym;
			}
			set
			{
				StrAcronym = value;
			}
		}


		/// <summary>
		/// Person Father/Husband Name
		/// </summary>
		public string FHName
		{
			get
			{
				return StrFHName;
			}
			set
			{
				StrFHName = value;
			}
		}


		/// <summary>
		/// Person Sex
		/// </summary>
		public string Sex
		{
			get
			{
				return StrSex;
			}
			set
			{
				StrSex = value;
			}
		}


		/// <summary>
		/// Person Blood Group
		/// </summary>
		public string BG
		{
			get
			{
				return StrBG;
			}
			set
			{
				StrBG = value;
			}
		}


		/// <summary>
		/// Person Date of Birth in (dd/mm/yyyy)
		/// </summary>
		public string DOBirth
		{
			get
			{
				return StrDOB;
			}
			set
			{
				StrDOB = value;
			}
		}


		/// <summary>
		/// Person Age
		/// </summary>
		public string Age
		{
			get
			{
				return StrAge;
			}
			set
			{
				StrAge = value;
			}
		}


		/// <summary>
		/// Person Marital Status
		/// </summary>
		public string MS
		{
			get
			{
				return StrMS;
			}
			set
			{
				StrMS = value;
			}
		}


		/// <summary>
		/// Person National Identity Card Number
		/// </summary>
		public string NIC
		{
			get
			{
				return StrNIC;
			}
			set
			{
				StrNIC = value;
			}
		}


		/// <summary>
		/// Person National Identity Card Validation upto Date
		/// </summary>
		public string NICVUpto
		{
			get
			{
				return StrNICVUpto;
			}
			set
			{
				StrNICVUpto = value;
			}
		}


		/// <summary>
		/// Person Passport Number
		/// </summary>
		public string Passport
		{
			get
			{
				return StrPassport;
			}
			set
			{
				StrPassport = value;
			}
		}


		/// <summary>
		/// Person Passport Validation upto Date
		/// </summary>
		public string PVUpto
		{
			get
			{
				return StrPVUpto;
			}
			set
			{
				StrPVUpto = value;
			}
		}


		/// <summary>
		/// Person House Phone Number 1
		/// </summary>
		public string HPNo1
		{
			get
			{
				return StrHPNo1;
			}
			set
			{
				StrHPNo1 = value;
			}
		}


		/// <summary>
		/// Person House Phone Number 2
		/// </summary>
		public string HPNo2
		{
			get
			{
				return StrHPNo2;
			}
			set
			{
				StrHPNo2 = value;
			}
		}


		/// <summary>
		/// Person Office Phone Number 1
		/// </summary>
		public string OPNo1
		{
			get
			{
				return StrOPNo1;
			}
			set
			{
				StrOPNo1 = value;
			}
		}


		/// <summary>
		/// Person Office Phone Number 2
		/// </summary>
		public string OPNo2
		{
			get
			{
				return StrOPNo2;
			}
			set
			{
				StrOPNo2 = value;
			}
		}


		/// <summary>
		/// Person Cell Phone Number
		/// </summary>
		public string CPNo
		{
			get
			{
				return StrCPNo;
			}
			set
			{
				StrCPNo = value;
			}
		}


		/// <summary>
		/// Person Pager Number
		/// </summary>
		public string PNo
		{
			get
			{
				return StrPNo;
			}
			set
			{
				StrPNo = value;
			}
		}


		/// <summary>
		/// Person Email Address
		/// </summary>
		public string Email
		{
			get
			{
				return StrEmail;
			}
			set
			{
				StrEmail = value;
			}
		}


		/// <summary>
		/// Person Address
		/// </summary>
		public string Address
		{
			get
			{
				return StrAddress;
			}
			set
			{
				StrAddress = value;
			}
		}


		/// <summary>
		/// Person Picture Reference
		/// </summary>
		public string PReference
		{
			get
			{
				return StrPRef;
			}
			set
			{
				StrPRef = value;
			}
		}


		/// <summary>
		/// Person Specialty Type Identity
		/// </summary>
		public string STID
		{
			get
			{
				return StrSTID;
			}
			set
			{
				StrSTID = value;
			}
		}


		/// <summary>
		/// Person Name
		/// </summary>
		public string PName
		{
			get
			{
				return StrPersonName;
			}
			set
			{
				StrPersonName = value;
			}
		}
		
		
		#endregion

		#region "Data_Methods"
		
		/// <summary>
		/// Insert Data in Personal Table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public  OleDbCommand Insert()
		{
/*			// Get Stored procedure name for insert PERSONAL table
		
			SP.PERSONALTABLE = (clsdatadefinition.SPPersonalTable)1; // 1 is used for get insert stored procedure name
			StrData = SP.PERSONALTABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
		
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.VarChar,5,ParameterDirection.Output,false,0,0,"PERSONID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLOGINID",OleDbType.VarChar,10,"LOGINID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPASSWORD",OleDbType.VarChar,10,"PASWORD"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFNAME",OleDbType.VarChar,15,"FNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMNAME",OleDbType.VarChar,15,"MNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLNAME",OleDbType.VarChar,15,"LNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,10,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.VarChar,25,"FHNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
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
			ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,20,"PAGERNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,100,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALTYTYPEID"));
			ObjCommand.Parameters["@MACTIVE"].Value = StrActive;
			ObjCommand.Parameters["@MLOGINID"].Value = StrLoginId;
			ObjCommand.Parameters["@MPASSWORD"].Value = StrPassword;
			ObjCommand.Parameters["@MTITLE"].Value = StrTitle;
			ObjCommand.Parameters["@MFNAME"].Value = StrFName;
			ObjCommand.Parameters["@MMNAME"].Value = StrMName;
			ObjCommand.Parameters["@MLNAME"].Value = StrLName;
			ObjCommand.Parameters["@MACRONYM"].Value = StrAcronym;
			ObjCommand.Parameters["@MFHNAME"].Value = StrFHName;
			ObjCommand.Parameters["@MSEX"].Value = StrSex;
			ObjCommand.Parameters["@MBG"].Value = StrBG;
			ObjCommand.Parameters["@MDOB"].Value = StrDOB;
			ObjCommand.Parameters["@MAGE"].Value = StrAge;
			ObjCommand.Parameters["@MMS"].Value = StrMS;
			ObjCommand.Parameters["@MNIC"].Value = StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value = StrNICVUpto;
			ObjCommand.Parameters["@MPASSPORT"].Value = StrPassport;
			ObjCommand.Parameters["@MPASSPORTVALIDUPTO"].Value = StrPVUpto;
			ObjCommand.Parameters["@MHPHONENO1"].Value = StrHPNo1;
			ObjCommand.Parameters["@MHPHONENO2"].Value = StrHPNo2;
			ObjCommand.Parameters["@MOPHONENO1"].Value = StrOPNo1;
			ObjCommand.Parameters["@MOPHONENO2"].Value = StrOPNo2;
			ObjCommand.Parameters["@MCPHONENO"].Value = StrCPNo;
			ObjCommand.Parameters["@MPAGERNO"].Value = StrPNo;
			ObjCommand.Parameters["@MEMAIL"].Value = StrEmail;
			ObjCommand.Parameters["@MADDRESS"].Value = StrAddress;
			ObjCommand.Parameters["@MPICTUREREF"].Value = StrPRef;
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value = StrSTID;
			
			return ObjCommand;			*/			return null;
		}


		/// <summary>
		/// Update Record in Personal Table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in PERSONAL table
			
/*			SP.PERSONALTABLE = (clsdatadefinition.SPPersonalTable)2; // 2 is used for get update stored procedure name
			StrData = SP.PERSONALTABLE.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();
			
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
				
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONALID",OleDbType.VarChar,5,"PERSONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MPASSWORD",OleDbType.VarChar,10,"PASWORD"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFNAME",OleDbType.VarChar,15,"FNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMNAME",OleDbType.VarChar,15,"MNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLNAME",OleDbType.VarChar,15,"LNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,10,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.VarChar,25,"FHNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
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
			ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,20,"PAGERNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,100,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALTYTYPEID"));

			ObjCommand.Parameters["@MPERSONALID"].Value = StrPersonId;
			ObjCommand.Parameters["@MACTIVE"].Value = StrActive;			
			ObjCommand.Parameters["@MPASSWORD"].Value = StrPassword;
			ObjCommand.Parameters["@MTITLE"].Value = StrTitle;
			ObjCommand.Parameters["@MFNAME"].Value = StrFName;
			ObjCommand.Parameters["@MMNAME"].Value = StrMName;
			ObjCommand.Parameters["@MLNAME"].Value = StrLName;
			ObjCommand.Parameters["@MACRONYM"].Value = StrAcronym;
			ObjCommand.Parameters["@MFHNAME"].Value = StrFHName;
			ObjCommand.Parameters["@MSEX"].Value = StrSex;
			ObjCommand.Parameters["@MBG"].Value = StrBG;
			ObjCommand.Parameters["@MDOB"].Value = StrDOB;
			ObjCommand.Parameters["@MAGE"].Value = StrAge;
			ObjCommand.Parameters["@MMS"].Value = StrMS;
			ObjCommand.Parameters["@MNIC"].Value = StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value = StrNICVUpto;
			ObjCommand.Parameters["@MPASSPORT"].Value = StrPassport;
			ObjCommand.Parameters["@MPASSPORTVALIDUPTO"].Value = StrPVUpto;
			ObjCommand.Parameters["@MHPHONENO1"].Value = StrHPNo1;
			ObjCommand.Parameters["@MHPHONENO2"].Value = StrHPNo2;
			ObjCommand.Parameters["@MOPHONENO1"].Value = StrOPNo1;
			ObjCommand.Parameters["@MOPHONENO2"].Value = StrOPNo2;
			ObjCommand.Parameters["@MCPHONENO"].Value = StrCPNo;
			ObjCommand.Parameters["@MPAGERNO"].Value = StrPNo;
			ObjCommand.Parameters["@MEMAIL"].Value = StrEmail;
			ObjCommand.Parameters["@MADDRESS"].Value = StrAddress;
			ObjCommand.Parameters["@MPICTUREREF"].Value = StrPRef;
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value = StrSTID;
			
			return ObjCommand;			*/			return null;
		}


		/// <summary>
		/// Delete Record from Personal table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in PERSONAL table
			
/*			SP.PERSONALTABLE = (clsdatadefinition.SPPersonalTable)3; //3 is used for get delete stored procedure name
			StrData = SP.PERSONALTABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONALID",OleDbType.Char,5,"PERSONID"));
			ObjCommand.Parameters["@MPERSONALID"].Value = StrPersonId;
			
			return ObjCommand;			*/			return null;
		}

		
		/// <summary>
		/// Get All Function for Personal table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in CLINIC table
/*			SP.PERSONALTABLE = (clsdatadefinition.SPPersonalTable)4;
			StrData = SP.PERSONALTABLE.ToString().Replace("3",".");

			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MLOGINID",OleDbType.VarChar,10,"LOGINID"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MPASSWORD",OleDbType.VarChar,10,"PASWORD"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONNAME",OleDbType.VarChar,45,"PERSONNAME"));	
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,10,"ACRONYM"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MPASSPORT",OleDbType.VarChar,20,"PASSPORT"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONENO",OleDbType.VarChar,15,"HPHONENO1"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONENO",OleDbType.VarChar,15,"OPHONENO1"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONENO",OleDbType.VarChar,15,"CPHONENO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPAGERNO",OleDbType.VarChar,20,"PAGERNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALTYTYPEID"));
			
			ObjCommand.Parameters["@MACTIVE"].Value = StrActive;
			ObjCommand.Parameters["@MLOGINID"].Value = StrLoginId;			
			ObjCommand.Parameters["@MPASSWORD"].Value = StrPassword;			
			ObjCommand.Parameters["@MPERSONNAME"].Value = StrPersonName;
			ObjCommand.Parameters["@MACRONYM"].Value = StrAcronym;			
			ObjCommand.Parameters["@MSEX"].Value = StrSex;
			ObjCommand.Parameters["@MBG"].Value = StrBG;			
			ObjCommand.Parameters["@MMS"].Value = StrMS;
			ObjCommand.Parameters["@MNIC"].Value = StrNIC;			
			ObjCommand.Parameters["@MPASSPORT"].Value = StrPassport;
			ObjCommand.Parameters["@MHPHONENO"].Value = StrHPNo1;			
			ObjCommand.Parameters["@MOPHONENO"].Value = StrOPNo1;			
			ObjCommand.Parameters["@MCPHONENO"].Value = StrCPNo;
			ObjCommand.Parameters["@MPAGERNO"].Value = StrPNo;
			ObjCommand.Parameters["@MEMAIL"].Value = StrEmail;
			ObjCommand.Parameters["@MADDRESS"].Value = StrAddress;			
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value = StrSTID;
	
			return ObjCommand;			*/			return null;
		}


		/// <summary>
		/// Get Single Record from PERSONAL table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_Single()
		{
			// get Stored procedure name for Search Single record in CLINIC table
/*			SP.PERSONALTABLE = (clsdatadefinition.SPPersonalTable)5; //5 is used for get search Single stored procedure name
			StrData = SP.PERSONALTABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONALID",OleDbType.VarChar,5,"PERSONID"));
			ObjCommand.Parameters["@MPERSONALID"].Value = StrPersonId;
				
			return ObjCommand;			*/			return null;
		}

		#endregion
	}	
}
