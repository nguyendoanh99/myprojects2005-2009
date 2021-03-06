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

public partial class He_Phuc_Vu_QTThayDoiQuiDinhHeThong : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];

        if (r == "LayThamSo")
        {
            LayThamSo();
            return;
        }
        if (r == "LuuThamSo")
        {
            LuuThamSo();
            return;
        }
    }

    private void LuuThamSo()
    {
        ThamSoBUS bus = new ThamSoBUS();

        ThamSoDTO dto = new ThamSoDTO();

        dto.GiaTriDiemSo = decimal.Parse(Request["GiaTriDiemSo"].ToString());
        dto.DiemKhachHangThanThiet = int.Parse(Request["DiemKhachHangThanThiet"].ToString());
        dto.TiLeGiamGiaThucDon = float.Parse(Request["TiLeGiamGiaThucDon"].ToString()) / 100;
        dto.Thue = float.Parse(Request["Thue"].ToString()) / 100;
        dto.GiaTriDoiDiemKhuyenMai = decimal.Parse(Request["GiaTriDoiDiemKhuyenMai"].ToString());
        dto.GioiHanDoiDiemKhuyenMai = float.Parse(Request["GioiHanDoiDiemKhuyenMai"].ToString()) / 100;

        bool flag = bus.LuuThamSo(dto);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
    private void LayThamSo()
    {
        ThamSoBUS bus = new ThamSoBUS();

        ThamSoDTO dto = bus.LayThamSo();

        XL_THE kq = new XL_THE("ThamSo");

        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("GiaTriDiemSo", ((int)dto.GiaTriDiemSo).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("DiemKhachHangThanThiet", ((int)dto.DiemKhachHangThanThiet).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("TiLeGiamGiaThucDon", ((int)(dto.TiLeGiamGiaThucDon * 100)).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("Thue", ((int)(dto.Thue * 100)).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("GiaTriDoiDiemKhuyenMai", ((int)dto.GiaTriDoiDiemKhuyenMai).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        Thuoc_tinh = new XL_THUOC_TINH("GioiHanDoiDiemKhuyenMai", ((int)(dto.GioiHanDoiDiemKhuyenMai * 100)).ToString());
        kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        XL_CHUOI.XuatXML(Response, kq.Chuoi());
    }
}
