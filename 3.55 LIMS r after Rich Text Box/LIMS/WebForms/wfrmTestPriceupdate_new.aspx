<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestPriceupdate_new.aspx.cs" Inherits="LIMS_WebForms_wfrmTestPriceupdate_new" %>

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
            width: 13%;
            
        }
        .mandatoryfield
        {}
        .style4
        {
            width: 17%;
        }
        .style5
        {
            width: 10%;
        }
        .style6
        {
            width: 18%;
        }
    </style>
</head>
<body>
<script type="text/javascript">
    function isNumeric(x,_id) {
        var value = x.value; // toString();
        if (isNaN(parseFloat(value))) {
            alert("only numeric characters allowed");
            document.getElementById(_id).value = "";
            return false;
        }
         return true;
    }
</script>
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
                        <asp:ImageButton id="ibtnSave" Enabled="false" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnrefresh" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefresh_Click"></asp:ImageButton>
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
                <tr>
                <td>
                <asp:RadioButton ID="rbtnTest" Text="Test" Font-Bold="true" Checked="true" GroupName="Type" AutoPostBack="true" 
                        runat="server" oncheckedchanged="rbtnTest_CheckedChanged" />
                        
                <asp:RadioButton ID="rbtnGroup" Text="Group" Font-Bold="true" GroupName="Type" AutoPostBack="true" 
                        runat="server"  oncheckedchanged="rbtnGroup_CheckedChanged" />
                </td>
                </tr>
				<TR>
					<%--<TD class="style1">&nbsp;</TD>--%>
					
					<TD class="style1" align="right">Sub-Department</TD>
					<TD class="style4">
                        <asp:dropdownlist id="ddlSection" runat="server" Width="98%" 
                            AutoPostBack="True" tabIndex="1" 
                            onselectedindexchanged="ddlSection_SelectedIndexChanged" CssClass="field" ></asp:dropdownlist></TD>
					<TD class="style5" align="right">Test Group</TD>
					<TD class="style6">
                        <asp:dropdownlist id="ddlTestGroup" runat="server" Enabled="False" 
                             AutoPostBack="True" Width="100%"
							tabIndex="2" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged" CssClass="field" ></asp:dropdownlist></TD>
				</TR>
				<%--<TR>
					<TD></TD>
					<TD></TD>
					<TD class="style1">&nbsp;</TD>
					<TD colSpan="3">&nbsp;</TD>
					<TD></TD>
					<TD></TD>
				</TR>--%>
                	<TR>
					<%--<TD></TD>--%>
					
					<TD class="style1" align=right>%age Increase</TD>
					<TD colspan="2" align="left"><asp:Label ID="lblNormal" Text="Normal" CssClass="label" runat="server"></asp:Label>&nbsp;<asp:textbox id="txtTestAttribute" runat="server" Enabled="true" 
                            Width="25%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change" onchange="javascript:isNumeric(this,this.id)"></asp:textbox>
                        &nbsp; 
                        <asp:Label ID="lblUrgent" Text="Urgent" runat="server" CssClass="label"></asp:Label>
                        &nbsp;<asp:textbox id="txtUrgper" runat="server" Enabled="true" 
                            Width="25%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change" onchange="javascript:isNumeric(this,this.id)"></asp:textbox>
                        %</TD>
					<TD class="style5" align="right">Effective Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:textbox id="txteffective" runat="server" Enabled="true" 
                            Width="35%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Effective Date"></asp:textbox>
                            
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy" TargetControlID="txteffective">
                        </cc1:CalendarExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txteffective" Mask="99/99/9999"
                            MaskType="Date">

                        </cc1:MaskedEditExtender>
                                                    </TD>
					<TD class="style6">&nbsp;
                            
                                                    <asp:Button ID="btnProcess" Text="Process" Font-Bold="true"   
                                    BackColor="Highlight"  runat="server" onclick="btnProcess_Click" CssClass="buttonStyle" />
                            
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
                            CssClass="datagrid" HorizontalAlign="Left" AllowSorting="True"
                            OnPageIndexChanging="gvTests_PageIndexChanging" DataKeyNames="TESTID"
                            OnSorting="gvTests_Sorting">
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
                                    <ItemStyle HorizontalAlign="Left" Width="12%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="12%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Normal Price" DataField="CHARGES" SortExpression="CHARGES">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Normal Price (Proposed)" 
                                    SortExpression="charges_new">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("charges_new") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt1" CssClass="field" runat="server" width="60px" Text='<%# Bind("charges_new") %>'></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Urgent Price" DataField="ChargesURGENT" SortExpression="ChargesURGENT">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Urgent Price (Proposed)" 
                                    SortExpression="UrgentCharges_New">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox2" runat="server" 
                                            Text='<%# Bind("UrgentCharges_New") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt2" CssClass="field" Width="60px" runat="server" Text='<%# Bind("UrgentCharges_New") %>'></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="effective_date" HeaderText="Effective Date" SortExpression="effective_date" >
                                <HeaderStyle Width="23%" HorizontalAlign="Center" />
                                <ItemStyle Width="23%" HorizontalAlign="Left" />
                                </asp:BoundField> 

                              <%--  <asp:TemplateField HeaderText="Effective Date" SortExpression="effective_date">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("effective_date") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Calendar ID="Calendar1" runat="server" 
                                            VisibleDate='<%# Bind("effective_date") %>' BackColor="White" 
                                            BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                                            Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" 
                                            SelectedDate='<%# Bind("effective_date") %>' Width="200px">
                                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                            <NextPrevStyle VerticalAlign="Bottom" />
                                            <OtherMonthDayStyle ForeColor="#808080" />
                                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                            <SelectorStyle BackColor="#CCCCCC" />
                                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <WeekendDayStyle BackColor="#FFFFCC" />
                                        </asp:Calendar>
                                    
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                           
                            </Columns>
                            <RowStyle CssClass="gridItem" Height="15px" />
                            
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate"  Height="15px"/>
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
