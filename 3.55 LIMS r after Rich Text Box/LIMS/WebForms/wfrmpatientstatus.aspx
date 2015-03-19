<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmPatientStatus" CodeFile="wfrmPatientStatus.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient Status:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>PATIENT STATUS</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<td width="10%"></td>
					<TD width="15%">Sub-Department:</TD>
					<TD width="25%"><asp:dropdownlist id="CmbSection" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="CmbSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right" width="13%">Patient Name:&nbsp;&nbsp;</TD>
					<TD width="27%"><asp:textbox id="TxtPatient" runat="server" Width="100%" CssClass="field"></asp:textbox></TD>
					<td width="10%"></td>
				</TR>
				<TR>
					<td></td>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="CmbTestGroup" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="CmbSex" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<td></td>
				</TR>
				<TR>
					<td></td>
					<TD>Rec - No:</TD>
					<TD><asp:textbox id="TxtRecNoFrom" runat="server" Width="48%" CssClass="field"></asp:textbox><asp:textbox id="TxtRecNoTo" runat="server" Width="48%" CssClass="field"></asp:textbox></TD>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<td align="center">&nbsp;|&nbsp;</td>
								<TD align="center"><asp:linkbutton id="ButRefresh" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="ButRefresh_Click">Refresh</asp:linkbutton></TD>
								<td align="center">&nbsp;|&nbsp;</td>
								<TD align="center"><asp:linkbutton id="ButAll" runat="server" ForeColor="Blue" Font-Size="X-Small">All</asp:linkbutton></TD>
								<td align="center">&nbsp;|&nbsp;</td>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="DGPatientInfo" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="mserialno"></asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="PatientName" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="40%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="age" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="serviceno" HeaderText="Service No">
									<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Status" CommandName="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<td colspan="6" class="screenid" align="right">HMS_LM_IN_015</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
