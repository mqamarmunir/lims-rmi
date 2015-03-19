using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LS_BusinessLayer;
using System.ComponentModel;
using System.IO;

public partial class LIMS_WebForms_wfrmSOPresultge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {
            
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

                FillDDLProcess();
                ddlProcess.ClearSelection();
                ddlProcess.Items.FindByValue(Request.QueryString["id"].ToString().Trim()).Selected = true;

                

                FillDDLTest();
                ddlTest.ClearSelection();
                ddlTest.Items.FindByValue(Request.QueryString["TestID"].ToString().Trim()).Selected = true;

                FillGV();

            }
        }
        else
        {
            Response.Write("<script language='javascript'>parent.location.href='../../login.aspx'</script>");
 
        }

    }
    private void FillDDLProcess()
    {
        clsBLTestProcess obj_Process = new clsBLTestProcess();
        DataView dv_processes = obj_Process.GetAll(4);
        obj_Process = null;
        if (dv_processes.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlProcess, dv_processes, "Process", "ProcessID");
            obj_Comp = null;
        }
        dv_processes.Dispose();


    }

    private void FillDDLTest()
    {
        clsBLTest obj_Test = new clsBLTest();
        DataView dv_Tests=obj_Test.GetAll(13);
        obj_Test = null;
        if (dv_Tests.Count > 0)
        {
            SComponents obj_Comp = new SComponents();
            obj_Comp.FillDropDownList(ddlTest, dv_Tests, "Test", "TestID");
            obj_Comp = null;

        }
        dv_Tests.Dispose();

    }

    private void FillGV()
    {
        clsBlSopTypes obj_SOps = new clsBlSopTypes();
        obj_SOps.TestID = ddlTest.SelectedValue.ToString().Trim();
        obj_SOps.ProcessID = ddlProcess.SelectedValue.ToString().Trim();
        
        DataView dv_SOPs = obj_SOps.GetAll(4);
        obj_SOps = null;
        if (dv_SOPs.Count > 0)
        {
            lblCount.Visible = true;
            lblCount.Text = "(" + dv_SOPs.Count + ") Record(s) Found";
            gvSOPs.DataSource = dv_SOPs;
            gvSOPs.DataBind();
        }
        else
        {
            lblCount.Visible = false;
            gvSOPs.DataSource = "";
            gvSOPs.DataBind();
        }
        dv_SOPs.Dispose();
    }

    protected void gvSOP_selectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int startingindex = 0;
        int rowindex = e.NewSelectedIndex;
        divdetail.Visible = true;
        tblSops.Visible = false;
        lblTitle.Text = gvSOPs.Rows[rowindex].Cells[1].Text;
        lblApplicableon.Text = gvSOPs.Rows[rowindex].Cells[2].Text;
        clsBlTestSops obj_TestSops = new clsBlTestSops();
        obj_TestSops.TestID = gvSOPs.DataKeys[rowindex].Values[1].ToString();
        obj_TestSops.SopTypeID = gvSOPs.DataKeys[rowindex].Values[0].ToString();
        DataView dv_TestSops = obj_TestSops.GetAll(3);
        obj_TestSops = null;
        if (dv_TestSops.Count > 0)
        {
            txtDescription.Text = dv_TestSops[0]["sopdescription"].ToString();
            if (dv_TestSops[0]["Doc_Path"].ToString() != "&nbsp;" && dv_TestSops[0]["Doc_path"].ToString() != "")
            {
                lnkPath1.Visible = true;
                lnkPath1.ToolTip = dv_TestSops[0]["Doc_Path"].ToString();
                string path = dv_TestSops[0]["Doc_Path"].ToString();
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                    lnkPath1.Text = dv_TestSops[0]["Doc_Path"].ToString().Substring(startingindex+1);

            }
            else
            {
                lnkPath1.Visible = false;
            }
            startingindex = 0;
            if (dv_TestSops[0]["Doc_Path2"].ToString() != "&nbsp;" && dv_TestSops[0]["Doc_path2"].ToString() != "")
            {
                lnkPath2.Visible = true;
                lnkPath2.ToolTip = dv_TestSops[0]["Doc_Path2"].ToString();
                string path = dv_TestSops[0]["Doc_Path2"].ToString();
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                lnkPath2.Text = dv_TestSops[0]["Doc_Path2"].ToString().Substring(startingindex + 1);

            }
            else
            {
                lnkPath2.Visible = false;
            }
            startingindex = 0;

            if (dv_TestSops[0]["Doc_Path3"].ToString() != "&nbsp;" && dv_TestSops[0]["Doc_path3"].ToString() != "")
            {
                lnkPath3.Visible = true;
                lnkPath3.ToolTip = dv_TestSops[0]["Doc_Path3"].ToString();
                string path = dv_TestSops[0]["Doc_Path3"].ToString();
                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i].ToString() == @"\")
                    {
                        startingindex = i;
                    }
                }
                lnkPath3.Text = dv_TestSops[0]["Doc_Path3"].ToString().Substring(startingindex + 1);

            }
            else
            {
                lnkPath3.Visible = false;
            }
            startingindex = 0;
        }
        dv_TestSops.Dispose();
    }
    protected void ddlProcess_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        FillGV();

    }
    protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGV();
    }
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClear_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ibtnClose_Click(object sender, ImageClickEventArgs e)
    {
        txtDescription.Text = "";
        lblTitle.Text = "";
        lblApplicableon.Text = "";
        divdetail.Visible = false;
        tblSops.Visible = true;

    }
    protected void OnClickLink(object sender, CommandEventArgs e)
    {
        txtDescription.Text = "";
        lblTitle.Text = "";
        lblApplicableon.Text = "";
        divdetail.Visible = false;
        tblSops.Visible = true;
    }
    //protected void hyperlink1_Load(object sender, EventArgs e)
    //{
        
        
    //}

    protected void lnkPath1_Click(object sender, EventArgs e)
    {
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
        else
        {
            Response.Write("<script language='javascript'>alert('File not Found');</script>");
        }
    }
    protected void lnkPath2_Click(object sender, EventArgs e)
    {
        string filepath = lnkPath2.ToolTip.ToString();// @"D:\negno25462.jpg";
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
        else
        {
            Response.Write("<script language='javascript'>alert('File not Found');</script>");
        }

    }
    protected void lnkPath3_Click(object sender, EventArgs e)
    {
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
        else
        {
            Response.Write("<script language='javascript'>alert('File not Found');</script>");
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
}