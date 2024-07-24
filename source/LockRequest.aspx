<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LockRequest.aspx.cs" Inherits="LockRequest" MasterPageFile="~/HomeMasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
        <tr>
            <th colspan="2" style="color: white">
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >
                    LOCK REQUEST</h1>
            </th>
        </tr>
        <tr><td style="text-align: right">
            Account Number</td><td>
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
        <tr>
            <td style="text-align: right">
                UserName</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
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
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue"
                    OnClick="LinkButton1_Click" Width="110px" Enabled="False">Submit</asp:LinkButton>
                </td>
        </tr>
      
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                    Text="Label"></asp:Label>
                </td>
        </tr>
    </table>
</asp:Content>




