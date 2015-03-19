<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmComment" CodeFile="wfrmComment.aspx.cs" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Comment:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">

         <script language="javascript">
            function replaceenters(strid,e) {
                var textb = document.getElementById(strid);
                var key = window.event ? e.keyCode : e.which;
                //alert(textb.innerHTML);
                if (key == 13) {
                    //alert(textb.value.substring(0,textb.value.length-1));
                    textb.value = textb.value.substring(0, textb.value.length - 1)+' ';
                }

            }
            </script>
	</HEAD>
	<body>
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>COMMENT</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="LblMessage" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<td width="10%"></td>
					<td width="10%">Name:</td>
					<TD width="30%"><asp:label id="LblPerson" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
					<td align="right" width="10%">Test:&nbsp;&nbsp;</td>
					<TD width="30%"><asp:label id="LblTest" runat="server" Width="100%" Font-Bold="True"></asp:label></TD>
					<td width="10%"></td>
				</TR>
				<TR>
					<TD colspan="6">&nbsp;</TD>
				</TR>
				<TR>
					<td></td>
					<TD>Search By:
					</TD>
					<td colSpan="3"><asp:textbox id="TxtSearch" runat="server" Width="100%" CssClass="field"></asp:textbox></td>
					<td align="center"><asp:linkbutton id="ButGo" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="ButGo_Click">Go</asp:linkbutton></td>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="DGComment" runat="server" Width="100%" AutoGenerateColumns="False" BorderColor="Silver">
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
								<asp:TemplateColumn Visible="False" HeaderText="CommentID">
									<HeaderStyle Width="80%"></HeaderStyle>
									<ItemTemplate>
										<asp:Label id=LblVaultID runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CommentID")  %>'>
										</asp:Label>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Comment">
									<ItemTemplate>
										<asp:Label id=LblDescription runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>'>
										</asp:Label>
									</ItemTemplate>
									<EditItemTemplate>
                                   <%--<CKEditor:CKEditorControl ID="TxtDescription" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="true"
                            ToolbarBasic="Source|-|Bold|Italic" MaxLength="1000"></CKEditor:CKEditorControl>--%>
										<asp:TextBox id="TxtDescription" runat="server" Height="70px" Width="100%" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>'>
										</asp:TextBox>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn Text="Select" CommandName="Select">
                                
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							<asp:ButtonColumn Text="Delete" Commandname="Delete">
                            <HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle></asp:ButtonColumn>
                            </Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_013</TD>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
