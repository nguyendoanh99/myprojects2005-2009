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

public partial class He_Phuc_Vu_XL_KHXemDanhSachDonHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }

        string r = (string)Request["request"];
        int request = -1;
     
        if (r == "XoaDonHang")
        {
            XoaDonHang();
            return;
        }
        if (r == "LayDanhSachDonHangDaLuu")
            request = 0;
        else if (r == "LayDanhSachDonHangDaDatChuaThanhToan")
            request = 1;
        else if (r == "LayDanhSachDonHangDaThanhToanChuaGiao")
            request = 2;
        else if (r == "LayDanhSachDonHangDaHoanTat")
            request = 3;
        else if (r == "LayDanhSachDonHangTrongNgay")
            request = 4;
        else if (r == "LayDanhSachDonHangDinhKy")
            request = 5;
        

        LayDanhSachDonHang(request);
    }
    private void XoaDonHang()
    {
        string strMaDonHang = (string)Request["MaDonHang"];

        int maDonHang = int.Parse(strMaDonHang);
        DonHangBUS bus = new DonHangBUS();
        bool flag = bus.XoaDonHang(maDonHang);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    delegate DonHangDTO[] XemDanhSachDonHang(int maKhachHang, int pageNum, int pageSize);
    delegate int TongDonHang(int maKhachHang);
    private void LayDanhSachDonHang(int request)
    {
        DonHangBUS bus = new DonHangBUS();
        DonHangDinhKyBUS dhdkBUS = new DonHangDinhKyBUS();
        XemDanhSachDonHang[] arrFuncXemDanhSach = new XemDanhSachDonHang[] 
            { bus.DanhSachDonHangDaLuu, bus.DanhSachDonHangDaDatChuaThanhToan,
              bus.DanhSachDonHangDaThanhToanChuaGiao, bus.DanhSachDonHangDaHoanTat,
              bus.DanhSachDonHangTrongNgay, dhdkBUS.DanhSachDonHangDinhKy};
        TongDonHang[] arrFuncTongDonHang = new TongDonHang[]
            {
                bus.TongDonHangDaLuu, bus.TongDonHangDaDatChuaThanhToan,
                bus.TongDonHangDaThanhToanChuaGiao, bus.TongDonHangDaHoanTat,
                bus.TongDonHangTrongNgay, bus.TongDonHangDinhKy
            };

        int maKhachHang = (int)Session["MaNguoiDung"];
        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;

        // Lấy danh sách đơn hàng
        
        DonHangDTO[] kq = arrFuncXemDanhSach[request](maKhachHang, pageNum, pageSize);
        int tongDonHang = arrFuncTongDonHang[request](maKhachHang);

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", tongDonHang.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (DonHangDTO dto in kq)
        {
            XL_THE the = new XL_THE("DonHang");

            Thuoc_tinh = new XL_THUOC_TINH("MaDonHang", dto.Ma_don_hang.ToString());
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

            
            if (request == 5) // đơn hàng định kỳ
            {
                DonHangDinhKyDTO dhdk = (DonHangDinhKyDTO)dto;

                Thuoc_tinh = new XL_THUOC_TINH("LoaiDinhKy", dhdk.Loai_dinh_ky);
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("NgayBatDau", dhdk.Ngay_bat_dau.ToString());
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("NgayKetThuc", dhdk.Ngay_ket_thuc.ToString());
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("NgayGiao", dhdk.Ngay_giao.ToString());
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("ThuGiao", dhdk.Thu_giao.ToString());
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("GioGiao", dhdk.Gio_giao.ToString());
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                Thuoc_tinh = new XL_THUOC_TINH("TinhTrang", dhdk.Tinh_trang ? "1" : "0");
                the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            }

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
