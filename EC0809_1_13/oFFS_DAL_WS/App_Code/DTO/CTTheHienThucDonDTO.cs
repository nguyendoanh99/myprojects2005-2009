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
/// Summary description for CTTheHienThucDonDTO
/// </summary>
public class CTTheHienThucDonDTO
{
    #region "Attributes"
    private int _ma_ct_the_hien;   
    private int _ma_the_hien;
    private int _ma_ct_thuc_don_loai_mon;
    private int _ma_mon;    
    #endregion

    #region "Properties"
    public int Ma_ct_the_hien
    {
        get { return _ma_ct_the_hien; }
        set { _ma_ct_the_hien = value; }
    }
    public int Ma_the_hien
    {
        get { return _ma_the_hien; }
        set { _ma_the_hien = value; }
    }
    public int Ma_ct_thuc_don_loai_mon
    {
        get { return _ma_ct_thuc_don_loai_mon; }
        set { _ma_ct_thuc_don_loai_mon = value; }
    }
    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }
    #endregion

    #region "Constructor"
    public CTTheHienThucDonDTO()
	{
        Ma_ct_the_hien = -1;   
        Ma_the_hien = -1;
        Ma_ct_thuc_don_loai_mon = -1;
        Ma_mon = -1;
    }
    #endregion
}
