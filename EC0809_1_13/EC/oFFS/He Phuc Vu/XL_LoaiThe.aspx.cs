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

public partial class XL_LoaiThe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request["xac_nhan"] == "LayDSLoaiThe")
        {
            LayDanhSachLoaiThe();
        }
    }

    protected void LayDanhSachLoaiThe()
    {
        LoaiTheBUS loaitheBUS = new LoaiTheBUS();
        LoaiTheDTO[] dsLoaiThe = loaitheBUS.LayDanhSachLoaiThe();

        XL_THE Kq = new XL_THE("dsLoaiThe");
        for (int i = 0; i < dsLoaiThe.Length; ++i)
        {
            XL_THE Kq1 = new XL_THE("LoaiThe");
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("MaLoaiThe", dsLoaiThe[i].Ma_loai_the.ToString()));
            Kq1.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TenLoaiThe", dsLoaiThe[i].Ten_loai_the));

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }

}
