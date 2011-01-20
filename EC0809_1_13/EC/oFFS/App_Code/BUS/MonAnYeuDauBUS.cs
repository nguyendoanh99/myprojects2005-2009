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
/// Summary description for MonAnYeuDauBUS
/// </summary>
public class MonAnYeuDauBUS
{
	public MonAnYeuDauBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    MonAnYeuDauDAO dao = new MonAnYeuDauDAO();
    public int ThemMonAnYeuDau(MonAnYeuDauDTO dto)
    {        
        return dao.ThemMonAnYeuDau(dto);
    }

    public void XoaMonAnYeuDau(int makhachhang, int mamon)
    {
        dao.XoaMonAnYeuDau(makhachhang, mamon);
    }

    public MonAnYeuDauDTO[] LayDSMonAnYeuThich(int makhachhang)
    {
        return dao.LayDSMonAnYeuThich(makhachhang);
    }
}
