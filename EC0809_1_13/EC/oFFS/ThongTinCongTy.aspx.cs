using System;
using System.ComponentModel;
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

public partial class ThongTinCongTy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
        }
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript1", GetJavaScript1(), true);    
        Page.ClientScript.RegisterClientScriptResource(this.GetType(), GetJavaScript1());
    }
    private string GetJavaScript1()
    {        
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_CongTy.HienThiThongTin();\n");      
        return JavaScript.ToString();
    }

}
