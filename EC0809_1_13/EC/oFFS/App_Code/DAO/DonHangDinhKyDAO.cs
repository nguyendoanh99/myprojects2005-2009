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
/// Summary description for DonHangDinhKyDAO
/// </summary>
public class DonHangDinhKyDAO: DonHangDAO
{
	public DonHangDinhKyDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool ThemDonHangDinhKy(DonHangDinhKyDTO donhangdk)
    {
        SqlConnection cnn = Connect();

        SqlCommand cmd = new SqlCommand("spThemDonHangDinhKy", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@madonhangkinhky", SqlDbType.Int);
        cmd.Parameters.Add("@loaidinhky", SqlDbType.NVarChar);
        cmd.Parameters.Add("@ngaybatdau", SqlDbType.DateTime);
        cmd.Parameters.Add("@ngayketthuc", SqlDbType.DateTime);
        cmd.Parameters.Add("@ngaygiao", SqlDbType.VarChar);
        cmd.Parameters.Add("@thugiao", SqlDbType.VarChar);
        cmd.Parameters.Add("@giogiao", SqlDbType.DateTime);
        cmd.Parameters.Add("@tinhtrang", SqlDbType.Bit);

        cmd.Parameters["@madonhangkinhky"].Value = donhangdk.Ma_don_hang;
        cmd.Parameters["@loaidinhky"].Value = donhangdk.Loai_dinh_ky;
        cmd.Parameters["@ngaybatdau"].Value = donhangdk.Ngay_bat_dau;
        cmd.Parameters["@ngayketthuc"].Value = donhangdk.Ngay_ket_thuc;
        cmd.Parameters["@ngaygiao"].Value = donhangdk.Ngay_giao;
        cmd.Parameters["@thugiao"].Value = donhangdk.Thu_giao;
        cmd.Parameters["@giogiao"].Value = donhangdk.Gio_giao;
        cmd.Parameters["@tinhtrang"].Value = donhangdk.Tinh_trang;

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
        return true;
    }

    public bool XoaDonHangDinhKy(int maDonHang)
    {
        SqlCommand cmd = CreateCommandStored("spXoaDonHangDinhKy",
             new string[] { "@maDonHang" },
             new object[] { maDonHang });
        return ExecuteNonQuery(cmd);
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(DonHangDinhKyDTO), dt.Rows[i]);
    }
    // Danh sách đơn hàng loại 6: đơn hàng định kỳ
    public DonHangDinhKyDTO[] DanhSachDonHangDinhKy(int maKhachHang, int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spXemDanhSachDonHangDinhKy",
            new string[] { "@maKhachHang", "@pageNum", "@pageSize" },
            new object[] { maKhachHang, pageNum, pageSize });
        DonHangDinhKyDTO[] kq = (DonHangDinhKyDTO[])LayDanhSach(typeof(DonHangDinhKyDTO), cmd);
        return kq;
    }
    public DonHangDinhKyDTO LayThongTinDonHangDinhKy(int maDonHang)
    {
        SqlCommand cmd = CreateCommandStored("spLayThongTinDonHangDinhKy",
            new string[] { "@maDonHang" },
            new object[] { maDonHang });
        DonHangDinhKyDTO[] kq = (DonHangDinhKyDTO[])LayDanhSach(typeof(DonHangDinhKyDTO), cmd);
        if (kq.Length == 0)
            return null;
        return kq[0];
    }
}
