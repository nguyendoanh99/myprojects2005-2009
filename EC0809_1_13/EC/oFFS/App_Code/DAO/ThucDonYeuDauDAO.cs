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
/// Summary description for ThucDonYeuDauDAO
/// </summary>
public class ThucDonYeuDauDAO : AbstractDAO
{
	public ThucDonYeuDauDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ThemThucDon(ThucDonUaThich thucdon)
    {
        int Kq = 0; // mã thực đơn
        Connect();

        SqlCommand cmd = new SqlCommand("spThemThucDonYeuThich", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@mathucdon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);

        cmd.Parameters["@mathucdon"].Value = thucdon.Ma_thuc_don;
        cmd.Parameters["@makhachhang"].Value = thucdon.Ma_khach_hang;

        cmd.Parameters.Add("@mathucdonyeudau", SqlDbType.Int);
        cmd.Parameters["@mathucdonyeudau"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            int mathucdon = int.Parse(cmd.Parameters["@mathucdonyeudau"].Value.ToString());
            Kq = mathucdon;
            Disconnect();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        return Kq;
    }

    public ThucDonUaThich[] LayDSThucDonYeuThich(int makhachhang)
    {
        Connect();
        ThucDonUaThich[] kq;
        SqlCommand cmd = new SqlCommand("spLayDSThucDonYeuThich", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters["@makhachhang"].Value = makhachhang;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        kq = new ThucDonUaThich[tab.Rows.Count];
        for (int i = 0; i < tab.Rows.Count; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            kq[i] = (ThucDonUaThich)mon_an;
        }
        Disconnect();
        return kq;
    }

    public void XoaThucDonYeuThich(int makhachhang, int mathucdon)
    {
        Connect();
        ThucDonCaNhanDTO[] kq;
        SqlCommand cmd = new SqlCommand("spXoaThucDonYeuThich", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);

        cmd.Parameters["@makhachhang"].Value = makhachhang;
        cmd.Parameters["@mathucdon"].Value = mathucdon;

        try
        {
            cmd.ExecuteNonQuery();                        
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }
        Disconnect();        
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        ThucDonUaThich thucdon = new ThucDonUaThich();
        thucdon.Ma_thuc_don_yeu_dau = int.Parse(dt.Rows[i]["MaThucDonYeuDau"].ToString());
        thucdon.Ma_khach_hang = int.Parse(dt.Rows[i]["MaKhachHang"].ToString());        
        thucdon.Ma_thuc_don = int.Parse(dt.Rows[i]["MaThucDon"].ToString());

        return (object)thucdon;
    }
}
