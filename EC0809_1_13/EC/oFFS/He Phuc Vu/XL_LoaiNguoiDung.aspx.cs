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

public partial class He_Phuc_Vu_XL_LoaiNguoiDung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String xac_nhan = Request["xac_nhan"].ToString();

        if (xac_nhan == "LoadDSLoaiNguoiDung")
            LoadDSLoaiNguoiDung();
    }

    public void LoadDSLoaiNguoiDung()
    {
        LoaiNguoiDungBUS lndBUS = new LoaiNguoiDungBUS();
        LoaiNguoiDungDTO[] dsLoaiNguoiDung = lndBUS.LayDanhSachLoaiNguoiDung();

        XL_THE Kq = new XL_THE("dsLoaiNguoiDung");
        for (int i = 0; i < dsLoaiNguoiDung.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiNguoiDung");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiNguoiDung", dsLoaiNguoiDung[i].Ma_loai_nguoi_dung.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiNguoiDung", dsLoaiNguoiDung[i].Ten_loai_nguoi_dung));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }
}
