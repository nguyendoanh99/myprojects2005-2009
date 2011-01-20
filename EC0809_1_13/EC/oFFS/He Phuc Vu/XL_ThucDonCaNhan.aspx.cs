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

public partial class He_Phuc_Vu_XL_ThucDonCaNhan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xac_nhan = Request["xac_nhan"];
        if (xac_nhan == "ThemThucDonTuTao")
            ThemThucDonTuTao();
        else if (xac_nhan == "Ghi_nhan_thuc_don")
            Ghi_nhan_thuc_don();
        else if (xac_nhan == "Lay_ma_thuc_don")
            Lay_ma_thuc_don();
        else if (xac_nhan == "Chi_tiet_thuc_don")
            Chi_tiet_thuc_don();
        else if (xac_nhan == "Lay_danh_sach_thuc_don_tu_tao")
            Lay_danh_sach_thuc_don_tu_tao();
    }

    private void Chi_tiet_thuc_don()
    {
        int ma_thuc_don = int.Parse(Session["MaThucDon"].ToString());

        //oFFS_BUS_WS.WebService service = new oFFS_BUS_WS.WebService();
        ThucDonCaNhanBUS thucdonBUS = new ThucDonCaNhanBUS();
        MonAnBUS monanBUS = new MonAnBUS();
        XL_THE Kq = new XL_THE("DANH_SACH");

        int[] arr = thucdonBUS.MonAnThuocThucDonCaNhan(ma_thuc_don);

        for (int i = 0; i < arr.Length; i++)
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

    protected void Lay_danh_sach_thuc_don_tu_tao()
    {
        int makhachhang = int.Parse(Session["MaNguoiDung"].ToString());

        ThucDonBUS thucdonbus = new ThucDonBUS();
        ThucDonCaNhanBUS thcnBus = new ThucDonCaNhanBUS();
        ThucDonCaNhanDTO[] arr = thcnBus.LayDSThucDonYeuThich(makhachhang);

        if (arr == null)
            return;

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < arr.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");
            ThucDonCaNhanDTO ThucDonCaNhan = (ThucDonCaNhanDTO)arr[i];
            //ThucDonDTO thucdon = thucdonbus.ChiTietThucDon(ThucDonCaNhan.Ma_thuc_don_ca_nhan);

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_thuc_don", ThucDonCaNhan.Ma_thuc_don_ca_nhan.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_thuc_don", ThucDonCaNhan.Ten_thuc_don);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", ThucDonCaNhan.Hinh_anh);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", ThucDonCaNhan.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);                       

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    protected void ThemThucDonTuTao()
    {
        //if(Session["User"] == null)
        //    return; //không đc dùng chức năng

        //test : gán 
        //Session["User"] = "tinyfoot";


        String Username = Session["User"].ToString();
 
        ThucDonCaNhanDTO dto = new ThucDonCaNhanDTO();
        dto.Ten_thuc_don = XL_CHUOI.Nhap(Request, "ten");
        dto.Gia = decimal.Parse(XL_CHUOI.Nhap(Request, "gia"));
        dto.Hinh_anh = XL_CHUOI.Nhap(Request, "hinh_anh");

        //lấy mã khách hàng
        if (Session["khachhang"] != null) //đã có thông tin trong session khách hàng
            dto.Ma_khach_hang = ((viewKhachHangDTO)Session["khachhang"]).Ma_nguoi_dung;
        else
        {       //chưa có thông tin -> đọc thông tin về kh từ username
            KhachHangBUS khBus = new KhachHangBUS();
            viewKhachHangDTO viewKH = khBus.LayThongTinKhachHang(Username);
            dto.Ma_khach_hang = viewKH.Ma_nguoi_dung;
        }


        String strDsMaMonAn = XL_CHUOI.Nhap(Request, "dsmamonan");
        String[] M = strDsMaMonAn.Split(new String[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        
        ThucDonCaNhanBUS bus = new ThucDonCaNhanBUS();
        int Kq = bus.ThemThucDon(dto, M);

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

    protected void Ghi_nhan_thuc_don()
    {
        Session["MaThucDon"] = Request["Ma_thuc_don"];
    }

    protected void Lay_ma_thuc_don()
    {
        XL_THE Kq = new XL_THE("DANH_SACH");
        if (Session["MaThucDon"] == null)
            Kq.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("Ma_thuc_don", "-1"));
        else
            Kq.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("Ma_thuc_don", Session["MaThucDon"].ToString()));

        Session["MaThucDon"] = null;
        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());   
    }
}
