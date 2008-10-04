<%-- 
    Document   : index
    Created on : Oct 2, 2008, 10:52:46 PM
    Author     : Nguyen Dang Khoa
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.lang.*, java.sql.*, MyPackage.*" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
            Connection con = MyUtilities.MyConnection.getODBCConnection("bai2");
            Statement statement = con.createStatement();
        %>
        
        <form action="result.jsp">
            Ho ten: <input type="text" name="name" value="" /><br>
            Dia chi: <input type="text" name="address" value="" /> <br>
            Dien thoai: <input type="text" name="phone" value="" /> <br>
            Danh muc cac mat hang:<br>
            <%
            String sql = "select * from MatHang";
            
            ResultSet rs = statement.executeQuery(sql);
            while (rs.next()) {
                MatHang mh = MatHang.CreateMatHang(rs);
                out.print(mh.ToString() + "<br>");
            }

            %>
            <input  type = "submit" value = "Submit Query" />
        </form>
    </body>
</html>
