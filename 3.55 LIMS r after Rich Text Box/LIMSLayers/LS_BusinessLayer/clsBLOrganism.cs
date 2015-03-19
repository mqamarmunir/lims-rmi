using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestProcess.
	/// </summary>
	public class clsBLOrganism
	{
		public clsBLOrganism()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "ls_torganism";
		private string StrErrorMessage = "";
		private string StrOrganismID = Default;
		private string StrOrganism = Default;		
		private string StrAcronym = Default;		
		private string StrActive = Default;		
		private string StrDescription = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;

		#endregion

		#region "Properties"
		
		public string OrganismID
		{
			get{	return StrOrganismID;	}
			set{	StrOrganismID = value;	}
		}
		
		public string Organism
		{
			get{	return StrOrganism;	}
			set{	StrOrganism = value;	}
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
			if(this.Organism.Equals(""))
			{
				this.StrErrorMessage = "Please enter Organism (empty is not allowed).";
				return false;
			}

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMax("OrganismID", TableName, "4");
				this.StrOrganismID = objTrans.DataTrigger_Get_Max(objdbhims);

				if(!this.StrOrganismID.Equals("True"))
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

				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
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
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select OrganismID, Organism, Active from LS_TOrganism Where Active = 'Y' Order by Organism";
					break;

				case 2:
					objdbhims.Query = "Select OrganismID, Organism, Acronym, Active, Description from LS_TOrganism Order by Organism";
					break;

				case 3:
					/*objdbhims.Query = "Select ProcessID from LS_TTestProcess Where Sequence < (Select Sequence from LS_TTestProcess Where ProcessID = '" + StrProcessID + "')And PROCEDUREID = '" + StrProcedureID + "' order by sequence Desc";*/
					break;

				case 4:
					/**/
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}	

		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[7,3];

			if(!this.StrOrganismID.Equals(Default))
			{
				aryTestGroup[0,0] = "OrganismID";
				aryTestGroup[0,1] = this.StrOrganismID;
				aryTestGroup[0,2] = "string";
			}

			if(!this.StrOrganism.Equals(Default))
			{
				aryTestGroup[1,0] = "Organism";
				aryTestGroup[1,1] = this.StrOrganism;
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
            if (!this.StrEnteredon.Equals(Default))
            {
                aryTestGroup[5, 0] = "enteredon";
                aryTestGroup[5, 1] = this.StrEnteredon;
                aryTestGroup[5, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryTestGroup[6, 0] = "enteredby";
                aryTestGroup[6, 1] = this.StrEnteredby;
                aryTestGroup[6, 2] = "string";
            }
			return aryTestGroup;
		}

		#endregion
	}
}
