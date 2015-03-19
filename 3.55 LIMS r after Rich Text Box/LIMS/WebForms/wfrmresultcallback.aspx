<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmResultCallBack" CodeFile="wfrmResultCallBack.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Result Call Back:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>RESULT CALL BACK</STRONG></font></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Report Type:</TD>
					<TD width="27%"><asp:dropdownlist id="ddlReportType" tabIndex="1" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right" width="13%">
						PR&nbsp;No:&nbsp;&nbsp;</TD>
					<TD width="35%"><asp:textbox id="txtPLNo" tabIndex="2" runat="server" Width="100px" CssClass="field" MaxLength="10"
							ToolTip="Enter Employee Service No"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD><asp:dropdownlist id="ddlSection" tabIndex="3" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Patient Name:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtPatientName" tabIndex="4" runat="server" Width="100%" CssClass="field" MaxLength="45"
							ToolTip="Enter Patient Name (optional)"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="ddlTestGroup" tabIndex="5" runat="server" Width="100%" AutoPostBack="True" Enabled="False" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" tabIndex="6" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test:</TD>
					<TD><asp:dropdownlist id="ddlTest" tabIndex="7" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
					<TD align="right">Rec - ID:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtMSerialNoFrom" tabIndex="8" runat="server" Width="100px" CssClass="field"
							MaxLength="14" ToolTip="Enter Serial No for view to start from (optional)"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:textbox id="txtMSerialNoTo" tabIndex="9" runat="server" Width="100px" CssClass="field" MaxLength="14"
							ToolTip="Enter Serial No for view to end at (optional)"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px">Ward:</TD>
					<TD style="HEIGHT: 17px">
						<asp:dropdownlist id="ddlWard" tabIndex="36" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right" style="HEIGHT: 17px">Lab - Date :</TD>
					<TD style="HEIGHT: 17px">
						<asp:TextBox id="txtDF" tabIndex="10" runat="server" Width="100px" CssClass="field"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
						<asp:textbox id="txtDT" tabIndex="11" runat="server" Width="100px" ToolTip="Enter Serial No for view to end at (optional)"
							MaxLength="10" CssClass="field"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"></TD>
					<TD style="HEIGHT: 19px">Patient Type:</TD>
					<TD colspan="2" style="HEIGHT: 19px">
						<asp:radiobuttonlist id="rbtnPatientType" runat="server" RepeatDirection="Horizontal" BorderWidth="1px"
							BorderColor="Olive" Font-Size="Small" Width="100%" BorderStyle="Dotted">
							<asp:ListItem Value="A" Selected="True">ALL</asp:ListItem>
							<asp:ListItem Value="E">Ent</asp:ListItem>
							<asp:ListItem Value="C">CNE</asp:ListItem>
							<asp:ListItem Value="P">PNL</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD align="center">
						<asp:radiobuttonlist id="rbtnIO" runat="server" RepeatDirection="Horizontal" BorderWidth="1px" BorderColor="Olive"
							Font-Size="Small" Width="100%" BorderStyle="Dotted">
							<asp:ListItem Value="A" Selected="True">ALL</asp:ListItem>
							<asp:ListItem Value="I">Indoor</asp:ListItem>
							<asp:ListItem Value="O">Outdoor</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD style="HEIGHT: 19px"></TD>
				</TR>
				<TR>
					<td colSpan="6"><asp:label id="lblRecordNo" runat="server" Width="520px" ForeColor="ForestGreen"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="images/btn_Refresh.gif"
                            OnClick="ibtnRefresh_Click" /></td>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgResultDis" runat="server" Width="100%" BorderColor="Silver" AutoGenerateColumns="False"
							AllowSorting="True" CssClass="datagrid" CellPadding="4" GridLines="Horizontal" OnSortCommand="dgResultDis_Sorting" OnItemDataBound="dgResultDis_ItemDataBound">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn Visible="False" HeaderText="Print-">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Checked="False" ID="dgchkPrint" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="Priority" ReadOnly="True" HeaderText="Priority-">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LabID" ReadOnly="True" HeaderText="Lab ID" SortExpression="LabID">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Test" SortExpression="Test">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" ReadOnly="True" HeaderText="Patient Name" SortExpression="PatientName">
									<HeaderStyle Width="13%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" ReadOnly="True" HeaderText="Sex" SortExpression="Psex">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" ReadOnly="True" HeaderText="Age" SortExpression="PAge">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" HeaderText="Type-"></asp:BoundColumn>
								<asp:BoundColumn DataField="EnteredDate" ReadOnly="True" HeaderText="Entry Date" SortExpression="EnteredDate">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="WardName" HeaderText="Ward" SortExpression="WardName">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo-"></asp:BoundColumn>
								<asp:BoundColumn DataField="Location" HeaderText="Location" SortExpression="Location">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Result Entry" CommandName="SenttoResultEntry">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="Verification" CommandName="SenttoVerification"></asp:ButtonColumn>
								<asp:ButtonColumn Text="Clear Result" CommandName="ClearR">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="ProcessID" HeaderText="ProcessID"></asp:BoundColumn>
								<asp:ButtonColumn Text="Edit Pat/Doctor Info" CommandName="EPName">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="MSerialNo" HeaderText="MSerialNo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_018</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
