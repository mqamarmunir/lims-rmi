<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmAttributeTemplates.aspx.cs" Inherits="LIMS_WebForms_wfrmAttributeTemplates" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<HTML>
	<HEAD>
		<title>LIMS: Attribute Templates:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD align="center" colSpan="7"><font size="4"><STRONG>ATTRIBUTE TEMPLATES<asp:HiddenField ID="hdTemplateID" runat="server" />
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
					<TD width="15%"></TD>
					<TD width="20%"></TD>
					<TD width="15%"></TD>
					<TD width="20%"></TD>
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
					<TD>Sub-Department</TD>
					<TD>
						<asp:DropDownList ID="ddlSubDepartment" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList>
					<TD>Test:</TD>
					<TD>
						<asp:DropDownList ID="ddlTest" runat="server" AutoPostBack="true" 
                            onselectedindexchanged="ddlTest_SelectedIndexChanged"></asp:DropDownList> </TD>
					<TD>&nbsp;</TD>
				</TR>
                <tr>
                <td></td>
                <td>
                Attribute:
                </td>
                <td>
                <asp:DropDownList ID="ddlAttributes" runat="server" AutoPostBack="true" 
                        onselectedindexchanged="ddlAttributes_SelectedIndexChanged" ></asp:DropDownList>
                </td>
                <td colspan="2"><asp:checkbox id="chkActive" Text="Active" runat="server"  Width="25%" tabIndex="2" Checked="True"></asp:checkbox>
                <asp:CheckBox ID="chkDefault" runat="server" Checked="true"  Text="Default" CssClass="label" />
                </td>
                </tr>
				<TR>
					<TD ></TD>
					<TD >Description:</TD>
					<TD colspan="4">
						<asp:textbox id="txtDescription" tabIndex="4" runat="server" Width="100%" CssClass="flattextbox"
							TextMode="MultiLine" Rows="2"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
                <td></td>
					<TD colSpan="7"><asp:Label ID="lblCount" runat="server" Visible="false" ForeColor="Green"></asp:Label></TD>
				</TR>
				<TR>
                <td></td>
					<TD colSpan="5" align="left">
						<asp:datagrid id="dgTemplates" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Silver"
							PageSize="25" CssClass="datagrid" OnSortCommand="dgTemplates_Sorting" OnItemCommand="dg_ItemCommand" >
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
								<asp:BoundColumn Visible="False" DataField="TEMPLATEID" HeaderText="TEMPLATEID"></asp:BoundColumn>
                                <asp:BoundColumn Visible="false" DataField="AttributeID" ></asp:BoundColumn>
								<asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True" HeaderText="Attribute">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Description" SortExpression="Description" Visible="true" HeaderText="Description">
									<HeaderStyle HorizontalAlign="left" Width="50%"></HeaderStyle>
									<ItemStyle Width="50%" HorizontalAlign="left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="false" Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn SortExpression="T_Default" HeaderText="Default">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkDefault" Enabled="false" Checked='<%#(DataBinder.Eval(Container.DataItem, "T_Default").ToString() == "Y")%>' runat="server">
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
