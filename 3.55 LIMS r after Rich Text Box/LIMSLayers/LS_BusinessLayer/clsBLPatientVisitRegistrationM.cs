using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;
using System.IO;
using System.Collections;
using System.Web;

namespace LS_BusinessLayer
{
    public class clsBLPatientVisitRegistrationM
    {
        #region MemberVariables

        private const string Default = "~!@";
        private const string TableName = "whims2.PR_TPATIENTVISITM";
        private string StrErrorMessage = "";

        private string _VisitNo = Default;
        private string _VisitDateTime = Default;
        private string _PRNO = Default;
        private string _Condition = Default;
        private string _Emergency = Default;
        private string _FollowUp = Default;
        private string _TotalAmount = Default;
        private string _EnteredBy = Default;
        private string _EnteredAt = Default;
        private string _MStatus = Default;
        private string _dTransNo = Default;
        private string _dDepartmentID = Default;
        private string _dSubDepartmentID = Default;
        private string _dServiceID = Default;
        private string _dAmount = Default;
        private string _dStatus = Default;
        private string _Expire = Default;


        private string _VisitDateTime2 = Default;

        #endregion

        #region Properties

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }
        public string VisitNo
        {
            get
            {
                return _VisitNo;
            }
            set
            {
                _VisitNo = value;
            }
        }
        public string VisitDateTime
        {
            get
            {
                return _VisitDateTime;
            }
            set
            {
                _VisitDateTime = value;
            }
        }
        public string VisitDateTime2
        {
            get
            {
                return _VisitDateTime2;
            }
            set
            {
                _VisitDateTime2 = value;
            }
        }

        public string PRNO
        {
            get
            {
                return _PRNO;
            }
            set
            {
                _PRNO = value;
            }
        }
        public string Condition
        {
            get
            {
                return _Condition;
            }
            set
            {
                _Condition = value;
            }
        }
        public string FollowUp
        {
            get
            {
                return _FollowUp;
            }
            set
            {
                _FollowUp = value;
            }
        }
        public string Emergency
        {
            get
            {
                return _Emergency;
            }
            set
            {
                _Emergency = value;
            }
        }
        public string TotalAmount
        {
            get
            {
                return _TotalAmount;
            }
            set
            {
                _TotalAmount = value;
            }
        }
        public string EnteredBy
        {
            get
            {
                return _EnteredBy;
            }
            set
            {
                _EnteredBy = value;
            }
        }
        public string EnteredAt
        {
            get
            {
                return _EnteredAt;
            }
            set
            {
                _EnteredAt = value;
            }
        }
        public string MStatus
        {
            get
            {
                return _MStatus;
            }
            set
            {
                _MStatus = value;
            }
        }
              
                
        public string DepartmentID
        {
            get
            {
                return _dDepartmentID;
            }
            set
            {
                _dDepartmentID = value;
            }
        }
        public string SubDepartmentID
        {
            get
            {
                return _dSubDepartmentID;
            }
            set
            {
                _dSubDepartmentID = value;
            }
        }
        public string ServiceID
        {
            get
            {
                return _dServiceID;
            }
            set
            {
                _dServiceID = value;
            }
        }
        public string Amount
        {
            get
            {
                return _dAmount;
            }
            set
            {
                _dAmount = value;
            }
        }
        public string Status
        {
            get
            {
                return _dStatus;
            }
            set
            {
                _dStatus = value;
            }
        }
        

        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region "Methods"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * from " + TableName + " order by visitno";
                    break;

/*                case 2:
                    objdbhims.Query = "Select * from " + TableName + " Where Upper(Name) like '%'||'" + _FName.ToUpper() + "'||'%'";
                    break;*/

