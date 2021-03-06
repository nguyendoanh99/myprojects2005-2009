using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DonHangDAO
/// </summary>
public class DonHangDAO : AbstractDAO
{
	public DonHangDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool CapNhatTrangThaiDaThanhToan(int maDonHang, bool trangthai)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatDaThanhToan",
             new string[] { "@maDonHang", "@trangThai" },
             new object[] { maDonHang, trangthai });
        return ExecuteNonQuery(cmd);
    }
    public bool CapNhatTrangThaiDaGiaoHang(int maDonHang, bool trangthai)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatDaGiaoHang",
             new string[] { "@maDonHang", "@trangThai" },
             new object[] { maDonHang, trangthai });
        return ExecuteNonQuery(cmd);
    }
    public bool CapNhatNgayGioGiaoHang(int maDonHang, DateTime ngayGioGiaoHang)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatNgayGioGiaoHang",
             new string[] { "@maDonHang", "@ngayGioGiaoHang" },
             new object[] { maDonHang, ngayGioGiaoHang });
        return ExecuteNonQuery(cmd);
    }

    public bool CapNhatTrangThaiDaDatHang(int maDonHang, bool trangthai)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatDaDatHang",
             new string[] { "@maDonHang", "@trangThai" },
             new object[] { maDonHang, trangthai });
        return ExecuteNonQuery(cmd);
    }

    public int ThemDonHang(DonHangDTO donhang)
    {
        int Kq = 0; //mã don hang
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemDonHang", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
      
        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@ngaygiolap", SqlDbType.DateTime);
        cmd.Parameters.Add("@diachinhan", SqlDbType.NVarChar);
        cmd.Parameters.Add("@nguoinhan", SqlDbType.NVarChar);
        cmd.Parameters.Add("@ngaygiogiaohang", SqlDbType.DateTime);
        cmd.Parameters.Add("@loaidondathang", SqlDbType.Int);
        cmd.Parameters.Add("@hinhthuckhuyenmai", SqlDbType.Int);
        cmd.Parameters.Add("@tienkhuyenmai", SqlDbType.Money);
        cmd.Parameters.Add("@giatri", SqlDbType.Money);
        cmd.Parameters.Add("@mahinhthucthanhtoan", SqlDbType.Int);
        cmd.Parameters.Add("@dadathang", SqlDbType.Bit);
        cmd.Parameters.Add("@dathanhtoan", SqlDbType.Bit);
        cmd.Parameters.Add("@dagiaohang", SqlDbType.Bit);
        cmd.Parameters.Add("@tienthue", SqlDbType.Money);

        cmd.Parameters["@makhachhang"].Value = donhang.Ma_khach_hang;
        cmd.Parameters["@ngaygiolap"].Value = donhang.Ngay_gio_lap;
        cmd.Parameters["@diachinhan"].Value = donhang.Dia_chi_nhan;
        cmd.Parameters["@nguoinhan"].Value = donhang.Nguoi_nhan;
        cmd.Parameters["@ngaygiogiaohang"].Value = donhang.Ngay_gio_giao_hang;
        cmd.Parameters["@loaidondathang"].Value = donhang.Loai_don_dat_hang;
        cmd.Parameters["@hinhthuckhuyenmai"].Value = donhang.Hinh_thuc_khuyen_mai;
        cmd.Parameters["@tienkhuyenmai"].Value = donhang.Tien_khuyen_mai;
        cmd.Parameters["@giatri"].Value = donhang.Gia_tri;
        cmd.Parameters["@mahinhthucthanhtoan"].Value = donhang.Ma_hinh_thuc_thanh_toan;
        cmd.Parameters["@dadathang"].Value = donhang.Da_dat_hang;
        cmd.Parameters["@dathanhtoan"].Value = donhang.Da_thanh_toan;
        cmd.Parameters["@dagiaohang"].Value = donhang.Da_giao_hang;
        cmd.Parameters["@tienthue"].Value = donhang.Tien_thue;

        cmd.Parameters.Add("@madonhang", SqlDbType.Int);
        cmd.Parameters["@madonhang"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Kq = (int)cmd.Parameters["@madonhang"].Value;

        Disconnect();
        return Kq;
    }

    public int ThemDonHangGuest(DonHangDTO donhang)
    {
        int Kq = 0; //mã don hang
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemDonHangGuest", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
       
        cmd.Parameters.Add("@ngaygiolap", SqlDbType.DateTime);
        cmd.Parameters.Add("@diachinhan", SqlDbType.NVarChar);
        cmd.Parameters.Add("@nguoinhan", SqlDbType.NVarChar);
        cmd.Parameters.Add("@ngaygiogiaohang", SqlDbType.DateTime);
        cmd.Parameters.Add("@loaidondathang", SqlDbType.Int);
        cmd.Parameters.Add("@hinhthuckhuyenmai", SqlDbType.Int);
        cmd.Parameters.Add("@tienkhuyenmai", SqlDbType.Money);
        cmd.Parameters.Add("@giatri", SqlDbType.Money);
        cmd.Parameters.Add("@mahinhthucthanhtoan", SqlDbType.Int);
        cmd.Parameters.Add("@dadathang", SqlDbType.Bit);
        cmd.Parameters.Add("@dathanhtoan", SqlDbType.Bit);
        cmd.Parameters.Add("@dagiaohang", SqlDbType.Bit);

        cmd.Parameters["@ngaygiolap"].Value = donhang.Ngay_gio_lap;
        cmd.Parameters["@diachinhan"].Value = donhang.Dia_chi_nhan;
        cmd.Parameters["@nguoinhan"].Value = donhang.Nguoi_nhan;
        cmd.Parameters["@ngaygiogiaohang"].Value = donhang.Ngay_gio_giao_hang;
        cmd.Parameters["@loaidondathang"].Value = donhang.Loai_don_dat_hang;
        cmd.Parameters["@hinhthuckhuyenmai"].Value = donhang.Hinh_thuc_khuyen_mai;
        cmd.Parameters["@tienkhuyenmai"].Value = donhang.Tien_khuyen_mai;
        cmd.Parameters["@giatri"].Value = donhang.Gia_tri;
        cmd.Parameters["@mahinhthucthanhtoan"].Value = donhang.Ma_hinh_thuc_thanh_toan;
        cmd.Parameters["@dadathang"].Value = donhang.Da_dat_hang;
        cmd.Parameters["@dathanhtoan"].Value = donhang.Da_thanh_toan;
        cmd.Parameters["@dagiaohang"].Value = donhang.Da_giao_hang;

        cmd.Parameters.Add("@madonhang", SqlDbType.Int);
        cmd.Parameters["@madonhang"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Kq = (int)cmd.Parameters["@madonhang"].Value;

        Disconnect();
        return Kq;
    }

    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 1: đơn hàng khách hàng đã lưu
    public void ThongTinDonHangDaLuu(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        XemThongTinDonHangLoai1_4(maKhachHang, false, false, false, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán
    public void ThongTinDonHangDaDatChuaThanhToan(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        XemThongTinDonHangLoai1_4(maKhachHang, true, false, false, out SoLuongDonHang, out TongTriGia);
    }
    // Tr? v? s? lu?ng don hàng và t?ng giá tr? c?a don hàng lo?i 3: don hàng dã thanh toán nhung chua giao hàng
    public void ThongTinDonHangDaThanhToanChuaGiao(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        XemThongTinDonHangLoai1_4(maKhachHang, true, true, false, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 4: đơn hàng đã hoàn tất
    public void ThongTinDonHangDaHoanTat(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        XemThongTinDonHangLoai1_4(maKhachHang, true, true, true, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 5: đơn hàng trong ngày (có thể thanh toán hoặc chưa thanh toán
    public void ThongTinDonHangTrongNgay(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        SqlCommand cmd = CreateCommandStored("spXemThongTinDonHangTrongNgay", new string[] { "@maKhachHang" }, new object[] { maKhachHang });
        LayThongTinDonHang(out SoLuongDonHang, out TongTriGia, cmd);
    }    
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 6: đơn hàng định kỳ
    public void ThongTinDonHangDinhKy(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        SqlCommand cmd = CreateCommandStored("spXemThongTinDonHangDinhKy", new string[] { "@maKhachHang" }, new object[] { maKhachHang });
        LayThongTinDonHang(out SoLuongDonHang, out TongTriGia, cmd);        
    }

    // Danh sách đơn hàng thuộc đơn hàng loại 1: đơn hàng khách hàng đã lưu
    public DonHangDTO[] DanhSachDonHangDaLuu(int maKhachHang, int pageNum, int pageSize)
    {
        return LayDanhSachDonHang(maKhachHang, false, false, false, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán
    public DonHangDTO[] DanhSachDonHangDaDatChuaThanhToan(int maKhachHang, int pageNum, int pageSize)
    {
        return LayDanhSachDonHang(maKhachHang, true, false, false, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng
    public DonHangDTO[] DanhSachDonHangDaThanhToanChuaGiao(int maKhachHang, int pageNum, int pageSize)
    {
        return LayDanhSachDonHang(maKhachHang, true, true, false, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 4: đơn hàng đã hoàn tất
    public DonHangDTO[] DanhSachDonHangDaHoanTat(int maKhachHang, int pageNum, int pageSize)
    {
        return LayDanhSachDonHang(maKhachHang, true, true, true, pageNum, pageSize);
    }
    // Danh sách đơn hàng loại 5: đơn hàng trong ngày (có thể thanh toán hoặc chưa thanh toán
    public DonHangDTO[] DanhSachDonHangTrongNgay(int maKhachHang, int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spXemDanhSachDonHangTrongNgay",
            new string[] { "@maKhachHang", "@pageNum", "@pageSize" },
            new object[] { maKhachHang, pageNum, pageSize });
        DonHangDTO[] kq = (DonHangDTO[])LayDanhSach(typeof(DonHangDTO), cmd);
        return kq;
    }

    // Danh sách đơn hàng chưa hoàn tất (nhân viên)
    private DonHangDTO[] DanhSachDonHangChuaHoanTat(bool daThanhToan, int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spXemDanhSachDonHangChuaHoanTat",
            new string[] { "@daThanhToan", "@pageNum", "@pageSize" },
            new object[] { daThanhToan, pageNum, pageSize });
        DonHangDTO[] kq = (DonHangDTO[])LayDanhSach(typeof(DonHangDTO), cmd);
        return kq;
    }
    // Danh sách đơn hàng đã hoàn tất trong ngày (nhân viên)
    public DonHangDTO[] DanhSachDonHangDaHoanTatTrongNgay(int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spXemDanhSachDonHangDaHoanTatTrongNgay",
            new string[] { "@pageNum", "@pageSize" },
            new object[] { pageNum, pageSize });
        DonHangDTO[] kq = (DonHangDTO[])LayDanhSach(typeof(DonHangDTO), cmd);
        return kq;
    }
    // Danh sách đơn hàng chưa thanh toán chưa giao (nhân viên)
    public DonHangDTO[] DanhSachDonHangChuaThanhToanChuaGiao(int pageNum, int pageSize)
    {
        return DanhSachDonHangChuaHoanTat(false, pageNum, pageSize);
    }
    // Danh sách đơn hàng đã thanh toán chưa giao (nhân viên)
    public DonHangDTO[] DanhSachDonHangDaThanhToanChuaGiao(int pageNum, int pageSize)
    {
        return DanhSachDonHangChuaHoanTat(true, pageNum, pageSize);
    }

    // Tổng đơn hàng chưa hoàn tất (nhân viên)
    private int TongDonHangChuaHoanTat(bool daThanhToan)
    {
        SqlCommand cmd = CreateCommandStored("spTongDonHangChuaHoanTat",
            new string[] { "@daThanhToan" },
            new object[] { daThanhToan });
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }
    // Tổng đơn hàng đã hoàn tất trong ngày (nhân viên)
    public int TongDonHangDaHoanTatTrongNgay()
    {
        SqlCommand cmd = CreateCommandStored("spTongDonHangDaHoanTatTrongNgay",
            new string[] { },
            new object[] { });
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }
    // Tổng đơn hàng chưa giao (nhân viên)
    public int TongDonHangChuaThanhToanChuaGiao()
    {
        return TongDonHangChuaHoanTat(false);
    }
    // Tổng đơn hàng đã thanh toán nhưng chưa giao (nhân viên)
    public int TongDonHangDaThanhToanChuaGiao()
    {
        return TongDonHangChuaHoanTat(true);
    }

    public int TongDonHangDaLuu(int maKhachHang)
    {
        return TongDongHangLoai1_4(maKhachHang, false, false, false);

    }
    public int TongDonHangDaDatChuaThanhToan(int maKhachHang)
    {
        return TongDongHangLoai1_4(maKhachHang, true, false, false);
    }
    public int TongDonHangDaThanhToanChuaGiao(int maKhachHang)
    {
        return TongDongHangLoai1_4(maKhachHang, true, true, false);
    }
    public int TongDonHangDaHoanTat(int maKhachHang)
    {
        return TongDongHangLoai1_4(maKhachHang, true, true, true);
    }
    public int TongDonHangTrongNgay(int maKhachHang)
    {
        SqlCommand cmd = CreateCommandStored("spTongDonHangTrongNgay", new string[] { "@maKhachHang" }, new object[] { maKhachHang });
        return (int) ExecuteScalar(cmd);
    }
    public int TongDonHangDinhKy(int maKhachHang)
    {
        SqlCommand cmd = CreateCommandStored("spTongDonHangDinhKy", 
            new string[] {"@maKhachHang"}, new object[] { maKhachHang });
        return (int)ExecuteScalar(cmd);
    }

    public bool XoaDonHang(int maDonHang)
    {
        SqlCommand cmd = CreateCommandStored("spXoaDonHang",
             new string[] { "@maDonHang" },
             new object[] { maDonHang });
        return ExecuteNonQuery(cmd);
    }
    public DonHangDTO LayThongTinDonHang(int maDonHang)
    {
        SqlCommand cmd = CreateCommandStored("spLayThongTinDonHang",
             new string[] { "@maDonHang" },
             new object[] { maDonHang });
        DonHangDTO[] kq = (DonHangDTO[])LayDanhSach(typeof(DonHangDTO), cmd);
        return kq[0];
    }

    private int TongDongHangLoai1_4(int maKhachHang, bool daDatHang, bool daThanhToan, bool daGiaoHang)
    {
        SqlCommand cmd = CreateCommandStored("spTongDonHangLoai1_4",
            new string[] {"@maKhachHang", "@daDatHang", "@daThanhToan", "@daGiaoHang"},
            new object[] { maKhachHang, daDatHang, daThanhToan, daGiaoHang });
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }
    private DonHangDTO[] LayDanhSachDonHang(int maKhachHang, bool daDatHang, bool daThanhToan, bool daGiaoHang, int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spXemDanhSachDonHangLoai1_4",
            new string[] { "@maKhachHang", "@daDatHang", "@daThanhToan", "@daGiaoHang", "@pageNum", "@pageSize" },
            new object[] { maKhachHang, daDatHang, daThanhToan, daGiaoHang, pageNum, pageSize});
        DonHangDTO[] kq = (DonHangDTO[])LayDanhSach(typeof(DonHangDTO), cmd);
        return kq;
    }
    private void XemThongTinDonHangLoai1_4(int maKhachHang, bool daDatHang, bool daThanhToan, bool daGiaoHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
         SqlCommand cmd = CreateCommandStored("spXemThongTinDonHangLoai1_4",
             new string[] { "@maKhachHang", "@daDatHang", "@daThanhToan", "@daGiaoHang" },
             new object[] { maKhachHang, daDatHang, daThanhToan, daGiaoHang});
        LayThongTinDonHang(out SoLuongDonHang, out TongTriGia, cmd);
    }
    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(DonHangDTO), dt.Rows[i]);
    }
    private void LayThongTinDonHang(out int SoLuongDonHang, out decimal TongTriGia, SqlCommand cmd)
    {
        cmd.Connection = cnn;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        SoLuongDonHang = (int)dt.Rows[0]["SoLuongDonHang"];
        if (dt.Rows[0]["TongTriGia"].GetType() != typeof(DBNull))
            TongTriGia = (decimal)dt.Rows[0]["TongTriGia"];
        else
            TongTriGia = 0;

        Disconnect();
    }
}
