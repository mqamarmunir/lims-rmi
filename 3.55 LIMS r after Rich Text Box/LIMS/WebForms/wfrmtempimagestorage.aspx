<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmtempimagestorage.aspx.cs" Inherits="LIMS_WebForms_wfrmtempimagestorage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblx" runat="server"></asp:Label>
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnupload" runat="server" Text="Upload" OnClick="btnupload_Click" />
    </div>
    </form>
</body>
</html>
