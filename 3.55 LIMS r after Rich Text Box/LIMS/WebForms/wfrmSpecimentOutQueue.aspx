<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmSpecimentOutQueue.aspx.cs" Inherits="LIMS_WebForms_wfrmSpecimentOutQueue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>LIMS: Specimen Out Queue:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">


        <script language="javascript">

            function chkallchanged(cb) {
                if (cb.checked == true) {
                    //document.getElementById('gvExtOrganizations_ctl02_gvtests_ctl02_gvChkSelect').checked = true;
                    //alert(cb.id.substring(0, 32));
                    var table = document.getElementById(cb.id.substring(0, 32));
                    //alert(table.rows.length);
                    for (var i = 1; i < table.rows.length; i++) {
                        //alert(cb.id.substring(0, 32) + '_ctl0' + (i + 1).toString() + '_gvChkSelect');
                        //alert(padDigits(i+1,2));
                        document.getElementById(cb.id.substring(0, 32) + '_ctl' + padDigits(i + 1, 2) + '_gvChkSelect').checked = true;
                       // document.getElementById(cb.id.substring(0, 32) + 'ctl' + lPad((i - 1).toString(),2,'0')+'_gvChkSelect').checked = true;
                    }


                }
                else {
                    var table = document.getElementById(cb.id.substring(0, 32));
                    for (var i = 1; i < table.rows.length; i++) {
                        //alert(cb.id.substring(0, 32) + '_ctl0' + (i + 1).toString() + '_gvChkSelect');
                        //alert(padDigits(i+1,2));
                        document.getElementById(cb.id.substring(0, 32) + '_ctl' + padDigits(i + 1, 2) + '_gvChkSelect').checked = false;
                        // document.getElementById(cb.id.substring(0, 32) + 'ctl' + lPad((i - 1).toString(),2,'0')+'_gvChkSelect').checked = true;
                    }

                }
            }
            function padDigits(number, digits) {
                return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
            }
            </script>
	</head>
<body>
    <form id="form1" runat="server">
    


    <div>
    <asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
    <table class="label" width="100%">
    <tr>
					<td align="right" colSpan="7"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
    <tr>
    <td colspan="3">
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    </td>
    <td align="right" colspan="3">

    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" 
            onclick="imgSearch_Click" />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Closepack.gif" 
            onclick="ImageButton1_Click" />
    </td>
    <td></td>

    </tr>
    <tr>
    <td align="right">From Date</td>
    <td>
    <asp:TextBox ID="txtFromDate" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox>
    <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtFromDate" Mask="99/99/9999"
                            MaskType="Date"></asp:MaskedEditExtender>
    </td>
    <td align="right">To:</td>
    <td>
    <asp:TextBox ID="txtToDate" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox>
     <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtToDate">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtToDate" Mask="99/99/9999"
                            MaskType="Date"></asp:MaskedEditExtender>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
    <td colspan="7"></td>
    </tr>
    <tr>
    <td colspan="7">
    <asp:GridView ID="gvExtOrganizations" Width="99%" runat="server" CssClass="datagrid" AutoGenerateColumns="false" DataKeyNames="orgid" OnRowDataBound="gvExtOrganizations_RowDataBound">
    <RowStyle CssClass="gridAlternate" />
    <AlternatingRowStyle CssClass="gridAlternate" />
    <HeaderStyle CssClass="gridheader" />
    <Columns>
    <asp:BoundField DataField="Organization" HeaderStyle-HorizontalAlign="Left" 
            HeaderText="Organization" >
<HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:BoundField>
    <asp:TemplateField>
<ItemTemplate>
<tr>
<td colspan="7">
<table id="tblbranches" class="listing" width="99%">
<tr>
<td align="left">
        <div id="dvabc" style="display:inline">
        
             <asp:GridView ID="gvtests" Width="100%" runat="server" AutoGenerateColumns="False" 
                    CssClass="datagrid" DataKeyNames="TestID,prid,DSerialno,MSerialno">
            <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" /> 
            <RowStyle CssClass="gridItem" />
            <AlternatingRowStyle CssClass="gridAlternate" />
            <Columns>
            <asp:TemplateField HeaderText="S#">
            <HeaderStyle HorizontalAlign="Center" Width="5%" />
            <ItemTemplate>
            <%#Container.DataItemIndex+1 %>
            </ItemTemplate>

                <ItemStyle HorizontalAlign="Center" />

            </asp:TemplateField>

            <asp:BoundField HeaderText="Lab ID" DataField="labID" />
            <asp:BoundField HeaderText="Patient Name" DataField="PName"/>
            <asp:BoundField HeaderText="Test" DataField="Test_Name"/>
            <asp:BoundField HeaderText="Booked On" DataField="EnteredOn"/>
            <asp:BoundField HeaderText="Delivery Date" DataField="DeliveryDate"/>
            <asp:BoundField HeaderText="Origin" DataField="Booking_Branch" />
            <asp:CommandField ShowSelectButton="True" SelectText="Send" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:CommandField>
                <asp:TemplateField>
                <HeaderTemplate>
                <asp:CheckBox ID="chkHeader" ToolTip="Select/DeSelect All" onclick="javascript:chkallchanged(this);" runat="server" />
                </HeaderTemplate>
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                <asp:CheckBox ID="gvChkSelect" runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            </asp:GridView>
            <table id="tblCourier" runat="server" class="label">
            <tr>
            <td width="10%"></td>
            <td width="30%"></td>
            <td style="width: 4%"></td>
            <td width="30%"></td>
            <td width="20%"></td>
            </tr>
            <tr>
            <td align="center"></td>
            <td></td>
            <td align="center"></td>
            <td></td>
            <td></td>
           
            </tr>
            <tr>
            <td></td>
            <td></td>
            <td style="width: 4%"></td>
            <td colspan="2" align="right"><asp:Button ID="btnSend" Text="Send" runat="server" CssClass="btn" OnClick="btnSend_Click" /></td>
            <td></td>
            </tr>
            </table>
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
    <td></td>
    </tr>
    <tr>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="15%"></td>
    <td width="15%"></td>
    <td width="10%"></td>
    </tr>
    </table>
    </div>
    </form>
</body>
</html>
