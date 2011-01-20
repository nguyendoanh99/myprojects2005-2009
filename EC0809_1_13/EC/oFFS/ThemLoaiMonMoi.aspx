<%@ Page Language="C#" MasterPageFile="~/MPVirtueMart.master" AutoEventWireup="true" CodeFile="ThemLoaiMonMoi.aspx.cs" Inherits="ThemLoaiMonMoi" %>

    
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type="text/javascript" src="He Khach/XL_MonAn.js"></script>
    <script type="text/javascript" src="He Khach/XL_LoaiMon.js"></script>
    
    <script type="text/javascript">
    <asp:Literal ID="ltlAlert" runat="server" EnableViewState="false"></asp:Literal>
    </script>
    
    <div id="doc" class="yui-t7">
    <div id="section1">
    <h2>THÊM LOẠI MÓN MỚI
    </h2>  
    </div>
    
    <hr />
    
    <form id="form1" runat="server">
    <input type="hidden" name="txtHinhAnh" id="txtHinhAnh" value="" runat="server"/>
    
    <div id="section2">
         <fieldset>
    <legend></legend>
    
    <div id="div_TenLoaiMon" class="forminput">
        <div class="formlabel"> <label>Tên loại món</label> </div>
        <div class="formfield"> <input name="txtTenLoaiMon" type="text" id="txtTenLoaiMon"  size="40" runat="server"/></div>
     </div> 
        
     <div id="div_LoaiMonCha" class="forminput">
	    <div class="formlabel"><label>Loại món cha</label></div>
        <div class="formfield">
            <asp:DropDownList ID="cmbLoaiMonCha" runat="server">
            </asp:DropDownList></div>
	 </div>    
     
     <div id="div_LaLoaiMonLa" class="forminput">
        <div class="formlabel"> <label>Là loại món lá</label> </div>
        <div class="formfield"> <input name="rdMonLa" type="radio" id="optLa" size="20" runat="server" value="Có"/>Có
                                <input name="rdMonLa" type="radio" id="optKLa" size="20" runat="server" value="Không" checked="true"/>Không
        </div>
     </div>
     
     <script type="text/javascript">
            var tenloaimon = document.getElementById('<%= txtTenLoaiMon.ClientID %>');
            var maloaimoncha = document.getElementById('<%= cmbLoaiMonCha.ClientID %>');
            var laloaimonla = document.getElementById('<%= optLa.ClientID %>');
            //var IDtxtTenLoaiMon = <%= txtTenLoaiMon.ClientID %>;
            //var IDcmbMaLoaiMonCha = <%= cmbLoaiMonCha.ClientID %>;
            //var IDoptLaLoaiMonLa = <%= optLa.ClientID %>;
            
           // alert(IDtxtTenLoaiMon);
           // alert(IDcmbMaLoaiMonCha);
           // alert(IDoptLaLoaiMonLa);
    </script>
    
     <div id="div_Button" class="forminput">
        <div class="formlabel"> <label></label> </div>
        <div class="formfield"> <input name="btnDongY" type="submit" id="btnDongY" value="Thêm" onclick="XL_LoaiMon.ThemLoaiMonMoi(tenloaimon, maloaimoncha, laloaimonla)"/></div>
     </div>

    </fieldset>
    </div>
   
    </form>
    </div>
</asp:Content>