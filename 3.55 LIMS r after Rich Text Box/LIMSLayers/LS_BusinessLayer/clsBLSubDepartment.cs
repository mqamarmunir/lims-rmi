using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;


namespace LS_BusinessLayer
{
    public class clsBLSubDepartment
    {

        #region "Class Variables"

        private const string Default = "~!@";
        private const string TableName = "HR_TSUBDEPARTMENT d";
        private string StrErrorMessage = "";
        private string _SubDepartmentID = Default;
        private string _DepartmentID = Default;
        private string _SubDepartmentName = Default;
        private string _Active = Default;

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

        public string SubDepartmentName
        {
            get
            {
                return _SubDepartmentName;
            }
            set
            {
                _SubDepartmentName = value;
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
        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region "Class Methods"

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "select t.subdepartmentid,t.name from whims2.HR_TSUBDEPARTMENT t where t.DepartmentID='011'";
                    if (Active != Default && Active != "")
                        objdbhims.Query += "  and Active = '" + this.Active + "' ";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);

        }

        #endregion
    }
}
