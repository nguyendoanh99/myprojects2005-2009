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
    private int _ma_hinh_thuc_khuyen_mai;    
    private string _ten_hinh_thuc_khuyen_mai;
    #endregion

    #region "Properties"
    public int Ma_hinh_thuc_khuyen_mai
    {
        get { return _ma_hinh_thuc_khuyen_mai; }
        set { _ma_hinh_thuc_khuyen_mai = value; }
    }
    public string Ten_hinh_thuc_khuyen_mai
    {
        get { return _ten_hinh_thuc_khuyen_mai; }
        set { _ten_hinh_thuc_khuyen_mai = value; }
    }
    #endregion

    #region "Constructor"
    public HinhThucKhuyenMaiDTO()
	{
        Ma_hinh_thuc_khuyen_mai = -1;
        Ten_hinh_thuc_khuyen_mai = "";
    }
    #endregion
}
