<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DanhSachThucDon.aspx.cs" Inherits="DanhSachThucDon" %>

<%@ Register Src="UserControl/DanhSachThucDon.ascx" TagName="DanhSachThucDon" TagPrefix="uc2" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type = "text/javascript" src ="He Khach/XL_ThucDon.js"></script>
    <script type = "text/javascript" src ="He Khach/XL_ThucDonCaNhan.js"></script>
    <script type="text/javascript">
    document.getElementById('pathway').innerHTML += 'Danh sách thực đơn';
    </script>
    <div>
        <uc2:DanhSachThucDon ID="DanhSachThucDon1" runat="server" />
        &nbsp;</div>
  </asp:Content>