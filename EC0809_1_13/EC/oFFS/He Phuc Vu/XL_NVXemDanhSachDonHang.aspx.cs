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

public partial class He_Phuc_Vu_XL_NVXemDanhSachDonHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "NhanVien" && Session["LoaiNguoiDung"] != "QuanLy")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }

        string r = (string)Request["request"];
        int request = -1;
        
        if (r == "LayDanhSachDonHangChuaThanhToanChuaGiao")
            request = 0;
        else if (r == "LayDanhSachDonHangDaThanhToanChuaGiao")
            request = 1;
        else if (r == "LayDanhSachDonHangDaHoanTatTrongNgay")
            request = 2;
        else if (r == "CapNhatTrangThai")
        {
            CapNhatTrangThai();
            return;
        }
        LayDanhSachDonHang(request);
    }
    void CapNhatTrangThai()
    {
        string strMaDonHang = (string)Request["MaDonHang"];
        int trangThai = int.Parse(Request["TrangThai"]);
        int maDonHang = int.Parse(strMaDonHang);

        DonHangBUS bus = new DonHangBUS();
        bool flag = false;
        
        DateTime now = DateTime.Now;
        if (trangThai == 0) // Cập nhật đã thanh toán
            flag = bus.CapNhatTrangThaiDaThanhToan(maDonHang, true);
        else if (trangThai == 1) // Cập nhật đã giao hàng (hoàn tất)
            flag = bus.CapNhatTrangThaiDaThanhToan(maDonHang, true) && bus.CapNhatTrangThaiDaGiaoHang(maDonHang, true)
                && bus.CapNhatNgayGioGiaoHang(maDonHang, now);
        
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        thuoctinh = new XL_THUOC_TINH("NgayGioGiaoHang", now.ToString());
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);

        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    delegate DonHangDTO[] XemDanhSachDonHang(int pageNum, int pageSize);
    delegate int TongDonHang();
    private void LayDanhSachDonHang(int request)
    {
        DonHangBUS bus = new DonHangBUS();
        DonHangDinhKyBUS dhdkBUS = new DonHangDinhKyBUS();
        XemDanhSachDonHang[] arrFuncXemDanhSach = new XemDanhSachDonHang[] 
            { bus.DanhSachDonHangChuaThanhToanChuaGiao, bus.DanhSachDonHangDaThanhToanChuaGiao,
              bus.DanhSachDonHangDaHoanTatTrongNgay};
        TongDonHang[] arrFuncTongDonHang = new TongDonHang[]
            {
                bus.TongDonHangChuaThanhToanChuaGiao, bus.TongDonHangDaThanhToanChuaGiao,
                bus.TongDonHangDaHoanTatTrongNgay
            };

        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;

        // Lấy danh sách đơn hàng

        DonHangDTO[] kq = arrFuncXemDanhSach[request](pageNum, pageSize);
        int tongDonHang = arrFuncTongDonHang[request]();

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", tongDonHang.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (DonHangDTO dto in kq)
        {
            XL_THE the = new XL_THE("DonHang");

            Thuoc_tinh = new XL_THUOC_TINH("MaDonHang", dto.Ma_don_hang.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            NguoiDungBUS ndBus = new NguoiDungBUS();
            NguoiDungDTO ndDTO = ndBus.ThongTinNguoiDung(dto.Ma_khach_hang);

            Thuoc_tinh = new XL_THUOC_TINH("TenKhachHang", ndDTO.Ho_ten);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayGioLap", dto.Ngay_gio_lap.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("DiaChiNhan", dto.Dia_chi_nhan);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NguoiNhan", dto.Nguoi_nhan);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayGioGiaoHang", dto.Ngay_gio_giao_hang.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("GiaTri", dto.Gia_tri.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
