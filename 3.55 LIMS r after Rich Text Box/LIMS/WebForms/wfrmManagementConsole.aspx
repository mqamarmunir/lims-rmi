<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmManagementConsole.aspx.cs" Inherits="LIMS_WebForms_wfrmManagementConsole" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
 
    <table class="label" id="TBLhead" style="Z-INDEX: 101; LEFT: 1px; POSITION: relative; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>MANAGEMENT CONSOLE</STRONG></font>
                     <asp:ScriptManager ID="smanager1" runat="server"></asp:ScriptManager>
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
        <td colspan="4">
        <asp:TabContainer ID="leftside" runat="server" ActiveTabIndex="1">
            
            
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
                         </td>
                         </tr>
                         <tr>
        <td align="right">Sub-Department:</td>
        <td>
        <asp:DropDownList ID="ddlSubDep" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlSubDep_SelectedIndexChanged" Width="99%"></asp:DropDownList>
        </td>
        <td align="right">Ward:</td>
        <td>
        <asp:DropDownList ID="ddlWard" runat="server" AutoPostBack="True" 
                OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" Width="99%"></asp:DropDownList>
            </td>
        <td></td>
        <td></td>
        <td></td>
        </tr>

        <tr>
        <td align="right">PR No:</td>
        <td>
        <asp:TextBox ID="txtPRNo" runat="server" CssClass="field" Width="50%"></asp:TextBox>
            <asp:MaskedEditExtender ID="txtPRNo_MaskedEditExtender" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txtPRNo" Mask="99\-99\-999999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder=""></asp:MaskedEditExtender>
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
        <td>
        
            <asp:TextBox ID="txtLabFrom" runat="server" CssClass="field" Width="50%"></asp:TextBox>
            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                 Enabled="True" ClearMaskOnLostFocus="False" AutoComplete="False" 
                TargetControlID="txtLabFrom" Mask="99\-999\-9999999" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder=""></asp:MaskedEditExtender>
    
            </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        </tr>
                        <tr>
                        <td colspan="7"><asp:Label ID="lblOverDue" Text="OverDue" BackColor="IndianRed" runat="server"></asp:Label>
                        <asp:Label ID="lblResultEntry" Text="Result Entry" BackColor="#ff99ff" runat="server"></asp:Label>
                        <asp:Label ID="lblResultVerifivation" Text="Verification" BackColor="#99ff99" runat="server"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td colspan="7">
                                <asp:GridView ID="gvTests" DataKeyNames="processid" runat="server" CssClass="datagrid" 
                                    AutoGenerateColumns="False" Width="99%"
                                AllowPaging="True" OnPageIndexChanging="gvTests_PageIndexChanging" 
                                    OnRowDataBound="gvTests_RowDataBound" PageSize="25">
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
                                <asp:BoundField DataField="labid" HeaderText="Lab ID">
                                <ItemStyle Width="15%" />
                                </asp:BoundField>
                               <asp:BoundField DataField="test" HeaderText="Test">
                                <ItemStyle Width="25%" />
                                </asp:BoundField>
                               <asp:BoundField DataField="PatientName" HeaderText="Patient Name">
                                <ItemStyle Width="20%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Priority" HeaderText="Priorirty">
                                <ItemStyle Width="10%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TimeLeft" HeaderText="Time Left">
                                <ItemStyle Width="15%" />
                                </asp:BoundField>
                               <asp:BoundField DataField="WardName" HeaderText="Ward">
                                <ItemStyle Width="15%" />
                                </asp:BoundField>
                                
                                    </Columns>

                                </asp:GridView>
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

