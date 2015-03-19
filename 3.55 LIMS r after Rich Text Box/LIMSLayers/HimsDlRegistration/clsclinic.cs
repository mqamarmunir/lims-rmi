using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsclinic.
	/// </summary>
	/// 
	public class clsclinic:Iinterface
	{
		public clsclinic()
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
		string StrClinicId=null;
		string StrClinicName=null;
		string StrDepartmentID=null;
		string StrActive=null;
		string StrAcronym=null;	
		string StrContactPerson=null;
		string StrCellNo=null;
		string StrPhone1=null;
		string StrPhone2=null;
		string StrFax1=null; 
		string StrFax2=null;
		string StrEMail1=null;
		string StrEMail2=null;
		string StrDescription=null;
		string StrLocation = null;

		// For Searching Purpose

		string StrPhone=null;
		string StrFax=null; 
		string StrEMail=null;



		#endregion


		#region "Properties"

		/// <summary>
		/// ClinicId Primary Key
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrClinicId;
			}

			set
			{
				StrClinicId=value;
			}
		}

		/// <summary>
		/// ClinicName field
		/// </summary>

		public string ClinicName
		{
			get
			{
				return StrClinicName;
			}

			set
			{
				StrClinicName=value;
			}
		}

		/// <summary>
		/// DepartmentID field
		/// </summary>

		public string DepartmentID
		{
			get
			{
				return StrDepartmentID;
			}

			set
			{
				StrDepartmentID=value;
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
		/// ContactPerson field
		/// </summary>

		public string ContactPerson
		{
			get
			{
				return StrContactPerson;
			}

			set
			{
				StrContactPerson=value;
			}
		}


		/// <summary>
		/// CellNo field
		/// </summary>

		public string CellNo
		{
			get
			{
				return StrCellNo;
			}

			set
			{
				StrCellNo=value;
			}
		}

		/// <summary>
		/// Phone1 field
		/// </summary>

		public string Phone1
		{
			get
			{
				return StrPhone1;
			}

			set
			{
				StrPhone1=value;
			}
		}

		/// <summary>
		/// Phone2 field
		/// </summary>

		public string Phone2
		{
			get
			{
				return StrPhone2;
			}

			set
			{
				StrPhone2=value;
			}
		}

		/// <summary>
		/// Fax1 field
		/// </summary>

		public string Fax1
		{
			get
			{
				return StrFax1;
			}

			set
			{
				StrFax1=value;
			}
		}


		/// <summary>
		/// Fax2 field
		/// </summary>

		public string Fax2
		{
			get
			{
				return StrFax2;
			}

			set
			{
				StrFax2=value;
			}
		}

		/// <summary>
		/// EMail1 field
		/// </summary>

		public string EMail1
		{
			get
			{
				return StrEMail1;
			}

			set
			{
				StrEMail1=value;
			}
		}


		/// <summary>
		/// EMail2 field
		/// </summary>

		public string EMail2
		{
			get
			{
				return StrEMail2;
			}

			set
			{
				StrEMail2=value;
			}
		}

		/// <summary>
		/// Description field
		/// </summary>

		public string Description
		{
			get
			{
				return StrDescription;
			}

			set
			{
				StrDescription=value;
			}
		}


		/// <summary>
		/// Clinic Location (string, 255)
		/// </summary>
		public string Location
		{
			get{	return StrLocation;		}
			set{	StrLocation = value;	}
		}


		/// <summary>
		/// Phone field for searching
		/// </summary>

		public string Phone
		{
			get
			{
				return StrPhone;
			}

			set
			{
				StrPhone=value;
			}
		}


		/// <summary>
		/// Fax field for searching
		/// </summary>

		public string Fax
		{
			get
			{
				return StrFax;
			}

			set
			{
				StrFax=value;
			}
		}


		/// <summary>
		/// Email field for searching
		/// </summary>

		public string Email
		{
			get
			{
				return StrEMail;
			}

			set
			{
				StrEMail=value;
			}
		}

		#endregion


		#region "Data_Methods"
		
		// INSERT DATA IN CLINIC TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert CLINIC table
			SP.CLINIC = (clsdatadefinition.SPClinic)1; // 1 is used for get insert stored procedure name
			StrData = SP.CLINIC.ToString().Replace("3",".");
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,3,ParameterDirection.Output,false,0,0,"ClinicId",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICNAME",OleDbType.VarChar,50,"CLINICNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.Char,4,"DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,50,"CONTACTPERSON"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"PHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,250,"DESCRIPTION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLocation", OleDbType.VarChar, 255, "Location"));
			
			ObjCommand.Parameters["@MCLINICNAME"].Value=StrClinicName;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDepartmentID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
			ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
			ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
			ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
			ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
			ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
			ObjCommand.Parameters["@MEMAIL1"].Value=StrEMail1;
			ObjCommand.Parameters["@MEMAIL2"].Value=StrEMail2;
			ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
			ObjCommand.Parameters["@MLocation"].Value = StrLocation;

			return ObjCommand;
		}

		// UPDATE RECORD IN CLINIC TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in CLINIC table
			SP.CLINIC = (clsdatadefinition.SPClinic)2; // 2 is used for get update stored procedure name
			StrData = SP.CLINIC.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"ClinicId"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICNAME",OleDbType.VarChar,50,"CLINICNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.Char,4,"DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,50,"CONTACTPERSON"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"PHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,250,"DESCRIPTION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLocation", OleDbType.VarChar, 255, "Location"));

			ObjCommand.Parameters["@MCLINICID"].Value=StrClinicId;
			ObjCommand.Parameters["@MCLINICNAME"].Value=StrClinicName;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDepartmentID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
			ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
			ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
			ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
			ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
			ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
			ObjCommand.Parameters["@MEMAIL1"].Value=StrEMail1;
			ObjCommand.Parameters["@MEMAIL2"].Value=StrEMail2;
			ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
			ObjCommand.Parameters["@MLocation"].Value = StrLocation;
			
			return ObjCommand;
		}

		// DELETE RECORD IN CLINIC TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in CLINIC table
			SP.CLINIC = (clsdatadefinition.SPClinic)3; //3 is used for get delete stored procedure name
			StrData = SP.CLINIC.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"ClinicId"));
			ObjCommand.Parameters["@MCLINICID"].Value=StrClinicId;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN CLINIC TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in CLINIC table
			SP.CLINIC = (clsdatadefinition.SPClinic)4;  //4 is used for get search all stored procedure name
			StrData = SP.CLINIC.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICNAME",OleDbType.VarChar,50,"CLINICNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID",OleDbType.Char,4,"DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,50,"CONTACTPERSON"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE",OleDbType.VarChar,15,"PHONE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX",OleDbType.VarChar,15,"FAX"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,250,"DESCRIPTION"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MLocation", OleDbType.VarChar, 255, "Location"));

			ObjCommand.Parameters["@MCLINICNAME"].Value=StrClinicName;
			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDepartmentID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
			ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
			ObjCommand.Parameters["@MPHONE"].Value=StrPhone;
			ObjCommand.Parameters["@MFAX"].Value=StrFax;
			ObjCommand.Parameters["@MEMAIL"].Value=StrEMail;
			ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
			ObjCommand.Parameters["@MLocation"].Value = StrLocation;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM CLINIC TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in CLINIC table
			SP.CLINIC = (clsdatadefinition.SPClinic)5; //5 is used for get search Single stored procedure name
			StrData = SP.CLINIC.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLINICID",OleDbType.Char,3,"ClinicId"));
			ObjCommand.Parameters["@MCLINICID"].Value=StrClinicId;
			
	
			return ObjCommand;
		}

		#endregion
	}
}