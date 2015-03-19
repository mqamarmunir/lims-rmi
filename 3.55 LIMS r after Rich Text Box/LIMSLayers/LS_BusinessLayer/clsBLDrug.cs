using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcess.
	/// </summary>
	public class clsBLDrug
	{
		public clsBLDrug()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDrug";
		private string StrErrorMessage = "";
		private string StrDrugID = Default;
		private string StrOrganismID = Default;		
		private string StrDrug = Default;		
		private string StrAcronym = Default;		
		private string StrActive = Default;		
		private string StrDescription = Default;		
		private string StrDerialNo = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;

		#endregion

		#region "Properties"
		
		
		public string DrugID
		{
			get{	return StrDrugID;	}
			set{	StrDrugID = value;	}
		}

		public string OrganismID
		{
			get{	return StrOrganismID;	}
			set{	StrOrganismID = value;	}
		}
		
		public string Drug
		{
			get{	return StrDrug;	}
			set{	StrDrug = value;	}
		}
		
		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}
		
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		
		public string Description
		{
			get{	return StrDescription;	}
			set{	StrDescription = value;	}
		}

		public string DerialNo
		{			
			get{	return StrDerialNo;	}
			set{	StrDerialNo = value;	}
		}
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
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
			if(this.StrDrug.Equals(""))
			{
				this.StrErrorMessage = "Please enter Drug (empty is not allowed).";
				return false;
			}

			if(this.StrOrganismID.Equals(""))
			{
				this.StrErrorMessage = "Please select Organism (empty is not allowed).";
				return false;
			}

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMax("DrugID", TableName, "4");
				this.StrDrugID = objTrans.DataTrigger_Get_Max(objdbhims);

				if(!this.StrDrugID.Equals("True"))
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


		public bool UpdateAll(string[,] arrayUpdate)
		{
			/*clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();

			for(int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
			{
				this.StrTestGroupID = arrayUpdate[counter, 0];
				this.StrDOrder = arrayUpdate[counter, 1];

				objdbhims.Query = objQB.QBUpdate(MakeArray(), "LS_TTestGroup");
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					objTrans.End_Transaction();
					return false;
				}
			}

			objTrans.End_Transaction();*/

			return true;
		}

				
		public DataView GetAll(int flag)
		{
			//StrDerialNo = "22072";
			switch(flag)
			{					
				case 1:
					objdbhims.Query = "Select d.OrganismID, d.drugid, d.drug, LS_FMicroResult("+ DerialNo +", d.drugid) As microresult from ls_tdrug d Where d.organismid = '" + StrOrganismID + "' And d.active = 'Y' Order By d.drug";				
					break;
				case 2:
					objdbhims.Query = "Select d.OrganismID, d.drugid, d.drug, LS_FMicroResult2("+ DerialNo +", d.drugid) As microresult from ls_tdrug d Where d.organismid = '" + StrOrganismID + "' And d.active = 'Y' Order By d.drug";
					break;
				case 3:
					objdbhims.Query = "Select d.OrganismID, d.drugid, d.drug, LS_FMicroResult3("+ DerialNo +", d.drugid) As microresult from ls_tdrug d Where d.organismid = '" + StrOrganismID + "' And d.active = 'Y' Order By d.drug";
					break;
				case 4:
					objdbhims.Query = "Select DrugID, Drug, OrganismID, Description, Active, Acronym from LS_TDRUG  Where organismid = '" + StrOrganismID + "' Order By Drug";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[8,3];

			if(!this.StrDrugID.Equals(Default))
			{
				aryTestGroup[0,0] = "DrugID";
				aryTestGroup[0,1] = this.StrDrugID;
				aryTestGroup[0,2] = "string";
			}

			if(!this.StrDrug.Equals(Default))
			{
				aryTestGroup[1,0] = "Drug";
				aryTestGroup[1,1] = this.StrDrug;
				aryTestGroup[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryTestGroup[2,0] = "Active";
				aryTestGroup[2,1] = this.StrActive;
				aryTestGroup[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryTestGroup[3,0] = "Acronym";
				aryTestGroup[3,1] = this.StrAcronym;
				aryTestGroup[3,2] = "string";
			}

			if(!this.StrDescription.Equals(Default))
			{
				aryTestGroup[4,0] = "Description";
				aryTestGroup[4,1] = this.StrDescription;
				aryTestGroup[4,2] = "string";
			}

			if(!this.StrOrganismID.Equals(Default))
			{
				aryTestGroup[5,0] = "OrganismID";
				aryTestGroup[5,1] = this.OrganismID;
				aryTestGroup[5,2] = "string";
			}
            if (!this.StrEnteredon.Equals(Default))
            {
                aryTestGroup[6,0] = "enteredon";
                aryTestGroup[6,1] = this.StrEnteredon;
                aryTestGroup[6, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryTestGroup[7, 0] = "enteredby";
                aryTestGroup[7, 1] = this.StrEnteredby;
                aryTestGroup[7, 2] = "string";
            }
			return aryTestGroup;
		}

		#endregion
	}
}
