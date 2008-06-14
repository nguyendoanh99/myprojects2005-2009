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

public partial class LuuNuocDi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int ConCo;
        int ViTri;
        try
        {
            ConCo = int.Parse(XL_CHUOI.Nhap(Request, "ConCo"));
            ViTri = int.Parse(XL_CHUOI.Nhap(Request, "ViTri"));

            QUANLY ql = (QUANLY)Application["QUANLY"];
            Application.Lock();
            ql.BanCo.ViTriCacQuanCo[ConCo] = ViTri;
            ql.XiNgau = -1;
            ql.DangDoXiNgau = false;
            Application.UnLock();
        }
        catch (Exception _e)
        {
            
        }
        
    }
}
