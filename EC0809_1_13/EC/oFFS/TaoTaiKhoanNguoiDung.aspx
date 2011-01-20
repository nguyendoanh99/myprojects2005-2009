<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="TaoTaiKhoanNguoiDung.aspx.cs" Inherits="TaoTaiKhoanNguoiDung" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">  

    <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script language="javascript" type="text/javascript" src="He Khach/SHA1.js"></script>

    <script type="text/javascript">
    <asp:Literal ID="ltlAlert" runat="server" EnableViewState="false"></asp:Literal>
    </script>
    
    <div id="doc" class="yui-t7">
    
    <div id="hd">
    <p>&nbsp;</p>
    <p class="title">Đăng ký tài khoản người dùng</p>
    <p>*Các thông tin bắt buộc</p>
    </div>
    
    <hr />
    <div id="section1">
    <h2>ĐĂNG KÝ TÀI KHOẢN NGƯỜI DÙNG</h2>
    </div>
    
    <hr />
    
    <form id="form1" runat="server">
    <div>
        <div id="section2">
         <fieldset>
        <legend>Thông tin cá nhân </legend>
        <div id="LoaiNguoiDung" class="forminput">
            <div class="formlabel"> <label>Loại người dùng*</label> </div>
            <div class="formfield">  
                 <select id="cmbLoaiNguoiDung"></select>
                 <script type="text/javascript">
                    XL_NguoiDung.LoadLoaiNguoiDung('cmbLoaiNguoiDung');
                </script>
            </div>
         </div>
         
        <div id="HoTen" class="forminput">
            <div class="formlabel"> <label>Họ tên*</label> </div>
            <div class="formfield"> <input name="txtHoTen" type="text" id="txtHoTen" size="40"/></div>
         </div>
         
          <div id="NgaySinh" class="forminput">
            <div class="formlabel"> <label>Ngày sinh*</label> </div>
            <div class="formfield"> 
                <select id="cmbNgaySinh"></select>
                <select id="cmbThangSinh"></select>
                <select id="cmbNamSinh"></select>
                <script type="text/javascript">
                XL_NguoiDung.LoadCmbNum('cmbNgaySinh', 1, 30);
                XL_NguoiDung.LoadCmbNum('cmbThangSinh', 1, 12);
                XL_NguoiDung.LoadCmbNum('cmbNamSinh', 1930, 2000);
            </script>
            </div>
         </div>
         
       
        <div id="GioiTinh" class="forminput">
	    <div class="formlabel"><label>Giới tính*</label></div>
        <div class="formfield">
        <input type="radio" name="rdGioiTinh" id="optNam" value="optGioiTinh" checked="true" />
        <label for="optNam">Nam</label>
        <input type="radio" name="rdGioiTinh" id="optNu" value="optGioiTinh" />
        <label for="optNu">Nữ</label>
        </div>
	    </div>
        
        <div id="DiaChi" class="forminput">
            <div class="formlabel"> <label>Địa chỉ</label> </div>
            <div class="formfield"> <input name="txtDiaChi" type="text" id="txtDiaChi" size="40" value="Tan Phu"/></div>
         </div>
    	
        <div id="DienThoai" class="forminput">
            <div class="formlabel"> <label>Điện thoại</label> </div>
            <div class="formfield"> <input name="txtDienThoai" type="text" id="txtDienThoai" size="40" value="0978925960"/></div>
         </div>
         
          <div id="Email" class="forminput">
            <div class="formlabel"> <label>Email</label> *</div>
            <div class="formfield"> <input name="txtEmail" type="text" id="txtEmail" size="40" value="nv@yahoo.com"/></div>
         </div>

         <div id="KichHoat" class="forminput">
            <div class="formlabel"> <label>Tình trạng kích hoạt</label> *</div>
            <div class="formfield"> <input name="rdKichHoat" type="radio" id="optKichHoat" size="40" value="KichHoat" checked="true"/>
                                    <label for="optKichHoat">Yes</label>
                                    <input name="rdKichHoat" type="radio" id="optBiKhoa" size="40" value="BiKhoa"/>
                                    <label for="optBiKhoa">No</label>
            </div>
          </div>

        </fieldset>
        </div>
    
    <div id="section3">
        <fieldset>
        <legend>Thông tin tài khoản</legend>
        
        <div id="Account" class="forminput">
            <div class="formlabel"> <label>Tên đăng nhập</label>*</div>
            <div class="formfield"> <input name="txtAcc" type="text" id="txtAcc" style="width: 258px" size="40"/></div>
         </div>
         
        <div class="forminput">
          <div class="formlabel"><label>Mật khẩu*</label></div>
          <div class="formfield"><input type="password" name="txtPass" size="40" id="txtPass"/></div>
        </div>
        
        <div class="forminput">
            <div class="formlabel"><label>Gõ lại mật khẩu*</label></div>
            <div class="formfield">
              <input type="password" name="txtRePass" id="txtRePass" size="40" onchange="txtRePass_onChange()"/>
              <span class="formerror" id="errRePass" style="display:none">Please verify your password again</span>
             </div>
        </div>
        
        <div class="forminput">
            <div class="formlabel"><label></label></div>
            <div class="formfield">
               <input type="button" value="Thêm" onclick="ThemTaiKhoan()" id="Button1" /></div>           
        </div>
    
        </fieldset>
    </div>
       
    <div id="section4">
    <fieldset id="fsDSNguoiDung" style="display:none">
    <legend>Danh sách người dùng mới</legend>
    <div>
    <table id="hor-minimalist-b" summary="Danh sách món ăn đã thêm">
    <tbody id="tbodyDSNguoiDung">
        <tr>
            <td class="helpHed">STT</td>
            <td class="helpHed">Loại</td>
	        <td class="helpHed">Họ tên</td>
	        <td class="helpHed">Username</td>
	        <td class="helpHed">Email</td>
	        <td class="helpHed">Tình trạng kích hoạt</td>
        </tr>
    </tbody>
    </table>
    </div>
    </fieldset>
    </div>
    
    </div>
    
    </form>
    
    </div>
</asp:Content>
