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
using System.Data.SqlClient;

public partial class He_Phuc_Vu_XL_NguoiDung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String xac_nhan = Request["Xac_nhan"].ToString();

        if (xac_nhan == "Thoat")
            Thoat();
        else if (xac_nhan == "XacNhanCode")
            XacNhanCode();
        else if (xac_nhan == "ThemKhachHang")
            ThemKhachHang();
        else if (xac_nhan == "TaoTaiKhoan")
            TaoTaiKhoan();
        else if (xac_nhan == "CapNhatThongTinCaNhan")
            CapNhatThongTinCaNhan();
        else if (xac_nhan == "NVCapNhatThongTinCaNhan")
            NVCapNhatThongTinCaNhan();
        else if (xac_nhan == "CapNhatThongTinTheTinDung")
            CapNhatThongTinTheTinDung();
        else if (xac_nhan == "CapNhatThongTinMatKhau")
            CapNhatThongTinMatKhau();
        else if (xac_nhan == "NVCapNhatThongTinMatKhau")
            NVCapNhatThongTinMatKhau();

    }
    private void NVCapNhatThongTinMatKhau()
    {
        NguoiDungDTO vkhDto = (NguoiDungDTO)Session["nguoidung"];

        //Lấy tham số client truyền xuống
        string mkcu = XL_CHUOI.Nhap(Request, "mkcu");
        string mkmoi = XL_CHUOI.Nhap(Request, "mkmoi");

        XL_THE the = new XL_THE("goc");
        if (mkcu != vkhDto.Password)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "False"));
            XL_CHUOI.XuatChuoi(Response, the.Chuoi());
            return;
        }

        //Cập nhật
        int Ma_nguoi_dung = vkhDto.Ma_nguoi_dung;

        NguoiDungBUS ndBus = new NguoiDungBUS();
        bool kq = ndBus.CapNhatThongTinMatKhau(mkmoi, Ma_nguoi_dung);
        if (kq == true)
        {
            vkhDto.Password = mkmoi;
            Session["nguoidung"] = vkhDto;   //Lưu thông tin cho biến trong session
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "True"));
        }
        else
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "False"));

        XL_CHUOI.XuatChuoi(Response, the.Chuoi());
    }

    private void CapNhatThongTinMatKhau()
    {
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];

        //Lấy tham số client truyền xuống
        string mkcu = XL_CHUOI.Nhap(Request, "mkcu");
        string mkmoi = XL_CHUOI.Nhap(Request,"mkmoi");

        XL_THE the = new XL_THE("goc");  
        if (mkcu != vkhDto.Password)
        {
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "False"));
            XL_CHUOI.XuatChuoi(Response, the.Chuoi());
            return;
        }

        //Cập nhật
        int Ma_nguoi_dung = vkhDto.Ma_nguoi_dung;

        NguoiDungBUS ndBus = new NguoiDungBUS();
        bool kq = ndBus.CapNhatThongTinMatKhau(mkmoi, Ma_nguoi_dung);
        if (kq == true)
        {
            vkhDto.Password = mkmoi;
            Session["khachhang"] = vkhDto;   //Lưu thông tin cho biến trong session
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "True"));
        }
        else
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "False"));

        XL_CHUOI.XuatChuoi(Response, the.Chuoi());
    }

    private void CapNhatThongTinCaNhan()
    {
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        viewKhachHangDTO vkhDto_new = new viewKhachHangDTO(vkhDto);

        //Lấy tham số client truyền xuống
        vkhDto_new.Ho_ten = XL_CHUOI.Nhap(Request, "hoten");
        vkhDto_new.Ngay_sinh = DateTime.Parse(Request["ngaysinh"]);

        vkhDto_new.Gioi_tinh = bool.Parse((XL_CHUOI.Nhap(Request, "gioitinh")));
        vkhDto_new.Dia_chi = XL_CHUOI.Nhap(Request, "diachi");
        vkhDto_new.Dien_thoai = XL_CHUOI.Nhap(Request, "dienthoai");
        vkhDto_new.Email = XL_CHUOI.Nhap(Request, "email");

        //Cập nhật neu co thay doi
        bool kq = true;
        if (vkhDto_new.Ho_ten != vkhDto.Ho_ten || vkhDto_new.Ngay_sinh != vkhDto.Ngay_sinh || vkhDto_new.Gioi_tinh != vkhDto.Gioi_tinh || vkhDto_new.Dia_chi != vkhDto.Dia_chi || vkhDto_new.Dien_thoai != vkhDto.Dien_thoai || vkhDto_new.Email != vkhDto.Email)
        {
            KhachHangBUS khBus = new KhachHangBUS();
            kq = khBus.CapNhatThongTinKhachHang(vkhDto_new);
        }

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        //Cập nhật thành công
        if (kq == true)
        {
            Session["khachhang"] = vkhDto_new;

            thuoc_tinh = new XL_THUOC_TINH("kq", "True");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "False");

        //Trả kết quả về client
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    private void NVCapNhatThongTinCaNhan()
    {
        NguoiDungDTO vkhDto = (NguoiDungDTO)Session["nguoidung"];
        NguoiDungDTO vkhDto_new = new NguoiDungDTO(vkhDto);

        //Lấy tham số client truyền xuống
        vkhDto_new.Ho_ten = XL_CHUOI.Nhap(Request, "hoten");
        vkhDto_new.Ngay_sinh = DateTime.Parse(Request["ngaysinh"]);

        vkhDto_new.Gioi_tinh = bool.Parse((XL_CHUOI.Nhap(Request, "gioitinh")));
        vkhDto_new.Dia_chi = XL_CHUOI.Nhap(Request, "diachi");
        vkhDto_new.Dien_thoai = XL_CHUOI.Nhap(Request, "dienthoai");
        vkhDto_new.Email = XL_CHUOI.Nhap(Request, "email");

        //Cập nhật neu co thay doi
        bool kq = true;
        if (vkhDto_new.Ho_ten != vkhDto.Ho_ten || vkhDto_new.Ngay_sinh != vkhDto.Ngay_sinh || vkhDto_new.Gioi_tinh != vkhDto.Gioi_tinh || vkhDto_new.Dia_chi != vkhDto.Dia_chi || vkhDto_new.Dien_thoai != vkhDto.Dien_thoai || vkhDto_new.Email != vkhDto.Email)
        {
            NguoiDungBUS ndBus = new NguoiDungBUS();
            kq = ndBus.CapNhatThongTinNguoiDung(vkhDto_new);
        }

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        //Cập nhật thành công
        if (kq == true)
        {
            Session["nguoidung"] = vkhDto_new;

            thuoc_tinh = new XL_THUOC_TINH("kq", "True");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "False");

        //Trả kết quả về client
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }


    private void CapNhatThongTinTheTinDung()
    {
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];

        TheThanhToanDTO tttDto = new TheThanhToanDTO();
        tttDto.Ma_the = vkhDto.Ma_the;

        //Lấy tham số client truyền xuống
        tttDto.Ma_loai_the = int.Parse(XL_CHUOI.Nhap(Request, "maloaithe"));
        //tttDto.So_the = XL_CHUOI.Nhap(Request, "sothe").ToCharArray();
        tttDto.So_the = XL_CHUOI.Nhap(Request, "sothe").ToString();
        tttDto.Ngay_het_han = DateTime.Parse(Request["ngayhh"].ToString());

        //Cập nhật neu co thay doi
        bool kq = true;
        if (tttDto.Ma_loai_the != vkhDto.Ma_loai_the || tttDto.So_the != vkhDto.So_the || tttDto.Ngay_het_han != vkhDto.Ngay_het_han)
            kq = (new TheThanhToanBUS()).CapNhatTheThanhToan(tttDto);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        if (kq == true)
        {
            //Lưu lại biến trong session
            vkhDto.Ma_loai_the = tttDto.Ma_loai_the;
            //vkhDto.Ten_loai_the = (new LoaiTheBUS()).Lay_Ten_Loai_The(tttDto.Ma_loai_the);
            vkhDto.Ten_loai_the = Request["tenloaithe"].ToString();
            vkhDto.So_the = tttDto.So_the;
            vkhDto.Ngay_het_han = tttDto.Ngay_het_han;

            Session["khachhang"] = vkhDto;

            thuoc_tinh = new XL_THUOC_TINH("kq", "True");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "False");

        //Trả kết quả về client
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void ThemKhachHang()
    {
        KhachHangDTO khachhangdto = new KhachHangDTO();

        khachhangdto.Ho_ten = XL_CHUOI.Nhap(Request, "hoten");
        khachhangdto.Username = XL_CHUOI.Nhap(Request, "username");
        
        khachhangdto.Password = XL_CHUOI.Nhap(Request, "password"); //hex string

        khachhangdto.Email = XL_CHUOI.Nhap(Request, "email");
        khachhangdto.Dia_chi = XL_CHUOI.Nhap(Request, "diachi");
        khachhangdto.Dien_thoai = XL_CHUOI.Nhap(Request, "dienthoai");
        khachhangdto.Gioi_tinh = bool.Parse(XL_CHUOI.Nhap(Request, "gioitinh"));
        khachhangdto.Ngay_sinh = DateTime.Parse(XL_CHUOI.Nhap(Request, "date").ToString());

        TheThanhToanDTO thedto = new TheThanhToanDTO();

        thedto.Ma_loai_the = int.Parse(XL_CHUOI.Nhap(Request, "loaithe").ToString());
        thedto.So_the = XL_CHUOI.Nhap(Request, "mathe");
        thedto.Ngay_het_han = DateTime.Parse(XL_CHUOI.Nhap(Request, "dateHH").ToString());

        int manguoidung = 0;
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("Kq", "false");
        try
        {
            KhachHangBUS khachhangBUS = new KhachHangBUS();
            manguoidung = khachhangBUS.ThemKhachHang(khachhangdto, thedto);

            if (manguoidung != 0)
                thuoctinh = new XL_THUOC_TINH("kq", "true");
            else
                thuoctinh = new XL_THUOC_TINH("kq", "error");
        }
        catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                thuoctinh = new XL_THUOC_TINH("kq", "false");
            }
        }

        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    public void TaoTaiKhoan()
    {
        NguoiDungDTO nguoidung = new NguoiDungDTO();
        nguoidung.Ma_loai_nguoi_dung = int.Parse(XL_CHUOI.Nhap(Request, "loai"));
        nguoidung.Ho_ten = XL_CHUOI.Nhap(Request, "hoten");
        nguoidung.Username = XL_CHUOI.Nhap(Request, "username");
        nguoidung.Password = XL_CHUOI.Nhap(Request, "password");

        nguoidung.Email = XL_CHUOI.Nhap(Request, "email");
        nguoidung.Dia_chi = XL_CHUOI.Nhap(Request, "diachi");
        nguoidung.Dien_thoai = XL_CHUOI.Nhap(Request, "dienthoai");
        nguoidung.Gioi_tinh = bool.Parse(XL_CHUOI.Nhap(Request, "gioitinh"));
        nguoidung.Ngay_sinh = DateTime.Parse(XL_CHUOI.Nhap(Request, "date").ToString());
        nguoidung.Tinh_trang_kich_hoat = bool.Parse(XL_CHUOI.Nhap(Request, "kichhoat"));

        int manguoidung = 0;
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh;
        try
        {
            //oFFS_BUS_WS.WebService service = new oFFS_BUS_WS.WebService();
            NguoiDungBUS nguoidungBUS = new NguoiDungBUS();
            manguoidung = nguoidungBUS.ThemNguoiDung(nguoidung);

            if (manguoidung != 0)
                thuoctinh = new XL_THUOC_TINH("kq", "true");
            else
                thuoctinh = new XL_THUOC_TINH("kq", "false");
        }
        catch
        {
            thuoctinh = new XL_THUOC_TINH("kq", "false");
        }

        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    public void Thoat()
    {
        Session["User"] = null;
        Session["LoaiNguoiDung"] = "";
        Session["khachhang"] = null;
        Session["nguoidung"] = null;
        Session["FormDatHang"] = null;
        Session["FormDatHangDinhKy"] = null;
        Session["Gio_qua_tang"] = null;
        Session["Gio_hang"] = null;
        Session["Item_online"] = null;

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", "true");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    public void XacNhanCode()
    {
        String strCode = Request["code"];

        bool Kq = false;
        if (strCode == Session["CaptchaImageText"].ToString())
            Kq = true;

        XL_THE the = new XL_THE("goc");
        if(Kq == true)
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "true"));
        else
            the.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "false"));

        XL_CHUOI.XuatXML(Response, the.Chuoi());
    }       
}
