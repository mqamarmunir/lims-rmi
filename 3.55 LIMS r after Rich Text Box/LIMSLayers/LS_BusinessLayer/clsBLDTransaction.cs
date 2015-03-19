using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLDTransaction.
	/// </summary>
	public class clsBLDTransaction
	{
		public clsBLDTransaction()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDTransaction";
		private string StrErrorMessage = "";
		
		private string StrDSerialNo = Default;
		private string StrMSerialNo = Default;
		private string StrTestID = Default;
		private string StrTimes = Default;
		private string StrDeptTestNo = Default;
		private string StrDeptID = Default;
		private string StrSectionID = Default;
		private string StrTestGroupID = Default;
		private string StrCharges = Default;
		private string StrDeliveryDate = Default;
		private string StrProcedureID = Default;
		private string StrProcessID = Default;
		private string StrEnteredBy = Default;
		private string StrEnteredDateTime = Default;
		private string StrEnteredAt = Default;
		private string StrRSerialNo = Default;
		private string StrNoPrint = Default;
		private string StrSpecimenCollection = Default;
		private string StrWorkListNo = Default;
		
		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string DSerialNo
		{
			get{	return StrDSerialNo;	}
			set{	StrDSerialNo = value;	}
		}
		public string MSerialNo
		{
			get{	return StrMSerialNo;	}
			set{	StrMSerialNo = value;	}
		}
		public string TestID
		{
			get{	return StrTestID;	}
			set{	StrTestID = value;	}
		}
		public string Times
		{
			get{	return StrTimes;	}
			set{	StrTimes= value;	}
		}
		
		public string DeptTestNo
		{
			get{	return StrDeptTestNo;	}
			set{	StrDeptTestNo = value;	}
		}
		public string DeptID
		{
			get{	return StrDeptID;	}
			set{	StrDeptID = value;	}
		}
		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}
		public string TestGroupID
		{
			get{	return StrTestGroupID;	}
			set{	StrTestGroupID = value;	}
		}
		public string Charges
		{
			get{	return StrCharges;	}
			set{	StrCharges = value;	}
		}
		public string DeliveryDate
		{
			get{	return StrDeliveryDate;	}
			set{	StrDeliveryDate = value;	}
		}			
		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}			
		public string ProcessID
		{
			get{	return StrProcessID;	}
			set{	StrProcessID = value;	}
		}			
		public string EnteredBy
		{
			get{	return StrEnteredBy;	}
			set{	StrEnteredBy = value;	}
		}			
		public string EnteredDateTime
		{
			get{	return StrEnteredDateTime;	}
			set{	StrEnteredDateTime = value;	}
		}						
		public string EnteredAt
		{
			get{	return StrEnteredAt;	}
			set{	StrEnteredAt = value;	}
		}				
		public string RSerialNo
		{
			get{	return StrRSerialNo;	}
			set{	StrRSerialNo = value;	}
		}				
		public string NoPrint
		{
			get{	return StrNoPrint;	}
			set{	StrNoPrint = value;	}
		}				
		public string SpecimenCollection
		{
			get{	return StrSpecimenCollection;	}
			set{	StrSpecimenCollection = value;	}
		}				
		public string WorkListNo
		{
			get{	return StrWorkListNo;	}
			set{	StrWorkListNo = value;	}
		}				
		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public string Insert(clsoperation trans)
		{
			if(Validate())
			{

				QueryBuilder objQB = new QueryBuilder();
				
				objdbhims.Query = objQB.QBGetMax("DSerialNo", TableName, "15");
				this.StrDSerialNo = trans.DataTrigger_Get_Max(objdbhims);
				
				if(!this.StrDSerialNo.Equals("True"))
				{
					return objQB.QBInsert(MakeArray(), TableName);
				}
				else
				{
					this.StrErrorMessage = trans.OperationError;
				}

				return objQB.QBInsert(MakeArray(), TableName);
			}
			else
			{
				return "";
			}
		}

		public string Update()
		{
			if(Validate())
			{
				QueryBuilder objQB = new QueryBuilder();

				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				
				return objQB.QBInsert(MakeArray(), TableName);
			}
			else
			{
				return "";
			}
		}

		public bool UpdateReLocation()
		{		
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();
			objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
			this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
			objTrans.End_Transaction();

			if(this.StrErrorMessage.Equals("True"))
			{
				this.StrErrorMessage = objTrans.OperationError;
				return false;
			}
			else
			{
				return true;
			}					
		}

		public bool UpdateToArchived(string[] aryArchive)
		{
			clsoperation objTrans2 = new clsoperation();
			objTrans2.Start_Transaction();
			QueryBuilder objQB = new QueryBuilder();

			for(int counter = 0; counter < aryArchive.GetUpperBound(0); counter++)
			{
				if(aryArchive[counter] != null)
				{
					StrDSerialNo = aryArchive[counter];
					StrProcessID = "0007";
					objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
					StrErrorMessage = objTrans2.DataTrigger_Update(objdbhims);

					if(StrErrorMessage.Equals("True"))
					{
						objTrans2.End_Transaction();
						StrErrorMessage = objTrans2.OperationError;
						return false;
					}
				}
				else
				{
					objTrans2.End_Transaction();
					return true;
				}
			}
			
			objTrans2.End_Transaction();
			return true;
		}

		public string Delete()
		{
			string query = "delete from ls_tdtransaction where mserialno="+MSerialNo+
				" and dserialno="+DSerialNo;
			
			return query;
		}

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					/*objdbhims.Query = "Select * from LS_TMTransaction Where Upper(Method) like '%'||'" + StrMethod.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";*/
					break;

				case 2:
					/*objdbhims.Query = "Select * from LS_TMTransaction Where Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";*/
					break;

				case 3:
					/*				objdbhims.Query = "Select * from LS_TMTransaction Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";*/
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[18,3];

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "DSerialNo";
				aryLIMS[0,1] = this.StrDSerialNo;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[1,0] = "MSerialNo";
				aryLIMS[1,1] = this.StrMSerialNo;
				aryLIMS[1,2] = "int";
			}

			if(!this.StrTestID.Equals(Default))
			{
				aryLIMS[2,0] = "TestID";
				aryLIMS[2,1] = this.StrTestID;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrTimes.Equals(Default))
			{
				aryLIMS[3,0] = "Times";
				aryLIMS[3,1] = this.StrTimes;
				aryLIMS[3,2] = "int";
			}

			if(!this.StrDeptTestNo.Equals(Default))
			{
				aryLIMS[4,0] = "TestNo";
				aryLIMS[4,1] = this.StrDeptTestNo;
				aryLIMS[4,2] = "string";
			}

			/*if(!this.StrDeptID.Equals(Default))
			{
				aryLIMS[5,0] = "DeptID";
				aryLIMS[5,1] = this.StrDeptID;
				aryLIMS[5,2] = "string";
			}*/
			if(!this.StrSectionID.Equals(Default))
			{
				aryLIMS[5,0] = "SectionID";
				aryLIMS[5,1] = this.StrSectionID;
				aryLIMS[5,2] = "string";
			}
			if(!this.StrCharges.Equals(Default))
			{
				aryLIMS[6,0] = "Charges";
				aryLIMS[6,1] = this.StrCharges;
				aryLIMS[6,2] = "int";
			}
			if(!this.StrDeliveryDate.Equals(Default))
			{
				aryLIMS[7,0] = "DeliveryDate";
				aryLIMS[7,1] = this.StrDeliveryDate;
				aryLIMS[7,2] = "date";
			}
			if(!this.StrProcedureID.Equals(Default))
			{
				aryLIMS[8,0] = "ProcedureID";
				aryLIMS[8,1] = this.StrProcedureID;
				aryLIMS[8,2] = "string";
			}
			if(!this.StrProcessID.Equals(Default))
			{
				aryLIMS[9,0] = "ProcessID";
				aryLIMS[9,1] = this.StrProcessID;
				aryLIMS[9,2] = "string";
			}
			if(!this.StrEnteredBy.Equals(Default))
			{
				aryLIMS[10,0] = "EnteredBy";
				aryLIMS[10,1] = this.StrEnteredBy;
				aryLIMS[10,2] = "string";
			}
			if(!this.StrEnteredDateTime.Equals(Default))
			{
				aryLIMS[11,0] = "EnterEDate";
				aryLIMS[11,1] = this.StrEnteredDateTime;
				aryLIMS[11,2] = "date";
			}
			if(!this.StrEnteredAt.Equals(Default))
			{
				aryLIMS[12,0] = "EnteredAt";
				aryLIMS[12,1] = this.StrEnteredAt;
				aryLIMS[12,2] = "date";
			}
			if(!this.StrRSerialNo.Equals(Default))
			{
				aryLIMS[13,0] = "RSerialNo";
				aryLIMS[13,1] = this.StrRSerialNo;
				aryLIMS[13,2] = "int";
			}					
			if(!this.StrNoPrint.Equals(Default))
			{
				aryLIMS[14,0] = "Print";
				aryLIMS[14,1] = this.StrNoPrint;
				aryLIMS[14,2] = "string";
			}		
			if(!this.StrSpecimenCollection.Equals(Default))
			{
				aryLIMS[15,0] = "SpecimenCollected";
				aryLIMS[15,1] = this.StrSpecimenCollection;
				aryLIMS[15,2] = "string";
			}
			if(!this.StrWorkListNo.Equals(Default))
			{
				aryLIMS[16,0] = "WorkListNo";
				aryLIMS[16,1] = this.StrWorkListNo;
				aryLIMS[16,2] = "int";
			}
			if(!this.StrTestGroupID.Equals(Default))
			{
				aryLIMS[17,0] = "TestGroupID";
				aryLIMS[17,1] = this.StrTestGroupID;
				aryLIMS[17,2] = "string";
			}
			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		private bool Validate()
		{
			return VD_Method();
		}

		public bool VD_Method()
		{
			Validation objValid = new Validation();

			if(this.StrCharges.Equals(""))
			{
				this.StrErrorMessage = "Please enter vaild Charges (empty is not allowed).";
				return false;
			}
			
			return true;
		}

		#endregion
	}
}
