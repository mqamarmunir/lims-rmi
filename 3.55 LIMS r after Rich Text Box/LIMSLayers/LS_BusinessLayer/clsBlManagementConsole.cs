using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlManagementConsole
    {
        public clsBlManagementConsole()
        {
 
            /// Add Constructor logic here...
        }

        #region Variables
        private const string Default="~!@";
        private const string TableName = "ls_tshiftcomments";
        private string StrTestGroupID = Default;


        private string StrLabIDFrom = Default;

   
        private string StrLabIDTo = Default;

       
        private string StrWardID = Default;
        private string StrMSerialNoFrom = Default;
        private string StrMSerialNoTo = Default;
        private string StrMSerialNo = Default;
        private string StrDSerialNo = Default;
        private string StrPatientName = Default;
        private string StrPRNo = Default;
        private string StrSectionID = Default;


        private string StrCommentID = Default;
        private string StrComment_Desc = Default;
        private string StrEnteredBy = Default;
        private string StrEnteredOn = Default;
        private string StrClientID = Default;
        private string StrSystem_Ip = Default;
        private string StrNew = Default;
        private string StrDateFrom = Default;
        private string StrDateTo = Default;
        private string StrErrorMessage = Default;
        private string[] strpersonIds;//Default;
        private string StrNotificationID = Default;
        private string StrPersonID = Default;
        private string StrProcessID = Default;
 
        
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();

        #endregion

        #region Properties
        public string ProcessID
        {
            get { return StrProcessID; }
            set { StrProcessID = value; }
        }
        public string PersonID
        {
            get { return StrPersonID; }
            set { StrPersonID = value; }
        }
        public string NotificationID
        {
            get { return StrNotificationID; }
            set { StrNotificationID = value; }
        }
        public string[] StrpersonIds
        {
            get { return strpersonIds; }
            set { strpersonIds = value; }
        }
        public string DateFrom
        {
            get { return StrDateFrom; }
            set { StrDateFrom = value; }
        }
        public string DateTo
        {
            get { return StrDateTo; }
            set { StrDateTo = value; }
        }
        public string TestGroupID
        {
            get { return StrTestGroupID; }
            set { StrTestGroupID = value; }
        }
        public string LabIDFrom
        {
            get { return StrLabIDFrom; }
            set { StrLabIDFrom = value; }
        }
        public string LabIDTo
        {
            get { return StrLabIDTo; }
            set { StrLabIDTo = value; }
        }
        public string WardID
        {
            get { return StrWardID; }
            set { StrWardID = value; }
        }
        public string MSerialNoFrom
        {
            get { return StrMSerialNoFrom; }
            set { StrMSerialNoFrom = value; }
        }
        public string MSerialNoTo
        {
            get { return StrMSerialNoTo; }
            set { StrMSerialNoTo = value; }
        }
        public string DSerialNo
        {
            get { return StrDSerialNo; }
            set { StrDSerialNo = value; }
        }
        public string PatientName
        {
            get { return StrPatientName; }
            set { StrPatientName = value; }
        }
        public string PRNo
        {
            get { return StrPRNo; }
            set { StrPRNo = value; }
        }

        public string SectionID
        {
            get { return StrSectionID; }
            set { StrSectionID = value; }
        }
        public string CommentID
        {
            get { return StrCommentID; }
            set { StrCommentID = value; }
        }
        public string Comment_Desc
        {
            get { return StrComment_Desc; }
            set { StrComment_Desc = value; }
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
        public string System_Ip
        {
            get { return StrSystem_Ip; }
            set { StrSystem_Ip = value; }
        }
        public string New
        {
            get { return StrNew; }
            set { StrNew = value; }
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
            string sTestGroupID = "";
            string sLabIDFrom = "";
            string sLabIDTo = "";
            string sWardID = "";
            string sMSerialNoFrom = "";
            string sMSerialNoTo = "";
            string sMSerialNo = "";
            string sDSerialNo = "";
            string sPatientName = "";
            string sPRNo = "";
            string sSectionID = "";
            string sdaterange = "";
            string processids = "";

            switch (flag)
            {
                    
                case 1:
              if(!this.StrTestGroupID.Equals(Default))
					{sTestGroupID = " And d.TestGroupID = '"+ StrTestGroupID +"' ";}
					if(!this.StrLabIDFrom.Equals(Default))
					{sLabIDFrom = " And m.LabID >= '"+ StrLabIDFrom +"' ";}
					if(!this.StrLabIDTo.Equals(Default))
					{sLabIDTo = " And m.LabID <= '"+ StrLabIDTo +"' ";}
					if(!this.StrWardID.Equals(Default))
					{sWardID = " And p.WardID = '"+ StrWardID +"' ";}
					if(!this.StrMSerialNoFrom.Equals(Default))
					{sMSerialNoFrom = " And m.MSerialNo >= '"+ StrMSerialNoFrom +"' ";}
					if(!this.StrMSerialNoTo.Equals(Default))
					{sMSerialNoTo = " And m.MSerialNo <= '"+ StrMSerialNoTo +"' ";}
					if(!this.StrMSerialNo.Equals(Default))
					{sMSerialNo = " And m.MSerialNo = '"+ StrMSerialNo +"' ";}
					if(!this.StrDSerialNo.Equals(Default))
					{sDSerialNo = " And d.DSerialNo = '"+ StrDSerialNo +"' ";}
                    if (!this.StrPatientName.Equals(Default))
                    { sPatientName = " And upper(p.patientCompletename) Like upper('%" + StrPatientName + "%') "; }
                    if (!this.StrPRNo.Equals(Default))
                    { sPRNo = " And trim(m.PRNo) = trim('" + StrPRNo + "') "; }
                    if (!this.StrSectionID.Equals(Default))
                    { sSectionID = " And trim(d.SectionID) = trim('" + StrSectionID + "') "; }
                    if (!this.StrDateFrom.Equals(Default) && !this.StrDateTo.Equals(Default))
                    { sdaterange = " And m.entrydatetime >= to_date('" + StrDateFrom + "','dd/mm/yyyy') and m.entrydatetime<= to_date('" + StrDateTo + " 11:59:59 am','dd/mm/yyyy hh:mi:ss am') "; }
                    if (!this.StrProcessID.Equals(Default))
                    { processids = " And  d.ProcessID in (" + StrProcessID + ")"; }
                   // objdbhims.Query = "Select Distinct LS_GetPriority(d.priority) As priority, m.MSerialNo, d.DSerialNo, p.patientCompletename As PatientName, LS_GetSex(p.PSex) as PSex, To_Char(p.PAgeD)||' '||p.PAgeU As PAge, t.testid, t.Test, p.PType As Type, p.ServiceNo, d.ProcessID, p.WardName, m.LabID, t.TestType,case when p.PageU ='Y' then p.PageD else 1 end as Cal_Age,d.deliverydate from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p, LS_TTest t  Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo And m.MStatus = 'A' And d.TestID = t.TestID And d.ProcessID in ('0004','0005') And d.SectionID = '" + StrSectionID + "' " + sTestGroupID + sLabIDFrom + sLabIDTo + sWardID + sPatientName + sPRNo + " Order By m.LabID";

                    objdbhims.Query = @"Select Distinct LS_GetPriority(d.priority) As priority,

                                        m.MSerialNo,

                                        d.DSerialNo,

d.SectionID,

d.TestGroupID,

m.PRNo,m.entrydatetime,

                                        p.patientCompletename As
PatientName,

                                        FGETSEX(p.PSex) as PSex,

                                        To_Char(p.PAgeD) || ' ' || p.PAgeU
As PAge,

                                        t.testid,

                                        t.Test,

                                        p.PType As Type,

                                        p.ServiceNo,

                                        d.ProcessID,

                                        nvl(p.WardName,nvl(o.name,'RMI')) as WardName,

p.WardID,

                                        m.LabID,

                                        t.TestType,

                                        case

                                            

                                            when p.PageU = 'Y' then

                                            p.PageD

                                            else

                                            1

                                        end as Cal_Age,

                                        to_char(d.deliverydate,'dd/mm/yyyy
hh:mi:ss am') deliverydate,

                                        to_char(d.EnteredAte,'dd/mm/yyyy
hh:mi:ss am') enteredate,

                                        case

                                            when (((d.DeliveryDate -
d.EnteredAte) * 1440)) >= 1440 then

 
concat(to_char(Floor(d.deliverydate - d.EnteredAte)),

                                                    ' days') ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-d.EnteredAte)*24,24))),'hours
')

                                            ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-d.EnteredAte)*1440,60))),'min
