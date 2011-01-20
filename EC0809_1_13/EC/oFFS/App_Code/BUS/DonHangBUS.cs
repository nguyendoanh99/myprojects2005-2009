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
/// Summary description for DonHangBUS
/// </summary>
public class DonHangBUS
{
	
    DonHangDAO dhDAO = new DonHangDAO();
    public int ThemDonHang(DonHangDTO donhang)
    {
        return dhDAO.ThemDonHang(donhang);
    }

    public bool CapNhatTrangThaiDaDatHang(int maDonHang, bool trangthai)
    {
        return dhDAO.CapNhatTrangThaiDaDatHang(maDonHang,trangthai);
    }

    public int ThemDonHangGuest(DonHangDTO donhang)
    {
        return dhDAO.ThemDonHangGuest(donhang);
    }

    public bool CapNhatTrangThaiDaThanhToan(int madonhang, bool trangthai)
    {
        return dhDAO.CapNhatTrangThaiDaThanhToan(madonhang, trangthai);
    }
    public bool CapNhatNgayGioGiaoHang(int maDonHang, DateTime ngayGioGiaoHang)
    {
        return dhDAO.CapNhatNgayGioGiaoHang(maDonHang, ngayGioGiaoHang);
    }
    public bool CapNhatTrangThaiDaGiaoHang(int madonhang, bool trangthai)
    {
        return dhDAO.CapNhatTrangThaiDaGiaoHang(madonhang, trangthai);
    }

    public int CapNhatDiemKMTheoQuiDinh(int makh, int diemcu, decimal giatri, decimal tienkm)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        int diemdc = 0;

        //cong them diem neu don hang > gia tri qui dinh
        if (giatri > tsDto.GiaTriDiemSo)
            diemdc = (int)(Math.Round(giatri/tsDto.GiaTriDiemSo));
        //tru so diem su dung
        int diemsd = TinhDiemKhuyenMai(tienkm);

