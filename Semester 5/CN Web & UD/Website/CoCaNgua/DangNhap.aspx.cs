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

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int NguoiChoiThu = (int) Session["NguoiChoiThu"];

        XL_THE The = new XL_THE("Goc");
        XL_THE TheCon = new XL_THE("NguoiChoiThu");
        XL_THUOC_TINH ThuocTinh = new XL_THUOC_TINH("GiaTri", NguoiChoiThu.ToString());
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);
/*
        TheCon = new XL_THE("XiNgau");
        ThuocTinh = new XL_THUOC_TINH("GiaTri", XiNgau.ToString());
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);
        */
        String Chuoi = The.Chuoi();
        XL_CHUOI.Xuat(Response, Chuoi);
    }
}
