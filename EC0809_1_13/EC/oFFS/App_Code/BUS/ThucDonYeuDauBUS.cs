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
/// Summary description for ThucDonYeuDauBUS
/// </summary>
public class ThucDonYeuDauBUS
{
	public ThucDonYeuDauBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    ThucDonYeuDauDAO dao = new ThucDonYeuDauDAO();
    public int ThemThucDon(ThucDonUaThich thucdon)
    {
        return dao.ThemThucDon(thucdon);
    }
    public ThucDonUaThich[] LayDSThucDonYeuThich(int makhachhang)
    {
        return dao.LayDSThucDonYeuThich(makhachhang);
    }
    public void XoaThucDonYeuThich(int makhachhang, int mathucdon)
    {
        dao.XoaThucDonYeuThich(makhachhang, mathucdon);
    }
}