')

                                            when ((d.DeliveryDate -
d.EnteredAte) * 1440) < 1440 and

                                                ((d.DeliveryDate -
d.EnteredAte) * 1440) > 60 then

 
concat(to_char(Floor((d.DeliveryDate - d.Enteredate) * 60)),

                                                    ' hour(s)')

                                                    ||' '||

                                                    

 
concat(to_char(floor(Remainder((d.DeliveryDate-d.EnteredAte)*1440,60))),'min
')

                                             

                                            else

                                            to_char((d.Deliverydate -
d.EnteredAte) * 1440)

                                        end As timedidff,

                                        case

                                            when (d.DeliveryDate - sysdate)
<= 0 then

                                            case

                                                when ((d.DeliveryDate -
sysdate) * -1440 >= 1440) then

                                                'OverDue by(' ||

                                                to_char(Floor(-
(d.DeliveryDate - sysdate))) || ' day(s)'

                                                ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-sysdate)*24,24))),'hour(s))')

                                        

                                                when (((d.DeliveryDate -
sysdate) * -1440) < 1440 and

                                                    ((d.DeliveryDate -
sysdate) * -1440) > 60) then

                                                'OverDue by(' ||

 
to_char(Floor((d.DeliveryDate - sysdate) * -60)) ||

                                                ' hour(s))' ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-sysdate)*1440,60))),'min)')

                                                else

                                                'OverDue by(' ||

                                                to_char(Floor(d.Deliverydate
- sysdate) * -1440) || ')'

                                            end

                                            else

                                            case

                                                when ((d.DeliveryDate -
sysdate) * 1440) >= 1440 then

 
concat(to_char(Round(d.DeliveryDate - sysdate)), ' day(s)')

                                                ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-sysdate)*24,24))),'hours')

                                                    ||' '||


 
