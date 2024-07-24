<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ObjectCaptcha.aspx.cs" Inherits="ObjectCaptcha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>    Bot Control And Monitoring CAPTCHA System</title>
    <link href="css/main.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .style1
        {
            text-align: right;
        }
    </style>

</head>
<body style ="background-color :black ;">
    <form id="form1" runat="server">
  <div id="main_wrapper">
        <div id="header">
            <img src="images/header1.jpg" /></div>
        <div id="logo">
            <img src="images/logo1.jpg" /></div>
        <div id="content">
        <table>
        <tr>
        <td>
        
        <div id="side_table">
                <div id="main">
                    <img src="images/main.jpg" /></div>
                <div id="menu">
                    <ul>
                        <li><a href="Home.aspx">Home</a></li>
                         <li><a href="AccountCreation.aspx">Account Creation</a></li>
                         <li><a href="ActivityCaptcha.aspx">Activity Captcha</a></li>
                         <li><a href="ObjectCaptcha.aspx">Object Captcha</a></li>
                          <li><a href="AdminViewLockRequestDetails.aspx" >Request User</a></li>
                      
                    </ul>
                </div>
            </div>

        </td>

        <td>
        <div id="right_table" style ="background-color :White ; width :90%">
                <div id="rig_in" >
                </div>
                <div id="right_con" style ="width :100%;background-color :White ;">
                    <table border ="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >
    OBJECT CAPTCHA</h1></th></tr>
<tr><td style="width: 55px" class="style1">
    Image1</td><td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
        &nbsp;
        <asp:Button ID="Button1" runat="server" Text="Preview" 
            onclick="Button1_Click" />
         <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
       
    <br />
        </td></tr>
    
   
  
    <tr>
        <td style="width: 55px" class="style1">
            Option1</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox></td>
    </tr>
   <tr><td class="style1">
       Option2</td><td>
           <asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td></tr> 
  <tr><td class="style1">
      Option3</td><td>
          <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False"></asp:TextBox></td></tr>  
  <tr><td class="style1">
      Option4</td><td>
          <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False"></asp:TextBox></td></tr>  
  <tr><td class="style1">
            Answer</td><td>
                <asp:TextBox ID="TextBox5" runat="server" Font-Bold="False"></asp:TextBox></td></tr>  
                
                <tr>
       
        <td colspan ="2" style ="COLOR: darkblue "><strong>Choose The Common Activity
            </strong>
        </td>
    </tr>
   <tr><td>
       <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" /></td><td>
       <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" /></td></tr> 
    <tr>
        <td>
            <asp:Image ID="Image4" runat="server" Height="50px" Width="50px" /></td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" 
                AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
   
  
    <tr>
       
        <td colspan ="2" style ="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" ForeColor="Darkblue"
                OnClick="LinkButton2_Click">Clear</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan ="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>

</div>
            </div>
        
        </td>
        </tr>
        
        </table> 
            
            
        </div>
        <div id="footer" style ="color :White ;">
            <marquee direction="left">
                Bot Control And Monitoring CAPTCHA System</marquee>
        </div>
        <div id="footer1">
            </div>
    </div>
    </form>
</body>
</html>
