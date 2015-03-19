<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmCollectionCenterrecieving.aspx.cs" Inherits="LIMS_WebForms_wfrmCollectionCenterrecieving" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIMS: Sample Recieving:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">

        <script type="text/javascript">
            function filter(term, _id, cellNr,cellNr2,cellNr3) {
                var suche = term.value.toLowerCase();
                var table = document.getElementById(_id);
                var ele;
                for (var r = 1; r < table.rows.length; r++) {
                    ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
                    ele2 = table.rows[r].cells[cellNr2].innerHTML.replace(/<[^>]+>/g, "");
                    ele3 = table.rows[r].cells[cellNr3].innerHTML.replace(/<[^>]+>/g, "");
                    if (ele.toLowerCase().indexOf(suche) >= 0 || ele2.toLowerCase().indexOf(suche) >= 0 || ele3.toLowerCase().indexOf(suche) >= 0)
                        table.rows[r].style.display = '';
                    else table.rows[r].style.display = 'none';

                    //      alert(table.rows[1].cells[1].innerHTML.toString());
                }
            }
        </script>
        
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%">
    <tr>
    <td colspan="7"><!-- #include file="LimsHeader2.htm"--></td>
    
    </tr>
    <tr>
    <td colspan="7"  align="center"><font size="4"><strong>External Sample Recieving</strong></font></td>
   
    </tr>
    <tr>
    <td colspan="7">
    <asp:TextBox ID="txtSearch" runat="server"  onkeyup="Javascript:filter(this,'gvTests',1,2,3)" CssClass="flattextbox"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="7"><asp:Label ID="lblCount" runat="server" Visible="false"></asp:Label></td>
    
    </tr>
    <tr>
    <td colspan="7">
    <asp:GridView ID="gvTests" runat="Server" CssClass="datagrid" 
            AutoGenerateColumns="false" 
            DataKeyNames="MserialNo,DSerialNo,cliqcheckinid,cliqorderid" Width="100%"
    OnRow onrowcommand="gvTests_RowCommand">
    <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
    <RowStyle CssClass="gridItem" />
    <AlternatingRowStyle CssClass="gridAlternate" />
    <Columns>
    <asp:TemplateField HeaderText="S#" ItemStyle-Width="5%">
    <ItemTemplate>
    <%#Container.DataItemIndex+1 %>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="PatientCompleteName" HeaderText="Patient" />
    <asp:BoundField DataField="labID" HeaderText="Lab ID" />
    <asp:BoundField DataField="cliqvisitno" HeaderText="External Visit No" />
    <asp:BoundField DataField="Test" HeaderText="Test" />
    <asp:BoundField DataField="EntryDatetime" HeaderText="Booked On" />
    <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date" />
    <asp:BoundField DataField="Origin" HeaderText="Origin" />
    <asp:ButtonField HeaderText="" Text="Recieved" CommandName="Recieved" ButtonType="Link" />
    </Columns>
    </asp:GridView> 
    </td>
   
    </tr>
    <tr>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
