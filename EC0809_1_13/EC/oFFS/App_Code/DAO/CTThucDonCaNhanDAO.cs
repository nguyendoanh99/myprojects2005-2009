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
/// Summary description for CTThucDonCaNhanDAO
/// </summary>
public class CTThucDonCaNhanDAO : AbstractDAO
{
    public int ThemCTThucDon(CTThucDonCaNhanDTO dto)
    {
        int Kq = 0;
        Connect();

        SqlCommand cmd = new SqlCommand("spThemCTThucDonCaNhan", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@mathucdoncanhan", SqlDbType.Int);
        cmd.Parameters.Add("@mamon", SqlDbType.Int);

        cmd.Parameters["@mathucdoncanhan"].Value = dto.Ma_thuc_don_ca_nhan;
        cmd.Parameters["@mamon"].Value = dto.Ma_mon;

        cmd.Parameters.Add("@mactthucdoncanhan", SqlDbType.Int);
        cmd.Parameters["@mactthucdoncanhan"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();

            Kq = int.Parse(cmd.Parameters["@mactthucdoncanhan"].Value.ToString());
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
