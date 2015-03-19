using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

using System.Globalization;

public partial class LIMS_WebForms_wfrmTestPriceupdate_new : System.Web.UI.Page
{
    private static string DGSort = "SECTIONNAME DESC";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "123";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }

                FillSectionDDL();

            }
        }
    }
    public void FillSectionDDL()
    {
        clsBLTestPriceUpdate obj_priceupdate = new clsBLTestPriceUpdate();

        SComponents objComp = new SComponents();
        DataView dv = obj_priceupdate.GetAll(1);
        if (dv.Count > 0)
        {
            objComp.FillDropDownList(ddlSection, dv, "SECTIONNAME", "SECTIONID");

        }
        else
        {
            this.lblErrMsg.Text = "No Section found";
        }
        dv.Dispose();
        obj_priceupdate = null;
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlTestGroup.Enabled = true;
        FillTestGroupDDl();
    }
    protected void FillTestGroupDDl()
    {

        clsBLTestPriceUpdate obj_priceupdate = new clsBLTestPriceUpdate();
        obj_priceupdate.SectionID = ddlSection.SelectedValue.ToString();
        SComponents objComp = new SComponents();
        DataView dv = obj_priceupdate.GetAll(2);
        if (dv.Count > 0)
        {
            objComp.FillDropDownList(ddlTestGroup, dv, "TESTGROUP", "TESTGROUPID");

        }
        else
        {
            this.lblErrMsg.Text = "No Test Group Found";
        }
        dv.Dispose();
        obj_priceupdate = null;
    }
    protected void ddlTestGroup_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillgvTest();
        RFound.Visible = true;
        RFound.Text = "Total (" + gvTests.Rows.Count.ToString() + ") Records Found";
        lblErrMsg.Text = "";
    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillgvTest();
        RFound.Visible = true;
        RFound.Text = "Total (" + gvTests.Rows.Count.ToString() + ") Records Found";
        lblErrMsg.Text = "";
    }
    protected void FillgvTest()
    {
        clsBLTestPriceUpdate obj_testprice = new clsBLTestPriceUpdate();
        if (ddlSection.SelectedValue.ToString() != "-1")
        {
            obj_testprice.SectionID = ddlSection.SelectedValue.ToString();
            if (ddlTestGroup.SelectedValue.ToString() != "-1")
            {
                obj_testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

            }
        }
        if (rbtnTest.Checked == true)
        {
            DataView dv = obj_testprice.GetAll(3);
            dv.Sort = DGSort;
            gvTests.DataSource = dv;
            gvTests.Columns[6].Visible = true;
            gvTests.Columns[7].Visible = true;
            gvTests.DataBind();
            
        }
        else if (rbtnGroup.Checked == true)
        {
            DataView dv = obj_testprice.GetAll(5);
            dv.Sort = DGSort;
            gvTests.DataSource = dv;
            gvTests.DataBind();
            gvTests.Columns[6].Visible = false;
            gvTests.Columns[7].Visible = false;
 
        }
    }

    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ddlSection.SelectedValue = "-1";
        ddlTestGroup.SelectedValue = "-1";
        txtTestAttribute.Text = "";
        txteffective.Text = "";
        ddlTestGroup.Enabled = false;
        ibtnSave.Enabled = false;
        lblErrMsg.Text = "";
    }

    protected void gvTests_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    protected void gvTests_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "SECTIONNAME")
        {
            if (DGSort == "SECTIONNAME ASC")
            {
                DGSort = "SECTIONNAME DESC";
            }
            else
            {
                DGSort = "SECTIONNAME ASC";
            }
        }

        else if (e.SortExpression == "TEST")
        {
            if (DGSort == "TEST ASC")
            {
                DGSort = "TEST DESC";
            }
            else
            {
                DGSort = "TEST ASC";
            }

        }
        else if (e.SortExpression == "ACRONYM")
        {
            if (DGSort == "ACRONYM ASC")
            {
                DGSort = "ACRONYM DESC";
            }
            else
            {
                DGSort = "ACRONYM ASC";
            }

        }

        else if (e.SortExpression == "CHARGES")
        {
            if (DGSort == "CHARGES ASC")
            {
                DGSort = "CHARGES DESC";
            }
            else
            {
                DGSort = "CHARGES ASC";
            }

        }
        else if (e.SortExpression == "ChargesURGENT")
        {
            if (DGSort == "ChargesURGENT ASC")
            {
                DGSort = "ChargesURGENT DESC";
            }
            else
            {
                DGSort = "ChargesURGENT ASC";
            }

        }

        else if (e.SortExpression == "effective_date")
        {
            if (DGSort == "effective_date ASC")
            {
                DGSort = "effective_date DESC";
            }
            else
            {
                DGSort = "effective_date ASC";
            }

        }

        else if (e.SortExpression == "charges_new")
        {
            if (DGSort == "charges_new ASC")
            {
                DGSort = "charges_new DESC";
            }
            else
            {
                DGSort = "charges_new ASC";
            }

        }

        else if (e.SortExpression == "UrgentCharges_New")
        {
            if (DGSort == "UrgentCharges_New ASC")
            {
                DGSort = "UrgentCharges_New DESC";
            }
            else
            {
                DGSort = "UrgentCharges_New ASC";
            }

        }


        FillgvTest();


    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        #region new code
        clsBLTestPriceUpdate obj_Testprice = new clsBLTestPriceUpdate();
        DateTime dt = DateTime.Now;
        int year = dt.Year;
        int month = dt.Month;
        int day = dt.Day;
        //DateTime dteffective=Convert.ToDateTime(_EffectiveDate);
        string systemdate = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        if (rbtnTest.Checked == true)
        {
            for (int i = 0; i < gvTests.Rows.Count; i++)
            {
                obj_Testprice.TestID = gvTests.DataKeys[i].Value.ToString();

                obj_Testprice.Charges_Old = gvTests.Rows[i].Cells[4].Text;
                obj_Testprice.Charges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text;
                obj_Testprice.UrgentCharges_Old = gvTests.Rows[i].Cells[6].Text;
                obj_Testprice.UrgentCharges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text;
                obj_Testprice.EnteredBy = Session["loginid"].ToString();
                obj_Testprice.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                obj_Testprice.Type = "T";
                if (ddlTestGroup.SelectedValue.ToString() != "-1")
                {
                    obj_Testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();
                }
                else
                {
                    clsBLTest obj_Test = new clsBLTest();
                    obj_Test.TestID = gvTests.DataKeys[i].Value.ToString();
                    DataView dv_testgroup = obj_Test.GetAll(9);
                    if (dv_testgroup.Count > 0)
                    {
                        obj_Testprice.TestGroupID = dv_testgroup[0]["TESTGROUPID"].ToString();
                    }
                    dv_testgroup.Dispose();
                    obj_Test = null;
                }
                obj_Testprice.Effective_Date = gvTests.Rows[i].Cells[8].Text;
                if (DateTime.Parse(obj_Testprice.Effective_Date, new CultureInfo("en-GB", false)) == DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
                {
                    if (obj_Testprice.update())
                    {

                    }
                    else
                    {
                        lblErrMsg.Text = obj_Testprice.Errormessage;
                    }
                }
                else
                {
                    if (obj_Testprice.insert())
                    {
                        // lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";

                    }
                    else
                    {
                        lblErrMsg.Text = obj_Testprice.Errormessage;
                    }
                }
            }
        }

        else if (rbtnGroup.Checked == true)
        {
            for (int i = 0; i < gvTests.Rows.Count; i++)
            {
                obj_Testprice.TestID = gvTests.DataKeys[i].Value.ToString();

                obj_Testprice.Charges_Old = gvTests.Rows[i].Cells[4].Text;
                obj_Testprice.Charges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text;
               // obj_Testprice.UrgentCharges_Old = gvTests.Rows[i].Cells[6].Text;
              //  obj_Testprice.UrgentCharges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text;
                obj_Testprice.EnteredBy = Session["loginid"].ToString();
                obj_Testprice.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"); ;
                obj_Testprice.Effective_Date = gvTests.Rows[i].Cells[8].Text;
                obj_Testprice.Type = "G";
                obj_Testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

                if (DateTime.Parse(obj_Testprice.Effective_Date, new CultureInfo("en-GB", false)) == DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
                {
                    if (obj_Testprice.updateTestGroupD())
                    {
                        
                    }
                    else
                    {
                        lblErrMsg.Text = obj_Testprice.Errormessage;
                    }
                }
                else
                {
                    if (obj_Testprice.insert())
                    {
                        // lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";

                    }
                    else
                    {
                        lblErrMsg.Text = obj_Testprice.Errormessage;
                    }
                }
            }
        }
        FillgvTest();
        ibtnSave.Enabled = false;
        #endregion
        #region old code depricated
        //clsBLTestPriceUpdate obj_testprice = new clsBLTestPriceUpdate();
        //string _EffectiveDate = txteffective.Text;
        //obj_testprice.Percentage = txtTestAttribute.Text;
        //DateTime dt = DateTime.Now;
        //int year = dt.Year;
        //int month = dt.Month;
        //int day = dt.Day;
        ////DateTime dteffective=Convert.ToDateTime(_EffectiveDate);
        //string systemdate = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        ////Convert.ToDateTime(systemdate);
        //// int x = DateTime.Now.CompareTo(Convert.ToDateTime(_EffectiveDate));
        //if (DateTime.Parse(_EffectiveDate, new CultureInfo("en-GB", false)) != DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
        //{

        //    if (DateTime.Parse(_EffectiveDate, new CultureInfo("en-GB", false)) < DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
        //    {
        //        lblErrMsg.Text = "Date not applicable Please Enter Future Date ";// +x.ToString();

        //    }
        //    else
        //    {
        //        if (ddlSection.SelectedValue.ToString() != "-1")
        //        {
        //            obj_testprice.SectionID = ddlSection.SelectedValue.ToString();
        //            if (ddlTestGroup.SelectedValue.ToString() != "-1")
        //            {
        //                obj_testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

        //            }
        //        }
        //        obj_testprice.Effective_Date = _EffectiveDate;
        //        obj_testprice.EnteredBy = Session["loginid"].ToString();
        //        obj_testprice.EnteredOn = systemdate;


        //        obj_testprice.insertall();

        //        obj_testprice = null;
        //    }

        //}
        //else
        //{
        //    clsBLTestPriceUpdate obj_testpriceupdate = new clsBLTestPriceUpdate();
        //    obj_testpriceupdate.Percentage = txtTestAttribute.Text;
        //    if (ddlSection.SelectedValue.ToString() != "-1")
        //    {
        //        obj_testprice.SectionID = ddlSection.SelectedValue.ToString();
        //        if (ddlTestGroup.SelectedValue.ToString() != "-1")
        //        {
        //            obj_testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

        //        }
        //    }
        //    obj_testprice.updateall();
        //    obj_testprice = null;

        //}
        //FillgvTest();

        #endregion

    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        lblErrMsg.Text = "";
        ibtnSave.Enabled = true;
        string _EffectiveDate = "";
        double urgentpercent = 0;
        double normalpercent = 0;
        if (txtUrgper.Text != "")
        {
            urgentpercent = Convert.ToDouble(txtUrgper.Text);
        }
        if (txtTestAttribute.Text != "")
        {
            normalpercent = Convert.ToDouble(txtTestAttribute.Text);
        }
        
        if (txteffective.Text != null)
        {
            _EffectiveDate = txteffective.Text;
        }
      
        DateTime dt = DateTime.Now;
        string system_date = dt.Day.ToString() + "/" + dt.Month.ToString() + "/" + dt.Year.ToString();

        if (_EffectiveDate != "__/__/____" && txtTestAttribute.Text != "")
        {
            if (DateTime.Parse(_EffectiveDate, new CultureInfo("en-GB", false)) < DateTime.Parse(system_date, new CultureInfo("en-GB", false)))
            {
                lblErrMsg.Text = "Date not applicable Please Enter Future Date ";// +x.ToString();

            }
            else
            {
                for (int i = 0; i < gvTests.Rows.Count; i++)
                {
                    ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text = Convert.ToInt32(Convert.ToDouble(gvTests.Rows[i].Cells[4].Text) + (Convert.ToDouble(gvTests.Rows[i].Cells[4].Text) * normalpercent) / 100).ToString();
                    #region depricated
                    
                    //if (normalpercent != 0)
                  //  {
                       // if (((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text == "")
                       // {
                           // ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text = Convert.ToInt32(Convert.ToDouble(gvTests.Rows[i].Cells[4].Text) + (Convert.ToDouble(gvTests.Rows[i].Cells[4].Text) * normalpercent) / 100).ToString();
                       // }
                        //else
                        //{
                        //    ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text = Convert.ToInt32(Convert.ToDouble(((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text) + (Convert.ToDouble(((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text) * normalpercent) / 100).ToString();

                        //}
                            // }
                    #endregion
                    
                    gvTests.Rows[i].Cells[8].Text = "";

                    gvTests.Rows[i].Cells[8].Text = txteffective.Text;

                    // }
                    if (rbtnTest.Checked == true)
                    {
                        ((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text = Convert.ToInt32(Convert.ToDouble(gvTests.Rows[i].Cells[6].Text) + (Convert.ToDouble(gvTests.Rows[i].Cells[6].Text) * urgentpercent) / 100).ToString();
                        #region Depricated
                        //if (((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text == "" && gvTests.Rows[i].Cells[6].Text != "&nbsp;")
                       // {
                           

                        //}
                        //else if (((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text != "")
                        //{
                        //    ((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text = (Convert.ToInt32(((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text) + (Convert.ToInt32(((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text) * Convert.ToInt32(Convert.ToDouble(txtTestAttribute.Text))) / 100).ToString();
                        //}
                        #endregion
                    }

                }
            }
        }
        else
        {
            lblErrMsg.Text = "Process failed to initialize. Percentage and Effective Date can't be left empty.";
        }
        
       
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language = 'javascript'>window.close()</script>");
        #region ibtn save code temporary
        //clsBLTestPriceUpdate obj_Testprice = new clsBLTestPriceUpdate();
        //DateTime dt = DateTime.Now;
        //int year = dt.Year;
        //int month = dt.Month;
        //int day = dt.Day;
        ////DateTime dteffective=Convert.ToDateTime(_EffectiveDate);
        //string systemdate = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        //for (int i = 0; i < gvTests.Rows.Count; i++)
        //{
        //    obj_Testprice.TestID = gvTests.DataKeys[i].Value.ToString();

        //    obj_Testprice.Charges_Old = gvTests.Rows[i].Cells[4].Text;
        //    obj_Testprice.Charges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt1"))).Text;
        //    obj_Testprice.UrgentCharges_Old = gvTests.Rows[i].Cells[6].Text;
        //    obj_Testprice.UrgentCharges_New = ((TextBox)(gvTests.Rows[i].FindControl("txt2"))).Text;
        //    obj_Testprice.EnteredBy = Session["loginid"].ToString();
        //    obj_Testprice.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"); ;
        //    obj_Testprice.Effective_Date = gvTests.Rows[i].Cells[8].Text;
        //    if (DateTime.Parse(obj_Testprice.Effective_Date, new CultureInfo("en-GB", false)) == DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
        //    {
        //        if (obj_Testprice.update())
        //        {

        //        }
        //        else
        //        {
        //            lblErrMsg.Text = obj_Testprice.Errormessage;
        //        }
        //    }
        //    else
        //    {
        //        if (obj_Testprice.insert())
        //        {
        //           // lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";

        //        }
        //        else
        //        {
        //            lblErrMsg.Text = obj_Testprice.Errormessage;
        //        }
        //    }
        //}
        //FillgvTest();
        #endregion
    }
    protected void rbtnGroup_CheckedChanged(object sender, EventArgs e)
    {
        lblNormal.Visible = false;
        lblUrgent.Visible = false;
        txtUrgper.Visible = false;
        FillgvTest();
        RFound.Text = "Total (" + gvTests.Rows.Count.ToString() + ") Records Found";
        
    }
    protected void rbtnTest_CheckedChanged(object sender, EventArgs e)
    {
        lblNormal.Visible = true;
        lblUrgent.Visible = true;
        txtUrgper.Visible = true;
        FillgvTest();
        RFound.Text = "Total (" + gvTests.Rows.Count.ToString() + ") Records Found";
    }
}