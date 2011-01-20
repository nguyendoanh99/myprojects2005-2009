<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="AddToCard.aspx.cs" Inherits="AddToCard" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    
<script type ="text/javascript" src = "He Khach/XL_GioHang.js"></script>
    
    <div>
        <div id="Th_Gio_hang" style="left: 10px; top: 5px;">
        </div>
        <div style="width: 100px; height: 100px; left: -341px; position: absolute; top: 9px;">
            &nbsp;</div>
        <input type="hidden" id="txtloaind" runat="server"/>      
    </div>  
      
    <script type="text/javascript">
        nodeLoaiND = document.getElementById('<%=txtloaind.ClientID%>');
    </script>
</asp:Content>
