using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;


namespace LS_BusinessLayer
{
    public class clsBlTestMethod
    {
        public clsBlTestMethod()
        {
            // Add Constructor logic here
        }

        #region Varaibles
        private const string Default = "~!@";
        private const string TableName = "LS_TTestMethod";
        private string StrTestMethodID = Default;
        private string StrMethodID = Default;
        private string StrTestID = Default;
        private string StrDOrder = Default;
        private string StrActive = Default;
        private string StrMDefault = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrErrorMessage = Default;
        private string StrSectionID=Default;

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion
        #region Properties
        public string TestMethodID
        {
            get { return StrTestMethodID; }
            set { StrTestMethodID = value; }

        }
        public string MethodID
        {
            get { return StrMethodID; }
            set { StrMethodID = value; }
        }

        public string D_Order
        {
            get { return StrDOrder; }
            set { StrDOrder = value; }
        }

        public string M_Default
        {
            get { return StrMDefault; }
            set { StrMDefault = value; }
        }
        public string TestID
        {
            get { return StrTestID; }
            set { StrTestID = value; }
        }
        public string Active
        {
            get { return StrActive; }
            set { StrActive = value; }
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

         public string SectionID
        {
            get { return StrSectionID; }
            set { StrSectionID = value; }
        }

        #endregion
        #region Methods
         public DataView GetAll(int flag)
         {
             clsoperation objTrans2 = new clsoperation();

             switch (flag)
             {
                 case 1:
                     objdbhims.Query = "Select SECTIONID,SECTIONNAME From LS_TSection";
                     break;
                 case 2:
                     objdbhims.Query = "Select MethodID,Method FROM LS_TMethod where SECTIONID='" + StrSectionID + "' And Active='Y'";
                     break;
                 case 3:
                     objdbhims.Query = "Select TestID,Test From Ls_TTest Where SectionID='" + StrSectionID + "' and Active='Y'";
                     break;
                 case 4:
                     objdbhims.Query = "Select ts.SectionName,tt.Test,tm.TestMethodID,tm.M_Default,tm.Active,tm.D_Order From LS_TTestmethod tm Inner Join LS_TTest tt On tt.TestID=tm.TestID Inner Join LS_TSection ts On ts.SectionID=tm.SectionID Where tt.Active='Y' And tm.SectionID='" +StrSectionID+"' And tm.MethodID='"+ StrMethodID +"'";
                     break;
                 case 5:
                     objdbhims.Query = "Select TestID,TestMethodID From Ls_TTestMethod where TestID='" + StrTestID + "' And MethodID='" + StrMethodID +"'";
                     break;
                 case 6:

                     objdbhims.Query = "Select M_Default,TestMethodID From LS_TTestMethod where TestID='" + StrTestID + "'";
                     
                     break;
                 case 7:
                     objdbhims.Query = @"Select tm.Methodid,m.Method,tm.M_Default 
                                        From Ls_Ttestmethod tm Inner Join Ls_Tmethod m On m.MethodID=tm.MethodID

                                        where tm.Testid='"+StrTestID+"' and tm.Active='Y' order by tm.M_Default DESC";
                     break;
             }
             return objTrans2.DataTrigger_Get_All(objdbhims);
         }

         public bool Insert()
         {
             if (Validation() && VD_Test())
             {
                 try
                 {
                     QueryBuilder objQB = new QueryBuilder();
                     objTrans.Start_Transaction();

                     objdbhims.Query = objQB.QBGetMax("TESTMETHODID", TableName, "6");
                     this.StrTestMethodID = objTrans.DataTrigger_Get_Max(objdbhims);
                     objdbhims.Query = objQB.QBGetMax("d_order", TableName, "6");
                     this.StrDOrder = objTrans.DataTrigger_Get_Max(objdbhims);
                     if (!this.StrTestMethodID.Equals("True"))
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
         public bool Update()
         {
             clsoperation objTrans = new clsoperation();
             QueryBuilder objQB = new QueryBuilder();

             objTrans.Start_Transaction();
             if (Validation() && VD_Test())
             {
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
         public bool update_TestTable()
         {
             clsoperation objTransupdatetest = new clsoperation();
             objdbhims.Query="Update LS_TTest Set(d_methodID)='"+StrMethodID+"' Where TestID='"+StrTestID+ "'";
             objTransupdatetest.Start_Transaction();
             string ErrMsg = objTransupdatetest.DataTrigger_Update(objdbhims);
             objTransupdatetest.End_Transaction();
             if (ErrMsg.Equals("True"))
             {
                 this.StrErrorMessage = objTransupdatetest.OperationError;
                 return false;
             }

             return true;
         }
         private string[,] MakeArray()
         {
             string[,] ary_GroupD = new string[10, 3];

             if (!StrTestMethodID.Equals(Default))
             {
                 ary_GroupD[0, 0] = "TestMethodID";
                 ary_GroupD[0, 1] = this.StrTestMethodID;
                 ary_GroupD[0, 2] = "string";
             }

             if (!StrMethodID.Equals(Default))
             {
                 ary_GroupD[1, 0] = "MethodID";
                 ary_GroupD[1, 1] = this.StrMethodID;
                 ary_GroupD[1, 2] = "string";
             }
             if (!StrTestID.Equals(Default))
             {
                 ary_GroupD[2, 0] = "TestID";
                 ary_GroupD[2, 1] = this.StrTestID;
                 ary_GroupD[2, 2] = "string";
             }
             if (!StrDOrder.Equals(Default))
             {
                 ary_GroupD[3, 0] = "D_Order";
                 ary_GroupD[3, 1] = this.StrDOrder;
                 ary_GroupD[3, 2] = "int";
             }
             if (!StrMDefault.Equals(Default))
             {
                 ary_GroupD[4, 0] = "M_Default";
                 ary_GroupD[4, 1] = this.StrMDefault;
                 ary_GroupD[4, 2] = "string";
             }
             if (!StrActive.Equals(Default))
             {
                 ary_GroupD[5, 0] = "Active";
                 ary_GroupD[5, 1] = this.StrActive;
                 ary_GroupD[5, 2] = "string";
             }
           
             if (!StrEnteredBy.Equals(Default))
             {
                 ary_GroupD[6, 0] = "EnteredBy";
                 ary_GroupD[6, 1] = this.StrEnteredBy;
                 ary_GroupD[6, 2] = "string";
             }
             if (!StrEnteredOn.Equals(Default))
             {
                 ary_GroupD[7, 0] = "EnteredOn";
                 ary_GroupD[7, 1] = this.StrEnteredOn;
                 ary_GroupD[7, 2] = "date";
             }
             if (!StrClientID.Equals(Default))
             {
                 ary_GroupD[8, 0] = "ClientID";
                 ary_GroupD[8, 1] = this.StrClientID;
                 ary_GroupD[8, 2] = "string";
             }
             if (!StrSectionID.Equals(Default))
             {
                 ary_GroupD[9, 0] = "SectionID";
                 ary_GroupD[9, 1] = this.StrSectionID;
                 ary_GroupD[9, 2] = "string";
             }
             return ary_GroupD;

         }

         private bool Validation()
         {
             if (!VD_ddTest())
             {
                 return false;
             }
             if (!VD_Method())
             {
                 return false;
             }
             if (!VD_SubDepartment())
             {
                 return false;
             }
             return true;
         }

         private bool VD_Test()
         {
             DataView dv = GetAll(5);
             if (!StrTestMethodID.Equals(Default))
             {
                 dv.RowFilter = "TestMethodID<>" + StrTestMethodID;
             }
             if (dv.Count > 0)
             {

                 this.StrErrorMessage = "Insertion failed.Same Test with the same Method already exists";
                 return false;
             }
             else
             {
                 if (StrMDefault == "Y")
                 {
                     dv = GetAll(6);
                     if (!StrTestMethodID.Equals(Default))
                     {
                         dv.RowFilter = "TestMethodID<>" + StrTestMethodID;
                     }
                     int count = 0;
                     if (dv.Count > 0)
                     {
                         for (int i = 0; i < dv.Count; i++)
                         {
                             if (dv[i]["M_Default"].ToString() != "Y")
                             {
                                 count++;
                             }

                         }
                         if (count == dv.Count)
                         {
                             return true;
                         }
                         else
                         {
                             this.StrErrorMessage = "A Test can not have multiple Default Methods.";
                             return false;
                         }
                     }
                     else
                         return true;
                 }

                 else
                     return true;
                 
             }
         }

         private bool VD_SubDepartment()
         {
             if (StrSectionID.Equals(Default) || StrSectionID.Equals("-1") || StrSectionID.Equals(""))
             {
                 this.StrErrorMessage = "Insertion Failed. Please Select Sub-Department";
                 return false;
             }
             else
                 return true;
         }

         private bool VD_Method()
         {
             if (StrMethodID.Equals(Default) || StrMethodID.Equals("-1") || StrMethodID.Equals(""))
             {
                 this.StrErrorMessage = "Insertion Failed. Please Select Method";
                 return false;
             }
             else
                 return true;
         }

         private bool VD_ddTest()
         {
             if (StrTestID.Equals(Default) || StrTestID.Equals("-1")|| StrTestID.Equals(""))
             {
                 this.StrErrorMessage = "Insertion Failed. Please Select Test";
                 return false;
             }
             else
                 return true;
         }

        #endregion

    }
}
