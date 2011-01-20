<%@ Page  Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="CapNhatThongTinCongTy.aspx.cs" Inherits="CapNhatThongTinCongTy" %>

<%@ Register Src="UserControl/MultipleFileUpload.ascx" TagName="MultipleFileUpload"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <form id="form2" runat="server">
    <table border="0">
        <tr>
            <td style="width: 134217727px; height: 19px;">
                Tên Công Ty</td>
            <td style="width: 329px; height: 19px;">
                <input id="txtTenCongTy" type="text" style="width: 342px" onblur="XL_CongTy.KiemTraDuLieuNhap(document.getElementById('txtTenCongTy').value, 'divTenCongTy', 0);"/>
                <div id="divTenCongTy" style="width: 25px; position: absolute; height: 19px">
                </div>
            </td>
            <td style="width: 373px; height: 19px">
            </td>
            <td style="width: 373px; height: 19px">
            </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 26px;">
                Địa Chỉ</td>
            <td style="width: 329px; height: 26px;">
                <input id="txtDiaChi" type="text" style="width: 342px" onblur="XL_CongTy.KiemTraDuLieuNhap(document.getElementById('txtDiaChi').value, 'divDiaChi', 0);"/>
                <div id="divDiaChi" style="width: 25px; position: absolute; height: 19px">
                </div>
            </td>
            <td style="width: 373px; height: 26px">
            </td>
            <td style="width: 373px; height: 26px">
            </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 30px;">
                Điện Thoại</td>
            <td style="width: 329px; height: 30px;">
                <input id="txtDienThoai" type="text" style="width: 343px" onblur="XL_CongTy.KiemTraDuLieuNhap(document.getElementById('txtDienThoai').value, 'divDienThoai', 1);"/>
                <div id="divDienThoai" style="width: 25px; position: absolute; height: 19px">
                </div>
            </td>
            <td style="width: 373px; height: 30px">
            </td>
            <td style="width: 373px; height: 30px">
            </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 29px;">
                Điện Thoại Admin</td>
            <td style="width: 329px; height: 29px;">
                <input id="txtDienThoaiAdmin" type="text" style="width: 343px" onblur="XL_CongTy.KiemTraDuLieuNhap(document.getElementById('txtDienThoaiAdmin').value, 'divDienThoaiAdmin', 1);"/>
                <div id="divDienThoaiAdmin" style="width: 25px; position: absolute; height: 19px">
                </div>
            </td>
            <td style="width: 373px; height: 29px">
            </td>
            <td style="width: 373px; height: 29px">
            </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 9px; vertical-align: top; text-align: left;">
                Logo</td>
            <td style="width: 329px; height: 9px;">
                <br />
                <asp:FileUpload ID="FileUpload2" runat="server" Width="301px" />
                <input id="radLogo1" type="radio" checked="CHECKED" onclick="XL_CongTy.radLogo1_change();"/>
                &nbsp; &nbsp; &nbsp;<br />
                &nbsp;<br />
                <input id="txtLogo1" style="width: 302px" type="text" disabled="disabled" />
                <input id="radLogo2" type="radio" onclick="XL_CongTy.radLogo2_change()"/><br />
                <br />
                <td style="width: 373px; height: 9px">
                </td>
                <td style="width: 373px; height: 9px">
                </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 16px;">
                Banner</td>
            <td style="width: 329px; height: 16px;">
                <br />
                <br />
                <br />
                <asp:FileUpload ID="FileUpload3" runat="server" Width="303px" />
                <input id="radBanner1" type="radio" checked="CHECKED" onclick="XL_CongTy.radBanner1_change()"/><br />
                <br />
                <br />
                <input id="txtBanner" style="width: 302px" type="text" disabled="disabled" />
                <input id="radBanner2" type="radio" onclick="XL_CongTy.radBanner2_change()"/><br />
                <br />
                <td style="width: 373px; height: 16px">
                </td>
                <td style="width: 373px; height: 16px">
                </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 34px; vertical-align: top; text-align: left;" align="left">
                Mô Tả<img id="picLogo" src="" style="left: 495px; width: 93px; position: relative;
                    top: -234px; height: 89px" />
                <img id="picBanner" src="" style="left: 532px; width: 93px; position: relative; top: -190px;
                    height: 88px" /></td>
            <td style="width: 329px; height: 34px;">
                <textarea id="txtMoTa" style="width: 467px; height: 169px" onblur="XL_CongTy.KiemTraDuLieuNhap(document.getElementById('txtMoTa').value, 'divMoTa', 0);"></textarea>
                <div id="divMoTa" style="width: 25px; position: absolute; height: 19px">
                </div>
            </td>
            <td style="width: 373px; height: 34px">
            </td>
            <td style="width: 373px; height: 34px">
            </td>
        </tr>
        <tr>
            <td style="width: 134217727px; height: 16px;">
            </td>
            <td style="width: 329px; height: 16px;">
            </td>
            <td style="width: 373px; height: 16px">
            </td>
            <td style="width: 373px; height: 16px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" runat="server" OnClientClick="XL_CongTy.CapNhatThongTin();" OnClick="Button1_Click" Text="Cap Nhat" /></td>
            <td align="center" colspan="1">
            </td>
            <td align="center" colspan="1">
            </td>
        </tr>
    </table>
    </form>
</asp:Content>