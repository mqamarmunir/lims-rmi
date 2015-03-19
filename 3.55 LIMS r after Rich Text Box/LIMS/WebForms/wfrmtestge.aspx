<%@ Reference Page="~/lims/reports/generalreports.aspx" %>

<%@ Page Language="c#" Inherits="HMIS.LIMS.WebForms.wfrmTestGE" CodeFile="~/LIMS/WebForms/wfrmTestGE.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>LIMS: Test Result Entry (General Format):
        <% =Session["UNUIDFORMATTED"] %></title>
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
    <meta content="C#" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="LIMS.css" rel="stylesheet">
    <script language="javascript">	
//   function replaceAll(str1, str2, ignore) 
//{
//	return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g,"\\$&"),(ignore?"gi":"g")),(typeof(str2)=="string")?str2.replace(/\$/g,"$$$$"):str2);
//}
    function chkmethod(btnid)
    {
    //alert(btnid);
    var ddlmethod=document.getElementById(btnid.substring(0,13)+'dgDDLMethod');
    //alert(ddlmethod);
    if(ddlmethod.options[ddlmethod.selectedIndex].value=='-1')
    {
    alert('Please select valid Method');
    return false;
    }
    else
    {
    return true;
    }
    
    }
        function repeatreason(ddlid)
        {
     //   alert(ddlid);
        var ddl=document.getElementById(ddlid);
        var commenttb=document.getElementById(ddlid.substring(0,13)+'dgtxtCommentET');
        commenttb.value='Test Repeat, Reason:'+ddl.options[ddl.selectedIndex].text.toString();
        //alert(commenttb);
        //alert(ddl.options[ddl.selectedIndex].text.toString());
        }
        	/////////////////////////////////////////////////////////////////////////////////////////////	
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
function filter(term,testctl,attributectl) {
       
        var id="dgTest_ctl0"+testctl.toString()+"_dgAttribute_ctl0"+attributectl.toString()+"_dgAttributeResult";
        var txtid=document.getElementById(id);
        txtid.value="";
        txtid.value=term.toFixed(2);
        
        
     

    }

			
			function SetComment(comment)
			{
				document.all("<% =SelectedComment %>").value = comment.replace(/<br>/g,'\r\n');
			}
			
		function GetValue(name)
        {

            
            var label = document.getElementById(name);
            var Text = label.options[label.selectedIndex].text; 
            var Value = label.options[label.selectedIndex].value;
           
             var processid = "<%=Session["processid"]%>";           

             if(parseInt(Value) < parseInt(processid))
             {
                var answer = confirm ("Are you sure to send this test to "+Text+"?")
                if (answer)
                return true;
                else
                return false;             
             }
 
             
               
        }
        function chkValue(term,_id,cellNr,_myid) 
        {
            var hiddenfield=document.getElementById("hdPref");
            var suche = term.value.toLowerCase();
             var myid=_myid.toString();
             var _ctlnumber=myid.substr(10,2);
             var range_min;
             var range_max;
             var upper;
             var lower;
         
        // alert(_ctlnumber);
           
            ///////////////////////////////////////////////////////////////////////////////////////////
            //var table = document.getElementById("dgTest__ctl2_dgAttribute");
           var id="dgTest_ctl"+_ctlnumber+"_dgAttribute";
           //alert(id);
           var table=document.getElementById(id);
            var rownumber=myid.substr(28,2);
            var range=table.rows[rownumber-1].cells[5].innerHTML.toString();
         //   alert(range);
          
           if(range.indexOf("&gt;")>=0)
           {
           //alert('< is called');
          range_min=range.substring(range.indexOf("&gt;")+4);
           //alert(range_min);
           if(range_min.indexOf('-')>0)
           {
           //alert('- called');
           range_min=range_min.replace('-','');
           }
//           else if(range_max.indexOf('-')>0)
//           {
//           alert('I Am called');
//           range_min=range_min.replace('-','');
//           }
          // alert(range_min);
            lower=parseFloat(range_min)-(parseFloat(range_min)*parseFloat(hiddenfield.value)/100);
           //alert(lower);
           if (parseFloat(suche) < parseFloat(lower)) 
            {
                 document.getElementById(_myid).style.color="red";
           //  alert("That must be a typo mistake. Please re-enter");
             //   alert(_myid);
            }
            else
            {
            document.getElementById(_myid).style.color="black";
            }
           }
           
           
           else if(range.indexOf("&lt;")>=0)
           {
       //    alert("< is called " +range_max);
           range_max=range.substring(range.indexOf("&lt;")+4);
           if(range_max.indexOf("--")>0)
           {
           range_max=range_max.replace("--","");
           }
           else if(range_max.indexOf('-')>0)
           {range_max=range_max.replace('-','');
           }
           //alert(range_max);
           upper=parseFloat(range_max)+(parseFloat(range_max)*parseFloat(hiddenfield.value)/100);
           //alert(upper);
           if (parseFloat(suche) > parseFloat(upper)) 
            {
                 document.getElementById(_myid).style.color="red";
               //  alert("That must be a typo mistake. Please re-enter");
             //   alert(_myid);
            }
            else
            {
            document.getElementById(_myid).style.color="black";
            }
           }
          else
          {
            range_min=range.substring(0,range.indexOf("-"));
            range_max=range.substring(range.indexOf("-")+1);
           
            upper=parseFloat(range_max)+(parseFloat(range_max)*parseFloat(hiddenfield.value)/100);
            lower=parseFloat(range_min)-(parseFloat(range_min)*parseFloat(hiddenfield.value)/100);
            
           }
            if (parseFloat(suche) < parseFloat(lower) || parseFloat(suche) > parseFloat(upper)) 
            {
                 document.getElementById(_myid).style.color="red";
               //  alert("That must be a typo mistake. Please re-enter");
             //   alert(_myid);
            }
            else
            {
            document.getElementById(_myid).style.color="black";
            }
        ////////////////////////////////////////////////////////////////////////////////////////////////
    
        }
        function chkForward(term, _id) {
    var e = document.getElementById(_id);
    //alert(e);
    if (e.options[e.selectedIndex].text == 'Result Entry' || e.options[e.selectedIndex].text == 'Specimen') {
        var x=confirm("Are You sure you want to send this result back to "+e.options[e.selectedIndex].text+"?");
        if(x==true)
        {
       // alert(x);
        e.options[e.selectedIndex].selected=true;
        }
        else
        {
        //alert(x);
        e.options[2].selected=true;
        }
    } 
}

