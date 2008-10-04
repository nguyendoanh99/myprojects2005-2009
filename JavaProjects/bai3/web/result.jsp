<%-- 
    Document   : result
    Created on : Oct 4, 2008, 12:33:46 PM
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
        <%
            String name = request.getParameter("name");
            String phone = request.getParameter("phone");
            String address = request.getParameter("address");

            String sql = "select max(MaHD) from HoaDon";

            ResultSet rs = statement.executeQuery(sql);
            rs.next();
            int max = rs.getInt(1);
            int maHD = max + 1;

            // Tinh tong tien
            int tongTien = 0;

            String maCPU = request.getParameter("cpu");
            String maRam = request.getParameter("ram");
            String maMonitor = request.getParameter("monitor");

            // CPU
            sql = "select * from CPU where MaSo ='" + maCPU + "'";
            rs = statement.executeQuery(sql);
            rs.next();
            LinhKien cpu = LinhKien.CreateLinkKien(rs);
            // Ram
            sql = "select * from Ram where MaSo ='" + maRam + "'";
            rs = statement.executeQuery(sql);
            rs.next();
            LinhKien ram = LinhKien.CreateLinkKien(rs);
            // Monitor
            sql = "select * from Monitor where MaSo ='" + maMonitor + "'";
            rs = statement.executeQuery(sql);
            rs.next();
            LinhKien monitor = LinhKien.CreateLinkKien(rs);

            tongTien += cpu.getGiaTien() + ram.getGiaTien() + monitor.getGiaTien();

            // Ghi du lieu
//            sql = "insert into HoaDon(MaHD, TenKH, DiaChi, DienThoai, GiaTien, MaCPU, MaRAM, MaMonitor) values ('" +
//                    maHD + "','" + name + "','" + address + "','" + phone + "','" + tongTien + "','" +
//                    maCPU + "','" + maRam + "','" + maMonitor + "')";
            sql = "insert into HoaDon(MaHD, TenKH, DiaChi, DienThoai, GiaTien, MaCPU, MaRAM, MaMonitor) " +
                    "values (?, ?, ?, ?, ?, ?, ?, ?)";
            PreparedStatement ps = con.prepareStatement(sql);
            ps.setInt(1, maHD);
            ps.setString(2, name);
            ps.setString(3, address);
            ps.setString(4, phone);
            ps.setInt(5, tongTien);
            ps.setString(6, maCPU);
            ps.setString(7, maRam);
            ps.setString(8, maMonitor);
            ps.executeUpdate();
//            statement.executeUpdate(sql);
//            statement = con.createStatement();

            con.close();
        %>
        <h1>Cam on ban da mua hang</h1><br>
        <h2>Phieu mua hang cua ban da duoc ghi nhan vao CSDL</h2>
        Ho ten: <%=name%><br>
        Dia chi: <%=address%><br>
        Ma DDH cua ban: <%=maHD%><br>
        Chi tiet cac mat hang da mua<br>
        <ul>
            <li>CPU: <%=cpu.getTen()%> - <%=cpu.getGiaTien()%> USD</li>
            <li>RAM: <%=ram.getTen()%> - <%=ram.getGiaTien()%> USD</li>
            <li>Monitor: <%=monitor.getTen()%> - <%=monitor.getGiaTien()%> USD</li>
            <dl><dd>Thanh tien: <%=tongTien%></dd></dl>
        </ul>
        
    </body>
</html>
