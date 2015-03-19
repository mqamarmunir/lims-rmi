using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLRole.
	/// </summary>
	public class clsBLRole
	{
		public clsBLRole()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TRole";
		private string StrErrorMessage = "";

		private string StrSectionID = Default;
		private string StrActive = Default;
		private string StrRoleID = Default;
		private string StrRole = Default;
		private string StrAcronym = Default;

		#endregion

		#region "Properties"
		
		public string RoleID
		{
			get{	return StrRoleID;	}
			set{	StrRoleID = value;	}
		}

		public string Role
		{
			get{	return StrRole;	}
			set{	StrRole = value;	}
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

					objdbhims.Query = objQB.QBGetMax("RoleID", TableName, "4");
					this.StrRoleID = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrRoleID.Equals("True"))
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
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select * from LS_TRole Where Upper(Role) like '%'||'" + StrRole.ToUpper() + "'||'%' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 2:
					objdbhims.Query = "Select * from LS_TRole Where Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;

				case 3:
					objdbhims.Query = "Select * from LS_TRole Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[5,3];

			if(!this.StrRoleID.Equals(Default))
			{
				aryLIMS[0,0] = "RoleID";
				aryLIMS[0,1] = this.StrRoleID;
				aryLIMS[0,2] = "string";
			}

			if(!this.StrRole.Equals(Default))
			{
				aryLIMS[1,0] = "Role";
				aryLIMS[1,1] = this.StrRole;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrActive.Equals(Default))
			{
				aryLIMS[2,0] = "Active";
				aryLIMS[2,1] = this.StrActive;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrAcronym.Equals(Default))
			{
				aryLIMS[3,0] = "Acronym";
				aryLIMS[3,1] = this.StrAcronym;
				aryLIMS[3,2] = "string";
			}

			if(!this.StrSectionID.Equals(Default))
			{
				aryLIMS[4,0] = "SectionID";
				aryLIMS[4,1] = this.StrSectionID;
				aryLIMS[4,2] = "string";
			}

			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_Role())
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

		public bool VD_Role()
		{
			Validation objValid = new Validation();

			if(StrRole.Equals("") || !objValid.IsName(StrRole))
			{
				this.StrErrorMessage = "Please enter Role. (empty/special character(s) are not allowed)";
				return false;
			}
			
			DataView dvRole = GetAll(1);

			if(!StrRoleID.Equals(Default))
			{
				dvRole.RowFilter = "RoleID <> '" + StrRoleID + "' And Role = '" + this.StrRole + "'";
			}
			else
			{
				dvRole.RowFilter = "Role = '" + this.StrRole + "'";
			}
			
			if(dvRole.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Role, it is already present.";
				return false;
			}

			return true;
		}

		public bool VD_Acronym()
		{
			Validation objValid = new Validation();

			if(StrAcronym.Equals("") || !objValid.IsName(StrAcronym))
			{
				this.StrErrorMessage = "Please enter Acronym. (empty/special character(s) are not allowed)";
				return false;
			}
			
			if(!objValid.IsAlpha(StrAcronym))
			{
				this.StrErrorMessage = "Please enter valid Acronym (space is not allowed)";
				return false;
			}

			DataView dvAcronym = GetAll(2);

			if(!StrRoleID.Equals(Default))
			{
				dvAcronym.RowFilter = "RoleID <> " + StrRoleID;
			}

			if(dvAcronym.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Acronym, it is already present.";
				return false;
			}

			return true;
		}

		#endregion
	}
}