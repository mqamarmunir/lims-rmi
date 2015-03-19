using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTransHistory.
	/// </summary>
	public class clsBLTransHistory
	{
		public clsBLTransHistory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTRANSHISTORY";
		private string StrErrorMessage = "";
		private string StrTRANSNO = Default;
		private string StrPERSONID = Default;
		private string StrPROCESSID = Default;
		private string StrENTDATETIME = Default;	
		private string StrMSERIALNO = Default;
		private string StrDSERIALNO = Default;

		#endregion

		#region "Properties"
		
		public string TRANSNO
		{
			get{	return StrTRANSNO;	}
			set{	StrTRANSNO = value;	}
		}

		public string PERSONID
		{
			get{	return StrPERSONID;	}
			set{	StrPERSONID = value;	}
		}

		public string PROCESSID
		{
			get{	return StrPROCESSID;	}
			set{	StrPROCESSID = value;	}
		}
		
		public string MSERIALNO
		{
			get{	return StrMSERIALNO;	}
			set{	StrMSERIALNO = value;	}
		}

		public string DSERIALNO
		{
			get{	return StrDSERIALNO;	}
			set{	StrDSERIALNO = value;	}
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
			this.StrENTDATETIME = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
			QueryBuilder objQB = new QueryBuilder();
			objTrans.Start_Transaction();

			objdbhims.Query = objQB.QBGetMax("TRANSNO", TableName, "10");
			this.StrTRANSNO = objTrans.DataTrigger_Get_Max(objdbhims);

			if(!this.StrTRANSNO.Equals("True"))
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

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "";
					break;

				case 2:
					objdbhims.Query = "";
					break;

				case 3:
					objdbhims.Query = "";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[6,3];

			if(!this.StrTRANSNO.Equals(Default))
			{
				aryLIMS[0,0] = "TRANSNO";
				aryLIMS[0,1] = this.StrTRANSNO;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrPERSONID.Equals(Default))
			{
				aryLIMS[1,0] = "PERSONID";
				aryLIMS[1,1] = this.StrPERSONID;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrPROCESSID.Equals(Default))
			{
				aryLIMS[2,0] = "PROCESSID";
				aryLIMS[2,1] = this.StrPROCESSID;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrMSERIALNO.Equals(Default))
			{
				aryLIMS[3,0] = "MSERIALNO";
				aryLIMS[3,1] = this.StrMSERIALNO;
				aryLIMS[3,2] = "string";
			}	
		
			if(!this.StrDSERIALNO.Equals(Default))
			{
				aryLIMS[4,0] = "DSERIALNO";
				aryLIMS[4,1] = this.StrDSERIALNO;
				aryLIMS[4,2] = "string";
			}

			if(!this.StrENTDATETIME.Equals(Default))
			{
				aryLIMS[5,0] = "ENTDATETIME";
				aryLIMS[5,1] = this.StrENTDATETIME;
				aryLIMS[5,2] = "date";
			}

			return aryLIMS;
		}

		#endregion		
	}
}