function diffcalc(_val,_gridid,_myid)
{
//alert(_val);
//alert(_gridid);
//alert(_myid);
var testgridrownum=_myid.toString().substr(10,2);
var attribgridrownum=_myid.toString().substr(28,2);
var txtboxid=document.getElementById("dgTest_ctl"+testgridrownum+"_txtDiffCalc");
var gridid=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute");
var attribgridrownumber=parseInt(attribgridrownum);

if(!isNaN(parseFloat(_val.value)) && gridid.rows[attribgridrownumber-1].cells[4].innerHTML.indexOf('%')==0)
{
calcmeanvalue(gridid.rows[attribgridrownumber-1].cells[1].innerHTML,gridid,testgridrownum,parseFloat(_val.value)); // Function for caclulating mean value of this absolute valued attribute.  Arguments(1-Name of the Attribute,2-Reference of gvAttributegrid., 3-dgTest Rownumber.,4-Absolute value)
}
if(gridid.rows[attribgridrownumber-1].cells[1].innerHTML=="WBC")
{
//alert('abc');
calcwbccorrected(_val.value,testgridrownum,gridid)
}


//txtboxid.value=attribgridrownum;
var sum=0;
var resultiadd;
for(var i=2;i<=gridid.rows.length;i++)
{
    if(parseFloat(i)<10)
    {
        resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl0"+i+"_dgAttributeResult");
    }
    else
    {
        resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl"+i+"_dgAttributeResult");
    }
    if(!isNaN(parseFloat(resultiadd.value)) && gridid.rows[i-1].cells[4].innerHTML.indexOf('%')==0)/* 1-Counting all the numeric results. 2-Checking whther the atribute is of count type. */
    {
        //calcmeanvalue(gridid.rows[i-1].cells[1].innerHTML.toString(),gridid,testgridrownum,parseFloat(resultiadd.value)); // Function for caclulating mean value of this absolute valued attribute.  Arguments(1-Name of the Attribute,2-Reference of gvAttributegrid., 3-dgTest Rownumber.,4-Absolute value)
        sum=parseFloat(sum)+parseFloat(resultiadd.value);
    }
  
}
txtboxid.value=sum.toFixed(2);
if(parseFloat(txtboxid.value)>100 && gridid.rows[attribgridrownumber-1].cells[4].innerHTML.indexOf('%')>=0)
{
alert('Sum has exceeded the limit');
}
else if(parseFloat(txtboxid.value)==100 && gridid.rows[attribgridrownumber-1].cells[4].innerHTML.indexOf('%')>=0) 
{
alert('Attributes sum equal to hundred');
}

}

