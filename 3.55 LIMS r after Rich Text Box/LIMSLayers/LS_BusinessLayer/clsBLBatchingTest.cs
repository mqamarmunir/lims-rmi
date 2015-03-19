using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLBatchingTest.
	/// </summary>
	public class clsBLBatchingTest
	{
		public clsBLBatchingTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string StrErrorMessage = "";

		public string ErrorMessage
		{
			get{	return StrErrorMessage;	}
		}

		clsdbhims objdbhims = new clsdbhims();

		public bool Update(string[,] aryBatched)
		{
			clsoperation objTrans = new clsoperation();

			objTrans.Start_Transaction();
			bool isMaxIDMade = false;
			string maxBatchNo = "";

			for(int counter = 0; counter <= aryBatched.GetUpperBound(0); counter++)
			{
				if(aryBatched[counter, 0] != null)
				{
					if(aryBatched[counter, 1] == "N")
					{
						objdbhims.Query = "Update LS_TTest set TestBatchNo = 0 Where TestID = '" + aryBatched[counter, 0]+ "'";
						StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

						if(StrErrorMessage.Equals("True"))
						{
							StrErrorMessage = objTrans.OperationError;
							objTrans.End_Transaction();
							return false;
						}
					}
					else if(aryBatched[counter, 1] != "Y")
					{
						objdbhims.Query = "Update LS_TTest set TestBatchNo=" + aryBatched[counter, 1] + " Where TestID='" + aryBatched[counter, 0]+ "'";
						StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

						if(StrErrorMessage.Equals("True"))
						{
							StrErrorMessage = objTrans.OperationError;
							objTrans.End_Transaction();
							return false;
						}
					}
					else
					{
						if(!isMaxIDMade)
						{
							objdbhims.Query = "Select Max(TestBatchNo)+1 As MaxID From LS_TTest";
							StrErrorMessage = objTrans.DataTrigger_Get_Max(objdbhims);
							maxBatchNo = StrErrorMessage;
							isMaxIDMade = true;
						}

						if(!StrErrorMessage.Equals("True"))
						{
							objdbhims.Query = "Update LS_TTest set TestBatchNo=" + maxBatchNo + " Where TestID='" + aryBatched[counter, 0] + "'";
							StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

							if(StrErrorMessage.Equals("True"))
							{
								StrErrorMessage = objTrans.OperationError;
								objTrans.End_Transaction();
								return false;
							}
						}
						else
						{
							StrErrorMessage = objTrans.OperationError;
							objTrans.End_Transaction();
							return false;
						}
					}
				}
			}

			objTrans.End_Transaction();
			return true;
		}
	}
}