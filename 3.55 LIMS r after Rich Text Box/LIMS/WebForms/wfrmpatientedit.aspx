<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmPatientEdit" CodeFile="wfrmPatientEdit.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient Edit:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="True" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="LEFT: 1px; POSITION: absolute; TOP: 1px" cellSpacing="1"
				cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>Patient Modification</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="3"><FONT size="2"><B><U>Patient Info</U></B></FONT></TD>
					<TD align="right" colSpan="3">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="center">|
									<asp:linkbutton id="ButSave" tabIndex="36" runat="server" Font-Size="X-Small" ForeColor="Blue" ToolTip="Click to save Patient &amp; Tests Info" onclick="ButSave_Click">Save</asp:linkbutton></TD>
								<TD align="center"></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>Relationship:
					</TD>
					<TD><asp:dropdownlist id="CmbRelationShip" tabIndex="18" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
					<TD><asp:textbox id="txtKinFName" tabIndex="20" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient First Name"></asp:textbox></TD>
					<TD><asp:textbox id="txtKinMName" tabIndex="21" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient Middle Name"></asp:textbox></TD>
					<TD><asp:textbox id="txtKinLName" tabIndex="22" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient Last Name"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Name (F-M-L):</TD>
					<TD><asp:dropdownlist id="ddlPTitle" tabIndex="19" runat="server">
							<asp:ListItem Value="Mr" Selected="True">Mr.</asp:ListItem>
							<asp:ListItem Value="Miss">Miss.</asp:ListItem>
							<asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
							<asp:ListItem Value="Baby">Baby</asp:ListItem>
							<asp:ListItem Value="Baby of ">Baby of </asp:ListItem>
							<asp:ListItem Value="Master">Master</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:textbox id="TxtPFName" tabIndex="20" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient First Name"></asp:textbox></TD>
					<TD><asp:textbox id="TxtPMName" tabIndex="21" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient Middle Name"></asp:textbox></TD>
					<TD><asp:textbox id="TxtPLName" tabIndex="22" runat="server" CssClass="field" Width="100%" ToolTip="Enter Patient Last Name"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Sex / Age</TD>
					<TD><asp:label id="lblSexAge" runat="server">Label</asp:label></TD>
					<TD align="right"><FONT color="red">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</FONT></TD>
					<TD>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD align="right">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD>&nbsp;&nbsp;</TD>
				</TR>
                <tr>
                <td colspan="6">
                <FONT size="2"><B><U>Referring Doctor Info</U></B></FONT>
                </td>
                </tr>
                <tr>
                <td>
                Name:
                </td>
                <td>
                <asp:TextBox ID="txtReferredBy" runat="server" CssClass="field" Width="75%"></asp:TextBox>
                </td>
                </tr>
				<TR>
					<TD colSpan="6">
						<asp:Label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:Label></TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
