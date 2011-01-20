<%@ Page Language="C#" MasterPageFile="~/MPAdmin.master" AutoEventWireup="true" CodeFile="ThemQuangCao.aspx.cs" Inherits="ThemQuangCao" %>


<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<script type="text/javascript" src="He Khach/XL_QuangCao.js"></script>
<script language="javascript" type="text/javascript">
<!--

function Text1_onclick() {

}

// -->
</script>

    
    <div id="Div1" align="center" style="font-size: x-large; left: 114px; width: 349px;
        position: relative; top: 5px; height: 36px">
        THÊM QUẢNG CÁO</div>
        <form id="Form1" runat="server">
    <table style="left: 0px; width: 629px; position: relative; top: 24px; height: 285px">
        <tr>
            <td style="width: 110px; height: 41px">
                Tên Công Ty :</td>
            <td style="height: 41px; width: 442px;">
                <input id="txtTen" style="width: 335px" type="text" language="javascript" onclick="return Text1_onclick()" onblur="XL_QUANG_CAO.KiemTraTenQuangCao(document.getElementById('txtTen').value, 'divTen');"/>
                <div id="divTen" style="left: 345px; position: relative; top: -14px; color: red;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 40px">
                Địa Chỉ :</td>
            <td style="height: 40px; width: 442px;">
                <input id="txtDiaChi" style="width: 333px" type="text" onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtDiaChi').value, 'divDiaChi', 0);"/>
                <div id="divDiaChi" style="left: 341px; width: 27px; position: relative; top: -18px;
                    height: 18px; color: red;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 40px">
                Webstie</td>
            <td style="height: 40px; width: 442px;">
                <input id="txtWebsite" style="width: 336px" type="text" onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtWebsite').value, 'divWebsite', 1);"/>
                <div id="divWebsite" style="left: 343px; width: 27px; position: relative; top: -13px;
                    height: 20px; color: red;">
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 110px; height: 30px">
                Vị Trí :</td>
            <td style="height: 30px; width: 442px;">
                &nbsp;<table style="width: 515px">
                    <tr>
                        <td rowspan="3" style="width: 256px">
                            <select id="lstWebsite" size="7" style="width: 236px; height: 175px">
                            </select>
                            <script type="text/javascript">
                            XL_QUANG_CAO.Lay_danh_sach_website('lstWebsite', null);
                            </script>
                        </td>
                        <td rowspan="3" style="vertical-align: middle; width: 58px; text-align: center">
                            <input id="Button>" onclick="XL_QUANG_CAO.ChonWebsite('lstWebsite', 'lstWebsiteDaChon')" style="width: 25px;
                                height: 18px" type="button" value=">" />
                            <input id="Button>>" onclick="XL_QUANG_CAO.ChonHetWebsite('lstWebsite', 'lstWebsiteDaChon')" style="width: 25px;
                                height: 18px" type="button" value=">>" />
                            <input id="Button<" onclick="XL_QUANG_CAO.ChonWebsite('lstWebsiteDaChon', 'lstWebsite')" style="width: 25px;
                                height: 18px" type="button" value="<" />
                            <input id="Button<<" onclick="XL_QUANG_CAO.ChonHetWebsite('lstWebsiteDaChon', 'lstWebsite')" style="width: 25px;
                                height: 18px" type="button" value="<<" />
                        </td>
                        <td rowspan="3">
                            <select id="lstWebsiteDaChon" size="7" style="width: 226px; height: 175px">
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
            <td style="width: 110px; height: 40px;">
                Logo :</td>
            <td style="width: 442px; height: 40px;">
                &nbsp;&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" Width="333px" />
                <input id="radLogo1" type="radio" onclick="XL_QUANG_CAO.radLogo1_change();" checked="CHECKED"/><br />
                <br />
                &nbsp;
                <input id="txtLogo" style="width: 331px" type="text" disabled="disabled"  onblur="XL_QUANG_CAO.KiemTraDuLieuNhap(document.getElementById('txtLogo').value, 'divLogo', 1);"/>
                <input id="radLogo2" type="radio" onclick="XL_QUANG_CAO.radLogo2_change();"/>
                <div id="divLogo" style="left: 372px; width: 27px; position: relative; top: -22px;
                    height: 20px; color: red";>
                </div>
            </td>                
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 16px">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="height: 16px">
                <asp:Button ID="Button1" runat="server" OnClientClick="javascript:XL_QUANG_CAO.ThemQuangCao();" OnClick="Button1_Click1" Text="Thêm" />
                <input id="Reset1" style="left: 20px; position: relative; top: -1px" type="reset"
                    value="Hủy Bỏ" /></td>                    
        </tr>
    </table>
    </form>
</asp:Content>
