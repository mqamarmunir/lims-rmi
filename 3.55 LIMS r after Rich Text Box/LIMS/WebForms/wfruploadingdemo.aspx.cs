using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class LIMS_WebForms_wfruploadingdemo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            LinkButton hyperlink1 = new LinkButton();
            hyperlink1.Text = "Button" + i.ToString()+"<br />";
            hyperlink1.CommandName = "Select" + i.ToString();
            // hyperlink1.PostBackUrl = "";
           // hyperlink1.Load += new EventHandler(OnClickLink);
             hyperlink1.Command += new CommandEventHandler(OnClickLink);

            PlaceHolder1.Controls.Add(hyperlink1);
        }

    }
    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
       // System.Threading.Thread.Sleep(5000);
        if (AsyncFileUpload1.HasFile)
        {
            //string strPath = MapPath("~/Uploads/") + Path.GetFileName(e.FileName);
           // string strPath = MapPath("~/Uploads/abc.xls");// +Path.GetFileName(e.FileName);
            //AsyncFileUpload1.SaveAs(Server.MapPath("~/Uploads/abc.xls"));
            AsyncFileUpload1.SaveAs((@"D:\Qamar\Images\")+Path.GetFileName(e.FileName));
            //AsyncFileUpload1.SaveAs(strPath);
        }
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (!FileUploadControl.FileName.Equals(""))
            {
                string filename = Path.GetFileName(FileUploadControl.FileName);
                FileUploadControl.SaveAs((@"D:\Qamar\Images\") + filename);
                //filename = Path.GetFileName(FileUploadControl0.FileName);
                //FileUploadControl0.SaveAs(Server.MapPath("~/Uploads/") + filename);
                StatusLabel.Text = "Upload status: File uploaded!";
            }
        }
        catch (Exception ex)
        {
            StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //new code///////////////////

        //  string filepath = Server.MapPath("test.txt");
        string filepath = @"D:\negno25462.jpg";
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

        /////////-------./////////////

        //Response.ContentType = "image/jpeg";
        //Response.ContentType = "application/octet-stream";
        //Response.AppendHeader("Content-Disposition", "attachment; filename=SailBig.jpg");
        //Response.TransmitFile(@"D:\negno25462.jpg");
        ////Response.TransmitFile(Server.MapPath("~/Uploads/Trees Trainee  Developers Assignment 1.docx"));

        //Response.End();
       
    }

    protected void OnClickLink(object sender, CommandEventArgs e)
    {
        LinkButton obj1 = (LinkButton)sender;
       // Response.Write(obj1.Text);
        if (e.CommandName.ToString() == "Select0")
        {
            Image1.Visible = true;
            Image1.ImageUrl = "~/images/edit.png";

            lbl1.Text = Image1.ImageUrl.ToString();

        }
        else
        {
           // Uri navigateUri = new Uri("D:\negno25462.jpg");
            
            //Image1.ImageUrl = @"D:\negno25462.jpg";
            //Image1.ImageUrl = "~/negno25462.jpg";
            lbl1.Text = Image1.ImageUrl.ToString();
        }
        //Label1.Text = obj1.Text;
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