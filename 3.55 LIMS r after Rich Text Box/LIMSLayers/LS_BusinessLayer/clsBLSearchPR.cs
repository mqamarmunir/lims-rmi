using System;
using System.Data;  
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	///		Application	:	Hospital Information & Management System (HIMS)
	///		Class for	:	Searching Patients those are registered
	///		Developer	:	Trees Software (Pvt) Ltd.
	///		Date		:	April 2005
	/// 	Type		:	Business Layer Class
	/// </summary>
	public class clsBLSearchPR
	{
		public clsBLSearchPR()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private string StrErrorMessage = "";
		private string StrPatientID = Default;
		private string StrName = Default;
		private string StrSex = Default;
		private string StrNIC = Default;
		private string StrAddress = Default;
		private string StrPhone = Default;
		private string StrBloodGroup = Default;
		private string StrPLNo = Default;
		private string StrSectionID = Default;
		private string StrFactoryID = Default;
		private string StrOrgID = Default;
		private string StrRankID = Default;
		private string StrFHName = Default;

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		public string PatientID
		{
			get{	return StrPatientID;	}
			set{	StrPatientID = value;	}
		}

		public string Name
		{
			get{	return StrName;	}
			set{	StrName = value;	}
		}

		public string Sex
		{
			get{	return StrSex;	}
			set{	StrSex = value;	}
		}

		public string NIC
		{
			get{	return StrNIC;	}
			set{	StrNIC = value;	}
		}

		public string Address
		{
			get{	return StrAddress;	}
			set{	StrAddress = value;	}
		}

		public string PhoneNo
		{
			get{	return StrPhone;	}
			set{	StrPhone = value;	}
		}

		public string BloodGroup
		{
			get{	return StrBloodGroup;	}
			set{	StrBloodGroup = value;	}
		}

		public string PLNo
		{
			get{	return StrPLNo;	}
			set{	StrPLNo = value;	}
		}

		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}

		public string FactoryID
		{
			get{	return StrFactoryID;	}
			set{	StrFactoryID = value;	}
		}

		public string OrgID
		{
			get{	return StrOrgID;	}
			set{	StrOrgID = value;	}
		}

		public string RankID
		{
			get{	return StrRankID;	}
			set{	StrRankID = value;	}
		}

		public string FHName
		{
			get{	return StrFHName;	}
			set{	StrFHName = value;	}
		}

		#endregion

		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public DataView GetAll(int flag)
		{
			clsoperation objTrans = new clsoperation();

			switch(flag)
			{
				case 1:
					string sPatientID = "", sName = "", sSex = "", sNIC = "", sAddress = "", sPhone = "", sBloodGroup = "", sPLNo = "", sSectionID = "", sFactoryID = "", sOrgID = "", sRankID = "", sFHName = "";

					if(!StrPatientID.Equals(""))
					{
						sPatientID = " And Upper(pr.PatientID) = '" + StrPatientID.ToUpper() + "' ";
					}
					
					if(!StrName.Equals(""))
					{
						sName = " And Upper(NVL(pr.Title, '')||' '||NVL(pr.PFName, '')||' '||NVL(pr.PMName, '')||' '||NVL(pr.PLName, '')) like '%'||'" + StrName.ToUpper() + "'||'%' ";
					}

					if(!StrSex.Equals(""))
					{
						sSex = " And Upper(pr.Sex) = '" + StrSex.ToUpper() + "' ";
					}

					if(!StrNIC.Equals(""))
					{
						sNIC = " And Upper(pr.NIC) = '" + StrNIC.ToUpper() + "' ";
					}

					if(!StrAddress.Equals(""))
					{
						sAddress = " And Upper(pr.Address) like '%'||'" + StrAddress.ToUpper() + "'||'%' ";
					}

					if(!StrPhone.Equals(""))
					{
						sPhone = " And (Upper(Phone1) like '%'||'" + StrPhone.ToUpper() + "'||%' or Upper(Phone2) like '%'||'" + StrPhone.ToUpper() + "'||%') ";
					}

					if(!StrBloodGroup.Equals(""))
					{
						sBloodGroup = " And Upper(pr.BloodGroup) = '" + StrBloodGroup.ToUpper() + "' ";
					}

					if(!StrPLNo.Equals(""))
					{
						sPLNo = " And Upper(d.PLNo) = '" + StrPLNo.ToUpper() + "' ";
					}

					if(!StrSectionID.Equals(""))
					{
						sSectionID = " And Upper(d.SectionID) = '" + StrSectionID.ToUpper() + "' ";
					}

					if(!StrFactoryID.Equals(""))
					{
						sFactoryID = " And Upper(d.FactoryID) = '" + StrFactoryID.ToUpper() + "' ";
					}

					if(!StrOrgID.Equals(""))
					{
						sOrgID = " And Upper(d.OrgID) = '" + StrOrgID.ToUpper() + "' ";
					}

					if(!StrRankID.Equals(""))
					{
						sRankID = " And Upper(d.RankID) = '" + StrRankID.ToUpper() + "' ";
					}

					if(!StrFHName.Equals(""))
					{
						sFHName = " And Upper(e.FHName) like '%'||'" + StrFHName.ToUpper() + "'||'%' ";
					}

					objdbhims.Query = "Select NVL(pr.PatientID, '') As PatientID, NVL(pr.Title, '')||' '||NVL(pr.PFName, '')||' '||NVL(pr.PMName, '')||' '||NVL(pr.PLName, '') As PName, Case When pr.Sex = 'M' Then 'Male' Else 'Female' End As Sex, NVL(pr.NIC, '') As NIC, NVL(pr.BloodGroup, '') As BloodGroup, NVL(d.PLNo, '') As PLNo, NVL(d.Relation, '') As Relation from TPatientRegistration pr, Dependent d, Employee e Where pr.PatientID = d.PatientID(+) And d.EmployeeID = e.EmployeeID(+) " + sPatientID + sName + sSex + sNIC + sAddress + sPhone + sBloodGroup + sPLNo + sSectionID + sFactoryID + sOrgID + sRankID + sFHName;
					break;

				case 2:
					objdbhims.Query = "Select NVL(Title, '') Title, NVL(PFName, '') As PFName, NVL(PMName, '') As PMName, NVL(PLName, '')PLName, NVL(Phone2, '') As OPhone, NVL(CellPhone, '') As CPhone, NVL(EMail, '') As Email, NVL(Phone1, '') As HPhone, NVL(Address, '') As Address, NVL(Sex, '') As Sex, NVL(to_char(DOB, 'dd/mm/yyyy'), '') As DOB From TPatientRegistration Where PatientID='" + StrPatientID + "'";
					break;

				case 3:
					objdbhims.Query = "Select NVL(e.Title, '') As ETitle, NVL(e.EFName, '') As EFName, NVL(e.EMName, '') As EMName, NVL(e.ELName, '') As ELName, NVL(d.FactoryID, '') As FactoryID, NVL(d.SectionID, '') As SectionID, NVL(d.PLNo, '') As PLNo, NVL(d.RankID, '') As RankID, NVL(e.OPhone1, '') As OPhone1, NVL(e.OPhone2, '') As OPhone2, NVL(e.CPhone, '') As CPhone, NVL(e.Email, '') As EMail, NVL(e.HPhone1, '') As HPhone1, NVL(e.HPhone2, '') As HPhone2, NVL(e.TempAddress, '') As TempAddress, NVL(e.PermentAddress, '') As PermentAddress, NVL(Relation, '') As Relation, NVL(d.Title, '') As DTitle, NVL(d.DFName, '') As DFName, NVL(d.DMName, '') As DMName, NVL(d.DLName, '') As DLName, NVL(d.Sex, '') As Sex, NVL(to_char(d.DOB, 'dd/mm/yyyy'), '') As DOB From Dependent d, Employee e Where d.PatientID = '" + StrPatientID + "' And d.EmployeeID = e.EmployeeID";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		#endregion
	}
}
