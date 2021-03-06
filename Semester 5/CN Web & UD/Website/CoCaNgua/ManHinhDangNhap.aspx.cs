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
using System.Data.OleDb;
using System.Collections.Generic;
public partial class ManHinhDangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        QUANLY ql = (QUANLY)Application["QUANLY"];
        lblSoNguoiChoi.Text = ql.SoNguoiChoi.ToString();
        if (ql.SoNguoiChoi == 4)
            Login1.Enabled = false;
    }
    private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
    {
        List<String> arrUserName = new List<String>();
        List<String> arrPassword = new List<String>();
        arrUserName.Add("nguoi1");
        arrUserName.Add("nguoi2");
        arrUserName.Add("nguoi3");
        arrUserName.Add("nguoi4");

        arrPassword.Add("nguoi1");
        arrPassword.Add("nguoi2");
        arrPassword.Add("nguoi3");
        arrPassword.Add("nguoi4");
        UserName = UserName.ToUpper();
        String _username = "";
        String _password;

        for (int i = 0; i < arrUserName.Count; ++i)
        {
            _username = arrUserName[i];
            _password = arrPassword[i];
            _username = _username.ToUpper();
            if (_username == UserName && _password == Password)
            {
                QUANLY ql = (QUANLY)Application["QUANLY"];
                List<NGUOICHOI> arr = ql.arrNguoiChoi;
                for (int j = 0; j < arr.Count; ++j)
                {
                    if (arr[j].Username.ToUpper() == UserName)
                    {
                        Login1.FailureText = "Tài khoản này đã được đăng nhập. Bạn không thể đăng nhập lần nữa.";
                        return false;
                    }
                }
                return true;
            }

        }
        Login1.FailureText = "Username và password không chính xác. Xin hãy nhập lại.";
        return false;
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;
        Authenticated = SiteSpecificAuthenticationMethod(Login1.UserName, Login1.Password);

        e.Authenticated = Authenticated;
    }
    protected void Login1_LoggedIn(object sender, EventArgs e)
    {
        QUANLY ql = (QUANLY)Application["QUANLY"];
        int NguoiChoiThu = ql.SoNguoiChoi;
        Session["NguoiChoiThu"] = NguoiChoiThu;
        NGUOICHOI nc = new NGUOICHOI();
        nc.Username = Login1.UserName;
        ql.arrNguoiChoi.Add(nc);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        QUANLY ql = (QUANLY)Application["QUANLY"];
        ql.SoNguoiXem++;
        Session["NguoiChoiThu"] = -1; // Khach        
        Response.Redirect("~/CuaSoChinh.htm");

    }
}
