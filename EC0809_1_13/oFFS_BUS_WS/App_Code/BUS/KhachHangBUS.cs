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
    public int ThemKhachHang(oFFS_DAL_WS.KhachHangDTO khachhang, oFFS_DAL_WS.TheThanhToanDTO the)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.ThemKhachHang(khachhang, the);
    }

    public oFFS_DAL_WS.viewKhachHangDTO LayThongTinKhachHang(string username)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.LayThongTinKhachHang(username);
    }

    public bool CapNhatThongTinKhachHang(oFFS_DAL_WS.viewKhachHangDTO viewKH)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.CapNhatThongTinKhachHang(viewKH);
    }
}
