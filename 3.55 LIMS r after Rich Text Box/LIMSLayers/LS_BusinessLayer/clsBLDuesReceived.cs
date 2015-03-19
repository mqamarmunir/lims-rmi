using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLDuesReceived
	/// </summary>
	public class clsBLDuesReceived
	{
		public clsBLDuesReceived()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDuesReceived";
		private string StrErrorMessage = "";				
		
		private string StrMSerialNo = Default;		
		private string StrEntryDateTime = Default;		
		private string StrShift = Default;		
		private string StrEntryPerson = Default;
		private string StrPaidAmount = Default;
		
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
		public string EntryPerson
		{
			get{	return StrEntryPerson;	}
			set{	StrEntryPerson = value;	}
		}		
		public string PaidAmount
		{
			get{	return StrPaidAmount ;	}
			set{	StrPaidAmount = value;	}
		}									
		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();		

		#region "Methods"

		public bool Insert()
		{					
				try
				{
					QueryBuilder objQB = new QueryBuilder();
					
					objTrans.Start_Transaction();
					// setting transaction master serial no										
					objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
					this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
					objTrans.End_Transaction();
				}
				catch(Exception e)
				{
					this.StrErrorMessage = e.Message;
					return false;	
				}			
			return true;		
			
		}		

		public bool Update()
		{
			//
			return false;
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
			string[,] aryLIMS = new string[5,3];

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "MSerialNo";
				aryLIMS[0,1] = this.StrMSerialNo;
				aryLIMS[0,2] = "string";
			}
			
			if(!this.StrEntryDateTime.Equals(Default))
			{
				aryLIMS[1,0] = "EntryDateTime";
				aryLIMS[1,1] = this.EntryDateTime;
				aryLIMS[1,2] = "date";
			}
			if(!this.StrShift.Equals(Default))
			{
				aryLIMS[2,0] = "Shift";
				aryLIMS[2,1] = this.StrShift;
				aryLIMS[2,2] = "string";
			}
			if(!this.StrEntryPerson.Equals(Default))
			{
				aryLIMS[3,0] = "EntryPerson";
				aryLIMS[3,1] = this.StrEntryPerson;
				aryLIMS[3,2] = "string";
			}			
			if(!this.StrPaidAmount.Equals(Default))
			{
				aryLIMS[4,0] = "PaidAmount";
				aryLIMS[4,1] = this.StrPaidAmount;
				aryLIMS[4,2] = "number";
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
			/*Validation valid = new Validation();
			
			if(entitledIndex == 0)
			{
				if(this.HospitalID.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Panel (empty is not allowed).";
					return false;
				}
			}
			if(entitledIndex == 1)
			{
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
			}*/
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
