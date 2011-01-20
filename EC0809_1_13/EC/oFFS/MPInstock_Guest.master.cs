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

public partial class MPInstock_Guest : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            lblChao.InnerText = "Chào " + Session["User"];
            lblThoat.Visible = true;
            lblDangNhap.Visible = false;
            lblDangKy.Visible = false;
            menuCaNhan.Visible = true;
        }
        else
        {
            lblChao.InnerText = "Chào bạn";
            lblThoat.Visible = false;
            lblDangKy.Visible = true;
            lblDangNhap.Visible = true;
            menuCaNhan.Visible = false;
        }
    }

    
}
