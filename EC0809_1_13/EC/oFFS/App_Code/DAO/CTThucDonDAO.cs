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
/// Summary description for CTThucDon
/// </summary>
public class CTThucDonDAO : AbstractDAO
{
    public int ThemCTThucDon(CTThucDonDTO dto)
    {
        int Kq = 0;
        Connect();

        SqlCommand cmd = new SqlCommand("spThemCTThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);
        cmd.Parameters.Add("@mamon", SqlDbType.Int);

        cmd.Parameters["@mathucdon"].Value = dto.Ma_thuc_don;
        cmd.Parameters["@mamon"].Value = dto.Ma_mon;

        cmd.Parameters.Add("@mactthucdon", SqlDbType.Int);
        cmd.Parameters["@mactthucdon"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();

            Kq = int.Parse(cmd.Parameters["@mactthucdon"].Value.ToString());
        }
        catch (SqlException ex)
        {
            Disconnect();
            return Kq;
        }

        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        throw new Exception("The method or operation is not implemented.");
    }
}
