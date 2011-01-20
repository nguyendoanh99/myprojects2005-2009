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
/// Summary description for LoaiMonDAO
/// </summary>
public class LoaiMonDAO : AbstractDAO
{
    public LoaiMonDTO[] LayDanhSachLoaiMon()
    {
        LoaiMonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiMonLa", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiMonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiMonDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    public LoaiMonDTO[] LayDanhSachLoaiMonGoc()
    {
        LoaiMonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDSLoaiMonGoc", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiMonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiMonDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    public LoaiMonDTO[] DanhSachLoaiMon()
    {
        LoaiMonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiMonAn", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiMonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiMonDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    public LoaiMonDTO[] DanhSachLoaiMonLa()
    {
        LoaiMonDTO[] Kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spLayDanhSachLoaiMonLa", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

        int i = 0;
        int n = dt.Rows.Count;
        Kq = new LoaiMonDTO[n];

        for (i = 0; i < n; ++i)
        {
            object loaithe = GetDataFromDataRow(dt, i);
            Kq[i] = (LoaiMonDTO)loaithe;
        }

        Disconnect();
        return Kq;
    }

    public LoaiMonDTO[] DanhSachLoaiMonCon(int MaLMCha)
    {
        LoaiMonDTO[] kq;

        Connect();
        SqlCommand cmd = new SqlCommand("spDanhSachLoaiMonCon", cnn);

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@malmcha", SqlDbType.Int);
        cmd.Parameters["@malmcha"].Value = MaLMCha;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        int n = tab.Rows.Count;
        kq = new LoaiMonDTO[n];

        for (int i = 0; i < n; ++i)
        {
            object loaimon = GetDataFromDataRow(tab, i);
            kq[i] = (LoaiMonDTO)loaimon;
        }

        Disconnect();
        return kq;
    }

    public bool ThemLoaiMon(LoaiMonDTO lmDto)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spThemLoaiMon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@tenloaimon", SqlDbType.NVarChar);
        cmd.Parameters.Add("@maloaimoncha", SqlDbType.Int);
        cmd.Parameters.Add("@laloaimonla", SqlDbType.Bit);

        cmd.Parameters["@tenloaimon"].Value = lmDto.Ten_loai_mon;
        cmd.Parameters["@maloaimoncha"].Value = lmDto.Ma_loai_mon_cha;
        cmd.Parameters["@laloaimonla"].Value = lmDto.La_loai_mon_la;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return false;
        }

        Disconnect();
        return true;
    }

    public bool XoaLoaiMon(int maloaimon)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spXoaLoaiMon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@maloaimon", SqlDbType.Int);
        cmd.Parameters["@maloaimon"].Value = maloaimon;

        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Disconnect();
            return false;
        }

        Disconnect();
        return true;
    }

    public LoaiMonDTO ChiTietLoaiMon(int maloaimon)
    {
        Connect();

        SqlCommand cmd = new SqlCommand("spChiTietLoaiMon", cnn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add("@ma_loai_mon", SqlDbType.Int);
        cmd.Parameters["@ma_loai_mon"].Value = maloaimon;

        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable tab = new DataTable();
        da.Fill(tab);

        LoaiMonDTO kq = new LoaiMonDTO();

        object loaimon = GetDataFromDataRow(tab, 0);
        kq = (LoaiMonDTO)loaimon;

        Disconnect();
        return kq;
    }

    protected override object GetDataFromDataRow(DataTable dt, int i)
    {
        LoaiMonDTO loaimon = new LoaiMonDTO();

        loaimon.Ma_loai_mon = (int)dt.Rows[i]["MaLoaiMon"];
        loaimon.Ten_loai_mon = dt.Rows[i]["TenLoaiMon"].ToString();

        if (dt.Rows[i]["MaLoaiMonCha"].ToString() == "") //neu la loai mon goc, ko co cha
            loaimon.Ma_loai_mon_cha = -1;
        else
            loaimon.Ma_loai_mon_cha = (int)dt.Rows[i]["MaLoaiMonCha"];

        loaimon.La_loai_mon_la = (bool)dt.Rows[i]["LaLoaiMonLa"];

        return (object)loaimon;
    } 

}
