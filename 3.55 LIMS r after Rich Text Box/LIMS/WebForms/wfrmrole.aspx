<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmRole" CodeFile="wfrmRole.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Role Registration:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colspan="7"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>					
					<TD align="center" colSpan="7"><font size="4"><STRONG>ROLE REGISTRATION</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<td align=center>|</td>
								<TD align="center">
									<asp:LinkButton id="lbtnSave" runat="server" ForeColor="Blue" Font-Size="X-Small" tabIndex="5" ToolTip="Click to Save or Update Record" onclick="lbtnSave_Click">Save</asp:LinkButton></TD>
								<td align=center>|</td>
								<TD align="center">
									<asp:LinkButton id="lbtnClearAll" runat="server" ForeColor="Blue" Font-Size="X-Small" tabIndex="6"
										ToolTip="Click to refresh form" onclick="lbtnClearAll_Click">Clear All</asp:LinkButton></TD>
								<td align=center>|</td>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="7">
						<asp:Label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colSpan="2">
						<asp:dropdownlist id="ddlSection" runat="server" Width="100%" AutoPostBack="True" tabIndex="1" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD colSpan="2"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="10%">Active:</TD>
					<TD width="15%">
						<asp:checkbox id="chkActive" runat="server" Width="100%" Checked="True" tabIndex="2" ToolTip="Mark Active or Inactive"></asp:checkbox></TD>
					<TD width="18%"></TD>
					<TD width="10%"></TD>
					<TD width="17%"></TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Role:</TD>
					<TD colSpan="2">
						<asp:textbox id="txtRole" runat="server" Width="100%" CssClass="mandatoryfield" tabIndex="3"
							ToolTip="Enter Role Name (empty is not allowed)"></asp:textbox></TD>
					<TD align="right">Acronym:&nbsp;&nbsp;</TD>
					<TD>
						<asp:textbox id="txtAcronym" runat="server" Width="100%" CssClass="mandatoryfield" tabIndex="4"
							ToolTip="Enter Role Acronym (space is not allowed)"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="7" align="center">
						<asp:datagrid id="dgRole" runat="server" Width="75%" AllowPaging="True" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="Silver" PageSize="25" onselectedindexchanged="dgRole_SelectedIndexChanged">
							<SelectedItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="RoleID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Role" SortExpression="TestGroup" ReadOnly="True" HeaderText="Role">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" SortExpression="Acronym" HeaderText="Acronym">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled=False Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Edit">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" PageButtonCount="3" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="7">HMS_LM_IN_004</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
