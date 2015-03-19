<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmPatientTestStatus" CodeFile="wfrmPatientTestStatus.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient Test Status:    <% =Session["UNUIDFORMATTED"] %></title>
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
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>PATIENT TEST STATUS</STRONG></font></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" width="5%"></TD>
					<TD style="HEIGHT: 15px" width="10%">Lab-ID:</TD>
					<TD style="HEIGHT: 15px" width="30%">
						<asp:label id="lblLabID" runat="server" Width="100%">Label</asp:label></TD>
					<TD style="HEIGHT: 15px" width="10%"></TD>
					<TD style="HEIGHT: 15px" width="40%">
						<asp:label id="LblMSerialNo" runat="server" Width="100%" Visible="False">Label</asp:label></TD>
					<TD style="HEIGHT: 15px" width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Name:</TD>
					<TD colSpan="3"><asp:label id="LblPatientName" runat="server" Width="100%">Label</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Sex/Age:</TD>
					<TD width="30%"><asp:label id="LblAge" runat="server" Width="100%">Label</asp:label></TD>
					<TD width="10%"></TD>
					<TD width="40%" align="right">

                    <asp:TextBox ID="txtEmailID" CssClass="field" Width="50%" Visible="false" runat="server"></asp:TextBox>
                        <asp:linkbutton id="lnkbtnEmail" runat="server" Font-Size="X-Small" CommandName="EMail"  ForeColor="Blue" OnCommand="lbtn_EmailClick">E-Mail</asp:linkbutton>
                        &nbsp;| <asp:linkbutton id="lbtnViewResult" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnViewResult_Click">View Result</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnClose" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnClose_Click">Close</asp:linkbutton>
                        </TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="DGPatientStatus" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							BorderColor="Silver" CssClass="datagrid" CellPadding="4">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="testid" SortExpression="MSerialNo" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="SectionName" HeaderText="Sub-Department">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestGroup" ReadOnly="True" HeaderText="Test Group">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="40%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Process" ReadOnly="True" HeaderText="Status">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_016</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
