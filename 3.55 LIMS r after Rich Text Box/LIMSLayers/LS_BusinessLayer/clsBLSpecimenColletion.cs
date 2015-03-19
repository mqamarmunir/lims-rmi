using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenColletion.
	/// </summary>
	public class clsBLSpecimenColletion
	{
		public clsBLSpecimenColletion()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDTRANSACTION";
		private const string cProcessID = "0002";
		private string StrErrorMessage = "";
		private string StrProcessID = Default;
		private string StrProcedureID = Default;
		private string StrMSerialNo = Default;		
		private string StrLabID = Default;		
		private string StrDSerialNo = Default;		
		private string StrSectionID = Default;		
		private string StrTestGroupID = Default;		
		private string StrLabIDFrom = Default;		
		private string StrLabIDTo = Default;		
		private string StrPatientName = Default;		
		private string StrSex = Default;
		private string StrTestID = Default;
		private string StrPLNo = Default;
		private string StrWardID = Default;
		private string StrPatientType = Default;
		private string StrIOPatient = Default;
		private string StrEnteredateF = Default;		
		private string StrEnteredateT = Default;				
		private string StrSpecimenType = Default;
        private string StrSpec_Comment = Default;
        private string StrMStatus = Default;
        private string StrCancelReason = Default;
        private string StrSpecimenCollectedBy = Default;
        private string StrSpecimenCollectedOn = Default;

        private string _Extorgid = Default;

        
        private string _TestCost = Default;

        

        #endregion

		#region "Properties"
        public string TestCost
        {
            get { return _TestCost; }
            set { _TestCost = value; }
        }
        public string Extorgid
        {
            get { return _Extorgid; }
            set { _Extorgid = value; }
        }
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
		
		public string LabIDFrom
		{
			get{	return StrLabIDFrom;	}
			set{	StrLabIDFrom = value;	}
		}	
		
		public string LabIDTo
		{
			get{	return StrLabIDTo;	}
			set{	StrLabIDTo = value;	}
		}
        public string LabID
        {
            get { return StrLabID; }
            set { StrLabID = value; }
        }
		
		public string WardID
		{
			get{	return StrWardID;	}
			set{	StrWardID = value;	}
		}	

		public string PatientType
		{
			get{	return StrPatientType;	}
			set{	StrPatientType = value;	}
		}			

		public string IOPatient
		{
			get{	return StrIOPatient;	}
			set{	StrIOPatient = value;	}
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

		public string EnteredateF
		{
			get{	return StrEnteredateF;		}
			set{	StrEnteredateF = value;	}
		}		

		public string EnteredateT
		{
			get{	return StrEnteredateT;		}
			set{	StrEnteredateT = value;	}
		}				
		
		public string SpecimenType
		{
			get{	return StrSpecimenType;		}
			set{	StrSpecimenType = value;	}
		}				

		public string ErrorMessage
		{			
			get{ return StrErrorMessage;	}
		}

        public string Spec_Comment
        {
            get { return StrSpec_Comment; }
            set { StrSpec_Comment = value; }
        }

        public string MStatus
        {
            get { return StrMStatus; }
            set { StrMStatus = value; }
        }
        public string CancelReason
        {
            get { return StrCancelReason; }
            set { StrCancelReason = value; }
        }
        public string SpecimenCollectedBy
        {
            get { return StrSpecimenCollectedBy; }
            set { StrSpecimenCollectedBy = value; }
        }
        public string SpecimenCollectedOn
        {
            get { return StrSpecimenCollectedOn; }
            set { StrSpecimenCollectedOn = value; }
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

        public bool Update_Comment()
        {
            objTrans.Start_Transaction();
            objdbhims.Query = "update ls_tdtransaction set spec_coment='" + StrSpec_Comment + "' where dserialno=" + StrDSerialNo + "";
            StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

            if (this.StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }          			

            objTrans.End_Transaction();
            return true;
        }

		public bool Update()
		{				
			clsBLTestProcess objTTestProcess = new clsBLTestProcess();			
			
			//DSerialNo, ProcedureID			

			//DataView dvTSC = GetAll(2);
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();
			//foreach (DataRow DR in dvTSC.Table.Rows)
			//{
				/*LoadBuffers(dataRow);
				listBox1.Items.Add( Phonenum + "\t\t" + Subscriber);
				DS.Tables.Rows[0]["MaxID"].ToString();*/
				//StrDSerialNo = DR["DSerialNo"].ToString();
				//StrProcedureID = DR["ProcedureID"].ToString();
				StrProcessID = objTTestProcess.GetNextProcessID(StrProcedureID,cProcessID);
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					return false;
				}
			//} 			
			
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
        public bool updatestatus()
        {
            objdbhims.Query = "Update Ls_TMTransaction Set MStatus='" + StrMStatus + "',cancelreason='"+StrCancelReason+"' where LabID='" + StrLabID + "'";
            objTrans.Start_Transaction();
            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                objTrans.End_Transaction();
                return false;
            }
            objTrans.End_Transaction();
            return true;
        }


		public DataView GetAll(int flag)
		{
			string sSectionID = "", sTestGroupID = "", sPatientName = "", sSex = "", sLabIDFrom = "", sLabIDTo = "", sTestID = "", sPLNo = "", sWardID = "", sPatientType = "", sIOPatient = "", sEnteredateF = "", sEnteredateT  = "", sSpecimenType = "", sProcessID = "",externalorgid="";

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
					
					if(!this.StrLabIDFrom.Equals(Default))
					{sLabIDFrom = " And m.LabID >= '"+ LabIDFrom +"' ";}
					
					if(!this.StrLabIDTo.Equals(Default))
					{sLabIDTo = " And m.LabID <= '"+ LabIDTo +"' ";}

					if (ValidateDF())
					{
						if(!this.StrEnteredateF.Equals(Default))
						{sEnteredateF = " And m.EntryDateTime >= to_date('"+ StrEnteredateF +"', 'dd/mm/yyyy') ";}
					}

					if (ValidateDT())
					{
						if(!this.StrEnteredateT.Equals(Default))
						{sEnteredateT = " And m.EntryDateTime <= to_date('"+ StrEnteredateT +"', 'dd/mm/yyyy') ";}
					}	

					if(!this.StrSpecimenType.Equals(Default))
					{
						sSpecimenType = " And m.MSerialNo in (select MSerialNo from LS_TDTRANSACTION Where TestID in (Select TestID from LS_TTest Where SpecimenType = '"+ SpecimenType +"'))";

					}

                     objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName,p.Patientname as namewotitle, SubStr(p.PSex, 1, 1) as PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, p.PType As Type, p.ServiceNo, p.WardName, m.LabID,m.IOP,m.ENTRYDATETIME,(Select count(d.spec_coment) from ls_tdtransaction d where d.mserialno=m.mserialno and (d.spec_coment is not null or trim(d.spec_coment)!='') ) spec_coment, (select nvl(count(d.testid),0) from ls_tdtransaction d inner join ls_ttest t on d.testid=t.testid where t.external='Y' and d.processid='0002' and d.mserialno=m.mserialno ) as externaltest from LS_tMTransaction m, LS_vPatient p Where m.MSerialNo = p.MSerialNo " + sPatientName + sSex + " And m.MStatus not in ('C') And m.MSerialNo in (Select MSerialNo from LS_TDTransaction where ProcessID = '" + cProcessID + "' " + sSectionID + sTestGroupID + ") " + sLabIDFrom + sLabIDTo + sEnteredateF + sEnteredateT + sSpecimenType + "Order By m.Priority DESC, m.MSerialNo";
/*
						Select m.MSerialNo, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.ProcessID = '" + cProcessID + "' order by DOrder";					*/
						
						/*Select m.MSerialNo, t.Test, p.PFName As PatientName, p.PSex, t.ProcedureID, m.Type, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.ProcessID = '" + cProcessID + "' order by DOrder";*/
					break;

				case 2:
					objdbhims.Query = "Select DSerialNo, ProcedureID from LS_tDTransaction Where MSerialNo = '"+StrMSerialNo+"'";						
						
						/*Select m.MSerialNo, d.DTransID, t.Test, p.PFName As PatientName, p.PSex, m.Type, 'Positive' As Result, '--Result Range' As ResultRange, 'Opinion--' As Opinion1, 'Comments--' As Comment1, m.Priority from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And Upper(m.MSerialNo) = '" + StrMSerialNo.ToUpper() + "' order by DOrder";*/
					break;
					
				case 3:
					if (ValidateDF())
					{
						if(!this.StrEnteredateF.Equals(Default))
						{sEnteredateF = " And m.entrydatetime >= to_date('"+ StrEnteredateF +"', 'dd/mm/yyyy') ";}
					}

					if (ValidateDT())
					{
						if(!this.StrEnteredateT.Equals(Default))
						{sEnteredateT = " And m.EntryDateTime <= to_date('"+ StrEnteredateT +"', 'dd/mm/yyyy') ";}
					}	

					if(!this.StrSectionID.Equals(Default))
					{sSectionID = " And d.SectionID = '"+ StrSectionID +"' ";}

					if(!this.StrPLNo.Equals(Default))
					{sPLNo = " And trim(m.PRNo) = '"+ StrPLNo +"' ";}

					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}

					if(!this.StrTestID.Equals(Default))
					{sTestID = " And d.TestID = '"+ StrTestID +"' ";}

					if(!this.StrPatientName.Equals(Default))
					{sPatientName = " And Upper(p.PFName||' '||p.PMName||' '||p.PLName) Like '%"+ StrPatientName.ToUpper() +"%'";}

					if(!this.StrSex.Equals(Default))
					{sSex = " And p.PSex = '"+ StrSex +"' ";}

					if(!this.StrLabIDFrom.Equals(Default))
					{sLabIDFrom = " And m.LabID >= '"+ LabIDFrom +"' ";}

					if(!this.StrLabIDTo.Equals(Default))
					{sLabIDTo = " And m.LabID <= '"+ LabIDTo +"' ";}

					if(!this.StrWardID.Equals(Default))
					{sWardID = " And p.WardID = '"+ StrWardID +"' ";}

					if(!this.StrPatientType.Equals(Default))
					{sPatientType = " And m.Type = '"+ StrPatientType +"' ";}

					if(!this.StrIOPatient.Equals(Default))
					{sIOPatient = " And m.IOP = '"+ StrIOPatient +"' ";}										

					if(!this.StrProcessID.Equals(Default))
					{sProcessID = " And d.ProcessID in ("+ StrProcessID +")";}
                    if (!this._Extorgid.Equals(Default))
                    { externalorgid = " And d.extorgid =" + Extorgid; }	


					if ((sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sLabIDFrom + sLabIDTo + sWardID + sIOPatient + sPatientType + sEnteredateF + sEnteredateT) == "")
					{
						sSectionID = " And 1 = 2";
					}

                    objdbhims.Query = "Select NVL(trim(d.spec_coment),'xxxx') as spec_coment,LS_GetPriority(d.priority) As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo, d.DSerialNo, case when (d.extorgid is null or d.extorgid=0) then t.Test else t.test||'('||(Select o1.name from ls_textorganization o1 where o1.orgid=d.extorgid)||')' end as Test, NVL(p.ServiceNo, ''), to_char(d.Enteredate, 'dd/mm/yyyy hh:mi am') As EnteredDate,to_char(d.DeliveryDate,'dd/mm/yyyy hh:mi am') as DeliveryDate, p.WardName, m.LabID, LS_GetLocation(d.ProcessID) As Location, d.ProcessID,m.Prno,nvl(d.path_img1,'') path_img1, nvl(d.path_img2,'') path_img2,nvl(o.name,'RMI') as Origin  from LS_tMTransaction m, LS_vPatient p, LS_TDTransaction d, LS_TTest t,ls_textorganization o Where m.MSerialNo = p.MSerialNo And m.MStatus not in ('C') And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.SectionID = t.SectionID and d.TestGroupID = t.TestGroupID and  m.originplaceid=o.cliqbranchid(+) " + sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sLabIDFrom + sLabIDTo + sWardID + sIOPatient + sPatientType + sEnteredateF + sEnteredateT + sProcessID +externalorgid+ "  Order By m.MSerialNo";
					break;
                case 4:
                    objdbhims.Query = "Select Distinct(CANCELREASON) From LS_TmTransaction where cancelreason is not null";
                    break;
                case 5:
                    if(!this.StrLabIDFrom.Equals(Default))
					{sLabIDFrom = " And replace(m.LabID,'-','') >= '"+ LabIDFrom +"' ";}

					if(!this.StrLabIDTo.Equals(Default))
					{sLabIDTo = " And replace(m.LabID,'-','') <= '"+ LabIDTo +"' ";}
                    objdbhims.Query = @" Select NVL(trim(d.spec_coment),'xxxx') as spec_coment,LS_GetPriority(d.priority) As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo, d.DSerialNo, case when (d.extorgid is null or d.extorgid=0) then t.Test else t.test||'( External )' end as Test, NVL(p.ServiceNo, ''), to_char(d.Enteredate, 'dd/mm/yyyy hh:mi am') As EnteredDate,to_char(d.DeliveryDate,'dd/mm/yyyy hh:mi am') as DeliveryDate, p.WardName, m.LabID, LS_GetLocation(d.ProcessID) As Location, d.ProcessID,m.Prno,nvl(d.path_img1,'') path_img1, nvl(d.path_img2,'') path_img2,nvl(o.name,'RMI') as Origin  from LS_tMTransaction m, LS_vPatient p, LS_TDTransaction d, LS_TTest t,ls_textorganization o Where m.MSerialNo = p.MSerialNo And m.MStatus not in ('C') And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.SectionID = t.SectionID and d.TestGroupID = t.TestGroupID and  m.originplaceid=o.cliqbranchid(+) " + sLabIDFrom + sLabIDTo + "  Order By m.MSerialNo";
					
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
						
			if(!this.StrProcessID.Equals(Default))
			{
				aryTestGroup[1,0] = "ProcessID";
				aryTestGroup[1,1] = this.StrProcessID;
				aryTestGroup[1,2] = "string";
			}
            if (!this.StrSpecimenCollectedBy.Equals(Default))
            {
                aryTestGroup[2, 0] = "SpecimenCollectedBy";
                aryTestGroup[2, 1] = this.StrSpecimenCollectedBy;
                aryTestGroup[2, 2] = "string";
            }
            if (!this.StrSpecimenCollectedOn.Equals(Default))
            {
                aryTestGroup[3, 0] = "SpecimenCollectedOn";
                aryTestGroup[3, 1] = this.StrSpecimenCollectedOn;
                aryTestGroup[3, 2] = "date";
            }
            if (!this.Extorgid.Equals(Default))
            {
                aryTestGroup[4, 0] = "extorgid";
                aryTestGroup[4, 1] = this._Extorgid;
                aryTestGroup[4, 2] = "int";
            }
            if (!this._TestCost.Equals(Default))
            {
                aryTestGroup[5, 0] = "testcost";
                aryTestGroup[5, 1] = this._TestCost;
                aryTestGroup[5, 2] = "int";
            }
            
			return aryTestGroup;
		}

		public bool ValidateDF()
		{
			Validation valid = new Validation();

			if(!this.EnteredateF.Equals("") && !valid.IsDate(this.EnteredateF))
			{
				this.StrErrorMessage = "Please enter valid Date. (days/month/year)";
				return false;
			}			
			return true;
		}	

		public bool ValidateDT()
		{
			Validation valid = new Validation();			
			if(!this.EnteredateT.Equals("") && !valid.IsDate(this.EnteredateT))
			{
				this.StrErrorMessage = "Please enter valid Date. (days/month/year)";
				return false;
			}
			return true;
		}	
		#endregion		
	}
}