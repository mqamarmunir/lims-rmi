<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmSpecimenLife.aspx.cs" Inherits="LIMS_WebForms_wfrmSpecimenLife" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
		<title>LIMS: Specimen Life:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
<body>
    <form id="form1" runat="server">
    <TABLE id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px" cellSpacing="1"
				cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD colspan="7" style="HEIGHT: 20px"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>SAMPLE LIFE CONFIGURATION
                        </STRONG></font>
                        <asp:HiddenField ID="hdLifeID" runat=server />
                        </TD>
				</TR>
				<TR>
					<TD align="right" colSpan="7">
					<%--	<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="150" align="right" border="0">
							<TR>
								<TD align="right" colspan="5">--%>
                        
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" ToolTip="Insert" OnClick="ibtnSave_Click" Visible="true"></asp:ImageButton>
						
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					
				
					
					</TD>
							<%--</TR>
						</TABLE>
					</TD>--%>
				</TR>
				<TR>
					<TD colSpan="7">
						<asp:Label id="lblErrMSg" runat="server" Width="100%" ForeColor="Red"></asp:Label></TD>
				</TR>
			<TR>
					<TD width="10%">
						</TD>
					<TD width="15%">Sub-Department:</TD>
					<TD width="20%"><asp:DropDownList ID="ddlSubDepartment" AutoPostBack="true" 
                            CssClass="mandatorySelect" Width="100%" runat="server" 
                            onselectedindexchanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList></TD>
					<TD width="15%" align="center">Test:</TD>
					<TD width="20%"><asp:DropDownList ID="ddlTest" CssClass="mandatorySelect"  Width="100%" runat="server"></asp:DropDownList></TD>
					<TD width="18%"></TD>
					
				</TR>
                <tr>
                <td></td>
                <td>
                Specimen:
                </td>
                <td>
                <asp:DropDownList ID="ddlSpecimen" CssClass="mandatorySelect" runat="server" Width="100%"></asp:DropDownList>
                </td>
                <td align="center">
                    Life:</td>
                <td>
                <asp:TextBox ID="txtLife" runat="server" Width="70%" CssClass="mandatoryField"></asp:TextBox>
                hours
                </td>
                <td>
                </td>
                </tr>
                <tr>
                <td></td>
                <td colspan="7">
                <asp:Label ID="lblCount" runat="server"></asp:Label>
                </td>
                </tr>
         <tr>
         <td></td>
         <td colspan="7" >
         
         <asp:GridView ID="gvSpecimenLife" Width="80%" AllowSorting="True" AutoGenerateColumns="False" BorderColor="Silver"
         CssClass="datagrid" OnSortCommand="gvSpecimenLife_Sorting"  OnRowCommand="gvSpecimenLife_RowCommand" DataKeyNames="LifeID,SectionID" runat="server">
         <SelectedRowStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedRowStyle>
         <AlternatingRowStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingRowStyle>
							<RowStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></RowStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
         <Columns>
             <asp:TemplateField HeaderText="S#">
             <ItemStyle Width="5%" />
             <ItemTemplate>
             <%#Container.DataItemIndex+1 %>
             </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="Test" HeaderText="Test" SortExpression="Test">
             <ItemStyle HorizontalAlign="Left" />
             <HeaderStyle HorizontalAlign="left" />
             </asp:BoundField>
             <asp:BoundField DataField="Specimen" HeaderText="Specimen Type" 
                 SortExpression="Specimen">
                 <HeaderStyle HorizontalAlign="Left" />
                 </asp:BoundField>
             <asp:BoundField DataField="Life" HeaderText="Life" SortExpression="Life">
             <HeaderStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:TemplateField>
                 <ItemTemplate>
                 <asp:LinkButton ID="gvlnkEdit" CommandName="Select" Text="Edit" CommandArgument='<%#Container.DataItemIndex%>' runat="server"></asp:LinkButton>
                 </ItemTemplate>
                 </asp:TemplateField>   
            </Columns>
         </asp:GridView>
         </td>
       
         </tr>
               
   </TABLE>
    </form>
</body>
</html>
