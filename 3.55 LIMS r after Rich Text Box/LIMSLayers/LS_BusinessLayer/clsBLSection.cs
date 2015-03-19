using System;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    /// <summary>
    /// Summary description for clsBLSection.
    /// </summary>
    public class clsBLSection
    {
        public clsBLSection()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string StrErrorMessage = "";
        private string TableName = "LS_TSection";
        private const string Default = "~!@";
        private string StrActive = Default;
        private string StrSection = Default;
        private string StrDesc = Default;
        private string StrEnteredby = Default;
        private string StrSectionID = Default;
        private string StrEnteredon = Default;
        private string StrHeadID = Default;
        private string StrDOrder = Default;

        

        



        #region "Properties"
        public string DOrder
        {
            get { return StrDOrder; }
            set { StrDOrder = value; }
        }
        public string HeadID
        {
            get { return StrHeadID; }
            set { StrHeadID = value; }
        }
        public string ErrorMessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        public string SectionID
        {
            get { return StrSectionID; }
            set { StrSectionID = value; }
        }
        public string Section
        {
            get { return StrSection; }
            set { StrSection = value; }

        }
        public string Description
        {
            get { return StrDesc; }
            set { StrDesc = value; }
        }
        public string Enteredon
        {
            get { return StrEnteredon; }
            set { StrEnteredon = value; }
        }
        public string Enteredby
        {
            get { return StrEnteredby; }
            set { Enteredby = value; }
        }

        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
        }

        #endregion

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * from LS_TSection Where Upper(Active)='" + StrActive.ToUpper() + "'";
                    break;

                case 2:
                    objdbhims.Query = "Select * from LS_TSection where Active='Y'";
                    break;
                case 3:
                    objdbhims.Query = "Select orgid,name from whims.ls_textorganization where External='Y'";
                    break;
                case 4:
                    objdbhims.Query = @"Select * From ls_tsection";
                    break;
            }

            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public string GetNextTestNo(string sectionID, clsoperation trans)
        {

            objdbhims.Query = "select testno from " + TableName + " where sectionid='" + sectionID + "'";
            DataTable table = trans.Transaction_Get_Single(objdbhims).Table;
            string testNo = table.Rows[0][0].ToString();

            objdbhims.Query = "update " + TableName + " set testno=testno+1 where sectionid='" + sectionID + "'";
            trans.DataTrigger_Update(objdbhims);

            return testNo;
        }
        private string[,] MakeArray()
        {
            string[,] section = new string[7, 3];
            if (!this.StrSectionID.Equals(Default))
            {
                section[0, 0] = "SectionID";
                section[0, 1] = this.StrSectionID;
                section[0, 2] = "string";
            }
            if (!this.StrSection.Equals(Default))
            {
                section[1, 0] = "Sectionname";
                section[1, 1] = this.StrSection;
                section[1, 2] = "string";
            }

            if (!this.StrDesc.Equals(Default))
            {
                section[2, 0] = "Description";
                section[2, 1] = this.StrDesc;
                section[2, 2] = "string";
            }

            if (!this.StrActive.Equals(Default))
            {
                section[3, 0] = "Active";
                section[3, 1] = this.StrActive;
                section[3, 2] = "string";
            }

            if (!this.StrEnteredon.Equals(Default))
            {
                section[4, 0] = "Enteredon";
                section[4, 1] = this.StrEnteredon;
                section[4, 2] = "date";
            }

            if (!this.StrEnteredby.Equals(Default))
            {
                section[5, 0] = "Enteredby";
                section[5, 1] = this.StrEnteredby;
                section[5, 2] = "string";
            }
            if (!this.StrHeadID.Equals(Default))
            {
                section[6, 0] = "HeadID";
                section[6, 1] = this.StrHeadID;
                section[6, 2] = "string";
            }
            

            return section;
        }

        public bool Insert()
        {

            try
            {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();
                objdbhims.Query = objQB.QBGetMax("SectionId", TableName, "3");
                this.StrSectionID = objTrans.DataTrigger_Get_Max(objdbhims);

                objdbhims.Query = objQB.QBGetMax("DOrder", TableName);
                StrDOrder = objTrans.DataTrigger_Get_Max(objdbhims);
                if (this.StrSectionID.Equals("True") || this.StrDOrder.Equals("True"))
                {
                    objTrans.End_Transaction();
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }
                objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);

               // objTrans.End_Transaction();

                if (this.StrErrorMessage.Equals("True"))
                {
                    objTrans.End_Transaction();
                    this.StrErrorMessage = objTrans.OperationError;
                    return false;
                }

                objTrans.End_Transaction();
                return true;
                

            }
            catch (Exception e)
            {
                this.StrErrorMessage = e.Message;
                return false;
            }
        }
        public bool Update()
        {

            try
            {
                QueryBuilder objQB = new QueryBuilder();
                objTrans.Start_Transaction();

                objdbhims.Query = objQB.QBUpdate(MakeArray(), TableName);
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
            catch (Exception e)
            {
                this.StrErrorMessage = e.Message;
                return false;
            }

        }
    }
}