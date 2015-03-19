using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBLRepeatReasons
    {
        public clsBLRepeatReasons()
        {
            ///Add Constructor Logic here.
        }

        #region Variables
        private const string TableName = "LS_TRepeatReasons";
        private const string Default="~!@";
        private string StrRepeatReasonID = Default;

        private string StrErrorMessage = "";
        private string StrReason = Default;
        private string StrDescription = Default;
        private string StrActive = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;

        #endregion

        #region Properties
        public string RepeatReasonID
        {
            get { return StrRepeatReasonID; }
            set { StrRepeatReasonID = value; }
        }
        public string Reason
        {
            get { return StrReason; }
            set { StrReason = value; }
        }
        public string Description
        {
            get { return StrDescription; }
            set { StrDescription = value; }
        }
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
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
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }
        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #region Methods
        public bool Insert()
        {
            if (this.Reason.Equals(""))
            {
                this.StrErrorMessage = "Please enter Reason (empty is not allowed).";
                return false;
            }

            try
            {
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBGetMax("REPEATREASON_ID", TableName, "4");
                this.StrRepeatReasonID = objTrans.DataTrigger_Get_Max(objdbhims);

                if (!this.StrRepeatReasonID.Equals("True"))
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

        public bool Update()
        {

            //clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
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

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select REPEATREASON_ID,Reason,Description,Active From LS_TRepeatReasons where Active='Y'";
                    break;

   
            }

            return objTrans.DataTrigger_Get_All(objdbhims);
        }	


        private string[,] MakeArray()
        {
            string[,] aryTestGroup = new string[7, 3];

            if (!this.StrRepeatReasonID.Equals(Default))
            {
                aryTestGroup[0, 0] = "REPEATREASON_ID";
                aryTestGroup[0, 1] = this.StrRepeatReasonID;
                aryTestGroup[0, 2] = "string";
            }

            if (!this.StrReason.Equals(Default))
            {
                aryTestGroup[1, 0] = "Reason";
                aryTestGroup[1, 1] = this.StrReason;
                aryTestGroup[1, 2] = "string";
            }

            if (!this.StrActive.Equals(Default))
            {
                aryTestGroup[2, 0] = "Active";
                aryTestGroup[2, 1] = this.StrActive;
                aryTestGroup[2, 2] = "string";
            }


            if (!this.StrDescription.Equals(Default))
            {
                aryTestGroup[3, 0] = "Description";
                aryTestGroup[3, 1] = this.StrDescription;
                aryTestGroup[3, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryTestGroup[4, 0] = "EnteredOn";
                aryTestGroup[4, 1] = this.StrEnteredOn;
                aryTestGroup[4, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryTestGroup[5, 0] = "Enteredby";
                aryTestGroup[5, 1] = this.StrEnteredBy;
                aryTestGroup[5, 2] = "string";
            }

            if (!this.StrClientID.Equals(Default))
            {
                aryTestGroup[6, 0] = "ClientID";
                aryTestGroup[6, 1] = this.StrClientID;
                aryTestGroup[6, 2] = "string";
            }


            return aryTestGroup;
        }

        #endregion

    }
}
