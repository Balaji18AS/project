<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LockedForm.aspx.cs" Inherits="LockedForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title> Bot Control And Monitoring CAPTCHA System</title>
   <link href="css/main.css" rel="stylesheet" type="text/css" /> 

</head>
<body style ="background-color :Black ;">
    <form id="form1" runat="server">
    <div id="main_wrapper">
        <div id="header">
            <img src="images/header1.jpg" /></div>
        <div id="logo">
            <img src="images/logo1.jpg" /></div>
        <div id="content" style =" background-color :White ;">
            <div id="side_table" style =" background-color :White ;">
                <div id="main">
                    <img src="images/main.jpg" /></div>
                <div id="menu" style ="height :190px;">
                
                    
                </div>
            </div>
            <div id="right_table"  style =" background-color :White ;">
                <div id="rig_in">
                </div>
                <div id="right_con"  style =" background-color :White ;" >
                <table width="100%">
                <tr><td><br /><br /><br /></td></tr>
                <tr><td>
                   <center> 
                       <br />
                       <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="Black" 
                        Text="Your Status is Locked......" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="Black" 
                        Text="So Please Going to Lock Request Form........" Font-Bold="True"></asp:Label>
                       <br />
                       <br />
                    </center>
                    </td></tr>
                <tr><td>
                    <span style ="float:right ;">
                    <asp:HyperLink ID="HyperLink1" runat="server" 
                        Font-Bold="True" ForeColor="DarkBlue" NavigateUrl="~/LockRequest.aspx">Lock Request</asp:HyperLink></span>
                    <br /><br /><br /></td></tr>
                
                </table>
                

                    
                </div>
            </div>
        </div>
        
  <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <div id="footer" style ="color :White ; ">
            <marquee direction="left">
               Bot Control And Monitoring CAPTCHA System</marquee>
        </div>
        <div id="footer1">
            </div>
              </div>
    </form>
</body>
</html>
