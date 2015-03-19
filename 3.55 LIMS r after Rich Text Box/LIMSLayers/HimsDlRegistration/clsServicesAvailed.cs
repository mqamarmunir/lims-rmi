using System;
using System.Data;
using System.Data.OleDb;

namespace HimsDlRegistration
{
	/// <summary>
	/// Summary description for clsServicesAvailed.
	/// </summary>
	public class clsServicesAvailed : Iinterface
	{
		public clsServicesAvailed()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variable Declaration"
		// call stored procedure name from clsdatdefinition class
		clsdatadefinition.StoredProcedure SP;

		#endregion


		#region "Variable Declaration"

		// use for string data
		private string StrData;
		private string StrTransactionCode = null;
		private string StrVisitNo = null;
		private string StrPatientID = null;
		private string StrDateTime = null;
		private string StrDepartmentID = null;
		private string StrClinicID = null;
		private string StrServiceID = null;
		private string StrDoctorID = null;
		private int IntAmount = 0;
		private string StrShowedUp = null;
		private string StrComments = null;
		private int IntGovtDiscount = 0;
		
		#endregion


		#region "Properties"

		/// <summary>
		/// Transaction Code - Primary Key (string, 10)
		/// </summary>
		public string PKeycode
		{
			get{	return StrTransactionCode;	}
			set{	StrTransactionCode = value;	}
		}

		/// <summary>
		/// Patient Visit No field (string, 10)
		/// </summary>
		public string VisitNo
		{
			get{	return StrVisitNo;	}
			set{	StrVisitNo = value;	}
		}

		/// <summary>
		/// Patient ID field (string, 11)
		/// </summary>
		public string PatientID
		{
			get{	return StrPatientID;	}
			set{	StrPatientID = value;	}
		}

		/// <summary>
		/// Visited Date Time	(Date)
		/// </summary>
		public string VisitDateTime
		{
			get{	return StrDateTime;		}
			set{	StrDateTime = value;	}
		}

		/// <summary>
		/// Department ID field (string, 4)
		/// </summary>
		public string DepartmentID
		{
			get{	return StrDepartmentID;		}
			set{	StrDepartmentID = value;	}
		}

		/// <summary>
		/// Clinic ID field (string, 3)
		/// </summary>
		public string ClinicID
		{
			get{	return StrClinicID;		}
			set{	StrClinicID = value;	}
		}

		/// <summary>
		/// Service ID field (string, 4)
		/// </summary>
		public string ServiceID
		{
			get{	return StrServiceID;	}
			set{	StrServiceID = value;	}
		}

		/// <summary>
		/// Doctor ID field	(string, 6)
		/// </summary>
		public string DoctorID
		{
			get{	return StrDoctorID;		}
			set{	StrDoctorID = value;	}
		}

		/// <summary>
		/// Amount collected by patient	(number)
		/// </summary>
		public int Amount
		{
			get{	return IntAmount;	}
			set{	IntAmount = value;	}
		}

		/// <summary>
		/// Showed Up
		/// </summary>
		public string ShowedUp
		{
			get{	return StrShowedUp;	}
			set{	StrShowedUp = value;	}
		}

		public string Comments
		{
			get{	return StrComments;	}
			set{	StrComments = value;	}
		}

		public int GovtDiscount
		{
			get{	return IntGovtDiscount;		}
			set{	IntGovtDiscount = value;	}
		}

		#endregion

		#region "Data_Methods"

		// INSERT DATA IN ServicesAvailed TABLE
		public  OleDbCommand Insert()
		{
			// Get Stored procedure name for insert ServicesAvailed table
			SP.SERVICESAVAILED = (clsdatadefinition.SPServicesAvailed)1; // 1 is used for get insert stored procedure name
			StrData = SP.SERVICESAVAILED.ToString().Replace("3",".");
		
			OleDbCommand ObjCommand = new OleDbCommand();

			ObjCommand.CommandText =StrData;
			ObjCommand.CommandType = CommandType.StoredProcedure;

			ObjCommand.Parameters.Add(new OleDbParameter("@PK_Code", OleDbType.VarChar, 10, ParameterDirection.Output, false, 0, 0, "TransactionCode", DataRowVersion.Default, null));
			ObjCommand.UpdatedRowSource = UpdateRowSource.OutputParameters;
			ObjCommand.Parameters.Add(new OleDbParameter("@MVisitNo", OleDbType.VarChar, 10, "VisitNo"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MPatientID", OleDbType.VarChar, 11, "PatientID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDateTime", OleDbType.VarChar, 19, "DateTime"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDepartmentID", OleDbType.VarChar, 4, "DepartmentID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MClinicID", OleDbType.VarChar, 3, "ClinicID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MServiceID", OleDbType.VarChar, 4, "ServiceID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MDoctorID", OleDbType.VarChar, 6, "DoctorID"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MAmount", OleDbType.Integer));
			ObjCommand.Parameters.Add(new OleDbParameter("@MShowedUp", OleDbType.VarChar, 1, "ShowedUp"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MComments", OleDbType.VarChar, 1000, "Comments"));
			ObjCommand.Parameters.Add(new OleDbParameter("@MGovtDiscount", OleDbType.Integer));
			
			ObjCommand.Parameters["@MVisitNo"].Value = this.StrVisitNo;
			ObjCommand.Parameters["@MPatientID"].Value = this.StrPatientID;
			ObjCommand.Parameters["@MDateTime"].Value = this.StrDateTime;
			ObjCommand.Parameters["@MDepartmentID"].Value = this.StrDepartmentID;
			ObjCommand.Parameters["@MClinicID"].Value = this.StrClinicID;
			ObjCommand.Parameters["@MServiceID"].Value = this.StrServiceID;
			ObjCommand.Parameters["@MDoctorID"].Value = this.StrDoctorID;
			ObjCommand.Parameters["@MAmount"].Value = this.IntAmount;
			ObjCommand.Parameters["@MShowedUp"].Value = this.StrShowedUp;
			ObjCommand.Parameters["@MComments"].Value = this.StrComments;
			ObjCommand.Parameters["@MGovtDiscount"].Value = this.IntGovtDiscount;
			
			return ObjCommand;
		}

		public OleDbCommand Update()
		{
			// TODO:  Add clsServicesAvailed.Update implementation
			return null;
		}

		public OleDbCommand Delete()
		{
			// TODO:  Add clsServicesAvailed.Delete implementation
			return null;
		}

		public OleDbCommand Get_All()
		{
			// TODO:  Add clsServicesAvailed.Get_All implementation
			return null;
		}

		public OleDbCommand Get_Single()
		{
			// TODO:  Add clsServicesAvailed.Get_Single implementation
			return null;
		}

		#endregion
	}
}