using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using LS_BusinessLayer;
using HMIS.LIMS.WebForms;

public partial class LIMS_WebForms_wfrmConsultantsConfiguration : System.Web.UI.Page
{
    private static string DGSort = "PersonName ASC";
    private static string DGSortConsultants = "Active ASC";
    private static string mode = "save";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "114";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                FillDepartmentDDL();
                FillGV();
                
            }
        }

    }

    private void FillDepartmentDDL()
    {
        clsBLConsultants obj_consultant = new clsBLConsultants();

        DataView dv_Departments=obj_consultant.GetAll(1);
        SComponents obj_Comp=new SComponents();
        if (dv_Departments.Count > 0)
        {
            obj_Comp.FillDropDownList(ddlDepartment, dv_Departments, "Name", "DepartmentID");
        }
        obj_Comp = null;
        dv_Departments.Dispose();
        obj_consultant = null;

 
    }

    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedValue.ToString() != "-1")
        {
            FillSubDepartmentDDL();
            FillGV();
        }
        else
        {

            ddlSubDepartment.Enabled = false;
        }
    }

    private void FillSubDepartmentDDL()
    {
        clsBLConsultants obj_consultant = new clsBLConsultants();
        obj_consultant.DepartmentID = ddlDepartment.SelectedValue.ToString();
        DataView dv_SubDepartments = obj_consultant.GetAll(2);
        SComponents obj_Comp = new SComponents();
        if (dv_SubDepartments.Count > 0)
        {
            obj_Comp.FillDropDownList(ddlSubDepartment, dv_SubDepartments, "Name", "SubDepartmentID");
        }
        obj_Comp = null;
        dv_SubDepartments.Dispose();
        obj_consultant = null;
    }
    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
            FillGV();
        }
        else
        {
            gvPersons.DataSource = "";
            gvPersons.DataBind();
            lblCount.Text = "";
        }

    }

    private void FillGV()
    {
        clsBLConsultants obj_consultant = new clsBLConsultants();
        obj_consultant.DepartmentID = ddlDepartment.SelectedValue.ToString();
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
            obj_consultant.SubDepartmentID = ddlSubDepartment.SelectedValue.ToString();
        }
        DataView dv_persons = obj_consultant.GetAll(3);
        if (dv_persons.Count > 0)
        {
            lblCount.Text = "(" + dv_persons.Count + ") Record(s) Found";
            dv_persons.Sort = DGSort;
            gvPersons.DataSource = dv_persons;
            gvPersons.DataBind();
        }
        else
        {
            lblCount.Text = "";
            gvPersons.DataSource = "";
            gvPersons.DataBind();
 
        }
        dv_persons.Dispose();
        obj_consultant = null;

 
    }

    protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            divpersons.Visible = false;
           
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdperson.Value = gvPersons.DataKeys[rowindex].Values[0].ToString();
            hdDepartment.Value = gvPersons.DataKeys[rowindex].Values[1].ToString();
            hdSubDepartment.Value = gvPersons.DataKeys[rowindex].Values[2].ToString();
            FillRegistrationForm(rowindex);
        }
    }

    protected void gvPersons_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "ServiceNo")
        {
            if (DGSort == "ServiceNo ASC")
            {
                DGSort = "ServiceNo DESC";
            }
            else
                DGSort = "ServiceNo ASC";
            
        }
        if (e.SortExpression == "PersonName")
        {
            if (DGSort == "PersonName ASC")
            {
                DGSort = "PersonName DESC";
            }
            else
                DGSort = "PersonName ASC";

        }
        if (e.SortExpression == "Designation")
        {
            if (DGSort == "Designation ASC")
            {
                DGSort = "Designation DESC";
            }
            else
                DGSort = "Designation ASC";

        }
        if (e.SortExpression == "DepSub")
        {
            if (DGSort == "DepSub ASC")
            {
                DGSort = "DepSub DESC";
            }
            else
                DGSort = "DepSub ASC";

        }
        FillGV();
    }


    private void FillRegistrationForm(int rownum)
    {
       // tblRegistration.Visible = true;
        divRegistration.Visible = true;
        string personid = gvPersons.DataKeys[rownum].Values[0].ToString();
        clsBLConsultants obj_consultants = new clsBLConsultants();
        obj_consultants.PersonID = personid;
        DataView dv_Consultant = obj_consultants.GetAll(4);
        string salutation = dv_Consultant[0]["Salutation"].ToString();
        string edu = dv_Consultant[0]["Education"].ToString();
        dv_Consultant.Dispose();
        obj_consultants = null;
        
        txtService.Text = gvPersons.Rows[rownum].Cells[1].Text;
        txtName.Text = gvPersons.Rows[rownum].Cells[2].Text;
        
        txtDepartment.Text = gvPersons.Rows[rownum].Cells[4].Text;
        chkActive.Checked = true;

        txtLevel1.Text = salutation + " " + txtName.Text;
        txtLevel2.Text = edu;
        txtLevel3.Text = gvPersons.Rows[rownum].Cells[3].Text;
        txtLevel4.Text = "";// hdperson.Value + " " + hdDepartment.Value + " " + hdSubDepartment.Value;
        FillGvConsultants();
        FillddlSubDepartments();

    }
    private void FillddlSubDepartments()
    {
        clsBLSection objSection = new clsBLSection();
        SComponents objComp = new SComponents();

        objSection.Active = "Y";
        DataView dvSection = objSection.GetAll(1);
        objComp.FillDropDownList(this.ddlSubDepartments, dvSection, "SectionName", "SectionID");
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            clsBLConsultants obj_Consultant = new clsBLConsultants();
            obj_Consultant.ReportConsultantID = hdReportConsultant.Value.ToString();
            obj_Consultant.DepartmentID = hdDepartment.Value.ToString();
            obj_Consultant.SubDepartmentID = hdSubDepartment.Value.ToString();
            obj_Consultant.PersonID = hdperson.Value.ToString();
            obj_Consultant.Level1 = txtLevel1.Text;
            obj_Consultant.Level2 = txtLevel2.Text;
            obj_Consultant.Level3 = txtLevel3.Text;
            obj_Consultant.Level4 = txtLevel4.Text;
            obj_Consultant.Active = (chkActive.Checked == true) ? "Y" : "N";
            obj_Consultant.LabSubDepartmentID = ddlSubDepartments.SelectedValue.ToString().Trim();
            obj_Consultant.EnteredBy = Session["loginid"].ToString();
            obj_Consultant.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Consultant.ClientID = "0005";
            obj_Consultant.IPAddress = getIpAddress();
            if (ddlDorder.SelectedValue.ToString() != "-1")
            {
                obj_Consultant.DOrder = ddlDorder.SelectedValue.ToString();

            }
            if (obj_Consultant.Update())
            {
                this.lblErr.Text = "<font color='green'>Record Updated successfully.</font>";
                FillGvConsultants();
                RefreshRegistrationForm();
            }
            else
            {
                this.lblErr.Text = obj_Consultant.ErrorMessage;
                RefreshRegistrationForm();
            }
        }
        else
        {
            clsBLConsultants obj_Consultant = new clsBLConsultants();
            obj_Consultant.DepartmentID = hdDepartment.Value.ToString();
            obj_Consultant.SubDepartmentID = hdSubDepartment.Value.ToString();
            obj_Consultant.PersonID = hdperson.Value.ToString();
            obj_Consultant.Level1 = txtLevel1.Text;
            obj_Consultant.Level2 = txtLevel2.Text;
            obj_Consultant.Level3 = txtLevel3.Text;
            obj_Consultant.Level4 = txtLevel4.Text;
            obj_Consultant.Active = (chkActive.Checked == true)? "Y" : "N";
            obj_Consultant.LabSubDepartmentID = ddlSubDepartments.SelectedValue.ToString().Trim();
            obj_Consultant.EnteredBy = Session["loginid"].ToString();
            obj_Consultant.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            obj_Consultant.ClientID = "0005";
            obj_Consultant.IPAddress = getIpAddress();
            if (ddlDorder.SelectedValue.ToString() != "-1")
            {
                obj_Consultant.DOrder = ddlDorder.SelectedValue.ToString();

            }
            if (obj_Consultant.Insert())
            {
                this.lblErr.Text = "<font color='green'>Record inserted successfully.</font>";
                FillGvConsultants();
                RefreshRegistrationForm();
            }
            else
            {
                this.lblErr.Text = obj_Consultant.ErrorMessage;
                //RefreshRegistrationForm();
            }
 
        }

    }

    private string getIpAddress()
    {
        //Dns.GetHostName().ToString();

        string IpAddr = "";
        string host = Dns.GetHostName();
        IPHostEntry ip = Dns.GetHostEntry(host);
        for (int i = 0; i < ip.AddressList.Length; i++)
        {
            if (ip.AddressList[i].AddressFamily.ToString() == "InterNetwork")
            {
                //Console.WriteLine(ip.AddressList[i].AddressFamily.ToString());
                // Console.WriteLine("Host name {1} IPv4 Address {0}", ip.AddressList[i].ToString(), host);
                IpAddr = ip.AddressList[i].ToString();
                break;
            }
        }
        return IpAddr;
    }

    private void FillGvConsultants()
    {
        clsBLConsultants obj_Consultants = new clsBLConsultants();
        if (!ddlSubDepartments.SelectedValue.ToString().Equals("-1"))
        {
            obj_Consultants.LabSubDepartmentID = ddlSubDepartments.SelectedValue.ToString().Trim();
        }
        DataView dv_Consultants = obj_Consultants.GetAll(5);

        if (dv_Consultants.Count > 0)
        {
            dv_Consultants.Sort = DGSortConsultants;
            gvConsultants.DataSource = dv_Consultants;
            gvConsultants.DataBind();
        }
        else
        {
            gvConsultants.DataSource = dv_Consultants;
            gvConsultants.DataBind();
        }
 
    }
    
 protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshRegistrationForm();
        this.lblErr.Text = "";
    }

    private void RefreshRegistrationForm()
    {
        txtName.Text = "";
        txtService.Text = "";
        txtDepartment.Text = "";
        ddlDorder.ClearSelection();
        ddlSubDepartments.ClearSelection();
        ddlDorder.Enabled = true;
        txtLevel1.Text = "";
        txtLevel2.Text = "";
        txtLevel3.Text = "";
        txtLevel4.Text = "";
        hdperson.Value="";
        hdDepartment.Value="";
        hdSubDepartment.Value="";
        ibtnSave.ToolTip = "Insert";
        mode = "save";
       

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        this.txtfilterbyname.Text = "";
        this.txtfilterbyservice.Text = "";
        this.lblErr.Text = "";
        RefreshRegistrationForm();
        divpersons.Visible = true;
        divRegistration.Visible = false;
    }

    protected void gvConsultants_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        this.lblErr.Text = "";
        if (e.CommandName == "Select")
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            hdperson.Value = gvConsultants.DataKeys[rowindex].Values[1].ToString();
            hdReportConsultant.Value = gvConsultants.DataKeys[rowindex].Values[0].ToString();
            FillForm(rowindex);
           
            mode = "Update";
            ibtnSave.ToolTip = "Update";
        }
 
    }

    private void FillForm(int rownum)
    {
        txtLevel1.Text = gvConsultants.Rows[rownum].Cells[2].Text.Trim().Replace("&nbsp;", "");
        txtLevel2.Text = gvConsultants.Rows[rownum].Cells[3].Text.Trim().Replace("&nbsp;", "");
        txtLevel3.Text = gvConsultants.Rows[rownum].Cells[4].Text.Trim().Replace("&nbsp;", "");
        txtLevel4.Text = gvConsultants.Rows[rownum].Cells[5].Text.Trim().Replace("&nbsp;", "");
        txtLevel1.Text = gvConsultants.Rows[rownum].Cells[2].Text.Trim().Replace("&amp;", "&");
        txtLevel2.Text = gvConsultants.Rows[rownum].Cells[3].Text.Trim().Replace("&amp;", "&");
        txtLevel3.Text = gvConsultants.Rows[rownum].Cells[4].Text.Trim().Replace("&amp;", "&");
        txtLevel4.Text = gvConsultants.Rows[rownum].Cells[5].Text.Trim().Replace("&amp;", "&");
        ddlDorder.ClearSelection();
        try
        {
            ddlDorder.Items.FindByValue(gvConsultants.DataKeys[rownum].Values[2].ToString()).Selected = true;
            ddlDorder.Enabled = false;
        }
        catch 
        {
            ddlDorder.Items.FindByValue("-1").Selected = true;
        }
        ddlSubDepartments.ClearSelection();
        try
        {
            ddlSubDepartments.Items.FindByValue(gvConsultants.DataKeys[rownum].Values["labsubdepartmentid"].ToString()).Selected = true;
        }
        catch
        {
            ddlSubDepartments.Items.FindByValue("-1").Selected = true;
        }

        chkActive.Checked = ((CheckBox)gvConsultants.Rows[rownum].Cells[5].FindControl("gvchkActive")).Checked;
        clsBLConsultants obj_Consultant = new clsBLConsultants();
        obj_Consultant.PersonID = hdperson.Value.ToString();
        DataView dv_personinfo = obj_Consultant.GetAll(6);
        txtService.Text = dv_personinfo[0]["ServiceNo"].ToString();
        txtName.Text = dv_personinfo[0]["personName"].ToString();
        txtDepartment.Text = dv_personinfo[0]["depsub"].ToString();
        dv_personinfo.Dispose();
        obj_Consultant = null;


    }

    protected void gvConsultants_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "level1")
        {
            if (DGSortConsultants == "level1 ASC")
            {
                DGSortConsultants = "level1 DESC";
            }
            else
                DGSortConsultants = "level1 ASC";
        }
        if (e.SortExpression == "level2")
        {
            if (DGSortConsultants == "level2 ASC")
            {
                DGSortConsultants = "level2 DESC";
            }
            else
                DGSortConsultants = "level2 ASC";
        }
        if (e.SortExpression == "level3")
        {
            if (DGSortConsultants == "level3 ASC")
            {
                DGSortConsultants = "level3 DESC";
            }
            else
                DGSortConsultants = "level3 ASC";
        }
        if (e.SortExpression == "level4")
        {
            if (DGSortConsultants == "level4 ASC")
            {
                DGSortConsultants = "level4 DESC";
            }
            else
                DGSortConsultants = "level4 ASC";
        }

        if (e.SortExpression == "Active")
        {
            if (DGSortConsultants == "Active ASC")
            {
                DGSortConsultants = "Active DESC";
            }
            else
                DGSortConsultants = "Active ASC";
        }
        if (e.SortExpression == "DOrder")
        {
            if (DGSortConsultants == "DOrder ASC")
            {
                DGSortConsultants = "DOrder DESC";
            }
            else
                DGSortConsultants = "DOrder ASC";
        }
        FillGvConsultants();
    }



    protected void imgClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='javascript'>self.close();</script>");
    }
    protected void imgRefresh_Click(object sender, ImageClickEventArgs e)
    {
        ddlSubDepartment.ClearSelection();
        ddlDepartment.ClearSelection();
        FillGV();
    }
    protected void gvConsultants_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // Create a new WebUIFacade.
        WebUIFacade uiFacade = new WebUIFacade();

        // This is gives a tool tip for each
        // of the columns to sort by.
       // uiFacade.SetHeaderToolTip(e);


        // This sets a class for the link buttons in a grid.
        //uiFacade.SetGridLinkButtonStyle(e);

        // Make the row change color when the mouse hovers over.
        // *** You must have a class called gridHover with a different background 
        // color in your StyleSheet.
        uiFacade.SetRowHover(this.gvConsultants, e);
    }
    protected void gvPersons_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // Create a new WebUIFacade.
        WebUIFacade uiFacade = new WebUIFacade();

        // This is gives a tool tip for each
        // of the columns to sort by.
        // uiFacade.SetHeaderToolTip(e);


        // This sets a class for the link buttons in a grid.
        //uiFacade.SetGridLinkButtonStyle(e);

        // Make the row change color when the mouse hovers over.
        // *** You must have a class called gridHover with a different background 
        // color in your StyleSheet.
        uiFacade.SetRowHover(this.gvPersons, e);
    }
    protected void ddlSubDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGvConsultants();
    }
}