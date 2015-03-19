using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBLPreferenceSettings
    {
        public clsBLPreferenceSettings()
        {
        }

        #region Variables
        private const string Default = "~!@";
        private const string TableName = "LS_TPREFERENCESETTINGS";
        private string StrPreferenceID = Default;
        private string StrindoorTime = Default;
        private string StroutdoorTime = Default;
        private string StricdEnabled = Default;
        private string StrAttributeMax_min = Default;
        private string StrResultEntryTime = Default;
        private string StrAutoVerify = Default;
        private string StrImg_Path = Default;
        private string StrDoc_Path = Default;
        private string StrAd_Note = Default;
        private string StrThresholdTime = Default;
        private string StrAutoVerifyIndoor = Default;

        

        #endregion
        
        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();

        #region Properties
        public string Ad_Note
        {
            get { return StrAd_Note; }
            set { StrAd_Note = value; }
        }
        public string PreferenceID
        {
            get { return StrPreferenceID; }
            set { StrPreferenceID = value; }
        }

        public string IndoorTime
        {
            get { return StrindoorTime; }
            set { StrindoorTime = value; }
        }

        public string OutdoorTime
        {
            get { return StroutdoorTime; }
            set { StroutdoorTime = value; }
        }

        public string icdEnabled
        {
            get { return StricdEnabled; }
            set { StricdEnabled = value; }
        }
        public string AttributeMax_min
        {
            get { return StrAttributeMax_min; }
            set { StrAttributeMax_min = value; }
        }
        public string ResultEntryTime
        {
            get { return StrResultEntryTime; }
            set { StrResultEntryTime = value; }
        }
        public string AutoVerify
        {
            get { return StrAutoVerify; }
            set { StrAutoVerify = value; }
        }
        public string Img_Path
        {
            get { return StrImg_Path; }
            set { StrImg_Path = value; }
        }
        public string Doc_Path
        {
            get { return StrDoc_Path; }
            set { StrDoc_Path = value; }
        }
        public string ThresholdTime
        {
            get { return StrThresholdTime; }
            set { StrThresholdTime = value; }
        }

        public string AutoVerifyIndoor
        {
            get { return StrAutoVerifyIndoor; }
            set { StrAutoVerifyIndoor = value; }
        }

        #endregion

        #region methods
        public bool insert()
        {
            clsoperation objTrans4 = new clsoperation();
            DataView dv = GetAll(1);
            if (dv.Count== 0)
            {
                string command = @"Insert INTO LS_TPreferenceSettings Values(MICROSOFTSEQDTPROPERTIES.nextval," + Convert.ToDouble(StrindoorTime) + " ," + 
                    Convert.ToDouble(StroutdoorTime) + ",'" + StricdEnabled + "'," +StrAttributeMax_min+","+Convert.ToDouble(StrResultEntryTime)+",'"+
                    StrAutoVerify + "','" + StrImg_Path + "','" + StrDoc_Path + "','" + StrAd_Note + "'" + "," + Convert.ToInt32(StrThresholdTime) + ",'" + StrAutoVerifyIndoor + "')";
                objdbhims.Query = command;
                objTrans4.Start_Transaction();
                objTrans4.DataTrigger_Insert(objdbhims);
                objTrans4.End_Transaction();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void update()
        {
            clsoperation objTrans1 = new clsoperation();
            string command="";
            if (StrPreferenceID != Default || StrPreferenceID!="")
            {
                command = @"UPDATE ls_tpreferencesettings Set(COLLTIME_INDOOR, colltime_outdoor,ICD,ATTRIBUTEMAX_MIN,RESULTENTRYTIME,AutoVerify,AUTOVERIFYINDOOR,Img_path,doc_Path,AdvertisementNote,THRESHOLDTIME)
                        =(Select " + Convert.ToDouble(StrindoorTime) + ", " + Convert.ToDouble(StroutdoorTime) + ", '" + StricdEnabled + "'," + 
                                   StrAttributeMax_min + ","+StrResultEntryTime +",'"+StrAutoVerify+"','" + StrAutoVerifyIndoor + "','" +StrImg_Path+"','"+StrDoc_Path+"','"+
                                   StrAd_Note + "'" + "," + Convert.ToInt32(StrThresholdTime) + " From dual)  Where PREFERENCEID =" + Convert.ToDouble(StrPreferenceID);
                objdbhims.Query = command;
                objTrans1.Start_Transaction();
                objTrans1.DataTrigger_Update(objdbhims);
                objTrans1.End_Transaction();
            
            }

           
        }

        public DataView GetAll(int flag)
        {
            clsoperation objTrans2 = new clsoperation();
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From LS_TPreferenceSettings";
                    break;
            }
            return objTrans2.DataTrigger_Get_All(objdbhims);

        }

  
        #endregion
    }
}
