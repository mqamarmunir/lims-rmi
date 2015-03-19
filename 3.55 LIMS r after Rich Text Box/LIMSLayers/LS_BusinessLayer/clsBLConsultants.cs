using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLConsultants
    {
        public clsBLConsultants()
        {
            ///Add Constructor Logic here...
        }

        #region Variables
        private const string TableName = "whims2.HR_TReportConsultant";
        private const string Default = "~!@";
        private string StrReportConsultantID = Default;

        private string StrDepartmentID = Default;
        private string StrSubDepartmentID = Default;
        private string StrPersonID = Default;
        private string StrLevel1 = Default;
        private string StrLevel2 = Default;
        private string StrLevel3 = Default;
        private string StrLevel4 = Default;
        private string StrActive = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrIPAddress = Default;
        private string StrDOrder = Default;
        private string StrLabSubDepartmentID = Default;
        private string strfromdate=Default;
        private string strtodate=Default;

        
        private string StrErrorMessage = "";
        #endregion
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Properties
        public string Fromdate
        {
            get { return strfromdate; }
            set { strfromdate = value; }
        }
        public string Todate
        {
            get { return strtodate; }
            set { strtodate = value; }
        }
        public string LabSubDepartmentID
        {
            get { return StrLabSubDepartmentID; }
            set { StrLabSubDepartmentID = value; }
        }
        public string ReportConsultantID
        {
            get { return StrReportConsultantID; }
            set { StrReportConsultantID = value; }
        }

        public string SubDepartmentID
        {
            get { return StrSubDepartmentID; }
            set { StrSubDepartmentID = value; }
        }

        public string DepartmentID
        {
            get { return StrDepartmentID; }
            set { StrDepartmentID = value; }
        }

        public string PersonID
        {
            get { return StrPersonID; }
            set { StrPersonID = value; }
        }

        public string Level1
        {
            get { return StrLevel1; }
            set { StrLevel1 = value; }
        }

        public string Level2
        {
            get { return StrLevel2; }
            set { StrLevel2 = value; }
        }

        public string Level3
        {
            get { return StrLevel3; }
            set { StrLevel3 = value; }
        }

        public string Level4
        {
            get { return StrLevel4; }
            set { StrLevel4 = value; }
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

        public string IPAddress
        {
            get { return StrIPAddress; }
            set { StrIPAddress = value; }
        }
        public string DOrder
        {
            get { return StrDOrder; }
            set { StrDOrder = value; }
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
                    objdbhims.Query = "Select DepartmentID,Name From whims2.HR_TDepartment where Active='Y' and DepartmentID='011'";
                    break;
                case 2:
                    objdbhims.Query = "Select SubDepartmentID,Name From whims2.HR_TSubDepartment where DepartmentID='011' and Active='Y'";
                    break;
                case 3:
                    objdbhims.Query =@"Select tp.DepartmentID,tp.SubDepartmentID,tp.ServiceNo,tp.PersonID,tds.Name Designation,tp.FNAME,tp.MNAME,tp.LNAME,tp.FName||' '||tp.MNAME||' '||tp.LNAME PersonName,
                                        td.Name||':'||tsd.Name depsub 
 
                                        From whims2.HR_TPersonnel tp Inner Join whims2.HR_TDEPARTMENT td
                                        On td.DepartmentId=tp.DepartmentID
                                        Inner join whims2.Hr_Tsubdepartment tsd
                                        On tsd.subdepartmentid=tp.subdepartmentid
                                        Inner Join whims2.Hr_Tdesignation tds
                                        On tds.DesignationID=tp.DesignationID
                                        where tp.Active='Y' and tp.DepartmentID='011'";
                    if (!StrDepartmentID.Equals(Default) && !StrDepartmentID.Equals("-1") && !StrDepartmentID.Equals(""))
                    {
                        objdbhims.Query += " and td.DepartmentID='011'";

                        if (!StrSubDepartmentID.Equals(Default) && !StrSubDepartmentID.Equals("-1") && !StrSubDepartmentID.Equals(""))
                        {
                            objdbhims.Query += " and tsd.SubDepartmentID='" + StrSubDepartmentID + @"'";
                        }
                    }                 
                        //objdbhims.Query+="  and tp.Active='Y' ";
                    break;
                case 4:
                    objdbhims.Query = "Select * From whims2.HR_TPersonnel where personID='" + StrPersonID + "'";
                    break;
                case 5:
                    objdbhims.Query = "Select * From whims2.HR_vReportConsultant ";
                    if (!StrLabSubDepartmentID.Equals(Default))
                    {
                        objdbhims.Query += @" where labsubdepartmentid='" + StrLabSubDepartmentID + "'";
                    }
                    break;
                case 6:
                    objdbhims.Query = @"Select tp.ServiceNo,tds.Name Designation,tp.FName||' '||tp.MNAME||' '||tp.LNAME PersonName,
                                        td.Name||':'||tsd.Name depsub 
 
                                        From whims2.HR_TPersonnel tp Inner Join whims2.HR_TDEPARTMENT td
                                        On td.DepartmentId=tp.DepartmentID
                                        Inner join whims2.Hr_Tsubdepartment tsd
                                        On tsd.subdepartmentid=tp.subdepartmentid
                                        Inner Join whims2.Hr_Tdesignation tds
                                        On tds.DesignationID=tp.DesignationID
                                        where tp.PersonID='" + StrPersonID + "'";
                    break;
                case 7:
                    objdbhims.Query = "Select * From "+TableName+" where PersonID='"+StrPersonID+"' and labSubDepartmentID='"+StrLabSubDepartmentID+"' and Active='Y'";
                    break;
                case 8:
                    objdbhims.Query = "Select * From " + TableName + " WHERE Dorder=" + Convert.ToInt32(StrDOrder) + " and labsubdepartmentid='"+StrLabSubDepartmentID+"' and Active='Y'"; 
                    break;
                case 9:
                    objdbhims.Query = @"
  
  select tm.originid,
       tm.totalamount,
       p.PersonName as consultant,
       tm.mserialno,
       d.dserialno,
       d.testid,
       tm.entrydatetime
  from ls_tmtransaction tm
  left outer join ls_tdtransaction d on d.mserialno = tm.mserialno
  inner join whims2.hr_vpersonnel p on p.PERSONID=tm.originid
  inner join whims2.hr_tdesignation de on de.designationid=p.DESIGNATIONID
  where lower(de.NAME) LIKE ('%consultant%') AND p.active = 'Y'  and tm.entrydatetime between to_date('" + strfromdate + "','dd/MM/yyyy') and to_date('" + strtodate + "','dd/MM/yyyy')";
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            if (Validation() && Vd_Duplication())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();
                    objdbhims.Query = "Select NVl(max(reportconsultantId),0)+1 MAXID From whims2.Hr_Treportconsultant";
                    //objdbhims.Query = objQB.QBGetMax("ReportConsultantID", TableName);
                    this.StrReportConsultantID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (!this.StrReportConsultantID.Equals("True"))
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
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();
                  
                    //objdbhims.Query = objQB.QBGetMax("ReportConsultantID", TableName);
                    //this.StrReportConsultantID = objTrans.DataTrigger_Get_Max(objdbhims);
                    //if (!this.StrReportConsultantID.Equals("True"))
                    //{
                        objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
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
                   // }
                    //else
                    //{
                    //    this.StrErrorMessage = objTrans.OperationError;
                    //    objTrans.End_Transaction();
                    //    return false;
                    //}
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


        private string[,] MakeArray()
        {
            string[,] ary_Consultant = new string[15, 3];

            if (!StrReportConsultantID.Equals(Default))
            {
                ary_Consultant[0, 0] = "ReportConsultantID";
                ary_Consultant[0, 1] = this.StrReportConsultantID;
                ary_Consultant[0, 2] = "int";
            }

            if (!StrDepartmentID.Equals(Default))
            {
                ary_Consultant[1, 0] = "DepartmentID";
                ary_Consultant[1, 1] = this.StrDepartmentID;
                ary_Consultant[1, 2] = "string";
            }
            if (!StrSubDepartmentID.Equals(Default))
            {
                ary_Consultant[2, 0] = "SubDepartmentID";
                ary_Consultant[2, 1] = this.StrSubDepartmentID;
                ary_Consultant[2, 2] = "string";
            }
            if (!StrPersonID.Equals(Default))
            {
                ary_Consultant[3, 0] = "PersonID";
                ary_Consultant[3, 1] = this.StrPersonID;
                ary_Consultant[3, 2] = "string";
            }
            if (!StrLevel1.Equals(Default))
            {
                ary_Consultant[4, 0] = "Level1";
                ary_Consultant[4, 1] = this.StrLevel1;
                ary_Consultant[4, 2] = "string";
            }
            if (!StrLevel2.Equals(Default))
            {
                ary_Consultant[5, 0] = "Level2";
                ary_Consultant[5, 1] = this.StrLevel2;
                ary_Consultant[5, 2] = "string";
            }
            if (!StrLevel3.Equals(Default))
            {
                ary_Consultant[6, 0] = "Level3";
                ary_Consultant[6, 1] = this.StrLevel3;
                ary_Consultant[6, 2] = "string";
            }
            if (!StrLevel4.Equals(Default))
            {
                ary_Consultant[7, 0] = "Level4";
                ary_Consultant[7, 1] = this.StrLevel4;
                ary_Consultant[7, 2] = "string";
            }
            if (!StrActive.Equals(Default))
            {
                ary_Consultant[8, 0] = "Active";
                ary_Consultant[8, 1] = this.StrActive;
                ary_Consultant[8, 2] = "string";
            }
          
            if (!StrEnteredBy.Equals(Default))
            {
                ary_Consultant[9, 0] = "EnteredBy";
                ary_Consultant[9, 1] = this.StrEnteredBy;
                ary_Consultant[9, 2] = "string";
            }
            if (!StrEnteredOn.Equals(Default))
            {
                ary_Consultant[10, 0] = "EnteredOn";
                ary_Consultant[10, 1] = this.StrEnteredOn;
                ary_Consultant[10, 2] = "date";
            }
            if (!StrClientID.Equals(Default))
            {
                ary_Consultant[11, 0] = "ClientID";
                ary_Consultant[11, 1] = this.StrClientID;
                ary_Consultant[11, 2] = "string";
            }
            if (!StrIPAddress.Equals(Default))
            {
                ary_Consultant[12, 0] = "IPAddress";
                ary_Consultant[12, 1] = this.StrIPAddress;
                ary_Consultant[12, 2] = "string";
            }
            
            if (!StrDOrder.Equals(Default))
            {
                ary_Consultant[13, 0] = "DOrder";
                ary_Consultant[13, 1] = this.StrDOrder;
                ary_Consultant[13, 2] = "int";
            }
            if (!StrLabSubDepartmentID.Equals(Default))
            {
                ary_Consultant[14, 0] = "LabSubDepartmentID";
                ary_Consultant[14, 1] = this.StrLabSubDepartmentID;
                ary_Consultant[14, 2] = "string";
            }
            return ary_Consultant;

        }

        private bool Validation()
        {
            if (!VD_Levels())
            {
                return false;
            }
            
            return true;
        }

        private bool VD_Dorder()
        {

            if ((StrDOrder.Equals("") || StrDOrder.Equals(Default) || StrDOrder.Equals("-1")) && StrActive.Equals("Y"))
            {
                this.StrErrorMessage = "Select Display Order.";
                return false;
            }
            if (StrActive != "N")
            {
                DataView dv_chkduplicate = GetAll(8);
                if (dv_chkduplicate.Count > 0)
                {
                    StrErrorMessage = "Display Order already Registered with some consultant please select any other.";
                    dv_chkduplicate.Dispose();
                    return false;
                }
                dv_chkduplicate.Dispose();
                return true;
            }
            return true;
            
        }
        private bool VD_Levels()
        {
            if (StrLevel1.Equals("") || StrLevel1.Equals("&nbsp;") || StrLevel2.Equals("") || StrLevel2.Equals("&nbsp;") || StrLevel3.Equals("") || StrLevel3.Equals("&nbsp;"))
            {
                this.StrErrorMessage = "level1-Level3 TextBoxes can not be left empty.";
                return false;
            }
            return true;
        }

        private bool Vd_Duplication()
        {
            DataView dv_chkduplicate = GetAll(7);
            if (dv_chkduplicate.Count > 0)
            {
                StrErrorMessage = "Same Consultant already registered In the Same Sub Department. please check SerialNo:" + dv_chkduplicate[0]["ReportConsultantID"].ToString();
                dv_chkduplicate.Dispose();
                return false;

            }
          
            dv_chkduplicate.Dispose();
            if (!VD_Dorder())
            {
                return false;
            }
            return true;
        }

        #endregion

    }
}
