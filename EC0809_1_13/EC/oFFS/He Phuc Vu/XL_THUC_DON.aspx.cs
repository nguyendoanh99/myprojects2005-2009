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

public partial class He_Phuc_Vu_XL_THUC_DON : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request["Xac_nhan"] == "Lay_danh_sach")
             Lay_danh_sach();
         else if (Request["Xac_nhan"] == "Ghi_nhan_thuc_don")
             Ghi_nhan_thuc_don();
         if (Request["Xac_nhan"] == "Lay_ma_thuc_don")
             Lay_ma_thuc_don();
         else if (Request["Xac_nhan"] == "Chi_tiet_thuc_don")
             Chi_tiet_thuc_don();
         else if (Request["xac_nhan"] == "ChiTietThucDon")
             ChiTietThucDon();
         else if (Request["xac_nhan"] == "ThemThucDon")
             ThemThucDon();
        else if (Request["xac_nhan"] == "LayDSTenThucDon")
             LayDSTenThucDon();
         else if (Request["xac_nhan"] == "DS_thuc_don_theo_tag")
             DS_thuc_don_theo_tag();
         else if (Request["Xac_nhan"] == "DsThucDonThuocLoaiThucDon")
             DsThucDonThuocLoaiThucDon();
         else if (Request["Xac_nhan"] == "TimKiem")
             TimKiem();    
        
    }

    protected void TimKiem()
    {
        ThucDonBUS thuc_donBUS = new ThucDonBUS();
        ThucDonDTO[] dsThucDon;
        ArrayList arr = (ArrayList)Session["info"];

        if (arr.Count == 1)
        {
            string ten_thuc_don = arr[0].ToString();
            dsThucDon = thuc_donBUS.TimKiemThucDonTheoTen(ten_thuc_don);
        }
        else
        {
            string ten_thuc_don = "";
            int ma_loai_thuc_don = -1;
            string tag = "";
            double gia_min = -1;
            double gia_max = -1;

            if (arr[0].ToString() != "null")
                ten_thuc_don = arr[0].ToString();
            if (arr[1].ToString() != "null")
                ma_loai_thuc_don = int.Parse(arr[1].ToString());
            if (arr[2].ToString() != "null")
                tag = arr[2].ToString();
            if (arr[3].ToString() != "null")
                gia_min = double.Parse(arr[3].ToString());
            if (arr[4].ToString() != "null")
                gia_max = double.Parse(arr[4].ToString());

            dsThucDon = thuc_donBUS.TimKiemThucDonNangCao(ten_thuc_don, ma_loai_thuc_don, tag, gia_min, gia_max);
        }

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < dsThucDon.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO ThucDon = dsThucDon[i];
            if (ThucDon.Trang_thai_hien_thi == false)
                continue;
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
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    } 
    
    protected void DsThucDonThuocLoaiThucDon()
    {
        ThucDonBUS thuc_donBUS = new ThucDonBUS();
        ArrayList dsThucDon = thuc_donBUS.LayDSThucDonThuocLoaiThucDonBatKy(int.Parse(Session["LoaiThucDon"].ToString()));

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < dsThucDon.Count; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO ThucDon = (ThucDonDTO)dsThucDon[i];
            if (ThucDon.Trang_thai_hien_thi == false)
                continue;
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
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void DS_thuc_don_theo_tag()
    {
        TagThucDonBUS tagthucdonBUS = new TagThucDonBUS();
        ThucDonDTO[] dsThucDon = tagthucdonBUS.DSThucDonTheoTag(int.Parse(Session["Tag"].ToString()));

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < dsThucDon.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO ThucDon = dsThucDon[i];
            if (ThucDon.Trang_thai_hien_thi == false)
                continue;
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
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Lay_ma_thuc_don()
    {
        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_thuc_don", Session["MaThucDon"].ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Lay_danh_sach()
    {
        ThucDonBUS thucdonBUS = new ThucDonBUS();
        ThucDonDTO[] DsThucDon = thucdonBUS.DanhSachThucDon();

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsThucDon.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO ThucDon = DsThucDon[i];
            if (ThucDon.Trang_thai_hien_thi == false)
                continue;
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
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Ghi_nhan_thuc_don()
    {
        Session["MaThucDon"] = Request["Ma_thuc_don"];
    }

    private void Chi_tiet_thuc_don()
    {
        int ma_thuc_don = int.Parse(Session["MaThucDon"].ToString());

        //oFFS_BUS_WS.WebService service = new oFFS_BUS_WS.WebService();
        ThucDonBUS thucdonBUS = new ThucDonBUS();
        MonAnBUS monanBUS = new MonAnBUS();
        XL_THE Kq = new XL_THE("DANH_SACH");

        ArrayList arr = thucdonBUS.ThongTinThucDon(ma_thuc_don);

        for (int i = 0; i < arr.Count; i++)
        {
            MonAnDTO MonAn = monanBUS.ChiTietMonAn(int.Parse(arr[i].ToString()));

            XL_THE Kq1 = new XL_THE("MonAn");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_mon", MonAn.Ma_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_mon", MonAn.Ten_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", MonAn.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Mo_ta", MonAn.Mo_ta);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Diem_binh_chon", MonAn.Diem_binh_chon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Don_vi_tinh", MonAn.Don_vi_tinh);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", MonAn.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ma_loai_mon", MonAn.Ma_loai_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", MonAn.Tinh_trang.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Trang_thai_hien_thi", MonAn.Trang_thai_hien_thi.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }        
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    //Hàm của Nghi, truyền mã thực đơn lên từ client, chứ không gán vào session
    private void ChiTietThucDon()
    {
        int ma_thuc_don = int.Parse(Request["mathucdon"].ToString());

        ThucDonBUS thucdonBUS = new ThucDonBUS();
        MonAnBUS monanBUS = new MonAnBUS();
        XL_THE Kq = new XL_THE("DANH_SACH");

        ArrayList arr = thucdonBUS.ThongTinThucDon(ma_thuc_don);

        for (int i = 0; i < arr.Count; i++)
        {
            MonAnDTO MonAn = monanBUS.ChiTietMonAn(int.Parse(arr[i].ToString()));

            XL_THE Kq1 = new XL_THE("MonAn");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_mon", MonAn.Ma_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_mon", MonAn.Ten_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", MonAn.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", MonAn.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    public void LayDSTenThucDon()
    {
        ThucDonBUS bus = new ThucDonBUS();
        ThucDonDTO[] DsThucDon = bus.DanhSachThucDon();

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsThucDon.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");

            ThucDonDTO dto = DsThucDon[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaThucDon", dto.Ma_thuc_don.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("TenThucDon", dto.Ten_thuc_don);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }


    protected void ThemThucDon()
    {
        ThucDonDTO dto = new ThucDonDTO();
        dto.Ten_thuc_don = XL_CHUOI.Nhap(Request, "ten");
        dto.Ma_loai_thuc_don = int.Parse(XL_CHUOI.Nhap(Request, "maloai"));
        dto.Mo_ta = XL_CHUOI.Nhap(Request, "mota");
        dto.Hinh_anh_minh_hoa = XL_CHUOI.Nhap(Request, "hinhanh");
        dto.Gia = decimal.Parse(XL_CHUOI.Nhap(Request, "gia"));
        dto.Tinh_trang = bool.Parse(XL_CHUOI.Nhap(Request, "tinhtrang"));
        dto.Trang_thai_hien_thi = bool.Parse(XL_CHUOI.Nhap(Request, "hienthi"));

        String strTag = XL_CHUOI.Nhap(Request, "tag");
        String strDsMaMonAn = XL_CHUOI.Nhap(Request, "dsmamonan");
        String[] M = strDsMaMonAn.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

        ThucDonBUS bus = new ThucDonBUS();
        int Kq = bus.ThemThucDon(dto, M, strTag);

        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;
        if (Kq != 0)
        {
            thuoc_tinh = new XL_THUOC_TINH("kq", "true");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "false");

        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }


}
