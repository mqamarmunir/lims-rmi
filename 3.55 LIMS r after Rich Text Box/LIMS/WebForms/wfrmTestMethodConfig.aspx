<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestMethodConfig.aspx.cs" Inherits="LIMS_WebForms_wfrmTestMethodConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Test Method Config:    <% =Session["UNUIDFORMATTED"] %>
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
					<TD align="center" colSpan="5"><font size="4"><STRONG>TEST METHOD CONFIGURATION<asp:ScriptManager 
                            ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="5">
                    <asp:UpdatePanel ID="updatehdFields" runat="server">
                    <ContentTemplate>
                    
                    <asp:HiddenField ID="hdEdit" runat="server" />
                    <asp:HiddenField ID="hdTestMethod" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="gvTestMethod" EventName="RowCommand" />
                    </Triggers>
                    </asp:UpdatePanel>
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnrefresh" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefresh_Click" Visible="false"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="false" 
                            onclick="ibtnClose_Click" style="height: 26px"></asp:ImageButton>
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
                Method:
                </td>
                <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
                <ContentTemplate>
               
               
                <asp:DropDownList ID="ddlMethod" Width="60%" AutoPostBack="true" 
                        CssClass="field" Enabled="false" runat="server" 
                        onselectedindexchanged="ddlMethod_SelectedIndexChanged"></asp:DropDownList>
                       </ContentTemplate>
                       <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged" />
                       </Triggers>
                </asp:UpdatePanel>
                </td>
                
                <td >
                
                </td>
                
                </tr>
                
                
                <tr>
                <td align="right">
                Test:
                </td>
                <td >
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Always" runat="server">
                <ContentTemplate>
                <asp:DropDownList ID="ddlTest" Width="98%" AutoPostBack="true" CssClass="field" 
                        Enabled="false" runat="server" 
                        onselectedindexchanged="ddlTest_SelectedIndexChanged">
                    </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged" />
                 
                    </Triggers>
                </asp:UpdatePanel>  
                </td>
                <td align="right">
              
                
               
                DOrder:</td>
                <td colspan="2">
                  <asp:UpdatePanel ID="UpdateForm" runat="server">
                <ContentTemplate>
                <asp:TextBox ID="txtDorder" CssClass="field" runat="server"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:CheckBox ID="chkDefault" Text="Default" Checked="false" runat="server" />
                &nbsp;
                        <asp:CheckBox ID="chkActive" Text="Active" Checked="true" runat="server" />
                          </ContentTemplate>
                          <Triggers>
                          <asp:AsyncPostBackTrigger ControlID="gvTestMethod" EventName="RowCommand" />
                          </Triggers>
                          </asp:UpdatePanel>
                </td>
                <td></td>
                </tr>
                <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:UpdatePanel ID="UpdatePanel3" UpdateMode="Always" runat="server">

                <ContentTemplate> <asp:Label ID="lblCount"  Visible="false" runat="server"></asp:Label>
                </ContentTemplate></asp:UpdatePanel></td>
                
                </tr>
                <tr>
                <td colspan="7">
                <asp:UpdatePanel ID="Updategrid" UpdateMode="Always" runat="server">
                <ContentTemplate>
                
                 <asp:GridView ID="gvTestMethod" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                             DataKeyNames="TestMethodID" CssClass="datagrid" HorizontalAlign="Center"  Height="9px" AllowSorting="True"
                             OnSorting="gvTestMethod_Sorting" OnRowCommand="gvTestMethod_RowCommand" >
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
                                <asp:BoundField HeaderText="Sub-Department" SortExpression="SECTIONNAME" 
                                    DataField="SECTIONNAME">
                                <HeaderStyle HorizontalAlign="Left" />
                                    
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="Test Name" SortExpression="TEST" DataField="TEST">
                                   <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                 <asp:BoundField HeaderText="DOrder" SortExpression="D_Order" DataField="D_Order">
                                   <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                               <asp:TemplateField SortExpression="M_Default" HeaderText="Default">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkDefault" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem,"M_Default").ToString()=="Y") %>' runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateField>
                            
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
                        </ContentTemplate>
                        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlMethod" EventName="SelectedIndexChanged" />
                        </Triggers>
                </asp:UpdatePanel>
                
                </td>
                </tr>
               </TABLE>
    </div>
 
    </form>
</body>
</html>
