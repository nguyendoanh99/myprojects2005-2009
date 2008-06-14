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
/// Summary description for NGUOICHOI
/// </summary>
public class NGUOICHOI
{
    private String m_strUsername;
    public String Username
    {
        get
        {
            return m_strUsername;
        }
        set
        {
            m_strUsername = value;
        }
    }


	public NGUOICHOI()
	{
		//
		// TODO: Add constructor logic here
		//
        m_strUsername = "";
	}
}
