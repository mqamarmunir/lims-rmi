using System;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLRank.
	/// </summary>
	public class clsBLRank
	{
		public clsBLRank()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		private const string Default = "~!@";
		private const string TableName = "Rank";
		private string StrErrorMessage = "";
		private string StrRankID = Default;
		private string StrRankName = Default;
		private string StrActive = Default;
		private string StrOrgID = Default;		
		private string StrFactoryID = Default;					

		#region "Properties"
		
		public string RankID
		{
			get	{ return StrRankID; }
			set { StrRankID = value; }
		}
		
		public string RankName
		{
			get	{ return StrRankName; }
			set { StrRankName = value; }
		}
		
		public string Active
		{
			get	{ return StrActive; }
			set { StrActive = value; }
		}
		
		public string OrgID
		{
			get	{ return StrOrgID; }
			set { StrOrgID = value; }
		}

		public string FactoryID
		{
			get	{ return StrFactoryID; }
			set { StrFactoryID = value; }
		}

		public string ErrorMessage
		{
			get	{ return StrErrorMessage; }
			set { StrErrorMessage = value; }
		}	

		#endregion

		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public string Insert()
		{
			try
			{
				QueryBuilder objQB = new QueryBuilder();

				
				objTrans.Start_Transaction(); 
				

				objdbhims.Query = objQB.QBGetMax("RankID", TableName, "4");
				this.StrRankID = objTrans.DataTrigger_Get_Max(objdbhims);			

				if(!this.StrRankID.Equals("True"))
				{
					objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
					this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);					
					
					objTrans.End_Transaction(); 					
	
					if(this.StrErrorMessage.Equals("True"))
					{
						this.StrErrorMessage = objTrans.OperationError;
						return "Error";
					}
					else
					{
						return StrRankID;
					}
				}
				else
				{
					this.StrErrorMessage = objTrans.OperationError;
					objTrans.End_Transaction();
					return "Error";
				}
			}
			catch(Exception e)
			{
				this.StrErrorMessage = e.Message;
				return "Error";
			}
		}			
	
		public string GetRankID(string sRank)		
		{
			
			
			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMax("RankID", TableName, "4");
				this.StrRankID = objTrans.DataTrigger_Get_Max(objdbhims);			

				if(!this.StrRankID.Equals("True"))
				{
					objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
					this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
					objTrans.End_Transaction();
	
					if(this.StrErrorMessage.Equals("True"))
					{
						this.StrErrorMessage = objTrans.OperationError;
						return "Error";
					}
					else
					{
						return StrRankID;
					}
				}
				else
				{
					this.StrErrorMessage = objTrans.OperationError;
					objTrans.End_Transaction();
					return "Error";
				}
			}
			catch(Exception e)
			{
				this.StrErrorMessage = e.Message;
				return "Error";
			}
		}			
	

		public DataView GetAll(int flag)
		{
			string sFactoryID = "";	
			string sActive = "";		
			string sOrgID = "";		
			string sRankName = "";

			switch(flag)
			{				
				case 1:										
					if(!this.StrFactoryID.Equals(Default))
					{sFactoryID = " And FactoryID = '"+ StrFactoryID +"' ";}

					if(!this.StrActive.Equals(Default))
					{sActive = " And Active = '"+ StrActive +"' ";}

					if(!this.StrOrgID.Equals(Default))
					{sOrgID = " And OrgID = '"+ StrOrgID +"' ";}					

					if(!this.StrRankName.Equals(Default))
					{sRankName = " And Upper(RankName) Like Trim('"+ StrRankName.ToUpper() +"') ";}			

					objdbhims.Query = "Select RankID, RankName from Rank Where 1 = 1"+sFactoryID+sActive+sOrgID+sRankName;
					
					break;

				case 2:										
					//
					break;
					
				case 3:										
					//
					break;

				case 4:
					//
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[5,3];

			if(!this.StrRankID.Equals(Default))
			{
				aryLIMS[0,0] = "RankID";
				aryLIMS[0,1] = this.StrRankID;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrRankName.Equals(Default))
			{
				aryLIMS[1,0] = "RankName";
				aryLIMS[1,1] = this.StrRankName;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryLIMS[2,0] = "Active";
				aryLIMS[2,1] = this.StrActive;
				aryLIMS[2,2] = "string";
			}			

			if(!this.StrOrgID.Equals(Default))
			{
				aryLIMS[3,0] = "OrgID";
				aryLIMS[3,1] = this.StrOrgID;
				aryLIMS[3,2] = "string";
			}		

			if(!this.StrFactoryID.Equals(Default))
			{
				aryLIMS[4,0] = "FactoryID";
				aryLIMS[4,1] = this.StrFactoryID;
				aryLIMS[4,2] = "string";
			}		

			return aryLIMS;
		}

		#endregion
	}
}
