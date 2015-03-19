<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmDrug" CodeFile="wfrmDrug.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Drug Registration:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="vs_showGrid" content="True">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colspan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>DRUG REGISTRATION</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6">
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:ImageButton id="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif"></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Organism:</TD>
					<TD colspan="2"><asp:DropDownList id="ddlOrganism" runat="server" Width="100%" AutoPostBack="True" tabIndex="1" onselectedindexchanged="ddlOrganism_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Active:</TD>
					<TD>
						<asp:CheckBox id="chkActive" runat="server" Checked="True" tabIndex="2" ToolTip="Check to Active Test Group"></asp:CheckBox></TD>
					<TD colspan="3"></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="15%">
						Drug:</TD>
					<TD width="35%">
						<asp:TextBox id="txtDrug" runat="server" Width="100%" CssClass="mandatoryfield" tabIndex="3"
							ToolTip="Enter Test Group Name"></asp:TextBox></TD>
					<TD width="10%" align="right">Acronym:&nbsp;&nbsp;</TD>
					<TD width="20%">
						<asp:TextBox id="txtAcronym" runat="server" Width="100%" CssClass="field" tabIndex="4" ToolTip="Enter Test Group Acronym"
							MaxLength="10"></asp:TextBox></TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center">
						<asp:DataGrid id="dgDrug" runat="server" AllowSorting="True" AutoGenerateColumns="False" PageSize="25"
							AllowCustomPaging="True" CssClass="datagrid" BorderColor="Silver" OnSortCommand=dgDrug_Sorting>
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<EditItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#C9CDE7"></EditItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="DrugID" HeaderText="DrugID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Drug" ReadOnly="True" HeaderText="Drug" SortExpression="Drug">
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
								<asp:ButtonColumn Text="Select" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_001</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
