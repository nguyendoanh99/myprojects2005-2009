using System;
using System.Data;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_DanhSachThucDon : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_THUC_DON.Danh_sach_thuc_don();\n");
        return JavaScript.ToString();
    }
}
