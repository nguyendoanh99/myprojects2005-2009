<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="CapNhatThongTinQuangCao.aspx.cs" Inherits="CapNhatThongTinQuangCao" %>

<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script language="javascript" type="text/javascript">
<!--

function txtLogo_onclick() {

}

// -->
</script>

    &nbsp;<div id="Div1" style="font-size: x-large; left: 8px; width: 425px; position: relative;
        top: -6px; height: 36px">
        CẬP NHẬT THÔNG TIN QUẢNG CÁO</div>
        <form id="form3" runat="server">
    <table border="0" style="left: 0px; width: 640px; position: relative; top: 0px; height: 348px;">
        <tr>
            <td style="width: 265px">
            </td>
            <td colspan="2" style="width: 571px">
            </td>
        </tr>
        <tr>
            <td style="width: 265px; height: 45px">
                Tên Công Ty</td>
            <td colspan="2" style="height: 45px; width: 571px;">
                <input id="txtTen" style="width: 354px" type="text" onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtTen').value, 'divTen', 0);"/>
                <div id="divTen" style="width: 36px; position: absolute; height: 24px; left: 484px; top: 27px;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 265px; height: 45px">
                Địa Chỉ</td>
            <td colspan="2" style="height: 45px; width: 571px;">
                <input id="txtDiaChi" style="width: 354px" type="text" onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtDiaChi').value, 'divDiaChi', 0);"/>
                <div id="divDiaChi" style="width: 36px; position: absolute; height: 24px; left: 486px; top: 74px;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 265px; height: 45px">
                Website</td>
            <td colspan="2" style="height: 45px; width: 571px;">
                <input id="txtWebsite" style="width: 352px" type="text" onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtWebsite').value, 'divWebsite', 1);"/>
                <div id="divWebsite" style="width: 36px; position: absolute; height: 24px; left: 484px; top: 118px;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 265px; height: 7px">
                Logo</td>
            <td colspan="2" style="height: 7px; width: 571px;">
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" Width="279px" />
                <input id="radLogo1" type="radio" checked="CHECKED" onclick="XL_QUANG_CAO.radLogo1_change();"/><br />
                <br />
                <br />
                <input id="txtLogo" style="width: 278px" type="text" disabled="disabled" />
                <input id="radLogo2" type="radio" onclick="XL_QUANG_CAO.radLogo2_change()"/><br />
            </td>
        </tr>
        <tr>
            <td style="width: 265px; height: 45px">
                Website Hiển Thị</td>
            <td colspan="2" style="height: 45px; vertical-align: middle; width: 571px; text-align: center;">
                &nbsp;<table style="width: 515px">
                    <tr>
                        <td rowspan="3" style="width: 256px; height: 175px">
                            <select id="lstWebsite1" size="7" style="width: 236px; height: 175px">
                            </select>
                        </td>
                        <td rowspan="3" style="vertical-align: middle; width: 58px; height: 175px; text-align: center">
                            <input id="Button>" onclick="XL_QUANG_CAO.ChonWebsite('lstWebsite1', 'lstWebsiteDaChon1')"
                                style="width: 25px; height: 18px" type="button" value=">" />
                            <input id="Button>>" onclick="XL_QUANG_CAO.ChonHetWebsite('lstWebsite1', 'lstWebsiteDaChon1')"
                                style="width: 25px; height: 18px" type="button" value=">>" />
                            <input id="Button<" onclick="XL_QUANG_CAO.ChonWebsite('lstWebsiteDaChon1', 'lstWebsite1')"
                                style="width: 25px; height: 18px" type="button" value="<" />
                            <input id="Button<<" onclick="XL_QUANG_CAO.ChonHetWebsite('lstWebsiteDaChon1', 'lstWebsite1')"
                                style="width: 25px; height: 18px" type="button" value="<<" />
                        </td>
                        <td rowspan="3" style="height: 175px">
                            <select id="lstWebsiteDaChon1" size="7" style="width: 226px; height: 175px">
                            </select>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 265px">
                Trạng Thái</td>
            <td colspan="2" style="width: 571px">
                <input id="chkTrangThai" type="checkbox" language="javascript" /></td>
        </tr>
        <tr>
            <td style="width: 265px">
            </td>
            <td colspan="2" style="width: 571px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                &nbsp;<asp:Button ID="Button1" runat="server" OnClientClick="XL_QUANG_CAO.CapNhatThongTin();" OnClick="Button1_Click" Text="Cap Nhat" />
                <input id="Reset1" style="width: 75px" type="reset" value="Xóa" /></td>
        </tr>
    </table>
            <img id="imgLogo" src="" style="left: 443px; width: 90px; position: relative; top: -330px;
                height: 88px" /></form>
</asp:Content>
