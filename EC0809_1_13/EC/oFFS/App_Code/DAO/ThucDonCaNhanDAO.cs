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
/// Summary description for ThucDonCaNhanDAO
/// </summary>
public class ThucDonCaNhanDAO : AbstractDAO
{

    public int ThemThucDon(ThucDonCaNhanDTO thucdon, String[] strDsMaMon)
    {
        int Kq = 0; // mã thực đơn
        Connect();

        SqlCommand cmd = new SqlCommand("spThemThucDonTuTao", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tenthucdon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@hinhanh", SqlDbType.NVarChar);
        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters.Add("@dongia", SqlDbType.Money);

        cmd.Parameters["@tenthucdon"].Value = thucdon.Ten_thuc_don;
        cmd.Parameters["@makhachhang"].Value = thucdon.Ma_khach_hang;
        cmd.Parameters["@hinhanh"].Value = thucdon.Hinh_anh;
        cmd.Parameters["@dongia"].Value = thucdon.Gia;

        cmd.Parameters.Add("@mathucdoncanhan", SqlDbType.Int);
        cmd.Parameters["@mathucdoncanhan"].Direction = ParameterDirection.Output;                

        try
        {
            cmd.ExecuteNonQuery();
            int mathucdon = int.Parse(cmd.Parameters["@mathucdoncanhan"].Value.ToString());
            Kq = mathucdon;
            Disconnect();

            for (int i = 0; i < strDsMaMon.Length; ++i)
            {
                CTThucDonCaNhanDTO ctDto = new CTThucDonCaNhanDTO();
                ctDto.Ma_thuc_don_ca_nhan = mathucdon;
                ctDto.Ma_mon = int.Parse(strDsMaMon[i]);

                CTThucDonCaNhanBUS ctBus = new CTThucDonCaNhanBUS();
                ctBus.ThemCTThucDon(ctDto);
            }
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        return Kq;
    }


    public ThucDonCaNhanDTO[] LayDSThucDonTuTao(int makhachhang)
    {
        Connect();
        ThucDonCaNhanDTO[] kq;
        SqlCommand cmd = new SqlCommand("spLayDSThucDonTuTao", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@makhachhang", SqlDbType.Int);
        cmd.Parameters["@makhachhang"].Value = makhachhang;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);
        kq = new ThucDonCaNhanDTO[tab.Rows.Count];
        for (int i = 0; i < tab.Rows.Count; ++i)
        {
            object thucdon = GetDataFromDataRow(tab, i);
            kq[i] = (ThucDonCaNhanDTO)thucdon;
        }
        Disconnect();
        return kq;
    }
    // Lấy thông tin thực đơn cá nhân
    public ThucDonCaNhanDTO ChiTietThucDonCaNhan(int maThucDonCaNhan)
    {
        SqlCommand cmd = CreateCommandStored("spLayThongTinThucDonCaNhan",
            new string[] { "@maThucDonCaNhan" },
            new object[] { maThucDonCaNhan });
        ThucDonCaNhanDTO[] kq = (ThucDonCaNhanDTO[])LayDanhSach(typeof(ThucDonCaNhanDTO), cmd);
        return kq[0];
    }

    public int[] MonAnThuocThucDonCaNhan(int maThucDonCaNhan)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spLayChiTietThucDonCaNhan", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@maThucDonCaNhan", SqlDbType.Int);
        cmd.Parameters["@maThucDonCaNhan"].Value = maThucDonCaNhan;


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        int[] kq = new int[n];
        for (int i = 0; i < n; ++i)
            kq[i] = int.Parse(tab.Rows[i]["MaMon"].ToString());

        Disconnect();
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(ThucDonCaNhanDTO), dt.Rows[i]);
//         ThucDonCaNhanDTO tdcn = new ThucDonCaNhanDTO();
// 
//         tdcn.Ma_thuc_don_ca_nhan = (int)dt.Rows[i]["MaThucDonCaNhan"];
//         tdcn.Ten_thuc_don = dt.Rows[i]["TenThucDon"].ToString();
//         tdcn.Ma_khach_hang = (int)dt.Rows[i]["MaKhachHang"];
//         tdcn.Hinh_anh = dt.Rows[i]["HinhAnh"].ToString();
//         tdcn.Don_gia = (decimal)dt.Rows[i]["DonGia"];
//  
//         return (object)tdcn;
    }

    //protected override object GetDataFromDataRow(DataTable dt, int i)
    //{
    //    return CreateDTOFromDataRow(typeof(ThucDonCaNhanDTO), dt.Rows[i]);
    //}
}
