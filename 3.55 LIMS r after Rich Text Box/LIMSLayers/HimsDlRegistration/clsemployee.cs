using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsemployee.
	/// </summary>
	public class clsemployee:Iinterface
	{
		public clsemployee()
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
		private string StrEMPLOYEEID;
		private string StrPLNO;
		private string StrTITLE;
		private string StrEFNAME;
		private string StrEMNAME;
		private string StrELNAME;
		private string StrACTIVE;
		private string StrPICTUREREF;
		private string StrFACTORYID;	
		private string StrSEX;
		private string StrBG;
		private string StrDOB;
		private string StrMS;
		private string StrNIC;
		private string StrNICVALIDUPTO;
		private string StrHPHONE1;
		private string StrHPHONE2;
		private string StrOPHONE1;
		private string StrOPHONE2;
		private string StrCPHONE;
		private string StrEMAIL;
		private string StrTEMPADDRESS;
		private string StrPERMENTADDRESS;
		private string StrWELFARECONTNO;
		private string StrORGID;
		private string StrRANKID;
		private string StrSECTIONID;
		private string StrFHNAME;
		private string StrServiceType;
		private string StrDOJ;
		private string StrBPS;
		private string StrGatePassNo;

		// Additional Vaiables Declarte for search Funcation Get All
		private string StrMEMPLOYEENAME;
		private string StrMADDRESS;
		private string StrMHPHONE;
		private string StrMOPHONE;

		#endregion

		#region "Properties"
		
		/// <summary>
		/// EMPLOYEEID Primary key
		/// </summary>
		public string PKeycode
		{
			get
			{
				return StrEMPLOYEEID;
			}
			set
			{
				StrEMPLOYEEID = value;
			}
		}
		/// <summary>
		/// PLNO table field
		/// </summary>
		public string PLNO
		{
			get
			{
				return StrPLNO;
			}
			set
			{
				StrPLNO = value;
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
				StrTITLE = value;
			}
		}

		/// <summary>
		/// EFNAME table field
		/// </summary>
		public string EFNAME
		{
			get
			{
				return StrEFNAME;
			}
			set
			{
				StrEFNAME = value;
			}
		}

		/// <summary>
		/// EMNAME table field
		/// </summary>
		public string EMNAME
		{
			get
			{
				return StrEMNAME;
			}
			set
			{
				StrEMNAME = value;
			}
		}

		/// <summary>
		/// ELNAME table field
		/// </summary>
		public string ELNAME
		{
			get
			{
				return StrELNAME;
			}
			set
			{
				StrELNAME = value;
			}
		}

	
		/// <summary>
		/// ACTIVE table field
		/// </summary>
		public string ACTIVE
		{
			get
			{
				return StrACTIVE;
			}
			set
			{
				StrACTIVE = value;
			}
		}

		/// <summary>
		/// PICTUREREF table field
		/// </summary>
		public string PICTUREREF
		{
			get
			{
				return StrPICTUREREF;
			}
			set
			{
				StrPICTUREREF = value;
			}
		}

		/// <summary>
		/// FACTORYID table field
		/// </summary>
		public string FACTORYID
		{
			get
			{
				return StrFACTORYID;
			}
			set
			{
				StrFACTORYID = value;
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
				StrSEX = value;
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
				StrBG = value;
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
				StrDOB = value;
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
				StrMS = value;
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
				StrNIC = value;
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
				StrNICVALIDUPTO = value;
			}
		}

		/// <summary>
		/// HPHONE1 table field
		/// </summary>
		public string HPHONE1
		{
			get
			{
				return StrHPHONE1;
			}
			set
			{
				StrHPHONE1 = value;
			}
		}

		/// <summary>
		/// HPHONE2 table field
		/// </summary>
		public string HPHONE2
		{
			get
			{
				return StrHPHONE2;
			}
			set
			{
				StrHPHONE2 = value;
			}
		}

		/// <summary>
		/// OPHONE1 table field
		/// </summary>
		public string OPHONE1
		{
			get
			{
				return StrOPHONE1;
			}
			set
			{
				StrOPHONE1 = value;
			}
		}

		/// <summary>
		/// OPHONE2 table field
		/// </summary>
		public string OPHONE2
		{
			get
			{
				return StrOPHONE2;
			}
			set
			{
				StrOPHONE2 = value;
			}
		}

		/// <summary>
		/// OPHONE2 table field
		/// </summary>
		public string CPHONE
		{
			get
			{
				return StrCPHONE;
			}
			set
			{
				StrCPHONE = value;
			}
		}

		/// <summary>
		/// OPHONE2 table field
		/// </summary>
		public string EMAIL
		{
			get
			{
				return StrEMAIL;
			}
			set
			{
				StrEMAIL = value;
			}
		}

		/// <summary>
		/// TEMPADDRESS table field
		/// </summary>
		public string TEMPADDRESS
		{
			get
			{
				return StrTEMPADDRESS;
			}
			set
			{
				StrTEMPADDRESS = value;
			}
		}

		/// <summary>
		/// TEMPADDRESS table field
		/// </summary>
		public string PERMENTADDRESS
		{
			get
			{
				return StrPERMENTADDRESS;
			}
			set
			{
				StrPERMENTADDRESS = value;
			}
		}

		/// <summary>
		/// WELFARECONTNO table field
		/// </summary>
		public string WELFARECONTNO
		{
			get
			{
				return StrWELFARECONTNO;
			}
			set
			{
				StrWELFARECONTNO = value;
			}
		}

		/// <summary>
		/// FACTORYTYPE table field changed to ORGID
		/// </summary>
		public string ORGID
		{
			get
			{
				return StrORGID;
			}
			set
			{
				StrORGID = value;
			}
		}

		/// <summary>
		/// RANKID table field
		/// </summary>
		public string RANKID
		{
			get
			{
				return StrRANKID;
			}
			set
			{
				StrRANKID = value;
			}
		}

		/// <summary>
		/// SECTIONID table field
		/// </summary>
		public string SECTIONID
		{
			get
			{
				return StrSECTIONID;
			}
			set
			{
				StrSECTIONID = value;
			}
		}


		/// <summary>
		/// Employee Name table field
		/// </summary>
		public string EmployeeName
		{
			get
			{
				return StrMEMPLOYEENAME;
			}
			set
			{
				StrMEMPLOYEENAME = value;
			}
		}


		/// <summary>
		/// Address table field
		/// </summary>
		public string Address
		{
			get
			{
				return StrMADDRESS;
			}
			set
			{
				StrMADDRESS = value;
			}
		}

		/// <summary>
		/// Home Phone table field
		/// </summary>
		public string HPhone
		{
			get
			{
				return StrMHPHONE;
			}
			set
			{
				StrMHPHONE = value;
			}
		}

		/// <summary>
		/// Office Phone table field
		/// </summary>
		public string OPhone
		{
			get
			{
				return StrMOPHONE;
			}
			set
			{
				StrMOPHONE = value;
			}
		}

		/// <summary>
		/// FH Name table field
		/// </summary>

		public string FHName
		{
			get
			{
				return StrFHNAME;
			}
			set
			{
				StrFHNAME=value;
			}
		}

		public string ServiceType
		{
			set{	StrServiceType = value;	}
		}

		public string DOJ
		{
			set{	StrDOJ = value;	}
		}

		public string BPS
		{
			set{	StrBPS = value;	}
		}

		public string GatePassNo
		{
			get{	return StrGatePassNo;	}
			set{	StrGatePassNo = value;	}
		}

		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN EMPLOYEE TABLE
		public  OleDbCommand Insert()
		{
	
			// Get Stored procedure name for insert EMPLOYEE table
			SP.EMPLOYEE = (clsdatadefinition.SPEmployee)1; // 1 is used for get insert stored procedure name
			StrData = SP.EMPLOYEE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,7,ParameterDirection.Output,false,0,0,"EMPLOYEEID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNO",OleDbType.VarChar,10,"PLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,10,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEFNAME",OleDbType.VarChar,15,"EFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMNAME",OleDbType.VarChar,15,"EMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MELNAME",OleDbType.VarChar,15,"ELNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.VarChar,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,50,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,10,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.Char,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,10,"NICVALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE1",OleDbType.VarChar,15,"HPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE2",OleDbType.VarChar,15,"HPHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE1",OleDbType.VarChar,15," OPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE2",OleDbType.VarChar,15,"OPHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONE",OleDbType.VarChar,15,"CPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50," EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTEMPADDRESS",OleDbType.VarChar,250,"TEMPADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERMENTADDRESS",OleDbType.VarChar,250,"PERMENTADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MWELFARECONTNO",OleDbType.VarChar,15,"WELFARECONTNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RANKID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.Char,50,"FHNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MServiceType", OleDbType.Char, 1, "ServiceType"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOJ", OleDbType.VarChar, 10, "DOJ"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBPS", OleDbType.VarChar, 2, "BPS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MGatePassNo", OleDbType.VarChar, 10, "GatePassNo"));
	
			ObjCommand.Parameters["@MPLNO"].Value=StrPLNO;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MEFNAME"].Value=StrEFNAME;
			ObjCommand.Parameters["@MEMNAME"].Value=StrEMNAME;
			ObjCommand.Parameters["@MELNAME"].Value=StrELNAME;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFACTORYID;		
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNICVALIDUPTO;
			ObjCommand.Parameters["@MHPHONE1"].Value=StrHPHONE1;
			ObjCommand.Parameters["@MHPHONE2"].Value=StrHPHONE2;
			ObjCommand.Parameters["@MOPHONE1"].Value=StrOPHONE1;
			ObjCommand.Parameters["@MOPHONE2"].Value=StrOPHONE2;
			ObjCommand.Parameters["@MCPHONE"].Value=StrCPHONE;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MTEMPADDRESS"].Value=StrTEMPADDRESS;
			ObjCommand.Parameters["@MPERMENTADDRESS"].Value=StrPERMENTADDRESS;
			ObjCommand.Parameters["@MWELFARECONTNO"].Value=StrWELFARECONTNO;
			ObjCommand.Parameters["@MORGID"].Value = StrORGID;
			ObjCommand.Parameters["@MRANKID"].Value=StrRANKID;
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSECTIONID;
			ObjCommand.Parameters["@MFHNAME"].Value=StrFHNAME;
			ObjCommand.Parameters["@MServiceType"].Value= StrServiceType;
			ObjCommand.Parameters["@MDOJ"].Value = StrDOJ;
			ObjCommand.Parameters["@MBPS"].Value = StrBPS;
			ObjCommand.Parameters["@MGatePassNo"].Value = StrGatePassNo;

			return ObjCommand;
		}

		// UPDATE RECORD IN EMPLOYEE TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in EMPLOYEE table
			SP.EMPLOYEE = (clsdatadefinition.SPEmployee)2; // 2 is used for get update stored procedure name
			StrData = SP.EMPLOYEE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,7,"EMPLOYEEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNO",OleDbType.VarChar,10,"PLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,5,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEFNAME",OleDbType.VarChar,15,"EFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMNAME",OleDbType.VarChar,15,"EMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MELNAME",OleDbType.VarChar,15,"ELNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.VarChar,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,50,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,10,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,10,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.Char,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNICVALIDUPTO",OleDbType.VarChar,10,"NICVALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE1",OleDbType.VarChar,15,"HPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE2",OleDbType.VarChar,15,"HPHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE1",OleDbType.VarChar,15," OPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE2",OleDbType.VarChar,15,"OPHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONE",OleDbType.VarChar,15,"CPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50," EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTEMPADDRESS",OleDbType.VarChar,250,"TEMPADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERMENTADDRESS",OleDbType.VarChar,250,"PERMENTADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MWELFARECONTNO",OleDbType.VarChar,15,"WELFARECONTNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RANKID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFHNAME",OleDbType.Char,50,"FHNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MServiceType", OleDbType.Char, 1, "ServiceType"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOJ", OleDbType.VarChar, 10, "DOJ"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBPS", OleDbType.VarChar, 2, "BPS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MGatePassNo", OleDbType.VarChar, 10, "GatePassNo"));

			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
			ObjCommand.Parameters["@MPLNO"].Value=StrPLNO;
			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MEFNAME"].Value=StrEFNAME;
			ObjCommand.Parameters["@MEMNAME"].Value=StrEMNAME;
			ObjCommand.Parameters["@MELNAME"].Value=StrELNAME;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFACTORYID;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MNICVALIDUPTO"].Value=StrNICVALIDUPTO;
			ObjCommand.Parameters["@MHPHONE1"].Value=StrHPHONE1;
			ObjCommand.Parameters["@MHPHONE2"].Value=StrHPHONE2;
			ObjCommand.Parameters["@MOPHONE1"].Value=StrOPHONE1;
			ObjCommand.Parameters["@MOPHONE2"].Value=StrOPHONE2;
			ObjCommand.Parameters["@MCPHONE"].Value=StrCPHONE;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MTEMPADDRESS"].Value=StrTEMPADDRESS;
			ObjCommand.Parameters["@MPERMENTADDRESS"].Value=StrPERMENTADDRESS;
			ObjCommand.Parameters["@MWELFARECONTNO"].Value=StrWELFARECONTNO;
			ObjCommand.Parameters["@MORGID"].Value = StrORGID;	
			ObjCommand.Parameters["@MRANKID"].Value=StrRANKID;
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSECTIONID;
			ObjCommand.Parameters["@MFHNAME"].Value= StrFHNAME;
			ObjCommand.Parameters["@MServiceType"].Value = StrServiceType;
			ObjCommand.Parameters["@MDOJ"].Value = StrDOJ;
			ObjCommand.Parameters["@MBPS"].Value = StrBPS;
			ObjCommand.Parameters["@MGatePassNo"].Value = StrGatePassNo;

			return ObjCommand;
		}

		// DELETE RECORD IN EMPLOYEE TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in EMPLOYEE table
			SP.EMPLOYEE = (clsdatadefinition.SPEmployee)3; //3 is used for get delete stored procedure name
			StrData = SP.EMPLOYEE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,5,"EMPLOYEEID"));

			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;
		
			return ObjCommand;
		}

		// SELECT ALL RECORD IN EMPLOYEE TABLE
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in EMPLOYEE table
			SP.EMPLOYEE = (clsdatadefinition.SPEmployee)4;  //4 is used for get search all stored procedure name
			StrData = SP.EMPLOYEE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNO",OleDbType.VarChar,10,"PLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEENAME",OleDbType.VarChar,50,"EMPLOYEENAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RANKID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.Char,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.Char,1,"SEX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBG",OleDbType.VarChar,5,"BG"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.Char,1,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50," EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,250,"ADDRESS"));		
			ObjCommand.Parameters.Add(new OleDbParameter("@MHPHONE",OleDbType.VarChar,15,"HPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOPHONE",OleDbType.VarChar,15," OPHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCPHONE",OleDbType.VarChar,15,"CPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MWELFARECONTNO",OleDbType.VarChar,15,"WELFARECONTNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MServiceType", OleDbType.Char, 1, "ServiceType"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBPS", OleDbType.VarChar, 2, "BPS"));

			ObjCommand.Parameters["@MPLNO"].Value=StrPLNO;
			ObjCommand.Parameters["@MEMPLOYEENAME"].Value=StrMEMPLOYEENAME;
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFACTORYID;
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSECTIONID;
			ObjCommand.Parameters["@MRANKID"].Value=StrRANKID;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			ObjCommand.Parameters["@MBG"].Value=StrBG;
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			ObjCommand.Parameters["@MADDRESS"].Value=StrMADDRESS;
			ObjCommand.Parameters["@MHPHONE"].Value=StrMHPHONE;
			ObjCommand.Parameters["@MOPHONE"].Value=StrMOPHONE;
			ObjCommand.Parameters["@MCPHONE"].Value=StrCPHONE;
			ObjCommand.Parameters["@MWELFARECONTNO"].Value=StrWELFARECONTNO;
			ObjCommand.Parameters["@MORGID"].Value = StrORGID;
			ObjCommand.Parameters["@MServiceType"].Value = StrServiceType;
			ObjCommand.Parameters["@MBPS"].Value = StrBPS;

			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM EMPLOYEE
		public OleDbCommand Get_Single()
		{
			// get Stored procedure name for Search Single record in EMPLOYEE table
			SP.EMPLOYEE = (clsdatadefinition.SPEmployee)5; //5 is used for get search Single stored procedure name
			StrData = SP.EMPLOYEE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMPLOYEEID",OleDbType.Char,7,"EMPLOYEEID"));
			ObjCommand.Parameters["@MEMPLOYEEID"].Value=StrEMPLOYEEID;

			return ObjCommand;
		}

		public string GetMax_PLNo(OleDbConnection conn, OleDbTransaction trans, string strPrefix)
		{
			try
			{
				OleDbCommand ObjCommand = new OleDbCommand();
				ObjCommand.CommandText = "PK_Employee.P_GM_PLNO";
				ObjCommand.CommandType = CommandType.StoredProcedure;
								
				ObjCommand.Parameters.Add(new OleDbParameter("@MPrefix", OleDbType.VarChar));

				ObjCommand.Parameters["@MPrefix"].Value = strPrefix;

				ObjCommand.Connection = conn;
				ObjCommand.Transaction = trans;

				OleDbDataAdapter da = new OleDbDataAdapter(ObjCommand);
				DataSet DS = new DataSet();
				da.Fill(DS);

				return DS.Tables[0].Rows[0]["PLNo"].ToString();
			}
			catch(Exception ex)
			{				
				return ex.Message;
			}
		}

		#endregion
	
	}
}