<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmManagementCons.aspx.cs" Inherits="LIMS_WebForms_wfrmManagementCons" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title>LIMS: Management Console:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
</head>
<body>
<script type="text/javascript">
    function Notificationsclick() {
        var xyz = document.getElementById("rightend_tabnotification");
        var lsbel = document.getElementById("rightend_tabnotification_lblnotify");
        //var spsan = xyz.getElementsByTagName("span").item(1);
        // var tabid = xyz.childNodes.item(2);
        //tabid.value = "notifications";
        lsbel.innerHTML = "Notifications";
        //lsbel.text = "Notifications";
        //alert(lsbel.innerHTML.toString());
    }

</script>

    <form id="form1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
    <table class="label" id="TBLhead" style="Z-INDEX: 101; LEFT: 1px; POSITION: relative; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>MANAGEMENT CONSOLE</STRONG></font>
                   <%-- <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
--%>                    <asp:Timer ID="timer1" runat="server" Interval="60000" OnTick="Timer1_Tick"></asp:Timer>
                    </TD>
				</TR>
                <tr>
                <td colspan="6" align="right">
                
                <asp:ImageButton ID="lbtnClearAll" runat="server" AccessKey="c" ImageUrl="~/images/ClearPack.gif"
                                OnClick="lbtnClearAll_Click" TabIndex="24" ToolTip="Press To Clear (Alt+C)" />
                <asp:ImageButton ID="btnClose" runat="server" AccessKey="x" ImageUrl="~/images/ClosePack.gif"
                                    OnClick="btnClose_Click" TabIndex="26" ToolTip="Close Screen  (Alt+X)" />
                </td>
             
                </tr>
                <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
    </table>

    <table id="tblbody" class="label" width="99%">
    <tr>
    <td colspan="7"><asp:Label ID="lblErrMsg" runat="server" ForeColor="Red"></asp:Label> </td>
    </tr>
    <tr>
    <td>
        <asp:LinkButton runat="server" Text="Notify Others" ID="lnkSendNew" 
            OnClick="SendNotif_Click"></asp:LinkButton>

    <asp:ModalPopupExtender TargetControlID="lnkSendNew"  
            PopupControlID="pnlNotifications" runat="server" ID="ModalPopupExtender1"></asp:ModalPopupExtender>

   
        </td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
       

        <tr>
        <td colspan="4">
        <asp:TabContainer ID="leftside" Width="99%" runat="server" ActiveTabIndex="1" 
                onactivetabchanged="leftside_ActiveTabChanged" AutoPostBack="true">
            
            
 <asp:TabPanel ID="tabTests" HeaderText="Tests Under Process" runat="server">
        <ContentTemplate>
        
        <asp:Panel ID="pnlTests" runat="server" Height="600px" ScrollBars="Auto">
        
        
                <fieldset>
                <legend>Tests(Under Process):</legend>
                        <table id="tbltests" class="label" width="99%">
                         <tr>
                         <td colspan="7" align="right">
                            <asp:ImageButton id="ibtnrefreshtest" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefreshtest_Click"></asp:ImageButton>

                             <asp:ImageButton ID="ibtnsavetest" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnsavetest_Click" />
                         </td>
                         </tr>
                         <tr>
        <td align="right">Sub-Department:</td>
        <td>
        <asp:DropDownList ID="ddlSubDep" runat="server" 
                 Width="99%"></asp:DropDownList>
        </td>
        <td align="right">Ward:</td>
        <td>
        <asp:DropDownList ID="ddlWard" runat="server" 
                 Width="99%"></asp:DropDownList>
            </td>
        <td></td>
        <td></td>
        <td></td>
        </tr>

        <tr>
        <td align="right">PR No:</td>
        <td>
        <asp:TextBox ID="txtPRNo" runat="server" CssClass="field" Width="60%"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtPRNo_MaskedEditExtender" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txtPRNo" Mask="99\-99\-999999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Century="2000"></asp:MaskedEditExtender>
        </td>
        <td align="right">Patient Name:</td>
        <td>
        <asp:TextBox ID="txtpatient" CssClass="field" runat="server" Width="99%"></asp:TextBox>
            </td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td align="right">LabID:</td>
        <td colspan="2">
        
            <asp:TextBox ID="txtLabFrom" runat="server" CssClass="field" Width="35%"></asp:TextBox>
            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txtLabFrom" Mask="99\-999\-9999999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Century="2000"></asp:MaskedEditExtender>
            &nbsp;&nbsp;
