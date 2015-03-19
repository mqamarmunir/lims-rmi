<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmAttributeRange" CodeFile="wfrmAttributeRange.aspx.cs" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Attribute Range Registration:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
        <script language="javascript">
         function mlinterpretation() {
        if (document.getElementById('chkmlinterpretation').checked == true) {
//            alert('this will display all the textboxes');
            document.getElementById('multilineinterpretation').style.display = "block";
        }
        else {
//            alert('this will display only one');
            document.getElementById('multilineinterpretation').style.display = "none";
        }
    }
    </script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="9"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="9"><font size="4"><STRONG>ATTRIBUTE RANGES REGISTRATION</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="9">&nbsp;
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" OnClick="ibtnSave_Click1"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif" OnClick="ibtnClear_Click"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:ImageButton id="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif" OnClick="ibtnClose_Click"></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="9">
						<asp:Label id="lblErrMsg" runat="server" Font-Size="X-Small" ForeColor="Red" Width="100%" Font-Bold="True"></asp:Label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD style="width: 262px">
						<asp:DropDownList id="ddlSection" runat="server" tabIndex="1" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD align="right" style="width: 131px">
						Method&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						:&nbsp;&nbsp;</TD>
					<TD colspan="4">
						<asp:DropDownList id="ddlMethod" tabIndex="5" runat="server" Width="100%"></asp:DropDownList></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :</TD>
					<TD style="width: 262px">
						<asp:DropDownList id="ddlTestGroup" tabIndex="2" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD align="right" style="width: 131px">Sex&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						:&nbsp;&nbsp;</TD>
					<TD>
						<asp:DropDownList id="ddlSex" tabIndex="6" runat="server" Width="100%">
							<asp:ListItem Value="All" Selected="True">All</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:DropDownList></TD>
					<TD colspan="4"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						:</TD>
					<TD style="width: 262px">
						<asp:DropDownList id="ddlTest" runat="server" tabIndex="3" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlTest_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD align="right" style="width: 131px">Min-Max Age&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;</TD>
					<TD>
						<asp:DropDownList id="ddlMinMaxAgeType" tabIndex="7" runat="server" Width="100%">
							<asp:ListItem Value="Y" Selected="True">Year (s)</asp:ListItem>
							<asp:ListItem Value="M">Month (s)</asp:ListItem>
							<asp:ListItem Value="W">Week(s)</asp:ListItem>
							<asp:ListItem Value="D">Day(s)</asp:ListItem>
						</asp:DropDownList>
					</TD>
					<td align="center">
						<asp:TextBox id="txtAgeMin" tabIndex="8" runat="server" ToolTip="Enter Minimum Age in either years or in months"
							Width="99%" MaxLength="5" CssClass="field"></asp:TextBox>
					</td>
					<td align="center">
						<asp:TextBox id="txtAgeMax" tabIndex="9" runat="server" ToolTip="Enter Maximum Age in either years or in months"
							Width="99%" MaxLength="5" CssClass="field"></asp:TextBox></td>
					<TD colspan="2"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="13%">Attribute&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						:&nbsp;&nbsp;</TD>
					<TD style="width: 262px">
						<asp:DropDownList id="ddlTestAttribute" tabIndex="4" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlTestAttribute_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD align="right" style="width: 131px">Min-Max Value&nbsp;&nbsp;:&nbsp;&nbsp;</TD>
					<TD width="8%">
						<asp:TextBox id="txtMinValue" tabIndex="10" runat="server" ToolTip="Enter Result Minimum Value (not more than 273 Years or 3333 Months)"
							Width="100%" MaxLength="10" CssClass="field"></asp:TextBox>
					</TD>
					<TD width="8%" align="center">
						<asp:TextBox id="txtMaxValue" tabIndex="11" runat="server" ToolTip="Enter Result Maximum Value (not more than 273 Years or 3333 Months)"
							Width="99%" MaxLength="10" CssClass="field"></asp:TextBox></TD>
					<TD width="8%" align="right"></TD>
					<TD width="8%"></TD>
					<TD width="5%"></TD>
				</TR>
                <tr>
                    <td width="5%">
                    </td>
                    <td width="13%">
                        Interpretation</td>
                    <td style="width: 262px">
                    <%--<asp:TextBox ID="interpretation_Rtext" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                  --%> <%-- <CKEditor:CKEditorControl ID="interpretation_Rtext" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="False"
                           ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table"  MaxLength="1000" Visible="true"></CKEditor:CKEditorControl>--%>
                    </td>
                    <td align="right" style="width: 131px">
                        Min-Max Panic Value:&nbsp;</td>
                    <td width="8%">
                        <asp:TextBox ID="txtMinPValue" runat="server" CssClass="field" MaxLength="10" TabIndex="10"
                            ToolTip="Enter Result Minimum Value (not more than 273 Years or 3333 Months)"
                            Width="100%"></asp:TextBox></td>
                    <td align="center" width="8%">
                        <asp:TextBox ID="txtMaxPValue" runat="server" CssClass="field" MaxLength="10" TabIndex="10"
                            ToolTip="Enter Result Minimum Value (not more than 273 Years or 3333 Months)"
                            Width="100%"></asp:TextBox></td>
                    <td align="right" width="8%">
                    </td>
                    <td width="8%">
                    </td>
                    <td width="5%">
                    </td>
                </tr>
				<TR>
					<TD width="5%"></TD>
					<TD width="13%"></TD>
					<TD style="width: 262px"></TD>
					<TD align="right" style="width: 131px">Unit / Others&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;</TD>
					<TD colspan="4" width="8%">
						<asp:TextBox id="txtUnit" tabIndex="12" runat="server" Width="100%" CssClass="field" MaxLength="30"></asp:TextBox>
					</TD>
					<TD width="5%"></TD>
				</TR>
                <td colspan="9">

 <fieldset>
 <legend>Interpretation:</legend>
   <div id="divinterpretations" >
   <asp:CheckBox ID="chkmlinterpretation" runat="server" Text="Multiline" Checked="false" CssClass="label" onclick="javascript:mlinterpretation();" />
   <span id="interpretation1">
