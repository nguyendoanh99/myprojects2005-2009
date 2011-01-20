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
/// Summary description for CTThucDon
/// </summary>
public class CTThucDonDTO
{
	 #region "Attributes"
    private int _ma_ct_thuc;   
    private int _ma_thuc_don;
    private int _ma_mon;

    #endregion

    #region "Properties"
    public int Ma_ct_thuc
    {
        get { return _ma_ct_thuc; }
        set { _ma_ct_thuc = value; }
    }
    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }
    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }
    #endregion
    #region "Properties"
    public CTThucDonDTO()
	{
        Ma_ct_thuc = -1;
        Ma_thuc_don = -1;
        Ma_mon = -1;
    }
    #endregion
}