<asp:TabPanel ID="tabStaffPerfomance" HeaderText="Staff Perfomance" runat="server">
        <ContentTemplate>
         <asp:Panel ID="pnlstaffPerfomance" runat="server" Height="600px" ScrollBars="Auto">
        
        
                <fieldset>
                <legend>Staff Perfomance:</legend>
                        <table id="tblstaffperfomance" class="label" width="99%">
                          <tr>
                              <td colspan="7" align="right">
                                <asp:ImageButton id="ibtnrefreshstaff" runat="server" 
                                ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefreshstaff_Click" /></asp:ImageButton>
                             </td>
                         </tr>
                        <tr>
                        <td align="right">From:</td>
                        <td>
                            <asp:TextBox ID="txtFromdate" CssClass="mandatoryField" runat="server" Width="45%"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtFromdate">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtFromdate" Mask="99/99/9999"
                            MaskType="Date">
                            </asp:MaskedEditExtender>
                        </td>
                        <td align="right">
                            To:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTodate" CssClass="mandatoryField" runat="server" Width="45%"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtTodate">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtTodate" Mask="99/99/9999"
                            MaskType="Date">
                        </asp:MaskedEditExtender>
                            
                        </td>
                        </tr>
                        <tr>
                        <td colspan="7">
                        <asp:GridView ID="gvPerfomance" OnRowDataBound="gvPerfomance_RowDatabound"
                 DataKeyNames="EnteredBy" Width="99%" HorizontalAlign="Left" 
                     AutoGenerateColumns="False" CssClass="datagrid" runat="server">
                <HeaderStyle HorizontalAlign="Left" CssClass="gridheader" />
                <RowStyle CssClass="gridheader" />
                <AlternatingRowStyle CssClass="gridheader" />
                 <Columns>
                  <asp:TemplateField HeaderText="S#">

                 <HeaderStyle HorizontalAlign="Center" Width="5%" />
                 
                 <ItemTemplate>
                 <%#Container.DataItemIndex+1 %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField HeaderText="PersonName" DataField="EmployeeName" />
                 <asp:BoundField HeaderText="Total Test Performed" DataField="NumberOFTestsEntered" />
                  <asp:TemplateField>
                  <ItemTemplate>
                  <tr>
                  <td></td>
                  <td colspan="8">
                  <table id="tblQualitaitve" width="100%" runat="server" class="label">
                  <tr>
                  <td align="left">
                  <DIV id="divQualitative"  runat="server">
                  <font style="color:Black"> <b>Test Detail:</b></font><br />
                  <asp:GridView ID="gvQualitative" AutoGenerateColumns="false" DataKeyNames="TestID" CssClass="datagrid" runat="server" Width="99%">
                  <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                  <RowStyle CssClass="gridAlternate" />
                  <Columns>
                  <asp:TemplateField HeaderText="S#">
                  <ItemTemplate>
                  <%#Container.DataItemIndex+1 %>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:BoundField HeaderText="Test Name" DataField="Test" />
                  <asp:BoundField HeaderText="Count" DataField="TestEntryTimes" />
                      </Columns>
                      </asp:GridView>
                  </DIV>
                  </td>
                  </tr>
                 
                  </table>
                  </td>
                  </tr>
                     </ItemTemplate>
                  </asp:TemplateField>
               
                
               
                            </Columns>
                            </asp:GridView>
                        </td>
                        </tr>
                        <tr>
                        <td width="15%"></td>
                        <td width="20%"></td>
                        <td width="15%"></td>
                        <td width="20%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        <td width="10%"></td>
                        </tr>
                        </table>
                </fieldset>
          </asp:Panel>

            </ContentTemplate>
        </asp:TabPanel>
</asp:TabContainer>
        </td>
       
       
       
       
        <td colspan="3">
        <asp:TabContainer ID="rightend" runat="server" ActiveTabIndex="0">
            
            
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
                <asp:GridView ID="gvNotifications" runat="server" ShowHeader="false" CssClass="datagrid" Width="99%"
                 DataKeyNames="CommentID" AutoGenerateColumns="false" OnRowDataBound="gvnotifications_RowDataBound">
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
                <asp:BoundField DataField="Notifications" HeaderText="New Notifications" />
                    </Columns>
                    </asp:GridView>
                </fieldset>
                </asp:Panel>
                </ContentTemplate>
                </asp:TabPanel>





</asp:TabContainer>








        

        </td>
        
        
        </tr>

        <tr>
        
        <td colspan="4">
        Comment:
        <asp:TextBox ID="txtComment" CssClass="field" runat="server" TextMode="MultiLine" Width="85%"></asp:TextBox>
        <asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/save.png" OnClick="imgSave_Click"
                    AccessKey="s" ToolTip="Click or Press Alt+s to save test booking" />
        </td>
        <td></td>
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
        <td></td>
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

   
    </form>
</body>
</html>
