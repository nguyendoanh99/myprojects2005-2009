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
/// Summary description for TagMonAnBUS
/// </summary>
public class TagMonAnBUS
{
	public TagMonAnBUS()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    TagMonAnDAO dao = new TagMonAnDAO();
    public MonAnDTO[] DSMonAnTheoTag(int matag)
    {
        return dao.DSMonAnTheoTag(matag);
    }
}
