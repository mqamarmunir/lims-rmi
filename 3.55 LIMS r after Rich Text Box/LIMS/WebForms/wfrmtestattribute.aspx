<%@ Page language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestAttribute" CodeFile="wfrmTestAttribute.aspx.cs" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LIMS: Test Attribute Registration:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="False" name="vs_showGrid">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
	</HEAD>
	<body>
    <script type="text/javascript" language="javascript">
   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        function filter(txtid, _tableid) {
            var hidden_variables = document.getElementById("hdVariableNames");
            var hidden_locations = document.getElementById("hdlocations");
            var hidden_vartypes = document.getElementById("hdVariableTypes");
            var term = document.getElementById(txtid);
            var suche = term.value;
            var suchestring = suche.toString();
            var mystring = suchestring.replace(/[^a-zA-Z ]/g, " ");
            var countspaces = 0;
            var loopvar = 0;
            var indices = new Array();
            var variables = new Array();
            var patientvariables = new Array("age", "height", "weight", "bloodgroup", "gender");
            var formula_variable = new Array("sin", "cos", "tan", "log", "pow");
            var attribute_variables = new Array();
            var attributevalues_indices = 0;
            var _table = document.getElementById(_tableid);
            for (var a = 1; a < _table.rows.length; a++) {
                attribute_variables[attributevalues_indices] = _table.rows[a].cells[1].innerHTML.toString().toUpperCase();
                attributevalues_indices++;
            }
            //  alert(attribute_variables.toString());


            for (var i = 0; i < mystring.length; i++) {
                if (mystring[i] == " ") {
                    countspaces++;
                }
                else {
                    variables[loopvar] = mystring[i];
                    indices[loopvar] = i;
                    loopvar++;
                }
            }
            var loopvariable = 0;
            var vars = new Array();
            var locations = new Array();
            locations[0] = indices[0];
            vars[0] = variables[0].toString();

            for (var k = 1; k < indices.length; k++) {
                if (indices[k] - indices[k - 1] == 1) {
                    //                    variables[loopvariable] += variables[k];
                    vars[loopvariable] = vars[loopvariable] + variables[k];
                    locations[loopvariable] = locations[loopvariable] + ":" + indices[k];
                    //alert(variables[k - 1]);
                }
                else {
                    loopvariable++;
                    vars[loopvariable] = variables[k];
                    locations[loopvariable] = indices[k];
                }
            }

            //  alert(locations.toString());



            var comparecount = 0;
            var comparecount_attr = 0;
            var comparecount_function = 0;
            var count_validvariables = 0;
            var var_types = new Array();

            for (var tocheck = 0; tocheck < vars.length; tocheck++) {
                comparecount = 0;
                comparecount_attr = 0;
                comparecount_function = 0;
                for (var tcomparewith = 0; tcomparewith < patientvariables.length; tcomparewith++) {
                    if (vars[tocheck].toString() == patientvariables[tcomparewith].toString()) {
                        comparecount++;
                        count_validvariables++;
                        var_types[tocheck] = "P";
                        //break;
                    }
                }

                for (var tocompareattr = 0; tocompareattr < attribute_variables.length; tocompareattr++) {
                    if (vars[tocheck].toString() == attribute_variables[tocompareattr].toString()) {
                        comparecount_attr++;
                        count_validvariables++;
                       // vars[tocheck] = vars[tocheck].toUpperCase();
                        var_types[tocheck] = "A";
                    }
                }
                for (var tocompareattribute = 0; tocompareattribute < formula_variable.length; tocompareattribute++) {
                    if (vars[tocheck].toString() == formula_variable[tocompareattribute].toString()) {
                        comparecount_function++;
                        count_validvariables++;
                        var_types[tocheck] = "F";
                    }
                }

                if (comparecount == 0 && comparecount_attr == 0 && comparecount_function == 0) {
                    alert("'" + vars[tocheck].toString() + "' is not a valid variable, Please enter correct formula");
                }
            }
            // alert(var_types.toString());
            if (count_validvariables == vars.length) {

                hidden_variables.value = vars.toString();
                hidden_locations.value = locations.toString();
                hidden_vartypes.value = var_types.toString();

                ////alert("Variables: " + hidden_variables.value.toString() + " Types: " + hidden_vartypes.value.toString());
                ////            alert("Indices: " + hidden_locations.value.toString());
                ////            alert("Types: " + hidden_vartypes.value.toString());
                alert("All Formula Variables are correct");
                for (var chkgender = 0; chkgender < vars.length; chkgender++) {
                    if (vars[chkgender] == "gender") {
                        document.getElementById("txtMlValue").disabled = false;
                        document.getElementById("txtFmlValue").disabled = false;
                        break;
                    }
                    else {
                        document.getElementById("txtMlValue").disabled = true;
                        document.getElementById("txtFmlValue").disabled = true;
                        
                    }
                }
            }
        }
            //alert(count_validvariables);
              // alert(vars[1].toString());

