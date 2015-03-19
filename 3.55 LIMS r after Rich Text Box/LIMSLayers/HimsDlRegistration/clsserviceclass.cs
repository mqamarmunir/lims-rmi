using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsserviceclass.
	/// </summary>
	public class clsserviceclass:Iinterface 
	{
		public clsserviceclass()
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
		string StrPKeyCode=null;
		string StrServiceID=null;		
		string StrClassID=null;
		int IntRate=0;
		#endregion

		#region "Properties"

		public string PKeycode
		{
			get
			{
				return StrPKeyCode;
			}

			set
			{
				StrPKeyCode=value;
			}
		}


		/// <summary>
		/// ServiceID Primary Key
		/// </summary>
	
		public string ServiceID
		{
			get
			{
				return StrServiceID;
			}

			set
			{
				StrServiceID=value;
			}
		}

		/// <summary>
		/// ClassID field
		/// </summary>

		public string ClassID
		{
			get
			{
				return StrClassID;
			}

			set
			{
				StrClassID=value;
			}
		}


		/// <summary>
		/// Rate field
		/// </summary>

		public int Rate
		{
			get
			{
				return IntRate;
			}

			set
			{
				IntRate=value;
			}
		}



		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Rank TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert SERVICECLASS table
			SP.SERVICECLASS = (clsdatadefinition.SPServiceClass)1; // 1 is used for get insert stored procedure name
			StrData = SP.SERVICECLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

/*			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,4,ParameterDirection.Output,false,0,0,"RankID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;*/
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID",OleDbType.VarChar,4,"SERVICEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.VarChar,3,"CLASSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRATE",OleDbType.Integer,8,"Rate"));
			
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceID;
			ObjCommand.Parameters["@MCLASSID"].Value=StrClassID;
			ObjCommand.Parameters["@MRATE"].Value=IntRate;
			
			return ObjCommand;
		}

		// UPDATE RECORD IN Rank TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SERVICECLASS table
			SP.SERVICECLASS = (clsdatadefinition.SPServiceClass)2; // 2 is used for get update stored procedure name
			StrData = SP.SERVICECLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID",OleDbType.VarChar,4,"SERVICEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.VarChar,3,"CLASSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRATE",OleDbType.Integer,8,"Rate"));
			
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceID;
			ObjCommand.Parameters["@MCLASSID"].Value=StrClassID;
			ObjCommand.Parameters["@MRATE"].Value=IntRate;
			
			return ObjCommand;
		}

		// DELETE RECORD IN SERVICECLASS TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in RANk table
			SP.SERVICECLASS = (clsdatadefinition.SPServiceClass)3; //3 is used for get delete stored procedure name
			StrData = SP.SERVICECLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID",OleDbType.VarChar,4,"SERVICEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.VarChar,3,"CLASSID"));
			
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceID;
			ObjCommand.Parameters["@MCLASSID"].Value=StrClassID;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SERVICECLASS TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in RANK table
			SP.SERVICECLASS  = (clsdatadefinition.SPServiceClass)4;  //4 is used for get search all stored procedure name
			StrData = SP.SERVICECLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SERVICECLASS TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in RANK table
			SP.SERVICECLASS= (clsdatadefinition.SPServiceClass)5; //5 is used for get search Single stored procedure name
			StrData = SP.SERVICECLASS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MSERVICEID",OleDbType.VarChar,4,"SERVICEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.VarChar,3,"CLASSID"));
			
			ObjCommand.Parameters["@MSERVICEID"].Value=StrServiceID;
			ObjCommand.Parameters["@MCLASSID"].Value=StrClassID;
	
			return ObjCommand;
		}

		#endregion

	}
}
