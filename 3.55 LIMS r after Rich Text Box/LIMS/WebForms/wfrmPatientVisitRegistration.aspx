<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmPatientVisitregistration.aspx.cs" Inherits="WebForms_wfrmPatientVisitRegistration" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<script runat="server">

    [System.Web.Services.WebMethod]
    public string GetHtml(string contextKey)
    {
        // a little pause to mimic a latent call.
        //
        System.Threading.Thread.Sleep(250);

        string value = "";
        if (contextKey == "U")
        {
            value = DateTime.UtcNow.ToString();
        }
        else
        {
            value = String.Format("{0:" + contextKey + "}", DateTime.Now);
        }

        return String.Format("<span style='font-family:courier new;font-weight:bold;'>{0}</span>", value);

    }

</script>

<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN" >

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
		<title>HMIS: Patient Visit Registration</title>
		<link href="../../LIMS.css"rel="stylesheet" />

<script language="javascript" type="text/javascript">
<!-- 

    function updateDateKey(value) {

        var behavior = $object('DynamicPopulateExtender1');

        if (behavior) {
            behavior.populate(value);
        }
    }
    alert(value);
    Sys.Application.load.add(function(){updateDateKey('G');}
  )

function IMG1_onclick() {
    updateDateKey(this.value);
}

 -->
function formatdate(o){
				//alert(o.value);
				
				if(event.keyCode < 37 || event.keyCode > 40 ){
					if(event.keyCode != 46 && event.keyCode!=8)
					{
						if(o.value.length > 0)
						{
							removeSlashes(o);
							placeSlashes(o);
						}
						}
					}	
					
			}
			function placeSlashes(o){
				
				if(o.value.length > 2){
					o.value = o.value.substring(0,2)+"/"+o.value.substring(2,o.value.length);
				}
				if(o.value.length > 5){
					o.value = o.value.substring(0,5)+"/"+o.value.substring(5,o.value.length);
				}
			}
			function removeSlashes(o){
				index = o.value.indexOf("/");
				if(index !=-1){
					while(index != -1){
						o.value = (o.value).substring(0,index)+ (o.value).substring(index+1 , (o.value).length);
						index = o.value.indexOf("/");
					}
				}
			}
</script>
    
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
		
</head>
<body>
    
    <form id="form1" runat="server">                
    <div>
       <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
        
