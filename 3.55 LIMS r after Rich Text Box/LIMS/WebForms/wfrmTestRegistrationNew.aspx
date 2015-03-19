﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestRegistrationNew.aspx.cs" Inherits="LIMS_WebForms_wfrmTestRegistrationNew" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
    
		<title>LIMS: Test Resgistration : <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	   
	    <style type="text/css">
            .style1
            {
                width: 116px;
            }
        </style>
	   
	    </HEAD>
<body>
<script type="text/javascript">
    function isNumeric(x, _id) {
        var value = x.value; // toString();
        if (isNaN(parseFloat(value))) {
            alert("only numeric characters allowed");
            document.getElementById(_id).value = "";
            return false;
        }
        return true;
    }

    function PopupCal(checkbox) {
     //   alert(document.getElementById('Panel3'));
        if (checkbox.checked) {
            document.getElementById('Panel3').style.display = "block";
        }
        else {
            document.getElementById('Panel3').style.display = "none";
        }
         //return true;

    }
    

    function ResetScrollPosition() {
        setTimeout("window.scrollTo(0,85)", 0);
    }
    function mlinterpretation() {
        if (document.getElementById('chkmlinterpretation').checked == true) {
//            alert('this will display all the textboxes');
            document.getElementById('multilineinterpretation').style.display = "block";
        }
        else {
//            alert('this will display only one');
            document.getElementById('multilineinterpretation').style.display = "none";
        }
    }
    function Displayweekdays(DropDownList) {
        //alert(DropDownList.value);
        if (DropDownList.value == "0") {
            document.getElementById('lblbatch').style.display = "none";
            document.getElementById('txtbatchtime').style.display = "none";
            document.getElementById('PanelDays').style.display = "none";
            document.getElementById('PanelMonthly').style.display = "none";
            document.getElementById('pnlCutoffdays').style.display = "none";

        }
        else if (DropDownList.value == "1") {

            document.getElementById('lblbatch').style.display = "block";
            document.getElementById('txtbatchtime').style.display = "block";
            document.getElementById('PanelDays').style.display = "block";
            // document.getElementById('PanelWeek').visible = false;
            // alert(document.getElementById('PanelWeek').visible);

            document.getElementById('PanelWeek').style.display = "none";
            document.getElementById('PanelMonthly').style.display = "none";
            document.getElementById('pnlCutoffdays').style.display = "none";

        }
        else if (DropDownList.value == "2") {
            document.getElementById('lblbatch').style.display = "block";
            document.getElementById('txtbatchtime').style.display = "block";
            document.getElementById('PanelDays').style.display = "block";
            document.getElementById('PanelWeek').style.display = "block";
            document.getElementById('PanelMonthly').style.display = "none";
            document.getElementById('pnlCutoffdays').style.display = "block";
        }
        else if (DropDownList.value == "3") {
            document.getElementById('lblbatch').style.display = "block";
            document.getElementById('txtbatchtime').style.display = "block";
            document.getElementById('PanelDays').style.display = "none";
            document.getElementById('PanelWeek').style.display = "none";
            //alert(document.getElementById('PanelMonthly').style.display);
            document.getElementById('PanelMonthly').style.display = "block";
            document.getElementById('pnlCutoffdays').style.display = "none";
            //alert(document.getElementById('PanelMonthly').style.display);
        }


        //ddl
    }
</script>
    <form id="form1" runat="server">
    <div>
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION:relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
    <tr>
					<td><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
				<tr>
					<td align="center">
                     <font><strong>   
