using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenColletion.
	/// </summary>
	public class clsBLMisc
	{
		public clsBLMisc()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		private const string Default = "";
		private string StrErrorMessage = "";
		private string StrMSerialNo = Default;		
		private string StrDSerialNo = Default;		
		private string StrSectionID = Default;		
		private string StrTestGroupID = Default;		
		private string StrMSerialNoFrom = Default;		
		private string StrMSerialNoTo = Default;		
		private string StrPatientName = Default;		
		private string StrSex = Default;
		private string StrTestID = Default;
		private string StrPLNo = Default;
		private string StrStatus = Default;

		#endregion

		#region "Properties"
		public string MSerialNo
		{
			get{	return StrMSerialNo;	}
			set{	StrMSerialNo = value;	}
		}	

		public string DSerialNo
		{
			get{	return StrDSerialNo;	}
			set{	StrDSerialNo = value;	}
		}	
	
		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}	
		
		public string TestGroupID
		{
			get{	return StrTestGroupID;	}
			set{	StrTestGroupID = value;	}
		}	
		
		public string MSerialNoFrom
		{
			get{	return StrMSerialNoFrom;	}
			set{	StrMSerialNoFrom = value;	}
		}	
		
		public string MSerialNoTo
		{
			get{	return StrMSerialNoTo;	}
			set{	StrMSerialNoTo = value;	}
		}	
		
		public string PatientName
		{
			get{	return StrPatientName;	}
			set{	StrPatientName = value;	}
		}	
		
		public string Sex
		{
			get{	return StrSex;	}
			set{	StrSex = value;	}
		}

		public string TestID
		{
			get{	return StrTestID;	}
			set{	StrTestID = value;	}
		}

		public string PLNo
		{
			get{	return StrPLNo;		}
			set{	StrPLNo = value;	}
		}

		public string Status
		{
			get{	return StrStatus;		}
			set{	StrStatus = value;	}
		}
		
		public string ErrorMessage
		{			
			get{ return StrErrorMessage;	}
		}

		#endregion
		
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public bool Insert()
		{
			//
			return true;
		}

		public bool Update()
		{				
			return true;
		}


		public bool UpdateAll(string[,] arrayUpdate)
		{		
			return true;
		}


		public DataView GetAll(int flag)
		{
			string sSectionID = "", sTestGroupID = "", sPatientName = "", sSex = "", sMSerialNoFrom = "", sMSerialNoTo = "", sTestID = "", sPLNo = "", sStatus = "";

			switch(flag)
			{
				case 1:
					
					if(!this.StrSectionID.Equals(Default))
					{sSectionID = " And SectionID = '"+ StrSectionID +"' ";}
					
					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And TestGroupID = '"+ StrTestGroupID +"' ";}
					
					if(!this.StrPatientName.Equals(Default))
					{sPatientName = " And p.PFName||p.PMName||p.PLName  Like '%"+ StrPatientName +"%' ";}
					
					if(!this.StrSex.Equals(Default))
					{sSex = " And p.PSex = '"+ StrSex +"' ";}
					
					if(!this.StrMSerialNoFrom.Equals(Default))
					{sMSerialNoFrom = " And m.MSerialNo >= '"+ MSerialNoFrom +"' ";}
					
					if(!this.StrMSerialNoTo.Equals(Default))
					{sMSerialNoTo = " And m.MSerialNo <= '"+ MSerialNoTo +"' ";}

					if(this.StrStatus.Equals("C"))
					{sStatus = " And m.MStatus = 'C' ";}
					
					if(this.StrStatus.Equals("N"))
					{sStatus = " And m.MStatus not in ('C') ";}

					if(!this.StrPLNo.Equals(Default))
					{sPLNo = " And p.ServiceNo = '"+ StrPLNo +"' ";}

					

					objdbhims.Query = "Select m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, p.PType As Type, p.ServiceNo, m.MStatus, p.WardName from LS_tMTransaction m, LS_vPatient p Where m.MSerialNo = p.MSerialNo "+sPatientName+sSex+" And m.MSerialNo in (Select MSerialNo from LS_TDTransaction where 1 = 1 "+sSectionID+sTestGroupID+") "+sMSerialNoFrom+sMSerialNoTo+sStatus+sPLNo+"Order By m.MSerialNo";
					/*
											Select m.MSerialNo, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.ProcessID = '" + cProcessID + "' order by DOrder";					*/
						
					/*Select m.MSerialNo, t.Test, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d, p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.ProcessID = '" + cProcessID + "' order by DOrder";*/
					break;

				case 2:
					if(!this.StrSectionID.Equals(Default))
					{sSectionID = " And SectionID = '"+ StrSectionID +"' ";}
					
					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And TestGroupID = '"+ StrTestGroupID +"' ";}
					
					if(!this.StrPatientName.Equals(Default))
					{sPatientName = " And p.PFName||p.PMName||p.PLName  Like '%"+ StrPatientName +"%' ";}
					
					if(!this.StrSex.Equals(Default))
					{sSex = " And p.PSex = '"+ StrSex +"' ";}
					
					if(!this.StrMSerialNoFrom.Equals(Default))
					{sMSerialNoFrom = " And m.MSerialNo >= '"+ MSerialNoFrom +"' ";}
					
					if(!this.StrMSerialNoTo.Equals(Default))
					{sMSerialNoTo = " And m.MSerialNo <= '"+ MSerialNoTo +"' ";}

					if(this.StrStatus.Equals("C"))
					{sStatus = " And m.MStatus = 'C' ";}
					
					if(this.StrStatus.Equals("N"))
					{sStatus = " And m.MStatus not in ('C') ";}

					

					objdbhims.Query = "Select m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, p.PType As Type, p.ServiceNo, m.MStatus, m.TotalAmount, m.TotalAmount - m.PaidAmount As Dues from LS_tMTransaction m, LS_vPatient p Where m.MSerialNo = p.MSerialNo And m.TotalAmount - PaidAmount > 0 "+sPatientName+sSex+" And m.MSerialNo in (Select MSerialNo from LS_TDTransaction where 1 = 1 "+sSectionID+sTestGroupID+") "+sMSerialNoFrom+sMSerialNoTo+sStatus+"Order By m.MSerialNo";
					/*
											Select m.MSerialNo, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.ProcessID = '" + cProcessID + "' order by DOrder";					*/
						
					/*Select m.MSerialNo, t.Test, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.ProcessID = '" + cProcessID + "' order by DOrder";*/
					break;
					
				case 3:
					if(!this.StrSectionID.Equals(Default))
					{sSectionID = " And d.SectionID = '"+ StrSectionID +"' ";}

					if(!this.StrPLNo.Equals(Default))
					{sPLNo = " And p.ServiceNo = '"+ StrPLNo +"' ";}

					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}

					if(!this.StrTestID.Equals(Default))
					{sTestID = " And d.TestID = '"+ StrTestID +"' ";}

					if(!this.StrPatientName.Equals(Default))
					{sPatientName = " And Upper(p.PFName||' '||p.PMName||' '||p.PLName) Like '%"+ StrPatientName.ToUpper() +"%'";}

					if(!this.StrSex.Equals(Default))
					{sSex = " And p.PSex = '"+ StrSex +"' ";}

					if(!this.StrMSerialNoFrom.Equals(Default))
					{sMSerialNoFrom = " And m.MSerialNo >= '"+ MSerialNoFrom +"' ";}

					if(!this.StrMSerialNoTo.Equals(Default))
					{sMSerialNoTo = " And m.MSerialNo <= '"+ MSerialNoTo +"' ";}

					objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, p.PType As Type, p.ServiceNo, d.DSerialNo, t.Test, NVL(p.ServiceNo, ''), to_char(d.Enteredate, 'dd/mm/yyyy') As EnteredDate from LS_tMTransaction m, LS_vPatient p, LS_TDTransaction d, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.SectionID = t.SectionID And d.TestGroupID = t.TestGroupID " + sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sMSerialNoFrom + sMSerialNoTo + " Order By m.Priority DESC, m.MSerialNo";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryTestGroup = new string[6,3];

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryTestGroup[0,0] = "DSerialNo";
				aryTestGroup[0,1] = this.StrDSerialNo;
				aryTestGroup[0,2] = "int";
			}						
			
			return aryTestGroup;
		}

		#endregion		
	}
}