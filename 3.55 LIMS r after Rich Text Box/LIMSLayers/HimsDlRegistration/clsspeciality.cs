using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsspeciality.
	/// </summary>
	public class clsspeciality:Iinterface
	{
		public clsspeciality()
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
	string StrSpecialityId;
	string StrSpecialityDesc;
	string StrActive;
	string StrSpecialityTypeId;

#endregion
		
#region "Properties"

	/// <summary>
	/// SpecialityId Primary key field
	/// </summary>
	
	public string PKeycode
	{
		get
		{
			return StrSpecialityId;
		}
		
		set
		{
			StrSpecialityId=value;
		}
	}

	/// <summary>
	/// SpecialityDesc field
	/// </summary>

	public string SpecialityDesc
	{
		get
		{
			return StrSpecialityDesc;
		}
	
		set
		{
			StrSpecialityDesc=value;
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
		/// SpecialityTYpeID field
		/// </summary>

		public string SpecialityTypeID
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
#endregion

#region "Data_Methods"
		
		
	// INSERT DATA IN SPECIALITY TABLE
	public  OleDbCommand Insert()
	{
		// Get Stored procedure name for insert SPECIALITY table
		SP.SPECIALITY = (clsdatadefinition.SPSpeciality)1; // 1 is used for get insert stored procedure name
		StrData = SP.SPECIALITY.ToString().Replace("3",".");
	
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;
	

		ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,4,ParameterDirection.Output,false,0,0,"SPECIALITYID",DataRowVersion.Default,null));
		ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYDESC",OleDbType.VarChar,50,"SPECIALITYDESC"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALITYTYPEID"));
		
		ObjCommand.Parameters["@MSPECIALITYDESC"].Value=StrSpecialityDesc;
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSpecialityTypeId;
		
		return ObjCommand;
	}

	// UPDATE RECORD IN SPECIALITYID TABLE
	public OleDbCommand Update()
	{
		// get Stored procedure name for Update record in SPECIALITY table
		SP.SPECIALITY = (clsdatadefinition.SPSpeciality)2; // 2 is used for get update stored procedure name
		StrData = SP.SPECIALITY.ToString().Replace("3",".");
	
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYID",OleDbType.Char,4,"SPECIALITYID"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYDESC",OleDbType.VarChar,50,"SPECIALITYDESC"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYTYPEID",OleDbType.Char,4,"SPECIALITYTYPEID"));
		
		ObjCommand.Parameters["@MSPECIALITYID"].Value=StrSpecialityId;
		ObjCommand.Parameters["@MSPECIALITYDESC"].Value=StrSpecialityDesc;
		ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
		ObjCommand.Parameters["@MSPECIALITYTYPEID"].Value=StrSpecialityTypeId;
		
		return ObjCommand;
	}

	// DELETE RECORD IN SPECIALITY TABLE
	public OleDbCommand Delete()
	{
		// get Stored procedure name for Delete record in SPECIALITY table
		SP.SPECIALITY = (clsdatadefinition.SPSpeciality)3; //3 is used for get delete stored procedure name
		StrData = SP.SPECIALITY.ToString().Replace("3",".");
	
		OleDbCommand ObjCommand = new OleDbCommand();
		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYID",OleDbType.Char,4,"SPECIALITYID"));
		ObjCommand.Parameters["@MSPECIALITYID"].Value=StrSpecialityId;
		
		return ObjCommand;
	}

	// SELECT ALL RECORD IN SPECIALITY TABLE
	public OleDbCommand Get_All()
	{

		// get Stored procedure name for Get All record in SPECIALITY table
		SP.SPECIALITY = (clsdatadefinition.SPSpeciality)4;  //4 is used for get search all stored procedure name
		StrData = SP.SPECIALITY.ToString().Replace("3",".");
	
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		return ObjCommand;
	}

	// SELECT SINGLE RECORD FROM SPECIALITY TABLE
	public OleDbCommand Get_Single()
	{

		// get Stored procedure name for Search Single record in SPECIALITY table
		SP.SPECIALITY = (clsdatadefinition.SPSpeciality)5; //5 is used for get search Single stored procedure name
		StrData = SP.SPECIALITY.ToString().Replace("3",".");
	
		OleDbCommand ObjCommand = new OleDbCommand();

		ObjCommand.CommandText =StrData;
		ObjCommand.CommandType = CommandType.StoredProcedure;

		ObjCommand.Parameters.Add(new OleDbParameter("@MSPECIALITYID",OleDbType.Char,4,"SPECIALITYID"));
		ObjCommand.Parameters["@MSPECIALITYID"].Value=StrSpecialityId;
		

		return ObjCommand;
	}

#endregion
	
	}
}
