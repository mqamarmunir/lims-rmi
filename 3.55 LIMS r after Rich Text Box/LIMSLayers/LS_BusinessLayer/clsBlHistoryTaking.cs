using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;


namespace LS_BusinessLayer
{
    public class clsBlHistoryTaking
    {
        public clsBlHistoryTaking()
        {
            /// Add Constructor Logic here...
        }

        #region Variables
        private const string TableName1="Ls_THistoryTaking_A";
        private const string TableName2 = "Ls_THistoryTaking_B";
        private const string Default = "~!@";
        private string _PRNo = Default;

       
        private string _LabID = Default;
        private string _TestID = Default;
        #region Table1 Variables
        private string _HistoryTakingAID = Default;
  
        private string _PresentHistory = Default;
        private string _Pasthistory = Default;
        private string _TransfusionHistory = Default;
        private string _FamilyHistory = Default;
        private string _C_PresentHistory = Default;
        private string _C_PastHistory= Default;
        private string _C_FamilyHistory = Default;
        private string _C_TransfusionHistory = Default;
        private string _TreatmentTaken = Default;
        private string _Temperature = Default;
        private string _BloodPressure = Default;
        private string _PulseRate = Default;
        #endregion
        #region Table2 Variables
        private string _HistoryTakingBID = Default;
        private string _FieldName = Default;
        private string _Description = Default;
        private string _Active = Default;

      
        #endregion
        


        private string _EnteredBy = Default;

        private string _EnteredOn = Default;
        private string _ClientID = Default;
        private string _System_Ip = Default;
        private string StrErrorMessage = Default;

        

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #endregion

        #region Properties
        public string PRNo
        {
            get { return _PRNo; }
            set { _PRNo = value; }
        }
        public string LabID
        {
            get { return _LabID; }
            set { _LabID = value; }
        }
        public string TestID
        {
            get { return _TestID; }
            set { _TestID = value; }
        }

        #region Table1 Properties
        public string HistoryTakingAID
        {
            get { return _HistoryTakingAID; }
            set { _HistoryTakingAID = value; }
        }
        public string PresentHistory
        {
            get { return _PresentHistory; }
            set { _PresentHistory = value; }
        }
        public string Pasthistory
        {
            get { return _Pasthistory; }
            set { _Pasthistory = value; }
        }
        public string TransfusionHistory
        {
            get { return _TransfusionHistory; }
            set { _TransfusionHistory = value; }
        }
        public string FamilyHistory
        {
            get { return _FamilyHistory; }
            set { _FamilyHistory = value; }
        }


        public string C_PresentHistory
        {
            get { return _C_PresentHistory; }
            set { _C_PresentHistory = value; }
        }
        public string C_Pasthistory
        {
            get { return _C_PastHistory; }
            set { _C_PastHistory = value; }
        }
        public string C_TransfusionHistory
        {
            get { return _C_TransfusionHistory; }
            set { _C_TransfusionHistory = value; }
        }
        public string C_FamilyHistory
        {
            get { return _C_FamilyHistory; }
            set { _C_FamilyHistory = value; }
        }
        public string TreatmentTaken
        {
            get { return _TreatmentTaken; }
            set { _TreatmentTaken = value; }
        }
        public string Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }
        public string BloodPressure
        {
            get { return _BloodPressure; }
            set { _BloodPressure = value; }
        }
        public string PulseRate
        {
            get { return _PulseRate; }
            set { _PulseRate = value; }
        }
        #endregion