TEST REGISTRATION</strong></font></td>
				</tr>
                <tr>
					<td align="right">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    <%--<asp:UpdatePanel ID="Updatebtns" runat="server">
                    <ContentTemplate>--%>
                    
                   
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" 
                            TabIndex="22"></asp:ImageButton>
					
                        <asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif"  TabIndex="23"></asp:ImageButton>
						 
                         <%--</ContentTemplate>
                           </asp:UpdatePanel>--%>
                         <asp:ImageButton id="ibtnTestAttribute" runat="server" ImageUrl="images/btn_TestAttribute.gif"  TabIndex="24"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif" TabIndex="25"></asp:ImageButton>
						
                     
                       
                         <%--<Triggers>
                         <asp:AsyncPostBackTrigger ControlID="ddlTestGroup" EventName="SelectedIndexChanged" />
                         </Triggers>--%>
                  
                    </td>
				</tr>
                
                <tr>
                <%--<asp:UpdatePanel ID="updatelblErr" runat="server">
                <ContentTemplate>--%>
              
					<td colSpan="7"><asp:label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%" Font-Bold="True"></asp:label></td>
				  <%--</ContentTemplate>
                </asp:UpdatePanel>--%>
                </tr>
              
				
   
    </table>
    <br /> 

   <%-- <asp:UpdatePanel ID="Panelupdate1" runat="server">--%>
    <%--<ContentTemplate>--%>
    <fieldset style="width: 98%">
   <legend title="Test Info">Test Info</legend>
   
   <%--<table  class="label" id="Table3" border="0">
     <tr>
   
   <td>Sub-Department:</td>
   <td><asp:dropdownlist id="ddlSection" tabIndex="1" runat="server" 
           AutoPostBack="True" 
           onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></td>
           <td align="left" ><asp:checkbox id="chkActive" tabIndex="3" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left"></asp:checkbox></td>
           <td align="left">
						<asp:checkbox id="chkReportGroup" tabIndex="5" runat="server" Text="Report Group" TextAlign="Left"></asp:checkbox></td>
					<td align="left">
                        <asp:checkbox id="chkUrgent" tabIndex="6" runat="server" Text="Urgent" TextAlign="Left"></asp:checkbox></td>
                    <td align="left">
                        <asp:checkbox id="chkExternal" tabIndex="6" runat="server" Text="External" TextAlign="Left"></asp:checkbox></td>
					<td align="left">
						<asp:checkbox id="chkSepReport" tabIndex="7" runat="server" Text="Separate Report" TextAlign="Left"></asp:checkbox></td>
					<td  align="left">
						<asp:checkbox id="chkReportTest" tabIndex="8" runat="server" Width="100%" Checked="True" Text="Report Test" TextAlign="Left"></asp:checkbox></td>
					<td align ="left">
						<asp:checkbox id="chkProvisional" tabIndex="7" runat="server" Text="Provisional Report" TextAlign="Left"></asp:checkbox></td>
                    <td align="left">
                        <asp:CheckBox ID="chkSummary" runat="server" TabIndex="9" Text="Summary" TextAlign="Left" /></td>
   
   </tr>
   </table>--%>
   
  
   
  
   
   <table class="label" id="Table2" width="100%" border="0" >
   <tr>
   
   <td width="7%">Sub Department:</td>
   <td><asp:dropdownlist id="ddlSection" tabIndex="1" runat="server" 
           AutoPostBack="True" width="100%"
           onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></td>
           <td  colspan="2" >
          
						<asp:checkbox id="chkSepReport" tabIndex="7" runat="server" Text="Separate Report" TextAlign="Left"></asp:checkbox>
					
						<asp:checkbox id="chkReportTest" tabIndex="8" runat="server" Checked="True" Text="Report Test" TextAlign="Left"></asp:checkbox>
					
						<asp:checkbox id="chkProvisional" tabIndex="7" runat="server" Text="Provisional" TextAlign="Left"></asp:checkbox>
                   
                        <asp:CheckBox ID="chkDelivery" Text="Delivery Date On Specimen" TextAlign="Left" runat="server" />

                        <asp:CheckBox ID="chk24hrs" Text="24 Hrs. Delivery" TextAlign="Left" Checked="true" runat="server" />
                        
                        <asp:CheckBox ID="chkPrintmethod" Text="Print Method on Rep." TextAlign="Left" Checked="false" runat="server" />
                        
                        <asp:CheckBox ID="chkPrintMachine" Text="Print Machine on Rep." TextAlign="Left" Checked="false" runat="server" />
                        <asp:CheckBox ID="chkHistory" Text="History Taking" TextAlign="Left" Checked="false" runat="server" />
                        </td>
   
   </tr>
   <tr>
   <td>Test Group:</td>
   <td ><asp:dropdownlist id="ddlTestGroup" tabIndex="2" runat="server" OnSelectedIndexChanged="ddlTestGroup_SelectedIndexChanged" AutoPostBack="true" Width="100%" ></asp:dropdownlist><%--onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"--%></td>
  
   <td align="right">Test:</td>
					<td>
                    <%--<CKEditor:CKEditorControl ID="txtTest" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="50%" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList" MaxLength="150"></CKEditor:CKEditorControl>--%>
                    <asp:textbox id="txtTest" tabIndex="10" runat="server" Width="30%" CssClass="mandatoryField"
							ToolTip="Enter Test Name" MaxLength="200"></asp:textbox> <asp:checkbox id="chkActive" tabIndex="3" runat="server" Checked="True" ToolTip="Check for remain Activethroughout the application" Text="Active" TextAlign="Left"></asp:checkbox>
                        <asp:CheckBox ID="chkUrgent" runat="server" tabIndex="6" Text="Urgent" 
                            TextAlign="Left" />
                        <asp:CheckBox ID="chkPreferred" runat="server" TabIndex="10" Text="Preferred" 
                            TextAlign="Left" />
                        <asp:CheckBox ID="chkSummary" runat="server" TabIndex="9" Text="Summary" 
                            TextAlign="Left" />
                        <asp:CheckBox ID="chkReportGroup" runat="server" tabIndex="5" 
                            Text="Report Group" TextAlign="Left" />
                        <asp:CheckBox ID="chkExternal" runat="server" tabIndex="6" Text="External" 
                            TextAlign="Left" 
                            oncheckedchanged="chkExternal_CheckedChanged"  onclick="javascript:PopupCal(this);"  />
                            <asp:CheckBox ID="chkAdNote" runat="server" tabIndex="7" Text="Ad. Note" 
                            TextAlign="Left" />
       </td>
   </tr>
   <tr>
   <td></td>
   <td></td>
   <td colspan="2"><asp:Panel ID="Panel3" ClientIDMode="Static" runat="server" CssClass="label"  BackColor="#99CCFF" 
                            Width="100%" style="display:none;">
                            
       
                           
        <hr />
        <div>
            <strong>
            External Organization Information</strong><br />
                <hr />
                <table width="40%">
                <tr>
                <td class="style1"> <label
                    for="rdRed">Organization:</label></td>
                <td> <asp:DropDownList ID="ddlorg" Width="100%" runat="server">
                            </asp:DropDownList></td>
                </tr>
                <tr>
                <td class="style1"><label
                    for="rdRed">TAT (Traveling):</label></td>
                <td> <asp:DropDownList ID="ddltimetype" Width="100%" runat="server">
                            <asp:ListItem Selected="True" Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="H">Hours</asp:ListItem>
                            <asp:ListItem Value="M">Minutes</asp:ListItem>
                            <asp:ListItem Value="D">Days</asp:ListItem>
                            </asp:DropDownList></td>
                            <td>
                            Reporting Time:
                            </td>
                            <td>
                            <asp:TextBox ID="txtReportingTime" runat="server" CssClass="mandatoryField"></asp:TextBox>
                            <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" WatermarkText="HH:mm" TargetControlID="txtReportingTime" runat="server"></asp:TextBoxWatermarkExtender>
       <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtReportingTime" ClearMaskOnLostFocus="false" Mask="99:99"></asp:MaskedEditExtender>
       
                            </td>
                </tr>
                <tr>
                <td class="style1">
              <label
                    for="rdRed">Time:</label></td>
                <td><asp:TextBox ID="txttraveltime" Width="15%" CssClass="mandatoryField" runat="server"></asp:TextBox></td>
                <td>Test Cost:
                </td>
                <td><asp:TextBox ID="txtCostprice" runat="server" CssClass="mandatoryField"></asp:TextBox> </td>
                </tr>
          </table>
        </div>
        <div class="clear"></div>
        <div class="left">
            &nbsp; &nbsp; 
        </div>
        <%--<div class="right">
        <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="[ X ]" />
        </div>--%>
        <div class="clear"></div>
        </asp:Panel></td>
   
   </tr>
   <tr>
   <td>Acronym:</td>
					<td><asp:textbox id="txtAcronym" tabIndex="11" runat="server" Width="100%" CssClass="mandatoryField" ToolTip="Enter Test Acronym"
							MaxLength="15"></asp:textbox></td>

    <td align="right">&nbsp;&nbsp; Procedure:</td>
					<td ><asp:dropdownlist id="ddlProcedure" tabIndex="15" runat="server" ></asp:dropdownlist>
                    </td>
                    <td align="left">
                    <br />
                       
            
                    
                    </td>
   </tr>
   <tr>
   <td>Format:</td>
   <td><asp:dropdownlist id="ddlFormat" tabIndex="4" runat="server" Width="100%">
							<asp:ListItem Value="G">General</asp:ListItem>
							<asp:ListItem Value="H">Histo</asp:ListItem>
							<asp:ListItem Value="M">Micro</asp:ListItem>
						</asp:dropdownlist></td>
   <td align="right" width="10%">Perform:</td>
   <td ><asp:DropDownList ID="ddlPerform" runat="server"  onchange="javascript:Displayweekdays(this);">
       <asp:ListItem Value="0">Daily</asp:ListItem>
       <asp:ListItem Value="1">Days</asp:ListItem>
       <asp:ListItem Value="2">Weekly</asp:ListItem>
        <asp:ListItem Value="3">Monthly</asp:ListItem>
       </asp:DropDownList>
       <asp:Label ID="lblbatch" runat="server" Text="Batch Time:" style="display:none;"></asp:Label>
       <asp:TextBox ID="txtbatchtime" runat="server" CssClass="mandatoryField" style="display:none;"></asp:TextBox>
       <asp:TextBoxWatermarkExtender WatermarkText="HH:mm" TargetControlID="txtbatchtime" runat="server"></asp:TextBoxWatermarkExtender>
       <asp:MaskedEditExtender ID="mskeditext1" runat="server" TargetControlID="txtbatchtime" ClearMaskOnLostFocus="false" Mask="99:99"></asp:MaskedEditExtender>
       
       <asp:Panel ID="pnlCutoffdays"  runat="server" style="display:none;">
       <fieldset>
       <legend>Cut Off Day</legend>
       
       
   
   <table  id="Table4" width="75%" border="1" cellpadding="0" cellspacing="0">
   <tr style="background-color:Highlight">
   <td align="center">#</td>
   <td align="center" width="14%">Monday</td>
    <td align="center" width="14%">Tuesday</td>
    <td align="center" width="14%">Wednesday</td>
    <td align="center" width="14%">Thursday</td>
    <td align="center" width="14%">Friday</td>
   <td align="center" width="14%">Saturday</td>
   <td align="center" width="14%">Sunday</td>
   </tr>

   <tr style="background-color:White" >
   <td style="background-color:Highlight" align="center">1:</td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutMonday"   Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcuttuesday" Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutwed" Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutthu" Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutFriday" Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutsat" Text="" runat="server" /></td>
   <td align="center"><asp:RadioButton GroupName="cutoffday" ID="chcutsunday" Text="" runat="server" /></td>

   </tr>
   </table>
   </fieldset>
   </asp:Panel>
   
       </td>
       
   </tr>
   
   <tr>
   <td>Generation Level</td>
   <td><asp:dropdownlist id="ddlGenLevel"  tabIndex="20" runat="server" Width="100%">
							<asp:ListItem Value="S" Selected="True">Section</asp:ListItem>
							<asp:ListItem Value="G">Group</asp:ListItem>
							<asp:ListItem Value="T">Test</asp:ListItem>
						</asp:dropdownlist></td>
   <td>
    
    </td>
   <td>
   <asp:Panel ID="PanelDays"  runat="server" style="display:none;">
   
   <table  id="PerformTable" width="75%" border="1" cellpadding="0" cellspacing="0">
   <tr style="background-color:Highlight">
   <td align="center">#</td>
   <td align="center" width="14%">Monday</td>
    <td align="center" width="14%">Tuesday</td>
    <td align="center" width="14%">Wednesday</td>
    <td align="center" width="14%">Thursday</td>
    <td align="center" width="14%">Friday</td>
   <td align="center" width="14%">Saturday</td>
   <td align="center" width="14%">Sunday</td>
   </tr>

   <tr style="background-color:White" >
   <td style="background-color:Highlight" align="center">1:</td>
   <td align="center"><asp:CheckBox ID="chkMon1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkTue1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkWed1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkThu1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkFri1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSat1" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSun1" Text="" runat="server" /></td>

   </tr>
   </table>
   
  <asp:Panel ID="PanelWeek" runat="server" style="display:none;">
  <table  id="PerformTableweek" width="75%" border="1" cellpadding="0" cellspacing="0">
   <tr style="background-color:White">
   <td style="background-color:Highlight" align="center">2:</td>
   <td align="center"><asp:CheckBox ID="chkMon2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkTue2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkWed2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkThu2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkFri2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSat2" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSun2" Text="" runat="server" /></td>

   </tr>
   <tr style="background-color:White">
   <td style="background-color:Highlight" align="center">3:</td>
   <td align="center"><asp:CheckBox ID="chkMon3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkTue3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkWed3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkThu3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkFri3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSat3" Text="" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="chkSun3" Text="" runat="server" /></td>

   </tr>
   <tr style="background-color:White">
   <td style="background-color:Highlight" align="center">4:</td>
   <td align="center" width="14%"><asp:CheckBox ID="chkMon4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkTue4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkWed4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkThu4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkFri4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkSat4" Text="" runat="server" /></td>
   <td align="center" width="14%"><asp:CheckBox ID="chkSun4" Text="" runat="server" /></td>

   </tr>
   </table>
   </asp:Panel>

   

   </asp:Panel>

   <asp:Panel ID="PanelMonthly" runat="server" style="display:none;">
  <table  id="Table3" width="75%" border="1" cellpadding="0" cellspacing="0">
  <tr> 
  <th colspan="10" align="center">
  Check All the Batch Performing Dates Below
  </th>
  </tr>
   <tr style="background-color:White">
   
   <td align="center"><asp:CheckBox ID="CheckBox1" Text="01" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox2" Text="02" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox3" Text="03" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox4" Text="04" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox5" Text="05" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox6" Text="06" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox7" Text="07" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox8" Text="08" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox9" Text="09" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox10" Text="10" runat="server" /></td>

   </tr>
    <tr style="background-color:White">
   
   <td align="center"><asp:CheckBox ID="CheckBox11" Text="11" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox12" Text="12" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox13" Text="13" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox14" Text="14" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox15" Text="15" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox16" Text="16" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox17" Text="17" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox18" Text="18" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox19" Text="19" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox20" Text="20" runat="server" /></td>

   </tr>
    <tr style="background-color:White">
   
   <td align="center"><asp:CheckBox ID="CheckBox21" Text="21" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox22" Text="22" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox23" Text="23" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox24" Text="24" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox25" Text="25" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox26" Text="26" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox27" Text="27" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox28" Text="28" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox29" Text="29" runat="server" /></td>
   <td align="center"><asp:CheckBox ID="CheckBox30" Text="30" runat="server" /></td>

   </tr>
   
   
   </table>
   </asp:Panel>
   </td>
   </tr>
   <tr>
   <td>Generate On</td>
   <td><asp:dropdownlist id="ddlGenOn" tabIndex="21" runat="server" Width="100%">
							<asp:ListItem Value="R" Selected="True">Reception</asp:ListItem>
							<asp:ListItem Value="W">Work List</asp:ListItem>
						</asp:dropdownlist></td>
   
   </tr>
   <tr>
   <td>Re-Order Time</td>
   <td><asp:TextBox ID="txtReorder" runat="server" CssClass="field" Width="75%"></asp:TextBox>
                        (min)</td>
   </tr>
   </table>
   
  
    </fieldset>

    
    
    <fieldset style="width: 98%">
    <legend>Specimen Info</legend>
    <table class="label" id="SpecimenTable" cellpadding="1" cellspacing="1" border="0">
    <tr>
    <td width="12%">
    Specimen (Sc.):
    </td>
    <td width="20%" ><asp:textbox id="txtSpecimen" tabIndex="14" runat="server" Width="100%" CssClass="mandatoryField"
							ToolTip="Enter Test Specimen" MaxLength="50"></asp:textbox></td>

    <td width="10%" align="right">Specimen (Initial):</td>
    <td width="15%"><asp:dropdownlist id="ddlSpecimenType" tabIndex="16" runat="server" Width="100%"></asp:dropdownlist></td>
    <td align="right" width="8%">Container:</td>
    <td width=10%><asp:dropdownlist id="ddlSpecimenContainer" tabIndex="17" runat="server" Width="100%"></asp:dropdownlist></td>
    <td align="right">Quantity:</td>
    <td><asp:TextBox ID="txtQuantity" CssClass="field" runat="server"></asp:TextBox></td>
    <td align="right">Unit:</td>
    <td><asp:TextBox ID="txtunit" CssClass="field" runat="server"></asp:TextBox></td>
    </tr>
    </table> 
    </fieldset>
 
 <table width="100%" id="tblabovegrid">
 <tr>
 <td colspan="4">
 <fieldset style="width: 480px">
  <legend>Charges & General</legend>
  <table class="label" id="GeneralTable" cellpadding="1" cellpadding="1" border="0" width="100%">
  <tr>
  <td width=15% align="right">
  Charges:
  </td>
  <td width="15%"><asp:textbox id="txtCharges" tabIndex="13" runat="server" Width="100%" CssClass="mandatoryField"
							ToolTip="Enter Test Charges" onchange="javascript:isNumeric(this,this.id)"></asp:textbox></td>
  <td width="30%" align="right">Urgent Charges:</td>
  <td width="15%"><asp:textbox id="txtChargesUrgent" tabIndex="12" runat="server" Width="96px" ToolTip="Enter Urgent Test Charges"
							CssClass="mandatoryField" onchange="javascript:isNumeric(this,this.id)"></asp:textbox></td>

  </tr>
  <tr>
  <td align="right">Clinical Use:</td>
  <td colspan="3" ><asp:textbox id="txtClinicalUse" tabIndex="19" runat="server" Width="100%" CssClass="field" ToolTip="Enter Test Clinical Use"
							MaxLength="255"></asp:textbox></td>
  </tr>
  <tr>
  <td align="right">&nbsp;</td>
  <td colspan="3"><%--<asp:textbox id="txtAutomatedText" tabIndex="18" runat="server" 
          Width="100%" Height="100px" CssClass="field"
							ToolTip="Enter Test Interpretation" MaxLength="1500" TextMode="MultiLine" 
          Rows="3" Font-Size="Small"></asp:textbox>--%>
         
  

          </td>
  </tr>
  </table>
  </fieldset>
 </td>
 <td colspan="3"> 
 <table width="100%">
 <tr>
 <td width="100%">
 <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Visible="false">
            <fieldset>
            <legend>Method</legend>
            <asp:GridView ID="gvMethod" runat="server" CssClass="datagrid"  BorderStyle="None"
                    AutoGenerateColumns="False">
            
                <Columns>
                    <asp:TemplateField ShowHeader="false" HeaderText="S#">
                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>:
                                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Method" HeaderText="Method" ShowHeader="False">
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    
                    
                </Columns>
                <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
            
            </asp:GridView>
            </fieldset>
        </asp:Panel>
        </td>
 </tr>
 <tr>
 <td width="100%">
 <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Visible="false">
            <fieldset>
            <legend>Test Group</legend>
            <asp:GridView ID="gvTestGroup" runat="server" CssClass="datagrid"  BorderStyle="None"
                    AutoGenerateColumns="False">
            
                <Columns>
                    <asp:TemplateField ShowHeader="false" HeaderText="S#">
                    <ItemStyle Width="2%" HorizontalAlign="Center" />
                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>:
                                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="TestGroup" HeaderText="TestGroup" ShowHeader="False">
                    <HeaderStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    
                    
                </Columns>
                <RowStyle CssClass="gridItem" />
                           <HeaderStyle CssClass="gridheader"/>
                            <AlternatingRowStyle CssClass="gridAlternate" />
            
            </asp:GridView>
            </fieldset>
        </asp:Panel>
 </td>
 </tr>
 </table>
 </td>
 </tr>
 <tr>
 
 <td colspan="7">

 <fieldset>
 <legend>Interpretation:</legend>
   <div id="divinterpretations" >
   <asp:CheckBox ID="chkmlinterpretation" runat="server" Text="Multiline" Checked="false" CssClass="label" onclick="javascript:mlinterpretation();" />
   <span id="interpretation1">
