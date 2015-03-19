using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;
using System.Globalization;
namespace LS_BusinessLayer
{
    public class clsBlSopTypes
    {
        public clsBlSopTypes()
        {
            ///Add Constructor Logic here...
        }

        #region Variables
        private const string TableName = "LS_TSopTypes";
        private const string Default = "~!@";
        private string StrSopTypeID = Default;
        private string StrName = Default;
        private string StrProcessID = Default;
        private string StrActive = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrTestID = Default;
        private string StrApprovedBy = Default;
        private string StrDepartmentId = Default;

        
       
        private string StrApprovedOn = Default;
        private string StrApplicableDate = Default;
        private string StrErrorMessage = "";
        #endregion
        
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        
        #region Properties
        public string DepartmentId
        {
            get { return StrDepartmentId; }
            set { StrDepartmentId = value; }
        }
        public string SopTypeID
        {
            get { return StrSopTypeID; }
            set { StrSopTypeID = value; }
        }
        public string Name
        {
            get { return StrName; }
            set { StrName = value; }
        }
        public string ProcessID
        {
            get { return StrProcessID; }
            set { StrProcessID = value; }
        }
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
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
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string ApprovedBy
        {
            get { return StrApprovedBy; }
            set { StrApprovedBy = value; }
        }
        public string ApprovedOn
        {
            get { return StrApprovedOn; }
            set { StrApprovedOn = value; }
        }
        public string ApplicableDate
        {
            get { return StrApplicableDate; }
            set { StrApplicableDate = value; }
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
                    objdbhims.Query = "Select tst.SoptypeID,tst.PROCESSID,tp.Process,tst.name,tst.Active,tst.ApplicableDate,tst.ApprovedBy,tst.ApprovedOn From " + TableName + " tst Inner Join Ls_TTestProcess tp On tp.ProcessId=tst.PROCESSID";
                    break;
                case 2:
                    objdbhims.Query="Select * From "+TableName+" where Active<>'N'";
                    break;
                case 3:
                    objdbhims.Query = "Select * From " + TableName + " where Name='" + StrName + "' And ProcessID='" + StrProcessID + "'";
                    break;
                case 4:
                    objdbhims.Query = @"Select tst.SOPTypeID,tst.Name,tst.ApplicableDate,ttp.Process ProcessName,
                                        ttp.ProcessID,tt.TestID,tt.Test TestName 
                                        From ls_tsoptypes tst Inner Join ls_ttestsops tts 
                                        On tst.soptypeid= tts.soptypeid 
                                        inner join ls_ttestprocess ttp 
                                        On ttp.processid= tst.processid 
                                        Inner Join LS_Ttest tt 
                                        On tt.testid= tts.testid where tst.Active<>'N' ";
                    if (ProcessID != "" && ProcessID != Default && ProcessID != "-1")
                    {
                        objdbhims.Query += " and ttp.ProcessID='" + StrProcessID + "'";
                    }
                    if (StrTestID != "" && StrTestID != Default && StrTestID != "-1")
                    {
                        objdbhims.Query += " and tt.TestID='" + StrTestID + "'";
                    }

                    break;
                case 5:
                    objdbhims.Query = "Select tp.Personid,tp.fname||' '||tp.mname||' '||tp.lname|| ' '||tp.salutation as Name From whims2.Hr_Tpersonnel tp where tp.Active='Y'";
                    if (!StrDepartmentId.Equals(Default) && !StrDepartmentId.Equals(""))
                    {
                        objdbhims.Query += " and tp.DepartmentiD='" + StrDepartmentId + "' and tp.DesignationID in (Select designationid From whims2.hr_tdesignation where lower(name) like('%consultant%') and active='Y')";

                    }
               

                    break;


            }
            return objTrans.DataTrigger_Get_All(objdbhims);

        }

