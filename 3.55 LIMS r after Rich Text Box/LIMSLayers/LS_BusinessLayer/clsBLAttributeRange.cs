using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
	/// <summary>
	/// Summary description for clsBLAttributeRange.
	/// </summary>
	public class clsBLAttributeRange
	{
		public clsBLAttributeRange()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
		private const string TableName = "LS_TAttributeRange";
		private string StrErrorMessage = "";
		private string StrTransID = Default;
		private string StrMethodID = Default;
		private string StrProcedureID = Default;
		private string StrAttributeID = Default;
		private string StrTestID = Default;
		private string StrTestGroupID = Default;
		private string StrSectionID = Default;
		private string StrSex = Default;
		private string StrAgeMin = Default;
		private string StrAgeMax = Default;
		private string StrMinValue = Default;
		private string StrMaxValue = Default;
		private string StrAUnit = Default;
		private string StrAgeType = Default;
        private string StrMinPValue = Default;
        private string StrMaxPValue = Default;
        private string StrEnteredon = Default;
        private string StrEnteredby = Default;
        private string StrInterpretation = Default;
        private string StrInterpretation2 = Default;
        private string StrInterpretation3 = Default;
        private string StrInterpretation4 = Default;
    
		#endregion

		#region "Properties"
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
		public string TransID
		{
			get{	return StrTransID;	}
			set{	StrTransID = value;	}
		}

		public string MethodID
		{
			get{	return StrMethodID;		}
			set{	StrMethodID = value;	}
		}

		public string ProcedureID
		{
			get{	return StrProcedureID;	}
			set{	StrProcedureID = value;	}
		}

		public string AttributeID
		{
			get{	return StrAttributeID;	}
			set{	StrAttributeID = value;	}
		}

		public string TestID
		{
			get{	return StrTestID;	}
			set{	StrTestID = value;	}
		}

		public string TestGroupID
		{
			get{	return StrTestGroupID;	}
			set{	StrTestGroupID = value;	}
		}
		
		public string SectionID
		{
			get{	return StrSectionID;	}
			set{	StrSectionID = value;	}
		}		
		
		public string Sex
		{
			get{	return StrSex;	}
			set{	StrSex = value;	}
		}
		
		public string AgeMin
		{
			get{	return StrAgeMin;	}
			set{	StrAgeMin = value;	}
		}

		public string AgeMax
		{
			get{	return StrAgeMax;	}
			set{	StrAgeMax = value;	}
		}

		public string MinValue
		{
			get{	return StrMinValue;		}
			set{	StrMinValue = value;	}
		}

		public string MaxValue
		{
			get{	return StrMaxValue;		}
			set{	StrMaxValue = value;	}
		}

		public string AUnit
		{
			get{	return StrAUnit;	}
			set{	StrAUnit = value;	}
		}

		public string AgeType
		{
			get{	return StrAgeType;	}
			set{	StrAgeType = value;	}
		}
        public string MinPValue
        {
            get { return StrMinPValue; }
            set { StrMinPValue = value; }
        }
        public string MaxPValue
        {
            get { return StrMaxPValue; }
            set { StrMaxPValue = value; }
        }

		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
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
        public string Interpretation
        {
            get { return StrInterpretation; }
            set { StrInterpretation = value; }
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

					objdbhims.Query = objQB.QBGetMax("TransID", TableName, "10");
					this.StrTransID = objTrans.DataTrigger_Get_Max(objdbhims);

					if(!this.StrTransID.Equals("True"))
					{
						clsBLTest objTest = new clsBLTest();
						objTest.TestID = this.StrTestID;
						DataView dvTest = objTest.GetAll(5);
						this.StrProcedureID = dvTest.Table.Rows[0]["ProcedureID"].ToString();

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
					objTrans.End_Transaction();
					return false;
				}
			}
			else
			{
				return false;
			}
		}
        public bool Insertcopy()
        {
        
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("TransID", TableName, "10");
                    this.StrTransID = objTrans.DataTrigger_Get_Max(objdbhims);

                    if (!this.StrTransID.Equals("True"))
                    {
                        clsBLTest objTest = new clsBLTest();
                        objTest.TestID = this.StrTestID;
                        DataView dvTest = objTest.GetAll(5);
                        this.StrProcedureID = dvTest.Table.Rows[0]["ProcedureID"].ToString();

                        objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

                        objTrans.End_Transaction();

                        if (this.StrErrorMessage.Equals("True"))
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
                catch (Exception e)
                {
                    this.StrErrorMessage = e.Message;
                    objTrans.End_Transaction();
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

		/// <summary>
		/// Not Implemented Yet
		/// </summary>
		/// <param name="arrayUpdate"></param>
		/// <returns></returns>
		public bool UpdateAll(string[,] arrayUpdate)
		{/*
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
*/
			return false;
		}


		public bool Delete()
		{
			clsoperation objTrans = new clsoperation();
			QueryBuilder objQB = new QueryBuilder();

			objTrans.Start_Transaction();
			objdbhims.Query = "Delete LS_TAttributeRange Where TransID = '" + StrTransID + "'";

			if(objTrans.DataTrigger_Delete(objdbhims).Equals("True"))
			{
				objTrans.End_Transaction();
				StrErrorMessage = objTrans.OperationError;
				return false;
			}

			objTrans.End_Transaction();
			return true;
		}

		public DataView GetAll(int flag)
		{
			clsoperation objTrans2 = new clsoperation();

			switch(flag)
			{
				case 1:
                    objdbhims.Query = "Select NVL(ar.TransID, '') As TransID, NVL(m.Method, '') As Method, NVL(ar.Sex, '') As Sex, NVL(ar.AUnit, '') As Unit, ar.AgeMinX As AgeMin, ar.AgeMaxX As AgeMax, ar.MinValue||' - '||ar.MaxValue As ValueRange, ar.MinValue, ar.MaxValue, ar.MinPValue, ar.MaxPValue,ar.Interpretation,ar.Interpretation2,ar.Interpretation3,ar.Interpretation4 from LS_VAttributeRange ar, LS_TMethod m Where ar.MethodID = m.MethodID And ar.SectionID = m.SectionID And Upper(ar.SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(ar.TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(ar.TestID) = '" + StrTestID.ToUpper() + "' And Upper(ar.AttributeID) = '" + StrAttributeID.ToUpper() + "'";

					break;

				case 2:
					if(StrAgeType.Equals("Y"))
					{
						StrAgeMin = Convert.ToString(int.Parse(StrAgeMin) * 365);
						StrAgeMax = Convert.ToString(int.Parse(StrAgeMax) * 365);
					}
					else if(StrAgeType.Equals("M"))
					{
						StrAgeMin = Convert.ToString(int.Parse(StrAgeMin) * 30);
						StrAgeMax = Convert.ToString(int.Parse(StrAgeMax) * 30);
					}
					else if(StrAgeType.Equals("W"))
					{
						StrAgeMin = Convert.ToString(int.Parse(StrAgeMin) * 7);
						StrAgeMax = Convert.ToString(int.Parse(StrAgeMax) * 7);
					}
					else if(StrAgeType.Equals("D"))
					{
						StrAgeMin = Convert.ToString(int.Parse(StrAgeMin));
						StrAgeMax = Convert.ToString(int.Parse(StrAgeMax));
					}

					if(!StrSex.Equals("All"))
					{
						objdbhims.Query = "Select * from LS_TAttributeRange ar, LS_TMethod m Where ar.MethodID = m.MethodID And ar.SectionID = m.SectionID And Upper(ar.SectionID) = '" + StrSectionID.ToUpper() +"'And ar.MethodID='"+StrMethodID+ "' And Upper(ar.TestGroupID) = '" + StrTestGroupID.ToUpper() + "' And Upper(ar.TestID) = '" + StrTestID.ToUpper() + "' And Upper(ar.AttributeID) = '" + StrAttributeID.ToUpper() + "' And ((" + StrAgeMin + " Between ar.AgeMin and ar.AgeMax) or (" + StrAgeMax + " Between ar.AgeMin and ar.AgeMax) or (ar.AgeMin Between " + StrAgeMin + " and " + StrAgeMax + ")) and (ar.Sex = '" + StrSex + "' or ar.Sex = 'All')";
					}
					else
					{
						objdbhims.Query = "Select * from LS_TAttributeRange ar, LS_TMethod m Where ar.MethodID = m.MethodID And ar.SectionID = m.SectionID And Upper(ar.SectionID) = '" + StrSectionID.ToUpper() + "' And Upper(ar.TestGroupID) = '" + StrTestGroupID.ToUpper() +"' And ar.MethodID='" +StrMethodID + "' And Upper(ar.TestID) = '" + StrTestID.ToUpper() + "' And Upper(ar.AttributeID) = '" + StrAttributeID.ToUpper() + "' And ((" + StrAgeMin + " Between ar.AgeMin and ar.AgeMax) or (" + StrAgeMax + " Between ar.AgeMin and ar.AgeMax) or (ar.AgeMin Between " + StrAgeMin + " and " + StrAgeMax + "))";
					}


					break;
                case 3:
                    objdbhims.Query = @"Select * from " + TableName + " where TestID='" + StrTestID + "' and MethodID='" + StrMethodID + "'";
                    break;
			}

			return objTrans2.DataTrigger_Get_All(objdbhims);
		}
		
		private string[,] MakeArray()
		{
			string[,] aryAttRange = new string[22,3];

			if(!this.StrTransID.Equals(Default))
			{
				aryAttRange[0,0] = "TransID";
				aryAttRange[0,1] = this.StrTransID;
				aryAttRange[0,2] = "int";
			}
			if(!this.StrMethodID.Equals(Default))
			{
				aryAttRange[1,0] = "MethodID";
				aryAttRange[1,1] = this.StrMethodID;
				aryAttRange[1,2] = "string";
			}
			if(!this.StrSex.Equals(Default))
			{
				aryAttRange[2,0] = "Sex";
				aryAttRange[2,1] = this.StrSex;
				aryAttRange[2,2] = "string";
			}
			if(!this.StrAgeMin.Equals(Default))
			{
				aryAttRange[3,0] = "AgeMin";
				aryAttRange[3,1] = this.StrAgeMin;
				aryAttRange[3,2] = "int";
			}
			if(!this.StrAgeMax.Equals(Default))
			{
				aryAttRange[4,0] = "AgeMax";
				aryAttRange[4,1] = this.StrAgeMax;
				aryAttRange[4,2] = "int";
			}
			if(!this.StrMinValue.Equals(Default))
			{
				aryAttRange[5,0] = "MinValue";
				aryAttRange[5,1] = this.StrMinValue;
				aryAttRange[5,2] = "string";
			}
			if(!this.StrMaxValue.Equals(Default))
			{
				aryAttRange[6,0] = "MaxValue";
				aryAttRange[6,1] = this.StrMaxValue;
				aryAttRange[6,2] = "string";
			}
			if(!this.StrAUnit.Equals(Default))
			{
				aryAttRange[7,0] = "AUnit";
				aryAttRange[7,1] = this.StrAUnit;
				aryAttRange[7,2] = "string";
			}
			if(!this.StrAgeType.Equals(Default))
			{
				aryAttRange[8,0] = "AgeType";
				aryAttRange[8,1] = this.StrAgeType;
				aryAttRange[8,2] = "string";
			}
			if(!this.StrSectionID.Equals(Default))
			{
				aryAttRange[9,0] = "SectionID";
				aryAttRange[9,1] = this.StrSectionID;
				aryAttRange[9,2] = "string";
			}
			if(!this.StrTestGroupID.Equals(Default))
			{
				aryAttRange[10,0] = "TestGroupID";
				aryAttRange[10,1] = this.StrTestGroupID;
				aryAttRange[10,2] = "string";
			}
			if(!this.StrTestID.Equals(Default))
			{
				aryAttRange[11,0] = "TestID";
				aryAttRange[11,1] = this.StrTestID;
				aryAttRange[11,2] = "string";
			}
			if(!this.StrAttributeID.Equals(Default))
			{
				aryAttRange[12,0] = "AttributeID";
				aryAttRange[12,1] = this.StrAttributeID;
				aryAttRange[12,2] = "string";
			}
			if(!this.StrProcedureID.Equals(Default))
			{
				aryAttRange[13,0] = "ProcedureID";
				aryAttRange[13,1] = this.StrProcedureID;
				aryAttRange[13,2] = "string";
			}
            if (!this.StrMinPValue.Equals(Default))
            {
                aryAttRange[14, 0] = "MinPValue";
                aryAttRange[14, 1] = this.StrMinPValue;
                aryAttRange[14, 2] = "string";
            }
            if (!this.StrMaxPValue.Equals(Default))
            {
                aryAttRange[15, 0] = "MaxPValue";
                aryAttRange[15, 1] = this.StrMaxPValue;
                aryAttRange[15, 2] = "string";
            }
            if (!this.StrEnteredon.Equals(Default))
            {
                aryAttRange[16, 0] = "enteredon";
                aryAttRange[16, 1] = this.StrEnteredon;
                aryAttRange[16, 2] = "date";
            }
            if (!this.StrEnteredby.Equals(Default))
            {
                aryAttRange[17, 0] = "enteredby";
                aryAttRange[17, 1] = this.StrEnteredby;
                aryAttRange[17, 2] = "string";
            }
            if (!this.StrInterpretation.Equals(Default))
            {
                aryAttRange[18, 0] = "Interpretation";
                aryAttRange[18, 1] = this.StrInterpretation;
                aryAttRange[18, 2] = "string";
            }
            if (!this.StrInterpretation2.Equals(Default))
            {
                aryAttRange[19, 0] = "INTERPRETATION2";
                aryAttRange[19, 1] = StrInterpretation2;
                aryAttRange[19, 2] = "string";
            }
            if (!this.StrInterpretation3.Equals(Default))
            {
                aryAttRange[20, 0] = "Interpretation3";
                aryAttRange[20, 1] = StrInterpretation3;
                aryAttRange[20, 2] = "string";
            }
            if (!this.StrInterpretation4.Equals(Default))
            {
                aryAttRange[21, 0] = "Interpretation4";
                aryAttRange[21, 1] = StrInterpretation4;
                aryAttRange[21, 2] = "string";
            }
			
			return aryAttRange;
		}

		#endregion

		#region "Validation Functions"

		private bool Validation()
		{
			if(!VD_Method())
			{
				return false;
			}

			if(!VD_MinimumAge())
			{
				return false;
			}

			if(!VD_MaximumAge())
			{
				return false;
			}

			if(!VD_MinMaxAgeDiff())
			{
				return false;
			}

			if(!VD_AgeRangeConfliction())
			{
				return false;
			}

			if(!VD_MinimumValue())
			{
				return false;
			}

			if(!VD_MaximumValue())
			{
				return false;
			}

			if(!VD_MinMaxValueDiff())
			{
				return false;
			}

			return true;
		}

		private bool VD_AgeRangeConfliction()
		{
			DataView dvAgeRC = GetAll(2);

			if(!StrTransID.Equals(Default))
			{
				dvAgeRC.RowFilter = "TransID <> " + StrTransID;
			}

			if(dvAgeRC.Count > 0)
			{
				StrErrorMessage = "Age Range is already defined with the selected Method. Please check other ranges and change age range or Test Method.";
				return false;
			}

			return true;
		}

		private bool VD_Method()
		{
			if(StrMethodID.Equals("-1"))
			{
				this.StrErrorMessage = "Please select Method.";
				return false;
			}

			return true;
		}

		private bool VD_MinimumAge()
		{
			Validation objValid = new Validation();

			if(StrAgeMin.Equals(""))
			{
				this.StrErrorMessage = "Please enter Minimum Age for the attribute range. (empty is not allowed)";
				return false;
			}

			if(!objValid.IsWholeNumber(StrAgeMin))
			{
				this.StrErrorMessage = "Please enter valid Minimum Age. (-ve & decimal is not allowed)";
				return false;
			}

			if(StrAgeType.Equals("Y"))
			{
				if((int.Parse(StrAgeMin) > 200))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 200 years)";
					return false;
				}
			}
			else if(StrAgeType.Equals("M"))
			{
				if((int.Parse(StrAgeMin) > 2433))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 2433 months)";
					return false;
				}
			}
			else if(StrAgeType.Equals("W"))
			{
				if((int.Parse(StrAgeMin) > 10428))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 10428 weeks)";
					return false;
				}
			}
			else if(StrAgeType.Equals("D"))
			{
				if((int.Parse(StrAgeMin) > 73000))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 73000 days)";
					return false;
				}
			}

			return true;
		}

		private bool VD_MaximumAge()
		{
			Validation objValid = new Validation();

			if(StrAgeMax.Equals(""))
			{
				this.StrErrorMessage = "Please enter Maximum Age for the attribute range. (empty is not allowed)";
				return false;
			}

			if(!objValid.IsWholeNumber(StrAgeMax))
			{
				this.StrErrorMessage = "Please enter valid Maximum Age. (-ve & decimal is not allowed)";
				return false;
			}

			if(StrAgeType.Equals("Y"))
			{
				if((int.Parse(StrAgeMin) > 200))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 200 years)";
					return false;
				}
			}
			else if(StrAgeType.Equals("M"))
			{
				if((int.Parse(StrAgeMin) > 2433))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 2433 months)";
					return false;
				}
			}
			else if(StrAgeType.Equals("W"))
			{
				if((int.Parse(StrAgeMin) > 10428))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 10428 weeks)";
					return false;
				}
			}
			else if(StrAgeType.Equals("D"))
			{
				if((int.Parse(StrAgeMin) > 73000))
				{
					this.StrErrorMessage = "Minimum Age is too large. (not more than 73000 days)";
					return false;
				}
			}

			return true;
		}

		private bool VD_MinMaxAgeDiff()
		{
			if((int.Parse(StrAgeMin) > int.Parse(StrAgeMax)))
			{
				this.StrErrorMessage = "Minimum Age is greater than Maximum Age.";
				return false;
			}

			return true;
		}

		private bool VD_MinimumValue()
		{
			Validation objValid = new Validation();

			/*if(StrMinValue.Equals(""))
			{
				this.StrErrorMessage = "Please enter Minimum Value for the Test Attribute result. (empty is not allowed)";
				return false;
			}*/

			/*if(!objValid.IsNumber(StrMinValue))
			{
				this.StrErrorMessage = "Please enter valid Minimum value. (only real numbers allowed)";
				return false;
			}*/

			return true;
		}

		private bool VD_MaximumValue()
		{
			Validation objValid = new Validation();

			/*if(StrMaxValue.Equals(""))
			{
				this.StrErrorMessage = "Please enter Maximum Value for the Test Attribute result. (empty is not allowed)";
				return false;
			}

			if(!objValid.IsNumber(StrMaxValue))
			{
				this.StrErrorMessage = "Please enter valid Maximum Value. (only real numbers allowed)";
				return false;
			}*/

			return true;
		}

		private bool VD_MinMaxValueDiff()
		{
			try
			{
				if((double.Parse(StrMinValue) > double.Parse(StrMaxValue)))
				{
					this.StrErrorMessage = "Minimum Value is greater than Maximum Value for the result.";
					return false;
				}
			}
			catch{}
			return true;
		}

		#endregion
	}
}