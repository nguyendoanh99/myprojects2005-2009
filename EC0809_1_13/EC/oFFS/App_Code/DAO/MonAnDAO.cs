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
using System.Collections;

/// <summary>
/// Summary description for MonAnDAO
/// </summary>
public class MonAnDAO : AbstractDAO
{
    public int ThemMonAn(MonAnDTO monan, String strTag)
    {
        int Kq = 0; //mã món ăn
        Connect();

        SqlCommand cmd = new SqlCommand("spThemMonAn", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tenmon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@hinhanhminhhoa", SqlDbType.NVarChar);
        cmd.Parameters.Add("@mota", SqlDbType.Text);
        cmd.Parameters.Add("@diembinhchon", SqlDbType.Int);
        cmd.Parameters.Add("@donvitinh", SqlDbType.NVarChar);
        cmd.Parameters.Add("@gia", SqlDbType.Money);
        cmd.Parameters.Add("@maloaimon", SqlDbType.Int);
        cmd.Parameters.Add("@tinhtrang", SqlDbType.Bit);
        cmd.Parameters.Add("@trangthaihienthi", SqlDbType.Bit);

        cmd.Parameters["@tenmon"].Value = monan.Ten_mon;
        cmd.Parameters["@hinhanhminhhoa"].Value = monan.Hinh_anh_minh_hoa;
        cmd.Parameters["@mota"].Value = monan.Mo_ta;
        cmd.Parameters["@diembinhchon"].Value = monan.Diem_binh_chon;
        cmd.Parameters["@donvitinh"].Value = monan.Don_vi_tinh;
        cmd.Parameters["@gia"].Value = monan.Gia;
        cmd.Parameters["@maloaimon"].Value = monan.Ma_loai_mon;
        cmd.Parameters["@tinhtrang"].Value = monan.Tinh_trang;
        cmd.Parameters["@trangthaihienthi"].Value = monan.Trang_thai_hien_thi;

        cmd.Parameters.Add("@mamon", SqlDbType.Int);
        cmd.Parameters["@mamon"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            int mamon = int.Parse(cmd.Parameters["@mamon"].Value.ToString());
            Kq = mamon;
            Disconnect();            
            String[] dsTag = TagDAO.XuLyChuoiTag(strTag);
            TagDTO tagDTO = new TagDTO();
            TagMonAnDTO tagmonanDTO = new TagMonAnDTO();
            tagmonanDTO.Ma_mon = mamon;

            for (int i = 0; i < dsTag.Length; ++i)
            {
                TagDAO tag = new TagDAO();
                tagDTO.Ten_tag = dsTag[i];
                int matag = tag.ThemTag(tagDTO);

                tagmonanDTO.Ma_tag = matag;
                (new TagMonAnDAO()).ThemTagMonAn(tagmonanDTO);
            }
        }
        catch (SqlException ex)
        {
            Disconnect();
            throw ex;
        }

        return Kq;
    }


    public MonAnDTO[] DanhSachMonAn(int pageNum, int pageSize)
    {
        SqlCommand cmd = CreateCommandStored("spLayDanhSachMonAn",
            new string[] { "@pageNum", "@pageSize" },
            new object[] { pageNum, pageSize });
        MonAnDTO[] kq = (MonAnDTO[])LayDanhSach(typeof(MonAnDTO), cmd);
        return kq;
    }

    public MonAnDTO[] LayDSQuaTang(double gia)
    {
        MonAnDTO[] kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachQuaTang", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@gia", SqlDbType.Money);
        cmd.Parameters["@gia"].Value = gia;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return kq;
    }

    public MonAnDTO[] LayDSMonAnHienThi(int pageNum, int pageSize)
    {
        MonAnDTO[] kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSMonAnHienThi", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@pageNum", SqlDbType.Int);
        cmd.Parameters.Add("@pageSize", SqlDbType.Int);

