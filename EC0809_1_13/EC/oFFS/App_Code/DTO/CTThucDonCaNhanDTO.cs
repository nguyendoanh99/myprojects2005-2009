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
/// Summary description for XL_ChiTietThucDonCaNhan
/// </summary>
public class CTThucDonCaNhanDTO
{
    #region "Attributes"
    private int _ma_ct_thuc_don_ca_nhan;   
    private int _ma_thuc_don_ca_nhan;
    private int _ma_mon; 
    #endregion

    #region "Properties"
    public int Ma_ct_thuc_don_ca_nhan
    {
        get { return _ma_ct_thuc_don_ca_nhan; }
        set { _ma_ct_thuc_don_ca_nhan = value; }
    }
    public int Ma_thuc_don_ca_nhan
    {
        get { return _ma_thuc_don_ca_nhan; }
        set { _ma_thuc_don_ca_nhan = value; }
    }
    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }
    #endregion
    #region "Properties"
    public CTThucDonCaNhanDTO()
	{
		Ma_ct_thuc_don_ca_nhan = -1;   
        Ma_thuc_don_ca_nhan = -1 ;
        Ma_mon = -1;
    }
    #endregion
}
