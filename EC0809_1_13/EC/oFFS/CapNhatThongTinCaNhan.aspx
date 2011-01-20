<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="CapNhatThongTinCaNhan.aspx.cs" Inherits="CapNhatCaNhan" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    
   <div id="doc" class="yui-t7">

    <hr />
    
   <div id="section1">
        <h2>CẬP NHẬT THÔNG TIN CÁ NHÂN</h2>
   </div>
   <hr />
   
   <form id="form1">
   <div id="section2">
   <fieldset>
        <div id="HoTen" class="forminput">
            <div class="formlabel"> <label>Họ tên*:</label> </div>
            <div class="formfield"> <input name="txtHoTen" type="text" id="txtHoTen" size="40" runat="server"/></div>
            
        </div>
     
        <div id="NgaySinh" class="forminput">
            <div class="formlabel"> <label>Ngày sinh*:</label> </div>
            <div class="formfield"> 
                <asp:DropDownList ID="cmbNgaySinh" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="cmbThangSinh" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="cmbNamSinh" runat="server"></asp:DropDownList>
            </div>
        </div>   
   
        <div id="GioiTinh" class="forminput">
            &nbsp;<div class="formlabel"><label>Giới tính*:</label></div>
            <div class="formfield">
                <input type="radio" name="rdGioiTinh" id="optNam" value="optGioiTinh" runat="server"/>
                <label for="optNam">Nam</label>
                <input type="radio" name="rdGioiTinh" id="optNu" value="optGioiTinh" runat="server"/>
                <label for="optNu">Nữ</label>
            </div>
	    </div>
    
        <div id="DiaChi" class="forminput">
            <div class="formlabel"> <label>Địa chỉ:</label> </div>
            <div class="formfield"> <input name="txtDiaChi" type="text" id="txtDiaChi" size="40" runat="server"/></div>
        </div>
	
        <div id="DienThoai" class="forminput">
            <div class="formlabel"> <label>Điện thoại:</label> </div>
            <div class="formfield"> <input name="txtDienThoai" type="text" id="txtDienThoai" size="40" runat="server"/></div>
        </div>
     
        <div id="Email" class="forminput">
            <div class="formlabel"> <label>Email*:</label> </div>
            <div class="formfield"> <input name="txtEmail" type="text" id="txtEmail" size="40" runat="server"/></div>
        </div>

        <div class="forminput">
            <div class="formlabel">&nbsp;</div>
            <div class="formhint">Ví dụ: offs@yahoo.com</div>
        </div>
    
        <div class="forminput">
            <div class="formfield"><center>
                <input type="button" id="but_Luu" value="Lưu" onclick="CapNhatThongTinCaNhan(0)"/>
                <input type="button" id="btnThoat" value="Trở về" onclick="window.location='XemThongTinCaNhan.aspx?t='+new Date().getTime();"/>
            </center></div>
        </div><br />
   </fieldset>
   </div>
        <script type="text/javascript">
           nodeHoTen = document.getElementById('<%=txtHoTen.ClientID%>');
           nodeNgaySinh = document.getElementById('<%=cmbNgaySinh.ClientID%>');
           nodeThangSinh = document.getElementById('<%=cmbThangSinh.ClientID%>');
           nodeNamSinh = document.getElementById('<%=cmbNamSinh.ClientID%>');
           
           nodeGioiTinhNam = document.getElementById('<%=optNam.ClientID%>');
           nodeDiaChi = document.getElementById('<%=txtDiaChi.ClientID%>');
           nodeDienThoai = document.getElementById('<%=txtDienThoai.ClientID%>');
           nodeEmail = document.getElementById('<%=txtEmail.ClientID%>');
           document.getElementById('pathway').innerHTML += 'Thông tin cá nhân';
        </script>
   </form>
   
</div>
</asp:Content>