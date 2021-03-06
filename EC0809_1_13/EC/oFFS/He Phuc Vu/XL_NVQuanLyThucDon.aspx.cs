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

public partial class He_Phuc_Vu_XL_NVQuanLyThucDon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "NhanVien" && Session["LoaiNguoiDung"] != "QuanLy")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "LayDanhSachThucDon")
        {
            LayDanhSachThucDon();
            return;
        }
        if (r == "CapNhatTinhTrang")
        {
            ThucDonBUS bus = new ThucDonBUS();
            CapNhat(bus.CapNhatTinhTrang);
            return;
        }
        if (r == "CapNhatTrangThaiHienThi")
        {
            ThucDonBUS bus = new ThucDonBUS();
            CapNhat(bus.CapNhatTrangThaiHienThi);
            return;
        }
        if (r == "XoaThucDon")
        {
            XoaThucDon();
            return;
        }
    }

    
    private void XoaThucDon()
    {
        string strMaThucDon = (string)Request["MaThucDon"];

        int maThucDon = int.Parse(strMaThucDon);
        ThucDonBUS bus = new ThucDonBUS();
        bool flag = bus.XoaThucDon(maThucDon);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }    
    delegate bool CapNhatBUS(bool giaTri, int maThucDon);
    void CapNhat(CapNhatBUS cn)
    {
        string strMaThucDon = (string)Request["MaThucDon"];
        bool giaTri = int.Parse(Request["GiaTri"]) == 1;
        int maThucDon = int.Parse(strMaThucDon);

        bool flag = cn(giaTri, maThucDon);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    void LayDanhSachThucDon()
    {
        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;

        ThucDonBUS bus = new ThucDonBUS();
        ThucDonDTO[] kq = bus.DanhSachThucDon(pageNum, pageSize);

        LoaiThucDonBUS ltdBus = new LoaiThucDonBUS();

        int tongSoThucDon = bus.TongSoThucDon();

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", tongSoThucDon.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (ThucDonDTO dto in kq)
        {
            XL_THE the = new XL_THE("ThucDon");

            Thuoc_tinh = new XL_THUOC_TINH("MaThucDon", dto.Ma_thuc_don.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TenThucDon", dto.Ten_thuc_don);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            LoaiThucDonDTO ltdDto = ltdBus.ChiTietLoaiThucDon(dto.Ma_loai_thuc_don);
            Thuoc_tinh = new XL_THUOC_TINH("LoaiThucDon", ltdDto.Ten_loai_thuc_don);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("MoTa", dto.Mo_ta);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("HinhAnhMinhHoa", dto.Hinh_anh_minh_hoa);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Gia", dto.Gia.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TrangThaiHienThi", dto.Trang_thai_hien_thi ? "1" : "0");
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TinhTrang", dto.Tinh_trang ? "1" : "0");
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
