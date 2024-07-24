<%@ Page Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
        <tr>
            <th colspan="2" style="color: white">
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >
                    CHANGE PASSWORD</h1>
            </th>
        </tr>
        <tr>
            <td colspan="2" style="color: darkblue">
                <strong>Answer The Following Question To Receive Your Password</strong></td>
        </tr>
        <tr>
            <td style="text-align: right">
                EMailID</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                Old Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align: right">
                New Password</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr><td style="text-align: right">
            Confirm Password</td><td>
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" TextMode="Password"></asp:TextBox>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox3"
                ControlToValidate="TextBox4" ErrorMessage="Password Shoud Be Same" ForeColor="Red"
                ValidationGroup="aa" Font-Bold="True"></asp:CompareValidator></td></tr>
        <tr>
            <td colspan="2" style="color: darkblue">
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
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 23px; text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" Font-Bold="True"
                    ForeColor="Darkblue" OnClick="LinkButton1_Click">Submit</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                    Text="Label"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

