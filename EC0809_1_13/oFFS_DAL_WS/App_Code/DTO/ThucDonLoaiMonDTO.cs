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
/// Summary description for ThucDonLoaiMonDTO
/// </summary>
public class ThucDonLoaiMonDTO
{
	#region "Attributes"
    private int _ma_ct_thuc_don_loai_mon;
    private int _ma_thuc_don;
    private int _ma_loai_mon;    
    #endregion

    #region "Properties"
    public int Ma_ct_thuc_don_loai_mon
    {
        get { return _ma_ct_thuc_don_loai_mon; }
        set { _ma_ct_thuc_don_loai_mon = value; }
    }
    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }
    public int Ma_loai_mon
    {
        get { return _ma_loai_mon; }
        set { _ma_loai_mon = value; }
    }
    #endregion

    #region "Constructor"
    public ThucDonLoaiMonDTO()
	{
        Ma_ct_thuc_don_loai_mon = -1;
        Ma_thuc_don = -1;
        Ma_loai_mon = -1;
    }
    #endregion
}
