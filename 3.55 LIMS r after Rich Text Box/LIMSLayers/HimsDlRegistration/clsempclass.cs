using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsempclass.
	/// </summary>
	public class clsempclass:Iinterface
	{
		public clsempclass()
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
		private string StrCLASSID;
		private string StrCLASSNAME;
		private string StrACRONYM;
		private string StrACTIVE;
		private string StrOrgID = null;					

		#endregion

		#region "Properties"
	
		/// <summary>
		/// CLASSID Primary key
		/// </summary>

		public string PKeycode
		{
			get
			{
				return StrCLASSID;
			}
			set
			{
				StrCLASSID=value;
			}
		}

		/// <summary>
		/// CLASSNAME table field
		/// </summary>

		public string ClassName
		{
			get
			{
				return StrCLASSNAME;
			}
			set
			{
				StrCLASSNAME=value;
			}
		}

		/// <summary>
		/// Acronym table field
		/// </summary>

		public string Acronym
		{
			get
			{
				return StrACRONYM;
			}
			set
			{
				StrACRONYM=value;
			}
		}

		public string Active
		{
			get
			{
				return StrACTIVE;
			}
			set
			{
				StrACTIVE=value;
			}
		}

		public string OrgID
		{
			get{	return StrOrgID;	}
			set{	StrOrgID = value;	}
		}	

		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Department TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Department table
			SP.EMPCLASS = (clsdatadefinition.SPEmpClass)1; // 1 is used for get insert stored procedure name
			StrData = SP.EMPCLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,3,ParameterDirection.Output,false,0,0,"DEPARTENTID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSNAME",OleDbType.VarChar ,50,"CLASSNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOrgID", OleDbType.Char, 2, "OrgID"));

			ObjCommand.Parameters["@MCLASSNAME"].Value=StrCLASSNAME;
			ObjCommand.Parameters["@MACRONYM"].Value=StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MOrgID"].Value = StrOrgID;

			return ObjCommand;
		}

		// UPDATE RECORD IN DEPARTMENT TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in DEPARTMENT table
			SP.EMPCLASS = (clsdatadefinition.SPEmpClass)2; // 2 is used for get update stored procedure name
			StrData = SP.EMPCLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.Char ,3,"CLASSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSNAME",OleDbType.VarChar ,50,"CLASSNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));

			ObjCommand.Parameters["@MCLASSID"].Value=StrCLASSID;
			ObjCommand.Parameters["@MCLASSNAME"].Value=StrCLASSNAME;
			ObjCommand.Parameters["@MACRONYM"].Value=StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
		
			return ObjCommand;
		}

		// DELETE RECORD IN DEPARTMENT TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in DEPARTMENT table
			SP.EMPCLASS = (clsdatadefinition.SPEmpClass)3; //3 is used for get delete stored procedure name
			StrData = SP.EMPCLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@CLASSID",OleDbType.Char,3,"CLASSID"));

			ObjCommand.Parameters["@CLASSID"].Value=StrCLASSID;

			return ObjCommand;
		}

		// SELECT ALL RECORD IN DEPARTMENT TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in DEPARTMENT table
			SP.EMPCLASS = (clsdatadefinition.SPEmpClass)4;  //4 is used for get search all stored procedure name
			StrData = SP.EMPCLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSNAME",OleDbType.VarChar ,50,"CLASSNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MOrgID", OleDbType.Char, 2, "OrgID"));

			ObjCommand.Parameters["@MCLASSNAME"].Value = StrCLASSNAME;
			ObjCommand.Parameters["@MACRONYM"].Value = StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value = StrACTIVE;
			ObjCommand.Parameters["@MOrgID"].Value = StrOrgID;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM Department
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in Department table
			SP.EMPCLASS = (clsdatadefinition.SPEmpClass)5; //5 is used for get search Single stored procedure name
			StrData = SP.EMPCLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@CLASSID",OleDbType.Char,3,"CLASSID"));
			ObjCommand.Parameters["@CLASSID"].Value=StrCLASSID;

			return ObjCommand;
		}

		#endregion
	}
}