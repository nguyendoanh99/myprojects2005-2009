using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// Summary description for MonAnBUS
/// </summary>
public class MonAnBUS
{
    public int ThemMonAn(oFFS_DAL_WS.MonAnDTO monan, String strTag)
    {
        int Kq = 0;
        try
        {
            oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
            Kq = service.ThemMonAn(monan, strTag);
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return Kq;
    }

    public oFFS_DAL_WS.MonAnDTO[] DanhSachMonAn()
    {
        try
        {
            oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
            return service.DanhSachMonAn();
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        return null;
    }
}
