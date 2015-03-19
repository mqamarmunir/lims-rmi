using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLOpinion.
	/// </summary>
	public class clsBLOpinion
	{
		#region Class Variable
		private string StrErrorMessage = "";
		private string TableName = "LS_TOpinion";
		private const string Default = "~!@";
		private string StrActive = Default;

        private string _opinionid = Default;

        
        private string _personid = Default;


        private string _testid = Default;

		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Properties"
        public string Opinionid
        {
            get { return _opinionid; }
            set { _opinionid = value; }
        }
        public string Testid
        {
            get { return _testid; }
            set { _testid = value; }
        }

        public string Personid
        {
            get { return _personid; }
            set { _personid = value; }
        }

		public string ErrorMessage
		{
			get	{ return StrErrorMessage; }
			set { StrErrorMessage = value; }
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		#endregion

		public clsBLOpinion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void AddOpinion(string personID, string testID, string opinion)
		{
			objTrans.Start_Transaction();
			QueryBuilder objQB = new QueryBuilder();
			objdbhims.Query = objQB.QBGetMax("OpinionID", TableName, "5");
			long opinionID = long.Parse(objTrans.DataTrigger_Get_Max(objdbhims));
			
			objdbhims.Query = "insert into "+TableName+" values("+opinionID+", '"+
				testID+"', '"+opinion+"', '"+personID+"')";

			StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
			objTrans.End_Transaction();
		}

		public void UpdateOpinion(long OpinionID, string Opinion,string testID,string personID)
		{
			objTrans.Start_Transaction();
			objdbhims.Query = "update "+TableName+" set Opinion='"+
				Opinion+"' where OpinionID="+OpinionID+" and testid='"+testID+"' and personid='"+personID+"' ";

			StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
			objTrans.End_Transaction();
		}

		public DataView GetAll(string personID, string testID, string condition)
		{
			string query = "Select v.OpinionID, v.Opinion, t.Test, p.Title||' '||p.FName||' '||NVL(p.MName, '')||' '||NVL(p.LName, '') As PersonName From LS_TOpinion v, LS_TTest t, TPersonnel p Where v.TestID = t.TestID And v.PersonID = p.PersonID And v.personid='"+personID+"' and v.testid='"+testID+"' ";
			if(!condition.Equals("All~!@"))
				query += "and opinion like '%"+condition+"%' ";
			query += "order by opinion";
			objdbhims.Query = query;
			DataView dvOpinion = objTrans.DataTrigger_Get_All(objdbhims);
			DataRow row = dvOpinion.Table.NewRow();
			row["OpinionID"] = 0;
			row["PersonName"] = "";
			row["Test"] = "";
			row["Opinion"] = "";
			dvOpinion.Table.Rows.Add(row);

			return dvOpinion;
		}
        public bool deleteopinion()
        {
            objdbhims.Query = "delete from " + TableName + " where opinionid=" + Opinionid.Trim() + " and personid=" + _personid + " and Testid=" + _testid;
            objTrans.Start_Transaction();
            StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
            if (StrErrorMessage.Equals("True"))
            {
                StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
            }
            else
            {
                objTrans.End_Transaction();
                return true;
            }

        }


	}
}
