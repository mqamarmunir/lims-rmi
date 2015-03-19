using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsTDesignation.
	/// </summary>
	public class clsTDesignation:Iinterface
	{
		public clsTDesignation()
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
		private string strDesignationID = null;
		private string strDesignationName = null;
		private string strActive = null;
		private string strAcronym = null;
		private string strDesignationType = null;

		#endregion


		#region "Properties"
		
		/// <summary>
		/// Designation ID - Primary Key
		/// </summary>
		public string PKeycode
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
		/// Designation Name - Table Field
		/// </summary>
		public string DesignationName
		{
			get
			{
				return strDesignationName;
			}
			set
			{
				strDesignationName = value;
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


		/// <summary>
		/// Designation Type - Table Field
		/// </summary>
		public string DesignationType
		{
			get
			{
				return strDesignationType;
			}
			set
			{
				strDesignationType = value;
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
			// get Stored procedure name for Insert record in tDesignation table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)1;	// 1 is used for get insert stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3", ".");

			OleDbCommand objCommand = new OleDbCommand();
			objCommand.CommandText = strData;
			objCommand.CommandType = CommandType.StoredProcedure;

			objCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 5, ParameterDirection.Output,false, 0, 0,"DesignationID", DataRowVersion.Default, null));
			objCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;

			objCommand.Parameters.Add(new OleDbParameter("@MDesignationName", OleDbType.VarChar, 30, "DesignationName"));
			objCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			objCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
			objCommand.Parameters.Add(new OleDbParameter("@MDesignationType", OleDbType.VarChar, 2, "DesignationType"));
			objCommand.Parameters["@MDesignationName"].Value = strDesignationName;
			objCommand.Parameters["@MActive"].Value = strActive;
			objCommand.Parameters["@MAcronym"].Value = strAcronym;
			objCommand.Parameters["@MDesignationType"].Value = strDesignationType;

			return objCommand;
		}


		/// <summary>
		/// Record Updation Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SPECIALITY table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)2; // 2 is used for get update stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5, "DesignationID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationName", OleDbType.VarChar, 30,"DesignationName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationType", OleDbType.VarChar, 2, "DesignationType"));

			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			ObjCommand.Parameters["@MDesignationName"].Value = strDesignationName;
			ObjCommand.Parameters["@MActive"].Value = strActive;
			ObjCommand.Parameters["@MAcronym"].Value = strAcronym;
			ObjCommand.Parameters["@MDesignationType"].Value = strDesignationType;
		
			return ObjCommand;
		}


		/// <summary>
		/// Record Deletion Method
		/// </summary>
		/// <returns></returns>
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in tDesignation table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)3;	//3 is used for get delete stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5, "DesignationID"));
			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
		
			return ObjCommand;
		}


		/// <summary>
		/// Get All Records Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in tDesignation table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)4;	//4 is used for get search all stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationName", OleDbType.VarChar, 30, "DesignationName"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.VarChar, 1, "Active"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAcronym", OleDbType.VarChar, 6, "Acronym"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationType", OleDbType.VarChar, 2, "DesignationType"));

			ObjCommand.Parameters["@MDesignationName"].Value = strDesignationName;
			ObjCommand.Parameters["@MActive"].Value = strActive;
			ObjCommand.Parameters["@MAcronym"].Value = strAcronym;
			ObjCommand.Parameters["@MDesignationType"].Value = strDesignationType;
			return ObjCommand;
		}


		/// <summary>
		/// Get Single Record Method
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_Single()
		{
			// get Stored procedure name for Search Single record in tDesignation table
			SP.TDESIGNATION = (clsdatadefinition.SPTDesignation)5;	//5 is used for get search Single stored procedure name
			strData = SP.TDESIGNATION.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =strData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MDesignationID", OleDbType.VarChar, 5, "DesignationID"));
			ObjCommand.Parameters["@MDesignationID"].Value = strDesignationID;
			return ObjCommand;
		}
		
		#endregion
	}
}