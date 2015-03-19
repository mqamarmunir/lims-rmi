<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmSpecimenCollectionDetail" CodeFile="wfrmSpecimenCollectionDetail.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Specimen Collection Detail:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"-->
                        <asp:ScriptManager id="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                       

                        </TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG> SPECIMEN COLLECTION DETAIL</STRONG></font></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 15px" width="5%"></TD>
					<TD style="HEIGHT: 15px" width="10%">Rec-ID:</TD>
					<TD style="HEIGHT: 15px" width="30%"><asp:label id="LbLabID" runat="server" Width="100%">Label</asp:label></TD>
					<TD style="HEIGHT: 15px" width="10%"></TD>
					<TD style="HEIGHT: 15px" width="40%">
						<asp:label id="LblMSerialNo" runat="server" Width="100%" Visible="False">Label</asp:label></TD>
					<TD style="HEIGHT: 15px" width="5%"></TD>
				</TR>
                <tr>
                <td></td>
                <td>
                PR #:
                </td>
                <td colspan="3">
                <asp:Label ID="lblPrno" Width="99%" runat="server"></asp:Label> 
                </td>
                </tr>
				<TR>
					<TD></TD>
					<TD>Name:</TD>
					<TD colSpan="3"><asp:label id="LblPatientName" runat="server" Width="100%">Label</asp:label></TD>
					<TD></TD>
				</TR>
                <tr>
                <td></td>
                <td>Ward:</td>
                <td>
                <asp:Label ID="lblWard" runat="server"></asp:Label>
                </td>
                </tr>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Sex/Age:</TD>
					<TD width="30%"><asp:label id="LblAge" runat="server" Width="100%">Label</asp:label></TD>
					<TD width="10%">
						<asp:label id="lblSpecimen" runat="server" Width="100%" Visible="False">Label</asp:label></TD>
					<TD width="40%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|<asp:ImageButton
                            ID="ibtnSave" runat="server" ImageUrl="images/btn_Close.gif" OnClick="ibtnSave_Click" /></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD colspan="2">
                    <asp:Label ID ="lbColorCode1" BackColor="OliveDrab" runat="server" Text="Comments added"></asp:Label>
                    </TD>
                    <TD>
                    <asp:Label ID ="lbColorCode2" BackColor="SeaShell" runat="server" Text="External"></asp:Label>
                    </TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="DGPatientStatus" runat="server" Width="100%" BorderColor="Gray" AutoGenerateColumns="False"
							AllowSorting="True" CellPadding="8" GridLines="Horizontal" CellSpacing="2" CssClass="datagrid" OnItemDataBound="DGPatientStatus_ItemDataBound" >
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" HeaderText="DSerialNo"></asp:BoundColumn>
								<asp:BoundColumn DataField="SectionName" HeaderText="Department">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TestGroup" ReadOnly="True" HeaderText="Test Group">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Specimen" HeaderText="Specimen">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProcedureID" HeaderText="ProcedureID"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="Comment" DataField="Spec_Coment">
                                    <HeaderStyle Width="15%" />
                                </asp:BoundColumn>
								<asp:ButtonColumn Text="Collect" HeaderText="Collect" CommandName="Collect">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:ButtonColumn>
                                <asp:ButtonColumn CommandName="comment" HeaderText="Comment" Text="Comment"></asp:ButtonColumn>
							    <asp:BoundColumn DataField="TestID" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="RoundDelivery" Visible="False"></asp:BoundColumn>
                                <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkHistory" Text="History" CommandName="History" Visible="false" CommandArgument="<%#Container.DataSetIndex %>" runat="server"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkSOp" Text="SOPs" CommandName="SOPs" Visible="false" CommandArgument= "<%#Container.DataSetIndex %>" runat="server"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <%--<asp:ButtonColumn CommandName="History" HeaderText="History" Text="History" Visible="false"></asp:ButtonColumn>--%>
                                <asp:BoundColumn DataField="PRNo" HeaderText="PRNo" Visible="false">
                                </asp:BoundColumn>
							    <asp:BoundColumn DataField="HIstoryTaking" Visible="False"></asp:BoundColumn>
                                 <asp:BoundColumn DataField="External" HeaderText="External" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
                <tr>
                    <td></td>
                    <td colspan="5" align="left">
                        <asp:Panel ID="pnl_cmt" runat="server" Width="70%" GroupingText="Comment">
                            <table id="tb_cmt" cellpadding="1" cellspacing="1" border="0" width="100%" class="label">
                                <tr>
                                    <td>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblError_Cmt" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDserial_Cmt" runat="server" Visible="False"></asp:Label></td>
                                    <td align="right">
                                        <asp:ImageButton ID="imgSave_Cmt" runat="server" ImageUrl="~/LIMS/WebForms/images/btn_Save.gif" OnClick="imgSave_Cmt_Click" />
                                        <asp:ImageButton ID="imgClose_Cmt" runat="server" ImageUrl="~/LIMS/WebForms/images/btn_Close.gif" OnClick="imgClose_Cmt_Click" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Test:</td>
                                    <td>
                                        <asp:Label ID="lblTest_Cmt" runat="server"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                        Comment:</td>
                                    <td rowspan="2">
                                        <asp:TextBox ID="txtComment" runat="server" CssClass="field" TextMode="MultiLine"
                                            Width="100%"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:20%"></td>
                                    <td style="width:80%"></td>
                                    
                                </tr>
                            </table>
                        </asp:Panel>    
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                    </td>
                </tr>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_016</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
