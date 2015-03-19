using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPatientHistory.
	/// </summary>
	public class clsBLPatientHistory
	{
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		private string StrErrorMessage="";

		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		public clsBLPatientHistory()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public DataView GetAll(string patientID, string departmentID, string clinicID, string doctorID, 
			string serviceID, string from, string to)
		{
			string query = "select sa.visitno, sa.patientid, "+
				"to_char(pv.visitdatetime, 'DD/MM/YYYY HH:MI:SS AM') visitdatetime, "+
				"d.departmentname||':'||c.clinicname||':'|| "+
				"case when nvl(sa.doctorid,'null')='null' then "+
				"s.servicename else p.title||' '||p.fname||' '||p.mname||' '||p.lname end referrer, "+
				"d.url "+
				"from servicesavailed sa, tpatientvisit pv, department d, clinic c, service s, tpersonnel p "+
				"where sa.patientid = pv.patientid "+
				"and sa.visitno = pv.visitno "+
				"and sa.departmentid = d.departmentid "+
				"and sa.clinicid = c.clinicid "+
				"and sa.serviceid = s.serviceid(+) "+
				"and sa.doctorid = p.personid(+) ";
            //if(!to.Equals(""))
            //    query +="and to_date(pv.visitdatetime, 'dd-mm-yy') >= to_date('"+from+"', 'dd-mm-yy') "+
            //    "and to_date(pv.visitdatetime, 'dd-mm-yy') <= to_date('"+to+"', 'dd-mm-yy') "+
            //    "and sa.patientid = '"+patientID+"' ";
            //else
            //    query +="and to_date(pv.visitdatetime, 'dd-mm-yy') = to_date('"+from+"', 'dd-mm-yy') "+
            //    "and sa.patientid = '"+patientID+"' ";
			if(!departmentID.Equals("-1"))
				query +="and sa.departmentid='"+departmentID+"' ";
			if(!clinicID.Equals("-1"))
				query +="and sa.clinicid='"+clinicID+"' ";
			if(!doctorID.Equals("-1") && !doctorID.Equals(""))
				query +="and sa.doctorid='"+doctorID+"' ";
			if(!serviceID.Equals("-1") && !serviceID.Equals(""))
				query +="and sa.serviceid='"+serviceID+"' ";
			
			query += "order by pv.visitdatetime ";
			
			objdbhims.Query = query;
			return removeRepeatation(objTrans.DataTrigger_Get_All(objdbhims), "visitdatetime");
		}
		private DataView removeRepeatation(DataView dv, string column)
		{
			string data = "";
			for(int i=0; i<dv.Table.Rows.Count; i++)
			{
				if(!dv.Table.Rows[i][column].ToString().Equals(data))
					data = dv.Table.Rows[i][column].ToString();
				else
				{
					dv.Table.Rows[i][column] = "";
				}
			}
			return dv;
		}
	}
}
