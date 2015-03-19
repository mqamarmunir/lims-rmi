using System;
using System.Data;
using System.Collections;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPaymentMode.
	/// </summary>
	public class clsBLPaymentMode
	{
		private DataTable tblMode;
		public clsBLPaymentMode()
		{
			tblMode = new DataTable("paymentMode");
			tblMode.Columns.Add("ID");
			tblMode.Columns.Add("Data");

			AddRow("C", "By Cash");
			AddRow("H", "By Check");
			AddRow("B", "By Bill");
			AddRow("R", "By Credit Card");
			AddRow("N", "None");
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
