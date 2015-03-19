using System;
using System.Data.OleDb;
using System.Data;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsoperation.
	/// </summary>
	public class clsoperation
	{
		
		private string strmsg="False";
		protected OleDbCommand ObjCmd;
		private string StrOperationError;
		protected OleDbConnection Conn;
		protected  OleDbTransaction DbTrans;
		// clsdbconnection class
		protected clsdbconnection Objconn = new clsdbconnection();
		
		public clsoperation()
		{
			
		}

#region "Properties"

		public string OperationError
		{
			get
			{
				return StrOperationError;
			}
			set
			{
				StrOperationError = value;
			}
		}

		public OleDbConnection GetConnection
		{
			get
			{
				return Conn;
			}
		}

		public OleDbTransaction DBTransaction
		{
			get
			{
				return DbTrans;
			}
		}

#endregion

#region "Enumeration"

		public enum Get_PKey : byte
		{
			Yes = 1,
			No = 2
		}
#endregion

#region "Error_Transction"

	public void Start_Transaction()
	{
		// Get Database connection
		Conn = Objconn.OleDb_SQL_Connection;
		// Declare Transaction Variable 
		DbTrans = Conn.BeginTransaction();  //New a transaction		
	}

		public void End_Transaction()
		{
			if (strmsg == "True")
			{
				// Rollback transaction
				DbTrans.Rollback();
				Conn.Close();
				Conn.Dispose();
				Conn = null;
				DbTrans = null;
			}
			else
			{
				// commit transaction
				DbTrans.Commit();			
				Conn.Close();
				Conn.Dispose();
				Conn = null;
				DbTrans = null;
			}
		}	
	
#endregion

#region DataAccess

	
	public string DataTrigger_Insert(Iinterface Entity,Get_PKey Get_Primarykey)
	{
	
		try
			{
				// Get Command object with Stored procedure
				ObjCmd = Entity.Insert();
				// to Command object for a pending local transaction
				ObjCmd.Transaction = DbTrans;
						
				ObjCmd.Connection = Conn;				
				ObjCmd.ExecuteNonQuery();
					
				// Get primary key
					
				if (Get_Primarykey==Get_PKey.Yes)
					{
					string PKCode = (string) ObjCmd.Parameters["@PK_Code"].Value;
					Entity.PKeycode= PKCode;
					// convert PKeycode value in string
					strmsg = Entity.PKeycode.ToString();
					}
				else 
					{	
					strmsg="False";
					}
			}
			catch(Exception e)
			{	
				OperationError = (e.ToString()) +
				"Sorry, Record can not be updated.";
				strmsg="True";
				return strmsg ;
			}
		return strmsg;
	}
		public string DataTrigger_Delete(Iinterface Entity)
		{
		
			// Get Command object with Stored procedure
			ObjCmd = Entity.Delete();
			// to Command object for a pending local transaction
			ObjCmd.Transaction = DbTrans;
			
			try
			{
				ObjCmd.Connection = Conn;				
				ObjCmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				OperationError = (e.ToString()) +
					"Sorry, Record can not be updated.";
				strmsg="True";
			}
			return strmsg ;
		}
		
	public  string DataTrigger_Update(Iinterface Entity)
		{
			// Get Command object with Stored procedure
			ObjCmd = Entity.Update();
			// to Command object for a pending local transaction
			ObjCmd.Transaction = DbTrans;
			
			try
			{
				ObjCmd.Connection = Conn;
				ObjCmd.ExecuteNonQuery();
			}
			catch(Exception e)
			{
				// Rollback transaction
				//DbTrans.Rollback();
				OperationError = (e.ToString()) +
					"Sorry, Record can not be updated.";
				strmsg="True";
			}
			return strmsg ;			
		}

	public DataView DataTrigger_Get_All(Iinterface Entity)
		{
			
			// Get Database connection
			Conn = Objconn.OleDb_SQL_Connection;
			
			ObjCmd = Entity.Get_All();
			ObjCmd.Connection = Conn;
				
			// Dataadapter
			OleDbDataAdapter da = new OleDbDataAdapter(ObjCmd);
			// fill dataset
			DataSet DS = new DataSet();
			da.Fill(DS);
				
			// Create the DataView Object
			DataView DV = new DataView(DS.Tables[0]);

		Conn.Close();
		Conn.Dispose();
		Conn = null;
			
			return DV;
		}

		public DataView DataTrigger_Get_Single(Iinterface Entity)
		{
			// Get Database connection
			Conn = Objconn.OleDb_SQL_Connection;
	
			ObjCmd = Entity.Get_Single();
			ObjCmd.Connection = Conn;
				
			// Dataadapter
			OleDbDataAdapter da = new OleDbDataAdapter(ObjCmd);
			// fill dataset
			DataSet DS = new DataSet();
			da.Fill(DS);
				
			// Create the DataView Object
			DataView DV = new DataView(DS.Tables[0]);
				
			Conn.Close();
			Conn.Dispose();
			Conn = null;

			return DV;
		}
#endregion
	}
}
