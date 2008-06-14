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

public partial class LayTrangThaiBanCo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QUANLY ql = (QUANLY)Application["QUANLY"];
        int luotdi = ql.LuotDi;
        int XiNgau = ql.XiNgau;
        Boolean DangDoXiNgau = ql.DangDoXiNgau;
        int[] vitri = ql.BanCo.ViTriCacQuanCo;
        XL_THE The = new XL_THE("Goc");
        XL_THE TheCon = new XL_THE("LuotDi");
        XL_THUOC_TINH ThuocTinh = new XL_THUOC_TINH("GiaTri", luotdi.ToString());
        // Them luot di vao xml
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);

        TheCon = new XL_THE("XiNgau");
        ThuocTinh = new XL_THUOC_TINH("GiaTri", XiNgau.ToString());
        // Them Xi Ngau vao xml
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);

        TheCon = new XL_THE("DangDoXiNgau");
        ThuocTinh = new XL_THUOC_TINH("GiaTri", (DangDoXiNgau ? 1 : 0).ToString());
        // Them DangDoXiNgau vao xml
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);

        int SoNguoiChoi = ql.SoNguoiChoi;
        int SoNguoiXem = ql.SoNguoiXem;
        
        TheCon = new XL_THE("SoNguoiChoi");
        ThuocTinh = new XL_THUOC_TINH("GiaTri", SoNguoiChoi.ToString());
        // Them SoNguoiChoi vao xml
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);

        TheCon = new XL_THE("SoNguoiXem");
        ThuocTinh = new XL_THUOC_TINH("GiaTri", SoNguoiXem.ToString());
        // Them SoNguoiXem vao xml
        TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
        The.Danh_sach_the.Add(TheCon);
        
        // Vi tri cac quan co
        for (int i = 0; i < 16; ++i)
        {
            TheCon = new XL_THE("Co");
            ThuocTinh = new XL_THUOC_TINH("ViTri", vitri[i].ToString());
            TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
            The.Danh_sach_the.Add(TheCon);
        }
        String Chuoi = The.Chuoi();
        XL_CHUOI.Xuat(Response, Chuoi);
    }
}
