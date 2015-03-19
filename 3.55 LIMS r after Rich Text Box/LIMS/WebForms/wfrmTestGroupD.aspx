<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestGroupD.aspx.cs" Inherits="LIMS_WebForms_wfrmTestGroupD" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Test Group Detail:    <% =Session["UNUIDFORMATTED"] %>
    </title>
    <meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
   
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="5"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5"><font size="4"><STRONG>TEST GROUP DETAIL<asp:ScriptManager 
                            ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="5">
                    <asp:HiddenField ID="hdEdit" runat="server" />
                    <asp:HiddenField ID="hdGroupDetail" runat="server" />
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnrefresh" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefresh_Click" Visible="false"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD colSpan="5"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
               
                <tr>
              
                <td align="right" >
                Sub-Department:
                </td>
                <td>
                <asp:DropDownList ID="ddlSubDepartment" Width="98%" AutoPostBack="true" 
                        CssClass="field" runat="server" 
                        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">
                Test Group:
                </td>
                <td>
                <asp:DropDownList ID="ddlTestGroup" Width="60%" AutoPostBack="true" 
                        CssClass="field" Enabled="false" runat="server" 
                        onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:DropDownList>
                        <asp:CheckBox ID="chkActive" Text="Active" Checked="true" runat="server" />
                </td>
                
                <td >
                
                </td>
                </tr>
               
                
                <tr>
                <td align="right">
                Test:
                </td>
                <td >
                <asp:DropDownList ID="ddlTest" Width="98%" AutoPostBack="true" CssClass="field" 
                        Enabled="false" runat="server" 
                        onselectedindexchanged="ddlTest_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">Charges:</td>
                <td colspan="2"><asp:TextBox ID="txtCharges" CssClass="field" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                Rate:<asp:TextBox ID="txtRate" CssClass="field" runat="server"></asp:TextBox>
                </td>
                <td></td>
                </tr>
                <tr><td> <asp:Label ID="lblCount"  Visible="false" runat="server"></asp:Label></td>
                <td><asp:Label ID="lblGroupTotal" runat="server" Visible="false" Font-Bold="true" Font-Size="Small"></asp:Label></td>
                </tr>
                <tr>
                <td colspan="7">
                 <asp:GridView ID="gvTests" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datagrid" HorizontalAlign="Center"  Height="9px" AllowSorting="True"
                             OnSorting="gvTests_Sorting" OnRowCommand="gvTests_RowCommand" DataKeyNames="GroupDetailID">
                            <Columns>
                                <%--<asp:BoundField HeaderText="Marital Status" DataField="marital_status">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>--%>
                                <%--<asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>--%>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Sub-Department" DataField="SECTIONNAME" SortExpression="SECTIONNAME">
                                <HeaderStyle HorizontalAlign="Left" />
                                    
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Group Name" DataField="TestGroup" SortExpression="TestGroup" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TEST" HeaderText="Test Name" SortExpression="TEST">
                                   <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            
                                <asp:BoundField HeaderText="Charges" DataField="CHARGES" SortExpression="CHARGES">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y") %>' runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateField>
                           <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                             
                                
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                            
                        </asp:GridView>
                
                </td>
                </tr>
               </TABLE>
    </div>
    <div>
   
    </div>
    </form>
</body>
</html>
