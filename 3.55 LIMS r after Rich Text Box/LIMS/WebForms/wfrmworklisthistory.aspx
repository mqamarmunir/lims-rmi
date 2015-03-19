<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmWorkListHistory" CodeFile="wfrmWorkListHistory.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Work List History:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>WORK LIST HISTORY</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD colSpan="2" width="38%">
						<asp:DropDownList id="ddlSection" runat="server" Width="100%"></asp:DropDownList></TD>
					<TD width="37%" align="center">|&nbsp;<asp:LinkButton id="Refreash" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="Refreash_Click">Refresh</asp:LinkButton>&nbsp;|</TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%" colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center"><font size="2"><b><u>Printing Options</u></b></font></TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center">
						<asp:RadioButtonList id="RdoList" runat="server" Width="240px" BorderStyle="None" Font-Size="X-Small"
							RepeatDirection="Horizontal">
							<asp:ListItem Value="W" Selected="True">Work List</asp:ListItem>
							<asp:ListItem Value="R">Result List</asp:ListItem>
						</asp:RadioButtonList>
						<asp:RadioButtonList id="RdoGroupWise" runat="server" Width="448px" BorderStyle="None" Font-Size="X-Small"
							RepeatDirection="Horizontal" Visible="False">
							<asp:ListItem Value="T" Selected="True">Test Wise</asp:ListItem>
							<asp:ListItem Value="G">Group Wise</asp:ListItem>
							<asp:ListItem Value="D">Delivery Date Wise</asp:ListItem>
						</asp:RadioButtonList>
					</TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:label id="lblRecordNo" runat="server" Width="100%" ForeColor="ForestGreen"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:DataGrid id="dgWorkList" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
							AllowCustomPaging="True" PageSize="20" AllowPaging="True" BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Detail" CommandName="Detail">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="WorkListNo" SortExpression="WorkListNo" ReadOnly="True" HeaderText="Work List">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="WorkListDate" SortExpression="WorkListDate" HeaderText="Date">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="GeneratedBy" SortExpression="GeneratedBy" ReadOnly="True" HeaderText="Performed By">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NoofTest" SortExpression="NoofTest" ReadOnly="True" HeaderText="Total Test">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Print" CommandName="Print">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:label id="lblDetail" runat="server" Width="100%" ForeColor="Black"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:DataGrid id="dgGroupList" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
							BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="MSerialNo" SortExpression="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Times" HeaderText="Times">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" SortExpression="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="PatientName" ReadOnly="True" HeaderText="Patient">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Type" SortExpression="Type" ReadOnly="True" HeaderText="Type">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProcedureID" HeaderText="ProcedureID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
						<asp:Label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_012</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