<CKEditor:CKEditorControl ID="interpretation_Rtext" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="False" Width="23%"
                           ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table"  MaxLength="1000" Visible="true"></CKEditor:CKEditorControl>
                    
          </span>

          <span id="multilineinterpretation" style="display:none">
          <CKEditor:CKEditorControl ID="txtAutomatedText2" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText3" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
          <CKEditor:CKEditorControl ID="txtAutomatedText4" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="23%" 
          EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" 
                            
          ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|-|Table" 
          MaxLength="150"></CKEditor:CKEditorControl>
</span>
</div>
 </fieldset>

 </td>
				<TR>
					<TD colSpan="9"></TD>
				</TR>
				<TR>
					<TD colSpan="9" align="center">
						<asp:DataGrid id="dgAttRange" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Silver"
							Font-Size="X-Small" Font-Names="Verdana" CssClass="datagrid" OnEditCommand="dgAttRange_EditCommand" OnItemCommand="dgAttRange_ItemCommand">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="TransID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="Method" ReadOnly="True" HeaderText="Method">
									<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Sex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AgeMin" ReadOnly="True" HeaderText="Minimum Age">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AgeMax" ReadOnly="True" HeaderText="Maximum Age">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ValueRange" ReadOnly="True" HeaderText="Results Range">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Unit" ReadOnly="True" HeaderText="Unit">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:EditCommandColumn EditText="Edit">
									<HeaderStyle Width="9%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:BoundColumn Visible="False" DataField="MinValue" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="MaxValue" ReadOnly="True"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MinPValue" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="MaxPValue" Visible="False"></asp:BoundColumn>
								<asp:ButtonColumn Text="Delete" CommandName="Delete">
									<HeaderStyle Width="9%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
							    <asp:BoundColumn DataField="Interpretation" HeaderText="Interpretation" 
                                    Visible="False"></asp:BoundColumn>
							    <asp:BoundColumn DataField="Interpretation2" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Interpretation3" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Interpretation4" Visible="False"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<TR>
					<TD colSpan="9">&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="9">HMS_LM_IN_022</TD>
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
