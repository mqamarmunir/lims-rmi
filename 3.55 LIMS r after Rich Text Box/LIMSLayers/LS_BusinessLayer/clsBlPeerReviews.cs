using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlPeerReviews
    {
        public clsBlPeerReviews()
        {
            /// Add Constructor logic here...
        }

        #region Variables
        private const string TableName = "Ls_TpeerReviews";
        private const string Default = "~!@";
        
        private string _ReviewID = Default;
        private string _ReferredBy = Default;
        private string _ReferredTo = Default;
        private string _Comments = Default;
        private string _EnteredBy = Default;
        private string _EnteredOn = Default;
        private string _ClientID= Default;
        private string _System_Ip = Default;
        private string _Reviewed = Default;
        private string _DSerialNo = Default;

      
        private string StrErrorMessage = "";

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();


        #endregion

        #region properties
        public string ReviewID
        {
            get { return _ReviewID; }
            set { _ReviewID = value; }
        }
        public string ReferredBy
        {
            get { return _ReferredBy; }
            set { _ReferredBy = value; }
        }
        public string ReferredTo
        {
            get { return _ReferredTo; }
            set { _ReferredTo = value; }
        }
        public string Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
        public string EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }
        public string EnteredOn
        {
            get { return _EnteredOn; }
            set { _EnteredOn = value; }
        }
        public string ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }
        public string System_Ip
        {
            get { return _System_Ip; }
            set { _System_Ip = value; }
        }
        public string Reviewed
        {
            get { return _Reviewed; }
            set { _Reviewed = value; }
        }
        public string DSerialNo
        {
            get { return _DSerialNo; }
            set { _DSerialNo = value; }
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
                    objdbhims.Query = @"Select pv.Reviewid,
                                           t.test,
                                           p.salutation || p.fname || ' ' || p.mname ReferredBy,
                                           m.labid,
                                           pv.referredto,pv.DSerialNo
                                      From ls_tpeerreviews pv
                                     Inner join Ls_Tdtransaction d
                                        on d.Dserialno = pv.Dserialno
                                     Inner join ls_tmtransaction m
                                        on m.Mserialno = d.mserialno
                                     Inner Join Ls_Ttest t
                                        on t.TestID = d.testid
                                     Inner join whims2.Hr_Tpersonnel p
                                        on p.personid = pv.referredby

                                     where pv.Referredto = '"+_ReferredTo+@"'
                                       and pv.Reviewed = 'N'";
                    break;
                case 2:

                    objdbhims.Query = @"Select distinct trm.methodID,trm.DSerialNo, trd.AttributeID, ta.Attribute,NVL(trd.runit,'-') Unit,
                                         trd.Result, trd.MinRange, trd.MaxRange,
                                          trd.MinRange||'-'||trd.MaxRange AS Range, 
                                          FGetResultState(trd.Result, trd.MinRange, trd.MaxRange, trd.MinPValue, trd.MaxPValue) as ResultState, 
                                          trd.RUnit, trd.RPrint, ta.SMLine, ta.InputType, 
                                          trd.MinPValue,
                                           trd.MaxPValue

                                           from LS_TTestResultM trm,LS_TTestResultD trd,
                                           LS_TTestAttribute ta, LS_TDTransaction d,ls_ttestmethod tm,
                                           Ls_Tattributerange ar
                                           Where trm.RSerialNo = trd.RSerialNo 
                                           And trd.AttributeID = ta.AttributeID 
                                           And trm.DSerialNo = d.DSerialNo 
                                           And trm.RSerialNo = d.RSerialNo 
                                          And tm.methodId=trm.Methodid
                                          and trm.testID=tm.TestID
                                          and ar.methodID=trm.methodID
                                          and ar.Attributeid=trd.AttributeID
                                        
 
                                           And ta.Active = 'Y' 
                                           And trm.DSerialNo = '" + _DSerialNo + @"'";
//                    objdbhims.Query = @"Select  d.result, t.test, a.attribute,NVL(d.minrange||'-'||d.maxrange,'-') Range,NVL(d.runit,'-') Unit
//
//                                          From Ls_ttestresultm m inner join
//                                           ls_ttestresultd d on m.rserialno=d.rserialno
//                                         Inner Join ls_TTest t
//                                            on t.TestID = d.testid
//                                         inner join ls_ttestattribute a
//                                            on a.attributeid = d.attributeid
//                                         where m.dserialno = " +_DSerialNo+@"
//                                          order by a.dorder";
                    break;
                case 3:
                    objdbhims.Query = @"Select pr.Comments, p.salutation || p.fname || ' ' || p.mname as EnteredBy
                                      From Ls_Tpeerreviews pr
                                     Inner Join whims2.Hr_TPersonnel p
                                        on p.PersonID = pr.Referredto

                                     where Reviewed = 'Y' and DSerialno=" + _DSerialNo;

                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();
                    objdbhims.Query = "Select NVl(max(ReviewID),0)+1 MAXID From " + TableName ;
                    //objdbhims.Query = objQB.QBGetMax("ReportConsultantID", TableName);
                    this._ReviewID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (!this._ReviewID.Equals("True"))
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
            string[,] ary_Consultant = new string[10, 3];

            if (!_ReviewID.Equals(Default))
            {
                ary_Consultant[0, 0] = "ReviewID";
                ary_Consultant[0, 1] = this._ReviewID;
                ary_Consultant[0, 2] = "int";
            }

            if (!_ReferredBy.Equals(Default))
            {
                ary_Consultant[1, 0] = "ReferredBy";
                ary_Consultant[1, 1] = this._ReferredBy;
                ary_Consultant[1, 2] = "string";
            }
            if (!_ReferredTo.Equals(Default))
            {
                ary_Consultant[2, 0] = "ReferredTo";
                ary_Consultant[2, 1] = this._ReferredTo;
                ary_Consultant[2, 2] = "string";
            }
            if (!_Comments.Equals(Default))
            {
                ary_Consultant[3, 0] = "Comments";
                ary_Consultant[3, 1] = this._Comments;
                ary_Consultant[3, 2] = "string";
            }


            if (!_EnteredBy.Equals(Default))
            {
                ary_Consultant[4, 0] = "EnteredBy";
                ary_Consultant[4, 1] = this._EnteredBy;
                ary_Consultant[4, 2] = "string";
            }
            if (!_EnteredOn.Equals(Default))
            {
                ary_Consultant[5, 0] = "EnteredOn";
                ary_Consultant[5, 1] = this._EnteredOn;
                ary_Consultant[5, 2] = "date";
            }
            if (!_ClientID.Equals(Default))
            {
                ary_Consultant[6, 0] = "ClientID";
                ary_Consultant[6, 1] = this._ClientID;
                ary_Consultant[6, 2] = "string";
            }
            if (!_System_Ip.Equals(Default))
            {
                ary_Consultant[7, 0] = "System_Ip";
                ary_Consultant[7, 1] = this._System_Ip;
                ary_Consultant[7, 2] = "string";
            }

            if (!_Reviewed.Equals(Default))
            {
                ary_Consultant[8, 0] = "Reviewed";
                ary_Consultant[8, 1] = this._Reviewed;
                ary_Consultant[8, 2] = "string";
            }
            if (!_DSerialNo.Equals(Default))
            {
                ary_Consultant[9, 0] = "DSerialNo";
                ary_Consultant[9, 1] = this._DSerialNo;
                ary_Consultant[9, 2] = "int";
            }
            return ary_Consultant;

        }
        #endregion


        #region Validations
        private bool Validation()
        {
            return true;
        }
        #endregion
    }

}
