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

        //Hiển thị thông tin của khách hàng hiện tại
        NguoiDungDTO vkhDto = (NguoiDungDTO)Session["nguoidung"];
        //Load họ tên
        txtHoTen.Value = vkhDto.Ho_ten;

        //Load ngày
        for (int i = 1; i <= 31; ++i)
            cmbNgaySinh.Items.Add(i.ToString());
        cmbNgaySinh.SelectedValue = vkhDto.Ngay_sinh.Day.ToString();

        for (int i = 1; i <= 12; ++i)
        {
            cmbThangSinh.Items.Add("Tháng " + i);
            cmbThangSinh.Items[i - 1].Value = i.ToString();
        }
        cmbThangSinh.SelectedValue = vkhDto.Ngay_sinh.Month.ToString();

        for (int i = 1930; i <= 2000; ++i)
            cmbNamSinh.Items.Add(i.ToString());
        cmbNamSinh.SelectedValue = vkhDto.Ngay_sinh.Year.ToString();

        //Load giới tính
        optNam.Checked = false;
        optNu.Checked = false;

        if (vkhDto.Gioi_tinh == true)
            optNu.Checked = true;
        else
            optNam.Checked = true;

        //Load địa chỉ, điện thoại, email
        txtDiaChi.Value = vkhDto.Dia_chi;
        txtDienThoai.Value = vkhDto.Dien_thoai;
        txtEmail.Value = vkhDto.Email;
    }
}
