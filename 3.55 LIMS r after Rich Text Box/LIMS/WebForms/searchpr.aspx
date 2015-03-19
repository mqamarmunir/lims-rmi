<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.SearchPR" CodeFile="SearchPR.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient Search</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="center" colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><u>Search Patient</u></font></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Font-Size="X-Small" ForeColor="Red" Width="100%"></asp:label></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Organization:&nbsp;&nbsp;</TD>
					<TD width="35%"><asp:dropdownlist id="ddlOrganization" tabIndex="1" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlOrganization_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right" width="10%">Service No:&nbsp;&nbsp;</TD>
					<TD width="35%"><asp:textbox id="txtPlNo" tabIndex="2" runat="server" Width="110px" ToolTip="Enter Employee Service No"
							MaxLength="10" CssClass="field"></asp:textbox></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Factory:</TD>
					<TD><asp:dropdownlist id="ddlFactory" tabIndex="3" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlFactory_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Name:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtName" tabIndex="4" runat="server" Width="100%" ToolTip="Enter Patient Name"
							MaxLength="69" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Section:</TD>
					<TD><asp:dropdownlist id="ddlSection" tabIndex="5" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">F/H Name:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtFHName" tabIndex="6" runat="server" Width="100%" ToolTip="Enter Employee Father or Husband Name"
							MaxLength="50" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Rank:</TD>
					<TD><asp:dropdownlist id="ddlRank" tabIndex="7" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right">Patient ID:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtPatientID" tabIndex="8" runat="server" Width="120px" ToolTip="Enter Patient's Hospital generated Patient ID"
							MaxLength="11" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sex:</TD>
					<TD><asp:dropdownlist id="ddlSex" tabIndex="9" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="M">Male</asp:ListItem>
							<asp:ListItem Value="F">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right">NIC No:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtNIC" tabIndex="10" runat="server" Width="210px" ToolTip="Enter Patient NIC No"
							MaxLength="20" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Blood Group:</TD>
					<TD><asp:dropdownlist id="ddlBloodGroup" tabIndex="11" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="A-">A-</asp:ListItem>
							<asp:ListItem Value="A+">A+</asp:ListItem>
							<asp:ListItem Value="AB-">AB-</asp:ListItem>
							<asp:ListItem Value="AB+">AB+</asp:ListItem>
							<asp:ListItem Value="B-">B-</asp:ListItem>
							<asp:ListItem Value="B+">B+</asp:ListItem>
							<asp:ListItem Value="O-">O-</asp:ListItem>
							<asp:ListItem Value="O+">O+</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right">Phone No:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtPhoneNo" tabIndex="12" runat="server" Width="160px" ToolTip="Enter Phone No"
							MaxLength="15" CssClass="field"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Address:</TD>
					<TD colSpan="3"><asp:textbox id="txtAddress" tabIndex="13" runat="server" Width="100%" ToolTip="Enter Temporary Address"
							MaxLength="255" CssClass="field" TextMode="MultiLine" Rows="2"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD></TD>
					<TD align="right"><asp:button id="btnSearch" tabIndex="14" runat="server" ForeColor="Black" BackColor="Silver"
							Text="Search" onclick="btnSearch_Click"></asp:button></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgSearch" tabIndex="4" runat="server" Width="100%" BorderColor="Silver" AllowSorting="True"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Select">
									<HeaderStyle Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:BoundColumn DataField="PName" SortExpression="PName" ReadOnly="True" HeaderText="Name">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Relation" SortExpression="Relation" ReadOnly="True" HeaderText="Relation">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Sex" SortExpression="Sex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="BloodGroup" ReadOnly="True" HeaderText="BG">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientID" SortExpression="PatientID" ReadOnly="True" HeaderText="Patient ID">
									<HeaderStyle HorizontalAlign="Center" Width="11%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PLNo" ReadOnly="True" HeaderText="Service No">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NIC" ReadOnly="True" HeaderText="NIC No">
									<HeaderStyle HorizontalAlign="Center" Width="13%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_024</TD>
				</TR>
			</TABLE>
		</form>
		<script language="javascript">
			if("<%=focusElement%>" != ""){
				document.all("<%=focusElement%>").focus();
			}
		</script>
	</body>
</HTML>