                case 3:
                    objdbhims.Query = "Select whims2.fgetnewvisitno() as visitno from HR_Dummy01";
                    break;
                case 4:
                    objdbhims.Query = "Select * from  whims2.PR_VPATIENTVISITD  Where to_date(to_char(VISITDATETIME,'dd/MM/yyyy'),'dd/MM/yyyy')  between to_Date( '" + VisitDateTime + "' ,'DD/MM/YYYY') and to_Date( '" + VisitDateTime2 + "' ,'DD/MM/YYYY')  ";
                    if (_dDepartmentID != "" && _dDepartmentID != Default)
                    objdbhims.Query += " and DepartmentID = '" + _dDepartmentID + "' ";
                    if (_dSubDepartmentID != "" && _dSubDepartmentID != Default)
                    objdbhims.Query += " and  SubDepartmentID = '" + _dSubDepartmentID + "' ";
                    break;
               // for visit registration report(070830)
                case 5:
                     objdbhims.Query = "Select * from  whims2.PR_VVISITD  Where to_date(to_char(VISITDATETIME,'dd/MM/yyyy'),'dd/MM/yyyy')  between to_Date( '" + VisitDateTime + "' ,'DD/MM/YYYY') and to_Date( '" + VisitDateTime2 + "' ,'DD/MM/YYYY')  ";
                    if (_dDepartmentID != "" && _dDepartmentID != Default)
                        objdbhims.Query += " and DepartmentID = '" + _dDepartmentID + "' ";
                    if (_dSubDepartmentID != "" && _dSubDepartmentID != Default)
                        objdbhims.Query += " and  SubDepartmentID = '" + _dSubDepartmentID + "' ";
                    break;
                
            }

            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert(string[,] arrayUpdate)
        {
  
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = "Select whims2.fgetnewvisitno() as MaxID from whims2.HR_Dummy01";
                    this._VisitNo = objTrans.DataTrigger_Get_Max(objdbhims);
                                        
                    if (!this._VisitNo.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        //objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                        else
                        {
                            //Update Test Result Detail
                            for (int i = 0; i <= arrayUpdate.GetUpperBound(0); i++)
                            {
                                _dDepartmentID = arrayUpdate[i, 0]; //Department
                                _dSubDepartmentID = arrayUpdate[i, 1]; //SubDepartment
                                _dServiceID = arrayUpdate[i, 2]; //ServiceID;
                                _dAmount = arrayUpdate[i, 3]; //Amount;
                                _dStatus = arrayUpdate[i, 4]; // Status 

                                if (this._dAmount != this._TotalAmount)
                                {
                                    this.StrErrorMessage = "Please verify consultant charges";
                                    objTrans.End_Transaction();
                                    return false;
                                }            
                                objdbhims.Query = objQB.QBGetMax("TRANSNO", "whims2.PR_TPATIENTVISITD", "8");
                                this._dTransNo = objTrans.DataTrigger_Get_Max(objdbhims);
                                                               
                                if (!this._dTransNo.Equals("True"))
                                {
                                    objdbhims.Query = objQB.QBInsert(MakeArrayD(), "whims2.PR_TPATIENTVISITD");
                                    this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                                    if (this.StrErrorMessage.Equals("True"))
                                    {
                                        this.StrErrorMessage = objTrans.OperationError;
                                        return false;
                                    }
                                }
                                else
                                {
                                    this.StrErrorMessage = objTrans.OperationError;
                                    objTrans.End_Transaction();
                                    return false;
                                }
                          
                            }
                        
                                
                            objTrans.End_Transaction();
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
            return false;            
        }

        private string[,] MakeArray()
        {
            string[,] aryTest = new string[10, 3];

            if (!this._VisitNo.Equals(Default))
            {
                aryTest[0, 0] = "VISITNO";
                aryTest[0, 1] = this._VisitNo;
                aryTest[0, 2] = "string";
            }

            if (!this._PRNO.Equals(Default))
            {
                aryTest[1, 0] = "PRNO";
                aryTest[1, 1] = this._PRNO;
                aryTest[1, 2] = "string";
            }

            if (!this._VisitDateTime.Equals(Default))
            {
                aryTest[2, 0] = "VisitDateTime";
                aryTest[2, 1] = this._VisitDateTime;
                aryTest[2, 2] = "date";
            }

            if (!this._Condition.Equals(Default))
            {
                aryTest[3, 0] = "PATCONDITION";
                aryTest[3, 1] = this._Condition;
                aryTest[3, 2] = "string";
            }

            if (!this._FollowUp.Equals(Default))
            {
                aryTest[4, 0] = "FOLLOWUP";
                aryTest[4, 1] = this._FollowUp;
                aryTest[4, 2] = "string";
            }

            if (!this._Emergency.Equals(Default))
            {
                aryTest[5, 0] = "EMERGENCYPAT";
                aryTest[5, 1] = this._Emergency;
                aryTest[5, 2] = "string";
            }

            if (!this._TotalAmount.Equals(Default))
            {
                aryTest[6, 0] = "TOTALAMT";
                aryTest[6, 1] = this._TotalAmount;
                aryTest[6, 2] = "int";
            }

            if (!this._EnteredBy.Equals(Default))
            {
                aryTest[7, 0] = "EnteredBy";
                aryTest[7, 1] = this._EnteredBy;
                aryTest[7, 2] = "string";
            }

            if (!this._EnteredAt.Equals(Default))
            {
                aryTest[8, 0] = "EnteredDate";
                aryTest[8, 1] = this._EnteredAt;
                aryTest[8, 2] = "date";
            }
            if (!this._EnteredAt.Equals(Default))
            {
                aryTest[9, 0] = "MStatus";
                aryTest[9, 1] = this._MStatus;
                aryTest[9, 2] = "string";
            }

            return aryTest;
        }

        private string[,] MakeArrayD()
        {
            string[,] aryPVD = new string[10, 3];

            if (!this._dTransNo.Equals(Default))
            {
                aryPVD[0, 0] = "TRANSNO";
                aryPVD[0, 1] = this._dTransNo;
                aryPVD[0, 2] = "string";
            }

            if (!this._PRNO.Equals(Default))
            {
                aryPVD[1, 0] = "PRNO";
                aryPVD[1, 1] = this._PRNO;
                aryPVD[1, 2] = "string";
            }

            if (!this._dDepartmentID.Equals(Default))
            {
                aryPVD[2, 0] = "DEPARTMENTID";
                aryPVD[2, 1] = this._dDepartmentID;
                aryPVD[2, 2] = "string";
            }

            if (!this._dSubDepartmentID.Equals(Default))
            {
                aryPVD[3, 0] = "SUBDEPARTMENTID";
                aryPVD[3, 1] = this._dSubDepartmentID;
                aryPVD[3, 2] = "string";
            }

            if (!this._dServiceID.Equals(Default))
            {
                aryPVD[4, 0] = "SERVICEID";
                aryPVD[4, 1] = this._dServiceID;
                aryPVD[4, 2] = "string";
            }

            if (!this._dAmount.Equals(Default))
            {
                aryPVD[5, 0] = "CHARGES";
                aryPVD[5, 1] = this._dAmount;
                aryPVD[5, 2] = "int";
            }

            if (!this._dStatus.Equals(Default))
            {
                aryPVD[6, 0] = "Status";
                aryPVD[6, 1] = this._dStatus;
                aryPVD[6, 2] = "string";
            }

            if (!this._EnteredBy.Equals(Default))
            {
                aryPVD[7, 0] = "EnteredBy";
                aryPVD[7, 1] = this._EnteredBy;
                aryPVD[7, 2] = "string";
            }

            if (!this._EnteredAt.Equals(Default))
            {
                aryPVD[8, 0] = "EnteredAt";
                aryPVD[8, 1] = this._EnteredAt;
                aryPVD[8, 2] = "date";
            }

            if (!this._VisitNo.Equals(Default))
            {
                aryPVD[9, 0] = "VisitNo";
                aryPVD[9, 1] = this._VisitNo;
                aryPVD[9, 2] = "string";
            }

            return aryPVD;
        }

        #endregion

        #region "Validation Functions"

        public bool ValidationM()
        {   
            Validation objValid = new Validation();

            if (this._PRNO.Equals("") || this._PRNO.Equals(Default))
            {
                this.StrErrorMessage = "Please enter Patient Registration No. (empty is not allowed)";
                return false;
            }

            if (this._Condition.Equals("") || this._Condition.Equals(Default))
            {
                this.StrErrorMessage = "Please select Patient Condition. (empty is not allowed)";
                return false;
            }

            if (this._TotalAmount.Equals("") || this._TotalAmount.Equals(Default))
            {
                this.StrErrorMessage = "Please select service. (empty is not allowed)";
                return false;
            }
            //if (!this._Expire.Equals(Default))
            //{
            //    this.StrErrorMessage = "Patient has been expire. So visit registration can't be made";
            //    return false;
            //}
           
            
            return true;
        }

        public bool ValidationD()
        {
            Validation objValid = new Validation();

            if (this._dDepartmentID.Equals("") || this._dDepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Department not found in service detail! Please try again";
                return false;
            }

            if (this._dSubDepartmentID.Equals("") || this._dSubDepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Sub-Department not found in service detail! Please try again";
                return false;
            }

            if (this._dServiceID.Equals("") || this._dServiceID.Equals(Default))
            {
                this.StrErrorMessage = "Service not found in service detail! Please try again";
                return false;
            }

            if (this._dAmount.Equals("") || this._dAmount.Equals(Default))
            {
                this.StrErrorMessage = "Service not found in service detail! Please try again";
                return false;
            }
           
            return true;
        }
        public bool ValidationD2()
        {
            Validation objValid = new Validation();

            if (this._dDepartmentID.Equals("") || this._dDepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Department not found in service detail! Please try again";
                return false;
            }

            if (this._dSubDepartmentID.Equals("") || this._dSubDepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Sub-Department not found in service detail! Please try again";
                return false;
            }

            //if (this._dServiceID.Equals("") || this._dServiceID.Equals(Default))
            //{
            //    this.StrErrorMessage = "Service not found in service detail! Please try again";
            //    return false;
            //}

            if (this._dAmount.Equals("") || this._dAmount.Equals(Default))
            {
                this.StrErrorMessage = "Service not found in service detail! Please try again";
                return false;
            }
          
           
            return true;
        }
        #endregion

    }
}
