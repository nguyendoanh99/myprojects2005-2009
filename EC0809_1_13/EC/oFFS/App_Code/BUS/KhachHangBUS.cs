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
/// Summary description for KhachHangBUS
/// </summary>
public class KhachHangBUS
{
    KhachHangDAO khDAO = new KhachHangDAO();
    public int ThemKhachHang(KhachHangDTO khachhang, TheThanhToanDTO the)
    {
        return khDAO.ThemKhachHang(khachhang, the);
    }

    public viewKhachHangDTO LayThongTinKhachHang(string username)
    {
        return khDAO.LayThongTinKhachHang(username);
    }

    public bool CapNhatThongTinKhachHang(viewKhachHangDTO viewKH)
    {
        return khDAO.CapNhatThongTinKhachHang(viewKH);
    }

    public void CapNhatDiemKhuyenMai(int makh, int diemmoi)
    {
        khDAO.CapNhatDiemKhuyenMai(makh, diemmoi);
    }
}