<asp:Button ID="btnsearchlab" runat="server" CssClass="field" Text=">" 
                onclick="btnsearchlab_Click" />
            <asp:TextBox ID="txtLabTo" runat="server" CssClass="field" Width="35%"></asp:TextBox>
            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txtLabTo" Mask="99\-999\-9999999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Century="2000"></asp:MaskedEditExtender>
    
            </td>
        
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td align="right">Date(From):</td>
        <td colspan="2">
        
        <asp:TextBox ID="txttestdatefrom" runat="server" CssClass="field" Width="35%"></asp:TextBox>
        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txttestdatefrom" Mask="99/99/9999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Century="2000"></asp:MaskedEditExtender>
        <asp:CalendarExtender ID="ce1" runat="server"  Format="dd/MM/yyyy" TargetControlID="txttestdatefrom" 
                Enabled="True"></asp:CalendarExtender>
            &nbsp;&nbsp; To:
            <asp:TextBox ID="txttestdateto" runat="server" CssClass="field" Width="35%"></asp:TextBox>
             <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txttestdateto" Mask="99/99/9999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Century="2000"></asp:MaskedEditExtender>
        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txttestdateto" 
                Enabled="True" Format="dd/MM/yyyy"></asp:CalendarExtender>
            </td>
        
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
        <tr>
        <td colspan="7">
        <asp:Label ID ="lbllastupdated" runat="server"></asp:Label>
        </td>
        </tr>
                        <tr>
                        <td colspan="7">
                                  
                            
                                <asp:CheckBox ID="chkresultentry" runat="server" BackColor="AntiqueWhite" 
                                Font-Size="Smaller" Text="Result Entry" />
                                <asp:CheckBox ID="chkresultverification" runat="server" BackColor="Aqua" 
                                Font-Size="Smaller" Text="Result Verification" />
                                
                                <asp:CheckBox ID="chkSpecimenOutQUeue" runat="server" BackColor="SeaShell" Text="Specimen Out Queue"  Font-Size="Smaller" />

<asp:CheckBox ID="chkSpecomenInqueue" runat="server" BackColor="RoyalBlue" Text="Specimen In Queue"  Font-Size="Smaller" />
<asp:label ID="chkOverdue" runat="server" BackColor="IndianRed" 
                                Font-Size="Smaller" Text="Over Due" />
                                <asp:label ID="chkrepeat" runat="server" BackColor="Bisque" 
                                Font-Size="Smaller" Text="Repeat" />
                                  
                        </td>
                        </tr>
                        <tr>
                        <td colspan="7">
                        <asp:UpdatePanel ID="updtegridtests" runat="server">
                        <ContentTemplate>
                        
                                <asp:GridView ID="gvTests" DataKeyNames="processid,testid" runat="server" CssClass="datagrid" 
                                    AutoGenerateColumns="False" Width="99%"
                                AllowPaging="True" OnPageIndexChanging="gvTests_PageIndexChanging" 
                                    OnRowDataBound="gvTests_RowDataBound"  PageSize="25" AllowSorting="True" 
                                    onsorting="gvTests_Sorting">
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                <asp:TemplateField HeaderText="S#">
                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:BoundField DataField="labid" HeaderText="Lab ID" SortExpression="labid">
                                <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" SortExpression="PatientName">
                                <ItemStyle Width="15%" />
                                 </asp:BoundField>
                               <asp:BoundField DataField="test" HeaderText="Test" SortExpression="test">
                                <ItemStyle Width="20%" />
                               
                               
                                </asp:BoundField>
                                <asp:BoundField DataField="Priority" HeaderText="Priorirty" SortExpression="Priority">
                                <ItemStyle Width="5%" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Entry Time" DataField="EnteredAte" 
                                        ItemStyle-Width="12%"  SortExpression="EnteredAte">
                                    <ItemStyle Width="12%" />
                                    </asp:BoundField>
                                <asp:BoundField HeaderText="Delivery Time" DataField="DeliveryDate" 
                                        ItemStyle-Width="13%" SortExpression="DeliveryDate" >
                                    <ItemStyle Width="13%" />
                                    </asp:BoundField>
                                <asp:BoundField DataField="TimeLeft" HeaderText="Time Left" SortExpression="TimeLeft">
                                <ItemStyle Width="10%" />
                                </asp:BoundField>
                               <asp:BoundField DataField="WardName" HeaderText="Booked At" SortExpression="WardName">
                                <ItemStyle Width="15%" />
                                </asp:BoundField>
                                
                                    </Columns>

                                </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="timer1" EventName="Tick" />
                                </Triggers>
                        </asp:UpdatePanel>
                        </td>
                        </tr>
                        <tr>
                        <td width="20%"></td>
                        <td width="20%"></td>
                        <td width="15%"></td>
                        <td width="15%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        </tr>
                        </table>
                </fieldset>
                
                </asp:Panel>
                
