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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanLy" && Session["LoaiNguoiDung"] != "NhanVien")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }

        string username = (string)Session["User"];

        //Nếu khách hàng mới đăng nhập -> kết nối csdl lấy đầy đủ thông tin
        //Nếu không -> hiển thị thông tin hiện có trong session
        NguoiDungDTO ndDto = (NguoiDungDTO)Session["nguoidung"];
        if (ndDto == null)
        {
            NguoiDungBUS ndBus = new NguoiDungBUS();
            ndDto = ndBus.LayThongTinNguoiDung(username);
            Session["nguoidung"] = ndDto;
        }

        Hien_Thi_Thong_Tin_Ca_Nhan();
    }

    protected void Hien_Thi_Thong_Tin_Ca_Nhan()
    {
        NguoiDungDTO ndDto = (NguoiDungDTO)Session["nguoidung"];
        //refresh
        lb_HoTen.Text = "";
        lb_NgaySinh.Text = "";
        lb_GioiTinh.Text = "";
        lb_DiaChi.Text = "";
        lb_DienThoai.Text = "";
        lb_Email.Text = "";

        lb_TenDangNhap.Text = "";

        //show
        lb_HoTen.Text = ndDto.Ho_ten;
        lb_NgaySinh.Text = ndDto.Ngay_sinh.ToShortDateString();
        if (ndDto.Gioi_tinh == true)
            lb_GioiTinh.Text = "Nữ";
        else
            lb_GioiTinh.Text = "Nam";
        lb_DiaChi.Text = ndDto.Dia_chi.ToString();
        lb_DienThoai.Text = ndDto.Dien_thoai.ToString();
        lb_Email.Text = ndDto.Email.ToString();

        lb_TenDangNhap.Text = ndDto.Username.ToString();

    }
}
