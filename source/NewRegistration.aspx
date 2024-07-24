<%@ Page Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="NewRegistration.aspx.cs" Inherits="NewRegistration"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">

<tr><th colspan ="2" style ="color :White ;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >NEW REGISTRATION </h1></th></tr>
<tr><td style="text-align: right">Account Number</td><td>
    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" AutoPostBack="True" 
        OnTextChanged="TextBox1_TextChanged"></asp:TextBox></td></tr>
<tr><td style="text-align: right">
    Name</td><td>
    <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td></tr>
    <tr>
        <td style="text-align: right">
            Login Name</td>
        <td>
            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Password</td>
        <td>
            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" TextMode="Password" 
                ValidationGroup="aa"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right" >
            Confirm Password</td>
        <td >
            <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False" TextMode="Password" 
                ValidationGroup="aa"></asp:TextBox>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox4"
                ControlToValidate="TextBox5" ErrorMessage="Password Shoud Be Same" ForeColor="Red"
                ValidationGroup="aa" Font-Bold="True"></asp:CompareValidator></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Father Name</td>
        <td>
            <asp:TextBox ID="TextBox6" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Age</td>
        <td>
            <asp:TextBox ID="TextBox7" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="text-align: right">
            Gender</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                RepeatDirection="Horizontal" Font-Bold="False" Width="176px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Marital Status</td>
        <td>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" 
                RepeatDirection="Horizontal" Font-Bold="False">
                <asp:ListItem>Married</asp:ListItem>
                <asp:ListItem>Unmarried</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Contact No</td>
        <td>
            <asp:TextBox ID="TextBox8" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            MailID</td>
        <td>
            <asp:TextBox ID="TextBox9" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Address</td>
        <td>
            <asp:TextBox ID="TextBox10" runat="server" Font-Bold="False" ReadOnly="True" 
                TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            City</td>
        <td>
            <asp:TextBox ID="TextBox11" runat="server" Font-Bold="False" ReadOnly="True"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Pincode</td>
        <td>
            <asp:TextBox ID="TextBox12" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Country</td>
        <td>
            <asp:TextBox ID="TextBox13" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
   <tr><td style="text-align: right">
       Security Question</td><td>
           <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" >
      <asp:ListItem >Select</asp:ListItem> 
     <asp:ListItem >Your First School?</asp:ListItem>  
     <asp:ListItem >Your Best Friend?</asp:ListItem>  
     <asp:ListItem >Favourite Color?</asp:ListItem>  
     <asp:ListItem >Favourite Dish?</asp:ListItem>  
       </asp:DropDownList></td></tr> 
  <tr><td style="text-align: right">
      Security Answer</td><td>
      <asp:TextBox ID="TextBox14" runat="server" Font-Bold="False" ></asp:TextBox></td></tr>  
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
            &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" 
                AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
           
            </asp:DropDownList></td>
    </tr>
    <tr>
      
        <td colspan ="2" style="text-align :center ; height: 40px;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Width="110px" OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton>
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

