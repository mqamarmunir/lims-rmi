using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBLTestPriceUpdate
    {
        public clsBLTestPriceUpdate()
        {
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TestPriceHistory";
        private string StrTransactionID = Default;
        private string StrEffective_Date = Default;
        private string StrCharges_Old = Default;
        private string StrCharges_New = Default;
        private string StrUrgentCharges_Old = Default;
        private string StrUrgentCharges_New = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrTestID = Default;

        private string StrSectionID = Default;
        private string StrtestGroupID = Default;
        private string StrPercentage = Default;
        private string StrType = Default;

        private string StrErrorMessage = Default;

       
        #endregion

        
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region properties
        public string TransactionID
        {
            get { return StrTransactionID; }
            set { StrTransactionID = value; }
        }
        public string Effective_Date
        {
            get { return StrEffective_Date; }
            set { StrEffective_Date = value; }
        }
        public string Charges_Old
        {
            get { return StrCharges_Old; }
            set { StrCharges_Old = value; }
        }
        public string Charges_New
        {
            get { return StrCharges_New; }
            set { StrCharges_New = value; }
        }

        public string UrgentCharges_Old
        {
            get { return StrUrgentCharges_Old; }
            set { StrUrgentCharges_Old = value; }
        }
        public string UrgentCharges_New
        {
            get { return StrUrgentCharges_New; }
            set { StrUrgentCharges_New = value; }
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
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string SectionID
        {
            get { return StrSectionID; }
            set { StrSectionID = value; }
        }

        public string TestGroupID
        {
            get { return StrtestGroupID; }
            set { StrtestGroupID = value; }
        }

        public string Percentage
        {
            get { return StrPercentage; }
            set { StrPercentage = value; }
        }

        public string Type
        {
            get { return StrType; }
            set { StrType = value; }
        }
      
        public string Errormessage
        {
            get { return StrErrorMessage; }
            set { StrErrorMessage = value; }
        }
        #endregion

        #region methods
        public DataView GetAll(int flag)
        {
            clsoperation objTrans2 = new clsoperation();

            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select SECTIONID,SECTIONNAME From LS_TSection";
                    break;
                case 2:
                    objdbhims.Query = "Select TESTGROUPID,TESTGROUP FROM LS_TTESTGROUP where SECTIONID='" + StrSectionID + "' and Active='Y'";
                    break;
                case 3:
                    string query = "Select TT.TESTID, TS.SECTIONNAME,TT.TEST,TT.ACRONYM,TT.CHARGES, tp.charges_new, TT.ChargesURGENT, tp.UrgentCharges_New, To_Char(To_Date(tp.effective_date,'DD-MM-YYYY hh:mi:ss')) Effective_Date From Ls_TTest TT Inner Join LS_TSection Ts On ts.sectionid= tt.sectionid";
                    if (StrSectionID != Default)
                    {
                        if (StrtestGroupID != Default)
                        {
                            query = query + " AND TT.SectionID=" + StrSectionID + " And TT.TestGroupID=" + StrtestGroupID + "  Left Outer Join Ls_TTestPriceHistory tp On tp.TestID=tt.TestID  and tp.Type='T' and tp.Status='A' Where tt.Active='Y' ";
                        }
                        else
                        {
                            query = query + " AND TT.SectionID=" + StrSectionID + " Left Outer Join Ls_TTestPriceHistory tp On tp.TestID=tt.TestID and tp.Type='T' and tp.Status='A' Where tt.Active='Y'" ;
                        }
                    }
                    else 
                    {
                        query = query + " Left Outer Join Ls_TTestPriceHistory tp On tp.TestID=tt.TestID and tp.Type='T' and tp.Status='A' Where tt.Active='Y'";
                    }
                    objdbhims.Query = query;
                    break;
                case 4:
                    objdbhims.Query = "Select * From Ls_TTestPriceHistory where TestID='" + StrTestID + "' And Type='"+StrType+"' and TestgroupID='"+StrtestGroupID+"' And Status='A'";//And Effective_Date=To_Date('" + StrEffective_Date + "','DD/MM/YYYY')
                    break;
                case 5:
                    objdbhims.Query = @"Select ttgd.TestID,Ts.SectionName,TT.Test,TT.Acronym,ttgd.Charges,tp.Charges_new,tt.ChargesUrgent,tp.UrgentCharges_new,To_Char(To_Date(tp.effective_date,'DD-MM-YYYY hh:mi:ss')) Effective_Date
                                        From LS_TTestGroupD ttgd Inner Join Ls_TTest tt
                                        On tt.TestID=ttgd.TestID
                                        inner Join Ls_TTestGroup ttg
                                        On ttg.TestGroupID=ttgd.TestGroupID
                                        inner Join ls_tsection ts
                                        On ts.SectionID=ttg.SectionID
                                        Left Outer join Ls_TTestPriceHistory tp
                                        On tp.testid= ttgd.testid
                                        and tp.TestGroupID=ttgd.testgroupID
                                        and tp.Type='G' and tp.Status='A'
                                        where ts.SectionID='" +StrSectionID+@"'
                                        and ttgd.testgroupid='"+StrtestGroupID+"'";
                    break;

            }



            return objTrans2.DataTrigger_Get_All(objdbhims);

        }

        public bool insertall()
        {
            // using(OleDbConnection connection=new OleDbConnection ("Provider=MSDAORA;Data Source=HIMS;User ID=whims;Password=whims;Unicode=True"))
            //  {
            //    connection.Open();
            clsoperation objTrans4 = new clsoperation();
            double percentage = Convert.ToDouble(StrPercentage) / 100;
            string command = "Insert Into LS_TTestPriceHistory(TransactionID,Effective_Date,Charges_Old,Charges_New,EnteredBy,EnteredOn,TestID,UrgentCharges_Old,UrgentCharges_New) (Select MICROSOFTSEQDTPROPERTIES.nextval,To_Date('" + StrEffective_Date + "','DD-MM-YYYY') ,tt.charges,(tt.charges+(tt.charges *" + percentage + ")),'" + StrEnteredBy + "', To_Date('" + StrEnteredOn + "','DD-MM-YYYY'),tt.TestID,tt.ChargesUrgent,(tt.chargesurgent+(tt.chargesUrgent *" + percentage + ")) From LS_TTest tt";
            if (StrSectionID != Default)
            {
                if (StrtestGroupID != Default)
                {
                    command = command + " where tt.SectionID=" + StrSectionID + " And tt.TestGroupID=" + StrtestGroupID + " And tt.Active='Y')";
                }
                else
                {
                    command = command + " where tt.SectionID=" + StrSectionID + " And tt.Active='Y')";
                }
            }
            else
            {
                command = command + ")";
            }
            objdbhims.Query = command;
            objTrans4.Start_Transaction();
            string err=objTrans4.DataTrigger_Insert(objdbhims);
            if (!err.Equals("true"))
            {
                StrErrorMessage = "Record inserted Successfully";
                objTrans4.End_Transaction();
                return true;
            }
            else
            {
                StrErrorMessage = objTrans4.OperationError;
                objTrans4.End_Transaction();
                return false;
 
            }
            

            //  OleDbCommand _command = new OleDbCommand(command, connection);
            // _command.ExecuteNonQuery();
            // connection.Close();
            //  }
        }

        public void updateall()
        {
           // using (OleDbConnection connection = new OleDbConnection("Provider=MSDAORA;Data Source=HIMS;User ID=whims;Password=whims;Unicode=True"))
          //  {
               // connection.Open();
             clsoperation objTrans3 = new clsoperation();
                double percentage = Convert.ToDouble(StrPercentage) / 100;
                string command = "Update LS_TTest tt Set (tt.Charges,tt.ChargesURGENT)=(Select Round(tp.Charges+(tp.Charges*" + percentage + ")),Round(tp.ChargesURGENT+(tp.ChargesURGENT*" + percentage + ")) From LS_TTest tp where tp.TestID=tt.TestID ";
                if (StrSectionID != Default)
                {
                    if (StrtestGroupID != Default)
                    {
                        command = command + " And tt.SectionID='" + StrSectionID + "' And tt.TestGroupID='" + StrtestGroupID + "' And tt.Active='Y') Where exists (Select al.TestID From LS_TTest al where al.TestID=tt.TestID and al.SectionID='" + StrSectionID + "' And al.TestGroupID='" +StrtestGroupID + "' and tt.Active='Y')";
                    }
                    else
                    {
                        command = command + " And tt.SectionID='" + StrSectionID + "' And tt.Active='Y') Where Exists(Select al.TestID From LS_TTest al where al.TestId=tt.TestId and al.SectionId='"+StrSectionID + "' tt.active='Y')";
                    }
                }
                else
                {
                    command = command + ")";
                }
            objdbhims.Query=command;
            objTrans3.Start_Transaction();
            objTrans3.DataTrigger_Update(objdbhims);
            objTrans3.End_Transaction();
               // OleDbCommand _command = new OleDbCommand(command, connection);
               // _command.ExecuteNonQuery();
               // connection.Close();
           // }
        }

        public bool insert()
        {
            clsoperation objTrans_insert = new clsoperation();
            if (checks())
            {
                if (Validation())
                {
                    if (!StrUrgentCharges_Old.Equals(Default) && StrUrgentCharges_Old != "&nbsp;")
                    {
                        objdbhims.Query = "Insert into LS_TTestPriceHistory(TransactionID,Effective_Date,Charges_Old,Charges_New,EnteredBy,EnteredOn,TestID,UrgentCharges_Old,UrgentCharges_New,Type,Status,TestGroupID) Values( MICROSOFTSEQDTPROPERTIES.nextval,To_Date('" + StrEffective_Date + "','DD-MM-YYYY'),'" + StrCharges_Old + "','" + StrCharges_New + "','" + StrEnteredBy + "',To_Date('" + StrEnteredOn + "','DD-MM-YYYY hh:mi:ss am'),'" + StrTestID + "','" + StrUrgentCharges_Old + "','" + StrUrgentCharges_New + "','" + StrType + "','A','" + StrtestGroupID + "')";
                    }
                    else
                    {
                        objdbhims.Query = "Insert into LS_TTestPriceHistory(TransactionID,Effective_Date,Charges_Old,Charges_New,EnteredBy,EnteredOn,TestID,UrgentCharges_Old,UrgentCharges_New,Type,Status,TestGroupID) Values( MICROSOFTSEQDTPROPERTIES.nextval,To_Date('" + StrEffective_Date + "','DD-MM-YYYY'),'" + StrCharges_Old + "','" + StrCharges_New + "','" + StrEnteredBy + "',To_Date('" + StrEnteredOn + "','DD-MM-YYYY hh:mi:ss am'),'" + StrTestID + "',0,0,'" + StrType + "','A','" + StrtestGroupID + "')";

                    }
                    objTrans_insert.Start_Transaction();
                    string err = objTrans_insert.DataTrigger_Insert(objdbhims);
                    if (err == "False")
                    {

                        objTrans_insert.End_Transaction();
                        return true;
                    }
                    else
                    {
                        objTrans_insert.End_Transaction();
                        this.StrErrorMessage = objTrans_insert.OperationError;
                        return false;
                    }
                }
                else
                {
                    if (!StrUrgentCharges_Old.Equals(Default) && StrUrgentCharges_Old != "&nbsp;")
                    {
                        objdbhims.Query = @"Update (Select Effective_Date e_d,Charges_Old co,Charges_new cn,
                                            EnteredBy eb,EnteredOn eo,UrgentCharges_Old uc_o,
                                            UrgentCharges_New uc_n,Type t,Status s,TestGroupID tg_I
                                            From Ls_TTestPriceHistory 
                                             Where TestID='"+StrTestID+@"' And TestGroupID='"+StrtestGroupID+@"' And Type='"+StrType+@"')
                                             Set e_d=To_Date('" + StrEffective_Date + @"','DD-MM-YYYY'),
                                             co='" +StrCharges_Old+@"',
                                             cn='" + StrCharges_New + @"',
                                             eb='" + StrEnteredBy + @"',
                                             eo=To_Date('" + StrEnteredOn + @"','DD-MM-YYYY hh:mi:ss am'),
                                             uc_o='" + StrUrgentCharges_Old + @"',
                                             uc_n='"+StrUrgentCharges_New+@"',
                                             t='"+StrType+@"',
                                             s='A',
                                             tg_I='"+StrtestGroupID+"'";
                    }
                    else
                    {
                        objdbhims.Query = @"Update (Select Effective_Date e_d,Charges_Old co,Charges_new cn,
                                            EnteredBy eb,EnteredOn eo,UrgentCharges_Old uc_o,
                                            UrgentCharges_New uc_n,Type t,Status s,TestGroupID tg_I
                                            From Ls_TTestPriceHistory 
                                             Where TestID='" + StrTestID + @"' And TestGroupID='" + StrtestGroupID + @"' And Type='" + StrType + @"')
                                             Set e_d=To_Date('" + StrEffective_Date + @"','DD-MM-YYYY'),
                                             co='" + StrCharges_Old + @"',
                                             cn='" + StrCharges_New + @"',
                                             eb='" + StrEnteredBy + @"',
                                             eo=To_Date('" + StrEnteredOn + @"','DD-MM-YYYY hh:mi:ss am'),
                                             uc_o='0',
                                             uc_n='0',
                                             t='" + StrType + @"',
                                             s='A',
                                             tg_I='" + StrtestGroupID + "'";
                    }
                    objTrans_insert.Start_Transaction();
                    string err = objTrans_insert.DataTrigger_Update(objdbhims);
                    if (err == "False")
                    {

                        objTrans_insert.End_Transaction();
                        return true;
                    }
                    else
                    {
                        objTrans_insert.End_Transaction();
                        this.StrErrorMessage = objTrans_insert.OperationError;
                        return false;
                    }
                    //return true;
                }
            }
            else
            {
                // StrErrorMessage = "One or more test prices not updated due to same date conflict";
                return false;
            }
        }

        public bool update()
        {
            if (checks())
            {
                clsoperation objTrans_Update = new clsoperation();
                if (!StrUrgentCharges_Old.Equals(Default) && StrUrgentCharges_Old != "&nbsp;")
                {
                    objdbhims.Query = "Update ls_ttest Set(charges, chargesurgent) = (Select'" + StrCharges_New + "','" + StrUrgentCharges_New + "' From dual) Where testid='" + StrTestID + "'";


                }
                else
                {
                    objdbhims.Query = "Update ls_ttest Set(charges, chargesurgent) = (Select'" + StrCharges_New + "',0 From dual) Where testid='" + StrTestID + "'";

                }

                objTrans_Update.Start_Transaction();
                string err = objTrans_Update.DataTrigger_Update(objdbhims);
                if (err == "True")
                {
                    objTrans_Update.End_Transaction();
                    this.StrErrorMessage = objTrans_Update.OperationError;
                    return false;

                }
                else
                {
                    objTrans_Update.End_Transaction();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool updateTestGroupD()
        {
            if (checks())
            {
                clsoperation objTrans_up = new clsoperation();
                objdbhims.Query = "Update Ls_TTestGroupD Set Charges=" + Convert.ToInt32(StrCharges_New) + " Where TestId='" + StrTestID + "' And TestGroupID='" + StrtestGroupID + "'";
                objTrans_up.Start_Transaction();
                string err = objTrans_up.DataTrigger_Update(objdbhims);
                objTrans_up.End_Transaction();
                if (err == "True")
                {
                    this.StrErrorMessage = objTrans_up.OperationError;
                    return false;
                }
                else
                {
                    this.StrErrorMessage = "Update Successful";
                    return true;
                }
            }
            else
            { return false; }
        }

        private bool Validation()
        {
            //clsBLTestPriceUpdate obj_validation=new clsBLTestPriceUpdate();
            DataView dv = GetAll(4);
            if (dv.Count > 0)
            {
                //this.StrErrorMessage = "A Test can have only one update set at one Time.";
                return false;
            }
            else
            {
                return true;
            }
 
        }

        private bool checks()
        {
            if (!VD_percentage())
            {
                return false;
            }
            if (!VD_EffectiveDate())
            {
                return false;
            }

            return true;
        }

        private bool VD_percentage()
        {
            Validation objValid = new Validation();

            if (this.StrPercentage.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Percentage. (empty is not allowed)";
                return false;
            }
          
            else
            {
                return true;
            }
        }

        private bool VD_EffectiveDate()
        {
            Validation objValid = new Validation();

            if (this.StrPercentage.Equals(""))
            {
                this.StrErrorMessage = "Please Enter Effective Date. (empty is not allowed)";
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
