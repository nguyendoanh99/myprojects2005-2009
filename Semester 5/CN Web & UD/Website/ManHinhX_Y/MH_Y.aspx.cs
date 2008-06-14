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

public partial class MH_Y : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Ten"] != null)
        {
            TextBox1.Enabled = true;
            TextBox1.Text = Session["Ten"].ToString();
        }
        else
            TextBox1.Enabled = false;
    }
}
