using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTMethod.
	/// </summary>
	public class clsBLTMethod
	{
		public clsBLTMethod()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Initial = "~!@";
		private const string TableName = "LS_TMethod";
		private string StrErrorMessage = "";
		private string StrMethodID = Initial;
		private string StrSectionID = Initial;
		private string StrMethod = Initial;
		private string StrActive = Initial;
		private string StrDefault = Initial;
		private string StrAcronym = Initial;
		private string StrTAT = Initial;
		private string StrMinTime = Initial;
		private string StrMaxTime = Initial;
		private string StrDOrder = Initial;

		#endregion

		#region "Properties"

		public string MethodID
		{
			get{	return StrMethodID;	}
			set{	StrMethodID = value;	}
		}

		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}

		public string Method
		{
			get{	return StrMethod;	}
			set{	StrMethod = value;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}

		public string Default
		{
			get{	return StrDefault;	}
			set{	StrDefault = value;	}
		}

		public string Acronym
		{
			get{	return StrAcronym;	}
			set{	StrAcronym = value;	}
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

		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

/*		#region "Methods"

		public bool Insert()
		{
			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMax("TestGroupID", TableName, "2");
				this.StrTestGroupID = objTrans.DataTrigger_Get_Max(objdbhims);

				if(!this.StrTestGroupID.Equals("True"))
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
			if(Validate())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), "LS_TTestGroup");
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
					objdbhims.Query = "Select * from LS_TTestGroup Where Upper(TestGroup) like '%'||'" + StrTestGroup.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 2:
					objdbhims.Query = "Select * from LS_TTestGroup Where Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 3:
					objdbhims.Query = "Select * from LS_TTestGroup Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[6,3];

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
				aryTestGroup[5,2] = "string";
			}

			return aryTestGroup;
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

			if(!StrAcronym.Equals(Default))
			{
				VD_Acronym();
			}
			
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
			
			if(!objValid.IsName(StrTestGroup))
			{
				this.StrErrorMessage="Please enter valid Test Group (only alphabets)";
				return false;
			}

			DataView dvTestGroup = GetAll(1);

			if(!StrTestGroupID.Equals(Default))
			{
				dvTestGroup.RowFilter = "TestGroupID <> '" + StrTestGroupID + "'";
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
			Validation objValid = new Validation();

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

			if(!StrTestGroupID.Equals(Default))
			{
				dvAcronym.RowFilter = "TestGroupID <> " + StrTestGroupID;
			}

			if(dvAcronym.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Acronym, it is already present.";
				return false;
			}

			return true;
		}

		#endregion	*/
	}
}
