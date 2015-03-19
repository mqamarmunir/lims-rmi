<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmouttestreceiving.aspx.cs" Inherits="LIMS_WebForms_wfrmouttestreceiving" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <LINK href="LIMS.css" rel="stylesheet">
    <script src="../../scripts/jquery-2.1.0.min.js" type="text/javascript"></script>
   
    <script language="javascript" type="text/javascript">

        $(document).ready(function () {
            $("<%#dgReceivedTestList.ClientID %> tr").find('[id *= fileupload ]').click(function () {
                //alert($("<%#hfParentFile.ClientID %>").val());
                if ($("<%#hfParentFile.ClientID %>").val() != "" && $("<%#hfParentFile.ClientID %>").val() != null) {
                  //  alert($("<%#hfParentFile %>").val());
                    alert("When master file is selected Individual files are not allowed");
                    return false;
                }
                return true;
            });
        });

     function chkallchanged(cb) {
                if (cb.checked == true) {
                    //document.getElementById('gvExtOrganizations_ctl02_gvtests_ctl02_gvChkSelect').checked = true;
                   // alert(cb.id.substring(0, 18));
                    var table = document.getElementById(cb.id.substring(0, 18));
                    //alert(table);
                    for (var i = 1; i < table.rows.length; i++) {
                        //alert(cb.id.substring(0, 32) + '_ctl0' + (i + 1).toString() + '_gvChkSelect');
                        //alert(padDigits(i+1,2));
                        document.getElementById(cb.id.substring(0, 18) + '_ctl' + padDigits(i + 1, 2) + '_dgchkActive').checked = true;
                       // document.getElementById(cb.id.substring(0, 32) + 'ctl' + lPad((i - 1).toString(),2,'0')+'_gvChkSelect').checked = true;
                    }


                }
                else {
                    var table = document.getElementById(cb.id.substring(0, 18));
                    for (var i = 1; i < table.rows.length; i++) {
                        //alert(cb.id.substring(0, 32) + '_ctl0' + (i + 1).toString() + '_gvChkSelect');
                        //alert(padDigits(i+1,2));
                        document.getElementById(cb.id.substring(0, 18) + '_ctl' + padDigits(i + 1, 2) + '_dgchkActive').checked = false;
                        // document.getElementById(cb.id.substring(0, 32) + 'ctl' + lPad((i - 1).toString(),2,'0')+'_gvChkSelect').checked = true;
                    }

                }
            }
            function padDigits(number, digits) {
                return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
            }
    </script>
            
    <style type="text/css">
        .style2
        {
            width: 20%;
        }
        .style6
        {
            width: 319px;
        }
        .style7
        {
            width: 383px;
        }
        .style11
        {
            width: 319px;
            height: 25px;
        }
        .style12
        {
            height: 25px;
            width: 383px;
        }
        .style13
        {
            height: 25px;
        }
        .style14
        {
            height: 21px;
            width: 383px;
        }
        .style15
        {
            height: 21px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION:relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
    <tr>
					<td colspan="4"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
				<tr>
					<td align="center" colspan="4">
                     <font><h3>SPECIMEN IN QUEUE</h3></font></td>
				</tr>
                <tr>
                <td align="right" class="style2">
                        ThresholdReached</td>
                <td align="left" style="width: 30%">
                        &nbsp <asp:Label ID="lblTReached" runat="server" Text="TReached"></asp:Label>
                    </td>
                <td align="right" width = "50%" style="width: 35%" rowspan="3">
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                        
                        <asp:HiddenField ID = "hfParentFile" runat = "server"/>
                        </td>
					<td align="right" width = "50%" style="width: 35%" rowspan="3">
                        <%--<asp:UpdatePanel ID="Updatebtns" runat="server">
                    <ContentTemplate>--%>
                    
                        <asp:ImageButton id="ibtnsearch" runat="server" 
                            ImageUrl="~/images/Search_OT.gif" TabIndex="23" onclick="ibtnsearch_Click"></asp:ImageButton>
                        <asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif"  TabIndex="23" onclick="ibtnClear_Click"></asp:ImageButton>
						 
                         <%--</ContentTemplate>
                           </asp:UpdatePanel>--%>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" TabIndex="25" onclick="ibtnClose_Click"></asp:ImageButton>
						
                     
                       
                         <%--<Triggers>
                         <asp:AsyncPostBackTrigger ControlID="ddlTestGroup" EventName="SelectedIndexChanged" />
                         </Triggers>--%>
                  
                    </td>
                   
					
                   
				</tr>
                
                <tr>
                <td align="right" class="style2">
                        ThresholdExceeded</td>
                <td align="left" style="width: 30%">
                        &nbsp <asp:Label ID="LblTExceeded" runat="server" Text="TExceded"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                <td align="right" class="style2">
                        All Okay</td>
                <td align="left" style="width: 30%">
                        &nbsp; No Color</td>
                   
					
                   
				</tr>
                
                <tr>
                    <%--<asp:UpdatePanel ID="updatelblErr" runat="server">
                <ContentTemplate>--%>
              
					<td colSpan="4"><asp:label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%" Font-Bold="True"></asp:label></td>
                    <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                </tr>
              
				
   
    </table>
    <br />
      

   <table class="label" id="Table2" width="100%" border="0" >
   <tr>
   <td style="text-align: right" class="style7">From Date:</td>
					<td width="200px"><asp:textbox id="txtfromdate" tabIndex="11" runat="server" Width="100%" CssClass="mandatoryField" ToolTip="From Date"
							MaxLength="15"></asp:textbox><asp:CalendarExtender ID="CalendarExtender1"  TargetControlID="txtfromdate" Format="dd/MM/yyyy" runat="server">
                            </asp:CalendarExtender>
                            
                            
                            </td>

    <td align="right" style="text-align: right" class="style6">&nbsp;&nbsp; To Date:</td>
					<td width="200px"><asp:textbox id="txttodate" tabIndex="11" runat="server" Width="100%" 
                            CssClass="mandatoryField" ToolTip="To Date"
							MaxLength="15"></asp:textbox>
                    </td>
       <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate" Format="dd/MM/yyyy" runat="server">
       </asp:CalendarExtender>
                    <td align="left">
                    <br />
                       
            
                    
                    </td>
   </tr>
   <tr>
   <td class="style7"></td>
   </tr>
     <tr style="">
   <td style="text-align: right" class="style7">Search By LabID:</td>
					<td width="200px"><asp:textbox id="txtLabId" tabIndex="11" runat="server" 
                            Width="100%" CssClass="mandatoryField" ToolTip="Enter LabId"
							MaxLength="15"></asp:textbox>
                        <asp:MaskedEditExtender ID="txtLabId_MaskedEditExtender" runat="server" 
                            Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                            TargetControlID="txtLabId" Mask="99-999-9999999">
                        </asp:MaskedEditExtender>
         </td>

    <td align="right" style="text-align: right" class="style6">External Lab</td>
					<td width="200px">
                        <asp:DropDownList ID="ddlLab" runat="server" CssClass="mandatoryField" 
                            Height="17px" Width="100%">
                        </asp:DropDownList>
         </td>
                    <td align="left">
                    <br />
                       
            
                    
                    </td>



   </tr>
     <tr>
   <td style="text-align: right" class="style12">Upload File:</td>
					<td width="200px" class="style13">
                        <asp:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                            
                            onuploadedcomplete="AsyncFileUpload1_UploadedComplete" Width="0px"
                             />
         </td>

    <td align="right" style="text-align: right" class="style11"></td>
					<td width="200px" class="style13">
                        </td>
                    <td align="left" class="style13">
                        </td>



   </tr>
   <tr>
   <td class="style14">
   <asp:LinkButton ID="lnkRecieveSelected" runat="server" Text="Receive Selected" 
           onclick="lnkRecieveSelected_Click"></asp:LinkButton>
   </td>
   <td class="style15">
      &nbsp <asp:Label ID="lblMsg" runat="server"></asp:Label>
   </td>
   <td colspan="2" class="style15">
   </td>
   </tr>
   <tr>
      
   <td colspan=5>
   <asp:datagrid id="dgReceivedTestList" runat="server" AllowSorting="True" 
                            AutoGenerateColumns="False" PageSize="25" 
							AllowCustomPaging="True" CssClass="datagrid" Width="100%" 
           OnSortCommand="dgReceivedTestList_SortCommand" 
           onitemdatabound="dgReceivedTestList_ItemDataBound">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                            <asp:TemplateColumn SortExpression="Received">
									<HeaderStyle HorizontalAlign="Center" Width="4%"></HeaderStyle>
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="chkRecieveAll" ToolTip="Select/DeSelect All" onclick="javascript:chkallchanged(this);" runat="server" />
                                    </HeaderTemplate>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="S#" SortExpression = "SerialNo">
                           <HeaderStyle HorizontalAlign="Center" Width="4%" />
                           <ItemStyle HorizontalAlign="Center" />
                           <ItemTemplate>
                           <%#Container.ItemIndex+1 %>
                           </ItemTemplate>
                           </asp:TemplateColumn>
								
                                <asp:BoundColumn DataField="batchno" HeaderText="Batch No." SortExpression = "BatchNo">
                                <headerStyle Width="8%" /></asp:BoundColumn>
								<asp:BoundColumn DataField="labid" SortExpression="LabId" ReadOnly="True" HeaderText="Lab ID">
									<HeaderStyle Width="8%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Patientname" HeaderText="Patient Name" SortExpression="PatientName">
                                  <HeaderStyle HorizontalAlign="Left" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="test" HeaderText="Test" 
                                    SortExpression="Test">
                                    <HeaderStyle HorizontalAlign="Left" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundColumn>
								<asp:BoundColumn DataField="enteredate" SortExpression="BookedOn" HeaderText="Booked On">
									<HeaderStyle HorizontalAlign="Left" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
                                <asp:BoundColumn Visible="True" HeaderText="Dispatched On" DataField="dispatchedon" SortExpression="DispatchedOn" ReadOnly="True"><HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle></asp:BoundColumn>
                                <asp:BoundColumn Visible="True" HeaderText="Delivery Date" DataField="deliverydate" SortExpression="DeliveryDate"  ReadOnly="True">
                                <HeaderStyle HorizontalAlign="Left" Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle></asp:BoundColumn>
                                <asp:BoundColumn DataField="Destination" HeaderText="Destination" SortExpression = "Destination" >
                                <HeaderStyle HorizontalAlign="Left" Width="13%" /><HeaderStyle />
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="DSerialNo" Visible="false" HeaderText="Destination" ></asp:BoundColumn>
                                <asp:BoundColumn DataField="MSerialNo" Visible="false" HeaderText="Destination" ></asp:BoundColumn>
                                <asp:TemplateColumn HeaderText = "ReferenceFile">
                                <HeaderStyle HorizontalAlign = "Left" Width = "11%" />
                                <ItemTemplate>
                                <asp:AsyncFileUpload ID = "fileupload" runat = "server" 
                                        onuploadedcomplete="fileupload_UploadedComplete" Width="0px"/>
                                
                                </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
   
   </td>
   
   </tr>
   </table>
   
  
    
    </div>
    </form>
</body>
</html>
