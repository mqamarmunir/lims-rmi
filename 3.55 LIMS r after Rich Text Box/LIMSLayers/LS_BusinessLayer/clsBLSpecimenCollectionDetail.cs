using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenCollectionDetail.
	/// </summary>
	public class clsBLSpecimenCollectionDetail
	{
		public clsBLSpecimenCollectionDetail()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		private const string cProcessID = "0002";
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

        public DataView GetPendingSpecimen(string mSerialNo, string sSpecimen)
        {
            string query = "select p.MSerialNo,p.prno, td.dserialno, p.patientCompletename As patientname, '('||p.psex||') '||' '||p.paged||' '||pageu||'(s)' age, t.testid, s.sectionname, tg.testgroup, t.test, tp.process, t.specimentype||' | '||t.specimencontainer As Specimen, td.ProcedureID,t.TestID,t.RoundDelivery,t.HistoryTaking,td.Spec_Coment,p.WardName,t.External from ls_tdtransaction td, LS_vPatient p, ls_tsection s, ls_ttestgroup tg, ls_ttest t, ls_ttestprocess tp where p.mserialno = td.mserialno and s.sectionid = td.sectionid and tg.sectionid = td.sectionid and tg.testgroupid = td.testgroupid and t.sectionid = td.sectionid and t.testgroupid = td.testgroupid and t.testid = td.testid and tp.processid = td.processid and td.Procedureid = tp.Procedureid and td.ProcessID = '" + cProcessID + "' and td.mserialno=" + mSerialNo;

            if (!sSpecimen.Equals("-1"))
            {
                query += " and t.SpecimenType = '" + sSpecimen + "'";
            }

            objdbhims.Query = query;
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
	}
}
