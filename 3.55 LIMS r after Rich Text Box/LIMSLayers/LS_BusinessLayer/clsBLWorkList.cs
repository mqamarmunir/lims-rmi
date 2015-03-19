using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenColletion.
	/// </summary>
	public class clsBLWorkList
	{
		public clsBLWorkList()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDTRANSACTION";
		private const string cProcessID = "0003";
		private string StrErrorMessage = "";				
		private string StrProcessID = Default;
		private string StrProcedureID = Default;
		private string StrSectionID = Default;
		private string StrTestGroupID = Default;		
		private string StrWorkListNo = Default;
		private string StrDSerialNo = Default;				
		private string StrWorkListDate = Default;		
		private string StrNoofTest = Default;		
		private string StrGeneratedBy = Default;		

		#endregion

		#region "Properties"
		public string DSerialNo
		{
			get{	return StrDSerialNo;	}
			set{	StrDSerialNo = value;	}
		}	

		public string ProcessID
		{
			get{	return cProcessID;	}			
		}	

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}	
		
		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}

		public string WorkListNo
		{
			get{	return StrWorkListNo;	}
			set{	StrWorkListNo = value;	}
		}	

		public string WorkListDate
		{
			get{	return StrWorkListDate;	}
			set{	StrWorkListDate = value;	}
		}	

		public string NoofTest
		{
			get{	return StrNoofTest;	}
			set{	StrNoofTest = value;	}
		}	
		
		public string GeneratedBy
		{
			get{	return StrGeneratedBy;	}
			set{	StrGeneratedBy = value;	}
		}			
		
		public string TestGroupID
		{
			get{	return StrTestGroupID;	}
			set{	StrTestGroupID = value;	}
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
			if(this.StrSectionID.Equals(""))
			{
				this.StrErrorMessage = "Please select Section (empty is not allowed).";
				return false;
			}			

			try
			{
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();

				objdbhims.Query = objQB.QBGetMaxWorkListNo(StrSectionID);
				this.StrWorkListNo = objTrans.DataTrigger_Get_Max(objdbhims);		

				if(!this.StrWorkListNo.Equals("True"))
				{
					objdbhims.Query = objQB.QBInsert(MakeArrayInsert(), "LS_TWorkList");
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
			/*if (StrWorkListNo == Default) 
			{				
				bool isSuccessful = this.Insert();							
				if(!isSuccessful)
				{
					StrWorkListNo = Default;					
					return false;
				}
			}

			clsBLTestProcess objTTestProcess = new clsBLTestProcess();
			StrProcessID = objTTestProcess.GetNextProcessID(StrProcedureID,cProcessID);

			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();			
			
			objdbhims.Query = objQB.QBUpdate(MakeArrayUpdate(), TableName);
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
			}		*/		return true;		
		}

		public bool UpdateAll(string[,] arrayUpdate)
		{
			clsBLTestProcess objTTestProcess = new clsBLTestProcess();			

			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();			

			bool isSuccessful = this.Insert();							
			if(!isSuccessful)
			{				
				objTrans.End_Transaction();
				return false;
			}


			for(int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
			{			
				
				this.DSerialNo = arrayUpdate[counter, 0];	
				this.ProcedureID = arrayUpdate[counter, 1];
				this.SectionID = arrayUpdate[counter, 2];

				StrProcessID = objTTestProcess.GetNextProcessID(StrProcedureID,cProcessID);

				objdbhims.Query = objQB.QBUpdate(MakeArrayUpdate(), "LS_TDTransaction");
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
			string sTestGroupID = "";	
			string sWorkListNo = "";		

			switch(flag)
			{				
				case 1:										
					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}
					objdbhims.Query = "Select Distinct Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||p.PAgeUN As PAge, d.DSerialNo, t.Test, p.PType As Type,  p.ServiceNo, d.Times, d.ProcedureID  from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p, LS_TTest t  Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And m.MStatus not in ('C') And d.TestID = t.TestID And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' "+sTestGroupID+"";

					/*objdbhims.Query = "Select Distinct m.Priority, m.MSerialNo, p.PFName As PatientName, p.PSex, To_Char(p.PAgeD)||p.PAgeU As PAge, m.Type, p.ServiceNo, d.Times, t.Test, d.ProcedureID, d.DSerialNo  from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo  And d.TestID = d.TestID And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' Order By m.MSerialNo";*/
					break;

				case 2:										
					objdbhims.Query = "Select wl.SectionID, wl.WorkListNo, To_Char(wl.WorkListDate,'DD/MM/YYYY HH:MI:SS AM') As WorkListDate, NVL(p.Title, '')||' '||NVL(p.FName, '')||' '||NVL(p.MName, '')||' '||NVL(p.LName, '') As GeneratedBy, wl.NoofTest from LS_TWorkList wl, TPersonnel p Where wl.GeneratedBy = p.PersonID And wl.SectionID = '" + StrSectionID + "' Order By wl.WorkListNo Desc";				
					
					/*
					objdbhims.Query = "Select m.MSerialNo, d.DTransID, t.Test, p.PFName As PatientName, p.PSex, m.Type, 'Positive' As Result, '--Result Range' As ResultRange, 'Opinion--' As Opinion1, 'Comments--' As Comment1, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And Upper(m.MSerialNo) = '" + StrMSerialNo.ToUpper() + "' order by DOrder";*/
					break;
					
				case 3:										
					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}
					if(!this.StrWorkListNo.Equals(Default))
					{sWorkListNo = " And d.WorkListNo = "+ StrWorkListNo +" ";}
					objdbhims.Query = "Select Distinct Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||p.PAgeU As PAge, d.DSerialNo, t.Test, p.PType As Type,  p.ServiceNo, d.Times, d.ProcedureID  from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p, LS_TTest t  Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo  And d.TestID = t.TestID And m.MStatus not in ('C') And d.SectionID = '" + StrSectionID + "' "+sTestGroupID+sWorkListNo+"";

					/*objdbhims.Query = "Select * from LS_TTestGroup Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "' order by DOrder";*/
					break;

				case 4:
					objdbhims.Query = "Select NVL(Max(WorkListNo), 0) As WorkListNo from LS_TWorkList Where SectionID = '" +StrSectionID.ToUpper()+ "'";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArrayInsert()
		{
			string[,] aryTestGroup = new string[5,3];

			if(!this.StrWorkListNo.Equals(Default))
			{
				aryTestGroup[0,0] = "WorkListNo";
				aryTestGroup[0,1] = this.WorkListNo;
				aryTestGroup[0,2] = "int";
			}
						
			if(!this.StrSectionID.Equals(Default))
			{
				aryTestGroup[1,0] = "SectionID";
				aryTestGroup[1,1] = this.StrSectionID;
				aryTestGroup[1,2] = "string";
			}			

			if(!this.StrWorkListDate.Equals(Default))
			{
				aryTestGroup[2,0] = "WorkListDate";
				aryTestGroup[2,1] = this.StrWorkListDate;
				aryTestGroup[2,2] = "date";
			}			

			if(!this.StrGeneratedBy.Equals(Default))
			{
				aryTestGroup[3,0] = "GeneratedBy";
				aryTestGroup[3,1] = this.StrGeneratedBy;
				aryTestGroup[3,2] = "string";
			}			

			if(!this.StrNoofTest.Equals(Default))
			{
				aryTestGroup[4,0] = "NoofTest";
				aryTestGroup[4,1] = this.StrNoofTest;
				aryTestGroup[4,2] = "int";
			}			
			return aryTestGroup;
		}

		private string[,] MakeArrayUpdate()
		{
			string[,] aryTestGroup = new string[3,3];

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryTestGroup[0,0] = "DSerialNo";
				aryTestGroup[0,1] = this.StrDSerialNo;
				aryTestGroup[0,2] = "int";
			}
						
			if(!this.StrProcessID.Equals(Default))
			{
				aryTestGroup[1,0] = "ProcessID";
				aryTestGroup[1,1] = this.StrProcessID;
				aryTestGroup[1,2] = "string";
			}			

			if(!this.StrWorkListNo.Equals(Default))
			{
				aryTestGroup[2,0] = "WorkListNo";
				aryTestGroup[2,1] = this.StrWorkListNo;
				aryTestGroup[2,2] = "string";
			}			
			return aryTestGroup;
		}

		#endregion		
	}
}

