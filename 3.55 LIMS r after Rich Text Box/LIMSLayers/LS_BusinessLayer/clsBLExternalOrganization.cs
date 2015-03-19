//using System;
//using System.Collections.Generic;
//using System.Text;

using System;
using System.Data;  
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLExternalOrganization
    {
        public clsBLExternalOrganization()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region "Class Variables"
		
		private const string Default = "~!@";
        private const string TableName = "LS_TEXTORGANIZATION";
        private string StrOrganizationId = Default;

        public string OrganizationId
        {
            get { return StrOrganizationId; }
            set { StrOrganizationId = value; }
        }
		private string StrErrorMessage = "";
		private string StrActive = Default;
        private string StrAcronym = Default;
        private string StrName = Default;
        private string StrPhoneNo = Default;
        private string StrFaxNo = Default;
        private string StrEmail = Default;
        private string StrWebAddress = Default;
        private string StrPostalAddress = Default;
        private string StrEnteredOn = Default;
        private string StrEnteredBy = Default;


        private string StrClientId = Default;


        private string StrExternal = Default;



		#endregion

		#region "Properties"
		
		public string ErrorMessage
		{			
			get{	return StrErrorMessage;	}
		}

		public string Active
		{
			get{	return StrActive;	}
			set{	StrActive = value;	}
		}
        
        public string Acronym
        {
          get { return StrAcronym; }
          set { StrAcronym = value; }
        }
        
        public string Name
        {
          get { return StrName; }
          set { StrName = value; }
        }

        public string PhoneNo
        {
          get { return StrPhoneNo; }
          set { StrPhoneNo = value; }
        }
        
        public string FaxNo
        {
          get { return StrFaxNo; }
          set { StrFaxNo = value; }
        }
        
        public string Email
        {
          get { return StrEmail; }
          set { StrEmail = value; }
        }

        public string WebAddress
        {
          get { return StrWebAddress; }
          set { StrWebAddress = value; }
        }

        public string PostalAddress
        {
          get { return StrPostalAddress; }
          set { StrPostalAddress = value; }
        }

        public string EnteredOn
        {
          get { return StrEnteredOn; }
          set { StrEnteredOn = value; }
        }

        public string EnteredBy
        {
          get { return StrEnteredBy; }
          set { StrEnteredBy = value; }
        }

        public string ClientId
        {
          get { return StrClientId; }
          set { StrClientId = value; }
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

		public DataView GetAll(int flag)
		{
			switch(flag)
			{
				case 1:
                    objdbhims.Query = @"select org.ORGID,org.Name,org.acronym,org.phoneno,org.faxno,org.web_address,org.address,org.email,
                                        org.active,per.fname,org.enteredon,org.clientid,org.External,to_char(enteredon,'dd-Mon-yyyy') as displaydate
                                        from 
                                        whims.ls_textorganization org 
                                        inner join
                                        whims2.hr_vpersonnel per on per.personid = org.enteredby";
					break;
                case 2:
                    objdbhims.Query = @"Select ORGID from ls_textorganization where upper(NAME) = '" + StrName.ToUpper() + "'";
                    break;
                case 3:
                    objdbhims.Query = "Select orgid,name from ls_textorganization where Active='Y' and External='Y'";
                    break;
			}

			return objTrans.DataTrigger_Get_All(objdbhims);
		}

        public bool insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();
                    objTrans.Start_Transaction();
                    objdbhims.Query = objQB.QBGetMax("ORGID", TableName);
                    this.StrOrganizationId = objTrans.DataTrigger_Get_Max(objdbhims);
                    if (this.StrOrganizationId.Equals("True"))
                    {

                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                    this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);



                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    objTrans.End_Transaction();
                    return true;
                }
                catch (Exception ex)
                {

                    this.StrErrorMessage = ex.Message;
                    return false;
                }
            }
            else 
                return false;
         }

        public bool update()
        {
           
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();
                    objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
                    this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
                    objTrans.End_Transaction();

                    if (this.StrErrorMessage.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    else
                    {
                        return true;

                    }


                }
                catch (Exception ex)
                {
                    this.StrErrorMessage = ex.Message;
                    return false;

                }
           
        }

        private string[,] MakeArray()
        {
            string[,] array = new string[13, 3];

            if (!this.StrOrganizationId.Equals(Default))
            {
                array[0, 0] = "ORGID";
                array[0, 1] = this.StrOrganizationId;
                array[0, 2] = "int";
            }

            if (!StrName.Equals(Default))
            {
                array[1, 0] = "NAME";
                array[1, 1] = this.StrName;
                array[1, 2] = "string";
            }

            if (!StrAcronym.Equals(Default))
            {
                array[2, 0] = "ACRONYM";
                array[2, 1] = this.StrAcronym;
                array[2, 2] = "string";
            }

            if (!this.StrPhoneNo.Equals(Default))
            {
                array[3, 0] = "PHONENO";
                array[3, 1] = this.StrPhoneNo;
                array[3, 2] = "string";
            }

            if (!this.StrFaxNo.Equals(Default))
            {
                array[4, 0] = "FAXNO";
                array[4, 1] = this.StrFaxNo;
                array[4, 2] = "string";
            }

            if (!this.StrEmail.Equals(Default))
            {
                array[5, 0] = "EMAIL";
                array[5, 1] = this.StrEmail;
                array[5, 2] = "string";
            }

            if (!this.StrWebAddress.Equals(Default))
            {
                array[6, 0] = "WEB_ADDRESS";
                array[6, 1] = this.StrWebAddress;
                array[6, 2] = "string";
            }

            if (!this.StrPostalAddress.Equals(Default))
            {
                array[7, 0] = "ADDRESS";
                array[7, 1] = this.StrPostalAddress;
                array[7, 2] = "string";
            }

            if (!this.StrActive.Equals(Default))
            {
                array[8, 0] = "ACTIVE";
                array[8, 1] = this.StrActive;
                array[8, 2] = "string";
            }

            if (!this.StrEnteredOn.Equals(Default))
            {
                array[9, 0] = "ENTEREDON";
                array[9, 1] = this.StrEnteredOn;
                array[9, 2] = "date";
            }

            if (!this.StrEnteredBy.Equals(Default))
            {
                array[10, 0] = "ENTEREDBY";
                array[10, 1] = this.StrEnteredBy;
                array[10, 2] = "string";
            }

            if (!this.StrClientId.Equals(Default))
            {
                array[11, 0] = "CLIENTID";
                array[11, 1] = this.StrClientId;
                array[11, 2] = "string";
            }

            if (!this.StrExternal.Equals(Default))
            {
                array[12, 0] = "EXTERNAL";
                array[12, 1] = this.StrExternal;
                array[12, 2] = "string";
            }
            return array;
        }


        public bool Validation()
        {
            DataView dv = GetAll(2);

            if (dv.Count > 0)
            {
                if (StrOrganizationId != null && StrOrganizationId != Default && StrOrganizationId != "")
                    dv.RowFilter = "ORGID <>" + StrOrganizationId;
                if (dv.Count > 0)
                {
                    StrErrorMessage = "Please Enter another organization Name. This organisation is already present";
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        }

		#endregion
	}
}

