using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsopddoctorstatus.
	/// </summary>
	public class clsopddoctorstatus:Iinterface
	{
		public clsopddoctorstatus()
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
	private string StrDOCTORSTATUSID;
	private string StrDOCTORID;
	private string StrSTATUS;
	private string StrDOCTORRETURNEDTIME;

	#endregion


	#region "Properties"

		public string PKeycode
		{
			get
			{
				return StrDOCTORSTATUSID;
			}
			set
			{
				StrDOCTORSTATUSID=value;
			}
		}

		/// <summary>
		/// Hospital No table field
		/// </summary>

		public string DOCTORID
		{
			get
			{
				return StrDOCTORID;
			}
			set
			{
				StrDOCTORID=value;
			}
		}


		public string STATUS
		{
			get
			{
				return StrSTATUS;
			}
			set
			{
				StrSTATUS=value;
			}
		}

		/// <summary>
		/// DOCTOR RETURNED TIME ID table field
		/// </summary>

		public string DOCTORRETURNEDTIME
		{
			get
			{
				return StrDOCTORRETURNEDTIME;
			}
			set
			{
				StrDOCTORRETURNEDTIME=value;
			}
		}
	#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Service TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Service table
			SP.OPDDOCTORSTATUS  = (clsdatadefinition.SPOPDDoctorStatus)1; // 1 is used for get insert stored procedure name
			StrData = SP.OPDDOCTORSTATUS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,8,ParameterDirection.Output,false,0,0,"DOCTORSTATUSID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORID",OleDbType.Char,4,"DOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSTATUS",OleDbType.Char,1,"STATUS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORRETURNEDTIME",OleDbType.Char,10,"DOCTORRETURNEDTIME"));
			
			//ObjCommand.Parameters["@MDOCTORSTATUSID"].Value=StrDOCTORSTATUSID;
			ObjCommand.Parameters["@MDOCTORID"].Value=StrDOCTORID;
			ObjCommand.Parameters["@MSTATUS"].Value=StrSTATUS;
			ObjCommand.Parameters["@MDOCTORRETURNEDTIME"].Value=StrDOCTORRETURNEDTIME;
			
			return ObjCommand;
		}

		// UPDATE RECORD IN SERVICE TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SERVICE table
			SP.OPDDOCTORSTATUS = (clsdatadefinition.SPOPDDoctorStatus)2; // 2 is used for get update stored procedure name
			StrData = SP.OPDDOCTORSTATUS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORSTATUSID",OleDbType.Char,8,"DOCTORSTATUSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORID",OleDbType.Char,4,"DOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSTATUS",OleDbType.VarChar,5,"STATUS"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORRETURNEDTIME",OleDbType.Char,10,"DOCTORRETURNEDTIME"));
			
			ObjCommand.Parameters["@MDOCTORSTATUSID"].Value=StrDOCTORSTATUSID;
			ObjCommand.Parameters["@MDOCTORID"].Value=StrDOCTORID;
			ObjCommand.Parameters["@MSTATUS"].Value=StrSTATUS;
			ObjCommand.Parameters["@MDOCTORRETURNEDTIME"].Value=StrDOCTORRETURNEDTIME;
			
			return ObjCommand;
		}

		// DELETE RECORD IN SERVICE TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SERVICE table
			SP.OPDDOCTORSTATUS = (clsdatadefinition.SPOPDDoctorStatus)3; //3 is used for get delete stored procedure name
			StrData = SP.OPDDOCTORSTATUS.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORSTATUSID",OleDbType.Char,8,"DOCTORSTATUSID"));
			ObjCommand.Parameters["@MDOCTORSTATUSID"].Value=StrDOCTORSTATUSID;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SERVICE TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in SERVICE table
			SP.OPDDOCTORSTATUS = (clsdatadefinition.SPOPDDoctorStatus)4;  //4 is used for get search all stored procedure name
			StrData = SP.OPDDOCTORSTATUS.ToString().Replace("3",".");


			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORID",OleDbType.Char,4,"DOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MSTATUS",OleDbType.VarChar,5,"STATUS"));

			ObjCommand.Parameters["@MDOCTORID"].Value=StrDOCTORID;
			ObjCommand.Parameters["@MSTATUS"].Value=StrSTATUS;

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SERVICE TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SERVICE table
			SP.OPDDOCTORSTATUS = (clsdatadefinition.SPOPDDoctorStatus)5; //5 is used for get search Single stored procedure name
			StrData = SP.OPDDOCTORSTATUS.ToString().Replace("3",".");
		

			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MDOCTORSTATUSID",OleDbType.Char,8,"DOCTORSTATUSID"));
			ObjCommand.Parameters["@MDOCTORSTATUSID"].Value=StrDOCTORSTATUSID;
			
	
			return ObjCommand;
		}

		#endregion

	}
}
