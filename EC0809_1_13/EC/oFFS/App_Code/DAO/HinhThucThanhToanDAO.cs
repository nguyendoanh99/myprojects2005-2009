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
/// Summary description for HinhThucThanhToanDAO
/// </summary>
public class HinhThucThanhToanDAO : AbstractDAO
{
	public HinhThucThanhToanDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public HinhThucThanhToanDTO[] LayDanhSachHTTT()
    {
        HinhThucThanhToanDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachHTTT", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new HinhThucThanhToanDTO[n];

        for (i = 0; i < n; ++i)
        {
            object htkm = GetDataFromDataRow(dt, i);
            Kq[i] = (HinhThucThanhToanDTO)htkm;
        }

        Disconnect();
        return Kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        HinhThucThanhToanDTO httt = new HinhThucThanhToanDTO();

        httt.Mahinh_thuc_tt = (int)dt.Rows[i]["MaHinhThucThanhToan"];
        httt.Ten_hinh_thuc_tt = dt.Rows[i]["TenHinhThucThanhToan"].ToString();

        return (object)httt;
    } 
}
