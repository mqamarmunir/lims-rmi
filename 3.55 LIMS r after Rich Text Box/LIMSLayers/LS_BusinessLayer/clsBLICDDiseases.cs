using System;
using System.Collections.Generic;
using System.Text;
using LS_DataLayer;
using System.Data;

namespace LS_BusinessLayer
{
    public class clsBLICDDiseases
    {
        public clsBLICDDiseases()
        {

        }

        #region variables
        private const string TableName = "";
        private const string Default = "~!@";
        private string StrChapterID = Default;
        private string StrBlockID = Default;
        private string StrSearchquery = Default;
        private string StrSuitTitle = Default;

        

        clsoperation objTrans = new clsoperation();
        clsdbhims objdbhims = new clsdbhims();
        #endregion
        
        #region Properties
        public string ChapterID
        {
            get { return StrChapterID; }
            set { StrChapterID = value; }

        }
        public string BlockID
        {
            get { return StrBlockID; }
            set { StrBlockID = value; }
        }
        public string SearchQuery
        {
            get { return StrSearchquery; }
            set { StrSearchquery = value; }
        }

        public string SuitTitle
        {
            get { return StrSuitTitle; }
            set { StrSuitTitle = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            clsoperation objTrans2 = new clsoperation();

            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select chap.CHAPBLOCKTITLE,chap.CHAPBLOCKID From whims2.icd_tchapblock chap where chap.type='C'";
                    break;
                case 2:
                    objdbhims.Query = "Select  chap.CHAPBLOCKTITLE,chap.CHAPBLOCKID FROM whims2.icd_tchapblock chap where chap.type='B' And chap.REFCHAPTER='" +StrChapterID +"'";
                    break;
                case 3:

                    string command = "Select ds.DISEASEID,ds.DISEASENAME,ds.DISEASECODE From whims2.ICD_TDisease ds where 1=1 ";
                   if(!StrChapterID.Equals(Default))
                   {
                       command = command + " and ds.ChapterID='" + StrChapterID + "'";
                   }
                    
                    if (!StrBlockID.Equals(Default))
                    {
                        command = command + " And ds.BLOCKID='" + StrBlockID + "'";
                    }
                    if (!StrSearchquery.Equals(Default))
                    {
                        command = command + " And lower(ds.DiseaseName) Like('%" + StrSearchquery.ToLower() + "%')";
                    }
                    objdbhims.Query = command;
                    break;
                case 4:
                    objdbhims.Query="Select ds.DISEASENAME,ds.DISEASECODE From whims2.ICD_TDisease ds where ds.DISEASENAME Like('%"+ StrSearchquery+"%')";
                    break;
                case 5:
                    objdbhims.Query="Select ds.DISEASENAME,ds.DISEASECODE,ds.DiseaseID From whims2.ICD_TDisease ds where ds.Active='Y' order by Ds.DiseaseName";// and ds.DiseaseName like('"+StrSuitTitle+"%') and rownum<=30 order by ds.DiseaseName";
                    break;
                case 6:
                    
                    objdbhims.Query="Select ds.DISEASENAME,ds.DISEASECODE,ds.DiseaseID From whims2.ICD_TDisease ds where ds.Active='Y' ";
                    if (StrSuitTitle.Trim().Length > 0)
                    {
                        objdbhims.Query += " and lower(ds.DiseaseName) like('" + StrSuitTitle.ToLower() + "%')";
                    }
                    else
                    {
                        objdbhims.Query+=" and 1=2";
                    }
                    objdbhims.Query+=" and rownum<=30 order by ds.DiseaseName";
                    break;

            }
            return objTrans2.DataTrigger_Get_All(objdbhims);
 
        }
        #endregion

    }
}
