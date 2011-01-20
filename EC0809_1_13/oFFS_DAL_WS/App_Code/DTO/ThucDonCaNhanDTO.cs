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
/// Summary description for ThucDonCaNhanDTO
/// </summary>
public class ThucDonCaNhanDTO
{
	#region "Attributes"
    private int _ma_thuc_don_ca_nhan;    
    private int _ma_khach_hang;
    #endregion

    #region "Properties"
    public int Ma_thuc_don_ca_nhan
    {
        get { return _ma_thuc_don_ca_nhan; }
        set { _ma_thuc_don_ca_nhan = value; }
    }
    public int Ma_khach_hang
    {
        get { return _ma_khach_hang; }
        set { _ma_khach_hang = value; }
    }
    #endregion

    #region "Constructor"
    public ThucDonCaNhanDTO()
	{
        Ma_thuc_don_ca_nhan = -1;
        Ma_khach_hang = -1;
    }
    #endregion
}
