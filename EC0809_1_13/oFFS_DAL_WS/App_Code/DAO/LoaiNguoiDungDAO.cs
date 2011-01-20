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
using System.Data;
/// <summary>
/// Summary description for LoaiNguoiDungDAO
/// </summary>
public class LoaiNguoiDungDAO : AbstractDAO
{
    public LoaiNguoiDungDTO[] LayDanhSachLoaiNguoiDung()
    {
        LoaiNguoiDungDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiNguoiDung", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiNguoiDungDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loainguoidung = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiNguoiDungDTO)loainguoidung;
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        LoaiNguoiDungDTO loainguoidung = new LoaiNguoiDungDTO();
        loainguoidung.Ma_loai_nguoi_dung = int.Parse(dt.Rows[i]["MaLoaiNguoiDung"].ToString());
        loainguoidung.Ten_loai_nguoi_dung = dt.Rows[i]["TenLoaiNguoiDung"].ToString();

        return (object)loainguoidung;
    }  
}
