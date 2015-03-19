using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;


namespace LS_BusinessLayer
{
    public class clsBLDepartment
    {

        #region "Class Variables"

        private const string Default = "~!@";
        private const string TableName = "HR_TDEPARTMENT";
        private string StrErrorMessage = "";
        private string _DepartmentID = Default;
        private string _DepartmentName = Default;
        private string _Acronym = Default;
        private string _Active = Default;
        private string _Type = Default;
        private string _DOrder = Default;
        private string _HODID = Default;
        #endregion

        #region "Properties"

        public string ErrorMessage
        {
            get { return StrErrorMessage; }
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

        public string DepartmentName
        {
            get
            {
                return _DepartmentName;
            }
            set
            {
                _DepartmentName = value;
            }
        }

        public string Acronym
        {
            get
            {
                return _Acronym;
            }
            set
            {
                _Acronym = value;
            }
        }

        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        public string Active
        {
            get
            {
                return _Active;
            }
            set
            {
                _Active = value;
            }
        }

        public string Dorder
        {
            get
            {
                return _DOrder;
            }
            set
            {
                _DOrder = value;
            }
        }

        public string HODID
        {
            get
            {
                return _HODID;
            }
            set
            {
                _HODID = value;
            }
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
                    objdbhims.Query = "select * from whims2." + TableName ;
                    if (Active != Default && Active != "")
                    objdbhims.Query += "  where  Active = '"+this.Active+"' ";
                    break;
                    //add 080116 for services
                case 2:
                    objdbhims.Query = "select d.departmentid,d.name from whims2.hr_tdepartment d where d.type = 'Sr'";
                    if (Active != Default && Active != "")
                        objdbhims.Query += "and Active='"+this.Active+"'";
                    break;

                case 3:
                    objdbhims.Query = @"select d.departmentid, d.departmentname
                                      from department d
                                     where /*d.type = 'Sr'and*/
                                     d.Active = 'Y'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);

        }

        #endregion
    }
}
