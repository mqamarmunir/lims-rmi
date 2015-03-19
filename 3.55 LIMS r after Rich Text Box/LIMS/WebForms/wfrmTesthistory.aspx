<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTesthistory.aspx.cs" Inherits="wfrmTesthistory" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>
    LIMS: Test history:    <% =Session["UNUIDFORMATTED"] %>
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
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>TEST HISTORY</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="8">
                        <%--<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>--%>
						<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					</TD>
				</TR>
                <TR>
					<TD colSpan="8"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
                </TABLE>
                <br />
                <table id="tblgrid" runat="server" class="label" width="100%">
                <tr>
                <td></td>
                <td colspan="3">
                   <asp:Panel ID="Panelchks" runat="server"></asp:Panel>
                    </td>
                <td><asp:Button ID="btngengraph" runat="server" BackColor="Aqua"
                   Text="Generate Graph" onclick="btngengraph_Click"  CssClass="buttonStyle" /></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td colspan="6">
                           

                    <asp:UpdatePanel ID="updtegraph" runat="server">
                    <ContentTemplate>
                    
                    
                  <asp:Chart ID="Chart1" Width="700" Visible="false" runat="server">
                      
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart> 

                    </ContentTemplate>
                    <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btngengraph" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                    <asp:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" TargetControlID="updtegraph" runat="server">
                    <Animations>
                    
                    </Animations>
                    </asp:UpdatePanelAnimationExtender>
                    
                </td>
                
                </tr>
                
                 <tr>
                <td></td>
                <td colspan="6">
                <asp:LinkButton ID="lnkshow" Text="Show Data" OnClick="lnkshow_Click" runat="server"></asp:LinkButton>
                <asp:Panel ID="pnlgrid" runat="server">
                
                <asp:GridView ID="gvTests" Width="75%" DataKeyNames="DserialNo,labid" CssClass="datagrid"
                 OnRowDataBound="gvTests_RowDataBound"  runat="server" AutoGenerateColumns="false">
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:BoundField DataField="TestID" HeaderText="Test ID" />
                <asp:BoundField DataField="Test" HeaderText="Test" />
                <asp:BoundField DataField="Bookedon" HeaderText="Booked On" />
                 <asp:TemplateField>
                        <ItemTemplate>
                        <tr>
                        <td></td>
                        <td colspan="2">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
													<tr>
                                                    
														<td align="right">
															<div id="divOrders" style="display:inline" runat="server">
                                                            <asp:GridView ID="gvAttributes" runat="server" width="100%" 
                                                            AutoGenerateColumns="False" OnRowDataBound="gvAttributes_RowDataBound">
                                                            <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <Columns>
                                                            <asp:BoundField DataField="Attribute" HeaderText="Attribute">
                                                            <ItemStyle Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Result" HeaderText="Result" />
                                                            <asp:BoundField DataField="AttributeType" HeaderText="Type" />
                                                            </Columns>
                                                             </asp:GridView>
                </div>
                </td>
                </table>
                </td>
                </tr>
                 </ItemTemplate>
                </asp:TemplateField>
                </Columns>
                </asp:GridView>
                </asp:Panel>

                <asp:CollapsiblePanelExtender ID="cpanelextender1" runat="server" TargetControlID="pnlgrid" Collapsed="true" ExpandControlID="lnkshow" CollapseControlID="lnkshow" ExpandDirection="Vertical"></asp:CollapsiblePanelExtender>
                </td>
             
                </tr>
                  <tr>
                <td></td>
                <td colspan="2">
                    &nbsp;</td>
           <td>&nbsp;</td>
           <td></td>
           <td></td>
           <td></td>
                </tr>

                  <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td colspan="6">
                    &nbsp;</td>
            
                </tr>
                <tr>
                <td></td>
                <td colspan="6">
                   

                    &nbsp;</td>
            
                </tr>

                 
                 <tr>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>
                </table>
    </div>
    </form>
</body>
</html>
