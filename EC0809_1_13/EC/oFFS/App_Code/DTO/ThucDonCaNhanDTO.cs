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
    //private bool _loai_thuc_don_ca_nhan; // 1 : ưa thích, 2 : tự tạo
    private string _ten_thuc_don;
    private string _hinh_anh;
    private decimal _gia;
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
    //public bool Loai_thuc_don_ca_nhan
    //{
    //    get { return _loai_thuc_don_ca_nhan; }
    //    set { _loai_thuc_don_ca_nhan = value; }
    //}
    public string Ten_thuc_don
    {
        get { return _ten_thuc_don; }
        set { _ten_thuc_don = value; }
    }
    public string Hinh_anh
    {
        get { return _hinh_anh; }
        set { _hinh_anh = value; }
    }
    public decimal Gia
    {
        get { return _gia; }
        set { _gia = value; }
    }
    #endregion

    #region "Constructor"
    public ThucDonCaNhanDTO()
	{
        Ma_thuc_don_ca_nhan = -1;
        Ma_khach_hang = -1;
        //Loai_thuc_don_ca_nhan = true;
        Ten_thuc_don = "";
        Hinh_anh = "";
        Gia = 0;
    }
    #endregion
}