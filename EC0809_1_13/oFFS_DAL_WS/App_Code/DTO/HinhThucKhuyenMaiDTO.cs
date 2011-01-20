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
/// Summary description for HinhThucKhuyenMaiDTO
/// </summary>
public class HinhThucKhuyenMaiDTO
{
    #region "Attributes"
    private int _ma_hinh_thuc_km;    
    private string _ten_hinh_thuc_km;
    #endregion

    #region "Properties"
    public int Mahinh_thuc_km
    {
        get { return _ma_hinh_thuc_km; }
        set { _ma_hinh_thuc_km = value; }
    }
    public string Ten_hinh_thuc_km
    {
        get { return _ten_hinh_thuc_km; }
        set { _ten_hinh_thuc_km = value; }
    }
    #endregion

    #region "Constructor"
    public HinhThucKhuyenMaiDTO()
	{
        Mahinh_thuc_km = -1;
        Ten_hinh_thuc_km = "";
    }
    #endregion
}
