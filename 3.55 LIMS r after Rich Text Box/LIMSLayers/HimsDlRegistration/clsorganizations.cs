using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsorganizations.
	/// </summary>
	public class clsorganizations:Iinterface
	{
		public clsorganizations()
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
		string StrOrgId=null;
		string StrName=null;
		string StrActive=null;
		string StrValidUpto=null;	
		string StrBilling=null;
		string StrOType=null;
		private string StrPersonToContact = null;
		private string StrAddress = null;
		private string StrPhoneNo = null;
		private string StrEmail = null;
		
		#endregion

		#region "Properties"

		/// <summary>
		/// OrgId Primary Key
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrOrgId;
			}

			set
			{
				StrOrgId=value;
			}
		}

		/// <summary>
		/// Name field
		/// </summary>

		public string Name
		{
			get
			{
				return StrName;
			}

			set
			{
				StrName=value;
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
		/// Registration Valid Upto field
		/// </summary>

		public string ValidUpto
		{
			get
			{
				return StrValidUpto;
			}

			set
			{
				StrValidUpto=value;
			}

		}


		/// <summary>
		/// Billing field
		/// </summary>

		public string Billing
		{
			get
			{
				return StrBilling;
			}

			set
			{
				StrBilling=value;
			}
		}


		/// <summary>
		/// Organization Type field
		/// </summary>

		public string OType
		{
			get
			{
				return StrOType;
			}

			set
			{
				StrOType=value;
			}
		}

		/// <summary>
		/// Person Name to Contact	(string, 65)
		/// </summary>
		public string PersonToContact
		{
			get{	return StrPersonToContact;	}
			set{	StrPersonToContact = value;	}
		}

		/// <summary>
		/// Address of Organization	(string, 255)
		/// </summary>
		public string Address
		{
			get{	return StrAddress;	}
			set{	StrAddress = value;	}
		}

		/// <summary>
		/// Phone Number of the Organization
		/// </summary>
		public string PhoneNo
		{
			get{	return StrPhoneNo;	}
			set{	StrPhoneNo = value;	}
		}

		/// <summary>
		/// Email Address of Organization
		/// </summary>
		public string Email
		{
			get{	return StrEmail;	}
			set{	StrEmail = value;	}
		}

		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN ORGANIZATIONS TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert ORGANIZATIONS table
			SP.ORGANIZATIONS = (clsdatadefinition.SPOrganizations)1; // 1 is used for get insert stored procedure name
			StrData = SP.ORGANIZATIONS.ToString().Replace("3",".");
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,2,ParameterDirection.Output,false,0,0,"OrgId",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MNAME",OleDbType.VarChar,200,"NAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOTYPE",OleDbType.Char,1,"OTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MVALIDUPTO",OleDbType.VarChar,10,"VALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBILLING",OleDbType.Char,1,"BILLING"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonToContact", OleDbType.VarChar, 65, "PersonToContact"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAddress", OleDbType.VarChar, 255, "Address"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEmail", OleDbType.VarChar, 50, "Email"));
									
			ObjCommand.Parameters["@MNAME"].Value=StrName;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MOTYPE"].Value=StrOType;
			ObjCommand.Parameters["@MVALIDUPTO"].Value=StrValidUpto;
			ObjCommand.Parameters["@MBILLING"].Value=StrBilling;
			ObjCommand.Parameters["@MPersonToContact"].Value = StrPersonToContact;
			ObjCommand.Parameters["@MAddress"].Value = StrAddress;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MEmail"].Value = StrEmail;
						
			return ObjCommand;
		}

		// UPDATE RECORD IN ORGANIZATIONS TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in ORGANIZATIONS table
			SP.ORGANIZATIONS = (clsdatadefinition.SPOrganizations)2; // 2 is used for get update stored procedure name
			StrData = SP.ORGANIZATIONS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"OrgId"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MNAME",OleDbType.VarChar,200,"NAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOTYPE",OleDbType.Char,1,"OTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MVALIDUPTO",OleDbType.VarChar,10,"VALIDUPTO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBILLING",OleDbType.Char,1,"BILLING"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonToContact", OleDbType.VarChar, 65, "PersonToContact"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAddress", OleDbType.VarChar, 255, "Address"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEmail", OleDbType.VarChar, 50, "Email"));
						
			ObjCommand.Parameters["@MORGID"].Value=StrOrgId;
			ObjCommand.Parameters["@MNAME"].Value=StrName;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MOTYPE"].Value=StrOType;
			ObjCommand.Parameters["@MVALIDUPTO"].Value=StrValidUpto;
			ObjCommand.Parameters["@MBILLING"].Value=StrBilling;
			ObjCommand.Parameters["@MPersonToContact"].Value = StrPersonToContact;
			ObjCommand.Parameters["@MAddress"].Value = StrAddress;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MEmail"].Value = StrEmail;
						
			return ObjCommand;
		}

		// DELETE RECORD IN ORGANIZATIONS TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in CLINIC table
			SP.ORGANIZATIONS = (clsdatadefinition.SPOrganizations)3; //3 is used for get delete stored procedure name
			StrData = SP.ORGANIZATIONS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"OrgId"));
			ObjCommand.Parameters["@MORGID"].Value=StrOrgId;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN ORGANIZATIONS TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in ORGANIZATIONS table
			SP.ORGANIZATIONS = (clsdatadefinition.SPOrganizations)4;  //4 is used for get search all stored procedure name
			StrData = SP.ORGANIZATIONS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MNAME",OleDbType.VarChar,200,"NAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOTYPE",OleDbType.Char,1,"OTYPE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBILLING",OleDbType.Char,1,"BILLING"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonToContact", OleDbType.VarChar, 65, "PersonToContact"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAddress", OleDbType.VarChar, 255, "Address"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEmail", OleDbType.VarChar, 50, "Email"));
						
			ObjCommand.Parameters["@MNAME"].Value=StrName;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MOTYPE"].Value=StrOType;
			ObjCommand.Parameters["@MBILLING"].Value=StrBilling;
			ObjCommand.Parameters["@MPersonToContact"].Value = StrPersonToContact;
			ObjCommand.Parameters["@MAddress"].Value = StrAddress;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MEmail"].Value = StrEmail;
			
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM ORGANIZATIONS TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in ORGANIZATIONS table
			SP.ORGANIZATIONS = (clsdatadefinition.SPOrganizations)5; //5 is used for get search Single stored procedure name
			StrData = SP.ORGANIZATIONS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"OrgId"));
			ObjCommand.Parameters["@MORGID"].Value=StrOrgId;
				
			return ObjCommand;
		}

		#endregion
	}
}