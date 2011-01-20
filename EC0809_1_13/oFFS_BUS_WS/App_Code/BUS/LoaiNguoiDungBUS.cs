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
/// Summary description for LoaiNguoiDungBUS
/// </summary>
public class LoaiNguoiDungBUS
{
    public oFFS_DAL_WS.LoaiNguoiDungDTO[] LayDanhSachLoaiNguoiDung()
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.LayDanhSachLoaiNguoiDung();
    }
}
