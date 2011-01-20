<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="QTXemThongTinCaNhan.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    
    <div id="doc" class="yui-t7">
    <hr />
    
   <div id="section1">
        <h2>XEM THÔNG TIN CÁ NHÂN</h2>
   </div>
   <hr />
   
   <div id="section2">
   <fieldset>
        <legend>Thông Tin Cá Nhân</legend>
        <div class="forminput">
            <div id="div_HoTen1" class="formlabel"> <label>Họ tên:</label> </div>
            <div class="formlabel_left"> <asp:label id="lb_HoTen" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_NgaySinh1" class="formlabel"> <label>Ngày sinh:</label> </div>
            <div class="formlabel_left"> <asp:label id="lb_NgaySinh" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_GioiTinh1" class="formlabel"> <label>Giới tính:</label> </div>
            <div id="div_GioiTinh2" class="formlabel_left"> <asp:label ID="lb_GioiTinh" runat="server"/> </div>
        </div><br />
         <div class="forminput">
            <div id="div_DiaChi1" class="formlabel"> <label>Địa chỉ:</label> </div>
            <div id="div_DiaChi2" class="formlabel_left"> <asp:label ID="lb_DiaChi" runat="server"/> </div>
        </div><br />
         <div class="forminput">
            <div id="div_DienThoai1" class="formlabel"> <label>Điện thoại:</label> </div>
            <div id="div_DienThoai2" class="formlabel_left"> <asp:label ID="lb_DienThoai" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_Email1" class="formlabel"> <label>Email:</label> </div>
            <div id="div_Email2" class="formlabel_left"> <asp:label ID="lb_Email" runat="server"/> </div>
        </div><br />
        <div class="formedit"><a href="QTCapNhatThongTinCaNhan.aspx">Cập nhật</a></div>
   </fieldset>
   </div>
   <hr />
   
   <div id="section3">
   <fieldset>
        <legend>Thông Tin Tài Khoản</legend>
        <div class="forminput">
            <div id="div_TenDangNhap1" class="formlabel"> <label>Tên đăng nhập:</label> </div>
            <div id="div_TenDangNhap2" class="formlabel_left"> <asp:label ID="lb_TenDangNhap" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_MatKhau1" class="formlabel"> <label>Mật khẩu:</label> </div>
            <div id="div_MatKhau2" class="formlabel_left"> <a href="QTCapNhatThongTinMatKhau.aspx">Thay đổi mật khẩu</a> </div>
        </div><br />
   </fieldset>
   </div>
   <hr />   

</div>
</asp:Content>

