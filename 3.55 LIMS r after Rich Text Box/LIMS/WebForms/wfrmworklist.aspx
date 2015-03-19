<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmWorkList" CodeFile="wfrmWorkList.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Work List Formation:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>&nbsp;</P>
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colSpan="4"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>WORK LIST</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="4">
						<asp:label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="65%">
						<asp:dropdownlist id="ddlSection" runat="server" Width="60%" AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						|
						<asp:linkbutton id="lbtnSave" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnSave_Click">Save</asp:linkbutton>&nbsp;|&nbsp;
						<asp:linkbutton id="LinkButton2" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="LinkButton2_Click">History</asp:linkbutton>&nbsp;|
					</TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:datagrid id="dgGroupList" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							BorderColor="Silver" CssClass="datagrid" onselectedindexchanged="dgGroupList_SelectedIndexChanged">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
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
								<asp:BoundColumn Visible="False" DataField="DSerialNo" SortExpression="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="4" class="screenid">HMS_LM_IN_011</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
