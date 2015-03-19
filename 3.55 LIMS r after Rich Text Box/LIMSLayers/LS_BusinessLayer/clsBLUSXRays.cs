using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLUSXRays.
	/// </summary>
	public class clsBLUSXRays
	{
		public clsBLUSXRays()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDTRANSACTION";
		private const string cProcessID = "0008";
		private string StrErrorMessage = "";
		private string StrProcessID = Default;
		private string StrProcedureID = Default;
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
		private string StrLastUpdatedBy = Default;		

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

		public string ProcessID
		{
			get{	return cProcessID;	}
		}

		public string ProcessIDVary
		{
			get{	return StrProcessID;	}			
			set{	StrProcessID = value;	}
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
		
		public string LastUpdatedBy
		{
			get{	return StrLastUpdatedBy;		}
			set{	StrLastUpdatedBy = value;	}
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
			clsBLTestProcess objTTestProcess = new clsBLTestProcess();			
			
			//DSerialNo, ProcedureID			

			DataView dvTSC = GetAll(2);
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();
			foreach (DataRow DR in dvTSC.Table.Rows)
			{
				/*LoadBuffers(dataRow);
				listBox1.Items.Add( Phonenum + "\t\t" + Subscriber);
				DS.Tables.Rows[0]["MaxID"].ToString();*/
				StrDSerialNo = DR["DSerialNo"].ToString();
				StrProcedureID = DR["ProcedureID"].ToString();
				StrProcessID = objTTestProcess.GetNextProcessID(StrProcedureID,cProcessID);
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					return false;
				}
			} 			
			
			objTrans.End_Transaction();
			return true;
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
*/
			return true;
		}


		public DataView GetAll(int flag)
		{
			string sSectionID = "", sTestGroupID = "", sPatientName = "", sSex = "", sMSerialNoFrom = "", sMSerialNoTo = "", sTestID = "", sPLNo = "";

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

					objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo from LS_tMTransaction m, LS_vPatient p Where m.MSerialNo = p.MSerialNo "+sPatientName+sSex+" And m.MSerialNo in (Select MSerialNo from LS_TDTransaction where ProcessID = '" + cProcessID + "' "+sSectionID+sTestGroupID+") "+sMSerialNoFrom+sMSerialNoTo+"Order By m.Priority DESC, m.MSerialNo";
					/*
											Select m.MSerialNo, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.ProcessID = '" + cProcessID + "' order by DOrder";					*/
						
					/*Select m.MSerialNo, t.Test, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.ProcessID = '" + cProcessID + "' order by DOrder";*/
					break;

				case 2:
					objdbhims.Query = "Select DSerialNo, ProcedureID from LS_tDTransaction Where MSerialNo = '"+StrMSerialNo+"'";						
						
					/*Select m.MSerialNo, d.DTransID, t.Test, p.PFName As PatientName, p.PSex, m.Type, 'Positive' As Result, '--Result Range' As ResultRange, 'Opinion--' As Opinion1, 'Comments--' As Comment1, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And Upper(m.MSerialNo) = '" + StrMSerialNo.ToUpper() + "' order by DOrder";*/
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

					objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo, d.DSerialNo, t.Test, NVL(p.ServiceNo, ''), to_char(d.Enteredate, 'dd/mm/yyyy') As EnteredDate from LS_tMTransaction m, LS_vPatient p, LS_TDTransaction d, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.SectionID = t.SectionID And d.TestGroupID = t.TestGroupID " + sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sMSerialNoFrom + sMSerialNoTo + " And d.ProcessID ='" + StrProcessID + "' Order By m.Priority DESC, m.MSerialNo";
					break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
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

			if(!this.StrLastUpdatedBy.Equals(Default))
			{
				aryTestGroup[2,0] = "LastUpdatedBy";
				aryTestGroup[2,1] = this.StrLastUpdatedBy;
				aryTestGroup[2,2] = "string";
			}			
			
			return aryTestGroup;
		}

		#endregion		
	}
}
