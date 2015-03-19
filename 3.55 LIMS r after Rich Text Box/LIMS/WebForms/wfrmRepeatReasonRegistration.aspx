<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmRepeatReasonRegistration.aspx.cs" Inherits="LIMS_WebForms_wfrmRepeatReasonRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
					<TD align="center" colSpan="7"><font size="4"><STRONG>REPEAT REASON REGISTRATION<asp:HiddenField ID="ReasonID" runat="server" />
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
					<%--	<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="right" colspan="5">--%>
                        
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" ToolTip="Insert" OnClick="ibtnSave_Click" Visible="true"></asp:ImageButton>
						
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					
				
					
					</TD>
							<%--</TR>
						</TABLE>
					</TD>--%>
				</TR>
				<TR>
					<TD colSpan="7">
						<asp:Label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
			<TR>
					<TD width="10%">
						</TD>
					<TD width="10%"></TD>
					<TD width="15%"></TD>
					<TD width="19%"></TD>
					<TD width="18%"></TD>
					<TD width="18%"></TD>
					<TD width="10%"></TD>
				</TR>
				<%--<TR>
					<TD>
						&nbsp;</TD>
					<TD>
						&nbsp;</TD>
					<TD align="right"></TD>
					<TD></TD>
					<TD></TD>
				</TR>--%>
				<TR>
					<TD></TD>
					<TD>Reason:</TD>
					<TD colSpan="2">
						<asp:textbox id="txtReason" runat="server" Width="100%" tabIndex="4" CssClass="mandatoryField"></asp:textbox></TD>
					<TD>&nbsp;&nbsp;<asp:checkbox id="chkActive" Text="Active" runat="server" Width="100%" tabIndex="2" Checked="True"></asp:checkbox></TD>
					<TD>
						&nbsp;</TD>
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
                <td></td>
					<TD colSpan="7"><asp:Label ID="lblCount" runat="server" Visible="false" ForeColor="Green"></asp:Label></TD>
				</TR>
				<TR>
                <td></td>
					<TD colSpan="5" align="left">
						<asp:datagrid id="dgReasons" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Silver"
							PageSize="25" CssClass="datagrid" OnSortCommand="dgReasons_Sorting" OnItemCommand="dgReasons_ItemCommand" >
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                            <asp:TemplateColumn HeaderText="S#" >
                            <HeaderStyle Width="2%" HorizontalAlign="Center"/>
                            <ItemStyle Width="2%" HorizontalAlign="Center" />
                            <ItemTemplate>
                            <%#Container.ItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="REPEATREASON_ID" HeaderText="REPEATREASON_ID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Reason" SortExpression="Reason" ReadOnly="True" HeaderText="Reason">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Description" SortExpression="Description" Visible="false" HeaderText="Description">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="false" Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								
								<asp:ButtonColumn Text="Edit" CommandName="Select">
                                
                                <HeaderStyle Width="8%" />
                                <ItemStyle Width="8%" />
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
