<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="KHThongTinGiaoDich.aspx.cs" Inherits="KHThongTinGiaoDich" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

    <script type="text/javascript" src="He Khach/XL_KHThongTinGiaoDich.js"></script>    
    <LINK href="css/template[1].css" type="text/css" rel="stylesheet">
    
   <div class="ushead" > 
		<div class="uscontentheading"><h3>Thông tin giao dịch</h3></div> 
	</div> 
	<div class="ushead_logo"> 
		<img src="images_layout/personal.png" /> 
	</div> 
			<br />
			
    <div class="yui-skin-sam">
        <div id="divKHThongTinGiaoDich">
        </div>
    </div>
    <script type="text/javascript">
        LoadTable();
        document.getElementById('pathway').innerHTML += 'Thông tin giao dịch';
    </script>   
   
</asp:Content>
