<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DsMonAnThuocLoaiMonAn.aspx.cs" Inherits="DsMonAnThuocLoaiMonAn" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="Th_ds_MonAn_loai_mon_an">
    </div>
    <script type = "text/javascript">
    XL_MON_AN.LayDSMonAnThuocLoaiMonBatKy();
    document.getElementById('pathway').innerHTML += 'Danh sách món ăn thuộc loại món';
    </script>

</asp:Content>