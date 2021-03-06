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

public partial class He_Phuc_Vu_XL_KHXemChiTietDonHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];

        if (r == "LayThongTinDonHang")
        {
            LayThongTinDonHang();
            return;
        }
        if (r == "LayCTDonHang")
        {
            LayCTDonHang();
            return;
        }
    }

    private void LayCTDonHang()
    {
        int maDonHang = int.Parse(Request["MaDonHang"]);

        XL_THE kq = new XL_THE("DanhSachCTDonHang");

        CTDonHangBUS ctdhbus = new CTDonHangBUS();
        CTDonHangDTO[] arrCtdhDto = ctdhbus.DanhSachCTDonHang(maDonHang);
        foreach (CTDonHangDTO ctdh in arrCtdhDto)
        {
            XL_THE the = new XL_THE("CTDonHang");

            // mã chi tiết đơn hàng
            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaCTDonHang", ctdh.Ma_ct_don_hang.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

           
            string loai = "";
            string ten = "";
            switch (ctdh.Loai_item)
            {
                case 0: // món ăn
                    loai = "Món ăn";
                    MonAnBUS maBus = new MonAnBUS();
                    MonAnDTO ma = maBus.ChiTietMonAn(ctdh.Ma_item);
                    ten = ma.Ten_mon;
                    break;
                case 1: // thực đơn
                    loai = "Thực đơn";
                    ThucDonBUS tdBus = new ThucDonBUS();
                    ThucDonDTO tdDto = tdBus.ChiTietThucDon(ctdh.Ma_item);
                    if (tdDto == null)
                        ten = "Không có trong csdl";
                    else
                        ten = tdDto.Ten_thuc_don;
                    break;
                case 2: // thực đơn cá nhân
                    loai = "Thực đơn cá nhân";
                    ThucDonCaNhanBUS tdcnBus = new ThucDonCaNhanBUS();
                    ThucDonCaNhanDTO tdcnDto = tdcnBus.ChiTietThucDonCaNhan(ctdh.Ma_item);
                    ten = tdcnDto.Ten_thuc_don;
                    break;
            }

            // Tên món hoặc tên thực đơn
            Thuoc_tinh = new XL_THUOC_TINH("Ten", ten);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            // Loại đơn hàng
            Thuoc_tinh = new XL_THUOC_TINH("LoaiItem", loai);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            // Số lượng
            Thuoc_tinh = new XL_THUOC_TINH("SoLuong", ctdh.So_luong.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            // Thành tiền
            Thuoc_tinh = new XL_THUOC_TINH("ThanhTien", ctdh.Thanh_tien.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, kq.Chuoi());
    }
    private void LayThongTinDonHang()
    {
        DonHangBUS bus = new DonHangBUS();

        int maDonHang = int.Parse(Request["MaDonHang"]);

        DonHangDTO dhDTO = bus.LayThongTinDonHang(maDonHang);

        XL_THE kq = new XL_THE("DonHang");

        NguoiDungBUS ndBUS = new NguoiDungBUS();
        NguoiDungDTO ndDTO = ndBUS.ThongTinNguoiDung(dhDTO.Ma_khach_hang);

        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("TenKhachHang", ndDTO.Ho_ten);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("NgayGioLap", dhDTO.Ngay_gio_lap.ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("DiaChiNhan", dhDTO.Dia_chi_nhan.ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("NguoiNhan", dhDTO.Nguoi_nhan);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        HinhThucKhuyenMaiBUS htkmBus = new HinhThucKhuyenMaiBUS();
        HinhThucKhuyenMaiDTO htkmDto = htkmBus.ThongTinHTKM(dhDTO.Hinh_thuc_khuyen_mai);
        string tenHinhThucKhuyenMai = "Không có";
        if (htkmDto != null)
            tenHinhThucKhuyenMai = htkmDto.Ten_hinh_thuc_khuyen_mai;
        Thuoc_tinh = new XL_THUOC_TINH("HinhThucKhuyenMai", tenHinhThucKhuyenMai);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("TienKhuyenMai", dhDTO.Tien_khuyen_mai.ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("GiaTri", dhDTO.Gia_tri.ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("TienThue", dhDTO.Tien_thue.ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        string loai = dhDTO.Ngay_gio_giao_hang.ToString();
        string ngayGioGiaoHang = "chưa có";
        if (dhDTO.Loai_don_dat_hang == 1)
            loai = "5"; // " (Đơn hàng định kỳ)";
        else if (dhDTO.Da_dat_hang == false && dhDTO.Da_thanh_toan == false && dhDTO.Da_giao_hang == false)
            loai = "0"; //"Đã lưu";
        else if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == false && dhDTO.Da_giao_hang == false)
            loai = "1"; //"Đã đặt hàng nhưng chưa thanh toán";
        else if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == true && dhDTO.Da_giao_hang == false)
            loai = "2"; //"Đã thanh toán nhưng chưa giao hàng";
        else if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == true && dhDTO.Da_giao_hang == true)
        {
            loai = "3"; //Đã hoàn tất";
            ngayGioGiaoHang = dhDTO.Ngay_gio_giao_hang.ToString();
        }
        else
            loai = "4"; //Trong ngày (đã đặt hàng)";
        
        if (loai == "5")
        {
            DonHangDinhKyBUS dhdkBus = new DonHangDinhKyBUS();
            DonHangDinhKyDTO dhdk = dhdkBus.LayThongTinDonHangDinhKy(dhDTO.Ma_don_hang);

            Thuoc_tinh = new XL_THUOC_TINH("LoaiDinhKy", dhdk.Loai_dinh_ky);
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayBatDau", dhdk.Ngay_bat_dau.ToString());
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayKetThuc", dhdk.Ngay_ket_thuc.ToString());
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            string thoiDiem = "";
            if (dhdk.Loai_dinh_ky.ToUpper().Trim() == "Tuần")
                thoiDiem = dhdk.Thu_giao;
            else 
                thoiDiem = dhdk.Ngay_giao;

            Thuoc_tinh = new XL_THUOC_TINH("ThoiDiemGiao", thoiDiem);
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("GioGiao", dhdk.Gio_giao.ToString());
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TinhTrang", dhdk.Tinh_trang ? "1" : "0");
            kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        }

        Thuoc_tinh = new XL_THUOC_TINH("loai", loai);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("NgayGioGiaoHang", ngayGioGiaoHang);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        XL_CHUOI.XuatXML(Response, kq.Chuoi());
    }
}
