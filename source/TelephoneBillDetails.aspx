<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="TelephoneBillDetails.aspx.cs" Inherits="TelephoneBillDetails"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2"  ><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;">
    TELEPHONE BILL DETAILS</h1></th></tr>
<tr><td style="text-align: right">Account Number</td><td>
    <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Label"></asp:Label></td></tr>
<tr><td style="height: 28px; text-align: right;">
    Telephone Number</td><td style="height: 28px">
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" AutoPostBack="True" 
            OnTextChanged="TextBox1_TextChanged"></asp:TextBox></td></tr>
    <tr><td style="text-align: right">
        Plan Name</td><td>
    <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Label"></asp:Label></td></tr>
<tr><td style="text-align: right">Amount Payment Date</td><td>
    <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="Label"></asp:Label></td></tr>
<tr><td style="text-align: right">Amount</td><td>
    <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
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
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        
<tr><td colspan ="2" style ="text-align :center ;">
    <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" Font-Bold="True"
        ForeColor="Darkblue" OnClick="LinkButton1_Click">Submit</asp:LinkButton>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue"
        OnClick="LinkButton2_Click">Clear</asp:LinkButton></td></tr>
<tr><td colspan ="2" style ="text-align :center ;">
    <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
        Text="Label"></asp:Label></td></tr>
</table>
</asp:Content>

