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

public partial class XemThongTinCaNhan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }

        string username = (string)Session["User"];

        //Nếu khách hàng mới đăng nhập -> kết nối csdl lấy đầy đủ thông tin
        //Nếu không -> hiển thị thông tin hiện có trong session
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        if (vkhDto == null)
        {
            KhachHangBUS khBus = new KhachHangBUS();
            vkhDto = khBus.LayThongTinKhachHang(username);
            Session["khachhang"] = vkhDto;
        }

        Hien_Thi_Thong_Tin_Ca_Nhan();
        
    }

    protected void Hien_Thi_Thong_Tin_Ca_Nhan() 
    {
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        //refresh
        lb_HoTen.Text = "";
        lb_NgaySinh.Text = "";
        lb_GioiTinh.Text = "";
        lb_DiaChi.Text = "";
        lb_DienThoai.Text = "";
        lb_Email.Text = "";

        lb_TenDangNhap.Text = "";

        lb_LoaiThe.Text = "";
        lb_SoThe.Text = "";
        lb_NgayHetHan.Text = "";

        lb_DiemKhuyenMai.Text = "";

        //show
        lb_HoTen.Text = vkhDto.Ho_ten;
        lb_NgaySinh.Text = vkhDto.Ngay_sinh.ToShortDateString();
        if (vkhDto.Gioi_tinh == true)
            lb_GioiTinh.Text = "Nữ";
        else
            lb_GioiTinh.Text = "Nam";
        lb_DiaChi.Text = vkhDto.Dia_chi.ToString();
        lb_DienThoai.Text = vkhDto.Dien_thoai.ToString();
        lb_Email.Text = vkhDto.Email.ToString();

        lb_TenDangNhap.Text = vkhDto.Username.ToString();

        lb_LoaiThe.Text = vkhDto.Ten_loai_the.ToString();
        //lb_SoThe.Text = vkhDto.So_the;
        lb_SoThe.Text = "[Mã số thẻ của bạn]";
        lb_NgayHetHan.Text = vkhDto.Ngay_het_han.ToString();

        lb_DiemKhuyenMai.Text = vkhDto.Diem_khuyen_mai.ToString();    
         
    }
}
