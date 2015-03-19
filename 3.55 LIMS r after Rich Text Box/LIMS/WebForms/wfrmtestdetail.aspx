<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestDetail" CodeFile="wfrmTestDetail.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Detail:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="javascript">
			function RefreshPage()
			{
				location.href = "wfrmTestDetail.aspx?id=<%Response.Write(id);%>&ProcessID=<%Response.Write(ProcessID);%>&MSerialNos=<%Response.Write(sMSerialNos);%>&SectionID=<%Response.Write(SectionID);%>";
			}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"-->
						<asp:LinkButton id="LinkButton4" runat="server">LinkButton</asp:LinkButton></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><u><asp:label id="lblHeading" runat="server">Label</asp:label></u></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Rec-ID:</TD>
					<TD width="30%"><asp:label id="lblLabID" runat="server" Font-Bold="True" Width="100%">Label</asp:label></TD>
					<TD width="10%">Priority:</TD>
					<TD width="40%"><asp:label id="lblPriority" runat="server" Font-Bold="True" Width="100%">Label</asp:label></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="10%">Name:</TD>
					<TD width="30%"><asp:label id="lblName" runat="server" Font-Bold="True" Width="100%">Label</asp:label></TD>
					<TD width="10%">Type:</TD>
					<TD width="40%"><asp:label id="lblType" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Sex/Age:&nbsp;&nbsp;</TD>
					<TD width="30%"><asp:label id="lblAgeSex" runat="server" Font-Bold="True" Width="100%">Label</asp:label></TD>
					<TD width="10%">Ward:</TD>
					<TD width="40%"><asp:label id="lblWard" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:label id="lblMSerialNo" runat="server" Font-Bold="True" Width="100%">Label</asp:label></TD>
					<TD><asp:linkbutton id="LinkButton3" runat="server" Visible="False">LinkButton</asp:linkbutton></TD>
					<TD align="center" colSpan="3">|
						<asp:linkbutton id="lbtnPatientTestDetail" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnPatientTestDetail_Click">Detail</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnNextPatient" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnNextPatient_Click">Next Patient</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnClose" runat="server" Font-Size="X-Small" ForeColor="Blue" onclick="lbtnClose_Click">Close</asp:linkbutton>&nbsp;|
						<asp:linkbutton id="lbtnAddTest" runat="server" Visible="False" Font-Size="X-Small" ForeColor="Blue">Add/Delete Test</asp:linkbutton>&nbsp;|</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgTest" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="True"
							BorderColor="Black" CellSpacing="5" CellPadding="1" GridLines="Horizontal">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" BackColor="LemonChiffon"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="Save" CommandName="Save">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="95%"></HeaderStyle>
									<HeaderTemplate>
										<asp:label id="Label10" runat="server" Width="100%">Test</asp:label>
										<asp:label id="Label9" runat="server" Width="100%">Result</asp:label>
									</HeaderTemplate>
									<ItemTemplate>
										<P>
											<asp:label id=Label11 runat="server" Width="100%" Font-Bold="True" Text='<%# DataBinder.Eval(Container.DataItem, "Test")  %>'>
											</asp:label>
											<HR>
										<P></P>
										<P>
											<asp:datagrid id=Datagrid1 runat="server" Width="100%" AutoGenerateColumns="False" DataSource='<%# DisplayAttribute((string)DataBinder.Eval(Container.DataItem, "DSerialNo").ToString()) %>'>
												<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
												<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
												<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
												<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="AttributeID" SortExpression="AttributeID" ReadOnly="True"
														HeaderText="AttributeID"></asp:BoundColumn>
													<asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True" HeaderText="Attribute">
														<HeaderStyle Width="15%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="Result">
														<HeaderStyle Width="55%"></HeaderStyle>
														<ItemTemplate>
															<asp:TextBox id=dgAttributeResult runat="server" MaxLength="100" Textmode='<%# GetTextmode((string)DataBinder.Eval(Container.DataItem, "SMLine")) %>' Width="100%" Height="200%" Text='<%# DataBinder.Eval(Container.DataItem, "Result")  %>' Rows='<%# int.Parse(DataBinder.Eval(Container.DataItem, "SMLine").ToString()) %>'>
															</asp:TextBox>
															<asp:CheckBox ID="chkRPrint" Enabled=True Text="Report" Checked='<%#(DataBinder.Eval(Container.DataItem, "RPrint").ToString() == "Y")%>' Runat=server>
															</asp:CheckBox></P>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="RUnit" SortExpression="RUnit" HeaderText="Unit">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MinRange" SortExpression="MinRange" HeaderText="Min">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MaxRange" SortExpression="MaxRange" ReadOnly="True" HeaderText="Max">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Range" SortExpression="Range" HeaderText="Range">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:checkbox id=chkSensitivity runat="server" Visible='<%#(DataBinder.Eval(Container.DataItem, "TestType").ToString() == "M")%>' OnCheckedChanged="chkSensitivity_CheckedChanged" Text="Sensitivity" Checked='<%#(DataBinder.Eval(Container.DataItem, "Sensitivity").ToString() == "Y")%>' AutoPostBack="True">
						</asp:checkbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:label id=lblOrganism runat="server" Visible='<%# Micro((string)DataBinder.Eval(Container.DataItem, "TestType").ToString(), (string)DataBinder.Eval(Container.DataItem, "Sensitivity").ToString()) %>'>Organism: </asp:label>&nbsp;
						<asp:dropdownlist id=ddlOrganism runat="server" Visible='<%# Micro((string)DataBinder.Eval(Container.DataItem, "TestType").ToString(), (string)DataBinder.Eval(Container.DataItem, "Sensitivity").ToString()) %>' OnSelectedIndexChanged="ddlOrganism_SelectedIndexChanged" DataSource="<%# FillDDLOrganism() %>" AutoPostBack="True" DataTextField="Organism" DataValueField="OrganismID" SelectedIndex='<%# GetOrganismIndex((string)DataBinder.Eval(Container.DataItem, "OrganismID").ToString()) %>'>
						</asp:dropdownlist>&nbsp; </P>
						<P><asp:datagrid id="dgMicro" runat="server" Width="100%" AutoGenerateColumns="False">
								<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
								<AlternatingItemStyle Font-Size="X-Small" BackColor="#FFFCF2"></AlternatingItemStyle>
								<ItemStyle Font-Size="X-Small" BackColor="White"></ItemStyle>
								<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True">
										<HeaderStyle Width="30%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True"></asp:BoundColumn>
									<asp:BoundColumn DataField="Drug" HeaderText="Drug">
										<HeaderStyle Width="70%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Result">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemTemplate>
											<asp:DropDownList id=ddlResult runat="server" Width="100%" SelectedIndex='<%# GetMicroResultIndex((string)DataBinder.Eval(Container.DataItem, "microresult").ToString()) %>'>
												<asp:ListItem></asp:ListItem>
												<asp:ListItem Value="Sensitive">Sensitive</asp:ListItem>
												<asp:ListItem Value="Resistant">Resistant</asp:ListItem>
												<asp:ListItem Value="Intermediate">Intermediate</asp:ListItem>
											</asp:DropDownList>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><asp:label id="lblDisplaydgMicro" runat="server" OnLoad="lblDisplaydgMicro_Load"></asp:label><asp:label id="Label3" runat="server" Font-Bold="True">Forward to</asp:label><asp:dropdownlist id=dgddlForwardtoIT runat="server" Width="100%" DataSource='<%# FillDDLForwardTo(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>' DataTextField="Process" DataValueField="ProcessID" SelectedIndex='<%# GetForwardIndex((string)DataBinder.Eval(Container.DataItem, "ProcessID")) %>' Enabled="True">
							</asp:dropdownlist><asp:label id="Label1" runat="server" Width="100%" Font-Bold="True">Opinion:</asp:label><asp:textbox id=dgtxtOpinionET runat="server" Width="94%" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>' Height="45px" MaxLength="255" Rows="3">
							</asp:textbox><asp:linkbutton id="Linkbutton2" onclick="LinkButton2_Click" runat="server" Width="5%"><></asp:linkbutton><asp:label id="Label2" runat="server" Width="100%" Font-Bold="True">Comment:</asp:label><asp:textbox id=dgtxtCommentET runat="server" Width="94%" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>' Height="45px" MaxLength="255" Rows="3">
							</asp:textbox><asp:linkbutton id="Linkbutton1" onclick="Linkbutton1_Click" runat="server" Width="5%"><></asp:linkbutton></P>
						</ItemTemplate>
						<EditItemTemplate>
							<P>&nbsp;</P>
						</EditItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo"></asp:BoundColumn>
						</Columns>
						<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid><asp:button id="btnSaveAll" runat="server" Width="112px" Height="34px" Text="Save All" onclick="btnSaveAll_Click"></asp:button></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_009</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<script language="javascript">
			function SetOpinion(opinion)
			{
				document.all("<% =SelectedOpinion %>").value = opinion;
			}
			
			function SetComment(comment)
			{
				document.all("<% =SelectedComment %>").value = comment;
			}
		</script>
	</body>
</HTML>
