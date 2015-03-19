<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmBatchedTests" CodeFile="wfrmBatchedTests.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Batches:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD colSpan="7"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>TEST BATCHES</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="7"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Size="X-Small"></asp:label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="28%"><asp:dropdownlist id="ddlSection" tabIndex="1" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD width="5%"></TD>
					<TD align="right" width="10%">Test Group:&nbsp;&nbsp;</TD>
					<TD width="32%"><asp:dropdownlist id="ddlTestGroup" tabIndex="2" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD align="right" colSpan="2">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="center">|</TD>
								<TD align="center">
									<asp:linkbutton id="lbtnSave" tabIndex="3" runat="server" Font-Size="X-Small" ForeColor="Blue" ToolTip="Click to save Tests as a Batch" onclick="lbtnSave_Click">Save</asp:linkbutton></TD>
								<TD align="center">|</TD>
								<TD align="center">
									<asp:LinkButton id="lbtnNew" tabIndex="4" runat="server" Font-Size="X-Small" ForeColor="Blue" ToolTip="Click to delete Selected Tests" onclick="lbtnNew_Click">New</asp:LinkButton></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><asp:datagrid id="dgTests" runat="server" Width="100%" ToolTip="Tests (White: Not Batched, Cream: Already Batched)"
							AutoGenerateColumns="False" BorderColor="Silver" CssClass="datagrid">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="75%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestBatchNo" ReadOnly="True"></asp:BoundColumn>
								<asp:ButtonColumn Text="Select &gt;" CommandName="Select">
									<HeaderStyle Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
					<TD></TD>
					<TD vAlign="top" colSpan="3"><asp:datagrid id="dgBatchTest" runat="server" Width="100%" ToolTip="Tests that you want to be batched "
							AutoGenerateColumns="False" BorderColor="Silver" CssClass="datagrid">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Selected Tests">
									<HeaderStyle Width="75%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestBatchNo" ReadOnly="True"></asp:BoundColumn>
								<asp:ButtonColumn Text="&lt; Deselect" CommandName="Select">
									<HeaderStyle Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7" class="screenid">HMS_LM_IN_023</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">
			if("<%=focusElement%>" != ""){
				document.all("<%=focusElement%>").focus();
			}
		</script>
	</body>
</HTML>
