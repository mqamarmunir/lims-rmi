using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using System.Globalization;

public partial class LIMS_WebForms_wfrmReceptionLab : System.Web.UI.Page
{
    private static string _sectionid = "";
    private string _testgroupID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {

            if (!IsPostBack)
            {
                if (Session["dt"] != "")
                {
                    Session["dt"] = "";
                }
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "101";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                txtPRSearch.Focus();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                //lblPRNO.Text = Request.QueryString.Get("prno");
                //lblVisitno.Text = Request.QueryString.Get("visitno");
                // fillPatientInfo();
                ////fillDepartmentInfo();
                //fillSubdepartmentInfo();
                ////fillGroup();
                //fillOriginBy();
                //fillRefferedBy();

            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
    protected void lbtnSave_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "";
        if (!ValidationVD())
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = "Reffered by not selected";
            return;
        }
        else
        {
            insert();
        }
    }
    protected void lbtnClearAll_Click(object sender, ImageClickEventArgs e)
    {
        DataTable dt = new DataTable();
        Session["dt"] = dt;
        gvTestList.DataSource = dt;
        gvTestList.DataBind();
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        gvGroup.DataSource = dt;
        gvGroup.DataBind();
        lnkAddBatch.Visible = false;
        slctbtnAddAll.Visible = false;
        slctbtnAddSelected.Visible = false;
        lnkbtnSlctRemoveAll.Visible = false;
        ddlOrigenBy.SelectedIndex = 0;
        ddlRefferdBy.SelectedIndex = -1;
        ddlRptCollect.SelectedIndex = 0;
        Label1.Text = "";
        lblErrMsg.Text = "";
        lblTotalCharges.Text = "";
        txtTestList.Text = "";
        txtTestSearch.Text = "";
        txtSpeedKey.Text = "";
        lblColorCode.Visible = false;
        txtRefferedby.Text = "";
        // pnlpopup.Visible = false;
        //chktemp.Checked = true;
        //        chktemp_CheckedChanged(sender, e);


    }
    protected void btnClose_Click(object sender, ImageClickEventArgs e)
    {
        lbtnClearAll_Click(sender, e);
        gvPRNo.DataSource = "";
        gvPRNo.DataBind();
        txtPRSearch.Text = "";
        txtNameSearch.Text = "";
        txtmobilesearch.Text = "";
        txtPRSearch.Focus();
        fsetinvestbooking.Visible = false;
        fsetsearch.Visible = true;
        // Response.Write("<script language = 'javascript'>window.close()</script>");
    }
    private void fillPatientInfo()
    {
        PatientRegView prv = new PatientRegView();
        //prv.FromDate = txtFrom.Text.Trim();
        //prv.ToDate = txtTo.Text.Trim();
        // prv.PRNO = txtPRSearch.Text.Trim();
        prv.PRNO = lblPRNO.Text.Trim();
        prv.VisitNo = lblVisitno.Text.Trim();
        DataView dv = prv.GetAll(2);
        if (dv.Count > 0)
        {
            lblPatientName.Text = dv.Table.Rows[0]["name"].ToString().Trim();
            lblAge.Text = dv.Table.Rows[0]["age"].ToString().Trim();
            lblGender.Text = dv.Table.Rows[0]["Gender"].ToString().Trim();
            lblMSStatus.Text = dv.Table.Rows[0]["marital_status"].ToString().Trim();
            lblPRID.Text = dv.Table.Rows[0]["PRID"].ToString().Trim();
        }
    }
    private void fillDepartmentInfo()
    {
        PatientRegView prv = new PatientRegView();

        DataView dv = prv.GetAll(3);
        if (dv.Count > 0)
        {
            //gvDpet.DataSource = dv;
            //gvDpet.DataBind();
        }
    }
    private void fillSubdepartmentInfo()
    {
        PatientRegView prv = new PatientRegView();

        DataView dv = prv.GetAll(4);
        if (dv.Count > 0)
        {
            gvSubDept.DataSource = dv;
            gvSubDept.DataBind();
        }
    }
    private void fillGroup()
    {
        PatientRegView prv = new PatientRegView();

        DataView dv = prv.GetAll(5);
        if (dv.Count > 0)
        {
            gvGroup.DataSource = dv;
            gvGroup.DataBind();
        }
    }
    private void fillRefferedBy()
    {
        PatientRegView prv = new PatientRegView();
        DataView dv = prv.GetAll(22);
        if (dv.Count > 0)
        {
            SComponents ddlrefby = new SComponents();
            ddlrefby.FillDropDownList(ddlRefferdBy, dv, "CompleteName", "personid");
        }
    }
    private void fillOriginBy()
    {
        PatientRegView prv = new PatientRegView();
        DataView dv = prv.GetAll(9);
        if (dv.Count > 0)
        {
            SComponents ddlrefby = new SComponents();
            ddlrefby.FillDropDownList(ddlOrigenBy, dv, "originplace", "originplaceid");
        }

        ddlOrigenBy.SelectedIndex = ddlOrigenBy.Items.IndexOf(ddlOrigenBy.Items.FindByText("RMI"));
    }
    protected void slctbtnTestList_Click(object sender, ImageClickEventArgs e)
    {
        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {
            if (gvTestList.Rows[i].Cells[0].Text.Trim().ToUpper().Contains(txtTestList.Text.Trim().ToUpper()))
            {

                gvTestList.Rows[i].BackColor = System.Drawing.Color.Pink;
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        PatientRegView prv = new PatientRegView();
        prv.SpeedKey = txtSpeedKey.Text.Trim();
        if (lblGender.Text.Trim().Contains("Female"))
        {
            prv.Sex = "Female";
        }
        else
        {
            prv.Sex = "Male";
        }
        if (rdoNormal.Checked == true)
        {
            prv.Priority = "N";
        }
        else if (rdoUrgent.Checked == true)
        {
            prv.Priority = "U";
        }
        if (lblAge.Text.ToLower().Contains("year"))
        {
            prv.PatAgeU = "Y";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("year") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("month"))
        {
            prv.PatAgeU = "M";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("month") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("week"))
        {
            prv.PatAgeU = "W";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("week") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("day"))
        {
            prv.PatAgeU = "D";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("day") - 1).Trim();
        }
        DataView dv = prv.GetAll(11);
        //dv.RowFilter = " Amount>0";
        if (dv.Count > 0)
        {
            gvTestList.DataSource = dv;
            gvTestList.DataBind();
        }
    }
    protected void btnTestFind_Click(object sender, ImageClickEventArgs e)
    {
        PatientRegView prv = new PatientRegView();
        prv.TestName = txtTestSearch.Text.Trim().Replace("'","''");
        _sectionid = "";
        if (lblGender.Text.Trim().Contains("Female"))
        {
            prv.Sex = "Female";
        }
        else
        {
            prv.Sex = "Male";
        }
        if (rdoNormal.Checked == true)
        {
            prv.Priority = "N";
        }
        else if (rdoUrgent.Checked == true)
        {
            prv.Priority = "U";
        }
        if (lblAge.Text.ToLower().Contains("year"))
        {
            prv.PatAgeU = "Y";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("year") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("month"))
        {
            prv.PatAgeU = "M";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("month") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("week"))
        {
            prv.PatAgeU = "W";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("week") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("day"))
        {
            prv.PatAgeU = "D";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("day") - 1).Trim();
        }

        prv.SearchType = rdosearchtypename.Checked ? "Name" : "Acronym";
        DataView dv = prv.GetAll(10);
       // dv.RowFilter = " Amount>0";
        if (dv.Count > 0)
        {
            Label1.Text = "";
            gvTestList.DataSource = dv;
            gvTestList.DataBind();
            if (gvTestList.Rows.Count == 1)
            {
                slctbtnAddAll_Click(this, e);// if search returned 1 result then add that test to patient selected tests
                txtTestSearch.Text = "";
                txtTestSearch.Focus();
            }
            slctbtnAddAll.Visible = true;
            slctbtnAddSelected.Visible = true;

        }
        else
        {
            gvTestList.DataSource = "";
            gvTestList.DataBind();
            //lblErrMsg.Text = "No test found with such name";
            Label1.Text = "No test found with such name";
        }
    }
    protected void slctbtnAddSelected_Click(object sender, EventArgs e)
    {
        int testmatchedcount = 0;
        Label1.Text = "";
        string method_id = "";
        string Delivery_Date = "";
        string batchtime = "";
        DataTable dt = new DataTable();
        createTable(dt);

        int count = 0;
        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

        if (dt.Columns.Count == 0)
        {
            createTable(dt);
            Session["dt"] = dt;
        }

        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {
            batchtime = gvTestList.DataKeys[i].Values["batchtime"].ToString().Trim();
            testmatchedcount = 0;
            if (((CheckBox)(gvTestList.Rows[i].Cells[2].FindControl("chkCharges"))).Checked == true)
            {
                if (dt.Rows.Count > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {

                        if (dt.Rows[j]["testname"].ToString().Trim().Equals(((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim()))
                        {
                            Label1.Text += dt.Rows[j]["testname"].ToString().Trim() + ": already selected <br />";
                            testmatchedcount++;
                            break;
                            //return;
                        }
                    }
                    if (testmatchedcount > 0)
                    {
                        continue;
                    }
                }
                /////////////////////////////////////Getting Nearest Delivery Date/Time/////////////////////////////////////
                /////////////Checking Delivery Date after Specimen Collection////////////////////////////
                if (gvTestList.DataKeys[i].Values[4].ToString() == "Y")
                {
                    Delivery_Date = "On Specimen Collection.";
                }
                else
                {
                    #region getting nearest Delivery Time
                    int addhours = 0;
                    clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
                    obj_Schedule.TestID = gvTestList.DataKeys[i].Value.ToString();
                    
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
                            if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString())) || (todaynum != Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString()) && gvTestList.DataKeys[i].Values["External_orgid"].ToString() != "0" && !istodayperformingday(performingdates)))
                            {
                                date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                try
                                {

                                    date_today = DateTime.Now.AddDays(Convert.ToInt16(gvTestList.DataKeys[i]["traveltime"].ToString().Trim()) / (60 * 24)).ToString("dd/MM/yyyy");
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

                        else// if (dv[0]["Type"].ToString().Trim() == "Daily")
                        {
                            Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                    }
                    else
                    {
                        Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                   

                    /////////////////////Adding Method Time/////////////////////////////
                    clsBLTest obj_Test = new clsBLTest();
                    obj_Test.TestID = gvTestList.DataKeys[i].Value.ToString();
                    DataView dv_method = obj_Test.GetAll(8);
                    if (dv_method.Count > 0)
                    {
                        addhours = 0;
                        //method_id=dv_method[0]["MethodID"].ToString();
                        if (dv_method[0]["TAT"].ToString() == "D")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                            addhours = addhours * 24;
                        }
                        else if (dv_method[0]["TAT"].ToString() == "H")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                        }
                        else if (dv_method[0]["TAT"].ToString() == "W")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
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
                    ////////////////////////////////////////////////////////////////////////
                    #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
                    if (gvTestList.DataKeys[i].Values[5].ToString().Trim() == "N")
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

                    #endregion
                }
                ////////////////////////////////////////----------------------------///////////////////////////////////////

                ///////////////////////////////////////Getting Secction and TestGrupIDs///////////////////////////////////
                #region getting Section and TestGroupIDs
                string test_groupID = "";
                string section_id = "";

                if (!_testgroupID.Equals("") && !_testgroupID.Equals("-1"))
                {
                    test_groupID = _testgroupID;
                    section_id = _sectionid;

                }
                else
                {
                    PatientRegView getgroup = new PatientRegView();
                    getgroup.TestId = gvTestList.DataKeys[i].Value.ToString().Trim();
                    DataView sectionandgroup = getgroup.GetAll(20);
                    section_id = sectionandgroup[0]["SectionID"].ToString();
                    test_groupID = sectionandgroup[0]["TESTGROUPID"].ToString();

                }
                #endregion


                DataRow dr = dt.NewRow();

                // dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                dr["testname"] = ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim();
                dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
                if (gvTestList.DataKeys[i].Values["External_orgid"] != "0")
                {
                    _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(gvTestList.DataKeys[i].Values["traveltime"].ToString().Trim()));

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

                if (int.Parse(gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim()) > 0 && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim()!="") 
                {
                    if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()))
                    {
                        _deliverydate = _deliverydate.AddDays(1);
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                    else
                    {
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                }
               
                dr["deliverydate"] = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).ToString("dd/MM/yyyy hh:mm:ss tt"); ;

                if (rdoNormal.Checked == true)
                {
                    dr["Urgent"] = "N";
                }
                else if (rdoUrgent.Checked == true)
                {
                    dr["Urgent"] = "U";
                }
                dr["sectionid"] = section_id;
                dr["testgroupid"] = test_groupID;
                dr["methodid"] = gvTestList.DataKeys[i].Values[3].ToString();
                dr["procedureid"] = gvTestList.DataKeys[i].Values["Procedureid"].ToString().Trim();
                dr["External_orgid"] = gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim();
                dr["TestCost"] = gvTestList.DataKeys[i].Values["TestCost"].ToString().Trim();
                dt.Rows.Add(dr);
                gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;

            }
            else
            {
                count += 1;
            }
        }
        if (count == gvTestList.Rows.Count)
        {
            Label1.Text = "No test is selected";
            return;
        }

