<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="MiniStatement.aspx.cs" Inherits="MiniStatement"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px"  >
<tr><th colspan ="2" style ="color :White ;"><h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >MINI STATEMENTS</h1></th></tr>
<tr><td style="width: 116px; text-align: right;">
    Options</td><td>
    <asp:DropDownList ID="DropDownList2" runat="server" Font-Bold="False" Width="141px" 
            AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        <asp:ListItem>Select</asp:ListItem>
        <asp:ListItem>FromTo</asp:ListItem>
        <asp:ListItem>Month</asp:ListItem>
        <asp:ListItem>Year</asp:ListItem>
        <asp:ListItem>All</asp:ListItem>
    </asp:DropDownList></td></tr>
    <tr>
      
        <td colspan ="2" >
            <asp:MultiView ID="MultiView1" runat="server">
                <asp:View ID="View1" runat="server">
                <table border="2" style=" font-weight :normal ; width: 100%; " cellpadding="10px">
                    <tr>
                        <td style="text-align: right" >
                            From Date</td>
                        <td >
                            <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False" Width="139px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td style="text-align: right" >
                            To Date</td>
                        <td >
                            <asp:TextBox ID="TextBox2" runat="server" Height="17px" Width="139px" 
                                Font-Bold="False"></asp:TextBox></td>
                    </tr>
                </table>
                </asp:View>
                <asp:View ID="View2" runat="server"><table border="2" style=" font-weight :normal ; width: 100%; " cellpadding="10px">
                    <tr>
                        <td style=" text-align: right;" >
                            Month</td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Font-Bold="False" Width="142px"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="Black" 
                                Text="Label"></asp:Label></td>
                    </tr>
                    
                </table>
                </asp:View>
                <asp:View ID="View3" runat="server"><table border="2" style=" font-weight :normal ; width: 100%; " cellpadding="10px">
                    <tr>
                        <td style=" text-align: right;" >
                            Year</td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Font-Bold="False" Width="139px"></asp:TextBox></td>
                    </tr>
                   
                </table>
                </asp:View>
            </asp:MultiView></td>
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
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
   
    <tr>
        <td colspan="2" style ="text-align :center ;">
        <center>
            <asp:GridView ID="GridView1" AutoGenerateColumns ="False" runat="server" 
                 AllowPaging="True" 
                OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="3" 
                EmptyDataText="Record Not Found" BackColor="#CCCCCC" BorderColor="#999999" 
                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                ForeColor="Black">
            <Columns >
            <asp:BoundField  DataField ="type" HeaderText ="Type" />
            <asp:BoundField  DataField ="wddate" HeaderText ="Date" DataFormatString ="{0:dd-MMM-yyyy}" HtmlEncode ="False" />
            <asp:BoundField  DataField ="amount" HeaderText ="Amount" />
            </Columns>
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="white" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView></center>
        </td>
    </tr>
    <tr>
        <td colspan="2" style ="text-align :center ;">
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" ForeColor="Darkblue" Enabled="False" OnClick="LinkButton1_Click">Submit</asp:LinkButton></td>
    </tr>
    <tr>
        <td colspan="2" style ="text-align :center ;">
            <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                Text="Label"></asp:Label></td>
    </tr>
</table>
</asp:Content>

