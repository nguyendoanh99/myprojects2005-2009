using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for AbstractDAO
/// </summary>
public class AbstractDAO
{
    protected String strConn = @"Data Source=MISSFULE\SQLEXPRESS; Initial Catalog=BalanceSystem; Integrated Security=True";
    //protected String strConn = @"Data Source=DangKhoa-PC\SQLEXPRESS; Initial Catalog=BalanceSystem; Integrated Security=True";
    protected SqlConnection cnn;

    public String ConnectionString
    {
        get { return strConn; }
        set { strConn = value; }
    }
    public SqlConnection Connection
    {
        get { return cnn; }
        set { cnn = value; }
    }
    //new
    public SqlConnection Connect()
    {
        cnn = new SqlConnection(strConn);
        cnn.Open();
        return cnn;
    }
    public void Disconnect()
    {
        cnn.Close();
    }

    protected virtual object GetDataFromDataRow(DataTable dt, int i)
    {
        return null;
    }
}
