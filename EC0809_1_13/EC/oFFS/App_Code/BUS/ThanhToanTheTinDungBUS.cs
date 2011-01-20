using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ThanhToanTheTinDungBUS
/// </summary>
public class ThanhToanTheTinDungBUS
{
    public void ThemThanhToanTheTinDung(ThanhToanTheTinDungDTO thett)
    {
        (new ThanhToanTheTinDungDAO()).ThemThanhToanTheTinDung(thett);
    }

    public bool XoaThanhToanTheTinDung(int madonhang)
    {
        return (new ThanhToanTheTinDungDAO()).XoaThanhToanTheTinDung(madonhang);
    }
}
