<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuplicatebatchReport.aspx.cs" Inherits="LIMS_WebForms_DuplicatebatchReport" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD runat="server">
		<title>LIMS: INVESTIGATION BOOKING:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
<body>

    <form id="form1" runat="server">
        <div>
            <table width="100%" class="label">
                <TR>
					<TD colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                    
                                        
                   <TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>BATCH REPORT REPRINT QUEUE</STRONG></font>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </td>
                    
                </tr>
                
                <tr>
                    <td colspan="8">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                   
                    
                </tr>


                <tr>
                <td colspan="8">
                    <fieldset id="fsetsearch" runat="server">
                    <legend>Saved Batches </legend>
                    
                    <table id="tblSearch" width="99%" class="label">
                    <tr>
                    <td colspan="8" align="right">                        <asp:ImageButton
                                    ID="btnSearch" runat="server" AccessKey="x" ImageUrl="~/images/Search_OT.gif"
                                    OnClick="btnSearch_Click" TabIndex="26" 
                            ToolTip="Close Screen  (Alt+X)" />
                    </td>
                    </tr>
                        <tr>
                            <td>From:
                                </td>
                            <td>
                            
                                    <asp:TextBox ID="txtDF" Width="85%" CssClass="field" runat="server"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDF">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtDF" Mask="99/99/9999"
                            MaskType="Date"></cc1:MaskedEditExtender>    
                            
                                </td>
                            <td>To:</td>
                            <td>
                            
                                    <asp:TextBox ID="txtDT" Width="59%" CssClass="field"  runat="server"></asp:TextBox>
                           <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDT">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtDT" Mask="99/99/9999"
                            MaskType="Date"></cc1:MaskedEditExtender>  
                                </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <asp:GridView ID="gvbatches" runat="server" CssClass="datagrid"
                                  AutogenerateColumns="false" Width="99%">
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Batchno" SortExpression="batchno">
                                    <ItemTemplate>
                                    <asp:LinkButton ID="lnkbatchno" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"batchno") %>' OnClick="lnkbatchno_Click"></asp:LinkButton>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Dispatched On" DataField="EnteredOn" />
                                    
                                </Columns>
                                </asp:GridView>
                            </td>
                            
                        </tr>

                       <tr>
                            <td width="10%"></td>
                            <td width="15%"></td>
                            <td width="10%"></td>
                            <td width="20%"></td>
                            <td width="10%"></td>
                            <td width="15%"></td>
                            <td width="10%"></td>
                            <td width="10%"></td>
                        </tr>
                    
                    </table>
                    </fieldset>
                    </td>
                    </tr>
                    </table>
    </div>
    </form>
</body>
</html>
