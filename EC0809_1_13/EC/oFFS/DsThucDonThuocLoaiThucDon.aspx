<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DsThucDonThuocLoaiThucDon.aspx.cs" Inherits="DsThucDonThuocLoaiThucDon" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="Th_ds_ThucDon_loai_thuc_don">
    </div>
    <script type ="text/javascript">
        XL_ThucDon.LayDSThucDonThuocLoaiThucDonBatKy()
        document.getElementById('pathway').innerHTML += 'Danh sách thực đơn thuộc loại thực đơn';
    </script>
</asp:Content>