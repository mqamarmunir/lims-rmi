<%@ Page Language="C#" AutoEventWireup="true" CodeFile="asyncgridview.aspx.cs" Inherits="asyncgridview" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Async GridView</title>
</head>
<body>
  <form id="form1" runat="server">
  
  <div id="grid">
    <span>Loading...</span>
    <asp:GridView runat="Server" ID="gvAsync" onrowdatabound="gvAsync_RowDataBound" />  
  </div>
  
  <script type="text/javascript">    
    function EndGetData(arg)
    {
      document.getElementById("grid").innerHTML = arg;
    }
    
    setTimeout("<asp:literal runat="server" id="ltCallback" />", 100);
  </script>
    
  </form>
</body>
</html>
