<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DanhSachMonAnYeuThich.aspx.cs" Inherits="DanhSachMonAnYeuThich" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    
    <h1 style="text-align: center">DANH SÁCH MÓN ĂN YÊU THÍCH</h1>
    <table class="tborder" id="tablePhanTrang" cellspacing="5" cellpadding="3">
    <tbody id="tbodyPhanTrang">
        
    </tbody>
    </table>
    <table id="hor-minimalist-b" summary="Danh sách món ăn">
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
    <tbody id="tbodyDSMonAn">
    </tbody>
    </table>
</asp:Content>