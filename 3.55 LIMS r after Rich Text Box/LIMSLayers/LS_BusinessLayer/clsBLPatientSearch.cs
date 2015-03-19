using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLPatientSearch
    {
        #region "Class Variables"

        private const string Default = "~!@";
        private const string TableName = "PR_VPATIENTSEARCH";
        private string StrErrorMessage = "";
        private string _PRNO = Default;
        private string _PatientType = Default;
        private string _FName = Default;
        private string _MName = Default;
        private string _LName = Default;
        private string _PatientCompleteName = Default;
        private string _NICOLD = Default;
        private string _Sex = Default;
        private string _Age = Default;

        private string _OrgID = Default;
        private string _DesignationID = Default;
        private string _ServiceNo = Default;
        private string _Expire = Default;
        private string _CellNumber = Default;

        
        #endregion

        #region "Properties"

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
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
        public string Expire
        {
            get
            {
                return _Expire;
            }
            set
            {
                _Expire = value;
            }
        }
        

        public string PatientType
        {
            get
            {
                return _PatientType;
            }
            set
            {
                _PatientType = value;
            }
        }

        public string FName
        {
            get
            {
                return _FName;
            }
            set
            {
                _FName = value;
            }
        }

        public string MName
        {
            get
            {
                return _MName;
            }
            set
            {
                _MName = value;
            }
        }

        public string LName
        {
            get
            {
                return _LName;
            }
            set
            {
                _LName = value;
            }
        }

        public string PatientCompleteName
        {
            get
            {
                return _PatientCompleteName;
            }
            set
            {
                _PatientCompleteName = value;
            }
        }

        public string NICOLD
        {
            get
            {
                return _NICOLD;
            }
            set
            {
                _NICOLD = value;
            }
        }

        public string Sex
        {
            get
            {
                return _Sex;
            }
            set
            {
                _Sex = value;
            }
        }

        public string Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }

        public string OrgID
        {
            get
            {
                return _OrgID;
            }
            set
            {
                _OrgID = value;
            }
        }

        public string DesignationID
        {
            get
            {
                return _DesignationID;
            }
            set
            {
                _DesignationID = value;
            }
        }
        public string ServiceNo
        {
            get
            {
                return _ServiceNo;
            }
            set
            {
                _ServiceNo = value;
            }
        }
        public string CellNumber
        {
            get { return _CellNumber; }
            set { _CellNumber = value; }
        }

        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region "Class Methods"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "select t.*,case when t.sex='M' then 'Male' else 'Female' end as Gender,case when t.maritalStatus='S' then 'Single' else 'Married' end as MStatus from whims2." +TableName+" t";
                    objdbhims.Query = objdbhims.Query + " where 1=1 ";

                    if (!this._PRNO.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.PRNo = '" + this._PRNO + "'";
                    }

                    if (!this._FName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.fname) like '%'||'" + this._FName.Trim().ToUpper() + "'||'%' ";
                    }
                    if (!this._MName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.mname) like '%'||'" + this._MName.Trim().ToUpper() + "'||'%' ";
                    }
                    if (!this._LName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.lname) like '%'||'" + this._LName.Trim().ToUpper() + "'||'%' ";
                    }
                    if (!this._Sex.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.sex = '" + this._Sex + "'";
                    }

                    if (!this._NICOLD.Equals(Default)&&!this._NICOLD.Equals(""))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.NICOLD = '" + this._NICOLD + "'";
                    }
                    if (!this._CellNumber.Equals(Default) && !this._CellNumber.Equals(""))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.CellPhone = '" + this._CellNumber + "'";
                    }
                   

                    break;

                    /*==================for CNE search===============*/
                case 2:
                    objdbhims.Query = "select * ";
                    objdbhims.Query = objdbhims.Query + " from pr_tpatientreg t";
                    objdbhims.Query = objdbhims.Query + " where 1=1 ";
                    objdbhims.Query = objdbhims.Query + " and t.PRNO = '" + this._PRNO + "'";

                break;

                case 3:
                    objdbhims.Query = "select t.designationid, t.name ";
                    objdbhims.Query = objdbhims.Query + " from or_tdesignation t";
                    objdbhims.Query = objdbhims.Query + " where t.orgid = "+this._OrgID;
                break;

                    /*=============for ENT search===================*/
                case 4:
                    objdbhims.Query = "select * from pr_ventpatientsearch t where 1=1";
                    if (!this._FName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.PatientFullName,) like '%'||'" + this._FName.Trim().ToUpper() + "'||'%' ";
                    }
                    if (!this._MName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.mname,) like '%'||'" + this._MName.Trim().ToUpper() + "'||'%' ";
                    }
                    if (!this._LName.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and Upper(t.lname,) like '%'||'" + this._LName.Trim().ToUpper() + "'||'%' ";
                    }                    

                    if (!this._Sex.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.sex = '" + this._Sex + "'";
                    }

                    if (!this._NICOLD.Equals(Default) && !this._NICOLD.Equals(""))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.NICOLD = '" + this._NICOLD + "'";
                    }

                    if (!this._OrgID.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.orgid =" + this._OrgID;
                    }
                    if (!this._DesignationID.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.designationid =" + this._DesignationID;
                    }
                    if (!this._ServiceNo.Equals(Default))
                    {
                        objdbhims.Query = objdbhims.Query + " and t.serviceno =" + this._ServiceNo;
                    }
                break;
                case 5:
                    objdbhims.Query = "select t.DISCHARGESHEETID,a.ADMNO,a.PRNO,a.ADMDATETIME from WD_TDISCHARGESHEET t, WD_TADMISSION a where t.ADMNO = a.ADMNO and t.prno = a.prno and a.prno = '"+_PRNO+"'";
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }


        #endregion    
    }
}