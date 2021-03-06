using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class He_Phuc_Vu_XL_KHThongTinGiaoDich : System.Web.UI.Page
{
    delegate void ThongTinDonHang(int maKhachHang, out int soLuongDonHang, out decimal tongTriGia);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        // Xử lý request
        int maKhachHang = (int) Session["MaNguoiDung"];
        DonHangBUS bus = new DonHangBUS();

        XL_THE Kq = new XL_THE("DANH_SACH");

        int soLuongDonHang;
        decimal tongTriGia;
        string[] dienGiai = new string[] 
            {"Đơn hàng khách hàng đã lưu", 
            "Đơn hàng đã đặt hàng nhưng chưa thanh toán",
            "Đơn hàng đã thanh toán nhưng chưa giao hàng", 
            "Đơn hàng đã hoàn tất",
            "Đơn hàng trong ngày (đã đặt hàng)",
            "Đơn hàng định kỳ"};
        ThongTinDonHang[] arrFunction = new ThongTinDonHang[] 
            { bus.ThongTinDonHangDaLuu, bus.ThongTinDonHangDaDatChuaThanhToan,
              bus.ThongTinDonHangDaThanhToanChuaGiao, bus.ThongTinDonHangDaHoanTat,
              bus.ThongTinDonHangTrongNgay, bus.ThongTinDonHangDinhKy};

        for (int i = 1; i <= 6; i++)
        {
            XL_THE the = new XL_THE("GiaoDich");
            arrFunction[i - 1](maKhachHang, out soLuongDonHang, out tongTriGia);

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaLoai", i.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("DienGiai", dienGiai[i - 1]);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("SoLuongDonHang", soLuongDonHang.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TongTriGia", tongTriGia.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
