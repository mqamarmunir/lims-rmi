using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsdoctorspeciality.
	/// </summary>
	public class clsdoctorspeciality:Iinterface
	{
		public clsdoctorspeciality()
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
		
	string StrPersonId=null;
	string StrSpecialityId=null;

#endregion

#region "Properties"

		/// <summary>
		///  Primary key
		/// </summary>

	public string PKeycode
	{
		get
		{
			return null;
		}
		set
		{
			value=null;
		}
	}

	/// <summary>
	/// DoctorId field
	/// </summary>
	
	public string PersonId
	{
		get
		{
			return StrPersonId;
		}
		
		set
		{
			StrPersonId=value;
		}
	}

	/// <summary>
	/// SpecialityId field
	/// </summary>

	public string SpecialityId
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
#endregion

#region "Data_Methods"
		
		
		// INSERT DATA IN DOCTORSPECIALITY TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert DOCTORSPECIALITY table
			SP.DOCTORSPECIALITY = (clsdatadefinition.SPDoctorspeciality)1; // 1 is used for get insert stored procedure name
			StrData = SP.DOCTORSPECIALITY.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonID",OleDbType.VarChar,5,"PERSONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSpecialityID",OleDbType.VarChar,4,"SpecialityID"));
			
			ObjCommand.Parameters["@MPersonID"].Value=StrPersonId;
			ObjCommand.Parameters["@MSpecialityID"].Value=StrSpecialityId;
			
			return ObjCommand;
		}
 
		// UPDATE RECORD IN DOCTORSPECIALITY TABLE
		public OleDbCommand Update()
		{
			return null;
		}

		// DELETE RECORD IN DOCTORSPECIALITY TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in DOCTORSPECIALITY table
			SP.DOCTORSPECIALITY = (clsdatadefinition.SPDoctorspeciality)3; //3 is used for get delete stored procedure name
			StrData = SP.DOCTORSPECIALITY.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonID",OleDbType.VarChar,5,"PersonID"));
			
			ObjCommand.Parameters["@MPersonID"].Value=StrPersonId;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN DOCTORSPECIALITY TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Delete record in DOCTORSPECIALITY table
			SP.DOCTORSPECIALITY = (clsdatadefinition.SPDoctorspeciality)4;  //4 is used for get search all stored procedure name
			StrData = SP.DOCTORSPECIALITY.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM DOCTORSPECIALITY
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in DOCTORSPECIALITY table
			SP.DOCTOR = (clsdatadefinition.SPDoctor)5; //5 is used for get search Single stored procedure name
			StrData = SP.DOCTOR.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@MPersonId",OleDbType.VarChar,5,"PERSONID"));
			ObjCommand.Parameters["@MPersonId"].Value=StrPersonId;		
			return ObjCommand;
		}

#endregion
	}
}
