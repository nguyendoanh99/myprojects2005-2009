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

public partial class He_Phuc_Vu_XL_MON_AN : System.Web.UI.Page
{
    //LoaiMonDTO[] dsLoaiMon = null;
    int pageSize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Xac_nhan"] == "Lay_danh_sach")
            Lay_danh_sach();
        else if (Request["Xac_nhan"] == "LayDSMonAnHienThi")
            LayDSMonAnHienThi();
        else if (Request["xac_nhan"] == "TongSoTrang")
            TongSoTrang();
        else if (Request["Xac_nhan"] == "Ghi_nhan_mon_an")
            Ghi_nhan_mon_an();
        else if (Request["Xac_nhan"] == "Chi_tiet_mon_an")
            Chi_tiet_mon_an();
        else if (Request["xac_nhan"] == "ThemMonMoi")
            ThemMonMoi();
        else if (Request["xac_nhan"] == "LayDSTenMonAn")
            LayDSTenMonAn();
        else if (Request["Xac_nhan"] == "DS_mon_an_theo_tag")
            DS_mon_an_theo_tag();
        else if (Request["Xac_nhan"] == "DsMonAnThuocLoaiMon")
            DsMonAnThuocLoaiMon();
        else if (Request["Xac_nhan"] == "DsMonAnThuocLoaiMonBatKy")
            DsMonAnThuocLoaiMonBatKy();
        else if (Request["Xac_nhan"] == "Lay_danh_sach_qua_tang")
            DsQuaTang();
        else if (Request["Xac_nhan"] == "TimKiem")
            TimKiem();
        else if (Request["Xac_nhan"] == "GhiNhanThongTinTimKiemTheoTen")
            GhiNhanThongTinTimKiemTheoTen();
        else if (Request["Xac_nhan"] == "GhiNhanThongTinTimKiemNangCao")
            GhiNhanThongTinTimKiemNangCao();
    }

    protected void DsMonAnThuocLoaiMonBatKy()
    {
        int pageSize = 5;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        int startIndex = 0;
        if (Request["startIndex"] != null)
        {
            startIndex = int.Parse((string)Request["startIndex"]);
            pageNum = (startIndex / pageSize) + 1;
        }

        MonAnBUS mon_anBUS = new MonAnBUS();
        ArrayList dsMonAn = new ArrayList();
        int index = 0;        
        int loaimon = -1;

        if (Session["LoaiNguoiDung"].ToString() == "NhanVien")
            loaimon = int.Parse((string)Request["LoaiMon"]);
        else
            loaimon = int.Parse(Session["LoaiMon"].ToString());
        dsMonAn = mon_anBUS.LayDSMonAnThuocLoaiMonBatKy(loaimon);
        int n = dsMonAn.Count;

        XL_THE Kq = new XL_THE("DANH_SACH");

        if (Session["LoaiNguoiDung"].ToString() == "NhanVien") //co phan trang
        {   
            index = startIndex;
            n = startIndex + pageSize;
            n = (n < dsMonAn.Count) ? n : dsMonAn.Count;

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", dsMonAn.Count.ToString());
            Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        }

        

        for (int i = index; i < n; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = (MonAnDTO)dsMonAn[i];
            if (MonAn.Trang_thai_hien_thi == false)
                continue;
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

    protected void GhiNhanThongTinTimKiemTheoTen()
    {
        ArrayList arr = new ArrayList();
        arr.Add(Request["ten_mon"].ToString());
        Session["info"] = arr;
    }

    protected void GhiNhanThongTinTimKiemNangCao()
    {
        ArrayList arr = new ArrayList();
        arr.Add(Request["ten_mon"].ToString());
        arr.Add(Request["ma_loai_mon"].ToString());
        arr.Add(Request["tag"].ToString());
        arr.Add(Request["gia_min"].ToString());
        arr.Add(Request["gia_max"].ToString());
        Session["info"] = arr;
    }

    protected void TimKiem()
    {
        MonAnBUS monanBUS = new MonAnBUS();
        ArrayList arr = (ArrayList)Session["info"];
        MonAnDTO[] dsMonAn;
        if (arr.Count == 1)
        {
            string ten_mon = arr[0].ToString();
            dsMonAn = monanBUS.TimKiemMonAnTheoTen(ten_mon);
        }
        else
        {
            string ten_mon = "";
            int ma_loai_mon = -1;
            string tag = "";
            double gia_min = -1;
            double gia_max = -1;

            if (arr[0].ToString() != "null")
                ten_mon = arr[0].ToString();
            if (arr[1].ToString() != "null")
                ma_loai_mon = int.Parse(arr[1].ToString());
            if (arr[2].ToString() != "null")
                tag = arr[2].ToString();
            if (arr[3].ToString() != "null")
                gia_min = double.Parse(arr[3].ToString());
            if (arr[4].ToString() != "null")
                gia_max = double.Parse(arr[4].ToString());

            dsMonAn = monanBUS.TimKiemMonAnNangCao(ten_mon, ma_loai_mon, tag, gia_min, gia_max);
        }

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < dsMonAn.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = dsMonAn[i];
            if (MonAn.Trang_thai_hien_thi == false)
                continue;
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

    protected void DsQuaTang()
    { 
        MonAnBUS monanBUS = new MonAnBUS();
        double limit = double.Parse((string)Request["limit"]);
        MonAnDTO[] DsMonAn = monanBUS.LayDSQuaTang(limit);

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
   
   
    protected void DsMonAnThuocLoaiMon()
    {
        // Xử lý request
        int pageSize = 5;
        if (Request["results"] != null)
            pageSize = int.Parse((string)Request["results"]);

        int pageNum = 1;
        int startIndex = 0;
        if (Request["startIndex"] != null)
        {
            startIndex = int.Parse((string)Request["startIndex"]);
            pageNum = (startIndex / pageSize) + 1;
        }

        MonAnBUS mon_anBUS = new MonAnBUS();
        ArrayList dsMonAn = new ArrayList();
        int index = 0;        
        int loaimon = -1;

        if (Session["LoaiNguoiDung"] == "NhanVien" || Session["LoaiNguoiDung"] == "QuanLy")
            loaimon = int.Parse((string)Request["LoaiMon"]);
        else
            loaimon = int.Parse(Session["LoaiMon"].ToString());

        dsMonAn = mon_anBUS.LayDSMonAnThuocLoaiMonBatKy(loaimon);
        int n = dsMonAn.Count;

        XL_THE Kq = new XL_THE("DANH_SACH");

        if (Session["LoaiNguoiDung"] == "NhanVien" || Session["LoaiNguoiDung"] == "QuanLy") //co phan trang
        {   
            index = startIndex;
            n = startIndex + pageSize;
            n = (n < dsMonAn.Count) ? n : dsMonAn.Count;

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("totalRecords", dsMonAn.Count.ToString());
            Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        }

        LoaiMonDTO lmDto = (new LoaiMonBUS()).ChiTietLoaiMon(loaimon);   //chu íu lấy tên loại món

        for (int i = index; i < n; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = (MonAnDTO)dsMonAn[i];
//             if (MonAn.Trang_thai_hien_thi == false)
//                 continue;
            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaMonAn", MonAn.Ma_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TenMonAn", MonAn.Ten_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("LoaiMonAn", lmDto.Ten_loai_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("MoTa", MonAn.Mo_ta);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("HinhAnhMinhHoa", MonAn.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("Gia", MonAn.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TrangThaiHienThi", MonAn.Trang_thai_hien_thi ? "1" : "0");
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Thuoc_tinh = new XL_THUOC_TINH("TinhTrang", MonAn.Tinh_trang ? "1": "0");
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    protected void DS_mon_an_theo_tag()
    {
        TagMonAnBUS tagmonanBUS = new TagMonAnBUS();
        MonAnDTO[] dsMonAn = tagmonanBUS.DSMonAnTheoTag(int.Parse(Session["Tag"].ToString()));

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < dsMonAn.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("TagMonAn");

            MonAnDTO MonAn = dsMonAn[i];
            if (MonAn.Trang_thai_hien_thi == false)
                continue;
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

    private void LayDSMonAnHienThi()
    {
        int pageNum = int.Parse((string)Request["pageNum"]);

        MonAnBUS monanBUS = new MonAnBUS();
        MonAnDTO[] DsMonAn = monanBUS.LayDSMonAnHienThi(pageNum, pageSize);

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
            //Thuoc_tinh = new XL_THUOC_TINH("Trang_thai_hien_thi", MonAn.Trang_thai_hien_thi.ToString());
            //Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    void TongSoTrang()
    {
        MonAnBUS bus = new MonAnBUS();
        int tongsomon = bus.TongSoMonAn();
        int kq = -1;
        // không lỗi
        if (tongsomon != -1)
        {
            kq = tongsomon / pageSize;
            kq += (tongsomon % pageSize != 0) ? 1 : 0;
        }
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("TongSoTrang", kq.ToString());
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }

    protected void ThemMonMoi()
    {
        MonAnDTO monanDTO = new MonAnDTO();
        monanDTO.Ten_mon = XL_CHUOI.Nhap(Request, "tenmon");
        monanDTO.Ma_loai_mon = int.Parse(XL_CHUOI.Nhap(Request, "loaimon"));
        monanDTO.Hinh_anh_minh_hoa = XL_CHUOI.Nhap(Request, "hinhanh");
        monanDTO.Mo_ta = XL_CHUOI.Nhap(Request, "mota");
        monanDTO.Gia = Decimal.Parse(XL_CHUOI.Nhap(Request, "gia"));
        monanDTO.Don_vi_tinh = XL_CHUOI.Nhap(Request, "donvitinh");
        String strTag = XL_CHUOI.Nhap(Request, "tag");
        monanDTO.Diem_binh_chon = 0;
        monanDTO.Tinh_trang = bool.Parse(XL_CHUOI.Nhap(Request, "tinhtrang"));
        monanDTO.Trang_thai_hien_thi = bool.Parse(XL_CHUOI.Nhap(Request, "hienthi"));

        MonAnBUS monanBUS = new MonAnBUS();
        int Kq = monanBUS.ThemMonAn(monanDTO, strTag);

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

    private void Lay_danh_sach()
    {
        MonAnBUS monanBUS = new MonAnBUS();
        MonAnDTO[] DsMonAn = monanBUS.DanhSachMonAn();

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsMonAn.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = DsMonAn[i];
            if (MonAn.Trang_thai_hien_thi == false)
                continue;
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

    private void Ghi_nhan_mon_an()
    {
        Session["MaMon"] = Request["Ma_mon_an"];
    }

    private void Chi_tiet_mon_an()
    {
        int ma_mon = int.Parse(Session["MaMon"].ToString());

        //oFFS_BUS_WS.WebService service = new oFFS_BUS_WS.WebService();
        MonAnBUS monanBUS = new MonAnBUS();
        MonAnDTO MonAn = monanBUS.ChiTietMonAn(ma_mon);

        XL_THE Kq = new XL_THE("DANH_SACH");

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
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    public void LayDSTenMonAn()
    {
        MonAnBUS monanBUS = new MonAnBUS();
        MonAnDTO[] DsMonAn = monanBUS.DanhSachMonAn();

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsMonAn.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnDTO MonAn = DsMonAn[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaMon", MonAn.Ma_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("TenMon", MonAn.Ten_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
