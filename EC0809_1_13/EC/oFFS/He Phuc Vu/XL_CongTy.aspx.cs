using System;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class He_Phuc_Vu_XL_CongTy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Xac_nhan"] == "Thong_Tin_Cong_Ty")
            Thong_Tin_Cong_Ty();
        if (Request["Xac_nhan"] == "Cap_Nhat_Thong_Tin")
            Cap_Nhat_Thong_Tin();
        if (Request["Xac_nhan"] == "Kiem_Tra_Du_Lieu_Nhap")
            Kiem_Tra_Du_Lieu_Nhap();
    }

    private void Thong_Tin_Cong_Ty()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Cong_ty = null;

        Tai_lieu.Load(Server.MapPath("CONG_TY.xml"));
        Cong_ty = Tai_lieu.DocumentElement;


        XL_THE Kq = new XL_THE("CONG_TY");
        

        XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ten_cong_ty", Cong_ty.GetAttribute("Ten_cong_ty"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Dien_thoai", Cong_ty.GetAttribute("Dien_thoai"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Dien_thoai_admin", Cong_ty.GetAttribute("Dien_thoai_admin"));        
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Dia_chi", Cong_ty.GetAttribute("Dia_chi"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Logo", Cong_ty.GetAttribute("Logo"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Banner", Cong_ty.GetAttribute("Banner"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
        Thuoc_tinh = new XL_THUOC_TINH("Mo_ta", Cong_ty.GetAttribute("Mo_ta"));
        Kq.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Cap_Nhat_Thong_Tin()
    {
        XmlDocument Tai_lieu = new XmlDocument();
        XmlElement Cong_ty = null;

        Tai_lieu.Load(Server.MapPath("CONG_TY.xml"));
        Cong_ty = Tai_lieu.DocumentElement;

        Cong_ty.SetAttribute("Ten_cong_ty", Request["Ten_cong_ty"]);
        Cong_ty.SetAttribute("Dia_chi", Request["Dia_chi"]);
        Cong_ty.SetAttribute("Dien_thoai", Request["Dien_thoai"]);
        Cong_ty.SetAttribute("Dien_thoai_admin", Request["Dien_thoai_admin"]);
        if (Request["Logo"] != null)
            Cong_ty.SetAttribute("Logo", Request["Logo"]);
        if (Request["Banner"] != null)
            Cong_ty.SetAttribute("Banner", Request["Banner"]);
        Cong_ty.SetAttribute("Mo_ta", Request["Mo_ta"]);

        Tai_lieu.Save(Server.MapPath("CONG_TY.xml"));
        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }

    private void Kiem_Tra_Du_Lieu_Nhap()
    {
        String data = Request["Du_lieu_nhap"].ToString();

        for (int i = 0; i < data.Length; i++)
            if (Char.IsNumber(data[i]) == false)
                return;

        XL_THE Kq = new XL_THE("Goc");
        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
