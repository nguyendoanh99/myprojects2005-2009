using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;


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

    //NGUOI DUNG DAO
    [WebMethod]
    public NguoiDungDTO KiemTraAccount(string username, string password)
    {
        NguoiDungDAO nguoidungDAO = new NguoiDungDAO();
        return nguoidungDAO.KiemTraAccount(username, password);
    }

    [WebMethod]
    public bool CapNhatTongTinMatKhau(string Password, int Ma_nguoi_dung)
    {
        NguoiDungDAO nguoidungDAO = new NguoiDungDAO();
        return nguoidungDAO.CapNhatTongTinMatKhau(Password, Ma_nguoi_dung);
    }

    [WebMethod]
    public int ThemNguoiDung(NguoiDungDTO nguoidungDTO)
    {
        NguoiDungDAO nguoidungDAO = new NguoiDungDAO();
        return nguoidungDAO.ThemNguoiDung(nguoidungDTO);
    }

    //KHACH HANG DAO
    [WebMethod]
    public int ThemKhachHang(KhachHangDTO khachhang, TheThanhToanDTO the)
    {
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        return khachhangDAO.ThemKhachHang(khachhang, the);
    }

    [WebMethod]
    public viewKhachHangDTO LayThongTinKhachHang(string username)
    {
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        return khachhangDAO.LayThongTinKhachHang(username);
    }

    [WebMethod]
    public bool CapNhatThongTinKhachHang(viewKhachHangDTO viewKH)
    {
        KhachHangDAO khachhangDAO = new KhachHangDAO();
        return khachhangDAO.CapNhatThongTinKhachHang(viewKH);
    }

    //LOAI THE DAO
    [WebMethod]
    public LoaiTheDTO[] LayDanhSachLoaiThe()
    {
        LoaiTheDAO loaitheDAO = new LoaiTheDAO();
        return loaitheDAO.LayDanhSachLoaiThe();
    }

    //THE THANH TOAN DAO
    [WebMethod]
    public bool CapNhatTheThanhToan(TheThanhToanDTO tttDto)
    {
        TheThanhToanDAO theDAO = new TheThanhToanDAO();
        return theDAO.CapNhatTheThanhToan(tttDto);
    }

    //LOAI MON DAO
    [WebMethod]
    public LoaiMonDTO[] LayDanhSachLoaiMon()
    {
        LoaiMonDAO loaimonDAO = new LoaiMonDAO();
        return loaimonDAO.LayDanhSachLoaiMon();
    }

    //MON AN DAO
    [WebMethod]
    public int ThemMonAn(MonAnDTO monan, String strTag)
    {
        MonAnDAO monanDAO = new MonAnDAO();
        return monanDAO.ThemMonAn(monan, strTag);
    }

    [WebMethod]
    public MonAnDTO[] DanhSachMonAn()
    {
        MonAnDAO monanDAO = new MonAnDAO();
        return monanDAO.DanhSachMonAn();
    }

    //LOAI NGUOI DUNG DTO
    [WebMethod]
    public LoaiNguoiDungDTO[] LayDanhSachLoaiNguoiDung()
    {
        LoaiNguoiDungDAO loainguoidungDAO = new LoaiNguoiDungDAO();
        return loainguoidungDAO.LayDanhSachLoaiNguoiDung();
    }
}

