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

public partial class He_Phuc_Vu_XL_NVXemChiTietDonHang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "NhanVien" && Session["LoaiNguoiDung"] != "QuanLy")
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
                    
                    if (ma != null)
                        ten = ma.Ten_mon;
                    else
                        ten = "Món ăn này không tồn tại";
                    break;
                case 1: // thực đơn
                    loai = "Thực đơn";
                    ThucDonBUS tdBus = new ThucDonBUS();
                    ThucDonDTO tdDto = tdBus.ChiTietThucDon(ctdh.Ma_item);
                    if (tdDto != null)
                        ten = tdDto.Ten_thuc_don;
                    else
                        ten = "Thực đơn này không tồn tại";
                    break;
                case 2: // thực đơn cá nhân
                    loai = "Thực đơn cá nhân";
                    ThucDonCaNhanBUS tdcnBus = new ThucDonCaNhanBUS();
                    ThucDonCaNhanDTO tdcnDto = tdcnBus.ChiTietThucDonCaNhan(ctdh.Ma_item);
                    if (tdcnDto != null)
                        ten = tdcnDto.Ten_thuc_don;
                    else
                        ten = "Thực đơn cá nhân này không tồn tại";
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

        string tinhTrang = "";
        // Đã đặt hàng nhưng chưa thanh toán
        if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == false && dhDTO.Da_giao_hang == false)
            tinhTrang = "0";
        // Đã thanh toán nhưng chưa giao hàng
        else if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == true && dhDTO.Da_giao_hang == false)
            tinhTrang = "1";
        // Đã hoàn tất
        else if (dhDTO.Da_dat_hang == true && dhDTO.Da_thanh_toan == true && dhDTO.Da_giao_hang == true)
            tinhTrang = "2";

        Thuoc_tinh = new XL_THUOC_TINH("NgayGioGiaoHang", tinhTrang == "2" ? dhDTO.Ngay_gio_giao_hang.ToString() : "chưa");
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

        Thuoc_tinh = new XL_THUOC_TINH("TinhTrang", tinhTrang);
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        XL_CHUOI.XuatXML(Response, kq.Chuoi());
    }
}