//            var tempstr = mystring.split(" ");
//            alert(tempstr);
//            alert(tempstr.split(","));
//            alert(variables.toString());
//            alert(indices.toString());
           
//            for (var j = 0; j < countspaces; j++) {
////                variables[j] = mystring.split(" ");
////                alert(variables[j]);
//               // variables[j] = mystring.substr(indices, mystring.indexOf(" ",indices));
//                //indices = mystring.indexOf(" ", indices+1);
//                //alert(variables[j]);
////                alert(j);
////                alert(j + 1);
////                alert(mystring.indexOf(" ",j));
////                alert(mystring.indexOf(" ",j+1));
//            }



           ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
    </script>
		<form id="Form1" method="post" runat="server">
			<TABLE class="label" id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD align="right" colSpan="8"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="8"><font size="4"><STRONG>TEST ATTRIBUTE REGISTRATION</STRONG></font>
                    
                    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
                    </TD>
				</TR>
				<TR>

					<TD align="right" colspan="8">&nbsp;
                    <asp:HiddenField ID="hdVariableNames" runat="server" />
                    <asp:HiddenField ID="hdlocations" runat="server" />
                    <asp:HiddenField ID="hdVariableTypes" runat="server" />
						<asp:ImageButton id="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" 
                            onclick="ibtnSave_Click2" ></asp:ImageButton>
						<asp:ImageButton id="ibtnClear" runat="server" ImageUrl="images/btn_Clear.gif" 
                            onclick="ibtnClear_Click1"></asp:ImageButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:ImageButton id="ibtnAttributeRanges" runat="server" ImageUrl="images/btn_AttributeRanges.gif"></asp:ImageButton>
						<asp:ImageButton id="ibtnClose" runat="server" ImageUrl="images/btn_Close.gif"></asp:ImageButton>
					</TD>
				</TR>
				<TR>
					<TD colSpan="8"><asp:label id="lblErrMsg" runat="server" Width="100%" ForeColor="Red" Font-Bold="True"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Section</TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlSection" runat="server" Width="100%" AutoPostBack="True" tabIndex="1" onselectedindexchanged="ddlSection_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Test Group</TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlTestGroup" runat="server" Enabled="False" Width="100%" AutoPostBack="True"
							tabIndex="2" onselectedindexchanged="ddlTestGroup_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD>Test</TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlTest" runat="server" Enabled="False" Width="100%" AutoPostBack="True" tabIndex="3" onselectedindexchanged="ddlTest_SelectedIndexChanged"></asp:dropdownlist></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="10%"></TD>
					<TD width="10%"></TD>
					<TD width="10%" align="right"><asp:checkbox id="chkActive" runat="server" Width="100%" Checked="True" tabIndex="4" Text="Active" TextAlign="Left"></asp:checkbox></TD>
					<TD width="20%" align="right">
                        <asp:CheckBox ID="chkSummary" runat="server" Text="Summary" TextAlign="Left" /></TD>
					<TD width="10%" align="right">
						<asp:CheckBox id="chkReport" runat="server" tabIndex="9" Text="Report" TextAlign="Left"></asp:CheckBox></TD>
					<TD width="20%"></TD>
					<TD width="10%"></TD>
				</TR>
                <Tr>
                <TD></TD>
                <TD>
                &nbsp;</TD>
                <TD colspan=3>
                    &nbsp;</TD>
                </Tr>
					<TD></TD>
                    
					<TD>Attribute</TD>
					<TD colSpan="3">
                     <%--<CKEditor:CKEditorControl ID="txtTestAttribute" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="10" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="false" Width="100%" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="25px" Enabled="False" ToolbarBasic="Source|-|Bold|Italic" MaxLength="150"></CKEditor:CKEditorControl>--%>
                    <asp:textbox id="txtTestAttribute" runat="server" Enabled="False" Width="100%" CssClass="mandatoryfield"
							tabIndex="5" ToolTip="Enter Test Attribute Name"></asp:textbox></TD>
					<TD align="right">Acronym:</TD>
					<TD><asp:textbox id="txtAcronym" runat="server" Enabled="False" Width="50%" CssClass="field" tabIndex="6"
							ToolTip="Enter Test Attribute Acronym" MaxLength="100"></asp:textbox>
                            <asp:LinkButton ID="lnkupdteAcronym" Text="Update Acronym" runat="server" CommandName="Edit" OnClick="lnkbtnupdateAcronym_Click" Visible="false" Font-Size="XX-Small"></asp:LinkButton>
                            </TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD>Input Type</TD>
					<TD><asp:dropdownlist id="ddlType" runat="server" Enabled="False" Width="100%" tabIndex="7" AutoPostBack="True" onselectedindexchanged="ddlType_SelectedIndexChanged">
							<asp:ListItem Value="0" Selected="True">Input</asp:ListItem>
							<asp:ListItem Value="1">Selection</asp:ListItem>
						</asp:dropdownlist></TD>
					<TD align="right">
						<asp:LinkButton id="lbtnSelectionValues" runat="server" Visible="False" onclick="lbtnSelectionValues_Click">Values</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; Type:</TD>
					<td><asp:dropdownlist id="ddlAttributeType" runat="server" Enabled="False" 
                            Width="50%" tabIndex="7" 
                            onselectedindexchanged="ddlAttributeType_SelectedIndexChanged" 
                            AutoPostBack="True">
							<asp:ListItem Value="-1" Selected="True">Select</asp:ListItem>
							<asp:ListItem Value="0">Numeric</asp:ListItem>
							<asp:ListItem Value="1">Text</asp:ListItem>
						</asp:dropdownlist>
                        <asp:LinkButton ID="lnkupdateType" runat="server" Text="Update Multiple" OnClick="lnkupdateType_Click"></asp:LinkButton>
                        <asp:ModalPopupExtender ID="lnkupdateType_ModalPopupExtender" runat="server" 
                            DynamicServicePath="" PopupControlID="pnlpopup" Enabled="True" TargetControlID="lnkupdateType">
                        </asp:ModalPopupExtender>
                        </td>
					<TD align="right">
                    <asp:UpdatePanel ID="updteCountchk" runat="server">
                    <ContentTemplate>
                   
                    <asp:CheckBox ID="chkCount" AutoPostBack="true" runat="server" Enabled="false" Text="Count" 
                            oncheckedchanged="chkCount_CheckedChanged" />
                            
                            
                             </ContentTemplate>
                             <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="ddlAttributeType" EventName="SelectedIndexChanged" />
                             </Triggers>
                    </asp:UpdatePanel> </TD>
					<TD align="justify">
                    <asp:UpdatePanel ID="txtUpdateCount" runat="server">
                    <ContentTemplate>
                    
                    
					<asp:Label ID="lblValueCount" runat="server" Text="Value(Count)" ></asp:Label>
                        
              <asp:TextBox ID="txtCountValue" Width="50%" runat="server" Enabled="false" CssClass="mandatoryField"></asp:TextBox>
              </ContentTemplate>
              <Triggers>
              <asp:AsyncPostBackTrigger ControlID="chkCount" EventName="CheckedChanged" />
              </Triggers>
                    </asp:UpdatePanel>
              </TD>
					<TD></TD>
				</TR>
				<TR>
					<TD width="10%"></TD>
					<TD width="10%">Rows</TD>
					<TD width="10%">
						<asp:DropDownList id="ddlSMline" tabIndex="8" runat="server" Width="100%">
							<asp:ListItem Value="1" Selected="True">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="4">4</asp:ListItem>
							<asp:ListItem Value="5">5</asp:ListItem>
							<asp:ListItem Value="6">6</asp:ListItem>
							<asp:ListItem Value="7">7</asp:ListItem>
							<asp:ListItem Value="8">8</asp:ListItem>
							<asp:ListItem Value="9">9</asp:ListItem>
						</asp:DropDownList></TD>
					<TD width="10%" align="right">Report Col</TD>
					<TD width="20%">
						<asp:DropDownList id="ddlReportCol" runat="server" Width="80%">
							<asp:ListItem Value="1" Selected="True">Column 1</asp:ListItem>
							<asp:ListItem Value="2">Column 2</asp:ListItem>
							<asp:ListItem Value="3">Column 3</asp:ListItem>
						</asp:DropDownList></TD>
					<TD width="10%" align="right"><asp:CheckBox ID="chkDerived" Text="Derived" 
                            AutoPostBack="true" runat="server" 
                            oncheckedchanged="chkDerived_CheckedChanged" /></TD>
					<TD width="20%">
						</TD>
					<TD width="10%"></TD>
				</TR>
                        <tr>
                        <td></td>
                        <td colspan="4">
                        <asp:UpdatePanel ID="updteFormula" runat="server">
                        <ContentTemplate>
                       
                        <div id="divFormula" style="background-color: #CCFFCC">
                                <table id="tblderivedfield" visible="false" class="label"  width="100%" runat="server" 
                                    cellspacing="0" style="background-color: #CCFFCC">
                                <tr>
                                <td>
                                <asp:Label ID="lblFormula" Font-Size="X-Small" Text="Formula" runat="server"></asp:Label>
                                </td>
                                <td colspan="2">
                                 <asp:TextBox ID="txtFormula" Width="100%" runat="server" 
                                        CssClass="mandatoryField"  
                                        onchange="javascript: filter('txtFormula','dgTestAtt');" BackColor="#CCFFFF"></asp:TextBox>
                                </td>
                              
                                </tr>
                                <tr>
                                <td width="20%">
                                    Gender(Values)</td>
                                <td width="40%">
                                    Male:
                                    <asp:TextBox ID="txtMlValue" runat="server" CssClass="mandatoryField" 
                                        BackColor="#CCFFFF" Enabled="false"></asp:TextBox></td>
                                <td width="40%">
                                Female:
                                <asp:TextBox ID="txtFmlValue" runat="server" CssClass="mandatoryField" 
                                        BackColor="#CCFFFF" Enabled="false"></asp:TextBox>
                                </td>
                                
                                </tr>
                                <tr>
                                
                           
                                <td>
                                Description
                                </td>
                                <td colspan="2">
                      <asp:TextBox ID="txtDescription" runat="server" CssClass="field" TextMode="MultiLine" BackColor="#CCFFFF" Width="100%"></asp:TextBox>
                                </td>
                                     </tr>
                                <tr>
                                <td colspan="3" align="justify">
                                    <strong>Guide Lines for Formula Writing</strong></td>
                                    </tr>
                                    <tr>
                                    <td colspan="3">
                                    <ol>
                                    <li>
                                        Use Attribute Acronyms for Attribute Variables.</li>
                                    <li>
                                        Supported Mathematical Functions and there syntax is as given below:
                                        <ol>
                                        <li>
                                            pow(base,power) For power.</li>
                                            <li>
                                            log(x) for log.
                                            </li>
                                            <li>
                                            sin(x),cos(x),tan(x) for trignometric functions.
                                            </li>
                                            <li>
                                            
                                                +,-,*,/ for simple mathematical operations.</li>
                                        </ol>
                                        </li>
                                        <li>
                                        Use (age,weight,height and gender) for patient Variables.
                                        </li>
                                        <li>
                                        Attribute Vaiables(Acronyms) must be in upper case(letters) and all other variables and fuctions should be in lower case.
                                        </li>
                                        <li>
                                            Acronyms should be purely alphabetical i-e characters except Alphabets[a-z,A-Z] 
                                            are not allowed.   
                                        </li>
                                    <li>
                                        Note:The system will Prompt for wrong variable entry. But It willl not check the 
                                        validity of the formula. So be careful while writing the Formulas.</li>
                                        <li>
                                            All variables and formula functions are case sensitive.
                                        </li>
                                       
                                   
                                    </ol>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td></td>
                                    </tr>
                                </table>
                        </div>
                         </ContentTemplate>
                         <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="chkDerived" EventName="CheckedChanged" />
                         </Triggers>
                        </asp:UpdatePanel>
                        </td>
                        </tr>

             <%--   <tr>
                <td>
                
                 </td>
                 
                 <td>
                  <asp:UpdatePanel ID="updtefrmula" runat="server">
                  <ContentTemplate>
                 
                 <asp:Label ID="lblFormula" Text="Formula" Visible="false" runat="server"></asp:Label>
               </ContentTemplate>
               <Triggers>
               <asp:AsyncPostBackTrigger ControlID="chkDerived" EventName="CheckedChanged" />
              
               </Triggers>
                  </asp:UpdatePanel>
                 </td>
                 <td colspan="3">
                 <asp:UpdatePanel ID="updteFormulaetxt" runat="server">
                 <ContentTemplate>
                 
                 <asp:TextBox ID="txtFormula" Width="100%" Visible="false" runat="server" CssClass="mandatoryField"  onchange="javascript: filter('txtFormula','dgTestAtt');"></asp:TextBox> 
       
                 </ContentTemplate>
                 <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="chkDerived" EventName="CheckedChanged" />
                 </Triggers>
                 </asp:UpdatePanel>
                 
                 </td>
                </tr>--%>
				<TR>
					<TD></TD>
                    <td>&nbsp;</td>
                    <td colspan=3>
                    <CKEditor:CKEditorControl ID="interpretation_Rtext" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="False"
                            ToolbarBasic="Source|-|Bold|Italic" MaxLength="1000" Visible="false"></CKEditor:CKEditorControl>
                    </td>
				</TR>
                <tr>
                <td>
                </td>
                <td colspan="7">
                    <asp:Label ID="lblColor" runat="server" BackColor="Cyan" Text="Numeric Attributes"></asp:Label>
                </td>
                </tr>
               
				<TR>
					<TD colSpan="8" align="center"><asp:datagrid id="dgTestAtt" runat="server" AutoGenerateColumns="False" AllowSorting="True" BorderColor="Silver"
							PageSize="25" CssClass="datagrid" OnItemDataBound="dTgTestAtt_ItemDataBound">
							<SelectedItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridSelectedItem"></SelectedItemStyle>
							<AlternatingItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridAlternate"></AlternatingItemStyle>
							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="AttributeID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn DataField="Attribute" SortExpression="TestGroup" ReadOnly="True" HeaderText="Attribute">
									<HeaderStyle Width="60%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Acronym" SortExpression="Acronym" ReadOnly="True" HeaderText="Acronym">
									<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled=False Checked='<%#(DataBinder.Eval(Container.DataItem, "Active").ToString() == "Y")%>' Runat=server>
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:EditCommandColumn EditText="Edit">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" ForeColor="Blue"></ItemStyle>
								</asp:EditCommandColumn>
								<asp:BoundColumn Visible="False" DataField="InputType" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="ProcedureID" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="RPrint" ReadOnly="True"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="SMLine" ReadOnly="True" HeaderText="SMLine"></asp:BoundColumn>
								<asp:ButtonColumn Visible="False" Text="Delete" CommandName="Delete">
									<HeaderStyle Width="5%"></HeaderStyle>
								</asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="RDISCOL" HeaderText="RDISCOL"></asp:BoundColumn>
                                <asp:BoundColumn DataField="summary" HeaderText="summary" Visible="False"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="Attribute_Interpretation" ReadOnly="true" HeaderText="Interpretation"></asp:BoundColumn>
                                <asp:BoundColumn Visible="False" DataField="AttributeType" ReadOnly="true" 
                                    HeaderText="Attribute Type"></asp:BoundColumn>
							
                                <asp:BoundColumn DataField="Count" HeaderText="chkCount" Visible="False">
                                </asp:BoundColumn>
							
                                <asp:BoundColumn DataField="Derived" Visible="False"></asp:BoundColumn>
							
                            </Columns>
							<PagerStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Blue" PageButtonCount="3" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD colspan="8">
                    <asp:Panel ID="pnlpopup" CssClass="mPopup" runat="server" Width="50%">
                    <table id="tblpopup" class="label" style="background-color:#CCFFCC" >
                    <tr>
                    <td colspan="7" align="right">
                    <asp:ImageButton id="popupsave" runat="server" ImageUrl="images/btn_Save.gif" OnClick="popupsave_Click" ></asp:ImageButton>
                    <asp:ImageButton id="popupclose" runat="server" ImageUrl="images/btn_Close.gif" 
                            onclick="popupclose_Click"></asp:ImageButton>
                    </td>
                   
                   
                    </tr>
                    <tr>
                    <td colspan="7">
                
                        <asp:GridView ID="popupgridAttributes" CssClass="datagrid" DataKeyNames="AttributeID,AttributeType" Width="99%" 
                          OnRowDataBound="popgridAttributes_DataBound" AutoGenerateColumns="false" runat="server">
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

                            <asp:BoundField DataField="Attribute" HeaderText="Attribute" />

                            <asp:TemplateField HeaderText="Numeric">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                            <asp:CheckBox ID="gvpopchknumeric" runat="server" />
                            </ItemTemplate>

                            </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                    
                    </td>
                    </tr>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    </tr>
                    </table>
                    </asp:Panel>
                    </TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="8">HMS_LM_IN_003 colspan="8"></TD>
				</TR>
				<TR>
					<TD class="screenid" align="right" colSpan="8">HMS_LM_IN_003</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
