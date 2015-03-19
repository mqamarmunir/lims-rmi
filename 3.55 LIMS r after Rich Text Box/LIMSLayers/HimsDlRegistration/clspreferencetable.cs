using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clspreferencetable.
	/// </summary>
	public class clspreferencetable:Iinterface 
	{
		public clspreferencetable()
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
		string StrREPORTNO=null;
		string StrREPORTDESC=null;
		string StrREPORTTITLE=null;
		string StrREPORTSUBTITLE1=null;
		string StrPAGEFOOTER=null;
		string StrTREESFOOTER1=null;
		string StrTREESFOOTER2=null;
					
	#endregion

		#region "Properties"

		/// <summary>
		/// ServiceId Primary Key
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrREPORTNO;
			}

			set
			{
				StrREPORTNO=value;
			}
		}

		/// <summary>
		/// Report Description field
		/// </summary>

		public string ReportDesc
		{
			get
			{
				return StrREPORTDESC;
			}

			set
			{
				StrREPORTDESC=value;
			}
		}


		/// <summary>
		/// Report Title field
		/// </summary>

		public string ReportTitle
		{
			get
			{
				return StrREPORTTITLE;
			}

			set
			{
				StrREPORTTITLE=value;
			}
		}



		/// <summary>
		/// Report Sub Title 1 field
		/// </summary>

		public string ReportSubTitle1
		{
			get
			{
				return StrREPORTSUBTITLE1;
			}

			set
			{
				StrREPORTSUBTITLE1=value;
			}
		}


		/// <summary>
		/// Page Footer field
		/// </summary>

		public string PageFooter
		{
			get
			{
				return StrPAGEFOOTER;
			}

			set
			{
				StrPAGEFOOTER=value;
			}
		}

		/// <summary>
		/// Trees Footer - 01 field
		/// </summary>

		public string TreesFooter1
		{
			get
			{
				return StrTREESFOOTER1;
			}

			set
			{
				StrTREESFOOTER1=value;
			}
		}


		/// <summary>
		/// Trees Footer - 02 field
		/// </summary>

		public string TreesFooter2
		{
			get
			{
				return StrTREESFOOTER2;
			}

			set
			{
				StrTREESFOOTER2=value;
			}
		}
		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Service TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Service table
			SP.PREFERENCETABLE = (clsdatadefinition.SPPreferenceTable)1; // 1 is used for get insert stored procedure name
			StrData = SP.PREFERENCETABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTNO",OleDbType.VarChar,10,"REPORTNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTDESC",OleDbType.VarChar,250,"REPORTDESC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTTITLE",OleDbType.VarChar,250,"REPORTTITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTSUBTITLE1",OleDbType.VarChar,250,"REPORTSUBTITLE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPAGEFOOTER",OleDbType.VarChar,250,"PAGEFOOTER"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTREESFOOTER1",OleDbType.VarChar,250,"TREESFOOTER1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTREESFOOTER2",OleDbType.VarChar,250,"TREESFOOTER2"));
			
			ObjCommand.Parameters["@MREPORTNO"].Value=StrREPORTNO;
			ObjCommand.Parameters["@MREPORTDESC"].Value=StrREPORTDESC;
			ObjCommand.Parameters["@MREPORTTITLE"].Value=StrREPORTTITLE;
			ObjCommand.Parameters["@MREPORTSUBTITLE1"].Value=StrREPORTSUBTITLE1;
			ObjCommand.Parameters["@MPAGEFOOTER"].Value=StrPAGEFOOTER;
			ObjCommand.Parameters["@MTREESFOOTER1"].Value=StrTREESFOOTER1;
			ObjCommand.Parameters["@MTREESFOOTER2"].Value=StrTREESFOOTER2;
		
			return ObjCommand;
		}

		// UPDATE RECORD IN SERVICE TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SERVICE table
			SP.PREFERENCETABLE = (clsdatadefinition.SPPreferenceTable)2; // 2 is used for get update stored procedure name
			StrData = SP.PREFERENCETABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTNO",OleDbType.VarChar,10,"REPORTNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTDESC",OleDbType.VarChar,250,"REPORTDESC"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTTITLE",OleDbType.VarChar,250,"REPORTTITLE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTSUBTITLE1",OleDbType.VarChar,250,"REPORTSUBTITLE1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPAGEFOOTER",OleDbType.VarChar,250,"PAGEFOOTER"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTREESFOOTER1",OleDbType.VarChar,250,"TREESFOOTER1"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MTREESFOOTER2",OleDbType.VarChar,250,"TREESFOOTER2"));
			
			ObjCommand.Parameters["@MREPORTNO"].Value=StrREPORTNO;
			ObjCommand.Parameters["@MREPORTDESC"].Value=StrREPORTDESC;
			ObjCommand.Parameters["@MREPORTTITLE"].Value=StrREPORTTITLE;
			ObjCommand.Parameters["@MREPORTSUBTITLE1"].Value=StrREPORTSUBTITLE1;
			ObjCommand.Parameters["@MPAGEFOOTER"].Value=StrPAGEFOOTER;
			ObjCommand.Parameters["@MTREESFOOTER1"].Value=StrTREESFOOTER1;
			ObjCommand.Parameters["@MTREESFOOTER2"].Value=StrTREESFOOTER2;
			
			return ObjCommand;
		}

		// DELETE RECORD IN SERVICE TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in SERVICE table
			SP.PREFERENCETABLE = (clsdatadefinition.SPPreferenceTable)3; //3 is used for get delete stored procedure name
			StrData = SP.PREFERENCETABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTNO",OleDbType.VarChar,10,"REPORTNO"));
			ObjCommand.Parameters["@MREPORTNO"].Value=StrREPORTNO;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN PREFERENCETABLE TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in PREFERENCETABLE table
			SP.PREFERENCETABLE = (clsdatadefinition.SPPreferenceTable)4;  //4 is used for get search all stored procedure name
			StrData = SP.PREFERENCETABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SERVICE TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in SERVICE table
			SP.PREFERENCETABLE = (clsdatadefinition.SPPreferenceTable)5; //5 is used for get search Single stored procedure name
			StrData = SP.PREFERENCETABLE.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MREPORTNO",OleDbType.VarChar,10,"REPORTNO"));
			ObjCommand.Parameters["@MREPORTNO"].Value=StrREPORTNO;
			
			return ObjCommand;
		}
		#endregion

	}
}