        #region Table2 Properties
        public string HistoryTakingBID
        {
            get { return _HistoryTakingBID; }
            set { _HistoryTakingBID = value; }
        }
        public string FieldName
        {
            get { return _FieldName; }
            set { _FieldName = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        public string Active
        {
            get { return _Active; }
            set { _Active = value; }
        }
        #endregion

        public string EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }

        public string EnteredOn
        {
            get { return _EnteredOn; }
            set { _EnteredOn = value; }
        }
        public string ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }
        public string System_Ip
        {
            get { return _System_Ip; }
            set { _System_Ip = value; }
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
                case 1:// Fill Patient Information
                    objdbhims.Query = @"Select * From LS_Vpatient where LabID='" + _LabID + "' and trim(PRNo)='" + _PRNo + "'";
                    break;
                case 2:
                    objdbhims.Query = @"Select * From " + TableName1 + " where trim(labid)='" + _LabID + "' and testid='" + _TestID + "' and trim(PRNo)='" + _PRNo + "'";
                    break;
                case 3:
                    objdbhims.Query = @"Select * From " + TableName2 + " where Active!='N' and trim(labid)='" + _LabID + "' and testid='" + _TestID + "' and trim(PRNo)='" + _PRNo + "'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool DeletePrevious()
        {
            objdbhims.Query = @"Update " + TableName2 + " set Active='N' where labID='" + _LabID + "' and TestID='" + _TestID + "'";
            objTrans.Start_Transaction();

            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            objTrans.End_Transaction();

            if (StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            return true;
        }
        public bool Insert1()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    //objdbhims.Query = objQB.QBGetMax("CommentID", TableName,"4");
                    objdbhims.Query = @"Select NVL(max(HistoryTakingAID),0)+1 as MaxID From "+TableName1;
                    this._HistoryTakingAID = objTrans.DataTrigger_Get_Max(objdbhims);


                    if (!this._HistoryTakingAID.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray1(), TableName1);
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
        public bool Update1()
        {
            if (Validation())
            {

                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray1(), TableName1);
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
        public bool Insert2()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    //objdbhims.Query = objQB.QBGetMax("CommentID", TableName,"4");
                    objdbhims.Query = @"Select NVL(max(HistoryTakingBID),0)+1 as MaxID From " + TableName2;
                    this._HistoryTakingBID = objTrans.DataTrigger_Get_Max(objdbhims);


                    if (!this._HistoryTakingBID.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray2(), TableName2);
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
        private string[,] MakeArray1()
        {
            string[,] aryLIMS = new string[20, 3];

            if (!this._HistoryTakingAID.Equals(Default))
            {
                aryLIMS[0, 0] = "HistoryTakingAID";
                aryLIMS[0, 1] = this._HistoryTakingAID;
                aryLIMS[0, 2] = "int";
            }

            if (!this._PRNo.Equals(Default))
            {
                aryLIMS[1, 0] = "PRNo";
                aryLIMS[1, 1] = this._PRNo;
                aryLIMS[1, 2] = "string";
            }
            if (!this._LabID.Equals(Default))
            {
                aryLIMS[2, 0] = "LabID";
                aryLIMS[2, 1] = this._LabID;
                aryLIMS[2, 2] = "string";
            }
            if (!this._TestID.Equals(Default))
            {
                aryLIMS[3, 0] = "TestID";
                aryLIMS[3, 1] = this._TestID;
                aryLIMS[3, 2] = "string";
            }
            if (!this._PresentHistory.Equals(Default))
            {
                aryLIMS[4, 0] = "PresentHistory";
                aryLIMS[4, 1] = this._PresentHistory;
                aryLIMS[4, 2] = "string";
            }
            if (!this._Pasthistory.Equals(Default))
            {
                aryLIMS[5, 0] = "Pasthistory";
                aryLIMS[5, 1] = this._Pasthistory;
                aryLIMS[5, 2] = "string";
            }

            if (!this._TransfusionHistory.Equals(Default))
            {
                aryLIMS[6, 0] = "TransfusionHistory";
                aryLIMS[6, 1] = this._TransfusionHistory;
                aryLIMS[6, 2] = "string";
            }

            if (!this._FamilyHistory.Equals(Default))
            {
                aryLIMS[7, 0] = "FamilyHistory";
                aryLIMS[7, 1] = this._FamilyHistory;
                aryLIMS[7, 2] = "string";
            }
            
            
            if (!this._C_PresentHistory.Equals(Default))
            {
                aryLIMS[8, 0] = "C_PresentHistory";
                aryLIMS[8, 1] = this._C_PresentHistory;
                aryLIMS[8, 2] = "string";
            }
            if (!this._C_PastHistory.Equals(Default))
            {
                aryLIMS[9, 0] = "C_Pasthistory";
                aryLIMS[9, 1] = this._C_PastHistory;
                aryLIMS[9, 2] = "string";
            }

            if (!this._C_TransfusionHistory.Equals(Default))
            {
                aryLIMS[10, 0] = "C_TransfusionHistory";
                aryLIMS[10, 1] = this._C_TransfusionHistory;
                aryLIMS[10, 2] = "string";
            }
            

            if (!this._TreatmentTaken.Equals(Default))
            {
                aryLIMS[11, 0] = "TreatmentTaken";
                aryLIMS[11, 1] = this._TreatmentTaken;
                aryLIMS[11, 2] = "string";
            }
            if (!this._Temperature.Equals(Default))
            {
                aryLIMS[12, 0] = "Temperature";
                aryLIMS[12, 1] = this._Temperature;
                aryLIMS[12, 2] = "string";
            }
            if (!this._PulseRate.Equals(Default))
            {
                aryLIMS[13, 0] = "PulseRate";
                aryLIMS[13, 1] = this._PulseRate;
                aryLIMS[13, 2] = "string";
            }
            if (!this._BloodPressure.Equals(Default))
            {
                aryLIMS[14, 0] = "BloodPressure";
                aryLIMS[14, 1] = this._BloodPressure;
                aryLIMS[14, 2] = "string";
            }
            if (!this._EnteredBy.Equals(Default))
            {
                aryLIMS[15, 0] = "EnteredBy";
                aryLIMS[15, 1] = this._EnteredBy;
                aryLIMS[15, 2] = "string";
            }
            if (!this._EnteredOn.Equals(Default))
            {
                aryLIMS[16, 0] = "EnteredOn";
                aryLIMS[16, 1] = this._EnteredOn;
                aryLIMS[16, 2] = "date";
            }
            if (!this._ClientID.Equals(Default))
            {
                aryLIMS[17, 0] = "ClientID";
                aryLIMS[17, 1] = this._ClientID;
                aryLIMS[17, 2] = "string";
            }
            if (!this._System_Ip.Equals(Default))
            {
                aryLIMS[18, 0] = "System_Ip";
                aryLIMS[18, 1] = this._System_Ip;
                aryLIMS[18, 2] = "string";
            }
            if (!this._C_FamilyHistory.Equals(Default))
            {
                aryLIMS[19, 0] = "C_FamilyHistory";
                aryLIMS[19, 1] = this._C_FamilyHistory;
                aryLIMS[19, 2] = "string";
            }
            return aryLIMS;
        }
        private string[,] MakeArray2()
        {
            string[,] aryLIMS = new string[11, 3];

            if (!this._HistoryTakingBID.Equals(Default))
            {
                aryLIMS[0, 0] = "HistoryTakingBID";
                aryLIMS[0, 1] = this._HistoryTakingBID;
                aryLIMS[0, 2] = "int";
            }

            if (!this._PRNo.Equals(Default))
            {
                aryLIMS[1, 0] = "PRNo";
                aryLIMS[1, 1] = this._PRNo;
                aryLIMS[1, 2] = "string";
            }
            if (!this._LabID.Equals(Default))
            {
                aryLIMS[2, 0] = "LabID";
                aryLIMS[2, 1] = this._LabID;
                aryLIMS[2, 2] = "string";
            }
            if (!this._TestID.Equals(Default))
            {
                aryLIMS[3, 0] = "TestID";
                aryLIMS[3, 1] = this._TestID;
                aryLIMS[3, 2] = "string";
            }
            if (!this._FieldName.Equals(Default))
            {
                aryLIMS[4, 0] = "FieldName";
                aryLIMS[4, 1] = this._FieldName;
                aryLIMS[4, 2] = "string";
            }
            if (!this._Description.Equals(Default))
            {
                aryLIMS[5, 0] = "Description";
                aryLIMS[5, 1] = this._Description;
                aryLIMS[5, 2] = "string";
            }

           
            if (!this._EnteredBy.Equals(Default))
            {
                aryLIMS[6, 0] = "EnteredBy";
                aryLIMS[6, 1] = this._EnteredBy;
                aryLIMS[6, 2] = "string";
            }
            if (!this._EnteredOn.Equals(Default))
            {
                aryLIMS[7, 0] = "EnteredOn";
                aryLIMS[7, 1] = this._EnteredOn;
                aryLIMS[7, 2] = "date";
            }
            if (!this._ClientID.Equals(Default))
            {
                aryLIMS[8, 0] = "ClientID";
                aryLIMS[8, 1] = this._ClientID;
                aryLIMS[8, 2] = "string";
            }
            if (!this._System_Ip.Equals(Default))
            {
                aryLIMS[9, 0] = "System_Ip";
                aryLIMS[9, 1] = this._System_Ip;
                aryLIMS[9, 2] = "string";
            }
            if (!this._Active.Equals(Default))
            {
                aryLIMS[10, 0] = "Active";
                aryLIMS[10, 1] = this._Active;
                aryLIMS[10, 2] = "string";
            }
           
            return aryLIMS;
        }
        #endregion

        #region Validation Functions
        private bool Validation()
        {
            return true;
        }
        #endregion

    }
}
