using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLPatientVisitRegistrationD
    {
        #region MemberVariables

        private const string Default = "~!@";
        private const string TableName = "PR_TPATIENTVISITD";
        private string StrErrorMessage = "";

        private string _TransNo = Default;
        private string _PRNO = Default;
        private string _VisitNo = Default;
        private string _DepartmentID = Default;
        private string _SubDepartmentID = Default;
        private string _ServiceID = Default;
        private string _Amount = Default;
        private string _Status = Default;
        private string _EnteredBy = Default;
        private string _EnteredAt = Default;

        #endregion

        #region Properties

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
        }

        public string TransNo
        {
            get
            {
                return _TransNo;
            }
            set
            {
                _TransNo = value;
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

        public string Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return _DepartmentID;
            }
            set
            {
                _DepartmentID = value;
            }
        }

        public string SubDepartmentID
        {
            get
            {
                return _SubDepartmentID;
            }
            set
            {
                _SubDepartmentID = value;
            }
        }

        public string ServiceID
        {
            get
            {
                return _ServiceID;
            }
            set
            {
                _ServiceID = value;
            }
        }

        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
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

        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region "Methods"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * from " + TableName + " order by transno";
                    break;

                /*                case 2:
                                    objdbhims.Query = "Select * from " + TableName + " Where Upper(Name) like '%'||'" + _FName.ToUpper() + "'||'%'";
                                    break;*/

                case 3:
                    objdbhims.Query = "select max(t.visitno) as visitno from pr_tpatientvisitm t";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


        public bool Insert()
        {
            if (ValidationD())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    //objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("TRANSNO", TableName, "8");
                    this._TransNo = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this._TransNo.Equals("True"))
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArrayD(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        //objTrans.End_Transaction();

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
                        //objTrans.End_Transaction();
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
            /*// if (Validation())
            //{
            clsoperation objTrans = new clsoperation();
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
            //}
            //else
            //{
            //   return false;
            //}*/
            return false;
        }

        private string[,] MakeArrayD()
        {
            string[,] aryTest = new string[10, 3];

                if (!this._TransNo.Equals(Default))
                {
                    aryTest[0, 0] = "TRANSNO";
                    aryTest[0, 1] = this._TransNo;
                    aryTest[0, 2] = "string";
                }

                if (!this._PRNO.Equals(Default))
                {
                    aryTest[1, 0] = "PRNO";
                    aryTest[1, 1] = this._PRNO;
                    aryTest[1, 2] = "string";
                }

                if (!this._DepartmentID.Equals(Default))
                {
                    aryTest[2, 0] = "DEPARTMENTID";
                    aryTest[2, 1] = this._DepartmentID;
                    aryTest[2, 2] = "string";
                }

                if (!this._SubDepartmentID.Equals(Default))
                {
                    aryTest[3, 0] = "SUBDEPARTMENTID";
                    aryTest[3, 1] = this._SubDepartmentID;
                    aryTest[3, 2] = "string";
                }

                if (!this._ServiceID.Equals(Default))
                {
                    aryTest[4, 0] = "SERVICEID";
                    aryTest[4, 1] = this._ServiceID;
                    aryTest[4, 2] = "string";
                }

                if (!this._Amount.Equals(Default))
                {
                    aryTest[5, 0] = "CHARGES";
                    aryTest[5, 1] = this._Amount;
                    aryTest[5, 2] = "string";
                }

                if (!this._Status.Equals(Default))
                {
                    aryTest[6, 0] = "Status";
                    aryTest[6, 1] = this._Status;
                    aryTest[6, 2] = "string";
                }

                if (!this._EnteredBy.Equals(Default))
                {
                    aryTest[7, 0] = "EnteredBy";
                    aryTest[7, 1] = this._EnteredBy;
                    aryTest[7, 2] = "string";
                }

                if (!this._EnteredAt.Equals(Default))
                {
                    aryTest[8, 0] = "EnteredAt";
                    aryTest[8, 1] = this._EnteredAt;
                    aryTest[8, 2] = "datetime";
                }

                if (!this._VisitNo.Equals(Default))
                {
                    aryTest[9, 0] = "VisitNo";
                    aryTest[9, 1] = this._VisitNo;
                    aryTest[9, 2] = "string";
                }

            return aryTest;
        }

        #endregion

        #region "Validation Functions"

        private bool ValidationD()
        {
            Validation objValid = new Validation();

            if (this._DepartmentID.Equals("") || this._DepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Department not found in service detail! Please try again";
                return false;
            }

            if (this._SubDepartmentID.Equals("") || this._SubDepartmentID.Equals(Default))
            {
                this.StrErrorMessage = "Sub-Department not found in service detail! Please try again";
                return false;
            }

            if (this._ServiceID.Equals("") || this._ServiceID.Equals(Default))
            {
                this.StrErrorMessage = "Service not found in service detail! Please try again";
                return false;
            }

            if (this._Amount.Equals("") || this._Amount.Equals(Default))
            {
                this.StrErrorMessage = "Service not found in service detail! Please try again";
                return false;
            }
            return true;
        }




        #endregion


    }
}
