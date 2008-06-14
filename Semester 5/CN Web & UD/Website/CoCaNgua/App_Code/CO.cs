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
/// Summary description for Co
/// </summary>
public class CO
{
    private int mViTri;
    public int ViTri
    {
        get
        {
            return mViTri;
        }
        set
        {
            mViTri = value;
        }
    }
	public CO()
	{
		//
		// TODO: Add constructor logic here
		//
        ViTri = -1;
	}
}
