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

public partial class NhanNoiDung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int SoCauDaChat = (int)Application["SoCauDaChat"];
        String NoiDung;
        NoiDung = XL_CHUOI.Nhap(Request, "NoiDung");
        
        if (NoiDung != null)
        {
            String HoTen = (String) Session["HoTen"];
            int SoNguoi = (int)Application["SoNguoiDung"];
            Application.Lock();
            ArrayList lst = (ArrayList) Application["DanhSachNoiDung"];
            NoiDungChat nd = new NoiDungChat(NoiDung, HoTen, SoNguoi);
            lst.Add(nd);
            SoCauDaChat++;
            Application["SoCauDaChat"] = SoCauDaChat;
            Application.UnLock();
        }
    }
}
