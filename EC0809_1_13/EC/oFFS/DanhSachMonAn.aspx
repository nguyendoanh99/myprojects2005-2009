<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DanhSachMonAn.aspx.cs" Inherits="DanhSachMonAn" %>

<%@ Register Src="UserControl/DanhSachMonAn.ascx" TagName="DanhSachMonAn" TagPrefix="uc1" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type = "text/javascript">    
    document.getElementById('pathway').innerHTML += 'Danh sách món ăn';
    </script>
    <div>
        <div style="width: 500px; position:relative; height: 500px">
            <uc1:DanhSachMonAn ID="DanhSachMonAn1" runat="server" />
        </div>  
    </div>
  </asp:Content>  
 