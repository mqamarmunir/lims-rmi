using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using System.Globalization;

namespace HMIS.LIMS.WebForms
{
	/// <summary>
	/// Summary description for wfrmSpecimenCollectionDetail.
	/// </summary>
    public partial class wfrmSpecimenCollectionDetail : System.Web.UI.Page
    {

        private string mSerialNo;
        private string labid;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsPostBack)
                {
                    mSerialNo = Request.QueryString.Get("mserialno");
                    labid = Request.QueryString.Get("labid");
                    lblSpecimen.Text = Request.QueryString.Get("Specimen");
                    LblMSerialNo.Text = mSerialNo;
                    LbLabID.Text = labid;
                    
                    FillDG();
                    pnl_cmt.Visible = false;
                }
            }
            else
            {
                Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGPatientStatus.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DGPatientStatus_ItemCreated);
            this.DGPatientStatus.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DGPatientStatus_ItemCommand);

        }
        #endregion


        private void FillDG()
        {

            try
            {
                clsBLSpecimenCollectionDetail SpecimenCollectionDetail = new clsBLSpecimenCollectionDetail();
                DataView dv = SpecimenCollectionDetail.GetPendingSpecimen(LblMSerialNo.Text, lblSpecimen.Text);
                DGPatientStatus.DataSource = dv;
                DGPatientStatus.DataBind();

                LblMSerialNo.Text = dv[0]["MSerialno"].ToString();
                LblPatientName.Text = dv[0]["PatientName"].ToString();
                LblAge.Text = dv[0]["Age"].ToString();
                lblPrno.Text = dv[0]["prno"].ToString().Trim();
                lblWard.Text = dv[0]["Wardname"].ToString().Trim();
                DGPatientStatus.Visible = true;
            }
            catch
            {
                Response.Write("<script language='javascript'>self.close();</script>");
            }
        }



        private void DGPatientStatus_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            if (e.CommandName.Equals("Collect"))
            {
               // string time_type = "";
                string travel_time = "";
                clsBLSpecimenColletion objTSpecimenColletion = new clsBLSpecimenColletion();

                objTSpecimenColletion.DSerialNo = e.Item.Cells[0].Text;
                if (Request.QueryString["IOP"].ToString().Trim() == "I")
                {
                    clsBLTest objtest = new clsBLTest();
                    objtest.TestID = e.Item.Cells[9].Text.Trim();
                    DataView dv_testinfo = objtest.GetAll(15);
                    //time_type=dv_testinfo[0]["time_type"].ToString();
                    travel_time = dv_testinfo[0]["traveltime"].ToString().Trim();
                    string ProcedureId = dv_testinfo[0]["Procedureid"].ToString().Trim();
                     objTSpecimenColletion.ProcedureID = ProcedureId;
                    if (dv_testinfo[0]["External"].ToString().Trim() == "Y")
                    {
                        objTSpecimenColletion.TestCost = dv_testinfo[0]["TestCost"].ToString().Trim();
                        objTSpecimenColletion.Extorgid = dv_testinfo[0]["external_orgid"].ToString().Trim();
                    }
                }
                else
                {
                    objTSpecimenColletion.ProcedureID = e.Item.Cells[5].Text;
                }
                objTSpecimenColletion.SpecimenCollectedBy = Session["loginid"].ToString().Trim();
                objTSpecimenColletion.SpecimenCollectedOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                bool isSuccessful = objTSpecimenColletion.Update();

                try
                {
                    clsBLTransHistory objTTransHistory = new clsBLTransHistory();

                    objTTransHistory.MSERIALNO = LblMSerialNo.Text;
                    objTTransHistory.DSERIALNO = e.Item.Cells[0].Text;
                    objTTransHistory.PROCESSID = "0002";
                    objTTransHistory.PERSONID = Session["loginid"].ToString();
                    objTTransHistory.Insert();
                }
                catch { };
                try
                {
                    if (Request.QueryString["IOP"].ToString().Trim() == "I")
                    {
                        string testid = e.Item.Cells[9].Text.Trim();
                        string RoundDelivery = e.Item.Cells[10].Text.Trim();
                        if (UpdateDeliveryDateTime(testid, e.Item.Cells[0].Text.Trim()/*DSerial No*/, RoundDelivery,travel_time))
                        {
                            ///Add Code here if update successful
                        }
                        else
                        {
                            ///Add Error Display code here...
                        }

                    }
                    else
                    {
                        string testid = e.Item.Cells[9].Text.Trim();
                        string DserialNo = e.Item.Cells[0].Text.Trim();
                        clsBLTest objTest = new clsBLTest();
                        objTest.TestID = testid;
                        DataView dv_method = objTest.GetAll(8);
                        PatientRegView obj_patreg = new PatientRegView();
                        obj_patreg.DSerialNo = DserialNo;
                        obj_patreg.MethodId = dv_method[0]["methodid"].ToString().Trim();
                        if (!obj_patreg.Updatemethodid_outp())
                        {
                            ///Add unssuccesful code here...
                        }
                        else
                        {
                            ///Add successful code here...
                        }
                        
                    }

                   
                }

                catch 
                {

                }
                FillDG();
            }
            else if (e.CommandName.Equals("comment"))
            {

                lblDserial_Cmt.Text = e.Item.Cells[0].Text;
                lblTest_Cmt.Text = e.Item.Cells[3].Text;
                txtComment.Text = e.Item.Cells[6].Text.Trim().Replace("&nbsp;","");
                DGPatientStatus.Visible = false;
                ibtnSave.Visible = false;
                pnl_cmt.Visible = true;
            }

            else if (e.CommandName == "History")
            {
                string PRNo = e.Item.Cells[12].Text;
                string testid = e.Item.Cells[9].Text;
                string labid = Request.QueryString["labid"].ToString().Trim();
                Response.Write("<script language='javascript'>window.open('wfrmhistoryTaking.aspx?labid=" + labid + "&testid=" + testid + "&PRNo=" + PRNo + "');</script>");
            }
            else if (e.CommandName == "SOPs")
            {
                string testid = e.Item.Cells[9].Text;
                
                 Response.Write("<script language = 'javascript'>window.open('wfrmSOPresultge.aspx?id=0002&TestID=" + testid + "&Tag=" + "GS" + "','','channelmode,scrollbars')</script>");
                
            }
        }

        private bool UpdateDeliveryDateTime(string testid,string DSerialNo,string RoundDelivery,string Travel_Time)
        {
            string Delivery_Date = "";
            #region getting nearest Delivery Time
            int addhours = 0;
            string batchtime = "";
            string ReportingTime = "";
            string External_Orgid = "0";
            string cutoffday = "0";
            clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
            obj_Schedule.TestID = testid;
            clsBLTest obj_Test = new clsBLTest();
            obj_Test.TestID = testid;
            DataView dv_method = obj_Test.GetAll(8);
            batchtime = dv_method[0]["batchtime"].ToString().Trim();
            ReportingTime = dv_method[0]["ReportingTime"].ToString().Trim();
            cutoffday = dv_method[0]["cutoffday"].ToString().Trim();
            External_Orgid = dv_method[0]["External_orgid"].ToString().Trim();
            #region Getting Time According to the test Performing Schedule
            DataView dv = obj_Schedule.GetAll(1);
            int[] performingdays_array = new int[dv.Count];
            int[,] performing_days_weekly = new int[dv.Count, 2];

            if (dv.Count > 0)
            {
                if (dv[0]["Type"].ToString().Trim() == "Days")
                {
                    performingdays_array = performingdays(dv);
                    string todayis = System.DateTime.Now.DayOfWeek.ToString().Trim();
                    int gettodaynum = gettoday(todayis);
                    int daystoadd = getminimumdiff(performingdays_array, gettodaynum, batchtime);
                    if (daystoadd < 8)
                    {
                        Delivery_Date = System.DateTime.Now.AddHours(24 * daystoadd).ToString("dd/MM/yyyy") + " " + batchtime;
                    }
                }
                #region old
                //else if (dv[0]["Type"].ToString().Trim() == "Weekly")
                //{
                //    //performing_days_weekly = performingdays_weekly(dv);
                //    //string todayis = System.DateTime.Now.DayOfWeek.ToString().Trim();
                //    //int gettodaynum = gettoday(todayis);
                //    //int date_today = Convert.ToInt32(System.DateTime.Now.Day);
                //    //int getcurrentweek_num = getcurrentweek(date_today);
                //    //if (getcurrentweek_num != 0)
                //    //{
                //    //    int daystoadd = getnumberofdays(performing_days_weekly, getcurrentweek_num, gettodaynum,date_today);
                //    //    Delivery_Date = System.DateTime.Now.AddHours(24 * daystoadd + 6).ToString("dd/MM/yyyy hh:mm:ss tt");
                //    //}
                //    string[] performingdates = dates(dv, Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year));
                //    string date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                //    string D_Date = getnextcomingdate(performingdates, date_today);
                //    if (D_Date != "")
                //    {
                //        // Delivery_Date = D_Date;
                //        DateTime dt_addhours = DateTime.Parse(D_Date, new CultureInfo("en-GB", false));
                //        string currenttime = DateTime.Now.ToString("HH:mm:ss");
                //        //DateTime dt_currenttime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss tt"));
                //        dt_addhours = dt_addhours + TimeSpan.Parse(currenttime);
                //        dt_addhours = dt_addhours.AddHours(addhours);
                //        Delivery_Date = dt_addhours.ToString("dd/MM/yyyy hh:mm:ss tt");
                //    }
                //    else
                //    {
                //        DateTime datenextmonth = DateTime.Now.AddMonths(1);
                //        //datenextmonth.AddMonths(1);
                //        int month = Convert.ToInt32(datenextmonth.Month);
                //        string _date = getnextmonthdate(dv, month, Convert.ToInt32(datenextmonth.Year));

                //        DateTime dt_addhours = DateTime.Parse(_date, new CultureInfo("en-GB", false));
                //        string currenttime = DateTime.Now.ToString("HH:mm:ss");
                //        //DateTime dt_currenttime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss tt"));
                //        dt_addhours = dt_addhours + TimeSpan.Parse(currenttime);
                //        dt_addhours = dt_addhours.AddHours(addhours);
                //        Delivery_Date = dt_addhours.ToString("dd/MM/yyyy hh:mm:ss tt");
                //    }

                //}
                #endregion
                #region new
                else if (dv[0]["Type"].ToString().Trim() == "Weekly")
                {
                    int todaynum = gettoday(System.DateTime.Now.DayOfWeek.ToString());
                    //performing_days_weekly = performingdays_weekly(dv);
                    //string todayis = System.DateTime.Now.DayOfWeek.ToString().Trim();
                    //int gettodaynum = gettoday(todayis);
                    //int date_today = Convert.ToInt32(System.DateTime.Now.Day);
                    //int getcurrentweek_num = getcurrentweek(date_today);
                    //if (getcurrentweek_num != 0)
                    //{
                    //    int daystoadd = getnumberofdays(performing_days_weekly, getcurrentweek_num, gettodaynum,date_today);
                    //    Delivery_Date = System.DateTime.Now.AddHours(24 * daystoadd + 6).ToString("dd/MM/yyyy hh:mm:ss tt");
                    //}
                    string[] performingdates = dates(dv, Convert.ToInt32(DateTime.Now.Month), Convert.ToInt32(DateTime.Now.Year));
                    string date_today = "";
                    if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(cutoffday)) || (todaynum != Convert.ToInt16(cutoffday) && External_Orgid != "0" && !istodayperformingday(performingdates)))
                    {
                        date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        try
                        {

                            date_today = DateTime.Now.AddDays(Convert.ToInt16(Travel_Time) / (60 * 24)).ToString("dd/MM/yyyy");
                        }
                        catch
                        {
                            date_today = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
                        }
                    }
                    string D_Date = getnextcomingdate(performingdates, date_today);
                    if (D_Date != "")
                    {
                        // Delivery_Date = D_Date;
                        DateTime dt_addhours = DateTime.Parse(D_Date, new CultureInfo("en-GB", false));
                        string currenttime = DateTime.Now.ToString("HH:mm:ss");
                        //DateTime dt_currenttime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss tt"));
                        dt_addhours = dt_addhours + TimeSpan.Parse(currenttime);
                        dt_addhours = dt_addhours.AddHours(addhours);
                        Delivery_Date = dt_addhours.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                    else
                    {
                        DateTime datenextmonth = DateTime.Now.AddMonths(1);
                        //datenextmonth.AddMonths(1);
                        int month = Convert.ToInt32(datenextmonth.Month);
                        string _date = getnextmonthdate(dv, month, Convert.ToInt32(datenextmonth.Year));

                        DateTime dt_addhours = DateTime.Parse(_date, new CultureInfo("en-GB", false));
                        string currenttime = DateTime.Now.ToString("HH:mm:ss");
                        //DateTime dt_currenttime = DateTime.Parse(DateTime.Now.ToString("hh:mm:ss tt"));
                        dt_addhours = dt_addhours + TimeSpan.Parse(currenttime);
                        dt_addhours = dt_addhours.AddHours(addhours);
                        Delivery_Date = dt_addhours.ToString("dd/MM/yyyy hh:mm:ss tt");
                    }

                }
                #endregion
                else// if (dv[0]["Type"].ToString().Trim() == "Daily")
                {
                    Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                }

            }

            else
            {
                Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");

            }

            #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
            if (RoundDelivery == "N")
            {
                if ((DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)) > DateTime.Parse(Delivery_Date.Substring(0, 10) + " 05:00:00 pm", new CultureInfo("en-GB", false)) && DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)) <= DateTime.Parse(Delivery_Date.Substring(0, 10) + " 11:59:59 pm", new CultureInfo("en-GB", false))))
                {
                    string temp_date = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).AddDays(1).ToString("dd/MM/yyyy");
                    int noofminutes = Convert.ToInt32((DateTime.Parse(temp_date + " 09:00:00 am", new CultureInfo("en-GB", false)) - DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false))).TotalMinutes);
                    Delivery_Date = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).AddMinutes(noofminutes + 30).ToString("dd/MM/yyyy hh:mm:ss tt");
                }
                else if ((DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)) >= DateTime.Parse(Delivery_Date.Substring(0, 10) + " 12:00:00 am", new CultureInfo("en-GB", false)) && DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)) <= DateTime.Parse(Delivery_Date.Substring(0, 10) + " 09:00:00 am", new CultureInfo("en-GB", false))))
                {
                    Delivery_Date = Delivery_Date.Substring(0, 10) + " 09:30:00 am";
                }

            }
            #endregion

            
           

            #region Adding Method TIme
            ////////////////////////////////////////Adding Hours of Method//////////////////////////////////
            if (dv_method.Count > 0)
            {
                addhours = 0;
                //method_id=dv_method[0]["MethodID"].ToString();
                if (dv_method[0]["TAT"].ToString() == "D")
                {
                    //if (rdoUrgent.Checked == true)
                    //{
                    //    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                    //}
                    //else
                    //{
                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                    // }
                    addhours = addhours * 24;
                }
                else if (dv_method[0]["TAT"].ToString() == "H")
                {
                    //if (rdoUrgent.Checked == true)
                    //{
                    //    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                    //}
                    //else
                    //{
                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                    // }
                }
                else if (dv_method[0]["TAT"].ToString() == "W")
                {
                    //if (rdoUrgent.Checked == true)
                    //{
                    //    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                    //}
                    //else
                    //{
                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                    // }
                    addhours = addhours * 24;
                    addhours = addhours * 7;

                }
                else
                    addhours = 0;

                Delivery_Date = DateTime.Parse(Delivery_Date, new CultureInfo("ur-pk", false)).AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            else
            {
                Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
            }
            ////////////////////////////////////////////-------------------------////////////////////////////////////////
            #endregion

            #endregion


            DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
            if (Travel_Time != "0")
            {
                _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(Travel_Time));

            }
            TimeSpan rounded = roundto30(_deliverydate.ToString("HH:mm"));
            if (rounded.Days > 0)
            {
                Delivery_Date = _deliverydate.AddDays(rounded.Days).ToString("dd/MM/yyyy") + " " + rounded.ToString().Substring(2);

            }
            else
            {
                Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + rounded.ToString();
            }

            if (Travel_Time != "0" && ReportingTime!="" && ReportingTime!=null)
                {
                    if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(ReportingTime))
                    {
                        _deliverydate = _deliverydate.AddDays(1);
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(ReportingTime).ToString();
                    }
                    else
                    {
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(ReportingTime).ToString();
                    }
                }
            #endregion
            #region Update Database
            PatientRegView prv=new PatientRegView();
            prv.DeliveryDate=DateTime.Parse(Delivery_Date,new CultureInfo("ur-pk",false)).ToString("dd/MM/yyyy hh:mm:ss tt");
            prv.DSerialNo = DSerialNo;
            prv.MethodId = dv_method[0]["methodid"].ToString().Trim();
            if (prv.UpdateDeliverydateforinpatients())
            {
                return true;
            }
            else
            {
              
                return false;
            }
            #endregion

        }

        private bool istodayperformingday(string[] performingdates)
        {
            for (int i = 0; i < performingdates.Length; i++)
            {
                if (System.DateTime.Now.ToString("dd/MM/yyyy") == performingdates[i])
                {
                    return true;
                }
            }
            return false;

        }
        #region Delivery Date And Time Functions
        private int[] performingdays(DataView dv)
        {
            int[] performingdays_array = new int[dv.Count];
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["Value"].ToString().Trim() == "Monday")
                {
                    performingdays_array[i] = 1;
                }
                if (dv[i]["Value"].ToString().Trim() == "Tuesday")
                {
                    performingdays_array[i] = 2;
                }
                if (dv[i]["Value"].ToString().Trim() == "Wednesday")
                {
                    performingdays_array[i] = 3;
                }
                if (dv[i]["Value"].ToString().Trim() == "Thursday")
                {
                    performingdays_array[i] = 4;
                }
                if (dv[i]["Value"].ToString().Trim() == "Friday")
                {
                    performingdays_array[i] = 5;
                }
                if (dv[i]["Value"].ToString().Trim() == "Saturday")
                {
                    performingdays_array[i] = 6;
                }
                if (dv[i]["Value"].ToString().Trim() == "Sunday")
                {
                    performingdays_array[i] = 7;
                }

            }
            return performingdays_array;

        }
        private int gettoday(string todayis)
        {
            int today = 0;
            switch (todayis)
            {
                case "Monday":
                    today = 1;
                    break;
                case "Tuesday":
                    today = 2;
                    break;
                case "Wednesday":
                    today = 3;
                    break;
                case "Thursday":
                    today = 4;
                    break;
                case "Friday":
                    today = 5;
                    break;
                case "Saturday":
                    today = 6;
                    break;
                case "Sunday":
                    today = 7;
                    break;
            }
            return today;
        }
        private int getminimumdiff(int[] arrayperform, int today, string batchtime)
        {
            int getminimum = 7;
            int getminimumminus = 0;
            for (int i = 0; i < arrayperform.Length; i++)
            {
                int x = arrayperform[i] - today;
                if (x < getminimum && x > 0)
                {
                    getminimum = x;

                }
                else if (x == 0)
                {
                    DateTime compareDate = System.DateTime.Today.AddMinutes(Convert.ToInt32(batchtime.Substring(0, 2)) * 60 + Convert.ToInt32(batchtime.Substring(3, 2)) - 30);
                    if (System.DateTime.Now > compareDate)
                    {
                        if (today == 7)
                        {
                            today = 1;
                        }
                        else
                        {
                            today++;
                        }
                        return getminimumdiff(arrayperform, today, batchtime) + 1;
                    }

                    return x;
                }
                else if (x < 0 && x < getminimumminus)
                {
                    getminimumminus = x;

                }
            }
            if (getminimum < 7)
            {
                return getminimum;
            }
            else if (getminimumminus < 0)
            {
                getminimumminus = getminimumminus + 7;
                return getminimumminus;
            }
            else
                return 8;
            //return getminimum;
        }
        private int getminimumdiff(int[] arrayperform, int today)
        {
            int getminimum = 7;
            int getminimumminus = 0;
            for (int i = 0; i < arrayperform.Length; i++)
            {
                int x = arrayperform[i] - today;
                if (x < getminimum && x > 0)
                {
                    getminimum = x;

                }
                else if (x == 0)
                    return x;
                else if (x < 0 && x < getminimumminus)
                {
                    getminimumminus = x;

                }
            }
            if (getminimum < 7)
            {
                return getminimum;
            }
            else if (getminimumminus < 0)
            {
                getminimumminus = getminimumminus + 7;
                return getminimumminus;
            }
            else
                return 8;
            //return getminimum;
        }
        private string[] dates(DataView dv, int month, int year)
        {
            string[] performingdates = new string[dv.Count];
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["VALUE"].ToString().Trim() == "1-Monday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Monday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }
                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Tuesday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Tuesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Wednesday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Wednesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Thursday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Thursday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Friday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Friday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Saturday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Saturday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "1-Sunday")
                {
                    for (int datecheck = 1; datecheck < 8; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Sunday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                ////////////////////////////////////
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Monday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Monday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }
                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Tuesday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Tuesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Wednesday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Wednesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Thursday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Thursday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Friday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Friday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Saturday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Saturday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "2-Sunday")
                {
                    for (int datecheck = 8; datecheck < 15; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Sunday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                ////////////////////////////////////////////////////
                if (dv[i]["VALUE"].ToString().Trim() == "3-Monday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Monday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }
                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Tuesday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Tuesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Wednesday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Wednesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Thursday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Thursday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Friday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Friday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Saturday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Saturday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "3-Sunday")
                {
                    for (int datecheck = 15; datecheck < 22; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Sunday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }

                ///////////////////////////////////////////
                if (dv[i]["VALUE"].ToString().Trim() == "4-Monday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Monday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }
                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Tuesday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Tuesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Wednesday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Wednesday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Thursday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Thursday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Friday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Friday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Saturday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Saturday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }
                else if (dv[i]["VALUE"].ToString().Trim() == "4-Sunday")
                {
                    for (int datecheck = 22; datecheck < 29; datecheck++)
                    {
                        string date = datecheck.ToString() + "/" + month.ToString() + "/" + year.ToString();
                        DateTime dt = DateTime.Parse(date, new CultureInfo("en-GB", false));
                        if (dt.DayOfWeek.ToString() == "Sunday")
                        {
                            performingdates[i] = dt.Date.ToString("dd/MM/yyyy");
                        }

                    }

                }

            }
            return performingdates;
        }
        private string getnextcomingdate(string[] performingdates, string date_today)
        {
            string nearestperformingdate = "";
            int difference = 60;
            for (int i = 0; i < performingdates.Length; i++)
            {
                int chkdiff = Convert.ToInt32((DateTime.Parse(performingdates[i], new CultureInfo("en-GB", false)) - DateTime.Parse(date_today, new CultureInfo("en-GB", false))).Days);
                if (chkdiff < difference && chkdiff >= 0)
                {
                    difference = chkdiff;
                    nearestperformingdate = performingdates[i];
                }
            }
            return nearestperformingdate;
        }
        private string getnextmonthdate(DataView dv, int month, int year)
        {
            string D_Date = "";
            string date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
            string[] performing_dates = dates(dv, month, year);
            D_Date = getnextcomingdate(performing_dates, date_today);
            return D_Date;
        }
        #endregion


        private void DGPatientStatus_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {
            // Create a new WebUIFacade.
            WebUIFacade uiFacade = new WebUIFacade();

            // This is gives a tool tip for each
            // of the columns to sort by.
            uiFacade.SetHeaderToolTip(e);


            // This sets a class for the link buttons in a grid.
            uiFacade.SetGridLinkButtonStyle(e);

            // Make the row change color when the mouse hovers over.
            // *** You must have a class called gridHover with a different background 
            // color in your StyleSheet.
            uiFacade.SetRowHover((DataGrid)sender, e);
        }
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            Response.Write("<script language='javascript'>self.close();</script>");
        }

        protected void imgClose_Cmt_Click(object sender, ImageClickEventArgs e)
        {
            this.txtComment.Text = "";
            this.lblTest_Cmt.Text = "";
            this.ibtnSave.Visible = true;
            this.pnl_cmt.Visible = false;
            FillDG();
        }
        protected void imgSave_Cmt_Click(object sender, ImageClickEventArgs e)
        {
            clsBLSpecimenColletion objTSpecimenColletion = new clsBLSpecimenColletion();

            objTSpecimenColletion.DSerialNo = this.lblDserial_Cmt.Text.Trim();
            objTSpecimenColletion.Spec_Comment = this.txtComment.Text.Trim().Replace("'", "''");

            if (objTSpecimenColletion.Update_Comment())
            {
                imgClose_Cmt_Click(sender, e);
            }
            else
            {
                lblError_Cmt.ForeColor = System.Drawing.Color.Red;
                lblError_Cmt.Text = objTSpecimenColletion.ErrorMessage;
            }
        }
        protected void DGPatientStatus_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
            {
                if (e.Item.Cells[13].Text.Trim() == "Y")
                {
                    ((LinkButton)e.Item.Cells[11].FindControl("lnkhistory")).Visible = true;
                }
                if (!e.Item.Cells[6].Text.Trim().Replace("&nbsp;", "").Equals(""))
                {
                    e.Item.BackColor = System.Drawing.Color.OliveDrab;
                }
                if (e.Item.Cells[14].Text.Trim().Replace("&nbsp;", "").Equals("Y"))
                {
                    e.Item.BackColor = System.Drawing.Color.SeaShell;
                }
                clsBlTestSops objtestsops = new clsBlTestSops();
               // string testid = e.Item.Cells[9].Text;
                objtestsops.TestID = e.Item.Cells[9].Text;
                objtestsops.ProcessID = "0002";
                DataView dvtestsops = objtestsops.GetAll(2);
                if (dvtestsops.Count == 0)
                {
                    (e.Item.Cells[11].FindControl("lnkSOp") as LinkButton).Visible = false;
                }
            }
        }
        private TimeSpan roundto30(string time)
        {
            int hours = Convert.ToInt16(time.Substring(0, 2));
            int minutes = Convert.ToInt16(time.Substring(3, 2));

            TimeSpan t = new TimeSpan(hours, minutes, 0);
            int Round = 30;

            // Count of round number in this total minutes...
            double CountRound = (t.TotalMinutes / Round);

            // The main formula to calculate round time...
            int Min = (int)Math.Round(CountRound + 0.5) * Round;// 1-Round has been used to ceil the time to 30 minutes. 2-if rounding is required use Truncate instead of round

            // Now show the result...
            TimeSpan tRes = new TimeSpan(0, 0, Min, 0);
            return tRes;
            //Console.WriteLine(tRes.ToString());
            //Console.WriteLine(tRes.Days.ToString());
            //Console.ReadLine();

        }
}
}
