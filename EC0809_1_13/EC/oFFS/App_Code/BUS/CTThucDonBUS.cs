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
/// Summary description for CTThucDonBUS
/// </summary>
public class CTThucDonBUS
{
    CTThucDonDAO dao = new CTThucDonDAO();
    public int ThemCTThucDon(CTThucDonDTO dto)
    {
        return dao.ThemCTThucDon(dto);
    }
}
