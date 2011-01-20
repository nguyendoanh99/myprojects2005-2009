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
/// Summary description for GlobalConstant
/// </summary>
public class GlobalConstant
{
    public static string connectionString = @"Data Source=TINYFOOT\SQLEXPRESS; Initial Catalog=OFFS; Integrated Security=True";
    public static string[] dsDonVi = { "Chén", "Dĩa", "Tô", "Chai", "Lon", "Bình", "Ly", "Cái", "Gói", "Miếng", "Phần" };

	public GlobalConstant()
	{
		//
		// TODO: Add constructor logic here
		//
        
	}
}
