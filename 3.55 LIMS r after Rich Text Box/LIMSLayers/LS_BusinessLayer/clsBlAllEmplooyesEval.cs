using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using LS_DataLayer;

namespace LS_BusinessLayer
{
    public class clsBlAllEmplooyesEval
    {
        public clsBlAllEmplooyesEval()
        {
            ///Add Constructor logic here...
        }
        #region Variables
        private const string Default="~!@";
        private string StrEnteredBy = Default;
        private string StrFromDate = Default;
        private string StrStarttime = Default;
        private string StrEndTime = Default;
        private string StrEndDate = Default;
        #endregion
        clsdbhims objdbhims = new clsdbhims();
        clsoperation objTrans = new clsoperation();
        #region Properties
        public string EndTime
        {
            get { return StrEndTime; }
            set { StrEndTime = value; }
        }
        public string Starttime
        {
            get { return StrStarttime; }
            set { StrStarttime = value; }
        }
        public string EnteredBy
        {
            get { return StrEnteredBy; }
            set { StrEnteredBy = value; }
        }
        public string FromDate
        {
            get { return StrFromDate; }
            set { StrFromDate = value; }
        }
        public string EndDate
        {
            get { return StrEndDate; }
            set { StrEndDate = value; }
        }
        #endregion

        #region Methods
        public DataView GetAll(int flag)
        {
            switch (flag)
            {
                case 1:
                    objdbhims.Query = "Select * From LS_TTestResultM where EnteredBy !=' ' and EvaluatedBy !=' ' and EnteredBy='"+StrEnteredBy+"'";
                    break;
                case 2:
                    objdbhims.Query = "Select Salutation||' '||fname||' '||mname||' '||lname as EmployeeName From whims2.HR_TPersonnel where Active='Y' and PersonID='"+StrEnteredBy+"'";
                    break;
                case 3:
                    objdbhims.Query = "Select Distinct EnteredBy From LS_TTestResultM where EnteredBy!=' ' and EvaluatedBy!=' '";
                    break;
                case 4:
                    objdbhims.Query = "SELECT Count(EnteredBy) as Total,EnteredBy From LS_TTestResultM where EnteredBy!=' ' and EvaluatedBy!=' ' group by EnteredBy";
                    break;
                case 5:/*Total Results Entered By the Technicians*/
                    objdbhims.Query = @"Select tm.Enteredby,
                                           count(tm.DSerialNo) as NumberOFTestsEntered,
                                           nvl(tp.salutation,'') || nvl(tp.fname,'') || ' ' || nvl(tp.mname,'') || ' ' || nvl(tp.lname,'') as EmployeeName
                                      From Ls_ttestResultm tm, whims2.Hr_TPersonnel tp
                                     where tp.PersonID = tm.Enteredby
                                       and tm.EnteredBy is not null
                    
                                       and to_date(to_char(tm.Enteredon,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate+@"', 'dd/mm/yyyy') and
                                           to_date('"+StrEndDate+@"', 'dd/mm/yyyy')";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(tm.Enteredon,'hh24:mi:ss am') between '"+StrStarttime+"' and '"+StrEndTime+"'";
                    }
                    if(!StrEnteredBy.Equals(Default))
                    {
                        objdbhims.Query+=" and tm.EnteredBy='"+StrEnteredBy+"'";
                    }

                    objdbhims.Query+=" group by tm.Enteredby, tp.salutation, tp.fname, tp.lname,tp.mname";
                    break;
                case 6:/*Test Entry Details*/
                    objdbhims.Query = @"Select t.Test, m.testid, count(m.testid) TestEntryTimes
                                        From ls_TTestresultm m, ls_ttest t
                                        where t.TestID = m.TestID
                                        and m.Enteredby = '"+StrEnteredBy+@"'
                                        and to_date(to_char(m.Enteredon,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate + @"', 'dd/mm/yyyy') and
                                            to_date('" + StrEndDate + @"', 'dd/mm/yyyy')";
                     if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(m.Enteredon,'hh24:mi:ss am') between '"+StrStarttime+"' and '"+StrEndTime+"'";
                    }
                     objdbhims.Query+=@"  group by m.testid, t.Test
                                        order by TestEntryTimes desc";
                    break;
                case 7:/*Specimen Collected By and its count*/
                    objdbhims.Query = @"Select tm.SpecimenCollectedBy EnteredBy,
                                        count(tm.DSerialNo) as NumberOFTestsEntered,
                                        nvl(tp.salutation,'') || nvl(tp.fname,'') || ' ' || nvl(tp.mname,'') || ' ' || nvl(tp.lname,'') as EmployeeName
                                    From ls_tdtransaction tm, whims2.Hr_TPersonnel tp
                                    where tp.PersonID = tm.SpecimenCollectedBy
                                    and tm.SpecimenCollectedBy is not null
                                    and to_date(to_char(tm.SpecimenCollectedOn,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate + @"', 'dd/mm/yyyy') and
                                        to_date('" +StrEndDate+@"', 'dd/mm/yyyy')";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(tm.SpecimenCollectedon,'hh24:mi:ss am') between '" + StrStarttime + "' and '" + StrEndTime + "'";
                    }
                    if(!StrEnteredBy.Equals(Default))
                    {
                        objdbhims.Query+=" and tm.SpecimenCollectedBy='"+StrEnteredBy+"'";
                    }
                    objdbhims.Query+=@"  group by tm.SpecimenCollectedBy,
                                            tp.salutation,
                                            tp.fname,tp.mname,
                                            tp.lname";
                    break;
                    
                case 8:/*Specimenn Collection Details*/
                    objdbhims.Query = @"Select t.Test, m.testid, count(m.testid) TestEntryTimes
                                          From Ls_Tdtransaction m, ls_ttest t
                                         where t.TestID = m.TestID
                                           and m.SpecimenCollectedBy = '" +StrEnteredBy+@"'
                                           and to_date(to_char(m.SpecimenCollectedOn,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+StrFromDate+@"', 'dd/mm/yyyy') and
                                               to_date('"+StrEndDate+@"', 'dd/mm/yyyy')";
                     if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(m.SpecimenCollectedOn,'hh24:mi:ss am') between '"+StrStarttime+"' and '"+StrEndTime+"'";
                    }
                                   objdbhims.Query +=@" group by m.testid, t.Test
                                         order by TestEntryTimes desc";
                    break;
                case 9:/*Total Tests Verified by a Personnel*/
                    objdbhims.Query = @"Select tm.EvaluatedBy EnteredBy,
                                           count(tm.DSerialNo) as NumberOFTestsEntered,
                                           nvl(tp.salutation,'') || nvl(tp.fname,'') || ' ' || nvl(tp.mname,'') || ' ' || nvl(tp.lname,'') as EmployeeName
                                      From Ls_ttestResultm tm, whims2.Hr_TPersonnel tp
                                     where tp.PersonID = tm.EvaluatedBy
                                       and tm.EvaluatedBy is not null
                                       and to_date(to_char(tm.EvaluatedOn,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate+@"', 'dd/mm/yyyy') and
                                           to_date('"+StrEndDate+@"', 'dd/mm/yyyy')";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(tm.EvaluatedOn,'hh24:mi:ss am') between '" + StrStarttime + "' and '" + StrEndTime + "'";
                    }
                    if(!StrEnteredBy.Equals(Default))
                    {
                        objdbhims.Query+=" and tm.EvaluatedBy='"+StrEnteredBy+"'";
                    }
                    objdbhims.Query+=@" group by tm.EvaluatedBy, tp.salutation, tp.fname, tp.lname,tp.mname";
                    break;
                case 10:/*Test Verification Details*/
                    objdbhims.Query = @"Select t.Test, m.testid, count(m.testid) TestEntryTimes
                                        From ls_TTestresultm m, ls_ttest t
                                        where t.TestID = m.TestID
                                        and m.EvaluatedBy = '" +StrEnteredBy+@"'
                                        and to_date(to_char(m.EvaluatedOn,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+@StrFromDate+@"', 'dd/mm/yyyy') and
                                            to_date('"+StrEndDate+@"', 'dd/mm/yyyy')";
                     if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(m.EvaluatedOn,'hh24:mi:ss am') between '"+StrStarttime+"' and '"+StrEndTime+"'";
                    }
                    objdbhims.Query+=@" group by m.testid, t.Test
                                        order by TestEntryTimes desc";
                    break;
                case 11:/*Test Processes for Employees Evaluation Drop Down List*/
                    objdbhims.Query = @"Select distinct ProcessID,Process From ls_ttestprocess where Active='Y' and processid in('0002','0004','0005')";
                    break;
                case 12:
                    objdbhims.Query = @"Select 'Entry' as Process,count(tm.DSerialNo) as NumberOFTests
                                          
                                      From Ls_ttestResultm tm, whims2.Hr_TPersonnel tp
                                     where tp.PersonID = tm.Enteredby
                                       and tm.EnteredBy is not null
                    
                                       and to_date(to_char(tm.Enteredon,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('"+StrFromDate+@"', 'dd/mm/yyyy') and
                                           to_date('"+StrEndDate+@"', 'dd/mm/yyyy') and tm.EnteredBy='"+StrEnteredBy+@"'";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += " and to_char(tm.Enteredon,'hh24:mi:ss am') between '" + StrStarttime + "' and '" + StrEndTime + "'";
                    }
                     objdbhims.Query+=@" group by tm.Enteredby, tp.salutation, tp.fname, tp.lname
Union
Select 'Specimen' as Process,
                                        count(tm.DSerialNo) as NumberOFTests
                                        
                                    From ls_tdtransaction tm, whims2.Hr_TPersonnel tp
                                    where tp.PersonID = tm.SpecimenCollectedBy
                                    and tm.SpecimenCollectedBy is not null
                                    and to_date(to_char(tm.SpecimenCollectedon,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate + @"', 'dd/mm/yyyy') and
                                        to_date('" + StrEndDate + @"', 'dd/mm/yyyy') and tm.SpecimenCollectedBy='" + StrEnteredBy + @"'";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += "  and to_char(tm.SpecimenCollectedon,'hh24:mi:ss am') between '" + StrStarttime + "' and '" + StrEndTime + "'";
                    }
                         objdbhims.Query+=@"  group by tm.SpecimenCollectedBy,
                                            tp.salutation,
                                            tp.fname,
                                            tp.lname
Union
Select 'Verification' as Process,count(tm.DSerialNo) as NumberOFTests
                                          
                                      From Ls_ttestResultm tm, whims2.Hr_TPersonnel tp
                                     where tp.PersonID = tm.EvaluatedBy
                                       and tm.EvaluatedBy is not null
                                       and to_date(to_char(tm.EvaluatedOn,'dd/mm/yyyy'),'dd/mm/yyyy') between to_date('" + StrFromDate + @"', 'dd/mm/yyyy') and
                                           to_date('" + StrEndDate + @"', 'dd/mm/yyyy') and tm.EvaluatedBy='" + StrEnteredBy + @"'";
                    if (!StrStarttime.Equals(Default))
                    {
                        objdbhims.Query += " and to_char(tm.EvaluatedOn,'hh24:mi:ss am') between '" + StrStarttime + "' and '" + StrEndTime + "'";
                    }
                    objdbhims.Query+=@"group by tm.EvaluatedBy, tp.salutation, tp.fname, tp.lname";
                    break;


            }
            return objTrans.DataTrigger_Get_All(objdbhims);
        }
        #endregion

    }
}
