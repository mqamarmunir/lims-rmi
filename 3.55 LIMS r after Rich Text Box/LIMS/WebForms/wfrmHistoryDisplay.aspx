<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wfrmHistoryDisplay.aspx.cs" Inherits="LIMS_WebForms_wfrmHistoryDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LIMS: History:    <% =Session["UNUIDFORMATTED"] %></title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="LIMS.css" rel="stylesheet">
    <style type="text/css">
        .style1
        {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="label" id="TBLhead" style="Z-INDEX: 101; LEFT: 1px; POSITION: relative; TOP: 1px"
				cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD colSpan="6"><!-- #include file="LimsHeader2.htm"--></TD>
				</TR>
                <TR>
					<TD align="center" colSpan="6"><font size="4"><STRONG>HISTORY</STRONG></font>
                    <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>
         
                        <asp:HiddenField ID="hdHistoryTakingID_A" runat="server" />
                    </TD>
				</TR>
                <tr>
                <td colspan="6" align="right">
               <asp:ImageButton ID="lbtnSave" runat="server" AccessKey="s" ImageUrl="~/images/SavePack_2.gif"
                            OnClick="lbtnSave_Click" TabIndex="23" ToolTip="Press To Save (Alt+S)" />
                
                <asp:ImageButton ID="lbtnClearAll" runat="server" AccessKey="c" ImageUrl="~/images/ClearPack.gif"
                                OnClick="lbtnClearAll_Click" TabIndex="24" ToolTip="Press To Clear (Alt+C)" />
                <asp:ImageButton ID="btnClose" runat="server" AccessKey="x" ImageUrl="~/images/ClosePack.gif"
                                    OnClick="btnClose_Click" TabIndex="26" ToolTip="Close Screen  (Alt+X)" />
                </td>
             
                </tr>
                <tr>
                <td colspan="7">
                <asp:Label ID="lblErrMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
                </td>
               
                </tr>
    </table>
    <fieldset>
    <legend>Present History:</legend>
    <fieldset>
    <legend>Patient General:</legend>
  
    <table id="tblPatientGenreal" class="label" width="99%">
    <tr>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td align="right">Lab ID:</td>
    <td colspan="2"><asp:Label ID="lblLabID" runat="server" Font-Underline="True" 
            Font-Bold="True" Font-Size="Small"></asp:Label>
    </td>
    
    </tr>
     <tr> 
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td align="right">PR No:</td>
    <td colspan="2"><asp:Label ID="lblPRno" runat="server" Font-Underline="True" 
            Font-Bold="True" Font-Size="Small"></asp:Label>
    </td>
    
    </tr>
     <tr>
    <td align="right">Name: </td>
    <td colspan="2"><asp:Label ID="lblName" runat="server" Font-Bold="true"></asp:Label></td>

    <td align="right">Age/Sex:

    </td>
    <td>
    <asp:Label ID="lblAge" runat="server" Font-Bold="true"></asp:Label>
         /<asp:Label ID="lblSex" runat="server" Font-Bold="true"></asp:Label>
         </td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right">
    Address:
    </td>
    <td colspan="2">
        <asp:Label ID="lblAddress" runat="server" Font-Bold="true"></asp:Label>
    
    </td>

    <td align="right">Contact No:</td>
    <td>
        <asp:Label ID="lblContactNo" runat="server" Font-Bold="true"></asp:Label>
    </td>
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
        <tr>
    <td align="right">Present History:</td>
    <td colspan="3">
        <asp:TextBox ID="txtPresenthistory" runat="server" 
        CssClass="field" TextMode="MultiLine" Width="98%">
        </asp:TextBox>
    </td>
    
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
    <td align="right">Past History:</td>
   <td colspan="3">
        <asp:TextBox ID="txtPasthistory" runat="server" 
        CssClass="field" TextMode="MultiLine" Width="98%">
        </asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right">Transfusion History:</td>
     <td colspan="3">
        <asp:TextBox ID="txtTransfusionhistory" runat="server" 
        CssClass="field" TextMode="MultiLine" Width="98%">
        </asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right">Family History:</td>
     <td colspan="3">
        <asp:TextBox ID="txtFamilyhistory" runat="server" 
        CssClass="field" TextMode="MultiLine" Width="98%">
        </asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right"></td>
    <td style="font-weight: 700" class="style1">Complaints:</td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    <td></td>
    </tr>

     <tr>
    <td align="right"></td>
    <td align="right">Present Hx:</td>
    <td colspan="2">
        <asp:TextBox ID="txtComplaintsPresent" runat="server" CssClass="field" Width="98%" TextMode="SingleLine"></asp:TextBox>
    </td>

    <td></td>
    <td></td>
    <td></td>
    </tr>

     <tr>
    <td align="right"></td>
    <td align="right">Past Hx:</td>
  <td colspan="2">
        <asp:TextBox ID="txtComplaintsPast" runat="server" CssClass="field" Width="98%" TextMode="SingleLine"></asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right"></td>
    <td align="right">Transfusion Hx:</td>
  <td colspan="2">
        <asp:TextBox ID="txtComplaintsTrans" runat="server" CssClass="field" Width="98%" TextMode="SingleLine"></asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td align="right"></td>
    <td align="right">Family Hx:</td>
   <td colspan="2">
        <asp:TextBox ID="txtComplaintsFamily" runat="server" CssClass="field" Width="98%" TextMode="SingleLine"></asp:TextBox>
    </td>
    <td></td>
    <td></td>
    <td></td>
    </tr>
    <tr>
    <td></td>
    <td align="right">
        Any Treatment Taken:
    </td>
    <td colspan="2">
        
        
        <asp:TextBox ID="txttreatment" runat="server" 
        CssClass="field" TextMode="MultiLine" Width="98%">
        </asp:TextBox>
        
        
    </td>

    <td></td>
    <td></td>
    <td></td>
    </tr>
     <tr>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    </tr>
    </table>
      </fieldset>

      <fieldset>
      <legend>Clinical Examination</legend>

      <table id="tblClinicalExam" class="label" width="99%">
      <tr>
      <td></td>
      <td colspan="3">
        <fieldset>
            <legend>Vitals</legend>
            <table id="tblVitals" style="background-color:Aqua" class="label" width="99%">
            <tr>
            <td></td>
            <td align="right">Temperature:</td>
            <td>
                <asp:TextBox ID="txtTemperature" CssClass="field" Width="30%" runat="server"></asp:TextBox>
            </td>
            <td></td>
            </tr>
            <tr>
            <td></td>
            <td align="right">Pulse Rate:</td>
            <td>
                <asp:TextBox ID="txtPulse" CssClass="field" Width="30%" runat="server"></asp:TextBox>
            </td>
            <td></td>
            </tr>
            <tr>
            <td></td>
             <td align="right">Blood Pressure:</td>
            <td>
                <asp:TextBox ID="txtBloodPressure" CssClass="field" Width="30%" runat="server"></asp:TextBox>
                </td>
            <td></td>
            </tr>
            <tr>
            <td width="10%"></td>
            <td width="40%"></td>
            <td width="40%"></td>
            <td width="10%"></td>
            </tr>
            
            </table>
        </fieldset>
      </td>
      
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
      <tr>
      <td></td>
      <td align="right">Patient Symptoms/sign:</td>
      <td>
                <asp:TextBox ID="txtclName" CssClass="field" Width="99%" runat="server"></asp:TextBox>
            </td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>

      </tr>
      <tr>
      <td></td>
      <td align="right">Symptom Detail:</td>
      <td colspan="2">
        <asp:TextBox ID="txtclDescription" runat="server" CssClass="field" Width="99%" TextMode="MultiLine"></asp:TextBox>
      </td>
     
      <td>
          <asp:ImageButton ID="imgSave" runat="server" AccessKey="s" 
              ImageUrl="~/images/save.png" OnClick="imgSave_Click" 
              ToolTip="Click or Press Alt+s to save test booking" style="height: 20px" />
          </td>
      <td></td>
      <td></td>

      </tr>
      <tr>
      <td></td>
      <td colspan="3">
        <asp:GridView ID="gvClinical" runat="server" Width="99%" CssClass="datagrid"  
              AutoGenerateColumns="False">
        <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
        <RowStyle CssClass="gridItem" />
        <AlternatingRowStyle CssClass="gridAlternate" />
        <Columns>
        <asp:TemplateField HeaderText="S#" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
        <ItemTemplate>
            <%# Container.DataItemIndex+1 %>
        </ItemTemplate>

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
        </asp:TemplateField>
        <asp:BoundField DataField="FieldName" ItemStyle-Width="20%" HeaderText="Symptom" >
<ItemStyle Width="20%"></ItemStyle>
            </asp:BoundField>
        <asp:BoundField DataField="Description" ItemStyle-Width="60%" HeaderText="Detail" >
<ItemStyle Width="60%"></ItemStyle>
            </asp:BoundField>
        <asp:TemplateField>
        <ItemTemplate>
            <asp:ImageButton ID="gvimgEdit" runat="server" ImageUrl="~/images/editing.jpg" CommandArgument="<%#Container.DataItemIndex%>" ToolTip="Edit" Visible="false" OnCommand="gvimgEdit_Click"/>
            <asp:ImageButton ID="gvimgDelete" runat="server" ImageUrl="~/images/delete.jpg" CommandArgument="<%#Container.DataItemIndex%>" ToolTip="Remove" OnCommand="gvimgDelete_Click"/>
        </ItemTemplate>
        </asp:TemplateField>

        </Columns>

        </asp:GridView>
      </td>
      
      <td></td>
      <td></td>
      <td></td>

      </tr>
      <tr>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    </tr>
      </table>
      </fieldset>
      
    </fieldset>




    <fieldset>
    <legend>
    Others
    </legend>
    <table id="tblotherhistory" class="label" width="99%">
    <tr>
    <td colspan="7">
        <asp:GridView ID="otherhistories" CssClass="datagrid" AutoGenerateColumns="false" runat="server" Width="99%">
        <RowStyle CssClass="gridItem" />
        <AlternatingRowStyle CssClass="gridAlternate" />
        <HeaderStyle CssClass="gridheader" HorizontalAlign="Left" />
        <Columns>
        <asp:TemplateField HeaderText="S#">
        <HeaderStyle HorizontalAlign="Center" />
        <ItemTemplate>
        <%#Container.DataItemIndex+1 %>
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
<tr>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="15%"></td>
    <td width="20%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    <td width="10%"></td>
    </tr>
    </table>
    </fieldset>
    </div>
    </form>
</body>
</html>

