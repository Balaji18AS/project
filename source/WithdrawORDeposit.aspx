<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="WithdrawORDeposit.aspx.cs" Inherits="WithdrawORDeposit"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style ="color :White ;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;  " >
    WITHDRAW/DEPOSIT</h1></th></tr>
<tr><td style="text-align: right">Transaction Number</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Account Number</td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Label" Font-Bold="False"></asp:Label></td>
    </tr>
    <tr><td style="height: 49px; text-align: right;">
        Type</td><td style="height: 49px">
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>Withdraw</asp:ListItem>
            <asp:ListItem>Deposit</asp:ListItem>
        </asp:RadioButtonList></td></tr>
    <tr>
        <td style="text-align: right">
            Withdraw/Deposit Date</td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Label" Font-Bold="False"></asp:Label></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Amount</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
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
            <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" Font-Bold="True"
                ForeColor="Darkblue" OnClick="LinkButton1_Click">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue"
                OnClick="LinkButton2_Click">Clear</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" 
                ForeColor="Black"></asp:Label></td>
        
    </tr>
</table>


</asp:Content>