</ContentTemplate>
        

</asp:TabPanel>










<%--Staff Perfomance Tab begins here--%>

<asp:TabPanel ID="tabPerfomance" runat="server" HeaderText="Employees Perfomance">
<ContentTemplate>
<asp:Panel ID="pnlperfomance" runat="server" Height="600px" ScrollBars="Auto"><table id="tblPerf" width="99%"><tr><td colspan="3" align="right"></td>
                              <td colspan="4" align="right"><asp:ImageButton id="ibtnrefreshstaff" runat="server" 
                                ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefreshstaff_Click"></asp:ImageButton>


                                <asp:ImageButton id="ibtnsavestaff" runat="server" 
                             ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnsavestaff_Click"></asp:ImageButton>


                             </td>
                             <tr><td align="right">Process: </td><td><asp:DropDownList ID="ddlProcess" 
                                     runat="server" Width="99%"></asp:DropDownList>


                                </td>
                                <td align="right">Person:</td><td><asp:DropDownList ID="ddlPersons" 
                                     runat="server" Width="99%"></asp:DropDownList>


                                </td>
                                <td></td>
                                <td></td>
                                <td></td>
                             </tr>
                         </tr>
                         <tr><td align="right">Shift:</td><td><asp:DropDownList ID="ddlShift" runat="server"><asp:ListItem 
                                 Value="-1">Select</asp:ListItem><asp:ListItem Value="0">1st Shift(0800-1500)</asp:ListItem><asp:ListItem 
                                 Value="1">2nd Shift(1500-2200)</asp:ListItem><asp:ListItem Value="2">3rd Shift(2200-0800)</asp:ListItem></asp:DropDownList></td><td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        </tr>
                        <tr><td align="right">From:</td><td><asp:TextBox ID="txtFromdate" runat="server" 
                                CssClass="mandatoryField" Width="45%"></asp:TextBox><asp:CalendarExtender 
                                ID="CalendarExtender1" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                TargetControlID="txtFromdate"></asp:CalendarExtender>


                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" 
                                AutoComplete="False" Century="2000" ClearMaskOnLostFocus="False" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="txtFromdate"></asp:MaskedEditExtender>


                        </td>
                        <td align="right">To: </td><td><asp:TextBox ID="txtTodate" runat="server" 
                                CssClass="mandatoryField" Width="45%"></asp:TextBox><asp:CalendarExtender 
                                ID="CalendarExtender2" runat="server" Enabled="True" Format="dd/MM/yyyy" 
                                TargetControlID="txtTodate"></asp:CalendarExtender>


                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
                                AutoComplete="False" Century="2000" ClearMaskOnLostFocus="False" 
                                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                                Mask="99/99/9999" MaskType="Date" TargetControlID="txtTodate"></asp:MaskedEditExtender>


                            
                        </td>
                        </tr>
                        <tr><td colspan="7"><asp:Label ID="lblindipersum" runat="server" Text="Individual Performance Summary:" 
                                Visible="False"></asp:Label><asp:GridView ID="gvIndividualPer" runat="server" Width="99%"><AlternatingRowStyle CssClass="gridAlternate" />

<HeaderStyle CssClass="gridheader" />

