using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLEMailPreferences
    {
        public clsBLEMailPreferences()
        {
            ///Add Constructor Logic Here...
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TEMAILPREFERENCES";
        private string StrEmailPreferenceID = Default;

      
        private string StrHostAddress = Default;
        private string StrPortNumber = Default;
        private string StrUserName = Default;
        private string StrPassword = Default;
        private string StrFooter = Default;
        private string StrMessageFrom = Default;

     
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_IP = Default;

     
        private string StrErrorMessage = Default;


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string EmailPreferenceID
        {
            get { return StrEmailPreferenceID; }
            set { StrEmailPreferenceID = value; }
        }
        public string HostAddress
        {
            get { return StrHostAddress; }
            set { StrHostAddress = value; }
        }
        public string PortNumber
        {
            get { return StrPortNumber; }
            set { StrPortNumber = value; }
        }
        public string UserName
        {
            get { return StrUserName; }
            set { StrUserName = value; }
        }
        public string Password
        {
            get { return StrPassword; }
            set { StrPassword = value; }
        }
        public string Footer
        {
            get { return StrFooter; }
            set { StrFooter = value; }
        }
        public string MessageFrom
        {
            get { return StrMessageFrom; }
            set { StrMessageFrom = value; }
        }
        public string EnteredBy
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }
        public string EnteredOn
        {
            get { return StrEnteredOn; }
            set { StrEnteredOn = value; }
        }

        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }
        public string System_IP
        {
            get { return StrSystem_IP; }
            set { StrSystem_IP = value; }
        }

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From LS_TEmailPreferences";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();
                    objdbhims.Query = "Select NVL(Max(EMAILPREFERENCEID),0)+1 as MAXID From " + TableName;
                   // objdbhims.Query = objQB.QBGetMax("EMAILPREFERENCEID", TableName, "6");
                    this.StrEmailPreferenceID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (!this.StrEmailPreferenceID.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
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
                catch (Exception e)
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
            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
            if (Validation())
            {
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();

                if (this.StrErrorMessage.Equals("True"))
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

        private string[,] MakeArray()
        {
            string[,] ary_Email = new string[11, 3];

            if (!StrEmailPreferenceID.Equals(Default))
            {
                ary_Email[0, 0] = "EmailPreferenceID";
                ary_Email[0, 1] = this.StrEmailPreferenceID;
                ary_Email[0, 2] = "int";
            }

            if (!StrHostAddress.Equals(Default))
            {
                ary_Email[1, 0] = "HostAddress";
                ary_Email[1, 1] = this.StrHostAddress;
                ary_Email[1, 2] = "string";
            }
            if (!StrPortNumber.Equals(Default))
            {
                ary_Email[2, 0] = "PortNumber";
                ary_Email[2, 1] = this.StrPortNumber;
                ary_Email[2, 2] = "int";
            }
            if (!StrUserName.Equals(Default))
            {
                ary_Email[3, 0] = "UserName";
                ary_Email[3, 1] = this.StrUserName;
                ary_Email[3, 2] = "string";
            }
            if (!StrPassword.Equals(Default))
            {
                ary_Email[4, 0] = "Password";
                ary_Email[4, 1] = this.StrPassword;
                ary_Email[4, 2] = "string";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                ary_Email[5, 0] = "EnteredBy";
                ary_Email[5, 1] = this.StrEnteredBy;
                ary_Email[5, 2] = "string";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                ary_Email[6, 0] = "EnteredOn";
                ary_Email[6, 1] = this.StrEnteredOn;
                ary_Email[6, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                ary_Email[7, 0] = "ClientID";
                ary_Email[7, 1] = this.StrClientID;
                ary_Email[7, 2] = "string";
            }
            if (!StrFooter.Equals(Default))
            {
                ary_Email[8, 0] = "MESSAGEFOOTER";
                ary_Email[8, 1] = this.StrFooter;
                ary_Email[8, 2] = "string";
            }
            if (!StrSystem_IP.Equals(Default))
            {
                ary_Email[9, 0] = "System_IP";
                ary_Email[9, 1] = this.StrSystem_IP;
                ary_Email[9, 2] = "string";
            }
            if (!StrMessageFrom.Equals(Default))
            {
                ary_Email[10, 0] = "MessageFrom";
                ary_Email[10, 1] = this.StrMessageFrom;
                ary_Email[10, 2] = "string";
            }
            return ary_Email;

        }
        private bool Validation()
        {
            return true;
        }
        //private bool chkrecords()
        //{
        //    DataView dv_records = GetAll(1);
        //    if (dv_records.Count > 0)
        //    {
        //        this.StrErrorMessage = "Only One Entry Allowed.";

        //    }
        //}
        #endregion
    }
}
