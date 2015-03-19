<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmSubdepartment.aspx.cs" Inherits="LIMS_WebForms_wfrmSubdepartment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <LINK href="LIMS.css" rel="stylesheet">
</head>
<body>
    	<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colspan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>Sub Department</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="6">
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" 
                            ></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif" 
                            ></asp:ImageButton><asp:ImageButton id="ibtnClose" 
                            runat="server" ImageUrl="images/btn_Close.gif" ></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="6">
						<asp:Label id="lblErrMsg" runat="server" ForeColor="Red" Width="100%" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD colspan="2">
						<asp:TextBox id="txtsection" runat="server" Width="100%" 
                           tabIndex="3"
							ToolTip="Enter Sub-Department Name"></asp:TextBox></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Active:</TD>
					<TD>
						<asp:CheckBox id="chkActive" runat="server" Checked="True" tabIndex="2" ToolTip="Check to Active Test Group"></asp:CheckBox></TD>
					<TD colspan="3"></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="15%">Description:</TD>
					<TD width="40%">
						<asp:TextBox id="txtdesc" runat="server" Width="100%" CssClass="mandatoryfield" tabIndex="3"
							ToolTip="Enter Description"></asp:TextBox></TD>
					<TD width="10%" align="right">&nbsp;&nbsp;</TD>
					<TD width="20%">
						&nbsp;</TD>
					<TD width="10%"></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6" align="center">
						<asp:DataGrid id="dgSectionList" runat="server" AllowSorting="True" AutoGenerateColumns="False"
							PageSize="25" AllowCustomPaging="True" CssClass="datagrid" BorderColor="Silver">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<EditItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#C9CDE7"></EditItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="SECTIONID"></asp:BoundColumn>
								<asp:BoundColumn DataField="SECTIONNAME" SortExpression="TestGroup" ReadOnly="True" HeaderText="Sub Department">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Description" SortExpression="Acronym" Visible="false" HeaderText="Description">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled=False Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="" CancelText="" EditText="Edit">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Font-Size="X-Small" Font-Names="Verdana" HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:ButtonColumn Visible="False" Text="Delete" CommandName="Delete">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_001</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
</body>
</html>
