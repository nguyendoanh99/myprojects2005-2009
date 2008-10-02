<%-- 
    Document   : result
    Created on : Oct 2, 2008, 3:17:20 PM
    Author     : Nguyen Dang Khoa
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="java.lang.*"%>
<%@ page import="java.sql.*" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN"
"http://www.w3.org/TR/html4/loose.dtd">

<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <%
            String className = "sun.jdbc.odbc.JdbcOdbcDriver";
            // Load the driver
            try {
                Class.forName(className);
            } catch (ClassNotFoundException e) {
                out.print("Error loading driver: " + e.toString());
            }

            // Establish the connection
            String url = "jdbc:odbc:bai1";
            Connection con = DriverManager.getConnection(url);

            // Get name, phone
            String name = request.getParameter("name");
            String phone = request.getParameter("phone");

            // Create MaPhieuTL
            String sql = "select max(MaPhieuTL) from PhieuTraLoi";
            Statement statement = con.createStatement();
            ResultSet rs = statement.executeQuery(sql);
            rs.next();
            int max = Integer.valueOf(rs.getString(1));
            int maPhieuTL = max + 1;

            // Write Answers to Database
            sql = "insert into PhieuTraLoi (MaPhieuTL, HoTen, DienThoai) values ('" +
                    maPhieuTL + "','" + name + "','" + phone + "')";
            statement.executeUpdate(sql);

            sql = "select * from CauHoi";
            statement = con.createStatement();
            rs = statement.executeQuery(sql);
            while (rs.next()) {
                String maCauHoi = rs.getString("MaCauHoi");
                String answer = request.getParameter(maCauHoi);

                sql = "insert into ChiTietTL (MaPhieuTL, MaCauHoi, LuaChon) values ('" +
                        maPhieuTL + "','" + maCauHoi + "','" + answer + "')";
                statement = con.createStatement();
                statement.executeUpdate(sql);
            }
        %>
        <h1>Xin cam on cac ban da tra loi cau hoi</h1><br>     
        <h2>Phieu tra loi cua ban da duoc ghi nhan vao CSDL</h2>
        <br>
        Ho ten: <%=request.getParameter("name")%> <br>
        Dien thoai: <%=request.getParameter("phone")%> <br>
        Ma phieu Tra loi cua ban: <%=maPhieuTL%><br>
        Chi tiet Phieu Tra loi:<br>
        <%
            int count = 0;
            sql = "select * from CauHoi";
            statement = con.createStatement();
            rs = statement.executeQuery(sql);

            while (rs.next()) {
                count++;
                String maCauHoi = rs.getString("MaCauHoi");
                String content = rs.getString("Noidung");
                String choice = "Luachon" + request.getParameter(maCauHoi);
                String answer = rs.getString(choice);

                // Ket xuat ra html
                out.println("Cau hoi " + count + ": " + content + "<br>");
                out.println("Tra loi: " + answer + "<br>");
            }
            con.close();
        %>
    </body>
</html>
