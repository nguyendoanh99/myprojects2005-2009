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
/// Summary description for TagMonAnDAO
/// </summary>
public class TagMonAnDAO : AbstractDAO
{
    public void ThemTagMonAn(TagMonAnDTO tagmonanDTO)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spThemTagMonAn", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@matag", SqlDbType.Int);
        cmd.Parameters.Add("@mamon", SqlDbType.Int);

        cmd.Parameters["@matag"].Value = tagmonanDTO.Ma_tag;
        cmd.Parameters["@mamon"].Value = tagmonanDTO.Ma_mon;

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();
        }
        catch 
        {   
        }
    }
}
