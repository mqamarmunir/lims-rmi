<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmSearchTest" CodeFile="wfrmSearchTest.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Search:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table2" style="HEIGHT: 84px" cellSpacing="1" cellPadding="1" width="100%"
				border="0">
				<TR>
					<TD align="right" colSpan="4" height="20"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="4">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<td align="center">|</td>
								<TD align="center"><asp:linkbutton id="ButClose" tabIndex="4" runat="server" ToolTip="Click to add selected tests"
										Font-Size="X-Small" ForeColor="Blue" onclick="ButClose_Click">Add</asp:linkbutton></TD>
								<td align="center">|</td>
								<TD align="center"><asp:linkbutton id="lbtnCancel" tabIndex="5" runat="server" ToolTip="Click to cancel current selected tests"
										Font-Size="X-Small" ForeColor="Blue" onclick="lbtnCancel_Click">Cancel</asp:linkbutton></TD>
								<td align="center">|</td>
							</TR>
						</TABLE>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="4"><asp:label id="LblMessage" runat="server" ForeColor="Red" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="4"><asp:label id="lblPatientInfo" runat="server" Font-Size="X-Small" Width="100%"></asp:label></TD>
				<TR>
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="4"><font size="2"><b><u>Selected Test(s)</u></b></font></TD>
				</TR>
				<TR>
					<TD align="left" colSpan="4"><asp:datagrid id="DGSelectedTest" runat="server" Width="100%" BorderColor="Silver" AllowSorting="True"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="sno" HeaderText="S. #.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Section" HeaderText="Sub-Department">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestGroup" HeaderText="Test Group">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Times" HeaderText="Time">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestName" HeaderText="Test Name">
									<HeaderStyle Width="34%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Charges" HeaderText="Charges">
									<HeaderStyle HorizontalAlign="Right" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Delivery" HeaderText="Delivery">
									<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" HeaderText="Test ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SectionID" HeaderText="Section ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestGroupID" HeaderText="TestGroupID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestBatchNo" HeaderText="TestBatchNo"></asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="4"><font size="2"><B><u>Search Test</u></B></font></TD>
				</TR>
				<TR>
					<td width="25%"></td>
					<TD width="10%">Section:</TD>
					<TD width="40%"><asp:dropdownlist id="CmbSection" tabIndex="1" runat="server" Width="100%" onselectedindexchanged="CmbSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<td width="25%"></td>
				</TR>
				<TR>
					<td></td>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="CmbTestGroup" tabIndex="2" runat="server" Width="100%"></asp:dropdownlist></TD>
					<td align="left"><asp:linkbutton id="lbtnGetList" tabIndex="3" runat="server" Font-Size="Smaller" ForeColor="Blue" onclick="lbtnGetList_Click">Get list</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:linkbutton id="ButGetTest" tabIndex="3" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="ButGetTest_Click"> Refresh</asp:linkbutton></td>
				</TR>
				<TR>
					<td></td>
					<TD>Searching Test</TD>
					<TD><asp:textbox id="txtSearchString" runat="server" Width="100%"></asp:textbox></TD>
					<TD><asp:radiobutton id="rbLeft" runat="server" GroupName="TS" Text="Left"></asp:radiobutton>&nbsp;|
						<asp:radiobutton id="rbMiddle" runat="server" GroupName="TS" Text="Middle" Checked="True"></asp:radiobutton>&nbsp;|
						<asp:radiobutton id="rbRight" runat="server" GroupName="TS" Text="Right"></asp:radiobutton></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="4"></TD>
				</TR>
				<tr>
					<td colSpan="4"><asp:datagrid id="DGAllTest" runat="server" Width="100%" BorderColor="Silver" AllowSorting="True"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="section" HeaderText="Sub-Department">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="testgroup" HeaderText="Test Group">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="testname" HeaderText="Test Name">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="charges" HeaderText="Charges">
									<HeaderStyle HorizontalAlign="Right" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="delivery"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="testid"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="sectionid"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="testgroupid"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="testbatchno"></asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:LinkButton ID="dglbtnBatch" Enabled='<%# int.Parse(DataBinder.Eval(Container.DataItem, "TestBatchNo").ToString()) > 0 ? true : false%>' OnClick="dglbtnBatch_Click" Runat=server Font-Size="X-Small" ForeColor="Blue">Select Batch</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="Select" CommandName="Select">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></td>
				</tr>
				<TR>
					<TD colSpan="4">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="4">HMS_LM_IN_007</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
