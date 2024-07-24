<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="AmountTransfer.aspx.cs" Inherits="AmountTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >MONEY TRANSACTION</h1></th></tr>
<tr><td style="height: 28px; text-align: right;">
    Account Number</td><td style="height: 28px">
        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Account Number To Tranfer</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Amount To Transfer</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Transfer Date</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
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
        <td style ="text-align :right ;">
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
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Enabled="False" OnClick="LinkButton1_Click">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue">Clear</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

