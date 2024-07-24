<%@ Page Language="C#" MasterPageFile="~/ClientMasterPage.master" AutoEventWireup="true" CodeFile="ViewAccountHolder.aspx.cs" Inherits="ViewAccountHolder"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table border="2"style="font-weight :normal ; width :100%;  " cellpadding="5px" >
        <tr>
            <th colspan="2"  >
                <h1 style ="color :DarkBlue ; font-size :x-large ; text-transform :capitalize;">
                    VIEW ACCOUNT HOLDER</h1>
            </th>
        </tr>
        <tr>
            <td colspan="2" style="color: darkblue; height: 24px">
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
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" Font-Bold="False"
                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatColumns="2">
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <br />
                <center>
                <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" Height="50px"
                    Width="297px" BackColor="#CCCCCC" BorderColor="#999999" 
                    BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" 
                    ForeColor="Black">
                    <EditRowStyle BackColor="#000099" ForeColor="Black" />
                    <Fields>
                        <asp:BoundField DataField ="name" HeaderText ="Name" />
                        <asp:BoundField DataField ="dob" HeaderText ="Date of Birth" HtmlEncode ="False"  DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField ="occupation" HeaderText ="Occupation" />
                        <asp:BoundField DataField ="address" HeaderText ="Address" />
                        <asp:BoundField DataField ="city" HeaderText ="City" />
                        <asp:BoundField DataField ="pnumber" HeaderText ="Phone Number" />
                        <asp:BoundField DataField ="cfacility" HeaderText ="Cheque Facility" />
                        <asp:BoundField DataField ="odate" HeaderText ="Opening Date" HtmlEncode ="False" DataFormatString ="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField ="oamount" HeaderText ="Opening Amount" />
                        <asp:BoundField DataField ="emailid" HeaderText ="EmailID" />
                        <asp:BoundField DataField ="bname" HeaderText ="Bank Name" />
                        <asp:BoundField DataField ="branchname" HeaderText ="Branch Name" />
                        <asp:BoundField DataField ="baddress" HeaderText ="Bank Address" />
                        <asp:BoundField DataField ="bpnumber" HeaderText ="Bank Phone Number" />
                        <asp:BoundField DataField ="bcity" HeaderText ="City Name" />
                    </Fields>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="Black" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle HorizontalAlign="Left" BackColor="White" />
                </asp:DetailsView>
                </center>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
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

