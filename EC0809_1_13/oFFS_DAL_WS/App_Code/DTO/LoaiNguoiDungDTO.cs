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
/// Summary description for QuyenDTO
/// </summary>
public class LoaiNguoiDungDTO
{
	#region "Attributes"
    private int _ma_loai_nguoi_dung;    
    private string _ten_loai_nguoi_dung;
    #endregion

    #region "Properties"
    public int Ma_loai_nguoi_dung
    {
        get { return _ma_loai_nguoi_dung; }
        set { _ma_loai_nguoi_dung = value; }
    }
    public string Ten_loai_nguoi_dung
    {
        get { return _ten_loai_nguoi_dung; }
        set { _ten_loai_nguoi_dung = value; }
    }
    #endregion

    #region "Constructor"
    public LoaiNguoiDungDTO()
	{
        Ma_loai_nguoi_dung = -1;
        Ten_loai_nguoi_dung = "";
    }
    #endregion
}
