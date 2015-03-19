<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmReport" CodeFile="wfrmReport.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.1 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Reports:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="javascript">
		function GetDate(clientID){
			window.open("calender.aspx?objName="+clientID+"&time=no", "_blank", "height=265, width=210'");
		}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="label">
				<TBODY>
					<TR>
						<TD colspan="8"><!--#include file="LimsHeader2.htm"--></TD>
					</TR>
					<TR>
						<TD colspan="8">
							<TABLE WIDTH="100%" BORDER="0" CELLPADDING="0" CELLSPACING="0">
								<TR>
									<TD align="left" colSpan="8">
										<asp:Label id="lblErrMsg" runat="server" ForeColor="Red"></asp:Label></TD>
								</TR>
								<TR>
									<TD colSpan="8" align="right" style="height: 15px">
                                        <asp:ImageButton ID="ibtnDisplayReport" runat="server" ImageUrl="images/btn_Display Report.GIF"
                                            OnClick="ibtnDisplayReport_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD colspan="6">
										<asp:RadioButtonList id="rdoReport" runat="server" Width="100%" RepeatColumns="3" AutoPostBack="True" onselectedindexchanged="rdoReport_SelectedIndexChanged">
											<asp:ListItem Value="0" Selected="True">Daily Patient Status</asp:ListItem>
											<asp:ListItem Value="1">Patient Cash Report (Indoor)</asp:ListItem>
											<asp:ListItem Value="2">Daily Test Summary</asp:ListItem>
											<asp:ListItem Value="3">Cash Report (By Cashier)</asp:ListItem>
											<asp:ListItem Value="4">Master Test List - I</asp:ListItem>
                                            <asp:ListItem Value="5">Master Test List - II</asp:ListItem>
                                            <asp:ListItem Value="6">External Test Summary</asp:ListItem>
										</asp:RadioButtonList></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD colspan="6">
										<asp:DataGrid id="dgDepartment" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
											BorderColor="Silver" PageSize="25" AllowCustomPaging="True" CssClass="datagrid">
											<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn SortExpression="Active">
													<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
													<ItemTemplate>
														<asp:CheckBox id="dgchkActive" Runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="SectionID"></asp:BoundColumn>
												<asp:BoundColumn DataField="SectionName" ReadOnly="True" HeaderText="Department">
													<HeaderStyle Width="90%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" Mode="NumericPages"></PagerStyle>
										</asp:DataGrid></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px"></TD>
									<TD style="HEIGHT: 16px">
										<asp:Label id="Label1" runat="server" Width="100%">Shift:</asp:Label></TD>
									<TD colspan="2" style="HEIGHT: 16px">
										<asp:DropDownList id="ddlShift" runat="server">
											<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
											<asp:ListItem Value="Morning">Morning</asp:ListItem>
											<asp:ListItem Value="Evening">Evening</asp:ListItem>
											<asp:ListItem Value="Night">Night</asp:ListItem>
										</asp:DropDownList>&nbsp;</TD>
									<TD style="HEIGHT: 16px">
										<asp:Label id="lblPatientType" runat="server" Width="100%"> Patient Type:</asp:Label></TD>
									<TD align="left" colspan="2" style="HEIGHT: 16px">
										<asp:DropDownList id="ddlPatientType" runat="server" Width="136px">
											<asp:ListItem Value="A" Selected="True">All</asp:ListItem>
											<asp:ListItem Value="E">Entitled</asp:ListItem>
											<asp:ListItem Value="C">CNE</asp:ListItem>
											<asp:ListItem Value="P">Panel</asp:ListItem>
										</asp:DropDownList>
										<asp:DropDownList id="ddlIOPatient" runat="server" Width="136px">
											<asp:ListItem Value="A" Selected="True">All</asp:ListItem>
											<asp:ListItem Value="I">Indoor</asp:ListItem>
											<asp:ListItem Value="O">Outdoor</asp:ListItem>
										</asp:DropDownList></TD>
									<TD style="HEIGHT: 16px"></TD>
									<TD style="HEIGHT: 16px"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD width="10%">
										<asp:Label id="Label2" runat="server" Width="100%">From:</asp:Label></TD>
									<TD width="10%">
										<asp:TextBox id="txtDF" runat="server" Width="99%" CssClass="field"></asp:TextBox>
									</TD>
									<td width="25%">&nbsp;
									</td>
									<TD width="10%" align="right">
										<asp:Label id="Label3" runat="server" Width="100%">To:</asp:Label></TD>
									<TD width="10%">
										<asp:TextBox id="txtDT" runat="server" Width="99%" CssClass="field"></asp:TextBox>
									</TD>
									<td width="25%">&nbsp;
									</td>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD width="10%">
										<asp:Label id="lblAdminNo" runat="server" Width="100%">A & D No:</asp:Label></TD>
									<TD width="10%">
										<asp:TextBox id="txtAdminNo" runat="server" Width="99%" CssClass="field"></asp:TextBox>
									</TD>
									<td width="25%">&nbsp;
										<asp:Label id="lblAdminDate" runat="server">A & D Date:</asp:Label>&nbsp;
										<asp:TextBox id="txtAdminDate" runat="server" CssClass="field" Width="94px"></asp:TextBox>
									</td>
									<TD width="10%" align="right">
										<asp:Label id="lblName" runat="server" Width="100%"> Name:</asp:Label></TD>
									<TD colspan="2" width="10%">
										<asp:TextBox id="txtPatientName" runat="server" CssClass="field" Width="99%"></asp:TextBox>
									</TD>
									<TD width="5%"></TD>
								</TR>
                                	<TR>
									<TD width="5%"></TD>
									<TD width="10%">
										&nbsp;</TD>
									<TD width="10%">
										&nbsp;</TD>
									
									<TD width="10%" align="right" colspan=2>
										<asp:Label id="lblextorg" runat="server" Width="100%"> External Organization:</asp:Label></TD>
									<TD colspan="2" width="10%">
										<asp:DropDownList id="ddlextorg" runat="server" Width="136px">
											
										</asp:DropDownList>
									</TD>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD align="right" class="screenid" colspan="8">HMS_RD_IN_009</TD>
								</TR>
							</TABLE>
		
		</TD></TR></TBODY></TABLE></form>
	</body>
</HTML>
