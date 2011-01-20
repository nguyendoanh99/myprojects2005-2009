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
/// Summary description for HinhThucKhuyenMaiDAO
/// </summary>
public class HinhThucKhuyenMaiDAO : AbstractDAO
{
	public HinhThucKhuyenMaiDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public HinhThucKhuyenMaiDTO[] LayDanhSachHTKM()
    {
        HinhThucKhuyenMaiDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachHTKM", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new HinhThucKhuyenMaiDTO[n];

        for (i = 0; i < n; ++i)
        {
            object htkm = GetDataFromDataRow(dt, i);
            Kq[i] = (HinhThucKhuyenMaiDTO)htkm;
        }

        Disconnect();
        return Kq;
    }

    public HinhThucKhuyenMaiDTO ThongTinHTKM(int maHinhThucKhuyenMai)
    {
        SqlCommand cmd = CreateCommandStored("spThongTinHTKM",
            new string[] { "@maHinhThucKhuyenMai" },
            new object[] { maHinhThucKhuyenMai });
        HinhThucKhuyenMaiDTO[] kq = (HinhThucKhuyenMaiDTO[])LayDanhSach(typeof(HinhThucKhuyenMaiDTO), cmd);
        if (kq.Length == 0)
            return null;

        return kq[0];
    }
    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(HinhThucKhuyenMaiDTO), dt.Rows[i]);
    } 
}
