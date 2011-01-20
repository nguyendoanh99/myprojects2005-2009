<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="ThemThucDonMoi.aspx.cs" Inherits="ThemThucDonMoi" %>

<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1"%>
    
 
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="He Khach/XL_ThucDon.js"></script>
    
    <div id="doc" class="yui-t7">
    <div id="section1">
    <h2>THÊM THỰC ĐƠN MỚI
    </h2>  
    </div>    
    <hr />
    
    <form id="form1" runat="server">
    <input type="hidden" name="txtHinhAnh" id="txtHinhAnh" value="" runat="server"/>
    
    <div id="section2">
         <fieldset>
    <legend></legend>
    
     <div id="div_TenThucDon" class="forminput">
        <div class="formlabel"> <label>Tên thực đơn</label>&nbsp;</div>
        <div class="formfield"> <input name="txtTenThucDon" type="text" id="txtTenThucDon" size="40" value="Thực đơn test"/></div>
     </div> 
        
     <div id="div_LoaiThucDon" class="forminput">
	    <div class="formlabel"><label>Loại thực đơn</label></div>
        <div class="formfield">
            <asp:DropDownList ID="cmbLoaiThucDon" runat="server">
            </asp:DropDownList></div>
	 </div>    
	 
	 <div id="UploadHinhAnh" class="forminput">
        <div class="formlabel"> <label>URL hình ảnh </label> </div>
        <div class="formfield"> &nbsp;
            <asp:FileUpload ID="FileUpload1" runat="server" Width="323px" /></div>
     </div>
     
     <div id="div2" class="forminput">
	    <div class="formlabel"><label>Mô tả</label></div>
        <div class="formfield"><textarea name="txtMoTa" id="txtMoTa" size="40" style="width: 332px; height: 113px"></textarea></div>
	 </div>    
	 
     <div id="div1" class="forminput">
	    <div class="formlabel"><label>Giá</label></div>
        <div class="formfield"><input name="txtGia" type="text" readonly id="txtGia" size="20" value="0"/>
                                <label id="lblTiLeGiam">Tỉ lệ giảm : </label>
        </div>
	 </div>    
	
	 <div id="TinhTrang" class="forminput">
        <div class="formlabel"> <label>Tình trạng</label> </div>
        <div class="formfield"> <input name="rdTinhTrang" type="radio" checked id="optCon" size="20" value="Con"/>Còn 
                                <input name="rdTinhTrang" type="radio" id="optHet" size="20" value="Het"/>Hết
        </div>
     </div>
     
     <div id="TrangThaiHienThi" class="forminput">
        <div class="formlabel"> <label>Trạng thái hiển thị</label> </div>
        <div class="formfield"> <input name="rdHienThi" type="radio" checked id="optHien" size="20" value="HienThi"/>Hiển thị 
                                <input name="rdHienThi" type="radio" id="optAn" size="20"  value="An"/>Ẩn
        </div>
     </div>
	 
	  <div id="div3" class="forminput">
	    <div class="formlabel"><label>Tag</label></div>
        <div class="formfield"><input name="txtTag" type="text" id="txtTag" size="40" value=""/></div>
	 </div>    
	 
     <div id="div_Button" class="forminput">
        <div class="formlabel"> <label></label> </div>
        <div class="formfield"> 
            <asp:Button ID="Button1" runat="server" OnClientClick="XL_ThucDon.ThemThucDonMoi()" OnClick="Button1_Click" Text="Thêm" />
            <input name="btnKhoiTao" type="button" id="btnKhoiTao" value="Khởi tạo" onclick="XL_ThucDon.KhoiTao()"/></div>
     </div>

    </fieldset>
    <table id="hor-minimalist-a" summary="Danh sách các món được chọn" style="display:none">
    <thead>
    <tr>
            <th>STT</th>
	        <th>Tên món</th>
	        <th>Hình ảnh</th>
	        <th>Giá</th>
	        <th>Bỏ</th>
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
                XL_ThucDon.LayDSMonAnHienThi(1);
                XL_ThucDon.PhanTrang();
                XL_ThucDon.LayTiLeGiamGiaThucDon();
                
                objCmbLoaiThucDon = document.getElementById('<%=cmbLoaiThucDon.ClientID%>');
                objTxtPathHinhAnh = document.getElementById('<%=FileUpload1.ClientID%>');
            </script>
        
    </div>
    
    </form>
    </div>
 </asp:Content>