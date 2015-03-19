<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestMicro" CodeFile="wfrmTestMicro.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Result Entry (Micro Format):    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="javascript">
		    function repeatreason(ddlid) {
		        //   alert(ddlid);
		        var ddl = document.getElementById(ddlid);
		        var commenttb = document.getElementById('txtCommentET');
		        commenttb.value = 'Test Repeat\r\nReason:' + ddl.options[ddl.selectedIndex].text.toString();
		        //alert(commenttb);
		        //alert(ddl.options[ddl.selectedIndex].text.toString());
		    }
		    function SetOpinion(opinion) {
		        document.all("<% =SelectedOpinion %>").value = opinion.replace(/<br>/g, '\r\n');
		    }

		    function SetComment(comment) {
		        document.all("<% =SelectedComment %>").value = comment.replace(/<br>/g, '\r\n');
		    }
function chkValue(term,_id,cellNr) {
    var parent = document.getElementById("<%=dgAttribute.ClientID %>");
    var tr = parent.getElementsByTagName("TR")[1];
    var tc = tr.getElementsByTagName("TD")[2];
   // var tr = parent.getElementsByTagName("TR")[0];
   // var tc = tr.getElementByTagName("TD")[1];
    var suche = term.value.toLowerCase();
    var table = document.getElementById(_id);
    
    if (parseInt(suche) < -14 || parseInt(suche) > 28) {
        alert("Please Re-Enter Value. It may be a typo mistake");
    }
}
function chkForward(term) {
    var e = document.getElementById("ddlForwardto");
    //alert(e.options[e.selectedIndex].text);
    if (e.options[e.selectedIndex].text == 'Result Entry' || e.options[e.selectedIndex].text == 'Specimen') {
        //alert(e.options[e.selectedIndex].text);
        var x = confirm("Are You sure you want to send this result back to " + e.options[e.selectedIndex].text + "?");
        if (x == true) {
            // alert(x);
            e.options[e.selectedIndex].selected = true;
        }
        else {
            //alert(x);
            e.options[2].selected = true;
        }
    }
}
		</script>
        <%-- For Auto Search--%>
         <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
