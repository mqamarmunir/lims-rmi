using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLVault.
	/// </summary>
	public class clsBLVault
	{
		#region Class Variable
		private string StrErrorMessage = "";
		private string TableName = "LS_TVault";
		private const string Default = "~!@";
		private string StrActive = Default;
		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Properties"

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

		public clsBLVault()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		public void AddVault(string personID, string testID, string description)
		{
			objTrans.Start_Transaction();
			QueryBuilder objQB = new QueryBuilder();
			objdbhims.Query = objQB.QBGetMax("VaultID", TableName, "2");
			long vaultID = long.Parse(objTrans.DataTrigger_Get_Max(objdbhims));
			
			objdbhims.Query = "insert into "+TableName+" values("+vaultID+", '"+
				testID+"', '"+description+"', '"+personID+"')";

			StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
			objTrans.End_Transaction();
		}

		public void UpdateVault(long vaultID, string description)
		{
			objTrans.Start_Transaction();
			objdbhims.Query = "update "+TableName+" set description='"+
				description+"' where vaultid="+vaultID;

			StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
			objTrans.End_Transaction();
		}

		public DataView GetAll(string personID, string testID, string condition)
		{
			string query = " Select v.vaultid, p.Title||' '||p.FName||' '||NVL(p.MName, '')||' '||NVL(p.LName, '') As PersonName, t.test, v.description from LS_TVault v, ls_ttest t, tpersonnel p where v.testid=t.testid and v.personid=p.personid and v.personid='" +personID+ "' and v.testid='" +testID+ "' ";
			if(!condition.Equals("All~!@"))
				query += "and v.description like '%"+condition+"%' ";
			query += "order by v.description";
			
			objdbhims.Query = query;
			DataView dvVault = objTrans.DataTrigger_Get_All(objdbhims);
			DataRow row = dvVault.Table.NewRow();
			row["VaultID"] = 0;
			row["PersonName"] = "";
			row["Test"] = "";
			row["Description"] = "";
			dvVault.Table.Rows.Add(row);

			return dvVault;
		}
	}
}