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
/// Summary description for KhachHangDTO
/// </summary>
public class KhachHangDTO : NguoiDungDTO
{
	
	#region "Attributes"
    private int _ma_khach_hang;
    private int _ma_the;
    private int _diem_khuyen_mai;
    private int _diem_tich_luy;    

    #endregion

    #region "Properties"
    public int Ma_khach_hang
    {
        get { return _ma_khach_hang; }
        set { _ma_khach_hang = value; }
    }   
    public int Ma_the
    {
        get { return _ma_the; }
        set { _ma_the = value; }
    }
    public int Diem_khuyen_mai
    {
        get { return _diem_khuyen_mai; }
        set { _diem_khuyen_mai = value; }
    }
    public int Diem_tich_luy
    {
        get { return _diem_tich_luy; }
        set { _diem_tich_luy = value; }
    }
    #endregion
    #region"Constructor"
    public KhachHangDTO()
	{
        Ma_khach_hang = -1;
        Ma_the = -1;
        Diem_khuyen_mai = 0;
        Diem_tich_luy = 0;
    }

    public override string LoaiNguoiDung()
    {
        return "KhachHang";
    }
    #endregion
}
