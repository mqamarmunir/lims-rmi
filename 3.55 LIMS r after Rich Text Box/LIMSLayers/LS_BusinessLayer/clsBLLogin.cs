using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLLogin.
	/// </summary>
	public class clsBLLogin
	{
		private string StrErrorMessage = "";
		private clsoperation objTrans;
		private clsdbhims objdbhims;
        private string StrLoginID = "";
        private string StrPasword = "";

		#region Properties
		public string ErrorMessage
		{
			get{	return StrErrorMessage;	}
			set{	StrErrorMessage = value;	}
		}
        public string LoginID
        {
            get { return StrLoginID; }
            set { StrLoginID = value; }
        }
        public string Pasword
        {
            get { return StrPasword; }
            set { StrPasword = value; }
        }
		#endregion

		public clsBLLogin()
		{
			objTrans = new clsoperation();
			objdbhims = new clsdbhims();
		}

		#region Method
		public bool GetLogin(User user)
		{
			objdbhims.Query = "select * from ls_tpersonnel "+
				"where Active ='Y' And loginid='"+ user.LoginID + "' and password='"+
				user.Password +"'";
			
			DataTable dvUser = objTrans.DataTrigger_Get_Single(objdbhims).Table;
			
			if(dvUser.Rows.Count > 0)
			{
				user.PersonID = dvUser.Rows[0].ItemArray[0].ToString();
				user.Active = dvUser.Rows[0].ItemArray[1].ToString();
				user.Salutation = dvUser.Rows[0].ItemArray[2].ToString();
				user.PersonName = dvUser.Rows[0].ItemArray[3].ToString();
				user.Acronym = dvUser.Rows[0].ItemArray[4].ToString();
				user.Sex = dvUser.Rows[0].ItemArray[5].ToString();
				user.RoleID = dvUser.Rows[0].ItemArray[6].ToString();

				return true;
			}
			else
			{
				user = null;
				StrErrorMessage = "Invalid Login/Password";
				return false;
			}
		}

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1: // get login
                    objdbhims.Query = "select personid,personname from whims2.hr_vpersonnel where active='Y' and loginid='" + StrLoginID +"' and pasword = '"+StrPasword+"'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
		#endregion
	}
}
