<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="AddToGifts.aspx.cs" Inherits="AddToGifts" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1"> 
    <% Response.Write("<script type=\"text/javascript\"> var lbSoTien=" + Request["lbSoTien"] + "; </script>"); %>   
    <% Response.Write("<script type=\"text/javascript\"> var loaidh=" + Request["loaidh"] + "; </script>"); %>   
    <div>
        <div id="Th_Gio_QT" style="left: 10px; top: 5px;">
        </div>
        <div style="width: 100px; height: 100px; left: -341px; position: absolute; top: 9px;">
            &nbsp;</div>
    
    </div>    
</asp:Content>
