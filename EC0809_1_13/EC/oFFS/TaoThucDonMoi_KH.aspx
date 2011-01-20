<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="TaoThucDonMoi_KH.aspx.cs" Inherits="TaoThucDonMoi_KH" %>


<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1"%>
    
 
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="He Khach/XL_ThucDonCaNhan.js"></script>
    <script type="text/javascript" src="He Khach/XL_ThucDon.js"></script>
    <script type="text/javascript" src="He Khach/XL_MonAn.js"></script>
    
    <div id="doc" class="yui-t7">
    <hr />
    <div id="section1">
    <h2>TỰ TẠO THỰC ĐƠN CÁ NHÂN
    </h2>  
    </div>
    
    <hr />
    
    <form id="form1">
    
    
    <div id="section2">
         <fieldset>
    <legend></legend>
    
     <div id="div_TenThucDon" class="forminput">
        <div class="formlabel"> <label>Tên thực đơn</label>&nbsp;</div>
        <div class="formfield"> <input name="txtTenThucDon" type="text" id="txtTenThucDon" size="40" value="Thực đơn test"/></div>
     </div> 
        
     <div id="div1" class="forminput">
	    <div class="formlabel"><label>Giá</label></div>
        <div class="formfield"><input name="txtGia" type="text" readonly id="txtGia" size="20" value="0"/>
        </div>
	 </div>    
	 
     <div id="div_Button" class="forminput">
        <div class="formlabel"> <label></label> </div>
        <div class="formfield"> <input name="btnDongY" type="button" id="btnDongY" value="Thêm" onclick="XL_ThucDonCaNhan.ThemThucDonMoi()"/>
            <input name="btnKhoiTao" type="button" id="btnKhoiTao" value="Khởi tạo" onclick="XL_ThucDonCaNhan.KhoiTao()"/></div>
     </div>

    </fieldset>
    
    <table id="hor-minimalist-a" summary="Danh sách các món được chọn" style="display:none">
    <thead>
    <tr>
            <th>STT</th>
	        <th>Tên món</th>
	        <th>Hình ảnh</th>
	        <th>Giá</th>
        </tr>
    </thead>
    <tbody id="tbodyDSMonAnChon">
       
    </tbody>
    </table>
    
    <table class="tborder" id="tablePhanTrang" cellspacing="5" cellpadding="3">
    <tbody id="tbodyPhanTrang">
        
    </tbody>
    </table>
    </div>
    
    <div id="divDsNguoiDung" class="yui-skin-sam">
    <table id="hor-minimalist-b" summary="Danh sách món ăn">
    <thead>
    <tr>
            <th>STT</th>
	        <th>Tên món</th>
	        <th>Hình ảnh</th>
	        <th>Mô tả</th>
	        <th>Giá</th>
	        <th>Còn</th>
	        <th>Điểm bình chọn</th>
	        <th>Chọn</th>
        </tr>
    </thead>
    <tbody id="tbodyDSMonAnHienThi">
       
    </tbody>
    </table>
            <script type="text/javascript">
                XL_ThucDonCaNhan.LayDSMonAnHienThi(1);
                XL_ThucDonCaNhan.PhanTrang();
                //XL_ThucDonCaNhan.LoadDSMonChonTuThucDonCoSan(13);
            </script>
        
    </div>
    
    </form>
    </div>
 </asp:Content>