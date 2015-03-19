using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLTestGroup.
	/// </summary>
	public class clsBLTest
	{
		public clsBLTest()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTest";
		private string StrErrorMessage = "";		
		private string StrTestID = Default;
		private string StrSectionID = Default;
		private string StrTestGroupID = Default;
		private string StrActive = Default;
		private string StrTest = Default;
		private string StrAcronym = Default;
		private string StrCharges = Default;
		private string StrChargesUrgent = Default;
		private string StrSpecimen = Default;
		private string StrSpecimenType = Default;
		private string StrSpecimenContainer = Default;
		private string StrAutomatedText = Default;
		private string StrClinicalUse = Default;
		private string StrDOrder = Default;
		private string StrGenerationLevel = Default;
		private string StrGenerateOn = Default;
		private string StrProcedureID = Default;
		private string StrTestType = Default;
		private string StrSepReport = Default;		
		private string StrPrintTest = Default;
		private string StrPrintGroup = Default;
		private string StrUrgent = Default;
        private string StrSummary = Default;
        private string StrReorder = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;
        private string StrSpecimenQuantity = Default;
        private string StrSpecimenUnit = Default;
        private string StrProvisionalReport = Default;
        private string StrExternal = Default;
        private string StrPreferred = Default;
        private string StrDeliveryDateOnSpecimen = Default;
        private string StrRoundDelivery = Default;
        private string StrPrintMethod = Default;
        private string StrPrintMachine = Default;
        private string StrHistoryTaking = Default;
        private string StrAd_Note = Default;
        private string StrbatchTime = Default;
        private string StrInterpretation2 = Default;
        private string StrInterpretation3 = Default;
        private string StrInterpretation4 = Default;
        private string StrInterpretation5 = Default;
        private string StrInterpretationfooter = Default;
        private string Strorgid = Default;
        private string Strtimetype = Default;
        private string StrTraveltime = Default;
        private string StrFromdate = Default;
        private string Strtodate = Default;
        private string _TestCost = Default;
        private string StrLabId = Default;
        private string _Cutoffday = Default;

        private string strCliquetestid = Default;
        private string _ReportingTime = Default;

        
        
            
            
            
            
            
            
            
            
            
            
            
            
        #endregion





        #region "Properties"
        public string ReportingTime
        {
            get { return _ReportingTime; }
            set { _ReportingTime = value; }
        }
        public string CliqueTestid
        {
            get { return strCliquetestid; }
            set { strCliquetestid = value; }
        }
        public string Cutoffday
        {
            get { return _Cutoffday; }
            set { _Cutoffday = value; }
        }
        public string LabId
        {
            get { return StrLabId; }
            set { StrLabId = value; }
        }
        public string TestCost
        {
            get { return _TestCost; }
            set { _TestCost = value; }
        }
        public string Fromdate
        {
            get { return StrFromdate; }
            set { StrFromdate = value; }
        }
        public string ToDate
        {
            get { return Strtodate; }
            set { Strtodate = value; }
        }
        public string Interpretation2
        {
            get { return StrInterpretation2; }
            set { StrInterpretation2 = value; }
        }
        public string Interpretation3
        {
            get { return StrInterpretation3; }
            set { StrInterpretation3 = value; }
        }
        public string Interpretation4
        {
            get { return StrInterpretation4; }
            set { StrInterpretation4 = value; }
        }
        public string Interpretation5
        {
            get { return StrInterpretation4; }
            set { StrInterpretation4 = value; }
        }
        public string Interpretationfooter
        {
            get { return StrInterpretationfooter; }
            set { StrInterpretationfooter = value; }
        }
        public string batchTime
        {
            get { return StrbatchTime; }
            set { StrbatchTime = value; }
        }
        public string Ad_Note
        {
            get { return StrAd_Note; }
            set { StrAd_Note = value; }
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
		public string Test
		{
			get{	return StrTest;	}
			set{	StrTest = value;	}
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
		public string Charges
		{
			get{	return StrCharges;	}
			set{	StrCharges = value;	}
		}
		public string ChargesUrgent
		{
			get{	return StrChargesUrgent;	}
			set{	StrChargesUrgent = value;	}
		}
		public string Specimen
		{
			get{	return StrSpecimen;	}
			set{	StrSpecimen = value;	}
		}
		public string SpecimenType
		{
			get{	return StrSpecimenType;	}
			set{	StrSpecimenType = value;	}
		}
		public string SpecimenContainer
		{
			get{	return StrSpecimenContainer;	}
			set{	StrSpecimenContainer = value;	}
		}
		public string AutomatedText
		{
			get{	return StrAutomatedText;	}
			set{	StrAutomatedText = value;	}
		}
		public string ClinicalUse
		{
			get{	return StrClinicalUse;	}
			set{	StrClinicalUse = value;	}
		}
		public string DOrder
		{
			get{	return StrDOrder;	}
			set{	StrDOrder = value;	}
		}

		public string GenerationLevel
		{
			get{	return StrGenerationLevel;	}
			set{	StrGenerationLevel = value;	}
		}

		public string GenerateOn
		{
			get{	return StrGenerateOn;	}
			set{	StrGenerateOn = value;	}
		}

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}
		
		public string TestType
		{
			get{	return StrTestType;	}
			set{	StrTestType = value;	}
		}
		
		public string SepReport
		{
			get{	return StrSepReport;	}
			set{	StrSepReport = value;	}
		}
		
		public string PrintTest
		{
			get{	return StrPrintTest;	}
			set{	StrPrintTest = value;	}
		}
		
		public string PrintGroup
		{
			get{	return StrPrintGroup;	}
			set{	StrPrintGroup = value;	}
		}

		public string Urgent
		{
			get{	return StrUrgent;	}
			set{	StrUrgent = value;	}
		}

		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
        public string Summary
        {
            get { return StrSummary; }
            set { StrSummary = value; }
        }
        public string ReorderTime
        {
            get { return StrReorder; }
            set { StrReorder = value; }
        }
        public string Enteredon
        {
            get { return StrEnteredon; }
            set { StrEnteredon = value; }
        }
        public string Enteredby
        {
            get { return StrEnteredby; }
            set { StrEnteredby = value; }
        }

        public string SpecimenQuantity
        {
            get { return StrSpecimenQuantity; }
            set { StrSpecimenQuantity = value; }
        }
        public string SpecimenUnit
        {
            get { return StrSpecimenUnit; }
            set { StrSpecimenUnit = value; }
        }

        public string ProvisionalReport
        {
            get { return StrProvisionalReport; }
            set { StrProvisionalReport = value; }
        }

        public string External
        {
            get { return StrExternal; }
            set { StrExternal = value; }
        }
        public string Preferred
        {
            get { return StrPreferred; }
            set { StrPreferred = value; }
        }

        public string DeliveryDateOnSpecimen
        {
            get { return StrDeliveryDateOnSpecimen; }
            set { StrDeliveryDateOnSpecimen = value; }
        }

        public string RoundDelivery
        {
            get { return StrRoundDelivery; }
            set { StrRoundDelivery = value; }
        }

        public string PrintMachine
        {
            get { return StrPrintMachine; }
            set { StrPrintMachine = value; }
        }

        public string PrintMethod
        {
            get { return StrPrintMethod; }
            set { StrPrintMethod = value; }
        }
        public string HistoryTaking
        {
            get { return StrHistoryTaking; }
            set { StrHistoryTaking = value; }
        }
        public string ExtOrganizationID
        {
            get { return Strorgid; }
            set { Strorgid = value; }
        }

        public string Timetype
        {
            get { return Strtimetype; }
            set { Strtimetype = value; }
        }
        public string Traveltime
        {
            get { return StrTraveltime; }
            set { StrTraveltime = value; }
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

					objdbhims.Query = objQB.QBGetMax("TestID", TableName, "6");
					this.StrTestID = objTrans.DataTrigger_Get_Max(objdbhims);

					objdbhims.Query = objQB.QBGetMax("DOrder", TableName, "6");
					this.DOrder = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrTestID.Equals("True") && this.DOrder != "True")
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
        public bool UpdateCliqueTest()
        {
            clsoperation objTrans = new clsoperation();
            QueryBuilder objQB = new QueryBuilder();

            objTrans.Start_Transaction();
            objdbhims.Query = "update ls_ttest set cliqtestid='" + strCliquetestid + "' where testid='" + StrTestID + "'";
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

		public bool Delete()
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

		public bool UpdateAll(string[,] arrayUpdate)
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();

			for(int counter = 0; counter <= arrayUpdate.GetUpperBound(0); counter++)
			{
				this.StrTestID = arrayUpdate[counter, 0];
				this.StrDOrder = arrayUpdate[counter, 1];

				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
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
			switch(flag)
			{
                case 1:
                    objdbhims.Query = @"Select tt.TestID, tt.Test, ts.sectionname,ttg.TestGroup, tt.acronym,tt.charges,tt.Specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method,tt.PREFERRED,tt.DELIVERYDATEONSPECIMEN,tt.RoundDelivery,tt.PrintMachineName,tt.PrintMethodName,tt.HistoryTaking,tt.ad_note,tt.batchtime,tt.Interpretation2,tt.Interpretation3,tt.Interpretation4,tt.Interpretation5,tt.Interpretationfooter,
                                     tt.external_orgid,tt.travel_time,tt.time_type,tt.TestCost,nvl(tt.cutoffday,0) cutoffday,tt.reportingtime
                                    from LS_TTest tt Inner Join Ls_TSection ts 
                                    on tt.sectionid=ts.sectionid 
                                    inner join Ls_TTEstGroup ttg 
                                    On ttg.testgroupid= tt.testgroupid 
                                    Left Outer Join LS_TMethod tm
                                    On tm.MethodID=tt.d_methodid
                                    Where tt.Active <> 'D' And Upper(tt.SectionID)='" + StrSectionID + @"'";
                    if (StrTestGroupID != Default && StrTestGroupID != "")
                    {
                        objdbhims.Query += " And Upper(ttg.TestGroupID)='" + StrTestGroupID + "'";
                    }
                 //   objdbhims.Query += @" Group by tt.TestID,tt.Test,ts.SectionName,tt.acronym,tt.charges,tt.Specimen,tt.dorder,tt.Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method,tt.PREFERRED,tt.DELIVERYDATEONSPECIMEN,tt.RoundDelivery,tt.PrintMethodName,tt.PrintMachineName,tt.HistoryTaking,tt.ad_note,tt.batchtime,tt.Interpretation2,tt.Interpretation3,tt.Interpretation4,tt.Interpretation5,tt.Interpretationfooter, tt.external_orgid,tt.travel_time,tt.time_type,tt.TestCost";
//
//                                    Union 
//                                    (SELECT ttgd.Testid,tt.Test,ts.Sectionname,wm_concat(ttg.TestGroup) TestGroup ,tt.acronym,tt.charges,tt.specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method,tt.PREFERRED,tt.DELIVERYDATEONSPECIMEN,tt.RoundDelivery,tt.PrintMethodName,tt.PrintMachineName,tt.historyTaking,tt.ad_note,tt.batchtime
//                                    From ls_ttestgroupd ttgd Inner Join ls_ttest tt
//                                    On tt.testid= ttgd.testid
//                                    Inner Join ls_tsection ts
//                                    On ts.SectionID=ttgd.SectionID
//                                    Inner Join ls_ttestgroup ttg
//                                    on ttg.testgroupid=ttgd.TestGroupID
//                                    Left Outer Join LS_TMethod tm
//                                    On tm.MethodID=tt.d_methodid
//                                    where tt.Active='Y' And ts.SectionID='" + StrSectionID + @"'";
//                    if (StrTestGroupID != Default && StrTestGroupID != "")
//                    {
//                        objdbhims.Query += " And Upper(ttgd.TestGroupID)='" + StrTestGroupID + "'";
//                    }
//                    objdbhims.Query += @" Group by ttgd.TestID,tt.Test,ts.Sectionname,tt.acronym,tt.charges,tt.specimen,tt.dorder,tt.Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method,tt.PREFERRED,tt.DELIVERYDATEONSPECIMEN,tt.RoundDelivery,tt.PrintMachineName,tt.PrintMethodName,tt.HistoryTaking,tt.ad_note,tt.batchtime) ";
                    break;

//                case 1:
//                    objdbhims.Query = @"Select tt.TestID, tt.Test, ts.sectionname,LISTAGG(ttg.TestGroup, ', ') WITHIN GROUP (ORDER BY tt.Testid) As TestGroup, tt.acronym,tt.charges,tt.Specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method
//                                    from LS_TTest tt Inner Join Ls_TSection ts 
//                                    on tt.sectionid=ts.sectionid 
//                                    inner join Ls_TTEstGroup ttg 
//                                    On ttg.testgroupid= tt.testgroupid 
//                                    Left Outer Join LS_TMethod tm
//                                    On tm.MethodID=tt.d_methodid
//                                    Where tt.Active <> 'D' And Upper(tt.SectionID)='" + StrSectionID + @"'";
//                    if (StrTestGroupID != Default && StrTestGroupID != "")
//                    {
//                        objdbhims.Query += " And Upper(ttg.TestGroupID)='" + StrTestGroupID + "'";
//                    }
//                    objdbhims.Query += @" Group by tt.TestID,tt.Test,ts.SectionName,tt.acronym,tt.charges,tt.Specimen,tt.dorder,tt.Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method
//                                    Union 
//                                    (SELECT ttgd.Testid,tt.Test,ts.Sectionname,LISTAGG(ttg.TestGroup, ', ') WITHIN GROUP (ORDER BY ttgd.Testid) As TestGroup ,tt.acronym,tt.charges,tt.specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method
//                                    From ls_ttestgroupd ttgd Inner Join ls_ttest tt
//                                    On tt.testid= ttgd.testid
//                                    Inner Join ls_tsection ts
//                                    On ts.SectionID=ttgd.SectionID
//                                    Inner Join ls_ttestgroup ttg
//                                    on ttg.testgroupid=ttgd.TestGroupID
//                                    Left Outer Join LS_TMethod tm
//                                    On tm.MethodID=tt.d_methodid
//                                    where tt.Active='Y' And ts.SectionID='" + StrSectionID + @"'";
//                    if (StrTestGroupID != Default && StrTestGroupID != "")
//                    {
//                        objdbhims.Query += " And Upper(ttgd.TestGroupID)='" + StrTestGroupID + "'";
//                    }
//                    objdbhims.Query += @" Group by ttgd.TestID,tt.Test,ts.Sectionname,tt.acronym,tt.charges,tt.specimen,tt.dorder,tt.Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method) ";
//                    break;


                //case 1:
//                    objdbhims.Query = @"Select tt.TestID,tt.Test, ts.sectionname,ttg.Testgroup, tt.acronym,tt.charges,tt.Specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method
//                                    from LS_TTest tt Inner Join Ls_TSection ts 
//                                    on tt.sectionid=ts.sectionid 
//                                    inner join Ls_TTEstGroup ttg 
//                                    On ttg.testgroupid= tt.testgroupid 
//                                    Left Outer Join LS_TMethod tm
//                                    On tm.MethodID=tt.d_methodid
//                                    Where tt.Active <> 'D'";
//                    objdbhims.Query += @" And Upper(tt.SectionID)='" + StrSectionID + "'";// And Upper(tt.TestGroupID) = '" + StrTestGroupID +"'";
//                    if (StrTestGroupID != Default && StrTestGroupID != "")
//                    {
//                        objdbhims.Query += " And Upper(tt.TestGroupID)='" + StrTestGroupID + "'";
//                    }
//                    objdbhims.Query += @" UNION
//                                    (SELECT ttgd.Testid,tt.Test,ts.Sectionname,ttg.testgroup,tt.acronym,tt.charges,tt.specimen,tt.dorder,tt.Active Active,tt.AutomatedText,tt.ClinicalUSe,tt.ProcedureID,tt.TestNo,tt.TestNolevel,tt.TestNoGenOn,tt.TestBatchNo,tt.ReportNo,tt.TestType,tt.SpecimenType,tt.Specimencontainer,tt.SepReport,tt.PrintTest,tt.PrintGroup,tt.SpeedTest,tt.ChargesUrgent,tt.Urgent,tt.Summary,tt.ReorderTime,tt.SpecimenQuantity,tt.SpecimenUnit,tt.ProvisionalReport,tt.External,tm.method
//                                    From ls_ttestgroupd ttgd Inner Join ls_ttest tt
//                                    On tt.testid= ttgd.testid
//                                    Inner Join ls_tsection ts
//                                    On ts.SectionID=ttgd.SectionID
//                                    Inner Join ls_ttestgroup ttg
//                                    on ttg.testgroupid=ttgd.TestGroupID
//                                    Left Outer Join LS_TMethod tm
//                                    On tm.MethodID=tt.d_methodid
//                                    where tt.Active='Y'";
//                    objdbhims.Query += @" And ts.SectionID='" + StrSectionID + "'";// And ttgd.testgroupid='"+StrTestGroupID +"')";
//                    if (StrTestGroupID != Default && StrTestGroupID != "")
//                    {
//                        objdbhims.Query += @" And Upper(ttgd.TestGroupID)='" + StrTestGroupID + "')";
//                    }
//                    else
//                    {
//                        objdbhims.Query += @")";
//                    }

//                    break;
                //case 1:
                //    objdbhims.Query = "Select * from LS_TTest tt Inner Join Ls_TSection ts on tt.sectionid=ts.sectionid Where tt.Active <> 'D' And Upper(tt.TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(tt.SectionID) = '" + StrSectionID.ToUpper() + "' Order By tt.DOrder";
                //    break;

				case 2:
					objdbhims.Query = "Select * from LS_TTest Where Active = 'Y' And Upper(TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(Active) = '" + StrActive.ToUpper() + "' Order By DOrder";
					break;

				case 3:
					objdbhims.Query = "Select * from LS_TTest Where Active = 'Y' And SectionID = '" + StrSectionID + "' And TestGroupID = '" + StrTestGroupID + "' And Upper(Test) like '%'||'" + StrTest.ToUpper() + "'||'%'";
					break;

				case 4:
					objdbhims.Query = "Select * from LS_TTest Where Active = 'Y' And Upper(TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(Acronym) = '" + this.StrAcronym.ToUpper() + "' Order By DOrder";
					break;

				case 5:
					objdbhims.Query = "Select * from LS_TTest Where Active = 'Y' And Upper(TestID) = '" + StrTestID.ToUpper() +"'";
					break;
                case 6:
                    objdbhims.Query = "Select tm.Method From LS_TMethod tm Inner Join Ls_TTestMethod ttm On ttm.MethodID=tm.MethodID Where ttm.TestID='" + StrTestID + "' And ttm.Active='Y' And ttm.M_Default='Y'";
                    break;
                case 7:
                    objdbhims.Query = "Select tg.TestGroup From LS_TTestGroup tg Inner Join LS_TTestGroupD tgd On tgd.TestGroupID=tg.TestGroupID Where tgd.TestID='" + StrTestID + "'";
                    break;
                case 8:
                    objdbhims.Query = @"Select nvl(tt.cutoffday,0) as cutoffday,nvl(tt.external_orgid,0) as external_orgid,tt.ReportingTime,tt.batchtime,tm.methodid,tm.tat,tm.maxtime,tm.mintime From LS_TMethod tm Inner join Ls_TTest tt 
                                        On tt.d_methodid=tm.methodID
                                        where tt.testid='"+this.StrTestID+"'";
                    break;
                case 9:
                    objdbhims.Query="Select TestGroupID,Attribute_Count From Ls_TTest Where TestID='"+StrTestID+"'";
                    break;

                case 10:
                    objdbhims.Query = "Select TestID,Test From LS_TTest where SectionID='" + StrSectionID + "' and Active='Y'"; 
                    break;
                case 11:
                    objdbhims.Query = "Select Preferred From Ls_TTest where TestId='" + StrTestID + "' And Active='Y'";
                    break;
                case 12:
                    objdbhims.Query = "Select tt.D_METHODID,tm.Method Method From LS_TTest tt Inner Join Ls_TMethod tm On tm.MethodID=tt.D_MethodID where tt.Active='Y' and tm.Active<>'N' and tt.TestID='"+StrTestID+"'";
                    break;
                case 13:
                    objdbhims.Query = "Select TestID,Test From LS_TTest where Active='Y'";
                    break;
                case 14:
                    objdbhims.Query = @"select d.dserialno,d.mserialno,b.batchno,m.labid,t.test,p.PatientName,to_char(d.enteredate,'dd-Mon-yyyy hh:mi:ss am') as enteredate,
'RMI' as Originid,eo.name as Destination, to_char(d.deliverydate,'dd-Mon-yyyy hh:mi:ss am') as DeliveryDate,
to_char(b.enteredon,'dd-Mon-yyyy hh:mi:ss am')  as dispatchedon 
from ls_tmtransaction m inner join ls_tdtransaction d on m.mserialno=d.mserialno
inner join ls_ttest t on t.testid=d.testid
inner join ls_vpatient p 
on p.MSerialNo=m.mserialno
inner join LS_TCOURIERBATCHES b on b.dserialno=d.dserialno 
inner join ls_textorganization eo on b.extorgid=eo.orgid 
                                        where d.processid='0010' and b.enteredon between to_date('" + StrFromdate + "', 'dd/MM/yyyy') and to_date('" + Strtodate + "', 'dd/MM/yyyy')";
                    if (Strorgid != "" && Strorgid != Default)
                    {
                        objdbhims.Query += " and eo.orgid= " + Strorgid;
                    }

                    if (StrLabId != "" && StrLabId != Default)
                    {
                        objdbhims.Query += " and m.labid = '" + StrLabId + "'";
                    }
                    break;
                case 15:
                    objdbhims.Query += @"Select Procedureid,External,external_orgid,TestCost,case when time_type='M' then travel_time when time_type='H' then travel_time*60  when time_type='D' then travel_time*60*24 else 0 end as traveltime from ls_ttest where Testid='" + StrTestID + "'";
                    break;
                case 16:
                    objdbhims.Query = " select THRESHOLDTIME from ls_tpreferencesettings";
                    break;
                case 17:
                    objdbhims.Query = "select ORGID,NAME from ls_textorganization where active = 'Y'";
                    break;
                case 18:
                    objdbhims.Query = "select t.testid,t.test,t.cliqtestid clique_id,t.d_methodid,m.method from ls_ttest t inner join ls_tmethod m on m.methodid=t.d_methodid where t.active='Y' order by t.test asc";
                    break;
                case 19:
                    objdbhims.Query = "Select labid,mserialno from ls_tmtransaction where rownum<3000";
                    break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

		private string[,] MakeArray()
		{
			string[,] aryTest = new string[49,3];

			if(!this.StrTestID.Equals(Default))
			{
				aryTest[0,0] = "TestID";
				aryTest[0,1] = this.StrTestID;
				aryTest[0,2] = "string";
			}			
			if(!this.StrTestGroupID.Equals(Default))
			{
				aryTest[1,0] = "TestGroupID";
				aryTest[1,1] = this.StrTestGroupID;
				aryTest[1,2] = "string";
			}
			if(!this.StrSectionID.Equals(Default))
			{
				aryTest[2,0] = "SectionID";
				aryTest[2,1] = this.StrSectionID;
				aryTest[2,2] = "string";
			}
			if(!this.StrTest.Equals(Default))
			{
				aryTest[3,0] = "Test";
				aryTest[3,1] = this.StrTest;
				aryTest[3,2] = "string";
			}
			if(!this.StrActive.Equals(Default))
			{
				aryTest[4,0] = "Active";
				aryTest[4,1] = this.StrActive;
				aryTest[4,2] = "string";
			}
			if(!this.StrAcronym.Equals(Default))
			{
				aryTest[5,0] = "Acronym";
				aryTest[5,1] = this.StrAcronym;
				aryTest[5,2] = "string";
			}
			if(!this.StrCharges.Equals(Default))
			{
				aryTest[6,0] = "Charges";
				aryTest[6,1] = this.StrCharges;
				aryTest[6,2] = "int";
			}
			if(!this.StrSpecimen.Equals(Default))
			{
				aryTest[7,0] = "Specimen";
				aryTest[7,1] = this.StrSpecimen;
				aryTest[7,2] = "string";
			}
			if(!this.StrSpecimenType.Equals(Default))
			{
				aryTest[8,0] = "SpecimenType";
				aryTest[8,1] = this.StrSpecimenType;
				aryTest[8,2] = "string";
			}
			if(!this.StrSpecimenContainer.Equals(Default))
			{
				aryTest[9,0] = "SpecimenContainer";
				aryTest[9,1] = this.StrSpecimenContainer;
				aryTest[9,2] = "string";
			}
			if(!this.StrAutomatedText.Equals(Default))
			{
				aryTest[10,0] = "AutomatedText";
				aryTest[10,1] = this.StrAutomatedText;
				aryTest[10,2] = "string";
			}
			if(!this.StrClinicalUse.Equals(Default))
			{
				aryTest[11,0] = "ClinicalUse";
				aryTest[11,1] = this.StrClinicalUse;
				aryTest[11,2] = "string";
			}
			if(!this.StrDOrder.Equals(Default))
			{
				aryTest[12,0] = "DOrder";
				aryTest[12,1] = this.StrDOrder;
				aryTest[12,2] = "int";
			}
			if(!this.StrGenerationLevel.Equals(Default))
			{
				aryTest[13,0] = "TestNoLevel";
				aryTest[13,1] = this.StrGenerationLevel;
				aryTest[13,2] = "string";
			}
			if(!this.StrGenerateOn.Equals(Default))
			{
				aryTest[14,0] = "TestNoGenOn";
				aryTest[14,1] = this.StrGenerateOn;
				aryTest[14,2] = "string";
			}

			if(!this.StrProcedureID.Equals(Default))
			{
				aryTest[15,0] = "ProcedureID";
				aryTest[15,1] = this.StrProcedureID;
				aryTest[15,2] = "string";
			}

			if(!this.StrTestType.Equals(Default))
			{
				aryTest[16,0] = "TestType";
				aryTest[16,1] = this.StrTestType;
				aryTest[16,2] = "string";
			}

			if(!this.StrSepReport.Equals(Default))
			{
				aryTest[17,0] = "SepReport";
				aryTest[17,1] = this.StrSepReport;
				aryTest[17,2] = "string";
			}

			if(!this.StrPrintTest.Equals(Default))
			{
				aryTest[18,0] = "PRINTTEST";
				aryTest[18,1] = this.StrPrintTest;
				aryTest[18,2] = "string";
			}
			if(!this.StrPrintGroup.Equals(Default))
			{
				aryTest[19,0] = "PRINTGROUP";
				aryTest[19,1] = this.StrPrintGroup;
				aryTest[19,2] = "string";
			}
			if(!this.StrChargesUrgent.Equals(Default))
			{
				aryTest[20,0] = "ChargesUrgent";
				aryTest[20,1] = this.StrChargesUrgent;
				aryTest[20,2] = "int";
			}
			if(!this.StrUrgent.Equals(Default))
			{
				aryTest[21,0] = "Urgent";
				aryTest[21,1] = this.StrUrgent;
				aryTest[21,2] = "string";
			}

            if (!this.StrSummary.Equals(Default))
            {
                aryTest[22, 0] = "summary";
                aryTest[22, 1] = this.StrSummary;
                aryTest[22, 2] = "string";
            }
            if (!this.StrReorder.Equals(Default))
            {
                aryTest[23, 0] = "reordertime";
                aryTest[23, 1] = this.StrReorder;
                aryTest[23, 2] = "string";
            }
            if (!this.StrEnteredon.Equals(Default))
            {
                aryTest[24, 0] = "enteredon";
                aryTest[24, 1] = this.StrEnteredon;
                aryTest[24, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryTest[25, 0] = "enteredby";
                aryTest[25, 1] = this.StrEnteredby;
                aryTest[25, 2] = "string";
            }

            if(!this.StrSpecimenQuantity.Equals(Default))
            {
                aryTest[26, 0] = "SpecimenQuantity";
                aryTest[26, 1] = this.StrSpecimenQuantity;
                aryTest[26, 2] = "string";
            }
            if (!this.StrSpecimenUnit.Equals(Default))
            {
                aryTest[27, 0] = "SpecimenUnit";
                aryTest[27, 1] = StrSpecimenUnit;
                aryTest[27, 2] = "string";
            }
            if (!this.StrProvisionalReport.Equals(Default))
            {
                aryTest[28, 0] = "PROVISIONALREPORT";
                aryTest[28, 1] = StrProvisionalReport;
                aryTest[28, 2] = "string";
            }
            if (!this.StrExternal.Equals(Default))
            {
                aryTest[29, 0] = "EXTERNAL";
                aryTest[29, 1] = StrExternal;
                aryTest[29, 2] = "string";
            }
            if (!this.StrPreferred.Equals(Default))
            {
                aryTest[30, 0] = "Preferred";
                aryTest[30, 1] = StrPreferred;
                aryTest[30, 2] = "string";
            }
            if (!this.StrDeliveryDateOnSpecimen.Equals(Default))
            {
                aryTest[31, 0] = "DELIVERYDATEONSPECIMEN";
                aryTest[31, 1] = StrDeliveryDateOnSpecimen;
                aryTest[31, 2] = "string";
            }
            if (!this.StrRoundDelivery.Equals(Default))
            {
                aryTest[32, 0] = "RoundDelivery";
                aryTest[32, 1] = StrRoundDelivery;
                aryTest[32, 2] = "string";
            }
            if (!this.StrPrintMachine.Equals(Default))
            {
                aryTest[33, 0] = "PrintMachineName";
                aryTest[33, 1] = StrPrintMachine;
                aryTest[33, 2] = "string";
            }
            if (!this.StrPrintMethod.Equals(Default))
            {
                aryTest[34, 0] = "PrintMethodName";
                aryTest[34, 1] = StrPrintMethod;
                aryTest[34, 2] = "string";
            }
            if (!this.StrHistoryTaking.Equals(Default))
            {
                aryTest[35, 0] = "HistoryTaking";
                aryTest[35, 1] = StrHistoryTaking;
                aryTest[35, 2] = "string";
            }
            if (!this.StrAd_Note.Equals(Default))
            {
                aryTest[36, 0] = "Ad_Note";
                aryTest[36, 1] = StrAd_Note;
                aryTest[36, 2] = "string";
            }
            if (!this.StrbatchTime.Equals(Default))
            {
                aryTest[37, 0] = "batchTime";
                aryTest[37, 1] = StrbatchTime;
                aryTest[37, 2] = "string";
            }
            if (!this.StrInterpretation2.Equals(Default))
            {
                aryTest[38, 0] = "INTERPRETATION2";
                aryTest[38, 1] = StrInterpretation2;
                aryTest[38, 2] = "string";
            }
            if (!this.StrInterpretation3.Equals(Default))
            {
                aryTest[39, 0] = "Interpretation3";
                aryTest[39, 1] = StrInterpretation3;
                aryTest[39, 2] = "string";
            }
            if (!this.StrInterpretation4.Equals(Default))
            {
                aryTest[40, 0] = "Interpretation4";
                aryTest[40, 1] = StrInterpretation4;
                aryTest[40, 2] = "string";
            }
            if (!this.StrInterpretation5.Equals(Default))
            {
                aryTest[41, 0] = "Interpretation5";
                aryTest[41, 1] = StrInterpretation5;
                aryTest[41, 2] = "string";
            }
            if (!this.StrInterpretationfooter.Equals(Default))
            {
                aryTest[42, 0] = "Interpretationfooter";
                aryTest[42, 1] = StrInterpretationfooter;
                aryTest[42, 2] = "string";
            }
            if (!this.Strorgid.Equals(Default))
            {
                aryTest[43, 0] = "EXTERNAL_ORGID";
                aryTest[43, 1] = Strorgid;
                aryTest[43, 2] = "int";
            }
            if (!this.Strtimetype.Equals(Default))
            {
                aryTest[44, 0] = "TIME_TYPE";
                aryTest[44, 1] = Strtimetype;
                aryTest[44, 2] = "string";
            }
            if (!this.StrTraveltime.Equals(Default))
            {
                aryTest[45, 0] = "TRAVEL_TIME";
                aryTest[45, 1] = StrTraveltime;
                aryTest[45, 2] = "int";
            }
            if (!this._TestCost.Equals(Default))
            {
                aryTest[46, 0] = "TestCost";
                aryTest[46, 1] = _TestCost;
                aryTest[46, 2] = "int";
 
            }
            if (!this._Cutoffday.Equals(Default))
            {
                aryTest[47, 0] = "Cutoffday";
                aryTest[47, 1] = _Cutoffday;
                aryTest[47, 2] = "int";

            }
            if (!this._ReportingTime.Equals(Default))
            {
                aryTest[48, 0] = "ReportingTime";
                aryTest[48, 1] = _ReportingTime;
                aryTest[48, 2] = "string";

            }
           

			return aryTest;
		}

		public string GetTestNo(string testID, string generator, clsoperation trans)
		{
			objdbhims.Query = "select * from ls_ttest where testid='"+testID+"' "+
				"and testnogenon='"+generator+"'";
			DataView dv = trans.Transaction_Get_Single(objdbhims);

			if(dv.Table.Rows.Count>0)
			{
				string testNo="0";
				string level = dv.Table.Rows[0]["TestNoLevel"].ToString();
				if(level.Equals("S"))
				{
					testNo = new clsBLSection().GetNextTestNo(dv.Table.Rows[0]["SectionID"].ToString(), trans);
				}
				else if(level.Equals("G"))
				{
					testNo = new clsBLTestGroup().GetNextTestNo(dv.Table.Rows[0]["TestGroupID"].ToString(), trans);
				}
				else if(level.Equals("T"))
				{
					testNo = new clsBLTest().GetNextTestNo(dv.Table.Rows[0]["TestID"].ToString(), trans);
				}
				else
				{
					testNo = "0";//new clsBLTest().GetNextTestNo(detail.TestID, objTrans);
				}
				return testNo;
			}
			else
			{
				return "0";
			}
		}

		public string GetNextTestNo(string testID, clsoperation trans)
		{
            
			
			objdbhims.Query = "select testno from "+TableName+" where testid='"+testID+"'";
			DataTable table = trans.Transaction_Get_Single(objdbhims).Table;
			string testNo = table.Rows[0][0].ToString();
			
			objdbhims.Query = "update "+TableName+" set testno=testno+1 where testid='"+testID+"'";
			trans.DataTrigger_Update(objdbhims);
			
			return testNo;
		}

        public string GetTestId()
        {
            clsoperation trans1 = new clsoperation();
            trans1.Start_Transaction();
            string _TestId="";
            objdbhims.Query = "Select max(TestID) From LS_TTest";
            DataView dv = trans1.Transaction_Get_Single(objdbhims);
            if (dv.Count > 0)
            {
                _TestId = dv.Table.Rows[0]["max(TestID)"].ToString();
            }
            trans1.End_Transaction();
            //_TestId = trans1.DataTrigger_Get_Max(objdbhims);
            //_TestId=trans1.Tra
            return _TestId;
        }

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_Test())
			{
				return false;
			}
/*
			if(!VD_Acronym())
			{
				return false;
			}
*/
			if(!VD_Charges())
			{
				return false;
			}
			if(!VD_ChargesUrgent())
			{
				return false;
			}
			if(!VD_Specimen())
			{
				return false;
			}
			if(!VD_SpecimenType())
			{
				return false;
			}			
			if(!VD_SpecimenContainer())
			{
				return false;
			}
            
			return true;
		}

		public bool VD_Test()
		{
			Validation objValid = new Validation();

			if(StrTest.Equals(""))
			{
				this.StrErrorMessage = "Please enter Test. (empty is not allowed)";
				return false;
			}

			DataView dvTest = GetAll(3);

			if(!StrTestID.Equals(Default))
			{
				dvTest.RowFilter = "TestID <> '" + StrTestID + "' And Test = '" + StrTest + "'";
			}
			else
			{
				dvTest.RowFilter = "Test = '" + StrTest + "'";
			}

			if(dvTest.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Test Name, it is already present.";
				return false;
			}

			return true;
		}

		public bool VD_Acronym()
		{
			if(!StrAcronym.Equals(""))
			{
				Validation objValid = new Validation();

			/*	if(StrAcronym.Equals(""))
				{
					this.StrErrorMessage = "Please enter Acronym. (empty is not allowed)";
					return false;
				}
*/
				DataView dvAcronym = GetAll(4);

				if(!StrTestID.Equals(Default))
				{
					dvAcronym.RowFilter = "TestID <> " + StrTestID;
				}

				if(dvAcronym.Count > 0)
				{
					this.StrErrorMessage = "Please enter another Acronym, it is already present.";
					return false;
				}
			}

			return true;
		}

		private bool VD_Charges()
		{
			Validation objValid = new Validation();

			if(this.StrCharges.Equals(""))
			{
				this.StrErrorMessage = "Please insert Charges. (empty is not allowed)";
				return false;
			}
			else if(!objValid.IsPositiveNumber(this.StrCharges))
			{
				this.StrErrorMessage = "Please enter valid Charges. (only +ve integer is allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_ChargesUrgent()
		{
			Validation objValid = new Validation();

			if(this.StrChargesUrgent.Equals(""))
			{
				this.StrChargesUrgent = "0";
				return true;
			}
			else if(!objValid.IsPositiveNumber(this.StrChargesUrgent))
			{
				this.StrErrorMessage = "Please enter valid Urgent Charges. (only +ve integer is allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_Specimen()
		{
			if(this.StrSpecimen.Equals(""))
			{
				this.StrErrorMessage = "Please enter Test Specimen. (empty is not allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}

		private bool VD_SpecimenType()
		{
			if(this.StrSpecimenType.Equals("-1"))
			{
				this.StrErrorMessage = "Please select Specimen. (empty is not allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}
		private bool VD_SpecimenContainer()
		{
			if(this.StrSpecimenContainer.Equals("-1"))
			{
				this.StrErrorMessage = "Please select Specimen Container. (empty is not allowed)";
				return false;
			}
			else
			{
				return true;
			}
		}

		#endregion
	}
}