        int diemmoi = diemcu + diemdc - diemsd;
        (new KhachHangBUS()).CapNhatDiemKhuyenMai(makh, diemmoi);
        return diemmoi;
    }

    public decimal TinhTienKhuyenMai(int diem)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        return ((diem + 1) * tsDto.GiaTriDoiDiemKhuyenMai);
    }

    public int TinhDiemKhuyenMai(decimal tienkm)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        return (int)(tienkm / tsDto.GiaTriDoiDiemKhuyenMai - 1);
    }

    public int TinhDiemHoanLai(decimal tienkm)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        return (int)(tienkm / tsDto.GiaTriDoiDiemKhuyenMai);
    }

    public decimal TinhTienThue(decimal giatri)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        return (giatri * (decimal)tsDto.Thue);
    }

    public int TinhSoDiemToiDa(decimal giatri, int diemht)
    {
        ThamSoDTO tsDto = (new ThamSoBUS()).LayThamSo();
        decimal gioihan = giatri * (decimal)tsDto.GioiHanDoiDiemKhuyenMai;
        decimal diem = Math.Round(gioihan / tsDto.GiaTriDoiDiemKhuyenMai);
        int diemtd = int.Parse((diem.ToString()));

        if (diemtd <= diemht)
            return diemtd;
        else
            return diemht;
    }

    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 1: đơn hàng khách hàng đã lưu
    public void ThongTinDonHangDaLuu(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangDaLuu(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán
    public void ThongTinDonHangDaDatChuaThanhToan(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangDaDatChuaThanhToan(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng
    public void ThongTinDonHangDaThanhToanChuaGiao(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangDaThanhToanChuaGiao(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 4: đơn hàng đã hoàn tất
    public void ThongTinDonHangDaHoanTat(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangDaHoanTat(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 5: đơn hàng trong ngày (có thể thanh toán hoặc chưa thanh toán
    public void ThongTinDonHangTrongNgay(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangTrongNgay(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }
    // Trả về số lượng đơn hàng và tổng giá trị của đơn hàng loại 6: đơn hàng định kỳ
    public void ThongTinDonHangDinhKy(int maKhachHang, out int SoLuongDonHang, out decimal TongTriGia)
    {
        dhDAO.ThongTinDonHangDinhKy(maKhachHang, out SoLuongDonHang, out TongTriGia);
    }

    // Danh sách đơn hàng thuộc đơn hàng loại 1: đơn hàng khách hàng đã lưu
    public DonHangDTO[] DanhSachDonHangDaLuu(int maKhachHang, int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaLuu(maKhachHang, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 2: đơn hàng đã đặt hàng nhưng chưa thanh toán
    public DonHangDTO[] DanhSachDonHangDaDatChuaThanhToan(int maKhachHang, int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaDatChuaThanhToan(maKhachHang, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 3: đơn hàng đã thanh toán nhưng chưa giao hàng
    public DonHangDTO[] DanhSachDonHangDaThanhToanChuaGiao(int maKhachHang, int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaThanhToanChuaGiao(maKhachHang, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 4: đơn hàng đã hoàn tất
    public DonHangDTO[] DanhSachDonHangDaHoanTat(int maKhachHang, int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaHoanTat(maKhachHang, pageNum, pageSize);
    }
    // Danh sách đơn hàng thuộc đơn hàng loại 5: đơn hàng trong ngày (có thể thanh toán hoặc chưa thanh toán
    public DonHangDTO[] DanhSachDonHangTrongNgay(int maKhachHang, int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangTrongNgay(maKhachHang, pageNum, pageSize);
    }

    // Danh sách đơn hàng đã hoàn tất trong ngày (nhân viên)
    public DonHangDTO[] DanhSachDonHangDaHoanTatTrongNgay(int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaHoanTatTrongNgay(pageNum, pageSize);
    }
    // Danh sách đơn hàng chưa thanh toán chưa giao (nhân viên)
    public DonHangDTO[] DanhSachDonHangChuaThanhToanChuaGiao(int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangChuaThanhToanChuaGiao(pageNum, pageSize);
    }
    // Danh sách đơn hàng đã thanh toán chưa giao (nhân viên)
    public DonHangDTO[] DanhSachDonHangDaThanhToanChuaGiao(int pageNum, int pageSize)
    {
        return dhDAO.DanhSachDonHangDaThanhToanChuaGiao(pageNum, pageSize);
    }

    // Tổng đơn hàng đã hoàn tất trong ngày (nhân viên)
    public int TongDonHangDaHoanTatTrongNgay()
    {
        return dhDAO.TongDonHangDaHoanTatTrongNgay();
    }
    // Tổng đơn hàng chưa giao (nhân viên)
    public int TongDonHangChuaThanhToanChuaGiao()
    {
        return dhDAO.TongDonHangChuaThanhToanChuaGiao();
    }
    // Tổng đơn hàng đã thanh toán nhưng chưa giao (nhân viên)
    public int TongDonHangDaThanhToanChuaGiao()
    {
        return dhDAO.TongDonHangDaThanhToanChuaGiao();
    }

    public int TongDonHangDaLuu(int maKhachHang)
    {
        return dhDAO.TongDonHangDaLuu(maKhachHang);

    }
    public int TongDonHangDaDatChuaThanhToan(int maKhachHang)
    {
        return dhDAO.TongDonHangDaDatChuaThanhToan(maKhachHang);
    }
    public int TongDonHangDaThanhToanChuaGiao(int maKhachHang)
    {
        return dhDAO.TongDonHangDaThanhToanChuaGiao(maKhachHang);
    }
    public int TongDonHangDaHoanTat(int maKhachHang)
    {
        return dhDAO.TongDonHangDaHoanTat(maKhachHang);
    }
    public int TongDonHangTrongNgay(int maKhachHang)
    {
        return dhDAO.TongDonHangTrongNgay(maKhachHang);
    }
    public int TongDonHangDinhKy(int maKhachHang)
    {
        return dhDAO.TongDonHangDinhKy(maKhachHang);
    }

   
    public bool XoaDonHang(int maDonHang)
    {
        return dhDAO.XoaDonHang(maDonHang);
    }
    public DonHangDTO LayThongTinDonHang(int maDonHang)
    {
        return dhDAO.LayThongTinDonHang(maDonHang);
    }
}
