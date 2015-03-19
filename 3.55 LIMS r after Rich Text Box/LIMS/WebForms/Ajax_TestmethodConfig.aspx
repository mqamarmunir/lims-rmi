<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ajax_TestmethodConfig.aspx.cs" Inherits="LIMS_WebForms_Ajax_TestmethodConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Test Method Config:  <%--  <% =Session["UNUIDFORMATTED"] %>--%>
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
    <asp:ScriptManager  ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
                        </asp:ScriptManager>
     <table class="label" id="Table1"
				cellSpacing="1" cellPadding="1" runat="server" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="5"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5"><font size="4"><STRONG>TEST METHOD CONFIGURATION
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="5">
                    <asp:HiddenField ID="hdEdit" runat="server" />
                    <asp:HiddenField ID="hdTestMethod" runat="server" />
                    <asp:UpdateProgress ID="ashgdbjha"   runat="server">
                    <ProgressTemplate>
                    Updating...
                    </ProgressTemplate>
                    </asp:UpdateProgress>
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
                 </table>
                 
                 <table cellpadding="1" cellspacing="1" class="label">
                <tr>
                
                
                <td >
              
                Sub-Department:
                <asp:DropDownList ID="ddlSubDepartment" AutoPostBack="true" 
                        CssClass="field" runat="server" 
                        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged">
                    </asp:DropDownList>

                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
                    Method:
                     <asp:DropDownList ID="ddlMethod"  AutoPostBack="true" 
                        CssClass="field" Enabled="false" runat="server" 
                        onselectedindexchanged="ddlMethod_SelectedIndexChanged"></asp:DropDownList>
                        Test:
                          <asp:DropDownList ID="ddlTest" AutoPostBack="false" CssClass="field" 
                        Enabled="false" runat="server" 
                        onselectedindexchanged="ddlTest_SelectedIndexChanged">
                    </asp:DropDownList>
                      </ContentTemplate>
                      
                     <Triggers>
              <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment"  EventName="SelectedIndexChanged" />
                
                </Triggers>
               </asp:UpdatePanel>
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">--%>
              <%-- <ContentTemplate>--%>
                    
                 <%--     </ContentTemplate>--%>
               <%-- <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlSubDepartment" EventName="SelectedIndexChanged" />
              
                </Triggers>
               </asp:UpdatePanel>--%>
                   
                </td>
              
              
            
                
                </tr>
                
                
                <tr>
                
              
                <td>DOrder:<asp:TextBox ID="txtDorder" CssClass="field" runat="server"></asp:TextBox>
                 <asp:CheckBox ID="chkDefault" Text="Default" Checked="false" runat="server" />
                  <asp:CheckBox ID="chkActive" Text="Active" Checked="true" runat="server" />
                </td>
              
               
                </tr>
                </table>
              
                <table class="label" runat="server">
                <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCount"  Visible="false" runat="server"></asp:Label></td>
                
                </tr>
                <tr>
                <td colspan="7">
                <%-- <asp:GridView ID="gvTestMethod" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                             DataKeyNames="TestMethodID" CssClass="datagrid" HorizontalAlign="Center"  Height="9px" AllowSorting="True"
                             OnSorting="gvTestMethod_Sorting" OnRowCommand="gvTestMethod_RowCommand" >
                            <Columns>
                            
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
                            
                        </asp:GridView>--%>
                
                </td>
                </tr>
               </table>
               
    </div>
 
    </form>
</body>
</html>

