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

public partial class LienHe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", GetJavaScript1(), true);
    }
    private string GetJavaScript1()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_CongTy.HienThiThongTinLienHe();\n");
        return JavaScript.ToString();
    }
}
