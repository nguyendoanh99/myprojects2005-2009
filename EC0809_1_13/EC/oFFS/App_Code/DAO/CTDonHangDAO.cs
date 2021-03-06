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
/// Summary description for CTDonHangDAO
/// </summary>
public class CTDonHangDAO : AbstractDAO
{
	public CTDonHangDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int ThemChiTietDonHang(CTDonHangDTO ctdonhang)
    {
        int Kq = 0; //mã chi tiet don hang
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemChiTietDonHang", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@madonhang", SqlDbType.Int);
        cmd.Parameters.Add("@maitem", SqlDbType.Int);
        cmd.Parameters.Add("@loaiitem", SqlDbType.Int);
        cmd.Parameters.Add("@soluong", SqlDbType.Int);
        cmd.Parameters.Add("@thanhtien", SqlDbType.Money);
        cmd.Parameters.Add("@laquatang", SqlDbType.Bit);

        cmd.Parameters["@madonhang"].Value = ctdonhang.Ma_don_hang;
        cmd.Parameters["@maitem"].Value = ctdonhang.Ma_item;
        cmd.Parameters["@loaiitem"].Value = ctdonhang.Loai_item;
        cmd.Parameters["@soluong"].Value = ctdonhang.So_luong;
        cmd.Parameters["@thanhtien"].Value = ctdonhang.Thanh_tien;
        cmd.Parameters["@laquatang"].Value = ctdonhang.La_qua_tang;

        cmd.Parameters.Add("@machitietdonhang", SqlDbType.Int);
        cmd.Parameters["@machitietdonhang"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        Kq = (int)cmd.Parameters["@machitietdonhang"].Value;

        Disconnect();
        return Kq;
    }
    // Lấy danh sách chi tiết đơn hàng
    public CTDonHangDTO[] DanhSachCTDonHang(int maDonHang)
    {
        SqlCommand cmd = CreateCommandStored("spLayDSCTDonHang",
            new string[] { "@maDonHang"},
            new object[] { maDonHang});
        CTDonHangDTO[] kq = (CTDonHangDTO[])LayDanhSach(typeof(CTDonHangDTO), cmd);
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(CTDonHangDTO), dt.Rows[i]);
    }
}
