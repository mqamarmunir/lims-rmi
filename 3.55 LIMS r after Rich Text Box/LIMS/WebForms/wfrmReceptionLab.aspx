<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmReceptionLab.aspx.cs"
    Inherits="LIMS_WebForms_wfrmReceptionLab" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD>
		<title>LIMS: INVESTIGATION BOOKING:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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

    function unselectdropdown() {
        var ddl = document.getElementById("ddlRefferdBy");
        //alert(ddl);
        ddl.options[0].selected = true;
    }
</script>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
        <div>
            <table width="100%" class="label">
                <TR>
					<TD colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                    
                                        
                   <TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>INVESTIGATION BOOKING</STRONG></font>
                    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
                    </td>
                    
                </tr>
                
                <tr>
                    <td colspan="8">
                        <asp:Label ID="lblErrMsg" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </td>
                   
                    
                </tr>


                <tr>
                <td colspan="8">
                    <fieldset id="fsetsearch" runat="server">
                    <legend>Search Patient</legend>
                    
                    <table id="tblSearch" width="99%" class="label">
                    <tr>
                    <td colspan="8" align="right">                        <asp:ImageButton
                                    ID="btnClose0" runat="server" AccessKey="x" ImageUrl="~/images/ClosePack.gif"
                                    OnClick="btnClose1_Click" TabIndex="26" 
                            ToolTip="Close Screen  (Alt+X)" />
                    </td>
                    </tr>
                        <tr>
                            <td>PR. No.:
                                </td>
                            <td>
                            <asp:Panel ID="pnlPrtxt" DefaultButton="imgPRSearch" runat="server">
                                    <asp:TextBox ID="txtPRSearch" Width="85%" CssClass="field" runat="server"></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="txtPRSearch_MaskedEditExtender" runat="server" 
                                        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                                        CultureThousandsPlaceholder="" Mask="99-99-999999" 
                                        ClearMaskOnLostFocus="false" CultureTimePlaceholder="" Enabled="True" 
                                        TargetControlID="txtPRSearch">
                                    </cc1:MaskedEditExtender>
                                                            <asp:ImageButton ID="imgPRSearch" runat="server" 
                                        ImageUrl="~/images/Find.png" Height="18px"
                            Width="8%" OnClick="btnPRSearch_Click" />
                            </asp:Panel>
                                </td>
                            <td>Name:</td>
                            <td>
                            <asp:Panel ID="pnlnamesearch" DefaultButton="imgbtnNameSearch" runat="server">
                                    <asp:TextBox ID="txtNameSearch" Width="85%" CssClass="field" ToolTip="No Spaces allowed" onkeyup="javascript:chkspace()" runat="server"></asp:TextBox>
                                     <asp:ImageButton ID="imgbtnNameSearch" runat="server" 
                                        ImageUrl="~/images/Find.png" Height="18px"
                            Width="8%" OnClick="btnNameSearch_Click" />
                            </asp:Panel>
                                </td>
                            <td>Mobile No.</td>
                            <td>
                            <asp:Panel ID="pnlmobsearch" DefaultButton="btnMobileSearch" runat="server">
                                    <asp:TextBox ID="txtmobilesearch" Width="85%" CssClass="field" runat="server"></asp:TextBox>
                                                            
                                                            <asp:ImageButton ID="btnMobileSearch" runat="server" 
                                        ImageUrl="~/images/Find.png" Height="18px"
                            Width="8%" OnClick="btnMobileSearch_Click" />
                            </asp:Panel>
                                </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <asp:GridView ID="gvPRNo" runat="server" CssClass="datagrid"
                                 OnRowCommand="gvPRNo_RowCommand" AutogenerateColumns="false" Width="99%">
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S#">
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="PR No." DataField="PRNo" />
                                    <asp:BoundField HeaderText="Name" DataField="PatientFullName" />
                                    <asp:BoundField HeaderText="Cell #" DataField="CellPhone" />
                                    <asp:BoundField HeaderText="DOB" DataField="DOB" />
                                    <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                    <asp:BoundField HeaderText="Marital Status" DataField="Mstatus" />
                                    <asp:ButtonField HeaderText="CreateVisit" CommandName="Visit" Text="Create Visit" />
                                </Columns>
                                </asp:GridView>
                            </td>
                            
                        </tr>

                       <tr>
                            <td width="10%"></td>
                            <td width="15%"></td>
                            <td width="10%"></td>
                            <td width="20%"></td>
                            <td width="10%"></td>
                            <td width="15%"></td>
                            <td width="10%"></td>
                            <td width="10%"></td>
                        </tr>
                    
                    </table>
