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
/// Summary description for TheHienThucDonDTO
/// </summary>
public class TheHienThucDonDTO
{
	#region "Attributes"
    private int _ma_the_hien;    
    private int _ma_thuc_don;
    private Boolean _trang_thai_hien_thi;    
    private Boolean _tinh_trang;

    #endregion

    #region "Properties"
    public int Ma_the_hien
    {
        get { return _ma_the_hien; }
        set { _ma_the_hien = value; }
    }
    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }
    public Boolean Trang_thai_hien_thi
    {
        get { return _trang_thai_hien_thi; }
        set { _trang_thai_hien_thi = value; }
    }
    public Boolean Tinh_trang
    {
        get { return _tinh_trang; }
        set { _tinh_trang = value; }
    }
    #endregion

    #region "Constructor"
    public TheHienThucDonDTO()
	{
        Ma_the_hien = -1;
        Ma_thuc_don = -1;
        Trang_thai_hien_thi = false;
        Tinh_trang = false;
    }
    #endregion
}
