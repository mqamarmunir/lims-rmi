using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLComment
	/// </summary>
	public class clsBLComment
	{
		#region Class Variable
		private string StrErrorMessage = "";
		private string TableName = "LS_TComment";
		private const string Default = "~!@";
		private string StrActive = Default;
        private string _commentid = Default;
        private string _personid = Default;

       
        private string _testid = Default;

       
        
		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Properties"
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
        public string Commentid
        {
            get { return _commentid; }
            set { _commentid = value; }
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

		public clsBLComment()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void AddComment(string personID, string testID, string Comments)
		{
			objTrans.Start_Transaction();
			QueryBuilder objQB = new QueryBuilder();
			objdbhims.Query = objQB.QBGetMax("CommentID", TableName,"5");
			long CommentID = long.Parse(objTrans.DataTrigger_Get_Max(objdbhims));
			
			objdbhims.Query = "insert into "+TableName+" values("+CommentID+", '"+
				testID+"', '"+Comments+"', '"+personID+"')";

			StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
			objTrans.End_Transaction();
		}

		public void UpdateComment(long CommentID, string Comments,string testID, string personID) 
		{
			objTrans.Start_Transaction();
			objdbhims.Query = "update "+TableName+" set Comments='"+
				Comments+"' where CommentID="+CommentID+" and testid='"+testID+"' and personid='"+personID+"'" ;

			StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
			objTrans.End_Transaction();
		}

		public DataView GetAll(string personID, string testID, string condition)
		{
			string query = "Select distinct v.CommentID, v.Comments, t.Test, p.Title||' '||p.FName||' '||NVL(p.MName, '')||' '||NVL(p.LName, '') As PersonName From LS_TComment v, LS_TTest t, TPersonnel p Where v.TestID = t.TestID And v.PersonID = p.PersonID And  v.personid='"+personID+"' and v.testid='"+testID+"' ";
			if(!condition.Equals("All~!@"))
				query += "and Comments like '%"+condition+"%' ";
			query += "order by Comments";
			objdbhims.Query = query;
			DataView dvComment = objTrans.DataTrigger_Get_All(objdbhims);
			DataRow row = dvComment.Table.NewRow();
			row["CommentID"] = 0;
			row["PersonName"] = "";
			row["Test"] = "";
			row["Comments"] = "";
			dvComment.Table.Rows.Add(row);

			return dvComment;
		}
        public bool deletecomment()
        {
              objdbhims.Query = "delete from " + TableName + " where commentid=" + _commentid.Trim() + " and personid=" + _personid +" and Testid="+_testid;
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
