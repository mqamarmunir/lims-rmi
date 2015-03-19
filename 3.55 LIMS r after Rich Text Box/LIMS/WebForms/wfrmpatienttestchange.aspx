<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmPatientTestChange" CodeFile="wfrmPatientTestChange.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Patient Test Add/Delete:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="javascript">
			function FillForm(){
				location.href = "wfrmPatientTestChange.aspx";
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>PATIENT TEST CHANGES</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="8" align="right">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100" align="right" border="0">
							<TR>
								<TD align="center">|</TD>
								<TD align="center">
									<asp:LinkButton id="lbtnClose" tabIndex="1" runat="server" ForeColor="Blue" Font-Size="X-Small"
										ToolTip="Click to close window after addition or deletion of tests" onclick="lbtnClose_Click">Close</asp:LinkButton></TD>
								<TD align="center">|</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td width="3%"></td>
					<TD width="12%">
						Name:</TD>
					<TD width="32%"><asp:label id="LblPatientName" runat="server" Width="100%"></asp:label></TD>
					<TD align="right" width="10%">Priority:&nbsp;&nbsp;
					</TD>
					<TD width="15%"><asp:label id="LblPriority" runat="server" Width="100%"></asp:label></TD>
					<TD align="right" width="10%">Type:&nbsp;&nbsp;
					</TD>
					<TD width="15%"><asp:label id="LblType" runat="server" Width="100%"></asp:label></TD>
					<td width="3%"></td>
				</TR>
				<TR>
					<td></td>
					<TD>Sex:</TD>
					<TD><asp:label id="LblGender" runat="server" Width="100%"></asp:label></TD>
					<TD align="right">Age:&nbsp;&nbsp;
					</TD>
					<TD><asp:label id="LblAge" runat="server" Width="100%"></asp:label></TD>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD colSpan="8"><asp:label id="LblMessage" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="8"><asp:datagrid id="DGSelectedTest" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							DESIGNTIMEDRAGDROP="164" BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img border=0 src='update.gif'&gt;" CancelText="&lt;img border=0 src='cancel.gif'&gt;"
									EditText="&lt;img border=0 src='edit.gif'&gt;">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:TemplateColumn HeaderText="Test">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label id=LblTest runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Test") %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
										<P>Section:
											<asp:DropDownList id=ddlSection runat="server" Width="100%" DataSource="<%# FillDDLSection() %>" AutoPostBack="True" DataValueField="SectionID" DataTextField="SectionName" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
											</asp:DropDownList></P>
										<P>Test Group:
											<asp:DropDownList id="ddlTestGroup" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlTestGroup_SelectedIndexChanged"></asp:DropDownList></P>
										<P>Test:
											<asp:DropDownList id="ddlTest" runat="server" Width="100%"></asp:DropDownList></P>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Times" ReadOnly="True" HeaderText="Time">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Charges" ReadOnly="True" HeaderText="Charges">
									<HeaderStyle HorizontalAlign="Right" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DeliveryDate" ReadOnly="True" HeaderText="Delivery">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" HeaderText="Test ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SectionID" HeaderText="Section ID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestGroupID" HeaderText="TestGroupID"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestBatchNo" HeaderText="TestBatchNo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo"></asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="8">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="8">HMS_LM_IN_020</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
