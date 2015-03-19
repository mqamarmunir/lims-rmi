using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPatientStatus.
	/// </summary>
	public class clsBLPatientStatus
	{

		public clsBLPatientStatus()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		
		public DataView GetAll()
		{
			string query = "select mserialno, p.patientCompletename As patientname, "+
				"psex, paged||' '||pageun age, serviceno "+
				"from LS_vPatient p ";
			
			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		public DataView GetAll(string sectionID, string testGroupID, string sex, string patient, string recNoFrom, string recNoTo)
		{
			string query = "select p.mserialno, p.patientCompletename As patientname, "+
				"psex, paged||' '||pageu||'(s)' age, serviceno "+
				"from LS_vPatient p, ls_tdtransaction td "+
				"where p.mserialno = td.mserialno ";

			if(!sectionID.Equals("-1"))
				query += "and td.sectionid='"+sectionID+"' ";
			if(!testGroupID.Equals("-1") && !testGroupID.Equals(""))
				query += "and td.testgroupid='"+testGroupID+"' ";
			if(!sex.Equals("-1"))
				query += "and p.psex='"+sex+"' ";
			if(!patient.Equals(""))
				query += "and p.ptitle||' '||p.pfname||' '||p.pmname||' '||p.plname like '%"+
					patient+"%' ";
			if(!recNoFrom.Equals(""))
			{
				if(!recNoTo.Equals(""))
					query += "and (p.mserialno >= "+recNoFrom+" and p.mserialno <="+recNoTo+") ";
				else
					query += "and (p.mserialno = "+recNoFrom+")";
			}

			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView GetTestStatus(string mSerialNo)
		{
			string query = "select p.mserialno, td.DSerialNo, p.patientCompletename As patientname, '('||p.psex||') '||' '||p.paged||' '||pageu||'(s)' age, t.testid, s.sectionname, tg.testgroup, t.test, tp.process, m.LabID from ls_tmtransaction m, ls_tdtransaction td, LS_vPatient p, ls_tsection s, ls_ttestgroup tg, ls_ttest t, ls_ttestprocess tp where m.mserialno = p.mserialno and m.MSerialNo = td.MSerialNo and s.sectionid = td.sectionid and tg.sectionid = td.sectionid and tg.testgroupid = td.testgroupid and t.sectionid = td.sectionid and t.testgroupid = td.testgroupid and t.testid = td.testid and tp.processid = td.processid and td.Procedureid = tp.Procedureid and m.mserialno="+mSerialNo;
			
			/*string query = "select p.mserialno, p.ptitle||' '||p.pfname||' '||p.pmname||' '||p.plname patientname, "+
				"'('||p.psex||') '||' '||p.paged||' '||pageu||'(s)' age, "+
				"t.testid, s.sectionname, tg.testgroup, t.test, tp.process "+
				"from ls_tdtransaction td, LS_vPatient p, ls_tsection s, ls_ttestgroup tg, ls_ttest t, ls_ttestprocess tp "+
				"where p.mserialno = td.mserialno and s.sectionid = td.sectionid "+
				"and tg.sectionid = td.sectionid and tg.testgroupid = td.testgroupid "+
				"and t.sectionid = td.sectionid and t.testgroupid = td.testgroupid "+
				"and t.testid = td.testid "+
				"and tp.processid = td.processid "+
				"and td.mserialno="+mSerialNo;*/
			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
	}
}
