using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlSpecimenLife
    {
        public clsBlSpecimenLife()
        {
            ///Add Constructor Logic here...
        }

        #region Variables
        private const string TableName = "LS_TSpecimenLife";
        private const string Default = "~!@";
        private string StrLifeID = Default;

      
        private string StrTestID = Default;
        private string StrSpecimen = Default;
        private string StrLife = Default;
        private string StrEnteredBy= Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrErrorMessage = "";

        #endregion
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Properties
        public string LifeID
        {
            get { return StrLifeID; }
            set { StrLifeID = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string Specimen
        {
            get { return StrSpecimen; }
            set { StrSpecimen = value; }
        }
        public string Life
        {
            get { return StrLife; }
            set { StrLife = value; }
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
                    objdbhims.Query = "Select tt.SectionID,sl.LifeId,sl.testID,sl.Specimen,sl.Life,tt.Test From LS_TSpecimenLife sl inner Join Ls_TTest tt on tt.TestID=sl.TestID where tt.Active<>'D'";
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool update()
        {
            if (Validation())
            {

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
            else
            {
                return false;
            }
        }

        public bool insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = "Select NVl(max(LifeID),0)+1 as MAXID from "+TableName;
                    this.StrLifeID = objTrans.DataTrigger_Get_Max(objdbhims);



                    if (!this.StrLifeID.Equals("True"))
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
        private bool Validation()
        {
            return true;
        }

        private string[,] MakeArray()
        {
            string[,] aryLIMS = new string[8, 3];

            if (!this.StrLifeID.Equals(Default))
            {
                aryLIMS[0, 0] = "LifeID";
                aryLIMS[0, 1] = this.StrLifeID;
                aryLIMS[0, 2] = "int";
            }

            if (!this.StrTestID.Equals(Default))
            {
                aryLIMS[1, 0] = "TestID";
                aryLIMS[1, 1] = this.StrTestID;
                aryLIMS[1, 2] = "string";
            }



            if (!this.StrSpecimen.Equals(Default))
            {
                aryLIMS[2, 0] = "Specimen";
                aryLIMS[2, 1] = this.StrSpecimen;
                aryLIMS[2, 2] = "string";
            }

            if (!this.StrLife.Equals(Default))
            {
                aryLIMS[3, 0] = "Life";
                aryLIMS[3, 1] = this.StrLife;
                aryLIMS[3, 2] = "int";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryLIMS[4, 0] = "enteredon";
                aryLIMS[4, 1] = this.StrEnteredOn;
                aryLIMS[4, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryLIMS[5, 0] = "enteredby";
                aryLIMS[5, 1] = this.StrEnteredBy;
                aryLIMS[5, 2] = "string";
            }
            if (!this.StrClientID.Equals(Default))
            {
                aryLIMS[6, 0] = "ClientID";
                aryLIMS[6, 1] = this.StrClientID;
                aryLIMS[6, 2] = "string";
            }
            if (!this.StrSystem_Ip.Equals(Default))
            {
                aryLIMS[7, 0] = "SYSTEM_IP";
                aryLIMS[7, 1] = this.StrSystem_Ip;
                aryLIMS[7, 2] = "string";
            }


            return aryLIMS;
        }
        #endregion
    }
}
