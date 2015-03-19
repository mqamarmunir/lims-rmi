using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLMethod
	/// </summary>
	public class clsBLMethod
	{
		public clsBLMethod()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TMethod";
		private string StrErrorMessage = "";		
		
		private string StrSectionID = Default;
		private string StrActive = Default;
		private string StrMethodID = Default;
		private string StrMethod = Default;
		private string StrAcronym = Default;		
		private string StrMDefault = Default;		
		private string StrTAT = Default;		
		private string StrMinTime = Default;		
		private string StrMaxTime = Default;
		private string StrDOrder = Default;
        private string StrMethodText = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		public string MethodID
		{
			get{	return StrMethodID;	}
			set{	StrMethodID = value;	}
		}
		public string Method
		{
			get{	return StrMethod;	}
			set{	StrMethod = value;	}
		}
		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}
		public string MDefault
		{
			get{	return StrMDefault;	}
			set{	StrMDefault = value;	}
		}
		public string TAT
		{
			get{	return StrTAT;	}
			set{	StrTAT = value;	}
		}
		public string MinTime
		{
			get{	return StrMinTime;	}
			set{	StrMinTime = value;	}
		}
		public string MaxTime
		{
			get{	return StrMaxTime;	}
			set{	StrMaxTime = value;	}
		}
		public string DOrder
		{
			get{	return StrDOrder;	}
			set{	StrDOrder = value;	}
		}
        public string MethodText
        {
            get { return StrMethodText; }
            set { StrMethodText = value; }
        }
        public string Enteredon
        {
            get { return StrEnteredon; }
            set { StrEnteredon = value; }
        }
        public string Enteredby
        {
            get { return StrEnteredby; }
            set { StrEnteredby = value; }
        }
		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert()
		{
			if(Validation())
			{
				try
				{
					QueryBuilder objQB = new QueryBuilder();

					objTrans.Start_Transaction();

					objdbhims.Query = objQB.QBGetMax("MethodID", TableName, "4");
					this.StrMethodID = objTrans.DataTrigger_Get_Max(objdbhims);

					objdbhims.Query = objQB.QBGetMax("DOrder", TableName, "4");
					this.DOrder = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrMethodID.Equals("True"))
					{
						objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
						this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

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
					else
					{
						this.StrErrorMessage = objTrans.OperationError;
						objTrans.End_Transaction();
						return false;
					}
				}
				catch(Exception e)
				{
					this.StrErrorMessage = e.Message;
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public bool Update()
		{
			if(Validation())
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
			else
			{
				return false;
			}
		}

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select * from LS_TMethod Where Upper(Method) like '%'||'" + StrMethod.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 2:
					objdbhims.Query = "Select * from LS_TMethod Where Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 3:
					objdbhims.Query = "Select * from LS_TMethod Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[13,3];

			if(!this.StrMethodID.Equals(Default))
			{
				aryLIMS[0,0] = "MethodID";
				aryLIMS[0,1] = this.StrMethodID;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrMethod.Equals(Default))
			{
				aryLIMS[1,0] = "Method";
				aryLIMS[1,1] = this.StrMethod;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryLIMS[2,0] = "Active";
				aryLIMS[2,1] = this.StrActive;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryLIMS[3,0] = "Acronym";
				aryLIMS[3,1] = this.StrAcronym;
				aryLIMS[3,2] = "string";
			}

			if(!this.StrSectionID.Equals(Default))
			{
				aryLIMS[4,0] = "SectionID";
				aryLIMS[4,1] = this.StrSectionID;
				aryLIMS[4,2] = "string";
			}

			if(!this.StrTAT.Equals(Default))
			{
				aryLIMS[5,0] = "TAT";
				aryLIMS[5,1] = this.StrTAT;
				aryLIMS[5,2] = "string";
			}
			if(!this.StrMinTime.Equals(Default))
			{
				aryLIMS[6,0] = "MinTime";
				aryLIMS[6,1] = this.StrTAT.Equals("N") ? "0" : this.StrMinTime;
				aryLIMS[6,2] = "int";
			}
			if(!this.StrMaxTime.Equals(Default))
			{
				aryLIMS[7,0] = "MaxTime";
				aryLIMS[7,1] = this.StrTAT.Equals("N") ? "0" : this.StrMaxTime;
				aryLIMS[7,2] = "int";
			}
			if(!this.StrMDefault.Equals(Default))
			{
				aryLIMS[8,0] = "MDefault";
				aryLIMS[8,1] = this.StrMDefault;
				aryLIMS[8,2] = "string";
			}
			if(!this.StrDOrder.Equals(Default))
			{
				aryLIMS[9,0] = "DOrder";
				aryLIMS[9,1] = this.DOrder;
				aryLIMS[9,2] = "int";
			}
            if (!this.StrEnteredon.Equals(Default))
            {
                aryLIMS[10, 0] = "enteredon";
                aryLIMS[10, 1] = this.StrEnteredon;
                aryLIMS[10, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryLIMS[11, 0] = "enteredby";
                aryLIMS[11, 1] = this.StrEnteredby;
                aryLIMS[11, 2] = "string";
            }
            if (!this.StrMethodText.Equals(Default))
            {
                aryLIMS[12, 0] = "REPORT_TEXT";
                aryLIMS[12, 1] = this.StrMethodText;
                aryLIMS[12, 2] = "string";
            }

			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_Method())
			{
				return false;
			}
/*
			if(!VD_Acronym())
			{
				return false;
			}
*/
			if(!VD_MinTime())
			{
				return false;
			}

			if(!VD_MaxTime())
			{
				return false;
			}
			
			return true;
		}

		public bool VD_Method()
		{
			Validation objValid = new Validation();

			if(StrMethod.Equals("") || !objValid.IsBBName(StrMethod))
			{
				this.StrErrorMessage = "Please enter Method Name. (empty/special character(s) are not allowed)";
				return false;
			}

			DataView dvMethod = GetAll(1);

			if(!StrMethodID.Equals(Default))
			{
				dvMethod.RowFilter = "MethodID <> '" + StrMethodID + "' And Method = '" + this.StrMethod.ToUpper() + "'";
			}
			else
			{
				dvMethod.RowFilter = "Method = '" + this.StrMethod.ToUpper() + "'";
			}

			if(dvMethod.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Method name, it is already present.";
				return false;
			}
			return true;
		}

		public bool VD_Acronym()
		{
			if(!StrAcronym.Equals(""))
			{
				Validation objValid = new Validation();

/*				if(StrAcronym.Equals("") || !objValid.IsName(StrMethod))
				{
					this.StrErrorMessage = "Please enter Acronym. (empty/special character(s) are not allowed)";
					return false;
				}
*/			
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
				}
			}

			return true;
		}

		private bool VD_MinTime()
		{
			Validation objValid = new Validation();

			if(this.StrMinTime.Equals("") && !this.TAT.Equals("N"))
			{
				this.StrErrorMessage = "Please enter Method Minimum Time. (empty is not allowed)";
				return false;
			}
			else if(!objValid.IsPositiveNumber(this.StrMinTime) & !this.TAT.Equals("N"))
			{
				this.StrErrorMessage = "Please enter valid Method Minimum Time. (only digits allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_MaxTime()
		{
			Validation objValid = new Validation();

			if(this.StrMaxTime.Equals("") && !this.TAT.Equals("N"))
			{
				this.StrErrorMessage = "Please enter Method Maximum Time. (empty is not allowed)";
				return false;
			}
			else if(!objValid.IsPositiveNumber(this.StrMaxTime) && !this.TAT.Equals("N"))
			{
				this.StrErrorMessage = "Please enter valid Method Maximum Time. (only digits allowed)";
				return false;
			}
			else if(!this.TAT.Equals("N"))
			{
				StrMinTime = !objValid.IsPositiveNumber(this.StrMinTime) ? "0" : StrMinTime;
				StrMaxTime = !objValid.IsPositiveNumber(this.StrMaxTime) ? "-1" : StrMaxTime;
				if(long.Parse(StrMinTime) > long.Parse(StrMaxTime))
				{
					this.StrErrorMessage = "Min. Time cannot be greater than Max. Time.";
					return false;
				}
			}
			return true;
		}

		#endregion
	}
}