        cmd.Parameters["@pageNum"].Value = pageNum;
        cmd.Parameters["@pageSize"].Value = pageSize;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return kq;
    }

    public int TongSoMonAn()
    {
        SqlCommand cmd = CreateCommandStored("spLayTongSoMonAn",
            new string[] { },
            new object[] { });
        int kq = (int)ExecuteScalar(cmd);
        return kq;
    }

    public MonAnDTO ChiTietMonAn(int ma_mon)
    {
        SqlCommand cmd = CreateCommandStored("spLayThongTinMonAn",
            new string[] { "@maMon" },
            new object[] { ma_mon });
        MonAnDTO[] kq = (MonAnDTO[])LayDanhSach(typeof(MonAnDTO), cmd);
        if (kq.Length == 0)
            return null;
        return kq[0];
    }

    public int TinhSoLuongMonAnThuocLoaiMon(int maloaimon)
    {
        Connect();
        int Kq;

        SqlCommand cmd = new SqlCommand("spTinhSoLuongMonAnThuocLoaiMon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maloaimon", SqlDbType.Int);
        cmd.Parameters["@maloaimon"].Value = maloaimon;

        cmd.Parameters.Add("@soluong", SqlDbType.Int);
        cmd.Parameters["@soluong"].Direction = ParameterDirection.Output;

        try
        {
            cmd.ExecuteNonQuery();
            Kq = (int)cmd.Parameters["@soluong"].Value;
        }
        catch (SqlException ex)
        {
            Disconnect();
            return -1;
        }

        Disconnect();
        return Kq;
    }

    public MonAnDTO[] DSMonAnThuocLoaiMon(int maloaimon)
    {
        Connect();
        MonAnDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spLayDSMonAnThuocLoaiMon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ma_loai_mon", SqlDbType.Int);
        cmd.Parameters["@ma_loai_mon"].Value = maloaimon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        Kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(tab, i);
            Kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return Kq;
    }

    public MonAnDTO[] TimKiemMonAnTheoTen(string ten_mon)
    {
        Connect();
        MonAnDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spTimKiemTheoTen", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
        cmd.Parameters["@ten"].Value = ten_mon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable tab = new DataTable();
        DataSet dsMonAn = new DataSet();
        da.Fill(dsMonAn, "MON_AN");

        int n = dsMonAn.Tables[0].Rows.Count;
        Kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(dsMonAn.Tables[0], i);
            Kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return Kq;
    }

    public MonAnDTO[] TimKiemMonAnNangCao(string ten_mon, int ma_loai_mon, string tag, double gia_min, double gia_max)
    {
        Connect();
        MonAnDTO[] Kq;

        SqlCommand cmd = new SqlCommand("spTimKiemNangCao", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 50);
        cmd.Parameters["@ten"].Value = ten_mon;
        cmd.Parameters.Add("@ma_loai", SqlDbType.Int);
        cmd.Parameters["@ma_loai"].Value = ma_loai_mon;
        cmd.Parameters.Add("@tag", SqlDbType.NVarChar, 50);
        cmd.Parameters["@tag"].Value = tag;
        cmd.Parameters.Add("@gia_min", SqlDbType.Money);
        cmd.Parameters["@gia_min"].Value = gia_min;
        cmd.Parameters.Add("@gia_max", SqlDbType.Money);
        cmd.Parameters["@gia_max"].Value = gia_max;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //DataTable tab = new DataTable();
        DataSet dsMonAn = new DataSet();
        da.Fill(dsMonAn, "MON_AN");

        int n = dsMonAn.Tables[0].Rows.Count;
        Kq = new MonAnDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object mon_an = GetDataFromDataRow(dsMonAn.Tables[0], i);
            Kq[i] = (MonAnDTO)mon_an;
        }

        Disconnect();
        return Kq;
    }

    //LẤY DANH SÁCH MÓN ĂN CỦA 1 LOẠI MÓN BẤT KÌ, KHÔNG CẦN PHẢI LÀ LOẠI MÓN LÁ
    public ArrayList LayDSMonAnThuocLoaiMonBatKy(int maloaimon)
    {
        Connect();
        ArrayList Kq = new ArrayList();

        SqlCommand cmd = new SqlCommand("spLayDSMonAnThuocLoaiMonBatKy", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maloaimon", SqlDbType.Int);
        cmd.Parameters["@maloaimon"].Value = maloaimon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);

        for (int j = 0; j < ds.Tables.Count; ++j)
        {
            DataTable dt = ds.Tables[j];
            int n = dt.Rows.Count;

            for (int i = 0; i < n; ++i)
            {
                object mon_an = GetDataFromDataRow(dt, i);
                Kq.Add((MonAnDTO)mon_an);
            }
        }
        Disconnect();
        return Kq;
    }


    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        return CreateDTOFromDataRow(typeof(MonAnDTO), dt.Rows[i]);
    }

    public bool CapNhatTinhTrang(bool tinhTrang, int maMonAn)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatTinhTrangMonAn",
             new string[] { "@maMon", "@tinhTrang" },
             new object[] { maMonAn, tinhTrang });
        return ExecuteNonQuery(cmd);
    }

    internal bool CapNhatTrangThaiHienThi(bool trangThai, int maMonAn)
    {
        SqlCommand cmd = CreateCommandStored("spCapNhatTrangThaiHienThiMonAn",
             new string[] { "@maMon", "@trangThai" },
             new object[] { maMonAn, trangThai });
        return ExecuteNonQuery(cmd);
    }

    internal bool XoaMonAn(int maMonAn)
    {
        SqlCommand cmd = CreateCommandStored("spXoaMonAn",
             new string[] { "@maMon" },
             new object[] { maMonAn });
        return ExecuteNonQuery(cmd);
    }
}
