using System;
using System.Data;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLResultDespatch.
	/// </summary>
	public class clsBLResultDespatch
	{
		private DataTable tblMode;
		public clsBLResultDespatch()
		{
			tblMode = new DataTable("resultDespatch");
			tblMode.Columns.Add("ID");
			tblMode.Columns.Add("Data");

			AddRow("S", "By Self Collection");
			AddRow("L", "By Land Mail");
			AddRow("E", "By Email");
			AddRow("M", "By SMS");
		}
		
		private void AddRow(string id, string data)
		{
			object[] row = new object[2];
			row[0] = id;
			row[1] = data;
			tblMode.Rows.Add(row);
		}

		public DataView GetAll()
		{
			return new DataView(tblMode);
		}
	}
}
