<%@ Page Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style ="color :White ; "><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;">ADMIN LOGIN</h1></th></tr>
<tr><td style="text-align: right">User Name</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Password</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" 
                TextMode="Password" ></asp:TextBox></td>
    </tr>
    <tr>
       
        <td colspan ="2" style ="COLOR: darkblue "><strong>Choose The Common Activity
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
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False">
            </asp:DropDownList></td>
    </tr>
    <tr>
      
        <td colspan ="2" style="text-align :center ; height: 40px;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Width="110px" OnClick="LinkButton1_Click">Submit</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" 
                ForeColor="Black"></asp:Label></td>
    </tr>

</table>
</asp:Content>

