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

public partial class AddToCard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] == "KhachHang")
            txtloaind.Value = "KhachHang";

        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_GIO_HANG.Them();\n");
        JavaScript.Append("document.getElementById('pathway').innerHTML += 'Thông tin giỏ hàng';\n");
        JavaScript.Append("XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite('AddToCard');\n");
        return JavaScript.ToString();
    }           
}
