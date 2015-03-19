<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmSpecimenCollection" CodeFile="wfrmSpecimenCollection.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LIMS: Specimen Collection:    <% =Session["UNUIDFORMATTED"] %></title>
       
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
		<asp:ScriptManager ID="smanager" runat="server"></asp:ScriptManager>
        	<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>SPECIMEN COLLECTION</STRONG></font>
                     <asp:HiddenField ID="hdcollTimeIn" runat="server" />
                      <asp:HiddenField ID="hdcollTimeOut" runat="server" />
                    </TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="30%"><asp:dropdownlist id="ddlSection" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right" width="13%">Patient Name:&nbsp;&nbsp;</TD>
					<TD width="32%"><asp:textbox id="txtPatientName" runat="server" Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="ddlTestGroup" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Lab ID:</TD>
					<TD><asp:textbox id="txtMSerialNoFrom" runat="server" Width="40%" CssClass="field"></asp:textbox><asp:textbox id="txtMSerialNoTo" runat="server" Width="40%" CssClass="field"></asp:textbox></TD>
					<TD align="right">Specimen:&nbsp;&nbsp;</TD>
					<TD align="center">
						<asp:dropdownlist id="ddlSpecimenType" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Lab Date:</TD>
					<TD>
						<asp:TextBox id="txtDF" tabIndex="10" runat="server" Width="100px" CssClass="field"></asp:TextBox>
						<asp:textbox id="txtDT" tabIndex="11" runat="server" Width="100px" CssClass="field" ToolTip="Enter Serial No for view to end at (optional)"
							MaxLength="10"></asp:textbox></TD>
					<TD colspan="2" align="center">
                        <asp:ImageButton ID="ibtnToday" runat="server" ImageUrl="images/btn_Today.GIF" OnClick="ibtnToday_Click" />
                        <asp:ImageButton ID="ibtnLast2Days" runat="server" ImageUrl="images/btn_Last 2 days.GIF"
                            OnClick="ibtnLast2Days_Click" />
                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="images/btn_Refresh.gif"
                            OnClick="ibtnRefresh_Click" />
                        <asp:ImageButton ID="ibtnAll" runat="server" ImageUrl="images/btn_All.GIF" OnClick="ibtnAll_Click" />
                        <asp:ImageButton ID="ibtnIndoorReport" runat="server" ImageUrl="images/btn_IndoorReport.GIF"
                            OnClick="ibtnIndoorReport_Click" /><asp:ImageButton
                            ID="ibtnSave" runat="server" ImageUrl="images/btn_Close.gif" OnClick="ibtnSave_Click" /></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblRecordNo" runat="server" ForeColor="ForestGreen"></asp:label>
                    &nbsp;&nbsp;&nbsp;
                    <asp:Label ID="ColorCode1" BackColor="BurlyWood" Text="Delayed SpecimenIndoor" Font-Size="X-Small" runat="server"></asp:Label>

                    &nbsp;&nbsp;&nbsp;&nbsp;

                    <asp:Label ID="ColorCode2" BackColor="Cyan" Text="Delayed SpecimenOutDoor" Font-Size="X-Small" runat="server"></asp:Label>
                    &nbsp;&nbsp;   
                    <asp:Label ID="ColorCode3" BackColor="Bisque" Text="Repeat Test" Font-Size="X-Small" runat="server"></asp:Label>
                    &nbsp;&nbsp;   
                    <asp:Label ID="ColorCode4" BackColor="OliveDrab" Text="Commented" Font-Size="X-Small" runat="server"></asp:Label>
                    &nbsp;&nbsp;   
                    <asp:Label ID="ColorCode5" BackColor="SeaShell" Text="External" Font-Size="X-Small" runat="server"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD colSpan="6">
                        <asp:TabContainer ID="TabContainer1"  Width="100%" runat="server" 
                            ActiveTabIndex="1">
                        <asp:TabPanel ID="Tabpanel1" Width="100%" runat="server">
                        <HeaderTemplate>Internal Tests <asp:Label ID="lblicount" runat="server"></asp:Label></HeaderTemplate>
                        <ContentTemplate>
                            <asp:datagrid id="dgGroupList" runat="server" Width="100%" 
                            BorderColor="Gray" AutoGenerateColumns="False"
							AllowSorting="True" CellPadding="5" GridLines="Horizontal" CssClass="datagrid" 
                             OnSortCommand="dgGroupList_Sorting" 
                            OnItemCommand="dgGroupList_ItemCommand" 
                            OnItemDataBound="dgGroupList_ItemDataBound">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Visible="False" Text="Collect" CommandName="Collect">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LabID" SortExpression="LabID" HeaderText="Lab ID">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="namewotitle" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="24%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" ReadOnly="True" SortExpression="PSex" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" ReadOnly="True" SortExpression="PAge" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" HeaderText="Type">
								</asp:BoundColumn>
								<asp:BoundColumn DataField="WardName" SortExpression="WardName" HeaderText="Ward">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Specimen" CommandName="Detail">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
							    <asp:BoundColumn DataField="IOP" HeaderText="IOP" Visible="False"></asp:BoundColumn>
							    <asp:BoundColumn DataField="ENTRYDATETIME" HeaderText="ENTRY DATETIME" 
                                    Visible="False"></asp:BoundColumn>
                                   
							    <asp:TemplateColumn>
                                <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Cancel" Visible="false" CommandName="Delete" CommandArgument='<%#Container.DataItem %>'></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                   
							    <asp:BoundColumn DataField="spec_coment" HeaderText="Comment" Visible="False">
                                </asp:BoundColumn>
                                  <asp:BoundColumn DataField="externaltest" HeaderText="External test" Visible="False">
                                </asp:BoundColumn> 
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="Tabpanel2" Width="100%" runat="server">
                        <HeaderTemplate>External Test <asp:Label ID="lblexcount" runat="server"></asp:Label></HeaderTemplate>
                        <ContentTemplate>
                         <asp:datagrid id="dgexternal" runat="server" Width="100%" 
                            BorderColor="Gray" AutoGenerateColumns="False"
							AllowSorting="True" CellPadding="5" GridLines="Horizontal" CssClass="datagrid" 
                             OnSortCommand="dgGroupList_Sorting" 
                            OnItemCommand="dgGroupList_ItemCommand" 
                            OnItemDataBound="dgGroupList_ItemDataBound">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Visible="False" Text="Collect" CommandName="Collect">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MSerialNo" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="LabID" SortExpression="LabID" HeaderText="Lab ID">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" SortExpression="namewotitle" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="24%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" ReadOnly="True" SortExpression="PSex" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" ReadOnly="True" SortExpression="PAge" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" HeaderText="Type">
									<HeaderStyle></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="WardName" SortExpression="WardName" HeaderText="Ward">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:ButtonColumn Text="Specimen" CommandName="Detail">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
							    <asp:BoundColumn DataField="IOP" HeaderText="IOP" Visible="false"></asp:BoundColumn>
							    <asp:BoundColumn DataField="ENTRYDATETIME" HeaderText="ENTRY DATETIME" 
                                    Visible="False"></asp:BoundColumn>
                                   
							    <asp:TemplateColumn>
                                <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="Cancel" Visible="false" CommandName="Delete" CommandArgument='<%#Container.DataItem %>'></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                   
							    <asp:BoundColumn DataField="spec_coment" HeaderText="Comment" Visible="False">
                                </asp:BoundColumn>
                                  <asp:BoundColumn DataField="externaltest" HeaderText="External test" Visible="False">
                                </asp:BoundColumn> 
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
                        
                        </ContentTemplate>
                        </asp:TabPanel>
                       
                        </asp:TabContainer>
                        &nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_010lign="right" colSpan="6">HMS_LM_IN_010</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
