using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LS_BusinessLayer;
using System.Data;
using HMIS.LIMS.WebForms;

public partial class LIMS_WebForms_wfrmSubdepartment : System.Web.UI.Page
{
    private static string mode = "";
    private static string SEctionID = "";
    private static string DGSort = "";

    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "134";
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
                }

                //EnableForm(false);
                mode = "Insert";
                DGSort = "DOrder";

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
        this.ibtnSave.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnSave_Click);
        this.ibtnClear.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClear_Click);
        //this.ibtnTest.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnTest_Click);
        this.ibtnClose.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnClose_Click);
        this.dgSectionList.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgGroupList_ItemCreated);
        this.dgSectionList.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_ItemCommand);
        this.dgSectionList.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgGroupList_PageIndexChanged);
        this.dgSectionList.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgGroupList_EditCommand);
        this.dgSectionList.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgGroupList_SortCommand);

    }
    #endregion

    //private void enableform(bool enable)
    //{
    //    this.ibtnsave.enabled = enable;
    //    this.chkactive.enabled = enable;
    //    this.txtsection.enabled = enable;
    //   // this.txtacronym.enabled = enable;
    //}



    private void lbtnSave_Click(object sender, System.EventArgs e)
    {

    }

    private void Insert()
    {
        clsBLSection objTsec = new clsBLSection();

         objTsec.Section = this.txtsection.Text.Trim().ToString();
        objTsec.Active = (this.chkActive.Checked == true) ? "Y" : "N";
       // objTsec.Acronym = this.txtAcronym.Text;
        objTsec.Description = this.txtdesc.Text.Trim().ToString();
        objTsec.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        objTsec.HeadID = "0001";
       // objTsec.Enteredby = Session["loginid"].ToString();

        bool isSuccessful = objTsec.Insert();

        if (!isSuccessful)
        {
            this.lblErrMsg.Text = "<br>" + objTsec.ErrorMessage + "<br><br>";
        }
        else
        {
            this.lblErrMsg.Text = "<br><font color='Green'>Record has been inserted successfully.</font><br><br>";
            RefreshForm();
            FillDG();
        }
    }

    private void Update()
    {
       // clsBLTestGroup objTGroup = new clsBLTestGroup();
        clsBLSection objTsec = new clsBLSection();

        objTsec.Section = this.txtsection.Text.Trim().ToString();
        objTsec.Active = (this.chkActive.Checked == true) ? "Y" : "N";
        // objTsec.Acronym = this.txtAcronym.Text;
        objTsec.Description = this.txtdesc.Text.Trim().ToString();
        objTsec.SectionID = SEctionID;
        objTsec.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
       // objTsec.Enteredby = Session["loginid"].ToString();

        bool isSuccessful = objTsec.Update();

        if (!isSuccessful)
        {
            this.lblErrMsg.Text = "<br>" + objTsec.ErrorMessage + "<br><br>";
        }
        else
        {
            this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
            RefreshForm();
            FillDG();
            this.ibtnSave.ToolTip = "Save";
        }
    }

    private void FillDG()
    {
        clsBLSection objTGroup = new clsBLSection();

       
            DataView dvTGroup = objTGroup.GetAll(4);

            if (dvTGroup.Count > 0)
            {
                dvTGroup.Sort = DGSort;
                this.dgSectionList.DataSource = dvTGroup;
                this.dgSectionList.DataBind();
                this.dgSectionList.Visible = true;
            }
            else
            {
                this.dgSectionList.Visible = false;
            }
        }
       
    



    private void RefreshForm()
    {
        this.txtsection.Text = "";
        //this.txtAcronym.Text = "";
        this.chkActive.Checked = true;
        txtdesc.Text = "";
        SEctionID = "";
        mode = "Insert";
    }

    private void dgGroupList_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
    {
        this.dgSectionList.CurrentPageIndex = e.NewPageIndex;
        FillDG();
    }

    private void dgGroupList_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        this.lblErrMsg.Text = "";
        int index = e.Item.ItemIndex;
        this.chkActive.Checked = ((CheckBox)this.dgSectionList.Items[index].Cells[3].FindControl("dgchkActive")).Checked;
        SEctionID = this.dgSectionList.Items[index].Cells[0].Text;
        this.txtsection.Text = this.dgSectionList.Items[index].Cells[1].Text;
        this.txtdesc.Text = this.dgSectionList.Items[index].Cells[2].Text;
        this.ibtnSave.ToolTip = "Update";
        mode = "Update";
    }

    private void dgGroupList_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
    {
        DGSort = e.SortExpression;
        FillDG();
    }

    private void dgGroupList_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
    {
        if (e.CommandName.Equals("Delete"))
        {
            clsBLTestGroup objTGroup = new clsBLTestGroup();

            objTGroup.TestGroupID = e.Item.Cells[0].Text;
            objTGroup.Active = "D";
            bool isSuccessful = objTGroup.Delete();

            if (!isSuccessful)
            {
                this.lblErrMsg.Text = "<br>" + objTGroup.ErrorMessage + "<br><br>";
            }
            else
            {
                this.lblErrMsg.Text = "<br><font color='Green'>Record has been updated successfully.</font><br><br>";
                RefreshForm();
                FillDG();
            }
        }
    }

    private void dgGroupList_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
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
        uiFacade.SetRowHover(this.dgSectionList, e);
    }

    private void ibtnSave_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        this.lblErrMsg.Text = "";

        if (mode.Equals("Insert"))
        {
            Insert();
        }
        else
        {
            Update();
        }
    }

    private void ibtnClear_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        RefreshForm();
    }


    private void ibtnClose_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>self.close();</script>");
    }
}