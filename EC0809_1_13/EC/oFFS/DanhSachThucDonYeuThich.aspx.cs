using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DanhSachThucDonYeuThich : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"].ToString().CompareTo("KhachHang") != 0)
            Response.Redirect("ErrorPage.aspx");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();        
        JavaScript.Append("XL_ThucDonYeuThich.ThemThucDonMoi();\n");
        JavaScript.Append("document.getElementById('pathway').innerHTML += 'Thực đơn yêu thích';\n");
        JavaScript.Append("XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite('DanhSachThucDonYeuThich');\n");
        return JavaScript.ToString();
    }
}
