using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLAttribute.
	/// </summary>
	public class clsBLTestAttribute
	{
		public clsBLTestAttribute()
		{
			//
			// TODO: Add constructor logic here
			//
		}


		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TTestAttribute";
		private string StrErrorMessage = "";
		private string StrAttributeID = Default;
		private string StrSectionID = Default;
		private string StrTestGroupID = Default;
		private string StrTestID = Default;
		private string StrActive = Default;
		private string StrAttribute = Default;
		private string StrAcronym = Default;
		private string StrInputType = Default;
		private string StrDOrder = Default;
		private string StrProcedureID = Default;
		private string StrRPrint = Default;
		private string StrSMLine = Default;
		private string StrRDISCOL = Default;
        private string StrSummary = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;
        private string StrAttribute_Interpretation = Default;
        private string StrAttributeType = Default;
        private string StrAttributeCount = Default;
        private string StrAttributeCountValue = Default;
        private string StrDerivedAttribute = Default;
        private string StrNumericAttributeIDs = Default;

        
        private string StrTextAttributeIDs = Default;
		#endregion

		#region "Properties"
		
		public string AttributeID
		{
			get{	return StrAttributeID;	}
			set{	StrAttributeID = value;	}
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
		public string Attribute
		{
			get{	return StrAttribute;	}
			set{	StrAttribute = value;	}
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
		
		public string InputType
		{
			get{	return StrInputType;	}
			set{	StrInputType = value;	}
		}
		public string DOrder
		{
			get{	return StrDOrder;	}
			set{	StrDOrder = value;	}
		}

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}

		public string RPrint
		{
			get{	return StrRPrint;	}
			set{	StrRPrint = value;	}
		}

		public string SMLine
		{
			get{	return StrSMLine;	}
			set{	StrSMLine = value;	}
		}
		
		public string RDISCOL
		{
			get{	return StrRDISCOL;	}
			set{	StrRDISCOL = value;	}
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

        public string Attribute_Interpretation
        {
            get { return StrAttribute_Interpretation; }
            set { StrAttribute_Interpretation = value; }
        }

        public string AttributeType
        {
            get { return StrAttributeType; }
            set { StrAttributeType = value; }
        }

        public string AttributeCount
        {
            get { return StrAttributeCount; }
            set { StrAttributeCount = value; }
        }

        public string AttributeCountValue
        {
            get { return StrAttributeCountValue; }
            set { StrAttributeCountValue = value; }
        }

        public string DerivedAttribute
        {
            get { return StrDerivedAttribute; }
            set { StrDerivedAttribute = value; }
        }
        public string TextAttributeIDs
        {
            get { return StrTextAttributeIDs; }
            set { StrTextAttributeIDs = value; }
        }
        public string NumericAttributeIDs
        {
            get { return StrNumericAttributeIDs; }
            set { StrNumericAttributeIDs = value; }
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

					objdbhims.Query = objQB.QBGetMax("AttributeID", TableName, "6");
					this.StrAttributeID = objTrans.DataTrigger_Get_Max(objdbhims);

					objdbhims.Query = objQB.QBGetMax("DOrder", TableName, "6");
					this.StrDOrder = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrAttributeID.Equals("True"))
					{
						clsBLTest objTest = new clsBLTest();
						objTest.TestID = this.StrTestID;
						DataView dvTest = objTest.GetAll(5);
						this.StrProcedureID = dvTest.Table.Rows[0]["ProcedureID"].ToString();

						objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
						this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

						//objTrans.End_Transaction();

						if(this.StrErrorMessage.Equals("True"))
						{
							this.StrErrorMessage = objTrans.OperationError;
                            objTrans.End_Transaction();
							return false;
						}
						else
						{
                            if (!StrAttributeCountValue.Equals(Default) && !StrAttributeCountValue.Equals("") && StrAttributeCount == "Y")
                            {
                                objdbhims.Query = "Update LS_TTest Set Attribute_Count=To_Number('" + StrAttributeCountValue + "') Where TestID='" + StrTestID + "'";
                                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                                //objTrans.End_Transaction();
                                if (this.StrErrorMessage.Equals("True"))
                                {
                                    this.StrErrorMessage = objTrans.OperationError;
                                    objTrans.End_Transaction();

                                    return false;
                                }
                                else
                                {
                                    objTrans.End_Transaction();

                                    return true;
                                }
                            }
                            objTrans.End_Transaction();
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
				//objTrans.End_Transaction();

				if(this.StrErrorMessage.Equals("True"))
				{
					this.StrErrorMessage = objTrans.OperationError;
					return false;
				}
				else
				{
                    if (!StrAttributeCountValue.Equals(Default) && !StrAttributeCountValue.Equals("") && StrAttributeCount == "Y")
                    {
                        objdbhims.Query = "Update LS_TTest Set Attribute_Count=To_Number('" + StrAttributeCountValue + "') Where TestID='" + StrTestID + "'";
                        this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                        objTrans.End_Transaction();
                        if (this.StrErrorMessage.Equals("True"))
                        {
                            this.StrErrorMessage = objTrans.OperationError;
                            //objTrans.End_Transaction();

                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        objTrans.End_Transaction();
                        return true;
                    }
					//return true;
				}
			}
			else
			{
				return false;
			}
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
				this.StrAttributeID = arrayUpdate[counter, 0];
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

        public bool updateattribType()
        {
            objdbhims.Query = @"Update " + TableName + @" set AttributeType=(
                                  case when AttributeID in("+StrNumericAttributeIDs+@") then 'N' when AttributeID in("+StrTextAttributeIDs+@") then 'T' end)
                                    where TestID='"+StrTestID+"'";
            objTrans.Start_Transaction();
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


		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:				
					objdbhims.Query = "Select * from " + TableName + " Where Active <> 'D' And SectionID = '" + StrSectionID + "' And TestGroupID = '" + StrTestGroupID + "' And TestID = '" + StrTestID + "' Order By DOrder";
					break;

				case 2:
					objdbhims.Query = "Select * from " + TableName + " Where Active <> 'D' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(TestID) = '" + StrTestID.ToUpper() + "' And Upper(ACtive) = '" + this.StrActive.ToUpper() + "' Order By DOrder";
					break;

				case 3:
					objdbhims.Query = "Select * from " + TableName + " Where Active <> 'D' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(TestID) = '" + StrTestID.ToUpper() + "' And Upper(Attribute) like '%'||'" + this.StrAttribute.ToUpper() + "'||'%'";
					break;

				case 4:
					objdbhims.Query = "Select * from " + TableName + " Where Active <> 'D' And Upper(SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(TestID) = '" + StrTestID.ToUpper() + "' And Upper(Acronym) = '" + this.StrAcronym.ToUpper() + "'";
					break;

				case 5:
					objdbhims.Query = "select Svalue from ls_tattributeselection Where AttributeID = '"+StrAttributeID+"'";
					break;
                case 6:
                    objdbhims.Query = @"Select distinct tar.AttributeID,tar.maxValue,tar.minValue,tta.attributetype
                                        From ls_tattributerange tar
                                        Inner Join ls_ttestattribute tta
                                        On tta.attributeid=tar.AttributeID
                                        where tta.AttributeID='"+StrAttributeID+"'";
                    break;
                case 7:
                    objdbhims.Query = @"Select Max(AttributeID) AttributeID From LS_TTestAttribute where Active='Y'";
                    break;
                case 8:
                    objdbhims.Query = "Select AttributeID,Attribute From LS_TTestAttribute where TestID='" + StrTestID + "' and Active<>'D'";
                    break;
			}
         

			return objTrans.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryAttribute = new string[20,3];

			if(!this.StrAttributeID.Equals(Default))
			{
				aryAttribute[0,0] = "AttributeID";
				aryAttribute[0,1] = this.StrAttributeID;
				aryAttribute[0,2] = "string";
			}
			if(!this.StrSectionID.Equals(Default))
			{
				aryAttribute[1,0] = "SectionID";
				aryAttribute[1,1] = this.StrSectionID;
				aryAttribute[1,2] = "string";
			}
			if(!this.StrTestGroupID.Equals(Default))
			{
				aryAttribute[2,0] = "TestGroupID";
				aryAttribute[2,1] = this.StrTestGroupID;
				aryAttribute[2,2] = "string";
			}
			if(!this.StrTestID.Equals(Default))
			{
				aryAttribute[3,0] = "TestID";
				aryAttribute[3,1] = this.StrTestID;
				aryAttribute[3,2] = "string";
			}
			if(!this.StrAttribute.Equals(Default))
			{
				aryAttribute[4,0] = "Attribute";
				aryAttribute[4,1] = this.StrAttribute;
				aryAttribute[4,2] = "string";
			}
			if(!this.StrActive.Equals(Default))
			{
				aryAttribute[5,0] = "Active";
				aryAttribute[5,1] = this.StrActive;
				aryAttribute[5,2] = "string";
			}
			if(!this.StrAcronym.Equals(Default))
			{
				aryAttribute[6,0] = "Acronym";
				aryAttribute[6,1] = this.StrAcronym;
				aryAttribute[6,2] = "string";
			}
			if(!this.StrInputType.Equals(Default))
			{
				aryAttribute[7,0] = "InputType";
				aryAttribute[7,1] = this.StrInputType;
				aryAttribute[7,2] = "string";
			}
			if(!this.StrDOrder.Equals(Default))
			{
				aryAttribute[8,0] = "DOrder";
				aryAttribute[8,1] = this.StrDOrder;
				aryAttribute[8,2] = "int";
			}
			if(!this.StrProcedureID.Equals(Default))
			{
				aryAttribute[9,0] = "ProcedureID";
				aryAttribute[9,1] = this.StrProcedureID;
				aryAttribute[9,2] = "string";
			}
			if(!this.StrRPrint.Equals(Default))
			{
				aryAttribute[10,0] = "RPrint";
				aryAttribute[10,1] = this.StrRPrint;
				aryAttribute[10,2] = "string";
			}
			if(!this.StrSMLine.Equals(Default))
			{
				aryAttribute[11,0] = "SMLine";
				aryAttribute[11,1] = this.StrSMLine;
				aryAttribute[11,2] = "string";
			}
			if(!this.StrRDISCOL.Equals(Default))
			{
				aryAttribute[12,0] = "RDISCOL";
				aryAttribute[12,1] = this.StrRDISCOL;
				aryAttribute[12,2] = "string";
			}
            if (!this.StrSummary.Equals(Default))
            {
                aryAttribute[13, 0] = "summary";
                aryAttribute[13, 1] = this.StrSummary;
                aryAttribute[13, 2] = "string";
            }
            if (!this.StrEnteredon.Equals(Default))
            {
                aryAttribute[14, 0] = "enteredon";
                aryAttribute[14, 1] = this.StrEnteredon;
                aryAttribute[14, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryAttribute[15, 0] = "enteredby";
                aryAttribute[15, 1] = this.StrEnteredby;
                aryAttribute[15, 2] = "string";
            }

            if (!this.StrAttribute_Interpretation.Equals(Default))
            {
                aryAttribute[16, 0] = "Attribute_Interpretation";
                aryAttribute[16, 1] = this.StrAttribute_Interpretation;
                aryAttribute[16, 2] = "string";
            }

            if (!this.StrAttributeType.Equals(Default))
            {
                aryAttribute[17, 0] = "AttributeType";
                aryAttribute[17, 1] = this.StrAttributeType;
                aryAttribute[17, 2] = "string";
            }

            if (!this.StrAttributeCount.Equals(Default))
            {
                aryAttribute[18, 0] = "Count";
                aryAttribute[18, 1] = this.StrAttributeCount;
                aryAttribute[18, 2] = "string";
            }

            if (!this.StrDerivedAttribute.Equals(Default))
            {
                aryAttribute[19, 0] = "Derived";
                aryAttribute[19, 1] = this.StrDerivedAttribute;
                aryAttribute[19, 2] = "string";
            }
			return aryAttribute;
		}

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_TestAttribute())
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

		public bool VD_TestAttribute()
		{
			Validation objValid = new Validation();

			if(StrAttribute.Equals(""))
			{
				this.StrErrorMessage = "Please enter Test Attribute. (empty is not allowed)";
				return false;
			}

			DataView dvTestAttribute = GetAll(3);

			if(!StrAttributeID.Equals(Default))
			{
				dvTestAttribute.RowFilter = "AttributeID <> '" + StrAttributeID + "' And Attribute = '" + StrAttribute + "'";
			}
			else
			{
				dvTestAttribute.RowFilter = "Attribute = '" + StrAttribute + "'";
			}

			if(dvTestAttribute.Count > 0)
			{
				this.StrErrorMessage = "Please enter another Test Attribute Name, it is already present.";
				return false;
			}

			return true;
		}

		public bool VD_Acronym()
		{
			if(!StrAcronym.Equals(""))
			{
				Validation objValid = new Validation();

/*				if(StrAcronym.Equals(""))
				{
					this.StrErrorMessage = "Please enter Acronym. (empty is not allowed)";
					return false;
				}
*/			
				if(!objValid.IsAlpha(StrAcronym))
				{
					this.StrErrorMessage = "Please enter valid Acronym (space is not allowed)";
					return false;
				}

				DataView dvAcronym = GetAll(4);

				if(!StrAttributeID.Equals(Default))
				{
					dvAcronym.RowFilter = "AttributeID <> " + StrAttributeID;
				}

				if(dvAcronym.Count > 0)
				{
					this.StrErrorMessage = "Please enter another Acronym, it is already present.";
					return false;
				}
			}

			return true;
		}

		#endregion
	}
}