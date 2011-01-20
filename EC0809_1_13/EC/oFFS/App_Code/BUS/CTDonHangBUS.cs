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
/// Summary description for CTDonHangBUS
/// </summary>
public class CTDonHangBUS
{
	public CTDonHangBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    CTDonHangDAO ctdhDAO = new CTDonHangDAO();
    public int ThemChiTietDonHang(CTDonHangDTO ctdonhang)
    {
        return ctdhDAO.ThemChiTietDonHang(ctdonhang);
    }
    // Lấy danh sách chi tiết đơn hàng
    public CTDonHangDTO[] DanhSachCTDonHang(int maDonHang)
    {
        return ctdhDAO.DanhSachCTDonHang(maDonHang);
    }

}
