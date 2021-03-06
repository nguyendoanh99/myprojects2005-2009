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

public partial class He_Phuc_Vu_XL_ThongTinBanHang : System.Web.UI.Page
{
    delegate int TongDonHang ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "NhanVien" && Session["LoaiNguoiDung"] != "QuanLy")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        // Xử lý request        
        DonHangBUS bus = new DonHangBUS();

        XL_THE Kq = new XL_THE("DANH_SACH");

        int soLuongDonHang;
        string[] dienGiai = new string[] 
            {"Đơn hàng đã đặt hàng nhưng chưa thanh toán và giao hàng",
            "Đơn hàng đã thanh toán nhưng chưa giao hàng",             
            "Đơn hàng đã hoàn tất trong ngày"};
        TongDonHang[] arrFunction = new TongDonHang[] 
            { bus.TongDonHangChuaThanhToanChuaGiao,
              bus.TongDonHangDaThanhToanChuaGiao, bus.TongDonHangDaHoanTatTrongNgay};

        for (int i = 1; i <= dienGiai.Length; i++)
        {
            XL_THE the = new XL_THE("BanHang");
            soLuongDonHang = arrFunction[i - 1]();

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaLoai", i.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("DienGiai", dienGiai[i - 1]);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("SoLuongDonHang", soLuongDonHang.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
