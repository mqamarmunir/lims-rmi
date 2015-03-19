using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsTDsgSpecialty.
	/// </summary>
	public class clsTDsgSpecialty:Iinterface
	{
		public clsTDsgSpecialty()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variable Declaration"
		
		clsdatadefinition.StoredProcedure SP;

		#endregion


		#region "Variable Declarations"

		private string strData = null;
		private string strDsgSpecialtyID = null;
		private string strDesignationID = null;
		private string strDsgSpecialtyName = null;
		private string strActive = null;
		private string strAcronym = null;
		
		#endregion


		#region "Properties"
		
		/// <summary>
		/// Designation Specialty ID - Primary Key
		/// </summary>
		public string PKeycode
		{
			get
			{
				return strDsgSpecialtyID;
			}
			set
			{
				strDsgSpecialtyID = value;
			}
		}

		
		/// <summary>
		/// Designation ID - Table Field
		/// </summary>
		public string DesignationID
		{
			get
			{
				return strDesignationID;
			}
			set
			{
				strDesignationID = value;
			}
		}


		/// <summary>
		/// Designation Specialty Name - Table Field
		/// </summary>
		public string DsgSpecialtyName
		{
			get
			{
				return strDsgSpecialtyName;
			}
			set
			{
				strDsgSpecialtyName = value;
			}
		}


		/// <summary>
		/// Active - Table Field
		/// </summary>
		public string Active
		{
			get
			{
				return strActive;
			}
			set
			{
				strActive = value;
			}
		}


		/// <summary>
		/// Acronym - Table Field
		/// </summary>
		public string Acronym
		{
			get
			{
				return strAcronym;
			}
			set
			{
				strAcronym = value;
			}
		}
		
		#endregion


		#region "Data_Methods"
		
		/// <summary>
		/// Record Insertion Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Insert()
		{
			// get Stored procedure name for Insert record in tDsgSpecialty table
			SP.TDSGSPECIALTY = (clsdatadefinition.SPTDsgSpecialty)1;	// 1 is used for get insert stored procedure name
			strData = SP.TDSGSPECIALTY.ToString().Replace("3", ".");

			OleDbCommand objCommand = new OleDbCommand();
			objCommand.CommandText = strData;
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 5, ParameterDirection.Output,false, 0, 0,"DsgSpecialtyID", DataRowVersion.Default, null));
			objCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

			objCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5, "DesignationID"));	
			objCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyName", OleDbType.VarChar, 30, "DsgSpecialtyName"));
			objCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			objCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
			
			objCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			objCommand.Parameters["@MDsgSpecialtyName"].Value = strDsgSpecialtyName;
			objCommand.Parameters["@MActive"].Value = strActive;
			objCommand.Parameters["@MAcronym"].Value = strAcronym;
			
			return objCommand;
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in tDsgSpecialty table
			SP.TDSGSPECIALTY = (clsdatadefinition.SPTDsgSpecialty)2; // 2 is used for get update stored procedure name
			strData = SP.TDSGSPECIALTY.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyID", OleDbType.VarChar, 5, "DsgSpecialtyID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5,"DesignationID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyName", OleDbType.VarChar, 30, "DsgSpecialtyName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));

			ObjCommand.Parameters["@MDsgSpecialtyID"].Value = strDsgSpecialtyID;
			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			ObjCommand.Parameters["@MDsgSpecialtyName"].Value = strDsgSpecialtyName;
			ObjCommand.Parameters["@MActive"].Value = strActive;
			ObjCommand.Parameters["@MAcronym"].Value = strAcronym;			
		
			return ObjCommand;
		}


		/// <summary>
		/// Record Deletion Method
		/// </summary>
		/// <returns></returns>
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in tDsgSpecialty table
			SP.TDSGSPECIALTY = (clsdatadefinition.SPTDsgSpecialty)3;	//3 is used for get delete stored procedure name
			strData = SP.TDSGSPECIALTY.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyID", OleDbType.VarChar, 5, "DsgSpecialtyID"));
			ObjCommand.Parameters["@MDsgSpecialtyID"].Value = strDsgSpecialtyID;
		
			return ObjCommand;
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in tDsgSpecialty table
			SP.TDSGSPECIALTY = (clsdatadefinition.SPTDsgSpecialty)4;	//4 is used for get search all stored procedure name
			strData = SP.TDSGSPECIALTY.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID",OleDbType.VarChar,5, "DesignationID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyName", OleDbType.VarChar, 30, "DsgSpecialtyName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
	
			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			ObjCommand.Parameters["@MDsgSpecialtyName"].Value = strDsgSpecialtyName;
			ObjCommand.Parameters["@MActive"].Value = strActive;
			ObjCommand.Parameters["@MAcronym"].Value = strAcronym;

			return ObjCommand;
		}


		/// <summary>
		/// Get Single Record Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_Single()
		{
			// get Stored procedure name for Search Single record in tDsgSpecialty table
			SP.TDSGSPECIALTY = (clsdatadefinition.SPTDsgSpecialty)5;	//5 is used for get search Single stored procedure name
			strData = SP.TDSGSPECIALTY.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDsgSpecialtyID", OleDbType.VarChar, 5, "DsgSpecialtyID"));
			ObjCommand.Parameters["@MDsgSpecialtyID"].Value = strDsgSpecialtyID;
			return ObjCommand;
		}
		
		#endregion
	}
}
