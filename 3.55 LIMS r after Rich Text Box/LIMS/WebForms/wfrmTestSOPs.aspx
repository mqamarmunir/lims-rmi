<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmTestSOPs.aspx.cs" Inherits="LIMS_WebForms_wfrmTestSOPs" %>

<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
		<title>LIMS: Test SOPs:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>TEST SOPs<asp:ScriptManager ID="Scriptmanager1" runat="server"></asp:ScriptManager>
                        </STRONG></font>
                    &nbsp;
                  
                    
                    <asp:HiddenField ID="hdTestSopID" runat="server" />
                 
                    </TD>
				</TR>
                <tr>
                <td colspan="7" align="right">
                 <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False" style="height: 26px"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="false" 
                            onclick="ibtnClose_Click" style="height: 26px"></asp:ImageButton>
                
                </td>
                </tr>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
                </table>

                <fieldset>
                <legend>Test Info</legend>
                <table id="tbltestinfo" runat="server" class="label">
                <tr>
                <td align="right">Sub-Department:</td>
                <td><asp:DropDownList ID="ddlSubDepartment" runat="server" 
                        CssClass="mandatorySelect" Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList></td>
                <td align="right">Test:</td>
                <td>
                
                
                <asp:DropDownList ID="ddlTest" runat="server" CssClass="mandatorySelect" 
                        Width="100%" AutoPostBack="True" 
                        onselectedindexchanged="ddlTest_SelectedIndexChanged"></asp:DropDownList>
                        
                
                </td>
                <td></td>
                <td></td>
                </tr>
                  <tr>
                <td align="right">Test Name:</td>
                <td>
                <asp:TextBox ID="txtTestName" Enabled="false" runat="server" Width="100%" CssClass="field"></asp:TextBox>
              
                </td>
                <td align="right">Default Method: </td>
                <td>
              
                
                <asp:TextBox ID="txtMethod" Enabled="false" runat="server" Width="100%" CssClass="field"></asp:TextBox>
                
                </td>
                <td></td>
                <td></td>
                </tr>
             
                  <tr>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                </tr>
                
                </table>
                </fieldset>
                
                <fieldset id="fsSOPs" runat="server">
                <legend>SOPs</legend>
                <table id="tblSops" class="label" runat="server">
                <tr>
                <td></td>
                <td>SOP Type:</td>
                <td>
          
                
                <asp:DropDownList ID="ddlSopType" runat="server" Width="100%" CssClass="mandatorySelect"></asp:DropDownList>
         
                </td>
                <td></td>
                <td></td>
                 <td></td>
                </tr>
                <tr>
                <td></td>
                <td>Attach Files:</td>
                
                <td>
             
            
                
                        <asp:LinkButton ID="lnkpath1" runat="server" Visible="false" 
                        onclick="lnkpath1_Click"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkdelfile1" runat="server" Text="[X]" OnCommand="gvlnkdelfile_Command" CommandName="file1" Visible="false"></asp:LinkButton>
                         <br />
                <asp:LinkButton ID="lnkpath2" runat="server" Visible="false" 
                        onclick="lnkpath2_Click"></asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkdelfile2" runat="server" Text="[X]" OnCommand="gvlnkdelfile_Command" CommandName="file2" Visible="false"></asp:LinkButton>     <br />
                <asp:LinkButton ID="lnkpath3" runat="server" Visible="false" 
                        onclick="lnkpath3_Click"></asp:LinkButton>
                        &nbsp;&nbsp;&nbsp;
                 <asp:LinkButton ID="lnkdelfile3" runat="server" Text="[X]" OnCommand="gvlnkdelfile_Command" CommandName="file3" Visible="false"></asp:LinkButton>     <br />

                <asp:FileUpload ID="FileUpload1"  runat="server" Width="100%" /><br />
                <asp:FileUpload ID="FileUpload2" runat="server" Width="100%"/><br />
                <asp:FileUpload ID="FileUpload3" runat="server" Width="100%"/><br />
                
                </td>
                <td></td>
                <td></td>
                 <td></td>
                </tr>
                <tr>
                <td></td>
                <td>Description:</td>
                <td colspan="2">
               
                <CKEditor:CKEditorControl ID="txtDescription" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="100%" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="true" ToolbarBasic="Source|-|Bold|Italic|-|NumberedList|BulletedList|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock" MaxLength="2000"></CKEditor:CKEditorControl>
                            
                            </td>
                <td></td>
                <td></td>
                 
                </tr>
                     <tr>
                <td colspan="6">
                <asp:Label ID="lblCount" runat="server" ForeColor="Green"></asp:Label>
                </td>
             
                </tr>
                   <tr>
                <td colspan="6">
               
                
                       <asp:GridView ID="gvTestSOP" Width="70%" AutoGenerateColumns="False" runat="server"
                   OnRowCommand="gvTestSOP_RowCommand" AllowSorting="True" 
                           OnSorting="gvTestSoPSorting" DataKeyNames="TestSopID,SectionID,Description,doc_path1,doc_path2,doc_path3,testid" 
                           HorizontalAlign="Center" >
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle Width="5%" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Type" DataField="SOPtype" SortExpression="SOPType">
                <HeaderStyle HorizontalAlign="Left" Width="15%" />
                    </asp:BoundField>
               
                    <asp:BoundField DataField="Test"  HeaderText="Test" SortExpression="Test">
                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Doc_Path" HeaderText="Documents Path(s)" HtmlEncode="false">
                    <HeaderStyle Width="15%" HorizontalAlign="Left" />
                    </asp:BoundField>
                   <%-- <asp:TemplateField HeaderText="Document Path" SortExpression="Doc_Path">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Doc_Path") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Doc_Path") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                    </asp:TemplateField>--%>
                 <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'>Edit</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                </asp:GridView>
                
                </td>
                
                </tr>
                  <tr>
                <td width="10%"></td>
                <td width="15%"></td>
                <td width="25%"></td>
                <td width="15%"></td>
                <td width="15%"></td>
                 <td width="15%"></td>
                </tr>
                </table> 
                </fieldset>
    </div>
    </form>
</body>
</html>
