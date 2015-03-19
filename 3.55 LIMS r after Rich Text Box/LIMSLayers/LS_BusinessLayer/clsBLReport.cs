using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLReport.
	/// </summary>
	public class clsBLReport
	{
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		
		public clsBLReport(){}

		public DataView GetReport(string reportID)
		{
			string query = "Select * From PreferenceTable Where ReportNo = '" + reportID + "'";

			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		public DataView GetTestReportType()
		{
			string query = "Select p.ReportNo, p.ReportDesc From PreferenceTable p Where LIMSTestReports = 'Y'";

			objdbhims.Query = query;
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
	}
}
