using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// 
	/// </summary>
	public class clspvcomment:Iinterface 
	{
		public clspvcomment()
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
		string StrHospitalNo=null;
		string StrComments=null;
	#endregion


		#region "Properties"

		/// <summary>
		/// HospitalNo
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrHospitalNo;
			}

			set
			{
				StrHospitalNo=value;
			}
		}

		/// <summary>
		/// Comments field
		/// </summary>

		public string Comments
		{
			get
			{
				return StrComments;
			}

			set
			{
				StrComments=value;
			}
		}
		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN PVCOMMENT TABLE
		public  OleDbCommand Insert()
		{
			OleDbCommand ObjCommand = new OleDbCommand();
			return ObjCommand;
		}

		// UPDATE RECORD IN PVCOMMENT TABLE

		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in PVCOMMENT table
			SP.PVCOMMENT  = (clsdatadefinition.SPPVComment)2; // 2 is used for get update stored procedure name
			StrData = SP.PVCOMMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HospitalNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MCOMMENTS",OleDbType.VarChar,50,"Comments"));

			
			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHospitalNo; 
			ObjCommand.Parameters["@MCOMMENTS"].Value=StrComments;
			return ObjCommand;
		}

		// DELETE RECORD IN Patient Visit Comments TABLE
		public OleDbCommand Delete()
		{
			OleDbCommand ObjCommand = new OleDbCommand();
			return ObjCommand;
		}

		// SELECT ALL RECORD IN PVCOMMENT TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in CLINIC table
			SP.PVCOMMENT = (clsdatadefinition.SPPVComment)4;  //4 is used for get search all stored procedure name
			StrData = SP.PVCOMMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM PVCOMMENT TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in CLINIC table
			SP.PVCOMMENT = (clsdatadefinition.SPPVComment)5; //5 is used for get search Single stored procedure name
			StrData = SP.PVCOMMENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.Char,10,"HospitalNo"));
			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHospitalNo; 
				
			return ObjCommand;
		}

		#endregion

	}
}
