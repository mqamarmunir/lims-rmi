using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
   public class clsBlRepeatTest
    {
       public clsBlRepeatTest()
       {
           ///Add Constructor Logic here...
       }


        #region Variables
       private const string TableName = "LS_TRepeatResult";
       private const string Default = "~!@";
       private string StrRepeatResultID = Default;
       private string StrLabID = Default;
       private string StrTestID = Default;
       private string StrPRNumber= Default;
       private string StrRepeatReasonID = Default;
       private string StrEnteredBy = Default;
       private string StrEnteredOn = Default;
       private string StrClientID = Default;
       private string StrErrorMessage = "";

        #endregion
       clsoperation objTrans = new clsoperation();
       clsdbhims objdbhims = new clsdbhims();

        #region properties
       public string RepeatResultID
       {
           get { return StrRepeatResultID; }
           set { StrRepeatResultID = value; }
       }
       public string LabID
       {
           get { return StrLabID; }
           set { StrLabID = value; }
       }
       public string TestID
       {
           get { return StrTestID; }
           set { StrTestID = value; }
       }
       public string PRNumber
       {
           get { return StrPRNumber; }
           set { StrPRNumber = value; }
       }
       public string RepeatReasonID
       {
           get { return StrRepeatReasonID; }
           set { StrRepeatReasonID = value; }
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
                   objdbhims.Query = "Select REPEATREASONID From LS_TRepeatResult where labID='" + StrLabID + "' and TestID='" + StrTestID + "'";
                   break;
               case 2:
                   objdbhims.Query = "Select REPEATREASONID From LS_TRepeatResult where labID='" + StrLabID + "'";
                   break;
           }
           return objTrans.DataTrigger_Get_All(objdbhims);
       }

       public bool insert()
       {
           try
           {
               QueryBuilder objQB = new QueryBuilder();
               objTrans.Start_Transaction();

               objdbhims.Query = objQB.QBGetMax("RepeatResultID", TableName, "4");
               this.StrRepeatResultID = objTrans.DataTrigger_Get_Max(objdbhims);
               if (!this.StrRepeatResultID.Equals("True"))
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
       private string[,] MakeArray()
       {
           string[,] ary_GroupD = new string[8, 3];

           if (!StrRepeatResultID.Equals(Default))
           {
               ary_GroupD[0, 0] = "RepeatResultID";
               ary_GroupD[0, 1] = this.StrRepeatResultID;
               ary_GroupD[0, 2] = "string";
           }

           
           if (!StrTestID.Equals(Default))
           {
               ary_GroupD[1, 0] = "TestID";
               ary_GroupD[1, 1] = this.StrTestID;
               ary_GroupD[1, 2] = "string";
           }
           if (!StrLabID.Equals(Default))
           {
               ary_GroupD[2, 0] = "LabID";
               ary_GroupD[2, 1] = this.StrLabID;
               ary_GroupD[2, 2] = "string";
           }
           

           if (!StrEnteredBy.Equals(Default))
           {
               ary_GroupD[3, 0] = "EnteredBy";
               ary_GroupD[3, 1] = this.StrEnteredBy;
               ary_GroupD[3, 2] = "string";
           }
           if (!StrEnteredOn.Equals(Default))
           {
               ary_GroupD[4, 0] = "EnteredOn";
               ary_GroupD[4, 1] = this.StrEnteredOn;
               ary_GroupD[4, 2] = "date";
           }
           if (!StrClientID.Equals(Default))
           {
               ary_GroupD[5, 0] = "ClientID";
               ary_GroupD[5, 1] = this.StrClientID;
               ary_GroupD[5, 2] = "string";
           }
         
           if (!StrPRNumber.Equals(Default))
           {
               ary_GroupD[6, 0] = "PRNumber";
               ary_GroupD[6, 1] = this.StrPRNumber;
               ary_GroupD[6, 2] = "string";
           }
           if (!StrRepeatReasonID.Equals(Default))
           {
               ary_GroupD[7, 0] = "RepeatReasonID";
               ary_GroupD[7, 1] = this.StrRepeatReasonID;
               ary_GroupD[7, 2] = "string";
 
           }
           return ary_GroupD;

       }
        #endregion
    }
}
