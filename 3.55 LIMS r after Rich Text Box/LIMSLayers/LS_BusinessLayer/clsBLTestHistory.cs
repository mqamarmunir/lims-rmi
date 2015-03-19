using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLTestHistory
    {
        public clsBLTestHistory()
        {
            /// Add Constructor Logic here...
        }

        #region Variables
        private const string Default = "~!@";
        private string StrTestID = Default;


        private string StrPrNo = Default;

        private string StrDSerialNo = Default;

        private string StrMSerialNo = Default;

        private string StrAge = Default;
        private string StrSex = Default;
       

     


        private string StrErrMsg = "";

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion

        #region Properties
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string PrNo
        {
            get { return StrPrNo; }
            set { StrPrNo = value; }
        }

        public string DSerialNo
        {
            get { return StrDSerialNo; }
            set { StrDSerialNo = value; }
        }
        public string MSerialNo
        {
            get { return StrMSerialNo; }
            set { StrMSerialNo = value; }
        }

        public string Age
        {
            get { return StrAge; }
            set { StrAge = value; }
        }


        public string Sex
        {
            get { return StrSex; }
            set { StrSex = value; }
        }

        public string ErrMsg
        {
            get { return StrErrMsg; }
            set { StrErrMsg = value; }
        }
        #endregion

        #region Methods

        public DataView GetAll(int flag)
        {
            string sMSerialNo = "";
            string sDSerialNo = "";
            switch (flag)
            {
                case 1:
                    objdbhims.Query = @"Select m.MSerialNo, d.DSerialNo, p.patientCompletename As PatientName,
                                        p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, 
                                        p.PType As Type,p.ServiceNo, 
                                        t.Test,trm.Opinion AS Opinions, trm.Comments,
                                        trm.History as History, LS_GetPriority(m.priority) As priority,
                                        t.ProcedureID, d.ProcessID, d.TestID, p1.PAgeinDays, p.WardName, 
                                        t.Testtype,
                                        d.Sensitivity, LS_FOrganismID(d.DSerialNo) As OrganismID, 
                                        LS_FOrganismID2(d.DSerialNo) As OrganismID2,
                                        LS_FOrganismID3(d.DSerialNo) As OrganismID3, m.LabID,
                                        d.DeliveryDate, d.TestNo, t.Acronym, m.PRNo,
                                        m.REFERREDBY,t.Preferred,m.entrydatetime as bookedon
                                        from LS_tMTransaction m, LS_tDTransaction d,
                                        LS_VPatient p, LS_VPatientAgeSex p1, LS_TTest t,
                                        LS_TTestResultM trm 
                                        Where m.MSerialNo = p.MSerialNo
                                        And m.MSerialNo = p1.MSerialNo 
                                        And m.MSerialNo = d.MSerialNo 
                                        And d.TestID = t.TestID
                                        And d.RSerialNo = trm.RSerialNo(+)
                                        and d.TestID='"+StrTestID+@"'
                                        and trim(m.Prno)='"+StrPrNo+@"'
                                        and d.ProcessID in('0006','0007')
                                        order by m.entrydatetime";
                    break;
                case 2:
                    objdbhims.Query = "Select trm.DSerialNo, trd.AttributeID, ta.Attribute, trd.Result, trd.MinRange, trd.MaxRange, trd.MinRange||'-'||trd.MaxRange AS Range, FGetResultState(trd.Result, trd.MinRange, trd.MaxRange, trd.MinPValue, trd.MaxPValue) as ResultState, trd.RUnit, trd.RPrint, ta.SMLine, ta.InputType, trd.MinPValue, trd.MaxPValue,ta.ATTRIBUTETYPE,ta.DERIVED,ta.Acronym from LS_TTestResultM trm,LS_TTestResultD trd, LS_TTestAttribute ta, LS_TDTransaction d Where trm.RSerialNo = trd.RSerialNo And trd.AttributeID = ta.AttributeID And trm.DSerialNo = d.DSerialNo And trm.RSerialNo = d.RSerialNo And ta.Active = 'Y' And trm.DSerialNo = '" + StrDSerialNo + "' Order By ta.DOrder";
                    break;

                case 3:
                    if (!this.MSerialNo.Equals(Default))
                    { sMSerialNo = " And m.MSerialNo = '" + MSerialNo + "' "; }
                    if (!this.DSerialNo.Equals(Default))
                    { sDSerialNo = " And d.DSerialNo = '" + DSerialNo + "' "; }

                    objdbhims.Query = "Select m.MSerialNo, d.DSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type,  p.ServiceNo, t.Test,trm.Opinion AS Opinions, trm.Comments, LS_GetPriority(m.priority) As priority, t.ProcedureID, d.ProcessID, d.TestID TestID, p1.PAgeinDays, p.WardName, t.Testtype, d.Sensitivity, LS_FOrganismID(d.DSerialNo) As OrganismID, LS_FOrganismID2(d.DSerialNo) As OrganismID2,LS_FOrganismID3(d.DSerialNo) As OrganismID3, m.LabID, d.DeliveryDate, d.TestNo, t.Acronym, m.PRNo, m.REFERREDBY,t.Preferred from LS_tMTransaction m, LS_tDTransaction d, LS_VPatient p, LS_VPatientAgeSex p1, LS_TTest t,LS_TTestResultM trm Where m.MSerialNo = p.MSerialNo And m.MSerialNo = p1.MSerialNo And m.MSerialNo = d.MSerialNo And m.MStatus  = 'A' And d.TestID = t.TestID And d.RSerialNo = trm.RSerialNo (+) " + sDSerialNo + sMSerialNo + "order by t.DOrder";
                    break;
                case 4:
                    objdbhims.Query = @"Select tm.Method,tt.d_methodid,d.DSerialNo, a.AttributeID, a.Attribute , LS_FInterfacedValue(a.interfaceid, d.mserialno) As Result,
                                        a.TestGroupID, a.SectionID, a.InputType,  a.Dorder, ar.MethodID, ar.Sex, ar.AgeMin, ar.AgeMax, ar.MinValue AS MinRange, ar.MaxValue AS MaxRange,    
                                        ar.MinPValue, ar.MaxPValue, ar.MinValue||'-'||ar.MaxValue AS Range,
                                        0 as ResultState, ar.AUnit As RUnit, ar.TransID, a.RPrint, a.SMLine,a.ATTRIBUTETYPE,a.DERIVED,a.Acronym 
                                        From LS_TTestAttribute a,ls_TMethod tm, LS_TAttributeRange ar, LS_TDTransaction d,ls_TTest tt
                                        Where a.AttributeID = ar.AttributeID 
                                        And a.TestID = d.TestID 
                                        And tt.TestID=a.TestID 
                                        And ar.methodid=tt.d_methodid
                                        and ar.methodid=tm.methodid 
                                        and a.Active ='Y' 
                                        And d.DSerialNo ='" + StrDSerialNo + @"'
                                        And ar.TransID in 
                                        (Select TransID 
                                        from LS_TAttributeRange 
                                        Where (Sex ='" + StrSex + @"' or Sex = 'All') 
                                        And ('" + StrAge + @"' between AgeMin And AgeMax)) 
                                        Order By a.Dorder";//
                    break;

            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        #endregion

    }
}
