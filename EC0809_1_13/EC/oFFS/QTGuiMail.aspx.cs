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

public partial class QTGuiMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "GuiMail")
        {
            GuiMail();
            return;
        }
    }
    private void GuiMail()
    {
        string Username = (string)Request["Username"];
        string subject = (string)Request["subject"];
        string body = (string)Request["msgpost"];

        NguoiDungBUS ndBus = new NguoiDungBUS();
        NguoiDungDTO dto = ndBus.LayThongTinNguoiDung(Username);

        bool flag = Utilities.SendMail("ec0809.1.13@gmail.com", dto.Email, subject, body) == "";
        NoiDungEmailDTO ndedto = new NoiDungEmailDTO();
        NoiDungEmailBUS bus = new NoiDungEmailBUS();

        ndedto.TieuDe = subject;
        ndedto.NoiDung = body;
        ndedto.Email = dto.Email;
        ndedto.NgayGui = DateTime.Now;
        ndedto.Username = Username;

        bool kq = bus.ThemNoiDungEmail(ndedto);

//         XL_THE the = new XL_THE("goc");
//         XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
//         the.Danh_sach_thuoc_tinh.Add(thuoctinh);
//         string chuoi = the.Chuoi();
        string str = flag && kq ? "Gửi mail thành công" : "Không thực hiện được do lỗi server";
        Response.Write("<script type=\"text/javascript\"> alert('" + str + "'); </script>");
    }
}
