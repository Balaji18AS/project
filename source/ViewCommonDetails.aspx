<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ViewCommonDetails.aspx.cs" Inherits="ViewCommonDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
<tr><th colspan ="2" style ="color :White ;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >VIEW COMMON DETAILS</h1></th></tr>
 <tr>
        
        <td colspan ="2" style="color: darkblue; height: 24px">
            <strong>Identify The Picture And Select Correct Options</strong></td>
    </tr>
    <tr>
        <td style="text-align: right">
            Image</td>
        <td>
            <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" /></td>
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
        <td colspan ="2" style ="text-align :center ;">
        <center>
            <asp:DetailsView AutoGenerateRows ="False" ID="DetailsView1" runat="server" 
                Height="50px" Width="223px" BackColor="#CCCCCC" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                ForeColor="Black">
                <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
            <Fields >
            <asp:BoundField DataField ="policyno" HeaderText ="Policy Number" />
            <asp:BoundField DataField ="policyname" HeaderText ="Policy Name" />
            <asp:BoundField DataField ="duration" HeaderText ="Duration" />
            <asp:BoundField DataField ="dueamount" HeaderText ="Due Amount" />
            <asp:BoundField DataField ="ebno" HeaderText ="EB Number" />
            <asp:BoundField DataField ="teleno" HeaderText ="Telephone Number" />
            <asp:BoundField DataField ="planname" HeaderText ="Plan Name" />
            </Fields>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" HorizontalAlign="Left" />
            </asp:DetailsView>
            </center>
    </td>
    </tr>
    <tr>
    <td colspan ="2" style ="text-align :center ;">
        <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" Font-Bold="True"
            ForeColor="Darkblue" OnClick="LinkButton1_Click">Submit</asp:LinkButton>&nbsp;
    </td>
    
    </tr>
    <tr>
        <td colspan="2" style="text-align: center">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>

</table>
</asp:Content>

