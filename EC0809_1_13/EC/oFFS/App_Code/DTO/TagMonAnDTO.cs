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
/// Summary description for TagMonAnDTO
/// </summary>
public class TagMonAnDTO
{
    private int _ma_tag;
    private int _ma_mon;

    public int Ma_tag
    {
        get { return _ma_tag; }
        set { _ma_tag = value; }
    }

    public int Ma_mon
    {
        get { return _ma_mon; }
        set { _ma_mon = value; }
    }

    



	public TagMonAnDTO()
	{
        Ma_tag = -1;
        Ma_mon = -1;
	}
}
