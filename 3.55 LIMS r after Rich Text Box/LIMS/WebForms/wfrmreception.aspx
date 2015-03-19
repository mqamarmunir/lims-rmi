<%@ Reference Page="~/lims/reports/wfrmreceipt.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmReception" enableViewState="True" CodeFile="wfrmReception.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Reception:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="JavaScript">
			function formatDate(o){
				if(event.keyCode < 37 || event.keyCode > 40 ){
					if(event.keyCode != 46 && event.keyCode!=8)
					{
						if(o.value.length > 0)
						{
							removeSlashes(o);
							placeSlashes(o);
						}
					}
				}
			}
			
			function placeSlashes(o)
			{
				if(o.value.length > 2)
				{
					o.value = o.value.substring(0,2)+"/"+o.value.substring(2,o.value.length);
				}
				if(o.value.length > 5)
				{
					o.value = o.value.substring(0,5)+"/"+o.value.substring(5,o.value.length);
				}
			}
			
			function removeSlashes(o)
			{
				index = o.value.indexOf("/");
				if(index !=-1)
				{
					while(index != -1)
					{
						o.value = (o.value).substring(0,index)+ (o.value).substring(index+1 , (o.value).length);
						index = o.value.indexOf("/");
					}
				}
			}
			
			function SetAge(){
				var strDt = document.getElementById("TxtDOB").value;
				var strDay = parseInt(strDt.substring(0, 2));
				var strMonth = parseInt(strDt.substring(3, 5));
				var strYear = parseInt(strDt.substring(6, 10));
				
				var age = -1;
				var ageUnit = -1;
				var dob = new Date(strYear, strMonth-1, strDay);
				var now = new Date();
				var diffDays= parseInt((now-dob)/1000/60/60/24);
				
				if(diffDays < 0)
				{
					alert("Invalid date. Date cannot greater than todays' date");
					return;
				}
				
				if(diffDays < 7){
					age = parseInt(1);
					ageUnit = 2;
				}else if(diffDays < 30){
					age = parseInt(diffDays/7);
					ageUnit = 2;
				}else if(diffDays < 365){
					age = parseInt(diffDays/30);
					ageUnit = 1;
				}else{
					age = parseInt(diffDays/365);
					ageUnit = 0;
				}
				
				document.getElementById("TxtAge").value = age;
				document.getElementById("CmbAgeType").selectedIndex = ageUnit;
			}
			function FillForm(){
				location.href = "wfrmReception.aspx?remsession=n";
			}
			
			function LoadPatient(patientID)
			{
				location.href = "wfrmReception.aspx?remsession=n&patientid="+patientID;
			}
		</script>
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 0px; POSITION: absolute; TOP: 0px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 20px" colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6">
						<TABLE id="Table2" style="WIDTH: 294px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="294"
							align="right" border="0">
							<TR>
								<TD style="WIDTH: 146px" align="center"><asp:linkbutton id="lnkbPrintLastReceipt" tabIndex="44" runat="server" ToolTip="Click to save Patient &amp; Tests Info"
										Font-Size="X-Small" ForeColor="Blue" Visible="False" onclick="lnkbPrintLastReceipt_Click">Print Last Receipt</asp:linkbutton></TD>
								<TD style="WIDTH: 26px" align="center">|</TD>
								<TD align="center"><asp:linkbutton id="ButSave" tabIndex="45" runat="server" ToolTip="Click to save Patient &amp; Tests Info"
										Font-Size="X-Small" ForeColor="Blue" onclick="ButSave_Click">Save</asp:linkbutton></TD>
								<TD align="center">|</TD>
								<TD align="center"><asp:linkbutton id="ButClear" tabIndex="46" runat="server" ToolTip="Click to Enter a new entry"
										Font-Size="X-Small" ForeColor="Blue" onclick="ButClear_Click">New</asp:linkbutton></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
						<asp:label id="LblMessage" runat="server" ForeColor="Red" Width="618px"></asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" align="center" colSpan="2"><asp:radiobuttonlist id="RdoEntitled" tabIndex="1" runat="server" ToolTip="Select for Entitled or Non-Entitiled Patient"
							Font-Size="Small" RepeatDirection="Horizontal" Height="100%" BorderWidth="1px" AutoPostBack="True" BorderColor="DimGray" Width="304px" onselectedindexchanged="RdoEntitled_SelectedIndexChanged">
							<asp:ListItem Value="E" Selected="True">Entitled</asp:ListItem>
							<asp:ListItem Value="C">Non Entitled</asp:ListItem>
							<asp:ListItem Value="P">Panel</asp:ListItem>
						</asp:radiobuttonlist>
					<TD style="HEIGHT: 30px" align="center" colSpan="2"><asp:radiobuttonlist id="RdoRequestType" tabIndex="2" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
							Height="100%" BorderWidth="1px" BorderColor="DimGray" Width="100%">
							<asp:ListItem Value="N" Selected="True">Normal</asp:ListItem>
							<asp:ListItem Value="U">Urgent</asp:ListItem>
							<asp:ListItem Value="V">VIP</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD style="HEIGHT: 30px" align="center" colSpan="2"><asp:radiobuttonlist id="RdoIOP" tabIndex="3" runat="server" Font-Size="Small" RepeatDirection="Horizontal"
							Height="100%" BorderWidth="1px" AutoPostBack="True" BorderColor="DimGray" Width="100%" onselectedindexchanged="RdoIOP_SelectedIndexChanged">
							<asp:ListItem Value="I">Indoor</asp:ListItem>
							<asp:ListItem Value="O" Selected="True">Outdoor</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD colSpan="6"></TD>
				</TR>
				<%if(this.RdoEntitled.SelectedItem.Value == "E")
				{
				%>
				<TR>
					<TD class="header" colSpan="6"><FONT size="2"><B><U>Employee Info</U></B></FONT></TD>
				</TR>
				<TR>
					<TD>Organization:</TD>
					<TD><asp:dropdownlist id="CmbPanel" tabIndex="4" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="CmbPanel_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Unit:&nbsp;&nbsp;
					</TD>
					<TD>
						<asp:textbox id="txtUnit" tabIndex="6" runat="server" Width="100%" CssClass="field"></asp:textbox></TD>
					<TD></TD>
					<TD>
						<asp:dropdownlist id="CmbUnit" tabIndex="5" runat="server" Width="100%" Enabled="False" Visible="False"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD width="15%">Service&nbsp;No:</TD>
					<TD width="18%"><asp:textbox id="TxtPLNo" tabIndex="7" runat="server" ToolTip="Enter Employee Service No" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right" width="15%">Rank: &nbsp;</TD>
					<TD width="18%">
						<asp:textbox id="txtRank" tabIndex="9" runat="server" Width="100%" CssClass="field" ontextchanged="txtRank_TextChanged"></asp:textbox></TD>
					<TD width="15%"></TD>
					<TD width="19%">
						<asp:dropdownlist id="CmbRank" tabIndex="8" runat="server" Width="100%" AutoPostBack="True" Enabled="False"
							Visible="False"></asp:dropdownlist></TD>
				<TR>
				<TR>
					<TD width="15%">Name (F-M-L):</TD>
					<TD width="18%" colSpan="2"><asp:dropdownlist id="CmbTitle" tabIndex="11" runat="server" Width="20%">
							<asp:ListItem Value="Mr" Selected="True">Mr.</asp:ListItem>
							<asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
							<asp:ListItem Value="Miss">Miss.</asp:ListItem>
						</asp:dropdownlist><asp:textbox id="TxtEFName" tabIndex="12" runat="server" ToolTip="Enter Employee First Name"
							Width="75%" CssClass="field"></asp:textbox></TD>
					<TD width="18%"><asp:textbox id="TxtEMName" tabIndex="13" runat="server" ToolTip="Enter Employee Middle Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="15%"><asp:textbox id="TxtELName" tabIndex="14" runat="server" ToolTip="Enter Employee Last Name" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD width="19%"></TD>
				<TR>
					<TD>Office Phone:</TD>
					<TD><asp:textbox id="txtOfficePhone" tabIndex="15" runat="server" ToolTip="Enter Office Phone Number"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD align="right">&nbsp;&nbsp;Mobile No:&nbsp;&nbsp;</TD>
					<TD align="right"><asp:textbox id="txtMobileNo" tabIndex="16" runat="server" ToolTip="Enter Mobile Number" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right">Email:&nbsp;&nbsp;</TD>
					<TD align="right"><asp:textbox id="txtEmail" tabIndex="17" runat="server" ToolTip="Enter Email Address" Width="100%"
							CssClass="field"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Home Phone:</TD>
					<TD><asp:textbox id="TxtHPhone" tabIndex="18" runat="server" ToolTip="Enter Mobile #" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right">Address:&nbsp;&nbsp;
					</TD>
					<TD align="right" colSpan="3"><asp:textbox id="TxtAddress" tabIndex="19" runat="server" ToolTip="Enter Address" Width="100%"
							CssClass="field"></asp:textbox></TD>
				</TR>
				<%}%>
				<!--\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\-->
				<%if(this.RdoEntitled.SelectedItem.Value == "P")
				{
				%>
				<TR>
					<TD class="header" colSpan="6"><FONT size="2"><B><U>Employee Info</U></B></FONT></TD>
				</TR>
				<TR>
					<TD>Organization:</TD>
					<TD><asp:dropdownlist id="CmbPanelP" tabIndex="4" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Reference No:&nbsp;&nbsp;
					</TD>
					<TD><asp:textbox id="txtReferenceNoP" tabIndex="7" runat="server" ToolTip="Enter Employee Service No"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD>&nbsp;&nbsp; Service&nbsp;No:&nbsp;</TD>
					<TD><asp:textbox id="TxtPLNoP" tabIndex="7" runat="server" ToolTip="Enter Employee Service No" Width="100%"
							CssClass="field"></asp:textbox></TD>
				</TR>
				<TR>
					<TD width="15%">Name (F-M-L):</TD>
					<TD width="18%" colSpan="2"><asp:dropdownlist id="cmbTitleP" tabIndex="11" runat="server" Width="20%">
							<asp:ListItem Value="Mr" Selected="True">Mr.</asp:ListItem>
							<asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
							<asp:ListItem Value="Miss">Miss.</asp:ListItem>
						</asp:dropdownlist><asp:textbox id="TxtEFNameP" tabIndex="12" runat="server" ToolTip="Enter Employee First Name"
							Width="75%" CssClass="field"></asp:textbox></TD>
					<TD width="18%"><asp:textbox id="TxtEMNameP" tabIndex="13" runat="server" ToolTip="Enter Employee Middle Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="15%"><asp:textbox id="TxtELNameP" tabIndex="14" runat="server" ToolTip="Enter Employee Last Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD width="19%"></TD>
				<TR>
					<TD>Office Phone:</TD>
					<TD><asp:textbox id="txtOfficePhoneP" tabIndex="15" runat="server" ToolTip="Enter Office Phone Number"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD align="right">&nbsp;&nbsp;Mobile No:&nbsp;&nbsp;</TD>
					<TD align="right"><asp:textbox id="txtMobileNoP" tabIndex="16" runat="server" ToolTip="Enter Mobile Number" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right">Email:&nbsp;&nbsp;</TD>
					<TD align="right"><asp:textbox id="txtEmailP" tabIndex="17" runat="server" ToolTip="Enter Email Address" Width="100%"
							CssClass="field"></asp:textbox></TD>
				</TR>
				<TR>
					<TD>Home Phone:</TD>
					<TD><asp:textbox id="TxtHPhoneP" tabIndex="18" runat="server" ToolTip="Enter Mobile #" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right">Address:&nbsp;&nbsp;
					</TD>
					<TD align="right" colSpan="3"><asp:textbox id="TxtAddressP" tabIndex="19" runat="server" ToolTip="Enter Address" Width="100%"
							CssClass="field"></asp:textbox></TD>
				</TR>
				<%}%>
				<!--\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\-->
				<TR>
					<TD class="header" colSpan="6"><FONT size="2"><B><U>Patient Info</U></B></FONT></TD>
					<!-- 
					<TD align="right" colSpan="3">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="center">|</TD>
								<TD align="center"><asp:linkbutton id="lbtnSearch" tabIndex="17" runat="server" ForeColor="Blue" Font-Size="X-Small"
										ToolTip="Click to search Registered Entitled &amp; Non-Entitiled Patient" Visible="False">Search Patient</asp:linkbutton></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
					</TD>
					--></TR>
				<TR>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value != "C")	{	%>
						Relations:
						<% } %>
					</TD>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value != "C")	{	%>
						<asp:dropdownlist id="CmbRelationShip2" tabIndex="20" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="CmbRelationShip2_SelectedIndexChanged"></asp:dropdownlist>
						<% } %>
					</TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>Name (F-M-L):</TD>
					<TD><asp:dropdownlist id="ddlPTitle" tabIndex="21" runat="server" Width="100%">
							<asp:ListItem Value="Mr" Selected="True">Mr.</asp:ListItem>
							<asp:ListItem Value="Miss">Miss.</asp:ListItem>
							<asp:ListItem Value="Mrs">Mrs.</asp:ListItem>
							<asp:ListItem Value="Baby">Baby</asp:ListItem>
							<asp:ListItem Value="Baby of ">Baby of </asp:ListItem>
							<asp:ListItem Value="Master">Master</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD><asp:textbox id="TxtPFName" tabIndex="22" runat="server" ToolTip="Enter Patient First Name" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD><asp:textbox id="TxtPMName" tabIndex="23" runat="server" ToolTip="Enter Patient Middle Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<TD><asp:textbox id="TxtPLName" tabIndex="24" runat="server" ToolTip="Enter Patient Last Name" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value == "C")	{	%>
						Relations:
						<% } %>
					</TD>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value == "C")	{	%>
						<asp:dropdownlist id="CmbRelationShip" tabIndex="25" runat="server" AutoPostBack="True" Width="100%" onselectedindexchanged="CmbRelationShip_SelectedIndexChanged_1"></asp:dropdownlist>
						<% } %>
					</TD>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value == "C")	{	%>
						<asp:textbox id="txtKinFName" tabIndex="26" runat="server" ToolTip="Enter Patient First Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<% } %>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value == "C")	{	%>
						<asp:textbox id="txtKinMName" tabIndex="27" runat="server" ToolTip="Enter Patient Middle Name"
							Width="100%" CssClass="field"></asp:textbox></TD>
					<% } %>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value == "C")	{	%>
						<asp:textbox id="txtKinLName" tabIndex="28" runat="server" ToolTip="Enter Patient Last Name"
							Width="100%" CssClass="field"></asp:textbox>
					<TD>
						<% } %>
					</TD>
				</TR>
				<TR>
					<TD>Gender:</TD>
					<TD><asp:dropdownlist id="CmbGender" tabIndex="29" runat="server">
							<asp:ListItem Value="Male" Selected="True">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right">DOB: <FONT color="red">(dd/mm/yyyy)&nbsp;&nbsp;</FONT></TD>
					<TD><asp:textbox id="TxtDOB" onblur="SetAge()" onkeyup="formatDate(this)" tabIndex="30" runat="server"
							ToolTip="Enter DOB" Width="70px" CssClass="field"></asp:textbox></TD>
					<TD align="right">Age:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="TxtAge" tabIndex="31" runat="server" ToolTip="Enter Age" Width="30px" CssClass="field"></asp:textbox>&nbsp;&nbsp;
						<asp:dropdownlist id="CmbAgeType" tabIndex="32" runat="server">
							<asp:ListItem Value="Y" Selected="True">Year(s)</asp:ListItem>
							<asp:ListItem Value="M">Month(s)</asp:ListItem>
							<asp:ListItem Value="W">Week(s)</asp:ListItem>
							<asp:ListItem Value="D">Day(s)</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD class="header" colSpan="6"><FONT size="2"><B><U>Test Info</U></B></FONT></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 22px">Result Dispatch:</TD>
					<TD style="HEIGHT: 22px"><asp:dropdownlist id="CmbResultDespatch" tabIndex="33" runat="server"></asp:dropdownlist></TD>
					<TD style="HEIGHT: 22px" align="right">
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						Request No:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD style="HEIGHT: 22px">
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						<asp:textbox id="TxtRequestNo" tabIndex="34" runat="server" ToolTip="Enter Request No" Width="100%"
							CssClass="field"></asp:textbox>
						<%	}	%>
					</TD>
					<TD style="HEIGHT: 22px" align="right">
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						Payment Mode:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD style="HEIGHT: 22px">
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						<asp:dropdownlist id="CmbPaymentMode" tabIndex="35" runat="server"></asp:dropdownlist>
						<%	}	%>
					</TD>
				</TR>
				<TR>
					<TD>
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						Ward No:
						<%	}	%>
					</TD>
					<TD>
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						<asp:dropdownlist id="ddlWard" tabIndex="36" runat="server" Width="100%"></asp:dropdownlist>
						<%	}	%>
					</TD>
					<TD align="right">
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						Admission Date:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD>
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						<asp:textbox id="TxtAdmDate" onkeyup="formatDate(this)" tabIndex="37" runat="server" ToolTip="Enter Admission Date"
							Width="70px" CssClass="field"></asp:textbox>
						<%	}	%>
					</TD>
					<TD align="right">
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						Discount %:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						<asp:dropdownlist id="ddlDiscountLevel" tabIndex="38" runat="server" AutoPostBack="True" Width="75%" onselectedindexchanged="ddlDiscountLevel_SelectedIndexChanged"></asp:dropdownlist><asp:textbox id="TxtDiscountPer" tabIndex="39" runat="server" ToolTip="Enter Discount (%)" Font-Size="Medium"
							Width="20%" CssClass="field" Enabled="False"></asp:textbox>
						<%	}	%>
					</TD>
				</TR>
				<TR>
					<TD>
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						Patient Adm No:
						<%	}	%>
					</TD>
					<TD>
						<%if(RdoIOP.SelectedItem.Value == "I")	{	%>
						<asp:textbox id="TxtPatientNo" tabIndex="40" runat="server" ToolTip="Enter Patient ID" Width="100%"
							CssClass="field"></asp:textbox>
						<%	}	%>
					</TD>
					<TD colSpan="2"></TD>
					<TD align="right">
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						Total Amount:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD>
						<%if(this.RdoEntitled.SelectedItem.Value != "E")	{	%>
						<asp:textbox id="TxtAmount" tabIndex="41" runat="server" ToolTip="Total Amount " Font-Size="Medium"
							Width="100%" CssClass="field" Enabled="False" Font-Bold="True"></asp:textbox>
						<%	}	%>
					</TD>
				</TR>
				<TR>
					<TD>
						<P>Referred By:</P>
					</TD>
					<TD colSpan="3"><asp:textbox id="txtReferredBy" tabIndex="42" runat="server" ToolTip="Enter Patient ID" Width="100%"
							CssClass="field"></asp:textbox></TD>
					<TD align="right">
						<%if ((this.RdoEntitled.SelectedItem.Value == "C") && (this.RdoIOP.SelectedItem.Value == "O"))	{	%>
						Paid Amount:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD>
						<%if ((this.RdoEntitled.SelectedItem.Value == "C") && (this.RdoIOP.SelectedItem.Value == "O"))	{	%>
						<asp:textbox id="txtPaidAmount" tabIndex="43" runat="server" ToolTip="Enter Payment" Font-Size="Medium"
							Width="100%" CssClass="field"></asp:textbox>
						<%	}	%>
					</TD>
				</TR>
				<TR>
					<TD>|&nbsp;<asp:linkbutton id="ButSelectedTest" tabIndex="44" runat="server" ToolTip="Click to Select Tests"
							Font-Size="X-Small" ForeColor="Blue" onclick="ButSelectedTest_Click">Select Test(s)</asp:linkbutton>&nbsp;|</TD>
					<TD></TD>
					<TD></TD>
					<TD><asp:label id="LblNoTest" runat="server" Width="100%" Visible="False"></asp:label></TD>
					<TD align="right">
						<%if ((this.RdoEntitled.SelectedItem.Value == "C") && (this.RdoIOP.SelectedItem.Value == "O"))	{	%>
						Paid No:&nbsp;&nbsp;
						<%	}	%>
					</TD>
					<TD>
						<%if ((this.RdoEntitled.SelectedItem.Value == "C") && (this.RdoIOP.SelectedItem.Value == "O"))	{	%>
						<asp:textbox id="txtPaidNo" tabIndex="43" runat="server" Font-Size="Medium" ToolTip="Enter Payment"
							Width="100%" CssClass="field"></asp:textbox>
						<%	}	%>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" colSpan="6"><asp:datagrid id="DGSelectedTest" tabIndex="43" runat="server" BorderColor="Silver" Width="100%"
							DESIGNTIMEDRAGDROP="164" AutoGenerateColumns="False" AllowSorting="True">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="sno" HeaderText="S. #.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Section" HeaderText="Sub-Department">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestGroup" HeaderText="Test Group">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Times" HeaderText="Time">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestName" HeaderText="Test Name">
									<HeaderStyle Width="34%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Charges" HeaderText="Charges">
									<HeaderStyle HorizontalAlign="Right" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Delivery" HeaderText="Delivery">
									<HeaderStyle HorizontalAlign="Center" Width="8%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" HeaderText="Test ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SectionID" HeaderText="Section ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestGroupID" HeaderText="TestGroupID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestBatchNo" HeaderText="TestBatchNo"></asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="screenid" vAlign="top" align="right" width="100%" colSpan="6">HMS_LM_IN_006</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
	</body>
</HTML>
