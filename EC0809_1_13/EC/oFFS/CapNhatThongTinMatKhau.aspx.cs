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

public partial class CapNhatMatKhau : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
    }
    /*
    protected void but_Luu_Click(object sender, EventArgs e)
    {
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
       
        if (txt_MatKhauHT.Value != vkhDto.Password)
        {
            Thong_Bao("Mật khẩu hiện tại không đúng!");
            return;
        }
        if (txt_MatKhauM.Value != txt_MatKhauMNL.Value)
        {
            Thong_Bao("Nhập lại mật khẩu xác nhận!");
            return;
        }

        //Cập nhật
        string Password = txt_MatKhauM.Value;
        int Ma_nguoi_dung = vkhDto.Ma_nguoi_dung;

        NguoiDungBUS ndBus = new NguoiDungBUS();
        bool kq = ndBus.CapNhatTongTinMatKhau(Password, Ma_nguoi_dung);
        if (kq == true)
        {
            vkhDto.Password = Password;
            Session["khachhang"] = vkhDto;   //Lưu thông tin cho biến trong session
            Thong_Bao("Cập nhật thành công!");
        }
        else
            Thong_Bao("Cập nhật bị lỗi!");

    }

    */

}
