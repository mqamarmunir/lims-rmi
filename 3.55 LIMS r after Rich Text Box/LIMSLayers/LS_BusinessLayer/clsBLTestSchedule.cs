using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBLTestSchedule
    {
        public clsBLTestSchedule()
        {

        }
        #region Class Variables
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        private const string TableName = "LS_TTestSchedule";
        private const string Default = "~!@";
        private string StrType = Default;
        private string StrchkMon1 = Default;
        private string StrchkTue1 = Default;
        private string StrchkWed1 = Default;
        private string StrchkThu1 = Default;
        private string StrchkFri1 = Default;
        private string StrchkSat1 = Default;
        private string StrchkSun1 = Default;

        private string StrchkMon2 = Default;
        private string StrchkTue2 = Default;
        private string StrchkWed2 = Default;
        private string StrchkThu2 = Default;
        private string StrchkFri2 = Default;
        private string StrchkSat2 = Default;
        private string StrchkSun2 = Default;

        private string StrchkMon3 = Default;
        private string StrchkTue3 = Default;
        private string StrchkWed3 = Default;
        private string StrchkThu3 = Default;
        private string StrchkFri3 = Default;
        private string StrchkSat3 = Default;
        private string StrchkSun3 = Default;

        private string StrchkMon4 = Default;
        private string StrchkTue4 = Default;
        private string StrchkWed4 = Default;
        private string StrchkThu4 = Default;
        private string StrchkFri4 = Default;
        private string StrchkSat4 = Default;
        private string StrchkSun4 = Default;

        private string _chkMonthly1 = Default;

        
        private string _chkMonthly2=Default;
        private string _chkMonthly3=Default;
        private string _chkMonthly4=Default;
        private string _chkMonthly5=Default;
        private string _chkMonthly6=Default;
        private string _chkMonthly7=Default;
        private string _chkMonthly8=Default;
        private string _chkMonthly9=Default;
        private string _chkMonthly10=Default;
        private string _chkMonthly11=Default;
        private string _chkMonthly12=Default;
        private string _chkMonthly13=Default;
        private string _chkMonthly14=Default;
        private string _chkMonthly15=Default;
        private string _chkMonthly16=Default;
        private string _chkMonthly17=Default;
        private string _chkMonthly18=Default;
        private string _chkMonthly19=Default;
        private string _chkMonthly20=Default;
        private string _chkMonthly21=Default;
        private string _chkMonthly22=Default;
        private string _chkMonthly23=Default;
        private string _chkMonthly24=Default;
        private string _chkMonthly25=Default;
        private string _chkMonthly26=Default;
        private string _chkMonthly27=Default;
        private string _chkMonthly28=Default;
        private string _chkMonthly29=Default;
        private string _chkMonthly30 = Default;
        

        private string StrTestId=Default;
        private string StrEnteredby=Default;
        private string StrEnteredon=Default;
        private string StrClientID=Default;
        #endregion

        #region Properties
        public string TestID
        {
            get { return StrTestId; }
            set { StrTestId = value; }
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

        public string ClientID
        {
            get { return StrClientID; }
            set { StrClientID = value; }
        }

        public string Type
        {
            get { return StrType; }
            set { StrType = value; }
        }

        public string chkMon1
        {
            get { return StrchkMon1; }
            set { StrchkMon1 = value; }
        }
        public string chkTue1
        {
            get { return StrchkTue1; }
            set { StrchkTue1 = value; }
        }
        public string chkWed1
        {
            get { return StrchkWed1; }
            set { StrchkWed1 = value; }
        }
        public string chkThu1
        {
            get { return StrchkThu1; }
            set { StrchkThu1 = value; }
        }
        public string chkFri1
        {
            get { return StrchkFri1; }
            set { StrchkFri1 = value; }
        }
        public string chkSat1
        {
            get { return StrchkSat1; }
            set { StrchkSat1 = value; }
        }
        public string chkSun1
        {
            get { return StrchkSun1; }
            set { StrchkSun1 = value; }
        }


        public string chkMon2
        {
            get { return StrchkMon2; }
            set { StrchkMon2 = value; }
        }
        public string chkTue2
        {
            get { return StrchkTue2; }
            set { StrchkTue2 = value; }
        }
        public string chkWed2
        {
            get { return StrchkWed2; }
            set { StrchkWed2 = value; }
        }
        public string chkThu2
        {
            get { return StrchkThu2; }
            set { StrchkThu2 = value; }
        }
        public string chkFri2
        {
            get { return StrchkFri2; }
            set { StrchkFri2 = value; }
        }
        public string chkSat2
        {
            get { return StrchkSat2; }
            set { StrchkSat2 = value; }
        }
        public string chkSun2
        {
            get { return StrchkSun2; }
            set { StrchkSun2 = value; }
        }

        public string chkMon3
        {
            get { return StrchkMon3; }
            set { StrchkMon3 = value; }
        }
        public string chkTue3
        {
            get { return StrchkTue3; }
            set { StrchkTue3 = value; }
        }
        public string chkWed3
        {
            get { return StrchkWed3; }
            set { StrchkWed3 = value; }
        }
        public string chkThu3
        {
            get { return StrchkThu3; }
            set { StrchkThu3 = value; }
        }
        public string chkFri3
        {
            get { return StrchkFri3; }
            set { StrchkFri3 = value; }
        }
        public string chkSat3
        {
            get { return StrchkSat3; }
            set { StrchkSat3 = value; }
        }
        public string chkSun3
        {
            get { return StrchkSun3; }
            set { StrchkSun3 = value; }
        }


        public string chkMon4
        {
            get { return StrchkMon4; }
            set { StrchkMon4 = value; }
        }
        public string chkTue4
        {
            get { return StrchkTue4; }
            set { StrchkTue4 = value; }
        }
        public string chkWed4
        {
            get { return StrchkWed4; }
            set { StrchkWed4 = value; }
        }
        public string chkThu4
        {
            get { return StrchkThu4; }
            set { StrchkThu4 = value; }
        }
        public string chkFri4
        {
            get { return StrchkFri4; }
            set { StrchkFri4 = value; }
        }
        public string chkSat4
        {
            get { return StrchkSat4; }
            set { StrchkSat4 = value; }
        }
        public string chkSun4
        {
            get { return StrchkSun4; }
            set { StrchkSun4 = value; }
        }



        public string ChkMonthly1
        {
            get { return _chkMonthly1; }
            set { _chkMonthly1 = value; }
        }
        public string ChkMonthly2
        {
            get { return _chkMonthly2; }
            set { _chkMonthly2 = value; }
        }
        public string ChkMonthly3
        {
            get { return _chkMonthly3; }
            set { _chkMonthly3 = value; }
        }
        public string ChkMonthly4
        {
            get { return _chkMonthly4; }
            set { _chkMonthly4 = value; }
        }
        public string ChkMonthly5
        {
            get { return _chkMonthly5; }
            set { _chkMonthly5 = value; }
        }
        public string ChkMonthly6
        {
            get { return _chkMonthly6; }
            set { _chkMonthly6 = value; }
        }
        public string ChkMonthly7
        {
            get { return _chkMonthly7; }
            set { _chkMonthly7 = value; }
        }
        public string ChkMonthly8
        {
            get { return _chkMonthly8; }
            set { _chkMonthly8 = value; }
        }
        public string ChkMonthly9
        {
            get { return _chkMonthly9; }
            set { _chkMonthly9 = value; }
        }
        public string ChkMonthly10
        {
            get { return _chkMonthly1; }
            set { _chkMonthly1 = value; }
        }
        public string ChkMonthly11
        {
            get { return _chkMonthly11; }
            set { _chkMonthly11 = value; }
        }
        public string ChkMonthly12
        {
            get { return _chkMonthly12; }
            set { _chkMonthly12 = value; }
        }
        public string ChkMonthly13
        {
            get { return _chkMonthly13; }
            set { _chkMonthly13 = value; }
        }
        public string ChkMonthly14
        {
            get { return _chkMonthly14; }
            set { _chkMonthly14 = value; }
        }
        public string ChkMonthly15
        {
            get { return _chkMonthly15; }
            set { _chkMonthly15 = value; }
        }
        public string ChkMonthly16
        {
            get { return _chkMonthly16; }
            set { _chkMonthly16 = value; }
        }
        public string ChkMonthly17
        {
            get { return _chkMonthly17; }
            set { _chkMonthly17 = value; }
        }
        public string ChkMonthly18
        {
            get { return _chkMonthly18; }
            set { _chkMonthly18 = value; }
        }
        public string ChkMonthly19
        {
            get { return _chkMonthly19; }
            set { _chkMonthly19 = value; }
        }
        public string ChkMonthly20
        {
            get { return _chkMonthly20; }
            set { _chkMonthly1 = value; }
        }
        public string ChkMonthly21
        {
            get { return _chkMonthly21; }
            set { _chkMonthly21 = value; }
        }
        public string ChkMonthly22
        {
            get { return _chkMonthly22; }
            set { _chkMonthly22 = value; }
        }
        public string ChkMonthly23
        {
            get { return _chkMonthly23; }
            set { _chkMonthly23 = value; }
        }
        public string ChkMonthly24
        {
            get { return _chkMonthly24; }
            set { _chkMonthly24 = value; }
        }
        public string ChkMonthly25
        {
            get { return _chkMonthly25; }
            set { _chkMonthly25 = value; }
        }
        public string ChkMonthly26
        {
            get { return _chkMonthly26; }
            set { _chkMonthly26 = value; }
        }
        public string ChkMonthly27
        {
            get { return _chkMonthly27; }
            set { _chkMonthly27 = value; }
        }
        public string ChkMonthly28
        {
            get { return _chkMonthly28; }
            set { _chkMonthly28 = value; }
        }
        public string ChkMonthly29
        {
            get { return _chkMonthly29; }
            set { _chkMonthly29 = value; }
        }
        public string ChkMonthly30
        {
            get { return _chkMonthly30; }
            set { _chkMonthly30 = value; }
        }
        #endregion


        #region methods
        public DataView GetAll(int flag)
        {

            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select Type,Value From LS_TTestSchedule Where TestID='" + StrTestId + "'";
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public void insertall()
        {
            //string command = "";
            clsoperation objTrans2=new clsoperation();
         
           // bool flag = false;
            if (StrType == "Daily")
            {
                objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('"+ StrEnteredon +"','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'-','" + StrClientID + "')";
                objTrans2.Start_Transaction();
                objTrans2.DataTrigger_Insert(objdbhims);
                objTrans2.End_Transaction();

            }
            #region Days
            else if (StrType == "Days")
            {
                if (!StrchkMon1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Monday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkTue1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Tuesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkWed1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Wednesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkThu1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Thursday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkFri1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Friday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSat1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Saturday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSun1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'Sunday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

            }
            #endregion
            #region Weekly
            else if (StrType == "Weekly")
            {
                if (!StrchkMon1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Monday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkTue1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Tuesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkWed1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Wednesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkThu1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Thursday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkFri1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Friday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSat1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Saturday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSun1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1-Sunday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                /////////////////////////////
                if (!StrchkMon2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Monday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkTue2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Tuesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkWed2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Wednesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkThu2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Thursday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkFri2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Friday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSat2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Saturday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSun2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2-Sunday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                ///////////////////////////////////
                if (!StrchkMon3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Monday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkTue3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Tuesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkWed3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Wednesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkThu3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Thursday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkFri3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Friday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSat3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Saturday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSun3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3-Sunday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                ///////////////////////////////
                if (!StrchkMon4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Monday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkTue4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Tuesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkWed4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Wednesday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkThu4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Thursday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkFri4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Friday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSat4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Saturday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

                if (!StrchkSun4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4-Sunday','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                ////////////////////////////////////////////////

            }
            #endregion
            #region Monthly
            else if (StrType == "Monthly")
            {
                if (!_chkMonthly1.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'1','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly2.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'2','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly3.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'3','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly4.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'4','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly5.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'5','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly6.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'6','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly7.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'7','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly8.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'8','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly9.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'9','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly10.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'10','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly11.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'11','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly12.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'12','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly13.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'13','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly14.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'14','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly15.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'15','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly16.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'16','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly17.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'17','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly18.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'18','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly19.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'19','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly20.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'20','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly21.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'21','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly22.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'22','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly23.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'23','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly24.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'24','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly25.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'25','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly26.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'26','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly27.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'27','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly28.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'28','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly29.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'29','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }
                if (!_chkMonthly30.Equals(Default))
                {
                    objdbhims.Query = "Insert into LS_TTestSchedule(TestID,Type,Enteredon,Enteredby,Value,ClientID) Values('" + StrTestId + "','" + StrType + "', To_Date('" + StrEnteredon + "','dd/mm/yyyy hh:mi:ss am')" + ",'" + StrEnteredby + "'" + ",'30','" + StrClientID + "')";
                    objTrans2.Start_Transaction();
                    objTrans2.DataTrigger_Insert(objdbhims);
                    objTrans2.End_Transaction();
                }

            }
            #endregion
            // objdbhims.Query = command;

            objTrans2 = null;
               
            
            
        }
        public void deleteall()
        {
            clsoperation objTrans_update = new clsoperation();
            if (!StrTestId.Equals(Default))
            {
                objdbhims.Query = "Delete From LS_TTestSchedule Where TestID='" + StrTestId + "'";
                objTrans_update.Start_Transaction();
                objTrans_update.DataTrigger_Delete(objdbhims);
              
               
                objTrans_update.End_Transaction();
                
            }
           
        }

        #endregion
    }
}
