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
using System.Net.Mail;
using System.Net;

public partial class He_Phuc_Vu_XL_QTQuanLyTaiKhoanNguoiDung : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "LayDanhSachNguoiDung")
        {
            LayDanhSachNguoiDung();
            return;
        }
        if (r == "CapNhatTinhTrangKichHoat")
        {
            CapNhatTinhTrangKichHoat();
            return;
        }
        if (r == "XoaTaiKhoan")
        {
            XoaTaiKhoan();
            return;
        }
        if (r == "GuiLaiMatKhau")
        {
            GuiLaiMatKhau();
            return;
        }
    }

    private void GuiLaiMatKhau()
    {
        string Username = (string)Request["Username"];
        
        byte[] arr = new byte[10];
        Random r = new Random((int)DateTime.Now.ToBinary());
        r.NextBytes(arr);
        string pass = Utilities.ConvertToHexa(arr);

        NguoiDungBUS ndBus = new NguoiDungBUS();
        NguoiDungDTO dto = ndBus.LayThongTinNguoiDung(Username);
        int maNguoiDung = dto.Ma_nguoi_dung;
        bool flag = Utilities.SendMail("ec0809.1.13@gmail.com", dto.Email, "(OFFS) Reset mật khẩu", "Mật khẩu mới: <strong>" + pass + "</strong>") == "";
        string passSHA1 = Utilities.SHA1(pass).ToLower();
        bool kq = ndBus.CapNhatThongTinMatKhau(passSHA1, maNguoiDung);
        
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag && kq ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    private void XoaTaiKhoan()
    {
        string strMaNguoiDung = (string)Request["MaNguoiDung"];

        int maNguoiDung = int.Parse(strMaNguoiDung);
        NguoiDungBUS bus = new NguoiDungBUS();
        bool flag = bus.XoaNguoiDung(maNguoiDung);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    void CapNhatTinhTrangKichHoat()
    {
        string strMaNguoiDung = (string)Request["MaNguoiDung"];
        bool tinhTrangKichHoat = int.Parse(Request["TinhTrang"]) == 1;
        int maNguoiDung = int.Parse(strMaNguoiDung);

        NguoiDungBUS bus = new NguoiDungBUS();
        bool flag = bus.CapNhatTinhTrangKichHoat(tinhTrangKichHoat, maNguoiDung);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    void LayDanhSachNguoiDung()
    {
        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);
        
        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;

        // Lấy thông tin toàn bộ người dùng (nhân viên, quản lý, quản trị, ...)
        NguoiDungBUS bus = new NguoiDungBUS();
        NguoiDungDTO[] kq = bus.LayDanhSachNguoiDung(pageNum, pageSize);

        LoaiNguoiDungBUS loainguoidungbus = new LoaiNguoiDungBUS();
        LoaiNguoiDungDTO[] dsLoaiNguoiDung = loainguoidungbus.LayDanhSachLoaiNguoiDung();

        int tongSoNguoiDung = bus.TongSoNguoiDung();

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", tongSoNguoiDung.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        
        foreach (NguoiDungDTO dto in kq)
        {
            XL_THE the = new XL_THE("TaiKhoan");

            Thuoc_tinh = new XL_THUOC_TINH("MaNguoiDung", dto.Ma_nguoi_dung.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Username", dto.Username);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("HoTen", dto.Ho_ten);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            int i;
            string strPhanLoai = "";
            for (i = 0; i < dsLoaiNguoiDung.Length; ++i)
            {
                if (dsLoaiNguoiDung[i].Ma_loai_nguoi_dung == dto.Ma_loai_nguoi_dung)
                    break;
            }
            if (i == dsLoaiNguoiDung.Length)
                strPhanLoai = dto.Ma_loai_nguoi_dung.ToString() + " Không có loại người dùng tương ứng";
            else
                strPhanLoai = dsLoaiNguoiDung[i].Ten_loai_nguoi_dung;

            Thuoc_tinh = new XL_THUOC_TINH("PhanLoai", strPhanLoai);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("KichHoat", dto.Tinh_trang_kich_hoat ? "1" : "0");
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