<style type="text/css" media="screen">	
	   .suggest_link 
	   {
	   background-color: #FFFFFF;
	   padding: 2px 6px 2px 6px;
	   }	
	   .suggest_link_over
	   {
	   background-color:#e0f0ff;
	   color:Black;
	   padding: 2px 6px 2px 6px;
	   cursor:pointer;	
	   }	
	   #search_suggest 
	   {
	   position: absolute;
	   background-color: #FFFFFF;
	   text-align: left;
	   border: 1px solid #000000;			
	   }
	.style1
    {
        height: 22px;
    }
    .style2
    {
        height: 22px;
        width: 20%;
    }
    .style3
    {
        height: 7px;
        width: 20%;
    }
    .style4
    {
        width: 20%;
    }
	</style>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtItemName.ClientID%>").keyup(function (event) {
                var str = $("#<%=txtItemName.ClientID%>").val();
                // alert(str);
                searchSuggest(event, str);
            });

        });
        var maxDivId, currentDivId, strOriginal;
        //Our XmlHttpRequest object to get the auto suggestvar 
        searchReq = getXmlHttpRequestObject();
        function getXmlHttpRequestObject() {

            if (window.XMLHttpRequest) {

                return new XMLHttpRequest();
            }
            else if (window.ActiveXObject) {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
            else {
                alert(" !\nIt's about time to upgrade Your Browser, don't you think?");
            }
        }

        //Called from keyup on the search textbox.//Starts the AJAX request.
        function searchSuggest(e, str) {

            var key = window.event ? e.keyCode : e.which;


            if (key == 40 || key == 38) {

                scrolldiv(key);

            }
            else {

                if (searchReq.readyState == 4 || searchReq.readyState == 0) {
                    strOriginal = str

                    searchReq.open("GET", 'GoogleSearch.aspx?search=' + str, true);

                    searchReq.onreadystatechange = handleSearchSuggest;
                    searchReq.send(null);
                }

            }

        }
        //Called when the AJAX response is returned.
        function handleSearchSuggest() {

            if (searchReq.readyState == 4) {

                var ss = document.getElementById('search_suggest');
                ss.innerHTML = '';
                var str = searchReq.responseText.split("~");

                if (str.length > 1) {

                    for (i = 0; i < str.length - 1; i++) {
                        //Build our element string.  This is cleaner using the DOM, but			
                        //IE doesn't support dynamically added attributes.

                        maxDivId = i;
                        currentDivId = -1;
                        var suggest = '<div ';
                        suggest += 'id=div' + i;
                        suggest += '  '
                        suggest += 'onmouseover="javascript:suggestOver(this);" ';
                        suggest += 'onmouseout="javascript:suggestOut(this);" ';
                        suggest += 'onclick="javascript:setSearch(this.innerHTML);" ';
                        suggest += 'class="suggest_link">' + str[i] + '</div>';
                        ss.innerHTML += suggest;
                        ss.style.visibility = 'visible';
                    }
                }
                else {

                    ss.style.visibility = 'hidden';
                }
            }

        }

        //Mouse over function
        function suggestOver(div_value) {
            div_value.className = 'suggest_link_over';
            document.getElementById("<%=txtItemName.ClientID%>").value = div_value.innerHTML.replace("amp;", "");
        }

        function scrollOver(div_value) {

            div_value.className = 'suggest_link_over';

            document.getElementById("<%=txtItemName.ClientID%>").value = div_value.innerHTML.replace("amp;", "");

        }

        //Mouse out function
        function suggestOut(div_value) {
            div_value.className = 'suggest_link';
        }

        //Click function
        function setSearch(value) {
            var ss = document.getElementById('search_suggest');

            document.getElementById("<%=txtItemName.ClientID %>").value = value;
            ss.innerHTML = '';
            ss.style.visibility = 'hidden';
        }

        function scrolldiv(key) {
            var tempID;
            if (key == 40) {

                if (currentDivId == -1) {
                    tempID = 'div' + 0;
                    var a = document.getElementById(tempID);
                    scrollOver(a);
                    currentDivId = 0;

                }
                else {

                    if (currentDivId == maxDivId) {
                        tempID = 'div' + maxDivId;
                        var a = document.getElementById(tempID);
                        currentDivId = -1;
                        suggestOut(a)
                        document.getElementById("<%=txtItemName.ClientID %>").value = strOriginal;
                    }
                    else {
                        tempID = currentDivId + 1;
                        setScroll(currentDivId, tempID)
                    }

                }
            }
            else if (key == 38) {
                if (currentDivId == -1) {
                    tempID = maxDivId;
                    setScroll(maxDivId, maxDivId)

                }
                else {
                    if (currentDivId == 0) {
                        tempID = 'div' + currentDivId;
                        var a = document.getElementById(tempID);
                        currentDivId = -1;
                        suggestOut(a)
                        document.getElementById("<%=txtItemName.ClientID %>").value = strOriginal;

                    }
                    else {
                        tempID = currentDivId - 1;
                        setScroll(currentDivId, tempID)

                    }

                }

            }
        }
        function setScroll(Old, New) {
            var tempDivId;
            currentDivId = New;

            tempDivId = 'div' + Old;
            var a = document.getElementById(tempDivId);
            suggestOut(a)

            tempDivId = 'div' + currentDivId;
            var b = document.getElementById(tempDivId);
            scrollOver(b);

        }
        </script>
	</HEAD>
	<body leftMargin="20">
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0"
				runat="server">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><u><asp:label id="lblHeading" runat="server" Width="100%">Label</asp:label></u></font>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    </TD>
				</TR>
				<TR>
					<TD colSpan="6">&nbsp;</TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Rec-ID:</TD>
					<TD width="30%"><asp:label id="lblLabID" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Priority:</TD>
					<TD width="40%"><asp:label id="lblPriority" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD width="10%">Name:</TD>
					<TD width="30%"><asp:label id="lblName" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Type:</TD>
					<TD width="40%"><asp:label id="lblType" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="5%" style="HEIGHT: 16px"></TD>
					<TD width="10%" style="HEIGHT: 16px">Sex/Age:&nbsp;&nbsp;</TD>
					<TD width="30%" style="HEIGHT: 16px"><asp:label id="lblAgeSex" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%" style="HEIGHT: 16px">Ward:</TD>
					<TD width="40%" style="HEIGHT: 16px"><asp:label id="lblWard" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD width="5%" style="HEIGHT: 16px"></TD>
				</TR>
				<TR>
					<TD width="5%" style="HEIGHT: 16px"></TD>
					<TD width="10%" style="HEIGHT: 16px">PR No:&nbsp;&nbsp;</TD>
					<TD width="30%" style="HEIGHT: 16px"><asp:label id="lblPRNo" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%" style="HEIGHT: 16px">Referred By:</TD>
					<TD width="40%" style="HEIGHT: 16px"><asp:label id="lblReferredBy" runat="server" Visible="true" Font-Bold="True"  width="50%">Label</asp:label>
                    <asp:TextBox ID="txtRefDoctor" runat="server" CssClass="field" Visible="false" Width="50%"></asp:TextBox>
                    </TD>
					<TD width="5%" style="HEIGHT: 16px"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:label id="lblMSerialNo" runat="server" Width="100%" Font-Bold="True" Visible="False">Label</asp:label></TD>
					<TD>
						<asp:label id="lblDSerialNo" runat="server" Width="100%" Font-Bold="True" Visible="False">Label</asp:label></TD>
					<TD align="right" colSpan="3">
						<asp:imagebutton id="ibtnNextPatient" runat="server" ImageUrl="Images/btn_Next.gif"></asp:imagebutton>
                        <asp:ImageButton ID="ibtnResultByPRNo" runat="server" ImageUrl="Images/btn_ResultByPRNo.gif"
                            OnClick="ibtnResultByPRNo_Click" />
						<asp:imagebutton id="ibtnViewOtherResult" runat="server" ImageUrl="Images/btn_ViewResult.gif"></asp:imagebutton><asp:imagebutton id="ibtnPatientStatus" runat="server" ImageUrl="Images/btn_Detail.gif"></asp:imagebutton>
                        <asp:imagebutton id="ImageButton2" runat="server" 
                            ImageUrl="Images/btn_Close.gif" onclick="ImageButton2_Click"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">Test:</TD>
					<TD width="30%">
						<asp:label id="lblTest" runat="server" Width="100%" Font-Bold="True">Test Name</asp:label></TD>
					<TD width="10%">
						<asp:label id="lblTestID" runat="server" Width="100%" Font-Bold="True" Visible="False">Label</asp:label></TD>
					<TD width="40%"></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%"></TD>
					<TD width="30%"></TD>
					<TD width="10%"></TD>
					<TD width="40%"></TD>
					<TD width="5%"></TD>
				</TR>
			</TABLE>
			<DIV id="divOrders"  style=" font-size:x-small" runat="server">
             Method:
                                        <asp:DropDownList ID="dgDDLMethod" Width="20%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMethod_SelectedIndexChanged"></asp:DropDownList>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblDeliveryDatetxt" runat="server" 
                    Text="Delivery Date:" Font-Size="X-Small"></asp:Label>
                    <asp:Label ID="lblDeliveryDate" runat="server" 
                    Text="Delivery Date" Font-Size="X-Small" Font-Bold="True" 
                    ForeColor="#996633"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ibtnSOP" runat="server" ImageUrl="images\Btn_SOP.png" 
                    OnCommand="ibtn_SOPClick"  ToolTip="SOPs" />
                     <asp:ImageButton ID="imghistory" runat="server" 
                                            ImageUrl="~/images/history2.png" ToolTip="History" OnClick="imghistory_Click" />
                                        <br />
				<asp:datagrid id="dgAttribute" runat="server" Width="100%" AutoGenerateColumns="False" OnItemDataBound="dgAttribute_ItemDataBound"
					BorderStyle="None">
					<SelectedItemStyle Font-Size="X-Small" CssClass="gridItem"></SelectedItemStyle>
					<AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
					<ItemStyle Font-Size="X-Small" CssClass="gridAlternate"></ItemStyle>
					<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="AttributeID" SortExpression="AttributeID" ReadOnly="True"
							HeaderText="AttributeID"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="PRN">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemTemplate>
								&nbsp;
								<asp:CheckBox id=chkRPrint Runat="server" Text=" " Checked='<%#(DataBinder.Eval(Container.DataItem, "RPrint").ToString() == "Y")%>' Enabled="True">
								</asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True" HeaderText="Attribute">
							<HeaderStyle Width="15%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:TemplateColumn HeaderText="Result">
							<HeaderStyle Width="65%"></HeaderStyle>
							<ItemTemplate>
								<P>
                               <%-- <input type="text" id="txt" onchange="chkValue(this,dgAttribute,0)"  class="flattextbox" />--%>
									<asp:TextBox id="dgAttributeResult" runat="server" Width="100%" 
                                        Text='<%# DataBinder.Eval(Container.DataItem, "Result")  %>' MaxLength="100" 
                                        Rows='<%# int.Parse(DataBinder.Eval(Container.DataItem, "SMLine").ToString()) %>' 
                                        Height="100%" 
                                        
                                        
                                        Textmode='<%# GetTextmode((string)DataBinder.Eval(Container.DataItem, "SMLine"))%>' CssClass="flattextbox" 
                                       ></asp:TextBox>
									<asp:ListBox id="lbSelection" runat="server" Width="100%" AutoPostBack="True" Visible="False"
										OnSelectedIndexChanged="lbSelection_SelectedIndexChanged"></asp:ListBox></P>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn>
							<HeaderStyle Width="10%"></HeaderStyle>
							<ItemTemplate>
								<asp:ImageButton id="ibtnSelection" runat="server" ImageUrl="images\btn_Piclist.gif" OnClick="ibtnSelection_Click" Visible='<%#(DataBinder.Eval(Container.DataItem, "InputType").ToString() == "1")%>'>
								</asp:ImageButton>
                                
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn Visible="False" DataField="RUnit" SortExpression="RUnit" HeaderText="Unit">
							<HeaderStyle Width="10%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="MinRange" SortExpression="MinRange" HeaderText="Min">
							<HeaderStyle Width="10%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="MaxRange" SortExpression="MaxRange" ReadOnly="True" HeaderText="Max">
							<HeaderStyle Width="10%"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="Range" SortExpression="Range" HeaderText="Range">
							<HeaderStyle Width="15%"></HeaderStyle>
						</asp:BoundColumn>
					</Columns>
					<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<TABLE id="tbOpinion" width="100%" bgColor="#edf0f8">
					<TR>
						<TD width="10%" class="style1"></TD>
						<TD width="25%" class="style1"></TD>
						<TD width="321" class="style1"></TD>
						<TD width="20%" class="style1"></TD>
						<TD class="style2"></TD>
						<TD width="5%" class="style1"></TD>
					</TR>
					<TR>
						<TD width="10%" style="HEIGHT: 7px">
							<asp:checkbox id="chkSensitivity" runat="server" OnCheckedChanged="chkSensitivity_CheckedChanged"
								AutoPostBack="True" Text="Sensitivity"></asp:checkbox></TD>
						<TD width="25%" style="HEIGHT: 7px"></TD>
						<TD width="321" style="HEIGHT: 7px"></TD>
						<TD width="20%" style="HEIGHT: 7px"></TD>
						<TD class="style3"></TD>
						<TD width="5%" style="HEIGHT: 7px"></TD>
					</TR>
					<TR>
						<TD colspan="6"><TABLE id="TMSen" cellSpacing="1" cellPadding="1" width="100%" border="0" bgColor="#edf0f8">
								<TR>
									<TD width="5%"></TD>
									<TD width="30%">
										<asp:dropdownlist id="ddlOrganism" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlOrganism_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD width="30%">
										<asp:dropdownlist id="ddlOrganism2" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlOrganism2_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD width="30%">
										<asp:dropdownlist id="ddlOrganism3" runat="server" Width="100%" AutoPostBack="True" onselectedindexchanged="ddlOrganism3_SelectedIndexChanged"></asp:dropdownlist></TD>
									<TD width="5%"></TD>
								</TR>
								<TR>
									<TD width="5%"></TD>
									<TD vAlign="top">
										<asp:datagrid id="dgMicro" runat="server" Width="100%" BorderStyle="None" AutoGenerateColumns="False"
											CssClass="datagrid">
											<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True" HeaderText="OrganismID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True" HeaderText="DrugID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Drug" HeaderText="Drug">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="microresult" HeaderText="Result">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="35%"></HeaderStyle>
													<ItemTemplate>
														<asp:ImageButton id="ibtnR" onclick="ibtnR_Click" runat="server" ImageUrl="images/btn_R.GIF"></asp:ImageButton>
														<asp:ImageButton id="ibtnS" onclick="ibtnS_Click" runat="server" ImageUrl="images/btn_S.GIF"></asp:ImageButton>
														<asp:ImageButton id="ibtnI" onclick="ibtnI_Click" runat="server" ImageUrl="images/btn_I.GIF"></asp:ImageButton>
														<asp:ImageButton id="ibtnBlank" onclick="ibtnBlank_Click" runat="server" ImageUrl="images/btn_Blank.GIF"></asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
									<TD vAlign="top">
										<asp:datagrid id="dgMicro2" runat="server" AutoGenerateColumns="False" BorderStyle="None" Width="100%"
											CssClass="datagrid">
											<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True" HeaderText="OrganismID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True" HeaderText="DrugID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Drug" HeaderText="Drug">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="microresult" HeaderText="Result">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="35%"></HeaderStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton3" onclick="ibtnR_Click" runat="server" ImageUrl="images/btn_R.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton4" onclick="ibtnS_Click" runat="server" ImageUrl="images/btn_S.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton5" onclick="ibtnI_Click" runat="server" ImageUrl="images/btn_I.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton6" onclick="ibtnBlank_Click" runat="server" ImageUrl="images/btn_Blank.GIF"></asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
									<TD vAlign="top">
										<asp:datagrid id="dgMicro3" runat="server" AutoGenerateColumns="False" BorderStyle="None" Width="100%"
											CssClass="datagrid">
											<SelectedItemStyle Font-Size="X-Small" BackColor="WhiteSmoke"></SelectedItemStyle>
											<AlternatingItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#FFFCF2"></AlternatingItemStyle>
											<ItemStyle Font-Size="X-Small" CssClass="gridItem"></ItemStyle>
											<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" BackColor="#CCCCFF"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="OrganismID" ReadOnly="True" HeaderText="OrganismID"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="DrugID" ReadOnly="True" HeaderText="DrugID"></asp:BoundColumn>
												<asp:BoundColumn DataField="Drug" HeaderText="Drug">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="microresult" HeaderText="Result">
													<HeaderStyle Width="15%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="35%"></HeaderStyle>
													<ItemTemplate>
														<asp:ImageButton id="Imagebutton7" onclick="ibtnR_Click" runat="server" ImageUrl="images/btn_R.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton8" onclick="ibtnS_Click" runat="server" ImageUrl="images/btn_S.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton9" onclick="ibtnI_Click" runat="server" ImageUrl="images/btn_I.GIF"></asp:ImageButton>
														<asp:ImageButton id="Imagebutton10" onclick="ibtnBlank_Click" runat="server" ImageUrl="images/btn_Blank.GIF"></asp:ImageButton>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
										</asp:datagrid></TD>
									<TD width="5%"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label1" runat="server" Font-Size="X-Small">Forward to:</asp:label></TD>
						<TD>
							<asp:dropdownlist id="ddlForwardto" runat="server" Width="100%"  Enabled="True"></asp:dropdownlist></TD>
						<TD>
                         <asp:CheckBox ID="chkRepeat" Text="Repeat Test" Font-Size="X-Small" OnCheckedChanged="chkReport_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                        
                        
                        </TD>
						<TD>
                        <asp:UpdatePanel ID="updtereasons" runat="server">
                        <ContentTemplate>
                        
                        <asp:Label ID="lblReasons" runat="server" Text="Reasons:" Visible="false" Font-Size="X-Small"></asp:Label>
                                                                        <asp:DropDownList ID="ddlRepeatReasons" Width="40%" Visible="false" runat="server" onchange="javascript:repeatreason(this.id)"></asp:DropDownList>
                         </ContentTemplate>
                         <Triggers>
                        <%-- <asp:AsyncPostBackTrigger ControlID="chkRepeat" EventName="CheckedChanged" />--%>
                         </Triggers>
                        </asp:UpdatePanel>                                               
                        </TD>
						<TD class="style4"></TD>
						<TD></TD>
					</TR>
					<TR>
						<TD>
							<asp:label id="Label2" runat="server" Font-Size="X-Small">Opinion:</asp:label></TD>
						<TD colSpan="4">
							<asp:textbox id="txtOpinionET" runat="server" Width="100%" TextMode="MultiLine" Height="45px"
								MaxLength="255" Rows="3" CssClass="flattextbox"></asp:textbox></TD>
						<TD>
							<asp:imagebutton id="ibtnOpinion" onclick="ibtnOpinion_Click" runat="server" ImageUrl="images\btn_Piclist.gif"></asp:imagebutton></TD>
					</TR>
                   
					<TR>
						<TD>
							<asp:label id="Label4" runat="server" Font-Size="X-Small">Comment:</asp:label></TD>
						<TD colSpan="4">
                <%--        <asp:UpdatePanel ID="updtecomment" runat="server">
                        <ContentTemplate>--%>
                                               
							<asp:textbox id="txtCommentET" runat="server" Width="90%" Visible="true" TextMode="MultiLine" Height="45px"
								MaxLength="255" Rows="3" CssClass="flattextbox"></asp:textbox>
                                
                                <asp:LinkButton ID="lnksavecomment" runat="server" CommandName="save" Text="save" Font-Size="X-Small" Visible="true" OnCommand="lnkbtnsavecomment_Click"></asp:LinkButton>
                                </td>
                                <td>
							<asp:imagebutton id="ibtnComment" onclick="ibtnComment_Click" runat="server" 
                                        ImageUrl="images\btn_Piclist.gif" style="height: 19px"></asp:imagebutton></td>
                                </tr>
                                <tr>
                                <td></td>
                                <td colspan="4">
                        <asp:GridView ID="gvComments" Width="100%" CssClass="datagrid" DataKeyNames="TestResultCommentID" AutoGenerateColumns="false" OnRowDeleting="gvComments_RowDeleting" runat="server">
                                                                        <HeaderStyle CssClass="gridheader" />
                                                                        <RowStyle CssClass="gridItem" />
                                                                        <AlternatingRowStyle CssClass ="gridAlternate" />
                                                                        <Columns>
                                                                        <asp:BoundField HeaderText="Comments" DataField="Comments" />
                                                                        <asp:BoundField HeaderText="EnteredBy" DataField="Name" />
                                                                        <asp:CommandField DeleteImageUrl="~/images/remove.png" ButtonType="Image"  ShowDeleteButton="True" >
                                                                    <ItemStyle Width="7%" />
                                                                </asp:CommandField>
                                                                        </Columns>
                                                                        </asp:GridView>
                       
                                 <%--</ContentTemplate>
                                 <Triggers>
                                 <asp:AsyncPostBackTrigger ControlID="chkRepeat" EventName="CheckedChanged" />
                                 </Triggers>
                        </asp:UpdatePanel>--%>
                                </TD>
						<TD>
							&nbsp;</TD>
					</TR>
                  <%--   <tr>
                    <td colspan="7"><asp:LinkButton ID="lnkbtnEval" runat="server" Text="Add Evaluation" Font-Size="X-Small" OnClick="lnkbtnEval_Click" Visible="false"></asp:LinkButton></td>
                    </tr>--%>
                    <tr>
                    <td style="background-color:Window" colspan="7">
                    <asp:LinkButton ID="lnkAddDiagnosis" runat="server" Text="Add Diagnosis" 
                            Font-Size="X-Small" onclick="lnkAddDiagnosis_Click" Visible="false"></asp:LinkButton> 
                     <%--   <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="updteDiseasecode" DynamicLayout="true" runat="server">
                        
                        </asp:UpdateProgress>--%>
                    </td>
                    </tr>
                     <tr>
                   
                    <td colspan="7">
              
                    <table id="tblDiagnosis" visible="false" width="100%" runat="server" class="label">
                    <tr>
                    
                    <td width="15%">

                    <asp:label id="Label3" runat="server" Font-Size="X-Small">Disease Name:</asp:label>
                    </td>
                    <td width="25%"><asp:DropDownList ID="DDLdiseasename" runat="server" CssClass="field" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlDiseasename_SelectedIndexchanged"></asp:DropDownList></td>
                    <td>

                       
                    <asp:Label ID="Label6" Font-Size="X-Small" AssociatedControlID="DDLdiseasecode" runat="server">Code:</asp:Label>
               
                   
                                                                        <asp:DropDownList ID="DDLdiseasecode" runat="server" CssClass="field" AutoPostBack="true" OnSelectedIndexChanged="ddlDiseasecode_SelectedIndexchanged"></asp:DropDownList>
                                                                         
																		<asp:CheckBox ID="chkPrint" Text="Print" Font-Size="X-Small" runat="server" />
                                                                        <asp:Button ID="ibtnsearch" onclick="ibtnsearch_Click" runat="server" Text="Search" CssClass="buttonStyle" BackColor="HighLight"></asp:Button>
                                                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="buttonStyle" Text="Add" BackColor="Highlight" />
                 
                    </td>
                  </tr>
                  </table>
           
                    </td> 
                    </tr>
                    <tr>
                    <td></td>
                            <td colspan="7">
                                &nbsp;</td>


                    </tr>
                    <tr>
                                                                  
                                                                    <td colspan="5">
                                                                    
                                                              
                                                                   
                                                                        </td>
                                                                    </tr>
                    <tr>
                    <td colspan="7">
                    <asp:LinkButton ID="gvlnkpath1" runat="server" Visible="false"  OnClick="gvlnkPath1_Click" Font-Size="X-Small"></asp:LinkButton>
                                                              &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="gvlnkdelfile1" runat="server" Visible="false" 
                                                                        Text="[X]" ToolTip="Delete" 
                            Font-Size="X-Small" CommandName="file1" 
                                                                        
                            OnCommand="gvlnkdelfile_Command"></asp:LinkButton>
                                                              <br />
                                                              <asp:LinkButton ID="gvlnkPath2" runat="server" Visible="false"  OnClick="gvlnkPath2_Click" Font-Size="X-Small"></asp:LinkButton>
                                                              &nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="gvlnkdelfile2" runat="server" Visible="false" 
                                                                        Text="[X]" ToolTip="Delete" 
                            Font-Size="X-Small" CommandName="file2" 
                                                                        
                            OnCommand="gvlnkdelfile_Command"></asp:LinkButton>
                                                              <br />
                                                              <asp:LinkButton ID="gvlnkPath3" runat="server" Visible="false" OnClick="gvlnkPath3_Click" Font-Size="X-Small"></asp:LinkButton>
                                                                   
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="gvlnkdelfile3" runat="server" Visible="false" 
                                                                        Text="[X]" ToolTip="Delete" 
                            Font-Size="X-Small" CommandName="file2" 
                                                                        
                            OnCommand="gvlnkdelfile_Command"></asp:LinkButton>
                                                              <br />
&nbsp;<asp:FileUpload id="FileUploadControl1" runat="server" />
 <asp:Button runat="server" id="UploadButton1" text="Upload" Visible="false" onclick="UploadButton1_Click" /> 
<asp:Label runat="server" id="StatusLabel1" text="Upload status: " Visible="false" Font-Size="X-Small" />
                    </td>
                   
                    </tr>
                    <tr>
                    <td colspan="7">
                        <asp:FileUpload id="FileUploadControl2" Visible="true" runat="server" />
 <asp:Button runat="server" id="UploadButton2" text="Upload" Visible="false" onclick="UploadButton2_Click" />
<asp:Label runat="server" id="StatusLabel2" text="Upload status: " Visible="false" Font-Size="X-Small" /></td>
                    </tr>
                     <tr>
                    <td colspan="7">
                        <asp:FileUpload id="FileUploadControl3" Visible="false" runat="server" />
 <asp:Button runat="server" id="UploadButton3" text="Upload" Visible="false" onclick="UploadButton3_Click" />
<asp:Label runat="server" id="StatusLabel3" text="Upload status: " Visible="false" Font-Size="X-Small" />
                    </td>
                    </tr>
					<TR>
						<TD width="10%"></TD>
						<TD width="25%"></TD>
						<TD width="321"></TD>
						<TD width="20%"></TD>
						<TD align="right" class="style4">
							<asp:ImageButton id="ibtnHold" runat="server" ImageUrl="Images/btn_Hold.gif"></asp:ImageButton>
							<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" 
                                onclick="ibtnSave_Click"></asp:ImageButton></TD>
						<TD width="5%"></TD>
					</TR>
				</TABLE>
			</DIV>
            <fieldset>
            <legend>Diagnosis</legend>
            
            <table id="tblDiseases" class="label" width="99%" runat="server">
            <tr>
            <td>Disease Name:</td>
            <td colspan="2">
            
             <asp:TextBox ID="txtItemName" CssClass="field" autocomplete="off" runat="server" Width="99%"></asp:TextBox>
                <br />
                                                                 <div id="search_suggest"  style="width:350px"></div></td>
            <td>
                    <asp:Button ID="btnSearchDisease" runat="server" Text="Search" BackColor="Aqua" 
                        BorderColor="#3333CC" onclick="btnSearchDisease_Click" />
                    
                    
                    
                    <asp:DropShadowExtender ID="btnSearchDisease_DropShadowExtender" 
                    runat="server" Enabled="True" Rounded="True" TargetControlID="btnSearchDisease">
 </asp:DropShadowExtender>
                </td>
            
            <td></td>
            <td></td>
            <td></td>
            </tr>
            <tr>
            <td></td>
            <td colspan="3">
               <div id="divsearcharea" runat="server" visible="false">
                <fieldset>
                <legend>Search Results</legend>
                <asp:GridView ID="gvDiagnosissearch" Width="99%" runat="server" AutoGenerateColumns="false"
                 OnRowCommand="gvDiagnosissearch_RowCommand" DataKeyNames="DISEASEID" CssClass="datagrid">
                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                <RowStyle CssClass="gridItem" />
                <AlternatingRowStyle CssClass="gridAlternate" />
                <Columns>
                <asp:TemplateField HeaderText ="S#">
                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                <ItemTemplate>
                <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DISEASECODE" HeaderText="ICD Code" />
                <asp:BoundField DataField="DISEASENAME" HeaderText="Disease Name" />
                <asp:TemplateField HeaderText="Print">
                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                <ItemStyle HorizontalAlign="Center" Width="5%" />
                <ItemTemplate>
                <asp:CheckBox ID="gvdiagnosischkPrint" runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="true" SelectText="Add" />
                </Columns>

                </asp:GridView>
                    <asp:DropShadowExtender ID="gvDiagnosissearch_DropShadowExtender" 
                        runat="server" Enabled="True" Rounded="True" 
                        TargetControlID="gvDiagnosissearch">
                        
 </asp:DropShadowExtender>
 </fieldset>
 </div>
                 </td>
          
            <td></td>
            <td></td>
            <td></td>

            </tr>
            <tr>
            <td></td>
            <td colspan="3">
                            <asp:GridView ID="gvDiseases" AutoGenerateColumns="false" Width="99%"  runat="server" OnRowDeleting=" gvDiseases_RowDeleting_Click" DataKeyNames="DIAGNOSISID" CssClass="datagrid">
                            <Columns>
                            <asp:TemplateField HeaderText="S#">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                                    
                            <ItemTemplate>
                            <%# Container.DataItemIndex+1 %>
                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ICD Code" DataField="ICD_Code" >
                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            </asp:BoundField >
                            <asp:BoundField HeaderText="Disease Name" DataField="Disease_Name">
                            <HeaderStyle HorizontalAlign="Left" Width="65%" />
                            </asp:BoundField >
                            <asp:TemplateField HeaderText="Print">
                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                            <ItemTemplate>
                            <asp:CheckBox ID="gvchkprint" runat="server" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem,"Print").ToString()=="Y") %>' />

                            </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteImageUrl="~/images/remove.png" ButtonType="Image"  ShowDeleteButton="True" >
                                                                    <ItemStyle Width="7%" />
                                                                </asp:CommandField>
                           <%-- <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:ImageButton ID="ibtnDelete" ImageUrl="~/images/remove.png" CommandName="Delete" CommandArgument='<%#Container.DataItemIndex%>' runat="server" />
                            
                            </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>
                            <HeaderStyle CssClass="gridheader" />
                            <RowStyle CssClass="gridItem" />
                            <AlternatingRowStyle CssClass="gridAlternate" />
                            </asp:GridView>
                            </td>
            
            <td></td>
            <td></td>
            <td></td>
            </tr>
            <tr>
            <td width="20%"></td>
            <td width="20%"></td>
            <td width="20%"></td>
            <td width="10%"></td>
            <td width="10%"></td>
            <td width="10%"></td>
            <td width="10%"></td>
            
            </tr>
            </table>
</fieldset>            
		
        </form>
	</body>
</HTML>
