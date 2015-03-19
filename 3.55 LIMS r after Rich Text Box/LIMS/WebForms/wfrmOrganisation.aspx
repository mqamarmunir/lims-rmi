<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmOrganisation.aspx.cs" Inherits="LIMS_wfrmOrganisation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
    <%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: Preference Settings:    <% =Session["UNUIDFORMATTED"] %>
    </title>
    <meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            width: 10%;
        }
        .mandatoryfield
        {}
        .style3
        {
            width: 21%;
            margin-left: 40px;
        }
        .field
        {
            margin-left: 2px;
        }
        .mandatoryField
        {
            margin-left: 2px;
        }
        .style5
        {
            width: 13%;
        }
        .style6
        {
            width: 11%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="5"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="5">
                        
                        <h2>Organization&#39;s Registration</h2></td>
				</tr>
                <TR>
					<TD align="right" colSpan="5">
                        <asp:HiddenField ID="hfOrgId" runat="server" />
                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                        <asp:ImageButton id="ibtnSave" runat="server" 
                            ImageUrl="~/images/SavePack_2.gif" onclick="ibtnSave_Click" ></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif"  
                            CausesValidation="False" onclick="ibtnClear_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" onclick="ibtnClose_Click" 
                            ></asp:ImageButton>
					</TD>
				</TR>
                <TR>
					<TD colSpan="5"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
                <TR>
					<TD class="style1">&nbsp;</TD>
					
					<TD class="style6">&nbsp;</TD>
					<TD class="style3">
                        &nbsp;</TD>
					<TD class="style5" align="left">&nbsp;</TD>
					<TD>
                            
                            <asp:CheckBox ID="chkActive" Text="Active" runat="server" TabIndex="1" />
                            
                             <asp:CheckBox ID="chkExternal" Text="External" runat="server" TabIndex="2" />
                            </TD>
				</TR>
                <TR>
					<TD class="style1">&nbsp; </TD>
					
					<TD class="style6">Name</TD>
					<TD class="style3">
                        <asp:textbox id="txtName" runat="server" Enabled="true" 
                            Width="72%" CssClass="mandatoryField"
							tabIndex="3" ToolTip="Enter Organization's Name" Height="20px" MaxLength="35"></asp:textbox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" 
                            ControlToValidate="txtName" Display="None" 
                            ErrorMessage="Please Provide organisation's name"></asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="rfvName_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rfvName">
                        </asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="revName" runat="server" 
                            ControlToValidate="txtName" Display="None" 
                            ErrorMessage="Please provide a proper name" 
                            ValidationExpression="^[A-Za-z ]+$"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="revName_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="revName">
                        </asp:ValidatorCalloutExtender>
                    </TD>
					<TD class="style5" align="left">Acronym</TD>
					<TD>
                        <asp:textbox id="txtAcronym" runat="server" Enabled="true" 
                            Width="44%" CssClass="mandatoryField"
							tabIndex="4" ToolTip="Enter Organization's Acronym" Height="20px" MaxLength="5"></asp:textbox>
                            <asp:RequiredFieldValidator ID="rfvAcronym" runat="server" 
                            ControlToValidate="txtAcronym" Display="None" 
                            ErrorMessage="Pleas provide an acronym for the organization"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="rfvAcronym_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="rfvAcronym">
                        </asp:ValidatorCalloutExtender>
                        <asp:RegularExpressionValidator ID="revAcronym" runat="server" 
                            ControlToValidate="txtAcronym" Display="None" 
                            ErrorMessage="Please provide a proper Acronym" 
                            ValidationExpression="^[a-zA-Z]+$"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="revAcronym_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="revAcronym">
                        </asp:ValidatorCalloutExtender>
                            </TD>
				</TR>
                <%-- <TR>
					<TD></TD>
					<TD></TD>
					<TD class="style1">&nbsp;</TD>
					<TD colSpan="3">&nbsp;</TD>
					<TD></TD>
					<TD></TD>
				</TR>--%>
                <tr>
                <td></td>
                <td class="style6">Phone No.</td>
                <td>
                <asp:TextBox ID="txtPhoneNumber" CssClass="field" Width="72%" runat="server" 
                        Height="20px" MaxLength="14" TabIndex="5"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPhoneNumber" runat="server" 
                        ControlToValidate="txtPhoneNumber" Display="None" 
                        ErrorMessage="Please provide a proper phone number" 
                        ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                    <asp:ValidatorCalloutExtender ID="revPhoneNumber_ValidatorCalloutExtender" 
                        runat="server" Enabled="True" TargetControlID="revPhoneNumber">
                    </asp:ValidatorCalloutExtender>
                 </td>
                 <td class="style5">
                     Fax No.</td>
                 <td>
                 <asp:TextBox ID="txtFaxNumber" runat="server" CssClass="field" Width="44%" 
                         Height="20px" MaxLength="15" TabIndex="6"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="revFaxNo" runat="server" 
                         ControlToValidate="txtFaxNumber" Display="None" 
                         ErrorMessage="Please provide a proper fax no" 
                         ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                     <asp:ValidatorCalloutExtender ID="revFaxNo_ValidatorCalloutExtender" 
                         runat="server" Enabled="True" TargetControlID="revFaxNo">
                     </asp:ValidatorCalloutExtender>
                 </td>

                </tr>
                <TR>
					<TD></TD>
					
					<TD class="style6">Email</TD>
					<TD class="style3">
                        <asp:textbox id="txtEmail" runat="server" Enabled="true" 
                            Width="72%" CssClass="field"
							tabIndex="7" ToolTip="Enter Email Here" Height="20px"></asp:textbox>
                        <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                            ControlToValidate="txtEmail" Display="None" 
                            ErrorMessage="Please provide a proper email" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="revEmail_ValidatorCalloutExtender" 
                            runat="server" Enabled="True" TargetControlID="revEmail">
                        </asp:ValidatorCalloutExtender>
                    </TD>
                            <TD align="left" class="style5">
                            
                                Web Address</TD>
                                <td>
                                <asp:TextBox ID="txtWebAddress" runat="server" CssClass="field" Width="44%" 
                                        Height="20px" TabIndex="8"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="revWebAddress" runat="server" 
                                        ControlToValidate="txtWebAddress" Display="None" 
                                        ErrorMessage="Please provide a proper url" 
                                        ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                                    <asp:ValidatorCalloutExtender ID="revWebAddress_ValidatorCalloutExtender" 
                                        runat="server" Enabled="True" TargetControlID="revWebAddress">
                                    </asp:ValidatorCalloutExtender>

                                </td>
					
                            </TR>
                            <tr>
                            <td></td>
                            <td class="style6" valign="top">Postal Address:</td>
                            <td colspan="3">
                                <%--<asp:TextBox ID="txtadnote" runat="server" TextMode="MultiLine"></asp:TextBox>--%>
                        <asp:textbox id="txtPostalAddress" runat="server" Enabled="true" 
                            Width="68%" CssClass="field"
							tabIndex="9" Height="20px"></asp:textbox>
                            </td>
                            
                            </tr>
                            <tr>
                            <td></td>
                            <td colspan="4">
                            
                                &nbsp;</td>
                            </tr>

                           <tr>
                    <td>
                        </td>

                        <td class="style6"  >

                            <asp:Label ID="RFound" runat="server" Text="Label" Visible="False" 
                                ForeColor="#66FF66"></asp:Label>
                               </td>
                      
                </tr>
                <tr>
                
                    <td colspan="5" align="center">
                        <asp:GridView ID="gvOrganisation" runat="server" CssClass="datagrid" 
                            AutoGenerateColumns="False" 
                            DataKeyNames="ORGID,FAXNO,EMAIL,WEB_ADDRESS,ADDRESS" 
                            onrowcommand="gvOrganisation_RowCommand">
                            <HeaderStyle CssClass = "gridheader" HorizontalAlign = "left" />
                            <RowStyle CssClass = "gridItem" />
                            <AlternatingRowStyle CssClass = "gridAlternate" />
                            <Columns>
                            <asp:TemplateField HeaderText = "S#" ItemStyle-Width = "5%">
                            <ItemTemplate><%#Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField DataField="NAME" HeaderText="Name" ItemStyle-Width = "30%" />
                                <asp:BoundField DataField="ACRONYM" HeaderText="Acronym" ItemStyle-Width = "5%" />
                                <asp:BoundField DataField="PHONENO" HeaderText="Phone No." ItemStyle-Width = "10%" />
                                <asp:BoundField DataField="FNAME" HeaderText="Entered By" ItemStyle-Width = "10%" />
                                <asp:BoundField DataField="displaydate" HeaderText="Entered On" ItemStyle-Width = "20%" />
                                <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign = "center" ItemStyle-Width = "5%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkgvActive" runat="server" Enabled = "false" Checked = '<%# GetStatus(Eval("ACTIVE").ToString())    %>' />
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText = "External" ItemStyle-HorizontalAlign = "center" ItemStyle-Width = "5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID = "chkgvExternal" runat = "server" Enabled = "false" Checked = '<%# GetStatus(Eval("EXTERNAL").ToString()) %>' />
                                </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="External Status"></asp:TemplateField>--%>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width = "10%" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
             
                </TABLE>
                </form>

</body>
</html>

