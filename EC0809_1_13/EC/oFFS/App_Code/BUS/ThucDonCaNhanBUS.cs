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
/// Summary description for ThucDonCaNhanBUS
/// </summary>
public class ThucDonCaNhanBUS
{
    ThucDonCaNhanDAO dao = new ThucDonCaNhanDAO();
    public int ThemThucDon(ThucDonCaNhanDTO thucdon, String[] strDsMaMon)
    {
        return dao.ThemThucDon(thucdon, strDsMaMon);
    }

    public int[] MonAnThuocThucDonCaNhan(int maThucDonCaNhan)
    {
        return dao.MonAnThuocThucDonCaNhan(maThucDonCaNhan);
    }

    public ThucDonCaNhanDTO[] LayDSThucDonYeuThich(int makhachhang)
    {
        return dao.LayDSThucDonTuTao(makhachhang);
    }
    // Lấy thông tin thực đơn cá nhân
    public ThucDonCaNhanDTO ChiTietThucDonCaNhan(int maThucDonCaNhan)
    {
        return dao.ChiTietThucDonCaNhan(maThucDonCaNhan);
    }
}