<table class="label" id="table1" cellspacing="1" cellpadding="1" width="100%" border="0">
				<tr>
					<td colspan="7" style="height: 16px"><!-- #include file="limsheader2.htm"-->
                        <asp:Label ID="lblPersonName" runat="server" Font-Bold="true"></asp:Label></td>
				</tr>
				<tr>
					<td align="center" colspan="7" style="height: 24px"><font size="4"><strong> PATIENT VISIT&nbsp;REGISTRATION</strong></font></td>
				</tr>
				<tr>
					<td width="5%"></td>
					<td width="15%">
                        </td>
					<td width="25%">
                    </td>
					<td width="15%"></td>
					<td width="25%">
            </td>
					<td width="10%"></td>
					<td width="5%"></td>
				</tr>
				<tr>
					<td colspan="7"><asp:label id="lblErrMsg" runat="server" ForeColor="Red" Font-Bold="true" Width="100%"></asp:label></td>
				</tr>
				<tr>
					<td style="height: 44px"></td>
                    <td colspan="2" style="height: 44px">
                        <strong><span style="font-size: 10pt">Registered Patient Information:</span></strong></td>
					<td style="height: 44px">
                        <asp:ImageButton ID="ibtnPanelPatient" runat="server" Visible ="false" ImageUrl="~/images/Patient-Registration.gif"
                            OnClick="ibtnPanelPatient_Click" TabIndex="24" AccessKey="r" ToolTip="Press To View Patient Registeration (Alt+R)" /></td>
                    <td colspan="2" align="right" style="height: 44px">
                        <asp:ImageButton id="lbtnSave" runat="server" ImageUrl="~/images/SavePack_2.gif" OnClick="lbtnSave_Click" TabIndex="23" AccessKey="s" ToolTip="Press To Save (Alt+S)"></asp:ImageButton><asp:ImageButton id="lbtnClearAll" runat="server" ImageUrl="~/images/ClearPack.gif" TabIndex="24" OnClick="lbtnClearAll_Click" AccessKey="c" ToolTip="Press To Clear (Alt+C)"></asp:ImageButton><asp:imagebutton id="btnClose" tabIndex="26" runat="server" ImageUrl="~/images/ClosePack.gif" OnClick="btnClose_Click" AccessKey="x" ToolTip="Close Screen  (Alt+X)"></asp:imagebutton></td>
					<td style="height: 44px"></td>
				</tr>
				<tr>
					<td></td>
					<td>
                        PRNo :</td>
					<td>
						<asp:textbox id="txtPRNo" runat="server" Width="115px" CssClass="mandatoryfield" MaxLength="12" TabIndex="1"></asp:textbox>
						<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPRNo" AutoCompleteValue="0" ClearMaskOnLostFocus="False" Mask="99\-99\-999999" />
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click" ImageUrl="~/images/btn_Blank.GIF" ToolTip="Press to Search  PR No." TabIndex="2" />&nbsp;</td>
					<td>
                        <asp:TextBox ID="txtPatientVisitNo" runat="server" Visible="False"></asp:TextBox></td>
					<td colspan="2" align="right">
                        <asp:CheckBox ID="chkPrint" runat="server" Text="Print Visit Slip" Visible="False" /></td>
					<td></td>
				</tr>
				<tr>
					<td style="height: 25px"></td>
					<td style="height: 25px">
                        Patient Name</td>
                    <td colspan="4" style="height: 25px">
                        <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="mandatoryfield"
                            TabIndex="1" Width="115px" Enabled="False" >
                            <asp:ListItem Selected="true" Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="Mr">Mr</asp:ListItem>
                            <asp:ListItem Value="Miss">Miss</asp:ListItem>
                            <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="txtFName" runat="server" CssClass="Field" MaxLength="20"
                                        TabIndex="2" Width="210px" ReadOnly="true" ToolTip="Patient First Name"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="txtMName" runat="server" CssClass="field" MaxLength="15" TabIndex="3" Width="135px" ReadOnly="true" ToolTip="Patient  Middel Name"></asp:TextBox>&nbsp;
                                    <asp:TextBox ID="txtLName" runat="server" CssClass="field" MaxLength="15" TabIndex="4" Width="137px" ReadOnly="true" ToolTip="Patient Last Name"></asp:TextBox></td>
					<td style="height: 25px"></td>
				</tr>
				<tr>
					<td></td>
					<td>
                        Gender:</td>
                    <td colspan="3">
                        <asp:DropDownList ID="ddlSex" runat="server" CssClass="mandatoryfield" TabIndex="5"
                            Width="115px" Enabled="False">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="M">Male</asp:ListItem>
                            <asp:ListItem Value="F">Female</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        Date of Birth:
                        <asp:TextBox ID="txtdOB" runat="server"  onkeyup="formatdate(this)" CssClass="Field" MaxLength="10"
                            Rows="3" TabIndex="6" Width="112px" ReadOnly="true">Date Of Birth</asp:TextBox>
                        (<font
                                size="1">DD/MM/YYYY</font>)</td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td></td>
					<td>
                        Marital Status:</td>
					<td><asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="mandatoryfield"
                            TabIndex="7" Width="115px" Enabled="False">
                            <asp:ListItem Value="-1">Select</asp:ListItem>
                            <asp:ListItem Value="S">Single</asp:ListItem>
                            <asp:ListItem Value="M">Married</asp:ListItem>
                        </asp:DropDownList></td>
					<td></td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td style="height: 18px"></td>
					<td colspan="2" style="height: 18px">
                        <strong><span style="font-size: 10pt">Visit Master Information:</span></strong></td>
					<td style="height: 18px"></td>
					<td style="height: 18px">
                        <asp:Label ID="lblDept" runat="server" Visible="False"></asp:Label></td>
					<td style="height: 18px"></td>
					<td style="height: 18px"></td>
				</tr>
				<tr>
					<td style="height: 26px"></td>
					<td style="height: 26px">
                        Patient
            Condition:</td>
                    <td colspan="3" style="height: 26px">
                        <asp:DropDownList ID="ddlCondition" runat="server" CssClass="mandatoryfield" TabIndex="8" Width="115px">
            <asp:ListItem Value="N">Normal</asp:ListItem>
            <asp:ListItem Value="C">Critical</asp:ListItem>
            <asp:ListItem Value="S">Severe</asp:ListItem>
        </asp:DropDownList>
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:CheckBox ID="chkFollowUp" runat="server" Text="Follow Up: " TextAlign="Left" Width="140px" TabIndex="9" Visible="False" /><asp:CheckBox ID="chkEmergency" runat="server" Text="Emergency: " TextAlign="Left" Width="162px" TabIndex="10" Visible="False" /></td>
					<td style="height: 26px"></td>
					<td style="height: 26px"></td>
				</tr>
    <tr>
        <td style="height: 25px">
        </td>
        <td style="height: 25px">
        </td>
        <td colspan="3" style="height: 25px">
        </td>
        <td style="height: 25px">
        </td>
        <td style="height: 25px">
        </td>
    </tr>
				<tr valign="top">
					<td ></td>
                    <td colspan="2">
                        <strong><span style="font-size: 10pt">Visit Detail Information:</span></strong></td>
					<td >
            </td>
                    <td colspan="2">            
                    </td>
					<td></td>
				</tr>
    <tr>
        <td style="width: 50px">
        </td>
        <td colspan="2">
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
            <table class="label" id="table2" cellspacing="1" cellpadding="1" width="400" border="0">                        <tr>
                            <td width="30%">
                                <%--Department:--%></td>
                            <td width="70%" class="mandatoryField">
            <asp:DropDownList ID="ddlDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged"
                TabIndex="11" Width="100%" ToolTip="Select Department" Visible="False">
            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td>
                                Sub-Department:</td>
                            <td class="mandatoryField">
            <asp:DropDownList ID="ddlSubDepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlSubDepartment_SelectedIndexChanged"
                TabIndex="12" Width="100%" ToolTip="Select Sub Department">
            </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
            <asp:datagrid id="dgService" runat="server" CssClass="datagrid" AllowCustomPaging="true" PageSize="25"
							AutoGenerateColumns="False" AllowSorting="true" Width="100%" TabIndex="13" Visible="False">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
                <HeaderStyle CssClass="gridheader" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    ForeColor="Black" />
                <Columns>
                    <asp:BoundColumn DataField="SERVICEID" HeaderText="ServiceID" Visible="False">
                        <HeaderStyle Width="10%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="NAME" HeaderText="ServiceName">
                        <HeaderStyle Width="70%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="RATE" HeaderText="Amount">
                        <HeaderStyle Width="20%" />
                    </asp:BoundColumn>
                    <asp:TemplateColumn HeaderText="Select">
                        <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelect" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle Width="10%" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                    </asp:TemplateColumn>
                </Columns>
                <PagerStyle Font-Bold="False" Font-Italic="False" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" ForeColor="Blue" />
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
						</asp:datagrid></td>
                        </tr>
                        <tr>
                            <td style="height: 32px"></td>
                            <td  align="right" style="height: 32px">
            <asp:ImageButton ID="btnAdd" runat="server" ImageUrl="~/images/AddPack.gif" OnClick="btnAdd_Click" CausesValidation="False" OnClientClick="updateDateKey(this.value);" TabIndex="14" Visible="False" /></td>
                        </tr>
                    </table>
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </td>
        <td colspan="3" style="vertical-align: top">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="False">
            <ContentTemplate>
            <table class="label" id="table3" cellspacing="1" cellpadding="1" width="300" border="0">
                        <tr>
                            <td style="height: 11px" width="30%"> </td>
                            <td style="height: 11px" width="30%"> </td>                        
                        </tr>
                        <tr>
                            <td style="height: 27px"> </td>
                            <td style="height: 27px"> </td>                        
                        </tr>
                        <tr>
                            <td colspan="2">
                            <asp:DataGrid id="dgServiceSelected" runat="server" CssClass="datagrid" AllowCustomPaging="true" PageSize="25"
							AutoGenerateColumns="False" AllowSorting="true" Width="100%" TabIndex="22" Visible="False">
                <SelectedItemStyle CssClass="gridSelectedItem" Font-Names="Verdana" Font-Size="X-Small"
                    ForeColor="Black" />
                <PagerStyle Font-Bold="False" Font-Italic="False" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" ForeColor="Blue" />
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Names="Verdana" Font-Overline="False"
                    Font-Size="X-Small" Font-Strikeout="False" Font-Underline="False" ForeColor="Black" />
                <HeaderStyle CssClass="gridheader" Font-Bold="True" Font-Names="Verdana" Font-Size="X-Small"
                    ForeColor="Black" />
                <Columns>
                    <asp:BoundColumn DataField="ServiceID" HeaderText="ServiceID" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="ServiceName" HeaderText="ServiceName">
                        <HeaderStyle Width="80%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="Amount" HeaderText="Amount">
                        <HeaderStyle Width="20%" />
                    </asp:BoundColumn>
                    <asp:BoundColumn DataField="DepartmentID" HeaderText="DepartmentID" Visible="False"></asp:BoundColumn>
                    <asp:BoundColumn DataField="SubDepartmentID" HeaderText="SubDepartmentID" Visible="False"></asp:BoundColumn>
                </Columns>
            </asp:DataGrid></td>
            </tr>
                        <tr>
                            <td>
                                <%--Total Amount:--%></td>
                            <td>
                                <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="mandatoryfield" MaxLength="15"
                TabIndex="1" Width="100%" ReadOnly="true" Visible="False"></asp:TextBox></td>
                        </tr>
                </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            
        </td>
        <td>
        </td>
    </tr>
				<tr>
					<td class="screenid" align="right" colspan="7"></td>
				</tr>
			</table>    
    </div>
    </form>
</body>
</html>
