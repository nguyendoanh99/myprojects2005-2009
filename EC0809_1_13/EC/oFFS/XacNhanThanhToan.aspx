<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XacNhanThanhToan.aspx.cs" Inherits="XacNhanThanhToan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
     <link rel="stylesheet" href="css/mycss.css" type="text/css" />
    <link rel="stylesheet" href="css/2.3.0-reset-fonts-grids.css" type="text/css" />
</head>
<body>
    <div id="doc" class="yui-t7">
    <hr />
    <div id="section1">
    <h2>Cám ơn bạn đã mua hàng
    </h2>  
    </div>
    
    <hr />
    
     <blockquote>
     <p>
     Thank you for your generous order of <b>$<%= this.OrderAmount %></b>.
     <p><br />
    Please come back and visit us again.
    <p><br />
    Pretty please?
    </blockquote>
    <hr>
    <small> Online Fast Food System, &copy; HappyTinyfoot, Inc &trade;</small>
       </body>
</html>
