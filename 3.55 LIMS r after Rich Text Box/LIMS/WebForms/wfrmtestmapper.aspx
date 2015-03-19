<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmtestmapper.aspx.cs" Inherits="LIMS_WebForms_wfrmtestmapper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<script type="text/javascript" charset="utf-8">

    function filter(term, _id, cellNr) {
        var suche = term.value.toLowerCase();
        var table = document.getElementById(_id);
        var ele;
        for (var r = 1; r < table.rows.length; r++) {
            ele = table.rows[r].cells[cellNr].innerHTML.replace(/<[^>]+>/g, "");
            if (ele.toLowerCase().indexOf(suche) >= 0 && ele.toLowerCase().indexOf(suche) <= 11) {
                //alert(ele.toLowerCase().indexOf(suche));
                table.rows[r].style.display = '';
            }
            else table.rows[r].style.display = 'none';

            //      alert(table.rows[1].cells[1].innerHTML.toString());
        }
    }
    </script>
    <title></title>
    <LINK href="LIMS.css" rel="stylesheet">
   <%-- <link href="../../scripts/jquery-1.7.1.min.js" type="text/jscript" />--%>
    <script type="text/javascript">
        function SelectCheckbox(checkbox) {
            var row = checkbox.parentNode.parentNode;
            var grid = checkbox.parentNode.parentNode.parentNode;
           // alert(grid);
                        var inputs = row.getElementsByTagName('input');
                      

                      //   alert(inputs[2].value);
                            
                                if (inputs[0].checked) {
                                  //  alert("select chkb " + inputs[0].id);
                                var selectedchk = inputs[0].id; }



                              //  alert(grid.rows.length);

            for (var rowcount = 1; rowcount <= grid.rows.length-1; rowcount++) {
               // alert(grid.rows[rowcount]);
                var gridrow = grid.rows[rowcount].getElementsByTagName('input');
                // alert(grid.rows[rowcount]);
              //  alert(gridrow.length);

                if (gridrow[0].id == selectedchk) {

                    if (gridrow[0].checked) {
                       // alert("select chkb column no" + j + " " + inputs[j].id);
                       // var selectedchk = inputs[j].id;
                    }

                } else {
                             gridrow[0].checked = false;
                }
                
                    // alert(inputs[j].id);

                }
                 }
                 function GenerateTable(Button) {

                     var row = Button.parentNode.parentNode;
                     var grid = document.getElementById('<%=dgExternal.ClientID%>');
                    // alert(grid);
                     var inputs = row.getElementsByTagName('input');


                     //   alert(inputs[2].value);

                     if (inputs[0].checked) {
                         //  alert("select chkb " + inputs[0].id);
                         var testid = inputs[1].value;
                         var testname = inputs[2].value;
                     }
                     else {

                         alert("Please Select the test To add");
                         return;
                     }




                     //  alert(grid.rows.length);

                     for (var rowcount = 1; rowcount <= grid.rows.length - 1; rowcount++) {
                         // alert(grid.rows[rowcount]);
                         var gridrow = grid.rows[rowcount].getElementsByTagName('input');
                         // alert(grid.rows[rowcount]);
                         //  alert(gridrow.length);

                        

                             if (gridrow[0].checked) {
                                 var cliquetestid=gridrow[1].value;
                                 var cliquetestname=gridrow[2].value;
                             }





                         }
                         if ((cliquetestid == NaN || cliquetestid == null) && (cliquetestname == NaN || cliquetestname == null)) {

                             alert("Please Select the test To add");
                             return;
                         }
                        // var grid = document.getElementById('');
//                         document.getElementById('mappedtest.ClientID').style.display = "block";
//                         alert("cid " + cliquetestid + " ctest" + cliquetestname + " tid" + testid + " test " + testname);
//                        // grid.
//                         var row = grid.insertRow(1);
//                         var cell1 = row.insertCell(0);
//                         var cell2 = row.insertCell(1);
//                         var cell3 = row.insertCell(2);
//                         var cell4 = row.insertCell(3);
//                         cell1.innerHTML = cliquetestid;
//                         cell2.innerHTML = cliquetestname;
//                         cell3.innerHTML = testid;
//                         cell4.innerHTML = testname;
                        
                     }
                 
        
    </script>
