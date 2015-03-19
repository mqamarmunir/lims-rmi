using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLSpecimenColletion.
	/// </summary>
	public class clsBLGeneralTestResult
	{
		public clsBLGeneralTestResult()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TDTRANSACTION";
		private string cProcessID = "0004";
		private string StrErrorMessage = "";				
		private string StrNextProcessID = Default;
		private string StrProcedureID = Default;
		private string StrMSerialNo = Default;		
		private string StrDSerialNo = Default;				
		private string StrRSerialNo = Default;				
		private string StrSectionID = Default;			
		private string StrTestGroupID = Default;			
		private string StrTestID = Default;			
		private string StrTimes = Default;			
		private string StrOpinion = Default;						
		private string StrComments = Default;						
		private string StrAttributeID = Default;						
		private string StrResult = Default;						
		private string StrPrint = Default;						
		private string StrMinRange = Default;						
		private string StrMaxRange = Default;
        private string StrMinPValue = Default;
        private string StrMaxPValue = Default;
        private string StrRUnit = Default;
		private string StrMSerialNoFrom = Default;
		private string StrMSerialNoTo = Default;
		private string StrLabIDFrom = Default;
		private string StrLabIDTo = Default;
		private string StrSex = Default;
		private string StrAge = Default;
		private string StrRPrint = Default;
		private string StrWardID = Default;
		private string StrOrganismID = Default;
		private string StrDrugID = Default;
		private string StrMicroResult = Default;
		private string StrSensitivity = Default;
		private string StrTestType = Default;
        private string StrPatientName = Default;
        private string StrPRNo = Default;
        private string StrAbNormal = Default;
        private string StrResultHistoryID = Default;
        private string StrProcessID = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrRangeText = Default;
 
        private string Strpath_Img1 = Default;

       
        private string Strpath_Img2 = Default;
        private string Strpath_Img3 = Default;
        private string StrQualitative = Default;
        private string StrQuantitative = Default;

        private string StrHistory = Default;
        private string StrMethodID = Default;

        private string StrEvaluatedBy = Default;

        
        private string StrEvaluatedOn = Default;
        private string _AutoVerified = Default;
        private string _Spec_Coment = Default;
        private string _labid = Default;
        private string StrExternal = Default;
        

        

      
		#endregion					

		#region "Properties"
        public string Labid
        {
            get { return _labid; }
            set { _labid = value; }
        }
        public string Spec_Coment
        {
            get { return _Spec_Coment; }
            set { _Spec_Coment = value; }
        }
        public string AutoVerified
        {
            get { return _AutoVerified; }
            set { _AutoVerified = value; }
        }

		public string MSerialNo
		{
			get{	return StrMSerialNo;	}
			set{	StrMSerialNo = value;	}
		}	

		public string ProcessID
		{
			get{	return cProcessID;	}			
			set{	cProcessID = value;	}
		}	
		
		public string NextProcessID
		{
			get{	return StrNextProcessID;	}			
			set{	StrNextProcessID = value;	}			
		}	

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
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

		public string TestID
		{
			get{	return StrTestID;	}
			set{	StrTestID = value;	}
		}		
		
		public string Times
		{
			get{	return StrTimes;	}
			set{	StrTimes = value;	}
		}		
		
		public string Opinion
		{
			get{	return StrOpinion;	}
			set{	StrOpinion = value;	}
		}		
		
		public string Comments
		{
			get{	return StrComments;	}
			set{	StrComments = value;	}
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
		
		public string Sex
		{
			get{	return StrSex;	}
			set{	StrSex = value;	}
		}		
		
		public string Age
		{
			get{	return StrAge;	}
			set{	StrAge = value;	}
		}		
		
		public string RPrint
		{
			get{	return StrRPrint;	}
			set{	StrRPrint = value;	}
		}

		public string WardID
		{
			get{	return StrWardID;	}
			set{	StrWardID = value;	}
		}		
		
		public string OrganismID
		{
			get{	return StrOrganismID;	}
			set{	StrOrganismID = value;	}
		}		
		
		public string DrugID
		{
			get{	return StrDrugID;	}
			set{	StrDrugID = value;	}
		}		
		
		public string MicroResult
		{
			get{	return StrMicroResult;	}
			set{	StrMicroResult = value;	}
		}		

		public string Sensitivity
		{
			get{	return StrSensitivity;	}
			set{	StrSensitivity = value;	}
		}				

		public string TestType
		{
			get{	return StrTestType;	}
			set{	StrTestType = value;	}
		}

        public string PatientName
		{
            get { return StrPatientName; }
            set { StrPatientName = value; }
		}

        public string PRNo
        {
            get { return StrPRNo; }
            set { StrPRNo = value; }
        }
        public string AbNormal
        {
            get { return StrAbNormal; }
            set { StrAbNormal = value; }
        }

        public string ResultHistoryID
        {
            get { return StrResultHistoryID; }
            set { StrResultHistoryID = value; }
        }
        public string currProcessID
        {
            get { return StrProcessID; }
            set { StrProcessID = value; }
        }
        public string EnteredBy
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }
        public string EnteredOn
        {
            get { return StrEnteredOn; }
            set { StrEnteredOn = value; }
        }
        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }
        public string System_IP
        {
            get { return StrSystem_Ip; }
            set { StrSystem_Ip = value; }
        }
        public string RangeText
        {
            get { return StrRangeText; }
            set { StrRangeText = value; }
        }
        public string path_Img1
        {
            get { return Strpath_Img1; }
            set { Strpath_Img1 = value; }
        }
        public string path_Img2
        {
            get { return Strpath_Img2; }
            set { Strpath_Img2 = value; }
        }
        public string path_Img3
        {
            get { return Strpath_Img3; }
            set { Strpath_Img3 = value; }
        }
        public string Qualitative
        {
            get { return StrQualitative; }
            set { StrQualitative = value; }
        }


        public string Quantitative
        {
            get { return StrQuantitative; }
            set { StrQuantitative = value; }
        }

        public string History
        {
            get { return StrHistory; }
            set { StrHistory = value; }
        }

        public string MethodID
        {
            get { return StrMethodID; }
            set { StrMethodID = value; }
        }


		public string ErrorMessage
		{			
			get{ return StrErrorMessage;	}
		}
        public string EvaluatedBy
        {
            get { return StrEvaluatedBy; }
            set { StrEvaluatedBy = value; }
        }
        public string EvaluatedOn
        {
            get { return StrEvaluatedOn; }
            set { StrEvaluatedOn = value; }
        }
        public string External
        {
            get { return StrExternal; }
            set { StrExternal = value; }
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
			/*clsBLTestProcess objTTestProcess = new clsBLTestProcess();

			StrProcessID = objTTestProcess.GetNextProcessID(StrProcedureID,cProcessID);
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
			}*/				return true;		
		}

        public bool UpdateLs_TdTransaction(bool updaterserial)
        {
            clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();
            objTrans.Start_Transaction();

            try
            {
                //Get Max RSerialNo
                if (updaterserial)
                {
                    objdbhims.Query = objQB.QBGetMaxRSerialNo();
                    this.StrRSerialNo = objTrans.DataTrigger_Get_Max(objdbhims);
                }
                //Update DTransaction
                objdbhims.Query = objQB.QBUpdate(MakeArray_TDtransactionUpdate(), "LS_TDTransaction");
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }

                objTrans.End_Transaction();
                return true;
            }
            catch
            {
                return false;
            }
        }

		public bool UpdateAll(string[,] arrayUpdate, string[,] MicroUpdate, string IsMicro)
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();			
			
			if(this.StrMSerialNo.Equals(""))
			{
				this.StrErrorMessage = "Operation failed due to (SERIAL NO) not found.";
				return false;
			}
			if(this.StrDSerialNo.Equals(""))
			{
				this.StrErrorMessage = "Operation failed due to (SERIAL NO) not found.";
				return false;
			}
			if(this.StrNextProcessID.Equals(""))
			{
				this.StrErrorMessage = "Operation failed due to (NEXT PROCESS) not found.";
				return false;
			}
			if(this.StrTestID.Equals(""))
			{
				this.StrErrorMessage = "Operation failed due to (TEST) not found.";
				return false;
			}
			if(this.StrTestID.Equals(""))
			{
				this.StrErrorMessage = "Operation failed due to (TEST) not found.";
				return false;
			}		
