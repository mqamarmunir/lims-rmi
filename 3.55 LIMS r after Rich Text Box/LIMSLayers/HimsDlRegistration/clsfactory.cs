using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsfactory.
	/// </summary>
	public class clsfactory:Iinterface
	{
				
		public clsfactory()
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
	string StrFactoryId=null;
	string StrActive=null;
	string StrFactoryname=null;
	string StrAcronym=null;
	string StrContactPerson=null;
	string StrCellNo=null;
	string StrPhone1=null;
	string StrPhone2=null;
	string StrFax1=null;
	string StrFax2=null;
	string StrEmail1=null;
	string StrEmail2=null;
	string StrPAddress=null;
	string StrBAddress=null;
	string StrDescription=null;
	string StrOrgID=null;
	string StrBill=null;

	//For Searching Extrat Properties

	string StrPhone=null;
	string StrFax=null;
	string StrEmail=null;
        
#endregion

#region "Properties"

	/// <summary>
	/// FactoryId Primary key
	/// </summary>

	public string PKeycode
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
	/// Factoryname field
	/// </summary>

	public string Factoryname
	{
		get
		{
			return StrFactoryname;
		}
		set
		{
			StrFactoryname=value;
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
	/// Email1 field
	/// </summary>

	public string Email1
	{
		get
		{
			return StrEmail1;			
		}
		set
		{
			StrEmail1=value;
		}
	}

	/// <summary>
	/// Email2 field
	/// </summary>

	public string Email2
	{
		get
		{
			return StrEmail2;			
		}
		set
		{
			StrEmail2=value;
		}
	}

	/// <summary>
	/// PAddress field
	/// </summary>

	public string PAddress
	{
		get
		{
			return StrPAddress;			
		}
		set
		{
			StrPAddress=value;
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

		public string Bill
		{
			get
			{
				return StrBill;			
			}
			set
			{
				StrBill=value;
			}
		}


		/// <summary>
		/// Phone field
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
		/// Phone field
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


#endregion

#region "Data_Methods"
		
		
	// INSERT DATA IN Factory TABLE
	public  OleDbCommand Insert()
	{
	
		// Get Stored procedure name for insert Factory table
		SP.FACTORY = (clsdatadefinition.SPFactory)1; // 1 is used for get insert stored procedure name
		StrData = SP.FACTORY.ToString().Replace("3",".");
		
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
		

		ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,4,ParameterDirection.Output,false,0,0,"FactoryId",DataRowVersion.Default,null));
		ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYNAME",OleDbType.VarChar,50,"FACTORYNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,30,"CONTACTPERSON"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"FPHONE2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPADDRESS",OleDbType.Char,255,"PADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBADDRESS",OleDbType.VarChar,255,"BADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,50,"DESCRIPTION"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MORGANIZATIONID",OleDbType.Char,2,"ORGID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBILL",OleDbType.Char,1,"BILL"));

		
		
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MFACTORYNAME"].Value=StrFactoryname;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
		ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
		ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
		ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
		ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
		ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
		ObjCommand.Parameters["@MEMAIL1"].Value=StrEmail1;
		ObjCommand.Parameters["@MEMAIL2"].Value=StrEmail2;
		ObjCommand.Parameters["@MPADDRESS"].Value=StrPAddress;
		ObjCommand.Parameters["@MBADDRESS"].Value=StrBAddress;
		ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
		ObjCommand.Parameters["@MORGANIZATIONID"].Value=StrOrgID;
		ObjCommand.Parameters["@MBILL"].Value=StrBill;
		
		
		return ObjCommand;
	}

	// UPDATE RECORD IN FACTORY TABLE
	public OleDbCommand Update()
	{
		// get Stored procedure name for Update record in FACTORY table
		SP.FACTORY = (clsdatadefinition.SPFactory)2; // 2 is used for get update stored procedure name
		StrData = SP.FACTORY.ToString().Replace("3",".");
		
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
	
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FactoryID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYNAME",OleDbType.VarChar,50,"FACTORYNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,30,"CONTACTPERSON"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE1",OleDbType.VarChar,15,"PHONE1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE2",OleDbType.VarChar,15,"FPHONE2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFAX1",OleDbType.VarChar,15,"FAX1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFAX2",OleDbType.VarChar,15,"FAX2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL1",OleDbType.VarChar,50,"EMAIL1"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL2",OleDbType.VarChar,50,"EMAIL2"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPADDRESS",OleDbType.Char,255,"PADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBADDRESS",OleDbType.VarChar,255,"BADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,50,"DESCRIPTION"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MORGANIZATIONID",OleDbType.Char,2,"ORGID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBILL",OleDbType.Char,1,"BILL"));
		
		
		ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MFACTORYNAME"].Value=StrFactoryname;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
		ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
		ObjCommand.Parameters["@MPHONE1"].Value=StrPhone1;
		ObjCommand.Parameters["@MPHONE2"].Value=StrPhone2;
		ObjCommand.Parameters["@MFAX1"].Value=StrFax1;
		ObjCommand.Parameters["@MFAX2"].Value=StrFax2;
		ObjCommand.Parameters["@MEMAIL1"].Value=StrEmail1;
		ObjCommand.Parameters["@MEMAIL2"].Value=StrEmail2;
		ObjCommand.Parameters["@MPADDRESS"].Value=StrPAddress;
		ObjCommand.Parameters["@MBADDRESS"].Value=StrBAddress;
		ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
		ObjCommand.Parameters["@MORGANIZATIONID"].Value=StrOrgID;
		ObjCommand.Parameters["@MBILL"].Value=StrBill;
		
		return ObjCommand;
	}

	// DELETE RECORD IN FACTORY TABLE
	public OleDbCommand Delete()
	{
		// get Stored procedure name for Delete record in FACTORY table
		SP.FACTORY = (clsdatadefinition.SPFactory)3; //3 is used for get delete stored procedure name
		StrData = SP.FACTORY.ToString().Replace("3",".");
		
		OleDbCommand ObjCommand = new OleDbCommand();
		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
	
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FactoryId"));
		ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
	
		return ObjCommand;
	}

	// SELECT ALL RECORD IN FACTORY TABLE
	public OleDbCommand Get_All()
	{
		// get Stored procedure name for Get All record in FACTORY table
		SP.FACTORY = (clsdatadefinition.SPFactory)4;  //4 is used for get search all stored procedure name
		StrData = SP.FACTORY.ToString().Replace("3",".");
		
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYNAME",OleDbType.VarChar,50,"FACTORYNAME"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCONTACTPERSON",OleDbType.VarChar,30,"CONTACTPERSON"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MCELLNO",OleDbType.VarChar,15,"CELLNO"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPHONE",OleDbType.VarChar,15,"PHONE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MFAX",OleDbType.VarChar,15,"FAX"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MEMAIL",OleDbType.VarChar,50,"EMAIL"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MPADDRESS",OleDbType.Char,255,"PADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBADDRESS",OleDbType.VarChar,255,"BADDRESS"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MDESCRIPTION",OleDbType.VarChar,50,"DESCRIPTION"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MORGANIZATIONID",OleDbType.Char,2,"ORGID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MBILL",OleDbType.Char,1,"BILL"));

		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MFACTORYNAME"].Value=StrFactoryname;
		ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
		ObjCommand.Parameters["@MCONTACTPERSON"].Value=StrContactPerson;
		ObjCommand.Parameters["@MCELLNO"].Value=StrCellNo;
		ObjCommand.Parameters["@MPHONE"].Value=StrPhone;
		ObjCommand.Parameters["@MFAX"].Value=StrFax;
		ObjCommand.Parameters["@MEMAIL"].Value=StrEmail;
		ObjCommand.Parameters["@MPADDRESS"].Value=StrPAddress;
		ObjCommand.Parameters["@MBADDRESS"].Value=StrBAddress;
		ObjCommand.Parameters["@MDESCRIPTION"].Value=StrDescription;
		ObjCommand.Parameters["@MORGANIZATIONID"].Value=StrOrgID;
		ObjCommand.Parameters["@MBILL"].Value=StrBill;

		return ObjCommand;
	}

	// SELECT SINGLE RECORD FROM FACTORY
	public OleDbCommand Get_Single()
	{

		// get Stored procedure name for Search Single record in FACTORY table
		SP.FACTORY = (clsdatadefinition.SPFactory)5; //5 is used for get search Single stored procedure name
		StrData = SP.FACTORY.ToString().Replace("3",".");
		
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
	
		ObjCommand.Parameters.Add(new OleDbParameter("@MFACTORYID",OleDbType.Char,4,"FactoryId"));
		ObjCommand.Parameters["@MFACTORYID"].Value=StrFactoryId;
	
		return ObjCommand;
	}

#endregion


	}
}