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
/// Summary description for DonHangDTO
/// </summary>
public class DonHangDTO
{
    #region "Attributes"
    private int _ma_don_hang;    
    private int _ma_khach_hang;
    private DateTime _ngay_lap;
    private string _dia_chi_nhan;
    private string _nguoi_nhan;
    private DateTime _ngay_giao_hang;
    private int _loai_don_dat_hang;
    private int _hinh_thuc_khuyen_mai;
    private decimal _tien_khuyen_mai;
    private decimal _gia_tri;
    private int _ma_hinh_thuc_than_toan;
    private bool _da_dat_hang;
    private bool _da_thanh_toan;
    private bool _da_giao_hang;
    private decimal _tien_thue;
    #endregion

    #region "Properties"
    public int Ma_don_hang
    {
        get { return _ma_don_hang; }
        set { _ma_don_hang = value; }
    }
    public int Ma_khach_hang
    {
        get { return _ma_khach_hang; }
        set { _ma_khach_hang = value; }
    }
    public DateTime Ngay_gio_lap
    {
        get { return _ngay_lap; }
        set { _ngay_lap = value; }
    }
    public string Dia_chi_nhan
    {
        get { return _dia_chi_nhan; }
        set { _dia_chi_nhan = value; }
    }
    public string Nguoi_nhan
    {
        get { return _nguoi_nhan; }
        set { _nguoi_nhan = value; }
    }
    public DateTime Ngay_gio_giao_hang
    {
        get { return _ngay_giao_hang; }
        set { _ngay_giao_hang = value; }
    }
    public int Loai_don_dat_hang
    {
        get { return _loai_don_dat_hang; }
        set { _loai_don_dat_hang = value; }
    }
    public int Hinh_thuc_khuyen_mai
    {
        get { return _hinh_thuc_khuyen_mai; }
        set { _hinh_thuc_khuyen_mai = value; }
    }
    public decimal Tien_khuyen_mai
    {
        get { return _tien_khuyen_mai; }
        set { _tien_khuyen_mai = value; }
    }
    public decimal Gia_tri
    {
        get { return _gia_tri; }
        set { _gia_tri = value; }
    }
    public int Ma_hinh_thuc_thanh_toan
    {
        get { return _ma_hinh_thuc_than_toan; }
        set { _ma_hinh_thuc_than_toan = value; }
    }
    public bool Da_dat_hang
    {
        get { return _da_dat_hang; }
        set { _da_dat_hang = value; }
    }

    public bool Da_thanh_toan
    {
        get { return _da_thanh_toan; }
        set { _da_thanh_toan = value; }
    }

    public bool Da_giao_hang
    {
        get { return _da_giao_hang; }
        set { _da_giao_hang = value; }
    }

    public decimal Tien_thue
    {
        get { return _tien_thue; }
        set { _tien_thue = value; }
    }
    #endregion

    #region"Constructor"
    public DonHangDTO()
	{
        Ma_don_hang = -1;
        Ma_khach_hang = -1;
        Ngay_gio_lap = DateTime.Parse("1/1/1900");
        Dia_chi_nhan = "";
        Nguoi_nhan = "";
        Ngay_gio_giao_hang = DateTime.Parse("1/1/1900");
        Loai_don_dat_hang = -1;
        Hinh_thuc_khuyen_mai = -1;
        Tien_khuyen_mai = 0;
        Gia_tri = 0;
        Ma_hinh_thuc_thanh_toan = -1;
        Da_dat_hang = false;
        Da_giao_hang = false;
        Da_thanh_toan = false;
        Tien_thue = 0;
    }
    #endregion
}
