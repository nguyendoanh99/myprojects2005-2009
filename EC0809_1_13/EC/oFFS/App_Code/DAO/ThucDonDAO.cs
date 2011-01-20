using System;
using System.Collections;
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
/// Summary description for ThucDonDAO
/// </summary>
public class ThucDonDAO: AbstractDAO
{

    public int ThemThucDon(ThucDonDTO thucdon, String[] strDsMaMon,String strTag )
    {
        int Kq = 0; // mã thực đơn
        Connect();

        SqlCommand cmd = new SqlCommand("spThemThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tenthucdon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@maloaithucdon", SqlDbType.Int);
        cmd.Parameters.Add("@mota", SqlDbType.NVarChar);
        cmd.Parameters.Add("@hinhanhminhhoa", SqlDbType.VarChar);
        cmd.Parameters.Add("@diembinhchon", SqlDbType.Int);
        cmd.Parameters.Add("@gia", SqlDbType.Money);
        cmd.Parameters.Add("@tinhtrang", SqlDbType.Bit);
        cmd.Parameters.Add("@trangthaihienthi", SqlDbType.Bit);

        cmd.Parameters["@tenthucdon"].Value = thucdon.Ten_thuc_don;
        cmd.Parameters["@maloaithucdon"].Value = thucdon.Ma_loai_thuc_don;
        cmd.Parameters["@mota"].Value = thucdon.Mo_ta;
        cmd.Parameters["@hinhanhminhhoa"].Value = thucdon.Hinh_anh_minh_hoa;
        cmd.Parameters["@diembinhchon"].Value = thucdon.Diem_binh_chon;
        cmd.Parameters["@gia"].Value = thucdon.Gia;
        cmd.Parameters["@tinhtrang"].Value = thucdon.Tinh_trang;
        cmd.Parameters["@trangthaihienthi"].Value = thucdon.Trang_thai_hien_thi;

        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);
        cmd.Parameters["@mathucdon"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            int mathucdon = int.Parse(cmd.Parameters["@mathucdon"].Value.ToString());
            Kq = mathucdon;
            Disconnect();

            for (int i = 0; i < strDsMaMon.Length; ++i)
            {
                CTThucDonDTO ctDto = new CTThucDonDTO();
                ctDto.Ma_thuc_don = mathucdon;
                ctDto.Ma_mon = int.Parse(strDsMaMon[i]);

                CTThucDonBUS ctBus = new CTThucDonBUS();
                ctBus.ThemCTThucDon(ctDto);
            }

            String[] dsTag = TagDAO.XuLyChuoiTag(strTag);
            TagDTO tagDTO = new TagDTO();
            TagThucDonDTO tagthucdonDTO = new TagThucDonDTO();
            tagthucdonDTO.Ma_thuc_don = mathucdon;

            for (int i = 0; i < dsTag.Length; ++i)
            {
                tagDTO.Ten_tag = dsTag[i];
                int matag = (new TagDAO()).ThemTag(tagDTO);

                tagthucdonDTO.Ma_tag = matag;
                (new TagThucDonDAO()).ThemTagThucDon(tagthucdonDTO);
            }
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        return Kq;
    }
    // Lấy thông tin thực đơn
    public ThucDonDTO ChiTietThucDon(int maThucDon)
    {
        SqlCommand cmd = CreateCommandStored("spLayThongTinThucDon",
            new string[] { "@mathucdon" },
            new object[] { maThucDon });
        ThucDonDTO[] kq = (ThucDonDTO[])LayDanhSach(typeof(ThucDonDTO), cmd);
        if (kq.Length == 0)
            return null;
        return kq[0];
    }

