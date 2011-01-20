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

public partial class ThongTinQuangCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
        }
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    //private string GetJavaScript()
    //{
        //StringBuilder JavaScript = new StringBuilder();
        //JavaScript.Append("Danh_sach_quang_cao();\n");
        //JavaScript.Append("XL_QUANG_CAO.Thuc_hien_danh_sach_quang_cao(1);\n");        
        //return JavaScript.ToString();
    //}
}
