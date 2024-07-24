<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminViewLockRequestDetails.aspx.cs" Inherits="AdminViewLockRequestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
        <tr>
            <th colspan ="2" style="height: 114px">
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;">
                    LOCK REQUEST USER DETAILS&nbsp;</h1>
               
            </th>
        </tr>
        <tr>
            <td colspan ="2" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan ="2" style ="color: darkblue;  ">
                <strong>Choose The Common Activity
            </strong>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" />
            </td>
            <td>
                <asp:Image ID="Image2" runat="server" Height="50px" Width="50px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Font-Bold="False" 
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan ="2" style="text-align :center ; height: 40px;">
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Width="110px" OnClick="LinkButton1_Click" Enabled="False">Submit</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan ="2" style="text-align :center ; height: 40px;">
            <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            
                    PageSize="3" DataKeyNames="accno,loginname" 
                    onrowcommand="GridView1_RowCommand" Visible="False" BackColor="#CCCCCC" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                        CellSpacing="2" ForeColor="Black">
                    <Columns>
                     <asp:BoundField DataField ="accno" HeaderText ="Account Number" />
                     <asp:BoundField DataField ="loginname" HeaderText ="Login Name" />
                     <asp:BoundField DataField ="rdate" HeaderText ="Request Date" />
                     <asp:ButtonField  Text ="Unlock" HeaderText ="Unlock" CommandName ="uu"  ControlStyle-ForeColor ="Red"/>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="white" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                    <sortedascendingcellstyle backcolor="#F1F1F1" />
                    <sortedascendingheaderstyle backcolor="#808080" />
                    <sorteddescendingcellstyle backcolor="#CAC9C9" />
                    <sorteddescendingheaderstyle backcolor="#383838" />
                </asp:GridView>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan ="2" style ="text-align :center ;">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" 
                    ForeColor="Black"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>


