<%@ Page Language="C#"  MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DKTaiKhoan.aspx.cs" Inherits="DKTaiKhoan" %>



<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script language="javascript" type="text/javascript" src="He Khach/XL_The.js"></script>
    <script language="javascript" type="text/javascript" src="He Khach/SHA1.js"></script>
    
    <script type="text/javascript">
    <asp:Literal ID="ltlAlert" runat="server" EnableViewState="false"></asp:Literal>
    document.getElementById('pathway').innerHTML += 'Dang Ky Tai Khoan';
    </script>
    
   
    
    <div id="doc" class="yui-t7">
    
    <div id="hd">
    <p>&nbsp;</p>
    <p class="title">Đăng ký</p>
    <p>*Các thông tin bắt buộc</p>
    </div>

    <hr />
    
    <div id="section1">
    <h2>ĐĂNG KÝ TÀI KHOẢN
    </h2>  
    </div>
    <hr />

    <form id="form1">
    <div id="section2">
     <fieldset>
    <legend>Thông tin cá nhân </legend>
    <div id="HoTen" class="forminput">
        <div class="formlabel"> <label>Họ tên*</label> </div>
        <div class="formfield"> <input name="txtHoTen" type="text" id="txtHoTen" size="40"  value="Nguyễn Văn A"/></div>
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
        <div class="formfield"> <input name="txtDiaChi" type="text" id="txtDiaChi" size="40" value="213 Nguyễn Duy"/></div>
     </div>
	
    <div id="DienThoai" class="forminput">
        <div class="formlabel"> <label>Điện thoại</label> </div>
        <div class="formfield"> <input name="txtDienThoai" type="text" id="txtDienThoai" size="40" value="0909534838"/></div>
     </div>
     
      <div id="Email" class="forminput">
        <div class="formlabel"> <label>Email</label> *</div>
        <div class="formfield"> <input name="txtEmail" type="text" id="txtEmail" size="40"  value="nva@yahoo.com"/></div>
     </div>

    <div class="forminput">
        <div class="formlabel">&nbsp;</div>
        <div class="formhint">Vd : offs@yahoo.com</div>
    </div>

</fieldset>
    </div>

    <hr />
    
    <div id="section3">
        <fieldset>
        <legend>Thông tin tài khoản</legend>
        <div id="Account" class="forminput">
            <div class="formlabel"> <label>Tên đăng nhập</label>*</div>
            <div class="formfield"> <input name="txtAcc" type="text" id="txtAcc"  style="width: 258px" value="kh" size="40"/></div>
             </div>
        <div class="forminput">
          <div class="formlabel"><label>Mật khẩu*
          </label></div>
          <div class="formfield"><input type="password"  name="txtPass" size="40" id="txtPass"/></div>
        </div>
        <div class="forminput">
            <div class="formlabel"><label>Gõ lại mật khẩu*</label></div>
            <div class="formfield">
              <input type="password" name="txtRePass" id="txtRePass" size="40"  onchange="txtRePass_onChange()"/>
              <span class="formerror" id="errRePass">Mật khẩu gõ lại không chính xác</span>
        
            </div>
        </div>
        </fieldset>
    </div>

    <hr />

    <div id="section4">
        <fieldset>

    <legend>Thông tin thẻ tín dụng</legend>
    <div id="Div1" class="forminput">
        <div class="formlabel"> <label>Loại thẻ</label> *</div>
        <div class="formfield"> 
            <select id="cmbLoaiThe"></select>
               <script type="text/javascript">
                XL_NguoiDung.LoadLoaiThe('cmbLoaiThe');
            </script>
        </div>
         </div>
    <div class="forminput">
      <div class="formlabel"><label>Mã số thẻ*
      </label></div>
      <div class="formfield"><input type="text" name="txtMaThe" id="txtMaThe"  value="5101385022504098" style="width: 259px"/></div>
    </div>

    <div id="NgayHetHan" class="forminput">
            <div class="formlabel"> <label>Ngày hết hạn</label> *</div>
            <div class="formfield"> 
        	     <select id="cmbNgayHH"></select>
                <select id="cmbThangHH"></select>
                <select id="cmbNamHH"></select>
                   <script type="text/javascript">
                    XL_NguoiDung.LoadCmbNum('cmbNgayHH', 1, 30);
                    XL_NguoiDung.LoadCmbNum('cmbThangHH', 1, 12);
                    XL_NguoiDung.LoadCmbNum('cmbNamHH', 2008, 2020);
            </script>
          	
            </div>
         </div>
    </fieldset>
    </div>

    <hr />
    <div id="section5">
        <fieldset>
        <legend>Xác nhận</legend>
        <div class="forminput">
            <div class="formlabel"><label>Hình ảnh :</label></div>
            <div class="formfield">
            <img alt="" src="CaptchaImage/JpegImage.aspx" />
            <!--
            <table border="0">
    	        <tr>
    		        <td id="txtRandomNum" class="formpicture" width="250"></td>
                    <td>
                    <img alt="" src="JpegImage.aspx" /><br />
                    <img src="refresh_icon.gif" style="position:relative; left:10px; " onclick="generateRandomNum()"/></td>
                </tr>
            </table>
            -->
            </div>

        </div>
        <div class="forminput">
            <div class="formlabel"><label>Đánh vào mã số trong hình</label></div>
            <div class="formfield">
              <input type="text" name="txtCode" id="txtCode" style="width: 261px" />
            </div>
        </div>

        </fieldset>
    </div>
    
    <div>
    <fieldset>
        <legend></legend>
    <div class="forminput">
            <div class="formlabel"><label></label></div>
            <div class="formfield">
                &nbsp;<input type="button" id="btnThem" value="Đồng ý" onclick="XL_NguoiDung.ThemKhachHang()" /></div>
            
    </div>
    </fieldset>
    </div>
    </form>
    </div>
    
 </asp:Content>
