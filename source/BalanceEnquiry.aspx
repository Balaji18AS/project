<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="BalanceEnquiry.aspx.cs" Inherits="BalanceEnquiry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style ="color :White ;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >BALANCE ENQUIRY</h1></th></tr>
<tr><td style="text-align: right">
    Account Number</td><td>
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td></tr>
   <tr>
        
        <td colspan ="2" style="color: darkblue; height: 24px">
            <strong>Identify The Picture And Select Correct Options</strong></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Image</td>
        <td>
            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" /></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Options</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="False" 
                AutoPostBack="True" 
                OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" 
                RepeatColumns="2">
            </asp:RadioButtonList></td>
    </tr>
    <tr>
       
        <td colspan ="2" style ="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Enabled="False" OnClick="LinkButton1_Click">Submit</asp:LinkButton>&nbsp;
            </td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

