using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlAttributeTemplates
    {
        public clsBlAttributeTemplates()
        { 
        /// Add Constructor Logic here...
        }

        #region Variables
        private const string TableName = "LS_TAttributeTemplates";
        private const string Default = "~!@";
        private string StrTemplateID = Default;

        
        private string StrAttributeID = Default;
        private string StrDescription = Default;
        private string StrActive = Default;
        private string StrT_Default = Default;
        //private string StrTemplateID = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrErrorMessage = Default;
        #endregion
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Properties
        public string TemplateID
        {
            get { return StrTemplateID; }
            set { StrTemplateID = value; }
        }
        public string AttributeID
        {
            get { return StrAttributeID; }
            set { StrAttributeID = value; }
        }
        public string Description
        {
            get { return StrDescription; }
            set { StrDescription = value; }
        }
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
        }
        public string T_Default
        {
            get { return StrT_Default; }
            set { StrT_Default = value; }
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
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }

        
        
        #endregion

        #region Methods

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From " + TableName + " tt, LS_TTestAttribute ta  where ta.AttributeID=tt.AttributeID and tt.AttributeID='" + StrAttributeID + "'";
                    break;

                case 2:
                    objdbhims.Query = "Select * from LS_TAttributeTemplates where AttributeID='" + StrAttributeID + "' and T_Default='Y'";
                    break;

                case 3:
                    objdbhims.Query = "Select TemplateID,AttributeID,Description,T_Default From LS_TAttributeTemplates where Active='Y' and AttributeID='" +StrAttributeID+"'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool update()
        {
            if (Validation())
            {
                
                QueryBuilder objQB = new QueryBuilder();

                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
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
                return false;
            }
        }
        public bool insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    objdbhims.Query = objQB.QBGetMax("TemplateID", TableName, "6");
                    this.StrTemplateID = objTrans.DataTrigger_Get_Max(objdbhims);



                    if (!this.StrTemplateID.Equals("True"))
                    {
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
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private string[,] MakeArray()
        {
            string[,] aryLIMS = new string[8, 3];

            if (!this.StrTemplateID.Equals(Default))
            {
                aryLIMS[0, 0] = "TemplateID";
                aryLIMS[0, 1] = this.StrTemplateID;
                aryLIMS[0, 2] = "string";
            }

            if (!this.StrAttributeID.Equals(Default))
            {
                aryLIMS[1, 0] = "AttributeID";
                aryLIMS[1, 1] = this.StrAttributeID;
                aryLIMS[1, 2] = "string";
            }

            if (!this.StrActive.Equals(Default))
            {
                aryLIMS[2, 0] = "Active";
                aryLIMS[2, 1] = this.StrActive;
                aryLIMS[2, 2] = "string";
            }

            if (!this.StrDescription.Equals(Default))
            {
                aryLIMS[3, 0] = "Description";
                aryLIMS[3, 1] = this.StrDescription;
                aryLIMS[3, 2] = "string";
            }

            if (!this.StrT_Default.Equals(Default))
            {
                aryLIMS[4, 0] = "T_Default";
                aryLIMS[4, 1] = this.StrT_Default;
                aryLIMS[4, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryLIMS[5, 0] = "enteredon";
                aryLIMS[5, 1] = this.StrEnteredOn;
                aryLIMS[5, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryLIMS[6, 0] = "enteredby";
                aryLIMS[6, 1] = this.StrEnteredBy;
                aryLIMS[6, 2] = "string";
            }
            if (!this.StrClientID.Equals(Default))
            {
                aryLIMS[7, 0] = "ClientID";
                aryLIMS[7, 1] = this.StrClientID;
                aryLIMS[7, 2] = "string";
            }
            

            return aryLIMS;
        }

        private bool Validation()
        {
            if (!VD_Description())
            {
                return false;
            }

            if (!VD_AttributeID())
            {
                return false;
            }
            if (!VD_Defaultcheck())
            {
                return false;
            }
            return true;
        }

        public bool VD_Description()
        {
            if (StrDescription.Equals("") || StrDescription.Equals(Default))
            {
                this.StrErrorMessage = "Please enter Description (Empty is not allowed)";
                return false;
            }
            return true;
        }
        public bool VD_AttributeID()
        {
            if (StrAttributeID.Equals("") || StrAttributeID.Equals(Default) || StrAttributeID.Equals("-1"))
            {
                this.StrErrorMessage = "Please Select Attribute. Select is not a valid Attribute";
                return false;
            }
            return true;
        }

        public bool VD_Defaultcheck()
        {
            if (StrT_Default == "Y")
            {
                DataView dv_defaultcheck = GetAll(2);
                if (dv_defaultcheck.Count > 0)
                {
                    this.StrErrorMessage = "Only one Default value could be set for one Attribute at one Time";
                    return false;

                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        #endregion
    }
}
