<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="XemThongTinCaNhan.aspx.cs" Inherits="XemThongTinCaNhan" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script type="text/javascript">
    document.getElementById('pathway').innerHTML += 'Thong Tin Ca Nhan';
    </script>
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
        <div class="formedit"><a href="CapNhatThongTinCaNhan.aspx">Cập nhật</a></div>
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
            <div id="div_MatKhau2" class="formlabel_left"> <a href="CapNhatThongTinMatKhau.aspx">Thay đổi mật khẩu</a> </div>
        </div><br />
   </fieldset>
   </div>
   <hr />   

   <div id="section4">
   <fieldset>
        <legend>Thông Tin Thẻ Tín Dụng</legend>
        <div class="forminput">
            <div id="div_LoaiThe1" class="formlabel"> <label>Loại thẻ:</label> </div>
            <div id="div_LoaiThe2" class="formlabel_left"> <asp:label ID="lb_LoaiThe" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_MaSoThe1" class="formlabel"> <label>Số thẻ:</label> </div>
            <div id="div_MaSoThe2" class="formlabel_left"> <asp:label ID="lb_SoThe" runat="server"/> </div>
        </div><br />
        <div class="forminput">
            <div id="div_NgayHetHan1" class="formlabel"> <label>Ngày hết hạn:</label> </div>
            <div id="div_NgayHetHan2" class="formlabel_left"> <asp:label ID="lb_NgayHetHan" runat="server"/> </div>
        </div><br />
        <div class="formedit"><a href="CapNhatThongTinTheTinDung.aspx">Cập nhật</a></div>
   </fieldset>
   </div>
   <hr />   
   
   <div id="section5">
   <fieldset>
        <legend>Thông Tin Khuyến Mãi</legend>
        <div class="forminput">
            <div id="div_DiemKhuyenMai1" class="formlabel"> <label>Điểm khuyến mãi:</label> </div>
            <div id="div_DiemKhuyenMai2" class="formlabel_left"> <asp:label ID="lb_DiemKhuyenMai" runat="server"/> </div>
        </div><br />
   </fieldset>
   </div>
   <hr />   
</div>
</asp:Content>