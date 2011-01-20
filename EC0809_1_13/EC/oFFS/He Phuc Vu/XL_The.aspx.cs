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

public partial class He_Phuc_Vu_XL_The : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string xacnhan = Request["Xac_nhan"].ToString();

        if (xacnhan == "KiemTraTheTonTai")
        {
            KiemTraTheTonTai();
        }
    }

    protected void KiemTraTheTonTai()
    {
        string tenloaithe = XL_CHUOI.Nhap(Request, "tenloaithe").ToString();

        string sothe = XL_CHUOI.Nhap(Request, "sothe");
        DateTime ngayhethan = DateTime.Parse(XL_CHUOI.Nhap(Request, "ngayhethan").ToString());

        WS_CardSystem.CardDTO cardDto = new WS_CardSystem.CardDTO();
        cardDto.Code = sothe;
        cardDto.Expried_date = ngayhethan;
        cardDto.Type = tenloaithe;

        WS_CardSystem.Service ws = new WS_CardSystem.Service();

        XL_THE Kq = new XL_THE("goc");
        bool kt = ws.KiemTraHopLe(cardDto);
        if (kt)
        {
            Kq.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "true"));
        }
        else
            Kq.Danh_sach_thuoc_tinh.Add(new XL_THUOC_TINH("kq", "false"));
        
        XL_CHUOI.XuatChuoi(Response, Kq.Chuoi());
    }
}
