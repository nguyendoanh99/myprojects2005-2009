<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="ThongKeDoanhThu.aspx.cs" Inherits="ThongKeDoanhThu" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <!--
    <link rel="stylesheet" type="text/css" href="build/fonts/fonts-min.css" />
    <script type="text/javascript" src="build/yahoo-dom-event/yahoo-dom-event.js"></script>
    <script type="text/javascript" src="build/json/json-min.js"></script>
    <script type="text/javascript" src="build/element/element-beta-min.js"></script>

    <script type="text/javascript" src="build/datasource/datasource-min.js"></script>
    <script type="text/javascript" src="build/charts/charts-experimental-min.js"></script>
    -->
    
    
    <!--begin custom header content for this example-->

    <style type="text/css">
	
	#chart
	{
		width: 500px;
		height: 350px;
		margin-bottom: 10px;
	}
	.yui-dt-table {width: 500px;}

	.chart_title
	{
		display: block;
		font-size: 1.2em;
		font-weight: bold;
		margin-bottom: 0.4em;
	}
    </style>
    <!--end custom header content for this example-->



    <script type="text/javascript" src="He Khach/XL_ThongKe.js"></script> 
    
    <div id="doc" class="yui-t7">
    
    <hr />
    
    <div id="section1">
    <h2>THỐNG KÊ DOANH THU
    </h2>  
    </div>
    <hr />

    <form id="form1">
    
    <!-- Begin tiêu chí thống kê--> 
    <div id="section2">
     <fieldset>
     
    <legend>Tiêu chí thống kê </legend>
    
    <div id="Div2" class="forminput">
        <div class="formlabel"> <label>Thống kê theo : </label></div>
        <div class="formfield"> 
            <select id="cmbHinhThuc"></select>
               <script type="text/javascript">
                       XL_ThongKe.LoadHinhThucThongKe('cmbHinhThuc');
            </script>
        </div>
     </div>
     
      <div id="NgaySinh" class="forminput">
        <div class="formlabel"> <label>Khoảng thời gian : </label> </div>
        <div class="formfield"> 
            từ
            <select id="cmbNgayBegin"></select>
            <select id="cmbThangBegin"></select>
            <select id="cmbNamBegin"></select>
            đến
            <select id="cmbNgayEnd"></select>
            <select id="cmbThangEnd"></select>
            <select id="cmbNamEnd"></select>
               <script type="text/javascript">
                XL_ThongKe.LoadCmbNum('cmbNgayBegin', 1, 31);
                XL_ThongKe.LoadCmbNum('cmbThangBegin', 1, 12);
                XL_ThongKe.LoadCmbNum('cmbNamBegin', 2005, 2010);
                
                XL_ThongKe.LoadCmbNum('cmbNgayEnd', 1, 31);
                XL_ThongKe.LoadCmbNum('cmbThangEnd', 1, 12);
                XL_ThongKe.LoadCmbNum('cmbNamEnd', 2005, 2010);
            </script>
        </div>
     </div>
    <!-- End tiêu chí thống kê--> 
     
     
    <!-- Begin Kết quả thống kê-->
    <div class="forminput">
            <div class="formlabel"><label></label></div>
            <div class="formfield">
                &nbsp;<input type="button" id="btnThucHien" value="Đồng ý" onclick="XL_ThongKe.LoadKqThongKeDoanhThu()" /></div>            
    </div>
    
    </fieldset>
     </div>
     
    <div id="Section2">
     <fieldset>
    <legend>Kết quả</legend>
    
    <div class="yui-skin-sam" align="center">
    
    <div id="chart"></div>
    
    
    
    <div id="divKq">
    
    </div>
    </div>
    
    
    
   </fieldset>
     </div> 
   <!-- End tiêu chí thống kê--> 
  

   

    </form>
    </div>
    

     <script type="text/javascript">
       // MakeMyChart();
    </script>
 </asp:Content>