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

public partial class He_Phuc_Vu_XL_HTKM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayDSHTKM")
            LayDSHTKM();
    }
    HinhThucKhuyenMaiBUS htkmBus = new HinhThucKhuyenMaiBUS();
    protected void LayDSHTKM()
    {
        HinhThucKhuyenMaiDTO[] DsHTKM = htkmBus.LayDanhSachHTKM();

        
        XL_THE Kq = new XL_THE("DANH_SACH");

        for (int i = 0; i < DsHTKM.Length; i++)
        {
            XL_THE Kq1 = new XL_THE("HinhThucKhuyenMai");
            HinhThucKhuyenMaiDTO htkm = DsHTKM[i];

            XL_THUOC_TINH Thuoc_tinh = new XL_THUOC_TINH("MaHinhThucKhuyenMai", htkm.Ma_hinh_thuc_khuyen_mai.ToString());
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);
            Thuoc_tinh = new XL_THUOC_TINH("TenHinhThucKhuyenMai", htkm.Ten_hinh_thuc_khuyen_mai);
            Kq1.Danh_sach_thuoc_tinh.Add(Thuoc_tinh);

            Kq.Danh_sach_the.Add(Kq1);
        }

        XL_CHUOI.XuatXML(Response, Kq.Chuoi());
    }
}
