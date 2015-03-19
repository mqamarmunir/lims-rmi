using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLDiagnose
    {
        public clsBLDiagnose()
        {

        }

        #region Variables
        private const string Default="~!@";
        private const string TableName = "LS_TDiagnosis";
        private string StrDiagnosisID = Default;
        private string StrDiseaseID = Default;
        private string StrICDCode = Default;
        private string StrDiseaseName = Default;
        private string StrLabID = Default;
        private string StrTestID = Default;
        private string StrPRNumber = Default;
        private string StrPrint = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrErrorMessage = Default;

        clsoperation objTrans=new clsoperation();
        clsdbhims objdbhims=new clsdbhims();
        #endregion

        #region Properties

        public string DiagnosisID
        {
            get { return StrDiagnosisID; }
            set { StrDiagnosisID = value; }
        }
        
        public string DiseaseID
        {
            get { return StrDiseaseID; }
            set { StrDiseaseID = value; }
        }
        public string ICDCode
        {
            get { return StrICDCode; }
            set { StrICDCode = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
 
        }
        public string DiseaseName
        {
            get { return StrDiseaseName; }
            set { StrDiseaseName = value; }
        }
        public string LabID
        {
            get { return StrLabID; }
            set { StrLabID = value; }
        }
        public string PRNumber
        {
            get { return StrPRNumber; }
            set { StrPRNumber = value; }
        }
        public string Print
        {
            get { return StrPrint; }
            set { StrPrint = value; }
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
        public string Errormessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            clsoperation objTrans2 = new clsoperation();
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From LS_TDiagnosis where LabID='" +StrLabID+"' And TestID='" +StrTestID+"'";
                    break;
            }
           return objTrans2.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("DIAGNOSISID", TableName, "6");
                    this.StrDiagnosisID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (!this.StrDiagnosisID.Equals("True"))
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
            clsoperation objTrans_del = new clsoperation();
            objdbhims.Query = "Delete From Ls_TDiagnosis where DIAGNOSISID='" + StrDiagnosisID + "'";
            objTrans_del.Start_Transaction();
            string Errmsg=objTrans_del.DataTrigger_Delete(objdbhims);
            objTrans_del.End_Transaction();
            if (Errmsg.Equals("True"))
            {
                StrErrorMessage = objTrans_del.OperationError;
                return false;
            }
            return true;
        }

        private string[,] MakeArray()
        {
            string[,] ary_GroupD = new string[11, 3];

            if (!StrDiagnosisID.Equals(Default))
            {
                ary_GroupD[0, 0] = "DIAGNOSISID";
                ary_GroupD[0, 1] = this.StrDiagnosisID;
                ary_GroupD[0, 2] = "string";
            }

            if (!StrDiseaseID.Equals(Default))
            {
                ary_GroupD[1, 0] = "DiseaseID";
                ary_GroupD[1, 1] = this.StrDiseaseID;
                ary_GroupD[1, 2] = "int";
            }
            if (!StrTestID.Equals(Default))
            {
                ary_GroupD[2, 0] = "TestID";
                ary_GroupD[2, 1] = this.StrTestID;
                ary_GroupD[2, 2] = "string";
            }
            if (!StrLabID.Equals(Default))
            {
                ary_GroupD[3, 0] = "LabID";
                ary_GroupD[3, 1] = this.StrLabID;
                ary_GroupD[3, 2] = "string";
            }
            if (!StrDiseaseName.Equals(Default))
            {
                ary_GroupD[4, 0] = "Disease_Name";
                ary_GroupD[4, 1] = this.StrDiseaseName;
                ary_GroupD[4, 2] = "string";
            }
            if (!StrPrint.Equals(Default))
            {
                ary_GroupD[5, 0] = "Print";
                ary_GroupD[5, 1] = this.StrPrint;
                ary_GroupD[5, 2] = "string";
            }

            if (!StrEnteredBy.Equals(Default))
            {
                ary_GroupD[6, 0] = "EnteredBy";
                ary_GroupD[6, 1] = this.StrEnteredBy;
                ary_GroupD[6, 2] = "string";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                ary_GroupD[7, 0] = "EnteredOn";
                ary_GroupD[7, 1] = this.StrEnteredOn;
                ary_GroupD[7, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                ary_GroupD[8, 0] = "ClientID";
                ary_GroupD[8, 1] = this.StrClientID;
                ary_GroupD[8, 2] = "string";
            }
            if (!StrICDCode.Equals(Default))
            {
                ary_GroupD[9, 0] = "ICD_CODE";
                ary_GroupD[9, 1] = this.StrICDCode;
                ary_GroupD[9, 2] = "string";
            }
            if (!StrPRNumber.Equals(Default))
            {
                ary_GroupD[10, 0] = "PRNumber";
                ary_GroupD[10, 1] = this.StrPRNumber;
                ary_GroupD[10, 2] = "string";
            }
            return ary_GroupD;
 
        }

        private bool Validation()
        {
            return true;
        }

        #endregion


    }
}
