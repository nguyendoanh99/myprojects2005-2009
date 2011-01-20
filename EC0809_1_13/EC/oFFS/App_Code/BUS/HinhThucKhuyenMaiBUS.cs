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
/// Summary description for HinhThucKhuyenMaiBUS
/// </summary>
public class HinhThucKhuyenMaiBUS
{
	public HinhThucKhuyenMaiBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    HinhThucKhuyenMaiDAO htkmDao = new HinhThucKhuyenMaiDAO();
    public HinhThucKhuyenMaiDTO[] LayDanhSachHTKM()
    {
        return htkmDao.LayDanhSachHTKM();
    }
    public HinhThucKhuyenMaiDTO ThongTinHTKM(int maHinhThucKhuyenMai)
    {
        return htkmDao.ThongTinHTKM(maHinhThucKhuyenMai);
    }
}
