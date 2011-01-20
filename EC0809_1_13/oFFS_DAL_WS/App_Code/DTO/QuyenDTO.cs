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
public class QuyenDTO
{
	#region "Attributes"
    private int _ma_quyen;    
    private string _ten_quyen;
    #endregion

    #region "Properties"
    public int Ma_quyen
    {
        get { return _ma_quyen; }
        set { _ma_quyen = value; }
    }
    public string Ten_quyen
    {
        get { return _ten_quyen; }
        set { _ten_quyen = value; }
    }
    #endregion

    #region "Constructor"
    public QuyenDTO()
	{
        Ma_quyen = -1;
        Ten_quyen = "";
    }
    #endregion
}
