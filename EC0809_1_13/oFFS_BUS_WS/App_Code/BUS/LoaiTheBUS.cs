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
/// Summary description for LoaiTheBUS
/// </summary>
public class LoaiTheBUS
{
    public oFFS_DAL_WS.LoaiTheDTO[] LayDanhSachLoaiThe()
    {
        oFFS_DAL_WS.WebService service = new oFFS_DAL_WS.WebService();
        return service.LayDanhSachLoaiThe();
    }
}