function calcwbccorrected(wbcvalue,testgridrownum,gridid)
{
//alert(testgridrownum);
var wbccorrectedtextbox=document.getElementById("dgTest_ctl"+testgridrownum+"_txtWBCCorrect");
//alert(wbccorrectedtextbox);
var resultiadd="";
var count=0;

var wbccorrected=0;
for(var i=2;i<=gridid.rows.length;i++)
{
    if(gridid.rows[i-1].cells[1].innerHTML=="Nucleated RBCs")
    {
        if(parseFloat(i)<10)
        {
            resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl0"+i+"_dgAttributeResult");
        }
        else
        {
            resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl"+i+"_dgAttributeResult");
        }
        if(!isNaN(parseFloat(resultiadd.value)))/* 1-Whether NRBC is there or is empty*/
        {
            wbccorrected=(wbcvalue/((parseFloat(resultiadd.value))+100))*100;
        }
        else
        {
            wbccorrected=wbcvalue;
        }
    }
    else
    {
        count++;
    }

}
//alert(count);
//alert(gridid.rows.length);
if(count==gridid.rows.length)
{
//alert(wbcvalue);
wbccorrected=wbcvalue;
//alert(wbccorrected);
//wbccorrectedtextbox.value=wbcvalue;
}
else
{
wbccorrectedtextbox.value=parseFloat(wbccorrected).toFixed(2);
}
//alert(parseFloat(wbccorrected).toFixed(2));
//wbccorrectedtextbox.setAttribute("text",parseFloat(wbccorrected).toFixed(2));
//wbccorrectedtextbox.value=parseFloat(wbccorrected).toFixed(2);
//alert(wbccorrectedtextbox.value);

//alert(testgirdrownum);
}

