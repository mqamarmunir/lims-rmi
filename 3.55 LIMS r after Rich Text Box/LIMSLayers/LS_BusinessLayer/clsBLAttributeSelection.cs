using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLOpinion.
	/// </summary>
	public class clsBLAttributeSelection
	{
		#region Class Variable
		private string StrErrorMessage = "";
		private string TableName = "ls_tattributeselection";
		private const string Default = "~!@";
		private string StrAttributeID = Default;
		private string StrSValue = Default;
		private string StrSValueOld = Default;

		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Properties"

		public string AttributeID
		{
			get{	return StrAttributeID;	}
			set{	StrAttributeID = value;	}
		}

		public string SValue
		{
			get{	return StrSValue;	}
			set{	StrSValue = value;	}
		}

		public string SValueOld
		{
			get{	return StrSValueOld;	}
			set{	StrSValueOld = value;	}
		}

		public string ErrorMessage
		{
			get	{ return StrErrorMessage; }
			set { StrErrorMessage = value; }
		}
		
		#endregion

		public clsBLAttributeSelection()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool Insert()
		{
			if(this.AttributeID.Equals(""))
			{
				this.StrErrorMessage = "Attribute ID not found.";
				return false;
			}
			if(this.SValue.Equals(""))
			{
				this.StrErrorMessage = "Selection Value not found.";
				return false;
			}

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = "Delete from "+TableName+" Where AttributeID = '"+AttributeID+"' And SValue = '"+SValueOld+"'";
				this.StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);

				if(!this.StrErrorMessage.Equals("True"))
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

		public bool Update()
		{
			return true;
		}
		public bool Delete()
		{
			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = "Delete from "+TableName+" Where AttributeID = '"+AttributeID+"' And SValue = '"+SValueOld+"'";
				this.StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);

				if(!this.StrErrorMessage.Equals("True"))
				{
					objTrans.End_Transaction();
					return true;					
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


		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "select svalue, attributeid from ls_tattributeselection Where AttributeID = '"+StrAttributeID+"'";
					break;

				case 2:
					/**/
					break;

				case 3:
					/**/
					break;

				case 4:
					/**/
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryAttributeSelection = new string[2,3];

			if(!this.StrAttributeID.Equals(Default))
			{
				aryAttributeSelection[0,0] = "AttributeID";
				aryAttributeSelection[0,1] = this.StrAttributeID;
				aryAttributeSelection[0,2] = "string";
			}

			if(!this.StrSValue.Equals(Default))
			{
				aryAttributeSelection[1,0] = "SValue";
				aryAttributeSelection[1,1] = this.StrSValue;
				aryAttributeSelection[1,2] = "string";
			}
					
			return aryAttributeSelection;
		}
	}
}
