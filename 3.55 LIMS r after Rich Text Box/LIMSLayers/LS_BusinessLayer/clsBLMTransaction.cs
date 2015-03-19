using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLMTransaction.
	/// </summary>
	public class clsBLMTransaction
	{
		public clsBLMTransaction()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TMTransaction";
		private string StrErrorMessage = "";				
		
		private string StrMSerialNo = Default;
		private string StrPatientType = Default;
		private string StrPririty = Default;
		private string StrIOP = Default;
		private string StrHospitalID = Default;
		private string StrEntryDateTime = Default;
		private string StrShift = Default;
		private string StrContactNo = Default;
		private string StrEntryPerson = Default;
		private string StrClinicalNote = Default;
		private string StrDeliveryType = Default;
		private string StrDeliveryRef = Default;
		private string StrPaymentMode = Default;
		private string StrDiscountPer = Default;
		private string StrTotalAmount = Default;
		private string StrPaidAmount = Default;
		private string StrPaidNo = Default;
		private string StrReferredBy = Default;	
		private string StrMStatus = Default;
		private string StrDues = Default;

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string MSerialNo
		{
			get{	return StrMSerialNo;	}
			set{	StrMSerialNo = value;	}
		}
		public string PatientType
		{
			get{	return StrPatientType;	}
			set{	StrPatientType = value;	}
		}
		
		public string Pririty
		{
			get{	return StrPririty;	}
			set{	StrPririty = value;	}
		}

		public string IOP
		{
			get{	return StrIOP;	}
			set{	StrIOP = value;	}
		}
		public string HospitalID
		{
			get{	return StrHospitalID;	}
			set{	StrHospitalID = value;	}
		}
		public string EntryDateTime
		{
			get{	return StrEntryDateTime;	}
			set{	StrEntryDateTime = value;	}
		}
		public string Shift
		{
			get{	return StrShift;	}
			set{	StrShift = value;	}
		}
		public string ContactNo
		{
			get{	return StrContactNo;	}
			set{	StrContactNo = value;	}
		}
		public string EntryPerson
		{
			get{	return StrEntryPerson;	}
			set{	StrEntryPerson = value;	}
		}
		public string DeliveryType
		{
			get{	return StrDeliveryType;	}
			set{	StrDeliveryType = value;	}
		}			
		public string DeliveryRef
		{
			get{	return StrDeliveryRef;	}
			set{	StrDeliveryRef = value;	}
		}			
		public string PaymentMode
		{
			get{	return StrPaymentMode;	}
			set{	StrPaymentMode = value;	}
		}			
		public string DiscountPer
		{
			get{	return StrDiscountPer ;	}
			set{	StrDiscountPer = value;	}
		}
		public string TotalAmount
		{
			get{	return StrTotalAmount ;	}
			set{	StrTotalAmount = value;	}
		}
		public string PaidAmount
		{
			get{	return StrPaidAmount ;	}
			set{	StrPaidAmount = value;	}
		}
		public string PaidNo
		{
			get{	return StrPaidNo ;	}
			set{	StrPaidNo = value;	}
		}
		public string ReferredBy
		{
			get{	return StrReferredBy ;	}
			set{	StrReferredBy = value;	}
		}
		public string MStatus
		{
			get{	return StrMStatus;	}
			set{	StrMStatus = value;	}
		}					
		public string Dues
		{
			get{	return StrDues;	}
			set{	StrDues = value;	}
		}		

		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();
		int entitledIndex=-1, iopIndex=-1;

		#region "Methods"

		public string Insert(int entitledIndex, int iopIndex)
		{
			this.iopIndex = iopIndex;
			this.entitledIndex = entitledIndex;
			if(Validate())
			{
				try
				{
					objTrans.Start_Transaction();
					QueryBuilder objQB = new QueryBuilder();
					
					objdbhims.Query = objQB.QBGetMax("MSerialNo", TableName, "15");
					this.StrMSerialNo = objTrans.DataTrigger_Get_Max(objdbhims);
					objTrans.End_Transaction();
					
					if(!this.StrMSerialNo.Equals("True"))
					{
						return objQB.QBInsert(MakeArray(), TableName);
					}
					else
					{
						this.StrErrorMessage = objTrans.OperationError;
					}
				}
				catch(Exception e)
				{
					this.StrErrorMessage = e.Message;
				}
			}
			return "";
		}

		public bool Update()
		{
			if(Validate())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				//objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
				//objTrans.End_Transaction();

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
			else
			{
				return false;
			}
		}

		public bool UpdateStatus()
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();
			objdbhims.Query = objQB.QBUpdate(MakeStatusArray(), TableName);
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

		public bool UpdateDues()
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();							
			
			objTrans.Start_Transaction();
			objdbhims.Query = objQB.QBUpdate(MakeDuesArray(), TableName);
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
		

		private string[,] MakeStatusArray()
		{
			string[,] aryLIMS = new string[4,3];

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "MSerialNo";
				aryLIMS[0,1] = this.StrMSerialNo;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrMStatus.Equals(Default))
			{
				aryLIMS[1,0] = "MStatus";
				aryLIMS[1,1] = this.StrMStatus;
				aryLIMS[1,2] = "string";
			}
			
			if(!this.StrPaidAmount.Equals(Default))
			{
				aryLIMS[2,0] = "PaidAmount";
				aryLIMS[2,1] = this.StrPaidAmount;
				aryLIMS[2,2] = "number";
			}
			if(!this.StrPaidNo.Equals(Default))
			{
				aryLIMS[3,0] = "PaidNo";
				aryLIMS[3,1] = this.StrPaidNo;
				aryLIMS[3,2] = "string";
			}

			return aryLIMS;
		}

		private string[,] MakeDuesArray()
		{
			string[,] aryLIMS = new string[2,3];

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "MSerialNo";
				aryLIMS[0,1] = this.StrMSerialNo;
				aryLIMS[0,2] = "string";
			}			
			
			if(!this.StrPaidAmount.Equals(Default))
			{
				aryLIMS[1,0] = "PaidAmount";
				aryLIMS[1,1] = this.StrPaidAmount;
				aryLIMS[1,2] = "number";
			}

			return aryLIMS;
		}

		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[19,3];

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "MSerialNo";
				aryLIMS[0,1] = this.StrMSerialNo;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrPatientType.Equals(Default))
			{
				aryLIMS[1,0] = "Type";
				aryLIMS[1,1] = this.StrPatientType;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrPririty.Equals(Default))
			{
				aryLIMS[2,0] = "Priority";
				aryLIMS[2,1] = this.StrPririty;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrIOP.Equals(Default))
			{
				aryLIMS[3,0] = "IOP";
				aryLIMS[3,1] = this.StrIOP;
				aryLIMS[3,2] = "string";
			}
			if(!this.StrHospitalID.Equals(Default))
			{
				aryLIMS[4,0] = "HospitalID";
				aryLIMS[4,1] = this.StrHospitalID;
				aryLIMS[4,2] = "string";
			}
			if(!this.StrEntryDateTime.Equals(Default))
			{
				aryLIMS[5,0] = "EntryDateTime";
				aryLIMS[5,1] = this.EntryDateTime;
				aryLIMS[5,2] = "date";
			}
			if(!this.StrShift.Equals(Default))
			{
				aryLIMS[6,0] = "Shift";
				aryLIMS[6,1] = this.StrShift;
				aryLIMS[6,2] = "string";
			}
			if(!this.StrContactNo.Equals(Default))
			{
				aryLIMS[7,0] = "ContactNo";
				aryLIMS[7,1] = this.StrContactNo;
				aryLIMS[7,2] = "string";
			}
			if(!this.StrEntryPerson.Equals(Default))
			{
				aryLIMS[8,0] = "EntryPerson";
				aryLIMS[8,1] = this.StrEntryPerson;
				aryLIMS[8,2] = "string";
			}
			if(!this.StrClinicalNote.Equals(Default))
			{
				aryLIMS[9,0] = "ClinicalNote";
				aryLIMS[9,1] = this.StrClinicalNote;
				aryLIMS[9,2] = "string";
			}
			if(!this.StrDeliveryType.Equals(Default))
			{
				aryLIMS[10,0] = "DeliveryType";
				aryLIMS[10,1] = this.StrDeliveryType;
				aryLIMS[10,2] = "string";
			}
			if(!this.StrDeliveryRef.Equals(Default))
			{
				aryLIMS[11,0] = "DeliveryRef";
				aryLIMS[11,1] = this.StrDeliveryRef;
				aryLIMS[11,2] = "string";
			}
			if(!this.StrPaymentMode.Equals(Default))
			{
				aryLIMS[12,0] = "PaymentMode";
				aryLIMS[12,1] = this.StrPaymentMode;
				aryLIMS[12,2] = "string";
			}
			if(!this.StrDiscountPer.Equals(Default))
			{
				aryLIMS[13,0] = "DiscountPer";
				aryLIMS[13,1] = this.StrDiscountPer;
				aryLIMS[13,2] = "number";
			}
			if(!this.StrTotalAmount.Equals(Default))
			{
				aryLIMS[14,0] = "TotalAmount";
				aryLIMS[14,1] = this.StrTotalAmount;
				aryLIMS[14,2] = "number";
			}						
			if(!this.StrMStatus.Equals(Default))
			{
				aryLIMS[15,0] = "MStatus";
				aryLIMS[15,1] = this.StrMStatus;
				aryLIMS[15,2] = "string";
			}
			if(!this.StrPaidAmount.Equals(Default))
			{
				aryLIMS[16,0] = "PaidAmount";
				aryLIMS[16,1] = this.StrPaidAmount;
				aryLIMS[16,2] = "number";
			}
			if(!this.StrPaidNo.Equals(Default))
			{
				aryLIMS[17,0] = "PaidNo";
				aryLIMS[17,1] = this.StrPaidNo;
				aryLIMS[17,2] = "string";
			}
			if(!this.StrReferredBy.Equals(Default))
			{
				aryLIMS[18,0] = "ReferredBy";
				aryLIMS[18,1] = this.StrReferredBy;
				aryLIMS[18,2] = "string";
			}			
			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		public bool Validate()
		{
			return VD_Method();
		}

		private bool VD_Method()
		{
			Validation valid = new Validation();
			
			if(entitledIndex == 0)
			{
				if(this.HospitalID.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Panel (empty is not allowed).";
					return false;
				}
			}
			if(entitledIndex == 1){
				if(this.PaymentMode.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Payment Mode (empty is not allowed).";
					return false;
				}
			}

			if(this.Shift.Equals(""))
			{
				this.StrErrorMessage = "Please enter Shift (empty is not allowed)";
				return false;
			}
			if(this.EntryPerson.Equals(""))
			{
				this.StrErrorMessage = "Please enter Entry Person (empty is not allowed)";
				return false;
			}
			if(this.DeliveryType.Equals("-1"))
			{
				this.StrErrorMessage = "Please select Despatch Type.";
				return false;
			}
			if(!valid.IsNumber (this.DiscountPer))
			{
				this.StrErrorMessage = "Please enter Discount Percentage (empty is not allowed)";
				return false;
			}
			if(this.StrPaidNo.Equals(""))
			{
				this.StrErrorMessage = "Please enter Entry Paid No.(empty is not allowed)";
				return false;
			}
			return true;
		}

		public bool VD_Acronym()
		{
			/*Validation objValid = new Validation();

			if(StrAcronym.Equals(""))
			{
				this.StrErrorMessage = "Please enter Acronym.";
				return false;
			}
			
			if(!objValid.IsAlpha(StrAcronym))
			{
				this.StrErrorMessage = "Please enter valid Acronym (space is not allowed)";
				return false;
			}

			DataView dvAcronym = GetAll(2);

			if(!StrMethodID.Equals(Default))
			{
				dvAcronym.RowFilter = "MethodID <> " + StrMethodID;
			}

			if(dvAcronym.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Acronym, it is already present.";
				return false;
			}*/

			return true;
		}

		#endregion
	}

	
}
