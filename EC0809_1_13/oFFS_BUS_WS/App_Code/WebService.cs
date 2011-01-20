using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using oFFS_DAL_WS;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class WebService : System.Web.Services.WebService {

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    //NGUOI DUNG BUS
    [WebMethod]
    public NguoiDungDTO KiemTraAccount(string username, string password)
    {
        NguoiDungBUS nguoidungBUS = new NguoiDungBUS();
        return nguoidungBUS.KiemTraAccount(username, password);
    }

    [WebMethod]
    public bool CapNhatTongTinMatKhau(string Password, int Ma_nguoi_dung)
    {
        NguoiDungBUS nguoidungBUS = new NguoiDungBUS();
        return nguoidungBUS.CapNhatTongTinMatKhau(Password, Ma_nguoi_dung);
    }

    [WebMethod]
    public int ThemNguoiDung(NguoiDungDTO nguoidungDTO)
    {
         NguoiDungBUS nguoidungBUS = new NguoiDungBUS();
        return nguoidungBUS.ThemNguoiDung(nguoidungDTO);
    }

    //KHACH HANG BUS
    [WebMethod]
    public int ThemKhachHang(KhachHangDTO khachhang, TheThanhToanDTO the)
    {
        KhachHangBUS khachhangBUS = new KhachHangBUS();
        return khachhangBUS.ThemKhachHang(khachhang, the);
    }

    [WebMethod]
    public viewKhachHangDTO LayThongTinKhachHang(string username)
    {
        KhachHangBUS khachhangBUS = new KhachHangBUS();
        return khachhangBUS.LayThongTinKhachHang(username);
    }

    [WebMethod]
    public bool CapNhatThongTinKhachHang(viewKhachHangDTO viewKH)
    {
        KhachHangBUS khachhangBUS = new KhachHangBUS();
        return khachhangBUS.CapNhatThongTinKhachHang(viewKH);
    }

    //LOAI THE BUS
    [WebMethod]
    public LoaiTheDTO[] LayDanhSachLoaiThe()
    {
        LoaiTheBUS loaitheBUS = new LoaiTheBUS();
        return loaitheBUS.LayDanhSachLoaiThe();
    }

    //THE THANH TOAN BUS
    [WebMethod]
    public bool CapNhatTheThanhToan(TheThanhToanDTO tttDto)
    {
        TheThanhToanBUS theBUS = new TheThanhToanBUS();
        return theBUS.CapNhatTheThanhToan(tttDto);
    }

    //LOAI MON BUS
    [WebMethod]
    public LoaiMonDTO[] LayDanhSachLoaiMon()
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        return loaimonBUS.LayDanhSachLoaiMon();
    }

    //MON AN BUS
    [WebMethod]
    public int ThemMonAn(MonAnDTO monan, String strTag)
    {
        MonAnBUS monanBUS = new MonAnBUS();
        return monanBUS.ThemMonAn(monan, strTag);
    }

    [WebMethod]
    public MonAnDTO[] DanhSachMonAn()
    {
        MonAnBUS monanBUS = new MonAnBUS();
        return monanBUS.DanhSachMonAn();
    }

    //LOAI NGUOIDUNG BUS
    [WebMethod]
    public oFFS_DAL_WS.LoaiNguoiDungDTO[] LayDanhSachLoaiNguoiDung()
    {
        LoaiNguoiDungBUS loainguoidungBUS = new LoaiNguoiDungBUS();
        return loainguoidungBUS.LayDanhSachLoaiNguoiDung();
    }
}

