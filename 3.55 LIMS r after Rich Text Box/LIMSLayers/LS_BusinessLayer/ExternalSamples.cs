using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;
using LS_BusinessLayer.OliveService;

namespace LS_BusinessLayer
{
    public class ExternalSamples
    {
        public ExternalSamples()
        { }
        private static string Default = "~!@";
        private string _MserialNo = Default;

       
        private string _DSerialNo = Default;
        private string _CliqorderID = Default;
        private string _processId = Default;
        private string _cprocessid = Default;
        private string _cliqprocessid = Default;
        private string _ErrorMessage = Default;
        private string _TransNo = Default;
        private string _EnteredBy = Default;

       
        

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        QueryBuilder QB = new QueryBuilder();
      

        

        #region Properties
        public string EnteredBy
        {
            get { return _EnteredBy; }
            set { _EnteredBy = value; }
        }
        public string TransNo
        {
            get { return _TransNo; }
            set { _TransNo = value; }
        }
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        public string MserialNo
        {
            get { return _MserialNo; }
            set { _MserialNo = value; }
        }
        public string DSerialNo
        {
            get { return _DSerialNo; }
            set { _DSerialNo = value; }
        }
        public string CliqorderID
        {
            get { return _CliqorderID; }
            set { _CliqorderID = value; }
        }
        public string processId
        {
            get { return _processId; }
            set { _processId = value; }
        }
        public string cprocessid
        {
            get { return _cprocessid; }
            set { _cprocessid = value; }
        }
        public string cliqprocessid
        {
            get { return _cliqprocessid; }
            set { _cliqprocessid = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
             case 1:
                    objdbhims.Query = @"SELECT distinct m.mserialno,d.dserialno,m.labid,m.cliqvisitno,m.cliqcheckinid,nvl(d.cliqorderid,0) as cliqorderid,p.patientCompletename,to_char(m.entrydatetime,'dd/mm/yyyy hh:mi:ss am') entrydatetime,to_char(d.deliverydate,'dd/mm/yyyy hh:mi:ss am') deliverydate,o.name as Origin,t.test
from ls_tmtransaction m inner join ls_tdtransaction d on d.mserialno=m.mserialno
inner join ls_vpatient p on p.MSerialNo=m.mserialno
inner join ls_ttest t on t.testid=d.testid
left outer join ls_textorganization o on o.cliqbranchid=m.originplaceid
where d.processid='0011'
order by d.Dserialno desc";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Update()
        {
            try
            {
                objTrans.Start_Transaction();
                objdbhims.Query = QB.QBUpdate(MakeArray(), "ls_tdtransaction");
                _ErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (_ErrorMessage.Equals("True"))
                {
                    this._ErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objdbhims.Query = QB.QBGetMax("transno", "ls_ttranshistory", "8");
                //objtrans_transhistory.Start_Transaction();
                this._TransNo = objTrans.DataTrigger_Get_Max(objdbhims);
                // objtrans_transhistory.End_Transaction();

                if (this._TransNo.Equals("True"))
                {
                    _ErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    // objtrans = null;
                    return false;
                }
                objdbhims.Query = @"insert into ls_ttranshistory
                                              (transno, personid, processid, entdatetime, mserialno, dserialno)
                                            values
                                              ('" + this._TransNo + "', '" + this._EnteredBy + "', '"+_cprocessid+"', to_date('" + System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + "','dd/MM/yyyy hh:mi:ss AM'), '" + this._MserialNo + "', '" + this._DSerialNo + "')";
                // objTrans_historyinsert.Start_Transaction();
                this._ErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                // objTrans_historyinsert.End_Transaction();
                if (this._ErrorMessage.Equals("True"))
                {
                    this._ErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    // o//bjTrans_historyinsert = null;
                    return false;
                }
                if (_CliqorderID != "0")
                {
                    OliveService.OliveService objService = new OliveService.OliveService();
                    if (objService.updateorderstatus(_CliqorderID, cliqprocessid) == "false")
                    {
                        this.ErrorMessage = "Some Error Occured while updating Remote server. All transaction rolled Back successfuly.";
                        objTrans.StrMsg = "True";
                        objTrans.End_Transaction();
                        return false;
                    }
                }
                
            }
            catch
            { 
            }
            objTrans.End_Transaction();
            return true;
 
        }

        private string[,] MakeArray()
        {
            string[,] aryTest = new string[2, 3];

            if (!this.DSerialNo.Equals(Default))
            {
                aryTest[0, 0] = "DSerialNo";
                aryTest[0, 1] = this.DSerialNo;
                aryTest[0, 2] = "int";
            }
            
            
           
            

            if (!this._processId.Equals(Default))
            {
                aryTest[1, 0] = "ProcessID";
                aryTest[1, 1] = _processId;
                aryTest[1, 2] = "string";
            }

           




            return aryTest;
        }
#endregion

    }
}
