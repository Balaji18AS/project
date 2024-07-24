<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="CommonDetails.aspx.cs" Inherits="CommonDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style="height: 114px ; color :White ; "><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >POLICY, EB AND TELEPHONE DETAILS</h1>
  
</th></tr>
<tr><td style="text-align: right">
    Account Number</td><td>
        <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Label"></asp:Label></td></tr>
    <tr>
        <td style="text-align: right">
            Policy Number</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Policy Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Duration</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Font-Bold="False" RepeatColumns="2"
                RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Monthly</asp:ListItem>
                <asp:ListItem Value="3">Quaterly</asp:ListItem>
                <asp:ListItem Value="6">Halfly</asp:ListItem>
                <asp:ListItem Value="1">Yearly</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr><td style="text-align: right">Due Amount</td><td>
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            EB Connection Number</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Telephone Number</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr><td style="height: 23px; text-align: right;">Plan Name</td><td style="height: 23px">
        <asp:TextBox ID="TextBox6" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
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
       
        <td colspan ="2" style="text-align :center ; height: 23px;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Enabled="False" OnClick="LinkButton1_Click">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue">Clear</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