        Session["dt"] = dt;
        //dt.DefaultView.Sort = "deliverydate DESC";
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();

        lnkbtnSlctRemoveAll.Visible = true;
        int totalamount = 0;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            totalamount += Convert.ToInt32(dt.Rows[i]["amount"].ToString().Trim());
        }
        lblTotalCharges.Text = totalamount.ToString().Trim() + " Rupees Only";
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


    private int getcurrentweek(int date_today)
    {

        int week = 0;
        if (date_today >= 1 && date_today <= 7)
            week = 1;
        else if (date_today >= 8 && date_today <= 14)
            week = 2;
        else if (date_today >= 15 && date_today <= 21)
            week = 3;
        else if (date_today >= 22 && date_today <= 28)
            week = 4;
        else if (date_today >= 29 && date_today <= 31)
            week = 5;

        return week;

    }
    private int[,] performingdays_weekly(DataView dv)
    {
        int[,] performing_days_weekly = new int[dv.Count, 2];
        for (int i = 0; i < dv.Count; i++)
        {
            if (dv[i]["Value"].ToString().Trim() == "1-Monday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 1;

            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Tuesday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 2;
            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Wednesday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 3;
            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Thursday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 4;
            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Friday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 5;
            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Saturday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 6;
            }
            else if (dv[i]["Value"].ToString().Trim() == "1-Sunday")
            {
                performing_days_weekly[i, 0] = 1;
                performing_days_weekly[i, 1] = 7;
            }


            else if (dv[i]["Value"].ToString().Trim() == "2-Monday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 1;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Tuesday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 2;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Wednesday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 3;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Thursday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 4;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Friday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 5;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Saturday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 6;
            }
            else if (dv[i]["Value"].ToString().Trim() == "2-Sunday")
            {
                performing_days_weekly[i, 0] = 2;
                performing_days_weekly[i, 1] = 7;
            }


            else if (dv[i]["Value"].ToString().Trim() == "3-Monday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 1;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Tuesday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 2;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Wednesday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 3;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Thursday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 4;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Friday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 5;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Saturday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 6;
            }
            else if (dv[i]["Value"].ToString().Trim() == "3-Sunday")
            {
                performing_days_weekly[i, 0] = 3;
                performing_days_weekly[i, 1] = 7;
            }


            else if (dv[i]["Value"].ToString().Trim() == "4-Monday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 1;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Tuesday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 2;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Wednesday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 3;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Thursday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 4;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Friday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 5;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Saturday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 6;
            }
            else if (dv[i]["Value"].ToString().Trim() == "4-Sunday")
            {
                performing_days_weekly[i, 0] = 4;
                performing_days_weekly[i, 1] = 7;
            }

        }

        return performing_days_weekly;
    }

    private int getnumberofdays(int[,] performingdaysweekly, int week, int day, int date_today)
    {
        int numberofdays = 0;
        int min_diff_days = 7;
        int min_diff_days_minus = 0;
        int nearestweek = getnearestweek(performingdaysweekly, week, day);
        // int nearestday = getnearestday(performingdaysweekly, nearestweek, day);
        for (int i = 0; i < performingdaysweekly.Length / 2; i++)
        {
            if (performingdaysweekly[i, 0] == nearestweek + week)
            {
                int x = performingdaysweekly[i, 1] - day;
                if (x < min_diff_days && x >= 0)
                {
                    min_diff_days = x;
                }
                else if (x < 0 && x < min_diff_days_minus)
                {
                    min_diff_days_minus = x;
                }
            }


        }
        if (min_diff_days < 7)
        {
            int threshold = 0;
            if (nearestweek < 0)
            {

                nearestweek = nearestweek + 4;

                // threshhold = System.DateTime.DaysInMonth(Convert.ToInt32(System.DateTime.Now.Year), Convert.ToInt32(System.DateTime.Now.Month)) - date_today;
                // nearestweek--;
            }

            numberofdays = 7 * nearestweek + min_diff_days + threshold;
        }
        else if (min_diff_days_minus < 0)
        {
            nearestweek--;
            min_diff_days_minus = min_diff_days_minus + 7;
            numberofdays = 7 * nearestweek + min_diff_days_minus;
        }
        // numberofdays = 7*nearestweek + min_diff_days;
        return numberofdays;
    }

    private int getnearestweek(int[,] performingdaysweekly, int week, int day)
    {
        int min_diff_week = 4;
        int min_diff_week_minus = 0;

        for (int i = 0; i < performingdaysweekly.Length / 2; i++)
        {
            int x = performingdaysweekly[i, 0] - week;
            if (x < min_diff_week && x > 0)
            {
                min_diff_week = x;
            }
            else if (x == 0)
            {
                for (int j = 0; j < performingdaysweekly.Length / 2; j++)
                {
                    if (performingdaysweekly[j, 0] == performingdaysweekly[i, 0])
                    {

                        int y = performingdaysweekly[i, 1] - day;
                        if (y >= 0)
                        {
                            min_diff_week = x;
                        }
                    }
                }


            }
            else if (x < 0 && x < min_diff_week_minus)
            {
                min_diff_week_minus = x;
            }

        }
        if (min_diff_week < 4)
        {
            return min_diff_week;
        }
        else if (min_diff_week_minus < 0)
        {
            return min_diff_week_minus;
        }
        else
            return 4;
    }

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
    #region old getminimumdifference just to avoid exceptions
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
            {
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
    #endregion
    private void createTable(DataTable dt)
    {
        //dt.Columns.Add("testid");
        dt.Columns.Add("testid");
        dt.Columns.Add("testname");
        dt.Columns.Add("amount");
        dt.Columns.Add("enteredon");
        dt.Columns.Add("deliverydate");
        dt.Columns.Add("Urgent");
        dt.Columns.Add("sectionid");
        dt.Columns.Add("testgroupid");
        dt.Columns.Add("methodid");
        dt.Columns.Add("procedureid");
        dt.Columns.Add("External_orgid");
        dt.Columns.Add("TestCost");
        //dt.Columns.Add("traveltime");

    }
    protected void slctbtnAddAll_Click(object sender, EventArgs e)
    {
        int testselectedcount = 0;
        Label1.Text = "";
        string batchtime = "";
        DataTable dt = new DataTable();
        string test_groupID = "";
        string section_id = "";
        createTable(dt);
        string Delivery_Date = "";
        if (Session["dt"].Equals(""))
        {
            Session["dt"] = dt;
        }
        else
        {
            dt = (DataTable)Session["dt"];
        }

        if (dt.Columns.Count == 0)
        {
            createTable(dt);
            Session["dt"] = dt;
        }
        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {
            batchtime = gvTestList.DataKeys[i].Values["batchtime"].ToString().Trim();
            testselectedcount = 0;
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["testname"].ToString().Trim().Equals(((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim()))
                    {
                        Label1.Text = dt.Rows[j]["testname"].ToString().Trim() + ":already selected";
                        testselectedcount++;
                        //gvSelectedTests.DataSource = dt;
                        //gvSelectedTests.DataBind();
                        //int tamount = 0;
                        //for (int k = 0; k < dt.Rows.Count; k++)
                        //{
                        //    tamount += Convert.ToInt32(dt.Rows[k]["amount"].ToString().Trim());
                        //}
                        //lblTotalCharges.Text = tamount.ToString().Trim();
                        break;
                    }
                }
                if (testselectedcount > 0 || ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Enabled == false)
                {
                    continue;
                }
                // }
                // else
                // {
                /////////////////////////////////////Getting Nearest Delivery Date/Time/////////////////////////////////////
                if (gvTestList.DataKeys[i].Values[4].ToString() == "Y")
                {
                    Delivery_Date = "On Specimen Collection";
                }
                else
                {

                    #region getting nearest Delivery Time
                    int addhours = 0;
                    clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
                    obj_Schedule.TestID = gvTestList.DataKeys[i].Value.ToString();

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
                            if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString())) || (todaynum != Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString()) && gvTestList.DataKeys[i].Values["External_orgid"].ToString() != "0" && !istodayperformingday(performingdates)))
                            {
                                date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                try
                                {

                                    date_today = DateTime.Now.AddDays(Convert.ToInt16(gvTestList.DataKeys[i]["traveltime"].ToString().Trim()) / (60 * 24)).ToString("dd/MM/yyyy");
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

                        else// if (dv[0]["Type"].ToString().Trim() == "Daily")
                        {
                            Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                        }
                    }
                    else
                    {
                        Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                    }

                    /////////////////////Adding Method Time/////////////////////////////
                    clsBLTest obj_Test = new clsBLTest();
                    obj_Test.TestID = gvTestList.DataKeys[i].Value.ToString();
                    DataView dv_method = obj_Test.GetAll(8);
                    if (dv_method.Count > 0)
                    {
                        addhours = 0;
                        //method_id=dv_method[0]["MethodID"].ToString();
                        if (dv_method[0]["TAT"].ToString() == "D")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                            addhours = addhours * 24;
                        }
                        else if (dv_method[0]["TAT"].ToString() == "H")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                        }
                        else if (dv_method[0]["TAT"].ToString() == "W")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
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
                    ////////////////////////////////////////////////////////////////////////
                    #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
                    if (gvTestList.DataKeys[i].Values[5].ToString().Trim() == "N")
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

                    #endregion
                }
                ////////////////////////////////////////----------------------------///////////////////////////////////////

                ////////////////////////////////////Getting TestGroup and SectionIDs///////////////////////////////////////
                #region Getting Section and TestGroupIDs


                if (!_testgroupID.Equals("") && !_testgroupID.Equals("-1"))
                {
                    test_groupID = _testgroupID;
                    section_id = _sectionid;

                }
                else
                {
                    PatientRegView getgroup = new PatientRegView();
                    getgroup.TestId = gvTestList.DataKeys[i].Value.ToString().Trim();
                    DataView sectionandgroup = getgroup.GetAll(20);
                    section_id = sectionandgroup[0]["SectionID"].ToString();
                    test_groupID = sectionandgroup[0]["TESTGROUPID"].ToString();

                }
                #endregion
                ///////////////////////////////////////-----------------------////////////////////////////////////////////
                DataRow dr = dt.NewRow();
                dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                //dr["testid"] = gvTestList.Rows[i].Cells[0].Text.Trim();
                dr["testname"] = ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim();
                dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
                if (gvTestList.DataKeys[i].Values["External_orgid"] != "0")
                {
                    _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(gvTestList.DataKeys[i].Values["traveltime"].ToString().Trim()));

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
                if (int.Parse(gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim()) > 0 && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != "")
                {
                    if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()))
                    {
                        _deliverydate = _deliverydate.AddDays(1);
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                    else
                    {
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                }
                dr["deliverydate"] = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).ToString("dd/MM/yyyy hh:mm:ss tt"); ;
                if (rdoNormal.Checked == true)
                {
                    dr["Urgent"] = "N";
                }
                else if (rdoUrgent.Checked == true)
                {
                    dr["Urgent"] = "U";
                }
                dr["sectionid"] = section_id;
                dr["testgroupid"] = test_groupID;
                dr["methodid"] = gvTestList.DataKeys[i].Values[3].ToString();
                dr["procedureid"] = gvTestList.DataKeys[i].Values["Procedureid"].ToString().Trim();
                dr["External_orgid"] = gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim();
                dr["TestCost"] = gvTestList.DataKeys[i].Values["TestCost"].ToString().Trim();
                dt.Rows.Add(dr);
                gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;
            }
            // }
            else
            {
                if (((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Enabled == false)
                {
                    continue;
                }
                /////////////////////////////////////Getting Nearest Delivery Date/Time/////////////////////////////////////
                if (gvTestList.DataKeys[i].Values[4].ToString() == "Y")
                {
                    Delivery_Date = "On Specimen Collection.";
                }
                else
                {
                    #region getting nearest Delivery Time
                    int addhours = 0;
                    clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
                    obj_Schedule.TestID = gvTestList.DataKeys[i].Value.ToString();

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
                            if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString())) || (todaynum != Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString()) && gvTestList.DataKeys[i].Values["External_orgid"].ToString() != "0" && !istodayperformingday(performingdates)))
                            {
                                date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                            }
                            else
                            {
                                try
                                {

                                    date_today = DateTime.Now.AddDays(Convert.ToInt16(gvTestList.DataKeys[i]["traveltime"].ToString().Trim()) / (60 * 24)).ToString("dd/MM/yyyy");
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
                    }
                    else
                    {
                        Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                    }

                    /////////////////////Adding Method Time/////////////////////////////
                    clsBLTest obj_Test = new clsBLTest();
                    obj_Test.TestID = gvTestList.DataKeys[i].Value.ToString();
                    DataView dv_method = obj_Test.GetAll(8);
                    if (dv_method.Count > 0)
                    {
                        addhours = 0;
                        //method_id=dv_method[0]["MethodID"].ToString();
                        if (dv_method[0]["TAT"].ToString() == "D")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                            addhours = addhours * 24;
                        }
                        else if (dv_method[0]["TAT"].ToString() == "H")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
                        }
                        else if (dv_method[0]["TAT"].ToString() == "W")
                        {
                            if (rdoUrgent.Checked == true)
                            {
                                addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                            }
                            else
                            {
                                addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                            }
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
                    ////////////////////////////////////////////////////////////////////////
                    #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
                    if (gvTestList.DataKeys[i].Values[5].ToString().Trim() == "N")
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

                    #endregion
                }
                ////////////////////////////////////////----------------------------///////////////////////////////////////

                ////////////////////////////////////Getting TestGroup and SectionIDs///////////////////////////////////////
                #region Getting Section and TestGroupIDs


                if (!_testgroupID.Equals("") && !_testgroupID.Equals("-1"))
                {
                    test_groupID = _testgroupID;
                    section_id = _sectionid;

                }
                else
                {
                    PatientRegView getgroup = new PatientRegView();
                    getgroup.TestId = gvTestList.DataKeys[i].Value.ToString().Trim();
                    DataView sectionandgroup = getgroup.GetAll(20);
                    section_id = sectionandgroup[0]["SectionID"].ToString();
                    test_groupID = sectionandgroup[0]["TESTGROUPID"].ToString();

                }
                #endregion
                ///////////////////////////////////////-----------------------////////////////////////////////////////////




                DataRow dr = dt.NewRow();
                dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                dr["testname"] = ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim();
                dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
                if (gvTestList.DataKeys[i].Values["External_orgid"] != "0")
                {
                    _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(gvTestList.DataKeys[i].Values["traveltime"].ToString().Trim()));

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
                if (int.Parse(gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim()) > 0 && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != "")
                {
                    if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()))
                    {
                        _deliverydate = _deliverydate.AddDays(1);
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                    else
                    {
                        Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                    }
                }
                dr["deliverydate"] = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).ToString("dd/MM/yyyy hh:mm:ss tt"); ;
                if (rdoNormal.Checked == true)
                {
                    dr["Urgent"] = "N";
                }
                else if (rdoUrgent.Checked == true)
                {
                    dr["Urgent"] = "U";
                }
                dr["sectionid"] = section_id;
                dr["testgroupid"] = test_groupID;
                dr["methodid"] = gvTestList.DataKeys[i].Values[3].ToString();
                dr["procedureid"] = gvTestList.DataKeys[i].Values["Procedureid"].ToString().Trim();
                dr["External_orgid"] = gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim();
                dr["TestCost"] = gvTestList.DataKeys[i].Values["TestCost"].ToString().Trim();
                dt.Rows.Add(dr);
                gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;
            }

        }
        Session["dt"] = dt;
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        lnkbtnSlctRemoveAll.Visible = true;
        int totalamount = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            totalamount += Convert.ToInt32(dt.Rows[i]["amount"].ToString().Trim());
        }
        lblTotalCharges.Text = totalamount.ToString().Trim() + " Rupees Only";
    }
    protected void lbtnSubDepart_Click(object sender, EventArgs e)
    {
        PatientRegView prv = new PatientRegView();

        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);
        _sectionid = gvSubDept.DataKeys[gridItem.DataItemIndex].Value.ToString();
        prv.SubDepartmentId = gvSubDept.DataKeys[gridItem.DataItemIndex].Value.ToString();
        DataView dv = prv.GetAll(12);
        if (dv.Count > 0)
        {
            gvGroup.DataSource = dv;
            gvGroup.DataBind();
        }
        if (rdoNormal.Checked == true)
        {
            prv.Priority = "N";
        }
        else if (rdoUrgent.Checked == true)
        {
            prv.Priority = "U";
        }
        prv.SubDepartmentId = gvSubDept.DataKeys[gridItem.DataItemIndex].Value.ToString();
        if (lblGender.Text.Trim().Contains("Female"))
        {
            prv.Sex = "Female";
        }
        else
        {
            prv.Sex = "Male";
        }
        if (lblAge.Text.ToLower().Contains("year"))
        {
            prv.PatAgeU = "Y";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("year") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("month"))
        {
            prv.PatAgeU = "M";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("month") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("week"))
        {
            prv.PatAgeU = "W";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("week") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("day"))
        {
            prv.PatAgeU = "D";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("day") - 1).Trim();
        }
        dv = prv.GetAll(13);
        //dv.RowFilter = "Amount>0";
        if (dv.Count > 0)
        {
            //DataTable dt = new DataTable();
            //dt = (DataTable)Session["dt"];
            //Session["dt"] = dv.Table;
            gvTestList.DataSource = dv;
            gvTestList.DataBind();
            lblSectionid.Text = dv.Table.Rows[0]["sectionid"].ToString().Trim();
            slctbtnAddSelected.Visible = true;
            slctbtnAddAll.Visible = true;
            # region Test Batches Depricated
            ////////////////////////////////////////////Test Batches/////////////////////////////////////
            //for (int i = 0; i < dv.Count; i++)
            //{
            //    if (i < dv.Count - 1)
            //    {
            //        if (dv[i]["testbatchno"].Equals(dv[i + 1]["testbatchno"]) && !dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //    else if (dv.Count == 1)
            //    {
            //        if (!dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //    else if (i < dv.Count)
            //    {
            //        if (dv[i]["testbatchno"].Equals(dv[i - 1]["testbatchno"]) && !dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //}

            ///////////////////////////////////Test Batches////////////////////////////////////////////////
            #endregion
        }
        else
        {
            gvTestList.DataSource = "";
            gvTestList.DataBind();
        }


    }
    protected void lbtnTestGroup_Click(object sender, EventArgs e)
    {
        PatientRegView prv = new PatientRegView();

        GridViewRow gridItem = ((GridViewRow)((LinkButton)sender).Parent.Parent);

        _testgroupID = gvGroup.DataKeys[gridItem.DataItemIndex].Value.ToString();
        prv.TestGroupId = gvGroup.DataKeys[gridItem.DataItemIndex].Value.ToString();
        prv.SubDepartmentId = _sectionid;


        if (rdoNormal.Checked == true)
        {
            prv.Priority = "N";
        }
        else if (rdoUrgent.Checked == true)
        {
            prv.Priority = "U";
        }
        if (lblGender.Text.Trim().Contains("Female"))
        {
            prv.Sex = "Female";
        }
        else
        {
            prv.Sex = "Male";
        }
        if (lblAge.Text.ToLower().Contains("year"))
        {
            prv.PatAgeU = "Y";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("year") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("month"))
        {
            prv.PatAgeU = "M";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("month") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("week"))
        {
            prv.PatAgeU = "W";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("week") - 1).Trim();
        }
        else if (lblAge.Text.ToLower().Contains("day"))
        {
            prv.PatAgeU = "D";
            prv.PatAgeD = lblAge.Text.Substring(0, lblAge.Text.ToLower().IndexOf("day") - 1).Trim();
        }
        DataView dv = prv.GetAll(13);
       // dv.RowFilter = "Amount>0";
        if (dv.Count > 0)
        {
            gvTestList.DataSource = dv;
            gvTestList.DataBind();
            slctbtnAddAll.Visible = true;
            slctbtnAddSelected.Visible = true;
            lnkAddBatch.Visible = false;
            lblSectionid.Text = dv.Table.Rows[0]["sectionid"].ToString().Trim();
            lblTestGroupId.Text = dv.Table.Rows[0]["testgroupid"].ToString().Trim();
            //for (int i = 0; i < dv.Count; i++)
            //{
            //    if (i < dv.Count-1)
            //    {
            //        if (dv[i]["testbatchno"].Equals(dv[i + 1]["testbatchno"])&& !dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //    else if (dv.Count == 1)
            //    {
            //        if (!dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //    else if (i < dv.Count)
            //    {
            //        if (dv[i]["testbatchno"].Equals(dv[i - 1]["testbatchno"]) && !dv[i]["testbatchno"].ToString().Contains("0"))
            //        {
            //            gvTestList.Rows[i].BackColor = System.Drawing.Color.Silver;
            //        }
            //    }
            //}
        }

        else
        {
            gvTestList.DataSource = "";
            gvTestList.DataBind();
        }

    }

    protected void lnkbtnSlectTestRemoveAll_Click(object sender, EventArgs e)
    {
        DataTable dtTest = (DataTable)Session["dt"];
        //for (int k = 0; k < gvTestList.Rows.Count; k++)
        //{
        //    for (int l = 0; l < dtTest.Rows.Count; l++)
        //    {
        //        if (dtTest.Rows[l]["testid"].ToString().Contains(gvTestList.DataKeys[k].Value.ToString().Trim()))
        //        {
        //            if (k % 2 == 0)
        //            {
        //                gvTestList.Rows[k].BackColor = System.Drawing.Color.MistyRose;

        //            }
        //            else
        //            {
        //                gvTestList.Rows[k].BackColor = System.Drawing.Color.MistyRose;
        //            }

        //        }
        //    }
        //}
        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {
            //gvTestList.Rows[i].BackColor = System.Drawing.Color.Transparent;
            if (i % 2 == 0)
            {
                gvTestList.Rows[i].BackColor = gvTestList.AlternatingRowStyle.BackColor;
            }
            else
            {
                gvTestList.Rows[i].BackColor = gvTestList.RowStyle.BackColor;
            }
            if (gvTestList.DataKeys[i].Values["TestBatchNo"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["TestBatchNo"].ToString().Trim() != "0")
            {
                gvTestList.Rows[i].BackColor = System.Drawing.Color.Aqua;
            }
        }
        DataTable dt = new DataTable();
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        lnkbtnSlctRemoveAll.Visible = false;
        lblTotalCharges.Text = "";
        createTable(dt);
        Session["dt"] = dt;
    }
    protected void chkCharges_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void gvSelectedTestList_RowDeleting_Click(object sender, GridViewDeleteEventArgs e)
    {
        int count = 0;
        DataTable dt = (DataTable)Session["dt"];
        for (int k = 0; k < gvTestList.Rows.Count; k++)
        {
            if (dt.Rows[e.RowIndex]["testid"].ToString().Equals(gvTestList.DataKeys[k].Values[0].ToString().Trim()))
            {
                if (k % 2 == 0)
                {
                    gvTestList.Rows[k].BackColor = gvTestList.AlternatingRowStyle.BackColor;
                }
                else
                {
                    gvTestList.Rows[k].BackColor = gvTestList.RowStyle.BackColor;
                }
                if (gvTestList.DataKeys[k].Values["TestBatchNo"].ToString().Trim() != null && gvTestList.DataKeys[k].Values["TestBatchNo"].ToString().Trim() != "0")
                {
                    gvTestList.Rows[k].BackColor = System.Drawing.Color.Aqua;
                }
            }


        }
        dt.Rows[e.RowIndex].Delete();
        dt.AcceptChanges();
        if (dt.Rows.Count > 0)
        {


        }
        this.gvSelectedTests.DataSource = dt;
        this.gvSelectedTests.DataBind();
        Session["dt"] = dt;
        int totalamount = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            totalamount += Convert.ToInt32(dt.Rows[i]["amount"].ToString().Trim());
        }
        if (totalamount == 0)
        {
            lblTotalCharges.Text = "";
        }
        lblTotalCharges.Text = totalamount.ToString().Trim();
    }
    private bool ValidationVD()
    {
        if (ddlRefferdBy.SelectedIndex <= 0 && txtRefferedby.Text.Trim().Replace("&nbsp;", "").Equals(""))
        {
            lblErrMsg.Text = "Reffered by not mentioned.";
            return false;
        }
        else return true;
    }
    private void insert()
    {
        lblErrMsg.Text = "";
        Label1.Text = "";
        PatientRegView prv = new PatientRegView();
        prv.EnteredBy = Session["loginid"].ToString().Trim();
        prv.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        prv.PRID = lblPRID.Text.Trim();
        prv.PRNO = lblPRNO.Text.Trim();
        prv.VisitNo = lblVisitno.Text.Trim();
        //prv.TotalAmount = lblTotalCharges.Text.Trim().Substring(1,3);
        if (ddlRefferdBy.SelectedIndex > 0)
        {
            prv.ReferredBy = ddlRefferdBy.SelectedItem.Text.Trim();
        }
        else
        {
            prv.ReferredBy = txtRefferedby.Text.Trim();
        }
        prv.OriginBy = ddlRefferdBy.SelectedItem.Value.ToString().Trim();
        prv.OriginPlaceBy = ddlOrigenBy.SelectedItem.Value.ToString().Trim();
        prv.SectionId = lblSectionid.Text.Trim();
        prv.TestGroupId = lblTestGroupId.Text.Trim();
      
        DataTable dt = new DataTable();
        dt = (DataTable)Session["dt"];
        string[,] arrTest = new string[dt.Rows.Count, 12];
        prv.TotalAmount = makeArray(arrTest, dt).ToString();
        prv.Test = arrTest;
        if (rdoNormal.Checked == true)
        {
            prv.Priority = "N";
        }
        else if (rdoUrgent.Checked == true)
        {
            prv.Priority = "U";
        }
        prv.ReportCollection = ddlRptCollect.SelectedItem.Value.ToString().Trim();
        if (!prv.insert())
        {
            lblErrMsg.ForeColor = System.Drawing.Color.Red;
            lblErrMsg.Text = prv.ErrorMessage;

        }
        else
        {
            Response.Write("<script language='javascript'>alert('Investigation successfully written to database with LabID:" + prv.LabId + "');</script>");
            // Page.ClientScript.RegisterStartupScript(this.GetType(), "labidpop", "alert('Investigation successfully written to database'", true);

            // ScriptManager.RegisterStartupScript(Page, this.GetType(), "labidpop", "alert('Investigation successfully written to database with LabID: " + prv.LabId + ")", true);
            lblErrMsg.ForeColor = System.Drawing.Color.Green;
            lblErrMsg.Text = "Investigation successfully written to database with LabID: <font size='X-Large' color='green'>" + prv.LabId + "</font>";
            DataTable dtEmpty = new DataTable();
            Session["dt"] = dtEmpty;
            gvTestList.DataSource = dtEmpty;
            gvTestList.DataBind();
            gvSelectedTests.DataSource = dtEmpty;
            gvSelectedTests.DataBind();
            gvGroup.DataSource = dtEmpty;
            gvGroup.DataBind();
            lnkAddBatch.Visible = false;
            slctbtnAddAll.Visible = false;
            slctbtnAddSelected.Visible = false;
            lnkbtnSlctRemoveAll.Visible = false;
            ddlOrigenBy.SelectedIndex = 0;
            ddlRefferdBy.SelectedIndex = -1;
            ddlRptCollect.SelectedIndex = 0;
            Label1.Text = "";
            txtPRSearch.Text = "";
            txtmobilesearch.Text = "";
            txtNameSearch.Text = "";
            gvPRNo.DataSource = "";
            gvPRNo.DataBind();
            lblTotalCharges.Text = "";
            txtTestList.Text = "";
            txtTestSearch.Text = "";
            txtSpeedKey.Text = "";
            fsetinvestbooking.Visible = false;
            fsetsearch.Visible = true;
            txtRefferedby.Text = "";
            txtPRSearch.Focus();


        }
    }
    private int makeArray(string[,] arrTest, DataTable dt)
    {
        int total = 0;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            arrTest[i, 0] = dt.Rows[i][0].ToString().Trim();
            arrTest[i, 1] = dt.Rows[i][1].ToString().Trim();
            arrTest[i, 2] = dt.Rows[i][2].ToString().Trim();
            arrTest[i, 3] = dt.Rows[i][3].ToString().Trim();
            arrTest[i, 4] = dt.Rows[i][4].ToString().Trim();
            arrTest[i, 5] = dt.Rows[i][5].ToString().Trim();
            arrTest[i, 6] = dt.Rows[i][6].ToString().Trim();
            arrTest[i, 7] = dt.Rows[i][7].ToString().Trim();
            arrTest[i, 8] = dt.Rows[i][8].ToString().Trim();
            arrTest[i, 9] = dt.Rows[i][9].ToString().Trim();//Procedureid
            arrTest[i, 10] = dt.Rows[i][10].ToString().Trim();//External Organization Id
            arrTest[i, 11] = dt.Rows[i][11].ToString().Trim();//Test Cost price from External Organization
            total += Convert.ToInt32(dt.Rows[i][2].ToString().Trim());
        }
        return total;
    }
    protected void lnkAddBatch_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        DataTable dt = new DataTable();
        createTable(dt);


        if (Session["dt"].Equals(""))
            Session["dt"] = dt;
        else
            dt = (DataTable)Session["dt"];

        for (int i = 0; i < gvTestList.Rows.Count; i++)
        {
            if (i > 0)
            {
                if (((CheckBox)(gvTestList.Rows[i].Cells[2].FindControl("chkCharges"))).Checked == true || (((CheckBox)(gvTestList.Rows[i - 1].Cells[2].FindControl("chkCharges"))).Checked == true && gvTestList.DataKeys[i].Values[3].ToString().Equals(gvTestList.DataKeys[i - 1].Values[3].ToString())))
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {

                            if (dt.Rows[j]["testname"].ToString().Trim().Equals(gvTestList.Rows[i].Cells[0].Text.Trim()))
                            {
                                Label1.Text = dt.Rows[j]["testname"].ToString().Trim() + ": already selected";
                                return;
                            }
                        }
                    }
                    DataRow dr = dt.NewRow();
                    dr["testid"] = gvTestList.DataKeys[i].Value.ToString();
                    dr["testname"] = gvTestList.Rows[i].Cells[0].Text.Trim();
                    dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                    dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    dt.Rows.Add(dr);
                    gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;

                }
            }
            else
            {
                if (((CheckBox)(gvTestList.Rows[i].Cells[2].FindControl("chkCharges"))).Checked == true)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {

                            if (dt.Rows[j]["testname"].ToString().Trim().Equals(gvTestList.Rows[i].Cells[1].Text.Trim()))
                            {
                                Label1.Text = dt.Rows[j]["testname"].ToString().Trim() + ": already selected";
                                return;
                            }
                        }
                    }
                    DataRow dr = dt.NewRow();
                    dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                    dr["testname"] = gvTestList.Rows[i].Cells[0].Text.Trim();
                    dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                    dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    dt.Rows.Add(dr);
                    gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;
                }
            }
        }

        Session["dt"] = dt;
        gvSelectedTests.DataSource = dt;
        gvSelectedTests.DataBind();
        lnkbtnSlctRemoveAll.Visible = true;
        int totalamount = 0;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            totalamount += Convert.ToInt32(dt.Rows[i]["amount"].ToString().Trim());
        }
        lblTotalCharges.Text = totalamount.ToString().Trim() + " Rupees Only";
    }
    protected void rdoNormal_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoNormal.Checked == true)
        {
            PatientRegView prv = new PatientRegView();
            DataView dv = new DataView();
            if (!_sectionid.Equals(""))
            {
                prv.SubDepartmentId = _sectionid;
                prv.Priority = "N";
                if (_testgroupID != "")
                {
                    prv.TestGroupId = _testgroupID;
                    dv = prv.GetAll(19);
                }
                else
                {
                    dv = prv.GetAll(17);
                }
            }
            else if (txtTestSearch.Text != "")
            {
                prv.Priority = "N";
                prv.TestName = txtTestSearch.Text.Trim();
                dv = prv.GetAll(10);


            }
            //dv.RowFilter = " Amount>0";
            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
            }
            else
            {
                gvTestList.DataSource = "";
                gvTestList.DataBind();
            }
        }
    }
    protected void rdoUrgent_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoUrgent.Checked == true)
        {
            PatientRegView prv = new PatientRegView();
            DataView dv = new DataView();
            if (!_sectionid.Equals(""))
            {
                prv.SubDepartmentId = _sectionid;
                prv.Priority = "U";
                if (_testgroupID != "")
                {
                    prv.TestGroupId = _testgroupID;
                    dv = prv.GetAll(19);
                }
                else
                {
                    dv = prv.GetAll(17);
                }
            }
            else if (txtTestSearch.Text != "")
            {
                prv.Priority = "U";
                prv.TestName = txtTestSearch.Text.Trim();
                dv = prv.GetAll(10);

            }
            //dv.RowFilter = "Amount>0";
            if (dv.Count > 0)
            {
                gvTestList.DataSource = dv;
                gvTestList.DataBind();
            }
            else
            {
                gvTestList.DataSource = "";
                gvTestList.DataBind();
            }
        }
    }

    protected void gvTestList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Control container = e.Row;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string methodid = gvTestList.DataKeys[e.Row.RowIndex].Values[3].ToString();
            if (methodid == "" || methodid == null)
            {
                lblColorCode.Visible = true;
                e.Row.ForeColor = System.Drawing.Color.Red;
                //((CheckBox)(gvTestList.Rows[e.Row.RowIndex].Cells[2].FindControl("chkCharges"))).Enabled=false;
                ((CheckBox)(e.Row.Cells[2].FindControl("chkCharges"))).Enabled = false;
                ((LinkButton)(e.Row.Cells[0].Controls[0])).Enabled = false;
                ((LinkButton)e.Row.Cells[3].FindControl("lnkbatch")).Enabled = false;

            }

            string BatchNo = gvTestList.DataKeys[e.Row.RowIndex].Values["TestBatchNo"].ToString().Trim();
            if (BatchNo != null && BatchNo != "0")
            {
                e.Row.BackColor = System.Drawing.Color.Aqua;

                container.FindControl("lnkbatch").Visible = true;
                //pnlpopup.Visible = true;
            }

        }

    }

    protected void gvTestList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //dt.Columns.Add("testid");
        //dt.Columns.Add("testname");
        //dt.Columns.Add("amount");
        //dt.Columns.Add("enteredon");
        //dt.Columns.Add("deliverydate");
        //dt.Columns.Add("Urgent");
        //dt.Columns.Add("sectionid");
        //dt.Columns.Add("testgroupid");
        //dt.Columns.Add("methodid");

        if (e.CommandName == "Select")
        {
            Label1.Text = "";
            DataTable dt = new DataTable();
            string test_groupID = "";
            string section_id = "";
            string batchtime = "";
            createTable(dt);
            string Delivery_Date = "";
            if (Session["dt"].Equals(""))
            {
                Session["dt"] = dt;
            }
            else
            {
                dt = (DataTable)Session["dt"];
            }

            if (dt.Columns.Count == 0)
            {
                createTable(dt);
                Session["dt"] = dt;
            }
            ////////////////////////////////////////////////////////////////
            int i = int.Parse(e.CommandArgument.ToString());
            batchtime = gvTestList.DataKeys[i].Values["batchtime"].ToString().Trim();
            if (dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    if (dt.Rows[j]["testname"].ToString().Trim().Equals(((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim()))
                    {
                        Label1.Text = dt.Rows[j]["testname"].ToString().Trim() + ": already selected";
                        return;
                    }
                }
            }
            /////////////////////////////////////Getting Nearest Delivery Date/Time/////////////////////////////////////
            /////////////Checking Delivery Date after Specimen Collection////////////////////////////
            if (gvTestList.DataKeys[i].Values[4].ToString() == "Y")
            {
                Delivery_Date = "On Specimen Collection.";
            }
            else
            {
                #region getting nearest Delivery Time
                int addhours = 0;
                clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
                obj_Schedule.TestID = gvTestList.DataKeys[i].Value.ToString();

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
                        if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString())) || (todaynum != Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString()) && gvTestList.DataKeys[i].Values["External_orgid"].ToString() != "0" && !istodayperformingday(performingdates)))
                        {
                            date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            try
                            {

                                date_today = DateTime.Now.AddDays(Convert.ToInt16(gvTestList.DataKeys[i]["traveltime"].ToString().Trim()) / (60 * 24)).ToString("dd/MM/yyyy");
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

                    else// if (dv[0]["Type"].ToString().Trim() == "Daily")
                    {
                        Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                    }
                }
                else
                {
                    Delivery_Date=System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                }

                /////////////////////Adding Method Time/////////////////////////////
                clsBLTest obj_Test = new clsBLTest();
                obj_Test.TestID = gvTestList.DataKeys[i].Value.ToString();
                DataView dv_method = obj_Test.GetAll(8);
                if (dv_method.Count > 0)
                {
                    addhours = 0;
                    //method_id=dv_method[0]["MethodID"].ToString();
                    if (dv_method[0]["TAT"].ToString() == "D")
                    {
                        if (rdoUrgent.Checked == true)
                        {
                            addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                        }
                        else
                        {
                            addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                        }
                        addhours = addhours * 24;
                    }
                    else if (dv_method[0]["TAT"].ToString() == "H")
                    {
                        if (rdoUrgent.Checked == true)
                        {
                            addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                        }
                        else
                        {
                            addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                        }
                    }
                    else if (dv_method[0]["TAT"].ToString() == "W")
                    {
                        if (rdoUrgent.Checked == true)
                        {
                            addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                        }
                        else
                        {
                            addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                        }
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
                ////////////////////////////////////////////////////////////////////////
                #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
                if (gvTestList.DataKeys[i].Values[5].ToString().Trim() == "N")
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

                #endregion
            }
            ////////////////////////////////////////----------------------------///////////////////////////////////////

            ///////////////////////////////////////Getting Secction and TestGrupIDs///////////////////////////////////
            #region getting Section and TestGroupIDs
            //string test_groupID = "";
            //string section_id = "";

            if (!_testgroupID.Equals("") && !_testgroupID.Equals("-1"))
            {
                test_groupID = _testgroupID;
                section_id = _sectionid;

            }
            else
            {
                PatientRegView getgroup = new PatientRegView();
                getgroup.TestId = gvTestList.DataKeys[i].Value.ToString().Trim();
                DataView sectionandgroup = getgroup.GetAll(20);
                section_id = sectionandgroup[0]["SectionID"].ToString();
                test_groupID = sectionandgroup[0]["TESTGROUPID"].ToString();

            }
            #endregion


            DataRow dr = dt.NewRow();

            // dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
            dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
            dr["testname"] = ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim();
            dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
            dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
            if (gvTestList.DataKeys[i].Values["External_orgid"] != "0")
            {
                _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(gvTestList.DataKeys[i].Values["traveltime"].ToString().Trim()));

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
            if (int.Parse(gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim()) > 0 && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != "")
            {
                if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()))
                {
                    _deliverydate = _deliverydate.AddDays(1);
                    Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                }
                else
                {
                    Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                }
            }
            dr["deliverydate"] = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).ToString("dd/MM/yyyy hh:mm:ss tt");

            if (rdoNormal.Checked == true)
            {
                dr["Urgent"] = "N";
            }
            else if (rdoUrgent.Checked == true)
            {
                dr["Urgent"] = "U";
            }
            dr["sectionid"] = section_id;
            dr["testgroupid"] = test_groupID;
            dr["methodid"] = gvTestList.DataKeys[i].Values[3].ToString();
            dr["procedureid"] = gvTestList.DataKeys[i].Values["Procedureid"].ToString().Trim();
            dr["External_orgid"] = gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim();
            dr["TestCost"] = gvTestList.DataKeys[i].Values["TestCost"].ToString().Trim();
            dt.Rows.Add(dr);
            gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;

            Session["dt"] = dt;
            //dt.DefaultView.Sort = "deliverydate DESC";
            gvSelectedTests.DataSource = dt;
            gvSelectedTests.DataBind();

            lnkbtnSlctRemoveAll.Visible = true;
            int totalamount = 0;

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                totalamount += Convert.ToInt32(dt.Rows[j]["amount"].ToString().Trim());
            }
            lblTotalCharges.Text = totalamount.ToString().Trim() + " Rupees Only";
        }
    }

    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string GetDynamicContent(string contextKey)
    {
        return default(string);
    }

    protected void ibtnsavepop_Click(object sender, ImageClickEventArgs e)
    {
        lblErrMsg.Text = "Hi I have been Called";
    }

    protected void lnkbatch_Command(object sender, CommandEventArgs e)
    {
        string batchtime = "";
        if (e.CommandName == "Selection")
        {
            int testselectedcount = 0;
            int index = Convert.ToInt16(e.CommandArgument);
            string batchNo = gvTestList.DataKeys[index].Values["TestBatchNo"].ToString().Trim();

            Label1.Text = "";
            string method_id = "";
            string Delivery_Date = "";
            DataTable dt = new DataTable();
            createTable(dt);

            int count = 0;
            if (Session["dt"].Equals(""))
                Session["dt"] = dt;
            else
                dt = (DataTable)Session["dt"];

            if (dt.Columns.Count == 0)
            {
                createTable(dt);
                Session["dt"] = dt;
            }


            for (int i = 0; i < gvTestList.Rows.Count; i++)
            {
                batchtime = gvTestList.DataKeys[i].Values["batchtime"].ToString().Trim();
                testselectedcount = 0;
                if (gvTestList.DataKeys[i].Values["TestBatchNo"].ToString().Trim() == batchNo.Trim())
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {

                            if (dt.Rows[j]["testname"].ToString().Trim().Equals(((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim()))
                            {
                                Label1.Text += dt.Rows[j]["testname"].ToString().Trim() + ": already selected <br />";
                                testselectedcount++;
                                break;
                                //return;
                            }
                        }
                        if (testselectedcount > 0 || ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Enabled == false)
                        {
                            continue;
                        }
                    }
                    /////////////////////////////////////Getting Nearest Delivery Date/Time/////////////////////////////////////
                    /////////////Checking Delivery Date after Specimen Collection////////////////////////////
                    if (gvTestList.DataKeys[i].Values[4].ToString() == "Y")
                    {
                        Delivery_Date = "On Specimen Collection.";
                    }
                    else
                    {
                        #region getting nearest Delivery Time
                        int addhours = 0;
                        clsBLTestSchedule obj_Schedule = new clsBLTestSchedule();
                        obj_Schedule.TestID = gvTestList.DataKeys[i].Value.ToString();

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
                                if ((TimeSpan.Parse(batchtime) > TimeSpan.Parse(DateTime.Now.ToString("HH:mm")) && todaynum == Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString())) || (todaynum != Convert.ToInt16(gvTestList.DataKeys[i]["cutoffday"].ToString()) && gvTestList.DataKeys[i].Values["External_orgid"].ToString() != "0" && !istodayperformingday(performingdates)))
                                {
                                    date_today = System.DateTime.Now.ToString("dd/MM/yyyy");
                                }
                                else
                                {
                                    try
                                    {

                                        date_today = DateTime.Now.AddDays(Convert.ToInt16(gvTestList.DataKeys[i]["traveltime"].ToString().Trim()) / (60 * 24)).ToString("dd/MM/yyyy");
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

                            else// if (dv[0]["Type"].ToString().Trim() == "Daily")
                            {
                                Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                            }
                        }
                        else
                        {
                            Delivery_Date = System.DateTime.Now.AddHours(addhours).ToString("dd/MM/yyyy hh:mm:ss tt");
                        }

                        /////////////////////Adding Method Time/////////////////////////////
                        clsBLTest obj_Test = new clsBLTest();
                        obj_Test.TestID = gvTestList.DataKeys[i].Value.ToString();
                        DataView dv_method = obj_Test.GetAll(8);
                        if (dv_method.Count > 0)
                        {
                            addhours = 0;
                            //method_id=dv_method[0]["MethodID"].ToString();
                            if (dv_method[0]["TAT"].ToString() == "D")
                            {
                                if (rdoUrgent.Checked == true)
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                                }
                                else
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                                }
                                addhours = addhours * 24;
                            }
                            else if (dv_method[0]["TAT"].ToString() == "H")
                            {
                                if (rdoUrgent.Checked == true)
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                                }
                                else
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                                }
                            }
                            else if (dv_method[0]["TAT"].ToString() == "W")
                            {
                                if (rdoUrgent.Checked == true)
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["minTime"].ToString());
                                }
                                else
                                {
                                    addhours = Convert.ToInt32(dv_method[0]["maxtime"].ToString());
                                }
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
                        ////////////////////////////////////////////////////////////////////////
                        #region Adjusting Delivery Time For those Tests Which Couldnt be Delivered round the Clock
                        if (gvTestList.DataKeys[i].Values[5].ToString().Trim() == "N")
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

                        #endregion
                    }
                    ////////////////////////////////////////----------------------------///////////////////////////////////////

                    ///////////////////////////////////////Getting Secction and TestGrupIDs///////////////////////////////////
                    #region getting Section and TestGroupIDs
                    string test_groupID = "";
                    string section_id = "";

                    if (!_testgroupID.Equals("") && !_testgroupID.Equals("-1"))
                    {
                        test_groupID = _testgroupID;
                        section_id = _sectionid;

                    }
                    else
                    {
                        PatientRegView getgroup = new PatientRegView();
                        getgroup.TestId = gvTestList.DataKeys[i].Value.ToString().Trim();
                        DataView sectionandgroup = getgroup.GetAll(20);
                        section_id = sectionandgroup[0]["SectionID"].ToString();
                        test_groupID = sectionandgroup[0]["TESTGROUPID"].ToString();

                    }
                    #endregion


                    DataRow dr = dt.NewRow();

                    // dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                    dr["testid"] = gvTestList.DataKeys[i].Value.ToString().Trim();
                    dr["testname"] = ((LinkButton)gvTestList.Rows[i].Cells[0].Controls[0]).Text.Trim();
                    dr["amount"] = gvTestList.Rows[i].Cells[1].Text.Trim();
                    dr["enteredon"] = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    DateTime _deliverydate = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false));
                    if (gvTestList.DataKeys[i].Values["External_orgid"] != "0")
                    {
                        _deliverydate = _deliverydate.AddMinutes(Convert.ToInt32(gvTestList.DataKeys[i].Values["traveltime"].ToString().Trim()));

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
                    if (int.Parse(gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim()) > 0 && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != null && gvTestList.DataKeys[i].Values["ReportingTime"].ToString().Trim() != "")
                    {
                        if (TimeSpan.Parse(System.DateTime.Now.ToString("HH:mm")) > TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()))
                        {
                            _deliverydate = _deliverydate.AddDays(1);
                            Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                        }
                        else
                        {
                            Delivery_Date = _deliverydate.ToString("dd/MM/yyyy") + " " + TimeSpan.Parse(gvTestList.DataKeys[i].Values["ReportingTime"].ToString()).ToString();
                        }
                    }
                    dr["deliverydate"] = DateTime.Parse(Delivery_Date, new CultureInfo("en-GB", false)).ToString("dd/MM/yyyy hh:mm:ss tt"); ;

                    if (rdoNormal.Checked == true)
                    {
                        dr["Urgent"] = "N";
                    }
                    else if (rdoUrgent.Checked == true)
                    {
                        dr["Urgent"] = "U";
                    }
                    dr["sectionid"] = section_id;
                    dr["testgroupid"] = test_groupID;
                    dr["methodid"] = gvTestList.DataKeys[i].Values[3].ToString();
                    dr["procedureid"] = gvTestList.DataKeys[i].Values["Procedureid"].ToString().Trim();
                    dr["External_orgid"] = gvTestList.DataKeys[i].Values["External_orgid"].ToString().Trim();
                    dr["TestCost"] = gvTestList.DataKeys[i].Values["TestCost"].ToString().Trim();
                    dt.Rows.Add(dr);
                    gvTestList.Rows[i].BackColor = System.Drawing.Color.SlateGray;

                }
                else
                {
                    count += 1;
                }
            }
            if (count == gvTestList.Rows.Count)
            {
                Label1.Text = "No test is selected";
                return;
            }

            Session["dt"] = dt;
            //dt.DefaultView.Sort = "deliverydate DESC";
            gvSelectedTests.DataSource = dt;
            gvSelectedTests.DataBind();

            lnkbtnSlctRemoveAll.Visible = true;
            int totalamount = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalamount += Convert.ToInt32(dt.Rows[i]["amount"].ToString().Trim());
            }
            lblTotalCharges.Text = totalamount.ToString().Trim() + " Rupees Only";



        }
    }

    protected void btnNameSearch_Click(object sender, EventArgs e)
    {
        Fillpatientinfo2();
    }


    protected void btnPRSearch_Click(object sender, ImageClickEventArgs e)
    {
        Fillpatientinfo2();
    }

    private void Fillpatientinfo2()
    {

        clsBLPatientSearch objPatientSearch = new clsBLPatientSearch();

        SComponents objComp = new SComponents();
        DataView dv = null;
        int count = 0;
        if (!txtPRSearch.Text.Trim().Replace("__-__-______", "").Equals(""))
        {
            if (txtPRSearch.Text.Trim().Contains("-"))
            {
                objPatientSearch.PRNO = this.txtPRSearch.Text;

            }
            else
            {
                objPatientSearch.PRNO = txtPRSearch.Text.Substring(0, 2) + "-" + txtPRSearch.Text.Substring(2, 2) + "-" + txtPRSearch.Text.Substring(4);
            }
            count++;
        }
        if (txtmobilesearch.Text.Trim() != "")
        {
            objPatientSearch.CellNumber = txtmobilesearch.Text.Trim();
            count++;
        }
        if (txtNameSearch.Text.Trim() != "")
        {
            objPatientSearch.FName = txtNameSearch.Text;
            count++;
        }
        if (count > 0)
        {
            dv = objPatientSearch.GetAll(1);
        }

        if (dv.Count > 0)
        {
            if (dv.Table.Rows[0]["EXPIRE"].ToString().Equals("Y"))
            {
                this.lblErrMsg.Text = " This patient has been expired. Visit can't be made for this patient.";
                //  this.lbtnSave.Enabled = false;
                // this.ddlSalutation.SelectedItem.Selected = false;
                //this.ddlSalutation.Items.FindByValue(dv.Table.Rows[0]["SALUTATION"].ToString().Trim()).Selected = true;
                // lblPatientName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim() + " " + dv.Table.Rows[0]["MNAME"].ToString().Trim() + " " + dv.Table.Rows[0]["LNAME"].ToString().Trim();
                //txtFName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim();
                //txtMName.Text = dv.Table.Rows[0]["MNAME"].ToString().Trim();
                //txtLName.Text = dv.Table.Rows[0]["LNAME"].ToString().Trim();
                //txtdOB.Text = dv.Table.Rows[0]["DOB"].ToString().Trim();
                // lblGender.Text = dv.Table.Rows[0]["SEX"].ToString().Trim();
                // lblMSStatus.Text = dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim();
                //this.ddlSex.SelectedItem.Selected = false;
                //this.ddlSex.Items.FindByValue(dv.Table.Rows[0]["SEX"].ToString().Trim()).Selected = true;
                //this.ddlMaritalStatus.SelectedItem.Selected = false;
                //this.ddlMaritalStatus.Items.FindByValue(dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim()).Selected = true;
                return;
            }


            else
            {
                gvPRNo.DataSource = dv;
                gvPRNo.DataBind();

                if (gvPRNo.Rows.Count == 1)
                {
                    InsertVisit(0);
                }
                // lblPRNO.Text = dv.Table.Rows[0]["PRNO"].ToString().Trim();
                //this.ddlSalutation.SelectedItem.Selected = false;
                //this.ddlSalutation.Items.FindByValue(dv.Table.Rows[0]["SALUTATION"].ToString().Trim()).Selected = true;
                //  lblPatientName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim() + " " + dv.Table.Rows[0]["MNAME"].ToString().Trim() + " " + dv.Table.Rows[0]["LNAME"].ToString().Trim();
                //  lblGender.Text = dv.Table.Rows[0]["SEX"].ToString().Trim();
                // lblMSStatus.Text = dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim();
                //txtFName.Text = dv.Table.Rows[0]["FNAME"].ToString().Trim();
                //txtMName.Text = dv.Table.Rows[0]["MNAME"].ToString().Trim();
                //txtLName.Text = dv.Table.Rows[0]["LNAME"].ToString().Trim();
                //txtdOB.Text = dv.Table.Rows[0]["DOB"].ToString().Trim();
                //this.ddlSex.SelectedItem.Selected = false;
                //this.ddlSex.Items.FindByValue(dv.Table.Rows[0]["SEX"].ToString().Trim()).Selected = true;
                //this.ddlMaritalStatus.SelectedItem.Selected = false;
                //this.ddlMaritalStatus.Items.FindByValue(dv.Table.Rows[0]["MARITALSTATUS"].ToString().Trim()).Selected = true;
                lblErrMsg.Text = "";
                // lbtnSave.Enabled = true;
            }
        }
        else
        {
            lblErrMsg.Text = "Patient not found!";
            gvPRNo.DataSource = "";
            gvPRNo.DataBind();
            //ClearAll();
        }

    }






    protected void btnMobileSearch_Click(object sender, ImageClickEventArgs e)
    {
        Fillpatientinfo2();
    }

    protected void gvPRNo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        InsertVisit(Convert.ToInt16(e.CommandArgument));
    }

    private void InsertVisit(int index)
    {
        bool isSuccessful = true;

        clsBLPatientVisitRegistrationM objPVisitRegM = new clsBLPatientVisitRegistrationM();
        objPVisitRegM.PRNO = gvPRNo.Rows[index].Cells[1].Text.Trim();
        objPVisitRegM.VisitDateTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPVisitRegM.Condition = "N";// this.ddlCondition.SelectedItem.Value;
        objPVisitRegM.FollowUp = "N";// (this.chkFollowUp.Checked == true) ? "Y" : "N";
        objPVisitRegM.Emergency = "N";// (this.chkEmergency.Checked == true) ? "Y" : "N";
        objPVisitRegM.TotalAmount = "0";
        objPVisitRegM.EnteredBy = Session["LoginID"].ToString();
        objPVisitRegM.EnteredAt = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objPVisitRegM.MStatus = "A";
        if (!objPVisitRegM.ValidationM())
        {
            this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
            return;
        }

        // Service Details
        string[,] VisitDetails = new string[1, 5];
        VisitDetails[0, 0] = "011"; //Department
        VisitDetails[0, 1] = "0063";// GetSubDepID();//SubDep ID
        VisitDetails[0, 2] = ""; //ServiceID;
        VisitDetails[0, 3] = "0"; //Amount;
        VisitDetails[0, 4] = "N";
        for (int i = 0; i <= VisitDetails.GetUpperBound(0); i++)
        {
            objPVisitRegM.DepartmentID = "011"; //Department
            objPVisitRegM.SubDepartmentID = VisitDetails[i, 1]; //SubDepartment
            objPVisitRegM.ServiceID = VisitDetails[i, 1]; //ServiceID;
            objPVisitRegM.Amount = VisitDetails[i, 1]; //Amount;
            objPVisitRegM.Status = VisitDetails[i, 1]; // Status                                
            if (!objPVisitRegM.ValidationD2())
            {
                this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
                return;
            }
        }
        isSuccessful = objPVisitRegM.Insert(VisitDetails);
        if (!isSuccessful)
        {
            this.lblErrMsg.Text = "<br>" + objPVisitRegM.ErrorMessage + "<br><br>";
        }
        else
        {
            //this.txtPatientVisitNo.Text = objPVisitRegM.VisitNo;
            // this.txtPatientVisitNo.ToolTip = objPVisitRegM.VisitNo;
            //PrintVisitSlip(this.txtPatientVisitNo.Text);
            // Session["PrintVisitSlip"] = (this.chkPrint.Checked == true) ? "Y" : "N";
            // ClearAll();
            //if (Request.QueryString.Get("appid") != null)
            //{
            //    clsBlAppointment objApp = new clsBlAppointment();
            //    objApp.PERSONID = Request.QueryString.Get("appid");
            //    objApp.Update();
            //}
            fsetinvestbooking.Visible = true;
            fsetsearch.Visible = false;
            //lblPRNO.Text = Request.QueryString.Get("prno");
            //lblVisitno.Text = Request.QueryString.Get("visitno");
            //fillPatientInfo();
            ////fillDepartmentInfo();
            //fillSubdepartmentInfo();
            ////fillGroup();
            //fillOriginBy();
            //fillRefferedBy();
            lblPRNO.Text = gvPRNo.Rows[index].Cells[1].Text.Trim();
            lblVisitno.Text = objPVisitRegM.VisitNo.ToString().Trim();
            fillPatientInfo();
            fillSubdepartmentInfo();
            fillOriginBy();
            fillRefferedBy();
            this.lblErrMsg.Text = "<br><font color='Green'>Visit has been done successfully.</font><br><br>";
            //Response.Redirect("wfrmPatientReg.aspx");
        }
    }

    protected void btnClose1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
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
