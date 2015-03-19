<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmConsultantsConfiguration.aspx.cs" Inherits="LIMS_WebForms_wfrmConsultantsConfiguration" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
    
		<title>LIMS: Consultants Configuration : <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	   
	    </HEAD>
<body>
<script type="text/javascript" charset="utf-8">

    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
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
    <TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION:relative; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
                <tr>
					<td colSpan="7"><!-- #include file="LimsHeader2.htm"--></td>
				</tr>
				<tr>
					<td align="center" colSpan="7">
                        
                        <font size="4"><STRONG>CONSULTANTS CONFIGURATION</STRONG></font></td>
				</tr>
                </TABLE>
                <br />
                <div id="divpersons" runat="server">
              
                <fieldset>
                <legend>Search Persons</legend>
                
                <table id="tblsearch" class="label" runat="server" width="100%" border="0">
                <tr>
                <td colspan="7" align="right">
                <asp:ImageButton ID="imgRefresh" runat="server" ImageUrl="~/images/Refresh.gif" OnClick="imgRefresh_Click" />
                <asp:ImageButton ID="imgClode" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="imgClose_Click" />
                </td>
                </tr>
                <tr>
                <td> </td>
                <td>Department:</td>
                <td><asp:DropDownList ID="ddlDepartment" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"></asp:DropDownList>  </td>
                <td>Sub-Department: </td>
                <td><asp:DropDownList ID="ddlSubDepartment" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged"></asp:DropDownList>  </td>
                <td> </td>
                <td> </td>
                </tr>
                 <tr>
                <td>Filter Results: </td>
                <td colspan="3">(By Service Number) <asp:TextBox ID="txtfilterbyservice" runat="server" width="25%" CssClass="field" onkeyup="javascript:filter(this,'gvPersons',1);"></asp:TextBox> &nbsp;(By 
                    Name) <asp:TextBox ID="txtfilterbyname" runat="server" width="25%"
                        CssClass="field" onkeyup="javascript:filter(this,'gvPersons',2);"></asp:TextBox> </td>
                <td>&nbsp;</td>
                <td> </td>
                <td> </td>
               
                </tr>
                 <tr>
                <td> </td>
                <td> </td>
                <td> </td>
                <td> </td>
                <td> </td>
                <td> </td>
                <td> </td>
                </tr>
                 <tr>
                <td colspan="7"><asp:Label ID="lblCount" runat="server" ForeColor="green"></asp:Label>
                 <%--<a href="#divRegistration">GO TO Registration Form</a>--%> </td>
               
                </tr>
                    <tr>
                <td colspan="7">
                <asp:GridView ID="gvPersons" runat="server" CssClass="label" 
                        AutoGenerateColumns="False" 
                        DataKeyNames="PersonID,DepartmentID,SubDepartmentID" AllowSorting="true" 
                        OnRowCommand="gvPersons_RowCommand" OnSorting="gvPersons_Sorting" 
                        onrowcreated="gvPersons_RowCreated">
                        <HeaderStyle HorizontalAlign="Left" ForeColor="Black" CssClass="gridheader" />
                        <RowStyle HorizontalAlign="Left" CssClass="gridItem" />
                        <AlternatingRowStyle HorizontalAlign="left" CssClass="gridAlternate" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" Width="5%" />
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ServiceNo" HeaderText="Service#" 
                        SortExpression="ServiceNo" />
                    <asp:BoundField DataField="PersonName" HeaderText="Person Name" 
                        SortExpression="PersonName" />
                    <asp:BoundField DataField="Designation" HeaderText="Designation" 
                        SortExpression="Designation" />
                    <asp:BoundField DataField="DepSub" HeaderText="Department:SubDepartment" 
                        SortExpression="DepSub" />
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton ID="gvlnkselect" runat="server" Text="Select" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>' ></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                 </td>
             
             
              
                </tr>
                <tr>
                <td width="10%"> </td>
                <td width="10%"> </td>
                <td width="20%"> </td>
                <td width="15%"> </td>
                <td width="20%"> </td>
                <td width="10%"> </td>
                <td width="10%"> </td>
                </tr>

                </table>
                </fieldset>
                  </div>
                <br />
                <div id="divRegistration" runat="server" visible="false">
                
                <fieldset>
                <legend>Registration</legend>
                <table id="tblRegistration" runat="server"  width="100%" class="label">
                <tr>
                <td colspan="7" align="right">
