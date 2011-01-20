using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MonAnYeuDauDAO
/// </summary>
public class MonAnYeuDauDAO : AbstractDAO
{
	public MonAnYeuDauDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ThemMonAnYeuDau(MonAnYeuDauDTO dto)
    {
        int Kq = 0;
        Connect();

        SqlCommand cmd = new SqlCommand("spThemMonAnYeuDau", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@mamon", SqlDbType.Int);

        cmd.Parameters["@makhachhang"].Value = dto.Ma_khach_hang;
        cmd.Parameters["@mamon"].Value = dto.Ma_mon;

        cmd.Parameters.Add("@mamonyeudau", SqlDbType.Int);
        cmd.Parameters["@mamonyeudau"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();

            Kq = int.Parse(cmd.Parameters["@mamonyeudau"].Value.ToString());
        }
        catch (SqlException ex)
        {
            Disconnect();            
        }
        return Kq;
    }

    public void XoaMonAnYeuDau(int makhachhang, int mamon)
    {
        int Kq = 0;
        Connect();

        SqlCommand cmd = new SqlCommand("spXoaMonAnYeuDau", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@mamon", SqlDbType.Int);

        cmd.Parameters["@makhachhang"].Value = makhachhang;
        cmd.Parameters["@mamon"].Value = mamon;        

        try
        {
            cmd.ExecuteNonQuery();
            Disconnect();            
        }
        catch (SqlException ex)
        {
            Disconnect();
           
        }
    }

    public MonAnYeuDauDTO[] LayDSMonAnYeuThich(int makhachhang)
    {
        Connect();
        MonAnYeuDauDTO[] kq;
        SqlCommand cmd = new SqlCommand("spLayDSMonAnYeuThich", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters["@makhachhang"].Value = makhachhang;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        kq = new MonAnYeuDauDTO[tab.Rows.Count];
        for (int i = 0; i < tab.Rows.Count; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            kq[i] = (MonAnYeuDauDTO)mon_an;
        }
        Disconnect();
        return kq;
    }


    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        MonAnYeuDauDTO monan = new MonAnYeuDauDTO();
        monan.Ma_mon_yeu_dau = int.Parse(dt.Rows[i]["MaMonYeuDau"].ToString());                
        monan.Ma_khach_hang = int.Parse(dt.Rows[i]["MaKhachHang"].ToString());       
        monan.Ma_mon = int.Parse(dt.Rows[i]["MaMon"].ToString());        

        return (object)monan;
    } 
}
