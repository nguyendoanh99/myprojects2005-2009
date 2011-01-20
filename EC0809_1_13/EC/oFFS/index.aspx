<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register Src="UserControl/DanhSachMonAn.ascx" TagName="DanhSachMonAn" TagPrefix="uc1" %>
<%@ Register Src="UserControl/DanhSachThucDon.ascx" TagName="DanhSachThucDon" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <uc1:DanhSachMonAn ID="DanhSachMonAn1" runat="server" />
    </div>
    <div>
        <uc2:DanhSachThucDon ID="DanhSachThucDon1" runat="server" />
    </div>

</asp:Content>

