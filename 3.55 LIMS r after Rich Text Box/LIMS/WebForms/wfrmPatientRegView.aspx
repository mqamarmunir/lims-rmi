<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPatientRegView.aspx.cs"
    Inherits="LIMS_WebForms_wfrmPatientRegView" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PatientRegistrationView</title>
    <link href="../../LIMS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="label" id="table1" style="z-index: 101; left: 1px; position: absolute;
                top: 1px" cellspacing="1" cellpadding="1" width="100%" border="0">
                <tr>
                    <td colspan="6">
                        <!-- #include file="Limsheader2.htm"-->
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="7">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 30%">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 40%" align="center">
                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/images/Search_OT.gif"
                            OnClick="btnSearch_Click" /><asp:ImageButton ID="btnRefresh" runat="server" ImageUrl="~/images/Refresh.gif" OnClick="btnRefresh_Click" />
                            <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/images/ClosePack.gif"
                                    OnClick="btnClose_Click" />
                    </td>
                    <td style="width: 5%">
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">
                    </td>
                    <td style="width: 10%">
                        From Date:</td>
                    <td style="width: 30%">
                        <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFrom">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtFrom" Mask="99/99/9999"
                            MaskType="Date">
                        </cc1:MaskedEditExtender>
                    </td>
                    <td style="width: 10%">
                        To Date:</td>
                    <td style="width: 40%">
                        <asp:TextBox ID="txtTo" runat="server">
                        </asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTo">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtTo" Mask="99/99/9999"
                            MaskType="Date">
                        </cc1:MaskedEditExtender>
                        &nbsp;
                    </td>
                    <td style="width: 5%">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td colspan="3">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 30%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 40%">
                        <asp:Label ID="lblVisitno" runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lblPRNO" runat="server" Visible="False"></asp:Label></td>
                    <td style="width: 5%">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="gvVisitReg" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datagrid" HorizontalAlign="Center" Width="75%" AllowPaging="true"  AllowSorting="True"
                            OnPageIndexChanging="gvVisitReg_PageIndexChanging" OnRowCommand="gvPatientVisitReg_RowCommand"
                            OnSorting="gvVisitReg_Sorting">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="PR No" DataField="prno">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="visitno" HeaderText="Visit No">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Patient" DataField="name">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Age" DataField="age">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Gender" DataField="Gender">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Marital Status" DataField="marital_status">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="screenid" align="right" colspan="6">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
