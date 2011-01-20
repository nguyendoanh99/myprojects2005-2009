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
/// Summary description for TagDTO
/// </summary>
public class TagDTO
{
    private int _ma_tag;
    private string _ten_tag;
    private int _do_uu_tien;

    public int Ma_tag
    {
        get { return _ma_tag; }
        set { _ma_tag = value; }
    }
    
    public string Ten_tag
    {
        get { return _ten_tag; }
        set { _ten_tag = value; }
    }
    public int Do_uu_tien
    {
        get { return _do_uu_tien; }
        set { _do_uu_tien = value; }
    }

	public TagDTO()
	{
        Ma_tag = -1;
        Ten_tag = "";
        Do_uu_tien = -1;
	}
}
