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
/// Summary description for ThamSoBUS
/// </summary>
public class ThamSoBUS
{
    public ThamSoDTO LayThamSo()
    {
        return (new ThamSoDAO()).LayThamSo();
    }
    public bool LuuThamSo(ThamSoDTO ts)
    {
        return (new ThamSoDAO()).LuuThamSo(ts);
    }
}