    public ThucDonDTO[] DSMThucDonThuocLoaiThucDon(int maloaithucdon)
    {
        Connect();
        ThucDonDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spLayDSThucDonCuaMotLoaiThucDonLa", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maloaithucdon", SqlDbType.Int);
        cmd.Parameters["@maloaithucdon"].Value = maloaithucdon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        Kq = new ThucDonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            Kq[i] = (ThucDonDTO)mon_an;
        }

        Disconnect();
        return Kq;
    }

    public ThucDonDTO[] DanhSachThucDon(int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spLayDanhSachThucDon",
            new string[] { "@pageNum", "@pageSize" },
            new object[] { pageNum, pageSize });
        ThucDonDTO[] kq = (ThucDonDTO[])LayDanhSach(typeof(ThucDonDTO), cmd);
        return kq;
    }


    //NGHI
    public ArrayList LayDSThucDonThuocLoaiThucDonBatKy(int maloaithucdon)
    {
        Connect();
        ArrayList Kq = new ArrayList();

        SqlCommand cmd = new SqlCommand("spLayDSThucDonThuocLoaiThucDonBatKy", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maloaithucdon", SqlDbType.Int);
        cmd.Parameters["@maloaithucdon"].Value = maloaithucdon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        for (int j = 0; j < ds.Tables.Count; ++j)
        {
            DataTable dt = ds.Tables[j];
            int n = dt.Rows.Count;

            for (int i = 0; i < n; ++i)
            {
                object thuc_don = GetDataFromDataRow(dt, i);
                Kq.Add((ThucDonDTO)thuc_don);
            }
        }
        Disconnect();
        return Kq;
    }


    //-> tên hàm này nhập nhằng 
    public ArrayList ThongTinThucDon(int ma)
    {
        ArrayList kq = new ArrayList();

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachMonAnCuaThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@ma_thuc_don", SqlDbType.Int);
        cmd.Parameters["@ma_thuc_don"].Value = ma;


        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;

        for (int i = 0; i < n; ++i)
            kq.Add(int.Parse(tab.Rows[i]["MaMon"].ToString()));

        Disconnect();
        return kq;
    }

    //-> tránh nhập nhằng với hàm trên -> lấy thông tin thực đơn ko bao gồm chi tiết món :|
    public ThucDonDTO LayThongTinTongQuatCuaThucDon(int ma)
    {
        ThucDonDTO Kq = new ThucDonDTO();

        Connect();
        SqlCommand cmd = new SqlCommand("spLayThongTinThucDon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@mathucdon", SqlDbType.Int);
        cmd.Parameters["@mathucdon"].Value = ma;

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {            
            Kq.Ma_thuc_don = int.Parse(dr["MaThucDon"].ToString());
            Kq.Ten_thuc_don = dr["TenThucDon"].ToString();
            Kq.Ma_loai_thuc_don = int.Parse(dr["MaLoaiThucDon"].ToString());
            Kq.Mo_ta = dr["MoTa"].ToString();
            Kq.Hinh_anh_minh_hoa = dr["HinhAnhMinhHoa"].ToString();
            Kq.Gia = decimal.Parse(dr["Gia"].ToString());
            Kq.Diem_binh_chon = int.Parse(dr["DiemBinhChon"].ToString());
            Kq.Trang_thai_hien_thi = bool.Parse(dr["TrangThaiHienThi"].ToString());
            Kq.Tinh_trang = bool.Parse(dr["TinhTrang"].ToString());
        }

        Disconnect();
        return Kq;
    }

    // Lấy danh sách các thực đơn của một loại thực đơn lá nào đó
    public ArrayList LayDSThucDonCuaLoaiThucDonLa(int maloaithucdon)
    {
        ArrayList Kq = new ArrayList();

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSThucDonCuaMotLoaiThucDonLa", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@maloaithucdon", SqlDbType.Int);
        cmd.Parameters["maloaithucdon"].Value = maloaithucdon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int i = 0;
        int n = tab.Rows.Count;

        for (i = 0; i < n; ++i)
        {
            object thucdon = GetDataFromDataRow(tab, i);
            Kq[i] = (ThucDonDTO)thucdon;
        }

        Disconnect();
        return Kq;
    }

    public ThucDonDTO[] TimKiemThucDonTheoTen(string ten_thuc_don)
    {
        Connect();
        ThucDonDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spTimKiemTheoTen", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
        cmd.Parameters["@ten"].Value = ten_thuc_don;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable tab = new DataTable();
        DataSet dsThucDon = new DataSet();
        da.Fill(dsThucDon, "THUC_DON");

        int n = dsThucDon.Tables[1].Rows.Count;
        Kq = new ThucDonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object thuc_don = GetDataFromDataRow(dsThucDon.Tables[1], i);
            Kq[i] = (ThucDonDTO)thuc_don;
        }

        Disconnect();
        return Kq;
    }

    public ThucDonDTO[] TimKiemThucDonNangCao(string ten_thuc_don, int ma_loai_thuc_don, string tag, double gia_min, double gia_max)
    {
        Connect();
        ThucDonDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spTimKiemNangCao", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
        cmd.Parameters["@ten"].Value = ten_thuc_don;
        cmd.Parameters.Add("@ma_loai", SqlDbType.Int);
        cmd.Parameters["@ma_loai"].Value = ma_loai_thuc_don;
        cmd.Parameters.Add("@tag", SqlDbType.NVarChar, 50);
        cmd.Parameters["@tag"].Value = tag;
        cmd.Parameters.Add("@gia_min", SqlDbType.Money);
        cmd.Parameters["@gia_min"].Value = gia_min;
        cmd.Parameters.Add("@gia_max", SqlDbType.Money);
        cmd.Parameters["@gia_max"].Value = gia_max;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable tab = new DataTable();
        DataSet dsThucDon = new DataSet();
        da.Fill(dsThucDon, "THUC_DON");

        int n = dsThucDon.Tables[1].Rows.Count;
        Kq = new ThucDonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object thuc_don = GetDataFromDataRow(dsThucDon.Tables[1], i);
            Kq[i] = (ThucDonDTO)thuc_don;
        }

        Disconnect();
        return Kq;
    }
    public int TongSoThucDon()
    {
        SqlCommand cmd = CreateCommandStored("spTongSoThucDon",
            new string[] { },
            new object[] { });
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }
    
    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(ThucDonDTO), dt.Rows[i]);
    }

    public bool CapNhatTinhTrang(bool tinhTrang, int maThucDon)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatTinhTrangThucDon",
             new string[] { "@maThucDon", "@tinhTrang" },
             new object[] { maThucDon, tinhTrang});
        return ExecuteNonQuery(cmd);
    }
    public bool CapNhatTrangThaiHienThi(bool trangThai, int maThucDon)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatTrangThaiHienThiThucDon",
             new string[] { "@maThucDon", "@trangThai" },
             new object[] { maThucDon, trangThai });
        return ExecuteNonQuery(cmd);
    }
    public bool XoaThucDon(int maThucDon)
    {
        SqlCommand cmd = CreateCommandStored("spXoaThucDon",
             new string[] { "@maThucDon"},
             new object[] { maThucDon});
        return ExecuteNonQuery(cmd);
    }
}
