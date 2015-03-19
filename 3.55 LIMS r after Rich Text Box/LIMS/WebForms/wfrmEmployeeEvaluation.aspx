<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmEmployeeEvaluation.aspx.cs" Inherits="LIMS_WebForms_wfrmEmployeeEvaluation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>
    LIMS: Evaluation:    <% =Session["UNUIDFORMATTED"] %>
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
 <form id="form2" runat="server">
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>EMPLOYEE EVALUATION</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="8">
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					</TD>
                    </tr>
                    <tr>
                    <td colspan="7">
                    <asp:Label ID="lblErrMsg" ForeColor="Red" runat="server"></asp:Label>
                    
                    </td>
				</TR>
    </TABLE>
    <br />
    <table id="tblbody" runat="server" class="label">
    <tr>
        <td colspan="7">
        
            <asp:RadioButton ID="rbExcellent" Text="Excellent" GroupName="gpEval" runat="server" />
            <asp:RadioButton ID="rbVGood" Text="Very Good" GroupName="gpEval" runat="server" />
            <asp:RadioButton ID="rbGood" Text="Good" GroupName="gpEval" runat="server" />
            <asp:RadioButton ID="rbPoor" Text="Poor" GroupName="gpEval" runat="server" />
            <asp:RadioButton ID="rbVPoor" Text="Very Poor" GroupName="gpEval" runat="server" />
        
        </td>

    </tr>
      <tr>
    <td align="right">Comments:</td>
    <td colspan="6"><asp:TextBox ID="txtQualitative" runat="server" CssClass="field" TextMode="MultiLine" Width="30%"></asp:TextBox></td>

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
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    </table> 
</form>
</body>
</html>
