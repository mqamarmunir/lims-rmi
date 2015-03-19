<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPreferenceSettings.aspx.cs" Inherits="LIMS_WebForms_wfrmPreferenceSettings" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Test Price Update:    <% =Session["UNUIDFORMATTED"] %>
    </title>
    <meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            width: 10%;
        }
        .mandatoryfield
        {}
        .style2
        {
            width: 17%;
        }
        .style3
        {
            width: 21%;
        }
    </style>
</head>
<body>
    
				<TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>Preference Settings</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="8">
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False"></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="8"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD class="style1">&nbsp;</TD>
					<TD class="style1"></TD>
					<TD class="style3">Specimen Collection Time(Indoor)</TD>
					<TD class="style3">
                        <asp:textbox id="txtIndoor" runat="server" Enabled="true" 
                            Width="60%" CssClass="mandatoryfield"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>minutes</TD>
					<TD class="style1" align="right">&nbsp;</TD>
					<TD colspan="3">
                        &nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD class="style1">&nbsp;</TD>
					<TD colSpan="3">&nbsp;</TD>
					<TD></TD>
					<TD></TD>
				</TR>
                	<TR>
					<TD></TD>
					<TD></TD>
					<TD class="style3">Specimen Collection Time(Outdoor)</TD>
					<TD class="style3"><asp:textbox id="txtOutdoor" runat="server" Enabled="true" 
                            Width="60%" CssClass="mandatoryfield"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>minutes</TD>
					<TD class="style2" align="right"><asp:CheckBox ID="ICD" Text="ICD Code Enabling" runat="server" /></TD>
					<TD>
                            
                        &nbsp;</TD>
				</TR>
    </form>
</body>
</html>
