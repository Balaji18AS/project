<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMasterPage.master" AutoEventWireup="true" CodeFile="DeleteAllRecords.aspx.cs" Inherits="DeleteAllRecords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        <asp:LinkButton ID="LinkButton1" runat="server" Font-Bold="True" 
            ForeColor="Black" onclick="LinkButton1_Click">Delete All Records</asp:LinkButton>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" ForeColor="Black" Text="Label"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <br />
</asp:Content>

