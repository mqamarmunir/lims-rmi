using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLCourierbatches
    {
        public clsBLCourierbatches()
        {
            /// Add Constructor logic here...
        }
        #region Variables 
        private static string TableName = "LS_TCOURIERBATCHES";
        private static string Default = "~!@";
        private string _batchid = Default;
        private string _StrProcedureId = Default;
        private string _TransNo = Default;
        private string _Mserialno=Default;



        
        
        
        private string _CurrentProcessid = Default;
        private string _nextprocessid = Default;

       

        private string _batchno = Default;
        private string _labid = Default;
        private string _testid = Default;
        private string _prno = Default;
        private string _extorgid = Default;
        private string _enteredby = Default;
        private string _enteredon = Default;
        private string _Clientid = Default;
        private string _DSerialNo = Default;
        private string _ExtResultReference = Default;
        private string _DateFrom = Default;

        
        private string _DateTo = Default;

        private string _StrErrorMessage = Default;

        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();
        #endregion

        #region Properties
        public string DateTo
        {
            get { return _DateTo; }
            set { _DateTo = value; }
        }
        public string DateFrom
        {
            get { return _DateFrom; }
            set { _DateFrom = value; }
        }
        public string CurrentProcessid
        {
            get { return _CurrentProcessid; }
            set { _CurrentProcessid = value; }
        }
        public string DSerialNo
        {
            get { return _DSerialNo; }
            set { _DSerialNo = value; }
        }
        public string Mserialno
        {
            get { return _Mserialno; }
            set { _Mserialno = value; }
        }
        public string TransNo
        {
            get { return _TransNo; }
            set { _TransNo = value; }
        }
        public string Nextprocessid
        {
            get { return _nextprocessid; }
            set { _nextprocessid = value; }
        }
        public string StrProcedureId
        {
            get { return _StrProcedureId; }
            set { _StrProcedureId = value; }
        }
        public string StrErrorMessage
        {
            get { return _StrErrorMessage; }
            set { _StrErrorMessage = value; }
        }
        public string Batchid
        {
            get { return _batchid; }
            set { _batchid = value; }
        }
        public string Batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
        }
        public string Labid
        {
            get { return _labid; }
            set { _labid = value; }
        }
        public string Testid
        {
            get { return _testid; }
            set { _testid = value; }
        }
        public string Prno
        {
            get { return _prno; }
            set { _prno = value; }
        }
        public string Extorgid
        {
            get { return _extorgid; }
            set { _extorgid = value; }
        }
        public string Enteredby
        {
            get { return _enteredby; }
            set { _enteredby = value; }
        }
        public string Enteredon
        {
            get { return _enteredon; }
            set { _enteredon = value; }
        }
        public string ClientID
        {
            get { return _Clientid; }
            set { _Clientid = value; }
        }

        public string ExtResultReference
        {
            get { return _ExtResultReference; }
            set { _ExtResultReference = value; }
        }
        #endregion

        #region methods 
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"Select lpad(count(distinct batchno)+1,3,0) as MaxID 
From ls_tcourierbatches where to_char(enteredon,'yyyy/mm/dd') between '"+System.DateTime.Now.Year.ToString()+"/"+System.DateTime.Now.ToString("MM")+"/01' and '"+System.DateTime.Now.ToString("yyyy/MM/dd")+@"'
                        and clientid='005' and extorgid="+_extorgid;
                    break;
                case 2:
                    objdbhims.Query = @"select distinct batchno,to_char(enteredon,'dd-Mon-yyyy hh:mi am') as EnteredOn from Ls_Tcourierbatches where enteredon between to_date('"+_DateFrom+@"','dd/mm/yyyy') and to_date('"+_DateTo+@"','dd/mm/yyyy') order by batchno desc";
                    break;
                case 3:
                    objdbhims.Query = "Select Doc_Path from ls_tPreferenceSettings";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        public bool Insert()
        {
            

            //System.DateTime.Now.Month.ToString();
            //System.DateTime.Now.Year.ToString();

            try
            {
                //clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBGetMax("BatchId", TableName);
                this._batchid = objTrans.DataTrigger_Get_Max(objdbhims);

                if (this._batchid.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);



                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                clsBLTestProcess objTEstProcess = new clsBLTestProcess();
                _nextprocessid = objTEstProcess.GetNextProcessID(StrProcedureId, _CurrentProcessid);
                objTEstProcess = null;
                objdbhims.Query = "update ls_tdtransaction set processid='" + _nextprocessid + "' where DSerialNo=" + _DSerialNo;
                StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objdbhims.Query = objQB.QBGetMax("transno", "ls_ttranshistory", "8");
                //objtrans_transhistory.Start_Transaction();
                this._TransNo = objTrans.DataTrigger_Get_Max(objdbhims);
                // objtrans_transhistory.End_Transaction();

                if (this._TransNo.Equals("True"))
                {
                    StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    // objtrans = null;
                    return false;
                }
                objdbhims.Query = "Insert into ls_ttranshistory Values(" + _TransNo + "," + _enteredby + ",'0009',to_date('" + _enteredon + "','dd/mm/yyyy hh:mi:ss am')," + Mserialno + "," + _DSerialNo + ")";
                _StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objTrans.End_Transaction();
                return true;


            }
            catch (Exception e)
            {
                this.StrErrorMessage = e.Message;
                return false;
            }
            
            
        }
        public bool UpdateRecieved()
        {
            try
            {
                //clsoperation objTrans = new clsoperation();
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();
                clsBLTestProcess objTEstProcess = new clsBLTestProcess();
                _nextprocessid = objTEstProcess.GetNextProcessID(StrProcedureId, _CurrentProcessid);
                objTEstProcess = null;
                objdbhims.Query = "update ls_tdtransaction set processid='" + _nextprocessid + "',EXT_RESULT_REFERENCE='" + _ExtResultReference +"'  where DSerialNo=" + _DSerialNo;
                StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objdbhims.Query = objQB.QBGetMax("transno", "ls_ttranshistory", "8");
                //objtrans_transhistory.Start_Transaction();
                this._TransNo = objTrans.DataTrigger_Get_Max(objdbhims);
                // objtrans_transhistory.End_Transaction();

                if (this._TransNo.Equals("True"))
                {
                    StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    // objtrans = null;
                    return false;
                }
                objdbhims.Query = "Insert into ls_ttranshistory Values(" + _TransNo + "," + _enteredby + ",'"+CurrentProcessid+"',to_date('" + _enteredon + "','dd/mm/yyyy hh:mi:ss am')," + Mserialno + "," + _DSerialNo + ")";
                _StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
                objTrans.End_Transaction();
                return true;


            }
            catch (Exception e)
            {
                this.StrErrorMessage = e.Message;
                return false;
            }
        }
        private string[,] MakeArray()
        {
            string[,] arySAPS = new string[10, 3];

            if (!this._batchid.Equals(Default))
            {
                arySAPS[0, 0] = "BatchID";
                arySAPS[0, 1] = this._batchid;
                arySAPS[0, 2] = "int";
            }

            if (!this._batchno.Equals(Default))
            {
                arySAPS[1, 0] = "Batchno";
                arySAPS[1, 1] = this._batchno;
                arySAPS[1, 2] = "string";
            }

            if (!this._labid.Equals(Default))
            {
                arySAPS[2, 0] = "labid";
                arySAPS[2, 1] = this._labid;
                arySAPS[2, 2] = "string";
            }

            if (!this._testid.Equals(Default))
            {
                arySAPS[3, 0] = "TestID";
                arySAPS[3, 1] = this._testid;
                arySAPS[3, 2] = "string";
            }

            if (!this._prno.Equals(Default))
            {
                arySAPS[4, 0] = "prno";
                arySAPS[4, 1] = this._prno;
                arySAPS[4, 2] = "string";
            }

            if (!this._enteredby.Equals(Default))
            {
                arySAPS[5, 0] = "Enteredby";
                arySAPS[5, 1] = this._enteredby;
                arySAPS[5, 2] = "string";
            }

            if (!this._enteredon.Equals(Default))
            {
                arySAPS[6, 0] = "Enteredon";
                arySAPS[6, 1] = this._enteredon;
                arySAPS[6, 2] = "date";
            }

            

            if (!this._Clientid.Equals(Default))
            {
                arySAPS[7, 0] = "ClientId";
                arySAPS[7, 1] = this._Clientid;
                arySAPS[7, 2] = "string";
            }
           
            
            if (!this._extorgid.Equals(Default))
            {
                arySAPS[8, 0] = "extorgid";
                arySAPS[8, 1] = this._extorgid;
                arySAPS[8, 2] = "int";
            }
            if (!this._DSerialNo.Equals(Default))
            {
                arySAPS[9, 0] = "DSerialNo";
                arySAPS[9, 1] = this._DSerialNo;
                arySAPS[9, 2] = "int";
            }
           

            return arySAPS;
        }
        #endregion
    }
}
