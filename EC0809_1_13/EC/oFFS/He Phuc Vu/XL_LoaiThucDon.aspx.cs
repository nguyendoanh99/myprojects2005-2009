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

public partial class He_Phuc_Vu_XL_LoaiThucDon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayDSLoaiThucDon")
            LayDSLoaiThucDon();
        else if (Request["xac_nhan"] == "LayDanhSachLoaiThucDonCon")
            LayDanhSachLoaiThucDonCon();
        else if (Request["xac_nhan"] == "LayDSThucDon")
            LayDSThucDon();
        else if (Request["xac_nhan"] == "ChiTietLoaiThucDon")
            ChiTietLoaiThucDon();
        else if (Request["xac_nhan"] == "LayDSLoaiThucDonGoc")
            LayDSLoaiThucDonGoc();
        else if (Request["xac_nhan"] == "GhiNhanLoaiThucDon")
            GhiNhanLoaiThucDon();
    }
    protected void GhiNhanLoaiThucDon()
    {
        Session["LoaiThucDon"] = Request["Ma_loai_thuc_don"];
    }


    protected void ChiTietLoaiThucDon()
    {
        LoaiThucDonBUS loaiThucDonBUS = new LoaiThucDonBUS();
        LoaiThucDonDTO LoaiThucDon = loaiThucDonBUS.ChiTietLoaiThucDon(int.Parse(Request["MaLoaiThucDon"].ToString()));

        XL_THE Kq1 = new XL_THE("loai_thuc_don");

        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDon", LoaiThucDon.Ma_loai_thuc_don.ToString()));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiThucDon", LoaiThucDon.Ten_loai_thuc_don));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDonCha", LoaiThucDon.Ma_loai_thuc_don_cha.ToString()));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiThucDonLa", LoaiThucDon.La_loai_thuc_don_la.ToString()));

        XL_CHUOI.XuatXML(Response, Kq1.Chuoi());
    }

    protected void LayDSThucDon()
    {
        ThucDonBUS ThucDonBUS = new ThucDonBUS();
        ThucDonDTO[] DsThucDon = ThucDonBUS.DSThucDonThuocLoaiThucDon(int.Parse(Request["MaLoaiThucDon"].ToString()));

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsThucDon.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO ThucDon = DsThucDon[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_thuc_don", ThucDon.Ma_thuc_don.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_thuc_don", ThucDon.Ten_thuc_don);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", ThucDon.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);            
            Thuoc_tinh = new XL_THUOC_TINH("Gia", ThucDon.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ma_loai_thuc_don", ThucDon.Ma_loai_thuc_don.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", ThucDon.Tinh_trang.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Trang_thai_hien_thi", ThucDon.Trang_thai_hien_thi.ToString());

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    protected void LayDanhSachLoaiThucDonCon()
    {
        LoaiThucDonBUS loaiThucDonBUS = new LoaiThucDonBUS();
        LoaiThucDonDTO[] dsLoaiThucDon = loaiThucDonBUS.DanhSachLoaiThucDonCon(int.Parse(Request["MaLoaiThucDon"].ToString()));

        XL_THE Kq = new XL_THE("dsLoaiThucDon");
        for (int i = 0; i < dsLoaiThucDon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDon", dsLoaiThucDon[i].Ma_loai_thuc_don.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiThucDon", dsLoaiThucDon[i].Ten_loai_thuc_don));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDonCha", dsLoaiThucDon[i].Ma_loai_thuc_don_cha.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiThucDonLa", dsLoaiThucDon[i].La_loai_thuc_don_la.ToString()));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

    protected void LayDSLoaiThucDon()
    {
        LoaiThucDonBUS loaiThucDonBUS = new LoaiThucDonBUS();
        LoaiThucDonDTO[] dsLoaiThucDon = loaiThucDonBUS.LayDanhSachLoaiThucDon();

        XL_THE Kq = new XL_THE("dsLoaiThucDon");
        for (int i = 0; i < dsLoaiThucDon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDon", dsLoaiThucDon[i].Ma_loai_thuc_don.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiThucDon", dsLoaiThucDon[i].Ten_loai_thuc_don));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDonCha", dsLoaiThucDon[i].Ma_loai_thuc_don_cha.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiThucDonLa", dsLoaiThucDon[i].La_loai_thuc_don_la.ToString()));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

    protected void LayDSLoaiThucDonGoc()
    {
        LoaiThucDonBUS loaiThucDonBUS = new LoaiThucDonBUS();
        LoaiThucDonDTO[] dsLoaiThucDon = loaiThucDonBUS.LayDanhSachLoaiThucDonRoot();

        XL_THE Kq = new XL_THE("dsLoaiThucDon");
        for (int i = 0; i < dsLoaiThucDon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThucDon", dsLoaiThucDon[i].Ma_loai_thuc_don.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiThucDon", dsLoaiThucDon[i].Ten_loai_thuc_don));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }
}
