using System;
using System.Data;  
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	"Factory - Section" Table
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	March 2005
	/// 	Type		:	Business Layer Class
	/// </summary>
	/// 
	
	public class clsBLFacSection
	{
		public clsBLFacSection()
		{
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "Section";
		private string StrErrorMessage = "";
		
		private string StrSectionID = Default;
		private string StrSectionName = Default;		
		private string StrActive = Default;		
		private string StrFactoryID = Default;
		private string StrOrgID = Default;
		#endregion			

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		public string SectionID
		{
			get{	return	StrSectionID;	}
			set{	StrSectionID = value;	}
		}

		public string SectionName
		{
			get{	return StrSectionName;	}
			set{	StrSectionName = value;	}
		}

		public string FactoryID
		{
			get{	return StrFactoryID;	}
			set{	StrFactoryID = value;	}
		}
		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
		public string OrgID
		{
			get{	return StrOrgID;	}
			set{	StrOrgID = value;	}
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

				objdbhims.Query = objQB.QBGetMax("SectionID", TableName, "4");
				this.StrSectionID = objTrans.DataTrigger_Get_Max(objdbhims);			

				if(!this.StrSectionID.Equals("True"))
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
						return StrSectionID;
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
			string sSectionName = "";

			switch(flag)
			{				
				case 1:										
					if(!this.StrFactoryID.Equals(Default))
					{sFactoryID = " And FactoryID = '"+ StrFactoryID +"' ";}

					if(!this.StrActive.Equals(Default))
					{sActive = " And Active = '"+ StrActive +"' ";}

					if(!this.StrOrgID.Equals(Default))
					{sOrgID = " And OrgID = '"+ StrOrgID +"' ";}					

					if(!this.StrSectionName.Equals(Default))
					{sSectionName = " And Upper(SectionName) Like Trim('"+ StrSectionName.ToUpper() +"') ";}		

					objdbhims.Query = "Select * from " + TableName + " Where 1 = 1"+sFactoryID+sActive+sOrgID+sSectionName;					
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

			if(!this.StrSectionID.Equals(Default))
			{
				aryLIMS[0,0] = "SectionID";
				aryLIMS[0,1] = this.StrSectionID;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrSectionName.Equals(Default))
			{
				aryLIMS[1,0] = "SectionName";
				aryLIMS[1,1] = this.StrSectionName;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryLIMS[2,0] = "Active";
				aryLIMS[2,1] = this.StrActive;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrFactoryID.Equals(Default))
			{
				aryLIMS[3,0] = "FactoryID";
				aryLIMS[3,1] = this.StrFactoryID;
				aryLIMS[3,2] = "string";
			}		

			if(!this.StrOrgID.Equals(Default))
			{
				aryLIMS[4,0] = "OrgID";
				aryLIMS[4,1] = this.StrOrgID;
				aryLIMS[4,2] = "string";
			}		

			return aryLIMS;
		}

		#endregion
	}
}