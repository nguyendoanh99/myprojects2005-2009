<%-- 
    Document   : index
    Created on : Oct 4, 2008, 12:07:07 PM
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
            Connection con = MyUtilities.MyConnection.getODBCConnection("bai3");
            Statement statement = con.createStatement();
        %>
        <form action="result.jsp">

        Ho ten KH: <input type="text" name="name" value="" /><br>
        Dia chi: <input type="text" name="address" value="" /><br>
        Dien thoai: <input type="text" name="phone" value="" /><br>
        <br>
        CPU:<br>
        <%
            //CPU
            String sql = "select * from CPU";
            ResultSet rs = statement.executeQuery(sql);
            
            out.print("<select name=\"cpu\">");
            while (rs.next()) {
                LinhKien lk = LinhKien.CreateLinkKien(rs);
                out.println(lk);
            }
            out.println("</select>");
            
            //RAM
            sql = "select * from Ram";
            rs = statement.executeQuery(sql);
            
            out.print("<br>Ram:<br><select name=\"ram\">");
            while (rs.next()) {
                LinhKien lk = LinhKien.CreateLinkKien(rs);
                out.println(lk);
            }
            out.println("</select>");
            
            //Monitor
            sql = "select * from Monitor";
            rs = statement.executeQuery(sql);
            
            out.print("<br>Monitor:<br><select name=\"monitor\">");
            while (rs.next()) {
                LinhKien lk = LinhKien.CreateLinkKien(rs);
                out.println(lk);
            }
            out.println("</select>");
        %>
        <br>
        <input type="submit" value="Submit Query" />
        <input type="reset" value="Reset" />
        </form>
    </body>
</html>
