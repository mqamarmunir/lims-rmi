using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clstpatientvisit.
	/// </summary>
	/// #region "Class Variable Declaration"


	public class clstpvregistration:Iinterface
	{
		#region "Class Variable Declaration"

		// call stored procedure name from clsdatdefinition class
		clsdatadefinition.StoredProcedure SP;

		#endregion


		#region "Variable Declaration"

		// use for string data
		private string StrData;
		private string StrTITLE;
		private string StrPFNAME;
		private string StrPMNAME;
		private string StrPLNAME;
		private string StrSEX;
		private string StrDOB;
		private string StrBG;
		private string StrMS;
		private string StrNIC;
		private string StrPICTUREREF;
		private string StrADDRESS;
		private string StrCELLPHONE;
		private string StrPHONE1;
		private string StrPHONE2;
		private string StrFAX;
		private string StrEMAIL;
		private string StrREGISTEREDBY;
		private string StrLASTVISITNO;
		private string StrPTYPE;
		private string StrPATIENTID;
		private string StrRelation;

		#endregion


		#region "Properties"

		/// <summary>
		/// Registered By (User Logged in)
		/// </summary>
		public string RegisteredBy
		{
			get{	return StrREGISTEREDBY;		}
			set{	StrREGISTEREDBY = value;	}
		}

		public string LastVistNo
		{
			get{	return StrLASTVISITNO;	}
			set{	StrLASTVISITNO = value;	}
		}

		public string Fax
		{
			get{	return StrFAX;	}
			set{	StrFAX = value;	}
		}

		public string CellPhone
		{
			get{	return StrCELLPHONE;	}
			set{	StrCELLPHONE = value;	}
		}

		public string Phone1
		{
			get{	return StrPHONE1;	}
			set{	StrPHONE1=	value;	}
		}

		public string Phone2
		{
			get{	return StrPHONE2;	}
			set{	StrPHONE2= value;	}
		}

		public string PKeycode
		{
			get{	return StrPATIENTID;	}
			set{	StrPATIENTID=value;		}
		}

		/// <summary>
		/// Patient Type (Entitled or CNE) table field
		/// </summary>
		public string PTYPE
		{
			get{	return StrPTYPE;	}
			set{	StrPTYPE=value;		}
		}

		/// <summary>
		/// TITLE table field
		/// </summary>
		public string TITLE
		{
			get{	return StrTITLE;	}
			set{	StrTITLE=value;		}
		}

		/// <summary>
		/// Patient First Name table field
		/// </summary>
		public string PFNAME
		{
			get{	return StrPFNAME;	}
			set{	StrPFNAME=value;	}
		}

		/// <summary>
		/// Patient Middle Name table field
		/// </summary>
		public string PMNAME
		{
			get{	return StrPMNAME;	}
			set{	StrPMNAME=value;	}
		}

		/// <summary>
		/// Patient Last Name table field
		/// </summary>
		public string PLNAME
		{
			get{	return StrPLNAME;	}
			set{	StrPLNAME=value;	}
		}

		/// <summary>
		/// Sex table field
		/// </summary>
		public string SEX
		{
			get{	return StrSEX;	}
			set{	StrSEX=value;	}
		}

		/// <summary>
		/// Blood Group table field
		/// </summary>
		public string BLOODGROUP
		{
			get{	return StrBG;	}
			set{	StrBG=value;	}
		}

		/// <summary>
		/// Date of Birth table field
		/// </summary>
		public string DOB
		{
			get{	return StrDOB;	}
			set{	StrDOB=value;	}
		}

		/// <summary>
		/// National Identity Card table field
		/// </summary>
		public string NIC
		{
			get{	return StrNIC;	}
			set{	StrNIC=value;	}
		}

		/// <summary>
		/// Marital Status table field
		/// </summary>
		public string MS
		{
			get{	return StrMS;	}
			set{	StrMS=value;	}
		}

		/// <summary>
		/// Email table field
		/// </summary>
		public string EMAIL
		{
			get{	return StrEMAIL;	}
			set{	StrEMAIL=value;		}
		}

		/// <summary>
		/// Address table field
		/// </summary>
		public string ADDRESS
		{
			get{	return StrADDRESS;	}
			set{	StrADDRESS=value;	}
		}

		/// <summary>
		/// Picture Reference table field
		/// </summary>
		public string PictureReference
		{
			get{	return StrPICTUREREF;	}
			set{	StrPICTUREREF=value;	}
		}

		public string Relation
		{
			get{	return StrRelation;		}
			set{	StrRelation = value;	}
		}

		#endregion
		
		
		public clstpvregistration()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		#region "Data_Methods"
		
		// INSERT DATA IN PATIENTVISIT TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert PATIENTVISIT table
			
			SP.TPATIENTREGISTRATION = (clsdatadefinition.SPTPVRegistration)1; // 1 is used for get insert stored procedure name
			StrData = SP.TPATIENTREGISTRATION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,11,ParameterDirection.Output,false,0,0,"PATIENTID",DataRowVersion.Default,null));
			
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

			ObjCommand.Parameters.Add(new OleDbParameter("@MTITLE",OleDbType.VarChar,6,"TITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPFNAME",OleDbType.VarChar,20,"PFNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPMNAME",OleDbType.VarChar,20,"PMNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLNAME",OleDbType.VarChar,20,"PLNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSEX",OleDbType.VarChar,1,"SEX"));

			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB",OleDbType.VarChar,20,"DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBLOODGROUP",OleDbType.VarChar,3,"BLOODGROUP"));

			ObjCommand.Parameters.Add(new OleDbParameter("@MMS",OleDbType.VarChar,20,"MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC",OleDbType.VarChar,20,"NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPICTUREREF",OleDbType.VarChar,255,"PICTUREREF"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MADDRESS",OleDbType.VarChar,255,"ADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLPHONE",OleDbType.VarChar,15,"CELLPHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"PHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX",OleDbType.VarChar,15,"FAX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,150,"EMAIL"));
			
			ObjCommand.Parameters.Add(new OleDbParameter("@MREGISTEREDBY",OleDbType.VarChar,6,"REGISTEREDBY"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLASTVISITNO",OleDbType.VarChar,10,"LASTVISITNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@IDPREFIX",OleDbType.VarChar,10));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRelation", OleDbType.VarChar, 4, "Relation"));

			ObjCommand.Parameters["@MTITLE"].Value=StrTITLE;
			ObjCommand.Parameters["@MPFNAME"].Value=StrPFNAME;
			ObjCommand.Parameters["@MPMNAME"].Value=StrPMNAME;
			ObjCommand.Parameters["@MPLNAME"].Value=StrPLNAME;
			ObjCommand.Parameters["@MSEX"].Value=StrSEX;
			
			ObjCommand.Parameters["@MDOB"].Value=StrDOB;
			ObjCommand.Parameters["@MBLOODGROUP"].Value=StrBG.Trim();
			
			ObjCommand.Parameters["@MMS"].Value=StrMS;
			ObjCommand.Parameters["@MNIC"].Value=StrNIC;

			ObjCommand.Parameters["@MPICTUREREF"].Value=StrPICTUREREF;
			ObjCommand.Parameters["@MADDRESS"].Value=StrADDRESS;
			ObjCommand.Parameters["@MCELLPHONE"].Value=StrCELLPHONE;
			ObjCommand.Parameters["@MPHONE1"].Value=StrPHONE1;
			ObjCommand.Parameters["@MPHONE2"].Value=StrPHONE2;
			
			ObjCommand.Parameters["@MFAX"].Value=StrFAX;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMAIL;
			
			ObjCommand.Parameters["@MREGISTEREDBY"].Value=StrREGISTEREDBY;
			ObjCommand.Parameters["@MLASTVISITNO"].Value=StrLASTVISITNO;
			ObjCommand.Parameters["@IDPREFIX"].Value = StrPTYPE;
			ObjCommand.Parameters["@MRelation"].Value = StrRelation;
			
			return ObjCommand;
		}

		// UPDATE RECORD IN TPATIENTRegistration TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in TPatientRegistration table
			SP.TPATIENTREGISTRATION = (clsdatadefinition.SPTPVRegistration)2; // 2 is used for get update stored procedure name
			StrData = SP.TPATIENTREGISTRATION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPatientID", OleDbType.Char, 11, "PatientID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTitle", OleDbType.VarChar, 6, "Title"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPFName", OleDbType.VarChar, 20, "PFName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPMName", OleDbType.VarChar, 20,"PMName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPLName", OleDbType.VarChar, 20, "PLName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSex", OleDbType.Char, 1, "Sex"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOB", OleDbType.VarChar, 10, "DOB"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBloodGroup", OleDbType.VarChar, 10, "BloodGroup"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MMS", OleDbType.Char, 1, "MS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNIC", OleDbType.VarChar, 20, "NIC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPictureRef", OleDbType.VarChar, 255, "PictureRef"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAddress", OleDbType.VarChar, 255, "Address"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCellPhone", OleDbType.VarChar, 15,"CellPhone"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhone1", OleDbType.VarChar, 15, "Phone1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhone2", OleDbType.VarChar, 15, "Phone2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFax", OleDbType.VarChar, 15, "Fax"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEmail", OleDbType.VarChar, 150, "Email"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLastVisitNo", OleDbType.VarChar, 10, "LastVisitNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRelation", OleDbType.VarChar, 4, "Relation"));
			
			ObjCommand.Parameters["@MPatientID"].Value = this.StrPATIENTID;
			ObjCommand.Parameters["@MTitle"].Value = this.StrTITLE;
			ObjCommand.Parameters["@MPFName"].Value = this.StrPFNAME;
			ObjCommand.Parameters["@MPMName"].Value = this.StrPMNAME;
			ObjCommand.Parameters["@MPLName"].Value = this.StrPLNAME;
			ObjCommand.Parameters["@MSex"].Value = this.StrSEX;
			ObjCommand.Parameters["@MDOB"].Value = this.StrDOB;
			ObjCommand.Parameters["@MBloodGroup"].Value = this.StrBG;
			ObjCommand.Parameters["@MMS"].Value = this.StrMS;
			ObjCommand.Parameters["@MNIC"].Value = this.StrNIC;
			ObjCommand.Parameters["@MPictureRef"].Value = this.StrPICTUREREF;
			ObjCommand.Parameters["@MAddress"].Value = this.StrADDRESS;
			ObjCommand.Parameters["@MCellPhone"].Value = this.StrCELLPHONE;
			ObjCommand.Parameters["@MPhone1"].Value = this.StrPHONE1;
			ObjCommand.Parameters["@MPhone2"].Value = this.StrPHONE2;
			ObjCommand.Parameters["@MFax"].Value = this.StrFAX;
			ObjCommand.Parameters["@MEmail"].Value = this.StrEMAIL;
			ObjCommand.Parameters["@MLastVisitNo"].Value = this.StrLASTVISITNO;
			ObjCommand.Parameters["@MRelation"].Value = this.StrRelation;

			return ObjCommand;
		}

		// DELETE RECORD IN PATIENTVISIT TABLE
		public OleDbCommand Delete()
		{
			return null;
		}

		// SELECT ALL RECORD IN PATIENTVISIT TABLE
		public OleDbCommand Get_All()
		{
			return null;
		}

		// SELECT SINGLE RECORD FROM PATIENTVISIT
		public OleDbCommand Get_Single()
		{
			SP.TPATIENTREGISTRATION = (clsdatadefinition.SPTPVRegistration)5;
			StrData = SP.TPATIENTREGISTRATION.ToString().Replace("3", ".");

			OleDbCommand objCommand = new OleDbCommand();
			objCommand.CommandText = StrData;
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.Parameters.Add(new OleDbParameter("@MPatientID", OleDbType.VarChar, 11, "PatientID"));
			objCommand.Parameters["@MPatientID"].Value = StrPATIENTID;

			return objCommand;
		}

		#endregion
	}
}