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

public partial class He_Phuc_Vu_XL_NVQuanLyMonAn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "NhanVien" && Session["LoaiNguoiDung"] != "QuanLy")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "LayDanhSachMonAn")
        {
            LayDanhSachMonAn();
            return;
        }
        if (r == "CapNhatTinhTrang")
        {
            MonAnBUS bus = new MonAnBUS();
            CapNhat(bus.CapNhatTinhTrang);
            return;
        }
        if (r == "CapNhatTrangThaiHienThi")
        {
            MonAnBUS bus = new MonAnBUS();
            CapNhat(bus.CapNhatTrangThaiHienThi);
            return;
        }
        if (r == "XoaMonAn")
        {
            XoaMonAn();
            return;
        }
    }


    private void XoaMonAn()
    {
        string strMaMonAn = (string)Request["MaMonAn"];

        int maMonAn = int.Parse(strMaMonAn);
        MonAnBUS bus = new MonAnBUS();
        bool flag = bus.XoaMonAn(maMonAn);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    delegate bool CapNhatBUS(bool giaTri, int maMonAn);
    void CapNhat(CapNhatBUS cn)
    {
        string strMaMonAn = (string)Request["MaMonAn"];
        bool giaTri = int.Parse(Request["GiaTri"]) == 1;
        int maMonAn = int.Parse(strMaMonAn);

        bool flag = cn(giaTri, maMonAn);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    void LayDanhSachMonAn()
    {
        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;

        LoaiMonBUS lmBus = new LoaiMonBUS();
        MonAnBUS bus = new MonAnBUS();
        MonAnDTO[] kq = bus.DanhSachMonAn(pageNum, pageSize);

        int tongSoMonAn = bus.TongSoMonAn();

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", tongSoMonAn.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (MonAnDTO dto in kq)
        {
            XL_THE the = new XL_THE("MonAn");

            Thuoc_tinh = new XL_THUOC_TINH("MaMonAn", dto.Ma_mon.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TenMonAn", dto.Ten_mon);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            LoaiMonDTO lmDto = lmBus.ChiTietLoaiMon(dto.Ma_loai_mon);
            Thuoc_tinh = new XL_THUOC_TINH("LoaiMonAn", lmDto.Ten_loai_mon);
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
