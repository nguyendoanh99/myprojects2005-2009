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

public partial class XL_LoaiMon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayDSLoaiMon")
            LayDSLoaiMon();
        else if (Request["xac_nhan"] == "LayDSLoaiMonLa")
            LayDSLoaiMonLa();
        else if (Request["xac_nhan"] == "ThemLoaiMonMoi")
            ThemLoaiMonMoi();
        else if (Request["xac_nhan"] == "LayDanhSachLoaiMonCon")
            LayDanhSachLoaiMonCon();
        else if (Request["xac_nhan"] == "LayDSMonAn")
            LayDSMonAn();
        else if (Request["xac_nhan"] == "ChiTietLoaiMon")
            ChiTietLoaiMon();
        else if (Request["xac_nhan"] == "LayDSLoaiMonGoc")
            LayDSLoaiMonGoc();
        else if (Request["xac_nhan"] == "GhiNhanLoaiMon")
            GhiNhanLoaiMon();
        else if (Request["xac_nhan"] == "DuyetCayLoaiMon")
            DuyetCayLoaiMon();
        else if (Request["xac_nhan"] == "XoaLoaiMon")
            XoaLoaiMon();
    }

    protected void XoaLoaiMon()
    {
        //Lấy tham số client truyền xuống
        int maloaimon = int.Parse(XL_CHUOI.Nhap(Request, "maloaimon"));

        //Xóa loại món
        LoaiMonBUS khBus = new LoaiMonBUS();
        bool kq = new LoaiMonBUS().XoaLoaiMon(maloaimon);


        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        //Them thanh cong
        if (kq == true)
        {
            thuoc_tinh = new XL_THUOC_TINH("kq", "1");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "0");

        //Trả kết quả về client
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void DuyetCayLoaiMon()
    {
        // Xử lý request
        int pageSize = 10;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        int startIndex = 0;
        if (Request["startIndex"] != null)
        {
            startIndex = int.Parse((string)Request["startIndex"]);
            pageNum = (startIndex / pageSize) + 1;
        }

        //Duyệt cây loại món 
        ArrayList ds = new ArrayList();
        LoadLoaiMonDeQui(-1, 0, ds);

        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", ds.Count.ToString());
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        int n = startIndex + pageSize;
        n = (n < ds.Count) ? n : ds.Count;

        for (int i=startIndex; i<n; i++)
        {
            LoaiMonItem lmItem = (LoaiMonItem)ds[i];

            XL_THE the = new XL_THE("Record");

            Thuoc_tinh = new XL_THUOC_TINH("MaLoaiMon", lmItem.MaLoaiMon.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TenLoaiMon", lmItem.TenLoaiMon.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("LaLoaiMonLa", lmItem.LaLoaiMonLa.ToString());
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            if(lmItem.LaLoaiMonLa == true)
                Thuoc_tinh = new XL_THUOC_TINH("SoLuongMonCon", lmItem.SoLuongMonCon.ToString());
            else
                Thuoc_tinh = new XL_THUOC_TINH("SoLuongMonCon", "-");
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
   
   private void LoadLoaiMonDeQui(int MaLMCha, int cap, ArrayList ds)
   {
       LoaiMonDTO[] dsloaimoncon = new LoaiMonBUS().DanhSachLoaiMonCon(MaLMCha);
       LoaiMonItem lmItem = new LoaiMonItem();

       foreach (LoaiMonDTO lmDto in dsloaimoncon)
       {
           lmItem.MaLoaiMon = lmDto.Ma_loai_mon;
           lmItem.TenLoaiMon = lmDto.Ten_loai_mon;
           lmItem.MaLoaiMonCha = lmDto.Ma_loai_mon_cha;
           lmItem.LaLoaiMonLa = lmDto.La_loai_mon_la;
           lmItem.SoLuongMonCon = -1;

           //định dạng tên loại món theo cấp
           string chuoi = "";
           for (int i = 0; i < cap; i++)
               chuoi += "--";
           chuoi += lmItem.TenLoaiMon;
           lmItem.TenLoaiMon = chuoi; //"<a href=ThemMonMoi.aspx>" + chuoi.Trim() + "</a>" ;

           //neu la mon la, tinh so luong mon con
           if (lmItem.LaLoaiMonLa == true)    
               lmItem.SoLuongMonCon = new MonAnBUS().TinhSoLuongMonAnThuocLoaiMon(lmItem.MaLoaiMon);

           ds.Add(lmItem);

           cap++;
           LoadLoaiMonDeQui(lmDto.Ma_loai_mon, cap, ds);
           cap--;
       }
   }
   

    protected void GhiNhanLoaiMon()
    {
        Session["LoaiMon"] = Request["Ma_loai_mon"];
    }

    protected void ChiTietLoaiMon()
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO LoaiMonAn = loaimonBUS.ChiTietLoaiMon(int.Parse(Request["MaLoaiMon"].ToString()));

        XL_THE Kq1 = new XL_THE("Loai_Mon_An");

        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMon", LoaiMonAn.Ma_loai_mon.ToString()));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiMon", LoaiMonAn.Ten_loai_mon));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMonCha", LoaiMonAn.Ma_loai_mon_cha.ToString()));
        Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiMonLa", LoaiMonAn.La_loai_mon_la.ToString()));

        XL_CHUOI.XuatXML(Response, Kq1.Chuoi());
    }

    protected void LayDSMonAn()
    {
        MonAnBUS monanBUS = new MonAnBUS();
        MonAnDTO[] DsMonAn = monanBUS.DSMonAnThuocLoaiMon(int.Parse(Request["MaLoaiMon"].ToString()));

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsMonAn.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = DsMonAn[i];

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

    protected void LayDanhSachLoaiMonCon()
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO[] dsLoaiMon = loaimonBUS.DanhSachLoaiMonCon(int.Parse(Request["MaLoaiMon"].ToString()));

        XL_THE Kq = new XL_THE("dsLoaiMon");
        for (int i = 0; i < dsLoaiMon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMon", dsLoaiMon[i].Ma_loai_mon.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiMon", dsLoaiMon[i].Ten_loai_mon));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMonCha", dsLoaiMon[i].Ma_loai_mon_cha.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiMonLa", dsLoaiMon[i].La_loai_mon_la.ToString()));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

    protected void LayDSLoaiMon() 
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO[] dsLoaiMon = loaimonBUS.DanhSachLoaiMon();

        XL_THE Kq = new XL_THE("dsLoaiMon");
        for (int i = 0; i < dsLoaiMon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMon", dsLoaiMon[i].Ma_loai_mon.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiMon", dsLoaiMon[i].Ten_loai_mon));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMonCha", dsLoaiMon[i].Ma_loai_mon_cha.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiMonLa", dsLoaiMon[i].La_loai_mon_la.ToString()));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

    protected void LayDSLoaiMonLa()   //lá
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO[] dsLoaiMon = loaimonBUS.DanhSachLoaiMonLa();

        XL_THE Kq = new XL_THE("dsLoaiMon");
        for (int i = 0; i < dsLoaiMon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMon", dsLoaiMon[i].Ma_loai_mon.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiMon", dsLoaiMon[i].Ten_loai_mon));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMonCha", dsLoaiMon[i].Ma_loai_mon_cha.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("LaLoaiMonLa", dsLoaiMon[i].La_loai_mon_la.ToString()));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

    protected void LayDSLoaiMonGoc() //gốc
    {
        LoaiMonBUS loaimonBUS = new LoaiMonBUS();
        LoaiMonDTO[] dsLoaiMon = loaimonBUS.LayDanhSachLoaiMonGoc();

        XL_THE Kq = new XL_THE("dsLoaiMon");
        for (int i = 0; i < dsLoaiMon.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiMon", dsLoaiMon[i].Ma_loai_mon.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiMon", dsLoaiMon[i].Ten_loai_mon));
            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }
    protected void ThemLoaiMonMoi()
    {
        LoaiMonDTO lmDto = new LoaiMonDTO();
        //Lấy tham số client truyền xuống
        lmDto.Ten_loai_mon = XL_CHUOI.Nhap(Request, "tenloaimon");
        lmDto.Ma_loai_mon_cha = int.Parse(XL_CHUOI.Nhap(Request, "maloaimoncha"));
        lmDto.La_loai_mon_la = bool.Parse(XL_CHUOI.Nhap(Request, "laloaimonla"));

        //Thêm loại món mới
        LoaiMonBUS khBus = new LoaiMonBUS();
        bool kq = new LoaiMonBUS().ThemLoaiMon(lmDto);


        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoc_tinh;

        //Them thanh cong
        if (kq == true)
        {
            thuoc_tinh = new XL_THUOC_TINH("kq", "True");
        }
        else
            thuoc_tinh = new XL_THUOC_TINH("kq", "False");

        //Trả kết quả về client
        the.Danh_sach_thuoc_tinh.Add(thuoc_tinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
           
}
