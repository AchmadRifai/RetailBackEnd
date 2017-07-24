<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dbconf.aspx.vb" Inherits="RetailBackEnd.dbconf" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database Connector Settings</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table border="0">
                <tr>
                    <td>Host : </td>
                    <td><input runat="server" id="dbserv" type="text" value="" required="required"
                        onserverchange="dbserv_ServerChange"/></td>
                </tr>
                <tr>
                    <td>DB Name : </td>
                    <td><input runat="server" id="namene" type="text" value="" required="required"
                        onserverchange="Text1_ServerChange"/></td>
                </tr>
                <tr>
                    <td>Port : </td>
                    <td><input runat="server" id="porte" type="number" required="required" value="3306"/></td>
                </tr>
                <tr>
                    <td>UserName : </td>
                    <td><input runat="server" id="username" type="text" required="required" value=""
                        onserverchange="username_ServerChange"/></td>
                </tr>
                <tr>
                    <td>Password : </td>
                    <td><input runat="server" id="sandi" type="password" value=""/></td>
                </tr>
                <tr>
                    <td><input runat="server" id="s" disabled="disabled" type="button" 
                        value="Simpan Dan Hubungkan" onserverclick="s_ServerClick"/></td>
                    <td><label id="pesan" runat="server"></label></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
