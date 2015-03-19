using System;
using System.Data;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLRelationShip.
	/// </summary>
	public class clsBLRelationShip
	{
		private DataTable tblMode;
		public clsBLRelationShip()
		{
			// maximum length is 10
			tblMode = new DataTable("relationship");
			tblMode.Columns.Add("ID");
			tblMode.Columns.Add("Data");
			
			AddRow("Self", "Self");
			AddRow("F/O", "F/O");
			AddRow("M/O", "M/O");
			AddRow("H/O", "H/O");
			AddRow("W/O", "W/O");
			AddRow("S/O", "S/O");
			AddRow("D/O", "D/O");
//			AddRow("SVT/O", "SVT/O");
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
