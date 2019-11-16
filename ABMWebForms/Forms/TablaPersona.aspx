<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TablaPersona.aspx.cs" Inherits="ABMWebForms.Forms.TablaPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head> 
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="dbwebModel">
        </asp:GridView>
        <asp:EntityDataSource ID="dbwebModel" runat="server">
        </asp:EntityDataSource>
    </form>
</body>
</html>
