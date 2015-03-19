using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
using System.Collections;
using System.Web.UI.DataVisualization.Charting;
using System.Text;

public partial class wfrmTesthistory : System.Web.UI.Page
{
    private static string sSex = "";
    private static string PAgeIndays = "";
    private static string DSerialNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            // Response.AddHeader("Refresh", "10");
            if (!IsPostBack)
            {

                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "105";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillGV();
               
                
            }
            GetAttributes();
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
        }

    }
    private void FillGV()
    {
        clsBLTestHistory obj_testhistory = new clsBLTestHistory();
        obj_testhistory.PrNo = Request.QueryString["PRNo"].ToString().Trim();
        obj_testhistory.TestID = Request.QueryString["TestID"].ToString();
        DataView dv_testhistory = obj_testhistory.GetAll(1);
        
        if (dv_testhistory.Count > 0)
        {
            DSerialNo = dv_testhistory[0]["DSerialNo"].ToString();
            gvTests.DataSource = dv_testhistory;
            gvTests.DataBind();
        }
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>window.close();</script>");
    }

    protected void gvTests_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string DSerialNo = "";
        string labid = "";
        Control container = e.Row;
        DataControlRowType rowtype = e.Row.RowType;
        if (rowtype == DataControlRowType.DataRow)
        {
            GridView gvAttributes = (GridView)container.FindControl("gvAttributes");
            
            DSerialNo = gvTests.DataKeys[e.Row.RowIndex].Value.ToString();
            DataView dv_Attributes = DisplayAttributes(DSerialNo);
            gvAttributes.DataSource = dv_Attributes;
            gvAttributes.DataBind();
        }
        
    }

    private DataView DisplayAttributes(string serialNo)
    {
        clsBLTestHistory obj_testhistory = new clsBLTestHistory();
        obj_testhistory.DSerialNo = serialNo;


        DataView dv_Attributes = obj_testhistory.GetAll(2);
        if (dv_Attributes.Count > 0)
        {
            return dv_Attributes;
        }
        else
        {
        

            obj_testhistory.DSerialNo = serialNo;
            DataView dv_Agesex = obj_testhistory.GetAll(3);
            PAgeIndays = dv_Agesex[0]["PAgeinDays"].ToString();
            sSex = dv_Agesex[0]["PSex"].ToString();
            dv_Agesex.Dispose();
            obj_testhistory.Age = PAgeIndays;
            if (sSex == "M")
            {
                obj_testhistory.Sex = "Male";
            }
            else if (sSex == "F")
            {
                obj_testhistory.Sex = "Female";
            }
            else
            {
                obj_testhistory.Sex = sSex;
            }
            DataView dvTGeneralTestResult2 = obj_testhistory.GetAll(4);
            return dvTGeneralTestResult2;
        }
        //return dv;
 
    }

    protected void gvAttributes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Control container = e.Row;
        //DataControlRowType rowtype = e.Row.RowType;
        //GridViewRow gvRow = (GridViewRow)e.Row.Parent.Parent.Parent.Parent.Parent;
        //int rownumtest = gvRow.RowIndex;
        //if (rowtype == DataControlRowType.DataRow && rownumtest==0 &&e.Row.Cells[2].Text.Trim()=="N")
        //{
        //    //CheckBox chk = new CheckBox();
        //    //chk.ID = e.Row.Cells[0].Text;
        //    //chk.Text = e.Row.Cells[0].Text;
        //    //chk.TextAlign = TextAlign.Left;
        //    ////chk.AutoPostBack = true;
        //    //Panelchks.Controls.Add(chk);
            
        //}
       // lblErrMsg.Text = Panelchks.Controls.Count.ToString();
 
    }
    protected void btngengraph_Click(object sender, EventArgs e)
    {
        string[] IDs = new string[Panelchks.Controls.Count];
        int count=0;
        for (int i = 0; i < Panelchks.Controls.Count; i++)
        {
            IDs[i] = Panelchks.Controls[i].ClientID.ToString();
           // lblErrMsg.Text += IDs[i] + "<br />";
        }

        for (int j = 0; j < IDs.Length; j++)
        {
            if (((CheckBox)Page.FindControl(IDs[j])).Checked == true)
            {
                count++;
                CreateArray(IDs[j]);
            }
           // lblErrMsg.Text = count + " CheckBoxes are Checked";
        }
            //if (((CheckBox)Page.FindControl("pH")).Checked == true)
            //{
            //    lblErrMsg.Text = "pH is checked";
            //}

    }

    private void GetAttributes()
    {
        clsBLTestHistory obj_hist = new clsBLTestHistory();
        obj_hist.DSerialNo = DSerialNo;
        DataView dv_1 = obj_hist.GetAll(2);
        if (dv_1.Count > 0)
        {
            for (int i = 0; i < dv_1.Count; i++)
            {
                if (dv_1[i]["AttributeType"].ToString().Trim() == "N")
                {
                    CheckBox chk = new CheckBox();
                    chk.ID = dv_1[i]["Attribute"].ToString();
                    chk.Text = dv_1[i]["Attribute"].ToString();
                    Panelchks.Controls.Add(chk);
                }
            }
        }
    }

    private void CreateArray(string s)
    {
        string[] items = new string[gvTests.Rows.Count];
        string[] dates = new string[gvTests.Rows.Count];
        for (int i = 0; i < gvTests.Rows.Count; i++)
        {
            GridView gvAttributes = (GridView)gvTests.Rows[i].Cells[3].FindControl("gvAttributes");
            for (int j = 0; j < gvAttributes.Rows.Count; j++)
            {
                if (gvAttributes.Rows[j].Cells[0].Text.Trim() == s)
                {
                    items[i] = gvAttributes.Rows[j].Cells[1].Text.Trim();
                    
                    break;
                }
            }
            dates[i] = gvTests.Rows[i].Cells[2].Text.Trim();
          //  lblErrMsg.Text += dates[i] + "     " + items[i] + "<br />";
            
        }

        CreateGraph(dates, items,s);

    }

    private void CreateGraph(string[] dates, string[] items,string s)
    {

        //ArrayList listdatasource = new ArrayList();
        //for (int i = 0; i < dates.Length; i++)
        //{
        //    listdatasource.Add(new Record(i,dates[i],Convert.ToDouble(items[i])));
        //}
        try
        {
            //Decimal[] itemsdo_dec = new Decimal[items.Length];

            double[] itemsdo = new double[items.Length];
            DateTime[] datesdo = new DateTime[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                itemsdo[i] = Convert.ToDouble(items[i]);
                datesdo[i] = Convert.ToDateTime(dates[i]);
               
            }
            Chart1.Visible = true;
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            Chart1.Series.Add(series);
            series.XValueType = ChartValueType.DateTime;
            series.YValueType = ChartValueType.Double;
            
            series.Points.DataBindXY(datesdo, itemsdo);
            series.Label = s;
            ////////////////////////////////////////////////////////////////////////////////////////////
            //AjaxControlToolkit.LineChartSeries series1 = new AjaxControlToolkit.LineChartSeries();

            //StringBuilder builder = new StringBuilder();
            //foreach (string value in dates)
            //{
            //    builder.Append(value);
            //    builder.Append(',');
            //}
            //LineChart1.CategoriesAxis = builder.ToString();
            //LineChart1.Series.Add(series1);
            //series1.Data = itemsdo_dec;


            //series1.Name = s;
            

            ////////////////////////////////////////////////////////////////////////////////////////////////
           // series.XValueType = ChartValueType.DateTime;
            //series.YValueType = ChartValueType.Double;
        }
        catch (Exception ee)
        {
            lblErrMsg.Text = ee.ToString();
        }
        // Chart1.Series[0].XValueType = ChartValueType.DateTime;
        //Chart1.Series[0].Points.DataBindXY(datesdo, itemsdo);

    }

    protected void lnkshow_Click(object sender, EventArgs e)
    {
        if (lnkshow.Text == "Hide Details")
        {
            lnkshow.Text = "Show Details";
        }
        else
        {
            lnkshow.Text = "Hide Details";
        }
    }
    }
