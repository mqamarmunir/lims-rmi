<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestPriceUpdate.aspx.cs" Inherits="LIMS_WebForms_wfrmTestPriceUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    </style>
</head>
<body>

    <form id="form1" runat="server">
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>TEST PRICE UPDATE<asp:ScriptManager 
                            ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="8">
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnrefresh" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefresh_Click"></asp:ImageButton>
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
					
					<TD class="style1">Section</TD>
					<TD colSpan="2">
                        <asp:dropdownlist id="ddlSection" runat="server" Width="100%" 
                            AutoPostBack="True" tabIndex="1" 
                            onselectedindexchanged="ddlSection_SelectedIndexChanged" ></asp:dropdownlist></TD>
					<TD class="style1" align="right">Test Group</TD>
					<TD colspan="3">
                        <asp:dropdownlist id="ddlTestGroup" runat="server" Enabled="False" 
                             AutoPostBack="True"
							tabIndex="2" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged" ></asp:dropdownlist></TD>
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
					
					<TD class="style1">%age Increase</TD>
					<TD colspan="2">Normal<asp:textbox id="txtTestAttribute" runat="server" Enabled="true" 
                            Width="20%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>%&nbsp; Urgent
                            <asp:textbox id="txtUrgPer" runat="server" Enabled="true" 
                            Width="20%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>
                            %</TD>
					<TD class="style1" align="right">Effective Date</TD>
					<TD><asp:textbox id="txteffective" runat="server" Enabled="true" 
                            Width="25%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Effective Date"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txteffective" Text="*"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnProcess" Text="Process" Font-Bold="true" CssClass="buttonStyle" ForeColor="Blue"  
                                    BackColor="Highlight" runat="server" onclick="btnProcess_Click" />
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txteffective">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txteffective" Mask="99/99/9999"
                            MaskType="Date">

                        </cc1:MaskedEditExtender>
                            </TD>
                            <td>                        
                                &nbsp;</td>
				</TR>

                <tr>
                  

                        
                        <td colspan="3" > 

                            <asp:Label ID="RFound" runat="server" Text="Label" Visible="False" 
                                ForeColor="#66FF66"></asp:Label>
                            </td>
                </tr>
                <tr>
                
                    <td colspan="7">
                        <asp:GridView ID="gvTests" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datagrid" HorizontalAlign="left"  Height="7px" AllowSorting="True"
                            OnPageIndexChanging="gvTests_PageIndexChanging" OnSorting="gvTests_Sorting">
                            <Columns>
                                <%--<asp:BoundField HeaderText="Marital Status" DataField="marital_status">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>--%>
                                <%--<asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>--%>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Sub-Department" DataField="SECTIONNAME" SortExpression="SECTIONNAME">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TEST" HeaderText="Test Name" SortExpression="TEST">
                                    <HeaderStyle HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Acronym" DataField="ACRONYM" SortExpression="ACRONYM">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Normal Price" DataField="CHARGES" SortExpression="CHARGES">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="charges_new" HeaderText="New Price" SortExpression="charges_new" >
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    </asp:BoundField>
                                <asp:BoundField HeaderText="Urgent Price" DataField="ChargesURGENT" SortExpression="ChargesURGENT">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UrgentCharges_New" HeaderText="New Price (Urgent)" SortExpression="UrgentCharges_New" />
                                <asp:BoundField DataField="effective_date" HeaderText="Effective Date" SortExpression="effective_date" />
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
    </form>
</body>
</html>
