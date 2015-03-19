using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;


namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLPatient.
	/// </summary>
	public class clsBLPatient
	{
		public clsBLPatient()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_tPatient";
		private string StrErrorMessage = "";				
		
		private string StrMSerialNo = Default;
		private string StrTitle = Default;
		private string StrPFName = Default;
		private string StrPMName = Default;
		private string StrPLName = Default;
		private string StrPSex = Default;
		private string StrPAgeD = Default;
		private string StrPAgeU = Default;
		private string StrPDOB = Default;
		private string StrUnitID = Default;
		private string StrRankID = Default;
		private string StrServiceNo = Default;
		private string StrRefNo = Default;
		private string StrKinShip = Default;
		private string StrKFName = Default;
		private string StrKMName = Default;
		private string StrKLName = Default;
		private string StrWardID = Default;
		private string StrRequestNo = Default;
		private string StrPAdmNo = Default;
		private string StrPAdmDate = Default;
		private string StrRefDoctor = Default;
		private string StrDiagnosis = Default;
        

		#endregion

		#region "Properties"	
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}
		public string MSerialNo
		{
			get{	return StrMSerialNo;	}
			set{	StrMSerialNo = value;	}
		}
		public string PTitle
		{
			get{	return StrTitle;	}
			set{	StrTitle = value;	}
		}
		public string PFName
		{
			get{	return StrPFName;	}
			set{	StrPFName = value;	}
		}
		public string PMName
		{
			get{	return StrPMName;	}
			set{	StrPMName = value;	}
		}
		public string PLName
		{
			get{	return StrPLName;	}
			set{	StrPLName = value;	}
		}
		public string PSex
		{
			get{	return StrPSex;	}
			set{	StrPSex = value;	}
		}
		public string PAgeD
		{
			get{	return StrPAgeD;	}
			set{	StrPAgeD = value;	}
		}
		public string PAgeU
		{
			get{	return StrPAgeU;	}
			set{	StrPAgeU = value;	}
		}
		public string PDOB
		{
			get{	return StrPDOB;	}
			set{	StrPDOB = value;	}
		}
		public string UnitID
		{
			get{	return StrUnitID;	}
			set{	StrUnitID = value;	}
		}			
		public string RankID
		{
			get{	return StrRankID;	}
			set{	StrRankID = value;	}
		}			
		public string ServiceNo
		{
			get{	return StrServiceNo;	}
			set{	StrServiceNo = value;	}
		}			
		public string RefNo
		{
			get{	return StrRefNo;	}
			set{	StrRefNo = value;	}
		}					
		public string KinShip
		{
			get{	return StrKinShip;	}
			set{	StrKinShip = value;	}
		}			
		public string KFName
		{
			get{	return StrKFName;	}
			set{	StrKFName = value;	}
		}						
		public string KMName
		{
			get{	return StrKMName;	}
			set{	StrKMName = value;	}
		}				
		public string KLName
		{
			get{	return StrKLName;	}
			set{	StrKLName = value;	}
		}
		public string WardID
		{
			get{	return StrWardID;	}
			set{	StrWardID = value;	}
		}
		public string RequestNo
		{
			get{	return StrRequestNo;	}
			set{	StrRequestNo = value;	}
		}
		public string PAdmNo
		{
			get{	return StrPAdmNo;	}
			set{	StrPAdmNo = value;	}
		}						
		public string PAdmDate
		{
			get{	return StrPAdmDate;	}
			set{	StrPAdmDate = value;	}
		}				
		public string RefDoctor
		{
			get{	return StrRefDoctor;	}
			set{	StrRefDoctor = value;	}
		}				
		public string Diagnosis
		{
			get{	return StrDiagnosis;	}
			set{	StrDiagnosis = value;	}
		}							
		#endregion
		int iopIndex=-1, entitledIndex=-1;
		clsoperation objTrans = new clsoperation();
		clsdbhims objdbhims = new clsdbhims();

		#region "Methods"

		public string Insert(int entitledIndex, int iopIndex, long mSerialNo)
		{
			this.entitledIndex = entitledIndex;
			this.iopIndex = iopIndex;
			if(Validate())
			{
				try
				{
					QueryBuilder objQB = new QueryBuilder();
					
					// setting transaction master serial no
					this.StrMSerialNo = mSerialNo.ToString();
					return objQB.QBInsert(MakeArray(), TableName);
				}
				catch(Exception e)
				{
					this.StrErrorMessage = e.Message;
				}
			}
			return "";
		}

		public bool Update()
		{
			if(Validate())
			{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				//objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
				//objTrans.End_Transaction();

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

		public bool UpdatePatientName()
		{
				clsoperation objTrans = new clsoperation();
				QueryBuilder objQB = new QueryBuilder();

				objTrans.Start_Transaction();
				objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
				this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
				

				if(this.StrErrorMessage.Equals("True"))
				{
                    objTrans.End_Transaction();
					this.StrErrorMessage = objTrans.OperationError;
					return false;
				}

                objdbhims.Query = "update ls_tmtransaction set referredby='" + StrRefDoctor + "' where MserialNo="+StrMSerialNo ;
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                if (this.StrErrorMessage.Equals("True"))
                {
                    objTrans.End_Transaction();
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                objTrans.End_Transaction();
                return true;
							
		}

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
					objdbhims.Query = "Select MSerialNo, PTitle, PFName, PMName, PLName, patientCompletename, KinShip, KFName, KMName, KLName, PSex, PAgeD, PAgeUN, WardID, PAdmNo, RequestNo, PAdmDate, RefDoctor from LS_VPatient Where MSerialNo = '"+StrMSerialNo+"'Order By PTitle, PFName, PMName, PLName";
					break;

				case 2:
					/*objdbhims.Query = "Select * from LS_TMTransaction Where Upper(Acronym) = '" + StrAcronym.ToUpper() + "' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";*/
					break;

				case 3:
					/*				objdbhims.Query = "Select * from LS_TMTransaction Where Upper(SectionID) = '" + StrSectionID.ToUpper() + "'";*/
					break;
			}
			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryLIMS = new string[22,3];

			if(!this.StrMSerialNo.Equals(Default))
			{
				aryLIMS[0,0] = "MSerialNo";
				aryLIMS[0,1] = this.StrMSerialNo;
				aryLIMS[0,2] = "int";
			}

			if(!this.StrPFName.Equals(Default))
			{
				aryLIMS[1,0] = "PFName";
				aryLIMS[1,1] = this.StrPFName;
				aryLIMS[1,2] = "string";
			}

			if(!this.StrPMName.Equals(Default))
			{
				aryLIMS[2,0] = "PMName";
				aryLIMS[2,1] = this.StrPMName;
				aryLIMS[2,2] = "string";
			}

			if(!this.StrPLName.Equals(Default))
			{
				aryLIMS[3,0] = "PLName";
				aryLIMS[3,1] = this.StrPLName;
				aryLIMS[3,2] = "string";
			}

			if(!this.StrPSex.Equals(Default))
			{
				aryLIMS[4,0] = "PSex";
				aryLIMS[4,1] = this.StrPSex;
				aryLIMS[4,2] = "string";
			}

			if(!this.StrPAgeD.Equals(Default))
			{
				aryLIMS[5,0] = "PAgeD";
				aryLIMS[5,1] = this.StrPAgeD;
				aryLIMS[5,2] = "int";
			}
			if(!this.StrPAgeU.Equals(Default))
			{
				aryLIMS[6,0] = "PAgeU";
				aryLIMS[6,1] = this.StrPAgeU;
				aryLIMS[6,2] = "string";
			}
			if(!this.StrPDOB.Equals(Default))
			{
				aryLIMS[7,0] = "PDOB";
				aryLIMS[7,1] = this.StrPDOB;
				aryLIMS[7,2] = "date";
			}
			if(!this.StrUnitID.Equals(Default))
			{
				aryLIMS[8,0] = "UnitID";
				aryLIMS[8,1] = this.StrUnitID;
				aryLIMS[8,2] = "string";
			}
			if(!this.StrRankID.Equals(Default))
			{
				aryLIMS[9,0] = "RankID";
				aryLIMS[9,1] = this.StrRankID;
				aryLIMS[9,2] = "string";
			}
			if(!this.StrServiceNo.Equals(Default))
			{
				aryLIMS[10,0] = "ServiceNo";
				aryLIMS[10,1] = this.StrServiceNo;
				aryLIMS[10,2] = "string";
			}
			if(!this.StrKinShip.Equals(Default))
			{
				aryLIMS[11,0] = "KinShip";
				aryLIMS[11,1] = this.StrKinShip;
				aryLIMS[11,2] = "string";
			}
			if(!this.StrKFName.Equals(Default))
			{
				aryLIMS[12,0] = "KFName";
				aryLIMS[12,1] = this.StrKFName;
				aryLIMS[12,2] = "string";
			}
			if(!this.StrKMName.Equals(Default))
			{
				aryLIMS[13,0] = "KMName";
				aryLIMS[13,1] = this.StrKMName;
				aryLIMS[13,2] = "string";
			}
			if(!this.StrKLName.Equals(Default))
			{
				aryLIMS[14,0] = "KLName";
				aryLIMS[14,1] = this.StrKLName;
				aryLIMS[14,2] = "string";
			}					
			if(!this.StrWardID.Equals(Default))
			{
				aryLIMS[15,0] = "WardID";
				aryLIMS[15,1] = this.StrWardID;
				aryLIMS[15,2] = "string";
			}		
			if(!this.StrPAdmNo.Equals(Default))
			{
				aryLIMS[16,0] = "PAdmNo";
				aryLIMS[16,1] = this.StrPAdmNo;
				aryLIMS[16,2] = "string";
			}		
			if(!this.StrPAdmDate.Equals(Default))
			{
				aryLIMS[17,0] = "PAdmDate";
				aryLIMS[17,1] = this.StrPAdmDate;
				aryLIMS[17,2] = "date";
			}		
			if(!this.StrRefDoctor.Equals(Default))
			{
				aryLIMS[18,0] = "RefDoctor";
				aryLIMS[18,1] = this.StrRefDoctor;
				aryLIMS[18,2] = "string";
			}		
			if(!this.StrDiagnosis.Equals(Default))
			{
				aryLIMS[19,0] = "Diagnosis";
				aryLIMS[19,1] = this.StrDiagnosis;
				aryLIMS[19,2] = "string";
			}
			if(!this.StrTitle.Equals(Default))
			{
				aryLIMS[20,0] = "PTitle";
				aryLIMS[20,1] = this.StrTitle;
				aryLIMS[20,2] = "string";
			}
			if(!this.StrRefNo.Equals(Default))
			{
				aryLIMS[21,0] = "RefNo";
				aryLIMS[21,1] = this.StrRefNo;
				aryLIMS[21,2] = "string";
			}
			return aryLIMS;
		}

		#endregion

		#region "Validation Functions"

		public bool Validate()
		{
			return VD_Method();
		}

		private bool VD_Method()
		{
			Validation valid = new Validation();

			if(this.StrMSerialNo.Equals(""))
			{
				this.StrErrorMessage = "Invalid Master Serial No (empty is not allowed).";
				return false;
			}
			if(!valid.IsName(this.PFName))
			{
				this.StrErrorMessage = "Please enter Patient First Name(empty is not allowed).";
				return false;
			}
			if(!this.PMName.Equals("") && !valid.IsName(this.PMName))
			{
				this.StrErrorMessage = "Please enter corrent Patient Middle Name(invalid name is not allowed).";
				return false;
			}
			if(!this.PLName.Equals("") && !valid.IsName(this.PLName))
			{
				this.StrErrorMessage = "Please enter corrent Patient Last Name(invalid name is not allowed).";
				return false;
			}
			if(!valid.IsName(this.StrPSex))
			{
				this.StrErrorMessage = "Please select Patient Sex (empty is not allowed).";
				return false;
			}
			if(!this.PDOB.Equals("") && !valid.IsDate(this.PDOB))
			{
				this.StrErrorMessage = "Please enter valid Patient Date of Birth. (days/month/year)";
				return false;
			}
			if(!valid.IsInteger(this.StrPAgeD))
			{
				this.StrErrorMessage = "Please enter Patient Age (empty is not allowed).";
				return false;
			}
			if(this.KinShip.Equals("-1"))
			{
				this.StrErrorMessage = "Please select Relationship.";
				return false;
			}
			if(this.KFName.Equals("") || !valid.IsName(this.KFName))
			{
				this.StrErrorMessage = "Please enter valid Relative's First Name (empty is not allowed).";
				return false;
			}

			if (this.PSex.Equals("Male")) 
			{			
				if ((this.KinShip.Equals("M/O")) || (this.KinShip.Equals("W/O")) || (this.KinShip.Equals("D/O")))
				{
					this.StrErrorMessage = "Please enter valid Sex / Relation....";
					return false;			
				}
				else if (this.KinShip.Equals("Self"))
				{
					if ((this.PTitle.Equals("Miss")) || (this.PTitle.Equals("Mrs")))
					{
						this.StrErrorMessage = "Please enter valid Sex / Relation....";
						return false;								
					}
				}
			}
			else
			if (this.PSex.Equals("Female")) 
			{
				if ((this.KinShip.Equals("F/O")) || (this.KinShip.Equals("H/O")) || (this.KinShip.Equals("S/O")))
				{
					this.StrErrorMessage = "Please enter valid Sex / Relation....";
					return false;			
				} 				
				else if (this.KinShip.Equals("Self"))
				{
					if ((this.PTitle.Equals("Mr")) || (this.PTitle.Equals("Master")))
					{
						this.StrErrorMessage = "Please enter valid Sex / Relation....";
						return false;								
					}
				}
			}     

			if(entitledIndex == 0)
			{
				if(this.ServiceNo.Equals(""))
				{
					this.ServiceNo = " ";
				}
				if(this.RankID.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Rank.";
					return false;
				}
				if(this.UnitID.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Unit.";
					return false;
				}
				/*if(this.KinShip.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Relationship.";
					return false;
				}*/
				if(!this.KinShip.Equals("Self"))
				{
					if(this.KFName.Equals("") || !valid.IsName(this.KFName))
					{
						this.StrErrorMessage = "Please enter valid Relative's First Name (empty is not allowed).";
						return false;
					}
					if(!this.KMName.Equals(""))
					{
						if(!valid.IsName(this.KMName))
						{
							this.StrErrorMessage = "Please enter valid Relative's Middle Name.";
							return false;
						}
					}
					if(!this.KLName.Equals(""))
					{
						if(!valid.IsName(this.KLName))
						{
							this.StrErrorMessage = "Please enter valid Relative's Last Name.";
							return false;
						}
					}
				} 
				else
				{
				
				}
			}
			if(iopIndex != 1)
			{				
				if(this.WardID.Equals("-1"))
				{
					this.StrErrorMessage = "Please select Ward (empty is not allowed).";
					return false;
				}

				if (this.PAdmNo.Equals(Default))
				{
					if(!(entitledIndex == 0))
					{
						this.StrErrorMessage = "Please enter Admission No. (empty is not allowed).";
						return false;
					}
				} 
				else if(this.PAdmNo.Trim().Equals(""))
				{
					if(!(entitledIndex == 0))
					{
						this.StrErrorMessage = "Please enter Admission No. (empty is not allowed).";
						return false;
					}
				}

				if(!this.PAdmDate.Equals(Default)) 
				{
					if(!valid.IsDate(this.PAdmDate))
					{
						this.StrErrorMessage = "Please enter vaild Admission Date.";
						return false;
					}
				} 
				else
				{
					this.StrErrorMessage = "Please enter Admission Date (empty is not allowed).";
					return false;
				}
			}		

			return true;
		}

		public bool VD_Acronym()
		{
			return true;
		}

		#endregion
	}
}