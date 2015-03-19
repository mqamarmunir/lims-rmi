using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBLTestGroupD
    {
        public clsBLTestGroupD()
        {

        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TTestGroupD";
        private string StrGroupDetailID = Default;
        private string StrSectionID = Default;
        private string StrTestGroupID= Default;
        private string StrTestID = Default;
       // private string StrTestName = Default;
        private string StrActive = Default;
        private string StrCharges = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrErrorMessage = Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string GroupDetailID
        {
            get { return StrGroupDetailID; }
            set { StrGroupDetailID = value; }
 
        }
        public string SectionID
        {
            get { return StrSectionID; }
            set { StrSectionID = value; }
        }

        public string TestGroupID
        {
            get { return StrTestGroupID; }
            set { StrTestGroupID = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
        }
        public string Charges
        {
            get { return StrCharges; }
            set { StrCharges = value; }
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
            set { StrErrorMessage = value; }
        }
        #endregion

        #region methods
        public DataView GetAll(int flag)
        {
            clsoperation objTrans2 = new clsoperation();

            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select SECTIONID,SECTIONNAME From LS_TSection where Active='Y'";
                    break;
                case 2:
                    objdbhims.Query = "Select TESTGROUPID,TESTGROUP FROM LS_TTESTGROUP where SECTIONID='" + StrSectionID +"' and Active<>'D'";
                    break;
                case 3:
                    objdbhims.Query = "Select TestID,Test From Ls_TTest Where SectionID='" + StrSectionID+"' and Active='Y'";
                    break;
                case 4:
                    objdbhims.Query = "Select tt.Charges,tgd.Charges Rate From LS_TTest tt Left Outer join Ls_TTestGroupD tgd On tt.TestID=tgd.TestID Where tt.TestID='" + StrTestID +"' And tgd.TestGroupID='"+ StrTestGroupID+"'";
                    break;
                case 5:
                    string command = "Select tgd.GroupDetailID,tgd.TestGroupID,tgd.TestID,tgd.SectionID,tg.TestGroup,ts.SectionName,tt.Test,tgd.Charges,tgd.Active From Ls_TTestGroupD tgd Inner join Ls_TSection ts On ts.SectionID=tgd.SectionID Inner join Ls_TTestGroup tg On tg.TestGroupID=tgd.TestGroupID Inner Join Ls_TTest tt On tt.TestID=tgd.TestID Where tgd.SectionID='" +StrSectionID + "'";
                    if (!StrTestGroupID.Equals(Default))
                    {
                        command = command + " And tgd.TestGroupID='" + StrTestGroupID + "'";
                    }
                    objdbhims.Query = command;
                    break;
                case 6:
                    objdbhims.Query = "Select TestID From Ls_TTestGroupD where TestID='"+StrTestID+"' And TestGroupID='"+StrTestGroupID+"'";
                    break;
                    
            }
            return objTrans2.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            if (Validation() && VD_Test())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("GroupDetailID", TableName, "6");
                    this.StrGroupDetailID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (!this.StrGroupDetailID.Equals("True"))
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
        public bool Update()
        {
            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
            if (Validation())
            {
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
        private string[,] MakeArray()
        {
            string[,] ary_GroupD=new string[9,3];

            if (!StrGroupDetailID.Equals(Default))
            {
                ary_GroupD[0, 0] = "GroupDetailID";
                ary_GroupD[0, 1] = this.StrGroupDetailID;
                ary_GroupD[0, 2] = "string";
            }

            if (!StrTestGroupID.Equals(Default))
            {
                ary_GroupD[1, 0] = "TestGroupID";
                ary_GroupD[1, 1] = this.StrTestGroupID;
                ary_GroupD[1, 2] = "string";
            }
            if (!StrTestID.Equals(Default))
            {
                ary_GroupD[2, 0] = "TestID";
                ary_GroupD[2, 1] = this.StrTestID;
                ary_GroupD[2, 2] = "string";
            }
            if (!StrActive.Equals(Default))
            {
                ary_GroupD[3, 0] = "Active";
                ary_GroupD[3, 1] = this.StrActive;
                ary_GroupD[3, 2] = "string";
            }
            if (!StrCharges.Equals(Default))
            {
                ary_GroupD[4, 0] = "Charges";
                ary_GroupD[4, 1] = this.StrCharges;
                ary_GroupD[4, 2] = "int";
            }
            if (!StrEnteredBy.Equals(Default))
            {
                ary_GroupD[5, 0] = "EnteredBy";
                ary_GroupD[5, 1] = this.StrEnteredBy;
                ary_GroupD[5, 2] = "string";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                ary_GroupD[6, 0] = "EnteredOn";
                ary_GroupD[6, 1] = this.StrEnteredOn;
                ary_GroupD[6, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                ary_GroupD[7, 0] = "ClientID";
                ary_GroupD[7, 1] = this.StrClientID;
                ary_GroupD[7, 2] = "string";
            }
            if (!StrSectionID.Equals(Default))
            {
                ary_GroupD[8, 0] = "SectionID";
                ary_GroupD[8, 1] = this.StrSectionID;
                ary_GroupD[8, 2] = "string";
            }
            return ary_GroupD;
 
        }
        private bool Validation()
        {
            //if (!VD_Test())
            //{
            //    return false;
            //}
            /*
                        if(!VD_Acronym())
                        {
                            return false;
                        }
            */
            if (!VD_Charges())
            {
                return false;
            }
            if (!VDSubDepartment())
            {
                return false;
            }
            if (!VDTestGroup())
            {
                return false;
            }

            if (!VDTest())
            {
                return false;
            }
          

            return true;




            //DataView dv = GetAll(6);
            //if (dv.Count > 0)
            //{
            //    this.StrErrorMessage = "Insertion failed.Same Test already exists";
            //    return false;
            //}
            //else
            //    return true;
        }

        private bool VD_Test()
        {
            DataView dv = GetAll(6);
            if (dv.Count > 0)
            {
                this.StrErrorMessage = "Insertion failed.Same Test with the same TestGroup already exists";
                return false;
            }
            else
                return true;
        }

        private bool VD_Charges()
        {
            Validation objValid = new Validation();

            if (this.StrCharges.Equals(""))
            {
                this.StrErrorMessage = "Please insert Charges. (empty is not allowed)";
                return false;
            }
            else if (!objValid.IsPositiveNumber(this.StrCharges))
            {
                this.StrErrorMessage = "Please enter valid Charges. (only +ve integer is allowed)";
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool VDSubDepartment()
        {

            if (this.StrSectionID.Equals("Default") || this.StrSectionID.Equals("-1"))
            {
                this.StrErrorMessage = "Please Select Sub-Department";
                return false;
            }
            else
                return true;
        }

        private bool VDTestGroup()
        {
            if (this.StrTestGroupID.Equals("Default") || this.StrTestGroupID.Equals("-1"))
            {
                this.StrErrorMessage = "Please Select Test Group";
                return false;
            }
            else
                return true;
 
        }

        private bool VDTest()
        {
            if (this.StrTestID.Equals("Default") || this.StrTestID.Equals("-1"))
            {
                this.StrErrorMessage = "Please Select Test";
                return false;
            }
            else
                return true;

        }

        #endregion
    }
}
