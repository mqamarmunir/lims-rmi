using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLService.
	/// </summary>
	public class clsBLService
	{
		public clsBLService()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private string StrErrorMessage = "";
		private string TableName = "Service";
		private const string Default = "~!@";
		private string StrActive = Default;
        private string _DepartmentId = Default;
        private string _SubdepartmentId = Default;
        

		#region "Properties"

		public string ErrorMessage
		{
			get	{ return StrErrorMessage; }
			set { StrErrorMessage = value; }
		}
        public string SubdepartmentID
        {
            get { return this._SubdepartmentId; }
            set { this._SubdepartmentId = value; }
        }
        public string DepartmentId
        { get { return this._DepartmentId; } set { this._DepartmentId = value; } }
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
			objdbhims.Query = "select serviceid, servicename "+
				"from "+TableName+" where active ='Y'";
			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView GetAll(string clinicID)
		{
			objdbhims.Query = "select serviceid, servicename "+
				"from "+TableName+" where active ='Y'"+
				"and clinicid='"+clinicID+"'";
			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
	}
}
