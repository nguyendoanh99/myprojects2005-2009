<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="ThongTinCongTy.aspx.cs" Inherits="ThongTinCongTy" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table border="0" >    
        <tr>
            <td colspan="3" style="font-size: x-large; vertical-align: middle; text-align: center; height: 29px;">
                THÔNG TIN CÔNG TY</td>
        </tr>
        <tr>
            <td style="width: 243px; height: 14px">
                Tên&nbsp;</td>
            <td colspan="2" style="width: 452px; height: 14px">
                <div id="LabTenCongTy">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px">
                Địa chỉ</td>
            <td colspan="2" style="width: 452px; height: 33px">
                <div id="LabDiaChi">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px">
                Điện thoại</td>
            <td colspan="2" style="width: 452px; height: 33px">
                <div id="LabDienThoai">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px">
                Điện thoại admin</td>
            <td colspan="2" style="width: 452px; height: 33px">
                <div id="LabDienThoaiAdmin">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px; vertical-align: top; text-align: left;">
                Logo</td>
            <td colspan="2" style="width: 452px; height: 33px" align = "left">
                <img id="picLogo" alt="Logo cong ty" style="top: -1px; width: 150px; height: 150px;"/></td>
        </tr>
        <tr>
            <td style="vertical-align: top; width: 243px; height: 24px; text-align: left">
            </td>
            <td align="left" colspan="2" style="width: 452px; height: 24px">
            </td>
        </tr>
        <tr>
            <td style="width: 243px; height: 33px; vertical-align: top; text-align: left;">
                Banner</td>
            <td colspan="2" style="width: 452px; height: 33px">
                <img id="picBanner" alt="Banner cong ty" style="top: -1px; width: 150px; height: 150px;"/></td>
        </tr>
        <tr>
            <td style="width: 243px; height: 32px">
                Mô tả</td>
            <td colspan="2" style="width: 452px; height: 32px" align="left" valign="middle">
                <div id="LabMoTa">
                </div>
                </td>
        </tr>
        <tr>
            <td colspan="3" style="height: 32px" align ="center">
                <input id="Button1" style="width: 70px; height: 23px" type="button" value="Chỉnh Xửa" onclick="return Button1_onclick()" /></td>
        </tr>
    </table>
    <script type ="text/javascript">
    XL_CongTy.HienThiThongTin();
function Button1_onclick() {
window.location = "CapNhatThongTinCongTy.aspx"
}

    </script>
</asp:Content>