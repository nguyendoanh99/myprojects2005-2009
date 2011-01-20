<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DangNhap.aspx.cs" Inherits="DangNhap" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript" src="He Khach/XL_NguoiDung.js"></script>
    <script language="javascript" type="text/javascript" src="He Khach/SHA1.js"></script>
    
    <script type="text/javascript">
    <asp:Literal ID="ltlAlert" runat="server" EnableViewState="false"></asp:Literal>
    </script>
    
    <div id="doc" class="yui-t7">
    <div id="section1">
    <hr />
    <h2>ĐĂNG NHẬP
    <hr />
    
   <!-- <form id="form1" >-->
    </h2>
    </div>
    <div>
        <div id="section2">
         <fieldset>
        <div id="HoTen" class="forminput">
            <div class="formlabel"> <label>Tên tài khoản</label> </div>
            <div class="formfield"> 
                <asp:TextBox ID="txtAcc" runat="server" Width="199px"></asp:TextBox></div>
         </div>
        
        <div id="DiaChi" class="forminput">
            <div class="formlabel"> <label>Mật khẩu</label> </div>
            <div class="formfield"> 
                <input type="password"  name="txtPass" size="40" id="txtPass" onchange="XL_NguoiDung.HashPass()"/>
                 <asp:HiddenField ID="hiddenPass" runat="server"></asp:HiddenField>
            </div>
         </div>
         
         <div id="Div2" class="forminput">
            <div class="formlabel"> <label></label> </div>
            <div class="formfield"> 
                <input type="checkbox" id="ckbNhoAcc"/><label for="ckbNhoAcc">Nhớ tên truy cập và mật khẩu</label> 
               
                </div>
             
         </div>
         
         <div id="Div3" class="forminput">
            <div class="formlabel"> <label></label> </div>
            <div class="formfield"> 
                 <a href="" id="linkQuenPass" style="color:Blue">(Quên mật khẩu)</a>
                </div>
             
         </div>
         
         <div id="Div1" class="forminput">
            <div class="formlabel"> <label></label> </div>
            <div class="formfield"> <asp:Button ID="btnDangNhap" runat="server" Text="Đăng nhập" OnClick="btnDangNhap_Click" /></div>
         </div>
         
	    
        </fieldset>
        </div>
        
    </div>
    <!--</form>-->
    <script type="text/javascript">
        var nodeHiddenPass = document.getElementById("<%=hiddenPass.ClientID %>");
    </script>
    
    </div>
</asp:Content>