<RowStyle CssClass="gridItem" />
</asp:GridView>


                        </td>
                        </tr>
                        <tr><td colspan="7"><asp:UpdatePanel ID="updteperformance" runat="server"><ContentTemplate><asp:GridView 
                                ID="gvPerfomance" runat="server" AutoGenerateColumns="False" 
                                CssClass="datagrid" DataKeyNames="EnteredBy" GridLines="None" 
                                HorizontalAlign="Left" OnRowDataBound="gvPerfomance_RowDatabound" Width="99%"><HeaderStyle 
                                CssClass="gridheader" HorizontalAlign="Left" /><RowStyle 
                                CssClass="gridItem" /><AlternatingRowStyle CssClass="gridAlternate" /><Columns><asp:TemplateField 
                                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" 
                                    ItemStyle-Width="5%"><ItemTemplate>
                            <asp:Panel ID="pnlmaster" runat="server">
                             <asp:Image ID="imgCollapsible" runat="server" Style="margin-right: 5px;" />
                                </asp:Panel>
                               <%-- <asp:ImageButton ID="gvimgexpand" runat="server" ImageUrl="~/images/button_plus_red.png"
                                    CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgexpand_Click" />
                                <asp:ImageButton ID="gvimgcollapse" runat="server" ImageUrl="~/images/button_minus_red.png"
                                    Visible="false" CommandArgument="<%#Container.DataItemIndex%>" OnCommand="gvimgcollapse_Click" />--%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                  <asp:TemplateField HeaderText="S#"><HeaderStyle HorizontalAlign="Center" Width="5%" />
                 <ItemStyle HorizontalAlign="Center" />
                 
                 <ItemTemplate>
                 <%#Container.DataItemIndex+1 %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="EmployeeName" HeaderText="PersonName" /><asp:BoundField 
                                    DataField="NumberOFTestsEntered" HeaderText="Total Test Performed" /><asp:TemplateField><ItemTemplate>
                  <tr>
                  <td></td>
                  <td colspan="3">
                  <table ID="tblQualitaitve" runat="server" class="label" width="99%">
                  <tr>
                  <td align="left">
                  <asp:Panel ID="pnldetails" runat="server">
                  <div ID="divQualitative" runat="server">
                  <font style="color:Black"> <b>Test Detail:</b></font><br /> <asp:GridView 
                          ID="gvQualitative" runat="server" AutoGenerateColumns="false" 
                          CssClass="datagrid" DataKeyNames="TestID" Width="99%">
                  <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                  <RowStyle CssClass="gridAlternate" />
                  <AlternatingRowStyle CssClass="gridItem" />
                  <Columns>
                  <asp:TemplateField HeaderText="S#">
                  <HeaderStyle HorizontalAlign="Center" Width="5%" />
                  <ItemStyle HorizontalAlign="Center" />
                  <ItemTemplate>
                  <%#Container.DataItemIndex+1 %>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField DataField="Test" HeaderText="Test Name" ItemStyle-Width="90%" />
                  <asp:BoundField DataField="TestEntryTimes" HeaderText="Count" 
                          ItemStyle-Width="5%" />
                      </Columns>
                      </asp:GridView>
                      
                  </div>
                  </asp:Panel>
                  <asp:CollapsiblePanelExtender ID="ctlCollapsiblePanel" runat="Server" 
                          AutoCollapse="false" AutoExpand="False" CollapseControlID="pnlmaster" 
                          Collapsed="True" CollapsedImage="~/images/button_plus_red.png" 
                          CollapsedSize="0" ExpandControlID="pnlmaster" ExpandDirection="Vertical" 
                          ExpandedImage="~/images/button_minus_red.png" ImageControlID="imgCollapsible" 
                          ScrollContents="false" TargetControlID="pnldetails" />
                  </td>
                  </tr>
                 
                  </table>
                  </td>
                  </tr>
                     </ItemTemplate>
                  </asp:TemplateField>
               
                
               
                            </Columns>
                            </asp:GridView>
                            
</ContentTemplate>
</asp:UpdatePanel>


                        </td>
                        </tr>
                        
                        <tr><td width="15%"></td>
                        <td width="20%"></td>
                        <td width="15%"></td>
                        <td width="20%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        </tr>
</table>

</asp:Panel>


</ContentTemplate>
</asp:TabPanel>
</asp:TabContainer>
        </td>
       
       
       
       <%--Right Tab Container starts here  --%>
        <td colspan="3">
        <asp:TabContainer ID="rightend" Width="99%" runat="server" ActiveTabIndex="0">
            
            
 <asp:TabPanel ID="tabstaff" runat="server" HeaderText="Staff Present">
        
        <ContentTemplate>
        <asp:Panel ID="pnlStaff" runat="server" Height="600px">
                <fieldset> 
                <legend>Staff Present:</legend>
                <asp:GridView ID="gvStaff" runat="server" ShowHeader="false" CssClass="datagrid" Width="99%" AutoGenerateColumns="false">
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <ItemStyle Width="10%" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1%>:
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="" HeaderText="Person" />
                    </Columns>
                    </asp:GridView>
                </fieldset>
                </asp:Panel>
                </ContentTemplate>
                </asp:TabPanel>



<%--Notifications Tab Starts here --%>
            

