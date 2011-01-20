using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for AbstractDAO
/// </summary>
public class AbstractDAO
{
		//
		// TODO: Add constructor logic here
		//
    //public string strConnection = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ";

    protected String strConn = @"Data Source=TINYFOOT\SQLEXPRESS; Initial Catalog=OFFS; Integrated Security=True";
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
