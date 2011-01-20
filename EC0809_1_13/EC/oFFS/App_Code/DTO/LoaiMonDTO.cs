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
/// Summary description for LoaiMonDTO
/// </summary>
public class LoaiMonDTO
{
    #region "Attributes"
    private int _ma_loai_mon;    
    private string _ten_loai_mon;
    private int _ma_loai_mon_cha;    
    private Boolean _la_loai_mon_la;

    #endregion

    #region "Properties"
    public int Ma_loai_mon
    {
        get { return _ma_loai_mon; }
        set { _ma_loai_mon = value; }
    }
    public string Ten_loai_mon
    {
        get { return _ten_loai_mon; }
        set { _ten_loai_mon = value; }
    }
    public int Ma_loai_mon_cha
    {
        get { return _ma_loai_mon_cha; }
        set { _ma_loai_mon_cha = value; }
    }
    public Boolean La_loai_mon_la
    {
        get { return _la_loai_mon_la; }
        set { _la_loai_mon_la = value; }
    }
    #endregion

    #region "Constructor"
    public LoaiMonDTO()
	{
        Ma_loai_mon = -1;    
        Ten_loai_mon = "";
        Ma_loai_mon_cha = -1;
        La_loai_mon_la = false;
    }
    #endregion
}
