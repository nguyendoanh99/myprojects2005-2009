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
/// Summary description for LoaiThucDonDTO
/// </summary>
public class LoaiThucDonDTO
{
	#region "Attributes"
    private int _ma_loai_thuc_don;    
    private string _ten_loai_thuc_don;
    #endregion

    #region "Properties"
    public int Ma_loai_thuc_don
    {
        get { return _ma_loai_thuc_don; }
        set { _ma_loai_thuc_don = value; }
    }
    public string Ten_loai_thuc_don
    {
        get { return _ten_loai_thuc_don; }
        set { _ten_loai_thuc_don = value; }
    }
    #endregion

    #region "Constructor"
    public LoaiThucDonDTO()
	{
        _ma_loai_thuc_don = -1;
        _ten_loai_thuc_don = "";
    }
    #endregion
}
