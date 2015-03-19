<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfruploadingdemo.aspx.cs" Inherits="LIMS_WebForms_wfruploadingdemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

   

    <title></title>
    <script type="text/javascript" language="javascript">

        function uploadError(sender, args) {
            document.getElementById('lblStatus').innerText = args.get_fileName(),
	"<span style='color:red;'>" + args.get_errorMessage() + "</span>";
        }

        function StartUpload(sender, args) {
            document.getElementById('lblStatus').innerText = 'Uploading Started.';
        }

        function UploadComplete(sender, args) {
            var filename = args.get_fileName();
            var contentType = args.get_contentType();
            var text = "Size of " + filename + " is " + args.get_length() + " bytes";
            if (contentType.length > 0) {
                text += " and content type is '" + contentType + "'.";
            }
            document.getElementById('lblStatus').innerText = text;
        }

</script>
</head>
<body>

    <form id="form1" runat="server" enctype="multipart/form-data">
    <div>
     <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <cc1:AsyncFileUpload ID="AsyncFileUpload1" Width="400px" runat="server" 
OnClientUploadError="uploadError" OnClientUploadStarted="StartUpload" 
OnClientUploadComplete="UploadComplete" 
CompleteBackColor="Lime" UploaderStyle="Modern" 
ErrorBackColor="Red" 
onuploadedcomplete="AsyncFileUpload1_UploadedComplete" 
UploadingBackColor="#66CCFF" />
  
<asp:Label ID="lblStatus" runat="server" Style="font-family: Arial; 
	font-size: small;"></asp:Label>


        <br />


    <asp:FileUpload id="FileUploadControl" runat="server" />
        <br />


    <asp:FileUpload id="FileUploadControl0" runat="server" />
        <br />
 <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" /> <br /><br />
<asp:Label runat="server" id="StatusLabel" text="Upload status: " />
<br />

    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">LinkButton</asp:LinkButton>
        <br />
        <asp:Label ID="lbl1" runat="server"></asp:Label>
        <br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Image ID="Image1"  runat="server" />
    </div>
    </form>
    
</body>
</html>
