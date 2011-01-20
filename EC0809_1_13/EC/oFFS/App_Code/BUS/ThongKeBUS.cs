using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

/// <summary>
/// Summary description for ThongKeBUS
/// </summary>
public class ThongKeBUS
{
    ThongKeDAO tk = new ThongKeDAO();

    public ArrayList ThongKeDoanhThu(String loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        return tk.ThongKeDoanhThu(loaithongke, ngaybatdau, ngayketthuc);
    }

    public ArrayList ThongKeMonAn(int mamon, string loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        return tk.ThongKeMonAn(mamon, loaithongke, ngaybatdau, ngayketthuc);
    }

    public ArrayList ThongKeThucDon(int mathucdon, string loaithongke, DateTime ngaybatdau, DateTime ngayketthuc)
    {
        return tk.ThongKeThucDon(mathucdon, loaithongke, ngaybatdau, ngayketthuc);
    }


   
    
}
