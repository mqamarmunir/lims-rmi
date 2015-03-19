using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsTPersonnelSpecialty.
	/// </summary>
	public class clsTPersonnelSpecialty:Iinterface
	{
		public clsTPersonnelSpecialty()
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
		private string StrData = null;
		private string StrPersonID = null;		
		private string StrDsgSpecialtyID = null;
		private string StrTransactionNo = null;
		
		#endregion

		#region "Properties"

		/// <summary>
		/// Transaction Number - Primary Key
		/// </summary>
		public string PKeycode
		{
			get
			{
				return StrTransactionNo;
			}
			set
			{
				StrTransactionNo = value;
			}
		}

		
		/// <summary>
		/// Person ID - Table Field
		/// </summary>
		public string PersonID
		{
			get
			{
				return StrPersonID;
			}
			set
			{
				StrPersonID = value;
			}
		}


		/// <summary>
		/// Designation Specialty ID - Table field
		/// </summary>
		public string DsgSpecialtyID
		{
			get
			{
				return StrDsgSpecialtyID;
			}
			set
			{
				StrDsgSpecialtyID = value;
			}
		}
				
		#endregion

		#region "Data_Methods"
		
		/// <summary>
		/// Insert Data in tPersonnelSpecialty Table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert tPersonnelSpecialty table
		
			SP.TPERSONNELSPECIALTY = (clsdatadefinition.SPTPersonnelSpecialty)1; // 1 is used for get insert stored procedure name
			StrData = SP.TPERSONNELSPECIALTY.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
		
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
		
			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 4, ParameterDirection.Output, false, 0, 0, "TRANSACTIONNO", DataRowVersion.Default, null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONID", OleDbType.VarChar, 6, "PERSONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDSGSPECIALTYID", OleDbType.VarChar, 5, "DSGSPECIALTYID"));
			
			ObjCommand.Parameters["@MPERSONID"].Value = StrPersonID;
			ObjCommand.Parameters["@MDSGSPECIALTYID"].Value = StrDsgSpecialtyID;
									
			return ObjCommand;
		}


		/// <summary>
		/// Update Record in tPersonnelSpecialty Table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Update()
		{
			// get Stored procedure name for Update record in tPersonnelSpecialty table
			
			SP.TPERSONNELSPECIALTY = (clsdatadefinition.SPTPersonnelSpecialty)2; // 2 is used for get update stored procedure name
			StrData = SP.TPERSONNELSPECIALTY.ToString().Replace("3",".");
			
			OleDbCommand ObjCommand = new OleDbCommand();
			
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
				
			ObjCommand.Parameters.Add(new OleDbParameter("@MTRANSACTIONNO",OleDbType.VarChar,4, "TRANSACTIONNO"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONID", OleDbType.VarChar, 6, "PERSONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDSGSPECIALTYID", OleDbType.VarChar, 5, "DSGSPECIALTYID"));
			
			ObjCommand.Parameters["@MTRANSACTIONNO"].Value = StrTransactionNo;
			ObjCommand.Parameters["@MPERSONID"].Value = StrPersonID;
			ObjCommand.Parameters["@MDSGSPECIALTYID"].Value = StrDsgSpecialtyID;
			
			return ObjCommand;
		}


		/// <summary>
		/// Delete Record from tPersonnelSpecialty table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Delete()
		{
			// get Stored procedure name for Delete record in tPersonnelSpecialty table
			
			SP.TPERSONNELSPECIALTY = (clsdatadefinition.SPTPersonnelSpecialty)3;	//3 is used for get delete stored procedure name
			StrData = SP.TPERSONNELSPECIALTY.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();
			
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONID", OleDbType.VarChar, 6, "PERSONID"));
			ObjCommand.Parameters["@MPERSONID"].Value = StrPersonID;
			
			return ObjCommand;
		}

		
		/// <summary>
		/// Get All Function for tPersonnelSpecialty table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_All()
		{
			// get Stored procedure name for Get All record in tPersonnelSpecialty table
			SP.TPERSONNELSPECIALTY = (clsdatadefinition.SPTPersonnelSpecialty)4;
			StrData = SP.TPERSONNELSPECIALTY.ToString().Replace("3",".");

			OleDbCommand ObjCommand = new OleDbCommand();
			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONID", OleDbType.VarChar, 6, "PERSONID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDSGSPECIALTYID", OleDbType.VarChar, 5, "DSGSPECIALTYID"));
			
			ObjCommand.Parameters["@MPERSONID"].Value = StrPersonID;
			ObjCommand.Parameters["@MDSGSPECIALTYID"].Value = StrDsgSpecialtyID;
				
			return ObjCommand;
		}


		/// <summary>
		/// Get Single Record from tPersonnelSpecialty table
		/// </summary>
		/// <returns>OleDbCommand</returns>
		public OleDbCommand Get_Single()
		{			
			// get Stored procedure name for Search Single record in tPersonnelSpecialty table
			SP.TPERSONNELSPECIALTY = (clsdatadefinition.SPTPersonnelSpecialty)5; //5 is used for get search Single stored procedure name
			StrData = SP.TPERSONNELSPECIALTY.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;
	
			ObjCommand.Parameters.Add(new OleDbParameter("@MPERSONID", OleDbType.VarChar, 6, "PERSONID"));
			ObjCommand.Parameters["@MPERSONID"].Value = StrPersonID;
				
			return ObjCommand;		
		}

		#endregion
	}
}