/*			if(this.StrOpinion.Equals(""))
			{
				this.StrErrorMessage = "Please enter OPINION (empty is not allowed)";
				return false;
			}		
			if(this.StrComments.Equals(""))
			{
				this.StrErrorMessage = "Please enter COMMENTS (empty is not allowed)";
				return false;
			}		
*/
			objTrans.Start_Transaction();

            try
            {
                //Get Max RSerialNo
                objdbhims.Query = objQB.QBGetMaxRSerialNo();
                this.StrRSerialNo = objTrans.DataTrigger_Get_Max(objdbhims);

                //Update DTransaction
                objdbhims.Query = objQB.QBUpdate(MakeArray_TDtransactionUpdate(), "LS_TDTransaction");
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }

                //Update Test Result Master
                objdbhims.Query = objQB.QBInsert(MakeArray_TTestResultMUpdate(), "LS_TTestResultM");
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }
               // update TestResult Comments
                objdbhims.Query = "update ls_ttestresultcomments set Rserialno="+StrRSerialNo+" where labid='"+Labid+"' and testid='"+StrTestID+"'";
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    objTrans.End_Transaction();
                    return false;
                }

                //Update Test Result Detail
                for (int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
                {
                    this.StrAttributeID = arrayUpdate[counter, 0];
                    this.StrResult = arrayUpdate[counter, 1];
                    this.StrPrint = arrayUpdate[counter, 2];
                    this.StrMinRange = arrayUpdate[counter, 3];
                    this.StrMaxRange = arrayUpdate[counter, 4];
                    this.StrRUnit = arrayUpdate[counter, 5];
                    this.StrRPrint = arrayUpdate[counter, 6];
                    this.StrMinPValue = arrayUpdate[counter, 7];
                    this.StrMaxPValue = arrayUpdate[counter, 8];
                    if (arrayUpdate[counter, 9] == "N")
                    {
                        try
                        {
                            if (StrMinRange.Contains(">") || StrMinRange.Contains("<"))
                            {
                                if (StrMinRange.Contains("<"))
                                {
                                    if (Convert.ToDouble(StrResult.Trim()) > Convert.ToDouble(StrMinRange.Trim().Replace("<", "")))
                                    {
                                        this.StrAbNormal = "Y";
                                    }
                                    else
                                    {
                                        this.StrAbNormal = "N";
                                    }
                                }
                                else if (StrMinRange.Contains(">"))
                                {
                                    if (Convert.ToDouble(StrResult.Trim()) < Convert.ToDouble(StrMinRange.Trim().Replace("<", "")))
                                    {
                                        this.StrAbNormal = "Y";
                                    }
                                    else
                                    {
                                        this.StrAbNormal = "N";
                                    }
                                }

                            }
                            
                            else
                            {
                                if (Convert.ToDouble(StrResult) < Convert.ToDouble(StrMinRange) || Convert.ToDouble(StrResult) > Convert.ToDouble(StrMaxRange))
                                {
                                    this.StrAbNormal = "Y";
                                }
                                else
                                {
                                    this.StrAbNormal = "N";
                                }
                            }
                        }
                        catch { }
                    }
                    this.StrRangeText = arrayUpdate[counter, 10].Trim() ;

                    if (this.StrAttributeID.Equals(""))
                    {
                        this.StrErrorMessage = "Operation failed due to (ATTRIBUTE) not found.";
                        objTrans.End_Transaction();
                        return false;
                    }
                    if (this.StrResult.Equals(""))
                    {
                        this.StrErrorMessage = "Please enter Result (empty is not allowed)";
                        objTrans.End_Transaction();
                        return false;
                    }


                    objdbhims.Query = objQB.QBInsert(MakeArray_TTestResultDUpdate(), "LS_TTestResultD");
                    this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);

                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }

                    //////////////////////////Inserting Data into LS_TResultHistory/////////////////////////////////
                    /*objdbhims.Query = "Select NVl(max(ResultHistoryID),0)+1 as MAXID from Ls_TResulthistory";
                    this.StrResultHistoryID = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (this.StrResultHistoryID.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }

                    objdbhims.Query = objQB.QBInsert(MakeArray_TTestResultHistory(), "Ls_TResulthistory");
                    this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    *///Commented this part just to see whether this optimizes the performance. Also these insertions are not critical...
                    ////////////////////////////////----------------////////////////////////////////////
                }

                ////Update Test Result Micro
                if (IsMicro.Equals("Y"))
                {
                    for (int counter = 0; counter <= MicroUpdate.GetUpperBound(0); counter++)
                    {
                        this.StrOrganismID = MicroUpdate[counter, 1];
                        this.StrDrugID = MicroUpdate[counter, 2];
                        this.StrMicroResult = MicroUpdate[counter, 3];

                        if (this.StrOrganismID.Equals(""))
                        {
                            this.StrErrorMessage = "Operation failed due to (Organism) not found.";
                            objTrans.End_Transaction();
                            return false;
                        }
                        if (this.StrDrugID.Equals(""))
                        {
                            this.StrErrorMessage = "Operation failed due to (Drug) not found.";
                            objTrans.End_Transaction();
                            return false;
                        }
                        if (!this.StrMicroResult.Equals(""))
                        {
                            if (MicroUpdate[counter, 0] == "1")
                            {
                                objdbhims.Query = objQB.QBInsert(MakeArray_TMicroUpdate(), "LS_TMicro");
                                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                            }
                            else if (MicroUpdate[counter, 0] == "2")
                            {
                                objdbhims.Query = objQB.QBInsert(MakeArray_TMicroUpdate(), "LS_TMicro2");
                                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                            }
                            else if (MicroUpdate[counter, 0] == "3")
                            {
                                objdbhims.Query = objQB.QBInsert(MakeArray_TMicroUpdate(), "LS_TMicro3");
                                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                            }
                        }

                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
                            return false;
                        }
                    }
                }
            }
            catch 
            {
                this.StrErrorMessage = "Cannot be updated due to internal Error! Contact administrator.";
                objTrans.End_Transaction();
                return false;
            }
			objTrans.End_Transaction();
			return true;
		}


		public DataView GetAll(int flag)
		{
			string sTestGroupID = "";	
			string sLabIDFrom = "";		
			string sLabIDTo = "";		
			string sWardID = "";		
			string sMSerialNoFrom = "";
			string sMSerialNoTo = "";
			string sMSerialNo = "";
			string sDSerialNo = "";
            string sPatientName = "";
            string sPRNo = "";
            string sExternal = "";
			switch(flag)
			{
				case 1:					
					if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}
					if(!this.StrLabIDFrom.Equals(Default))
					{sLabIDFrom = " And m.LabID >= '"+ StrLabIDFrom +"' ";}
					if(!this.StrLabIDTo.Equals(Default))
					{sLabIDTo = " And m.LabID <= '"+ StrLabIDTo +"' ";}
					if(!this.StrWardID.Equals(Default))
					{sWardID = " And p.WardID = '"+ StrWardID +"' ";}
					if(!this.StrMSerialNoFrom.Equals(Default))
					{sMSerialNoFrom = " And m.MSerialNo >= '"+ StrMSerialNoFrom +"' ";}
					if(!this.StrMSerialNoTo.Equals(Default))
					{sMSerialNoTo = " And m.MSerialNo <= '"+ StrMSerialNoTo +"' ";}
					if(!this.StrMSerialNo.Equals(Default))
					{sMSerialNo = " And m.MSerialNo = '"+ StrMSerialNo +"' ";}
					if(!this.StrDSerialNo.Equals(Default))
					{sDSerialNo = " And d.DSerialNo = '"+ StrDSerialNo +"' ";}
                    if (!this.StrPatientName.Equals(Default))
                    { sPatientName = " And upper(p.patientCompletename) Like upper('%" + StrPatientName + "%') "; }
                    if (!this.StrPRNo.Equals(Default))
                    { sPRNo = " And trim(m.PRNo) = trim('" + StrPRNo + "') "; }

                    if (!this.StrExternal.Equals(Default))
                    { sExternal = " And t.external='" + StrExternal + "'"; }
                    objdbhims.Query = "Select Distinct LS_GetPriority(d.priority) As priority, m.MSerialNo, d.DSerialNo, p.patientCompletename As PatientName,p.Patientname as namewotitle, FGetSex(p.PSex) as PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, t.testid, t.Test, p.PType As Type, p.ServiceNo, d.ProcessID, p.WardName, m.LabID, t.TestType,case when p.PageU ='Y' then p.PageD else 1 end as Cal_Age,d.deliverydate, m.PRNo,nvl(o.name,'RMI') as Origin  from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p, LS_TTest  t ,ls_textorganization o Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID  And m.MStatus = 'A' and m.originplaceid=o.cliqbranchid(+)    And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' " + sTestGroupID + sLabIDFrom + sLabIDTo + sWardID + sPatientName + sPRNo + sExternal + " Order By m.LabID";

                    //m.MStatus not in ('C') => m.MStatus = 'A' :070303 
						
						/*Select Distinct m.Priority, m.MSerialNo, d.DSerialNo, p.PFName As PatientName, p.PSex, To_Char(p.PAgeD)||p.PAgeU As PAge, m.Type,  p.ServiceNo from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p  Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo  And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' Order By m.MSerialNo";*/
					break;

				case 2:
					if(!this.StrMSerialNo.Equals(Default))
					{sMSerialNo = " And m.MSerialNo = '"+ StrMSerialNo +"' ";}
					if(!this.StrDSerialNo.Equals(Default))
					{sDSerialNo = " And d.DSerialNo = '"+ StrDSerialNo +"' ";}

                    objdbhims.Query = "Select distinct d.path_img1,d.EXT_RESULT_REFERENCE,d.path_Img2,d.path_img3, t.historytaking,m.MSerialNo, d.DSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type,  p.ServiceNo, t.Test,trm.Opinion AS Opinions, trm.Comments,trm.History as History, LS_GetPriority(m.priority) As priority, t.ProcedureID, d.ProcessID, d.TestID,  p1.PAgeinDays, p.WardName, t.Testtype, d.Sensitivity, LS_FOrganismID(d.DSerialNo) As OrganismID, LS_FOrganismID2(d.DSerialNo) As OrganismID2,LS_FOrganismID3(d.DSerialNo) As OrganismID3, m.LabID, to_char(d.DeliveryDate,'dd/MM/yyyy hh:mm am') DeliveryDate, d.TestNo, t.Acronym, m.PRNo, m.REFERREDBY,t.Preferred,t.Attribute_Count,NVL(NVL(trm.Methodid,d.methodid),t.d_methodid) AS d_METHODID from LS_tMTransaction m, LS_tDTransaction d, LS_VPatient p,  LS_VPatientAgeSex p1, LS_TTest t,LS_TTestResultM trm Where m.MSerialNo = p.MSerialNo And m.MSerialNo = p1.MSerialNo And m.MSerialNo = d.MSerialNo And m.MStatus  = 'A' And d.TestID = t.TestID And d.RSerialNo = trm.RSerialNo (+) And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' And t.TestType = '" + StrTestType + "' " + sDSerialNo + sMSerialNo;

                    //m.MStatus not in ('C') => m.MStatus in ('A') :070303 
					break;
					
				case 3:
                    objdbhims.Query = @"Select trm.methodID,trm.DSerialNo, d.EXT_RESULT_REFERENCE,trd.AttributeID, ta.Attribute,nvl(ls_finterfacedvalue(ta.interfaceid,d.mserialno),'NA') MachineResult,
                                         trd.Result, trd.MinRange, trd.MaxRange,
                                          trd.MinRange||'-'||trd.MaxRange AS Range, 
                                          FGetResultState(trd.Result, trd.MinRange, trd.MaxRange, trd.MinPValue, trd.MaxPValue) as ResultState, 
                                          trd.RUnit, trd.RPrint, ta.SMLine, ta.InputType, 
                                          trd.MinPValue,
                                           trd.MaxPValue,
                                           ta.ATTRIBUTETYPE,ta.DERIVED,ta.Acronym,d.Path_IMG1,d.Path_IMG2,d.Path_IMG3
   
                                           from LS_TTestResultM trm,LS_TTestResultD trd,
                                           LS_TTestAttribute ta, LS_TDTransaction d,ls_ttestmethod tm,
                                           Ls_Tattributerange ar
                                           Where trm.RSerialNo = trd.RSerialNo 
                                           And trd.AttributeID = ta.AttributeID 
                                           And trm.DSerialNo = d.DSerialNo 
                                           And trm.RSerialNo = d.RSerialNo 
                                          And tm.methodId=trm.Methodid
                                          and trm.testID=tm.TestID
                                          and ar.methodID=trm.methodID
                                          and ar.testid=d.testid
                                          and ar.Attributeid=trd.AttributeID
                                          and (ar.Sex='" + StrSex+@"' or ar.Sex='All')
                                          and ('"+StrAge +@"' between ar.AgeMin and ar.Agemax)
 
                                           And ta.Active = 'Y' 
                                           And trm.DSerialNo = '"+StrDSerialNo+@"' 
   
                                           order by ta.DOrder";

                 //   objdbhims.Query = "Select trm.DSerialNo, trd.AttributeID, ta.Attribute, trd.Result, trd.MinRange, trd.MaxRange, trd.MinRange||'-'||trd.MaxRange AS Range, FGetResultState(trd.Result, trd.MinRange, trd.MaxRange, trd.MinPValue, trd.MaxPValue) as ResultState, trd.RUnit, trd.RPrint, ta.SMLine, ta.InputType, trd.MinPValue, trd.MaxPValue,ta.ATTRIBUTETYPE,ta.DERIVED,ta.Acronym from LS_TTestResultM trm,LS_TTestResultD trd, LS_TTestAttribute ta, LS_TDTransaction d Where trm.RSerialNo = trd.RSerialNo And trd.AttributeID = ta.AttributeID And trm.DSerialNo = d.DSerialNo And trm.RSerialNo = d.RSerialNo And ta.Active = 'Y' And trm.DSerialNo = '" + StrDSerialNo + "' Order By ta.DOrder";
					break;
                case 4:
                    objdbhims.Query = @"Select tm.Method,
       tt.d_methodid,
       d.DSerialNo,
       a.AttributeID,
       a.Attribute,
       case
         when LS_FInterfacedValue(a.interfaceid, d.mserialno) is null then
          NVl((Select NVL(tat1.Description, '')
                From ls_tattributeTemplates tat1
               where tat1.attributeid = a.attributeid
                 and tat1.t_default = 'Y'
                 and tat1.Active = 'Y'),
              '')
         else
          LS_FInterfacedValue(a.interfaceid, d.mserialno)
       end As Result,
       a.TestGroupID,
       a.SectionID,
       a.InputType,
       a.Dorder,
       ar.MethodID,
       ar.Sex,
       ar.AgeMin,
       ar.AgeMax,
       ar.MinValue AS MinRange,
       ar.MaxValue AS MaxRange,
       ar.MinPValue,
       ar.MaxPValue,
       ar.MinValue || '-' || ar.MaxValue AS Range,
       0 as ResultState,
       ar.AUnit As RUnit,
       ar.TransID,
       a.RPrint,
       a.SMLine,
       a.ATTRIBUTETYPE,
       a.DERIVED,
       a.Acronym,
       nvl(ls_finterfacedvalue(a.interfaceid, d.mserialno), '') MachineResult
  From  ls_TTest tt inner join 
     LS_TTestAttribute  a on tt.testid=a.testid 
   left outer join LS_TAttributeRange ar on ar.attributeid=a.attributeid 
   inner join ls_TMethod tm on tm.methodid=ar.methodid 
   and ar.testid=tt.testid inner join ls_tdtransaction d on tt.testid=d.testid and a.Active ='Y' 
                                        And d.DSerialNo =" + StrDSerialNo+@"
                                        And ar.TransID in 
                                        (Select TransID 
                                        from LS_TAttributeRange 
                                        Where (Sex ='"+StrSex+@"' or Sex = 'All') 
                                        And ('"+StrAge+@"' between AgeMin And AgeMax)";
                    if (!StrMethodID.Equals(Default) && !StrMethodID.Trim().Equals(""))
                    {
                        objdbhims.Query += " and methodid='" + StrMethodID + "')";
                    }
                    else
                    {
                        objdbhims.Query += @" and methodid=(Select methodid from ls_ttestmethod ttm where ttm.testid=d.testid and ttm.m_default='Y'))";
                    }
                objdbhims.Query+=@" Order By a.Dorder";
//                    objdbhims.Query = @"Select tm.Method,tt.d_methodid,d.DSerialNo, a.AttributeID, a.Attribute , case when LS_FInterfacedValue(a.interfaceid, d.mserialno) is null then NVl((Select NVL(tat1.Description,'') From ls_tattributeTemplates tat1 where tat1.attributeid=a.attributeid and tat1.t_default='Y' and tat1.Active='Y'),'') else LS_FInterfacedValue(a.interfaceid, d.mserialno) end As Result, a.TestGroupID, a.SectionID, a.InputType,  a.Dorder, ar.MethodID, ar.Sex, ar.AgeMin, ar.AgeMax, ar.MinValue AS MinRange, ar.MaxValue AS MaxRange, ar.MinPValue, ar.MaxPValue, ar.MinValue||'-'||ar.MaxValue AS Range, 0 as ResultState, ar.AUnit As RUnit, ar.TransID, a.RPrint, a.SMLine,a.ATTRIBUTETYPE,a.DERIVED,a.Acronym,nvl(ls_finterfacedvalue(a.interfaceid, d.mserialno),'') MachineResult
//                                        From LS_TTestAttribute a,ls_TMethod tm, LS_TAttributeRange ar, LS_TDTransaction d,ls_TTest tt,ls_ttestmethod ttm
//                                        Where a.AttributeID = ar.AttributeID 
//                                        And a.TestID = d.TestID 
//                                        And tt.TestID=a.TestID 
//                                        and tt.Testid=ttm.TestID
//                                        and ttm.MethodiD=tm.MethodID
//                                        and ar.methodid=tm.methodid 
//                                        and d.Methodid=ttm.methodid
//                                        
//                                        and a.Active ='Y' 
//                                        And d.DSerialNo ='" + StrDSerialNo+@"'
//                                        
//                                        And ar.TransID in 
//                                        (Select TransID 
//                                        from LS_TAttributeRange 
//                                        Where (Sex ='"+StrSex+@"' or Sex = 'All') 
//                                        And ('"+StrAge+@"' between AgeMin And AgeMax)) 
//                                        Order By a.Dorder";//
                    break;
                //And ar.methodid=tt.d_methodid         NVL(tat.Description,'') 
                // And ttm.MethodID='"+StrMethodID+@"'        and tat.AttributeID(+)=a.AttributeID            and (tat.T_Default='Y' or tat.T_Default is null)
                //case 4:
                //    objdbhims.Query = "Select d.DSerialNo, a.AttributeID, a.Attribute , LS_FInterfacedValue(a.interfaceid, d.mserialno) As Result, a.TestGroupID, a.SectionID, a.Attribute, a.InputType,  a.Dorder, ar.MethodID, ar.Sex, ar.AgeMin, ar.AgeMax, ar.MinValue AS MinRange, ar.MaxValue AS MaxRange, ar.MinPValue, ar.MaxPValue, ar.MinValue||'-'||ar.MaxValue AS Range, 0 as ResultState, ar.AUnit As RUnit, ar.TransID, a.RPrint, a.SMLine, a.InputType,a.ATTRIBUTETYPE From LS_TTestAttribute a, LS_TAttributeRange ar, LS_TDTransaction d Where a.AttributeID = ar.AttributeID And a.TestID = d.TestID And a.Active ='Y' And d.DSerialNo = '" + StrDSerialNo + "'  And ar.TransID in (Select TransID from LS_TAttributeRange Where (Sex = '" + StrSex + "' or Sex = 'All') And ('" + StrAge + "' between AgeMin And AgeMax)) Order By a.Dorder";
                //    break;

					/*objdbhims.Query = "Select d.DSerialNo, a.AttributeID, a.Attribute , '' AS Result, a.TestGroupID, a.SectionID, a.Attribute, a.InputType,  a.Dorder, ar.MethodID, ar.Sex, ar.AgeMin, ar.AgeMax, ar.MinValue AS MinRange, ar.MaxValue AS MaxRange, ar.MinValue||'-'||ar.MaxValue AS Range, ar.AUnit As RUnit, ar.TransID, a.RPrint, a.SMLine From LS_TTestAttribute a, LS_TAttributeRange ar, LS_TDTransaction d Where a.AttributeID = ar.AttributeID And a.TestID = d.TestID And a.Active ='Y' And d.DSerialNo = '" + StrDSerialNo + "'  And ar.TransID in (Select TransID from LS_TAttributeRange Where (Sex = '" + StrSex + "' or Sex = 'All') And ('" + StrAge + "' between AgeMin And AgeMax)) Order By a.Dorder";*/
				
				case 5:				
					objdbhims.Query = "select m.dserialno, m.organismid, o.organism, m.drugid, d.drug, m.microresult from ls_tmicro m, ls_torganism o, ls_tdrug d Where m.organismid = o.organismid And m.drugid = d.drugid And DSerialNo = '" + StrDSerialNo + "' Order By m.organismid, m.drugid";
					break;			
			}
			
			return objTrans.DataTrigger_Get_All(objdbhims);
		}

        public bool UpdateMethod()
        {
            clsoperation objTrans = new clsoperation();
            objdbhims.Query = @"Update ls_tdTransaction set methodid='" + StrMethodID + "' where DserialNo='" + StrDSerialNo + "'";
            objTrans.Start_Transaction();
            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            objTrans.End_Transaction();
            if (StrErrorMessage.Equals("True"))
            {
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            else
            {
                objdbhims.Query = @"Update ls_ttestresultm set methodid='" + StrMethodID + "' where DSerialNo='" + StrDSerialNo + "'";
                objTrans.Start_Transaction();
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                objTrans.End_Transaction();
                if (StrErrorMessage.Equals("True"))
                {
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                return true;
            }
            //objTrans.
            
           
        }
		
		
		private string[,] MakeArray_TDtransactionUpdate()
		{
			string[,] aryUpdate = new string[8,3];
			if(!this.StrDSerialNo.Equals(Default))
			{
				aryUpdate[0,0] = "DSerialNo";
				aryUpdate[0,1] = this.StrDSerialNo;
				aryUpdate[0,2] = "int";
			}
				
			if(!this.StrNextProcessID.Equals(Default))
			{
				aryUpdate[1,0] = "ProcessID";
				aryUpdate[1,1] = this.StrNextProcessID;
				aryUpdate[1,2] = "string";
			}			

			if(!this.StrRSerialNo.Equals(Default))
			{
				aryUpdate[2,0] = "RSerialNo";
				aryUpdate[2,1] = this.StrRSerialNo;
				aryUpdate[2,2] = "int";
			}	
		
			if(!this.StrSensitivity.Equals(Default))
			{
				aryUpdate[3,0] = "Sensitivity";
				aryUpdate[3,1] = this.StrSensitivity;
				aryUpdate[3,2] = "string";
			}
            if (!this._Spec_Coment.Equals(Default))
            {
                aryUpdate[4, 0] = "Spec_Coment";
                aryUpdate[4, 1] = this._Spec_Coment;
                aryUpdate[4, 2] = "string";
            }
            if (!this.path_Img1.Equals(Default))
            {
                aryUpdate[5, 0] = "path_Img1";
                aryUpdate[5, 1] = this.path_Img1;
                aryUpdate[5, 2] = "string";
            }
            if (!this.path_Img2.Equals(Default))
            {
                aryUpdate[6, 0] = "path_Img2";
                aryUpdate[6, 1] = this.path_Img2;
                aryUpdate[6, 2] = "string";
            }
            if (!this.path_Img3.Equals(Default))
            {
                aryUpdate[7, 0] = "path_Img3";
                aryUpdate[7, 1] = this.path_Img3;
                aryUpdate[7, 2] = "string";
            }
          

			
			return aryUpdate;
		}

		
		private string[,] MakeArray_TTestResultMUpdate()
		{
			string[,] aryUpdate = new string[15,3];
			if(!this.StrRSerialNo.Equals(Default))
			{
				aryUpdate[0,0] = "RSerialNo";
				aryUpdate[0,1] = this.StrRSerialNo;
				aryUpdate[0,2] = "int";
			}
				
			if(!this.StrMSerialNo.Equals(Default))
			{
				aryUpdate[1,0] = "MSerialNo";
				aryUpdate[1,1] = this.StrMSerialNo;
				aryUpdate[1,2] = "int";
			}			

			if(!this.StrTestID.Equals(Default))
			{
				aryUpdate[2,0] = "TestID";
				aryUpdate[2,1] = this.StrTestID;
				aryUpdate[2,2] = "string";
			}			

			if(!this.StrTimes.Equals(Default))
			{
				aryUpdate[3,0] = "Times";
				aryUpdate[3,1] = this.StrTimes;
				aryUpdate[3,2] = "int";
			}			

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryUpdate[4,0] = "DSerialNo";
				aryUpdate[4,1] = this.StrDSerialNo;
				aryUpdate[4,2] = "int";
			}			

			if(!cProcessID.Equals(Default))
			{
				aryUpdate[5,0] = "ProcessID";
				aryUpdate[5,1] = cProcessID;
				aryUpdate[5,2] = "string";
			}			

			if(!this.StrOpinion.Equals(Default))
			{
				aryUpdate[6,0] = "Opinion";
				aryUpdate[6,1] = this.StrOpinion;
				aryUpdate[6,2] = "string";
			}			

			if(!this.StrComments.Equals(Default))
			{
				aryUpdate[7,0] = "Comments";
				aryUpdate[7,1] = this.StrComments;
				aryUpdate[7,2] = "string";
			}
           
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryUpdate[8, 0] = "EnteredBy";
                aryUpdate[8, 1] = this.EnteredBy;
                aryUpdate[8, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryUpdate[9, 0] = "EnteredOn";
                aryUpdate[9, 1] = this.EnteredOn;
                aryUpdate[9, 2] = "date";
            }

            if (!this.StrHistory.Equals(Default))
            {
                aryUpdate[10, 0] = "History";
                aryUpdate[10, 1] = this.StrHistory;
                aryUpdate[10, 2] = "string";
            }
            if (!this.StrMethodID.Equals(Default))
            {
                aryUpdate[11, 0] = "MethodID";
                aryUpdate[11, 1] = this.StrMethodID;
                aryUpdate[11, 2] = "string";
            }
            if (!this.StrEvaluatedBy.Equals(Default))
            {
                aryUpdate[12, 0] = "EvaluatedBy";
                aryUpdate[12, 1] = this.StrEvaluatedBy;
                aryUpdate[12, 2] = "string";
            }
            if (!this.StrEvaluatedOn.Equals(Default))
            {
                aryUpdate[13, 0] = "EvaluatedOn";
                aryUpdate[13, 1] = this.StrEvaluatedOn;
                aryUpdate[13, 2] = "date";
            }
            if (!this._AutoVerified.Equals(Default))
            {
                aryUpdate[14, 0] = "AutoVerified";
                aryUpdate[14, 1] = this._AutoVerified;
                aryUpdate[14, 2] = "string";
            }	
			return aryUpdate;
		}
		
		private string[,] MakeArray_TTestResultDUpdate()
		{
			string[,] aryUpdate = new string[14,3];
			if(!this.StrRSerialNo.Equals(Default))
			{
				aryUpdate[0,0] = "RSerialNo";
				aryUpdate[0,1] = this.StrRSerialNo;
				aryUpdate[0,2] = "int";
			}
				
			if(!this.StrTestID.Equals(Default))
			{
				aryUpdate[1,0] = "TestID";
				aryUpdate[1,1] = this.StrTestID;
				aryUpdate[1,2] = "string";
			}			

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryUpdate[2,0] = "DSerialNo";
				aryUpdate[2,1] = this.StrDSerialNo;
				aryUpdate[2,2] = "int";
			}			

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryUpdate[3,0] = "MSerialNo";
				aryUpdate[3,1] = this.StrMSerialNo;
				aryUpdate[3,2] = "int";
			}			

			if(!this.StrAttributeID.Equals(Default))
			{
				aryUpdate[4,0] = "AttributeID";
				aryUpdate[4,1] = this.StrAttributeID;
				aryUpdate[4,2] = "string";
			}			

			if(!this.StrResult.Equals(Default))
			{
				aryUpdate[5,0] = "Result";
				aryUpdate[5,1] = this.StrResult;
				aryUpdate[5,2] = "string";
			}			

			if(!this.StrPrint.Equals(Default))
			{
				aryUpdate[6,0] = "Print";
				aryUpdate[6,1] = this.StrPrint;
				aryUpdate[6,2] = "string";
			}			

			if(!this.StrMinRange.Equals(Default))
			{
				aryUpdate[7,0] = "MinRange";
				aryUpdate[7,1] = this.StrMinRange;
				aryUpdate[7,2] = "string";
			}			
			if(!this.StrMaxRange.Equals(Default))
			{
				aryUpdate[8,0] = "MaxRange";
				aryUpdate[8,1] = this.StrMaxRange;
				aryUpdate[8,2] = "string";
			}			
			if(!this.StrRUnit.Equals(Default))
			{
				aryUpdate[9,0] = "RUnit";
				aryUpdate[9,1] = this.StrRUnit;
				aryUpdate[9,2] = "string";
			}			
			if(!this.StrRPrint.Equals(Default))
			{
				aryUpdate[10,0] = "RPrint";
				aryUpdate[10,1] = this.StrRPrint;
				aryUpdate[10,2] = "string";
			}
            if (!this.StrMinPValue.Equals(Default))
            {
                aryUpdate[11, 0] = "MinPValue";
                aryUpdate[11, 1] = this.StrMinPValue;
                aryUpdate[11, 2] = "string";
            }
            if (!this.StrMaxPValue.Equals(Default))
            {
                aryUpdate[12, 0] = "MaxPValue";
                aryUpdate[12, 1] = this.StrMaxPValue;
                aryUpdate[12, 2] = "string";
            }
            if (!this.StrAbNormal.Equals(Default))
            {
                aryUpdate[13, 0] = "Abnormal";
                aryUpdate[13, 1] = this.StrAbNormal;
                aryUpdate[13, 2] = "string";
            }
			
			return aryUpdate;
		}


		private string[,] MakeArray_TMicroUpdate()
		{
			string[,] aryUpdate = new string[7,3];
			if(!this.StrRSerialNo.Equals(Default))
			{
				aryUpdate[0,0] = "RSerialNo";
				aryUpdate[0,1] = this.StrRSerialNo;
				aryUpdate[0,2] = "int";
			}
				
			if(!this.StrTestID.Equals(Default))
			{
				aryUpdate[1,0] = "TestID";
				aryUpdate[1,1] = this.StrTestID;
				aryUpdate[1,2] = "string";
			}			

			if(!this.StrDSerialNo.Equals(Default))
			{
				aryUpdate[2,0] = "DSerialNo";
				aryUpdate[2,1] = this.StrDSerialNo;
				aryUpdate[2,2] = "int";
			}			

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryUpdate[3,0] = "MSerialNo";
				aryUpdate[3,1] = this.StrMSerialNo;
				aryUpdate[3,2] = "int";
			}			

			if(!this.StrOrganismID.Equals(Default))
			{
				aryUpdate[4,0] = "OrganismID";
				aryUpdate[4,1] = this.StrOrganismID;
				aryUpdate[4,2] = "int";
			}			

			if(!this.StrDrugID.Equals(Default))
			{
				aryUpdate[5,0] = "DrugID";
				aryUpdate[5,1] = this.StrDrugID;
				aryUpdate[5,2] = "int";
			}			

			if(!this.StrMicroResult.Equals(Default))
			{
				aryUpdate[6,0] = "MICRORESULT";
				aryUpdate[6,1] = this.StrMicroResult;
				aryUpdate[6,2] = "string";
			}						
			
			return aryUpdate;
		}

        private string[,] MakeArray_TTestResultHistory()
        {
            string[,] aryUpdate = new string[18, 3];

            if (!this.StrResultHistoryID.Equals(Default))
            {
                aryUpdate[0, 0] = "RESULTHISTORYID";
                aryUpdate[0, 1] = this.StrResultHistoryID;
                aryUpdate[0, 2] = "int";
            }

            if (!this.StrRSerialNo.Equals(Default))
            {
                aryUpdate[1, 0] = "RSerialNo";
                aryUpdate[1, 1] = this.StrRSerialNo;
                aryUpdate[1, 2] = "int";
            }

            if (!this.StrTestID.Equals(Default))
            {
                aryUpdate[2, 0] = "TestID";
                aryUpdate[2, 1] = this.StrTestID;
                aryUpdate[2, 2] = "string";
            }

            if (!this.StrDSerialNo.Equals(Default))
            {
                aryUpdate[3, 0] = "DSerialNo";
                aryUpdate[3, 1] = this.StrDSerialNo;
                aryUpdate[3, 2] = "int";
            }

            if (!this.StrMSerialNo.Equals(Default))
            {
                aryUpdate[4, 0] = "MSerialNo";
                aryUpdate[4, 1] = this.StrMSerialNo;
                aryUpdate[4, 2] = "int";
            }

            if (!this.StrAttributeID.Equals(Default))
            {
                aryUpdate[5, 0] = "AttributeID";
                aryUpdate[5, 1] = this.StrAttributeID;
                aryUpdate[5, 2] = "string";
            }
            if (!this.StrProcessID.Equals(Default))
            {
                aryUpdate[6, 0] = "ProcessID";
                aryUpdate[6, 1] = this.StrProcessID;
                aryUpdate[6, 2] = "string";
            }

            if (!this.StrResult.Equals(Default))
            {
                aryUpdate[7, 0] = "Result";
                aryUpdate[7, 1] = this.StrResult;
                aryUpdate[7, 2] = "string";
            }

            if (!this.StrPrint.Equals(Default))
            {
                aryUpdate[8, 0] = "Print";
                aryUpdate[8, 1] = this.StrPrint;
                aryUpdate[8, 2] = "string";
            }

            if (!this.StrRangeText.Equals(Default))
            {
                aryUpdate[9, 0] = "RangeText";
                aryUpdate[9, 1] = this.StrRangeText;
                aryUpdate[9, 2] = "string";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryUpdate[10, 0] = "EnteredBy";
                aryUpdate[10, 1] = this.StrEnteredBy;
                aryUpdate[10, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryUpdate[11, 0] = "EnteredOn";
                aryUpdate[11, 1] = this.StrEnteredOn;
                aryUpdate[11, 2] = "date";
            }
            //if (!this.StrRPrint.Equals(Default))
            //{
            //    aryUpdate[12, 0] = "RPrint";
            //    aryUpdate[12, 1] = this.StrRPrint;
            //    aryUpdate[12, 2] = "string";
            //}
            if (!this.StrClientID.Equals(Default))
            {
                aryUpdate[12, 0] = "ClientID";
                aryUpdate[12, 1] = this.StrClientID;
                aryUpdate[12, 2] = "StrClientID";
            }
            if (!this.StrSystem_Ip.Equals(Default))
            {
                aryUpdate[13, 0] = "System_Ip";
                aryUpdate[13, 1] = this.StrSystem_Ip;
                aryUpdate[13, 2] = "string";
            }
            if (!this.StrPRNo.Equals(Default))
            {
                aryUpdate[14, 0] = "PRNumber";
                aryUpdate[14, 1] = this.StrPRNo;
                aryUpdate[14, 2] = "string";
            }
            if (!this.StrAbNormal.Equals(Default))
            {
                aryUpdate[15, 0] = "Abnormal";
                aryUpdate[15, 1] = this.StrAbNormal;
                aryUpdate[15, 2] = "string";
            }
            if (!this.StrOpinion.Equals(Default))
            {
                aryUpdate[16, 0] = "Opinion";
                aryUpdate[16, 1] = this.StrOpinion;
                aryUpdate[16, 2] = "string";
            }
            if (!this.StrComments.Equals(Default))
            {
                aryUpdate[17, 0] = "Comments";
                aryUpdate[17, 1] = this.StrComments;
                aryUpdate[17, 2] = "string";
            }

            return aryUpdate;
        }
        public bool update_ResultM_Evaluation()
        {
            objdbhims.Query = "Update LS_TTestResultM Set Qualitative='"+StrQualitative+"',Quantitative='"+StrQuantitative+"',EvaluatedBy='"+StrEnteredBy+"',EvaluatedOn=to_date('"+StrEnteredOn+"','dd/mm/yyyy hh:mi:ss am') Where MSerialNo="+Convert.ToInt32(StrMSerialNo) + " and TestId='"+ StrTestID+"'";

            objTrans.Start_Transaction();
            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (this.StrErrorMessage == "True")
            {
                objTrans.End_Transaction();
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            else
            {
                objTrans.End_Transaction();
                return true;
            }
        }

		#endregion		
	}
}

