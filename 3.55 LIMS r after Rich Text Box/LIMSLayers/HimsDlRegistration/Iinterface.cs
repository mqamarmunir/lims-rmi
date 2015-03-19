using System;
using System.Data.OleDb;


namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for IInterface.
	/// </summary>
	 public interface Iinterface
	{

		 string PKeycode
		 {
			 get;
			 set;
		 }


#region "Methods"

		 OleDbCommand Insert();
		 
		 OleDbCommand Update();

		 OleDbCommand Delete();

		 OleDbCommand Get_All();

		 OleDbCommand Get_Single();
	
#endregion
 
	 }
}