</fieldset>
                 </td>
                </tr>
  
  <tr>
    <td colspan="8">


<fieldset id="fsetinvestbooking" visible="false" runat="server">
<legend>Investigation Booking</legend>

<table id="tblinvestbooking" width="99%" class="label">
<tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblTestGroupId" runat="server" Visible="False"></asp:Label></td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    
                    </td>
                    <td align="right">
                        <asp:ImageButton ID="lbtnSave" runat="server" AccessKey="s" ImageUrl="~/images/SavePack_2.gif"
                            OnClick="lbtnSave_Click" TabIndex="23" ToolTip="Press To Save (Alt+S)" /><asp:ImageButton
                                ID="lbtnClearAll" runat="server" AccessKey="c" ImageUrl="~/images/ClearPack.gif"
                                OnClick="lbtnClearAll_Click" TabIndex="24" ToolTip="Press To Clear (Alt+C)" /><asp:ImageButton
                                    ID="btnClose" runat="server" AccessKey="x" ImageUrl="~/images/ClosePack.gif"
                                    OnClick="btnClose_Click" TabIndex="26" ToolTip="Close Screen  (Alt+X)" /></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="8">
                        <asp:Panel ID="PnlPatientInfo" runat="server" BorderStyle="Double" BorderWidth="1px"
                            Width="100%" Height="30px" BorderColor="graytext">
                            <table width="100%">
                              
                                <tr>
                                    <td style="width: 7%">
                                        PR. No:</td>
                                    <td style="width: 13%">
                                        
                                        <asp:Label ID="lblPRNO" runat="server" Width="100%"></asp:Label></td>
                                    <td style="width: 5%">
                                        Patient:</td>
                                    <td style="width: 20%">
                                        <asp:Label ID="lblPatientName" runat="server" Width="100%"></asp:Label></td>
                                    <td style="width: 5%">
                                        Age:</td>
                                    <td style="width: 10%">
                                        <asp:Label ID="lblAge" runat="server" Width="100%"></asp:Label></td>
                                    <td style="width: 10%">
                                        Gender:</td>
                                    <td style="width: 10%">
                                        <asp:Label ID="lblGender" runat="server" Width="100%"></asp:Label></td>
                                    <td style="width: 10%">
                                        Marital Status:</td>
                                    <td style="width: 10%">
                                        <asp:Label ID="lblMSStatus" runat="server" Width="100%"></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Test Priority:</td>
                    <td>
                        <asp:RadioButton ID="rdoNormal" runat="server" GroupName="TestPriority" 
                            Checked="True" Text="Normal" oncheckedchanged="rdoNormal_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rdoUrgent" runat="server" Text="Urgent" 
                            GroupName="TestPriority" oncheckedchanged="rdoUrgent_CheckedChanged" AutoPostBack="true" /></td>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblVisitno" runat="server" Visible="False"></asp:Label></td>
                    <td>
                        Total Charges:</td>
                    <td colspan="2">
                        <asp:Label ID="lblTotalCharges" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Search Test:</td>
                    <td>
                    <asp:Panel ID="pnlAlltestsearch" runat="server" DefaultButton="btnTestFind">
                    <asp:RadioButton ID="rdosearchtypename" runat="server" Text="Name" Checked="true" GroupName="searchtype" />
                    <asp:RadioButton ID="rdosearchtypeacronym" runat="server" Text="Speed Key" GroupName="searchtype" />
                        <asp:TextBox ID="txtTestSearch" runat="server" Width="82%" CssClass="flattextbox"></asp:TextBox>
                        <asp:ImageButton ID="btnTestFind" runat="server" ImageUrl="~/images/Find.png" Height="18px"
                            Width="8%" OnClick="btnTestFind_Click" />
                            </asp:Panel></td>
                    <td>
                        Origin:</td>
                    <td>
                        <asp:DropDownList ID="ddlOrigenBy" runat="server" Width="50%">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtSpeedKey" runat="server" Width="82%" CssClass="flattextbox" Visible="false"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Find.png" Height="18px"
                            OnClick="ImageButton1_Click" Visible="false" /></td>
                    <td>
                        </td>
                    <td>
                        <asp:Label ID="lblPRID" runat="server" Visible="False"></asp:Label></td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        Reffered By:</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlRefferdBy" runat="server" Width="50%">
                        </asp:DropDownList>
                        <asp:TextBox ID="txtRefferedby" runat="server" Width="40%" CssClass="field" onkeyup="javascript:unselectdropdown();"></asp:TextBox>
                        <cc1:TextBoxWatermarkExtender ID="txtwatermark" runat="server" TargetControlID="txtRefferedby" WatermarkText="If Other mention here."></cc1:TextBoxWatermarkExtender>
                         <cc1:ListSearchExtender ID="DDLPathologist_ListSearchExtender" runat="server" 
                                                                                Enabled="True" TargetControlID="ddlRefferdBy">
                                                                            </cc1:ListSearchExtender>

                        </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        </td>
                    <td>
                        <asp:DropDownList ID="ddlRptCollect" runat="server" Visible="false" Width="85%">
                            <asp:ListItem>Self</asp:ListItem>
                            <asp:ListItem>By Email</asp:ListItem>
                            <asp:ListItem>Mobile Message</asp:ListItem>
                            <asp:ListItem>By Post</asp:ListItem>
                            <asp:ListItem>Someone Else </asp:ListItem>
                        </asp:DropDownList></td>
                    <td>
                        &nbsp;</td>
                 
                </tr>
                <tr>
                    <td colspan="8">
                        <table width="100%">
                            <tr>
                                <td style="width: 30%">
                                    <div>
                                       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>--%>
                                        <asp:Panel ID="pnlDept" runat="server" Height="400px" Width="100%" BorderWidth="1px" BorderColor="graytext" >
                                         
                                            <asp:Panel ID="pnlSubDept" runat="server" Height="160px" Width="100%" BorderStyle="Double"
                                                BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                                                
                                                       <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false" UpdateMode="Conditional" >
                                                        <ContentTemplate>--%>
                                                        <table width="100%">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            SubDepartment
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gvSubDept" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                                EnableTheming="True" Width="100%" DataKeyNames="sectionid">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex+1+":" %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%--<asp:BoundField DataField="name">
                                                        <ItemStyle Width="90%" />
                                                    </asp:BoundField>--%>
                                                                    <asp:TemplateField HeaderText="Sub-Department" >
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="95%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtnSubDepart" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Name") %>'
                                                                                OnClick="lbtnSubDepart_Click"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridheader" />
                                                                <RowStyle CssClass="gridItem" />
                                                                <AlternatingRowStyle CssClass="gridAlternate" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 10%">
                                                        </td>
                                                        <td style="width: 90%">
                                                        </td>
                                                    </tr>
                                                </table>
                                                       <%-- </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                
                                            </asp:Panel>
                                            
                                               <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>--%>
                                                <asp:Panel ID="blnkSeparator" runat="server" Width="100%" Height="1px">
                                                
                                                </asp:Panel>
                                                <asp:Panel ID="pnlGroup" runat="server" Width="100%" BorderStyle="Double"
                                                BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                                                <table width="100%">
                                                    <tr>
                                                        <td style="height: 16px">
                                                        </td>
                                                        <td style="height: 16px">
                                                            Test Group</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gvGroup" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                                EnableTheming="True" Width="100%" DataKeyNames="testgroupid"  >
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="S#">
                                                                        <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex+1+":" %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Test Group" >
                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                        <ItemStyle HorizontalAlign="Left" Width="95%" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lbtngroup" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"groupname") %>'
                                                                                OnClick="lbtnTestGroup_Click"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="gridheader" />
                                                                <RowStyle CssClass="gridItem" />
                                                                <AlternatingRowStyle CssClass="gridAlternate" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 10%">
                                                        </td>
                                                        <td style="width: 90%">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            <%--</ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                                
                                        </asp:Panel>
                                        <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                        
                                    </div>
                                </td>
                                <td style="width: 35%">
                                    <div>
                                        <asp:Panel ID="pnlTestList" runat="server" Height="400px" Width="100%" BorderStyle="Double"
                                            BorderWidth="1px" BorderColor="graytext" ScrollBars="None">
                                            <%--<asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>--%>
                                            <table width="100%">
                                                <tr>
                                                <td style="width:40%">
                                                <asp:Label ID="lblColorCode" ForeColor="Red" Text="No Default Method set" Visible="false" runat="server"></asp:Label>
                                                </td>
                                                <td style="width:15%; text-align: right;">
                                                 Filter:
                                                </td>
                                                <td style="width:30%">
                                                <asp:TextBox ID="txtTestList" runat="server" Width="85%" onkeyup="Javascript:filter(this,'gvTestList',0)" CssClass="flattextbox"></asp:TextBox>
                                                        <asp:ImageButton ID="slctbtnTestList" runat="server" ImageUrl="~/images/Find.png"
                                                            Height="18px" OnClick="slctbtnTestList_Click" Visible="false" />
                                                </td>
                                                </tr>
                                                <tr>
                                                <td colspan="3">
                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="8pt" 
                                                        ForeColor="Red"></asp:Label>
                                                    </td>
                                                
                                                </tr>
                                                <tr>
                                                <td>
                                                    <asp:LinkButton ID="slctbtnAddAll" runat="server" 
                                                        OnClick="slctbtnAddAll_Click" Visible="False">Add All</asp:LinkButton>
                                                    </td>
                                                <td>
                                                    <asp:LinkButton ID="lnkAddBatch" runat="server" OnClick="lnkAddBatch_Click" 
                                                        Visible="False">Add Batch</asp:LinkButton>
                                                    </td>
                                                <td>
                                                    <asp:LinkButton ID="slctbtnAddSelected" runat="server" 
                                                        OnClick="slctbtnAddSelected_Click" Visible="False">Add Selected</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td colspan="3">
                                                 <asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%" BorderStyle="Double"
                                            BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                                                <table id="tblgridalltests" class="label">
                                                <tr>
                                                
                                                
                                                    <td colspan="3">
                                                        <asp:GridView ID="gvTestList" runat="server" 
                                                            OnRowDataBound="gvTestList_RowDataBound" AutoGenerateColumns="False" CssClass="datagrid"
                                                            Width="100%" DataKeyNames="testid,testgroupid,sectionid,D_METHODID,DELIVERYDATEONSPECIMEN,RoundDelivery,TestBatchNo,batchtime,Procedureid,External_orgid,traveltime,TestCost,cutoffday,ReportingTime"
                                                             OnRowCommand="gvTestList_RowCommand" >
                                                            <Columns>
                                                            <asp:ButtonField DataTextField="testname" HeaderText="Test" CommandName="Select">
                                                            </asp:ButtonField>
                                                            
                                                                <asp:BoundField DataField="amount" HeaderText="Price">
                                                                    <ItemStyle HorizontalAlign="Right" Width="10%" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkCharges" runat="server" OnCheckedChanged="chkCharges_CheckedChanged"  />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                <ItemTemplate>
                                                                
                                                                <asp:LinkButton ID="lnkbatch" runat="server" Text="Add batch" CommandName="Selection" CommandArgument="<%#(Container.DataItemIndex) %>"  OnCommand="lnkbatch_Command" Visible="false"></asp:LinkButton>
                                                                    <cc1:ModalPopupExtender ID="lnkbatch_ModalPopupExtender" runat="server" 
                                                                        DynamicServicePath="" Enabled="true" PopupControlID="pnlpopup" OkControlID="ibtnsavepop_Click" TargetControlID="lnkbatch">
                                                                    </cc1:ModalPopupExtender>
                                                                 
                                                                    
                                                                </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                            </Columns>
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                        </asp:GridView>
                                                    </td>
                                                    </tr>
                                                    <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    </tr>
                                                </table>
                                                </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                <td style="height: 16px">
                                                    &nbsp;</td>
                                                <td style="height: 16px">
                                                    &nbsp;</td>
                                                <td style="height: 16px">
                                                    <asp:Label ID="lblSectionid" runat="server" Visible="False"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                           <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                            
                                        </asp:Panel>
                                    </div>
                                </td>
                                <td style="width: 35%">
                                    <div>
                                        <asp:Panel ID="pnlPatientTests" runat="server" Height="400px" Width="100%" BorderStyle="Double"
                                            BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                                            <%--<asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>--%>
                                            <table width="100%">
                                                <tr>
                                                    <td style="width: 20%">
                                                    </td>
                                                    <td style="width: 40%">
                                                        Patient Test</td>
                                                    <td style="width: 40%">
                                                        <asp:LinkButton ID="lnkbtnSlctRemoveAll" runat="server" OnClick="lnkbtnSlectTestRemoveAll_Click" Visible="False">Remove All</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                    
                                                        <asp:GridView ID="gvSelectedTests" runat="server" AutoGenerateColumns="False" CssClass="datagrid"
                                                            Width="100%" OnRowDeleting="gvSelectedTestList_RowDeleting_Click">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S#">
                                                                    <ItemStyle HorizontalAlign="Center" Width="8%" />
                                                                    <ItemTemplate><%# Container.DataItemIndex+1+":" %></ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="testname" HeaderText="Test">
                                                                    <ItemStyle Width="40%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="enteredon" HeaderText="Entered On">
                                                                    <ItemStyle Width="200%" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="deliverydate" SortExpression="deliverydate" 
                                                                    HeaderText="Delivery Date">
                                                                    <ItemStyle Width="20%" />
                                                                </asp:BoundField>
                                                                <asp:CommandField DeleteImageUrl="~/images/remove.png" ButtonType="Image"  ShowDeleteButton="True" >
                                                                    <ItemStyle Width="7%" />
                                                                </asp:CommandField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="gridheader" />
                                                            <RowStyle CssClass="gridItem" />
                                                            <AlternatingRowStyle CssClass="gridAlternate" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </table>
                                           <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                            
                                        </asp:Panel>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="2">
                    
                       <%-- <asp:Panel ID="pnlpopup" Visible="false"  runat="server" Width="300px" Height="80px">
                    <div id="divpopup" runat="server">
                    <table id="tblpopup" style="background-color:Lime" width="99%" class="label">
                    <tr>
                    <td colspan="4" align="right">
                    <asp:ImageButton ID="imgsavepopup" ImageUrl="~/images/SavePack_2.gif" runat="server" OnClick="ibtnsavepop_Click" />
                    </td>
                   
                    </tr>
                     <tr>
                    <td colspan="2">
                    <asp:RadioButton ID="rdosingle" Text="Single Test" Checked="true" runat="server" GroupName="rdobatches" />
                    <asp:RadioButton ID="rdobatch" Text="Add Batch" Checked="false" runat="server" GroupName="rdobatches" />
                    </td>
                    <td colspan="2"></td>
              
                    </tr>
                     <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                     
                    </table>
                    </div>
                    
                    </asp:Panel>--%>
                    </td>
                    
                    <td>
                       </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 5%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 20%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 20%">
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 20%">
                    </td>
                    <td style="width: 5%">
                    </td>
                </tr>
            </table>
            </fieldset>
            
            </td>
  </tr>
</table>
        </div>
    </form>
</body>
</html>
