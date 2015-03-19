<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmResultDispatcher" CodeFile="wfrmResultDispatcher.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

<style type="text/css">
.tableClass
{
    width: 50%;background-color: #fff;
    margin: 5px 0 10px 0;border: 1px solid #00CCFF;border-collapse: collapse;
}
.tableClass td {
background: #fff;font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
padding: 6px 6px 6px 12px;color: #4f6b72;border-right: 1px solid #00CCFF;
}
.tableClass th{
    background-position: #D5EDEF;font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
    color: #4f6b72;border-right: 1px solid #00CCFF;border-bottom: 1px solid #00CCFF;
    border-top: 1px solid #00CCFF;border-left: 1px solid #00CCFF;letter-spacing: 2px;
    text-transform: uppercase;text-align: left; padding: 6px 0px 6px 12px;
    background: #D5EDEF;
}

.MenuStyle{background-color: #f5f5f5;width: 120px;position: absolute;border: #d3d3d3 1px solid;} 
.MenuItem { background-color: Transparent; }
.MenuItem:hover { background-color: #c2c2c2; }
.MenuItem:active { background-color: #c2c2c2; }

.contextMenu
{
    background-color: #BECFEF;border: 1px solid #94A8CD;    
    width: 120px;position: absolute;
}
.contextMenu tr
{    
    font: normal 12px Arial;border: 1px solid #E4E1DE;background-color: #9AB7E7;    
}
.contextMenu td {
font: bold 11px "Trebuchet MS" , Verdana, Arial, Helvetica, sans-serif;
color: #FFFFFF;border: 1px solid #E4E1DE;
}
.contextMenu tr:active
{
    background-color: #00CCFF;    
}
.contextMenu tr:hover {background: #424242 url(grd_head.png) repeat-x top; cursor: pointer; }
</style>




		<title>LIMS: Result Dispatcher:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
        <%--<script src="../../scripts/jquery-1.7.1.min.js" language="javascript"></script>--%>
        
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
        <script language="javascript" type="text/javascript">
            
            
           
     //       $(document).bind('click', function (e) {
       //         $("#myMenu").hide();
         //   });
            //hide when left mouse is clicked
            

            </script>
            <script type="text/javascript">
                function getalltests(celll) {
                    var labid = celll.innerHTML;
                    //alert(labid);
                    var grid = document.getElementById('dgResultDis');
                    var btnsearchlab = document.getElementById('btncopylabidsearch');
                  //  document.getElementById('txtMSerialNoFrom').value = celll.innerHTML;
                   // btnsearchlab.click();
                   // alert(grid.rows[3].cells[3].innerHTML);
                    for (var i = 1; i <= grid.rows.length; i++) {

                        if (grid.rows[i].cells[3].innerHTML.indexOf(labid) >= 0) {
                            //document.getElementById(celll).style.backgroundcolor="yellow";
                            //alert('labid found');
                            //alert(i);
                            //alert(grid.rows.length);
                            if (parseInt(i) == parseInt(grid.rows.length - 2) && parseInt(grid.rows.length) >= 30) { //if last id is clicked then post pack form and filter form according to labid
                                var btnsearchlab = document.getElementById('btncopylabidsearch');
                                document.getElementById('txtMSerialNoFrom').value = celll.innerHTML;
                                btnsearchlab.click();

                            }
                            //alert('dgResultDis_ctl' + padDigits(i + 1, 2) + '_dgchkPrint');
                            else {
                                document.getElementById('dgResultDis_ctl' + padDigits(i + 2, 2) + '_dgchkPrint').checked = true;
                                grid.rows[i].setAttribute("style", "background-color:yellow;");
                            } 
                        }
                        else {
                            grid.rows[i].setAttribute("style", "background-color:transparent;");
                            document.getElementById('dgResultDis_ctl' + padDigits(i + 2, 2) + '_dgchkPrint').checked = false;
                        }
                    }

                }
                function changebackgroundcolor(celll) {
                    
                }
                function ShowMenu(e,labid) {
                    var mmmenu = document.getElementById('myMenu');
                    //alert(labid.toString());
                    mmmenu.style.position = "absolute";
                    mmmenu.style.top = e.pageY.toString() + "px ";
                    mmmenu.style.left = +e.pageX.toString() + "px";

                    mmmenu.style.display = 'block';
                    mmmenu.getElementsByTagName("td").item(0).innerHTML = labid;


                return false;
                        //rowid = $(this).children(':first-child').text();
                        
                
                }

                function onloadfunction() {
                    //alert('I am called');
                    $("#myMenu").hide();

                    //alert($("table[id$ = 'dgResultDis']"));

                }
                function hidemenu() {
                    $("#myMenu").hide();
                }
            function CheckuncheckAll(cbselect) {
               // alert(cbselect.);
                var table = document.getElementById('dgResultDis');
               // alert(table)
                if (cbselect.checked) {
                    //alert(table.rows.length);
                    for (var i = 1; i < table.rows.length; i++) {
                        document.getElementById('dgResultDis_ctl' + padDigits(i + 2, 2) + '_dgchkPrint').checked = true;

                    }

                }
                else {
                    for (var i = 1; i < table.rows.length; i++) {
                        document.getElementById('dgResultDis_ctl' + padDigits(i + 2, 2) + '_dgchkPrint').checked = false;

                    }
                }
            }
            function padDigits(number, digits) {
                return Array(Math.max(digits - String(number).length + 1, 0)).join(0) + number;
            }
            function chkallchanged(cb) {
                if (cb.checked == true) {
                    //alert(cb.checked);
                    document.getElementById('chkUnpaid').checked = true;
                    document.getElementById('chkSpecimen').checked = true;
                    document.getElementById('chkREntry').checked = true;
                    document.getElementById('chkVerification').checked = true;
                    document.getElementById('chkDispatch').checked = true;
                    document.getElementById('chkDelivered').checked = true;
                    document.getElementById('chkSpecimenOutQueue').checked = true;
                    document.getElementById('chkSpecomenInQueue').checked = true;
                    document.getElementById('chkSpecimenPending').checked = true;
                    //unpaid.checked = true;
                }
                else {
                    document.getElementById('chkUnpaid').checked = false;
                    document.getElementById('chkSpecimen').checked = false;
                    document.getElementById('chkREntry').checked = false;
                    document.getElementById('chkVerification').checked = false;
                    document.getElementById('chkDispatch').checked = false;
                    document.getElementById('chkDelivered').checked = false;
                    document.getElementById('chkSpecimenOutQueue').checked = false;
                    document.getElementById('chkSpecomenInQueue').checked = false;
                    document.getElementById('chkSpecimenPending').checked = false;
                }
                //alert(cb);
                //var cb = document.getElementById(cb);
               // alert(cb.checked);
                //display("Changed, new value = " + cb.checked);
            }
            function addprefix() {
                //  alert('I am called');
                var today = new Date();
                if (document.getElementById('txtMSerialNoFrom').value.toString().replace('__-___-_______', '') == '') {
                    document.getElementById('txtMSerialNoFrom').value = today.getFullYear().toString().substr(2, 2) + '-001-';
                } 
            }
            
        </script>

	    </head>
	<body onload="onloadfunction()" onclick="hidemenu()">
    
		<form id="Form1" method="post" defaultbutton="ImgbtnRefresh" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 1px; POSITION: absolute; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="7"><font size="4"><STRONG>RESULT DISPATCH</STRONG></font></TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2" style="HEIGHT: 22px"><asp:radiobuttonlist id="rbtnlArchiver" Visible="false" runat="server" Font-Size="Small" BorderColor="Silver" BorderWidth="1px"
							RepeatDirection="Horizontal" onselectedindexchanged="rbtnlArchiver_SelectedIndexChanged">
							<asp:ListItem Value="N" Selected="True">Non-Archived</asp:ListItem>
							<asp:ListItem Value="Y">Archived</asp:ListItem>
						</asp:radiobuttonlist></TD>
                        <td colspan="4" align="right">
                        <asp:Button ID="ImgbtnReset" Text="   Reset   " onclick="lbtnReset_Click" runat="server" />
                        <asp:Button ID="ImgbtnRefresh" Text="   Refresh   " onclick="lbtnRefresh_Click" runat="server" />
                        <asp:Button ID="imgbtnpRint" Text="   Print   " Visible="false" onclick="lbtnPrint_Click"  runat="server" />
                         <asp:Button ID="btnClose" Text="   Close   " Visible="true" runat="server" 
                                onclick="btnClose_Click" />
                        </td>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="15%">Organization</TD>
					<TD width="27%"><asp:dropdownlist id="ddlOrganization" tabIndex="1" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right" width="13%">&nbsp;PR No:&nbsp;</TD>
					<TD width="35%"><asp:textbox id="txtPRNo" tabIndex="2" runat="server" Width="100px" 
                            CssClass="field" MaxLength="10"
							ToolTip="Enter Patient Registration Number"></asp:textbox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtPRNo" Mask="99-99-999999" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>
                    
                            </TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Sub-Department:</TD>
					<TD><asp:dropdownlist id="ddlSection" tabIndex="3" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Patient Name:&nbsp;&nbsp;</TD>
					<TD><asp:textbox id="txtPatientName" tabIndex="4" runat="server" Width="100%" CssClass="field" MaxLength="45"
							ToolTip="Enter Patient Name (optional)"></asp:textbox></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test Group:</TD>
					<TD><asp:dropdownlist id="ddlTestGroup" tabIndex="5" runat="server" Width="100%" AutoPostBack="True" Enabled="False" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD align="right">Sex:&nbsp;&nbsp;</TD>
					<TD><asp:dropdownlist id="ddlSex" tabIndex="6" runat="server">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="Male">Male</asp:ListItem>
							<asp:ListItem Value="Female">Female</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Test:</TD>
					<TD><asp:dropdownlist id="ddlTest" tabIndex="7" runat="server" Width="100%" Enabled="False"></asp:dropdownlist></TD>
					<TD align="right">Lab - ID:&nbsp;&nbsp;</TD>
					<TD>
                    <asp:Panel ID="pnllabsearch" runat="server" DefaultButton="btncopylabidsearch">
                    <asp:textbox id="txtMSerialNoFrom" tabIndex="8" runat="server"  Width="100px" CssClass="field"
						 ToolTip="Enter labid for view to start from (optional)"></asp:textbox>         <%--onfocus="javascript:addprefix()"--%>
                         <asp:Button ID="btncopylabidsearch" runat="server" Text=">" OnClick="btncopylabidsearch_Click" Height="20px" />
                           <%--<asp:MaskedEditExtender ID="msklabfrom" runat="server" TargetControlID="txtMSerialNoFrom" Mask="99-999-9999999" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>--%>
						<asp:textbox id="txtMSerialNoTo" tabIndex="9" runat="server" Width="100px" CssClass="field"
							ToolTip="Enter labid for view to end at (optional)"></asp:textbox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtMSerialNoTo" Mask="99-999-9999999" ClearMaskOnLostFocus="false"></asp:MaskedEditExtender>
                            </asp:Panel>
                            </TD>
					<TD></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px"></TD>
					<TD style="HEIGHT: 17px">Ward:</TD>
					<TD style="HEIGHT: 17px">
						<asp:dropdownlist id="ddlWard" tabIndex="36" runat="server" Width="100%"></asp:dropdownlist></TD>
					<TD align="right" style="HEIGHT: 17px">Lab - Date :</TD>
					<TD style="HEIGHT: 17px">
						<asp:TextBox id="txtDF" tabIndex="10" runat="server" Width="100px" 
                            CssClass="field"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						&nbsp;&nbsp;
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDF">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtDF" Mask="99/99/9999"
                            MaskType="Date"></asp:MaskedEditExtender>
                        
						<asp:textbox id="txtDT" tabIndex="11" runat="server" Width="100px" ToolTip="Enter Serial No for view to end at (optional)"
							MaxLength="10" CssClass="field"></asp:textbox>
                             <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="txtDT">
                        </asp:CalendarExtender>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" ClearMaskOnLostFocus="false"
                            AutoComplete="false" AcceptAMPM="false" TargetControlID="txtDT" Mask="99/99/9999"
                            MaskType="Date"></asp:MaskedEditExtender>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
					<TD style="HEIGHT: 17px"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px"></TD>
					<TD style="HEIGHT: 19px">Patient Type:</TD>
					<TD colspan="2" style="HEIGHT: 19px">
						<asp:radiobuttonlist id="rbtnPatientType" runat="server" RepeatDirection="Horizontal" BorderWidth="1px"
							BorderColor="Olive" Font-Size="Small" Width="100%" BorderStyle="Dotted">
							<asp:ListItem Value="A" Selected="True">ALL</asp:ListItem>
							<asp:ListItem Value="E">Entitled</asp:ListItem>
							<asp:ListItem Value="C">Private</asp:ListItem>
							<asp:ListItem Value="P">Panel</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD align="center">
						<asp:radiobuttonlist id="rbtnIO" runat="server" RepeatDirection="Horizontal" BorderWidth="1px" BorderColor="Olive"
							Font-Size="Small" Width="100%" BorderStyle="Dotted">
							<asp:ListItem Value="A" Selected="True">ALL</asp:ListItem>
							<asp:ListItem Value="I">Indoor</asp:ListItem>
							<asp:ListItem Value="O">Outdoor</asp:ListItem>
						</asp:radiobuttonlist></TD>
					<TD style="HEIGHT: 19px"></TD>
				</TR>
                 <tr>
                 <td colspan="2" style="display:none;"> 
						<asp:linkbutton id="lbtnReset" tabIndex="10" runat="server" 
                            Font-Size="Small" ToolTip="Click to refresh the view upon selected parameters"
							ForeColor="Blue" onclick="lbtnReset_Click">Reset</asp:linkbutton>&nbsp;|
                        <asp:LinkButton ID="lbtnRefresh" runat="server" Font-Size="Small" 
                            ForeColor="Blue" onclick="lbtnRefresh_Click" tabIndex="10" 
                            ToolTip="Click to refresh the view upon selected parameters">Refresh</asp:LinkButton>
                        &nbsp;|
                        <asp:LinkButton ID="lbtnAll" runat="server" Font-Size="X-Small" 
                            ForeColor="Blue" onclick="lbtnAll_Click" tabIndex="11" 
                            ToolTip="Click to view the result without any parameter selection" 
                            Visible="False">All</asp:LinkButton>
                        <asp:LinkButton ID="lbtnPrint" runat="server" Font-Size="Small" 
                            ForeColor="Blue" onclick="lbtnPrint_Click" tabIndex="12" 
                            ToolTip="Click to view Report">Print</asp:LinkButton>
                     </td>

                <td colspan="5" align="right">
              
                <asp:Panel ID="pnlprocesses" runat="server">
               <%-- <label><input type='checkbox' id="chkAll" onchange='chkallchanged(this);' />All</label>--%>
                <asp:CheckBox ID="chkall" runat="server" onclick="javascript:chkallchanged(this);" Text="All" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Checkbox ID="chkUnpaid"  BackColor="BurlyWood" Text="UnPaid" Checked="false"  
                        runat="server" Font-Size="Smaller"></asp:Checkbox>
                <asp:Checkbox ID="chkSpecimen" BackColor="Yellow" Text="Specimen Collection" 
                        Checked="false"  runat="server" Font-Size="Smaller"></asp:Checkbox>
                        <asp:Checkbox ID="chkSpecimenPending" BackColor="#993333" Text="Specimen Pending" 
                        Checked="false"  runat="server" Font-Size="Smaller"></asp:Checkbox>
                <asp:CheckBox ID="chkSpecimenOutQueue" runat="server" BackColor="SeaShell" Text="Specimen Out Queue"  Font-Size="Smaller" />

<asp:CheckBox ID="chkSpecomenInQueue" runat="server" BackColor="RoyalBlue" Text="Specimen In Queue"  Font-Size="Smaller" />
                <asp:Checkbox ID="chkREntry" BackColor="Aqua" Text="Result Entry" Checked="false"  
                        runat="server" Font-Size="Smaller"></asp:Checkbox>
                <asp:Checkbox ID="chkVerification" BackColor="Orchid" Text="Provisional" 
                        Checked="false"  runat="server" Font-Size="Smaller"></asp:Checkbox>
                <asp:Checkbox ID="chkDispatch" BackColor="White" Text="Dispatch" Checked="false"  
                        runat="server" Font-Size="Smaller"></asp:Checkbox>
                <asp:Checkbox ID="chkDelivered"   BackColor="SpringGreen" Text="Delivered" 
                        Checked="false"  runat="server" Font-Size="Smaller"></asp:Checkbox>
                </asp:Panel>
              
                </td>
                <td></td>
                </tr>
				<TR>
					<td colSpan="6"><asp:label id="lblRecordNo" runat="server" Width="520px" ForeColor="ForestGreen"></asp:label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
						</td>
				</TR>
               

				<%if(this.rbtnlArchiver.SelectedItem.Value.Equals("N")){%>
				<TR>
					<TD colSpan="6" style="HEIGHT: 22px">
						<asp:checkbox id="chkSelect" tabIndex="13" runat="server" Font-Size="X-Small" AutoPostBack="false"
							Text="Select" onClick="javascript:CheckuncheckAll(this);" Visible="false"></asp:checkbox>&nbsp;&nbsp;
						<asp:checkbox id="chkArchived" tabIndex="13" runat="server" Font-Size="X-Small" Text="Archive on Print"
							Checked="false" Visible="false"></asp:checkbox>&nbsp;&nbsp;
&nbsp;                            <asp:Label ID="lblComentedcc" runat="server" Text="Commented" BackColor="Green"></asp:Label>
                             
                            </TD>
                           
				</TR>
				<%}%>
                
				<TR>
					<TD colSpan="6">
                    <asp:datagrid id="dgResultDis" runat="server" Width="100%" 
                            BorderColor="Silver" AutoGenerateColumns="False"
							AllowSorting="True" onselectedindexchanged="dgResultDis_SelectedIndexChanged" 
                            OnItemDataBound="dgResultDis_ItemDataBound" 
                            onitemcreated="dgResultDis_ItemCreated" AllowPaging="True" PageSize="30" 
                            OnPageIndexChanged="dgResultDis_PageIndexChanged">
							<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle CssClass="gridItem"></ItemStyle>
							<HeaderStyle CssClass="gridheader" HorizontalAlign="Left" Font-Bold="true"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Print" Visible="False">
									<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox Checked="False" ID="dgchkPrint" Runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Priority" ReadOnly="True" HeaderText="Priority">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSerialNo" Visible="false" ReadOnly="True" HeaderText="Receipt ID">
									<HeaderStyle HorizontalAlign="Center" Width="7%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
                                <asp:BoundColumn DataField="PRNo" HeaderText="PR No"></asp:BoundColumn>
                                <asp:BoundColumn DataField="LabID" ReadOnly="true" HeaderText="Lab ID">
                                <HeaderStyle HorizontalAlign="left" Width="10%" />
                                <ItemStyle HorizontalAlign="left" Width="10%" />
                                </asp:BoundColumn>

								<asp:BoundColumn DataField="Test" ReadOnly="True" HeaderText="Test">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PatientName" ReadOnly="True" HeaderText="Patient Name">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PSex" ReadOnly="True" HeaderText="Sex">
									<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="PAge" ReadOnly="True" HeaderText="Age">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="Type" HeaderText="Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="EnteredDate" ReadOnly="True" HeaderText="Entry Date">
									<HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
                                <asp:BoundColumn DataField="DeliveryDate" ReadOnly="True" HeaderText="Delivery Date">
									<HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
                                
								<asp:BoundColumn DataField="WardName" HeaderText="Ward">
									<HeaderStyle HorizontalAlign="Left" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo"></asp:BoundColumn>
								<asp:ButtonColumn Text="Details" Visible="false" CommandName="Details">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:ButtonColumn>
								<asp:ButtonColumn Text="Result Entry" Visible="false" CommandName="SenttoResultEntry" 
                                    HeaderText="Send to ">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:ButtonColumn>
							    <asp:BoundColumn DataField="processID" HeaderText="ProcessID" Visible="False">
                                </asp:BoundColumn>
							    <asp:BoundColumn DataField="spec_coment" Visible="False"></asp:BoundColumn>
                                <asp:TemplateColumn Visible="false">
                                <ItemTemplate>
                                <asp:LinkButton ID="lnkimgpath1" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"path_img1") %>' OnClick="lnkimgpath1_Click"></asp:LinkButton> 
                                <asp:LinkButton ID="lnkimgpath2" Visible="false" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"path_img2") %>' OnClick="lnkimgpath2_Click"></asp:LinkButton>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:BoundColumn HeaderText="Booked At" DataField="Origin"></asp:BoundColumn>
                                <asp:TemplateColumn>
                                <ItemTemplate>
                                <asp:HyperLink ID="lbtnPrint" runat="server">
                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print.png" Width="20px" Height="20px"  />
                                </asp:HyperLink>
                                </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn>
                                <ItemTemplate>
                                <asp:HyperLink ID="lbtnPrintall" runat="server">
                                <asp:Image ID="imgprintall" runat="server" ImageUrl="~/images/PrintAll.gif" Width="20px" Height="20px"  />
                                </asp:HyperLink>
                                <asp:HyperLink ID="lbtnEmail" runat="server">
                                <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/mail.png" Width="20px" Height="20px"  />
                                </asp:HyperLink>
                                </ItemTemplate>
                                </asp:TemplateColumn>
							</Columns>
							<PagerStyle Font-Size="Small" Position="Bottom" HorizontalAlign="Center" PageButtonCount="10" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_018</TD>
				</TR>
                <tr>
                <td colspan="6">
                <div id="myMenu" class="contextMenu">
<table style='width:100%; display:none;'>
    <tr><td onclick="getalltests(this);">Check this visit No</td></tr>
    
</table>
</div>
<div id="conteneurmenu" style="display:none;"
></div>
                </td>
                </tr>
			</TABLE>
		</form>
        
	</body>
</HTML>
