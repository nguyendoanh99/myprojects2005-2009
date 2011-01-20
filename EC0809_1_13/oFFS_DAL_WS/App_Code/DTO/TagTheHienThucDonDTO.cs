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
public class TagTheHienThucDonDTO
{
    private int _ma_tag;
    private int _ma_the_hien;

    public int Ma_tag
    {
        get { return _ma_tag; }
        set { _ma_tag = value; }
    }

    public int Ma_the_hien
    {
        get { return _ma_the_hien; }
        set { _ma_the_hien = value; }
    }

    public TagTheHienThucDonDTO()
	{
        Ma_tag = -1;
        Ma_the_hien = -1;
	}

}
