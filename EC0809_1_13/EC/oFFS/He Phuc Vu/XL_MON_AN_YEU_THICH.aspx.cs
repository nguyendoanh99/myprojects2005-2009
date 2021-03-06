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

public partial class He_Phuc_Vu_XL_MON_AN_YEU_THICH : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xac_nhan = Request["xac_nhan"];
        if (xac_nhan == "ThemMonAn")
            ThemMonAn();
        else if (xac_nhan == "LayDSMonAn")
            LayDSMonAn();
        else if (xac_nhan == "XoaMonAn")
            XoaMonAn();
        else if (xac_nhan == "Ghi_nhan_mon_an")
            Ghi_nhan_mon_an();
        else if (xac_nhan == "TongSoTrang")
            TongSoTrang();
    }
    int pageSize = 10;
    void TongSoTrang()
    {
        MonAnYeuDauDTO[] arr = bus.LayDSMonAnYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
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

    protected void Ghi_nhan_mon_an()
    {
        Session["MaMon"] = Request["Ma_mon"];
    }

    MonAnYeuDauBUS bus = new MonAnYeuDauBUS();
    MonAnBUS monanbus = new MonAnBUS();

    protected void XoaMonAn()
    {
        int ma = int.Parse(Request["mamon"].ToString());

        //ArrayList arr = new ArrayList();
        //arr = (ArrayList)Session["MaMonAnYeuThich"];
        //for (int i = 0; i < arr.Count; i++)
        //{
        //    if (int.Parse(arr[i].ToString()) == ma)
        //    {
        //        arr.RemoveAt(i);
        //        break;
        //    }
        //}

        //Session["MaMonAnYeuThich"] = arr;

        bus.XoaMonAnYeuDau(int.Parse(Session["MaNguoiDung"].ToString()), ma);
        XL_THE Kq = new XL_THE("DANH_SACH");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    protected void ThemMonAn()
    {
        MonAnYeuDauBUS maydBus = new MonAnYeuDauBUS();
        MonAnYeuDauDTO[] arr;
        MonAnYeuDauDTO dto = new MonAnYeuDauDTO();

        arr = maydBus.LayDSMonAnYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
        if (Session["MaMon"] != null)
        {
            int ma = int.Parse(Session["MaMon"].ToString());

            if (arr == null)
            {
                dto.Ma_khach_hang = int.Parse(Session["MaNguoiDung"].ToString());
                dto.Ma_mon = ma;
                bus.ThemMonAnYeuDau(dto);
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (int.Parse(arr[i].Ma_mon.ToString()) == ma)
                        flag = true;
                }

                if (flag == false)
                {
                    dto.Ma_khach_hang = int.Parse(Session["MaNguoiDung"].ToString());
                    dto.Ma_mon = ma;
                    bus.ThemMonAnYeuDau(dto);

                }
            }


            Session["MaMon"] = null;

            XL_THE Kq = new XL_THE("DANH_SACH");
            XL_CHUOI.XuatXML(Response, Kq.Chuoi());
        }
    }
    private void LayDSMonAn()
    {
        MonAnYeuDauBUS maydBus = new MonAnYeuDauBUS();

        MonAnYeuDauDTO[] arr = maydBus.LayDSMonAnYeuThich(int.Parse(Session["MaNguoiDung"].ToString()));
        if (arr == null)
            return;

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < arr.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            MonAnYeuDauDTO MonAnYeuDau = (MonAnYeuDauDTO)arr[i];
            MonAnDTO monan = monanbus.ChiTietMonAn(MonAnYeuDau.Ma_mon);

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_mon", monan.Ma_mon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_mon", monan.Ten_mon);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", monan.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", monan.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Tinh_trang", monan.Tinh_trang.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Diem_binh_chon", monan.Diem_binh_chon.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

}
