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

public partial class He_Phuc_Vu_XL_HTTT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayDSHTTT")
            LayDSHTTT();
    }
    HinhThucThanhToanBUS htttBus = new HinhThucThanhToanBUS();
    protected void LayDSHTTT()
    {
        HinhThucThanhToanDTO[] DsHTTT = htttBus.LayDanhSachHTTT();


        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsHTTT.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("HinhThucThanhToan");
            HinhThucThanhToanDTO HTTT = DsHTTT[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaHinhThucThanhToan", HTTT.Mahinh_thuc_tt.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("TenHinhThucThanhToan", HTTT.Ten_hinh_thuc_tt);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
