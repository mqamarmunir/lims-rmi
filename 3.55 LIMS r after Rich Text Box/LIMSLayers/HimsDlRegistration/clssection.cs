using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clssection.
	/// </summary>
	public class clssection:Iinterface
	{
		public clssection()
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
	string StrSectionId=null;
	string StrFactoryId=null;
	string StrSectionName=null;
	string StrActive=null;
	string StrOrgID=null;
	string StrAcronym=null;
	string StrContactPerson=null;
	string StrCellNo=null;
	string StrPhone1=null;
	string StrPhone2=null;
	string StrFax1=null; 
	string StrFax2=null;
	string StrEMail1=null;
	string StrEMail2=null;
	string StrBAddress=null;
	string StrDescription=null;


#endregion

#region "Properties"

	/// <summary>
	/// SectionId Primary Key
	/// </summary>
	
	public string PKeycode
	{
		get
		{
			return StrSectionId;
			
        }

		set
		{
			StrSectionId=value;
		}
	}

	/// <summary>
	/// FactoryId field
	/// </summary>

	public string FactoryId
	{
		get
		{
			return StrFactoryId;
		}

		set
		{
			StrFactoryId=value;
		}
	}

	/// <summary>
	/// SectionName field
	/// </summary>

	public string SectionName
	{
		get
		{
			return StrSectionName;
		}

		set
		{
			StrSectionName=value;
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
		/// FactoryType field changed to OrgID
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
		/// BAddress field
		/// </summary>

		public string BAddress
		{
			get
			{
				return StrBAddress;
			}

			set
			{
				StrBAddress=value;
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


#endregion

#region "Data_Methods"
		
		// INSERT DATA IN Section TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Section table
			SP.SECTION = (clsdatadefinition.SPSection)1; // 1 is used for get insert stored procedure name
			StrData = SP.SECTION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,5,ParameterDirection.Output,false,0,0,"SectionId",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONNAME",OleDbType.VarChar,50,"SECTIONNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));

			ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,50,"CONTACTPERSON"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"PHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBADDRESS",OleDbType.VarChar,250,"BADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,250,"DESCRIPTION"));

			
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
			ObjCommand.Parameters["@MSECTIONNAME"].Value=StrSectionName;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
			ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
			ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
			ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
			ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
			ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
			ObjCommand.Parameters["@MEMAIL1"].Value=StrEMail1;
			ObjCommand.Parameters["@MEMAIL2"].Value=StrEMail2;
			ObjCommand.Parameters["@MBADDRESS"].Value=StrBAddress;
			ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
			
			return ObjCommand;
		}

		// UPDATE RECORD IN SECTION TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SECTION table

			SP.SECTION = (clsdatadefinition.SPSection)2; // 2 is used for get update stored procedure name
			StrData = SP.SECTION.ToString().Replace("3",".");		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SECTIONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FACTORYID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONNAME",OleDbType.VarChar,50,"SECTIONNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,50,"CONTACTPERSON"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"PHONE2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MBADDRESS",OleDbType.VarChar,250,"BADDRESS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,250,"DESCRIPTION"));

			
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSectionId;
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
			ObjCommand.Parameters["@MSECTIONNAME"].Value=StrSectionName;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
			ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
			ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
			ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
			ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
			ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
			ObjCommand.Parameters["@MEMAIL1"].Value=StrEMail1;
			ObjCommand.Parameters["@MEMAIL2"].Value=StrEMail2;
			ObjCommand.Parameters["@MBADDRESS"].Value=StrBAddress;
			ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
			
			return ObjCommand;
		}

		// DELETE RECORD IN SECTION TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SECTION table
			SP.SECTION = (clsdatadefinition.SPSection)3; //3 is used for get delete stored procedure name
			StrData = SP.SECTION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SectionId"));
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSectionId;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SECTION TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in SECTION table
			SP.SECTION = (clsdatadefinition.SPSection)4;  //4 is used for get search all stored procedure name
			StrData = SP.SECTION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FactoryId"));
			ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SECTION TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SECTION table
			SP.SECTION = (clsdatadefinition.SPSection)5; //5 is used for get search Single stored procedure name
			StrData = SP.SECTION.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSECTIONID",OleDbType.Char,5,"SectionId"));
			ObjCommand.Parameters["@MSECTIONID"].Value=StrSectionId;
			
	
			return ObjCommand;
		}

#endregion
	
	}
}
