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
/// Summary description for Tag
/// </summary>
public class TagDAO : AbstractDAO
{
    public int ThemTag(TagDTO tag)
    {
        int Kq = 0; //mã người dùng
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemTag", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tentag", SqlDbType.NVarChar);
        cmd.Parameters["@tentag"].Value = tag.Ten_tag;

        cmd.Parameters.Add("@matag", SqlDbType.Int);
        cmd.Parameters["@matag"].Direction = ParameterDirection.Output;

        try
        {   
            cmd.ExecuteNonQuery();
            Kq = (int)cmd.Parameters["@matag"].Value;
        }
        catch { }

        Disconnect();
        return Kq;
        
    }

    public static String[] XuLyChuoiTag(string strTag)
    {
        String[] Kq;
        char[] splitSign = { ',', ';' };

        Kq = strTag.Split(splitSign, StringSplitOptions.RemoveEmptyEntries);
        return Kq;
    }
}
