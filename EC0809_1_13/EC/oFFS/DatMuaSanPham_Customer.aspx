<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DatMuaSanPham_Customer.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="UserControl/ThongTinGioHang.ascx" TagName="ThongTinGioHang" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type ="text/javascript" src = "He Khach/XL_DonHang.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_HTTT.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_HTKM.js"></script>
    <script type ="text/javascript" src = "He Khach/XL_GioHang.js"></script>
    <script type="text/javascript" src="He Khach/SHA1.js"></script>
   
    
    <div id="section1">
    <h2>ĐẶT MUA SẢN PHẨM
    </h2>  
    </div>
    <hr />
	
	<form id="form1">
	<div id="section8"></div>
    <div id="section2">
    
    <fieldset>
    
    <legend>Hình Thức Khuyến Mãi</legend>

        <div class="forminput">
                <div id="div_DiemKM1" class="formlabel"> <label>Số điểm hiện có</label> </div>
                <div id="div_DiemKM2" class="formlabel_left1"> <asp:label id="lbDiemKM" runat="server"/> </div>
        </div><br />
            
        <div class="forminput">
                <div id="div11" class="formlabel"> <label>Số điểm tối đa được sử dụng</label> </div>
                <div id="div_DiemTD" class="formlabel_left1"></div>
        </div><br />
        
        <div id="SuDungKhuyenMai" class="forminput">
	        <div class="formlabel"><label>Sử dụng quyền khuyến mãi</label></div>
            <div class="formfield">
                <input type="radio" name="rdLoaiDH" id="rdCo" onclick ="CoSuDungQuyenKM()" value="optCoSDKM" />
                    <label for="optCo">Có</label>
                <input type="radio" name="rdLoaiDH" id="rdKo" onclick ="KoSuDungQuyenKM()" value="optKoSDKM" checked="checked"/>
                    <label for="optKo">Không</label>
            </div>
	    </div>
        
        <div id="DiemSuDung" class="forminput">
            <div class="formlabel"> <label>Số điểm sử dụng</label> </div>
            <div class="formfield"> <select id="cmbDiemSD" disabled="true" onchange="TinhTien()"></select></div>
        </div>
        
        <div class="forminput">
                <div id="div2" class="formlabel"> <label>Số tiền tương ứng</label> </div>
                <div id="div3" class="formlabel_left1"> <label id="lbSoTien"></label> </div>
        </div><br />
        
        <div id="HinhThucKhuyenMai" class="forminput">
            <div class="formlabel"> <label>Hình thức khuyến mãi</label> </div>
            <div class="formfield"> 
                <select id="cmbHTKM" disabled = "disabled" onchange="ChonHinhThucKhuyenMai()"></select>
                    <script type="text/javascript">
                        XL_HTKM.LayDSHTKM('cmbHTKM');
                    </script>
            </div>
        </div>
        
        <div id="ChonQuaTang" class="forminput">
            <div class="formlabel"> <label>Chọn quà tặng</label> </div>
            <input type="button" id="btChon" disabled="disabled" value="Chọn" onclick="return ClickChonQuaTang()"/>
        </div>
        
        <div id="Div4">
        <fieldset>
        <legend>Khuyến Mãi</legend>
	        <div id="Th_Danh_Sach_Qua_Tang"></div>
            
            <div id="Div6"class="forminput">
                <div id="div7" class="formlabel"> <label>Tổng giá trị khuyến mãi</label> </div>
                <div id="div_GTQT" class="formlabefl_left">
                      </div> 
            </div>
           
        </fieldset>
	    </div>
	
    </fieldset>
    </div>
    <hr/>  
    
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
                <div id="div14" class="formlabel"> <label>Thuế VAT</label> </div>
                <div id="div_Thue" class="formlabefl_left"></div> 
        </div> 
        
        <div id="Div8"class="forminput">
                <div id="div15" class="formlabel"> <label>Giá trị khuyến mãi</label> </div>
                <div id="div_KM" class="formlabefl_left"></div> 
        </div> <br />
        
        <div id="Div5"class="forminput">
                <div id="div9" class="formlabel"> <label>Tổng tiền phải trả</label> </div>
                <div id="div_TT" class="formlabefl_left"></div> 
        </div> 
        
    </fieldset>
	</div>
	<hr />
	
    <div id="section3">
    <fieldset>
    <legend>Hình Thức Thanh Toán</legend>
    
        <div id="HinhThucThanhToan" class="forminput">
            <div class="formlabel"> <label>Hình thức thanh toán</label> </div>
            <div class="formfield"> 
                <select id="cmbHTTT" onchange="ChonHinhThucThanhToan()"></select>
                    <script type="text/javascript">
                        XL_HTTT.LayDSHTTT('cmbHTTT');
                        document.getElementById('pathway').innerHTML += 'Đặt mua sản phẩm';
                    </script>
            </div>
       </div>
        
       <div id="ThongTinTTD">
       <fieldset>
            <legend>Thông Tin Thẻ Tín Dụng</legend>
            
            <div id="SuDungThe" class="forminput">
	            <div class="formlabel"><label>Sử dụng thẻ</label></div>
                <div class="formfield">
                    <input type="radio" name="rdMacDinh" id="rdMacDinh" disabled="disabled" onclick="ChonMacDinh()" checked="checked" value="optMacDinh"/>
                        <label for="optCo">Mặc định</label>
                    <input type="radio" name="rdKhac" id="rdKhac" disabled="disabled" onclick="ChonTheKhac()" value="optKhac"/>
                        <label for="optKo">Khác</label>
                        
                    
                </div>
	        </div>
	    
            <div id="Div1" class="forminput">
            <div class="formlabel"> <label>Loại thẻ</label> </div>
            <div class="formfield"> 
                <asp:DropDownList ID="cmbLoaiThe" Enabled="false" runat="server" Width="162px"></asp:DropDownList>
            </div>
            </div>
            
            <div class="forminput">
                <div class="formlabel"><label>Số thẻ</label></div>
                <div class="formfield"><input type="text" disabled="disabled" name="txtSoThe" size="40" id="txtSoThe" onchange="KiemTraSoThe()" runat="server"/></div>
            </div>

            <div id="NgayHetHan" class="forminput">
                <div class="formlabel"> <label>Ngày hết hạn</label> </div>
                <div class="formfield"> 
        	        <asp:DropDownList ID="cmbNgayHH" Enabled="false" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="cmbThangHH" Enabled="false" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="cmbNamHH" Enabled="false" runat="server"></asp:DropDownList>	
                </div>
             </div>
         
       </fieldset>
       </div> 
   
    </fieldset>
    </div>
    <hr />
        
    <div id="section4">
    <fieldset>
    <legend>Thông Tin Giao Hàng</legend>
    
        <div id="NguoiNhan" class="forminput">
            <div class="formlabel"> <label>Người nhận*</label> </div>
            <div class="formfield"> <input name="txtNguoiNhan" type="text" id="txtNguoiNhan" size="40" runat="server"/></div>
        </div>
        
        <div id="DiaChiNhan" class="forminput">
            <div class="formlabel"> <label>Địa chỉ nhận*</label> </div>
            <div class="formfield"> <input name="txtDiaChiNhan" type="text" id="txtDiaChiNhan" size="40" runat="server"/></div>
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
                <input type="button" id="btnQuayLai" value="Quay lại" onclick="btnQuayLai_onclick()" />
                <input type="button" id="btnThanhToan" value="Đặt hàng" onclick="XL_DonHang.DatHang(1)" />
                <input type="button" id="btnLuu" value="Lưu đơn hàng" onclick="XL_DonHang.DatHang(0)" />
                <input type="button" id="btnThoat" value="Thoát" onclick="XL_DonHang.Thoat()" />
            </div>  
             
    </div>
    </fieldset>
    </div>
    
    <input type="hidden" value="KhachHang" id="txtloaind" runat="server"/>
    <input type="hidden" id="hiddenSoThe" runat="server"/>

    
    </form>
    
    <script type="text/javascript">
           nodeLoaiND = document.getElementById('<%=txtloaind.ClientID%>');
           
           nodeNguoiNhan = document.getElementById('<%=txtNguoiNhan.ClientID%>');
           nodeDiaChiNhan = document.getElementById('<%=txtDiaChiNhan.ClientID%>');
           
           nodeLoaiThe = document.getElementById('<%=cmbLoaiThe.ClientID%>');
           nodeSoThe = document.getElementById('<%=txtSoThe.ClientID%>');
           nodeNgayHH = document.getElementById('<%=cmbNgayHH.ClientID%>');
           nodeThangHH = document.getElementById('<%=cmbThangHH.ClientID%>');
           nodeNamHH = document.getElementById('<%=cmbNamHH.ClientID%>');
           hiddenSoThe = document.getElementById('<%=hiddenSoThe.ClientID%>');

    </script>
     
    <script type="text/javascript">
        
        XL_DonHang.DsSanPham();
        XL_DonHang.DsQuaTang();
        TinhSoDiemToiDa('cmbDiemSD');
        XL_DonHang.LayTrangThaiForm();
    </script>
</asp:Content>

