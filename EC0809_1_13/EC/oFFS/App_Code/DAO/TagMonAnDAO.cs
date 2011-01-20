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

    public MonAnDTO[] DSMonAnTheoTag(int matag)
    {
        Connect();
        MonAnDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spDanhSachMonTheoTag", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ma_tag", SqlDbType.Int);
        cmd.Parameters["@ma_tag"].Value = matag;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        Kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            Kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(MonAnDTO), dt.Rows[i]);
    } 
}
