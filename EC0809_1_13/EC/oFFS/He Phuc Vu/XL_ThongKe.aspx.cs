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

public partial class He_Phuc_Vu_XL_ThongKe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String xacnhan = Request["xac_nhan"];

        if (xacnhan == "ThongKeDoanhThu")
        {
            ThongKeDoanhThu();
        }
        else if (xacnhan == "ThongKeMonAn")
        {
            ThongKeMonAn();
        }
        else if (xacnhan == "ThongKeThucDon")
        {
            ThongKeThucDon();
        }
    }

    public void ThongKeDoanhThu()
    {
        // Xử lý request
        /*
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;
        */
        String hinhthuc = Request["hinhthuc"];
        DateTime ngaybatdau = DateTime.Parse(Request["ngaybatdau"].ToString());
        DateTime ngayketthuc = DateTime.Parse(Request["ngayketthuc"].ToString());

        ThongKeBUS bus = new ThongKeBUS();
        ArrayList arrKq = bus.ThongKeDoanhThu(hinhthuc, ngaybatdau, ngayketthuc);

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", arrKq.Count.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (ThongKeDoanhThu tk in arrKq)
        {
            XL_THE the = new XL_THE("Record");

            Thuoc_tinh = new XL_THUOC_TINH("NgayBatDau", tk.NgayBatDau.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayKetThuc", tk.NgayKetThuc.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("DoanhThu", tk.DoanhThu.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    public void ThongKeMonAn()
    {
        // Xử lý request
        /*
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;
        */

        int mamon = int.Parse(Request["mamon"]);
        String hinhthuc = Request["hinhthuc"];
        DateTime ngaybatdau = DateTime.Parse(Request["ngaybatdau"].ToString());
        DateTime ngayketthuc = DateTime.Parse(Request["ngayketthuc"].ToString());

        ThongKeBUS bus = new ThongKeBUS();
        ArrayList arrKq = bus.ThongKeMonAn(mamon, hinhthuc, ngaybatdau, ngayketthuc);

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", arrKq.Count.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (ThongKeItem tk in arrKq)
        {
            XL_THE the = new XL_THE("Record");

            Thuoc_tinh = new XL_THUOC_TINH("NgayBatDau", tk.NgayBatDau.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayKetThuc", tk.NgayKetThuc.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("SoLuongBan", tk.SoLuongBan.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    public void ThongKeThucDon()
    {
        // Xử lý request
        /*
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        if (Request["startIndex"] != null)
            pageNum = (int.Parse((string)Request["startIndex"]) / pageSize) + 1;
        */

        int mathucdon = int.Parse(Request["mathucdon"]);
        String hinhthuc = Request["hinhthuc"];
        DateTime ngaybatdau = DateTime.Parse(Request["ngaybatdau"].ToString());
        DateTime ngayketthuc = DateTime.Parse(Request["ngayketthuc"].ToString());

        ThongKeBUS bus = new ThongKeBUS();
        ArrayList arrKq = bus.ThongKeThucDon(mathucdon, hinhthuc, ngaybatdau, ngayketthuc);

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", arrKq.Count.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        foreach (ThongKeItem tk in arrKq)
        {
            XL_THE the = new XL_THE("Record");

            Thuoc_tinh = new XL_THUOC_TINH("NgayBatDau", tk.NgayBatDau.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("NgayKetThuc", tk.NgayKetThuc.ToShortDateString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("SoLuongBan", tk.SoLuongBan.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
