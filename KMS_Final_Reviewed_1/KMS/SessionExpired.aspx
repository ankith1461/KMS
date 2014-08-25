<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionExpired.aspx.cs" Inherits="KMS.SessionExpired" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Session Expired</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" 
            Text="Sorry..Your session got expired due to unauthorized access.!" 
            Font-Bold="True" Font-Size="Larger" ForeColor="#0033CC"></asp:Label>
       <br /> To Login again please click <asp:LinkButton ID="LinkButton1" 
            runat="server" PostBackUrl="~/startpage.aspx">here</asp:LinkButton>
    </div>
    </form>
</body>
</html>
