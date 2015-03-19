using System;
using System.Data;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsrank.
	/// </summary>
	public class clsrank:Iinterface
	{
		public clsrank()
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
		string StrRankID=null;
		string StrRankName=null;
		string StrAcronym=null;		
		string StrClassID=null;
		string StrActive=null;
		string StrOrgID=null;

		#endregion

		#region "Properties"

		/// <summary>
		/// RankID Primary Key
		/// </summary>
	
		public string PKeycode
		{
			get
			{
				return StrRankID;
			}

			set
			{
				StrRankID=value;
			}
		}

		/// <summary>
		/// RankName field
		/// </summary>

		public string RankName
		{
			get
			{
				return StrRankName;
			}

			set
			{
				StrRankName=value;
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
		/// FactoryType field changed to OrgID
		/// </summary>

		public string OrgID
		{
			get
			{
				return StrOrgID;
			}

			set
			{
				StrOrgID = value;
			}
		}

		#endregion

		#region "Data_Methods"
		
		// INSERT DATA IN Rank TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert Rank table
			SP.RANK = (clsdatadefinition.SPRank)1; // 1 is used for get insert stored procedure name
			StrData = SP.RANK.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code",OleDbType.Char,4,ParameterDirection.Output,false,0,0,"RankID",DataRowVersion.Default,null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKNAME",OleDbType.VarChar,50,"RANKNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.Char,3,"CLASSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));

			ObjCommand.Parameters["@MRANKNAME"].Value = StrRankName;
			ObjCommand.Parameters["@MACRONYM"].Value = StrAcronym;			
			ObjCommand.Parameters["@MCLASSID"].Value = StrClassID;
			ObjCommand.Parameters["@MACTIVE"].Value = StrActive;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;

			return ObjCommand;
		}

		// UPDATE RECORD IN Rank TABLE
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in SECTION table
			SP.RANK = (clsdatadefinition.SPRank)2; // 2 is used for get update stored procedure name
			StrData = SP.RANK.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RankID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKNAME",OleDbType.VarChar,50,"RANKNAME"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACRONYM",OleDbType.VarChar,5,"ACRONYM"));			
			ObjCommand.Parameters.Add(new OleDbParameter("@MCLASSID",OleDbType.Char,3,"CLASSID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MACTIVE",OleDbType.Char,1,"ACTIVE"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));

			ObjCommand.Parameters["@MRANKID"].Value=StrRankID;
			ObjCommand.Parameters["@MRANKNAME"].Value=StrRankName;
			ObjCommand.Parameters["@MACRONYM"].Value=StrAcronym;			
			ObjCommand.Parameters["@MCLASSID"].Value=StrClassID;
			ObjCommand.Parameters["@MACTIVE"].Value=StrActive;
			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;

			return ObjCommand;
		}

		// DELETE RECORD IN SECTION TABLE
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in RANk table
			SP.RANK = (clsdatadefinition.SPRank)3; //3 is used for get delete stored procedure name
			StrData = SP.RANK.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RankID"));
			ObjCommand.Parameters["@MRANKID"].Value=StrRankID;
			
			return ObjCommand;
		}

		// SELECT ALL RECORD IN SECTION TABLE
		public OleDbCommand Get_All()
		{

			// get Stored procedure name for Get All record in RANK table
			SP.RANK = (clsdatadefinition.SPRank)4;  //4 is used for get search all stored procedure name
			StrData = SP.RANK.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MORGID",OleDbType.Char,2,"ORGID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MClassID", OleDbType.Char, 3, "ClassID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MActive", OleDbType.Char, 1, "Active"));

			ObjCommand.Parameters["@MORGID"].Value = StrOrgID;
			ObjCommand.Parameters["@MClassID"].Value = StrClassID;
			ObjCommand.Parameters["@MActive"].Value = StrActive;
			return ObjCommand;
		}

		// SELECT SINGLE RECORD FROM SECTION TABLE
		public OleDbCommand Get_Single()
		{

			// get Stored procedure name for Search Single record in RANK table
			SP.RANK = (clsdatadefinition.SPRank)5; //5 is used for get search Single stored procedure name
			StrData = SP.RANK.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MRANKID",OleDbType.Char,4,"RankID"));
			ObjCommand.Parameters["@MRANKID"].Value=StrRankID;			
	
			return ObjCommand;
		}

		#endregion
	}
}