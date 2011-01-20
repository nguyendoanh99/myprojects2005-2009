<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestCaptchaImage.aspx.cs" Inherits="TestCaptchaImage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
   
        CaptchaImage Test<p>
            A demonstration using the <code>CaptchaImage</code> object to prevent automated
            form submission.</p>
        <form id="Default" method="post" runat="server">
            <img alt="" src="JpegImage.aspx" /><br />
            <p>
                <strong>Enter the code shown above:</strong><br />
                <asp:TextBox ID="CodeNumberTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="SubmitButton" runat="server" Text="Submit" /><br />
            </p>
            <p>
                <em>(Note: If you cannot read the numbers in the above<br />
                </em>image, reload the page to generate a new <em>one.)</em>
            </p>
            <p>
                <asp:Label ID="MessageLabel" runat="server"></asp:Label></p>
        </form>
</body>
</html>
