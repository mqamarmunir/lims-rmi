using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestGroup.
	/// </summary>
	public class clsBLTestGroup
	{
		public clsBLTestGroup()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTestGroup";
		private string StrErrorMessage = "";
		private string StrTestGroupID = Default;
		private string StrTestGroup = Default;
		private string StrActive = Default;
		private string StrAcronym = Default;
		private string StrSectionID = Default;
		private string StrDOrder = Default;
        private string StrEnteredOn = Default;
        private string StrEnteredBy = Default;

		#endregion

		#region "Properties"

		public string TestGroupID
		{
			get{	return StrTestGroupID;	}
			set{	StrTestGroupID = value;	}
		}

		public string TestGroup
		{
			get{	return StrTestGroup;	}
			set{	StrTestGroup = value;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
		}

		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
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
        public string Enteredon
        {
            get { return StrEnteredOn; }
            set { StrEnteredOn = value; }
        }
        public string Enteredby
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert()
		{
			if(Validate())
			{
				try
				{
					QueryBuilder objQB = new QueryBuilder();

					objTrans.Start_Transaction();

					objdbhims.Query = objQB.QBGetMax("TestGroupID", TableName, "3");
					this.StrTestGroupID = objTrans.DataTrigger_Get_Max(objdbhims);

					objdbhims.Query = objQB.QBGetMax("DOrder", TableName, "3");
					DOrder = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrTestGroupID.Equals("True") && this.DOrder != "True")
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
			if(Validate())
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

		public bool Delete()
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
			} else
			{
				return false;
			}
		}

		public bool UpdateAll(string[,] arrayUpdate)
		{
			clsoperation objTrans = new clsoperation();
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

			objTrans.End_Transaction();

			return true;
		}


		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(TestGroup) like '%'||'" + StrTestGroup.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 2:
					objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 3:
					objdbhims.Query = "Select * from LS_TTestGroup Where Active ='Y' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 4:
					objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(Active) = '" + StrActive.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;
                case 5:
                    objdbhims.Query = "Select * from LS_TTestGroup Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
                    break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[8,3];

			if(!this.StrTestGroupID.Equals(Default))
			{
				aryTestGroup[0,0] = "TestGroupID";
				aryTestGroup[0,1] = this.StrTestGroupID;
				aryTestGroup[0,2] = "string";
			}

			if(!this.StrTestGroup.Equals(Default))
			{
				aryTestGroup[1,0] = "TestGroup";
				aryTestGroup[1,1] = this.StrTestGroup;
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

			if(!this.StrSectionID.Equals(Default))
			{
				aryTestGroup[4,0] = "SectionID";
				aryTestGroup[4,1] = this.StrSectionID;
				aryTestGroup[4,2] = "string";
			}

			if(!this.StrDOrder.Equals(Default))
			{
				aryTestGroup[5,0] = "DOrder";
				aryTestGroup[5,1] = this.DOrder;
				aryTestGroup[5,2] = "int";
			}
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryTestGroup[6, 0] = "enteredon";
                aryTestGroup[6, 1] = this.StrEnteredOn;
                aryTestGroup[6, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryTestGroup[7, 0] = "enteredby";
                aryTestGroup[7, 1] = this.StrEnteredBy;
                aryTestGroup[7, 2] = "string";
            }

			return aryTestGroup;
		}

		public string GetNextTestNo(string testGroupID, clsoperation trans)
		{
			
			objdbhims.Query = "select testno from "+TableName+" where testgroupid='"+testGroupID+"'";
			DataTable table = trans.Transaction_Get_Single(objdbhims).Table;
			string testNo = table.Rows[0][0].ToString();
			
			objdbhims.Query = "update "+TableName+" set testno=testno+1 where testgroupid='"+testGroupID+"'";
			trans.DataTrigger_Update(objdbhims);
			
			return testNo;
		}

		#endregion

		#region "Validation Functions"

		private bool Validate()
		{
			if(!StrTestGroup.Equals(Default))
			{
				if(!VD_TestGroup())
				{
					return false;
				}
			}
/*
			if(!StrAcronym.Equals(Default))
			{
				if(!VD_Acronym())
				{
					return false;
				}
			}
*/			
			return true;
		}

		public bool VD_TestGroup()
		{
			Validation objValid = new Validation();

			if(StrTestGroup.Equals(""))
			{
				this.StrErrorMessage = "Please enter Test Group.";
				return false;
			}

			DataView dvTestGroup = GetAll(1);

			if(!StrTestGroupID.Equals(Default))
			{
				dvTestGroup.RowFilter = "TestGroupID <> '" + StrTestGroupID + "' and testgroup = '" + StrTestGroup + "'" ;
			}
			else
			{
				dvTestGroup.RowFilter = "testgroup = '" + StrTestGroup + "'" ;
			}

			if(dvTestGroup.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Test Group Name, it is already present.";
				return false;
			}

			return true;
		}

		public bool VD_Acronym()
		{
			if(!Acronym.Equals(""))
			{
				Validation objValid = new Validation();

	/*			if(StrAcronym.Equals(""))
				{
					this.StrErrorMessage = "Please enter Acronym. (empty is not allowed)";
					return false;
				}
	*/
				DataView dvAcronym = GetAll(2);

				if(!StrTestGroupID.Equals(Default))
				{
					dvAcronym.RowFilter = "TestGroupID <> " + StrTestGroupID;
				}

				if(dvAcronym.Count > 0)
				{
					this.StrErrorMessage = "Please enter another Acronym, it is already present.";
					return false;
				}
			}

			return true;
		}	
		

		#endregion
	}
}