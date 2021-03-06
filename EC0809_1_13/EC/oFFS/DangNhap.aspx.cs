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

public partial class DangNhap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        string username = txtAcc.Text;
        string password = hiddenPass.Value;

        NguoiDungDTO nguoidungdto = ((new NguoiDungBUS()).KiemTraAccount(username, password));

        if (nguoidungdto == null)
        {
            DisplayMessage("Tài khoản không tồn tại");
            return;
        }
        else if (nguoidungdto.Tinh_trang_kich_hoat != true)
        {
            DisplayMessage("Tài khoản đã bị khóa");
            return;
        }
        else
            DisplayMessage("Đăng nhập thành công dưới quyền " + nguoidungdto.LoaiNguoiDung()); //for test

        Session["MaNguoiDung"] = nguoidungdto.Ma_nguoi_dung;
        Session["User"] = nguoidungdto.Username;
        Session["LoaiNguoiDung"] = nguoidungdto.LoaiNguoiDung();

        if (nguoidungdto.LoaiNguoiDung() == "KhachHang")
        {
            Session["Gio_hang"] = null;
            Session["Item_online"] = null;
            Session["Gio_qua_tang"] = null;

            Response.Redirect("TrangChu.aspx");
            
        }
        else if (nguoidungdto.LoaiNguoiDung() == "NhanVien")
        {
            Response.Redirect("ThemMonMoi.aspx");
        }
        else if (nguoidungdto.LoaiNguoiDung() == "QuanLy")
        {
            // Redirect trang chu phan he quan ly
            Response.Redirect("ThongKeDoanhThu.aspx");
        }
        else if (nguoidungdto.LoaiNguoiDung() == "QuanTri")
        {
            // Redirect trang chu phan he quan tri
            Response.Redirect("QTQuanLyTaiKhoanNguoiDung.aspx");
        }
        
        
    }

    
    private void DisplayMessage(String message)
    {
        ltlAlert.Text = "alert('" + message + "');";
    }
}
