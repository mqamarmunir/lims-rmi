using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBlTestResultComments
    {
        public clsBlTestResultComments()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string TableName = "LS_TTestResultComments";
        private const string Default = "~!@";
        private string StrTestResultCommentID = Default;

        
        private string StrLabId = Default;

   
        private string StrTestID = Default;
        private string StrComment = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn=Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrRSerialNo = Default;

       
        private string StrErrorMessage = "";

       


        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string RSerialNo
        {
            get { return StrRSerialNo; }
            set { StrRSerialNo = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        public string TestResultCommentID
        {
            get { return StrTestResultCommentID; }
            set { StrTestResultCommentID = value; }
        }
        public string LabId
        {
            get { return StrLabId; }
            set { StrLabId = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string Comment
        {
            get { return StrComment; }
            set { StrComment = value; }
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
        public string System_Ip
        {
            get { return StrSystem_Ip; }
            set { StrSystem_Ip = value; }
        }

       
        #endregion


        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select trc.TestResultCommentID,trc.Comments, tp.Salutation||' '|| tp.fname||' '|| tp.mname|| ' '||tp.lname as Name From " + TableName +" trc,whims2.HR_TPersonnel tp where tp.PersonID=trc.EnteredBy and  labID='"+StrLabId+"' and TestID='"+StrTestID+"'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = "Select NVL(max(TestResultCommentID),0)+1  as MaxID From "+TableName;
                    //objdbhims.Query = objQB.QBGetMax("REPEATREASON_ID", TableName, "4");
                    this.StrTestResultCommentID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this.StrTestResultCommentID.Equals("True"))
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

        public bool delete()
        {
            objdbhims.Query = @"Delete From " + TableName + " where TestresultcommentId=" + StrTestResultCommentID;
            objTrans.Start_Transaction();
            StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
            if (StrErrorMessage.Equals("True"))
            {
                objTrans.End_Transaction();
                StrErrorMessage = objTrans.OperationError;
                return false;
            }
            else
            {
                objTrans.End_Transaction();
                return true;
            }
            
        }

        private string[,] MakeArray()
        {
            string[,] aryComments = new string[9, 3];

            if (!this.StrTestResultCommentID.Equals(Default))
            {
                aryComments[0, 0] = "TestResultCommentID";
                aryComments[0, 1] = this.StrTestResultCommentID;
                aryComments[0, 2] = "int";
            }

            if (!this.StrLabId.Equals(Default))
            {
                aryComments[1, 0] = "LabId";
                aryComments[1, 1] = this.StrLabId;
                aryComments[1, 2] = "string";
            }

            if (!this.StrTestID.Equals(Default))
            {
                aryComments[2, 0] = "TestID";
                aryComments[2, 1] = this.StrTestID;
                aryComments[2, 2] = "string";
            }


            if (!this.StrComment.Equals(Default))
            {
                aryComments[3, 0] = "Comments";
                aryComments[3, 1] = this.StrComment;
                aryComments[3, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryComments[4, 0] = "EnteredOn";
                aryComments[4, 1] = this.StrEnteredOn;
                aryComments[4, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryComments[5, 0] = "Enteredby";
                aryComments[5, 1] = this.StrEnteredBy;
                aryComments[5, 2] = "string";
            }

            if (!this.StrClientID.Equals(Default))
            {
                aryComments[6, 0] = "ClientID";
                aryComments[6, 1] = this.StrClientID;
                aryComments[6, 2] = "string";
            }
            if (!this.StrSystem_Ip.Equals(Default))
            {
                aryComments[7, 0] = "System_Ip";
                aryComments[7, 1] = this.StrSystem_Ip;
                aryComments[7, 2] = "string";
            }
            if (!this.StrRSerialNo.Equals(Default))
            {
                aryComments[8, 0] = "RSerialNo";
                aryComments[8, 1] = this.StrRSerialNo;
                aryComments[8, 2] = "int";
            }


            return aryComments;
        }

        private bool Validation()
        {
            return true;
        }
        #endregion


    }
}
