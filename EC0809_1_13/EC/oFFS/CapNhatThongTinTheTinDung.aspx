<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="CapNhatThongTinTheTinDung.aspx.cs" Inherits="CapNhatTheTinDung" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script type="text/javascript" src="He Khach/SHA1.js"></script>
    <script type="text/javascript" src="He Khach/XL_The.js"></script>
    
    <div id="doc" class="yui-t7">
    <hr />
    
   <div id="section1">
        <h2>CẬP NHẬT THÔNG TIN THẺ TÍN DỤNG</h2>
   </div>
   <hr />
   
   <form id="form1">
   <div id="section2">
   <fieldset>
        <div id="Div1" class="forminput">
            <div class="formlabel"> <label>Loại thẻ:</label> </div>
            <div class="formfield"> 
                <asp:DropDownList ID="cmbLoaiThe" runat="server" Width="162px"></asp:DropDownList>
            </div>
        </div>
        <div class="forminput">
            <div class="formlabel"><label>Số thẻ:</label></div>
            <div class="formfield"><input type="text" name="txtSoThe" size="40" id="txtSoThe" runat="server"/></div>
        </div>

        <div id="NgayHetHan" class="forminput">
            <div class="formlabel"> <label>Ngày hết hạn:</label> </div>
            <div class="formfield"> 
        	    <asp:DropDownList ID="cmbNgayHH" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="cmbThangHH" runat="server"></asp:DropDownList>
                <asp:DropDownList ID="cmbNamHH" runat="server"></asp:DropDownList>	
            </div>
         </div>
         <div class="forminput">
            <div class="formfield"><center>
                <input type="button" id="btnLuu" value="Lưu" runat="server" onclick="CapNhatThongTinTheTinDung()"/>
                <input type="button" id="btnThoat" value="Trở về" runat="server" onclick="window.location='XemThongTinCaNhan.aspx?t='+new Date().getTime()"/>
            </center></div>
        </div>
   </fieldset>
   </div>
        <script type="text/javascript">
           nodeLoaiThe = document.getElementById('<%=cmbLoaiThe.ClientID%>');
           nodeSoThe = document.getElementById('<%=txtSoThe.ClientID%>');
           nodeNgayHH = document.getElementById('<%=cmbNgayHH.ClientID%>');
           nodeThangHH = document.getElementById('<%=cmbThangHH.ClientID%>');
           nodeNamHH = document.getElementById('<%=cmbNamHH.ClientID%>');
           document.getElementById('pathway').innerHTML += 'Thông tin thẻ tín dụng';
        </script>
   </form>
</div>
</asp:Content>