function calcmeanvalue(attribute,gridid,testgridrownum,absolutevalue)
{
//alert(attribute)
var foundatrownumber=0;
var resultiadd="";
var wbccorrectedtextbox=document.getElementById("dgTest_ctl"+testgridrownum+"_txtWBCCorrect");

    for(var i=2;i<=gridid.rows.length;i++)
    {
        if((attribute.indexOf(gridid.rows[i-1].cells[1].innerHTML)>=0 || gridid.rows[i-1].cells[1].innerHTML.indexOf(attribute)>=0) && gridid.rows[i-1].cells[4].innerHTML.indexOf('X10^')>=0)
        {
        foundatrownumber=i;
        //break;
        //alert(foundatrownumber);
        //break;
        }
    }
    if(foundatrownumber!=0 && parseInt(foundatrownumber)<10)
    {
    resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl0"+foundatrownumber+"_dgAttributeResult");
    }
    else if(foundatrownumber!=0 && parseInt(foundatrownumber)>=10)
    {
    resultiadd=document.getElementById("dgTest_ctl"+testgridrownum+"_dgAttribute_ctl"+foundatrownumber+"_dgAttributeResult");
    }
    else if(foundatrownumber==0)
    {
   // alert('attribute not found');
    }

    resultiadd.value=((absolutevalue*parseFloat(wbccorrectedtextbox.value))/100).toFixed(2);
}
    </script>
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
</head>
<body leftmargin="20">
    <form id="Form1" method="post" runat="server">
    <table class="label" id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td colspan="6">
                <!-- #include file="LimsHeader2.htm"-->
                <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="6">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <font size="4"><u>
                    <asp:Label ID="lblHeading" runat="server" Width="100%">Label</asp:Label></u></font>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td width="5%">
            </td>
            <td width="10%">
                Rec-ID:
            </td>
            <td width="30%">
                <asp:Label ID="lblLabID" runat="server" Width="100%" Font-Bold="True">Label</asp:Label>
            </td>
            <td width="10%">
                Priority:
            </td>
            <td width="40%">
                <asp:Label ID="lblPriority" runat="server" Width="100%" Font-Bold="True">Label</asp:Label>
            </td>
            <td width="5%">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td width="10%">
                Name:
            </td>
            <td width="30%">
                <asp:Label ID="lblName" runat="server" Width="100%" Font-Bold="True">Label</asp:Label>
            </td>
            <td width="10%">
                Type:
            </td>
            <td width="40%">
                <asp:Label ID="lblType" runat="server" Font-Bold="True" Width="100%">Label</asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td width="5%" style="height: 14px">
            </td>
            <td width="10%" style="height: 14px">
                Sex/Age:&nbsp;&nbsp;
            </td>
            <td width="30%" style="height: 14px">
                <asp:Label ID="lblAgeSex" runat="server" Width="100%" Font-Bold="True">Label</asp:Label>
            </td>
            <td width="10%" style="height: 14px">
                Ward:
            </td>
            <td width="40%" style="height: 14px">
                <asp:Label ID="lblWard" runat="server" Font-Bold="True" Width="100%">Label</asp:Label>
            </td>
            <td width="5%" style="height: 14px">
            </td>
        </tr>
        <tr>
            <td width="5%" style="height: 14px">
            </td>
            <td width="10%" style="height: 14px">
                PR No:
            </td>
            <td width="30%" style="height: 14px">
                <asp:Label ID="lblPRNo" runat="server" Width="100%" Font-Bold="True">Label</asp:Label>
            </td>
            <td width="10%" style="height: 14px">
                Referred By:
            </td>
            <td width="40%" style="height: 14px">
                <asp:Label ID="lblRefDoctor" Visible="true" runat="server" Font-Bold="True" Width="45%">Label</asp:Label>
                <asp:TextBox ID="txtRefDoctor" Visible="false" runat="server" CssClass="field" Width="50%"></asp:TextBox>
            </td>
            <td width="5%" style="height: 14px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblMSerialNo" runat="server" Width="100%" Font-Bold="True" Visible="false">Label</asp:Label>
            </td>
            <td>
            </td>
            <td align="center" colspan="3">
                <asp:HiddenField ID="hdPref" runat="server" />
                <input type="hidden" id="hdfield" />
                <asp:ImageButton ID="ibtnNextPatient" runat="server" ImageUrl="Images/btn_Next.gif">
                </asp:ImageButton><asp:ImageButton ID="ibtnResultByPRNo" runat="server" ImageUrl="Images/btn_ResultByPRNo.gif"
                    OnClick="ibtnResultByPRNo_Click"></asp:ImageButton>
                <asp:ImageButton ID="ibtnViewOtherResult" runat="server" ImageUrl="Images/btn_ViewResult.gif"
                    OnClick="ibtnViewOtherResult_Click" />&nbsp;<asp:ImageButton ID="ibtnPatientTestStatus"
                        runat="server" ImageUrl="Images/btn_Detail.gif" 
                    ></asp:ImageButton>
                &nbsp; &nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Images/btn_Close.gif"
                    OnClick="ImageButton2_Click1"></asp:ImageButton>
            </td>
        </tr>
        <tr>
            <td colspan="6" valign="top">
                <asp:DataGrid ID="dgTest" runat="server" Width="100%" AutoGenerateColumns="False"
                    AllowSorting="True" BorderColor="Gainsboro" OnItemDataBound="dgTest_ItemDataBound"
                    CellPadding="0" GridLines="Horizontal" CssClass="datagrid">
                    <SelectedItemStyle Font-Size="X-Small" CssClass="gridSelectedItem"></SelectedItemStyle>
                    <AlternatingItemStyle Font-Size="X-Small" CssClass="gridheader"></AlternatingItemStyle>
                    <ItemStyle Font-Size="X-Small" CssClass="gridheader"></ItemStyle>
                    <HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader">
                    </HeaderStyle>
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderStyle Width="5%"></HeaderStyle>
                            <ItemTemplate>
                                <img id="image_" height="16" src="images/expand.gif" width="16" runat="server">
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="False" DataField="DSerialNo" ReadOnly="True" HeaderText="DSerialNo">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="TestID" ReadOnly="True" HeaderText="TestID">
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="TestNo" HeaderText="Dept No.">
                            <HeaderStyle Width="5%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Test" HeaderText="Test">
                            <HeaderStyle Width="50%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Acronym" HeaderText="Acronym">
                            <HeaderStyle Width="15%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="DeliveryDate" HeaderText="Delivery Date">
                            <HeaderStyle Width="20%"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <tr>
                                    <td class="label" style="height: auto" colspan="5">
                                        Method:
                                        <asp:DropDownList ID="dgDDLMethod" Width="20%" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlMethod_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblDiffCalc" runat="server" Text="Diffrential Calculator:" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtDiffCalc" runat="server" Visible="false" CssClass="field" Enabled="True"
                                            Font-Bold="True" Font-Names="Franklin Gothic Demi Cond" Height="40px"></asp:TextBox>
                                        <asp:Label ID="lblWBCCorrect" runat="server" Text="WBC(Corrected):" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtWBCCorrect" runat="server" Visible="false" CssClass="field" Enabled="False"
                                            Font-Bold="True" Font-Names="Franklin Gothic Demi Cond"></asp:TextBox>
                                    </td>
                                    <td align="right">
                                        <asp:ImageButton ID="ibtnSOP" ToolTip="SOPs" runat="server" ImageUrl="images\Btn_SOP.png"
                                            OnCommand="ibtn_SOPClick" CommandArgument="<%#Container.DataSetIndex%>" />
                                        <asp:ImageButton ID="imghistory" runat="server" Visible='<%#(DataBinder.Eval(Container.DataItem, "historyTaking").ToString() == "Y")%>' CommandArgument="<%#Container.DataSetIndex%>"
                                            ImageUrl="~/images/history2.png" ToolTip="History" OnCommand="imghistory_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table cellspacing="0" cellpadding="0" width="100%" class="label" border="0">
                                            <tr>
                                                <td align="right">
                                                    <div id="divOrders" style="display: inline" runat="server">
                                                        <asp:DataGrid ID="dgAttribute" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            OnItemDataBound="dgAttribute_ItemDataBound" BorderStyle="None">
                                                            <SelectedItemStyle Font-Size="X-Small" CssClass="gridItem"></SelectedItemStyle>
                                                            <AlternatingItemStyle Font-Size="X-Small" CssClass="gridAlternate"></AlternatingItemStyle>
                                                            <ItemStyle Font-Size="X-Small" CssClass="gridAlternate"></ItemStyle>
                                                            <HeaderStyle Font-Size="X-Small" Font-Bold="True" ForeColor="Black" CssClass="gridheader">
                                                            </HeaderStyle>
                                                            <Columns>
                                                                <asp:BoundColumn Visible="False" DataField="AttributeID" SortExpression="AttributeID"
                                                                    ReadOnly="True" HeaderText="AttributeID"></asp:BoundColumn>
                                                                <asp:TemplateColumn HeaderText="PRN">
                                                                    <HeaderStyle Width="5%"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        &nbsp;
                                                                        <asp:CheckBox ID="chkRPrint" runat="server" Text=" " Checked='<%#(DataBinder.Eval(Container.DataItem, "RPrint").ToString() == "Y")%>'
                                                                            Enabled="True"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="Attribute" SortExpression="Attribute" ReadOnly="True"
                                                                    HeaderText="Attribute">
                                                                    <HeaderStyle Width="15%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:TemplateColumn HeaderText="Result">
                                                                    <HeaderStyle Width="40%"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <p>
                                                                            <%-- <input type="text" id="dgAttributeResult_{dgAttributeResult_:rowNumber}" onchange="chkValue(this,dgTest__ctl2_dgAttribute,5,this.id)" name="{dgAttribute_Result}" />--%>
                                                                            <asp:TextBox ID="dgAttributeResult" runat="server" Width="100%" CssClass='flattextbox'
                                                                                Text='<%# DataBinder.Eval(Container.DataItem, "Result")  %>' MaxLength="100"
                                                                                Rows='<%# int.Parse(DataBinder.Eval(Container.DataItem, "SMLine").ToString()) %>'
                                                                                Height="100%" TextMode='<%# GetTextmode((string)DataBinder.Eval(Container.DataItem, "SMLine")) %>'
                                                                                onchange="javascript:chkValue(this,'dgAttribute',0,this.id);" onkeyup="javascript:diffcalc(this,'dgAttribute',this.id);"></asp:TextBox>
                                                                            <br />
                                                                            <%--<asp:LinkButton ID="lnkbtnCalcDerived" Text="Calculate" Visible="false" OnClick="lnkbtnCalculate_Click" runat="server"></asp:LinkButton>--%>
                                                                            <asp:ListBox ID="lbSelection" runat="server" Width="100%" AutoPostBack="True" Visible="False"
                                                                                OnSelectedIndexChanged="lbSelection_SelectedIndexChanged"></asp:ListBox>
                                                                        </p>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:TemplateColumn>
                                                                    <HeaderStyle Width="2px"></HeaderStyle>
                                                                    <ItemStyle Width="10%" />
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ibtnSelection" runat="server" ImageUrl="images\btn_Piclist.gif"
                                                                            OnClick="ibtnSelection_Click" Visible='<%#(DataBinder.Eval(Container.DataItem, "InputType").ToString() == "1")%>'>
                                                                        </asp:ImageButton>
                                                                        <asp:ImageButton ID="ibtnFormula" Visible="false" OnClick="ibtnFormula_Click" runat="server"
                                                                            ImageUrl="images\btn_GFR.gif"></asp:ImageButton>
                                                                        <asp:LinkButton ID="lnkbtnCalcDerived" Text="Calc" Visible="false" OnClick="lnkbtnCalculate_Click"
                                                                            runat="server"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:BoundColumn DataField="RUnit" SortExpression="RUnit" HeaderText="Unit">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="MinRange" SortExpression="MinRange" HeaderText="Min">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="MaxRange" SortExpression="MaxRange" ReadOnly="True"
                                                                    HeaderText="Max">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn DataField="Range" SortExpression="Range" HeaderText="Range">
                                                                    <HeaderStyle Width="15%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="MinPValue" SortExpression="MinPValue"
                                                                    ReadOnly="True" HeaderText="MaxPV">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="MaxPValue" SortExpression="MaxPValue"
                                                                    ReadOnly="True" HeaderText="MinPV">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="AttributeType" SortExpression="AttributeType"
                                                                    ReadOnly="True" HeaderText="Attribute Type">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="Derived" SortExpression="Derived" ReadOnly="True"
                                                                    HeaderText="Derived">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn Visible="False" DataField="Acronym" SortExpression="Acronym" ReadOnly="True"
                                                                    HeaderText="Acronym">
                                                                    <HeaderStyle Width="10%"></HeaderStyle>
                                                                </asp:BoundColumn>
                                                                <asp:BoundColumn HeaderText="Analyzer Result" DataField="MachineResult" Visible="False"></asp:BoundColumn>
                                                            </Columns>
                                                            <PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
                                                        </asp:DataGrid>
                                                        <table id="tbOpinion" width="100%" bgcolor="#edf0f8">
                                                            <tr>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="25%">
                                                                </td>
                                                                <td width="20">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="5%">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label1" runat="server" Font-Size="X-Small">Forward to:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="dgddlForwardtoIT" runat="server" Width="100%" DataSource='<%# FillDDLForwardTo(DataBinder.Eval(Container.DataItem, "ProcedureID").ToString()) %>'
                                                                        DataTextField="Process" DataValueField="ProcessID" SelectedIndex='<%# GetForwardIndex((string)DataBinder.Eval(Container.DataItem, "ProcessID")) %>'
                                                                        Enabled="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkRepeat" Text="Repeat Test" Font-Size="X-Small" OnCheckedChanged="chkReport_CheckedChanged"
                                                                        AutoPostBack="true" runat="server" />
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblReasons" runat="server" Text="Reasons" Visible="false" Font-Size="X-Small"></asp:Label>
                                                                    <asp:DropDownList ID="ddlRepeatReasons" Width="70%" Visible="false" onchange="javascript:repeatreason(this.id)"
                                                                        runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label2" runat="server" Font-Size="X-Small">Opinion:</asp:Label>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:TextBox ID="dgtxtOpinionET" runat="server" Width="100%" TextMode="MultiLine"
                                                                        Height="45px" MaxLength="255" Rows="3" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>'
                                                                        CssClass="flattextbox">
                                                                    </asp:TextBox>
                                                                    <%--<CKEditor:CKEditorControl ID="dgtxtOpinionET" runat="server" 
                        Toolbar="Basic" ResizeMinHeight="50" ResizeMinWidth="50" 
                            ToolbarStartupExpanded="true" EnterMode="BR" ShiftEnterMode="BR" 
                            Height="50px" Enabled="true"
                            ToolbarBasic="Source|-|Bold|Italic" MaxLength="1000" Text='<%# DataBinder.Eval(Container.DataItem, "Opinions")  %>'></CKEditor:CKEditorControl>--%>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="ibtnOpinion" OnClick="ibtnOpinion_Click" runat="server" ImageUrl="images\btn_Piclist.gif">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" Font-Size="X-Small">Comment:</asp:Label>
                                                                </td>
                                                                <td colspan="4">
                                                                    <br />
                                                                    <asp:TextBox ID="dgtxtCommentET" runat="server" Width="50%" Visible="true" TextMode="MultiLine"
                                                                        Height="45px" MaxLength="255" Rows="3" Text='<%# DataBinder.Eval(Container.DataItem, "Comments")  %>'
                                                                        CssClass="flattextbox">
                                                                    </asp:TextBox>
                                                                    <asp:LinkButton ID="lnksavecomment" runat="server" CommandName="save" Text="save"
                                                                        Font-Size="X-Small" Visible="true" OnCommand="lnkbtnsavecomment_Click"></asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                    <asp:ImageButton ID="ibtnComment" OnClick="ibtnComment_Click" runat="server" ImageUrl="images\btn_Piclist.gif">
                                                                    </asp:ImageButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td colspan="4">
                                                                    <asp:GridView ID="gvComments" Width="100%" CssClass="datagrid" DataKeyNames="TestResultCommentID"
                                                                        AutoGenerateColumns="false" OnRowDeleting="gvComments_RowDeleting_Click" runat="server">
                                                                        <HeaderStyle CssClass="gridheader" />
                                                                        <RowStyle CssClass="gridItem" />
                                                                        <AlternatingRowStyle CssClass="gridAlternate" />
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Comments" DataField="Comments" />
                                                                            <asp:BoundField HeaderText="EnteredBy" DataField="Name" />
                                                                            <asp:CommandField DeleteImageUrl="~/images/remove.png" ButtonType="Image" ShowDeleteButton="True">
                                                                                <ItemStyle Width="7%" />
                                                                            </asp:CommandField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:LinkButton ID="lnkbtnEval" runat="server" Text="Add Evaluation" Font-Size="X-Small"
                                                                        OnClick="lnkbtnEval_Click" Visible="false"></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6" style="background-color: Window">
                                                                    <asp:LinkButton ID="lnkbtnDiagnosis" Text="Peer Review" Font-Size="X-Small" runat="server"
                                                                        OnClick="lnkbtnPeerReview_Click" Visible="false"></asp:LinkButton>
                                                                    <asp:ImageButton ID="gvimgReviewComments" ImageUrl="~/images/a-unread.png" OnClick="gvimgReviewComments_Click"
                                                                        Visible="false" ToolTip="Peer Comments about the Result" runat="server" />
                                                                    <asp:ModalPopupExtender ID="gvimgReviewComments_ModalPopupExtender" runat="server"
                                                                        PopupControlID="pnlComments" DynamicServicePath="" Enabled="True" TargetControlID="gvimgReviewComments">
                                                                    </asp:ModalPopupExtender>
                                                                    <asp:Panel ID="pnlComments" Visible="false" runat="server" Width="400px">
                                                                        <table id="tblcomments" style="background-color: Aqua" class="label" width="99%">
                                                                            <tr>
                                                                                <td width="99%" align="right">
                                                                                    <asp:LinkButton ID="lnkclose" Text="[X]close" OnClick="lnkClose_Click" runat="server"></asp:LinkButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="99%">
                                                                                    <asp:GridView ID="gvPeerReviews" CssClass="datagrid" runat="server" AutoGenerateColumns="false"
                                                                                        Width="99%">
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
                                                                            <td width="10%">
                                                                                <asp:Label ID="Label5" runat="server" Font-Size="X-Small">Pathologist:</asp:Label>
                                                                            </td>
                                                                            <td width="25%">
                                                                                <asp:DropDownList ID="DDLPathologist" runat="server" CssClass="field" Width="100%"
                                                                                    Visible="true">
                                                                                </asp:DropDownList>
                                                                                <asp:ListSearchExtender ID="DDLPathologist_ListSearchExtender" runat="server" Enabled="True"
                                                                                    TargetControlID="DDLPathologist">
                                                                                </asp:ListSearchExtender>
                                                                            </td>
                                                                            <td>
                                                                                <%--<asp:Label ID="Label6" Font-Size="X-Small" runat="server">Code:</asp:Label>--%>
                                                                                <%--<asp:DropDownList ID="DDLdiseasecode" runat="server" CssClass="field"  
                                                                                DataSource='<%#FillDDLPathologists()%>' DataTextField="DiseaseCode" 
                                                                                DataValueField="DiseaseID" AutoPostBack="true" 
                                                                                OnSelectedIndexChanged="ddlDiseasecode_SelectedIndexchanged" Visible="False"></asp:DropDownList>--%>
                                                                                <%-- <asp:CheckBox ID="chkPrint" Text="Print" Font-Size="X-Small" runat="server" 
                                                                                Visible="False" />--%>
                                                                                <%-- <asp:Button ID="ibtnsearch" onclick="ibtnsearch_Click" runat="server" Text="Search" 
                                                                                CssClass="buttonStyle" BackColor="HighLight" Visible="False"></asp:Button>--%>
                                                                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" CssClass="buttonStyle"
                                                                                    Text="Refer" BackColor="Highlight" Visible="true" />
                                                                                <%-- </ContentTemplate>
                                                                         <Triggers>
                                                                         <asp:AsyncPostBackTrigger ControlID="DDLdiseasename" EventName="SelectedIndexChanged" />
                                                                         </Triggers>
                                                                       </asp:UpdatePanel>--%>
                                                                                <%-- <input type="text" class="flattextbox" onchange="chkValue(this,'dgtest',0)" />--%>
                                                                            </td>
                                                                            <td width="10%">
                                                                            </td>
                                                                            <td width="10%" align="right">
                                                                            </td>
                                                                            <td width="5%">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
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

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:FileUpload ID="FileUploadControl1" runat="server" />
                                                                    <%-- <asp:Button runat="server" id="UploadButton1" text="Upload" Visible="false" onclick="UploadButton1_Click" /> --%>
                                                                    <asp:Label runat="server" ID="StatusLabel1" Text="Upload status: " Visible="false"
                                                                        Font-Size="X-Small" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:FileUpload ID="FileUploadControl2" runat="server" />
                                                                    <%-- <asp:Button runat="server" id="UploadButton2" text="Upload" Visible="false" onclick="UploadButton2_Click" />--%>
                                                                    <asp:Label runat="server" ID="StatusLabel2" Text="Upload status: " Visible="false"
                                                                        Font-Size="X-Small" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="6">
                                                                    <asp:FileUpload ID="FileUploadControl3" Visible="false" runat="server" />
                                                                    <%-- <asp:Button runat="server" id="UploadButton3" text="Upload" Visible="false" onclick="UploadButton3_Click" />--%>
                                                                    <asp:Label runat="server" ID="StatusLabel3" Text="Upload status: " Visible="false"
                                                                        Font-Size="X-Small" />
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
                                                            <tr>
                                                                <td width="10%">
                                                                </td>
                                                                <td width="25%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="20%">
                                                                </td>
                                                                <td width="20%" align="right">
                                                                    <asp:ImageButton ID="ibtnHold" runat="server" ImageUrl="Images/btn_Hold.gif"></asp:ImageButton>
                                                                    <asp:ImageButton ID="ibtnSave" runat="server" ImageUrl="images/btn_Save.gif" OnClientClick="return chkmethod(this.id);" OnClick="ibtnSave_Click">
                                                                    </asp:ImageButton>
                                                                </td>
                                                                <td width="5%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn DataField="Preferred" HeaderText="Preferred" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="Attribute_Count" Visible="False"></asp:BoundColumn>
                        <asp:BoundColumn DataField="D_Methodid" Visible="False"></asp:BoundColumn>
                    </Columns>
                    <PagerStyle Font-Size="X-Small" PageButtonCount="2" Mode="NumericPages"></PagerStyle>
                </asp:DataGrid>
            </td>
        </tr>
        <tr>
            <td colspan="7">
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
            <td colspan="2">
            </td>
            <td colspan="4" valign="top">
                <asp:LinkButton ID="lbtntest" runat="server"></asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
