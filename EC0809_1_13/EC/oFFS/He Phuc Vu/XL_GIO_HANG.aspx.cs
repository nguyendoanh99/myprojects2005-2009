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

public partial class He_Phuc_Vu_XL_GIO_HANG : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Xac_nhan"] == "Them_vao_gio_hang")
            Them_vao_gio_hang();
        else if (Request["Xac_nhan"] == "Xoa_khoi_gio_hang")
            Xoa_khoi_gio("Gio_hang");
        else if (Request["Xac_nhan"] == "Xoa_khoi_gio_qua_tang")
            Xoa_khoi_gio("Gio_qua_tang");
        else if (Request["Xac_nhan"] == "Cap_nhat_tien")
            Cap_nhat_tien();
        else if (Request["Xac_nhan"] == "Cap_nhat_tien_qua_tang")
            Cap_nhat_tien_qua_tang();
        // if (Request["Xac_nhan"] == "Tinh_tien")
        //     Tinh_tien();
        else if (Request["Xac_nhan"] == "Ghi_nhan_dat_hang")
            Ghi_nhan_dat_hang();
        else if (Request["Xac_nhan"] == "Thong_tin_chinh_gio_hang")
            Thong_tin_chinh_gio_hang();
        else if (Request["Xac_nhan"] == "Xuat_thong_tin_gio_hang")
        {
            //Gio_hang_online gio_hang = (Gio_hang_online)Session["Gio_hang_customer"];
            //Xuat_thong_tin_gio_hang(gio_hang);
            Thong_tin_chinh_gio_hang();
        }
        else if (Request["Xac_nhan"] == "Them_vao_gio_qua_tang")
            Them_vao_gio_qua_tang();
      
    }

    private void Xoa_khoi_gio(string gio)
    {
        int ma_mon = int.Parse(Request["Ma_mon_an"].ToString());

        Gio_hang_online gio_hang = new Gio_hang_online();

        if (Session[gio] == null)
            {
                return;
            }
            else
            {
                gio_hang = (Gio_hang_online)Session[gio];
                for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
                {
                    Item_online mon_an = (Item_online)gio_hang.DsMonAn[i];
                    if (mon_an.Ma_item == ma_mon)
                        gio_hang.DsMonAn.RemoveAt(i);
                }
                Tinh_gia_tri_gio_hang(ref gio_hang);
                Session[gio] = gio_hang;
            }
       
        Xuat_thong_tin_gio_hang(gio_hang);
    }

    private void Cap_nhat_tien()
    {
        int ma_mon = int.Parse(Request["Ma_mon_an"].ToString());

        Gio_hang_online gio_hang = new Gio_hang_online();

     
            if (Session["Gio_hang"] == null)
            {
                return;
            }
            else
            {
                gio_hang = (Gio_hang_online)Session["Gio_hang"];
                for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
                {
                    Item_online mon_an = (Item_online)gio_hang.DsMonAn[i];
                    if (mon_an.Ma_item == ma_mon)
                    {
                        //gio_hang.DsMonAn.RemoveAt(i);
                        mon_an.So_luong = int.Parse(Request["So_luong"].ToString());
                        gio_hang.DsMonAn[i] = mon_an;
                    }
                }
                Tinh_gia_tri_gio_hang(ref gio_hang);
                //gio_hang.DsMonAn.Sort();
                Session["Gio_hang"] = gio_hang;
            }
     
        Xuat_thong_tin_gio_hang(gio_hang);
    }

    private void Cap_nhat_tien_qua_tang()
    {
        int ma_mon = int.Parse(Request["Ma_mon_an"].ToString());

        Gio_hang_online gio_hang = new Gio_hang_online();


        if (Session["Gio_qua_tang"] == null)
        {
            return;
        }
        else
        {
            gio_hang = (Gio_hang_online)Session["Gio_qua_tang"];
            for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
            {
                Item_online mon_an = (Item_online)gio_hang.DsMonAn[i];
                if (mon_an.Ma_item == ma_mon)
                {
                    //gio_hang.DsMonAn.RemoveAt(i);
                    mon_an.So_luong = int.Parse(Request["So_luong"].ToString());
                    gio_hang.DsMonAn[i] = mon_an;
                }
            }
            Tinh_gia_tri_gio_hang(ref gio_hang);
            //gio_hang.DsMonAn.Sort();
            Session["Gio_qua_tang"] = gio_hang;
        }

        Xuat_thong_tin_gio_hang(gio_hang);
    }

    private void Tinh_gia_tri_gio_hang(ref Gio_hang_online gio_hang)
    {
        decimal tong_gia_tri = 0;
        for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
        {
            Item_online mon_an_ol = (Item_online)gio_hang.DsMonAn[i];
            tong_gia_tri += mon_an_ol.So_luong * mon_an_ol.Gia;
        }
        gio_hang.gia_tri = tong_gia_tri;
    }
    private void Ghi_nhan_dat_hang()
    {
        ArrayList arr = new ArrayList();
        int ma = int.Parse(Request["Ma"].ToString());
        MonAnBUS monanBUS = new MonAnBUS();
        if (Request["Loai"] == "0")
        {
            MonAnDTO MonAn = monanBUS.ChiTietMonAn(ma);

            Item_online mon_an = new Item_online();
            mon_an.Ma_item = MonAn.Ma_mon;
            mon_an.Ten_item = MonAn.Ten_mon;
            mon_an.Hinh_anh_minh_hoa = MonAn.Hinh_anh_minh_hoa;
            mon_an.Gia = MonAn.Gia;
            mon_an.Loai_item = 0;
            mon_an.So_luong = int.Parse(Request["So_luong"].ToString());

            Session["Item_online"] = mon_an;
        }
        else if (Request["Loai"] == "1")
        {
            ThucDonBUS thucdonBUS = new ThucDonBUS();
            //ThucDonDTO ThucDon = thucdonBUS.ThongTinThucDon(ma);
            ThucDonDTO thuc_don = thucdonBUS.ChiTietThucDon(ma);

            Item_online mon_an = new Item_online();
            mon_an.Ma_item = thuc_don.Ma_thuc_don;
            mon_an.Ten_item = thuc_don.Ten_thuc_don;
            mon_an.Hinh_anh_minh_hoa = thuc_don.Hinh_anh_minh_hoa;
            mon_an.Gia = thuc_don.Gia;
            mon_an.Loai_item = 1;
            mon_an.So_luong = int.Parse(Request["So_luong"].ToString());

            Session["Item_online"] = mon_an;
        }
        else
        {
            ThucDonCaNhanBUS thucdonBUS = new ThucDonCaNhanBUS();
            //ThucDonDTO ThucDon = thucdonBUS.ThongTinThucDon(ma);
            ThucDonCaNhanDTO thuc_don = thucdonBUS.ChiTietThucDonCaNhan(ma);

            Item_online mon_an = new Item_online();
            mon_an.Ma_item = thuc_don.Ma_thuc_don_ca_nhan;
            mon_an.Ten_item = thuc_don.Ten_thuc_don;
            mon_an.Hinh_anh_minh_hoa = thuc_don.Hinh_anh;
            mon_an.Gia = thuc_don.Gia;
            mon_an.Loai_item = 1;
            mon_an.So_luong = int.Parse(Request["So_luong"].ToString());

            Session["Item_online"] = mon_an;
        }
    }

    private void Xuat_thong_tin_gio_hang(Gio_hang_online gio_hang)
    {
        if (gio_hang.DsMonAn == null)
            return;

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
        {
            XL_THE Kq1 = new XL_THE("MonAn");

            Item_online mon_an_ol = (Item_online)gio_hang.DsMonAn[i];
            decimal gia_tri = gio_hang.gia_tri;

            int so_luong = mon_an_ol.So_luong;
            decimal Tong_gia_tri_mon_an = so_luong * mon_an_ol.Gia;

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_mon", mon_an_ol.Ma_item.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_mon", mon_an_ol.Ten_item);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Hinh_anh_minh_hoa", mon_an_ol.Hinh_anh_minh_hoa);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Gia", mon_an_ol.Gia.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("So_luong", so_luong.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Tong_gia_tri_mon_an", Tong_gia_tri_mon_an.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_THE Kq2 = new XL_THE("TongSoItem");
        XL_THUOC_TINH Thuoc_tinh1 = new XL_THUOC_TINH("TongSoItem", gio_hang.DsMonAn.Count.ToString());
        Kq2.Danh_sach_thuoc_tinh.Add(Thuoc_tinh1);
        Kq.Danh_sach_the.Add(Kq2);

        Kq2 = new XL_THE("TongGiaTri");
        Thuoc_tinh1 = new XL_THUOC_TINH("TongGiaTri", gio_hang.gia_tri.ToString());
        Kq2.Danh_sach_thuoc_tinh.Add(Thuoc_tinh1);
        Kq.Danh_sach_the.Add(Kq2);

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }


    private void Them_vao_gio_hang()
    {
        Gio_hang_online gio_hang = new Gio_hang_online();
        bool flag = false;
        if (Session["Item_online"] == null)
        {
            if (Session["Gio_hang"] != null)
                gio_hang = (Gio_hang_online)Session["Gio_hang"];
   
            Xuat_thong_tin_gio_hang(gio_hang);
            return;
        }
        Item_online mon_an = (Item_online)Session["Item_online"];
        Session["Item_online"] = null;

       
            if (Session["Gio_hang"] == null)
            {
                gio_hang.username = "";
                gio_hang.DsMonAn = new ArrayList();
                gio_hang.DsMonAn.Add(mon_an);
                Tinh_gia_tri_gio_hang(ref gio_hang);
                Session["Gio_hang"] = gio_hang;
            }
            else
            {
                gio_hang = (Gio_hang_online)Session["Gio_hang"];
                for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
                {
                    Item_online ma = (Item_online)gio_hang.DsMonAn[i];
                    if (mon_an.Ma_item == ma.Ma_item)
                    {
                        ma.So_luong += mon_an.So_luong;
                        gio_hang.DsMonAn[i] = ma;
                        flag = true;
                    }
                }
                if (flag == false)
                    gio_hang.DsMonAn.Add(mon_an);
                Tinh_gia_tri_gio_hang(ref gio_hang);
                Session["Gio_hang"] = gio_hang;
            }
       
        Xuat_thong_tin_gio_hang(gio_hang);
    }

    private void Them_vao_gio_qua_tang()
    {
        Gio_hang_online gio_qua_tang = new Gio_hang_online();
        bool flag = false;
        
        if (Session["Item_online"] == null)
        {
            if (Session["Gio_qua_tang"] != null)
                gio_qua_tang = (Gio_hang_online)Session["Gio_qua_tang"];
            Xuat_thong_tin_gio_hang(gio_qua_tang);
            return;
        }
        Item_online mon_an = (Item_online)Session["Item_online"];
        Session["Item_online"] = null;


        if (Session["Gio_qua_tang"] == null)
        {
            gio_qua_tang.username = Session["User"].ToString();
            gio_qua_tang.DsMonAn = new ArrayList();
            gio_qua_tang.DsMonAn.Add(mon_an);
            Tinh_gia_tri_gio_hang(ref gio_qua_tang);
            Session["Gio_qua_tang"] = gio_qua_tang;
        }
        else
        {
            gio_qua_tang = (Gio_hang_online)Session["Gio_qua_tang"];
            for (int i = 0; i < gio_qua_tang.DsMonAn.Count; i++)
            {
                Item_online ma = (Item_online)gio_qua_tang.DsMonAn[i];
                if (mon_an.Ma_item == ma.Ma_item)
                {
                    ma.So_luong += mon_an.So_luong;
                    gio_qua_tang.DsMonAn[i] = ma;
                    flag = true;
                }
            }
            if (flag == false)
                gio_qua_tang.DsMonAn.Add(mon_an);
            Tinh_gia_tri_gio_hang(ref gio_qua_tang);
            Session["Gio_qua_tang"] = gio_qua_tang;
        }

        Xuat_thong_tin_gio_hang(gio_qua_tang);
    }

    private void Thong_tin_chinh_gio_hang()
    {
        XL_THE Kq = new XL_THE("THONGTIN");
        Gio_hang_online gio_hang = new Gio_hang_online();

                
            if (Session["Gio_hang"] == null)
            {
                return;
            }
            else
            {                
                gio_hang = (Gio_hang_online)Session["Gio_hang"];
                int so_items = 0;
                for (int i = 0; i < gio_hang.DsMonAn.Count; i++)
                {
                    Item_online ma = (Item_online)gio_hang.DsMonAn[i];
                    so_items += ma.So_luong;
                }
                XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("So_items", so_items.ToString());
                Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
                Thuoc_tinh = new XL_THUOC_TINH("Tong_gia_tri", gio_hang.gia_tri.ToString());
                Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

                XL_CHUOI.XuatXML(Response, Kq.Chuoi());
            }
       
    }
}
