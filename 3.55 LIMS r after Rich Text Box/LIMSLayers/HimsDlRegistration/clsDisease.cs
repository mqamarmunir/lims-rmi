using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsDisease.
	/// </summary>
	public class clsDisease:Iinterface
	{
		public clsDisease()
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
		private string StrDiseaseID = null;
		private string StrDiseaseName = null;
		private string StrAcronym = null;
		private string StrActive = null;

		#endregion

		#region "Properties"
	
		/// <summary>
		/// Disease ID, Primary key
		/// </summary>

		public string PKeycode
		{
			get{	return StrDiseaseID;	}
			set{	StrDiseaseID = value;	}
		}

		/// <summary>
		/// Disease Name table field
		/// </summary>

		public string DiseaseName
		{
			get{	return StrDiseaseName;	}
			set{	StrDiseaseName = value;	}
		}

		/// <summary>
		/// Active table field
		/// </summary>

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		/// <summary>
		/// Acronym table field
		/// </summary>

		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}

		#endregion

		#region "Data_Methods"
		
		// Insert data in TDisease table
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert TDisease table
			SP.TDISEASE = (clsdatadefinition.SPTDisease)1; // 1 is used for get insert stored procedure name
			StrData = SP.TDISEASE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.Numeric, 10, ParameterDirection.Output, false, 10, 0, "DiseaseID", DataRowVersion.Default, null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MDiseaseName", OleDbType.VarChar, 50, "DiseaseName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 10, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.Char, 1, "Active"));

			ObjCommand.Parameters["@MDiseaseName"].Value = StrDiseaseName;
			ObjCommand.Parameters["@MAcronym"].Value = StrAcronym;
			ObjCommand.Parameters["@MActive"].Value = StrActive;

			return ObjCommand;
		}

		// Update record in TDisease table
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in TDisease table
			SP.TDISEASE = (clsdatadefinition.SPTDisease)2; // 2 is used for get update stored procedure name
			StrData = SP.TDISEASE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MDiseaseID", OleDbType.Numeric, 10, "DiseaseID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDiseaseName", OleDbType.VarChar , 50, "DiseaseName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 10, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.Char, 1, "Active"));

			ObjCommand.Parameters["@MDiseaseID"].Value = StrDiseaseID;
			ObjCommand.Parameters["@MDiseaseName"].Value = StrDiseaseName;
			ObjCommand.Parameters["@MAcronym"].Value = StrAcronym;
			ObjCommand.Parameters["@MActive"].Value = StrActive;

			return ObjCommand;
		}

		// Delete record in TDisease table
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in TDisease table
			SP.TDISEASE = (clsdatadefinition.SPTDisease)3; //3 is used for get delete stored procedure name
			StrData = SP.TDISEASE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DiseaseID", OleDbType.Numeric, 10, "DiseaseID"));

			ObjCommand.Parameters["@DiseaseID"].Value = StrDiseaseID;

			return ObjCommand;
		}

		// Select all record in TDisease table
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in TDisease table
			SP.TDISEASE = (clsdatadefinition.SPTDisease)4;  //4 is used for get search all stored procedure name
			StrData = SP.TDISEASE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			
			ObjCommand.Parameters.Add(new OleDbParameter("@MDiseaseName", OleDbType.VarChar, 50, "DiseaseName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 10, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.Char, 1, "Active"));

			ObjCommand.Parameters["@MDiseaseName"].Value = StrDiseaseName;
			ObjCommand.Parameters["@MAcronym"].Value = StrAcronym;
			ObjCommand.Parameters["@MActive"].Value = StrActive;

			return ObjCommand;
		}

		// Select single record from TDisease
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in TDisease table
			SP.TDISEASE = (clsdatadefinition.SPTDisease)5; //5 is used for get search Single stored procedure name
			StrData = SP.TDISEASE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@DiseaseID", OleDbType.Numeric, 10, "DiseaseID"));
			ObjCommand.Parameters["@DiseaseID"].Value = StrDiseaseID;

			return ObjCommand;
		}

		#endregion
	}
}
