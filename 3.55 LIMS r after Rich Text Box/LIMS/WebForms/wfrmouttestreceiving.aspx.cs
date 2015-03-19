using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LS_BusinessLayer;
using System.Data;
using System.Globalization;
using System.Text;

public partial class LIMS_WebForms_wfrmouttestreceiving : System.Web.UI.Page
{
   
    
    private static string GVSort = "Labid DESC";
    protected void Page_Load(object sender, EventArgs e)
    {

       

        
        if (User.Identity.IsAuthenticated)
        {
            if (!Page.IsPostBack)
            {
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "127";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                DateTime fromdate = new DateTime();
                fromdate = System.DateTime.Now.AddDays(-7);

                txttodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtfromdate.Text = fromdate.ToString("dd/MM/yyyy");
                // fromdate.Subtract;
                TimeSpan span = new TimeSpan();

                string enddate = DateTime.Now.Subtract(span).ToString();
                FillDropDownLab();
                FillGrid();
                
            }
            

            lblTReached.BackColor = System.Drawing.Color.Orange;
            lblTReached.ForeColor = System.Drawing.Color.Orange;
            LblTExceeded.BackColor = System.Drawing.Color.Red;
            LblTExceeded.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }

    private void FillDropDownLab()
    {
        clsBLTest test = new clsBLTest();
        DataView dv = test.GetAll(17);
        FillDropDownList(this.ddlLab, dv, "ORGID", "NAME");

    }

    private void FillGrid()
    {
        
        clsBLTest test = new clsBLTest();
        test.Fromdate = DateTime.Parse(txtfromdate.Text,new CultureInfo("ur-Pk",false)).ToString("dd/MM/yyyy");
        test.ToDate = DateTime.Parse(txttodate.Text,new CultureInfo("ur-pk",false)).AddDays(1).ToString("dd/MM/yyyy");
        if (ddlLab.SelectedItem.Text != "")
        {
            if (ddlLab.SelectedItem.Text != "Select")
            {
                //test.ExtLabId = ddlLab.SelectedItem.Value.ToString();
                test.ExtOrganizationID = ddlLab.SelectedItem.Value.ToString();
            }
        }
        if (txtLabId.Text != "")
        {
            test.LabId = txtLabId.Text.Trim();
        }

        DataView dv= test.GetAll(14);
        dv.Sort = GVSort;
        if (dv.Count > 0)
        {
            
            dgReceivedTestList.DataSource = dv;
            dgReceivedTestList.DataBind();
            lnkRecieveSelected.Visible = true;
        }
        else
        {
            dgReceivedTestList.DataSource = null;
            dgReceivedTestList.DataBind();
            lnkRecieveSelected.Visible = false;
            Response.Write("No Pending Specimen Found Against Your Request");
            //ClearAll();
        }
    }

    protected void lnkRecieveSelected_Click(object sender, EventArgs e)
    {
        RecieveSelected();
    }

    private void RecieveSelected()
    {
        int countupdated = 0;
        int countchecked = 0;
        foreach (DataGridItem row in dgReceivedTestList.Items)
        {
            if (row.ItemType == ListItemType.Item || row.ItemType == ListItemType.AlternatingItem)
            {
                if ((dgReceivedTestList.Items[row.ItemIndex].FindControl("dgchkActive") as CheckBox).Checked)
                {
                    countchecked++;
                    clsBLCourierbatches objbatch = new clsBLCourierbatches();
                    objbatch.DSerialNo = dgReceivedTestList.Items[row.ItemIndex].Cells[10].Text.Trim();
                    objbatch.Mserialno = dgReceivedTestList.Items[row.ItemIndex].Cells[11].Text.Trim();
                    objbatch.Enteredby = Session["loginid"].ToString().Trim();
                    objbatch.Enteredon = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    objbatch.ClientID = "005";
                    objbatch.StrProcedureId = "002";
                    objbatch.CurrentProcessid = "0010";
                    if (hfParentFile.Value.ToString() == "")
                    {
                        string filename = (dgReceivedTestList.Items[row.ItemIndex].FindControl("fileupload") as AjaxControlToolkit.AsyncFileUpload).FileName.ToString();
                        objbatch.ExtResultReference = Doc_Path() + filename;
                    }
                    else
                        objbatch.ExtResultReference = Doc_Path() + hfParentFile.Value.ToString();
                    
                    if (objbatch.UpdateRecieved())
                    {
                        countupdated++;

                    }
                    else
                    {
                        lblErrMsg.Text += objbatch.StrErrorMessage;
                    }

                }
            }
        }
        if (countchecked == countupdated)
        {
            lblErrMsg.Text = "<font color='green'>All Records successfully moved to next process.</font>";
            FillGrid();
        }
    }

    protected void dgReceivedTestList_Sorting(object sender, GridViewSortEventArgs e)
    {
     
        
    }

    protected void dgReceivedTestList_SortCommand(object source, DataGridSortCommandEventArgs e)
    {
       

        if (e.SortExpression == "BatchNo")
        {
            if (GVSort == "BatchNo ASC")
            {
                GVSort = "BatchNo DESC";
            }
            else
                GVSort = "BatchNo ASC";
        }

        if (e.SortExpression == "LabId")
        {
            if (GVSort == "LabId ASC")
            {
                GVSort = "LabId DESC";
            }
            else
                GVSort = "LabId ASC";
        }

        if (e.SortExpression == "PatientName")
        {
            if (GVSort == "PatientName ASC")
            {
                GVSort = "PatientName DESC";
            }
            else
                GVSort = "PatientName ASC";
        }

        if (e.SortExpression == "Test")
        {
            if (GVSort == "Test ASC")
            {
                GVSort = "Test DESC";
            }
            else
                GVSort = "Test ASC";
        }

        if (e.SortExpression == "BookedOn")
        {
            if (GVSort == "BookedOn ASC")
            {
                GVSort = "BookedOn DESC";
            }
            else
                GVSort = "BookedOn ASC";
        }

        if (e.SortExpression == "DispatchedOn")
        {
            if (GVSort == "DispatchedOn ASC")
            {
                GVSort = "DispatchedOn DESC";
            }
            else
                GVSort = "DispatchedOn ASC";
        }

        if (e.SortExpression == "DeliveryDate")
        {
            if (GVSort == "DeliveryDate ASC")
            {
                GVSort = "DeliveryDate DESC";
            }
            else
                GVSort = "DeliveryDate ASC";
        }

        if (e.SortExpression == "Destination")
        {
            if (GVSort == "Destination ASC")
            {
                GVSort = "Destination DESC";
            }
            else
                GVSort = "Destination ASC";
        }
        FillGrid();
    }

    protected void dgReceivedTestList_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            clsBLTest test = new clsBLTest();
            DataView dv = test.GetAll(16);
            int threshold = Convert.ToInt32(dv[0]["THRESHOLDTIME"].ToString());
            //string ss = e.Item.Cells[8].Text.ToString();

            DateTime st = DateTime.Parse(e.Item.Cells[8].Text.ToString(), new CultureInfo("ur-pk", false));
         //   DateTime dt = Convert.ToDateTime(st);
            TimeSpan diff = st-System.DateTime.Now;
            if (diff.TotalHours < threshold)
            {
                e.Item.BackColor = System.Drawing.Color.Orange;
                if(diff.TotalHours<0)
                {
                    e.Item.BackColor=System.Drawing.Color.Red;
                }
            }




        
        }
    }

    protected void ibtnsearch_Click(object sender, ImageClickEventArgs e)
    {
        FillGrid();
    }

    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        ClearAll();
    }

    private void ClearAll()
    {
        txtfromdate.Text = System.DateTime.Now.AddDays(-7).ToString("dd/MM/yyyy");
        txttodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        ddlLab.SelectedItem.Selected = false;
        ddlLab.Items[0].Selected = true;
        txtLabId.Text = String.Empty;
    }

    private void FillDropDownList(DropDownList ddl, DataView dv, string valueField, string textField)
    {
        
        ddl.DataTextField = textField;
        ddl.DataValueField = valueField;
        ddl.DataSource = dv;
        dv.Sort = textField;
        ddl.DataBind();
        ListItem li = new ListItem("Select","-1");
        ddl.Items.Insert(0, li);

        ddl.SelectedItem.Selected = false;
        ddl.Items[0].Selected = true;
        
    }

    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./wfrmMainMenu.aspx");
    }

    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        string fileName = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
        AsyncFileUpload1.SaveAs(Doc_Path() + fileName);
        dgReceivedTestList.Columns[12].Visible = false;
        hfParentFile.Value = fileName;
        
        StringBuilder strScript = new StringBuilder();
        strScript.Append("$(document).ready(function () {");
        strScript.Append("$(\"<%# dgReceivedTestList.ClientID %> tr\")");
        strScript.Append(".find('[id *= fileupload]').css(\"display\", \"none\");");
        strScript.Append("});");
        
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", strScript.ToString(), true);
    }

    protected void fileupload_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        AjaxControlToolkit.AsyncFileUpload afu = (AjaxControlToolkit.AsyncFileUpload)sender;
        string fileName = System.IO.Path.GetFileName(afu.FileName);
        
        afu.SaveAs(Doc_Path() + fileName);
    }

    protected void HideConrol()
    {
        foreach (DataGridItem row in dgReceivedTestList.Items)
        {
            dgReceivedTestList.Items[row.ItemIndex].Cells[12].Style.Add(HtmlTextWriterStyle.Display, "none");// = false;
        }

        
    }

    private string Doc_Path()
    {
        clsBLCourierbatches batch = new clsBLCourierbatches();
        DataView dv = batch.GetAll(3);
        string path = dv[0]["DOC_PATH"].ToString();
        if (dv[0]["DOC_PATH"].ToString().Substring(dv[0]["DOC_PATH"].ToString().Length - 1) == @"\")
        {
            path = dv[0]["DOC_PATH"].ToString();
        }
        else
        {
            path = dv[0]["DOC_PATH"].ToString() + @"\";
        }
        return path;
    }


}