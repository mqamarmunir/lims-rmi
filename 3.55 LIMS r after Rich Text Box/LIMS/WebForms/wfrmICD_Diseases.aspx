<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmICD_Diseases.aspx.cs" Inherits="LIMS_WebForms_wfrmICD_Diseases" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
    LIMS: ICD DISEASES:    <% =Session["UNUIDFORMATTED"] %>
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
            width: 142px;
        }
        .style2
        {
            width: 227px;
        }
    </style>
   
</head>
<body>
<script type="text/javascript" charset="utf-8">

    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
       // alert(table);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0)
                table.rows[r].style.display = '';
            else table.rows[r].style.display = 'none';

      //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
</script>
    <form id="form1" runat="server">
    <div>
     <table class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="5"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="5"><font size="4"><STRONG>ICD DISEASES<asp:ScriptManager 
                            ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="5">
                        <asp:ImageButton id="ibtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click" Visible="false"></asp:ImageButton>
						<asp:ImageButton id="ibtnrefresh" runat="server" 
                            ImageUrl="~/images/Refresh.gif" OnClick="ibtnrefresh_Click" Visible="false"></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
					&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
					</TD>
				</TR>
				<TR>
					<TD colSpan="5"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
               </table>
               <br />
                <fieldset style="width:97%">
               <legend>Patient Info</legend>
              
               <table class="label">
               
               <tr>
               <td align="left">Name:</td>
               <td><asp:Label ID="lblPName" CssClass="label" runat="server" Font-Bold="True"></asp:Label></td>
               <td align="left">Type:</td>
               <td><asp:Label ID="lblPType" CssClass="label" runat="server" Font-Bold="True"></asp:Label></td>
               </tr>
               <tr>
                <td align="left">Sex/Age:</td>
               <td><asp:Label ID="lblAge" CssClass="label" runat="server" Font-Bold="True"></asp:Label></td>
               <td align="left">Ward:</td>
               <td><asp:Label ID="lblWard" CssClass="label" runat="server" Font-Bold="True"></asp:Label></td>
               </tr>
               <tr>
               <td align="left" width="10%">
               Reffered By:
               </td>
               <td width="20%">
               <asp:Label ID="lblRefer" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
               </td>
               <td width="10%">
               </td>
               <td></td>
               <td></td>
               </tr>
         
               </table>
               </fieldset>
               <br />
              
                 <fieldset style="width:97%">
               <legend>Search Disease</legend>
               <table class="label">
                <tr>
                 <td align="right" class="style1" >
                Chapter:
                </td>
                <td class="style2">
                <asp:DropDownList ID="ddlICDChapter" Width="98%" AutoPostBack="true" 
                        CssClass="field" runat="server" 
                        onselectedindexchanged="ddlICDChapter_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right">
                Block:
                </td>
                <td>
                <asp:DropDownList ID="ddlICDBlock" Width="60%" AutoPostBack="true" 
                        CssClass="field" Enabled="false" runat="server" 
                        onselectedindexchanged="ddlICDBlock_SelectedIndexChanged"></asp:DropDownList>
                        
                </td>
            
                <td >
                
                </td>
                </tr>
               
                
                <tr>
                <td align="right" class="style1">
                    Filter Results:
                </td>
                <td class="style2" >
                    <asp:TextBox ID="txtSearch" CssClass="field" Width="50%"  runat="server" 
                        Visible="False"></asp:TextBox><input type="text" id="Filtertxt" onkeyup="filter(this,'gvDiseases',2)" class="flattextbox"/>
                        <asp:Button 
                        ID="btnSearch" Text="Search" BackColor="Highlight" Font-Bold="true" 
                        CssClass="buttonStyle" runat="server" onclick="btnSearch_Click" 
                        Visible="False" /> </td>
                <td class="style1"></td>
                <td ></td>
                <td></td>
                </tr>
                <tr><td class="style1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblCount"  Visible="false" runat="server"></asp:Label></td>
                </tr>
                <tr>
                <td colspan="5">
                 <asp:GridView ID="gvDiseases" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datagrid" HorizontalAlign="Center"  Height="9px" AllowSorting="True"
                            OnSorting="gvDiseases_Sorting" OnRowCommand="gvDiseases_RowCommand" DataKeyNames="DISEASEID" Width="60%">
                            <Columns>
                                <%--<asp:BoundField HeaderText="Marital Status" DataField="marital_status">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                </asp:BoundField>--%>
                                <%--<asp:CommandField ShowSelectButton="True">
                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                </asp:CommandField>--%>
                                <asp:TemplateField HeaderText="S#">
                                    <ItemStyle HorizontalAlign="Center" Width="2%" />
                                    <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Disease Code" DataField="DISEASECODE" 
                                    SortExpression="DISEASECODE">
                                <HeaderStyle HorizontalAlign="Left" Width="15%" />
                                    
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Disease Name" DataField="DISEASENAME" 
                                    SortExpression="DISEASENAME" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                   <%--             <asp:BoundField DataField="TEST" HeaderText="Test Name" SortExpression="TEST">
                                   <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                            
                                <asp:BoundField HeaderText="Charges" DataField="CHARGES" SortExpression="CHARGES">
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>--%>
                                <asp:TemplateField SortExpression="Active" HeaderText="Print">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkPrint" runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateField>
                           <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>'>Add</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="8%" />
                        </asp:TemplateField>
                             
                                
                            </Columns>
                            <RowStyle CssClass="gridItem" />
                            <HeaderStyle CssClass="gridheader" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                            
                        </asp:GridView>
                
                </td>
                </tr>
               </table>
               </fieldset>
    </div>
    <div>
   
    </div>
    </form>
</body>
</html>