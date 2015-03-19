using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTDiscountLevel.
	/// </summary>
	public class clsBLTDiscountLevel
	{
		public clsBLTDiscountLevel()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDiscountLevel";
		private string StrErrorMessage = "";
		private string StrDiscountID = Default;
		private string StrDiscountName = Default;
		private string StrDiscount = Default;
		private string StrActive = Default;
		private string StrDOrder = Default;		
				
				
		#endregion

		#region "Properties"			

		public string DiscountID
		{
			get{	return StrDiscountID;	}
			set{	StrDiscountID = value;	}
		}

		public string DiscountName
		{
			get{	return StrDiscountName;	}
			set{	StrDiscountName = value;	}
		}

		public string Discount
		{
			get{	return StrDiscount;	}
			set{	StrDiscount = value;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		public string DOrder
		{
			get{	return StrDOrder;	}
			set{	StrDOrder = value;	}
		}	

		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
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

					objdbhims.Query = objQB.QBGetMax("DiscountID", TableName, "2");
					this.StrDiscountID = objTrans.DataTrigger_Get_Max(objdbhims);

					objdbhims.Query = objQB.QBGetMax("DOrder", TableName, "2");
					this.DOrder = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrDiscountID.Equals("True"))
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
			string sDiscountID = "", sDiscount = "", sActive = "";

			if(!this.StrDiscountID.Equals(Default))
			{sDiscountID = " And DiscountID = '"+ StrDiscountID +"' ";}
					
			if(!this.StrDiscount.Equals(Default))
			{sDiscount = " And Discount = '"+ StrDiscount +"' ";}
					
			if(!this.StrActive.Equals(Default))
			{sActive = " And Active  = '"+ StrActive +"' ";}

			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select DiscountID, DiscountName, Discount, Active, DOrder from LS_TDiscountLevel Where 1 = 1 "+sDiscountID+sDiscount+sActive;
					break;

				case 2:
					objdbhims.Query = "Select DiscountID, DiscountName, Discount, Active, DOrder from LS_TDiscountLevel Where 1 = 1 "+sDiscountID+sDiscount+sActive+" Order By DOrder";
					break;

				case 3:
					//
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[5,3];

			if(!this.StrDiscountID.Equals(Default))
			{
				aryLIMS[0,0] = "DiscountID";
				aryLIMS[0,1] = this.StrDiscountID;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrDiscountName.Equals(Default))
			{
				aryLIMS[1,0] = "DiscountName";
				aryLIMS[1,1] = this.StrDiscountName;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrDiscount.Equals(Default))
			{
				aryLIMS[2,0] = "Discount";
				aryLIMS[2,1] = this.StrDiscount;
				aryLIMS[2,2] = "int";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryLIMS[3,0] = "Active";
				aryLIMS[3,1] = this.StrActive;
				aryLIMS[3,2] = "string";
			}

			if(!this.StrDOrder.Equals(Default))
			{
				aryLIMS[4,0] = "DOrder";
				aryLIMS[4,1] = this.StrDOrder;
				aryLIMS[4,2] = "int";
			}

			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_Discount())
			{
				return false;
			}
			/*
						if(!VD_Acronym())
						{
							return false;
						}
			*/		
			
			return true;
		}

		public bool VD_Discount()
		{
			Validation objValid = new Validation();

			if(StrDiscount.Equals("") || !objValid.IsName(StrDiscount))
			{
				this.StrErrorMessage = "Please enter Discount Name. (empty/special character(s) are not allowed)";
				return false;
			}

			DataView dvDiscount = GetAll(1);

			if(!StrDiscountID.Equals(Default))
			{
				dvDiscount.RowFilter = "DiscountID <> '" + StrDiscountID + "' And Discount = '" + this.StrDiscount.ToUpper() + "'";
			}
			else
			{
				dvDiscount.RowFilter = "Discount = '" + this.StrDiscount.ToUpper() + "'";
			}

			if(dvDiscount.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Discount name, it is already present.";
				return false;
			}
			return true;		
		}		
		#endregion
	}
}