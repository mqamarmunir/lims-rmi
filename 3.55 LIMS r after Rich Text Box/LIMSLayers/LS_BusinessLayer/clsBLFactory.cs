using System;
using System.Data;  
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Factory" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	March 2005
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	
	public class clsBLFactory
	{
		public clsBLFactory()
		{
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "Factory";
		private string StrErrorMessage = "";
		
		private string StrFactoryID = Default;
		private string StrActive = Default;
		private string StrOrgID = Default;
		private string StrFactoryType = Default;

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string FactoryID
		{
			get{	return StrFactoryID;	}
			set{	StrFactoryID = value;	}
		}
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		public string OrgID
		{
			get{	return StrOrgID;	}
			set{	StrOrgID = value;	}
		}
		
		public string FactoryType
		{
			get{	return StrFactoryType;	}
			set{	StrFactoryType = value;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public DataView GetAll(int flag)
		{
			string sActive = "";	
			string sFactoryType = "";

			if(!this.StrActive.Equals(Default))
			{sActive = " And Active = '"+ StrActive +"' ";}
			if(!this.StrFactoryType.Equals(Default))
			{sFactoryType = " And FactoryType = '"+ StrFactoryType +"' ";}

			switch(flag)
			{				
				case 1:
					objdbhims.Query = "Select * from " + TableName + " Where OrgID = '" + StrOrgID + "' "+sActive+sFactoryType+"";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		#endregion
	}
}