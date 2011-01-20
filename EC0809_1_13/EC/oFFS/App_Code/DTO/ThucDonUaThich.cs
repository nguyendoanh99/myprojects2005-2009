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
/// Summary description for ThucDonUaThich
/// </summary>
public class ThucDonUaThich
{
	#region "Attributes"
    private int _ma_thuc_don_yeu_dau;   
    private int _ma_khach_hang;
    private int _ma_thuc_don;

    #endregion

    #region "Properties"
    public int Ma_thuc_don_yeu_dau
    {
        get { return _ma_thuc_don_yeu_dau; }
        set { _ma_thuc_don_yeu_dau = value; }
    }
    public int Ma_khach_hang
    {
        get { return _ma_khach_hang; }
        set { _ma_khach_hang = value; }
    }
    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }
    #endregion
    #region "Properties"
    public ThucDonUaThich()
	{
        Ma_thuc_don_yeu_dau = -1;
        Ma_khach_hang = -1;
        Ma_thuc_don = -1;
    }
    #endregion
}
