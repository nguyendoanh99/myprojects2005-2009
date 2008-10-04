<%-- 
    Document   : result
    Created on : Oct 3, 2008, 10:39:26 AM
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
        %>
        
        <%
            String name = request.getParameter("name");
            String phone = request.getParameter("phone");
            String address = request.getParameter("address");

            String sql = "select max(MaDDH) from DDH";
            Statement statement = con.createStatement();
            ResultSet rs = statement.executeQuery(sql);
            rs.next();
            int max = rs.getInt(1);
            int maDDH = max + 1;

            // Them don dat hang
            int tongTien = 0;
            sql = "insert into DDH(MaDDH, HoTen, DienThoai, DiaChi) values ('" +
                    maDDH + "','" + name + "','" + phone + "','" + address + "')";

            statement.executeUpdate(sql);
            statement = con.createStatement();

            // Chi tiet don dat hang            
            String strChiTiet = "<ul>"; // Chuoi html

            sql = "select * from MatHang";
            rs = statement.executeQuery(sql);
            statement = con.createStatement();

            while (rs.next()) {
                MatHang mh = MatHang.CreateMatHang(rs);
                String maMH = String.valueOf(mh.getMaMH());

                if (request.getParameter(maMH) != null) {
                    int donGia = mh.getDonGia();
                    int soLuong = 1;
                    int thanhTien = donGia * soLuong;
                    String tenMH = mh.getTenMH();

                    sql = "insert into ChiTiet(MaDDH, MaMH, SoLuong, ThanhTien) values ('" +
                            maDDH + "','" + maMH + "','" + soLuong + "','" + thanhTien + "')";
                    statement.executeUpdate(sql);
                    statement = con.createStatement();

                    // chuoi html
                    strChiTiet += "<li>" + tenMH + ": " + donGia + "</li>";

                    // Tong tien
                    tongTien += thanhTien;
                }
            }
            
            // Cap nhat tong tien
            sql = "update DDH set ThanhTien='" + tongTien + "' where MaDDH=" + maDDH + "";
            statement.executeUpdate(sql);
            statement = con.createStatement();

            strChiTiet += "<dl><dd>Thanh tien: " + tongTien + "</dd></dl>";
            strChiTiet += "</ul>";
            con.close();
        %>
        <h1> Cam on ban da mua hang</h1>
        <h2> Phieu mua hang cua ban da duoc ghi nhan vao CSDL </h2>
        Ho ten: <%=name%><br>
        Dia chi: <%=address%><br>
        Ma DDH cua ban: <%=maDDH%><br>
        Chi tiet cac mat hang da mua<br>
        <%=strChiTiet%>
    </body>
</html>
