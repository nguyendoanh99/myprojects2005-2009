<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="QuanLyDanhMucLoaiMon.aspx.cs" Inherits="QuanLyDanhMucLoaiMon"%>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
    
    <script type="text/javascript" src="He Khach/XL_LoaiMon.js"></script>
    
    <LINK href="css/template[1].css" type="text/css" rel="stylesheet">
    <div class="ushead" > 
		<div class="uscontentheading"><h3>Danh sách loại món</h3></div> 
	</div> 
	<div class="ushead_logo"> 
		<img src="images_layout/personal.png" /> 
	</div> 
			<br />
  
    <div class="yui-skin-sam">
    <div id="divKq"></div>
    </div>
    
    <script type="text/javascript">
        DuyetCayLoaiMon();
    </script> 
    </asp:Content>  
    
   
