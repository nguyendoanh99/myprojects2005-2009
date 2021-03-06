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
/// Summary description for TheThanhToanDTO
/// </summary>
public class TheThanhToanDTO
{
	#region "Attributes"
    private int _ma_the;    
    private int _ma_loai_the;
    private DateTime _ngay_het_han;
    private string _so_the;
    #endregion

    #region "Properties"
    public int Ma_the
    {
        get { return _ma_the; }
        set { _ma_the = value; }
    }
    public int Ma_loai_the
    {
        get { return _ma_loai_the; }
        set { _ma_loai_the = value; }
    }
    public DateTime Ngay_het_han
    {
        get { return _ngay_het_han; }
        set { _ngay_het_han = value; }
    }
    public string So_the
    {
        get { return _so_the; }
        set { _so_the = value; }
    }
    
    #endregion

    #region"Constructor"
    public TheThanhToanDTO()
	{
        Ma_the = -1;
        Ma_loai_the = -1;
        Ngay_het_han = DateTime.Parse("1/1/1900");
        So_the = "";
    }
    #endregion
}
