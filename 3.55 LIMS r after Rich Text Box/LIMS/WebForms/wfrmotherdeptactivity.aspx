<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmOtherDeptActivity" CodeFile="wfrmOtherDeptActivity.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Other Department Activity:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<P>&nbsp;</P>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>Ultrasound / X-Rays</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="30%"><asp:dropdownlist id="ddlSection" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right" width="13%">Patient Name:&nbsp;&nbsp;</TD>
					<TD width="32%"><asp:textbox id="txtPatientName" runat="server" Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="ddlTestGroup" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Rec-No:</TD>
					<TD><asp:textbox id="txtMSerialNoFrom" runat="server" Width="40%" CssClass="field"></asp:textbox><asp:textbox id="txtMSerialNoTo" runat="server" Width="40%" CssClass="field"></asp:textbox></TD>
					<TD></TD>
					<TD align="center">|
						<asp:linkbutton id="Refreash" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="Refreash_Click">Refresh</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="LinkButton1" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="LinkButton1_Click">All</asp:linkbutton>&nbsp;|</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblRecordNo" runat="server" Width="100%" ForeColor="ForestGreen"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgGroupList" runat="server" Width="100%" BorderColor="Silver" AutoGenerateColumns="False"
							AllowSorting="True">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Done" CommandName="Done">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSerialNo" SortExpression="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="PatientName" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="35%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" SortExpression="PAge" ReadOnly="True" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" SortExpression="Type" HeaderText="Type">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ServiceNo" SortExpression="ServiceNo" HeaderText="Service No ">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_010</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
