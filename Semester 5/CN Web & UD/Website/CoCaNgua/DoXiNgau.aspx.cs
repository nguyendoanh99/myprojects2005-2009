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

public partial class DoXiNgau : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QUANLY ql = (QUANLY)Application["QUANLY"];
        int XiNgau = new Random().Next(6) + 1;
        XL_THE The = new XL_THE("Goc");
        XL_THUOC_TINH ThuocTinh = new XL_THUOC_TINH("XiNgau", XiNgau.ToString());
        // Them luot di vao xml
        The.Danh_sach_thuoc_tinh.Add(ThuocTinh);

        ql.XiNgau = XiNgau;
        ql.DangDoXiNgau = false;
        String Chuoi = The.Chuoi();
        XL_CHUOI.Xuat(Response, Chuoi);
    }
}
