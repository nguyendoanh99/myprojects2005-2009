<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DatMuaSanPham.aspx.cs" Inherits="DatMuaSanPham" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type ="text/javascript" src = "He Khach/XL_DonHang.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_HTTT.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_HTKM.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_GioHang.js"></script>

    
    
    <div id="section1">
    <h2>ĐẶT MUA SẢN PHẨM
    </h2>  
    </div>
    <hr />
	
	<form id="form1">

    <div id="section7">
    <fieldset>
    <legend>Chi Tiết Đơn Hàng</legend>
	    <div id="Th_ds_san_pham"></div>
        <br />
        <div id="TongGiaTri"class="forminput">
            <div id="div_TGT1" class="formlabel"> <label>Tổng giá trị hàng mua</label> </div>
            <div id="div_TGT2" class="formlabefl_left"> </div> 
        </div>
            
        <div id="Div13"class="forminput">
                <div id="div14" class="formlabel"> <label>Thuế VAT (10%)</label> </div>
                <div id="div_Thue" class="formlabefl_left"></div> 
        </div> 
        
        <div id="Div5"class="forminput">
                <div id="div9" class="formlabel"> <label>Tổng tiền phải trả</label> </div>
                <div id="div_TT" class="formlabefl_left"></div> 
        </div> 
        
    </fieldset>
	</div>
	<hr />

     <div id="section4">
    <fieldset>
    <legend>Thông Tin Giao Hàng</legend>
    
        <div id="NguoiNhan" class="forminput">
            <div class="formlabel"> <label>Người nhận*</label> </div>
            <div class="formfield"> <input name="txtNguoiNhan" type="text" id="txtNguoiNhan" size="40"/></div>
        </div>
        
        <div id="DiaChiNhan" class="forminput">
            <div class="formlabel"> <label>Địa chỉ nhận*</label> </div>
            <div class="formfield"> <input name="txtDiaChiNhan" type="text" id="txtDiaChiNhan" size="40"/></div>
        </div>
        
        <div id="NgayGiaoHang" class="forminput">
            <div class="formlabel"> <label>Ngày giao hàng*</label> </div>
            <div class="formfield"> 
                <select id="cmbNgayGH"></select>
                <select id="cmbThangGH"></select>
                <select id="cmbNamGH"></select>
                   <script type="text/javascript">
                    XL_DonHang.LoadCmbNum('cmbNgayGH', 1, 31);
                    XL_DonHang.LoadCmbNum('cmbThangGH', 1, 12);
                    XL_DonHang.LoadCmbNum('cmbNamGH', 2008, 2010);
                </script>
            </div>
         </div>
         
        <div id="GioGiaoHang" class="forminput">
            <div class="formlabel"> <label>Giờ giao hàng*</label> </div>
            <div class="formfield"> 
                <select id="cmbGioGH"></select>
                <select id="cmbPhutGH"></select>
                <select id="cmbBuoiGH">
                    <option selected="selected" value="AM">am</option>
                    <option value="PM">pm</option>
                </select>
                   <script type="text/javascript">
                    XL_DonHang.LoadCmbNum('cmbGioGH', 1, 12);
                    XL_DonHang.LoadCmbNum('cmbPhutGH', 0, 59);
                </script>
            </div>
        </div>
    
    </fieldset>
    </div>
    <hr />
    
    <div>
    <fieldset>
        <legend></legend>
    <div class="forminput">
            <div class="formlabel"><label></label></div>
            <div class="formfield">
                <input type="button" id="btnQuayLai" value="Quay lại" onclick="return Button1_onclick()" />
                <input type="button" id="btnThanhToan" value="Đặt hàng" onclick="XL_DonHang.DatHang(-1)" />
                <input type="button" id="btnThoat" value="Thoát" onclick="XL_DonHang.Thoat()" />
            </div>  
             
    </div>
    </fieldset>
    </div>
    
    <input type="hidden" id="txtloaind" value="" runat="server"/>
    </form>

    <script type="text/javascript">
        nodeLoaiND = document.getElementById('<%=txtloaind.ClientID%>');
        //XL_DonHang.DsSanPham();
       
    </script>
</asp:Content>