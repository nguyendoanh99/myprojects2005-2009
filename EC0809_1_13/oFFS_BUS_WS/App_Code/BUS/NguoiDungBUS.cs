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
    public oFFS_DAL_WS.NguoiDungDTO KiemTraAccount(string username, string password)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.KiemTraAccount(username, password);
    }

    public bool CapNhatTongTinMatKhau(string Password, int Ma_nguoi_dung)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.CapNhatTongTinMatKhau(Password, Ma_nguoi_dung);
    }

    public int ThemNguoiDung(oFFS_DAL_WS.NguoiDungDTO nguoidungDTO)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.ThemNguoiDung(nguoidungDTO);
    }
}
