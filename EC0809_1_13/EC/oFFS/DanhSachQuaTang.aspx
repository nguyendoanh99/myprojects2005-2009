<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="DanhSachQuaTang.aspx.cs" Inherits="DanhSachQuaTang" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <% Response.Write("<script type=\"text/javascript\"> var lbSoTien=" + Request["lbSoTien"] + "; </script>"); %>
    <% Response.Write("<script type=\"text/javascript\"> var page=" + Request["page"] + "; </script>"); %>
    <% Response.Write("<script type=\"text/javascript\"> var limit=" + Request["limit"] + "; </script>"); %>
    <% Response.Write("<script type=\"text/javascript\"> var loaidh=" + Request["loaidh"] + "; </script>"); %>
    
    <div><input id="QuayLai" type="button" value="Quay lai" onclick="QuayLai_Click()"/></div>
    
    <div id="Th_ds_QuaTang">
        
    </div>
    <script type = "text/javascript">
    XL_MON_AN.LayDanhSachQuaTang();
    document.getElementById('pathway').innerHTML += 'Danh sách quà tặng';
    </script>

</asp:Content>