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
/// Summary description for HinhThucThanhToanDTO
/// </summary>
public class HinhThucThanhToanDTO
{
	#region "Attributes"
    private int _ma_hinh_thuc_tt;    
    private string _ten_hinh_thuc_tt;
    #endregion

    #region "Properties"
    public int Mahinh_thuc_tt
    {
        get { return _ma_hinh_thuc_tt; }
        set { _ma_hinh_thuc_tt = value; }
    }
    public string Ten_hinh_thuc_tt
    {
        get { return _ten_hinh_thuc_tt; }
        set { _ten_hinh_thuc_tt = value; }
    }
    #endregion

    #region "Constructor"
    public HinhThucThanhToanDTO()
	{
        Mahinh_thuc_tt = -1;
        Ten_hinh_thuc_tt = "";
    }
    #endregion
}
