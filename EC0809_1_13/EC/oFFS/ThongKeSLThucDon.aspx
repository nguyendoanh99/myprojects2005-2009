<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="ThongKeSLThucDon.aspx.cs" Inherits="ThongKeSLThucDon" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
   
    <script type="text/javascript" src="He Khach/XL_ThongKe.js"></script> 
    
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
    
    
    
    <div id="doc" class="yui-t7">    
    <hr />
    
    <div id="section1">
    <h2>THỐNG KÊ SỐ LƯỢNG THỰC ĐƠN ĐÃ BÁN
    </h2>  
    </div>
    <hr />

    <form id='form1'>
    
    <!-- Begin tiêu chí thống kê--> 
    <div id="section2">
     <fieldset>
     
    <legend>Tiêu chí thống kê </legend>
    
    <div id="Div3" class="forminput">
        <div class="formlabel"> <label>Thực đơn : </label></div>
        <div class="formfield"> 
            <select id="cmbThucDon"></select>
               <script type="text/javascript">
                       XL_ThongKe.LayDSTenThucDon('cmbThucDon');
            </script>
        </div>
     </div>
     
     
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
                &nbsp;<input type="button" id="btnThucHien" value="Đồng ý" onclick="XL_ThongKe.LoadKqThongKeThucDon()" /></div>            
    </div>
    
    </fieldset>
     </div>
     
    <div id="Div1">
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
    
 </asp:Content>