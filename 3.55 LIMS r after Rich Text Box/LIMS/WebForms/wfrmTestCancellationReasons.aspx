<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestCancellationReasons.aspx.cs" Inherits="LIMS_WebForms_wfrmTestCancellationReasons" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>LIMS: Cancel Reason:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<TABLE class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>CANCEL REASON</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="LblMessage" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<td width="10%"></td>
					<td width="10%">Name:</td>
					<TD width="30%"><asp:label id="lblname" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
					<td align="right" width="10%">Lab ID:&nbsp;&nbsp;</td>
					<TD width="30%"><asp:label id="lblLabID" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
					<td width="10%"></td>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<td></td>
					<TD>Reason:
					</TD>
					<td colSpan="3"><asp:textbox id="txtReason" runat="server" Width="100%" CssClass="field"></asp:textbox></td>
					<td align="center"><asp:linkbutton id="lnkbtnsave" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lnkbtnsave_Click">Save</asp:linkbutton></td>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
                <tr>
                <td></td>
                <td colspan="6">
                <asp:GridView ID="gvReasons" Width="70%" AutoGenerateColumns="False" runat="server"
                   OnSelectedIndexChanging="gvReasons_SelectedIndexChanged" >
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle Width="5%" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Reason" DataField="cancelReason">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CommandField SelectText="Select"  ShowSelectButton="true" 
                        ShowCancelButton="False">
                <HeaderStyle Width="15%" />
                </asp:CommandField>
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
                </td>
                </tr>
                </TABLE>
    </div>
    </form>
</body>
</html>
