<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="QTThayDoiQuiDinhHeThong.aspx.cs" Inherits="QTThayDoiQuiDinhHeThong" Title="Untitled Page" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script type="text/javascript" src="He Khach/XL_QTThayDoiQuiDinhHeThong.js"> </script>
<script type="text/javascript" src="He Khach/_Number.js"> </script>
<link href="css/template[1].css" type="text/css" rel="stylesheet" />
    <div class="ushead" > 
		<div class="uscontentheading"><h3>Thay đổi qui định hệ thống</h3></div> 
	</div> 
	
	<div class="ushead_logo"> 
		<img src="images_layout/personal.png" /> 
	</div> 
	<div style="height:8px; clear:both; width:100%;"></div>
	<div class="usform_top"> 
	<div class="usform_topleft"> 
	<div class="usform_topright">&nbsp;
	</div></div></div> 
		
	<div class="usform"> 
	<div class="usform_right" style="height:67%;"> 
	<div class="usform_left"> 
    <table width="100%" cellpadding="2" cellspacing="2" border="0" align="center" class="contentpaneopen" style="height: 190px"> 
      <tr> 
        <th style="width: 396px">
            Số tiền qui đổi thành 1 điểm khuyến mãi từ đơn hàng:</th> 
	    <td >
            <input id="idGiaTriDiemSo" style="width: 123px" type="text" onchange="OnChange(this)"/>
            đồng <label style="color:Red" id="EGiaTriDiemSo"></label></td> 
      </tr> 
      <tr> 
	    <th style="width: 396px;">
            Số điểm để trở thành khách hàng thân thiết:</th> 
	    <td id="setNguoiNhan">
            <input id="idDiemKhachHangThanThiet" style="width: 123px" type="text" onchange="OnChange(this)"/>
            điểm <label style="color:Red" id="EDiemKhachHangThanThiet"></label></td> 
      </tr> 
      <tr> 
	    <th style="width: 396px; height: 16px;">
            Tỉ lệ giảm giá của thực đơn:</th> 
	    <td  style="height: 16px">
            <input id="idTiLeGiamGiaThucDon" style="width: 123px" type="text" onchange="OnChange(this)"/>
            %<label style="color:Red" id="ETiLeGiamGiaThucDon"></label></td> 
      </tr> 
      <tr> 	   
	    <th style="width: 396px">
            Thuế giá trị gia tăng:</th> 
	    <td id="setGiaTri">
            <input id="idThue" style="width: 123px" type="text" onchange="OnChange(this)"/>
            % &nbsp<label style="color:Red" id="EThue"></label></td> 
      </tr> 
      <tr> 	   	    
	    <th style="width: 396px; height: 16px;">
            Giá trị qui đổi thành tiền của 1 điểm khuyến mãi:</th> 
	    <td style="height: 16px">
            <input id="idGiaTriDoiDiemKhuyenMai" style="width: 123px" type="text" onchange="OnChange(this)" />
            đồng<label style="color:Red" id="EGiaTriDoiDiemKhuyenMai"></label></td> 
      </tr>       
      <tr> 	   	    
	    <th style="width: 396px; height: 22px;">
            Giới hạn số điểm khuyến mãi được dùng cho 1 đơn hàng:</th> 
	    <td style="height: 22px">
            <input id="idGioiHanDoiDiemKhuyenMai" style="width: 123px" type="text" onchange="OnChange(this)"/>
            % <label style="color:Red" id="EGioiHanDoiDiemKhuyenMai"></label></td> 
      </tr>       
        <tr>
            <th style="width: 396px; height: 19px">
            </th>
            <td style="height: 19px">
                <input id="butLuu" type="button" value="Lưu" onclick="Luu()"/></td>
        </tr>
    </table>     
    </div></div></div>    
    
    <script type="text/javascript">
        LoadData();
    </script>  
    </asp:Content>
