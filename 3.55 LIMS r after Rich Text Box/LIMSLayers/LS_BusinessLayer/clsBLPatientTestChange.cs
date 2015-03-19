using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPatientTestChange.
	/// </summary>
	public class clsBLPatientTestChange
	{
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		
		private string StrErrorMessage = "";
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		public clsBLPatientTestChange()
		{
			
		}

		public DataView GetTransactionMaster(string mSerialNo)
		{
			string query = "select p.patientCompletename As patientname, p.psex, p.paged, p.pageu, p.Ptype As Type, Case When  tm.priority = 'U' Then 'Urg' When  tm.priority = 'V' Then 'VIP' Else 'Nor' end As priority from ls_tmtransaction tm, LS_vPatient p where tm.mserialno = p.mserialno and tm.mserialno = "+mSerialNo; 			
			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		public DataView GetTransactionDetail(string mSerialNo)
		{
			string query = "Select td.dserialno, s.sectionid, s.sectionname, tg.testgroupid, "+
				"tg.testgroup, t.testid, t.test, td.sectionid, td.testgroupid, td.times, td.charges, "+
				"to_char(td.deliverydate, 'dd/mm/yyyy') deliverydate, t.testbatchno "+
				"from ls_tdtransaction td, ls_ttest t, ls_tsection s, "+
				"ls_ttestgroup tg "+
				"where td.testid = t.testid and td.sectionid = t.sectionid and td.testgroupid = t.testgroupid "+
				"and td.sectionid = s.sectionid and td.sectionid = tg.sectionid "+
				"and td.testgroupid = tg.testgroupid and td.mserialno = "+mSerialNo;
			
			objdbhims.Query = query;
			DataView dt = objTrans.DataTrigger_Get_All(objdbhims);
			dt.Table.Rows.Add(dt.Table.NewRow());

			return dt;
		}

		public DataView GetAllTest(long year, string sex, string testGroupID, string sectionID)
		{
			string query = "select Distinct t.test test, t.testid "+
				"from ls_ttest t, ls_ttestattribute at, "+
				"ls_tattributerange atrg, ls_tmethod m  "+
				"where at.sectionid = t.sectionid and at.testgroupid = t.testgroupid  "+
				"and at.testid = t.testid "+
				"and atrg.sectionid = at.sectionid and atrg.testgroupid = at.testgroupid "+
				"and atrg.testid = at.testid and atrg.attributeid = at.attributeid "+ 
				"and m.sectionid = atrg.sectionid and m.methodid = atrg.methodid "+
				"and t.active = 'Y' and at.active = 'Y' "+
				"and "+year+" Between atrg.agemin and atrg.agemax and (atrg.sex='" + sex +"' or atrg.sex='All') "+
				"and t.sectionid = '" + sectionID + "' "+
				" and t.testgroupid='"+testGroupID+"' ";

			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		public DataView GetTestDetail(string testID)
		{
			clsoperation objCon = new clsoperation();
			string query = "select t.testid, to_char((sysdate + maxtime), 'dd/mm/yyyy') deliverydate, processid from ls_ttest t, "+
				"ls_ttestattribute at, ls_tattributerange atrg, ls_tmethod m, ls_ttestprocess tp "+
				"where t.sectionid = at.sectionid and t.testgroupid = at.testgroupid "+
                "and t.testid = at.testid and at.sectionid = atrg.sectionid and at.testgroupid = atrg.testgroupid "+
				"and at.testid = atrg.testid and at.attributeid = atrg.attributeid and m.methodid = atrg.methodid "+
				"and m.sectionid = atrg.sectionid and tp.procedureid = t.procedureid "+
				"and t.testid = '"+testID+"'";
			objdbhims.Query = query;
			return objCon.DataTrigger_Get_All(objdbhims);
		}
		
		public bool Save(clsBLDTransaction dTransaction)
		{
			clsoperation objCon = new clsoperation();
			
			objCon.Start_Transaction();
			clsBLTest test = new clsBLTest();
			test.TestID = dTransaction.TestID;
			DataView dvTest = test.GetAll(5);
			DataView dvOtherDetail = GetTestDetail(dTransaction.TestID);
			
			dTransaction.RSerialNo = "0";
			dTransaction.SectionID = dvTest[0]["SectionID"].ToString();
			dTransaction.TestGroupID = dvTest[0]["TestGroupID"].ToString();
			dTransaction.Charges = dvTest[0]["Charges"].ToString();
			dTransaction.DeliveryDate = dvOtherDetail[0]["DeliveryDate"].ToString();
			dTransaction.ProcedureID = dvTest[0]["ProcedureID"].ToString();
			dTransaction.ProcessID = dvOtherDetail[0]["ProcessID"].ToString();
			dTransaction.NoPrint = "N";
			dTransaction.SpecimenCollection= "N";
			dTransaction.Times = GetNextTimes(dTransaction.MSerialNo, dTransaction.TestID);
			
			string generator = dvTest[0]["TestNoGenOn"].ToString();
			string level = dvTest[0]["TestNoLevel"].ToString();
			string levelNo = "";
			if(level.Equals("S"))
				levelNo = dTransaction.SectionID;
			else if(level.Equals("G"))
				levelNo = dTransaction.TestGroupID;
			else if(level.Equals("T"))
				levelNo = dTransaction.TestID;
			dTransaction.DeptTestNo = test.GetTestNo(dTransaction.TestID, generator, objCon).ToString();
			
			// 001 is a reception process ID
			clsBLTestProcess objTTestProcess = new clsBLTestProcess();
			dTransaction.ProcessID = objTTestProcess.GetNextProcessID(dTransaction.ProcedureID, "0001");
			
			objdbhims.Query = dTransaction.Insert(objCon);
			string queryResult = objCon.DataTrigger_Insert(objdbhims);
			if(objdbhims.Query.Equals("") || queryResult.Equals("True"))
			{
				StrErrorMessage = objCon.OperationError;
				objCon.End_Transaction();
				return false;
			}
			
			objCon.End_Transaction();
			return true;
		}
		private string GetNextTimes(string mSerialNo, string testID)
		{
			clsoperation objCon = new clsoperation();
			string query = "select NVL(max(td.times), 0)+1 maxid from ls_tdtransaction td "+
				"where td.mserialno="+mSerialNo+" and td.testid = '"+testID+"'";
			
			objdbhims.Query = query;
			return objCon.DataTrigger_Get_All(objdbhims).Table.Rows[0]["maxid"].ToString();
		}
		public bool Remove(clsBLDTransaction dTransaction)
		{
			//clsoperation objCon = new clsoperation();
			objTrans.Start_Transaction();
			
			objdbhims.Query = dTransaction.Delete();
			string queryResult = objTrans.DataTrigger_Delete(objdbhims);
			if(!queryResult.Equals("False"))
			{
				
				objTrans.End_Transaction();
				StrErrorMessage = objTrans.OperationError;
				return false;
			}
			if(SetTestTime(dTransaction.MSerialNo, dTransaction.TestID, objTrans)==false)
			{
				objTrans.End_Transaction();
				StrErrorMessage = objTrans.OperationError;
				return false;
			}
			objTrans.End_Transaction();
			return true;
		}
		private bool SetTestTime(string mSerialNo, string testID, clsoperation trans)
		{
			string query = "select * from ls_tdtransaction td "+
				"where td.mserialno="+mSerialNo+" and td.testid = '"+testID+"'";
			
			objdbhims.Query = query;
			DataView dv = objTrans.Transaction_Get_All(objdbhims);

			for(int i=0; i<dv.Table.Rows.Count; i++)
			{
				query = "update ls_tdtransaction set times="+(i+1)+
					" where mserialno="+mSerialNo+" and testid='"+testID+"' "+
					"and dserialno=" + dv.Table.Rows[i]["DSerialNo"].ToString();
				
				objdbhims.Query = query;
				string queryResult = objTrans.DataTrigger_Update(objdbhims);
				if(queryResult.Equals("True"))
					return false;
			}
			return true;
		}
	}
}
