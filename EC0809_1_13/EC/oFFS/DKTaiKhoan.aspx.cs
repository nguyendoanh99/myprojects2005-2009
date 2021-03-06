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
using System.Data.SqlClient;


public partial class DKTaiKhoan : System.Web.UI.Page
{   
    private Random random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Create a random code and store it in the Session object.
        TaoRandomCode();
     
    }

    protected void TaoRandomCode()
    {
        
        this.Session["CaptchaImageText"] = GenerateRandomCode();
        //hidRandomCode.Value = this.Session["CaptchaImageText"].ToString();
    }

    public string GenerateRandomCode()
    {
        string s = "";
        for (int i = 0; i < 6; i++)
            s = String.Concat(s, this.random.Next(10).ToString());
        return s;
    }

    private void DisplayMessage(String message)
    {
        ltlAlert.Text = "alert('" + message + "');";
    }
  
}
