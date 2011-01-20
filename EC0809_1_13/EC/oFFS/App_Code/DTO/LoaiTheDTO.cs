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
/// Summary description for LoaiTheDTO
/// </summary>
public class LoaiTheDTO
{
	#region "Attributes"
    private int _ma_loai_the;    
    private string _ten_loai_the;
    #endregion

    #region "Properties"
    public int Ma_loai_the
    {
        get { return _ma_loai_the; }
        set { _ma_loai_the = value; }
    }
    public string Ten_loai_the
    {
        get { return _ten_loai_the; }
        set { _ten_loai_the = value; }
    }
    #endregion

    #region "Constructor"
    public LoaiTheDTO()
	{
        Ma_loai_the = -1;
        Ten_loai_the = "";
    }
    #endregion
}
