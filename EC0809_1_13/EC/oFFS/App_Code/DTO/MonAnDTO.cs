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
/// Summary description for MonAnDTO
/// </summary>
public class MonAnDTO
{
	#region "Attributes"
    private int _ma_mon;        
    private string _ten_mon;
    private string _hinh_anh_minh_hoa;
    private string _mo_ta;    
    private int _diem_binh_chon;
    private string _don_vi_tinh;
    private decimal _gia;
    private int _ma_loai_mon;
    private bool _tinh_trang;
    private bool _trang_thai_hien_thi;

    #endregion

    #region "Properties"
    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }
    public string Ten_mon
    {
        get { return _ten_mon; }
        set { _ten_mon = value; }
    }
    public string Hinh_anh_minh_hoa
    {
        get { return _hinh_anh_minh_hoa; }
        set { _hinh_anh_minh_hoa = value; }
    }

    public int Diem_binh_chon
    {
        get { return _diem_binh_chon; }
        set { _diem_binh_chon = value; }
    }
    public string Don_vi_tinh
    {
        get { return _don_vi_tinh; }
        set { _don_vi_tinh = value; }
    }

    public decimal Gia
    {
        get { return _gia; }
        set { _gia = value; }
    }
    public int Ma_loai_mon
    {
        get { return _ma_loai_mon; }
        set { _ma_loai_mon = value; }
    }
    public string Mo_ta
    {
        get { return _mo_ta; }
        set { _mo_ta = value; }
    }
    public bool Tinh_trang
    {
        get { return _tinh_trang; }
        set { _tinh_trang = value; }
    }
    public bool Trang_thai_hien_thi
    {
        get { return _trang_thai_hien_thi; }
        set { _trang_thai_hien_thi = value; }
    }

    #endregion

    #region"Constructor"
    public MonAnDTO()
	{
        Ma_mon = -1;
        Ten_mon = "";
        Hinh_anh_minh_hoa = "";
        Mo_ta = "";    
        Diem_binh_chon = 0;
        Don_vi_tinh = "";
        Gia = 0;
        Ma_loai_mon = -1;
        Tinh_trang = true;
        Trang_thai_hien_thi = true;
    }
    #endregion
}
