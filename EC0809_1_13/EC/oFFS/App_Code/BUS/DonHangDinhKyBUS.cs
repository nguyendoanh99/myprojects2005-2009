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
/// Summary description for DonHangDinhKyBUS
/// </summary>
public class DonHangDinhKyBUS:DonHangBUS
{
    DonHangDinhKyDAO dhdkDAO = new DonHangDinhKyDAO();
    public bool ThemDonHangDinhKy(DonHangDinhKyDTO donhangdk)
    {
        return dhdkDAO.ThemDonHangDinhKy(donhangdk);
    }

    // Danh sách đơn hàng thuộc đơn hàng loại 6: đơn hàng định kỳ
    public DonHangDinhKyDTO[] DanhSachDonHangDinhKy(int maKhachHang, int pageNum, int pageSize)
    {
        return dhdkDAO.DanhSachDonHangDinhKy(maKhachHang, pageNum, pageSize);
    }
	public DonHangDinhKyBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool XoaDonHangDinhKy(int maDonHang)
    {
        return dhdkDAO.XoaDonHangDinhKy(maDonHang);
    }
    public DonHangDinhKyDTO LayThongTinDonHangDinhKy(int maDonHang)
    {
        return dhdkDAO.LayThongTinDonHangDinhKy(maDonHang);
    }
}
