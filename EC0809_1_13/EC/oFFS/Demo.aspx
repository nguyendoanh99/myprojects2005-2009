<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Demo.aspx.cs" Inherits="Demo" %>

<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:MultipleFileUpload ID="MultipleFileUpload1" OnClick="MultipleFileUpload1_Click"
                runat="server" UpperLimit="1"/>
        </div>
    </form>
</body>
</html>