<CKEditor:CKEditorControl ID="txtAutomatedText" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          </span>

          <span id="multilineinterpretation" style="display:none">
          <CKEditor:CKEditorControl ID="txtAutomatedText2" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText3" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText4" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText5" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText_footer" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
</span>
</div>
 </fieldset>

 </td>
 </tr>
 <tr>
 <td width="20%"></td>
 <td width="20%"></td>
 <td width="10%"></td>
 <td width="10%"></td>
 <td width="10%"></td>
 <td width="10%"></td>
 <td width="10%"></td>
 </tr>
 </table>
  
  
               <%--</ContentTemplate>--%>
       <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSection" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlTestGroup" 
                EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddlPerform" EventName="SelectedIndexChanged" />
        </Triggers>--%>
    <%--</asp:UpdatePanel>--%>  
<%--<asp:UpdatePanel ID="PanelUpdate2" runat="server">
<ContentTemplate>--%>
  <table id="GridViewTable" class="label" border="0" cellpadding="1" cellspacing="1" width="100%">
  <tr>

  <td>
  <asp:Label ID="lblCount" runat="server"></asp:Label>
  </td>
  </tr>
   <tr>
  
  <td width="100%">
  <asp:datagrid id="dgTestList" runat="server" AllowSorting="True" 
          AutoGenerateColumns="False" PageSize="25" 
							AllowCustomPaging="True" CssClass="datagrid" OnSortCommand="dgTestList_Sorting" Width="100%">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                           <asp:TemplateColumn HeaderText="S#">
                           <HeaderStyle HorizontalAlign="Center" Width="5%" />
                           <ItemStyle HorizontalAlign="Center" />
                           <ItemTemplate>
                           <%#Container.ItemIndex+1 %>
                           </ItemTemplate>
                           </asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" HeaderText="Test ID"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SECTIONNAME" HeaderText="Sub-Department"><headerStyle Width="20%" /></asp:BoundColumn>
								<asp:BoundColumn DataField="Test" SortExpression="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="35%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Method" HeaderText="Method" SortExpression="Method">
                                  <HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TESTGROUP" HeaderText="Test Group" 
                                    SortExpression="TESTGROUP">
                                    <HeaderStyle HorizontalAlign="Left" Width="22%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
                                    </asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" SortExpression="Acronym" HeaderText="Acronym">
									<HeaderStyle HorizontalAlign="Left" Width="17%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
                                <asp:BoundColumn Visible="True" HeaderText="Specimen" DataField="Specimen" SortExpression="Specimen" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn Visible="True" HeaderText="Charges" DataField="Charges" SortExpression="Charges" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn DataField="DORDER" HeaderText="DOrder" SortExpression="DORDER"></asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y") %>' runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn EditText="Edit">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								
								
								<asp:BoundColumn Visible="False" DataField="AutomatedText" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ClinicalUse" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProcedureID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestNoLevel" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestNoGenOn" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SpecimenType" HeaderText="SpecimenType"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SpecimenContainer" HeaderText="SpecimenContainer"></asp:BoundColumn>
								<asp:ButtonColumn Visible="false" Text="Delete" CommandName="Delete">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="TestType" HeaderText="TestType"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SEPREPORT" HeaderText="SEPREPORT"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PRINTGROUP" HeaderText="PRINTGROUP"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="PRINTTEST" HeaderText="PRINTTEST"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="CHARGESURGENT" HeaderText="CHARGESURGENT"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Urgent" HeaderText="Urgent"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Summary" HeaderText="Summary" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReorderTime" HeaderText="Reorder" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="ProvisionalReport" HeaderText="Provisional Report" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="External" HeaderText="External" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SPECIMENQUANTITY" HeaderText="Quantity" Visible="false"></asp:BoundColumn>
                                <asp:BoundColumn DataField="SPECIMENUNIT" HeaderText="Unit" Visible="false"></asp:BoundColumn>
                                
                                
							
                                <asp:BoundColumn DataField="Preferred" HeaderText="Preferred" Visible="False">
                                </asp:BoundColumn>
                                
                                
							
                                <asp:BoundColumn DataField="DELIVERYDATEONSPECIMEN" 
                                    HeaderText="Delivery on Specimen Col" SortExpression="DELIVERYDATEONSPECIMEN" 
                                    Visible="False"></asp:BoundColumn>
                                
                                
							
                                <asp:BoundColumn DataField="RoundDelivery" HeaderText="24 Hrs. Delivery" 
                                    Visible="False"></asp:BoundColumn>
                                
                                
							
                                <asp:BoundColumn DataField="PrintMachineName" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="PrintMethodName" Visible="False"></asp:BoundColumn>
                                
                                
							
                                <asp:BoundColumn DataField="HistoryTaking" HeaderText="History" Visible="False">
                                </asp:BoundColumn>
                                
                                <asp:BoundColumn DataField="Ad_Note" HeaderText="adNote" Visible="False">
                                </asp:BoundColumn>
							
                                <asp:BoundColumn DataField="batchtime" HeaderText="batchtime" Visible="False">
                                </asp:BoundColumn>
							
                                <asp:BoundColumn DataField="Interpretation2" ReadOnly="True" Visible="False">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Interpretation3" ReadOnly="True" Visible="False">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Interpretation4" ReadOnly="True" Visible="False">
                                </asp:BoundColumn>
							
                                <asp:BoundColumn DataField="Interpretation5" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Interpretationfooter" Visible="False">
                                </asp:BoundColumn>

							 <asp:BoundColumn DataField="external_orgid" Visible="False">
                                </asp:BoundColumn>
                                 <asp:BoundColumn DataField="travel_time" Visible="False">
                                </asp:BoundColumn>
                                 <asp:BoundColumn DataField="time_type" Visible="False">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="TestCost" Visible="False">
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="Cutoffday" HeaderText="Cutoffday" ReadOnly="True" 
                                    Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="ReportingTime" HeaderText="ReportingTime" 
                                    Visible="False"></asp:BoundColumn>
                            </Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
  </td>
  </tr>

  
  </table>
  <%--</ContentTemplate>--%>
      <%--<Triggers>
          <asp:AsyncPostBackTrigger ControlID="ddlSection" 
              EventName="SelectedIndexChanged" />
              <asp:AsyncPostBackTrigger ControlID="ddlTestGroup" EventName="SelectedIndexChanged" />
      </Triggers>--%>
 <%-- </asp:UpdatePanel>--%>
  
    </div>
    </form>
</body>
</html>