        public bool insert()
        {
            if (Validation() && chkduplicate())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = "Select NVl(Max(SOPTYPEID),0)+1 MAXID From " + TableName;
                    this.StrSopTypeID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (this.StrSopTypeID.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    else
                    {
                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;

                        }
                        else
                        {
                            objTrans.End_Transaction();
                            return true;
                        }
                    }

                }
                catch (Exception ee)
                {
                    this.StrErrorMessage = ee.ToString();
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

        private string[,] MakeArray()
        {
            string[,] ArySopTypes = new string[11, 3];

            if (!StrSopTypeID.Equals(Default))
            {
                ArySopTypes[0, 0] = "SopTypeID";
                ArySopTypes[0, 1] = StrSopTypeID;
                ArySopTypes[0, 2] = "int";
            }
            if (!StrName.Equals(Default))
            {
                ArySopTypes[1, 0] = "Name";
                ArySopTypes[1, 1] = StrName;
                ArySopTypes[1, 2] = "string";
            }
            if (!StrProcessID.Equals(Default))
            {
                ArySopTypes[2, 0] = "ProcessID";
                ArySopTypes[2, 1] = StrProcessID;
                ArySopTypes[2, 2] = "string";
            }
            if (!StrActive.Equals(Default))
            {
                ArySopTypes[3, 0] = "Active";
                ArySopTypes[3, 1] = StrActive;
                ArySopTypes[3, 2] = "string";
            }
            

            if (!StrEnteredBy.Equals(Default))
            {
                ArySopTypes[4, 0] = "EnteredBy";
                ArySopTypes[4, 1] = StrEnteredBy;
                ArySopTypes[4, 2] = "string";
            }

            if (!StrEnteredOn.Equals(Default))
            {
                ArySopTypes[5, 0] = "EnteredOn";
                ArySopTypes[5, 1] = StrEnteredOn;
                ArySopTypes[5, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                ArySopTypes[6, 0] = "ClientID";
                ArySopTypes[6, 1] = StrClientID;
                ArySopTypes[6, 2] = "string";
            }
            if (!StrSystem_Ip.Equals(Default))
            {
                ArySopTypes[7, 0] = "System_Ip";
                ArySopTypes[7, 1] = StrSystem_Ip;
                ArySopTypes[7, 2] = "string";
            }
            if (!StrApprovedBy.Equals(Default))
            {
                ArySopTypes[8, 0] = "ApprovedBy";
                ArySopTypes[8, 1] = StrApprovedBy;
                ArySopTypes[8, 2] = "string";
            }
            if (!StrApprovedOn.Equals(Default))
            {
                ArySopTypes[9, 0] = "ApprovedOn";
                ArySopTypes[9, 1] = StrApprovedOn;
                ArySopTypes[9, 2] = "date";
            }
            if (!StrApplicableDate.Equals(Default))
            {
                ArySopTypes[10, 0] = "ApplicableDate";
                ArySopTypes[10, 1] = StrApplicableDate;
                ArySopTypes[10, 2] = "date";
            }

            return ArySopTypes;

        }

        public bool Validation()
        {
            if (!chkprocessID())
            {
                return false;
            }
            if (!chkname())
            {
                return false;
            }
            if (!chkApprovedBy())
            {
                return false;
            }
            if (!chkApprovedOn())
            {
                return false;
            }
            if (!chkApplicable())
            {
                return false;
            }
            return true;
        }

        private bool chkduplicate()
        {
            DataView dv_chkduplicate = GetAll(3);
            if (dv_chkduplicate.Count > 0)
            {
                this.StrErrorMessage = "Type already present.";
                return false;
            }
            return true;

        }
        private bool chkprocessID()
        {
            if (this.StrProcessID == "" || StrProcessID == "&nbsp" || this.StrProcessID == "-1")
            {
                this.StrErrorMessage = "Please Select process ID";
                return false;
            }
            return true;
        }
        private bool chkname()
        {
            if (this.StrName == "" || StrName == "&nbsp")
            {
                this.StrErrorMessage = "Please Enter Type Name. Empty not allowed";
                return false;
 
            }
            return true;

        }
        private bool chkApprovedBy()
        {
            if (this.StrApprovedBy == "" || StrApprovedBy == "&nbsp" || this.StrApprovedBy == "-1")
            {
                this.StrErrorMessage = "Please Select Approved By";
                return false;
            }
            return true;
        }
        private bool chkApprovedOn()
        {
            if (this.StrApprovedOn == "" || StrApprovedOn == "&nbsp" || StrApprovedOn == "__/__/____"||DateTime.Parse(StrApprovedOn,new CultureInfo("en-GB",false))>System.DateTime.Now)
            {
                this.StrErrorMessage = "Please Enter Valid(Approved On) Date.";
                return false;

            }
            return true;

        }
        private bool chkApplicable()
        {
            if (this.StrApplicableDate == "" || StrApplicableDate == "&nbsp" || StrApplicableDate == "__/__/____" )
            {
                this.StrErrorMessage = "Please Enter Valid(Applicable) Date.";
                return false;

            }
            return true;

        }
        #endregion

    }
}
