using System;
using System.Text;
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
        if (Session["LoaiNguoiDung"] != "KhachHang")
        {
            Response.Redirect("ErrorPage.aspx");
        }

        //Hiển thị thông tin của khách hàng hiện tại
        viewKhachHangDTO vkhDto = (viewKhachHangDTO)Session["khachhang"];
        string username = (string)Session["User"];
        if (vkhDto == null)
        {
            KhachHangBUS khBus = new KhachHangBUS();
            vkhDto = khBus.LayThongTinKhachHang(username);
            Session["khachhang"] = vkhDto;
        }

        //Load diem KM
        lbDiemKM.Text = vkhDto.Diem_khuyen_mai.ToString();
       
        //Load thong tin the mặc định
        LoadThongTinThe(vkhDto);

        //Load thong tin ngưoi nhận mặc định
        LoadThongTinNguoiNhan(vkhDto);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "MyScript", GetJavaScript(), true);
    }

    private string GetJavaScript()
    {
        StringBuilder JavaScript = new StringBuilder();
        JavaScript.Append("XL_QUANG_CAO.LoadDsQuangCaoCuaWebsite('DatMuaSanPham_Customer');\n");
        return JavaScript.ToString();
    }

    private void LoadThongTinNguoiNhan(viewKhachHangDTO vkhDto)
    {
        txtNguoiNhan.Value = vkhDto.Ho_ten;

        txtDiaChiNhan.Value = vkhDto.Dia_chi;
    }

    private void LoadThongTinThe(viewKhachHangDTO vkhDto)
    {
       
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
   
        txtSoThe.Value = "[Mã số thẻ của bạn]";
        hiddenSoThe.Value = vkhDto.So_the;

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
   
}
