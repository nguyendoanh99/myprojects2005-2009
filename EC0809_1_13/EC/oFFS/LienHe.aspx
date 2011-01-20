<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="LienHe.aspx.cs" Inherits="LienHe" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<link href="css/template[1].css" type="text/css" rel="stylesheet"/>
<script type="text/javascript" src="He Khach/XL_CongTy.js"></script>
    <br /><br /><br />
    <div class="ushead" > 
		<div class="uscontentheading"><h3>Thông Tin Liên Hệ</h3></div> 
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
    <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center" class="contentpaneopen" style="height: 190px"> 
      <tr> 
        <th style="width: 200px">
            Tên công ty : </th> 
	    <td ><div id="div_ten_cong_ty"  style="font-size:x-large"></div>
            </td> 
      </tr> 
      <tr> 
	    <th style="width: 200px;">
            Địa chỉ liên hệ : </th> 
	    <td><div id="div_dia_chi" style="font-size:medium"></div>
            </td> 
      </tr> 
      <tr> 
	    <th style="width: 200px; height: 16px;">
            Điện thoại liên lạc : </th> 
	    <td><div id="div_dien_thoai"  style="font-size:medium"></div>
            </td> 
      </tr>       
    </table>     
    </div></div></div>    
</asp:Content>