using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlTestSops
    {
        public clsBlTestSops()
        {
            ///Add Constructor Logic here...
        }

        #region Variables
        private const string TableName = "LS_TTestSops";
        private const string Default = "~!@";
        private string StrTestSopID = Default;


        private string StrTestID = Default;

       
        private string StrSopTypeID = Default;
        private string StrSOPDescription = Default;
        private string StrDoc_Path = Default;

        private string StrSubDepartmentID = Default;

     
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrDoc_Path2 = Default;

        private string StrDoc_Path3 = Default;
        private string _ProcessID = Default;

       
        private string StrErrorMessage = "";
        #endregion
       
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
       
        #region Properties
        public string ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }
        public string TestSopID
        {
            get { return StrTestSopID; }
            set { StrTestSopID = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string SopTypeID
        {
            get { return StrSopTypeID; }
            set { StrSopTypeID = value; }
        }
        public string Description
        {
            get { return StrSOPDescription; }
            set { StrSOPDescription = value; }
        }
        public string Doc_Path
        {
            get { return StrDoc_Path; }
            set { StrDoc_Path = value; }
        }
        public string SubDepartmentID
        {
            get { return StrSubDepartmentID; }
            set { StrSubDepartmentID = value; }
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
        public string Doc_Path2
        {
            get { return StrDoc_Path2; }
            set { StrDoc_Path2 = value; }
        }
        public string Doc_Path3
        {
            get { return StrDoc_Path3; }
            set { StrDoc_Path3 = value; }
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
                    objdbhims.Query = @"Select tts.TestSopID,tts.SoptypeID,tst.Name SOPtype,tt.TestID,tts.SopDescription Description,tt.Test Test,tt.SectionID,NVL(Replace(tts.DOC_PATH,'X',''),'')||'<br />'||NVL(Replace(tts.Doc_path2,'X',''),'')||'<br />'||NVl(Replace(tts.Doc_Path3,'X',''),'') as Doc_path,NVL(tts.DOC_PATH,'') as Doc_path1,NVL(tts.DOC_PATH2,'') as Doc_path2,NVL(tts.DOC_PATH3,'') as doc_path3 From 
                                        ls_ttestsops tts Inner Join LS_TTest tt On tt.testid= tts.testid 
                                        Inner Join LS_TSopTypes tst On tst.SopTypeId=tts.SopTypeID 
                                        where tt.sectionid='" +SubDepartmentID+"'";

                    break;
                case 2:
                   objdbhims.Query="Select s.* from ls_tsoptypes s, ls_ttestsops ts where ts.soptypeid=s.soptypeid and  ts.TestId='"+StrTestID+"'";// And SOPTYPEID='"+StrSopTypeID+"'";
                   if (!_ProcessID.Equals(Default) && !_ProcessID.Equals(""))
                   {
                       objdbhims.Query += " and s.processid='" + _ProcessID + "'";
                   }
                   break;
                case 3:
                     objdbhims.Query="Select * From "+TableName+" Where TestId='"+StrTestID+"' And SOPTYPEID='"+StrSopTypeID+"'";
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

                    objdbhims.Query = "Select NVl(Max(TESTSOPID),0)+1 MAXID From " + TableName;
                    this.StrTestSopID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (this.StrTestSopID.Equals("True"))
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
            string[,] AryTestSops = new string[11, 3];

            if (!StrTestSopID.Equals(Default))
            {
                AryTestSops[0, 0] = "TestSopID";
                AryTestSops[0, 1] = StrTestSopID;
                AryTestSops[0, 2] = "int";
            }
            if (!StrTestID.Equals(Default))
            {
                AryTestSops[1, 0] = "TestID";
                AryTestSops[1, 1] = StrTestID;
                AryTestSops[1, 2] = "string";
            }
            if (!StrSopTypeID.Equals(Default))
            {
                AryTestSops[2, 0] = "SopTypeID";
                AryTestSops[2, 1] = StrSopTypeID;
                AryTestSops[2, 2] = "int";
            }
            if (!StrSOPDescription.Equals(Default))
            {
                AryTestSops[3, 0] = "SOPDescription";
                AryTestSops[3, 1] = StrSOPDescription;
                AryTestSops[3, 2] = "string";
            }


            if (!StrEnteredBy.Equals(Default))
            {
                AryTestSops[4, 0] = "EnteredBy";
                AryTestSops[4, 1] = StrEnteredBy;
                AryTestSops[4, 2] = "string";
            }

            if (!StrEnteredOn.Equals(Default))
            {
                AryTestSops[5, 0] = "EnteredOn";
                AryTestSops[5, 1] = StrEnteredOn;
                AryTestSops[5, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                AryTestSops[6, 0] = "ClientID";
                AryTestSops[6, 1] = StrClientID;
                AryTestSops[6, 2] = "string";
            }
            if (!StrSystem_Ip.Equals(Default))
            {
                AryTestSops[7, 0] = "System_Ip";
                AryTestSops[7, 1] = StrSystem_Ip;
                AryTestSops[7, 2] = "string";
            }
            if (!StrDoc_Path2.Equals(Default))
            {
                AryTestSops[8, 0] = "Doc_Path2";
                AryTestSops[8, 1] = StrDoc_Path2;
                AryTestSops[8, 2] = "string";
            }
            if (!StrDoc_Path3.Equals(Default))
            {
                AryTestSops[9, 0] = "Doc_Path3";
                AryTestSops[9, 1] = StrDoc_Path3;
                AryTestSops[9, 2] = "string";
            }
            if (!StrDoc_Path.Equals(Default))
            {
                AryTestSops[10, 0] = "Doc_Path";
                AryTestSops[10, 1] = StrDoc_Path;
                AryTestSops[10, 2] = "string";
            }
          
            return AryTestSops;

        }
        public bool Validation()
        {
            if (!chkprocessID())
            {
                return false;
            }
            if (!chksubdepartment())
            {
                return false;
            }
            if (!chkTest())
            {
                return false;
            }
            return true;
        }
        private bool chkprocessID()
        {
            if (this.StrSopTypeID == "" || StrSopTypeID == "&nbsp" || this.StrSopTypeID == "-1")
            {
                this.StrErrorMessage = "Please Select SOP Type.";
                return false;
            }
            return true;
        }
        private bool chksubdepartment()
        {
            if (this.StrSubDepartmentID == "" || StrSubDepartmentID == "&nbsp" || this.StrSubDepartmentID == "-1")
            {
                this.StrErrorMessage = "Please Select Sub-Department.";
                return false;
            }
            return true;
        }
        private bool chkTest()
        {
            if (this.StrTestID == "" || StrTestID == "&nbsp" || this.StrTestID == "-1")
            {
                this.StrErrorMessage = "Please Select Test.";
                return false;
            }
            return true;
        }

        private bool chkduplicate()
        {
            DataView chkduplicate = GetAll(3);
            if (chkduplicate.Count > 0)
            {
                this.StrErrorMessage = "Test already Present.";
                return false;
            }
            return true;
        }

        #endregion
    }
}
