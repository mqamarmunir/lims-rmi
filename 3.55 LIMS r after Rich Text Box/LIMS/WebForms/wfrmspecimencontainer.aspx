<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmSpecimenContainer" CodeFile="wfrmSpecimenContainer.aspx.cs" %>
<HTML>
	<HEAD>
		<title>Specimen Container:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 20px" colSpan="7"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>SPECIMEN CONTAINER</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="center">|</TD>
								<TD align="center"><asp:linkbutton id="lbtnSave" tabIndex="9" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnSave_Click">Save</asp:linkbutton></TD>
								<TD align="center">|</TD>
								<TD align="center"><asp:linkbutton id="lbtnClearAll" tabIndex="10" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnClearAll_Click">Clear All</asp:linkbutton></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="7"><asp:label id="lblErrMSg" runat="server" ForeColor="Red" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Vaue:
						<asp:textbox id="txtValue" tabIndex="4" runat="server" Width="100%" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD colSpan="5"></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><asp:datagrid id="dgSelectionValue" runat="server" CssClass="datagrid" BorderColor="Silver" AutoGenerateColumns="False"
							PageSize="25" AllowSorting="True">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="specimencontainer" SortExpression="TestGroup" ReadOnly="True" HeaderText="Selection Value">
									<HeaderStyle Width="80px"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Select" CommandName="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" PageButtonCount="3" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="7">HMS_LM_IN_005</TD>
				</TR>
			</TABLE>
			&nbsp;
		</FORM>
	</body>
</HTML>
