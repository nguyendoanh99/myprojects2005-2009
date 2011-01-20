<%@ Page Language="C#" MasterPageFile="~/MPInstock_Guest.master" AutoEventWireup="true" CodeFile="FormTimKiemNangCao.aspx.cs" Inherits="FormTimKiemNangCao" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">    
    <script type = "text/javascript" src="He Khach/XL_LoaiThucDon.js"></script>
    <script type = "text/javascript" src="He Khach/XL_ThucDon.js"></script>
    <script type = "text/javascript" src="He Khach/XL_LoaiMon.js"></script>
    <script type = "text/javascript" src="He Khach/XL_MonAn.js"></script>
    <table style="width: 588px; height: 105px">
        <tr>
            <td colspan="3" style="font-size: 20px; vertical-align: middle; height: 30px; text-align: center">
                TÌM KIẾM NÂNG CAO</td>
        </tr>
        <tr>
            <td colspan="3" style="height: 32px">
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Tên Món/Thực đơn
                :</td>
            <td colspan="2">
                <input id="txtTenItem" style="width: 310px" type="text" /></td>
        </tr>
        <tr>
            <td style="width: 198px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Loại Món/Thực đơn
                :</td>
            <td colspan="2">
                <select id="cmbLoaiItem" style="width: 183px">
                    <option selected="selected"></option>
                </select>
                <script type="text/javascript">
                XL_LoaiMon.LoadDSLoaiMon('cmbLoaiItem')
                XL_LoaiThucDon.LoadDSLoaiThucDon('cmbLoaiItem')          
                document.getElementById('pathway').innerHTML += 'Tìm kiếm nâng cao';      
                </script>
            </td>
        </tr>
        <tr>
            <td style="width: 198px; height: 22px;">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Tag :
            </td>
            <td colspan="2" style="height: 22px">
                <input id="txtTag" style="width: 309px" type="text" /></td>
        </tr>
        <tr>
            <td style="width: 198px">
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Giá :</td>
            <td colspan="2">
                từ
                <select id="cmbGiaMin" style="width: 144px">
                    <option selected="selected" value='null'></option>
                    <option value="10000">10000</option>
                    <option value="20000">20000</option>
                    <option value="30000">30000</option>
                    <option value="50000">50000</option>
                    <option value="100000">100000</option>
                    <option value="200000">200000</option>
                </select>
                &nbsp; đến
                <select id="cmbGiaMax" style="width: 132px">
                    <option selected="selected" value='null'></option>
                    <option value="20000">20000</option>
                    <option value="50000">50000</option>
                    <option value="100000">100000</option>
                    <option value="200000">200000</option>
                    <option value="500000">500000</option>
                </select>
            </td>
        </tr>
        <tr>
            <td style="width: 198px">
            </td>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="3" style="vertical-align: middle; text-align: center">
                <input id="Button1" type="button" value="Tim Kiem" onclick="return Button1_onclick()"/></td>
                <script type = "text/javascript">
                function Button1_onclick() 
                {
                    XL_MON_AN.GhiNhanTimKiemNangCao(document.getElementById('txtTenItem').value, document.getElementById('cmbLoaiItem'), document.getElementById('txtTag').value, document.getElementById('cmbGiaMin'), document.getElementById('cmbGiaMax'));
                }
                </script>
        </tr>
    </table>

</asp:Content>