<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmSopTypes.aspx.cs" Inherits="LIMS_WebForms_wfrmSopTypes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<title>LIMS: SOP Types:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>SOP TYPES<asp:ScriptManager 
                            ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </STRONG></font>
                    &nbsp;<asp:HiddenField ID="hdSopTypeID" runat="server" />
                    </TD>
				</TR>
                <tr>
                <td colspan="7" align="right">
                 <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="false" 
                            onclick="ibtnClose_Click" style="height: 26px"></asp:ImageButton>
                
                </td>
                </tr>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<td width="10%"></td>
					<td width="10%">SOP Type:</td>
					<TD width="30%"><asp:TextBox ID="txtSopType" runat="server" Width="100%" CssClass="mandatoryField"></asp:TextBox></TD>
					<td align="right" width="10%"><asp:CheckBox ID="chkActive" Text="Active" runat="server" /></td>
					<TD width="30%"></TD>
					<td width="10%"></td>
				</TR>
				
				<TR>
					<td></td>
					<TD>Process:</TD>
					<td><asp:DropDownList ID="ddlProcess" runat="server" Width="100%" CssClass="mandatorySelect"></asp:DropDownList></td>
					<td align="center"><%--<asp:linkbutton id="lnkbtnsave" runat="server" ForeColor="Blue" Font-Size="X-Small" onclick="lnkbtnsave_Click">Save</asp:linkbutton>--%></td>
				</TR>
                <tr>
                <td></td>
                <td>Approved By:</td>
                <td><asp:DropDownList ID="ddlPersons" runat="server" Width="100%" CssClass="mandatorySelect"></asp:DropDownList>
                <cc1:ListSearchExtender ID="listsearchextender1" TargetControlID="ddlPersons" PromptPosition="Top" runat="server"></cc1:ListSearchExtender>

                
                </td>
                <td>&nbsp;</td>
                <td>
                    
                    
                    </td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td>Approved On:</td>
                <td><asp:TextBox ID="txtApprovedOn" runat="server" CssClass="mandatoryField" 
                        Enabled="true"  ToolTip="Enter Effective Date" Width="30%"></asp:TextBox>
                    <cc1:calendarextender id="CalendarExtender3" runat="server" format="dd/MM/yyyy" 
                        targetcontrolid="txtApprovedOn">
                        </cc1:calendarextender>
                    <cc1:maskededitextender id="MaskedEditExtender2" runat="server" acceptampm="false" 
                        autocomplete="false" clearmaskonlostfocus="false" mask="99/99/9999" 
                        masktype="Date" targetcontrolid="txtApprovedOn">

                        </cc1:maskededitextender>&nbsp; Applicable Date
                    <asp:TextBox ID="txtApplicable" runat="server" CssClass="mandatoryField" 
                        Enabled="true" tabIndex="5" ToolTip="Enter Effective Date" Width="30%"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" format="dd/MM/yyyy" 
                        targetcontrolid="txtApplicable">
                    </cc1:CalendarExtender>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" 
                        acceptampm="false" autocomplete="false" clearmaskonlostfocus="false" 
                        mask="99/99/9999" masktype="Date" targetcontrolid="txtApplicable">
                    </cc1:MaskedEditExtender>
                    </td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
                <tr>
                <td></td>
                <td colspan="6">
                <asp:GridView ID="gvTypes" Width="70%" AutoGenerateColumns="False" runat="server"
                   OnRowCommand="gvTypes_RowCommand" DataKeyNames="SopTypeId,ProcessID,ApprovedBy,ApprovedOn" >
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle Width="5%" />
                <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Type" DataField="Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                    <asp:BoundField DataField="Process" HeaderText="Process">
                    <HeaderStyle HorizontalAlign="left" Width="25%" />
                    </asp:BoundField>
                      <asp:BoundField DataField="ApplicableDate" HeaderText="Applicable Date">
                    <HeaderStyle HorizontalAlign="left" Width="25%" />
                    </asp:BoundField>
            
                <asp:TemplateField HeaderText="Active">
                <ItemTemplate>
                <asp:CheckBox ID="gvchkActive" runat="server" Enabled="false" Checked='<%#DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y"%>' />
                </ItemTemplate>
                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                <ItemStyle HorizontalAlign="Center" />
                
                </asp:TemplateField>
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
                </table>
    </div>
    </form>
</body>
</html>
