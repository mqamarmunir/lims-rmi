<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTest" CodeFile="wfrmTest.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Resgistration : <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="7"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>TEST REGISTRATION</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" OnClick="ibtnSave_Click1" TabIndex="22"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif" TabIndex="23"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:ImageButton id="ibtnTestAttribute" runat="server" ImageUrl="images/btn_TestAttribute.gif" TabIndex="24"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif" TabIndex="25"></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="7"><asp:label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colSpan="2"><asp:dropdownlist id="ddlSection" tabIndex="1" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD colSpan="2"><asp:dropdownlist id="ddlTestGroup" tabIndex="2" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="15%"></TD>
					<TD width="15%"><asp:checkbox id="chkActive" tabIndex="3" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left"></asp:checkbox></TD>
					<TD width="23%">Format:&nbsp;&nbsp;
						<asp:dropdownlist id="ddlFormat" tabIndex="4" runat="server" Width="144px">
							<asp:ListItem Value="G">General</asp:ListItem>
							<asp:ListItem Value="H">Histo</asp:ListItem>
							<asp:ListItem Value="M">Micro</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD width="13%" align="right"></TD>
					<TD width="14%">
						</TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="15%">
						<asp:checkbox id="chkReportGroup" tabIndex="5" runat="server" Width="100%" Text="Report Group" TextAlign="Left"></asp:checkbox></TD>
					<TD width="15%">
                        &nbsp;<asp:checkbox id="chkUrgent" tabIndex="6" runat="server" Text="Urgent" TextAlign="Left"></asp:checkbox></TD>
					<TD width="23%">
						<asp:checkbox id="chkSepReport" tabIndex="7" runat="server" Text="Separate Report" TextAlign="Left"></asp:checkbox></TD>
					<TD width="13%" align="right">
						<asp:checkbox id="chkReportTest" tabIndex="8" runat="server" Width="100%" Checked="True" Text="Report Test" TextAlign="Left"></asp:checkbox></TD>
					<TD width="14%" align="right">
                        <asp:CheckBox ID="chkSummary" runat="server" TabIndex="9" Text="Summary" TextAlign="Left" /></TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test:</TD>
					<TD colSpan="4"><asp:textbox id="txtTest" tabIndex="10" runat="server" Width="100%" CssClass="mandatoryfield"
							ToolTip="Enter Test Name" MaxLength="200"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Acronym:</TD>
					<TD><asp:textbox id="txtAcronym" tabIndex="11" runat="server" Width="100%" CssClass="field" ToolTip="Enter Test Acronym"
							MaxLength="15"></asp:textbox></TD>
					<TD>Urgent Charges :
						<asp:textbox id="txtChargesUrgent" tabIndex="12" runat="server" Width="96px" ToolTip="Enter Test Charges"
							CssClass="mandatoryfield"></asp:textbox></TD>
					<TD align="right">Charges:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtCharges" tabIndex="13" runat="server" Width="100%" CssClass="mandatoryfield"
							ToolTip="Enter Test Charges"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Specimen (Sc.):</TD>
					<TD colspan="2"><asp:textbox id="txtSpecimen" tabIndex="14" runat="server" Width="100%" CssClass="mandatoryfield"
							ToolTip="Enter Test Specimen" MaxLength="50"></asp:textbox></TD>
					<TD align="right">Procedure:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlProcedure" tabIndex="15" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Specimen (Initial):</TD>
					<TD colspan="2">
						<asp:dropdownlist id="ddlSpecimenType" tabIndex="16" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Container:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSpecimenContainer" tabIndex="17" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>
						Interpretation:</TD>
					<TD colSpan="4"><asp:textbox id="txtAutomatedText" tabIndex="18" runat="server" Width="100%" CssClass="field"
							ToolTip="Enter Test Interpretation" MaxLength="1500" TextMode="MultiLine" Rows="3"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Clinical Use:</TD>
					<TD colSpan="4"><asp:textbox id="txtClinicalUse" tabIndex="19" runat="server" Width="100%" CssClass="field" ToolTip="Enter Test Clinical Use"
							MaxLength="255"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Generation Level:</TD>
					<TD colSpan="2"><asp:dropdownlist id="ddlGenLevel" tabIndex="20" runat="server" Width="96px">
							<asp:ListItem Value="S" Selected="True">Section</asp:ListItem>
							<asp:ListItem Value="G">Group</asp:ListItem>
							<asp:ListItem Value="T">Test</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right">Generate On:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlGenOn" tabIndex="21" runat="server" Width="100%">
							<asp:ListItem Value="R" Selected="True">Reception</asp:ListItem>
							<asp:ListItem Value="W">Work List</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
                <tr>
                    <td>
                    </td>
                    <td>
                        Re-Order Time:</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtReorder" runat="server" CssClass="field"></asp:TextBox>
                        (min)</td>
                    <td align="right">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
				<TR>
					<TD colSpan="7"></TD>
				</TR>
				<TR>
					<TD colSpan="7" align="center"><asp:datagrid id="dgTestList" runat="server" AllowSorting="True" AutoGenerateColumns="False" PageSize="25"
							AllowCustomPaging="True" CssClass="datagrid">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="TestID" HeaderText="Test ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Test" SortExpression="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" SortExpression="Acronym" HeaderText="Acronym">
									<HeaderStyle HorizontalAlign="Center" Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled=False Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn EditText="Edit">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:BoundColumn Visible="False" DataField="Charges" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Specimen" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="AutomatedText" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ClinicalUse" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProcedureID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestNoLevel" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestNoGenOn" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SpecimenType" HeaderText="SpecimenType"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SpecimenContainer" HeaderText="SpecimenContainer"></asp:BoundColumn>
								<asp:ButtonColumn Visible="False" Text="Delete" CommandName="Delete">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="TestType" HeaderText="TestType"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEPREPORT" HeaderText="SEPREPORT"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PRINTGROUP" HeaderText="PRINTGROUP"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PRINTTEST" HeaderText="PRINTTEST"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CHARGESURGENT" HeaderText="CHARGESURGENT"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Urgent" HeaderText="Urgent"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Summary" HeaderText="Summary" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReorderTime" HeaderText="Reorder" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="7">HMS_LM_IN_002</TD>
				</TR>
			</TABLE>
			&nbsp;</FORM>
	</body>
</HTML>
