<%@ Reference Page="~/lims/reports/wfrmreceipt.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmDuesReceiving" CodeFile="wfrmDuesReceiving.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Dues Receiving:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD colSpan="6"><!-- #include file="LimsHeader.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>Dues Receiving</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="27%"><asp:dropdownlist id="ddlSection" tabIndex="3" runat="server" AutoPostBack="True" Width="100%"></asp:dropdownlist></TD>
					<TD align="right" width="13%">Service No:&nbsp;&nbsp;</TD>
					<TD width="35%"><asp:textbox id="txtPLNo" tabIndex="2" runat="server" Width="100px" ToolTip="Enter Employee Service No"
							MaxLength="10" CssClass="field"></asp:textbox></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="ddlTestGroup" tabIndex="5" runat="server" AutoPostBack="True" Width="100%" Enabled="False"></asp:dropdownlist></TD>
					<TD align="right">Patient Name:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtPatientName" tabIndex="4" runat="server" Width="100%" ToolTip="Enter Patient Name (optional)"
							MaxLength="45" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test:</TD>
					<TD><asp:dropdownlist id="ddlTest" tabIndex="7" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" tabIndex="6" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD align="right">Rec - No:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtMSerialNoFrom" tabIndex="8" runat="server" Width="100px" ToolTip="Enter Serial No for view to start from (optional)"
							MaxLength="10" CssClass="field"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtMSerialNoTo" tabIndex="9" runat="server" Width="100px" ToolTip="Enter Serial No for view to end at (optional)"
							MaxLength="10" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px" align="center">|
						<asp:linkbutton id="lbtnRefresh" tabIndex="10" runat="server" Font-Size="X-Small" ToolTip="Click to refresh the view upon selected parameters"
							ForeColor="Blue" onclick="lbtnRefresh_Click">Refresh</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnAll" tabIndex="11" runat="server" Font-Size="X-Small" ToolTip="Click to view the result without any parameter selection"
							ForeColor="Blue" onclick="lbtnAll_Click">All</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnPrint" tabIndex="12" runat="server" Font-Size="X-Small" ToolTip="Click to view Report"
							ForeColor="Blue" Visible="False" onclick="lbtnPrint_Click">Print</asp:linkbutton>|</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblRecordNo" runat="server" Width="100%" ForeColor="ForestGreen"></asp:label></TD>
				</TR>
				<TR>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgResultDis" runat="server" BorderColor="Silver" Width="100%" AllowSorting="True"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="MSerialNo" SortExpression="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="PatientName" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" SortExpression="PAge" ReadOnly="True" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" SortExpression="Type" HeaderText="Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="ServiceNo" SortExpression="ServiceNo" HeaderText="Service No ">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Dues" HeaderText="Dues">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Receive" CommandName="Received">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="Print" HeaderText="Receipt" CommandName="RecPrint">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="View" HeaderText="Detail" CommandName="Details">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="TotalAmount" HeaderText="TotalAmount"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_018</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
