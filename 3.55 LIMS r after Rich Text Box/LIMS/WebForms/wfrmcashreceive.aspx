<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmCashReceive" CodeFile="wfrmCashReceive.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Cash Receiving:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; WIDTH: 928px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="928" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>CASH RECEIVING</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Lab ID:</TD>
					<TD width="30%"><asp:textbox id="txtMSerialNoFrom" runat="server" Width="40%" CssClass="field"></asp:textbox><asp:textbox id="txtMSerialNoTo" runat="server" Width="40%" CssClass="field"></asp:textbox></TD>
					<TD align="right" width="13%">Patient Name:&nbsp;&nbsp;</TD>
					<TD width="32%"><asp:textbox id="txtPatientName" runat="server" Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Lab Date:</TD>
					<TD>
						<asp:TextBox id="txtDF" tabIndex="10" runat="server" CssClass="field" Width="100px"></asp:TextBox>
						<asp:textbox id="txtDT" tabIndex="11" runat="server" CssClass="field" Width="100px" MaxLength="10"
							ToolTip="Enter Serial No for view to end at (optional)"></asp:textbox></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px"></TD>
					<TD align="center" style="HEIGHT: 17px">|
						<asp:linkbutton id="lnkToday" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lnkToday_Click">Today</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lnkLast2day" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lnkYesterday_Click">Last 2 days</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="Refreash" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="Refreash_Click">Refresh</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="LinkButton1" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="LinkButton1_Click">All</asp:linkbutton>&nbsp;|</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblRecordNo" runat="server" Width="100%" ForeColor="ForestGreen"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgGroupList" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							BorderColor="Gray" GridLines="Horizontal" CellSpacing="-1" CellPadding="10" onselectedindexchanged="dgGroupList_SelectedIndexChanged">
							<SelectedItemStyle Font-Size="X-Small" Font-Bold="True" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="LemonChiffon"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Visible="False" Text="Detail" CommandName="Detail">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="0%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LabID" HeaderText="Lab ID">
									<HeaderStyle Width="14%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="23%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" ReadOnly="True" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" HeaderText="Type">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PaidAmount" HeaderText="Amount">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Right" ForeColor="Black"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Receive" CommandName="Receive">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="WardName" HeaderText="Ward">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PRNo" HeaderText="PRNo"></asp:BoundColumn>
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
