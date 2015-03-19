using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlPatienttesthistory
    {
        public clsBlPatienttesthistory()
        {
            /// Add Constructor logic here...
        }


        #region Variables
        private const string Default="~!@";
        private string StrPrNo = Default;
        private string StrErrMessage = "";

    
      
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string PrNo
        {
            get { return StrPrNo; }
            set { StrPrNo = value; }
        }
        public string ErrMessage
        {
            get { return StrErrMessage; }
            set { StrErrMessage = value; }
        }
        #endregion

        #region methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From LS_TMTransaction where trim(PrNo)='" + StrPrNo.Trim() + "'";
                    break;
                case 2:
                    objdbhims.Query = @"Select salutation||' '||Fname||' '||Mname||' '||lname as Name,
                                        case when sex='F'
                                          then 'Female'
                                            else
                                              'Male'
                                              end as gender,DOb,Haddress,CellPhone
                                         From whims2.Pr_tPatientReg where prno='"+StrPrNo+"'";
                    break;
                case 3:
                    objdbhims.Query = @"Select  td.TestID,tt.Test,count(td.TestID) as testcount
                                         From Ls_TdTransaction td,Ls_TmTransaction tm,LS_TTest tt
                                         where td.MserialNo=tm.Mserialno
                                         and td.TestID=tt.TestID 
                                         and trim(tm.PrNo)='"+StrPrNo+@"'
                                         and td.processID in ('0006','0007')
                                         group by td.Testid,tt.Test
                                         order by testcount desc";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        #endregion
    }
}
