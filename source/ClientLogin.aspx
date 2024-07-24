<%@ Page Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ClientLogin.aspx.cs" Inherits="ClientLogin"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
        <tr>
            <th colspan="2" style="color: white">
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >
                    CLIENT LOGIN</h1>
            </th>
        </tr>
        <tr><td style="text-align: right">
            Account Number</td><td>
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
        <tr>
            <td style="text-align: right">
                User Name</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Password</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" 
                    TextMode="Password" ></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2" style="COLOR: darkblue">
     
                    <strong>Choose The Common Activity
            </strong>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" /></td>
            <td>
                <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" /></td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" /></td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" 
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" 
                    style="height: 22px">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 40px; text-align: center">
                <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    NavigateUrl="~/GetAccountNumber.aspx">GetAccountNumber</asp:HyperLink>
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    OnClick="LinkButton1_Click" Width="110px" Enabled="False">Submit</asp:LinkButton>
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    NavigateUrl="~/NewRegistration.aspx">NewRegistration</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
       
        <tr>
            <td colspan="2" style="text-align: center">
              
                <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="True" 
                    NavigateUrl="~/LockRequest.aspx"  ForeColor="Darkblue">Lock Request</asp:HyperLink>&nbsp;&nbsp;&nbsp;
                <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    NavigateUrl="~/ChangePassword.aspx">Change Password</asp:HyperLink>&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    NavigateUrl="~/ForgotPassword.aspx">ForGot Password</asp:HyperLink></td>
        </tr>
         <tr>
          <td colspan="2" style="text-align: center">
          <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                  Text="Label"></asp:Label>
          </td>
        </tr>
    </table>
</asp:Content>

