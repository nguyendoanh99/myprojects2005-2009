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

public partial class He_Phuc_Vu_XL_Tag : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayDanhSach")
            LayDanhSach();
        if (Request["xac_nhan"] == "Ghi_nhan_tag")
            Ghi_nhan_tag();
    }

    TagBUS tag = new TagBUS();

    protected void Ghi_nhan_tag()
    {
        Session["Tag"] = Request["Ma_tag"];
    }

    protected void LayDanhSach()
    {
        TagDTO[] ds = tag.LayDanhSachTag();

        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < ds.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("Tag");

            TagDTO dto = ds[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("Ma_tag", dto.Ma_tag.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Ten_tag", dto.Ten_tag);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("Do_uu_tien", dto.Do_uu_tien.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
