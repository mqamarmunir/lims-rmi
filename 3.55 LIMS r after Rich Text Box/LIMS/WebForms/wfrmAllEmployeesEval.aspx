<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmAllEmployeesEval.aspx.cs" Inherits="LIMS_WebForms_wfrmAllEmployeesEval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
     LIMS: All Employees Evaluation:    <% =Session["UNUIDFORMATTED"] %>
     </title>
     <meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">

</head>
<body>
<script type="text/javascript" charset="utf-8">

    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
</script>
    <form id="form1" runat="server">
    <div>
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>EMPLOYEES EVALUATION</STRONG></font></td>
				</tr>
                </TABLE>
                <br />
                <table id="tblgrid" runat="server" class="label">
                 <tr>
                <td width="10%" align="right">&nbsp;</td>
                <td width="20%"><asp:TextBox ID="txtFilter" runat="server" CssClass="field" Visible="false" Width="100%" onkeyup="javascript:filter(this,'gvPerfomance',1)"></asp:TextBox></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                </tr>
                <tr>
                <td></td>
             <td colspan="6">
                 <asp:GridView ID="gvPerfomance" OnRowDataBound="gvPerfomance_RowDatabound"
                 DataKeyNames="EnteredBy" Width="75%" HorizontalAlign="Left" 
                     AutoGenerateColumns="False" CssClass="datagrid" runat="server">
                <HeaderStyle HorizontalAlign="Left" CssClass="gridheader" />
                <RowStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridheader" />
                 <Columns>
                  <asp:TemplateField HeaderText="S#">

                 <HeaderStyle HorizontalAlign="Center" Width="5%" />
                 
                 <ItemTemplate>
                 <%#Container.DataItemIndex+1 %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="PersonName" DataField="EmployeeName" />
                 <asp:BoundField HeaderText="Total Test Performed" DataField="NumberOFTestsEntered" />
                  <asp:TemplateField>
                  <ItemTemplate>
                  <tr>
                  <td></td>
                  <td colspan="8">
                  <table id="tblQualitaitve" width="100%" runat="server" class="label">
                  <tr>
                  <td align="left">
                  <DIV id="divQualitative" style="display:inline" runat="server">
                  <font style="color:Black"> <b>Test Detail:</b></font><br />
                  <asp:GridView ID="gvQualitative" AutoGenerateColumns="false" DataKeyNames="TestID" CssClass="datagrid" runat="server" Width="100%">
                  <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                  <RowStyle CssClass="gridAlternate" />
                  <Columns>
                  <asp:TemplateField HeaderText="S#">
                  <ItemTemplate>
                  <%#Container.DataItemIndex+1 %>
                  </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField HeaderText="Test Name" DataField="Test" />
                  <asp:BoundField HeaderText="Count" DataField="TestEntryTimes" />
                  </Columns>
                  </asp:GridView>
                  </DIV>
                  </td>
                  </tr>
                 
                  </table>
                  </td>
                  </tr>
                  </ItemTemplate>
                  </asp:TemplateField>
               
                
               
                 </Columns>
                 </asp:GridView>
                    </td>
                </tr>
                   <tr>
                <td width="10%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                </tr>
                </table>
    </div>
    </form>
</body>
</html>
