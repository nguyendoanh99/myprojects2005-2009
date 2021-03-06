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

public partial class He_Phuc_Vu_XL_QTDanhSachEmailDaGui : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "LayDanhSach")
        {
            LayDanhSach();
            return;
        }
        if (r == "LayNoiDungEmail")
        {
            LayNoiDungEmail();
            return;
        }
    }

    private void LayNoiDungEmail()
    {
        string strMaMail = (string)Request["MaMail"];

        int maMail = int.Parse(strMaMail);
        NoiDungEmailBUS bus = new NoiDungEmailBUS();
        NoiDungEmailDTO dto = bus.LayNoiDungEmail(maMail);
        string str = HttpUtility.HtmlEncode(dto.NoiDung);
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", str);
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    void LayDanhSach()
    {
        // Lấy thông tin toàn bộ người dùng (nhân viên, quản lý, quản trị, ...)
        NoiDungEmailBUS bus = new NoiDungEmailBUS();
        NoiDungEmailDTO[] kq = bus.LayDanhSach();


        XL_THE Kq = new XL_THE("DANH_SACH");

        foreach (NoiDungEmailDTO dto in kq)
        {
            XL_THE the = new XL_THE("TaiKhoan");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaMail", dto.MaMail.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Username", dto.Username);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Email", dto.Email);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayGui", dto.NgayGui.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TieuDe", dto.TieuDe);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
