<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testtt.aspx.cs" Inherits="LIMS_WebForms_testtt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
    <%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Preference Settings:    <% =Session["UNUIDFORMATTED"] %>
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
        .style3
        {
            width: 21%;
        }
        .style4
        {
            height: 16px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="5"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="5">
                        
                        <font size="4"><STRONG>TEST PREFERENCE SETTINGS</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="5">
                    <asp:HiddenField ID="hdPreference" runat="server" />
                    <asp:HiddenField ID="hdEdit" runat="server" />
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
					<TD colSpan="5" class="style4"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
                <TR>
					<TD class="style1">&nbsp; </TD>
					
					<TD class="style3">Specimen Collection Time (Indoor)</TD>
					<TD class="style3">
                        <asp:textbox id="txtIndoor" runat="server" Enabled="true" 
                            Width="60%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>minutes</TD>
					<TD class="style3" align="left">Specimen Collection Time(Outdoor)</TD>
					<TD>
                        <asp:textbox id="txtOutdoor" runat="server" Enabled="true" 
                            Width="60%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>minutes
                            </TD>
				</TR>
                <%-- <TR>
					<TD></TD>
					<TD></TD>
					<TD class="style1">&nbsp;</TD>
					<TD colSpan="3">&nbsp;</TD>
					<TD></TD>
					<TD></TD>
				</TR>--%>
                <tr>
                <td></td>
                <td>Result Entry and Verification Time</td>
                <td>
                <asp:TextBox ID="txttimeResultEntry" CssClass="mandatoryField" Width="60%" runat="server"></asp:TextBox>
                hours
                 </td>
                 <td>
                     Graphs and Images Physical Path</td>
                 <td>
                 <asp:TextBox ID="txtPath" runat="server" CssClass="field" Width="100%"></asp:TextBox>
                 </td>

                </tr>
                <TR>
					<TD></TD>
					
					<TD class="style3">Attribute Value Preference</TD>
					<TD class="style3">
                        <asp:textbox id="txtPercent" runat="server" Enabled="true" 
                            Width="60%" CssClass="mandatoryField"
							tabIndex="5" ToolTip="Enter Percentage change"></asp:textbox>%</TD>
                            <TD align="left">
                            
                                Documents Physical Path</TD>
                                <td>
                                <asp:TextBox ID="txtPath_doc" runat="server" CssClass="field" Width="100%"></asp:TextBox>

                                </td>
					
                            </TR>
                <TR>
					<TD>&nbsp;</TD>
					
					<TD class="style3">External Test Threshold Time </TD>
					<TD class="style3">
                <asp:TextBox ID="txtThreshold" CssClass="mandatoryField" Width="60%" 
                            runat="server"></asp:TextBox>
                        hours</TD>
                            <TD align="left">
                            
                                &nbsp;</TD>
                                <td>
                                    &nbsp;</td>
					
                            </TR>
                            <tr>
                            <td></td>
                            <td>Advertisement Note:</td>
                            <td colspan="2">
                                <%--<asp:TextBox ID="txtadnote" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                            <CKEditor:CKEditorControl ID="adnote" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" ShiftEnterMode="BR" 
                            Height="50px" Enabled="true"
                           ToolbarBasic="Source|-|Bold|Italic|"  MaxLength="1000" Visible="true"></CKEditor:CKEditorControl>
                            </td>
                            
                            <td></td>
                            </tr>
                            <tr>
                            <td></td>
                            <td colspan="4">
                            
                            <asp:CheckBox ID="ICD" Text="ICD Code Enabling" runat="server" />
                            
                             <asp:CheckBox ID="chkAutoVerification" Text="Auto Verification" runat="server" />
                                <asp:CheckBox ID="chkAutoVerificationIndoor" runat="server" 
                                    Text="Auto Verification Indoor" />
                                </td>
                            </tr>

                           <tr>
                    <td>
                        </td>

                        <td  >

                            <asp:Label ID="RFound" runat="server" Text="Label" Visible="False" 
                                ForeColor="#66FF66"></asp:Label>
                               </td>
                      
                </tr>
                <tr>
                
                    <td colspan="5">
                        <asp:GridView ID="gvPreference" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datagrid" HorizontalAlign="Center" Width="73%" DataKeyNames="PreferenceID,Img_path,AdvertisementNote" 
                            AllowSorting="True" OnRowCommand="gvPreference_RowCommand" 
                            OnSorting="gvPreference_Sorting">
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
                                    <HeaderStyle HorizontalAlign="cENTER" Width="5%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="PreferenceID" DataField="PreferenceID" 
                                    Visible="False" ReadOnly="true" SortExpression="PreferenceID">
                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    <HeaderStyle  CssClass="gridheader" HorizontalAlign="Left" Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CollTime_Indoor" 
                                    HeaderText="Specimen Collection Time(Indoor)" SortExpression="CollTime_Indoor">
                                    <HeaderStyle  HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Specimen Collection Time(Outdoor)" 
                                    DataField="CollTime_OutDoor" SortExpression="CollTime_OutDoor">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="ICD Code Enabled" DataField="ICD" SortExpression="ICD">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ATTRIBUTEMAX_MIN" 
                                    HeaderText="Attribute Value(Percentage)" SortExpression="ATTRIBUTEMAX_MIN" />
                                <asp:BoundField DataField="RESULTENTRYTIME" 
                                    HeaderText="Result Entry and Verification Settings" 
                                    SortExpression="RESULTENTRYTIME" />
                                <asp:BoundField DataField="AutoVerify" HeaderText="Auto Verification" 
                                    SortExpression="AutoVerify" />
                                <asp:BoundField DataField="Img_path" HeaderText="Images Path" 
                                    SortExpression="Img_path">
                                    <ItemStyle Width="30%" />
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                <asp:BoundField DataField="doc_Path" HeaderText="Documents path" 
                                    SortExpression="doc_Path" />

                                <asp:BoundField DataField="THRESHOLDTIME" 
                                    HeaderText="ThresholdTimeInHours(ext.)" SortExpression="Threshold_Time" />

                              <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'>update</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                            
                        </asp:TemplateField>

                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                        </asp:GridView>
                    </td>
                </tr>
             
                </TABLE>
                </form>

</body>
</html>
