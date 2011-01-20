<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DanhSachThucDonYeuThich.aspx.cs" Inherits="DanhSachThucDonYeuThich" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    
    
    <h1 style="text-align: center">DANH SÁCH THỰC ĐƠN YÊU THÍCH</h1>
    <table class="tborder" id="tablePhanTrang" cellspacing="5" cellpadding="3">
    <tbody id="tbodyPhanTrang">
        
    </tbody>
    </table>
    <table id="hor-minimalist-b">
    <thead>
    <tr>
            <th></th>
            <th>STT</th>
	        <th>Tên</th>
	        <th>Hình ảnh</th>
	        <th>Giá</th>
	        <th>Còn</th>
	        <th>Điểm</th>
	        <th>Mua</th>
	        <th>Bỏ</th>
        </tr>
    </thead>
    <tbody id="tbodyDSThucDon">
    </tbody>
    </table>
</asp:Content>