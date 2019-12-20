<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BlobWebRole.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Upload" runat="server" Text="Upload" OnClick="Upload_Click" />
        <asp:Button ID="Download" runat="server" Text="Download" OnClick="Download_Click" />
    </div>
    </form>
</body>
</html>
