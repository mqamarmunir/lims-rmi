using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenType.
	/// </summary>
	public class clsBLSpecimenType
	{
		#region Class Variable
		private string StrErrorMessage = "";
		private string TableName = "ls_tspecimentype";
		private const string Default = "~!@";
		private string StrSValue = Default;
		private string StrSValueOld = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;
		
		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Properties"

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

		public clsBLSpecimenType()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool Insert()
		{
			if(this.SValue.Equals(""))
			{
				this.StrErrorMessage = "Specimen Type not found.";
				return false;
			}			

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = "Delete from "+TableName+" Where specimentype = '"+SValueOld+"'";
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

				objdbhims.Query = "Delete from "+TableName+" Where specimentype = '"+SValue+"'";
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
					objdbhims.Query = "select specimentype from ls_tspecimentype Order By specimentype";
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
			string[,] aryAttributeSelection = new string[3,3];

			if(!this.StrSValue.Equals(Default))
			{
				aryAttributeSelection[0,0] = "specimentype";
				aryAttributeSelection[0,1] = this.StrSValue;
				aryAttributeSelection[0,2] = "string";
			}
            if (!this.StrEnteredon.Equals(Default))
            {
                aryAttributeSelection[1, 0] = "enteredon";
                aryAttributeSelection[1, 1] = this.StrEnteredon;
                aryAttributeSelection[1, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryAttributeSelection[2, 0] = "enteredby";
                aryAttributeSelection[2, 1] = this.StrEnteredby;
                aryAttributeSelection[2, 2] = "string";
            }
					
			return aryAttributeSelection;
		}
	}
}
