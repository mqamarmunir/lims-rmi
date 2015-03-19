<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmConsultantreport.aspx.cs" Inherits="LIMS_WebForms_wfrmConsultantreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD runat="server">
    
		<title>LIMS: Consultants Reports : <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	   
	    <style type="text/css">
            .style1
            {
                height: 30px;
            }
            .style2
            {
                height: 30px;
                width: 12%;
            }
            .style3
            {
                width: 12%;
            }
        </style>
    
	    </HEAD>
<body>
<script type="text/javascript" charset="utf-8">

    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
</script>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager id="tm1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION:relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
                <tr>
					<td colSpan="7"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
				<tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>CONSULTANTS REPORT</STRONG></font></td>
				</tr>
                </TABLE>
                <br />
                <div id="divpersons" runat="server">
              
                <fieldset>
                <legend>Search Criteria</legend>
                
                <table id="tblsearch" class="label" runat="server" width="100%" border="0">
                <tr>
                <td colspan="7" align="right">
                <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="~/images/Refresh.gif" 
                        onclick="imgRefresh_Click" ValidationGroup="b" />
                <asp:ImageButton ID="imgClode" runat="server" ImageUrl="~/images/ClosePack.gif" 
                        onclick="imgClode_Click" CausesValidation="False" />
                </td>
                </tr>
                <tr>
                <td class="style1"> </td>
                <td class="style2">From Date:</td>
                <td class="style1">
                    <asp:TextBox ID="txtFromdate" runat="server" Width="150px" ValidationGroup="b"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtFromdate" ErrorMessage="*" ValidationGroup="b"></asp:RequiredFieldValidator>
                    <asp:CalendarExtender runat="server" ID="cext1" TargetControlID="txtFromdate" Format="dd/MM/yyyy"></asp:CalendarExtender>

                    </td>
                <td class="style1">To Date: </td>
                <td class="style1">
                    <asp:TextBox ID="txtTodate" runat="server" Width="150px" ValidationGroup="b"></asp:TextBox>
                     <asp:CalendarExtender runat="server" ID="Cext2" TargetControlID="txtTodate" Format="dd/MM/yyyy"></asp:CalendarExtender>
                                         <asp:RequiredFieldValidator
                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTodate" 
                        ErrorMessage="*" ValidationGroup="b"></asp:RequiredFieldValidator>
                    </td>
                <td class="style1"> </td>
                <td class="style1"> </td>
                </tr>
                 <tr>
                <td> </td>
                <td class="style3"> Consultant:</td>
                <td> <%--<asp:DropDownList ID="ddlDepartment" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>--%>  
                    <asp:DropDownList ID="ddlconsultant" runat="server" Width="150px">
                    </asp:DropDownList>
                     </td>
                <td> &nbsp;</td>
                <td> <%--<asp:DropDownList ID="ddlSubDepartment" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList>--%>  </td>
                <td> </td>
                <td> </td>
                </tr>
                                <tr>
                <td class="style1"> </td>
                <td class="style2">Report Type:</td>
                <td class="style1">
                    <asp:CalendarExtender runat="server" ID="CalendarExtender1" TargetControlID="txtFromdate" Format="dd/MM/yyyy"></asp:CalendarExtender>

                    <asp:RadioButton ID="rbtnsummary" runat="server" AutoPostBack="True" 
                        oncheckedchanged="rbtnsummary_CheckedChanged" Text="Summary" />

                    </td>
                <td class="style1">
                    <asp:RadioButton ID="rbtndetail" runat="server" AutoPostBack="True" 
                        oncheckedchanged="rbtndetail_CheckedChanged" Text="Detail" />
                                    </td>
                <td class="style1">
                     <asp:CalendarExtender runat="server" ID="CalendarExtender2" TargetControlID="txtTodate" Format="dd/MM/yyyy"></asp:CalendarExtender>

                    </td>
                <td class="style1"> </td>
                <td class="style1"> </td>
                </tr>

                    <tr>
                <td colspan="7">
                    &nbsp;</td>
             
             
              
                </tr>
                <tr>
                <td width="10%"> </td>
                <td class="style3"> </td>
                <td width="20%"> </td>
                <td width="15%"> </td>
                <td width="20%"> </td>
                <td width="10%"> </td>
                <td width="10%"> </td>
                </tr>

                </table>
                </fieldset>
                  </div>
                <br />
               

                

    </div>
    </form>
</body>
</html>
