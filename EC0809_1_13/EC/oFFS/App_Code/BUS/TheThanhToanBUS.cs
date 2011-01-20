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
    TheThanhToanDAO theDAO = new TheThanhToanDAO();
    public bool CapNhatTheThanhToan(TheThanhToanDTO tttDto)
    {

        return theDAO.CapNhatTheThanhToan(tttDto);
    }
    
}
