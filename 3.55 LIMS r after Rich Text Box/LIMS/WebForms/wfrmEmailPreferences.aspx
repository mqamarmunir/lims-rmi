<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmEmailPreferences.aspx.cs" Inherits="LIMS_WebForms_wfrmEmailPreferences" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>
    LIMS: E-Mail Preference Settings:    <% =Session["UNUIDFORMATTED"] %>
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
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"-->
                   </TD>
				</TR>
                <tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>E-MAIL PREFERENCE SETTINGS</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="8">
                    <%--<asp:HiddenField ID="hdPreference"  runat="server" />--%>
                    <asp:HiddenField ID="hdEmailid" runat="server" />
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
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
                <table id="TblDetails" runat="server" width="98%" class="label" cellpadding="0" cellspacing="0">
                <tr>
                <td>SMTP(Server) Address:</td>
                <td><asp:TextBox ID="txtServerAddr" runat="server" CssClass="mandatoryField" Width="90%"></asp:TextBox></td>
                <td>Port Number</td>
                <td><asp:TextBox ID="txtPort" runat="server" CssClass="field" Width="90%"></asp:TextBox></td>
                <td></td>
                <td></td>
                </tr>
                    <tr>
                <td>
                    <br />
                    From(Email Address)</td>
                <td>
                    <br />
                    <asp:TextBox ID="txtFromEmail" runat="server" CssClass="mandatoryField" 
                        Width="90%"></asp:TextBox></td>
                <td>
                    <br />
                        </td>
                <td>
                    <br />
                        </td>
                <td></td>
                <td></td>
                </tr>
                 <tr>
                <td>
                    <br />
                    User Name:</td>
                <td>
                    <br />
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="mandatoryField" 
                        Width="90%"></asp:TextBox></td>
                <td>
                    <br />
                    Password:</td>
                <td>
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="SingleLine" CssClass="mandatoryField" 
                        Width="90%"></asp:TextBox></td>
                <td></td>
                <td></td>
                </tr>
                 <tr>
                <td>Message Footer(Signatures):</td>
                <td colspan="3">
                    <br />
                    <CKEditor:CKEditorControl ID="txtMsgFooter" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="100%" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="75px" Enabled="true" ToolbarBasic="Source|-|Bold|Italic" MaxLength="550"></CKEditor:CKEditorControl></td>
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
                </tr>
                 <tr>
                <td width="15%"></td>
                <td width="30%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                <td width="10%"></td>
                </tr>
                </table>
    </div>
    </form>
</body>
</html>
