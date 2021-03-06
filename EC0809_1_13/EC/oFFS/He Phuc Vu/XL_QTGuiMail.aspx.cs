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

public partial class He_Phuc_Vu_XL_QTGuiMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoaiNguoiDung"] != "QuanTri")
        {
            Response.Redirect("ErrorPage.aspx");
            return;
        }
        string r = (string)Request["request"];
        if (r == "LayDanhSachNguoiDung")
        {
            LayDanhSachNguoiDung();
            return;
        }
        if (r == "GuiMail")
        {
            GuiMail();
            return;
        }
    }
    private void LayDanhSachNguoiDung()
    {
        // Xử lý request
        NguoiDungBUS bus = new NguoiDungBUS();
        int tongSoNguoiDung = bus.TongSoNguoiDung();
        int pageSize = tongSoNguoiDung;
        int pageNum = 1;
        NguoiDungDTO[] kq = bus.LayDanhSachNguoiDung(pageNum, pageSize);
        
        XL_THE ds = new XL_THE("DANH_SACH");

        foreach (NguoiDungDTO dto in kq)
        {
            XL_THE the = new XL_THE("TaiKhoan");

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Username", dto.Username);
            the.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            ds.Danh_sach_the.Add(the);
        }

        XL_CHUOI.XuatXML(Response, ds.Chuoi());
    }
    private void GuiMail()
    {
        string Username = (string)Request["Username"];
        string subject = (string)Request["subject"];
        string body = (string)Request["body"];

        NguoiDungBUS ndBus = new NguoiDungBUS();
        NguoiDungDTO dto = ndBus.LayThongTinNguoiDung(Username);
       
        //bool flag = Utilities.SendMail("ec0809.1.13@gmail.com", dto.Email, subject, body) == "";
        bool flag = true;
        XL_THE the = new XL_THE("goc");
        XL_THUOC_TINH thuoctinh = new XL_THUOC_TINH("kq", flag ? "1" : "0");
        the.Danh_sach_thuoc_tinh.Add(thuoctinh);
        string chuoi = the.Chuoi();
        XL_CHUOI.XuatChuoi(Response, chuoi);
    }
}
