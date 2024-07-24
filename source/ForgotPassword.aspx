<%@ Page Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border ="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style="color :White ; height: 59px;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >FORGOT YOUR PASSWORD </h1>
   
</th></tr>
<tr><td colspan ="2" style="color: darkblue" >
    <strong>Enter Your UserName To Receive Your Password</strong></td></tr>
    <tr>
        <td style="text-align: right" >
            EMailID</td>
        <td >
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
     <tr>
        
        <td colspan ="2" style="color: darkblue; height: 24px">
            <strong>Identify The Picture And Select Correct Options</strong></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Image</td>
        <td>
            <asp:Image ID="Image1" runat="server"  Height="100px" Width="100px"/></td>
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
       
       <td colspan ="2" style ="text-align :center ; ">
           <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue"
               OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

