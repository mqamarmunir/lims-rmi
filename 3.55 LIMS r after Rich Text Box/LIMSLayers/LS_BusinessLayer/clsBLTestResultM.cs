using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestResultM.
	/// </summary>
	public class clsBLTestResultM
	{
		public clsBLTestResultM()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "";
		private string StrErrorMessage = "";
		private string StrDSerialNo = Default;		
		private string StrProcessID = Default;
        private string StrLabid = Default;


		#endregion

		#region "Properties"


        public string Labid
        {
            get { return StrLabid; }
            set { StrLabid = value; }
        }
		public string DSerialNo
		{
			get{	return StrDSerialNo;	}
			set{	StrDSerialNo = value;	}
		}
		
		public string ProcessID
		{
			get{	return StrProcessID;	}
			set{	StrProcessID = value;	}
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
			return false;			
		}

		public bool Update()
		{
			return false;			
		}

		public bool Delete()
		{		
			if (!StrDSerialNo.Equals(Default))
			{
				if ((StrProcessID.Equals("0004")) || (StrProcessID.Equals("0005")) || (StrProcessID.Equals("0006")) || (StrProcessID.Equals("0007"))) 
				{
					clsoperation objTrans = new clsoperation();
					QueryBuilder objQB = new QueryBuilder();

					objTrans.Start_Transaction();

                    objdbhims.Query = "Delete From LS_TTestResultD Where DSerialNo = " + StrDSerialNo;
                    this.StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);

                    objdbhims.Query = "Delete From LS_TTestResultM Where DSerialNo = " + StrDSerialNo;
                    this.StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);			
			
                    objdbhims.Query="Delete from ls_tinterfaced where MserialNo="+Convert.ToInt32(Labid.Substring(Labid.Length-7));
                    this.StrErrorMessage = objTrans.DataTrigger_Delete(objdbhims);
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
					this.StrErrorMessage = "";
					return false;
				}
			}
			this.StrErrorMessage = "";
			return false;
		}

		public bool UpdateAll(string[,] arrayUpdate)
		{
			return true;
		}


		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					//objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(TestGroup) like '%'||'" + StrTestGroup.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 2:
					//objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 3:
					//objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;

				case 4:
					//objdbhims.Query = "Select * from LS_TTestGroup Where Active <> 'D' And Upper(Active) = '" + StrActive.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[6,3];
			/*
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
			*/
			return aryTestGroup;
		}

		#endregion
	}
}