using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for NguoiDungBUS
/// </summary>
public class NguoiDungBUS
{
    NguoiDungDAO ndDAO = new NguoiDungDAO();

    public bool CapNhatThongTinNguoiDung(NguoiDungDTO ndDto)
    {
        return ndDAO.CapNhatThongTinNguoiDung(ndDto);
    }

    public NguoiDungDTO LayThongTinNguoiDung(string username)
    {
        return ndDAO.LayThongTinNguoiDung(username);
    }

    public NguoiDungDTO KiemTraAccount(string username, string password)
    {

        return ndDAO.KiemTraAccount(username, password);
    }

    public bool CapNhatThongTinMatKhau(string Password, int Ma_nguoi_dung)
    {

        return ndDAO.CapNhatThongTinMatKhau(Password, Ma_nguoi_dung);
    }

    public int ThemNguoiDung(NguoiDungDTO nguoidungDTO)
    {

        return ndDAO.ThemNguoiDung(nguoidungDTO);
    }

    public NguoiDungDTO[] LayDanhSachNguoiDung(int pageNum, int pageSize)
    {
        return ndDAO.LayDanhSachNguoiDung(pageNum, pageSize);
    }
    public bool XoaNguoiDung(int maNguoiDung)
    {
        return ndDAO.XoaNguoiDung(maNguoiDung);
    }
    public bool CapNhatTinhTrangKichHoat(bool tinhTrangKichHoat, int maNguoiDung)
    {
        return ndDAO.CapNhatTinhTrangKichHoat(tinhTrangKichHoat, maNguoiDung);
    }
    public int TongSoNguoiDung()
    {
        return ndDAO.TongSoNguoiDung();
    }

    // Khoa
    // Lấy thông tin người dùng
    public NguoiDungDTO ThongTinNguoiDung(int maNguoiDung)
    {
        return ndDAO.ThongTinNguoiDung(maNguoiDung);
    }

}
