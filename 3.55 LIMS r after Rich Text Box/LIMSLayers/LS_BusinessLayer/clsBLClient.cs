using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLClient.
	/// </summary>
	public class clsBLClient
	{
		public clsBLClient()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string StrErrorMessage = "";
		private const string Default = "~!@";
		private string StrActive = Default;

		#region "Properties"

		public string ErrorMessage
		{
			get	{ return StrErrorMessage; }
			set { StrErrorMessage = value; }
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		public DataView GetAll()
		{
			objdbhims.Query = "Select ClientID, ClientName from LS_TClient";

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
	}
}
