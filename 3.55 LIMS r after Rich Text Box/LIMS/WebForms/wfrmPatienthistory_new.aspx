<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPatienthistory_new.aspx.cs" Inherits="LIMS_WebForms_wfrmPatienthistory_new" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>
    LIMS: Patient history:    <% =Session["UNUIDFORMATTED"] %>
    </title>
     <meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <TABLE class="label" id="Table1"  style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>PATIENT TEST HISTORY</STRONG></font></td>
				</tr>
                <TR>
					<TD align="right" colSpan="8">
                        <%--<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>--%>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					</TD>
				</TR>
                <TR>
					<TD colSpan="8"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
                </TABLE>
                <br />
                <asp:Panel ID="pnlsearch" runat="server" DefaultButton="btnGo">
                <table id="tblbody" runat="server" class="label" cellpadding="0" cellspacing="0" border="0">
                <tr>
                <td width="15%" align="right">Search(PRNo.)</td>
                <td width="20%"><asp:TextBox ID="txtPRNumber" runat="server" CssClass="mandatoryField" Width="100%"></asp:TextBox></td>
                <td width="15%"><asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/images/Find.png" OnClick="btnGo_Click" ToolTip="Search" /> </td>
                <td width="20%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>
                
                </table>
               </asp:Panel>
              

                <fieldset id="fieldpatientinfo" runat="server" visible="false">
                <legend>Patient information</legend>
                <table id="tblpatientinfo" runat="server" class="label">
                <tr>
                <td align="right">Name:</td>
                <td><asp:Label ID="lblName" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label></td>
                <td align="right">Gender:</td>
                <td><asp:Label ID="lblgender" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td align="right">DOB:</td>
                <td><asp:Label ID="lblDOB" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label></td>
                <td align="right">Phone Number: </td>
                <td><asp:Label ID="lblphNumber" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
             <tr>

                <td width="15%" align="right">Address:</td>
                <td width="20%" colspan="3"><asp:Label ID="lblAddress" runat="server" Font-Bold="true" Font-Size="X-Small"></asp:Label></td>
               
                
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>
                 <tr>

                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>
                </table>
                </fieldset>
                <br />
                <fieldset id="fieldlabs" runat="server" visible="false">
                <legend>Labs history</legend>
                
                <table id="tblgrid" class="label" runat="server">
                <tr>
                <td></td>
                <td><asp:Label ID="lblCount" runat="server" ForeColor="Green" Font-Size="X-Small"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                  <tr>
                <td></td>
                <td colspan="6">
                <asp:GridView ID="gvPatientLabs" AutoGenerateColumns="False" Width="75%" 
                        runat="server" CssClass="datagrid" Visible="false" OnRowCommand="gvPatientlabs_RowCommand">
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="5%" HorizontalAlign="Center" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                
                </asp:TemplateField>
                <asp:ButtonField DataTextField="LabID" CommandName="Select" ButtonType="Link" HeaderText="Lab ID" />
                    <asp:BoundField DataField="MSerialNo" HeaderText="MSerial #" />
                <asp:BoundField DataField="EntryDateTime" HeaderText="Booked On" />
                <asp:BoundField DataField="MSTATUS" HeaderText="Status" />
               
                
                
                </Columns>
                </asp:GridView>
                </td>
                
                </tr>
                <tr>
                <td width="15%"></td>
                <td colspan="6">
                <asp:GridView ID="gvTests" CssClass="datagrid" Width="75%" DataKeyNames="TestID" AutoGenerateColumns="false"
                 OnRowCommand="gvTests_RowCommand" runat="server">
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText="S#">
                <HeaderStyle HorizontalAlign="Center" />
                <ItemStyle Width="5%" HorizontalAlign="Center" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                
                </asp:TemplateField>
                <%--<asp:ButtonField DataTextField="TestID" CommandName="Select" HeaderText="Test ID" />--%>
            <%--    <asp:BoundField DataField="TestID" HeaderText="Test ID" />--%>
                <asp:ButtonField DataTextField="Test" HeaderText="Test" CommandName="Select" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="TestCount" HeaderText="Times Performed" />
                </Columns>
                </asp:GridView>
                </td>
              
                </tr>
                <tr>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="15%"></td>
                <td width="20%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                <td width="10%"></td>
                </tr>
                </table>
                </fieldset>
    
    </div>
    </form>
</body>
</html>
