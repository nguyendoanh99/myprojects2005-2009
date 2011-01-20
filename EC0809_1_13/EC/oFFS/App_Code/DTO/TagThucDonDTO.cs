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
/// Summary description for TagTheHienThucDon
/// </summary>
public class TagThucDonDTO
{
    private int _ma_tag;
    private int _ma_thuc_don;

    public int Ma_tag
    {
        get { return _ma_tag; }
        set { _ma_tag = value; }
    }

    public int Ma_thuc_don
    {
        get { return _ma_thuc_don; }
        set { _ma_thuc_don = value; }
    }

    public TagThucDonDTO()
	{
        Ma_tag = -1;
        Ma_thuc_don = -1;
	}

}
