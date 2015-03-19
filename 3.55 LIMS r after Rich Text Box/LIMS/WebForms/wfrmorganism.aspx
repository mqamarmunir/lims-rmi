<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmOrganism" CodeFile="wfrmOrganism.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Organism:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD align="center" colSpan="7"><font size="4"><STRONG>ORGANISM REGISTRATION</STRONG></font></TD>
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
					<TD>
						<asp:textbox id="txtOrganismID" tabIndex="4" runat="server" Width="100%" CssClass="flattextbox"
							Visible="False"></asp:textbox></TD>
					<TD align="right"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Organism:</TD>
					<TD colSpan="2">
						<asp:textbox id="txtOrganism" runat="server" Width="100%" tabIndex="4" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD align="right">Acronym:&nbsp;&nbsp;</TD>
					<TD>
						<asp:textbox id="txtAcronym" runat="server" Width="100%" tabIndex="5" CssClass="mandatoryfield"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"></TD>
					<TD style="HEIGHT: 19px">Description:</TD>
					<TD style="HEIGHT: 19px" colspan="4">
						<asp:textbox id="txtDescription" tabIndex="4" runat="server" Width="100%" CssClass="flattextbox"
							TextMode="MultiLine" Rows="2"></asp:textbox></TD>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
				<TR>
					<TD colSpan="7">&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="7" align="center">
						<asp:datagrid id="dgOrganism" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Silver"
							PageSize="25" CssClass="datagrid" OnSortCommand="dgOrganism_Sorting" >
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="OrganismID" HeaderText="OrganismID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Organism" SortExpression="Organism" ReadOnly="True" HeaderText="Organism">
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
								<asp:BoundColumn Visible="False" DataField="Description" HeaderText="Description"></asp:BoundColumn>
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
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
