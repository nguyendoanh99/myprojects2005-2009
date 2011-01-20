<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="ThemMonMoi.aspx.cs" Inherits="ThemMonMoi" %>

<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1" %>
    
    
    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="He Khach/XL_MonAn.js"></script>
    <script type="text/javascript" src="He Khach/XL_LoaiMon.js"></script>
        
    <script type="text/javascript">
    <asp:Literal ID="ltlAlert" runat="server" EnableViewState="false"></asp:Literal>
    </script>
    
    <div id="doc" class="yui-t7">
    <div id="section1">
    <h2>THÊM MÓN MỚI
    </h2>  
    </div>
    
    <hr />
    
    <form id="form1" runat="server" method="post" action="">
    <input type="hidden" name="txtHinhAnh" id="txtHinhAnh" runat="server" value=""/>
    
    <div id="section2">
         <fieldset>
    <legend>Thông tin món ăn</legend>
    <div id="TenMon" class="forminput">
        <div class="formlabel"> <label>Tên món</label> </div>
        <div class="formfield"> <input name="txtTenMon" type="text" id="txtTenMon11" size="40"/></div>
     </div>    
     <div id="LoaiMon" class="forminput">
	    <div class="formlabel"><label>Loại món</label></div>
        <div class="formfield">
            <select id="cmbLoaiMon" ></select>
            <br />
            <script type="text/javascript">XL_LoaiMon.LoadDSLoaiMonLa('cmbLoaiMon')</script>
    </div>
        <div class="formlabel" id="DIV1" > <label>URL hình ảnh </label> </div>
        </div>	
             <asp:FileUpload ID="FileUpload1" runat="server" Width="266px" /><br />
     
    <div id="MoTa" class="forminput">
        <div class="formfield">
	    <div class="formlabel"><label>Mô tả</label></div>
        <textarea name="txtMoTa" id="txtMoTa" size="40"  cols="30" rows="3"></textarea></div>
	</div>   
	
    <div id="DonViTinh" class="forminput">
        <div class="formlabel"> <label>Đơn vị tính</label> </div>
        <div class="formfield"> 
            <select id="cmbDonViTinh" ></select>
            <script type="text/javascript">
                XL_MON_AN.LoadDSDonViTinh('cmbDonViTinh');
            </script>
        </div>
     </div>
     
    <div id="Gia" class="forminput">
        <div class="formlabel"> <label>Giá</label> </div>
        <div class="formfield"> <input name="txtGia" type="text" id="txtGia" size="20"/> VND/đơn vị</div>
     </div>
     <div id="TinhTrang" class="forminput">
        <div class="formlabel"> <label>Tình trạng</label> </div>
        <div class="formfield"> <input name="rdTinhTrang" type="radio" id="optCon" checked="checked" size="20" value="Con"/>Còn 
                                <input name="rdTinhTrang" type="radio" id="optHet" size="20" value="Het"/>Hết
        </div>
     </div>
     <div id="TrangThaiHienThi" class="forminput">
        <div class="formlabel"> <label>Trạng thái hiển thị</label> </div>
        <div class="formfield"> <input name="rdHienThi" type="radio" id="optHien" checked="checked" size="20" value="HienThi"/>Hiển thị 
                                <input name="rdHienThi" type="radio" id="optAn" size="20"  value="An"/>Ẩn
        </div>
     </div>
     <div id="Tag" class="forminput">
        <div class="formlabel"> <label>Tag</label> </div>
        <div class="formfield"> <input name="txtTag" type="text" id="txtTag" size="40"/></div>
     </div>
     <div id="Button" class="forminput">
        <div class="formlabel"> <label></label> </div>
        <div class="formfield"> 
            <asp:Button ID="Button1" runat="server" OnClientClick="XL_MON_AN.ThemMonMoi()" OnClick="Button1_Click1" Text="Thêm" />
            <input name="btnKhoiTao" type="button" id="btnKhoiTao" value="Khởi tạo" onclick="XL_MON_AN.KhoiTao()"/></div>
     </div>
    </fieldset>
    </div>
    
    <!--<fieldset>
    <legend>Danh sách món ăn vừa thêm</legend>
    <div>
    <table id="hor-minimalist-b" summary="Danh sách món ăn đã thêm" class="sofT" cellspacing="0" align="center">
    <tbody id="tbodyDSMon">
        <tr>
            <td class="helpHed" style="height: 15px">STT</td>
	        <td class="helpHed" style="height: 15px">Hình ảnh</td>
	        <td class="helpHed" style="height: 15px">Tên món</td>
	        <td class="helpHed" style="height: 15px">Loại món</td>
	        <td class="helpHed" style="height: 15px">Đơn giá</td>
	        <td class="helpHed" style="height: 15px">Tình trạng</td>
	        <td class="helpHed" style="height: 15px">Trạng thái hiển thị</td>
        </tr>
        </tbody>
        </table>
    </div>
    </fieldset>-->
    
    <script type="text/javascript">
        nodePathHinhAnh = document.getElementById('<%=FileUpload1.ClientID%>');
    </script>
    </form>
    </div>
</asp:Content>