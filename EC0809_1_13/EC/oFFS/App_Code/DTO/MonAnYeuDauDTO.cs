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
/// Summary description for MonAnYeuDauDTO
/// </summary>
public class MonAnYeuDauDTO
{
	#region "Attributes"
    private int _ma_mon_yeu_dau;   
    private int _ma_khach_hang;
    private int _ma_mon;

    #endregion

    #region "Properties"
    public int Ma_mon_yeu_dau
    {
        get { return _ma_mon_yeu_dau; }
        set { _ma_mon_yeu_dau = value; }
    }
    public int Ma_khach_hang
    {
        get { return _ma_khach_hang; }
        set { _ma_khach_hang = value; }
    }
    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }
    #endregion
    #region "Properties"
    public MonAnYeuDauDTO()
	{
        Ma_mon_yeu_dau = -1;
        Ma_khach_hang = -1;
        Ma_mon = -1;
    }
    #endregion
}
