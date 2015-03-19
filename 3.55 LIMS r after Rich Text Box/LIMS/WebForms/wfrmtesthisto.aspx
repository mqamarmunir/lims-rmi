<%@ Reference Page="~/lims/reports/generalreports.aspx" %>
<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestHisto" CodeFile="wfrmTestHisto.aspx.cs" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Result Entry (General Format):    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
		<script language="javascript">
		    function chkmethod(btnid) {
		        //alert(btnid);
		        var ddlmethod = document.getElementById(btnid.substring(0, 13) + 'dgDDLMethod');
		        //alert(ddlmethod);
		        if (ddlmethod.options[ddlmethod.selectedIndex].value == '-1') {
		            alert('Please select valid Method');
		            return false;
		        }
		        else {
		            return true;
		        }

		    }
		    function repeatreason(ddlid) {
		        //   alert(ddlid);
		        var ddl = document.getElementById(ddlid);
		        var commenttb = document.getElementById(ddlid.substring(0, 13) + 'dgtxtCommentET');
		        commenttb.value = 'Test Repeat\r\nReason:' + ddl.options[ddl.selectedIndex].text.toString();
		        //alert(commenttb);
		        //alert(ddl.options[ddl.selectedIndex].text.toString());
		    }		
			function Toggle( commId, imageId )
			{	
				var div = document.getElementById(commId);
				var GetImg = document.getElementById(imageId);
				if (document.all[commId].style.display == 'none')
				{	
					document.all[commId].style.display = 'block';
					document.all[imageId].src = 'Images/expand.gif';
				}
				else
				{	
					document.all[commId].style.display = 'none';
					document.all[imageId].src = 'Images/collapse.gif';
				}
			}
			function SetOpinion(opinion)
			{
				document.all("<% =SelectedOpinion %>").value = opinion.replace(/<br>/g,'\r\n');
			}
			
			function SetComment(comment)
			{
			    document.all("<% =SelectedComment %>").value = comment.replace(/<br>/g, '\r\n');
}
function chkValue(term, cellNr) {
    //    //var parent = document.getElementById;
    // var tc = tr.getElementsByTagName("TD")[2];
    // var tr = parent.getElementsByTagName("TR")[0];
    // var tc = tr.getElementByTagName("TD")[1];
    var suche = term.value.toLowerCase();
    // var table = document.getElementById(_id);

    if (parseInt(suche) < -14 || parseInt(suche) > 28) {
        alert("Please Re-Enter Value. It may be a typo mistake");
    }

}
function chkForward(term, _id) {
    var e = document.getElementById(_id);
    //alert(e);
    if (e.options[e.selectedIndex].text == 'Result Entry' || e.options[e.selectedIndex].text == 'Specimen') {
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


      <%--For Auto Search --%>
         <script src="js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <style type="text/css" media="screen">
        .suggest_link
        {
            background-color: #FFFFFF;
            padding: 2px 6px 2px 6px;
        }
        .suggest_link_over
        {
            background-color: #e0f0ff;
            color: Black;
            padding: 2px 6px 2px 6px;
            cursor: pointer;
        }
        #search_suggest
        {
            position: absolute;
            background-color: #FFFFFF;
            text-align: left;
            border: 1px solid #000000;
        }
    </style>
    <script language="javascript" type="text/javascript">

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
        function searchSuggest(e, strid) {
            //  alert('I am Called');
            //alert(strid);
            var str = document.getElementById(strid).value;
            //alert(str);
            var key = window.event ? e.keyCode : e.which;


            if (key == 40 || key == 38) {

                scrolldiv(key);

            }
            else {

                if (searchReq.readyState == 4 || searchReq.readyState == 0) {
                    strOriginal = str
                    //alert(str);
                    searchReq.open("GET", 'GoogleSearch.aspx?search=' + str, true);
                    //handleSearchSuggest();
                    searchReq.onreadystatechange = function () {
                        handleSearchSuggest(strid);
                    };
                    searchReq.send(null);
                }

            }

        }
        //Called when the AJAX response is returned.
        function handleSearchSuggest(strid) {

            if (searchReq.readyState == 4) {
                //alert(str.substring(0,12));
                var ss = document.getElementById(strid.substring(0, 13) + 'search_suggest');
                //alert(ss);
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
                        suggest += 'onmouseover="javascript:suggestOver(this,this.parentNode.id)"';

                        suggest += 'onmouseout="javascript:suggestOut(this);" ';
                        suggest += 'onclick="javascript:setSearch(this.innerHTML,this.parentNode.id);" ';
                        suggest += 'class="suggest_link">' + str[i] + '</div>';
                        ss.innerHTML += suggest;
                        ss.style.visibility = 'visible';
                    }
                }
                else {
                    //       ss.style.display = 'none';
                    ss.style.visibility = 'hidden';
                }
            }

        }

        //Mouse over function
        function suggestOver(div_value, strid) {
            div_value.className = 'suggest_link_over';
            //alert(strid.SUB);
            document.getElementById(strid.substring(0, 13) + 'txtItemName').value = div_value.innerHTML.replace("amp;", "");

        }

        function scrollOver(div_value, strid) {

            div_value.className = 'suggest_link_over';
            document.getElementById(strid.substring(0, 13) + 'txtItemName').value = div_value.innerHTML.replace("amp;", "");

        }

        //Mouse out function
        function suggestOut(div_value) {
            div_value.className = 'suggest_link';
        }

        //Click function
        function setSearch(value, strid) {
            var ss = document.getElementById(strid);

            ss.innerHTML = '';
            document.getElementById(strid.substring(0, 13) + 'txtItemName').value = value;
            //ss.style.display = 'none';
            ss.style.visibility = 'hidden';
        }

        function scrolldiv(key) {
            var tempID;
            if (key == 40) {

                if (currentDivId == -1) {
                    tempID = 'div' + 0;
                    var a = document.getElementById(tempID);
                    scrollOver(a, a.parentNode.id);
                    currentDivId = 0;

                }
                else {

                    if (currentDivId == maxDivId) {
                        tempID = 'div' + maxDivId;
                        var a = document.getElementById(tempID);
                        currentDivId = -1;
                        suggestOut(a)

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
            //alert(a.parentNode.id);
            suggestOut(a)

            tempDivId = 'div' + currentDivId;
            var b = document.getElementById(tempDivId);

            scrollOver(b, b.parentNode.id);

        }
    </script>
	</HEAD>
	<body leftMargin="20">
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"-->
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="6"><font size="4"><u><asp:label id="lblHeading" runat="server" Width="100%">Label</asp:label></u></font></TD>
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
					<TD width="5%"></TD>
					<TD width="10%">Sex/Age:&nbsp;&nbsp;</TD>
					<TD width="30%"><asp:label id="lblAgeSex" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Ward:</TD>
					<TD width="40%"><asp:label id="lblWard" runat="server" Font-Bold="True" width="100%">Label</asp:label></TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD width="5%"></TD>
					<TD width="10%">PR No:&nbsp;&nbsp;</TD>
					<TD width="30%"><asp:label id="lblPRNo" runat="server" Width="100%" Font-Bold="True">Label</asp:label></TD>
					<TD width="10%">Referred By:</TD>
					<TD width="40%"><asp:label id="lblReferredBy" runat="server" Font-Bold="True" Visible="true" width="20%">Label</asp:label>
                    <asp:TextBox ID="txtRefDoctor" runat="server" CssClass="field" Width="50%" Visible="false"></asp:TextBox>
                    </TD>
					<TD width="5%"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD><asp:label id="lblMSerialNo" runat="server" Width="100%" Font-Bold="True" Visible="False">Label</asp:label></TD>
					<TD></TD>
					<TD align="right" colSpan="3">
						<asp:imagebutton id="ibtnNextPatient" runat="server" ImageUrl="Images/btn_Next.gif"></asp:imagebutton>
                        <asp:ImageButton ID="ibtnResultByPRNo" runat="server" ImageUrl="Images/btn_ResultByPRNo.gif"
                            OnClick="ibtnResultByPRNo_Click" />
						<asp:imagebutton id="ibtnViewOtherResult" runat="server" 
                            ImageUrl="Images/btn_ViewResult.gif" Height="19px" ></asp:imagebutton><asp:imagebutton id="ibtnPatientStatus" runat="server" ImageUrl="Images/btn_Detail.gif"></asp:imagebutton><asp:imagebutton id="ImageButton2" runat="server" ImageUrl="Images/btn_Close.gif"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD colSpan="6"><asp:datagrid id="dgTest" runat="server" CssClass="datagrid" GridLines="Horizontal" CellPadding="0"
							onitemdatabound="dgTest_ItemDataBound" Width="99%" BorderColor="Gainsboro" AllowSorting="True" AutoGenerateColumns="False">
							<SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" CssClass="gridheader"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" CssClass="gridheader"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<IMG id="image_" height="16" src="images/expand.gif" width="16" runat="server">
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True" HeaderText="TestID"></asp:BoundColumn>
								<asp:BoundColumn DataField="TestNo" HeaderText="Dept No.">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Test" HeaderText="Test">
									<HeaderStyle Width="50%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" HeaderText="Acronym">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DeliveryDate" HeaderText="Del Date">
									<HeaderStyle Width="20%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<ItemTemplate>
                                    <tr>
                                        <td class="label" style="height:auto" colspan="5">
                                        Method:
                                        <asp:DropDownList ID="dgDDLMethod" Width="20%" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlMethod_SelectedIndexChanged"></asp:DropDownList>
                                        </td>
                                        <td align="right">
                                        <asp:ImageButton ID="ibtnSOP" ToolTip="SOPs" runat="server" ImageUrl="images\Btn_SOP.png" CommandArgument="<%#Container.DataSetIndex%>" OnCommand="ibtn_SOPClick" />
                                         <asp:ImageButton ID="imghistory" runat="server" Visible='<%#(DataBinder.Eval(Container.DataItem, "historyTaking").ToString() == "Y")%>' CommandArgument="<%#Container.DataSetIndex%>" ImageUrl="~/images/history2.png" ToolTip="History" OnCommand="imghistory_Click" />
                                        
                                        </td>
                                        </tr>
										<TR>
											<TD colspan="6">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="right">
															<DIV id="divOrders" style="DISPLAY: inline" runat="server">
																<asp:datagrid id="dgAttribute" runat="server" Width="99%" AutoGenerateColumns="False" BorderStyle="None"
																	OnItemDataBound="dgAttribute_ItemDataBound">
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
																			<HeaderStyle Width="70%"></HeaderStyle>
                                                                            <ItemStyle Width="70%" />
																			<ItemTemplate>
																				<P>
																					<asp:TextBox id=dgAttributeResult runat="server" Width="100%" 
                                                                                        Text='<%# DataBinder.Eval(Container.DataItem, "Result")  %>' MaxLength="100" 
                                                                                        Rows='<%# int.Parse(DataBinder.Eval(Container.DataItem, "SMLine").ToString()) %>' 
                                                                                        Height="100%" 
                                                                                        Textmode='<%# GetTextmode((string)DataBinder.Eval(Container.DataItem, "SMLine")) %>' 
                                                                                        Font-Size="Medium" ></asp:TextBox>
																					<asp:ListBox id="lbSelection" runat="server" Width="100%" AutoPostBack="True" Visible="False"
																						OnSelectedIndexChanged="lbSelection_SelectedIndexChanged"></asp:ListBox></P>
																			</ItemTemplate>
																		</asp:TemplateColumn>
																		<asp:TemplateColumn>
																			<HeaderStyle Width="15%"></HeaderStyle>
                                                                            <ItemStyle Width="15%" />
																			<ItemTemplate>
																				<asp:ImageButton id="ibtnSelection" runat="server" ImageUrl="images\btn_Piclist.gif" OnClick="ibtnSelection_Click"></asp:ImageButton>
                                                                                 
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
																		<TD width="10%"></TD>
																		<TD width="25%"></TD>
																		<TD width="20"></TD>
																		<TD width="20%"></TD>
																		<TD width="20%"></TD>
																		<TD width="5%"></TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="Label1" runat="server" Font-Size="X-Small">Forward to:</asp:label></TD>
																		<TD>
																			<asp:dropdownlist id="dgddlForwardtoIT" runat="server" Width="100%" Enabled="True" DataValueField="ProcessID" DataTextField="Process" DataSource='<%# FillDDLForwardTo(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>' SelectedIndex='<%# GetForwardIndex((string)DataBinder.Eval(Container.DataItem, "ProcessID")) %>'>
																			</asp:dropdownlist></TD>
																		<TD >
                                                                        <asp:CheckBox ID="chkRepeat" Text="Repeat Test" Font-Size="X-Small" OnCheckedChanged="chkReport_CheckedChanged" AutoPostBack="true" runat="server" />
                                                                        
                                                                        </TD>
																		<TD><asp:Label ID="lblReasons" runat="server" Text="Reasons" Visible="false" Font-Size="X-Small"></asp:Label>
                                                                        <asp:DropDownList ID="ddlRepeatReasons" Width="40%" Visible="false" runat="server" onchange="javascript:repeatreason(this.id)"></asp:DropDownList>
                                                                        </TD>
																		<TD></TD>
																		<TD></TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="Label2" runat="server" Font-Size="X-Small">Opinion:</asp:label></TD>
																		<TD colSpan="4">
																			<asp:textbox id=dgtxtOpinionET runat="server" Width="100%" CssClass="flattextbox" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>' Rows="3" MaxLength="255" Height="45px" TextMode="MultiLine">
																			</asp:textbox></TD>
																		<TD>
																			<asp:imagebutton id="ibtnOpinion" onclick="ibtnOpinion_Click" runat="server" ImageUrl="images\btn_Piclist.gif"></asp:imagebutton></TD>
																	</TR>
                                                                    <tr>
                                                                    <td>
                                                                    <asp:Label ID="lblHistory" Text="History" Visible="false" Font-Size="X-Small" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td colspan="4">
                                                                    <asp:TextBox ID="txtHistory" Visible="false" Width="100%" Text='<%#DataBinder.Eval(Container.DataItem,"History") %>' TextMode="MultiLine" CssClass="field" runat="server"></asp:TextBox>
                                                                    </td>
                                                                    </tr>
																			<TR>
																		<TD>
																			<asp:label id="Label4" runat="server" Font-Size="X-Small">Comment:</asp:label></TD>
																		<TD colSpan="4">
                                                                        
                                                                        <br />
																			<asp:textbox id="dgtxtCommentET" runat="server" Width="50%" Visible="true" TextMode="MultiLine" Height="45px" MaxLength="255" Rows="3" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>' CssClass="flattextbox">
																			</asp:textbox>
                                                                            <asp:LinkButton ID="lnksavecomment" runat="server" CommandName="save" Text="save" Font-Size="X-Small" Visible="true" OnCommand="lnkbtnsavecomment_Click"></asp:LinkButton>
                                                                            </TD>
																		<TD>
																			<asp:imagebutton id="ibtnComment" onclick="ibtnComment_Click" runat="server" ImageUrl="images\btn_Piclist.gif"></asp:imagebutton></TD>
																	</TR>

                                                                    <tr>
                                                                    <td></td>
                                                                    <td colspan="4">
                                                                    <asp:GridView ID="gvComments" Width="100%" CssClass="datagrid" DataKeyNames="TestResultCommentID" AutoGenerateColumns="false" OnRowDeleting="gvComments_RowDeleting_Click" runat="server">
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
                                                                    </td>
                                                                    </tr>
                                                                     <tr>
                                                                    <td colspan="6"><asp:LinkButton ID="lnkbtnEval" runat="server" Text="Add Evaluation" Font-Size="X-Small" OnClick="lnkbtnEval_Click" Visible="false"></asp:LinkButton></td>
                                                                    </tr>

                                                                    <tr>
                                                                    <td colspan="6" style="background-color:Window">
                                                                    <asp:LinkButton ID="lnkbtnDiagnosis" Text="Peer Review" Font-Size="X-Small" 
                                                                            runat="server" OnClick="lnkbtnPeerReview_Click" Visible="false"></asp:LinkButton>
                                                                     <asp:ImageButton ID="gvimgReviewComments" ImageUrl="~/images/a-unread.png" OnClick="gvimgReviewComments_Click" Visible="false" ToolTip="Peer Comments about the Result" runat="server" />

                                                                        <asp:ModalPopupExtender ID="gvimgReviewComments_ModalPopupExtender" 
                                                                            runat="server" PopupControlID="pnlComments" DynamicServicePath="" Enabled="True" 
                                                                            TargetControlID="gvimgReviewComments">
                                                                        </asp:ModalPopupExtender>
                                                                        <asp:Panel ID="pnlComments" visible="false" runat="server" width="400px">
                        <table id="tblcomments" style="background-color:Aqua" class="label" width="99%">
                        <tr>
                            <td width="99%" align="right">
                                <asp:LinkButton ID="lnkclose" Text="[X]close" OnClick="lnkClose_Click" runat="server"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td width="99%">
                                <asp:GridView ID="gvPeerReviews" CssClass="datagrid" runat="server" AutoGenerateColumns="false" Width="99%">
                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                <RowStyle CssClass="gridItem" />
                                <AlternatingRowStyle CssClass="gridAlternate" />
                                <Columns>
                                    <asp:BoundField ItemStyle-Width="70%" HeaderText="Comments" DataField="Comments" />
                                    <asp:BoundField HeaderText="Entered By" DataField="EnteredBy" />
                                </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                    </asp:Panel>
                                                                    </td>
                                                                    </tr>
                                                                     <tr>
                                                                  <td colspan="6">
                                                                  <table id="tblDiagnosis" visible="false" runat="server" class="label" width="100%">
                                                              
                                                                  <tr>
                                                                 
                                                                    <TD width="10%"><asp:label id="Label5" runat="server" Font-Size="X-Small">Pathologist:</asp:label></TD>
																		<TD width="25%">
                                                                  
                                                                       
                                                                        <asp:DropDownList ID="DDLPathologist" runat="server" CssClass="field" Width="100%" 
                                                                         Visible="true"></asp:DropDownList>
                                                                          <asp:ListSearchExtender ID="DDLPathologist_ListSearchExtender" runat="server" 
                                                                                Enabled="True" TargetControlID="DDLPathologist">
                                                                            </asp:ListSearchExtender></TD>
																	
                                                                        <TD>
                                                                   
                                                                        <%--<asp:Label ID="Label6" Font-Size="X-Small" runat="server">Code:</asp:Label>--%>
                                                                       
                                                                      
                                                                        <%--<asp:DropDownList ID="DDLdiseasecode" runat="server" CssClass="field"  
                                                                                DataSource='<%#FillDDLPathologists()%>' DataTextField="DiseaseCode" 
                                                                                DataValueField="DiseaseID" AutoPostBack="true" 
                                                                                OnSelectedIndexChanged="ddlDiseasecode_SelectedIndexchanged" Visible="False"></asp:DropDownList>--%>
																		
                                                                       <%-- <asp:CheckBox ID="chkPrint" Text="Print" Font-Size="X-Small" runat="server" 
                                                                                Visible="False" />--%>
                                                                       <%-- <asp:Button ID="ibtnsearch" onclick="ibtnsearch_Click" runat="server" Text="Search" 
                                                                                CssClass="buttonStyle" BackColor="HighLight" Visible="False"></asp:Button>--%>
                                                                        <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" 
                                                                                CssClass="buttonStyle" Text="Refer" BackColor="Highlight" Visible="true" />
                                                                      <%-- </ContentTemplate>
                                                                         <Triggers>
                                                                         <asp:AsyncPostBackTrigger ControlID="DDLdiseasename" EventName="SelectedIndexChanged" />
                                                                         </Triggers>
                                                                       </asp:UpdatePanel>--%>
                                                                       <%-- <input type="text" class="flattextbox" onchange="chkValue(this,'dgtest',0)" />--%>
                                                                        </TD>
                                                                        <TD width="10%"></TD>
																		<TD width="10%" align="right">
																			
																			</TD>
																		<td width="5%"></td>
                                                                         </tr>
                                                                         <tr>
                                                                         <td colspan="6">
                                                                            
                                                                         </td>
                                                                         </tr>
                                                                  </table>
                                                                  </td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td></td>
                                                                    <td colspan="5">
                                                                    
                                                                    </td>
                                                                    </tr>

                                                                  

                                                                  <tr>
                                                                    <td colspan="6">
                                                                      <asp:LinkButton ID="gvlnkpath1" runat="server" Visible="false" OnClick="gvlnkPath1_Click"
                                                                        Font-Size="X-Small"></asp:LinkButton>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;                                                                   
                                                                         <asp:LinkButton ID="gvlnkdelfile1" runat="server" Visible="false" Text="[X]" ToolTip="Delete" Font-Size="X-Small" CommandName="file1" OnCommand="gvlnkdelfile_Command"></asp:LinkButton>
                                                                    <br />
                                                                    <asp:LinkButton ID="gvlnkPath2" runat="server" Visible="false" OnClick="gvlnkPath2_Click"
                                                                        Font-Size="X-Small"></asp:LinkButton>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:LinkButton ID="gvlnkdelfile2" runat="server" Visible="false" Text="[X]" ToolTip="Delete" Font-Size="X-Small" CommandName="file2" OnCommand="gvlnkdelfile_Command"></asp:LinkButton>

                                                                    <br />
                                                                    <asp:LinkButton ID="gvlnkPath3" runat="server" Visible="false" OnClick="gvlnkPath3_Click"
                                                                        Font-Size="X-Small"></asp:LinkButton>
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <asp:LinkButton ID="gvlnkdelfile3" runat="server" Visible="false" Text="[X]" ToolTip="Delete" Font-Size="X-Small" CommandName="file2" OnCommand="gvlnkdelfile_Command"></asp:LinkButton>
                                                                        <br />
                                                                    <asp:FileUpload id="FileUploadControl1" runat="server" />
<%-- <asp:Button runat="server" id="UploadButton1" text="Upload" Visible="false" onclick="UploadButton1_Click" /> --%>
<asp:Label runat="server" id="StatusLabel1" text="Upload status: " Visible="false" Font-Size="X-Small" />
                                                                    </td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td colspan="6">
                                                                    <asp:FileUpload id="FileUploadControl2" Visible="true" runat="server" />
<%-- <asp:Button runat="server" id="UploadButton2" text="Upload" Visible="false" onclick="UploadButton2_Click" />--%>
<asp:Label runat="server" id="StatusLabel2" text="Upload status: " Visible="false" Font-Size="X-Small" />
                                                                    
                                                                    </td>
                                                                    </tr>
                                                                      <tr>
                                                                    <td colspan="6">
                                                                    <asp:FileUpload id="FileUploadControl3" Visible="false" runat="server" />
<%-- <asp:Button runat="server" id="UploadButton3" text="Upload" Visible="false" onclick="UploadButton3_Click" />--%>
<asp:Label runat="server" id="StatusLabel3" text="Upload status: " Visible="false" Font-Size="X-Small" />
                                                                    
                                                                    
                                                                    </td>
                                                                    </tr>
                                                                    <tr>
                                                            <td colspan="5">
                                                            
                                                            
                                                            <%--<asp:LinkButton ID="lnkshowhide" runat="server" Text="Add ICD Code" Font-Size="X-Small"></asp:LinkButton>--%>
                                                            
                                                            <asp:Panel ID="pnlDiseases" runat="server">
                                                            
                                                            <table width="99%">
                                                            <tr>
                                                                                                                        
                                                            
                                                                <td style="font-size: xx-small; font-family: Arial">
                                                                    Disease Name</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtItemName" CssClass="field" runat="server" onkeyup="searchSuggest(event,this.id)"
                                                                        autocomplete="off" Width="45%"></asp:TextBox>
                                                                    <asp:Button ID="btnSearchDisease" CommandArgument="<%#Container.DataSetIndex %>" runat="server" Text="Search" BackColor="Aqua" BorderColor="#3333CC"
                                                                        OnCommand="btnSearchDisease_Click" />
                                                                    
                                                                    <br />
                                                                    <div id="search_suggest" runat="server" style="width: 350px">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <div id="divsearcharea" class="label" runat="server" visible="true">
                                                                        
                                                                            <asp:GridView ID="gvDiagnosissearch" runat="server" AutoGenerateColumns="false" CssClass="datagrid"
                                                                                DataKeyNames="DISEASEID" OnRowCommand="gvDiagnosissearch_RowCommand" Width="99%">
                                                                                <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
                                                                                <RowStyle CssClass="gridItem" />
                                                                                <AlternatingRowStyle CssClass="gridAlternate" />
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="S#">
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
                                                                                    <asp:CommandField SelectText="Add" ButtonType="Link" ShowSelectButton="true" />
                                                                                </Columns>
                                                                            </asp:GridView>
                                                                            <asp:DropShadowExtender ID="gvDiagnosissearch_DropShadowExtender" runat="server"
                                                                                Enabled="True" Rounded="True" TargetControlID="gvDiagnosissearch">
                                                                            </asp:DropShadowExtender>
                                                                        
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            <td></td>
                                                            <td>
                                                            
                                    <asp:GridView ID="gvDiseases" AutoGenerateColumns="false" Width="99%" DataKeyNames="DIAGNOSISID"
                                        OnRowDeleting="gvDiseases_RowDeleting_Click" runat="server" CssClass="datagrid">
                                        <%--DataSource='<%#FillgvDiseases() %>'--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="S#">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="ICD Code" DataField="ICD_Code">
                                                <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Disease Name" DataField="Disease_Name">
                                                <HeaderStyle HorizontalAlign="Left" Width="65%" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Print">
                                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="gvchkprint" runat="server" Enabled="false" Checked='<%# (DataBinder.Eval(Container.DataItem,"Print").ToString()=="Y") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField DeleteImageUrl="~/images/remove.png" ButtonType="Image" ShowDeleteButton="True">
                                                <ItemStyle Width="7%" />
                                            </asp:CommandField>
                                            <%-- <asp:TemplateField HeaderText="Delete">
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
                                                            </tr>
                                                            
                                                            </table>
                                                            </asp:Panel>
                                                            
                                                            <%--<asp:CollapsiblePanelExtender ID="discolpnlext" runat="server" TargetControlID="pnlDiseases" CollapsedSize="1" Collapsed="true" ExpandControlID="lnkshowhide" CollapseControlID="lnkshowhide" ExpandDirection="Vertical"></asp:CollapsiblePanelExtender>
                                                            --%></td>
                                                            </tr>

																	<TR>
																		<TD width="10%"></TD>
																		<TD width="25%"></TD>
																		<TD width="20"></TD>
																		<TD width="20%"></TD>
																		<TD align="right" width="20%">
																			<asp:ImageButton id="ibtnHold" runat="server" ImageUrl="Images/btn_Hold.gif"></asp:ImageButton>
																			<asp:ImageButton id="ibtnSave" OnClientClick="return chkmethod(this.id);" onclick="ibtnSave_Click" runat="server" ImageUrl="images/btn_Save.gif"></asp:ImageButton></TD>
																		<TD width="5%"></TD>
																	</TR>
																</TABLE>
															</DIV>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</ItemTemplate>
								</asp:TemplateColumn>
							    <asp:BoundColumn DataField="Preferred" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="Attribute_Count" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn DataField="D_methodiD" Visible="False"></asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>


						<!--	<TR>
					<TD colSpan="6"><asp:label id="lblErrMsg2" runat="server" Width="100%" ForeColor="Red"></asp:label></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="6">HMS_LM_IN_101</TD>
				</TR> --></TD>
				</TR>

                                                                                 </TABLE>
                                                                 
			</TABLE>
		</form>
	</body>
</HTML>
