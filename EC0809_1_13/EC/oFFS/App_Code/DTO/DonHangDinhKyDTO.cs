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
public class DonHangDinhKyDTO: DonHangDTO
{
    #region "Attributes"
    private int _ma_dh_dinh_ky;
    private string _loai_dinh_ky;
    private string _ngay_giao;
    private string _thu_giao;
    private DateTime _gio_giao;
    private DateTime _ngay_bat_dau;
    private DateTime _ngay_ket_thuc;
    private bool _tinh_trang;
    
    #endregion

    #region "Properties"
    public int Ma_don_hang_dinh_ky
    {
        get { return _ma_dh_dinh_ky; }
        set { _ma_dh_dinh_ky = value; }
    }
    public string Loai_dinh_ky
    {
        get { return _loai_dinh_ky; }
        set { _loai_dinh_ky = value; }
    }
    public string Ngay_giao
    {
        get { return _ngay_giao; }
        set { _ngay_giao = value; }
    }
    public string Thu_giao
    {
        get { return _thu_giao; }
        set { _thu_giao = value; }
    }
    public DateTime Gio_giao
    {
        get { return _gio_giao; }
        set { _gio_giao = value; }
    }
    public System.DateTime Ngay_bat_dau
    {
        get { return _ngay_bat_dau; }
        set { _ngay_bat_dau = value; }
    }
    public System.DateTime Ngay_ket_thuc
    {
        get { return _ngay_ket_thuc; }
        set { _ngay_ket_thuc = value; }
    }
    public bool Tinh_trang
    {
        get { return _tinh_trang; }
        set { _tinh_trang = value; }
    }
    #endregion

    #region "Constructor"
    public DonHangDinhKyDTO()
	{
        Ma_don_hang_dinh_ky = -1;
        Loai_dinh_ky = "";
        Ngay_giao = "";
        Thu_giao = "";
        Gio_giao = DateTime.Parse("1/1/1900");
        Ngay_bat_dau = DateTime.Parse("1/1/1900");
        Ngay_ket_thuc = DateTime.Parse("1/1/1900");
        Tinh_trang = false;
    }
    #endregion
}
