using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPatientQueue.
	/// </summary>
	public class clsBLPatientQueue
	{
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		
		public clsBLPatientQueue()
		{
		}

		public DataView GetAll(string deptID, string clinicID, string serviceID, string doctorID)
		{
			string query="";
			if (!doctorID.Equals(""))
			{
				query = "select pv.visitno, pv.patientid, d.plno, "+
					"pg.title||' '||pg.pfname||' '||pg.plname patientname, "+
					"case when substr(sa.patientid,1,1)='E' then 'ENT' else 'CNE' end patienttype, "+
					"to_char(sa.datetime, 'DD/MM/YYYY HH:MI:SS AM') datetime, "+
					"fd.departmentname||':'||fc.clinicname||':'|| "+
					"per.title||' '||per.fname||' '||per.mname||' '||per.lname referrer "+
					"from servicesavailed sa, tpatientvisit pv, tpatientregistration pg, dependent d, "+
					"department fd, clinic fc, "+
					"tpersonnel per "+
					"where sa.visitno = pv.visitno "+
					"and pv.patientid = pg.patientid(+) "+
					"and sa.patientid = d.patientid(+) "+
					"and sa.departmentid = fd.departmentid "+
					"and sa.clinicid = fc.clinicid "+
					"and sa.doctorid = per.personid "+
					"and sa.departmentid='"+deptID+"' "+
					"and sa.clinicid='"+clinicID+"' "+
					"and sa.doctorid='"+doctorID+"' ";
			}
			else if(!serviceID.Equals(""))
			{
				query = "select pv.visitno, pv.patientid, "+
					"d.plno, pg.title||' '||pg.pfname||' '||pg.plname patientname, "+
					"case when substr(sa.patientid,1,1)='E' then 'ENT' else 'CNE' end patienttype, "+
					"to_char(sa.datetime, 'DD/MM/YYYY HH:MI:SS AM') datetime, "+
					"fd.departmentname||':'||fc.clinicname||':'||per.servicename referrer "+
					"from servicesavailed sa, tpatientvisit pv, tpatientregistration pg, dependent d, "+
					"department fd, clinic fc, service per "+
					"where sa.visitno = pv.visitno "+
					"and pv.patientid = pg.patientid(+) "+
					"and sa.patientid = d.patientid(+) "+
					"and sa.departmentid = fd.departmentid "+
					"and sa.clinicid = fc.clinicid "+
					"and sa.serviceid = per.serviceid "+
					"and sa.departmentid='"+deptID+"' "+
					"and sa.clinicid='"+clinicID+"' "+
					"and sa.serviceid='"+serviceID+"'";
			}
			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView GetAllLIMSPatients(string deptID)
		{
			string query="";
			//	From Doctor
			query = "select sa.TransactionCode, pv.visitno, pv.patientid, d.plno, " + 
				"NVL(pg.title, '')||' '||NVL(pg.pfname, '')||' '||NVL(pg.PMName, '')||' '||NVL(pg.plname, '') patientname, "+
				"case when substr(sa.patientid,1,1)='E' then 'ENT' else 'CNE' end patienttype, "+
				"to_char(sa.datetime, 'DD/MM/YYYY HH:MI AM') datetime, "+
				"fd.departmentname||':'||fc.clinicname||':'|| "+
				"per.title||' '||per.fname||' '||per.mname||' '||per.lname referrer "+
				"from servicesavailed sa, tpatientvisit pv, tpatientregistration pg, dependent d, "+
				"department fd, clinic fc, "+
				"tpersonnel per "+
				"where sa.visitno = pv.visitno "+
				"and pv.patientid = pg.patientid(+) "+
				"and sa.patientid = d.patientid(+) "+
				"and sa.Fromdepartmentid = fd.departmentid(+) "+
				"and sa.Fromclinicid = fc.clinicid(+) "+
				"and sa.Fromdoctorid = per.personid(+) "+
				"and sa.departmentid='"+deptID+"' ";
			
			objdbhims.Query = query;
			DataView dv1 = objTrans.DataTrigger_Get_All(objdbhims);
			//	From Service
			query = "select sa.TransactionCode, pv.visitno, pv.patientid, d.plno, " + 
				"NVL(pg.title, '')||' '||NVL(pg.pfname, '')||' '||NVL(pg.PMName, '')||' '||NVL(pg.plname, '') patientname, "+
				"case when substr(sa.patientid,1,1)='E' then 'ENT' else 'CNE' end patienttype, "+
				"to_char(sa.datetime, 'DD/MM/YYYY HH:MI AM') datetime, "+
				"fd.departmentname||':'||fc.clinicname||':'||ser.ServiceName referrer "+
				"from servicesavailed sa, tpatientvisit pv, tpatientregistration pg, dependent d, "+
				"department fd, clinic fc, "+
				"service ser "+
				"where sa.visitno = pv.visitno "+
				"and pv.patientid = pg.patientid(+) "+
				"and sa.patientid = d.patientid(+) "+
				"and sa.Fromdepartmentid = fd.departmentid(+) "+
				"and sa.Fromclinicid = fc.clinicid(+) "+
				"and sa.Fromserviceid = ser.serviceid(+) "+
				"and sa.departmentid='"+deptID+"' ";
			
			objdbhims.Query = query;
			DataView dv2 = objTrans.DataTrigger_Get_All(objdbhims);

			foreach(DataRow dr2 in dv2.Table.Rows)
			{
				dv1.RowFilter = "TransactionCode = '" + dr2["TransactionCode"] + "'";

				if(dv1.Count == 0)
				{
					DataRow dr1 = dv1.Table.NewRow();

					dr1["VisitNo"] = dr2["VisitNo"].ToString();
					dr1["PatientID"] = dr2["PatientID"].ToString();
					dr1["PLNo"] = dr2["PLNo"].ToString();
					dr1["PatientName"] = dr2["PatientName"].ToString();
					dr1["PatientType"] = dr2["PatientType"].ToString();
					dr1["DateTime"] = dr2["DateTime"].ToString();
					dr1["Referrer"] = dr2["Referrer"].ToString();

					dv1.Table.Rows.Add(dr1);
				}

				dv1.RowFilter = "";
			}

			dv1.Table.AcceptChanges();
			return dv1;
		}
	}
}
