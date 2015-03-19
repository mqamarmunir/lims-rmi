using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcedure.
	/// </summary>
	public class clsBLTestProcedure
	{
		public clsBLTestProcedure()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTestProcedure";
		private string StrErrorMessage = "";
		private string StrProcedureID = Default;
		private string StrProcedure = Default;
		private string StrActive = Default;

		#endregion

		#region "Properties"

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}

		public string Procedure
		{
			get{	return StrProcedure;	}
			set{	StrProcedure = value;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert()
		{
			if(Validate())
			{
				try
				{
					QueryBuilder objQB = new QueryBuilder();

					objTrans.Start_Transaction();

					objdbhims.Query = objQB.QBGetMax("ProcedureID", TableName, "3");
					this.StrProcedureID = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrProcedureID.Equals("True"))
					{
						objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
						this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

						objTrans.End_Transaction();

						if(this.StrErrorMessage.Equals("True"))
						{
							this.StrErrorMessage = objTrans.OperationError;
							return false;
						}
						else
						{
							return true;
						}
					}
					else
					{
						this.StrErrorMessage = objTrans.OperationError;
						objTrans.End_Transaction();
						return false;
					}
				}
				catch(Exception e)
				{
					this.StrErrorMessage = e.Message;
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool Update()
		{
			if(Validate())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
				objTrans.End_Transaction();

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					return false;
				}
				else
				{
					return true;
				}
			}
			else
			{
				return false;
			}
		}

/*		public bool UpdateAll(string[,] arrayUpdate)
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();

			for(int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
			{
				this.StrProcedureID = arrayUpdate[counter, 0];
				this.StrDOrder = arrayUpdate[counter, 1];

				objdbhims.Query = objQB.QBUpdate(MakeArray(), "LS_TTestGroup");
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					objTrans.End_Transaction();
					return false;
				}
			}

			objTrans.End_Transaction();

			return true;
		}
*/
		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select * from " + TableName;
					break;

				case 2:
					objdbhims.Query = "Select * from " + TableName + " Where Upper(Active) = '" + StrActive.ToUpper() + "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryTestProcedure = new string[3,3];

			if(!this.StrProcedureID.Equals(Default))
			{
				aryTestProcedure[0,0] = "ProcedureID";
				aryTestProcedure[0,1] = this.StrProcedureID;
				aryTestProcedure[0,2] = "string";
			}

			if(!this.StrProcedure.Equals(Default))
			{
				aryTestProcedure[1,0] = "Procedure";
				aryTestProcedure[1,1] = this.StrProcedure;
				aryTestProcedure[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryTestProcedure[2,0] = "Active";
				aryTestProcedure[2,1] = this.StrActive;
				aryTestProcedure[2,2] = "string";
			}

			return aryTestProcedure;
		}

		#endregion

		#region "Validation Functions"

		private bool Validate()
		{
			if(!StrProcedure.Equals(Default))
			{
				if(!VD_Procedure())
				{
					return false;
				}
			}

			return true;
		}

		public bool VD_Procedure()
		{
			Validation objValid = new Validation();

			if(StrProcedure.Equals(""))
			{
				this.StrErrorMessage = "Please enter Procedure. (empty is not allowed)";
				return false;
			}

			DataView dvProcedure = GetAll(1);

			if(!StrProcedureID.Equals(Default))
			{
				dvProcedure.RowFilter = "ProcedureID <> '" + StrProcedureID + "'";
			}

			if(dvProcedure.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Procedure Name, it is already present.";
				return false;
			}

			return true;
		}

		#endregion
	}
}