using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsservice.
	/// </summary>
	public class clsservice:Iinterface
	{
		public clsservice()
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
		string StrServiceId = null;
		string StrServiceName = null;
		string StrAcronym = null;
		string StrClinicID = null;
		string StrActive = null;
		private string StrPhoneNo = null;
		private string StrDepartmentID = null;

		#endregion


		#region "Properties"

		/// <summary>
		/// ServiceId Primary Key
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrServiceId;
			}

			set
			{
				StrServiceId=value;
			}
		}

		/// <summary>
		/// ServiceName field
		/// </summary>

		public string ServiceName
		{
			get
			{
				return StrServiceName;
			}

			set
			{
				StrServiceName=value;
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
		/// ClinicID field
		/// </summary>

		public string ClinicID
		{
			get
			{
				return StrClinicID;
			}

			set
			{
				StrClinicID = value;
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
		/// Service Phone Number	(string, 15)
		/// </summary>
		public string PhoneNo
		{
			get{	return StrPhoneNo;	}
			set{	StrPhoneNo = value;	}
		}

		/// <summary>
		/// Department ID field
		/// </summary>
		public string DepartmentID
		{
			get{	return StrDepartmentID;		}
			set{	StrDepartmentID = value;	}
		}

		#endregion


		#region "Data_Methods"
		
		// INSERT DATA IN Service TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Service table
			SP.SERVICE = (clsdatadefinition.SPService)1; // 1 is used for get insert stored procedure name
			StrData = SP.SERVICE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 4, ParameterDirection.Output, false, 0, 0, "ServiceId", DataRowVersion.Default, null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICENAME", OleDbType.VarChar, 50, "SERVICENAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM", OleDbType.VarChar, 5, "ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MClinicID", OleDbType.VarChar, 3, "ClinicID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE", OleDbType.VarChar, 1, "ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDepartmentID", OleDbType.VarChar, 4, "DepartmentID"));
			
			ObjCommand.Parameters["@MSERVICENAME"].Value=StrServiceName;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MClinicID"].Value = this.StrClinicID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MDepartmentID"].Value = StrDepartmentID;
			
			return ObjCommand;
		}

		// UPDATE RECORD IN SERVICE TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SERVICE table
			SP.SERVICE = (clsdatadefinition.SPService)2; // 2 is used for get update stored procedure name
			StrData = SP.SERVICE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID", OleDbType.VarChar, 4, "ServiceId"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICENAME", OleDbType.VarChar, 50, "SERVICENAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM", OleDbType.VarChar, 5, "ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MClinicID", OleDbType.VarChar, 3, "ClinicID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE", OleDbType.VarChar, 1, "ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDepartmentID", OleDbType.VarChar, 4, "DepartmentID"));
			
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceId;
			ObjCommand.Parameters["@MSERVICENAME"].Value=StrServiceName;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MClinicID"].Value = this.StrClinicID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MDepartmentID"].Value = StrDepartmentID;
			
			return ObjCommand;
		}

		// DELETE RECORD IN SERVICE TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SERVICE table
			SP.SERVICE = (clsdatadefinition.SPService)3; //3 is used for get delete stored procedure name
			StrData = SP.SERVICE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID", OleDbType.VarChar, 4, "ServiceId"));
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceId;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SERVICE TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in SERVICE table
			SP.SERVICE = (clsdatadefinition.SPService)4;  //4 is used for get search all stored procedure name
			StrData = SP.SERVICE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICENAME", OleDbType.VarChar, 50, "SERVICENAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM", OleDbType.VarChar, 5, "ACRONYM"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MClinicID", OleDbType.VarChar, 3, "ClinicID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE", OleDbType.VarChar, 1, "ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPhoneNo", OleDbType.VarChar, 15, "PhoneNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDepartmentID", OleDbType.VarChar, 4, "DepartmentID"));
			
			ObjCommand.Parameters["@MSERVICENAME"].Value=StrServiceName;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;
			ObjCommand.Parameters["@MClinicID"].Value = this.StrClinicID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MPhoneNo"].Value = StrPhoneNo;
			ObjCommand.Parameters["@MDepartmentID"].Value = StrDepartmentID;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SERVICE TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SERVICE table
			SP.SERVICE = (clsdatadefinition.SPService)5; //5 is used for get search Single stored procedure name
			StrData = SP.SERVICE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID", OleDbType.VarChar, 4, "ServiceId"));
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceId;
			
	
			return ObjCommand;
		}

		#endregion
	}
}