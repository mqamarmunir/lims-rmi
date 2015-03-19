using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LS_DataLayer;
/// <summary>
/// Summary description for clssms
/// </summary>
public class clssms
{
	public clssms()
	{
		//
		// TODO: Add constructor logic here
		//
    }


    #region Variables
    clsoperation objTrans = new clsoperation();
    clsdbhims objdbhims = new clsdbhims();
    private static string Default = "~!@";
    private string _MserialNo = Default;


   

    #endregion

    #region Properties
    public string MserialNo
    {
        get { return _MserialNo; }
        set { _MserialNo = value; }
    }
    #endregion

    #region Methods
    public DataView GetAll(int flag)
    {
        switch (flag)
        {
            case 1:
                objdbhims.Query = @"Select count(testid),case when (select count(testid) from ls_tdtransaction d1 where d1.mserialno=d.mserialno and to_number(d1.processid) in(6,7))=count(testid) then 'Y' else 'N' end as sendsms from ls_tdtransaction d where d.mserialno=1287540
group by d.mserialno";
                break;
        }
        return objTrans.DataTrigger_Get_All(objdbhims);
    }


    #endregion


}