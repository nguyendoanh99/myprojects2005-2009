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
public class XL_ChiTietThucDonCaNhan
{
    #region "Attributes"
    private int _ma_ct_thuc_don_ca_nhan;   
    private int _ma_thuc_don_ca_nhan;
    private int _ma_item;
    private Boolean _loai_item;    
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
    public int Ma_item
    {
        get { return _ma_item; }
        set { _ma_item = value; }
    }
    public Boolean Loai_item
    {
        get { return _loai_item; }
        set { _loai_item = value; }
    }
    #endregion
    #region "Properties"
    public XL_ChiTietThucDonCaNhan()
	{
		Ma_ct_thuc_don_ca_nhan = -1;   
        Ma_thuc_don_ca_nhan = -1 ;
        Ma_item = -1;
        Loai_item = false;
    }
    #endregion
}
