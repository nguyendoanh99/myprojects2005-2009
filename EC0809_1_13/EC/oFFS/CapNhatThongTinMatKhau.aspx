<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="CapNhatThongTinMatKhau.aspx.cs" Inherits="CapNhatMatKhau" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script language="javascript" type="text/javascript" src="He Khach/SHA1.js"></script>
    
    <script type="text/javascript">
        document.getElementById('pathway').innerHTML += 'Cập nhật mật khẩu';
    </script>
    
<div id="doc" class="yui-t7">
   
    <hr />
   <div id="section1">
        <h2>CẬP NHẬT THÔNG TIN MẬT KHẨU</h2>
   </div>
   <hr />
   
   <div id="section2">
   <fieldset>
        <div class="forminput">
            <div class="formlabel"> <label>Nhập mật khẩu hiện tại:</label> </div>
            <div class="formfield"> <input type="password" id="txt_MatKhauHT" size="40"/> </div>
        </div>
        <div class="forminput">
            <div class="formlabel"> <label>Nhập mật khẩu mới:</label> </div>
            <div class="formfield"> <input type="password" id="txt_MatKhauM" size="40"/> </div>
        </div>
        <div class="forminput">
            <div class="formlabel"> <label>Nhập lại mật khẩu mới:</label> </div>
            <div class="formfield"> <input type="password" id="txt_MatKhauMNL" size="40"/> </div>
        </div>
        <div class="forminput">
            <div class="formfield"><center>
                <input type="button" id="but_Luu" value="Lưu" onclick="CapNhatThongTinMatKhau(0)"/>
                <input type="button" id="but_Thoat" value="Trở về" onclick="window.location='XemThongTinCaNhan.aspx?t='+new Date().getTime()"/>
            </center></div>
        </div>
   </fieldset>
   </div>
   
</div>
</asp:Content>