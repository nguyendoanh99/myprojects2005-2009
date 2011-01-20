<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="KHXemChiTietDonHang.aspx.cs" Inherits="KHXemChiTietDonHang" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <% Response.Write("<script type=\"text/javascript\"> var maDonHang=" + Request["MaDonHang"] + "; </script>"); %>
    <!--CSS file (default YUI Sam Skin) --> 
	<link type="text/css" rel="stylesheet" href="build/datatable/assets/skins/sam/datatable.css"> 
	<!-- Dependencies --> 
	<script type="text/javascript" src="build/yahoo-dom-event/yahoo-dom-event.js"></script> 
	<script type="text/javascript" src="build/element/element-beta-min.js"></script> 
	<script type="text/javascript" src="build/datasource/datasource-min.js"></script> 
	<!-- OPTIONAL: Connection Manager (enables XHR for DataSource) -->
    <script type="text/javascript" src="build/connection/connection-min.js"></script>
	<!-- Source files -->
    <script type="text/javascript" src="build/datatable/datatable-min.js"></script>
    <script type="text/javascript" src="build/paginator/paginator-min.js"></script> 
    <link rel="stylesheet" type="text/css" href="build/paginator/assets/skins/sam/paginator.css" />
    <link rel="stylesheet" type="text/css" href="build/fonts/fonts-min.css" /> 
    
       <!-- Sam Skin CSS -->
    <link rel="stylesheet" type="text/css" href="build/container/assets/skins/sam/container.css">
    <!-- OPTIONAL: You only need the YUI Button CSS if you're including YUI Button, mentioned below. -->
    <link rel="stylesheet" type="text/css" href="build/button/assets/skins/sam/button.css">
    <!-- OPTIONAL: YUI Button (these 2 files only required if you want SimpleDialog to use YUI Buttons, instead of HTML Buttons) -->
    <script type="text/javascript" src="build/element/element-beta-min.js"></script>
    <script type="text/javascript" src="build/button/button-min.js"></script>
    <!-- Source file -->
    <script type="text/javascript" src="build/container/container-min.js"></script>
    
    <script type="text/javascript" src="He Khach/XL_KHXemChiTietDonHang.js"></script>    
    <LINK href="css/template[1].css" type="text/css" rel="stylesheet">
    
   <div class="ushead" > 
		<div class="uscontentheading"><h3><label id="_title">Chi tiết đơn hàng</label></h3></div> 
	</div> 
	<div class="ushead_logo"> 
		<img src="images_layout/personal.png" /> 
	</div> 
			<br />
			
    <div style="height:8px; clear:both; width:100%;"></div> 
	<div class="usform_top"> 
	<div class="usform_topleft"> 
	<div class="usform_topright">&nbsp;
	</div></div></div> 
		
	<div class="usform"> 
	<div class="usform_right" style="height:100%;"> 
	<div class="usform_left"> 
    <table width="100%" cellpadding="2" cellspacing="2" border="0" align="center" class="contentpaneopen"> 
      <tr> 
	    <th width="19%">Tên khách hàng:</th> 
	    <td width="20%" colspan="4" id="setTenKhachHang"></td> 
	    <th width="30%" rowspan="7" valign="middle" align="center"> 
				    </th> 
      </tr> 
      <tr id="dinhky1"> 
        <th>Ngày bắt đầu:</th> 
	    <td id="setNgayBatDau"></td> 
        <td>&nbsp;</td> 
        <th >Ngày kết thúc:</th> 
	    <td id="setNgayKetThuc"></td> 	    	    
      </tr> 
      <tr id="dinhky3"> 
        <th>Loại định kỳ:</th> 
	    <td id="setLoaiDinhKy" colspan="3"></td>	    	    
      </tr> 
      <tr id="dinhky2"> 
        <th>Thời điểm giao:</th> 
	    <td id="setThoiDiemGiao"></td> 
        <td>&nbsp;</td> 
        <th >Giờ giao:</th> 
	    <td id="setGioGiao"></td> 	    	    
      </tr>       
      <tr id="ngaygiolap_giao"> 
        <th>Ngày giờ lập:</th> 
	    <td id="setNgayGioLap"></td> 
        <td>&nbsp;</td> 
        <th >Ngày giờ giao hàng:</th> 
	    <td id="setNgayGioGiaoHang"></td> 	    	    
      </tr> 
      <tr> 
	    <th>Người nhận:</th> 
	    <td id="setNguoiNhan"></td> 
	    <td width="1%">&nbsp;</td> 
	    <th width="12%">Địa chỉ nhận:</th> 
	    <td width="18%" id="setDiaChiNhan"></td> 
      </tr> 
      <tr> 
	    <th>Hình thức khuyến mãi:</th> 
	    <td id="setHinhThucKhuyenMai"></td> 
	    <td>&nbsp;</td> 
	    <th>Tiền khuyến mãi:</th> 
	    <td id="setTienKhuyenMai"></td> 
      </tr> 
      <tr> 	   
	    <th>Giá trị:</th> 
	    <td id="setGiaTri"></td> 
	     <td>&nbsp;</td> 
	      <th>Tiền thuế:</th> 
	    <td id="setTienThue"></td> 
      </tr>       
      <tr id="dinhky4"> 
        <th >Tình trạng:</th> 
	    <td id="setTinhTrang"></td> 	    	    
      </tr> 
    </table>     
    </div></div></div>
    <br />
    <div class="yui-skin-sam">
        <div id="divDanhSachCTDonHang">
        </div>
    </div>
    <script type="text/javascript">
        LoadData();
        LoadTable();
    </script>  
</asp:Content>

