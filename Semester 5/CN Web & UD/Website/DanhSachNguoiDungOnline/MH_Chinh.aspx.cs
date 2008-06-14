using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Timers;
public partial class MH_Chinh : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList arr = (ArrayList)Application["Danh_Sach"];
        String str = "";
        str = "<Goc GiaTri='";
        for (int i = 0; i < arr.Count; ++i)
        {
            str += arr[i].ToString() + "\n";
        }
        str += "' />";
        Response.ContentType = "text/xml";
        Response.Write(str);
    }
}
