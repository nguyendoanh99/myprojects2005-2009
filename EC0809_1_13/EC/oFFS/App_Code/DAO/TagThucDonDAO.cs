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
/// Summary description for TagThucDonDAO
/// </summary>
public class TagThucDonDAO : AbstractDAO
{
    public void ThemTagThucDon(TagThucDonDTO tagthucdon)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spThemTagThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@matag", SqlDbType.Int);
        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);

        cmd.Parameters["@matag"].Value = tagthucdon.Ma_tag;
        cmd.Parameters["@mathucdon"].Value = tagthucdon.Ma_thuc_don;

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();
        }
        catch
        {
        }
    }
    public ThucDonDTO[] DSThucDonTheoTag(int matag)
    {
        Connect();
        ThucDonDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spDanhSachThucDonTheoTag", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ma_tag", SqlDbType.Int);
        cmd.Parameters["@ma_tag"].Value = matag;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        Kq = new ThucDonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object thuc_don = GetDataFromDataRow(tab, i);
            Kq[i] = (ThucDonDTO)thuc_don;
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(ThucDonDTO), dt.Rows[i]);
    } 

}
