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
/// Summary description for ThucDonDTO
/// </summary>
public class ThucDonDTO
{
	#region "Attributes"
    private int _ma_thuc_don;    
    private string _ten_thuc_don;
    private int _ma_loai_thuc_don;
    private string _mo_ta;
    private string _hinh_anh_minh_hoa;
    private decimal _gia;
    private int _diem_binh_chon;
    private bool _trang_thai_hien_thi;
    private bool _tinh_trang;  
    
    #endregion

    #region "Properties"
    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }
    public string Ten_thuc_don
    {
        get { return _ten_thuc_don; }
        set { _ten_thuc_don = value; }
    }
    public int Ma_loai_thuc_don
    {
        get { return _ma_loai_thuc_don; }
        set { _ma_loai_thuc_don = value; }
    }
    public string Mo_ta
    {
        get { return _mo_ta; }
        set { _mo_ta = value; }
    }
    public string Hinh_anh_minh_hoa
    {
        get { return _hinh_anh_minh_hoa; }
        set { _hinh_anh_minh_hoa = value; }
    }
    public decimal Gia
    {
        get { return _gia; }
        set { _gia = value; }
    }
    public int Diem_binh_chon
    {
        get { return _diem_binh_chon; }
        set { _diem_binh_chon = value; }
    }
    public bool Trang_thai_hien_thi
    {
        get { return _trang_thai_hien_thi; }
        set { _trang_thai_hien_thi = value; }
    }
    public bool Tinh_trang
    {
        get { return _tinh_trang; }
        set { _tinh_trang = value; }
    }
    #endregion

    #region "Constructor"
    public ThucDonDTO()
	{
        Ma_thuc_don = -1;
        Ten_thuc_don = "";
        Ma_loai_thuc_don = -1;
        Mo_ta = "";
        Hinh_anh_minh_hoa = "";
        Gia = 0;
        Diem_binh_chon = 0;
        Trang_thai_hien_thi = true;
        Tinh_trang = true;
    }
    #endregion
}
