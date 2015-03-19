using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcess.
	/// </summary>
	public class clsBLTestProcess
	{
		public clsBLTestProcess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTestProcess";
		private string StrErrorMessage = "";
		private string StrProcessID = Default;
		private string StrProcedureID = Default;
		private string StrProcess = Default;
		private string StrScreen = Default;
		private string StrActive = Default;
		private string StrDescription = Default;
		private string StrSequence = Default;
        private string StrDisplayTag = Default;


		#endregion

		#region "Properties"

		public string ProcessID
		{
			get{	return StrProcessID;	}
			set{	StrProcessID = value;	}
		}

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}

		public string Process
		{
			get{	return StrProcess;	}
			set{	StrProcess = value;	}
		}

		public string Screen
		{
			get{	return StrScreen;	}
			set{	StrScreen = value;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		public string Description
		{
			get{	return StrDescription;	}
			set{	StrDescription = value;	}
		}

		public string Sequence
		{
			get{	return StrSequence;	}
			set{	StrSequence = value;	}
		}

        public string DisplayTag
		{
            get { return StrDisplayTag; }
            set { StrDisplayTag = value; }
		}
        
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert()
		{
			/*if(this.StrSectionID.Equals(""))
			{
				this.StrErrorMessage = "Please select Section (empty is not allowed).";
				return false;
			}

			if(this.StrTestGroup.Equals(""))
			{
				this.StrErrorMessage = "Please select Test Group (empty is not allowed).";
				return false;
			}

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMax("TestGroupID", TableName, "2");
				this.StrTestGroupID = objTrans.DataTrigger_Get_Max(objdbhims);

				if(!this.StrTestGroupID.Equals("True"))
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
			}*/return false;
		}

		public bool Update()
		{
			/*if(Validate())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), "LS_TTestGroup");
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
			}*/return false;
		}


		public bool UpdateAll(string[,] arrayUpdate)
		{
			/*clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();

			for(int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
			{
				this.StrTestGroupID = arrayUpdate[counter, 0];
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

			objTrans.End_Transaction();*/

			return true;
		}

		public string GetNextProcessID(string svalProcedureID, string svalProcessID)
		{
			StrProcessID = svalProcessID;
			StrProcedureID = svalProcedureID;

			DataView dvTestProcess = GetAll(2);		
			
			return dvTestProcess.Table.Rows[0]["ProcessID"].ToString();			
		}

		public string GetPriorProcessID(string svalProcedureID, string svalProcessID)
		{
			StrProcessID = svalProcessID;
			StrProcedureID = svalProcedureID;

			DataView dvTestProcess = GetAll(3);		

			return dvTestProcess.Table.Rows[0]["ProcessID"].ToString();			
		}
		
		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select ProcessID, Process from LS_VTestProcess Where ProcedureID = '" + StrProcedureID + "' And DList = 'Y'";

                    if (!DisplayTag.Equals("VS"))
                    {
                        objdbhims.Query += " And ProcessID in ('0002', '0003', '0004', '0005')";
                    }

                    objdbhims.Query += " order by sequence"; 

					break;

				case 2:
					objdbhims.Query = "Select ProcessID from LS_TTestProcess Where Sequence > (Select Sequence from LS_TTestProcess Where ProcessID = '" + StrProcessID + "' And PROCEDUREID = '" + StrProcedureID + "')And PROCEDUREID = '" + StrProcedureID + "' and Active='Y' order by sequence";
					break;

				case 3:
					objdbhims.Query = "Select ProcessID from LS_TTestProcess Where Sequence < (Select Sequence from LS_TTestProcess Where ProcessID = '" + StrProcessID + "')And PROCEDUREID = '" + StrProcedureID + "' and Active='Y' order by sequence Desc";
					break;

				case 4:
                    objdbhims.Query = "Select ProcessID,Process From LS_TTestProcess Where Active='Y'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[6,3];

			/*if(!this.StrTestGroupID.Equals(Default))
			{
				aryTestGroup[0,0] = "TestGroupID";
				aryTestGroup[0,1] = this.StrTestGroupID;
				aryTestGroup[0,2] = "string";
			}

			if(!this.StrTestGroup.Equals(Default))
			{
				aryTestGroup[1,0] = "TestGroup";
				aryTestGroup[1,1] = this.StrTestGroup;
				aryTestGroup[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryTestGroup[2,0] = "Active";
				aryTestGroup[2,1] = this.StrActive;
				aryTestGroup[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryTestGroup[3,0] = "Acronym";
				aryTestGroup[3,1] = this.StrAcronym;
				aryTestGroup[3,2] = "string";
			}

			if(!this.StrSectionID.Equals(Default))
			{
				aryTestGroup[4,0] = "SectionID";
				aryTestGroup[4,1] = this.StrSectionID;
				aryTestGroup[4,2] = "string";
			}

			if(!this.StrDOrder.Equals(Default))
			{
				aryTestGroup[5,0] = "DOrder";
				aryTestGroup[5,1] = "1";//this.DOrder;
				aryTestGroup[5,2] = "int";
			}
*/
			return aryTestGroup;
		}

		#endregion
	}
}
