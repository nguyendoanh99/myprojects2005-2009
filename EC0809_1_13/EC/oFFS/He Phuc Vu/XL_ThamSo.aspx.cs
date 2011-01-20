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

public partial class He_Phuc_Vu_XL_ThamSo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["xac_nhan"] == "LayTiLeGiamGiaThucDon")
        {
            LayTiLeGiamGiaThucDon();
        }
    }

    protected void LayTiLeGiamGiaThucDon()
    {
        ThamSoBUS bus = new ThamSoBUS();
        ThamSoDTO dto = bus.LayThamSo();

        XL_THE Kq = new XL_THE("THAM_SO");
        Kq.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("TiLeGiam", dto.TiLeGiamGiaThucDon.ToString()));
      
        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }
}
