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

public partial class ChuyenLuotDi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            QUANLY ql = (QUANLY)Application["QUANLY"];
            Application.Lock();
            ql.LuotDi = (ql.LuotDi + 1) % ql.SoNguoiChoi;
            ql.XiNgau = -1;
            ql.DangDoXiNgau = false;
            Application.UnLock();
        }
        catch (Exception _e)
        {

        }
        
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}
