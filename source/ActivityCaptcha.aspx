<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ActivityCaptcha.aspx.cs" Inherits="ActivityCaptcha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>   Bot Control And Monitoring CAPTCHA System</title>
   <link href="css/main.css" rel="stylesheet" type="text/css" /> 

    <style type="text/css">
        .style1
        {
            text-align: right;
        }
        .style2
        {
            text-align: right;
            height: 39px;
        }
        .style3
        {
            height: 39px;
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
        <div id="content" style="background-color :White ;">
        <table>
        <tr>
        <td >
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


        <td  rowspan ="3">
        <div id="right_table">
                <div id="rig_in">
                </div>
                <div id="right_con"  style ="width :90% ; background-color :White ;">
                <table border ="2"  style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;">ACTIVITY CAPTCHA</h1></th></tr>
<tr><td colspan ="2" style="color: darkblue; height: 24px"><strong>Select Three Images In Common Behaviour</strong></td></tr>
<tr><td class="style1">
    Image1</td><td>
    <asp:FileUpload ID="FileUpload1" runat="server" />
     <asp:Button ID="Button4" runat="server" onclick="Button4_Click" 
            Text="Preview" />
    &nbsp;<asp:Image ID="Image1" runat="server" Height="50px" Width="50px" />
       
        <asp:HiddenField ID="HiddenField1" runat="server" />
    <br />
        </td></tr>
    <tr>
        <td class="style2">
            Image2</td>
        <td class="style3" >
            <asp:FileUpload ID="FileUpload2" runat="server" />
             <asp:Button ID="Button5" runat="server" onclick="Button5_Click" 
                Text="Preview" />
            &nbsp;<asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
           
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <br /></td>
    </tr>
    <tr>
        <td class="style1">
            Image3</td>
        <td>
            <asp:FileUpload ID="FileUpload3" runat="server" />
           
            <asp:Button ID="Button6" runat="server" onclick="Button6_Click" 
                Text="Preview" />
            &nbsp;<asp:Image ID="Image3" runat="server" Height="50px" Width="50px" />
            
            <asp:HiddenField ID="HiddenField3" runat="server" />
            <br /></td>
    </tr>
   <tr><td colspan ="2" style="color: darkblue; height: 24px"><strong>Look Three Images And Type Common Activity  Answer</strong></td></tr> 
    <tr>
        <td style="text-align: right">
            Answer</td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True"></asp:TextBox></td>
    </tr>
    <tr>
       
        <td colspan ="2" style ="COLOR: darkblue "><strong>Choose The Common Activity
            </strong>
        </td>
    </tr>
   <tr><td>
       <asp:Image ID="Image4" runat="server" Height="50px" Width="50px" /></td><td>
       <asp:Image ID="Image5" runat="server" Height="50px" Width="50px" /></td></tr> 
    <tr>
        <td>
            <asp:Image ID="Image6" runat="server" Height="50px" Width="50px" /></td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" 
                AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList></td>
    </tr>
   
    <tr>
       
        <td colspan ="2" style ="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Darkblue" 
                onclick="LinkButton2_Click" Font-Bold ="true" >Clear</asp:LinkButton>
        </td>
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
        <tr>
        <td><br /></td>
        
        </tr>
        <tr>
        <td><br /></td>
        
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
