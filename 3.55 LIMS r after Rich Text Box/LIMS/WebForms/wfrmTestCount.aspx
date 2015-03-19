<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestCount.aspx.cs" Inherits="LIMS_WebForms_wfrmTestCount" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
		<title>LIMS: Location Wise/Section Wise Report    <% =Session["UNUIDFORMATTED"] %></title>
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
                    //alert(table);
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
    <table class="label" width="100%">
    <tr>
					<td align="right" colSpan="7"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
    <tr>
    <td colspan="3">
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    </td>
    <td align="right" colspan="3">

    <asp:ImageButton ID="imgSearch" runat="server" ImageUrl="~/images/Search_OT.gif" 
            onclick="imgSearch_Click" />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Closepack.gif" 
             />
    </td>
    <td></td>

    </tr>
    <tr>
    <td align="right">From Date</td>
    <td>
    <asp:TextBox ID="txtFromDate" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox>
        <asp:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtFromDate" Format = "dd/MM/yyyy"></asp:CalendarExtender>
    </td>
    <td align="right">To:</td>
    <td>
    <asp:TextBox ID="txtToDate" runat="server" CssClass="mandatoryField" Width="99%"></asp:TextBox>
        <asp:CalendarExtender ID="txtToDate_CalendarExtender" runat="server" 
            Enabled="True" TargetControlID="txtToDate" Format="dd/MM/yyyy"></asp:CalendarExtender>
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
        &nbsp;</td>
    
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