<asp:TabPanel ID="tabnotification" runat="server" OnClientClick="Notificationsclick">
                <HeaderTemplate>
                <div id="notify"><asp:Label ID="lblnotify" Text="Notifications" runat="server"></asp:Label></div>
                </HeaderTemplate>
        
        <ContentTemplate>
        <asp:Panel ID="pnlNotification" runat="server" Height="600px">
                <fieldset> 
                <legend>Notifications:</legend>
                <asp:GridView ID="gvNotifications" runat="server" ShowHeader="False" 
                        CssClass="datagrid" Width="99%"
                 DataKeyNames="NotificationID" AutoGenerateColumns="False" 
                        OnRowDataBound="gvnotifications_RowDataBound">
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <ItemTemplate>
                <%#Container.DataItemIndex+1%>:
                    </ItemTemplate>
                <ItemStyle Width="10%" />
                </asp:TemplateField>
                <asp:BoundField HtmlEncode="False" DataField="Notifications" 
                        HeaderText="New Notifications" />
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="gvimgdone" runat="server" ImageUrl="~/images/a-unread.png" CommandArgument="<%#Container.DataItemIndex %>" OnCommand="gvimgdone_Click" />
                </ItemTemplate>
                <ItemStyle Width="5%" />
                </asp:TemplateField>
                    </Columns>
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                    </asp:GridView>
                </fieldset>
                </asp:Panel>
                </ContentTemplate>
                </asp:TabPanel>





</asp:TabContainer>








        

        </td>
        
        
        </tr>
        <tr>
        <td width="20%"></td>
        <td width="20%"></td>
        <td width="15%"></td>
        <td width="15%"></td>
        <td width="10%"></td>
        <td width="10%"></td>
        <td width="10%"></td>
   
        </tr>
    </table>
    <asp:Panel ID="pnlNotifications" Width="50%" runat="server">
    
    
    <table class="label" style="background-color:Silver">

        <tr>
        <td>
        Comment for:
       
        </td>
        <td>
         <asp:DropDownCheckBoxes ID="ddlPersons_notification" runat="server" UseButtons="false" UseSelectAllNode="True"
                 Width="70%" AddJQueryReference="True"
                meta:resourcekey="checkBoxes3Resource1">
                <Style SelectBoxWidth="99%" DropDownBoxBoxWidth="99%" DropDownBoxBoxHeight=""></Style>
                <Texts SelectAllNode="ALL" SelectBoxCaption="Select Persons" />
                <%--<Items>
                    <asp:ListItem Text="Option 1" Value="1" meta:resourcekey="ListItemResource15" />
                    <asp:ListItem Text="Option 2" Value="2" meta:resourcekey="ListItemResource16" />
                    <asp:ListItem Text="Option 3" Value="3" meta:resourcekey="ListItemResource17" />
                    <asp:ListItem Text="Option 4" Value="4" meta:resourcekey="ListItemResource18" />
                    <asp:ListItem Text="Option 5" Value="5" meta:resourcekey="ListItemResource19" />
                    <asp:ListItem Text="Option 6" Value="6" meta:resourcekey="ListItemResource20" />
                    <asp:ListItem Text="Option 7" Value="7" meta:resourcekey="ListItemResource21" />
                </Items>--%>
            </asp:DropDownCheckBoxes>
            <asp:ListSearchExtender ID="lse3" runat="server" TargetControlID="ddlPersons_notification"></asp:ListSearchExtender>
        </td>
        <td></td>
        <td align="right">
            <asp:ImageButton ID="imgSave0" runat="server" AccessKey="s" 
                ImageUrl="~/images/save.png" OnClick="imgSave_Click" 
                ToolTip="Click or Press Alt+s to save test booking" />
                <asp:ImageButton ID="lnkCancelnoti" runat="server" 
                ImageUrl="~/images/icon_cancel.gif" OnClick="imgCancelNoti_Click" 
                ToolTip="Cancel" />
                <%--<asp:LinkButton ID="lnkCancelnoti" runat="server" Text="[X]" Font-Size="Medium" ></asp:LinkButton>--%>
            </td>
       
        </tr>
        <tr>
        
        <td colspan="4">
        
        Comment:
        <asp:TextBox ID="txtComment" CssClass="field" runat="server" TextMode="MultiLine" Width="70%"></asp:TextBox>
        </td>
        
        </tr>

        <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
       
        </tr>
        
        <tr>
        <td width="20%"></td>
        <td width="20%"></td>
        <td width="15%"></td>
        <td width="15%"></td>
        <%--<td width="10%"></td>
        <td width="10%"></td>
        <td width="10%"></td>--%>
   
        </tr>
    </table>
    </asp:Panel>

   
    </form>
</body>
</html>
