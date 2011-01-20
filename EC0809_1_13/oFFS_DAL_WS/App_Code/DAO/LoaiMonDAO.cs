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
/// Summary description for LoaiMonDAO
/// </summary>
public class LoaiMonDAO : AbstractDAO
{
    public LoaiMonDTO[] LayDanhSachLoaiMon()
    {
        LoaiMonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiMonLa", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiMonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiMonDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        LoaiMonDTO loaimon = new LoaiMonDTO();
        loaimon.Ma_loai_mon = (int)dt.Rows[i]["MaLoaiMon"];
        loaimon.Ten_loai_mon = dt.Rows[i]["TenLoaiMon"].ToString();
        loaimon.Ma_loai_mon_cha = (int)dt.Rows[i]["MaLoaiMonCha"];
        loaimon.La_loai_mon_la = (bool)dt.Rows[i]["LaLoaiMonLa"];

        return (object)loaimon;
    }  
}
