using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;

using System.Globalization;
public partial class LIMS_WebForms_wfrmTestPriceUpdate : System.Web.UI.Page
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
                UMatrix.FormID = "003";
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

    }
    protected void ibtnrefresh_Click(object sender, ImageClickEventArgs e)
    {
        FillgvTest();
        RFound.Visible = true;
        RFound.Text = "Total (" + gvTests.Rows.Count.ToString()+ ") Records Found";
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
        DataView dv = obj_testprice.GetAll(3);
        dv.Sort = DGSort;
        gvTests.DataSource = dv;
        gvTests.DataBind();
    }

    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ddlSection.SelectedValue = "-1";
        ddlTestGroup.SelectedValue = "-1";
        txtTestAttribute.Text = "";
        txteffective.Text = "";
        ddlTestGroup.Enabled = false;
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
                DGSort="SECTIONNAME ASC";
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
        clsBLTestPriceUpdate obj_testprice = new clsBLTestPriceUpdate();
        string _EffectiveDate = txteffective.Text;
        obj_testprice.Percentage = txtTestAttribute.Text;
        DateTime dt = DateTime.Now;
        int year = dt.Year;
        int month = dt.Month;
        int day = dt.Day;
        //DateTime dteffective=Convert.ToDateTime(_EffectiveDate);
        string systemdate = day.ToString() + "/" + month.ToString() + "/" + year.ToString();
        //Convert.ToDateTime(systemdate);
       // int x = DateTime.Now.CompareTo(Convert.ToDateTime(_EffectiveDate));
        if (DateTime.Parse(_EffectiveDate, new CultureInfo("en-GB", false)) != DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
        {

            if (DateTime.Parse(_EffectiveDate, new CultureInfo("en-GB", false)) < DateTime.Parse(systemdate, new CultureInfo("en-GB", false)))
            {
                lblErrMsg.Text = "Date not Correct Please Enter Future Date ";// +x.ToString();

            }
            else
            {
                if (ddlSection.SelectedValue.ToString() != "-1")
                {
                    obj_testprice.SectionID = ddlSection.SelectedValue.ToString();
                    if (ddlTestGroup.SelectedValue.ToString() != "-1")
                    {
                        obj_testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

                    }
                }
                obj_testprice.Effective_Date = _EffectiveDate;
                obj_testprice.EnteredBy = Session["loginid"].ToString();
                obj_testprice.EnteredOn = systemdate;


                obj_testprice.insertall();
                
                obj_testprice=null;
            }

        }
        else
        {
            clsBLTestPriceUpdate obj_testpriceupdate = new clsBLTestPriceUpdate();
            obj_testpriceupdate.Percentage = txtTestAttribute.Text;
            if (ddlSection.SelectedValue.ToString() != "-1")
            {
                obj_testprice.SectionID = ddlSection.SelectedValue.ToString();
                if (ddlTestGroup.SelectedValue.ToString() != "-1")
                {
                    obj_testprice.TestGroupID = ddlTestGroup.SelectedValue.ToString();

                }
            }
            obj_testprice.updateall();
            obj_testprice = null;
 
        }


      
    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {

    }
}
