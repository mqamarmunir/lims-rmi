<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmSOPresultge.aspx.cs" Inherits="LIMS_WebForms_wfrmSOPresultge" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ Import Namespace="System.ComponentModel"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>LIMS: Test Result SOP:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link href="LIMS.css" rel="stylesheet" />
	</head>
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
    <div>
    <table class="label" id="Table1" cellspacing="1" cellpadding="1" width="100%" border="0">
				<tr>
					<td colspan="6"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
				<tr>
					<td align="center" colspan="7"><font size="4"><strong>TEST RESULT SOPs</strong></font></td>
				</tr>
				<tr>
					<td colspan="6"><asp:label id="LblMessage" runat="server" Width="100%" ForeColor="Red"></asp:label></td>
				</tr>
                </table>
                <table class="label" id="tblSops" runat="server" cellspacing="1" cellpadding="1" width="100%" border="0">

				<tr>
					<td width="10%"></td>
					<td width="10%">Related To:</td>
					<td width="30%"><asp:DropDownList ID="ddlProcess" runat="server" Width="98%" 
                            CssClass="mandatorySelect" AutoPostBack="True" 
                            onselectedindexchanged="ddlProcess_SelectedIndexChanged" Enabled="false"></asp:DropDownList></td>
					<td align="right" width="10%">Test:&nbsp;&nbsp;</td>
					<td width="30%"><asp:DropDownList ID="ddlTest" runat="server" 
                            CssClass="mandatorySelect" Width="98%" AutoPostBack="True" 
                            onselectedindexchanged="ddlTest_SelectedIndexChanged" Enabled="false"></asp:DropDownList></td>
					<td width="10%"></td>


				</tr>
                <tr>
                <td></td>
                <td>Filter SOPs<br /> (by title)</td>
                <td><asp:TextBox ID="txtFilter" runat="server" Width="50%" onkeyup="javascript:filter(this,'gvSOPs',1);" CssClass="field"></asp:TextBox> </td>
                </tr>
                <tr>
                <td></td>
                <td colspan="6"><asp:Label ID="lblCount" runat="server" ForeColor="Green"></asp:Label></td>
                </tr>
                <tr>
                <td></td>
                <td colspan="6">
                <asp:GridView ID="gvSOPs" AutoGenerateColumns="False" Width="80%" runat="server" DataKeyNames="SOPTypeID,TestID,ProcessID"  OnSelectedIndexChanging="gvSOP_selectedIndexChanging">
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                  <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
             
                </asp:TemplateField>
                <asp:BoundField HeaderText="SOP Title" DataField="Name" >
                </asp:BoundField>
                <asp:BoundField HeaderText="Applicable Date" DataField="APPLICABLEDATE" >
                <ItemStyle Width="20%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Process" DataField="ProcessName">
                <ItemStyle Width="15%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Test" DataField="TestName">
                <ItemStyle Width="30%" />
                </asp:BoundField>
              
                    <asp:CommandField ShowSelectButton="True" />
              
                </Columns>
                </asp:GridView>
                </td>
                </tr>
                <tr>
                <td colspan="6"></td>
                </tr>
             
                </table>

                <div id="divdetail" visible="false" runat="server">
                <fieldset>
                <legend>SOP Detail</legend>
                <table id="tblDetail" runat="server" class="label">
                <tr>
                <td colspan="6" align="right">
                <asp:ImageButton id="ibtnSave" Enabled="true" runat="server" ImageUrl="~/images/SavePack_2.gif" Visible="false" OnClick="ibtnSave_Click"></asp:ImageButton>
				
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
                 </td>
                
                </tr>
                 <tr>
                <td align="right">Title:</td>
                <td><asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label> </td>
                <td align="right">Applicable On:</td>
                <td><asp:Label ID="lblApplicableon" runat="server" Font-Bold="true" Font-Size="Small"></asp:Label></td>
                <td></td>
                <td></td>
                </tr>
                 <tr>
                <td align="right">Description:</td>
                <td colspan="3"><CKEditor:CKEditorControl ID="txtDescription" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="100%" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="true" ToolbarBasic="Source|-|Bold|Italic" MaxLength="2000"></CKEditor:CKEditorControl></td>
                <td></td>
                <td></td>
              
                </tr>
                 <tr>
                <td width="10%">
                </td>
                <td width="10%">Attachments:<br /><asp:LinkButton ID="lnkPath1" 
                        runat="server" onclick="lnkPath1_Click" Visible="false"></asp:LinkButton><br />
                <asp:LinkButton ID="lnkPath2" runat="server" onclick="lnkPath2_Click" Visible="false"></asp:LinkButton><br />
                <asp:LinkButton ID="lnkPath3" runat="server" onclick="lnkPath3_Click" Visible="false"></asp:LinkButton></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
               
                </tr>
                </table>
                </fieldset>
                </div>
    
    </div>
    </form>
</body>
</html>
