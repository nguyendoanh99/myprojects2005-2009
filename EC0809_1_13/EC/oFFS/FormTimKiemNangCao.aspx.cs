using System;
using System.Text;
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

public partial class FormTimKiemNangCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite('FormTimKiemNangCao');\n");
        return JavaScript.ToString();
    }  
}
