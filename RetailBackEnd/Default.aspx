<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RetailBackEnd._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table border="0">
            <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
                <td><asp:TextBox ID="panjang" runat="server" ForeColor="Black" ></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
                <td><asp:TextBox ID="lebar" runat="server" forecolor="black"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Button ID="s" runat="server" Text="Hitung" /><br /></td>
                <td><asp:Label ID="metune" runat="server" Text="Label" Enabled="false"></asp:Label></td>
            </tr>
        </table>
    </div>
</asp:Content>
