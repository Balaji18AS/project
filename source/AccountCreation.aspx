<%@ Page Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AccountCreation.aspx.cs" Inherits="AccountCreation"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" "><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >ACCOUNT HOLDER  DETAILS </h1>
  
</th></tr>
<tr><td colspan ="2" style="color: darkblue; height: 24px"><strong>Account Holder Details</strong></td></tr>
<tr><td style="text-align: right">Account Number</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Name</td>
        <td>
            <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Date Of Birth</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" Width="55px"></asp:TextBox>
            <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False">
            <asp:ListItem >Select</asp:ListItem>
                <asp:ListItem>Jan</asp:ListItem>
                <asp:ListItem>Feb</asp:ListItem>
                <asp:ListItem>Mar</asp:ListItem>
                <asp:ListItem>Apr</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>Jun</asp:ListItem>
                <asp:ListItem>Jul</asp:ListItem>
                <asp:ListItem>Aug</asp:ListItem>
                <asp:ListItem>Sep</asp:ListItem>
                <asp:ListItem>Oct</asp:ListItem>
                <asp:ListItem>Nov</asp:ListItem>
                <asp:ListItem>Dec</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" Width="50px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Occupation</td>
        <td>
            <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Address</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server" Font-Bold="False" 
                TextMode="MultiLine"></asp:TextBox></td>
    </tr>
   <tr><td style="text-align: right">
       City</td><td>
       <asp:TextBox ID="TextBox14" runat="server" Font-Bold="False"></asp:TextBox></td></tr> 
    <tr>
        <td style="text-align: right">
            Phone Number</td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Cheque Facility</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Bold="False" 
                RepeatDirection="Horizontal">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Opening Date</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Opening Amount</td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr><td style="text-align: right">
        EmailID</td><td>
        <asp:TextBox ID="TextBox16" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
   <tr><td colspan ="2" style="color: darkblue; height: 24px"><strong>Bank Details</strong></td></tr>
   <tr><td style="text-align: right">Bank Name</td><td>
       <asp:TextBox ID="TextBox10" runat="server" Font-Bold="False"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Which Branch</td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Address</td>
        <td>
            <asp:TextBox ID="TextBox12" runat="server" Font-Bold="False" 
                TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
   <tr><td style="text-align: right">
       City</td><td>
       <asp:TextBox ID="TextBox15" runat="server" Font-Bold="False"></asp:TextBox></td></tr>  
    <tr>
        <td style="height: 17px; text-align: right;">
            Phone Number</td>
        <td style="height: 17px">
            <asp:TextBox ID="TextBox13" runat="server" Font-Bold="False"></asp:TextBox></td>
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
            <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" 
                AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
   
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue"
                OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue"
                OnClick="LinkButton2_Click">Clear</asp:LinkButton></td>
        
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

