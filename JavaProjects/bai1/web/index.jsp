<%-- 
    Document   : index
    Created on : Oct 2, 2008, 1:38:29 PM
    Author     : Nguyen Dang Khoa
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@ page import="java.sql.*" %>
<%@ page import="java.lang.*" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
            String driverName = "sun.jdbc.odbc.JdbcOdbcDriver";
            // Load the driver
            try {
                Class.forName(driverName);
            } catch (ClassNotFoundException e) {
                System.out.printf("Error loading driver: " + e.toString());
            }

            // Establish the connection
            String url = "jdbc:odbc:bai1";
            Connection con = DriverManager.getConnection(url);
        %>
        
                
        <form method="GET" action="result.jsp">
            Ho ten: <input type="text" name="name" value="" /><br>
            Dien thoai: <input type="text" name="phone" value="" /><br>
            Danh sach cac cau hoi: <br>
            <%
            String sql = "select * from CauHoi";
            Statement statement = con.createStatement();
            ResultSet rs = statement.executeQuery(sql);

            int count = 0;
            while (rs.next()) {
                String sNoiDung = rs.getString("NoiDung");
                String sMaCauHoi = rs.getString("MaCauHoi");
                String[] arrLuaChon = new String[4];
                // Lay cau hoi
                for (int i = 0; i < arrLuaChon.length; ++i) {
                    arrLuaChon[i] = rs.getString("LuaChon" + String.valueOf(i + 1));
                }

                // Ket xuat ra html
                count++;
                out.print("Cau hoi " + count + ":<br>");
                out.print(sNoiDung + "<br>");
                for (int i = 0; i < arrLuaChon.length; ++i) {
                    if (i == 0) {
                        out.print("<input type=\"radio\" name=\"" + sMaCauHoi + "\" value=\"" + String.valueOf(i + 1) + "\" checked=\"true\"/>" + arrLuaChon[i]);
                    } else {
                        out.print("<input type=\"radio\" name=\"" + sMaCauHoi + "\" value=\"" + String.valueOf(i + 1) + "\"/>" + arrLuaChon[i]);
                    }
                    out.print("<br>");
                }
            }
            %>
            <input type="submit" value="Submit" />
        </form>
        
    </body>
</html>
