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
/// Summary description for ThanhToanTheTinDungDAO
/// </summary>
public class ThanhToanTheTinDungDAO : AbstractDAO
{
    public void ThemThanhToanTheTinDung(ThanhToanTheTinDungDTO thett)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spThemThanhToanTheTinDung", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@madonhang", SqlDbType.Int);
        cmd.Parameters.Add("@maloaithe", SqlDbType.Int);
        cmd.Parameters.Add("@sothe", SqlDbType.VarChar);
        cmd.Parameters.Add("@ngayhh", SqlDbType.DateTime);

        cmd.Parameters["@madonhang"].Value = thett.Ma_don_hang;
        cmd.Parameters["@maloaithe"].Value = thett.Ma_loai_the;
        cmd.Parameters["@sothe"].Value = thett.So_the;
        cmd.Parameters["@ngayhh"].Value = thett.Ngay_het_han;

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
    public bool XoaThanhToanTheTinDung(int madonhang)
    {
        SqlCommand cmd = CreateCommandStored("spXoaThanhToanTheTinDung",
             new string[] { "@maDonHang" },
             new object[] { madonhang });
        return ExecuteNonQuery(cmd);
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        ThanhToanTheTinDungDTO thett = new ThanhToanTheTinDungDTO();
        thett.Ma_don_hang = int.Parse(dt.Rows[i]["MaDonHang"].ToString());
        thett.Ma_loai_the = int.Parse(dt.Rows[i]["MaLoaiThe"].ToString());
        thett.So_the = dt.Rows[i]["SoThe"].ToString();
        thett.Ngay_het_han = DateTime.Parse(dt.Rows[i]["MaLoaiThe"].ToString());
      
        return (object)thett;
    }  
}