<%--                <a href="#divpersons">go to Persons</a>--%>
                 <asp:ImageButton id="ibtnSave" Enabled="true" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="ibtnSave_Click"></asp:ImageButton>
				
						<asp:ImageButton id="ibtnClear" runat="server" 
                            ImageUrl="~/images/ClearPack.gif" onclick="ibtnClear_Click" 
                            CausesValidation="False"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" 
                            ImageUrl="~/images/ClosePack.gif" CausesValidation="False" 
                            onclick="ibtnClose_Click"></asp:ImageButton>
                            <asp:HiddenField ID="hdperson" runat="server" />
                            <asp:HiddenField ID="hdDepartment" runat="server" />
                            <asp:HiddenField ID="hdSubDepartment" runat="server" />
                            <asp:HiddenField ID="hdReportConsultant" runat="server" />
                </td>
                
                </tr>

                <tr>
                <td colspan="7"><asp:Label ID="lblErr" runat="server" ForeColor="Red" ></asp:Label></td>
               
                </tr>
                <tr>
                <td></td>
                <td>Sub-Department:</td>
                <td>
                <asp:DropDownList ID="ddlSubDepartments" runat="server" CssClass="mandatorySelect" 
                        Width="90%" onselectedindexchanged="ddlSubDepartments_SelectedIndexChanged" AutoPostBack=true></asp:DropDownList>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>

                </tr>

                <tr>
                <td>&nbsp;</td>
                <td>Service#:</td>
                <td><asp:TextBox ID="txtService" runat="server" Width="90%" CssClass="field"></asp:TextBox></td>
                <td colspan="2">Name:
                <asp:TextBox ID="txtName" runat="server" Width="60%" CssClass="field"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;
                Department:
                </td>
                <td colspan="2"><asp:TextBox ID="txtDepartment" runat="server" Width="100%" CssClass="field"></asp:TextBox> </td>
                
                </tr>

                <tr>
                <td></td>
                <td>Level1</td>
                <td><asp:TextBox ID="txtLevel1" TextMode="MultiLine" runat="server" Width="90%" CssClass="field"></asp:TextBox></td>
                <td colspan="2">
                DOrder:
                <asp:DropDownList ID="ddlDorder" runat="server">
                    <asp:ListItem Value="-1">Select</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                     <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    
                    </asp:DropDownList> 
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkActive" Text="Active" Font-Size="X-Small" runat="server" />
                &nbsp;&nbsp;&nbsp;
                </td>
             
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td>Level2</td>
                <td><asp:TextBox ID="txtLevel2" TextMode="MultiLine" runat="server" Width="90%" CssClass="field"></asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td></td>
                <td>Level3</td>
                <td><asp:TextBox ID="txtLevel3" TextMode="MultiLine" runat="server" Width="90%" CssClass="field"></asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>

                <tr>
                <td></td>
                <td>Level4</td>
                <td><asp:TextBox ID="txtLevel4" TextMode="MultiLine" runat="server" Width="90%" CssClass="field"></asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                </tr>

                  <tr>
                <td colspan="7"><asp:Label ID="lblCountreg" runat="server" ForeColor="Green"></asp:Label></td>
                
                </tr>

                  <tr>
                <td colspan="7">
                
                
                <asp:GridView ID="gvConsultants" runat="server" CssClass="label" 
                        AutoGenerateColumns="False" 
                        DataKeyNames="ReportConsultantID,PersonID,DOrder,labsubdepartmentid" 
                        AllowSorting="True" OnSorting="gvConsultants_Sorting" 
                        OnRowCommand="gvConsultants_RowCommand" onrowcreated="gvConsultants_RowCreated">
                        <HeaderStyle HorizontalAlign="Left" ForeColor="Black" CssClass="gridheader" />
                        <RowStyle HorizontalAlign="Left" CssClass="gridItem" />
                        <AlternatingRowStyle HorizontalAlign="left" CssClass="gridAlternate" />
                <Columns>
                    <asp:TemplateField HeaderText="S#">
                    <HeaderStyle CssClass="gridheader" HorizontalAlign="Center" Width="5%" />
                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                    <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Sub Department" DataField="LabSubDepartment" SortExpression="LabSubDepartment" />
                    <asp:BoundField DataField="Level1" HeaderText="Level 1" 
                        SortExpression="level1" />
                    <asp:BoundField DataField="level2" HeaderText="Level 2" 
                        SortExpression="level2" />
                    <asp:BoundField DataField="level3" HeaderText="Level 3" 
                        SortExpression="level3" />
                    <asp:BoundField DataField="level4" HeaderText="Level 4" 
                        SortExpression="level4" />
                    <asp:TemplateField HeaderText="Active" SortExpression="Active">
                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                        <asp:CheckBox ID="gvchkActive" runat="server" Enabled="false" Checked='<%#(DataBinder.Eval(Container.DataItem,"Active").ToString()=="Y") %>' />
                            <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("Active") %>'></asp:Label>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Dorder" HeaderText="D Order" 
                        SortExpression="DOrder" />
                    <asp:TemplateField>
                    <ItemTemplate>
                    <asp:LinkButton ID="gvlnkEdit" runat="server" Text="Edit" CommandName="Select" CommandArgument='<%# Container.DataItemIndex %>'></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
                
                
                </td>
           
                </tr>
                <tr>
                <td width="10%"> </td>
                <td width="10%"></td>
                <td width="20%"> </td>
                <td width="15%"> </td>
                <td width="20%"> </td>
                <td width="10%"> </td>
                <td width="10%"> </td>
                </tr>
                </table>
                </fieldset>
                </div>

                

    </div>
    </form>
</body>
</html>
