using System;
using System.Data;
using System.Data.OleDb;
namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsshuffledpatient.
	/// </summary>
	public class clsshuffledpatient:Iinterface
	{
		public clsshuffledpatient()
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
		private string StrPCode;
		private string StrHOSPITALNO;
		private int IntTRANSNO;
		private string StrASSIGNERDOCTORID;
		private string StrASSGNEDDOCTORID;


	#endregion

		#region "Properties"

		/// <summary>
		/// DOCTOR STATUS ID Primary key
		/// </summary>

		public string PKeycode
		{
			get
			{
				return StrPCode;
			}
			set
			{
				StrPCode=value;
			}
		}

		/// <summary>
		/// Hospital No table field
		/// </summary>

		public string HOSPITALNO
		{
			get
			{
				return StrHOSPITALNO;
			}
			set
			{
				StrHOSPITALNO=value;
			}
		}


		public int TRANSNO
		{
			get
			{
				return IntTRANSNO;
			}
			set
			{
				IntTRANSNO=value;
			}
		}

		/// <summary>
		/// ASSIGNER DOCTOR ID table field
		/// </summary>

		public string ASSIGNERDOCTORID
		{
			get
			{
				return StrASSIGNERDOCTORID;
			}
			set
			{
				StrASSIGNERDOCTORID=value;
			}
		}

		/// <summary>
		/// ASSIGNER DOCTOR ID table field
		/// </summary>

		public string ASSGNEDDOCTORID
		{
			get
			{
				return StrASSGNEDDOCTORID;
			}
			set
			{
				StrASSGNEDDOCTORID=value;
			}
		}

	#endregion


		#region "Data_Methods"
		
		
		// INSERT DATA IN SHUFFLEDPATIENT TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert SHUFFLEDPATIENT table
			SP.SHUFFLEDPATIENT = (clsdatadefinition.SPShuffledPatient)1; // 1 is used for get insert stored procedure name
			StrData = SP.SHUFFLEDPATIENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.VarChar,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MASSIGNERDOCTORID",OleDbType.Char,4,"ASSIGNERDOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MASSGNEDDOCTORID",OleDbType.Char,4,"ASSGNEDDOCTORID"));          

			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MASSIGNERDOCTORID"].Value=StrASSIGNERDOCTORID;
			ObjCommand.Parameters["@MASSGNEDDOCTORID"].Value=StrASSGNEDDOCTORID;			
			return ObjCommand;
		}

		// UPDATE RECORD IN SHUFFLEDPATIENT TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SHUFFLEDPATIENT table
			SP.SHUFFLEDPATIENT = (clsdatadefinition.SPShuffledPatient)2; // 2 is used for get update stored procedure name
			StrData = SP.SHUFFLEDPATIENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.VarChar,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTRANSNO",OleDbType.Integer, 2,"TRANSNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MASSIGNERDOCTORID",OleDbType.Char,4,"ASSIGNERDOCTORID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MASSGNEDDOCTORID",OleDbType.Char,4,"ASSGNEDDOCTORID"));          

			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MTRANSNO"].Value=IntTRANSNO;
			ObjCommand.Parameters["@MASSIGNERDOCTORID"].Value=StrASSIGNERDOCTORID;
			ObjCommand.Parameters["@MASSGNEDDOCTORID"].Value=StrASSGNEDDOCTORID;			
			return ObjCommand;
		}

		// DELETE RECORD IN SHUFFLEDPATIENT TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SHUFFLEDPATIENT table
			SP.SHUFFLEDPATIENT = (clsdatadefinition.SPShuffledPatient)3; //3 is used for get delete stored procedure name
			StrData = SP.SHUFFLEDPATIENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.VarChar,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTRANSNO",OleDbType.Integer, 2,"TRANSNO"));

			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MTRANSNO"].Value=IntTRANSNO;
		
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SHUFFLEDPATIENT TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in SHUFFLEDPATIENT table
			SP.SHUFFLEDPATIENT = (clsdatadefinition.SPShuffledPatient)4;  //4 is used for get search all stored procedure name
			StrData = SP.SHUFFLEDPATIENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.VarChar,10,"HOSPITALNO"));		
			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SHUFFLEDPATIENT
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SHUFFLEDPATIENT table
			SP.SHUFFLEDPATIENT = (clsdatadefinition.SPShuffledPatient)5; //5 is used for get search Single stored procedure name
			StrData = SP.SHUFFLEDPATIENT.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MHOSPITALNO",OleDbType.VarChar,10,"HOSPITALNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTRANSNO",OleDbType.Integer, 2,"TRANSNO"));

			ObjCommand.Parameters["@MHOSPITALNO"].Value=StrHOSPITALNO;
			ObjCommand.Parameters["@MTRANSNO"].Value=IntTRANSNO;

			return ObjCommand;
		}

		#endregion
	}
}
