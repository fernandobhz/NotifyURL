<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="default.aspx.vb" Inherits="NotifyURL.notify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ODSNotes">
        </asp:GridView>
        <asp:ObjectDataSource ID="ODSNotes" runat="server" SelectMethod="SelectAll" TypeName="NotifyURL.Note"></asp:ObjectDataSource>
    
    </div>
    </form>
</body>
</html>
