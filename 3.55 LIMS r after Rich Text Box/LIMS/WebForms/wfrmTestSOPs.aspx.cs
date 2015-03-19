using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
using System.IO;

public partial class LIMS_WebForms_wfrmTestSOPs : System.Web.UI.Page
{
    private static string mode = "";
    private static string doc_path = "";
    private static string DGSort = "Test ASC";
    private static string strsoptypeid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (!IsPostBack)
            {
                
                clsBLUMatrix UMatrix = new clsBLUMatrix();
                UMatrix.ApplicationID = "001";
                UMatrix.FormID = "117";
                UMatrix.PersonID = Session["loginid"].ToString();
                DataView dvUMatrix = UMatrix.GetAll(1);
                string sRigth = dvUMatrix[0]["Rec"].ToString();
                if (sRigth.Equals("0"))
                {
                    Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
                }
                clsBLPreferenceSettings obj_Pref = new clsBLPreferenceSettings();
                DataView dv = obj_Pref.GetAll(1);
                if (dv.Count > 0)
                {
                    if (dv[0]["DOC_PATH"] != null || dv[0]["DOC_PATH"] != "" || dv[0]["DOC_PATH"] != "&nbsp;")
                    {
                        doc_path = dv[0]["DOC_PATH"].ToString();
                    }


                }
                dv.Dispose();
                FillDDLSubDepartment();
            }
        }

    }

    private void FillDDLSubDepartment()
    {
        clsBLSection obj_Section = new clsBLSection();
        obj_Section.Active="Y";
        DataView dv_Sections = obj_Section.GetAll(1);
        if (dv_Sections.Count > 0)
        {
            SComponents obj_comp = new SComponents();
            obj_comp.FillDropDownList(ddlSubDepartment, dv_Sections, "SectionName", "SectionID");
            obj_comp = null;


        }
        dv_Sections.Dispose();
        obj_Section = null;
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (mode == "Update")
        {
            Update();
        }
        else
        {
            Insert();
        }

    }
    private void Insert()
    {
        clsBlTestSops obj_TestSops = new clsBlTestSops();
        obj_TestSops.TestID = ddlTest.SelectedValue.ToString();
        obj_TestSops.SopTypeID = ddlSopType.SelectedValue.ToString();
        obj_TestSops.Description = txtDescription.Text;

        if (!FileUpload1.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        if (!FileUpload2.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload2.FileName);
                FileUpload2.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path2 = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        if (!FileUpload3.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload3.FileName);
                FileUpload3.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path3 = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        obj_TestSops.EnteredBy = Session["loginid"].ToString();
        obj_TestSops.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_TestSops.ClientID = "0005";
        obj_TestSops.System_Ip = Request.UserHostAddress.ToString();
        if (obj_TestSops.insert())
        {
            RefreshForm();
            this.lblErrMSg.Text = "<font color='green'>Insertion Successful.</font>";
            FillGV();
        }
        else
        {
            lblErrMSg.Text = obj_TestSops.ErrorMessage;
        }

    }

    
    private void Update()
    {
        clsBlTestSops obj_TestSops = new clsBlTestSops();
        obj_TestSops.TestSopID = hdTestSopID.Value.ToString();
        obj_TestSops.TestID = ddlTest.SelectedValue.ToString();
        obj_TestSops.SopTypeID = ddlSopType.SelectedValue.ToString();
        obj_TestSops.Description = txtDescription.Text;

        if (!FileUpload1.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        if (!FileUpload2.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload2.FileName);
                FileUpload2.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path2 = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        if (!FileUpload3.FileName.Equals(""))
        {
            try
            {
                string filename = Path.GetFileName(FileUpload3.FileName);
                FileUpload3.SaveAs(doc_path + @"\" + filename);
                obj_TestSops.Doc_Path3 = doc_path + @"\" + filename;
                //FileUploadControl1.SaveAs(Server.MapPath("~/Uploads/") + filename);
                //objTGenTestResult.path_Img1 = Server.MapPath("~/Uploads/") + filename;

            }
            catch (Exception ee)
            {
                lblErrMSg.Text = ee.ToString();
            }
        }
        obj_TestSops.EnteredBy = Session["loginid"].ToString();
        obj_TestSops.EnteredOn = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
        obj_TestSops.ClientID = "0005";
        obj_TestSops.System_Ip = Request.UserHostAddress.ToString();
        if (obj_TestSops.Update())
        {
            RefreshForm();
            this.lblErrMSg.Text = "<font color='green'>Update Successful.</font>";
            FillGV();
        }
        else
        {
            lblErrMSg.Text = obj_TestSops.ErrorMessage;
        }
    }
    private void FillGV()
    {
        clsBlTestSops obj_TestSops = new clsBlTestSops();
        obj_TestSops.SubDepartmentID = ddlSubDepartment.SelectedValue.ToString();
        DataView dv_TestSops = obj_TestSops.GetAll(1);
        //for (int i = 0; i < dv_TestSops.Count; i++)
        //{
        //    dv_TestSops[i]["Doc_path"] = Server.HtmlDecode(dv_TestSops[i]["Doc_path"].ToString().Trim());
        //}
        if (dv_TestSops.Count > 0)
        {
            lblCount.Text = "(" + dv_TestSops.Count + ") Record(s) Found.";
            dv_TestSops.Sort = DGSort;
            
            gvTestSOP.DataSource = dv_TestSops;
            gvTestSOP.DataBind();
            
        }
        else
        {
            lblCount.Text = "";//<font color='red'>No Record Found</font>";
            gvTestSOP.DataSource = "";
            gvTestSOP.DataBind();
        }
        dv_TestSops.Dispose();
        obj_TestSops = null;
    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {
        RefreshForm();

    }

    private void RefreshForm()
    {
        txtTestName.Text = "";
        txtMethod.Text="";
        txtDescription.Text = "";
       // ddlSubDepartment.ClearSelection();
        ddlTest.ClearSelection();
        ddlSopType.ClearSelection();
        FileUpload1.Visible = true;
        FileUpload2.Visible = true;
        FileUpload3.Visible = true;
        lnkdelfile1.Visible = false;
        lnkdelfile2.Visible = false;
        lnkdelfile3.Visible = false;
        lnkpath1.Visible = false;
        lnkpath2.Visible = false;
        lnkpath3.Visible = false;
        lblErrMSg.Text = "";
        lblCount.Text = "";
        mode = "Save"; 
    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script language='Javascript'>window.close();</script>");
    }

    protected void gvTestSOP_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            int index = Convert.ToInt32(e.CommandArgument.ToString());
            mode = "Update";
            hdTestSopID.Value = gvTestSOP.DataKeys[index].Values[0].ToString();
            this.ibtnSave.ToolTip = "Update";
            FillForm(index);
        }
 
    }
    private void FillForm(int rowindex)
    {
        ddlSubDepartment.ClearSelection();
        ddlSubDepartment.Items.FindByValue(gvTestSOP.DataKeys[rowindex].Values[1].ToString().Trim()).Selected = true;
        ddlTest.ClearSelection();
        ddlTest.Items.FindByValue(gvTestSOP.DataKeys[rowindex].Values["testid"].ToString().Trim()).Selected = true;
        //txtTestName.Text = gvTestSOP.Rows[rowindex].Cells[2].Text.Trim();
        FillMethodandName();
        FillDDLSopTypes();
        ddlSopType.ClearSelection();
        ddlSopType.Items.FindByText(gvTestSOP.Rows[rowindex].Cells[1].Text.Trim()).Selected = true;
        txtDescription.Text = gvTestSOP.DataKeys[rowindex].Values[2].ToString();
        string filepath1 = gvTestSOP.DataKeys[rowindex].Values["doc_path1"].ToString().Trim();
        string filepath2 = gvTestSOP.DataKeys[rowindex].Values["doc_path2"].ToString().Trim();
        string filepath3 = gvTestSOP.DataKeys[rowindex].Values["doc_path3"].ToString().Trim();
        int startingindex = 0;
            if (filepath1 != "" && filepath1 != null && filepath1 != "&nbsp;" && filepath1.Trim() != "X")
            {

                FileUpload1.Visible = false;
                lnkpath1.Visible = true;
                lnkpath1.ToolTip = filepath1;
                lnkdelfile1.Visible = true;
                lnkdelfile1.CommandArgument = filepath1;
               // ((LinkButton)container.FindControl("gvlnkpath1")).ToolTip = filepath1;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).Visible = true;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).CommandArgument = filepath1;

                for (int i = 0; i < filepath1.Length; i++)
                {
                    if (filepath1[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                lnkpath1.Text = filepath1.Substring(startingindex + 1);
            }
            startingindex = 0;

            if (filepath2 != "" && filepath2 != null && filepath2 != "&nbsp;" && filepath2.Trim() != "X")
            {

                FileUpload2.Visible = false;
                lnkpath2.Visible = true;
                lnkpath2.ToolTip = filepath2;
                lnkdelfile2.Visible = true;
                lnkdelfile2.CommandArgument = filepath2;
                // ((LinkButton)container.FindControl("gvlnkpath1")).ToolTip = filepath1;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).Visible = true;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).CommandArgument = filepath1;

                for (int i = 0; i < filepath2.Length; i++)
                {
                    if (filepath2[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                lnkpath2.Text = filepath2.Substring(startingindex + 1);
            }
            startingindex = 0;


            if (filepath3 != "" && filepath3 != null && filepath3 != "&nbsp;" && filepath3.Trim() != "X")
            {

                FileUpload3.Visible = false;
                lnkpath3.Visible = true;
                lnkpath3.ToolTip = filepath3;
                lnkdelfile3.Visible = true;
                lnkdelfile3.CommandArgument = filepath3;
                // ((LinkButton)container.FindControl("gvlnkpath1")).ToolTip = filepath1;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).Visible = true;
                //((LinkButton)container.FindControl("gvlnkdelfile1")).CommandArgument = filepath1;

                for (int i = 0; i < filepath3.Length; i++)
                {
                    if (filepath3[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                lnkpath3.Text = filepath3.Substring(startingindex + 1);
            }
            startingindex = 0;

    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTest.SelectedValue.ToString() != "-1")
        {
            FillMethodandName();
            

            FillDDLSopTypes();

            
        }
    }

    private void FillMethodandName()
    {
        clsBLTest obj_Test = new clsBLTest();
        obj_Test.TestID = ddlTest.SelectedValue.ToString();
        DataView dv_Fillform = obj_Test.GetAll(12);
        txtTestName.Text = ddlTest.SelectedItem.Text;
        if (dv_Fillform.Count > 0)
        {
            if (dv_Fillform[0]["Method"].ToString() == "" || dv_Fillform[0]["Method"].ToString() == "&nbsp;")
            {
                txtMethod.Text = "";
            }
            else
            {
                txtMethod.Text = dv_Fillform[0]["Method"].ToString();
            }
        }
        else
        {
            txtMethod.Text = "";
        }
        dv_Fillform.Dispose();
        obj_Test = null;
 
    }
    private void FillDDLSopTypes()
    {
        clsBlSopTypes obj_Types = new clsBlSopTypes();
        DataView dv_Sops = obj_Types.GetAll(2);
        if (dv_Sops.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlSopType, dv_Sops, "Name", "SopTypeID");
            obj_Comp = null;
        }
        dv_Sops.Dispose();
        obj_Types = null;
    }
  

    protected void ddlSubDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubDepartment.SelectedValue.ToString() != "-1")
        {
           
            clsBLTest obj_Test = new clsBLTest();
            obj_Test.SectionID = ddlSubDepartment.SelectedValue.ToString();
            DataView dv_Test = obj_Test.GetAll(10);
            if (dv_Test.Count > 0)
            {
                SComponents obj_Comp = new SComponents();
                obj_Comp.FillDropDownList(ddlTest, dv_Test, "Test", "TestID");
                obj_Comp = null;

            }
            else
            {
                lblErrMSg.Text = "No Test Found.";
            }
            FillGV();
            dv_Test.Dispose();
            obj_Test = null; 
        }
    }
    protected void gvTestSoPSorting(object sender, GridViewSortEventArgs e)
    {
        if (e.SortExpression == "SOPType")
        {
            if (DGSort =="SOPType ASC")
            {
                DGSort = "SOPType DESC";
            }
            else
                DGSort="SOPType ASC";
            
        }
        if (e.SortExpression == "Test")
        {
            if (DGSort == "Test ASC")
            {
                DGSort = "Test DESC";
            }
            else
                DGSort = "Test ASC";

        }
        if (e.SortExpression == "Doc_Path")
        {
            if (DGSort == "Doc_Path ASC")
            {
                DGSort = "Doc_Path DESC";
            }
            else
                DGSort = "Doc_Path ASC";

        }
        FillGV();

    }

    protected void lnkpath1_Click(object sender, EventArgs e)
    {
        LinkButton lnkPath1 = (LinkButton)sender;
        string filepath = lnkPath1.ToolTip.ToString();// @"D:\negno25462.jpg";
        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
    }
    protected void lnkpath2_Click(object sender, EventArgs e)
    {
        LinkButton lnkPath2 = (LinkButton)sender;
        string filepath = lnkPath2.ToolTip.ToString();// @"D:\negno25462.jpg";
        filepath = filepath.Replace("\\", @"\");
        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
    }
    protected void lnkpath3_Click(object sender, EventArgs e)
    {
        LinkButton lnkPath3 = (LinkButton)sender;
        string filepath = lnkPath3.ToolTip.ToString();// @"D:\negno25462.jpg";
        // Create New instance of FileInfo class to get the properties of the file being downloaded
        FileInfo myfile = new FileInfo(filepath);

        // Checking if file exists
        if (myfile.Exists)
        {
            // Clear the content of the response
            Response.ClearContent();

            // Add the file name and attachment, which will force the open/cancel/save dialog box to show, to the header
            Response.AddHeader("Content-Disposition", "attachment; filename=" + myfile.Name);

            // Add the file size into the response header
            Response.AddHeader("Content-Length", myfile.Length.ToString());

            // Set the ContentType
            Response.ContentType = ReturnExtension(myfile.Extension.ToLower());

            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)
            Response.TransmitFile(myfile.FullName);

            // End the response
            Response.End();
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";

            case ".docx":
            case ".doc":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            default:
                return "application/octet-stream";
        }
    }

    protected void gvlnkdelfile_Command(object sender, CommandEventArgs e)
    {

        clsBlTestSops obj_gen = new clsBlTestSops();
        //obj_gen.path_Img1 = "X";

        if (e.CommandName == "file1")
        {
            obj_gen.Doc_Path = "X";
            obj_gen.TestSopID = hdTestSopID.Value.ToString().Trim();
            if (obj_gen.Update())
            {

                LinkButton lnkdel = (LinkButton)sender;
                string filepath = lnkdel.CommandArgument;
                if (File.Exists(filepath))
                {
                    try
                    {

                        File.Delete(filepath);
                        FillGV();

                    }
                    catch (Exception ee)
                    {
                        Response.Write(ee.ToString());
                    }
                }
                else
                {
                    Response.Write("File don't Exist");
                }
                FileUpload1.Visible = true;
                ((LinkButton)sender).Visible = false;
                lnkpath1.Visible = false;
                //((FileUpload)dgTest.Items[index].Cells[7].FindControl("FileUploadControl1")).Visible = true;
                //((LinkButton)sender).Visible = false;
                //((LinkButton)dgTest.Items[index].Cells[7].FindControl("gvlnkPath1")).Visible = false;
                //lnkdel.Visible = false;
            }
        }

        if (e.CommandName == "file2")
        {
            obj_gen.TestSopID = hdTestSopID.Value.ToString().Trim();
            obj_gen.Doc_Path2 = "X";
            if (obj_gen.Update())
            {

                LinkButton lnkdel = (LinkButton)sender;
                string filepath = lnkdel.CommandArgument;
                if (File.Exists(filepath))
                {
                    try
                    {

                        File.Delete(filepath);
                        FillGV();

                    }
                    catch (Exception ee)
                    {
                        Response.Write(ee.ToString());
                    }
                }
                else
                {
                    Response.Write("File don't Exist");
                }
                FileUpload2.Visible = true;
                ((LinkButton)sender).Visible = false;
                lnkpath2.Visible = false;
            }
        }
        if (e.CommandName == "file3")
        {
            obj_gen.TestSopID = hdTestSopID.Value.ToString().Trim();
            obj_gen.Doc_Path3 = "X";
            if (obj_gen.Update())
            {

                LinkButton lnkdel = (LinkButton)sender;
                string filepath = lnkdel.CommandArgument;
                if (File.Exists(filepath))
                {
                    try
                    {

                        File.Delete(filepath);
                        FillGV();

                    }
                    catch (Exception ee)
                    {
                        Response.Write(ee.ToString());
                    }
                }
                else
                {
                    Response.Write("File don't Exist");
                }
                FileUpload3.Visible = true;
                ((LinkButton)sender).Visible = false;
                lnkpath3.Visible = false;
               
            }
        }
    }
}