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

public partial class LayNoiDung : System.Web.UI.Page
{
    // Loai bo nhung cau da duoc lay ra khoi ArrayList
    private void DonDep()
    {
        ArrayList lst = (ArrayList)Application["DanhSachNoiDung"];
        int CauLuuTruHienTai = (int)Application["CauLuuTruHienTai"];
        for (int i = lst.Count - 1; i >= 0; --i)
        {
            NoiDungChat temp = (NoiDungChat)lst[i];
            if (temp.SoLanLay >= temp.SoNguoiDungHienTai)
            {
                lst.RemoveAt(i);
                CauLuuTruHienTai++;
            }
        }
        Application["CauLuuTruHienTai"] = CauLuuTruHienTai;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Application.Lock();
        QUANLY ql = (QUANLY)Application["QUANLY"];
        ArrayList lst = (ArrayList) Application["DanhSachNoiDung"];
        int SoNguoi = ql.SoNguoiChoi + ql.SoNguoiXem;
        int CauLuuTruHienTai = (int) Application["CauLuuTruHienTai"];
        int SoCauDaChat = (int)Application["SoCauDaChat"];
        int SoCauDaLay = (int)Session["SoCauDaLay"];

        XL_THE The = new XL_THE("Goc");
        for (int i = Math.Max(SoCauDaLay, CauLuuTruHienTai); i < SoCauDaChat; ++i )
        {
            NoiDungChat ndc = (NoiDungChat) lst[i - CauLuuTruHienTai];
            String NoiDung = ndc.NoiDung;
            String NguoiGui = ndc.TenNguoiGui;
            XL_THE TheCon = new XL_THE("Cau");
            XL_THUOC_TINH ThuocTinh = new XL_THUOC_TINH("NoiDung", NoiDung);
            TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
            ThuocTinh = new XL_THUOC_TINH("NguoiGui", NguoiGui);
            TheCon.Danh_sach_thuoc_tinh.Add(ThuocTinh);
            The.Danh_sach_the.Add(TheCon);
            
            ndc.SoLanLay++;
        }
        Session["SoCauDaLay"] = SoCauDaChat;
        DonDep();        
        String Chuoi = The.Chuoi();
        XL_CHUOI.Xuat(Response, Chuoi);
        Application.UnLock(); 
    }
}
