<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmAllTestsinonelab.aspx.cs" Inherits="LIMS_WebForms_wfrmAllTestsinonelab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIMS: Test Result Entry (General Format):    <% =Session["UNUIDFORMATTED"] %></title>
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
                        
                        <font size="4"><STRONG>PATIENT TEST HISTORY</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="8">
                        <%--<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>--%>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					</TD>
				</TR>
                
                </TABLE>
                <br />
                <table id="tblTests" runat="server" class="label" >
                <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td colspan="5">
                   <asp:GridView ID="gvTests" Width="100%" runat="server" DataKeyNames="DSerialNo" HorizontalAlign="left"
                    OnRowDataBound="gvTests_RowDatabound" AutoGenerateColumns="false">
                        <AlternatingRowStyle CssClass="gridAlternate" />
                        <RowStyle CssClass="gridItem" />
                        <HeaderStyle CssClass="gridheader" />
                        <Columns>
                        <asp:BoundField DataField="TestID" HeaderText="Test IDs">
                        <ItemStyle Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Test" HeaderText="Test Name" />
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
                                                            AutoGenerateColumns="False">
                                                            <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <Columns>
                                                            <asp:BoundField DataField="Attribute" HeaderText="Attribute">
                                                            <ItemStyle Width="20%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Result" HeaderText="Result" />
                                                            </Columns>
                                                             </asp:GridView>
                                                             <br /> 
                                                            
                                                             <asp:GridView ID="gvComments" runat="server" width="100%" AutoGenerateColumns="false">
                                                             <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <Columns>
                                                            <asp:BoundField DataField="Comments" HeaderText="Comments" >
                                                            <ItemStyle Width="80%" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Name" HeaderText="Entered By">
                                                            <ItemStyle Width="20%" />
                                                            </asp:BoundField>
                                                            </Columns>
                                                             </asp:GridView> 
                                                          <br />
                                                             <asp:GridView ID="gvDiagnosis" runat="server" Width="100%" AutoGenerateColumns="false">
                                                            <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <Columns>
                                                            <asp:BoundField DataField="Disease_Name" HeaderText="Diseases" />
                                                            </Columns>
                                                             
                                                             </asp:GridView>
                                                             <br />
                                                             </div>
                                                            </td>
                                                            </tr>
                                                            </table>
                        
                        </td>
                        </tr>
                        </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
    
                    </asp:GridView>
    </td>
                </tr>
                <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td width="10%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                </tr>
                </table>
 
    </div>
    </form>
</body>
</html>