concat(to_char(floor(Remainder((d.DeliveryDate-sysdate)*1440,60))),'min')

                                                

                                                when (((d.DeliveryDate -
sysdate) * 1440) < 1440 and

                                                    ((d.DeliveryDate -
sysdate) * 1440) > 60) then

 
concat(to_char(floor(Remainder((d.DeliveryDate - sysdate) * 24,24))),

                                                        ' hour(s)')

                                                        ||' '||

 
concat(to_char(floor(Remainder((d.DeliveryDate-sysdate)*1440,60))),'min')

                                                else 

 
concat(to_char(round((d.Deliverydate - sysdate) * 1440)),'min')

                                            end

                                        end as TimeLeft
                            from LS_tMTransaction m, LS_tDTransaction d,LS_vPatient p, LS_TTest t,ls_textorganization o
                            Where m.MSerialNo = p.MSerialNo
                            And m.MSerialNo = d.MSerialNo
                            And m.MStatus = 'A'
                            And d.TestID = t.TestID
                            and  m.originplaceid=o.cliqbranchid(+)
                           " + @" 
                           " + processids + sSectionID + sPRNo + sPatientName + sDSerialNo + sMSerialNo + sMSerialNoFrom + sMSerialNoTo + sLabIDFrom + sLabIDTo + sWardID + sTestGroupID + sdaterange + @" 
                            Order By m.LabID";

                   
