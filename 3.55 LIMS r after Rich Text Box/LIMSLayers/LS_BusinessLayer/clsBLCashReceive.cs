using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;
using System.IO;
using FILE_MODS;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLCashReceive.
	/// </summary>
	public class clsBLCashReceive
	{
		public clsBLCashReceive()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private FileIO FileIO;
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
		private string StrLabIDFrom = Default;		
		private string StrLabIDTo = Default;				
		private string StrLabID = Default;				
		private string StrPRNo = Default;				
		private string StrTotalAmount = Default;				
		private string StrPatientName = Default;		
		private string StrSex = Default;
		private string StrTestID = Default;
		private string StrPLNo = Default;
		private string StrWardID = Default;
		private string StrPatientType = Default;
		private string StrIOPatient = Default;
		private string StrEnteredateF = Default;		
		private string StrEnteredateT = Default;		
		private string StrPath = @"D:\LABCASHTRANSACTION";
		private string StrPath2 = @"D:\HMIS\LIMS\temp";
		private string StrFileName = DateTime.Now.ToString("yyyyMMdd")+".txt";			
		private string StrNewLine = Default;					
		//06-001-0000000, Date, RMINo, Name, Total
		
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
			get{	return StrLabID;	}
			set{	StrLabID = value;	}
		}	
		
		public string PRNo
		{
			get{	return StrPRNo;	}
			set{	StrPRNo = value;	}
		}	
		
		public string TotalAmount
		{
			get{	return StrTotalAmount;	}
			set{	StrTotalAmount = value;	}
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
		
		public string NewLine
		{
			get{	return StrNewLine;		}
			set{	StrNewLine = value;	}
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

		public bool appendtextinfo()
		{					
			if ((StrPRNo.Equals("&nbsp;")) || (StrPRNo.Equals(""))) {StrPRNo = "1";}	

			StrNewLine = StrLabID+", "+DateTime.Now.ToString("dd/MM/yyyy")+", "+StrPRNo+", "+StrPatientName.Trim()+", "+StrTotalAmount;
			
			if (!NewLine.Equals(Default))
			{
				
				FileIO = new FileIO();
				FileIO.PathTest( 1 , StrPath );
				FileIO.PathTest( 2 , StrPath , StrFileName );
				FileIO.AppendLastLine( StrPath , StrFileName , StrNewLine );		
			
				//FileIO = new FileIO();
				FileIO.PathTest( 1 , StrPath2 );
				FileIO.PathTest( 2 , StrPath2 , StrFileName );
				FileIO.AppendLastLine( StrPath2 , StrFileName , StrNewLine );		
				return true;			
			} 
			return false;
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
			
			appendtextinfo();
			
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
			string sSectionID = "", sTestGroupID = "", sPatientName = "", sSex = "", sLabIDFrom = "", sLabIDTo = "", sTestID = "", sPLNo = "", sWardID = "", sPatientType = "", sIOPatient = "", sEnteredateF = "", sEnteredateT = "" ;

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
						{sEnteredateF = " And to_Date(to_Char(m.EntryDateTime, 'dd/mm/yyyy'), 'dd/mm/yyyy') >= to_date('"+ StrEnteredateF +"', 'dd/mm/yyyy') ";}
					}

					if (ValidateDT())
					{
						if(!this.StrEnteredateT.Equals(Default))
						{sEnteredateT = " And to_Date(to_Char(m.EntryDateTime, 'dd/mm/yyyy'), 'dd/mm/yyyy') <= to_date('"+ StrEnteredateT +"', 'dd/mm/yyyy') ";}
					}	

					objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo, p.WardName, m.PaidAmount, m.LabID, m.PRNo from LS_tMTransaction m, LS_vPatient p Where m.MSerialNo = p.MSerialNo "+sPatientName+sSex+" And m.MStatus not in ('C') And m.MSerialNo in (Select MSerialNo from LS_TDTransaction where ProcessID = '" + cProcessID + "' "+sSectionID+sTestGroupID+") "+sLabIDFrom+sLabIDTo+sEnteredateF+sEnteredateT+"Order By m.Priority DESC, m.MSerialNo";
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
						{sEnteredateF = " And to_Date(to_Char(d.Enteredate, 'dd/mm/yyyy'), 'dd/mm/yyyy') >= to_date('"+ StrEnteredateF +"', 'dd/mm/yyyy') ";}
					}

					if (ValidateDT())
					{
						if(!this.StrEnteredateT.Equals(Default))
						{sEnteredateT = " And to_Date(to_Char(d.Enteredate, 'dd/mm/yyyy'), 'dd/mm/yyyy') <= to_date('"+ StrEnteredateT +"', 'dd/mm/yyyy') ";}
					}	

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


					if ((sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sLabIDFrom + sLabIDTo + sWardID + sIOPatient + sPatientType + sEnteredateF + sEnteredateT) == "")
					{
						sSectionID = " And 1 = 2";
					}				

					objdbhims.Query = "Select Case When  m.priority = 'U' Then 'Urg' When  m.priority = 'V' Then 'VIP' Else 'Nor' end As priority, m.MSerialNo, p.patientCompletename As PatientName, p.PSex, To_Char(p.PAgeD)||' '||p.PAgeUN As PAge, p.PType As Type, p.ServiceNo, d.DSerialNo, t.Test, NVL(p.ServiceNo, ''), to_char(d.Enteredate, 'dd/mm/yyyy') As EnteredDate, p.WardName from LS_tMTransaction m, LS_vPatient p, LS_TDTransaction d, LS_TTest t Where m.MSerialNo = p.MSerialNo And m.MStatus not in ('C') And m.MSerialNo = d.MSerialNo And d.TestID = t.TestID And d.SectionID = t.SectionID And d.TestGroupID = t.TestGroupID " + sSectionID + sPLNo + sTestGroupID + sTestID + sPatientName + sSex + sLabIDFrom + sLabIDTo + sWardID + sIOPatient + sPatientType + sEnteredateF + sEnteredateT + " And d.ProcessID ='" + StrProcessID + "' Order By m.MSerialNo";
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