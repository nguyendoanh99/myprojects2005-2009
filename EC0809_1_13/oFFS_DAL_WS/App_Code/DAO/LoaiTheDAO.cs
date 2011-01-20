using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for LoaiTheDAO
/// </summary>
public class LoaiTheDAO : AbstractDAO
{	
    public LoaiTheDTO[] LayDanhSachLoaiThe()
    {
        LoaiTheDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiThe", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiTheDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiTheDTO)loaithe;
        }

        Disconnect();
        return Kq;
       
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        LoaiTheDTO loaithe = new LoaiTheDTO();
        loaithe.Ma_loai_the = int.Parse(dt.Rows[i]["MaLoaiThe"].ToString());
        loaithe.Ten_loai_the = dt.Rows[i]["TenLoaiThe"].ToString();

        return (object)loaithe;
    }  
}
