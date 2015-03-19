<%@ Page Title="Email" Language="C#"   AutoEventWireup="true" CodeFile="SentEmail.aspx.cs" Inherits="transaction_SentEmail" %>
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
                function ShowMenu(e, labid) {
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
<body>
<form id="form1" runat="server">
<div>

<h2 style="text-align:center;">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/mail.png"  />
        Send Email
    </h2>
    <hr />

           <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                ControlToValidate="TxBx_To" runat="server" 
                ErrorMessage="*To: You entered invalid Email ID <br />" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
  
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                ControlToValidate="TxBx_Cc" runat="server" 
                ErrorMessage="*CC: You entered invalid Email ID" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
--%>
            <asp:RequiredFieldValidator ControlToValidate="TxBx_Subject" ID="RequiredFieldValidator1" runat="server" ErrorMessage="<br />*Subject: You Can't Leave empty field"></asp:RequiredFieldValidator>
  <center>
             <table  width="auto" id="tb3" cellpadding="2"  runat="server" cellspacing="3" style="background-color: #EEEEEE; font-size: 11px; border: 1px inset blue;">

                                          <tr>
                                          <td colspan="2">
                                              <asp:Label ID="lblsent" runat="server" Font-Size="Large" Visible="false" ForeColor="ControlDarkDark"></asp:Label>
                                              <asp:Label ID="Lbl_Email" runat="server" Font-Bold="True" ForeColor="#33CC33"></asp:Label>
                                          </td>
                                          </tr>
                                          
                                          <tr>
                                          <td>
                                          To:
                                          </td>
                                          <td>
                                              <asp:TextBox CssClass="input_text" Enabled="true" ID="TxBx_To" runat="server" Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>
                                          
                                          <%--<tr>
                                          <td>
                                          Cc: 
                                          </td>
                                          <td>
                                               <asp:TextBox CssClass="input_text" ID="TxBx_Cc" runat="server" Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>--%>

                                          <tr>
                                          <td>
                                          Subject:
                                          </td>
                                          <td>
                                               <asp:TextBox CssClass="input_text" ID="TxBx_Subject" runat="server"
                                                   Width="550px"></asp:TextBox>
                                          </td>
                                          </tr>
                                          
                                          <%--<tr>
                                          <td colspan="2" style="font-size:xx-small;">
                                               Attachment: 
                                               <asp:Label ID="Attach_file" ForeColor="Blue" runat="server" Text="Attach_file"></asp:Label>
                                          </td>
                                          </tr>--%>
                                          
                                          <tr>
                                          <td>
                                              &nbsp;</td>
                                          <td>
                                               Attached File: <asp:LinkButton ID="Hyp_Email" CausesValidation="false" OnClick="HypEmail_Click"  runat="server" 
                                                   >PDF File</asp:LinkButton>
                                          </td>
                                          </tr>
                                          
                                          <tr>
                                          <td colspan="2">
                                                <asp:TextBox Text="" CssClass="input_text" Enabled="false" TextMode="MultiLine" Rows="8" Width="600px" ID="TxBx_Message" 
                                                    runat="server"></asp:TextBox>
                                          </td>
                                          </tr>

                                          <tr>
                                          <td colspan="2" align="right">
                                             <asp:ImageButton ID="Btn_ok" ImageUrl="~/images/email.jpg" runat="server" 
                                                  Height="25px" onclick="Btn_ok_Click" />
                                          </td>
                                          </tr>
                      </table>

</center>

</div>
</form>
</body>

