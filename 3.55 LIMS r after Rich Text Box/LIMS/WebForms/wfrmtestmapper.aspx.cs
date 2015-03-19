using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;
using HMIS.LIMS.WebForms;
using LS_BusinessLayer.OliveService;
public partial class LIMS_WebForms_wfrmtestmapper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            clsBLUMatrix UMatrix = new clsBLUMatrix();
            UMatrix.ApplicationID = "001";
            UMatrix.FormID = "135";
            UMatrix.PersonID = Session["loginid"].ToString();
            DataView dvUMatrix = UMatrix.GetAll(1);
            string sRigth = dvUMatrix[0]["Rec"].ToString();
            if (sRigth.Equals("0"))
            {
                Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
            }
            else
            {
                FillDG();
               FillCliqueTests();
               txtCliqSearch.Focus();
              
            }
        }
    }
    private void FillDG()
    {
        clsBLTest objTGroup = new clsBLTest();



        DataView dvTGroup = objTGroup.GetAll(18);

        if (dvTGroup.Count > 0)
        {
            //  dvTGroup.Sort = DGSort;
            this.dgInternal.DataSource = dvTGroup;
            this.dgInternal.DataBind();
            //  this.dg.Visible = true;
        }
        else
        {
            //   this.dgSectionList.Visible = false;
        }
    }
    private void FillCliqueTests()
    {
        OliveService client = new OliveService();
        DataSet dvCliquetest = client.GEtCliqueClinicTests();
        if (dvCliquetest.Tables.Count > 0)
        {
            dgExternal.DataSource = dvCliquetest.Tables[0].DefaultView;
            dgExternal.DataBind();
            //dgcliquetest.Visible = true;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string cliquetestid = "";
        string internaltestid = "";
        string testname = "";
      // foreach( datag
        foreach (DataGridItem rowitem in dgExternal.Items)
        {
            CheckBox chk = (CheckBox)rowitem.FindControl("dgchkActive");
            if (chk.Checked)
            {
                HiddenField testid = (HiddenField)rowitem.FindControl("Cliquetestid");
                cliquetestid = testid.Value.ToString();
                break;
            }
   
        
        }
        foreach (DataGridItem rowitem in dgInternal.Items)
        {
            CheckBox chk = (CheckBox)rowitem.FindControl("dgchkActive");
            if (chk.Checked)
            {
                HiddenField testid = (HiddenField)rowitem.FindControl("testid");
                internaltestid = testid.Value.ToString();
                HiddenField test = (HiddenField)rowitem.FindControl("HtestName");
                testname=test.Value.ToString();

                break;
            }


        }
        if (internaltestid != "" && cliquetestid != "")
        {
            
            clsBLTest test = new clsBLTest();
            test.TestID = internaltestid;
            test.CliqueTestid = cliquetestid;
            test.Test = testname;
            if (test.UpdateCliqueTest())
            {
                FillDG();
                txtCliqSearch.Focus();
                uncheckall();
            }
            else
            {
                Response.Write(test.ErrorMessage);
            }
        
        }

    }
    private void uncheckall()
    {
        for (int i = 0; i < dgExternal.Items.Count; i++)
        {
            (dgExternal.Items[i].Cells[0].FindControl("dgchkActive") as CheckBox).Checked=false;
        }
        for (int i = 0; i < dgInternal.Items.Count; i++)
        {
            (dgInternal.Items[i].Cells[0].FindControl("dgchkActive") as CheckBox).Checked = false;
        }
    }

    protected void dgInternal_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==ListItemType.AlternatingItem)
        {

            //string testid = dgInternal.DataKeys[].ToString();
            //.Values["testid"].ToString().Trim();
            if (e.Item.Cells[5].Text != "&nbsp;" && e.Item.Cells[5].Text != null)
            {
                e.Item.BackColor = System.Drawing.Color.Aquamarine;
                //(e.Item.Cells[0].FindControl("dgchkActive") as CheckBox).Enabled = false;
            }
        }
    }
}