//                   objdbhims.Query = @"Select Distinct LS_GetPriority(d.priority) As priority,
//                                        m.MSerialNo,
//                                        d.DSerialNo,
//                                        p.patientCompletename As PatientName,
//                                        LS_GetSex(p.PSex) as PSex,
//                                        To_Char(p.PAgeD) || ' ' || p.PAgeU As PAge,
//                                        t.testid,
//                                        t.Test,
//                                        p.PType As Type,
//                                        p.ServiceNo,
//                                        d.ProcessID,
//                                        p.WardName,
//                                        m.LabID,
//                                        t.TestType,
//                                        case
//                                            when p.PageU = 'Y' then
//                                            p.PageD
//                                            else
//                                            1
//                                        end as Cal_Age,
//                                        to_char(d.deliverydate,'dd/mm/yyyy hh:mi:ss am') deliverydate,
//                                        to_char(d.EnteredAte,'dd/mm/yyyy hh:mi:ss am') enteredate,
//                                        case
//                                            when (((d.DeliveryDate - d.EnteredAte) * 1440)) >= 1440 then
//                                            concat(to_char(Round(d.deliverydate - d.EnteredAte)),
//                                                    ' days')
//                                            when ((d.DeliveryDate - d.EnteredAte) * 1440) < 1440 and
//                                                ((d.DeliveryDate - d.EnteredAte) * 1440) > 60 then
//                                            concat(to_char(Round((d.DeliveryDate - d.Enteredate) * 60)),
//                                                    ' hour(s)')
//                                            else
//                                            to_char((d.Deliverydate - d.EnteredAte) * 1440)
//                                        end As timedidff,
//                                        case
//                                            when (d.DeliveryDate - sysdate) <= 0 then
//                                            case
//                                                when ((d.DeliveryDate - sysdate) * -1440 >= 1440) then
//                                                'OverDue by(' ||
//                                                to_char(Round(- (d.DeliveryDate - sysdate))) || ' days)'
//                                                when (((d.DeliveryDate - sysdate) * -1440) < 1440 and
//                                                    ((d.DeliveryDate - sysdate) * -1440) > 60) then
//                                                'OverDue by(' ||
//                                                to_char(Round((d.DeliveryDate - sysdate) * -60)) ||
//                                                ' hour(s))'
//                                                else
//                                                'OverDue by(' ||
//                                                to_char(Round(d.Deliverydate - sysdate) * -1440) || ')'
//                                            end
//                                            else
//                                            case
//                                                when ((d.DeliveryDate - sysdate) * 1440) >= 1440 then
//                                                concat(to_char(Round(d.deliverydate - sysdate)), ' days')
//                                                when (((d.DeliveryDate - sysdate) * 1440) < 1440 and
//                                                    ((d.DeliveryDate - sysdate) * 1440) > 60) then
//                                                concat(to_char(Round((d.DeliveryDate - sysdate) * 60)),
//                                                        ' hour(s)')
//                                                else
//                                                to_char((d.Deliverydate - sysdate) * 1440)
//                                            end
//                                        end as TimeLeft
//
//                            from LS_tMTransaction m, LS_tDTransaction d, LS_vPatient p, LS_TTest t
//                            Where m.MSerialNo = p.MSerialNo
//                            And m.MSerialNo = d.MSerialNo
//                            And m.MStatus = 'A'
//                            And d.TestID = t.TestID
//                            And d.ProcessID in ('0004', '0005')" + @" 
//                            " +sSectionID+sPRNo+sPatientName+sDSerialNo+sMSerialNo+sMSerialNoFrom+sMSerialNoTo+sLabIDFrom+sLabIDTo+sWardID+sTestGroupID+sdaterange+@" 
// 
//                            Order By m.LabID";
              
                    //m.MStatus not in ('C') => m.MStatus = 'A' :070303 
						
						/*Select Distinct m.Priority, m.MSerialNo, d.DSerialNo, p.PFName As PatientName, p.PSex, To_Char(p.PAgeD)||p.PAgeU As PAge, m.Type,  p.ServiceNo from  LS_tMTransaction m,  LS_tDTransaction d, LS_vPatient p  Where m.MSerialNo = p.MSerialNo And m.MSerialNo = d.MSerialNo  And d.ProcessID = '" + cProcessID + "' And d.SectionID = '" + StrSectionID + "' Order By m.MSerialNo";*/
					break;
                case 2:
                    objdbhims.Query = @"Select d.NotificationID, c.Comment_Desc || ' by <font color=blue>' || nvl(p.fname,'') || nvl(p.mname,'') || nvl(p.lname,'') || '</font>'  Notifications
                                          From ls_tshiftComments c Inner join ls_tshiftNotificationsd d on d.CommentId=c.commentid
                                            Inner join whims2.hr_Tpersonnel p on p.personId=c.enteredBy
                                         where d.new <>'N'
                                           and d.personID = '"+StrPersonID+"'";
                    break;
                case 3:
                    objdbhims.Query = @"Select tp.Personid,tp.fname||' '||tp.mname||' '||tp.lname|| ' '||tp.salutation as Name From whims2.Hr_Tpersonnel tp where tp.Active='Y' and tp.DepartmentiD='011' and tp.personid!='"+StrPersonID+"'";//List of Laboratory Persons excluding myself(the user logged in)
                    break;
            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }

        public bool Insert()
        {
            if (Validation())
            {
                try
                {
                    QueryBuilder objQB = new QueryBuilder();

                    objTrans.Start_Transaction();

                    //objdbhims.Query = objQB.QBGetMax("CommentID", TableName,"4");
                    objdbhims.Query = @"Select NVL(max(Commentid),0)+1 as MaxID From ls_tshiftcomments";
                    this.StrCommentID = objTrans.DataTrigger_Get_Max(objdbhims);


                    if (this.StrCommentID.Equals("True"))
                    {
                        this.StrErrorMessage = objTrans.OperationError;
                        objTrans.End_Transaction();
                        return false;
                    }
                    objdbhims.Query = objQB.QBInsert(MakeArray(), TableName);
                    this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                    if (this.StrErrorMessage.Equals("True"))
                    {
                        objTrans.End_Transaction();
                        this.StrErrorMessage = objTrans.OperationError;
                        return false;
                    }
                    for (int i = 0; i < strpersonIds.Length; i++)
                    {
                        objdbhims.Query = objQB.QBGetMax("NotificationID", "LS_TSHIFTNOTIFICATIONSD", "10");
                        this.NotificationID = objTrans.DataTrigger_Get_Max(objdbhims);
                        if (StrNotificationID.Equals("True"))
                        {
                            objTrans.End_Transaction();
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
                        this.PersonID = strpersonIds[i];
                        objdbhims.Query = objQB.QBInsert(MakeArrayD(), "LS_TSHIFTNOTIFICATIONSD");
                        this.StrErrorMessage = objTrans.DataTrigger_Insert(objdbhims);
                        if (this.StrErrorMessage.Equals("True"))
                        {
                            objTrans.End_Transaction();
                            this.StrErrorMessage = objTrans.OperationError;
                            return false;
                        }
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
            else
            {
                return false;
            }
        }

        public bool updateNewNotifications()
        {
            clsoperation objTrans = new clsoperation();
            objdbhims.Query = "Update  ls_tshiftnotificationsd set new='N' where NotificationID=" + Convert.ToInt32(StrNotificationID);
            objTrans.Start_Transaction();
            this.StrErrorMessage = objTrans.DataTrigger_Update(objdbhims);
            if (this.StrErrorMessage.Equals("True"))
            {
                objTrans.End_Transaction();
                this.StrErrorMessage = objTrans.OperationError;
                return false;
            }
            objTrans.End_Transaction();
            return true;
        }

        private string[,] MakeArray()
        {
            string[,] aryLIMS = new string[6, 3];

            if (!this.StrCommentID.Equals(Default))
            {
                aryLIMS[0, 0] = "CommentID";
                aryLIMS[0, 1] = this.StrCommentID;
                aryLIMS[0, 2] = "int";
            }

            if (!this.StrComment_Desc.Equals(Default))
            {
                aryLIMS[1, 0] = "Comment_Desc";
                aryLIMS[1, 1] = this.StrComment_Desc;
                aryLIMS[1, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryLIMS[2, 0] = "EnteredOn";
                aryLIMS[2, 1] = this.StrEnteredOn;
                aryLIMS[2, 2] = "date";
            }
            if (!this.StrEnteredBy.Equals(Default))
            {
                aryLIMS[3, 0] = "enteredby";
                aryLIMS[3, 1] = this.StrEnteredBy;
                aryLIMS[3, 2] = "string";
            }
            if (!this.StrClientID.Equals(Default))
            {
                aryLIMS[4, 0] = "ClientID";
                aryLIMS[4, 1] = this.StrClientID;
                aryLIMS[4, 2] = "string";
            }
            if (!this.StrSystem_Ip.Equals(Default))
            {
                aryLIMS[5, 0] = "System_Ip";
                aryLIMS[5, 1] = this.StrSystem_Ip;
                aryLIMS[5, 2] = "string";
            }
          

            return aryLIMS;
        }
        private string[,] MakeArrayD()
        {
            string[,] aryLIMS = new string[5, 3];

            if (!this.StrNotificationID.Equals(Default))
            {
                aryLIMS[0, 0] = "NotificationID";
                aryLIMS[0, 1] = this.StrNotificationID;
                aryLIMS[0, 2] = "int";
            }

            if (!this.StrPersonID.Equals(Default))
            {
                aryLIMS[1, 0] = "personID";
                aryLIMS[1, 1] = this.StrPersonID;
                aryLIMS[1, 2] = "string";
            }
            if (!this.StrEnteredOn.Equals(Default))
            {
                aryLIMS[2, 0] = "EnteredOn";
                aryLIMS[2, 1] = this.StrEnteredOn;
                aryLIMS[2, 2] = "date";
            }
            if (!this.StrCommentID.Equals(Default))
            {
                aryLIMS[3, 0] = "CommentiD";
                aryLIMS[3, 1] = this.StrCommentID;
                aryLIMS[3, 2] = "int";
            }
            
           

            if (!this.StrNew.Equals(Default))
            {
                aryLIMS[4, 0] = "New";
                aryLIMS[4, 1] = this.StrNew;
                aryLIMS[4, 2] = "string";
            }

            return aryLIMS;
        }
        private bool Validation()
        {
            return true;
        }
        #endregion
    }
}
