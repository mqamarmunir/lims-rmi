<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmPatientHistory" CodeFile="wfrmPatientHistory.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient History:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" width="100%" border="0" class="label">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>PATIENT HISTORY</STRONG></font></TD>					
				</TR>
				<TR>
					<TD colspan="6"><asp:label id="LblMessage" runat="server" ForeColor="Red" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<td width="10%">Department:</td>
					<td width="20%"><asp:DropDownList id="CmbDept" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="CmbDept_SelectedIndexChanged"></asp:DropDownList>
					</td>
					<td width="12%" align="right">
						Sub-Department:&nbsp;&nbsp;</td>
					<td width="20%">
						<asp:DropDownList id="CmbSubDept" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="CmbSubDept_SelectedIndexChanged">
							<asp:ListItem Value="Select" Selected="True">Select</asp:ListItem>
						</asp:DropDownList></td>
					<TD width="14%" align="right">From:&nbsp;
						<asp:textbox id="TxtFrom" runat="server" Width="70px" CssClass="field"></asp:textbox></TD>
					<td width="14%" align="right">To:&nbsp;
						<asp:textbox id="TxtTo" runat="server" Width="70px" CssClass="field"></asp:textbox></td>
				</TR>
				<TR>
					<TD>
						<% if(!CmbDept.SelectedValue.ToString().Equals("0001")){ %>
						Service:
						<% } else { %>
						Doctor:
						<% } %>
					</TD>
					<td colspan="2">
						<% if(!CmbDept.SelectedValue.ToString().Equals("0001")){ %>
						<asp:DropDownList id="CmbService" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList>
						<% } else { %>
						<asp:DropDownList id="CmbDoctor" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList>
						<% } %>
					</td>
					<TD colspan="4" align="center">
						<asp:linkbutton id="ButGo" runat="server" ToolTip="10%" onclick="ButGo_Click">Go</asp:linkbutton></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD colspan="7"><asp:datagrid id="DGPatientHistory" runat="server" AutoGenerateColumns="False" Width="100%" BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="VisitNo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PatientID"></asp:BoundColumn>
								<asp:BoundColumn DataField="VisitDateTime" HeaderText="Visit Date">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="referrer" HeaderText="Service Availed">
									<HeaderStyle Width="75%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Select" CommandName="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="url"></asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="7">HMS_LM_IN_014</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
