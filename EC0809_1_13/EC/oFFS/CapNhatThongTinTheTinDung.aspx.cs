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

public partial class CapNhatTheTinDung : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }

        //Hiển thị thông tin của khách hàng hiện tại
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];

        //Load loại thẻ
        LoaiTheDTO[] dsLoaiThe = (new LoaiTheBUS()).LayDanhSachLoaiThe();
        for (int i = 0; i < dsLoaiThe.Length; ++i)
        {
            cmbLoaiThe.Items.Add(dsLoaiThe[i].Ten_loai_the);
            cmbLoaiThe.Items[i].Value = (dsLoaiThe[i]).Ma_loai_the.ToString();
        }
        cmbLoaiThe.SelectedValue = vkhDto.Ma_loai_the.ToString();
        vkhDto.Ten_loai_the = cmbLoaiThe.SelectedItem.Text;

        //Load số thẻ
        //txtSoThe.Value = vkhDto.So_the;
        txtSoThe.Value = "";

        //Load ngày hết hạn
        for (int i = 1; i <= 31; ++i)
            cmbNgayHH.Items.Add(i.ToString());
        cmbNgayHH.SelectedValue = vkhDto.Ngay_het_han.Day.ToString();

        for (int i = 1; i <= 12; ++i)
        {
            cmbThangHH.Items.Add("Tháng " + i);
            cmbThangHH.Items[i - 1].Value = i.ToString();
        }
        cmbThangHH.SelectedValue = vkhDto.Ngay_het_han.Month.ToString();

        for (int i = 2008; i <= 2020; ++i)
            cmbNamHH.Items.Add(i.ToString());
        cmbNamHH.SelectedValue = vkhDto.Ngay_het_han.Year.ToString();
    }

    protected void but_Thoat_Click(object sender, EventArgs e)
    {
        Response.Redirect("ThongTinCaNhan.aspx");
    }
}
