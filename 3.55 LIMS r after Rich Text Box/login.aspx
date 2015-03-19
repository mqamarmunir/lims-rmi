<%@ Page language="c#" Inherits="HMIS.login" CodeFile="login.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0" onload=javascript:document.Form1.txtlogin.focus();>
		<form id="Form1" method="post" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="1004" border="0">
				<TR vAlign="top">
					<TD><IMG height="7" alt="" src="images/images_01.jpg" width="230"></TD>
					<TD colSpan="5"><IMG height="7" alt="" src="images/images_02.jpg" width="774"></TD>
				</TR>
				<TR vAlign="top">
					<TD><IMG height="50" alt="" src="images/images_07.jpg" width="230"></TD>
					<TD rowSpan="2">&nbsp;
					</TD>
					<TD vAlign="bottom" rowSpan="2"><IMG height="19" alt="" src="images/images_15.jpg" width="18"></TD>
					<TD><IMG height="50" alt="" src="images/images_10.jpg" width="130"></TD>
					<TD><IMG height="50" alt="" src="images/images_11.jpg" width="306"></TD>
					<TD><IMG height="50" alt="" src="images/images_12.jpg" width="310"></TD>
				</TR>
				<TR vAlign="top">
					<TD><IMG height="18" alt="" src="images/images_13.jpg" width="230"></TD>
					<TD bgColor="#324a9d" colSpan="3">&nbsp;</TD>
				</TR>
				<TR vAlign="top">
					<TD><IMG height="170" alt="" src="images/images_19.jpg" width="230"></TD>
					<TD><IMG height="170" alt="" src="images/images_20.jpg" width="10"></TD>
					<TD><IMG height="170" alt="" src="images/images_21.jpg" width="18"></TD>
					<TD><IMG height="170" alt="" src="images/images_22.jpg" width="130"></TD>
					<TD><IMG height="170" alt="" src="images/images_23.jpg" width="306"></TD>
					<TD><IMG height="170" alt="" src="images/images_24.jpg" width="310"></TD>
				</TR>
				<TR vAlign="top">
					<TD colSpan="6" height="287">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr vAlign="top">
								<td width="37%" height="306">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top"><IMG height="47" src="images/what_is_image.jpg" width="189"></td>
										</tr>
										<tr>
											<td vAlign="top"><font face="Verdana, Arial, Helvetica, sans-serif" size="2">&nbsp;&nbsp;Haisam 
													is an enterprise hospital management product &nbsp;&nbsp;line of Trees. Hisam 
													empowers hospitals to manage &nbsp;&nbsp;information internally and with 
													outside stakeholders.
													<br>
													<br>
												</font>
											</td>
										</tr>
										<tr>
											<td vAlign="top"><IMG height="42" src="images/haisam_laboratory_image.jpg" width="225"></td>
										</tr>
										<tr>
											<td vAlign="top">
											</td>
										</tr>
										<tr>
											<td vAlign="top">&nbsp;</td>
										</tr>
									</table>
								</td>
								<td width="4%"><IMG height="306" src="images/line_image.jpg" width="46"></td>
								<td width="40%">&nbsp;</td>
								<td width="19%" bgColor="#eaedf5">
									<table cellSpacing="0" cellPadding="0" width="88%" border="0">
										<tr>
											<td vAlign="top">
												<table height="88" cellSpacing="2" cellPadding="2" width="99%" border="0" id="tbLogin">
													<tr vAlign="top">
														<td width="25%" height="26"><font face="Verdana, Arial, Helvetica, sans-serif" color="#003366" size="1">Shift:</font></td>
														<td width="75%" id="TD1">
															<DIV align="right">
																<asp:DropDownList id="ddlShift" runat="server" Width="100%">
																	<asp:ListItem Value="Morning" Selected="True">Morning</asp:ListItem>
																	<asp:ListItem Value="Evening">Evening</asp:ListItem>
																	<asp:ListItem Value="Night">Night</asp:ListItem>
																</asp:DropDownList>
															</DIV>
														</td>
													</tr>
													<tr vAlign="top">
														<td width="25%" height="26"><font face="Verdana, Arial, Helvetica, sans-serif" color="#003366" size="1">Login:</font></td>
														<td width="75%">
															<asp:textbox id="txtlogin"  tabIndex="5" MaxLength="10" Width="100%" Font-Size="X-Small" runat="server"></asp:textbox></td>
													</tr>
													<tr vAlign="top">
														<td vAlign="middle" height="27" style="HEIGHT: 27px"><font face="Verdana, Arial, Helvetica, sans-serif" color="#003366" size="1">Pwd:</font></td>
														<td style="HEIGHT: 27px">
															<asp:textbox id="txtpassword" tabIndex="5" MaxLength="10" Width="100%" Font-Size="X-Small" runat="server"
																TextMode="Password"></asp:textbox></td>
													</tr>
													<tr vAlign="top">
														<td vAlign="middle" height="28">&nbsp;</td>
														<td>
															<asp:ImageButton id="ibtnLogin" runat="server" ImageUrl="images/button1.gif" height="20" BorderWidth="0"
																ImageAlign="Middle" OnClick="ibtnLogin_Click"></asp:ImageButton></td>
													</tr>
												</table>
												<asp:Label id="lblErrMsg" Width="100%" Font-Size="X-Small" Runat="server" ForeColor="Red"></asp:Label></td>
										</tr>
										<tr>
											<td vAlign="top"><IMG height="20" src="images/line1_image.jpg" width="184"></td>
										</tr>
										<tr>
											<td vAlign="top"><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><br>
													&nbsp;<strong>&nbsp;Haisam</strong><font size="1"> Hospital</font> <font size="1">Management
														<br>
														&nbsp;&nbsp;&nbsp;Product Line. </font></font>
											</td>
										</tr>
										<tr>
											<td vAlign="top"><font face="Verdana, Arial, Helvetica, sans-serif" size="3"><strong><font color="#003366" size="2">&nbsp;&nbsp;Trees 
															Software pvt ltd</font></strong></font><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><br>
													&nbsp;&nbsp;Legal and HealthCare
													<br>
													&nbsp;&nbsp;Automation Consultants</font></td>
										</tr>
										<tr>
											<td vAlign="bottom" align="right"><font face="Verdana, Arial, Helvetica, sans-serif" size="1">
                                                Version:3.3.0
                                                <br />
                                                Dated:May 05, 2014</font></td>
										</tr>
										<tr>
											<td vAlign="top">
												<div align="right"><font face="Verdana, Arial, Helvetica, sans-serif" color="#003366" size="1">www.treesvalley.com<br />
														GetToTrees@treesvalley.com</font></div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr vAlign="top" bgColor="#324a9d">
								<td colSpan="4" height="19">
									<div align="right"><IMG height="21" src="images/haisam_footer.jpg" width="77"></div>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</BODY>
</HTML>
