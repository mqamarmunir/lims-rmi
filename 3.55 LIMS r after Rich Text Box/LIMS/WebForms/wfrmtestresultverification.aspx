<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestResultVerification" CodeFile="wfrmTestResultVerification.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD runat="server">
		<title>LIMS: Result Verification:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<%--<meta content="JavaScript" name="vs_defaultClientScript">--%>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!--<meta http-equiv="refresh" content="300">-->
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
    
		<form id="Form1" method="post" runat="server">
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
			<TABLE class="label" id="Table1" style="LEFT: 1px; POSITION: absolute; TOP: 1px" cellPadding="1"
				width="100%" border="0" cellSpacing="1">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>--%>
				</TR>
				<TR>
					<TD align="center" colSpan="6" height="24"><font size="4"><u><asp:label id="lblHeading" runat="server" Font-Bold="True" Font-Underline="True">Result Verification</asp:label></u></font>
                    <asp:HiddenField ID="hdresultEntryTime" runat="server" />
                    <%--<asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>--%>
                    </TD>
				</TR>
				<TR>
					<TD align="left" colSpan="6" style="HEIGHT: 18px">
						<asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label>&nbsp;</TD>
				</TR>
                <tr>
                    <td width="5%">
                    </td>
                    <td width="15%">
                        Rec-ID:</td>
                    <td width="25%">
                        <asp:textbox id="txtMSerialNoFrom" runat="server" Width="96px" CssClass="field"></asp:textbox>&nbsp; 
						To&nbsp;
						<asp:textbox id="txtMSerialNoTo" runat="server" Width="96px" CssClass="field"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right" width="10%">
                        Department:</td>
                    <td width="40%">
                        <asp:dropdownlist id="ddlSection" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></td>
                    <td width="5%">
                    </td>
                </tr>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">
                        PR No:</TD>
					<TD width="25%">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="field" Width="54%" Wrap="False"></asp:TextBox></TD>
					<TD align="right" width="10%">Test Group:&nbsp;&nbsp;</TD>
					<TD width="40%"><asp:dropdownlist id="ddlTestGroup" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">
                        Patient Name:</TD>
					<TD width="25%">
                        <asp:TextBox ID="txtPatientName" runat="server" CssClass="field" Width="100%"></asp:TextBox></TD>
					<TD align="right" width="10%">Ward:&nbsp;&nbsp;</TD>                       
					<TD width="40%">
						<asp:dropdownlist id="ddlWard" tabIndex="36" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%"></TD>
					<TD width="30%"></TD>
					<TD width="10%"></TD>
					<TD width="40%" align="center">
                        <asp:ImageButton ID="ibtnRefresh" runat="server" ImageUrl="images/btn_Refresh.gif"
                            OnClick="ibtnRefresh_Click" />
                        <asp:ImageButton ID="ibtnAll" runat="server" ImageUrl="images/btn_All.gif" OnClick="ibtnAll_Click" />
                        &nbsp; &nbsp;
                        <asp:ImageButton ID="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif" OnClick="ibtnClose_Click" /></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblRecordNo" runat="server"  ForeColor="ForestGreen" Font-Bold="True"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                     <asp:Label ID="ColorCode1" runat="server" BackColor="Gold" Visible="false"></asp:Label>
                    &nbsp;<asp:Label ID="ColorCode2" runat="server" BackColor="Silver" Visible="false"></asp:Label>
                    &nbsp;<asp:Label ID="ColorCode3" runat="server" Text="OverDue" BackColor="OrangeRed" Visible="false"></asp:Label>
                    
                    &nbsp;<asp:Label ID="ColorCode4" runat="server" Text="Repeat" BackColor="Bisque" Visible="true"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD colSpan="6">
                     <asp:TabContainer ID="TabContainer1" Width="100%" runat="server"  Visible="true"
                            ActiveTabIndex="0" onactivetabchanged="TabContainer1_ActiveTabChanged" 
                            AutoPostBack="True">
                    <asp:TabPanel ID="tbInternaltest" runat="server">
                   <HeaderTemplate>
                        Internal Tests<asp:Label ID="lblIntCount" runat="server" Text=""></asp:Label>
                        </HeaderTemplate>
                     <ContentTemplate>
						<div><asp:datagrid id="dgGroupList" runat="server" BorderColor="Black" AutoGenerateColumns="False"
								PageSize="150" Width="99%" CellPadding="5" GridLines="Horizontal" CssClass= "datagrid" AllowSorting="True" 
                                OnSortCommand ="dgGroupList_Sorting" 
                                OnItemDataBound="dgGrouplist_OnRowDataBound" 
                                onitemcreated="dgGroupList_ItemCreated1">
								<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
								<Columns>
									<asp:ButtonColumn DataTextField="LabID" HeaderText="Lab ID" CommandName="Select" SortExpression="LabID">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="Test" SortExpression="Test" HeaderText="Test">
										<HeaderStyle Width="21%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PatientName" SortExpression="PatientName" ReadOnly="True" HeaderText="Patient">
										<HeaderStyle Width="25%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAge" HeaderText="Age" SortExpression="PAge">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Type" SortExpression="Type" ReadOnly="True" HeaderText="Type" Visible="false">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WardName" HeaderText="Ward" SortExpression="WardName">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProcessID" HeaderText="ProcessID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="MSerialNo" HeaderText="MSerialNo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TestType" HeaderText="TestType"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="testid" HeaderText="testid" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="cal_age" HeaderText="cal_age" Visible="False"></asp:BoundColumn>
								    <asp:BoundColumn DataField="DeliveryDate" HeaderText="Delivery Date" 
                                        Visible="False"></asp:BoundColumn>
                                         <asp:BoundColumn DataField="Origin" HeaderText="Booked At" SortExpression="Origin"></asp:BoundColumn>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="gvimgReviewComments" ImageUrl="~/images/a-unread.png" OnClick="gvimgReviewComments_Click" Visible="false" ToolTip="Peer Comments about the Result" runat="server" />
                                                <asp:ModalPopupExtender ID="gvimgReviewComments_ModalPopupExtender" 
                                                    runat="server" PopupControlID="pnlComments" DynamicServicePath="" Enabled="True" 
                                                    TargetControlID="gvimgReviewComments">
                                                </asp:ModalPopupExtender>
                                                <asp:Panel ID="pnlComments" visible="false" runat="server" width="400px">
                        <table id="tblcomments" style="background-color:Aqua" class="label" width="99%">
                        <tr>
                            <td width="99%" align="right">
                                <asp:LinkButton ID="lnkclose" Text="[X]close" OnClick="lnkClose_Click" runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="99%">
                                <asp:GridView ID="gvComments" CssClass="datagrid" runat="server" AutoGenerateColumns="false" Width="99%">
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="70%" HeaderText="Comments" DataField="Comments" />
                                    <asp:BoundField HeaderText="Entered By" DataField="EnteredBy" />
                                </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                    </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></div>
                            </ContentTemplate>
                            </asp:TabPanel>
                            <asp:TabPanel ID="tbExternaltest" runat="server" >
                        <HeaderTemplate>
                        External Tests<asp:Label ID="lblExtTcount" runat="server" Text=""></asp:Label>
                        </HeaderTemplate>
                        <ContentTemplate>
                        	<div><asp:datagrid id="dgGroupListExt" runat="server" BorderColor="Black" AutoGenerateColumns="False"
								PageSize="150" Width="99%" CellPadding="5" GridLines="Horizontal" OnItemCommand="dgGroupList_ItemCommand" 
                                OnItemDataBound="dgGrouplist_OnRowDataBound" AllowSorting="True" 
                                CssClass="datagrid" OnSortCommand="dgGroupList_Sorting" 
                                onitemcreated="dgGroupList_ItemCreated1">
								<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
								<Columns>
                                
									<asp:ButtonColumn DataTextField="LabID" HeaderText="Lab ID" CommandName="Select" SortExpression="LabID">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:ButtonColumn>
									<asp:BoundColumn DataField="Test" SortExpression="Test" HeaderText="Test">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PatientName" SortExpression="namewotitle" ReadOnly="True" HeaderText="Patient">
										<HeaderStyle Width="15%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PSex" SortExpression="PSex" ReadOnly="True" HeaderText="Sex">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PAge" HeaderText="Age" SortExpression="PAge">
										<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Type" SortExpression="Type" ReadOnly="True" HeaderText="Type" Visible="false">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="WardName" HeaderText="Ward" SortExpression="WardName">
										<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Priority" SortExpression="Priority" ReadOnly="True" HeaderText="Priority">
										<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProcessID" HeaderText="ProcessID"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="MSerialNo" HeaderText="MSerialNo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="TestType" HeaderText="TestType"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="testid" HeaderText="testid" Visible="False"></asp:BoundColumn>
                                    <asp:BoundColumn DataField="Cal_Age" HeaderText="Cal_Age" Visible="False"></asp:BoundColumn>
								    <asp:BoundColumn DataField="Deliverydate" HeaderText="Delivery Date" 
                                        Visible="False">
                                    </asp:BoundColumn>
                                     <asp:BoundColumn DataField="Origin" HeaderText="Booked At" SortExpression="Origin"></asp:BoundColumn>
                                    
								    <asp:BoundColumn DataField="PRNo" Visible="False"></asp:BoundColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></div>
                        </ContentTemplate>
                        </asp:TabPanel>
                        </asp:TabContainer>
					</TD>
					<DIV></DIV>
				</TR>
                <tr>
                <td colspan="6">
                    
                </td>
                </tr>
				<TR>
					<TD colSpan="6"></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_008</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
