using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLDoctor.
	/// </summary>
	public class clsBLDoctor
	{
		public clsBLDoctor()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string StrErrorMessage = "";
		private string TableName = "tpersonnel";
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
			objdbhims.Query = "select personid, title||' '||fname||' '||mname||' '||lname personname "+
				"from "+TableName+" where active ='Y'";
			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView GetAll(string departmentID)
		{
			objdbhims.Query = "select personid, title||' '||fname||' '||mname||' '||lname personname "+
				"from "+TableName+" where active ='Y'"+
				"and departmentid='"+departmentID+"'";
			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
	}
}
