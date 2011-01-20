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
/// Summary description for CTDonHangDTO
/// </summary>
public class CTDonHangDTO
{
    #region "Attributes"
    private int _ma_ct_don_hang;   
    private int _ma_don_hang;
    private int _ma_item;
    private Boolean _loai_item;
    private int _so_luong;
    private Double _thanh_tien;    
    #endregion

    #region "Properties"
    public int Ma_ct_don_hang
    {
        get { return _ma_ct_don_hang; }
        set { _ma_ct_don_hang = value; }
    }
    public int Ma_don_hang
    {
        get { return _ma_don_hang; }
        set { _ma_don_hang = value; }
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
    public int So_luong
    {
        get { return _so_luong; }
        set { _so_luong = value; }
    }
    public Double Thanh_tien
    {
        get { return _thanh_tien; }
        set { _thanh_tien = value; }
    }
    #endregion

    #region "Constructor"
    public CTDonHangDTO()
	{
        Ma_ct_don_hang = -1;   
        Ma_don_hang = -1;
        Ma_item = -1;
        Loai_item = false;
        So_luong = 0;
        Thanh_tien = 0; 
    }
    #endregion
}
