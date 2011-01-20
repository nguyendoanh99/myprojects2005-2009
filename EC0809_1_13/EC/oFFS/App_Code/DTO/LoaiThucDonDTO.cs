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
    private int _ma_loai_thuc_don_cha;
    private bool _la_loai_thuc_don_la;    
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
    public int Ma_loai_thuc_don_cha
    {
        get { return _ma_loai_thuc_don_cha; }
        set { _ma_loai_thuc_don_cha = value; }
    }
    public bool La_loai_thuc_don_la
    {
        get { return _la_loai_thuc_don_la; }
        set { _la_loai_thuc_don_la = value; }
    }
    #endregion

    #region "Constructor"
    public LoaiThucDonDTO()
	{
        _ma_loai_thuc_don = -1;
        _ten_loai_thuc_don = "";
        Ma_loai_thuc_don_cha = -1;
        La_loai_thuc_don_la = false;
    }
    #endregion
}
