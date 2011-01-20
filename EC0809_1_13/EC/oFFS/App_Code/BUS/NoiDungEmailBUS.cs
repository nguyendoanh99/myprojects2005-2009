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
/// Summary description for NoiDungEmail
/// </summary>
public class NoiDungEmailBUS : AbstractBUS
{
    NoiDungEmailDAO ndeDAO = new NoiDungEmailDAO();
    public bool ThemNoiDungEmail(NoiDungEmailDTO dto)
    {
        return ndeDAO.ThemNoiDungEmail(dto);
    }
    public NoiDungEmailDTO[] LayDanhSach()
    {
        return ndeDAO.LayDanhSach();
    }
    public NoiDungEmailDTO LayNoiDungEmail(int ma)
    {
        return ndeDAO.LayNoiDungEmail(ma);
    }
}
