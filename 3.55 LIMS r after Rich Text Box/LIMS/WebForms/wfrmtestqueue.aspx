<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestQueue" CodeFile="wfrmTestQueue.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Queue:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><u>Test Queue</u></font></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%"></TD>
					<TD width="30%"></TD>
					<TD width="10%"></TD>
					<TD width="35%"></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%" colSpan="6">
						<asp:Label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colSpan="2">
						<asp:DropDownList id="ddlSection" runat="server" Width="100%" AutoPostBack="True"></asp:DropDownList></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:DataGrid id="dgGroupList" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
							AllowSorting="True" BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="SerialNo" SortExpression="SerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestTimes" HeaderText="Times">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" SortExpression="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Patient" SortExpression="Patient" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Sex" SortExpression="Sex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientType" SortExpression="PatientType" ReadOnly="True" HeaderText="Patient Type">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_021</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
