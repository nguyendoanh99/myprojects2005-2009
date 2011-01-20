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
/// Summary description for TheThanhToanBUS
/// </summary>
public class TheThanhToanBUS
{
    public bool CapNhatTheThanhToan(oFFS_DAL_WS.TheThanhToanDTO tttDto)
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.CapNhatTheThanhToan(tttDto);
    }
    
}
