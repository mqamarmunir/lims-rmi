using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsspecialitytype.
	/// </summary>
	public class clsspecialitytype:Iinterface
	{
		public clsspecialitytype()
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
		string StrSpecialityTypeId;
		string StrSpecialityTypeDesc;
		string StrActive;

		#endregion
		
		#region "Properties"

		/// <summary>
		/// SpecialityTypeId Primary key field
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrSpecialityTypeId;
			}
		
			set
			{
				StrSpecialityTypeId=value;
			}
		}

		/// <summary>
		/// SpecialityTypeDesc field
		/// </summary>

		public string SpecialityTypeDesc
		{
			get
			{
				return StrSpecialityTypeDesc;
			}
	
			set
			{
				StrSpecialityTypeDesc=value;
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

		#endregion

		#region "Data_Methods"
		
		
		// INSERT DATA IN SPECIALITY TYPE TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert SPECIALITY TYPE table
			SP.SPECIALITYTYPE = (clsdatadefinition.SPSpecialityType)1; // 1 is used for get insert stored procedure name
			StrData = SP.SPECIALITYTYPE.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,4,ParameterDirection.Output,false,0,0,"SPECIALITYTYPEID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEDESC",OleDbType.VarChar,50,"SPECIALITYTYPEDESC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		
			ObjCommand.Parameters["@MSPECIALITYTYPEDESC"].Value=StrSpecialityTypeDesc;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		
			return ObjCommand;
		}

		// UPDATE RECORD IN SPECIALITYID TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SPECIALITY table
			SP.SPECIALITYTYPE = (clsdatadefinition.SPSpecialityType)2; // 2 is used for get update stored procedure name
			StrData = SP.SPECIALITYTYPE.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALITYTYPEID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEDESC",OleDbType.VarChar,50,"SPECIALITYTYPEDESC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSpecialityTypeId;
			ObjCommand.Parameters["@MSPECIALITYTYPEDESC"].Value=StrSpecialityTypeDesc;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		
			return ObjCommand;
		}

		// DELETE RECORD IN SPECIALITY TYPE TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SPECIALITYTYPE table
			SP.SPECIALITYTYPE = (clsdatadefinition.SPSpecialityType)3; //3 is used for get delete stored procedure name
			StrData = SP.SPECIALITYTYPE.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALITYTYPEID"));
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSpecialityTypeId;
		
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SPECIALITY TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in SPECIALITY table
			SP.SPECIALITYTYPE = (clsdatadefinition.SPSpecialityType)4;  //4 is used for get search all stored procedure name
			StrData = SP.SPECIALITYTYPE.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SPECIALITY TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SPECIALITY table
			SP.SPECIALITYTYPE = (clsdatadefinition.SPSpecialityType)5; //5 is used for get search Single stored procedure name
			StrData = SP.SPECIALITYTYPE.ToString().Replace("3",".");
	
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALITYTYPEID"));
			ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSpecialityTypeId;
			return ObjCommand;
		}

		#endregion
	}
}
