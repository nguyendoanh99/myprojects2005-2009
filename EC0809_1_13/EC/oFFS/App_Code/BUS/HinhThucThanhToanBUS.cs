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
/// Summary description for HinhThucThanhToanBUS
/// </summary>
public class HinhThucThanhToanBUS
{
	public HinhThucThanhToanBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    HinhThucThanhToanDAO htttDao = new HinhThucThanhToanDAO();
    public HinhThucThanhToanDTO[] LayDanhSachHTTT()
    {
        return htttDao.LayDanhSachHTTT();
    }
}
