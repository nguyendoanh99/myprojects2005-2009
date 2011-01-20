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
/// Summary description for DonHangDinhKyDTO
/// </summary>
public class DonHangDinhKyDTO
{
    #region "Attributes"
    private int _ma_dh_dinh_ky;
    private string _loai_dinh_ky;
    private int _ngay_giao;
    private int _thu_giao;
    private int _gio_giao;   
    #endregion

    #region "Properties"
    public int Ma_dh_dinh_ky
    {
        get { return _ma_dh_dinh_ky; }
        set { _ma_dh_dinh_ky = value; }
    }
    public string Loai_dinh_ky
    {
        get { return _loai_dinh_ky; }
        set { _loai_dinh_ky = value; }
    }
    public int Ngay_giao
    {
        get { return _ngay_giao; }
        set { _ngay_giao = value; }
    }
    public int Thu_giao
    {
        get { return _thu_giao; }
        set { _thu_giao = value; }
    }
    public int Gio_giao
    {
        get { return _gio_giao; }
        set { _gio_giao = value; }
    }
    #endregion

    #region "Constructor"
    public DonHangDinhKyDTO()
	{
        Ma_dh_dinh_ky = -1;
        Loai_dinh_ky = "";
        Ngay_giao = 0;
        Thu_giao = 0;
        Gio_giao = -1;
    }
    #endregion
}
