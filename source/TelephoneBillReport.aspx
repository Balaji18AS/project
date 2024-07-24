<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="TelephoneBillReport.aspx.cs" Inherits="TelephoneBillReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table  border="2" 
       style="font-weight :normal ; width :100%;  " cellpadding="5px">
        <tr>
            <th colspan="2" style="color: white">
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;" >
                    TELEPHONE BILL PAYMENT REPORT</h1>        
                  
            </th>
        </tr>
        <tr>
            <td style=" text-align: right;">
                Options</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Width="141px">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>Month</asp:ListItem>
                    <asp:ListItem>Year</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:MultiView ID="MultiView1" runat="server">
                    <asp:View ID="View1" runat="server">
                        <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
                            <tr>
                                <td style="text-align: right">
                                    Month</td>
                                <td >
                                    <asp:TextBox ID="TextBox1" runat="server" Font-Bold="False"></asp:TextBox>
                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" ForeColor="Black" 
                                        Text="Label"></asp:Label></td>
                            </tr>
                           
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table border="2" style="font-weight :normal ; width :100%;  " cellpadding="5px">
                            <tr>
                                <td style=" text-align: right;">
                                    Year</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="TextBox2" runat="server" Font-Bold="False"></asp:TextBox></td>
                            </tr>
                        </table>
                    </asp:View>
                    &nbsp;
                </asp:MultiView></td>
        </tr>
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
            <td style="height: 54px">
                <asp:Image ID="Image3" runat="server" Height="50px" Width="50px" /></td>
            <td style="height: 54px">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label3" runat="server" Font-Bold="False" ForeColor="Black" 
                    Text="Label"></asp:Label>
                <center>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="Record Not Found"  OnPageIndexChanging="GridView1_PageIndexChanging"
                    PageSize="3" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                    BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <Columns>
                       <asp:BoundField DataField ="tnumber" HeaderText ="Telephone Number" />
                       <asp:BoundField DataField ="planname" HeaderText ="Plan Name" />
                       <asp:BoundField DataField ="pdate" HeaderText ="Payment Date" HtmlEncode ="false" DataFormatString ="{0:dd-MMM-yyyy}" />
                       
                       <asp:BoundField DataField ="amount" HeaderText ="Amount" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="Black" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                </center>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:LinkButton ID="LinkButton1" runat="server" Enabled="False" Font-Bold="True"
                    ForeColor="Darkblue" OnClick="LinkButton1_Click">Submit</asp:LinkButton></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="Black" 
                    Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

