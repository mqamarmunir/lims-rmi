using System;
using System.Data;  
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Organizations" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2005
	/// 	Type		:	Business Layer Class
	/// </summary>
	
	public class clsBLOrganization
	{
		public clsBLOrganization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "Organizations";
		private string StrErrorMessage = "";
		private string StrActive = Default;

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
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

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select * from " + TableName + " Where Upper(Active) = '" + StrActive + "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		#endregion
	}
}
