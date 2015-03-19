<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPeerReview.aspx.cs" Inherits="LIMS_WebForms_wfrmPeerReview" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>LIMS: Peer Reviews:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>PEER REVIEWS<asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
                        </STRONG></font>
                    &nbsp;
                    
                    </TD>
				</TR>
                <tr>
                <td colspan="7" align="right">
                    &nbsp;</td>
                </tr>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red" Font-Bold="true"></asp:label></TD>
				</TR>
                </table>

        <table id="tbltestinfo" runat="server" class="label">
                <tr>
                <td align="right"></td>
                <td><asp:DropDownList ID="ddlSubDepartment" runat="server" 
                        CssClass="mandatorySelect" Width="100%" Visible="false" AutoPostBack="True" 
                        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                  
                <tr>
                <td colspan="5">
                <asp:GridView ID="gvReviews" runat="server" CssClass="datagrid" Width="99%"
                 AutoGenerateColumns="false" DataKeyNames="DSerialNo,ReviewID" OnRowCommand="gvReviews_RowCommand" OnRowDataBound="gvReviews_RowDataBound">
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />

                <Columns>
                <asp:TemplateField HeaderText="S#">
                <ItemStyle Width="5%" HorizontalAlign="Center" />
                <HeaderStyle  Width="5%" HorizontalAlign="Center" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>:
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="LabID" DataField="labID" />
                <asp:BoundField HeaderText="Test" DataField="Test" />
                <asp:BoundField HeaderText="Referred By" DataField="ReferredBy" />
                <asp:CommandField ShowSelectButton="true" SelectText="Details" Visible="false" />
                <asp:TemplateField>
                <ItemTemplate>
                <asp:LinkButton ID="lnkDetails" Text="Details" OnCommand="gvlnkDetails_Click" CommandArgument="<%#Container.DataItemIndex %>" runat="server" >
                </asp:LinkButton>
                    <asp:ModalPopupExtender ID="lnkDetails_ModalPopupExtender" runat="server" 
                        DynamicServicePath="" Enabled="True" PopupControlID="divResult" TargetControlID="lnkDetails">
                    </asp:ModalPopupExtender>
                    <div id="divResult" style="width:600px" runat="server" visible="true">
                        <table class="label" style="background-color: Aqua" width="99%">
                        <tr>
                        <td colspan="6" align="right">
                            <asp:Label ID="lblNumber" runat="server"></asp:Label>
                 <asp:ImageButton id="ibtnSave" runat="server" CommandArgument="<%#Container.DataItemIndex %>" ImageUrl="~/images/SavePack_2.gif" 
                                OnCommand="ibtnSave_Click"></asp:ImageButton>
                                						
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False" style="height: 26px"></asp:ImageButton>
						
						
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="false" 
                            onclick="ibtnClose_Click" style="height: 26px"></asp:ImageButton>
                
						
                        </td>
                        </tr>
                        <tr>
                        <td colspan="6">
                        <asp:Panel ID="pnlDetails" runat="server" Height="400px" ScrollBars="Auto">
                            <asp:GridView ID="gvResult" CssClass="datagrid" Width="99%"  AutoGenerateColumns="false" runat="server" >
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                <asp:BoundField ItemStyle-Width="40%" HeaderText="Attribute" DataField="Attribute" />
                                <asp:BoundField HeaderText="Result" ItemStyle-Width="20%"  DataField="Result" />
                                <asp:BoundField  ItemStyle-Width="20%" HeaderText="Ranges" DataField="Range" />
                                <asp:BoundField  ItemStyle-Width="20%" HeaderText="Unit" DataField="Unit" />


                                </Columns>

                            </asp:GridView>   
                            </asp:Panel>
                        </td>
                       
                        </tr>
                        <tr>
                        <td align="right">Comment:</td>
                        <td colspan="5">
                            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="99%" CssClass="field">
                            </asp:TextBox>
                        </td>
                        
                        
                        </tr>
                        <tr>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="30%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        </tr>
                        </table>
                     </div>
                </ItemTemplate>
                </asp:TemplateField>
                </Columns>

                </asp:GridView>
                   
                </td>
                <td></td>
                
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
             <td colspan="6">
                     

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
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                </tr>
                
                </table>
    </div>
    </form>
</body>
</html>
