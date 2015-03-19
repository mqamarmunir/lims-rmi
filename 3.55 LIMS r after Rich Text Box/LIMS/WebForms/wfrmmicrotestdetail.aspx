<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmMicroTestDetail" CodeFile="wfrmMicroTestDetail.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Micro Test Result:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0" runat="server">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><FONT size="4"><U><asp:label id="lblHeading" runat="server">Label</asp:label></U></FONT></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;
						<asp:checkbox id="CheckBox1" runat="server" Text="11"></asp:checkbox><asp:dropdownlist id="DropDownList1" runat="server"></asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Rec-ID:</TD>
					<TD width="30%"><asp:label id="lblReceptionID" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Priority:</TD>
					<TD width="40%"><asp:label id="lblPriority" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="10%">Name:</TD>
					<TD width="30%"><asp:label id="lblName" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Type:</TD>
					<TD width="40%"><asp:label id="lblType" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Age/Sex:&nbsp;&nbsp;</TD>
					<TD width="30%"><asp:label id="lblAgeSex" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">1252</TD>
					<TD width="40%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD><asp:linkbutton id="LinkButton3" runat="server" Visible="False" onclick="LinkButton3_Click">LinkButton</asp:linkbutton></TD>
					<TD align="center" colSpan="3">|
						<asp:linkbutton id="lbtnPatientTestDetail" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnPatientTestDetail_Click">Detail</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnNextPatient" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnNextPatient_Click">Next Patient</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnClose" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnClose_Click">Close</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnAddTest" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lbtnAddTest_Click">Add/Delete Test</asp:linkbutton>&nbsp;|</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgTest" runat="server" Width="100%" BorderColor="Silver" AllowSorting="True"
							AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img border=0 src=Update.gif&gt;" CancelText="&lt;img border=0 src=Cancel.gif&gt;"
									EditText="&lt;img border=0 src=Edit.gif&gt;">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="45%"></HeaderStyle>
									<HeaderTemplate>
										<asp:label id="Label10" runat="server" Width="100%">Test</asp:label>
										<asp:label id="Label9" runat="server" Width="100%">Result</asp:label>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:label id=Label11 runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Test")  %>' Font-Bold="True" Width="100%">
										</asp:label>
										<HR>
										<asp:datagrid id=Datagrid2 runat="server" Width="100%" AutoGenerateColumns="False" DataSource='<%# DisplayAttribute((string)DataBinder.Eval(Container.DataItem, "DSerialNo").ToString()) %>'>
											<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AttributeID" SortExpression="AttributeID" ReadOnly="True"
													HeaderText="AttributeID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True" HeaderText="Attribute">
													<HeaderStyle Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Result" SortExpression="Result" ReadOnly="True" HeaderText="Result">
													<HeaderStyle Width="20%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RUnit" SortExpression="RUnit" HeaderText="Unit">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MinRange" SortExpression="MinRange" HeaderText="Min">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MaxRange" SortExpression="MaxRange" ReadOnly="True" HeaderText="Max">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<P>
											<asp:CheckBox id=chkSensitivityIT runat="server" Text="Sensitivity" Visible="<%# Microbiology1Test() %>" OnCheckedChanged="chkSensitivity_CheckedChanged" Enabled="false" AutoPostBack="True">
											</asp:CheckBox></P>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:label id=dglblTestIT runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Test")  %>' Font-Bold="True" Width="100%">
										</asp:label>
										<HR>
										<asp:datagrid id=Datagrid1 runat="server" Width="100%" AutoGenerateColumns="False" DataSource='<%# DisplayAttribute((string)DataBinder.Eval(Container.DataItem, "DSerialNo").ToString()) %>'>
											<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="AttributeID" SortExpression="AttributeID" ReadOnly="True"
													HeaderText="AttributeID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True" HeaderText="Attribute">
													<HeaderStyle Width="30%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="Result">
													<HeaderStyle Width="30%"></HeaderStyle>
													<ItemTemplate>
														<asp:TextBox id=dgAttributeResult runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem, "Result")  %>'>
														</asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="RUnit" SortExpression="RUnit" HeaderText="Unit">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MinRange" SortExpression="MinRange" HeaderText="Min">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="MaxRange" SortExpression="MaxRange" ReadOnly="True" HeaderText="Max">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
										</asp:datagrid>
										<P>
											<asp:CheckBox id=chkSensitivityET runat="server" Text="Sensitivity" Visible="<%# Microbiology1Test() %>" OnCheckedChanged="chkSensitivity_CheckedChanged" AutoPostBack="True">
											</asp:CheckBox></P>
										<P>
											<asp:datagrid id="dgDrugET" runat="server" Width="100%" AutoGenerateColumns="False">
												<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
												<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
												<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True">
														<HeaderStyle Width="30%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Drug" SortExpression="Drug" HeaderText="Drug">
														<HeaderStyle Width="70%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Result" HeaderText="Result"></asp:BoundColumn>
												</Columns>
												<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemTemplate>
										<P>
											<asp:Label id="Label3" runat="server" Font-Bold="True">Forward to</asp:Label>:
											<asp:dropdownlist id=dgddlForwardtoIT runat="server" Width="100%" DataSource='<%# FillDDLForwardTo(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>' Enabled="False" DataValueField="ProcessID" DataTextField="Process" SelectedIndex='<%# GetForwardIndex((string)DataBinder.Eval(Container.DataItem, "ProcessID")) %>'>
											</asp:dropdownlist></P>
										<P>
											<asp:Label id="Label1" runat="server" Font-Bold="True" Width="100%">Opinion:</asp:Label>
											<asp:Label id=dglblOpinionET runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>' Width="100%">
											</asp:Label></P>
										<P>
											<asp:Label id="Label2" runat="server" Font-Bold="True" Width="100%">Comment:</asp:Label>
											<asp:Label id=dglblCommentET runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>' Width="100%">
											</asp:Label></P>
									</ItemTemplate>
									<EditItemTemplate>
										<P>
											<asp:Label id="Label4" runat="server" Font-Bold="True">Forward to</asp:Label>
											<asp:dropdownlist id=dgddlForwardtoET runat="server" Width="100%" DataSource='<%# FillDDLForwardTo(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>' DataValueField="ProcessID" DataTextField="Process" SelectedIndex='<%# GetForwardIndex((string)DataBinder.Eval(Container.DataItem, "ProcessID")) %>'>
											</asp:dropdownlist></P>
										<P>
											<asp:Label id="Label7" runat="server" Font-Bold="True" Width="100%">Opinion:</asp:Label>
											<asp:textbox id=dgtxtOpinionET runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>' Width="94%" MaxLength="255" Height="45px">
											</asp:textbox>
											<asp:linkbutton id="Linkbutton2" onclick="LinkButton2_Click" runat="server" Width="5%"><></asp:linkbutton></P>
										<P>
											<asp:Label id="Label8" runat="server" Font-Bold="True" Width="100%">Comment:</asp:Label>
											<asp:textbox id=dgtxtCommentET runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>' Width="94%" MaxLength="255" Height="45px">
											</asp:textbox>
											<asp:linkbutton id="Linkbutton1" onclick="Linkbutton1_Click" runat="server" Width="5%"><></asp:linkbutton></P>
										<P>-------------------------------------------------------------------------</P>
										<P>
											<asp:dropdownlist id=ddlOrganism runat="server" Width="100%" DataSource="<%# FillDDLOrganism() %>" AutoPostBack="True" DataValueField="OrganismID" DataTextField="Organism" OnSelectedIndexChanged="ddlOrganism_SelectedIndexChanged">
											</asp:dropdownlist></P>
										<P>
											<asp:datagrid id="dgDrugsSource" runat="server" Width="100%" AutoGenerateColumns="False">
												<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
												<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
												<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True"></asp:BoundColumn>
													<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True">
														<HeaderStyle Width="30%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Drug" SortExpression="Drug" HeaderText="Drug">
														<HeaderStyle Width="70%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Result">
														<HeaderStyle Width="30%"></HeaderStyle>
														<ItemTemplate>
															<asp:DropDownList id="ddlsensitivity" runat="server" Width="100%">
																<asp:ListItem Value="None" Selected="True">None</asp:ListItem>
																<asp:ListItem Value="Resistant">Resistant</asp:ListItem>
																<asp:ListItem Value="Intermediate">Intermediate</asp:ListItem>
																<asp:ListItem Value="Sensitive">Sensitive</asp:ListItem>
															</asp:DropDownList>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
											</asp:datagrid></P>
										<P>&nbsp;
											<asp:LinkButton id="lbtnAddET" onclick="lbtnAdd_Click" runat="server">Add</asp:LinkButton></P>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_009</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