</head>
<body>
    	<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" class="label">
				<TR>
					<TD><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
				<TR>
					<TD align="center"><font size="4"><STRONG>MAP CLIQ TESTS</STRONG></font></TD>
				</TR>
				<TR>
					<TD align="right">
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>
						&nbsp;</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD align="left">
                    
                    <table>
                    <tr>
                    <td>Cliq Tests
                     <asp:TextBox ID="txtCliqSearch"
 runat="server" CssClass="flattextbox" TabIndex="1" autocomplete="off" onkeyup="Javascript:filter(this,'dgExternal',2)"></asp:TextBox>  
                    </td>
                    <td>Internal Tests
                        <asp:TextBox ID="txtLocalTestSearch"
 runat="server" CssClass="flattextbox" autocomplete="off" TabIndex="2" onkeyup="Javascript:filter(this,'dgInternal',2)"></asp:TextBox>  
                    </td>
                    </tr>
                    <tr>
                    <td valign="top" width="50%">
                     <asp:Panel ID="Panel1" runat="server" Height="350px" Width="100%" BorderStyle="Double"
                                            BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                    <asp:DataGrid id="dgExternal" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							PageSize="25" AllowCustomPaging="True" CssClass="datagrid" BorderColor="Silver">

							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                            <asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center" Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" />
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="true" onclick="javascript:SelectCheckbox(this)" Runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn>
									
									<ItemTemplate>
										<asp:HiddenField ID="Cliquetestid" Value='<%# DataBinder.Eval(Container.DataItem, "TestID").ToString() %>' runat="server" />
										
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Test Name">
									<ItemTemplate>
										<asp:Label ID="CliqueTestname" text='<%#DataBinder.Eval(Container.DataItem, "TestName").ToString() %>' Visible="true" runat="server" ></asp:Label>
										<asp:HiddenField ID="HCliquetest" Value='<%#DataBinder.Eval(Container.DataItem, "TestName").ToString() %>' runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
                               
								<asp:BoundColumn Visible="false" DataField="methodId"></asp:BoundColumn>
								<asp:BoundColumn DataField="MethodName"  ReadOnly="True" HeaderText="Method">
									
								</asp:BoundColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
                        </asp:Panel>
                        </td>
                    <td valign="top" width="50%" style="overflow:auto; height="400px;">
                     <asp:Panel ID="Panel2" runat="server" Height="350px" Width="100%" BorderStyle="Double"
                                            BorderWidth="1px" BorderColor="graytext" ScrollBars="Auto">
                    <asp:DataGrid id="dgInternal" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							PageSize="25" AllowCustomPaging="True" CssClass="datagrid" BorderColor="Silver"  DataKeyField="clique_id"
                            onitemdatabound="dgInternal_ItemDataBound">

							<ItemStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" CssClass="gridItem"></ItemStyle>
							<HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader"></HeaderStyle>
							<Columns>
                            <asp:TemplateColumn SortExpression="Active" HeaderText="Active">
									<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
									<ItemTemplate>
										<asp:CheckBox ID="dgchkActive" Enabled="true" onclick="javascript:SelectCheckbox(this)" Runat="server">
										</asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn>
									
									<ItemTemplate>
										<asp:HiddenField ID="testid" Value='<%#DataBinder.Eval(Container.DataItem, "testid").ToString() %>' runat="server" />
										
									</ItemTemplate>
								</asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="Test Name">
									<ItemTemplate>
										<asp:Label ID="Testname" text='<%#DataBinder.Eval(Container.DataItem, "test").ToString() %>' Visible="true" runat="server" ></asp:Label>
										<asp:HiddenField ID="HtestName" Value='<%#DataBinder.Eval(Container.DataItem, "test").ToString() %>' runat="server" />
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="false" DataField="d_methodid"></asp:BoundColumn>
								<asp:BoundColumn DataField="method"  ReadOnly="True" HeaderText="Default Method">
									
								</asp:BoundColumn>
                               
                                <asp:BoundColumn Visible="false" DataField="clique_id"></asp:BoundColumn>
                                  <asp:TemplateColumn>
									<ItemTemplate>
										<asp:Button ID="btnAdd" Text="Add" runat="server" 
                                            OnClientClick="javascript:GenerateTable(this)" onclick="btnAdd_Click" />
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Font-Size="X-Small" Mode="NumericPages"></PagerStyle>
						</asp:DataGrid>
                        </asp:Panel>
                        </td>
                    <td>
                   <%-- <table id="mappedtest" runat="server" border="1" style="display:none;" >
                    <thead title="test id"></thead>
                    
                    <tbody>
                    <tr>
                    <td><strong>Clique TestID</strong></td><td><strong>Clique Test</strong></td><td><strong>Internal TestID</strong></td><td><strong>Test Name</strong></td>
                    </tr>
                    </tbody>
                    </table>--%>
                    </td>
                    </tr>
                    
                    </table>
						</TD>
				</TR>
				<TR>
					<TD>&nbsp;</TD>
				</TR>
				<TR>
					<TD class="screenid" align="right">HMS_LM_IN_001</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
</body>
</html>
