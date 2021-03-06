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
using System.Reflection;

/// <summary>
/// Summary description for AbstractDAO
/// </summary>
public abstract class AbstractDAO
{
		//
		// TODO: Add constructor logic here
		//
    //public string strConnection = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = ";
    protected String strConn = @"Data Source=MISSFULE\SQLEXPRESS; Initial Catalog=OFFS; Integrated Security=True";
    //protected String strConn = @"Data Source=.\SQLEXPRESS;AttachDbFilename='D:\Hoc Tap\Chuyen Nganh\HK VII\Bai tap\TMDT\Project\OFFS\Database_VER2.6.1\OFFS.mdf';Integrated Security=True;Connect Timeout=30;User Instance=True";
    //protected String strConn = @"Data Source=TINYFOOT\SQLEXPRESS; Initial Catalog=OFFS; Integrated Security=True";
    //protected String strConn = @"Data Source=DangKhoa-PC\SQLEXPRESS; Initial Catalog=OFFS; Integrated Security=True";
    //protected String strConn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Hoc Tap\Chuyen Nganh\HK VII\Bai tap\TMDT\SVN2\Database\Database_VER 7.0\OFFS.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";    
    //protected String strConn = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Hoc Tap\Chuyen Nganh\HK VII\Bai tap\TMDT\Project\OFFS\Database_VER3.7\OFFS.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

    protected SqlConnection cnn = null;

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
        if (cnn == null)
        {
            cnn = new SqlConnection(strConn);
            cnn.Open();
        }        
        return cnn;
    }
    public void Disconnect()
    {
        if (cnn != null)
        {
            cnn.Close();
            cnn = null;
        }        
    }

    protected abstract object GetDataFromDataRow(DataTable dt, int i);
    // Tạo đối tượng DTO tương ứng với type, tự động đọc các property trong lớp DTO
    // gán các trường trong dr vào các property tương ứng (tên trường phải trùng với tên property)
    protected object CreateDTOFromDataRow(Type type, DataRow dr)
    {
        ConstructorInfo ci = type.GetConstructor(Type.EmptyTypes);
        Object obj = ci.Invoke(null);
        PropertyInfo[] pi = type.GetProperties();
        foreach (PropertyInfo o in pi)
        {
            string colName = o.Name.Replace("_", "");
            if (dr[colName].GetType() != typeof(DBNull))
                o.SetValue(obj, dr[colName], null);
        }
        return obj;
    }
    // Tạo command stored procedure, o là mảng các giá trị tương ứng với các tham số trong stored
    protected SqlCommand CreateCommandStored(string stored, string[] parameter, object[] o)
    {
        Connect();
        SqlCommand cmd = new SqlCommand(stored);
        cmd.CommandType = CommandType.StoredProcedure;

        if (parameter == null)
            return cmd;

        for (int i = 0; i < parameter.Length; ++i)
        {
            SqlParameter p = new SqlParameter();
            p.ParameterName = parameter[i];
            p.Value = o[i];
            cmd.Parameters.Add(p);
        }

        return cmd;
    }
    protected Array LayDanhSach(Type type, SqlCommand cmd)
    {
        Array Kq;

        cmd.Connection = cnn;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = Array.CreateInstance(type, n);

        for (i = 0; i < n; ++i)
            Kq.SetValue(GetDataFromDataRow(dt, i), i);

        Disconnect();
        return Kq;
    }
    protected object ExecuteScalar(SqlCommand cmd)
    {
        cmd.Connection = cnn;
        object kq = null;
        try
        {
            kq = cmd.ExecuteScalar();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return null;
        }

        Disconnect();
        return kq;
    }
    protected bool ExecuteNonQuery(SqlCommand cmd)
    {
        cmd.Connection = cnn;
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return false;
        }

        Disconnect();
        return true;
    }
}
