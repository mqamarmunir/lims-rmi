<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmVault" CodeFile="wfrmVault.aspx.cs" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Vault Access:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body onload="doInit()">
		<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="label">
			<TR>
				<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
			</TR>
			<TR>
				<TD align="center" colSpan="7"><font size="4"><STRONG>VAULT ACCESS</STRONG></font></TD>
			</TR>
			<TR>
				<TD colspan="6">
					<asp:Label id="LblMessage" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
			</TR>
			<TR>
				<td width="10%"></td>
				<TD colspan="2" width="40%"><asp:label id="LblPerson" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
				<TD colspan="2" width="40%"><asp:label id="LblTest" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
				<td width="10%"></td>
			</TR>
			<TR>
				<TD width="10%" colSpan="6">&nbsp;</TD>
			</TR>
			<TR>
				<td width="10%"></td>
				<TD width="10%">
					Search Text:
				</TD>
				<td colspan="2" width="50%">
					<asp:TextBox id="TxtSearch" runat="server" Width="90%" CssClass="field"></asp:TextBox>
				</td>
				<td width="10%" align="center">
					<asp:LinkButton id="ButGo" runat="server" Width="8%" Font-Size="X-Small" ForeColor="Blue" onclick="ButGo_Click">Go</asp:LinkButton></td>
				<td width="10%"></td>
			</TR>
			<TR>
				<TD width="10%" colSpan="6">&nbsp;</TD>
			</TR>
			<TR>
				<TD colSpan="6"><asp:datagrid id="DGVault" runat="server" Width="100%" AutoGenerateColumns="False" BorderColor="Silver">
						<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="WhiteSmoke"></SelectedItemStyle>
						<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
						<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
						<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
						<Columns>
							<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img  border=0 src='Update.gif'&gt;" CancelText="&lt;img border=0 src='Cancel.gif'&gt;"
								EditText="&lt;img border=0 src='Edit.gif'&gt;">
								<HeaderStyle Width="10%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center"></ItemStyle>
							</asp:EditCommandColumn>
							<asp:TemplateColumn Visible="False" HeaderText="Vault ID">
								<HeaderStyle Width="80%"></HeaderStyle>
								<ItemTemplate>
									<asp:Label id=LblVaultID runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "VaultID")  %>'>
									</asp:Label>
								</ItemTemplate>
							</asp:TemplateColumn>
							<asp:TemplateColumn HeaderText="Vault">
								<HeaderStyle Width="80%"></HeaderStyle>
								<ItemTemplate>
									<asp:Label id=LblDescription runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Description")  %>'>
									</asp:Label>
								</ItemTemplate>
								<EditItemTemplate>
									<asp:TextBox id=TxtDescription runat="server" Height="70px" Width="100%" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Description")  %>'>
									</asp:TextBox>
								</EditItemTemplate>
							</asp:TemplateColumn>
							<asp:ButtonColumn Text="Select" CommandName="Select">
								<HeaderStyle Width="10%"></HeaderStyle>
								<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
							</asp:ButtonColumn>
						</Columns>
					</asp:datagrid></TD>
			</TR>
			<TR>
				<TD colSpan="6">&nbsp;</TD>
			</TR>
			<TR>
				<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_017</TD>
			</TR>
		</TABLE>
		</FORM>
	</body>
</HTML>
