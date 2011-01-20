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
/// Summary description for ThamSo
/// </summary>
public class ThamSoDTO
{
    decimal _giaTriDiemSo;   //đơn hàng đã thanh toán cứ mỗi 100.000 được tính thành 1 điểm
    int _diemKhachHangThanThiet; //điểm để dc tính là khách hàng thân thiết
    Double _tiLeGiamGiaThucDon; //giá 1 thực đơn = tổng giá các món - tổng giá các món * tỉ lệ giảm
    Double _thue;               // thuế VAT 0,1
    decimal _giaTriDoiDiemKhuyenMai; // khi thanh toán hóa đơn đơn, 1 điểm khuyến mãi = 5000
    Double _gioiHanDoiDiemKhuyenMai; // 1 đơn hàng chỉ được dùng điểm khuyến mãi = 50% giá trị đơn hàng

    public decimal GiaTriDiemSo
    {
        get { return _giaTriDiemSo; }
        set { _giaTriDiemSo = value; }
    }
    public int DiemKhachHangThanThiet
    {
        get { return _diemKhachHangThanThiet; }
        set { _diemKhachHangThanThiet = value; }
    }
    public Double TiLeGiamGiaThucDon
    {
        get { return _tiLeGiamGiaThucDon; }
        set { _tiLeGiamGiaThucDon = value; }
    }
    public Double Thue
    {
        get { return _thue; }
        set { _thue = value; }
    }
    public decimal GiaTriDoiDiemKhuyenMai
    {
        get { return _giaTriDoiDiemKhuyenMai; }
        set { _giaTriDoiDiemKhuyenMai = value; }
    }
    public Double GioiHanDoiDiemKhuyenMai
    {
        get { return _gioiHanDoiDiemKhuyenMai; }
        set { _gioiHanDoiDiemKhuyenMai = value; }
    }


	public ThamSoDTO()
	{
        GiaTriDiemSo = 0;
        DiemKhachHangThanThiet = 0;
        TiLeGiamGiaThucDon = 0;
        Thue = 0;
        GiaTriDoiDiemKhuyenMai = 0;
        GioiHanDoiDiemKhuyenMai = 0;
	}
}
