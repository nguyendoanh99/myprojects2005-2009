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

public partial class ChiTietThucDon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_THUC_DON.Chi_tiet_thuc_don();\n");
        JavaScript.Append("document.getElementById('pathway').innerHTML += 'Chi tiết thực đơn';\n");
        JavaScript.Append("XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite('ChiTietThucDon');\n");
        return JavaScript.ToString();
    }
}
