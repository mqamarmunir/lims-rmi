using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsdepartment.
	/// </summary>
	public class clsdepartment:Iinterface 
	{
		public clsdepartment()
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
		private string StrData = null;	
		private string StrDEPARTMENTID = null;
		private string StrDEPARTMENTNAME = null;
		private string StrACRONYM = null;
		private string StrACTIVE = null;
		private string StrDEPARTMENTTYPE = null;

		#endregion

		#region "Properties"
	
		/// <summary>
		/// DEPARTMENTID Primary key
		/// </summary>

		public string PKeycode
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
		/// DEPARTMENTNAME table field
		/// </summary>

		public string DepartmentName
		{
			get
			{
				return StrDEPARTMENTNAME;
			}
			set
			{
				StrDEPARTMENTNAME=value;
			}
		}

		/// <summary>
		/// RELATION table field
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

		/// <summary>
		/// ACTIVE table field
		/// </summary>

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

		/// <summary>
		/// Department Type table field
		/// </summary>

		public string DepartmentType
		{
			get
			{
				return StrDEPARTMENTTYPE;
			}
			set
			{
				StrDEPARTMENTTYPE=value;
			}
		}


		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Department TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Department table
			SP.DEPARTMENT = (clsdatadefinition.SPDepartment)1; // 1 is used for get insert stored procedure name
			StrData = SP.DEPARTMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.VarChar,4,ParameterDirection.Output,false,0,0,"DEPARTMENTID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTNAME",OleDbType.VarChar,30,"DEPARTMENTNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.VarChar,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTTYPE",OleDbType.VarChar,2,"DEPARTMENTTYPE"));

			ObjCommand.Parameters["@MDEPARTMENTNAME"].Value=StrDEPARTMENTNAME;
			ObjCommand.Parameters["@MACRONYM"].Value=StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MDEPARTMENTTYPE"].Value=StrDEPARTMENTTYPE;


			return ObjCommand;
		}

		// UPDATE RECORD IN DEPARTMENT TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in DEPARTMENT table
			SP.DEPARTMENT = (clsdatadefinition.SPDepartment)2; // 2 is used for get update stored procedure name
			StrData = SP.DEPARTMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTID", OleDbType.VarChar, 4, "DEPARTMENTID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTNAME", OleDbType.VarChar , 30,"DEPARTMENTNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM", OleDbType.VarChar, 6, "ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE", OleDbType.VarChar, 1, "ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTTYPE", OleDbType.VarChar, 2, "DEPARTMENTTYPE"));

			ObjCommand.Parameters["@MDEPARTMENTID"].Value=StrDEPARTMENTID;
			ObjCommand.Parameters["@MDEPARTMENTNAME"].Value=StrDEPARTMENTNAME;
			ObjCommand.Parameters["@MACRONYM"].Value=StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MDEPARTMENTTYPE"].Value=StrDEPARTMENTTYPE;
		
			return ObjCommand;
		}

		// DELETE RECORD IN DEPARTMENT TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in DEPARTMENT table
			SP.DEPARTMENT = (clsdatadefinition.SPDepartment)3; //3 is used for get delete stored procedure name
			StrData = SP.DEPARTMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DEPARTMENTID",OleDbType.VarChar,4,"DEPARTMENTID"));

			ObjCommand.Parameters["@DEPARTMENTID"].Value=StrDEPARTMENTID;

			return ObjCommand;
		}

		// SELECT ALL RECORD IN DEPARTMENT TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in DEPARTMENT table
			SP.DEPARTMENT = (clsdatadefinition.SPDepartment)4;  //4 is used for get search all stored procedure name
			StrData = SP.DEPARTMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTNAME",OleDbType.VarChar,30,"DEPARTMENTNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,6,"ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE", OleDbType.VarChar, 1, "ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDEPARTMENTTYPE", OleDbType.VarChar, 2, "DEPARTMENTTYPE"));

			ObjCommand.Parameters["@MDEPARTMENTNAME"].Value=StrDEPARTMENTNAME;
			ObjCommand.Parameters["@MACRONYM"].Value=StrACRONYM;
			ObjCommand.Parameters["@MACTIVE"].Value=StrACTIVE;
			ObjCommand.Parameters["@MDEPARTMENTTYPE"].Value=StrDEPARTMENTTYPE;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM Department
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in Department table
			SP.DEPARTMENT = (clsdatadefinition.SPDepartment)5; //5 is used for get search Single stored procedure name
			StrData = SP.DEPARTMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DEPARTMENTID",OleDbType.VarChar,4,"DEPARTMENTID"));
			ObjCommand.Parameters["@DEPARTMENTID"].Value=StrDEPARTMENTID;

			return ObjCommand;
		}

		#endregion

	}
}
