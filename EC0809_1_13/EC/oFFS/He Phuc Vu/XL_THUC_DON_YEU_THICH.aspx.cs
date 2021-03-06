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

public partial class He_Phuc_Vu_XL_THUC_DON_YEU_THICH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xac_nhan = Request["xac_nhan"];
        if (xac_nhan == "ThemThucDon")
            ThemThucDon();
        else if (xac_nhan == "LayDSThucDon")
            LayDSThucDon();
        else if (xac_nhan == "XoaThucDon")
            XoaThucDon();
        else if (xac_nhan == "Ghi_nhan_thuc_don")
            Ghi_nhan_thuc_don();
        else if (xac_nhan == "TongSoTrang")
            TongSoTrang();
    }
    int pageSize = 10;
    void TongSoTrang()
    {
        ThucDonUaThich[] arr = bus.LayDSThucDonYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
        int tongsomon = arr.Length;
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

    protected void Ghi_nhan_thuc_don()
    {
        Session["MaThucDon"] = Request["Ma_thuc_don"];
    }

    ThucDonYeuDauBUS bus = new ThucDonYeuDauBUS();
    ThucDonBUS thucdonbus = new ThucDonBUS();

    protected void XoaThucDon()
    {
        int ma = int.Parse(Request["mathucdon"].ToString());

        //ArrayList arr = new ArrayList();
        //arr = (ArrayList)Session["MaThucDonYeuThich"];
        //for (int i = 0; i < arr.Count; i++)
        //{
        //    if (int.Parse(arr[i].ToString()) == ma)
        //    {
        //        arr.RemoveAt(i);
        //        break;
        //    }
        //}

        //Session["MaThucDonYeuThich"] = arr;

        bus.XoaThucDonYeuThich(int.Parse(Session["MaNguoiDung"].ToString()), ma);
        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    protected void ThemThucDon()
    {
        ThucDonUaThich[] arr;
        arr = bus.LayDSThucDonYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
        if (Session["MaThucDon"] != null)
        {
            ThucDonUaThich dto = new ThucDonUaThich();
            int ma = int.Parse(Session["MaThucDon"].ToString());

            if (arr == null)
            {
                dto.Ma_khach_hang = int.Parse(Session["MaNguoiDung"].ToString());
                dto.Ma_thuc_don = ma;
                bus.ThemThucDon(dto);
            }
            else 
            {
                bool flag = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (int.Parse(arr[i].Ma_thuc_don.ToString()) == ma)
                        flag = true;
                }

                if (flag == false)
                {
                    dto.Ma_khach_hang = int.Parse(Session["MaNguoiDung"].ToString());
                    dto.Ma_thuc_don = ma;
                    bus.ThemThucDon(dto);                 
                }
            }

            Session["MaThucDon"] = null;
           
            XL_THE Kq = new XL_THE("DANH_SACH");
            XL_CHUOI.XuatXML(Response, Kq.Chuoi());
        }
    }
    private void LayDSThucDon()
    {
        ThucDonYeuDauBUS tdydBus = new ThucDonYeuDauBUS();

        ThucDonUaThich[] arr = tdydBus.LayDSThucDonYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
        if (arr == null)
            return;

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < arr.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("ThucDon");
            ThucDonUaThich ThucDonUT = (ThucDonUaThich)arr[i];
            ThucDonDTO thucdon = thucdonbus.ChiTietThucDon(ThucDonUT.Ma_thuc_don);

            //ThucDonDTO thucdon = thucdonbus.ChiTietThucDon((int)arr[i]);

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_thuc_don", thucdon.Ma_thuc_don.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_thuc_don", thucdon.Ten_thuc_don);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", thucdon.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", thucdon.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", thucdon.Tinh_trang.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Diem_binh_chon", thucdon.Diem_binh_chon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);     

            Kq.Danh_sach_the.Add(Kq1);
        }        

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

}
