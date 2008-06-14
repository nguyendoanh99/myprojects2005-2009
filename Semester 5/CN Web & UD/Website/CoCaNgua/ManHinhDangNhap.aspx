<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManHinhDangNhap.aspx.cs" Inherits="ManHinhDangNhap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Height="58px" Style="clear: none; display: block;
            font-weight: bold; font-size: xx-large; float: none; visibility: visible; vertical-align: middle;
            text-transform: uppercase; color: blue; font-family: Arial; text-align: center"
            Text="CỜ CÁ NGỰA" Width="100%"></asp:Label>&nbsp;</div>
        <asp:Label ID="Label2" runat="server" Text="Số người chơi tối đa"></asp:Label>
        <asp:Label ID="lblNguoiChoiToiDa" runat="server" Text="4 người"></asp:Label>
        <asp:Label ID="Label8" runat="server" Width="241px"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Số người đang chơi"></asp:Label>
        <asp:Label ID="lblSoNguoiChoi" runat="server" Text="0"></asp:Label><br />
        <asp:Label ID="Label6" runat="server" Text="Số người đang xem"></asp:Label>
        <asp:Label ID="lblSoNguoiXem" runat="server" Text="0"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Đây là chương trình còn thử nghiệm nên được tạo sẵn 4 tài khoản để tiện sử dụng"></asp:Label><br />
        <asp:Label ID="Label5" runat="server" Text="Tài khoản 1: Username: nguoi1                         Password: nguoi1"></asp:Label><br />
        <asp:Label ID="Label7" runat="server" Text="Tài khoản 2: Username: nguoi2                         Password: nguoi2"></asp:Label><br />
        <asp:Label ID="Label9" runat="server" Text="Tài khoản 3: Username: nguoi3                         Password: nguoi3"></asp:Label><br />
        <asp:Label ID="Label10" runat="server" Text="Tài khoản 4: Username: nguoi4                        Password: nguoi4"></asp:Label><br />
        <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/CuaSoChinh.htm" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn">
        </asp:Login>
        &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Đăng nhập để xem"
            Width="190px" />
        &nbsp;
    </form>
</body>
</html>
