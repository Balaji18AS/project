<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="SendAccountNo.aspx.cs" Inherits="SendAccountNo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style="height: 114px"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >SEND ACCOUNT NUMBER</h1>
</th></tr>
<tr><td style="width: 246px; text-align: right;">From ID</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
<tr><td style="width: 246px; text-align: right;">To ID</td><td>
    <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
        <td style="width: 246px; text-align: right;">
            Account Number</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="width: 246px; height: 74px; text-align: right;">
            Subject</td>
        <td style="height: 74px">
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" Height="77px" 
                TextMode="MultiLine"></asp:TextBox></td>
    </tr>
     <tr>
       
        <td colspan ="2" style ="color: darkblue;  "><strong>Choose The Common Activity
            </strong>
        </td>
    </tr>
   <tr><td>
       <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" /></td><td>
       <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" /></td></tr> 
    <tr>
        <td>
            <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" /></td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" 
                AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
    <tr>
      
        <td colspan ="2" style="text-align :center ; height: 40px;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Width="110px" OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" 
                ForeColor="Black"></asp:Label></td>
    </tr>

</table>
</asp:Content>

