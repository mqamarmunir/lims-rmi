using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBlSpecimenOutQueue
    {
        public clsBlSpecimenOutQueue()
        {
            ///Add Constructor logic here
        }

        #region Variables
        private static string Default="~!@";
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        private string _FromDate = Default;

        
        private string _ToDate = Default;
        private string _OrgId = Default;


       
        #endregion

        #region properties
        public string OrgId
        {
            get { return _OrgId; }
            set { _OrgId = value; }
        }
        public string FromDate
        {
            get { return _FromDate; }
            set { _FromDate = value; }
        }
        public string ToDate
        {
            get { return _ToDate; }
            set { _ToDate = value; }
        }
        #endregion

        #region methods
        public DataView GetAll(int flag)
        {
            switch(flag)
            {
                case 1:
                    objdbhims.Query=@"Select distinct o.orgid,o.name as organization
from LS_TEXTORGANIZATION o inner join ls_tdtransaction d on d.extorgid=o.orgid
 where d.processid='0009' and d.enteredate between to_Date('"+_FromDate+"','dd/mm/yyyy') and to_Date('"+_ToDate+"','dd/mm/yyyy')";
                    break;
                case 2:
                    objdbhims.Query = @"select m.mSerialno,d.DSerialno,d.testid,p.prno prid,m.labid,p.PatientName PName,t.test as Test_name,to_char(m.entrydatetime,'dd-Mon-yyyy hh:mi am') enteredon,to_char(d.deliverydate,'dd-Mon-yyyy hh:mi') DeliveryDate,'RMI' as Booking_Branch from ls_tdtransaction d inner join ls_tmtransaction m on m.mserialno=d.mserialno inner join ls_vpatient p on p.MSerialNo=m.mserialno inner join ls_ttest t on t.testid=d.testid
where d.processid='0009' and d.extorgid=" + _OrgId + " and m.entrydatetime between to_Date('" + _FromDate + "','dd/mm/yyyy') and to_Date('" + _ToDate + "','dd/mm/yyyy')";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
 
        }
        #endregion

    }
}
