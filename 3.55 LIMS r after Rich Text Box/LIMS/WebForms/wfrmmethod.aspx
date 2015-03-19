<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmMethod" CodeFile="wfrmMethod.aspx.cs" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Method:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colspan="7" style="HEIGHT: 20px"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>METHOD REGISTRATION</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="200" align="right" border="0">
							<TR>
								<TD align="center">|</TD>
								<TD align="center">
									<asp:LinkButton id="lbtnSave" tabIndex="9" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnSave_Click">Save</asp:LinkButton></TD>
								<TD align="center">|</TD>
								<TD align="center">
									<asp:LinkButton id="lbtnClearAll" tabIndex="10" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnClearAll_Click">Clear All</asp:LinkButton></TD>
								<TD align="center">|</TD>
                                <TD align="center">
									<asp:LinkButton id="LinkButton1" tabIndex="11" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnClose_Click">Close</asp:LinkButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="7">
						<asp:Label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colSpan="2">
						<asp:dropdownlist id="ddlSection" runat="server" Width="100%" tabIndex="1" AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="10%"></TD>
					<TD width="15%"></TD>
					<TD width="19%"></TD>
					<TD width="18%"></TD>
					<TD width="18%"></TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Active:</TD>
					<TD>
						<asp:checkbox id="chkActive" runat="server" Width="100%" tabIndex="2" Checked="True"></asp:checkbox></TD>
					<TD></TD>
					<TD align="right">Default:&nbsp;&nbsp;</TD>
					<TD>
						<asp:checkbox id="chkDefault" runat="server" Width="100%" tabIndex="3"></asp:checkbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Method:</TD>
					<TD colSpan="2">
						<asp:textbox id="txtMethod" runat="server" Width="100%" tabIndex="4" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD align="right">Acronym:&nbsp;&nbsp;</TD>
					<TD>
						<asp:textbox id="txtAcronym" runat="server" Width="100%" tabIndex="5" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD></TD>
				</TR>
             <%--   <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>--%>
				<TR>
					<TD style="HEIGHT: 19px"></TD>
					<TD style="HEIGHT: 19px">TAT:</TD>
					<TD style="HEIGHT: 19px">
						<asp:dropdownlist id="ddlTAT" runat="server" Width="100%" tabIndex="6">
							<asp:ListItem Value="N" Selected="True">N/A</asp:ListItem>
							<asp:ListItem Value="H">Hour(s)</asp:ListItem>
							<asp:ListItem Value="D">Day(s)</asp:ListItem>
							<asp:ListItem Value="W">Week(s)</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD style="HEIGHT: 19px" align="right">Min/Max:&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 19px">
						<asp:textbox id="txtMinTime" runat="server" Width="100%" tabIndex="7" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD style="HEIGHT: 19px">
						<asp:textbox id="txtMaxTime" runat="server" Width="100%" tabIndex="8" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
				<TR>
					<TD>&nbsp;&nbsp;</TD>
                    <td>Text:</td>
                    <td colspan="2">
                        <CKEditor:CKEditorControl ID="rtbText" runat="server" Height="50px" 
                            Toolbar="Basic" ToolbarBasic="Source|-|Bold|Italic" EnterMode="BR" ShiftEnterMode="BR" >
                        </CKEditor:CKEditorControl>
                    </td>
				</TR>
				<TR>
					<TD colSpan="7" align="center">
						<asp:datagrid id="dgMethod" runat="server" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
							BorderColor="Silver" PageSize="25" CssClass="datagrid" oninit="dgMethod_Init">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                            <asp:TemplateColumn HeaderText="S#">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="MethodID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Method" SortExpression="Method" ReadOnly="True" HeaderText="Method">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" SortExpression="Acronym" HeaderText="Acronym">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled=False Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Edit">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:BoundColumn Visible="False" DataField="TAT" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MinTime" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MaxTime" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MDefault" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DOrder" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Report_Text" ReadOnly="true"></asp:BoundColumn>
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
